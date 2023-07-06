using AutoMapper;
using UnifyApi.Domain.Abstractions.Repositories;
using UnifyApi.Domain.Models.Inputs;
using UnifyApi.Domain.Models.Outputs;
using UnifyApi.Persistance.Entities;
using UnifyApi.Persistence;
using UnifyApi.Persistence.Repositories;

namespace UnifyApi.Persistance.Repositories;

public class WidgetRepository : GenericRepository<Widget, WidgetInput, WidgetOutput>, IWidgetRepository
{
    public WidgetRepository(UnifyContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
