using UnifyApi.Domain.Abstractions.Entities;

namespace UnifyApi.Domain.Models.Inputs;

public class WidgetInstanceInput : IInput
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Html { get; set; } = string.Empty;

    public string Css { get; set; } = string.Empty;

    public bool IsPublished { get; set; }
}
