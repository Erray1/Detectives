using Detectives.Sessions.Application.Mapping;
using Detectives.Sessions.Domain.Dto.SearchOperations;
using Detectives.Sessions.Domain.Entities;
using Detectives.Sessions.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Detectives.Sessions.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SessionsController : ControllerBase
{
    private readonly ISessionsRepository _sessionsRepository;
    private readonly IJoinLinkAdder _joinLinksAdder;
    private readonly IServiceProvider _serviceProvider;
    public SessionsController(
        ISessionsRepository repo, 
        IJoinLinkAdder joinLinksAdder,
        IServiceProvider service)
    {
        _sessionsRepository = repo;
        _joinLinksAdder = joinLinksAdder;
        _serviceProvider = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPaged([FromQuery] int page, [FromQuery] int pageSize)
    {
        var sessions = await _sessionsRepository.GetSessionsPagedAsync(page, pageSize);
        var sessionsDto = sessions.ToDto();
        _joinLinksAdder.AddJoinLinks(sessionsDto);
        return Ok(sessionsDto);

    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchPaged([FromBody] SearchSessionsRequest request, [FromQuery] int page, [FromQuery] int pageSize)
    {
        var searchEngine = _serviceProvider.GetRequiredService<ISessionsSearchEngine>();
        IQueryable<GameSession> sessionsQuery = null!;
        try
        {
            sessionsQuery = searchEngine.Search(request);
        }
        catch (InvalidOperationException exception)
        {
            return BadRequest(exception.Message);
        }
        var sessions = await sessionsQuery.PageAsync(page, pageSize);
        if (sessions.Count == 0)
        {
            return NotFound($"Не найдено сессий с названием {request.SearchQuery}");
        }
        var sessionsDto = sessions.ToDto();
        _joinLinksAdder.AddJoinLinks(sessionsDto);
        return Ok(sessionsDto);
        
    }
}

