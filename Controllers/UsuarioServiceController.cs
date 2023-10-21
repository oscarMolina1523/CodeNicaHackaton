using CodeNiceAplication.Core.Entities;
using CodeNiceAplication.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeNiceAplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioServiceController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioServiceController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            var usuarios = await _usuarioRepository.GetUsuarios();
            return Ok(usuarios);
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario nuevoUsuario)
        {
            var usuarioCreado = await _usuarioRepository.CrearUsuario(nuevoUsuario);
            return Ok(usuarioCreado);
        }

        [HttpDelete("{id}")]
        public async Task DeleteUsuario(string Id)
        {
            await _usuarioRepository.DeleteById(Id);
        }

        [HttpPut("{id}")]
        public async Task UpdateUsuario(string Id, Usuario cambioUser)
        {
            cambioUser.Id = Id;
            await _usuarioRepository.UpdateUsuario(cambioUser);
        }

    }
}
