using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace CRUDUsingMongo.Entities;

public class Book
{
    [BsonId]
    //[BsonRepresentation(BsonType.ObjectId)]
    public int? Id { get; set; }

    [BsonElement("Name")]
    [JsonPropertyName("Name")]
    public string BookName { get; set; } = null!;

    public decimal Price { get; set; }

    public string Category { get; set; } = null!;

    public string Author { get; set; } = null!;
}
