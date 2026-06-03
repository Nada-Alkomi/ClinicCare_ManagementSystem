
using System.ComponentModel.DataAnnotations;
using ClinicCare.DAL.Models;
using ClinicCare.DAL.Models.Appointment;
using ClinicCare.DAL.Models.BaseModel;


namespace Clinic.Care.DAL.Models.MedicalRecord;

public class MedicalRecord : BaseModel<Guid>
{
    
    public DateTime DateCreated { get; set; }
    
    public string Diagnosis { get; set; } = string.Empty;
    
    public string Treatment { get; set; } = string.Empty;

    public string? Prescription { get; set; }

    public string? Notes { get; set; }

    public Guid PatientId { get; set; }

    public virtual User Patient { get; set; } = null!;

    public Guid AppointmentId { get; set; }

    public virtual Appointment Appointment { get; set; } = null!;
}
