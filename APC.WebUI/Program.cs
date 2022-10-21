using APC.DAL.DataAccess;
using APC.DAL.Repositories;
using APC.WebUI.Models;
using APC.WebUI.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Microsoft.IdentityModel.Logging;
using System.Linq.Dynamic.Core;
using System.Security.Claims;

namespace APC.WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApp(options =>
                {
                    builder.Configuration.Bind("AzureAd", options);

                    options.Events = new OpenIdConnectEvents
                    {
                        OnTicketReceived = async ctxt => 
                        { 
                            await OnTicketReceived(ctxt, builder);
                        }
                    };
                });

            builder.Services.AddControllersWithViews()
                .AddMicrosoftIdentityUI();

            builder.Services.AddAuthorization(options =>
            {
                // By default, all incoming requests will be authorized according to the default policy
                options.FallbackPolicy = options.DefaultPolicy;

                //TODO: configurate admin authorization
                var authAdminRequirement = new RolesAuthorizationRequirement(new string[] { "Admin" });
                options.AddPolicy("admin-policy", policy =>
                    policy.Requirements.Add(authAdminRequirement));
            });

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor()
                .AddMicrosoftIdentityConsentHandler();
            //to display errors in hosted site
            //.AddCircuitOptions(options => { options.DetailedErrors = true; });

            builder.Services.AddDbContextFactory<APCContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("default")));

            //scoped service isn't ideal for blazor apps
            //builder.Services.AddDbContext<APCContext>(options =>
            //{
            //    options.UseSqlServer();
            //});

            builder.Services.AddTransient<IProductRepository, ProductRepository>();
            builder.Services.AddTransient<IProductService, ProductService>();
            builder.Services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            builder.Services.AddTransient<IProductCategoryService, ProductCategoryService>();
            builder.Services.AddTransient<IProductTypeRepository, ProductTypeRepository>();
            builder.Services.AddTransient<IProductTypeService, ProductTypeService>();
            builder.Services.AddTransient<IFileUploadService, AzureBlobFileUploadService>();
            builder.Services.AddTransient<ISimilarProductsRepository, SimilarProductsRepository>();
            builder.Services.AddTransient<ISimilarProductsService, SimilarProductsService>();

            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddHttpContextAccessor();

            var app = builder.Build();

            //wheeee...
            var apcContext = app.Services.GetService<IDbContextFactory<APCContext>>();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            if (app.Environment.IsDevelopment())
            {
                IdentityModelEventSource.ShowPII = true;
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }

        private static async Task OnTicketReceived(
            TicketReceivedContext ctxt,
            WebApplicationBuilder builder)
        {
            if (ctxt.Principal == null
                || ctxt.Principal.Identity is not ClaimsIdentity identity)
            {
                await Task.Yield();
                return;
            }

            var authClaims = await GetAuthClaims(ctxt.Principal.Claims);

            var optionsBuilder = new DbContextOptionsBuilder<APCContext>();
            optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("default"));
            APCContext dbContext = new APCContext(optionsBuilder.Options);

            var account = dbContext.Account
                .FirstOrDefault(a => a.Email.ToLower() == (authClaims.EmailAddress ?? "").ToLower());

            if (account is null)
            {
                //user is invalid, only users who have an account in the system
                //matching email can access the site.
                //TODO: sign out user and display error message
                return;
            }
            
            var isMissingOID = account is not null 
                && string.IsNullOrEmpty(account.ObjectIdentifier);
            if (isMissingOID)
            {
                account.ObjectIdentifier = authClaims.Objectidentifier;
                dbContext.SaveChanges();
            }

            await Task.Yield();
        }

        private static async Task<AuthClaims> GetAuthClaims(IEnumerable<Claim> claims)
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

            authClaims.FirstName = colClaims.FirstOrDefault(
                c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname")?.Value;

            authClaims.LastName = colClaims.FirstOrDefault(
                c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname")?.Value;

            authClaims.AzureB2CFlow = colClaims.FirstOrDefault(
                c => c.Type == "http://schemas.microsoft.com/claims/authnclassreference")?.Value;

            authClaims.auth_time = colClaims.FirstOrDefault(
                c => c.Type == "auth_time")?.Value;

            authClaims.DisplayName = colClaims.FirstOrDefault(
                c => c.Type == "name")?.Value;

            authClaims.idp_access_token = colClaims.FirstOrDefault(
                c => c.Type == "idp_access_token")?.Value;

            return authClaims;
        }
    }
}