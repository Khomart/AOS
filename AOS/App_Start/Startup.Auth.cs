using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;
//using System.ComponentModel;
using AOS.DbAccess;
using AOS.Models;
using SimpleInjector;
using AOS.Models.IdentityModels;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AOS
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app, Container container)
        {
            // Configure the db context, user manager and signin manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            //app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext(container.GetInstance<ApplicationUserManager>);

            //app.CreatePerOwinContext(() => container.GetInstance<ApplicationUserManager>());

            //app.CreatePerOwinContext(() => container.GetInstance<ApplicationUserManager>());
            //app.CreatePerOwinContext(() => container.GetInstance<ApplicationSignInManager>());
            //app.CreatePerOwinContext(() => container.GetInstance<ApplicationRoleManager>());

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            // Configure the sign in cookie
            CookieAuthenticationOptions cookieOptions = new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    // Enables the application to validate the security stamp when the user logs in.
                    // This is a security feature which is used when you change a password or add an external login to your account.  
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser, int>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentityCallback: (manager, user) => user.GenerateUserIdentityAsync(manager),
                        getUserIdCallback: (claim) => int.Parse(claim.GetUserId()))
                }
            };

            app.UseCookieAuthentication(cookieOptions);
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Enables the application to remember the second login verification factor such as phone or email.
            // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
            // This is similar to the RememberMe option when you log in.
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            //app.UseFacebookAuthentication(
            //   appId: "000-000.apps.facebook.com",
            //   appSecret: "00000000000");

            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "000-000.apps.googleusercontent.com",
            //    ClientSecret = "00000000000"
            //});

            // Enable Mixed Authentication
            //app.UseMixedAuth(new MixedAuthOptions()
            //{
            //    AuthenticationType = "ICAO Portal",
            //    Caption = "ICAO Portal",
            //    Provider = new MixedAuthProvider()
            //    {
            //        OnImportClaims = identity =>
            //        {
            //            List<Claim> claims = new List<Claim>();

            //            // Get user info from Active Directory
            //            using (var principalContext = new PrincipalContext(ContextType.Domain, ConfigurationManager.AppSettings["LDAP.Domain"]))
            //            {
            //                using (UserPrincipal userPrincipal = UserPrincipal.FindByIdentity(principalContext, identity.Name))
            //                {
            //                    if (userPrincipal != null)
            //                    {
            //                        claims.Add(new Claim(ClaimTypes.Email, userPrincipal.EmailAddress ?? string.Empty));
            //                        claims.Add(new Claim(ClaimTypes.GivenName, userPrincipal.GivenName ?? string.Empty));
            //                        claims.Add(new Claim(ClaimTypes.Surname, userPrincipal.Surname ?? string.Empty));
            //                    }
            //                }
            //            }

            //            return claims;
            //        }
            //    }
            //}, cookieOptions);
            AddUserAndRoles();

        }
        private void AddUserAndRoles()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole, int,ApplicationUserRole>(context));
            var UserManager = new ApplicationUserManager(new UserStore<ApplicationUser, ApplicationRole, int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>(context));
            if (!roleManager.RoleExists("Admin"))
            {
                // first we create Admin rool    
                var role = new ApplicationRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                   

                var user = new ApplicationUser();
                user.UserName = "shanu";
                user.Email = "syedshanumcain@gmail.com";

                string userPWD = "A@Z200711";


                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin    
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");

                }
            }
            // creating Creating Manager role     
            if (!roleManager.RoleExists("State"))
            {
                var role = new ApplicationRole();
                role.Name = "State";
                roleManager.Create(role);

            }

            // creating Creating Employee role     
            if (!roleManager.RoleExists("Operator"))
            {
                var role = new ApplicationRole();
                role.Name = "Operator";
                roleManager.Create(role);

            }
        }
    }
}