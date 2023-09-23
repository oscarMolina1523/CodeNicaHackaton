using CodeNiceAplication.Core.ContextMongoDB;
using CodeNiceAplication.Core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeNiceAplication.Repository
{
    public class CursoRepository : ICursoRepository
    {
        private readonly ICursoContext _cursoContext;
        public CursoRepository(ICursoContext cursoContext)
        {
            _cursoContext = cursoContext;
        }

        public async Task<Curso> CrearCurso(Curso nuevoCurso)
        {
            await _cursoContext.Cursos.InsertOneAsync(nuevoCurso);
            return nuevoCurso;
        }

        public async Task DeleteById(string Id)
        {
            var filter = Builders<Curso>.Filter.Eq(u => u.Id, Id);
            await _cursoContext.Cursos.FindOneAndDeleteAsync(filter);
        }

        public async Task<IEnumerable<Curso>> GetCursos()
        {
            return await _cursoContext.Cursos.Find(p => true).ToListAsync();
        }

        public async Task UpdateCurso(Curso cursoUpdate)
        {
            var filter = Builders<Curso>.Filter.Eq(doc => doc.Id, cursoUpdate.Id);
            await _cursoContext.Cursos.FindOneAndReplaceAsync(filter, cursoUpdate);
        }
    }
}
