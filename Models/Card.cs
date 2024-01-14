using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CourseworkNoSQL.Models;

public class Card
{
    [StringLength(16)]
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public string? Number { get; set; }
    public Guid AccountId { get; set; }
    public DateTime EndTime { get; set; }
    public int Svv { get; set; }

}