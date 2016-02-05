using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace TVS.WebApp.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

          
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<AddressOccupation> AddressOccupations { get; set; }
        public virtual DbSet<AddressOwnership> AddressOwnerships { get; set; }
      
        public virtual DbSet<DomainAspnetPersonMap> DomainAspnetPersonMaps { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<PersonAttribute> PersonAttributes { get; set; }
        public virtual DbSet<PersonRating> PersonRatings { get; set; }
        public virtual DbSet<RatingBreakdown> RatingBreakdowns { get; set; }
        public virtual DbSet<RoleAttribute> RoleAttributes { get; set; }
        public virtual DbSet<RoleParameter> RoleParameters { get; set; }

    }
}
