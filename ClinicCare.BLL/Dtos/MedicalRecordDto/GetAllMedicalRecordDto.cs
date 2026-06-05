namespace ClinicCare.BLL.Dtos.MedicalRecordDto;

public class GetAllMedicalRecordDto
{
    public Guid Id { get; set; }

    public string Diagnosis { get; set; } = string.Empty;

    public string Treatment { get; set; } = string.Empty;

    public DateTime RecordDate { get; set; }

    public Guid PatientId { get; set; }

    public string PatientName { get; set; } = string.Empty;
}