using CodeNiceAplication.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeNiceAplication.Repository
{
    public interface ICursoRepository
    {
        Task<IEnumerable<CursoDTO>> GetCursos();
        Task<Curso> GetById(string Id);
        Task<Curso> CrearCurso(Curso nuevoCurso);
        Task CrearModulo(string cursoId, Modulo nuevoModulo);
        Task NuevaInscripcion(string cursoId, Inscripcion nuevaInscripcion);
        Task CrearComentario(string cursoId, Comentario nuevoComentario);
        Task CrearClase(string cursoId, string nombreModulo, Clase nuevaClase);
        Task DeleteById(string Id);
        Task UpdateModulo(string cursoId, string nombreModulo, string nuevoNombre, string nuevaDescripcion);
    }
}
