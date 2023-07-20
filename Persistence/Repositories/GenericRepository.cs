using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using BandHub.Domain.Abstractions.Entities;
using BandHub.Domain.Abstractions.Repositories;

namespace BandHub.Persistence.Repositories;

public class GenericRepository<TEntity, TInput, TOutput> : IGenericRepository<TEntity, TInput, TOutput>
    where TEntity : class, IEntity
    where TInput : class, IInput
    where TOutput : class, IOutput
{
    protected readonly IMapper _mapper;
    protected readonly BandHubContext _context;

    public GenericRepository(BandHubContext context, IMapper mapper) => (_context, _mapper) = (context, mapper);

    public async Task<IEnumerable<TOutput>> Get(CancellationToken ct)
    {
        var items = await _context.Set<TEntity>().AsNoTracking().ToListAsync(ct);
        return (IEnumerable<TOutput>)_mapper.Map(items, items.GetType(), typeof(IEnumerable<TOutput>));
    }

    public async Task<TOutput> Get(Guid id, CancellationToken ct)
    {
        var item = await _context.Set<TEntity>()
                    .SingleAsync(e => e.Id == id, ct);

        return (TOutput)_mapper.Map(item, item.GetType(), typeof(TOutput));
    }

    public async Task<IEnumerable<TOutput>> Find(Expression<Func<TEntity, bool>> predicate, CancellationToken ct)
    {
        var items = await _context.Set<TEntity>().Where(predicate).ToListAsync(ct);

        return (IEnumerable<TOutput>)_mapper.Map(items, items.GetType(), typeof(IEnumerable<TOutput>));
    }

    public async Task<TOutput> Create(TInput input, CancellationToken ct)
    {
        var entity = (TEntity)_mapper.Map(input, input.GetType(), typeof(TEntity));

        entity.DateCreated = DateTime.Now;
        entity.DateModified = DateTime.Now;

        _context.Set<TEntity>().Add(entity);
        await _context.SaveChangesAsync(ct);

        return (TOutput)_mapper.Map(entity, entity.GetType(), typeof(TOutput));
    }

    public async Task<TOutput> Update(Guid id, TInput input, CancellationToken ct)
    {
        var existing = await _context.Set<TEntity>()
                    .SingleAsync(e => e.Id == id, ct);

        var entity = _mapper.Map(input, existing);

        entity.DateModified = DateTime.Now;

        _context.Set<TEntity>().Update(entity);
        await _context.SaveChangesAsync(ct);

        return (TOutput)_mapper.Map(entity, entity.GetType(), typeof(TOutput)); ;
    }

    public async Task Delete(Guid id, CancellationToken ct)
    {
        var entity = await _context.Set<TEntity>()
                    .SingleAsync(e => e.Id == id, ct);

        entity.DateDeleted = DateTime.Now;

        _context.Set<TEntity>().Update(entity);
        await _context.SaveChangesAsync(ct);
    }
}
