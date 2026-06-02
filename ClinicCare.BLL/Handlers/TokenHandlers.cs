using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Clinic.Care.DAL.Models;
using ClinicCare.DAL.Models; // اتأكدنا من الـ Namespace الصح وشيلنا المتكرر
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ClinicCare.BLL.Handlers;

public class TokenHandlers
{
    public static async Task<string> CreateTokenAsync(User user, IConfiguration configuration)
    {
        
        return await Task.Run(() =>
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), 
                new Claim(ClaimTypes.Name, user.Name ?? user.UserName ?? "Unknown"),
                new Claim(ClaimTypes.Email, user.Email!),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) 
            };

            var keyInBytes = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!);
            var key = new SymmetricSecurityKey(keyInBytes);
            
            var issuer = configuration["Jwt:Issuer"]!.ToString();
            var audience = configuration["Jwt:Audience"]!.ToString();
            var expireTime = double.Parse(configuration["Jwt:ExpireTime"]!);

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
         
            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expireTime),
                signingCredentials: creds
            );
            
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        });
    }
}