using Clinic.Care.DAL.Models.MedicalRecord;
using Clinic.Care.DAL.QueryHandler;
using Clinic.Care.DAL.Repositories.UntiOfWork;
using ClinicCare.BLL.Dtos.MedicalRecordDto; 
using ClinicCare.DAL.Models; 
using ClinicCare.BLL.Dtos.CommonResponse;
using ClinicCare.BLL.Dtos.MedicalRecordDto;

namespace ClinicCare.BLL.Services.MedicalRecordService;

public class MedicalRecordService : IMedicalRecordService
{
    private readonly IUnitOfWork _unitOfWork;
    
    public MedicalRecordService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<GetAllMedicalRecordDto>> GetAllMedicalRecordsAsync(Query query)
    {
        var medicalRecords = await _unitOfWork.MedicalRecords.GetAllAsync(query, m => m.Patient);

        return medicalRecords.Select(m => new GetAllMedicalRecordDto
        {
            Id = m.Id,
            Diagnosis = m.Diagnosis,
            PatientId = m.PatientId,
            PatientName = m.Patient?.Name 
        });
    }

    public async Task<GetByIdMedicalRecordDto?> GetMedicalRecordByIdAsync(Guid id)
    {
        var medicalRecord = await _unitOfWork.MedicalRecords.GetByIdAsync(id, m => m.Patient);

        if (medicalRecord == null) return null;

        return new GetByIdMedicalRecordDto
        {
            Id = medicalRecord.Id,
            Diagnosis = medicalRecord.Diagnosis,
            PatientId = medicalRecord.PatientId,
            PatientName = medicalRecord.Patient?.Name
        };
    }

    public async Task<CommonResponse> AddMedicalRecordAsync(CreateMedicalRecordDto dto)
    {
        var medicalRecord = new MedicalRecord
        {
            PatientId = dto.PatientId,
            Diagnosis = dto.Diagnosis
        };

        await _unitOfWork.MedicalRecords.AddAsync(medicalRecord);
        await _unitOfWork.CompleteAsync(); 
        
        return new CommonResponse("Medical Record added successfully", true);
    }

    public async Task<CommonResponse> UpdateMedicalRecordAsync(Guid id, UpdateMedicalRecordDto dto)
    {
        var medicalRecord = await _unitOfWork.MedicalRecords.GetByIdAsync(id);
        
        if (medicalRecord == null)
            return new CommonResponse("Medical record not found", false);
        
        medicalRecord.Diagnosis = dto.Diagnosis;
        
        _unitOfWork.MedicalRecords.Update(medicalRecord);
        await _unitOfWork.CompleteAsync();
        
        return new CommonResponse("Medical Record updated successfully", true);
    }

    public async Task<CommonResponse> DeleteMedicalRecordAsync(Guid id)
    {
        var medicalRecord = await _unitOfWork.MedicalRecords.GetByIdAsync(id);
        
        if (medicalRecord == null)
            return new CommonResponse("Medical record not found", false);

        _unitOfWork.MedicalRecords.Delete(medicalRecord);
        await _unitOfWork.CompleteAsync();
        
        return new CommonResponse("Medical Record deleted successfully", true);
    }
}