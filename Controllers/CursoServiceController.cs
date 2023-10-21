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

        ///me muestra todos los cursos de la base de datos///
        [HttpGet("cursos")]
        public async Task<ActionResult<IEnumerable<CursoDTO>>> GetCursos()
        {
            var cursos = await _cursoRepository.GetCursos();
            return Ok(cursos);
        }

        //me muestra el curso por id//
        [HttpGet("cursos/{cursoId}")]
        public async Task<ActionResult<Curso>> GetCursoPorId(string cursoId)
        {
            var curso = await _cursoRepository.GetById(cursoId);

            if (curso == null)
            {
                return NotFound(); 
            }

            return Ok(curso);
        }
        //crear un comentario en un curso existente//
        [HttpPost("cursos/{cursoId}/comentarios")]
        public async Task<ActionResult> CrearComentarioEnCurso(string cursoId, Comentario nuevoComentario)
        {
            await _cursoRepository.CrearComentario(cursoId, nuevoComentario);
            return Ok();
        }

        //esta es para inscribirse un usuario en un curso existente//
        [HttpPost("cursos/{cursoId}/inscripcion")]
        public async Task<ActionResult> CrearInscripcion(string cursoId, Inscripcion nuevaInscripcion)
        {
            await _cursoRepository.NuevaInscripcion(cursoId, nuevaInscripcion);
            return Ok();
        }

        //para crear un nuevo curso//
        [HttpPost("crearCurso")]
        public async Task<ActionResult<Curso>> PostCursos(Curso nuevoCurso)
        {
            var cursoCreado = await _cursoRepository.CrearCurso(nuevoCurso);
            return Ok(cursoCreado);
        }

        //crear un nuevo modulo en curso existente//
        [HttpPost("cursos/{cursoId}/modulos")]
        public async Task<ActionResult> CrearModuloEnCurso(string cursoId, Modulo nuevoModulo)
        {
            await _cursoRepository.CrearModulo(cursoId, nuevoModulo);
            return Ok();
        }

        //crear nueva clase en modulo existente//
        [HttpPost("cursos/{cursoId}/modulos/{nombreModulo}/clases")]
        public async Task<ActionResult> InsertarClaseEnModulo(string cursoId, string nombreModulo, Clase nuevaClase)
        {
            await _cursoRepository.CrearClase(cursoId, nombreModulo, nuevaClase);
            return Ok();
        }

        //eliminar curso//
        [HttpDelete("eliminar/{id}")]
        public async Task DeleteCurso(string Id)
        {
            await _cursoRepository.DeleteById(Id);
        }

        //cmabiar datos de un modulo de un curso//
        [HttpPut("cursos/{cursoId}/modulos/{nombreModulo}")]
        public async Task<ActionResult> ActualizarModuloEnCurso(string cursoId, string nombreModulo, Modulo moduloActualizado)
        {
            await _cursoRepository.UpdateModulo(cursoId, nombreModulo, moduloActualizado.NombreModulo, moduloActualizado.DescripcionModulo);
            return Ok();
        }

    }
}
