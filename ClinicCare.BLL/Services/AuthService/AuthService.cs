using Clinic.Care.DAL.Models;
using ClinicCare.BLL.Dtos.CommonResponse;
using ClinicCare.BLL.Dtos.User;
using ClinicCare.BLL.Handlers;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace ClinicCare.BLL.Services.AuthService;

public class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IConfiguration _configuration;
    public AuthService(UserManager<AppUser> userManager,IConfiguration configuration)
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

        var Token =await TokenHandlers.CreateTokenAsync(user, _configuration, _userManager);
        return new CommonResponse("Login successful", true,null, Token);
}

    public async Task<CommonResponse> RegisterAsync(RegistrationDtos dto)
    {
        var UserExist = await _userManager.FindByEmailAsync(dto.Email);
        if (UserExist is not null)
        {
            return new CommonResponse("there is problem while your registration", false);
        }

        var newUser = new AppUser
        {
            FullName = dto.FullName,
            Email = dto.Email,
            UserName = dto.Email,
            Address = dto.Address,
            PhoneNumber = dto.PhoneNumber

        };
        var result = await _userManager.CreateAsync(newUser, dto.Password);
        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(e => e.Description).ToList();
            return new CommonResponse("there is problem while your registration", false, errors: errors);
        }

        var AddToRoleResult = await _userManager.AddToRoleAsync(newUser, "User");
        if (!AddToRoleResult.Succeeded)
        {
            var errors = AddToRoleResult.Errors.Select(e => e.Description).ToList();
            return new CommonResponse("there is problem while your registration", false);
        }

        return new CommonResponse("your registration is successfull", true);


    }
}