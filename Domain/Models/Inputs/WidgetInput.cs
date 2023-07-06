using UnifyApi.Domain.Abstractions.Entities;
using UnifyApi.Domain.Enums;

namespace UnifyApi.Domain.Models.Inputs;

public class WidgetInput : IInput
{
    public string Name { get; set; } = string.Empty;

    public WidgetType Type { get; set; }

    public string DefaultHtml { get; set; } = string.Empty;

    public string DefaultCss { get; set; } = string.Empty;
}
