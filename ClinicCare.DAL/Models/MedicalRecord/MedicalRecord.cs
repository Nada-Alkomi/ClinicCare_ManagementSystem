
using System.ComponentModel.DataAnnotations;
using ClinicCare.DAL.Models;
using ClinicCare.DAL.Models.Appointment;
using ClinicCare.DAL.Models.BaseModel;


namespace Clinic.Care.DAL.Models.MedicalRecord;

public class MedicalRecord:BaseModel<Guid>
{

    public DateTime DateCreated { get; set; }

   
    public string? Diagnosis { get; set; }
    public string? Treatment { get; set; }

    [MaxLength(200, ErrorMessage = "Prescription must be less than 200 characters")]
    public string? Prescription { get; set; }

    [MaxLength(300, ErrorMessage = "Notes must be less than 300 characters")]
    public string? Notes { get; set; }
    public virtual Guid AppointmentId { get; set; }

    public virtual  Appointment Appointment { get; set; } = null!;
}
