using CodeNiceAplication.Core.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;

namespace CodeNiceAplication.Core.ContextMongoDB
{
    public class CursoContext : ICursoContext
    {

        private readonly IMongoDatabase _db;

        public CursoContext(IOptions<MongoSettings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.Database);
        }


        public IMongoCollection<Curso> Cursos => _db.GetCollection<Curso>("Curso");
    }
}
