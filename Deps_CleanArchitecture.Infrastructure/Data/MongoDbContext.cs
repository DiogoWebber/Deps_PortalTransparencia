using System.Threading.Tasks;
using Deps_CleanArchitecture.Core.DTO;
using MongoDB.Driver;

namespace Deps_CleanArchitecture.Infrastructure.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task SalvarConsulta(ConsultaData consulta)
        {
            var collection = _database.GetCollection<ConsultaData>("Consultas");
            await collection.InsertOneAsync(consulta);
        }
    }
}