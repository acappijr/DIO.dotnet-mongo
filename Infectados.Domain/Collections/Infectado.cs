using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.GeoJsonObjectModel;
using System;

namespace Infectados.Domain.Collections
{
    public class Infectado
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public DateTime DataNascimento { get; set; }
        
        public string Sexo { get; set; }
        
        public GeoJson2DGeographicCoordinates Localizacao { get; set; }
    }
}