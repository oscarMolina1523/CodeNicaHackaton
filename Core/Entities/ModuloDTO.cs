using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeNiceAplication.Core.Entities
{
    public class ModuloDTO
    {
        [BsonElement("nombreModulo")]
        public string NombreModulo { get; set; }

        [BsonElement("descripcionModulo")]
        public string DescripcionModulo { get; set; }

        [BsonElement("clases")]
        public Clase ClasesModulo { get; set; }
    }
}
