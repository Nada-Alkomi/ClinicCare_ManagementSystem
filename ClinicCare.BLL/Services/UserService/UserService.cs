using Clinic.Care.DAL.QueryHandler;
using Clinic.Care.DAL.Repositories.UntiOfWork;
using ClinicCare.BLL.Dtos.CommonResponse;
using ClinicCare.BLL.Dtos.UserDto;
using ClinicCare.DAL.Models;

namespace ClinicCare.BLL.Services.UserService;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<GetAllUsersDto>> GetAllUsersAsync()
    {
        var query = new Query
        {
            pageNumber = 1,
            pagesize = 100
        };

       
        var users = await _unitOfWork.Users.GetAllAsync(query);

        return users.Select(u => new GetAllUsersDto
        {
            Id = u.Id,
            Name = u.Name,
            Email = u.Email ?? string.Empty,
            PhoneNumber = u.PhoneNumber ?? string.Empty,
            Role = u.Role
        });
    }

    public async Task<IEnumerable<GetAllPatientsDto>> GetAllPatientsAsync()
    {
        var query = new Query
        {
            pageNumber = 1,
            pagesize = 100
        };

       
        var users = await _unitOfWork.Users.GetAllAsync(query);

        return users
            .Where(u => u.Role == UserRole.Patient)
            .Select(u => new GetAllPatientsDto
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email ?? string.Empty,
                PhoneNumber = u.PhoneNumber ?? string.Empty
            });
    }

    public async Task<GetUserByIdDto?> GetUserByIdAsync(Guid id)
    {
    
        var user = await _unitOfWork.Users.GetByIdAsync(id);

        if (user == null)
            return null;

        return new GetUserByIdDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email ?? string.Empty,
            PhoneNumber = user.PhoneNumber ?? string.Empty,
            BirthDate = user.BirthDate,
            Gender = user.Gender,
            Role = user.Role,
            ProfilePictureUrl = user.ProfilePictureUrl
        };
    }

    public async Task<CommonResponse> UpdateUserAsync(Guid id, UpdateUserDto dto)
    {
       
        var user = await _unitOfWork.Users.GetByIdAsync(id);

        if (user == null)
            return new CommonResponse("User not found", false);

        user.Name = dto.Name;
        user.PhoneNumber = dto.PhoneNumber;
        user.BirthDate = dto.BirthDate;
        user.Gender = dto.Gender;
        user.ProfilePictureUrl = dto.ProfilePictureUrl;

        _unitOfWork.Users.Update(user);

       
        await _unitOfWork.CompleteAsync();

        return new CommonResponse("User updated successfully", true);
    }

    public async Task<CommonResponse> DeleteUserAsync(Guid id)
    {
    
        var user = await _unitOfWork.Users.GetByIdAsync(id);

        if (user == null)
            return new CommonResponse("User not found", false);

        _unitOfWork.Users.Delete(user);

        
        await _unitOfWork.CompleteAsync();

        return new CommonResponse("User deleted successfully", true);
    }
}