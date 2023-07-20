using System.Text.Json.Serialization;
using BandHub.Domain.Abstractions.Entities;
using BandHub.Domain.Enums;

namespace BandHub.Domain.Models.Outputs;

public class LoginOutput
{
    public int StatusCode { get; set; }
    public string Token { get; set; } = string.Empty;

}
