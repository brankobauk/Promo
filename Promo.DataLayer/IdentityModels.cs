using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Promo.Model.Models;
using System.Data.Entity.ModelConfiguration.Conventions;
using Promo.DataLayer.Migrations;

namespace Promo.DataLayer
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("PromoContext", throwIfV1Schema: false)
        {
            Database.SetInitializer<ApplicationDbContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Company> Company { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Promotion> Promotion { get; set; }
        public DbSet<PromotionBrand> PromotionBrand { get; set; }
        public DbSet<PromotionProduct> PromotionProduct { get; set; }
        public DbSet<Store> Store { get; set; }
        public DbSet<PromotionStore> PromotionStore { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Error> Error { get; set; }

    }
}