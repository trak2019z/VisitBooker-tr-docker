using Domain.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Context;


namespace Bootstrap
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddDbAuthenticationServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<VisitBookerDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
                options.UseOpenIddict();
            });

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<VisitBookerDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}
