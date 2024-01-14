using CourseworkNoSQL;
using CourseworkNoSQL.Data.Repositories;
using CourseworkNoSQL.Data.Repositories.Interfaces;
using CourseworkNoSQL.MongoDbConfiguration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<BankStoreDatabaseSettings>(
    builder.Configuration.GetSection("BankStoreDatabase"));
builder.Services.AddSingleton<BankContext>();
builder.Services.AddTransient<IClientRepository, ClientRepository>();
builder.Services.AddTransient<IAccountRepository, AccountRepository>();
builder.Services.AddTransient<ICardRepository, CardRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();