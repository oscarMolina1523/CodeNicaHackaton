using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeNiceAplication.Core.Entities
{
    public class Clase
    {
        [BsonElement("nombreClase")]
        public string NombreClase { get; set; }

        [BsonElement("descripcion")]
        public string Descripcion { get; set; }

        [BsonElement("urlVideo")]
        public string? UrlVideo { get; set; }
    }
}
