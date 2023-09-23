using CodeNiceAplication.Core.ContextMongoDB;
using CodeNiceAplication.Core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeNiceAplication.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IUsuarioContext _usuarioContext;
        public UsuarioRepository(IUsuarioContext usuarioContext)
        {
            _usuarioContext = usuarioContext;
        }
        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
           return await _usuarioContext.Usuarios.Find(p => true).ToListAsync();
        }

        public async Task<Usuario> CrearUsuario(Usuario nuevoUsuario)
        {
            await _usuarioContext.Usuarios.InsertOneAsync(nuevoUsuario);
            return nuevoUsuario;
        }

        public async Task DeleteById(string Id)
        {
            var filter = Builders<Usuario>.Filter.Eq(u => u.Id, Id);
            await _usuarioContext.Usuarios.FindOneAndDeleteAsync(filter);
        }


        public async Task UpdateUsuario(Usuario updateUser)
        {
            var filter = Builders<Usuario>.Filter.Eq(doc => doc.Id, updateUser.Id);
            await _usuarioContext.Usuarios.FindOneAndReplaceAsync(filter, updateUser);
        }
    }
}
