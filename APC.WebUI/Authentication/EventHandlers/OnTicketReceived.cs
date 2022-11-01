using APC.DAL.DataAccess;
using APC.DAL.Models;
using APC.WebUI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Security.Claims;

namespace APC.WebUI.Authentication.EventHandlers
{
    public class OnTicketReceived : IOnTicketReceived
    {
        private readonly IDbContextFactory<APCContext> dbContextFactory;

        public OnTicketReceived(IDbContextFactory<APCContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task Execute(TicketReceivedContext context)
        {
            if (context == null || context.Principal == null
                || context.Principal.Identity is not ClaimsIdentity identity)
            {
                await Task.Yield();
                return;
            }

            var principal = context.Principal;
            var dbContext = await this.dbContextFactory.CreateDbContextAsync();
            var authClaims = await GetAuthClaims(principal.Claims);

            var account = dbContext.Account
                .FirstOrDefault(a => a.Email.ToLower() == (authClaims.EmailAddress ?? "").ToLower());

            account = this.SaveAccount(dbContext, account, authClaims);

            this.CreateShoppingCart(dbContext, account.Id);

            this.AddRoleClaims(dbContext, principal, account);
        }

        private async Task<AuthClaims> GetAuthClaims(IEnumerable<Claim> claims)
        {
            AuthClaims authClaims = new AuthClaims();

            var colClaims = await claims.ToDynamicListAsync();

            authClaims.IdentityProvider = colClaims.FirstOrDefault(
                c => c.Type == "http://schemas.microsoft.com/identity/claims/identityprovider")?.Value;

            authClaims.Objectidentifier = colClaims.FirstOrDefault(
                c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;

            authClaims.EmailAddress = colClaims.FirstOrDefault(
                c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;

            if (string.IsNullOrEmpty(authClaims.EmailAddress))
            {
                authClaims.EmailAddress = colClaims.FirstOrDefault(
                c => c.Type == "emails")?.Value;
            }

            authClaims.auth_time = colClaims.FirstOrDefault(
                c => c.Type == "auth_time")?.Value;

            authClaims.DisplayName = colClaims.FirstOrDefault(
                c => c.Type == "name")?.Value;

            authClaims.idp_access_token = colClaims.FirstOrDefault(
                c => c.Type == "idp_access_token")?.Value;

            return authClaims;
        }

        private Account SaveAccount(APCContext dbContext, Account account, AuthClaims authClaims)
        {
            if (account is null)
            {
                //ideally...
                //user is invalid, only users who have an account in the system
                //matching email can access the site.
                //TODO: sign out user and display error message
                //return;

                //or create a new account while testing?
                var newAccount = new Account
                {
                    Email = authClaims.EmailAddress,
                    DisplayName = authClaims.DisplayName,
                    FirstName = authClaims.FirstName,
                    LastName = authClaims.LastName,
                    ObjectIdentifier = authClaims.Objectidentifier,
                };

                dbContext.Account.Add(newAccount);
                dbContext.SaveChanges();

                return newAccount;
            }

            var isMissingOID = account is not null
                && string.IsNullOrEmpty(account.ObjectIdentifier);
            if (isMissingOID)
            {
                account.ObjectIdentifier = authClaims.Objectidentifier;
                dbContext.SaveChanges();
            }

            return account;
        }

        private void CreateShoppingCart(APCContext dbContext, int accountId)
        {
            var cart = dbContext.Cart
                .FirstOrDefault(c => c.AccountId == accountId && !c.Completed);
            if (cart is null)
            {
                var newCart = new Cart { AccountId = accountId };
                dbContext.Cart.Add(newCart);
                dbContext.SaveChanges();
            }
        }

        private void AddRoleClaims(APCContext dbContext, ClaimsPrincipal principal, Account account)
        {
            var accountId = account.Id;
            var rolesFromDB = dbContext.Role
                .Where(r => r.Accounts.Any(a => a.Id == accountId))
                .ToList();

            if (rolesFromDB.Any())
            {
                var roles = string.Join(",", rolesFromDB.Select(r => r.Name));

                var rolesClaimType = "roles";
                var newClaims = new List<Claim> { new Claim(rolesClaimType, roles) };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                    claims: newClaims, 
                    authenticationType: "AuthenticationTypes.Federation", 
                    nameType: "name", 
                    roleType: rolesClaimType
                );

                principal.AddIdentity(claimsIdentity);
            }
        }
    }
}
