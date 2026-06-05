namespace ClinicCare.BLL.Dtos.AppointmentDtos;

public class GetAppointmentByIdDto
{
    public Guid Id { get; set; }
    public Guid PatientId { get; set; }
    public DateTime AppointmentDate { get; set; }
    public int QueueNumber { get; set; }
    public string Status { get; set; }
    public DateTime CreateAtTimeStamp { get; set; } 
    public bool IsFollowUpReminderSent { get; set; }
    
    
}