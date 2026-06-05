namespace ClinicCare.BLL.Dtos.AppointmentDtos;

public class GetAllAppointmentsDto
{
    public Guid Id { get; set; }
    public DateTime AppointmentDate { get; set; }
    public int QueueNumber { get; set; } // رقم الدور
    public string Status { get; set; }   // حالة الموعد (Pending, Confirmed, الخ)
}