using Autofac;
using Deps_CleanArchitecture.Core.Interfaces;
using Deps_CleanArchitecture.Infrastructure.Data;
using Deps_CleanArchitecture.Infrastructure.Identity;
using Deps_CleanArchitecture.Infrastructure.Repository;
using Deps_CleanArchitecture.SharedKernel.Util;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Deps_CleanArchitecture.Infrastructure
{
    public static class StartupSetup
    {
        public static void AddDbContext(this IServiceCollection services)
        {
            // Configurar a conexão do MongoDB
            var mongoConnectionString = AmbienteUtil.GetValue("MONGO_CONNECTION");
            var mongoDatabaseName = AmbienteUtil.GetValue("MONGO_DATABASE");

            services.AddSingleton<IMongoClient>(new MongoClient(mongoConnectionString));
            services.AddSingleton<IMongoDatabase>(sp =>
                sp.GetRequiredService<IMongoClient>().GetDatabase(mongoDatabaseName));
            
            services.AddScoped<MongoDbContext>();
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