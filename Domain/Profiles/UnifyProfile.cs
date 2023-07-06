using AutoMapper;
using UnifyApi.Domain.Models.Inputs;
using UnifyApi.Domain.Models.Outputs;
using UnifyApi.Persistance.Entities;

namespace UnifyApi.Domain.Profiles;

public class UnifyProfile : Profile
{
    public UnifyProfile()
    {
        CreateMap<WidgetInput, Widget>();
        CreateMap<Widget, WidgetOutput>();

        CreateMap<WidgetInstanceInput, WidgetInstance>();
        CreateMap<WidgetInstance, WidgetInstanceOutput>();
    }
}
