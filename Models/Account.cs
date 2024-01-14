using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CourseworkNoSQL.Models;

public class Account
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; }
    public Guid ClientId { get; set; }
    public long Inn { get; set; }
    
}