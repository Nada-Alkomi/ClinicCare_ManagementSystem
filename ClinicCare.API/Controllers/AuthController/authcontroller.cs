using ClinicCare.BLL.Dtos.CommonResponse;
using ClinicCare.BLL.Dtos.User;
using ClinicCare.BLL.Services.AuthService;
using Microsoft.AspNetCore.Mvc;

namespace ClinicCare.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register-patient")]
    public async Task<ActionResult<CommonResponse>> RegisterPatientAsync(
        [FromBody] RegistrationDtos dto)
    {
        var response = await _authService.RegisterPatientAsync(dto);

        if (!response.IsSuccess)
            return BadRequest(response);

        return Ok(response);
    }

    [HttpPost("register-doctor")]
    public async Task<ActionResult<CommonResponse>> RegisterDoctorAsync(
        [FromBody] RegistrationDtos dto)
    {
        var response = await _authService.RegisterDoctorAsync(dto);

        if (!response.IsSuccess)
            return BadRequest(response);

        return Ok(response);
    }

    [HttpPost("register-admin")]
    public async Task<ActionResult<CommonResponse>> RegisterAdminAsync(
        [FromBody] RegistrationDtos dto)
    {
        var response = await _authService.RegisterAdminAsync(dto);

        if (!response.IsSuccess)
            return BadRequest(response);

        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<ActionResult<CommonResponse>> LoginAsync(
        [FromBody] LoginDtos dto)
    {
        var response = await _authService.LoginAsync(dto);

        if (!response.IsSuccess)
            return BadRequest(response);

        return Ok(response);
    }
}