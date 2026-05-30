using Clinic.Care.DAL.Models.MedicalRecord;
using ClinicCare.DAL.Models.Appointment;

namespace ClinicCare.DAL.Models;

public class Patient
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string DeviceToken { get; set; } = string.Empty;

    public ICollection<appointment> Appointments { get; set; } = new List<appointment>();
    public ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();
}