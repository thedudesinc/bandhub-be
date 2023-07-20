using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using BandHub.Domain.Abstractions.Services;
using BandHub.Domain.Models.Inputs;
using BandHub.Domain.Models.Outputs;

namespace BandHub.App.Controllers;

[Authorize]
[ApiController]
[Route("api/users")]
public class UserController
{
    //beginning of dependency injection
    private readonly IUserService _service;  //step one declare a global variable

    private readonly IConfiguration _configuration;

    public UserController(IUserService service, IConfiguration configuration) //step two add interface to constructor parameters
    {
        _service = service;
        _configuration = configuration;  //step three set global var ro parameter
    }

    [HttpGet]
    public async Task<IEnumerable<UserOutput>> Get(CancellationToken ct)
    {
        return await _service.Get(ct);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<UserOutput>> Get(Guid id, CancellationToken ct)
    {
        return await _service.Get(id, ct);
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<ActionResult<UserOutput>> Create([FromBody] UserInput user, CancellationToken ct)
    {
        return await _service.Create(user, ct);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<ActionResult<UserOutput>> Update(Guid id, [FromBody] UserInput user, CancellationToken ct)
    {
        return await _service.Update(id, user, ct);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task Delete(Guid id, CancellationToken ct)
    {
        await _service.Delete(id, ct);
    }

    [AllowAnonymous]
    [HttpPost]
    [Route("login")]
    public async Task<IResult> Login([FromBody] LoginInput input, CancellationToken ct)
    {
        var user = await _service.Login(input, ct);

        if (user == null) return Results.Ok(new LoginOutput { StatusCode = StatusCodes.Status401Unauthorized });

        var key = _configuration.GetValue<string>("Jwt:Key");

        if (key == null) throw new Exception("Could not retrieve Jwt:Key from configuration.");

        var issuer = _configuration.GetValue<string>("Jwt:Issuer");
        var audience = _configuration.GetValue<string>("Jwt:Audience");
        var tokenDescriptor = new SecurityTokenDescriptor
        {

            Subject = new ClaimsIdentity(new[]
            {
                new Claim("uid", user.Id.ToString()),
                new Claim("userRole", user.Role.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, input.Email),
                new Claim(JwtRegisteredClaimNames.Email, input.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
             }),
            Expires = DateTime.UtcNow.AddDays(5),
            Issuer = issuer,
            Audience = audience,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)), SecurityAlgorithms.HmacSha512Signature)
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var jwtToken = tokenHandler.WriteToken(token);
        var stringToken = tokenHandler.WriteToken(token);
        return Results.Ok(new LoginOutput { StatusCode = StatusCodes.Status200OK, Token = stringToken });
    }

    [AllowAnonymous]
    [HttpPost]
    [Route("verifyEmail")]
    public async Task<ActionResult<bool>> VerifyEmail([FromBody] string email, CancellationToken ct)
    {
        return await _service.VerifyEmail(email, ct);
    }
}
