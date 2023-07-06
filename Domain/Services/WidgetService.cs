using UnifyApi.Domain.Abstractions.Repositories;
using UnifyApi.Domain.Abstractions.Services;
using UnifyApi.Domain.Models.Inputs;
using UnifyApi.Domain.Models.Outputs;

namespace UnifyApi.Domain.Services;

public class WidgetService : IWidgetService
{
    private readonly IWidgetRepository _repository;

    public WidgetService(IWidgetRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<WidgetOutput>> Get(CancellationToken ct)
    {
        return await _repository.Get(ct);
    }

    public async Task<WidgetOutput> Get(Guid id, CancellationToken ct)
    {
        return await _repository.Get(id, ct);
    }

    public async Task<WidgetOutput> Create(WidgetInput input, CancellationToken ct)
    {
        return await _repository.Create(input, ct);
    }

    public async Task<WidgetOutput> Update(Guid id, WidgetInput input, CancellationToken ct)
    {
        return await _repository.Update(id, input, ct);
    }

    public async Task Delete(Guid id, CancellationToken ct)
    {
        await _repository.Delete(id, ct);
    }
}
