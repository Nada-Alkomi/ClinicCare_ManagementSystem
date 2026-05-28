using ClinicCare.BLL.Dtos.CommonResponse;

namespace ClinicCare.BLL.Services.RoleService;

public interface IRoleService
{
        public Task<CommonResponse> AddRoleAsync(string roleName);
        public Task<CommonResponse> RemoveRoleAsync(string roleName);
        Task<IEnumerable<string>> GetAllRolesAsync();
}