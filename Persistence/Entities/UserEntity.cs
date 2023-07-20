using BandHub.Domain.Enums;
using BandHub.Domain.Abstractions.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace BandHub.Persistence.Entities;

[Table("Users")]
public class UserEntity : IEntity
{

    public Guid Id { get; set; }

    public string Email { get; set; } = string.Empty;

    public UserRole Role { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public DateTime DateCreated { get; set; }

    public DateTime DateModified { get; set; }

    public DateTime? DateDeleted { get; set; }

    // navigation properties
    public List<UserEntity>? Cars { get; set; } = new List<UserEntity>();
}