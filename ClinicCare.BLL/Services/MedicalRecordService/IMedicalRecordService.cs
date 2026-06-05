using Clinic.Care.DAL.QueryHandler;
using ClinicCare.BLL.Dtos.MedicalRecordDto;
using ClinicCare.BLL.Dtos.CommonResponse; // لازم تضيفي الـ namespace ده

namespace ClinicCare.BLL.Services.MedicalRecordService;

public interface IMedicalRecordService
{
    Task<IEnumerable<GetAllMedicalRecordDto>> GetAllMedicalRecordsAsync(Query query);

    Task<GetByIdMedicalRecordDto?> GetMedicalRecordByIdAsync(Guid id);

    Task<CommonResponse> AddMedicalRecordAsync(CreateMedicalRecordDto dto);

    Task<CommonResponse> UpdateMedicalRecordAsync(Guid id, UpdateMedicalRecordDto dto);

    Task<CommonResponse> DeleteMedicalRecordAsync(Guid id);
}
