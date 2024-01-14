namespace CourseworkNoSQL.MongoDbConfiguration;

public class BankStoreDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string ClientsCollectionName { get; set; } = null!;
    public string AccountsCollectionName { get; set; } = null!;
    public string CardsCollectionName { get; set; } = null!;
}