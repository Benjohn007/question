using FavListUserManagement.Domain.DTO;
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
        public DbSet<RoleFeature> RoleFeatures { get; set; }
        public DbSet<PortalFeature> PortalFeatures { get; set; }
        public DbSet<QuestionDefaultParameter> QuestionDefaultParameters { get; set; }
        public DbSet<Catergory> Catergories { get; set;}

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries<BaseEntity>())
            {
                switch (item.State)
                {
                    case EntityState.Modified:
                        item.Entity.Last_Modified = DateTime.UtcNow;
                        break;
                    case EntityState.Deleted:
                        //item.Entity.IsDeleted = true;
                        break;
                    case EntityState.Added:
                        item.Entity.Id = Guid.NewGuid().ToString();
                        item.Entity.Created_Date = DateTime.UtcNow;
                        break;
                    default:
                        break;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
