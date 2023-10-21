using MongoDB.Bson.Serialization.Attributes;

namespace CodeNiceAplication.Core.Entities
{
    public class Imagen
    {
        [BsonElement("url")]
        public string ImagenUrl { get; set; }
    }
}