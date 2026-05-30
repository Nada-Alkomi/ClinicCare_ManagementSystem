
using ClinicCare.DAL.Models;
using ClinicCare.DAL.Models.Appointment;
using static ClinicCare.DAL.Models.Patient;


namespace Clinic.Care.DAL.Models.MedicalRecord;

public class MedicalRecord
{
    public int Id { get; set; }
    public DateTime RecordDate { get; set; }
    public string Diagnosis { get; set; } = string.Empty;
    public string Treatment { get; set; } = string.Empty;

    public int PatientId { get; set; }
    public int AppointmentId { get; set; } 
    
    
    public Patient Patient { get; set; } = null!;
    public appointment Appointment { get; set; } = null!;
}

