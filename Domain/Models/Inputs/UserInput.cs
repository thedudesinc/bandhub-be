using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using BandHub.Domain.Abstractions.Entities;
using BandHub.Domain.Enums;

namespace BandHub.Domain.Models.Inputs;

public class UserInput : IInput
{

    [Required]
    [EmailAddress]
    [Remote(action: "VerifyEmail", controller: "User")]
    public string Email { get; set; } = string.Empty;

    [Required]
    public UserRole Role { get; set; }

    [Required]
    [StringLength(20, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 2)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(20, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 2)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [Phone]
    public string Phone { get; set; } = string.Empty;

    [Required]
    [StringLength(100, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 6)]
    public string Password { get; set; } = string.Empty;

}
