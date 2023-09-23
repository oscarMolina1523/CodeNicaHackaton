using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeNiceAplication.Core.Entities
{
    public class Modulo
    {
        [BsonElement("nombreModulo")]
        public string NombreModulo { get; set; }

        [BsonElement("descripcionModulo")]
        public string DescripcionModulo { get; set; }

        [BsonElement("clases")]
        public List<Clase> ClasesModulo { get; set; }
    }
}
