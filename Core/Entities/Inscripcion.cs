using MongoDB.Bson.Serialization.Attributes;

namespace CodeNiceAplication.Core.Entities
{
    public class Inscripcion
    {
        [BsonElement("usuario")]
        public string InscripcionUsuario { get; set; }
    }
}