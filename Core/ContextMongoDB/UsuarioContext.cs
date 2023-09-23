using CodeNiceAplication.Core.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CodeNiceAplication.Core.ContextMongoDB
{
    public class UsuarioContext : IUsuarioContext
    {
        private readonly IMongoDatabase _db;

        public UsuarioContext(IOptions<MongoSettings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.Database);
        }

        public IMongoCollection<Usuario> Usuarios => _db.GetCollection<Usuario>("Usuario");
    }
}
