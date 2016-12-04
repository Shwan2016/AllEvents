using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace AllEvents.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Attendance> Attendances { get; set; } 

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>()
                .HasRequired(a => a.Event)
                .WithMany()
                 .WillCascadeOnDelete(false );

            base.OnModelCreating(modelBuilder);
        }
    }
}