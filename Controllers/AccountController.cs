using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace WebApiAuthentication.Api.Controllers;

[Route("account")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public AccountController(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public class AuthenticationRequestBody
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
    
    [HttpPost("login")]
    public ActionResult<string> Login(AuthenticationRequestBody authenticationRequestBody)
    {
        if (authenticationRequestBody is { Username: "Omar", Password: "123456" })
        {
            var securityKey = new SymmetricSecurityKey(
                Convert.FromBase64String(_configuration["Authentication:SecretForKey"] //this line is the problem (this is teh code "RgDldLrk+p+T0JIsAkDD7THNt/npmWYl4VvV3UUIrSVE=")
                                         ?? throw new KeyNotFoundException("SecretForKey not found ir invalid")));
            
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new List<Claim>
            {
                new(ClaimTypes.Name, authenticationRequestBody.Username),
                new(ClaimTypes.Email, "omar@gmail.com"),
                new(ClaimTypes.NameIdentifier, authenticationRequestBody.Password)
            };

            var jwtSecurityToken = new JwtSecurityToken(
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddMinutes(30),
                signingCredentials
            );
            
            var tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            return Ok(tokenToReturn);
        }
        return Unauthorized();
    }
}