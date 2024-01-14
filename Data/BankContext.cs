using CourseworkNoSQL.Models;
using CourseworkNoSQL.MongoDbConfiguration;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace CourseworkNoSQL;

public class BankContext
{
    public readonly IMongoCollection<Client> _clientCollection;
    public readonly IMongoCollection<Account> _accountCollection;
    public readonly IMongoCollection<Card> _cardCollection;
    public BankContext(IOptions<BankStoreDatabaseSettings> bankStoreDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            bankStoreDatabaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(
            bankStoreDatabaseSettings.Value.DatabaseName);
        _clientCollection = mongoDatabase.GetCollection<Client>(
            bankStoreDatabaseSettings.Value.ClientsCollectionName);
        _accountCollection = mongoDatabase.GetCollection<Account>(
            bankStoreDatabaseSettings.Value.AccountsCollectionName);
        _cardCollection = mongoDatabase.GetCollection<Card>(
            bankStoreDatabaseSettings.Value.CardsCollectionName);
    }
}