using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeNiceAplication.Core.Entities
{
    public class Curso
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("nombreCurso")]
        public string NombreCurso { get; set; }

        [BsonElement("descripcionCurso")]
        public string DescripcionCurso { get; set; }

        [BsonElement("instructor")]
        public string Instructor { get; set; }

        [BsonElement("modulos")]
        public List<Modulo> ModulosCurso { get; set; }

    }
}
