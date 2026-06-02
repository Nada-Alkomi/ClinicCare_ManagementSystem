using Clinic.Care.DAL.Models;
using Clinic.Care.DAL.Models.MedicalRecord;
using ClinicCare.DAL.Models.BaseModel;
namespace ClinicCare.DAL.Models.Appointment;

public class Appointment:BaseModel<Guid>
{
   

    public DateTime AppointmentDate { get; set; }

    public int QueueNumber { get; set; }

    public AppointmentStatus Status { get; set; }

    public bool IsFollowUpReminderSent { get; set; }

    public DateTime CreatedAt { get; set; }


    public virtual Guid PatientId { get; set; }

    public virtual User Patient { get; set; } = null!;

    public virtual MedicalRecord? MedicalRecord { get; set; }
}