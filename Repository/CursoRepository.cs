using CodeNiceAplication.Core.ContextMongoDB;
using CodeNiceAplication.Core.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task CrearClase(string cursoId, string nombreModulo, Clase nuevaClase)
        {
            var cursoFilter = Builders<Curso>.Filter.Eq(u => u.Id, cursoId);
            var curso = await _cursoContext.Cursos.Find(cursoFilter).FirstOrDefaultAsync();

            if (curso != null)
            {
                var modulo = curso.ModulosCurso.FirstOrDefault(m => m.NombreModulo == nombreModulo);

                if (modulo != null)
                {
                    modulo.ClasesModulo.Add(nuevaClase);
                    await _cursoContext.Cursos.ReplaceOneAsync(cursoFilter, curso);
                }
            }
        }

        public async Task CrearComentario(string cursoId, Comentario nuevoComentario)
        {
            var cursoFilter = Builders<Curso>.Filter.Eq(u => u.Id, cursoId);
            var curso = await _cursoContext.Cursos.Find(cursoFilter).FirstOrDefaultAsync();

            if (curso != null)
            {
                curso.ModulosComentario.Add(nuevoComentario);
                await _cursoContext.Cursos.ReplaceOneAsync(cursoFilter, curso);
            }
        }

        public async Task<Curso> CrearCurso(Curso nuevoCurso)
        {
            await _cursoContext.Cursos.InsertOneAsync(nuevoCurso);
            return nuevoCurso;
        }

        public async Task CrearModulo(string CursoId, Modulo nuevoModulo)
        {
            var cursoFilter = Builders<Curso>.Filter.Eq(u => u.Id, CursoId);
            var curso = await _cursoContext.Cursos.Find(cursoFilter).FirstOrDefaultAsync();

            if (curso != null)
            {
                curso.ModulosCurso.Add(nuevoModulo);
                await _cursoContext.Cursos.ReplaceOneAsync(cursoFilter, curso);
            }
        }

        public async Task DeleteById(string Id)
        {
            var filter = Builders<Curso>.Filter.Eq(u => u.Id, Id);
            await _cursoContext.Cursos.FindOneAndDeleteAsync(filter);
        }

        public async Task<Curso> GetById(string Id)
        {
            var filter = Builders<Curso>.Filter.Eq(u => u.Id, Id);

            return await _cursoContext.Cursos.Find(filter).FirstOrDefaultAsync();
            
        }

        public async Task<IEnumerable<CursoDTO>> GetCursos()
        {
            var cursosDTO = new List<CursoDTO>();
          
            var cursosOrigen = await _cursoContext.Cursos.Find(p => true).ToListAsync();

            
            foreach (var cursoOrigen in cursosOrigen)
            {
                var cursoDTO = new CursoDTO();

               
                cursoDTO.Id = cursoOrigen.Id; 
                cursoDTO.NombreCurso = cursoOrigen.NombreCurso;
                cursoDTO.DescripcionCurso = cursoOrigen.DescripcionCurso;
                cursoDTO.Instructor = cursoOrigen.Instructor;
                cursoDTO.ModulosCurso = cursoOrigen.ModulosCurso;
                cursoDTO.ModulosComentario = cursoOrigen.ModulosComentario;
                cursoDTO.CursoIncripcion = cursoOrigen.CursoIncripcion;
                if (cursoOrigen.ImagenCurso != null && cursoOrigen.ImagenCurso.Count > 0)
                {
                    cursoDTO.ImagenCurso = cursoOrigen.ImagenCurso[0]; // Asegúrate de que exista al menos un elemento en ImagenCurso
                }
                else
                {
                    var img = new Imagen { ImagenUrl = "https://cdn-icons-png.flaticon.com/512/3145/3145866.png" };
                    cursoDTO.ImagenCurso = img; 
                }
                cursosDTO.Add(cursoDTO);
                
            }

            return cursosDTO;
        }

        public async Task NuevaInscripcion(string cursoId, Inscripcion nuevaInscripcion)
        {
            var cursoFilter = Builders<Curso>.Filter.Eq(u => u.Id, cursoId);
            var curso = await _cursoContext.Cursos.Find(cursoFilter).FirstOrDefaultAsync();

            if (curso != null)
            {
                curso.CursoIncripcion.Add(nuevaInscripcion);
                await _cursoContext.Cursos.ReplaceOneAsync(cursoFilter, curso);
            }
        }

        public async Task UpdateModulo(string cursoId, string nombreModulo, string nuevoNombre, string nuevaDescripcion)
        {
            var filter = Builders<Curso>.Filter.Eq(doc => doc.Id, cursoId);
            var curso = await _cursoContext.Cursos.Find(filter).FirstOrDefaultAsync();
            if (curso != null)
            {
                var modulo = curso.ModulosCurso.FirstOrDefault(m => m.NombreModulo == nombreModulo);

                if (modulo != null)
                {
                    modulo.NombreModulo = nuevoNombre;
                    modulo.DescripcionModulo = nuevaDescripcion;

                    await _cursoContext.Cursos.ReplaceOneAsync(filter, curso);
                }
            }
        }
    }
}
