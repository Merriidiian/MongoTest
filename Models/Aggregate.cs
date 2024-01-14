namespace CourseworkNoSQL.Models;

public class Aggregate
{
    public Client Client { get; set; }
    public List<Account> Accounts { get; set; }
    public List<Card> Cards { get; set; }
}