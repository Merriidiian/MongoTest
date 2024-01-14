using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CourseworkNoSQL.Models;

public class Client
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; }
    [BsonElement("Name")]
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Patronymic { get; set; }
    public int Passport { get; set; }
   
}