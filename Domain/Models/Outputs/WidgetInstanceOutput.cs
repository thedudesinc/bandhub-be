using UnifyApi.Domain.Abstractions.Entities;

namespace UnifyApi.Domain.Models.Outputs;

public class WidgetInstanceOutput : IOutput
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Html { get; set; } = string.Empty;

    public string Css { get; set; } = string.Empty;

    public bool IsPublished { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime DateModified { get; set; }

    public DateTime? DateDeleted { get; set; }
}
