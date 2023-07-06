using UnifyApi.Domain.Abstractions.Repositories;
using UnifyApi.Domain.Abstractions.Services;
using UnifyApi.Domain.Models.Inputs;
using UnifyApi.Domain.Models.Outputs;

namespace UnifyApi.Domain.Services;

public class WidgetInstanceService : IWidgetInstanceService
{
    private readonly IWidgetInstanceRepository _repository;

    public WidgetInstanceService(IWidgetInstanceRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<WidgetInstanceOutput>> Get(CancellationToken ct)
    {
        return await _repository.Get(ct);
    }

    public async Task<WidgetInstanceOutput> Get(Guid id, CancellationToken ct)
    {
        return await _repository.Get(id, ct);
    }

    public async Task<WidgetInstanceOutput> Create(WidgetInstanceInput input, CancellationToken ct)
    {
        return await _repository.Create(input, ct);
    }

    public async Task<WidgetInstanceOutput> Update(Guid id, WidgetInstanceInput input, CancellationToken ct)
    {
        return await _repository.Update(id, input, ct);
    }

    public async Task Delete(Guid id, CancellationToken ct)
    {
        await _repository.Delete(id, ct);
    }
}
