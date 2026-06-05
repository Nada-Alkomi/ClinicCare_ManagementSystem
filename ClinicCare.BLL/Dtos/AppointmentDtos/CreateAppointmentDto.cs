namespace ClinicCare.BLL.Dtos.AppointmentDtos;

public class CreateAppointmentDto
{
    public Guid PatientId { get; set; }

    public DateTime AppointmentDate { get; set; }
}