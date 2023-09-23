using CodeNiceAplication.Core.Entities;
using MongoDB.Driver;

namespace CodeNiceAplication.Core.ContextMongoDB
{
    public interface ICursoContext
    {
        IMongoCollection<Curso> Cursos { get; }
    }
}
