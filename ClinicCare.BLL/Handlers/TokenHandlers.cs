using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Clinic.Care.DAL.Models;
using ClinicCare.BLL.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ClinicCare.BLL.Handlers;

public class TokenHandlers
{
    public static async Task<string> CreateTokenAsync(AppUser user, IConfiguration configuration, UserManager<AppUser> _userManager)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.FullName),
            new Claim(ClaimTypes.Email, user.Email!),
        };

        var userRoles = await _userManager.GetRolesAsync(user);
        foreach (var role in userRoles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var keyInBytes = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!);
        var key = new SymmetricSecurityKey(keyInBytes);
        
        var issuer = configuration["Jwt:Issuer"]!.ToString();
        var audience = configuration["Jwt:Audience"]!.ToString();
        var expireTime = configuration["Jwt:ExpireTime"]!.ToString();

       
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
     
        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(double.Parse(expireTime)),
            signingCredentials: creds
        );
        
        var tokenHandler = new JwtSecurityTokenHandler();
        return tokenHandler.WriteToken(token);
    }
}