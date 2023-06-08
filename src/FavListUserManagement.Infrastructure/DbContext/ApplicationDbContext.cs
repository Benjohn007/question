using FavListUserManagement.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace FavListUserManagement.Infrastructure.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<UserRole> Roles { get; set; } 
        public DbSet<SignUp> SignUps { get; set; }
        public DbSet<RoleFeature> RoleFeatures { get; set; }
        public DbSet<PortalFeature> PortalFeatures { get; set; }
        public DbSet<QuestionDefaultParameter> QuestionDefaultParameters { get; set; }
        public DbSet<Catergory> Catergories { get; set;}
    }
}
