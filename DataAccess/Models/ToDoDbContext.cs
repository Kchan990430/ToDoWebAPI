using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDoWebAPI.BusinessEntity;

namespace ToDoWebAPI.DataAccess.Models
{
    public class ToDoDbContext : IdentityDbContext<User>
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options)
        {
        }

        public DbSet<ToDoItem> ToDoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Customize the identity tables, if needed
            // For example, changing table names or adding indexes

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");

            modelBuilder.Entity<ToDoItem>(entity =>
            {
                entity.Property(e => e.Id)
                .HasMaxLength(100);

                entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

                entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(500);

                entity.Property(e => e.DueDate)
                .HasDefaultValue(DateTime.Now);

                entity.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(50);
            });


            base.OnModelCreating(modelBuilder);
        }
    }
}
