using AOS.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AOS.Models.IdentityModels
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser<int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>, IUser<int>
    {
        //personal data area
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Title Title { get; set; }
        public Language Language { get; set; }
        public string JobTitle { get; set; }


        //public OrganizationTypes OrganizationCategory { get; set; }
        //organization data
        public string OrganizationName { get; set; }
        public OrganizationTypes OrganizationType { get; set; }
        public Countries Country { get; set; }

        //mailing address
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, int> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
