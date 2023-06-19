using FavListUserManagement.Domain.DTO;
using FavListUserManagement.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FavListUserManagement.Infrastructure.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //public DbSet<UserRole>? Roles { get; set; } 
        public DbSet<RoleFeature>? RoleFeatures { get; set; }
        public DbSet<PortalFeature>? PortalFeatures { get; set; }
        public DbSet<QuestionDefaultParameter>? QuestionDefaultParameters { get; set; }
        public DbSet<Category>? Catergorys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Sponsor>? Sponsors { get; set; }


        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);

        //    builder.Entity<Question>(x =>
        //    {
        //        x.HasKey(y => y.Id);
        //        x.Property(y => y.Answer)
        //            .HasConversion(
        //                from => string.Join(";", from),
        //                to => string.IsNullOrEmpty(to) ? new List<string>() : to.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList(),
        //                new ValueComparer<List<string>>(
        //                    (c1, c2) => c1.SequenceEqual(c2),
        //                    c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
        //                    c => c.ToList()
        //            )
        //        );
        //    });
        //}
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
                        item.Entity.Id ??= Guid.NewGuid().ToString();
                        item.Entity.Created_Date = DateTime.UtcNow;
                        break;
                    default:
                        break;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }

        //private void DeleteUser()
        //{
        //    var entities = ChangeTracker.Entries()
        //                        .Where(e => e.State == EntityState.Deleted);
        //    foreach (var entity in entities)
        //    {
        //        if (entity.Entity is User)
        //        {
        //            entity.State = EntityState.Modified;
        //            var user = entity.Entity as User;
        //            if (user != null)
        //            {
        //                user.Is_Deleted = true;
        //            }
        //        }
        //    }
        //}

        //public override int SaveChanges()
        //{
        //    DeleteUser();
        //    return base.SaveChanges();
        //}
    }
}
