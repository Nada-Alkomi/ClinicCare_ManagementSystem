using Microsoft.AspNetCore.Mvc;
using ClinicCare.BLL.Services.UserService;
using ClinicCare.BLL.Dtos.UserDto;
using Microsoft.AspNetCore.Authorization;

namespace ClinicCare.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _service;

    public UserController(IUserService service)
    {
        _service = service;
    }

    [Authorize(Roles = "Admin,Doctor")]
    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllUsersAsync();
        return Ok(result);
    }


    [Authorize(Roles = "Doctor")]
    [HttpGet("patients")]
    public async Task<IActionResult> GetAllPatients()
    {
        var result = await _service.GetAllPatientsAsync();
        return Ok(result);
    }


    [Authorize(Roles = "Doctor,Patient")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _service.GetUserByIdAsync(id);
        if (result == null)
            return NotFound("User not found.");

        return Ok(result);
    }

    [Authorize(Roles = "Doctor,Patient")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUserDto dto)
    {
        var response = await _service.UpdateUserAsync(id, dto);
        if (!response.IsSuccess)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }

  
    [Authorize(Roles = "Doctor")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var response = await _service.DeleteUserAsync(id);
        if (!response.IsSuccess)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
}