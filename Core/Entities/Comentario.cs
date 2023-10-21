using MongoDB.Bson.Serialization.Attributes;

namespace CodeNiceAplication.Core.Entities
{
    public class Comentario
    {
        [BsonElement("usuario")]
        public string NombreUsuario { get; set; }

        [BsonElement("texto")]
        public string TextoUsuario { get; set; }
    }
}