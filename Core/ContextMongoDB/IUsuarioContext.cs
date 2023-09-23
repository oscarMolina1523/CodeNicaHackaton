using CodeNiceAplication.Core.Entities;
using MongoDB.Driver;

namespace CodeNiceAplication.Core.ContextMongoDB
{
    public interface IUsuarioContext
    {
        IMongoCollection<Usuario> Usuarios { get; }
    }
}
