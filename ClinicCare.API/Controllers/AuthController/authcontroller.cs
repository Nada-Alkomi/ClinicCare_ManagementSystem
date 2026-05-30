using ClinicCare.BLL.Dtos.CommonResponse;
using ClinicCare.BLL.Dtos.User;
using ClinicCare.BLL.Services.AuthService;
using Microsoft.AspNetCore.Mvc;

namespace ClinicCare.API.Controllers.AuthController;

public class authcontrollerc:ControllerBase
{
    private readonly IAuthService _authService; 
    public authcontrollerc(IAuthService authService)
    {
        _authService = authService;
    }
        
    [HttpPost("register")]
    public async Task<ActionResult<CommonResponse>> RegisterAsync( RegistrationDtos dto)
    {
        var response = await _authService.RegisterAsync(dto);
        if (!response.IsSuccess)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<ActionResult<CommonResponse>> LoginAsync( LoginDtos dto)
    {
        var response = await _authService.LoginAsync(dto);
        if (!response.IsSuccess)
        {
            return BadRequest(response);

        }

        return Ok(response);
    }
}