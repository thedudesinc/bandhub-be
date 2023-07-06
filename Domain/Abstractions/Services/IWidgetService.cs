using UnifyApi.Domain.Models.Inputs;
using UnifyApi.Domain.Models.Outputs;

namespace UnifyApi.Domain.Abstractions.Services;

public interface IWidgetService
{
    Task<IEnumerable<WidgetOutput>> Get(CancellationToken ct);

    Task<WidgetOutput> Get(Guid id, CancellationToken ct);

    Task<WidgetOutput> Create(WidgetInput input, CancellationToken ct);

    Task<WidgetOutput> Update(Guid id, WidgetInput input, CancellationToken ct);

    Task Delete(Guid id, CancellationToken ct);
}
