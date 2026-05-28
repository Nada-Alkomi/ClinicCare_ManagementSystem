using ClinicCare.BLL.Dtos.CommonResponse;
using ClinicCare.BLL.Dtos.User;

namespace ClinicCare.BLL.Services.AuthService;

public interface IAuthService
{
    public Task<CommonResponse> RegisterAsync(RegistrationDtos dto);
   public Task<CommonResponse> LoginAsync(LoginDtos dto);
}