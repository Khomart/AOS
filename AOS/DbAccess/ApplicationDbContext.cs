using AOS.Models.IdentityModels;
using AOS.Models.UserEntities;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace AOS.DbAccess
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<State> States { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Operator> Operator { get; set; }

    }
}
