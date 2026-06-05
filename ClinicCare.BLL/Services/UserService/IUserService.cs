using ClinicCare.BLL.Dtos.CommonResponse;
using ClinicCare.BLL.Dtos.User;
using ClinicCare.BLL.Dtos.UserDto;

namespace ClinicCare.BLL.Services.UserService;

public interface IUserService
{
    Task<IEnumerable<GetAllUsersDto>> GetAllUsersAsync();

    Task<IEnumerable<GetAllPatientsDto>> GetAllPatientsAsync();

    Task<GetUserByIdDto?> GetUserByIdAsync(Guid id);

    Task<CommonResponse> UpdateUserAsync(Guid id, UpdateUserDto dto);

    Task<CommonResponse> DeleteUserAsync(Guid id);
    
}