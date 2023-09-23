using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeNiceAplication.Core.Entities
{
    public class Usuario
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("nombre")]
        public string Nombre { get; set; }

        [BsonElement("apellido")]
        public string Apellido { get; set; }


        [BsonElement("userName")]
        public string UserName { get; set; }

        [BsonElement("password")]
        public string Contraseña { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("rol")]
        public string Rol { get; set; }

    }
}
