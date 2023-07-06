﻿using UnifyApi.Domain.Abstractions.Entities;
using UnifyApi.Domain.Enums;

namespace UnifyApi.Persistance.Entities;

public class Widget : IEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public WidgetType Type { get; set; }

    public string DefaultHtml { get; set; } = string.Empty;

    public string DefaultCss { get; set; } = string.Empty;

    public DateTime DateCreated { get; set; }

    public DateTime DateModified { get; set; }

    public DateTime? DateDeleted { get; set; }
}