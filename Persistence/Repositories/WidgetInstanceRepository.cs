using AutoMapper;
using UnifyApi.Domain.Abstractions.Repositories;
using UnifyApi.Domain.Models.Inputs;
using UnifyApi.Domain.Models.Outputs;
using UnifyApi.Persistance.Entities;
using UnifyApi.Persistence;
using UnifyApi.Persistence.Repositories;

namespace UnifyApi.Persistance.Repositories;

public class WidgetInstanceRepository : GenericRepository<WidgetInstance, WidgetInstanceInput, WidgetInstanceOutput>, IWidgetInstanceRepository
{
    public WidgetInstanceRepository(UnifyContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
