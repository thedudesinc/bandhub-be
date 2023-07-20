using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using BandHub.Domain.Abstractions.Entities;
using BandHub.Domain.Enums;

namespace BandHub.Domain.Models.Inputs;

public class LoginInput : IInput
{

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

}
