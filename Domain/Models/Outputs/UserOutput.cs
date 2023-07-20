using System.Text.Json.Serialization;
using BandHub.Domain.Abstractions.Entities;
using BandHub.Domain.Enums;

namespace BandHub.Domain.Models.Outputs;

public class UserOutput : IOutput
{
    public Guid Id { get; set; }

    public string Email { get; set; } = string.Empty;

    public UserRole Role { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    [JsonIgnore]
    public string Password { get; set; } = string.Empty;

    public DateTime DateCreated { get; set; }

    public DateTime DateModified { get; set; }

    public DateTime? DateDeleted { get; set; }

}
