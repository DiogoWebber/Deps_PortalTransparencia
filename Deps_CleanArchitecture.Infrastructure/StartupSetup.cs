using Autofac;
using Deps_CleanArchitecture.Core.Interfaces;
using Deps_CleanArchitecture.Infrastructure.Data;
using Deps_CleanArchitecture.Infrastructure.Identity;
using Deps_CleanArchitecture.Infrastructure.Repository;
using Deps_CleanArchitecture.SharedKernel.Util;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Deps_CleanArchitecture.Infrastructure
{
    public static class StartupSetup
    {
        public static void AddDbContext(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(AmbienteUtil.GetValue("POSTGRES_CONNECTION")));
            services.AddDbContext<IdentityContext>(options =>
                options.UseNpgsql(AmbienteUtil.GetValue("POSTGRES_CONNECTION")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();
        }

        public static void ConfigureJwt(this IServiceCollection services) 
        {
            JwtStartupSetup.RegisterJWT(services);
        }
        
        public static void ConfigureContainer(ContainerBuilder builder)
        {

        }
    }
}