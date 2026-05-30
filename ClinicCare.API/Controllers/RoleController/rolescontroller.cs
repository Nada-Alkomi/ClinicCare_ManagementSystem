using ClinicCare.BLL.Services.RoleService;
using Microsoft.AspNetCore.Mvc;

namespace ClinicCare.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoleController : ControllerBase
{
    private readonly IRoleService _roleService;


    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddRoleDtoAsync([FromBody] string roleName)
    {
        var response = await _roleService.AddRoleAsync(roleName);
        if (!response.IsSuccess)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }

    [HttpDelete("remove")]
    public async Task<IActionResult> RemoveRoleAsync([FromBody] string roleName)
    {
        var response = await _roleService.RemoveRoleAsync(roleName);
        if (!response.IsSuccess)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllRolesAsync()
    {
        var roles = await _roleService.GetAllRolesAsync();
        return Ok(roles);
    }
}