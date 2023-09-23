using CodeNiceAplication.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeNiceAplication.Repository
{
    public interface ICursoRepository
    {
        Task<IEnumerable<Curso>> GetCursos();
        Task<Curso> CrearCurso(Curso nuevoCurso);
        Task DeleteById(string Id);
        Task UpdateCurso(Curso cursoUpdate);
    }
}
