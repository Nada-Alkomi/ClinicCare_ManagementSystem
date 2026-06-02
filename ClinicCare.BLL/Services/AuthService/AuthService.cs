using Clinic.Care.DAL.Models;
using ClinicCare.DAL.Models; 
using ClinicCare.BLL.Dtos.CommonResponse;
using ClinicCare.BLL.Dtos.User;
using ClinicCare.BLL.Handlers;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace ClinicCare.BLL.Services.AuthService;

public class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _configuration;

    public AuthService(UserManager<User> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }

    public async Task<CommonResponse> LoginAsync(LoginDtos dto)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email);
        if (user is null)
        {
            return new CommonResponse("Invalid email or password", false);
        }

        var passwordValid = await _userManager.CheckPasswordAsync(user, dto.Password);
        if (!passwordValid)
        {
            return new CommonResponse("Invalid email or password", false);
        }

       
        var token = await TokenHandlers.CreateTokenAsync(user, _configuration);
        
        return new CommonResponse("Login successful", true, null, token);
    }

    public async Task<CommonResponse> RegisterAsync(RegistrationDtos dto)
    {
        var userExist = await _userManager.FindByEmailAsync(dto.Email);
        if (userExist is not null)
        {
            return new CommonResponse("Email is already registered", false); 
        }
        var newUser = new User
        {
            Name = dto.Name,
            Email = dto.Email,
            UserName = dto.Email, 
            Gender = dto.Gender,
            PhoneNumber = dto.PhoneNumber, 

          
            Role = UserRole.Patient 
        };

        var result = await _userManager.CreateAsync(newUser, dto.Password);
        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(e => e.Description).ToList();
            return new CommonResponse("There is a problem while your registration", false, errors: errors);
        }
        
        return new CommonResponse("Your registration is successful", true);
    }
}