using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using University_Project.Model;

namespace University_Project.Data
{
    public class AppDbContext : IdentityDbContext<User, Role, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            List<Role> roles = new List<Role>
            {
                new Role
                {
                    Id = 1,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                },
                new Role
                {
                    Id = 2,
                    Name = "Manager",
                    NormalizedName = "MANAGER"
                },
                new Role
                {
                    Id = 3,
                    Name = "User",
                    NormalizedName = "USER"
                }
            };
            builder.Entity<Role>().HasData(roles);

            builder.Entity<User>(b =>
            {
                b.ToTable("User");
                b.Property(user => user.Email).IsRequired(false);
                b.Property(e => e.UserName).HasColumnName("FullName");
                b.Property(e => e.NormalizedUserName).HasColumnName("NormalizedFullName");
                b.Property(e => e.PasswordHash).IsRequired(false);
                b.Property(e => e.PhoneNumber).IsRequired(true);
            });
            builder.Entity<Role>(b =>
            {
                b.ToTable("Role");
            });
        }
        public DbSet<User> users { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<CourseContent> coursesContent { get; set; }
        public DbSet<CourseType> coursesType { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Logo> logos { get; set; }
        public DbSet<RollCall> rollCalls { get; set; }
        public DbSet<UserCourseSignup> userCourseSignups { get; set; }
        public DbSet<UserCourseFavorite> userCourseFavorite { get; set; }
    }
}
