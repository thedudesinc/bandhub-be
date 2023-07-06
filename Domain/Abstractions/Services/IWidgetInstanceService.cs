using UnifyApi.Domain.Models.Inputs;
using UnifyApi.Domain.Models.Outputs;

namespace UnifyApi.Domain.Abstractions.Services;

public interface IWidgetInstanceService
{
    Task<IEnumerable<WidgetInstanceOutput>> Get(CancellationToken ct);

    Task<WidgetInstanceOutput> Get(Guid id, CancellationToken ct);

    Task<WidgetInstanceOutput> Create(WidgetInstanceInput input, CancellationToken ct);

    Task<WidgetInstanceOutput> Update(Guid id, WidgetInstanceInput input, CancellationToken ct);

    Task Delete(Guid id, CancellationToken ct);
}
