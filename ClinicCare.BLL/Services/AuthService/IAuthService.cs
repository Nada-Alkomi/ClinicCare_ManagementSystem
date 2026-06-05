using ClinicCare.BLL.Dtos.CommonResponse;
using ClinicCare.BLL.Dtos.User;

namespace ClinicCare.BLL.Services.AuthService;

public interface IAuthService
{
    Task<CommonResponse> RegisterPatientAsync(RegistrationDtos dto);

    Task<CommonResponse> RegisterDoctorAsync(RegistrationDtos dto);

    Task<CommonResponse> RegisterAdminAsync(RegistrationDtos dto);

    Task<CommonResponse> LoginAsync(LoginDtos dto);
}