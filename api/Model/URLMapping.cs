using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace model
{
    public class URLMapping
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("short")]
        public required string Short { get; set; }
        [BsonElement("long")]
        public required string Long { get; set; }
        [BsonElement("identifier")]
        public required string Identifier { get; set; }
    }
}

