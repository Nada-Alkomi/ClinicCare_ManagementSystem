namespace ClinicCare.BLL.Dtos.AppointmentDtos;

public class UpdateAppointmentDto
{
    public Guid Id { get; set; } = Guid.Empty;

    public DateTime Date { get; set; }

    public string Time { get; set; } = string.Empty;

    public string Reason { get; set; } = string.Empty;
    

     public Guid PatientId { get; set; } = Guid.Empty;
}