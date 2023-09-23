using CodeNiceAplication.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeNiceAplication.Repository
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetUsuarios();
        Task<Usuario> CrearUsuario(Usuario nuevoUsuario);
        Task DeleteById(string Id);
        Task UpdateUsuario(Usuario userUpdate);
    }
}
