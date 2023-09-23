using CodeNiceAplication.Core.Entities;
using CodeNiceAplication.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeNiceAplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoServiceController : ControllerBase
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoServiceController(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        [HttpGet("cursos")]
        public async Task<ActionResult<IEnumerable<Curso>>> GetCursos()
        {
            var cursos = await _cursoRepository.GetCursos();
            return Ok(cursos);
        }

        [HttpPost("crearCurso")]
        public async Task<ActionResult<Curso>> PostCursos(Curso nuevoCurso)
        {
            var cursoCreado = await _cursoRepository.CrearCurso(nuevoCurso);
            return Ok(cursoCreado);
        }

        [HttpDelete("{id}")]
        public async Task DeleteCurso(string Id)
        {
            await _cursoRepository.DeleteById(Id);
        }

        [HttpPut("{id}")]
        public async Task UpdateCurso(string Id, Curso cambioCurso)
        {
            cambioCurso.Id = Id;
            await _cursoRepository.UpdateCurso(cambioCurso);
        }

    }
}
