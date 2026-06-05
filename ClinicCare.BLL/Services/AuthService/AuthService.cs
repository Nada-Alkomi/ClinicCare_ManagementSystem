using Clinic.Care.DAL.Models;
using Clinic.Care.DAL.Repositories.UntiOfWork;
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
    private readonly IUnitOfWork _unitofwork;

    public AuthService(UserManager<User> userManager, IConfiguration configuration,IUnitOfWork unitOfWork)
    {
        _userManager = userManager;
        _configuration = configuration;
        _unitofwork = unitOfWork;
    }
    //==========================================login====================================
    public async Task<CommonResponse> LoginAsync(LoginDtos dto)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email);
        if (user is null)
        {
            return new CommonResponse("Invalid email or password ", false);
        }

        var passwordValid = await _userManager.CheckPasswordAsync(user, dto.Password);
        if (!passwordValid)
        {
            return new CommonResponse("Invalid email or password", false);
        }

       
        var token = await TokenHandlers.CreateTokenAsync(user, _configuration);
        
        return new CommonResponse("Login successful", true, null, token);
    }
    
//=============================================register=======================================

    public async Task<CommonResponse> RegisterPatientAsync(RegistrationDtos dto)
    {
        return await RegisterUserAsync(dto, UserRole.Patient);
    }

    public async Task<CommonResponse> RegisterDoctorAsync(RegistrationDtos dto)
    {
        return await RegisterUserAsync(dto, UserRole.Doctor);
    }

    public async Task<CommonResponse> RegisterAdminAsync(RegistrationDtos dto)
    {
        return await RegisterUserAsync(dto, UserRole.Admin);
    }
    private async Task<CommonResponse> RegisterUserAsync(
        RegistrationDtos dto,
        UserRole role)
    {
        try
        {
            var existingUser = await _userManager.FindByEmailAsync(dto.Email);

            if (existingUser is not null)
            {
                return new CommonResponse(
                    "Email already exists",
                    false);
            }

            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Email = dto.Email,
                UserName = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                BirthDate = dto.BirthDate,
                Gender = dto.Gender,
                Role = role
            };

            var createResult = await _userManager.CreateAsync(
                user,
                dto.Password);

            if (!createResult.Succeeded)
            {
                var errors = createResult.Errors
                    .Select(e => e.Description)
                    .ToList();

                return new CommonResponse(
                    "Registration failed",
                    false,
                    errors);
            }

            return new CommonResponse(
                "User registered successfully",
                true);
        }
        catch (Exception ex)
        {
            return new CommonResponse(
                "There is a problem during registration",
                false,
                new List<string> { ex.Message });
        }
    }
}