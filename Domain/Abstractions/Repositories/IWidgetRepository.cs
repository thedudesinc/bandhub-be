using UnifyApi.Domain.Models.Inputs;
using UnifyApi.Domain.Models.Outputs;
using UnifyApi.Persistance.Entities;

namespace UnifyApi.Domain.Abstractions.Repositories;

public interface IWidgetRepository : IGenericRepository<Widget, WidgetInput, WidgetOutput>
{
}
