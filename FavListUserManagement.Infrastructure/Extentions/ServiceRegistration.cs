using FavListUserManagement.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FavListUserManagement.Infrastructure.Extentions
{
    //public static class ServiceRegistration
    //{
    //    public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration Configuration)
    //    {
    //        services.AddDbContext<ApplicationDbContext>(options =>
    //        {

    //            //options.UseSqlServer(Configuration.GetConnectionString("Context"),
    //            var GetConnectionString = Configuration.GetConnectionString("Default");
    //            services.AddDbContext<ApplicationDbContext>(options =>
    //            {
    //                options.UseMySql(GetConnectionString, ServerVersion.AutoDetect(GetConnectionString));
    //            });


    //        });
    //        return services;
    //     }
    //}
}
