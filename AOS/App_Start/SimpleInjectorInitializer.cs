using AOS;
using AOS.DbAccess;
using AOS.Models.IdentityModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.DataProtection;
using Owin;
using SimpleInjector;
using SimpleInjector.Advanced;
using SimpleInjector.Diagnostics;
using SimpleInjector.Integration.Web;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using AOS.Services;
using System.Web.Http;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Integration.Web.Mvc;

namespace AOC
{
    public static class SimpleInjectorInitializer
    {
        public static Container Initialize(IAppBuilder app)
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            InitializeContainer(container, app);

            //container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            SuppressWarnings(container);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

            return container;
        }

        private static void InitializeContainer(Container container, IAppBuilder app)
        {
            // Singletons
            container.RegisterSingleton(app);

            // DB Contexts
            container.Register<ApplicationDbContext>(Lifestyle.Scoped);

            // Repositories
            //container.Register(typeof(IRepository<>), typeof(Repository<>));

            // Services
            container.Register<IMailService, MailService>();

            // ASP.NET Identity
            container.Register<ApplicationUserManager>();

            container.Register<IUserStore<ApplicationUser, int>>(() =>
                new UserStore<ApplicationUser, ApplicationRole, int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>(container.GetInstance<ApplicationDbContext>()));

            container.RegisterInitializer<ApplicationUserManager>(
                manager => InitializeUserManager(manager, app));

            container.Register<ApplicationSignInManager>();

            container.Register(() =>
                AdvancedExtensions.IsVerifying(container)
                    ? new OwinContext(new Dictionary<string, object>()).Authentication
                    : HttpContext.Current.GetOwinContext().Authentication);

            container.Register<ApplicationRoleManager>();

            container.Register<IRoleStore<ApplicationRole, int>>(() =>
                new RoleStore<ApplicationRole, int, ApplicationUserRole>(container.GetInstance<ApplicationDbContext>()));

            // For instance:
            // container.Register<IUserRepository, SqlUserRepository>(Lifestyle.Scoped);
        }

        private static void SuppressWarnings(Container container)
        {
            container.GetRegistration(typeof(ApplicationUserManager)).Registration
                .SuppressDiagnosticWarning(DiagnosticType.DisposableTransientComponent, "Dependencies are not disposable.");
            container.GetRegistration(typeof(IUserStore<ApplicationUser, int>)).Registration
                .SuppressDiagnosticWarning(DiagnosticType.DisposableTransientComponent, "Dependencies are not disposable.");
            container.GetRegistration(typeof(ApplicationSignInManager)).Registration
                .SuppressDiagnosticWarning(DiagnosticType.DisposableTransientComponent, "Dependencies are not disposable.");
            container.GetRegistration(typeof(ApplicationRoleManager)).Registration
                .SuppressDiagnosticWarning(DiagnosticType.DisposableTransientComponent, "Dependencies are not disposable.");
            container.GetRegistration(typeof(IRoleStore<ApplicationRole, int>)).Registration
                .SuppressDiagnosticWarning(DiagnosticType.DisposableTransientComponent, "Dependencies are not disposable.");
        }

        private static void InitializeUserManager(
            ApplicationUserManager manager, IAppBuilder app)
        {
            manager.UserValidator = new UserValidator<ApplicationUser, int>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            //manager.PasswordValidator = new PasswordValidator
            //{
            //    RequiredLength = 8,
            //    RequireNonLetterOrDigit = false,
            //    RequireDigit = true,
            //    RequireLowercase = false,
            //    RequireUppercase = false,
            //};

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<ApplicationUser, int>
            {
                MessageFormat = "Your security code is {0}"
            });
            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<ApplicationUser, int>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });
            manager.EmailService = new EmailService();
            //manager.SmsService = new SmsService();
            var dataProtectionProvider = app.GetDataProtectionProvider();
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<ApplicationUser, int>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
        }
    }
}