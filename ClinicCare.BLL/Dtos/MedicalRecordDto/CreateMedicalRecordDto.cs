namespace ClinicCare.BLL.Dtos.MedicalRecordDto;

public class CreateMedicalRecordDto
{
    public Guid PatientId { get; set; }

    public string Diagnosis { get; set; } = string.Empty;

    public string Treatment { get; set; } = string.Empty;

    public DateTime RecordDate { get; set; }
}