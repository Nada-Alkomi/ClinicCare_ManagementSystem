namespace ClinicCare.BLL.Dtos.MedicalRecordDto;

public class UpdateMedicalRecordDto
{
    public string Diagnosis { get; set; } = string.Empty;

    public string Treatment { get; set; } = string.Empty;

    public Guid PatientId { get; set; }
}