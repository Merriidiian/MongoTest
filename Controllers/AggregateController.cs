using CourseworkNoSQL.Data.Repositories;
using CourseworkNoSQL.Data.Repositories.Interfaces;
using CourseworkNoSQL.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace CourseworkNoSQL.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AggregateController: Controller
{
    private readonly IAggregateRepository _repository;

    public AggregateController(IAggregateRepository repository)
    {
        _repository = repository;
    }
    [HttpGet]
    public async Task<Aggregate> GetAggregateById(Guid id, CancellationToken cancellationToken)
    {
        return await _repository.AggregateLinq(id, cancellationToken);
    }
}