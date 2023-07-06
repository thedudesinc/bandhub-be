using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnifyApi.Domain.Abstractions.Services;
using UnifyApi.Domain.Models.Inputs;
using UnifyApi.Domain.Models.Outputs;

namespace UnifyApi.App.Controllers;

[Authorize]
[ApiController]
[Route("api/widget-instance")]
public class WidgetInstanceInstanceController
{
    private readonly IWidgetInstanceService _service;

    public WidgetInstanceInstanceController(IWidgetInstanceService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<WidgetInstanceOutput>> Get(CancellationToken ct)
    {
        return await _service.Get(ct);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<WidgetInstanceOutput>> Get(Guid id, CancellationToken ct)
    {
        return await _service.Get(id, ct);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    public async Task<ActionResult<WidgetInstanceOutput>> Create([FromBody] WidgetInstanceInput user, CancellationToken ct)
    {
        return await _service.Create(user, ct);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<ActionResult<WidgetInstanceOutput>> Update(Guid id, [FromBody] WidgetInstanceInput user, CancellationToken ct)
    {
        return await _service.Update(id, user, ct);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task Delete(Guid id, CancellationToken ct)
    {
        await _service.Delete(id, ct);
    }
}

