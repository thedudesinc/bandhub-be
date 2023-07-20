using System.Linq.Expressions;
using BandHub.Domain.Abstractions.Entities;

namespace BandHub.Domain.Abstractions.Repositories;

public interface IGenericRepository<TEntity, TInput, TOutput>
    where TEntity : class, IEntity
    where TInput : class, IInput
    where TOutput : class, IOutput
{
    Task<IEnumerable<TOutput>> Get(CancellationToken ct);

    Task<TOutput> Get(Guid id, CancellationToken ct);

    Task<IEnumerable<TOutput>> Find(Expression<Func<TEntity, bool>> predicate, CancellationToken ct);

    Task<TOutput> Create(TInput input, CancellationToken ct);

    Task<TOutput> Update(Guid id, TInput input, CancellationToken ct);

    Task Delete(Guid id, CancellationToken ct);
}
