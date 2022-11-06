using APC.DAL.DataAccess;
using APC.WebUI.Authentication.EventHandlers;
using APC.WebUI.Configuration;
using Blazored.Modal;
using Blazored.Toast;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Microsoft.IdentityModel.Logging;
using System.IdentityModel.Tokens.Jwt;

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
                        OnTicketReceived = async context =>
                        {
                            var serviceProvider = builder.Services.BuildServiceProvider();
                            var onTicketReceived = serviceProvider.GetService<IOnTicketReceived>();
                            await onTicketReceived.Execute(context);
                        }
                    };
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        NameClaimType = "name", //doesn't work
                        RoleClaimType = "roles"
                    };
                });

            //set claims to use shortened names
            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

            builder.Services.AddControllersWithViews()
                .AddMicrosoftIdentityUI();

            builder.Services.AddAuthorization(options =>
            {
                // By default, all incoming requests will be authorized according to the default policy
                options.FallbackPolicy = options.DefaultPolicy;

                //this is not required, you can just use roles, unless you want policy based authentication to allow multiple requirements
                //var authAdminRequirement = new RolesAuthorizationRequirement(new string[] { "admin" });
                //options.AddPolicy("admin-policy", policy =>
                //    policy.Requirements.Add(authAdminRequirement));
            });

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor()
                .AddMicrosoftIdentityConsentHandler();
            //to display errors in hosted site
            //.AddCircuitOptions(options => { options.DetailedErrors = true; });

            builder.Services.AddDbContextFactory<APCContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("default")));

            builder.Services.AddHttpContextAccessor();
            
            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddBlazoredToast();
            builder.Services.AddBlazoredModal();

            builder.Services.AddDalRepositories();
            builder.Services.AddDalServices();
            
            builder.Services.AddTransient<IOnTicketReceived, OnTicketReceived>();

            var app = builder.Build();

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
    }
}