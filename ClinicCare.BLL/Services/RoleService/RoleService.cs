using System.Collections;
using ClinicCare.BLL.Dtos.CommonResponse;
using Microsoft.AspNetCore.Identity;

namespace ClinicCare.BLL.Services.RoleService;

public class RoleService:IRoleService
{
  private readonly RoleManager<IdentityRole<Guid>> _roleManager;
  public RoleService(RoleManager<IdentityRole<Guid>> roleManager)
  {
    _roleManager = roleManager;
  }

  public async Task<CommonResponse> AddRoleAsync(string roleName)
  {
    var role = await _roleManager.FindByNameAsync(roleName);
    if (role is not null)
    {
      return new CommonResponse("Role already exists", false);
    }
    var result = await _roleManager.CreateAsync(new IdentityRole<Guid>(roleName));
    if (!result.Succeeded)
    {
      var errors=result.Errors.Select(e=>e.Description).ToList();
      return new CommonResponse("can't create role currently", false, errors: errors);
    }
    return new CommonResponse("role created successfully", true);  
  }
  

  public async   Task<CommonResponse> RemoveRoleAsync(string roleName)
  {
    var role = await _roleManager.FindByNameAsync(roleName);
    if (role is null)
    {
      return new CommonResponse("Role not found", false);
    }
    var result = await _roleManager.DeleteAsync(role);
    if (!result.Succeeded)
    {
      var errors=result.Errors.Select(e=>e.Description).ToList();
      return new CommonResponse("can't delete role currently", false, errors: errors);
    }
    return new CommonResponse("role deleted successfully", true);
  }
  public async Task<IEnumerable<string>> GetAllRolesAsync() 
  {
    var roles = _roleManager.Roles.Select(r => r.Name ?? "").ToList();
    return roles; 
  }
  
}