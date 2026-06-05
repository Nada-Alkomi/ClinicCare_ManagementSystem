using ClinicCare.BLL.Dtos.AppointmentDtos;
using ClinicCare.BLL.Dtos.CommonResponse;

namespace ClinicCare.BLL.Services.AppointmentService;

public interface IAppointmentService
{
  
    Task<CommonResponse> BookAppointmentAsync(CreateAppointmentDto dto);

    Task<IEnumerable<GetAllAppointmentsDto>> GetAllAppointmentsAsync();

    Task<GetAppointmentByIdDto> GetAppointmentByIdAsync(Guid id);

    Task<CommonResponse> CancelAppointmentAsync(Guid id);

    Task<CommonResponse> ConfirmAppointmentAsync(Guid id);

    Task<CommonResponse> CompleteAppointmentAsync(Guid id);
}