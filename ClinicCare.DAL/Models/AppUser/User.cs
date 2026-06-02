using System.ComponentModel.DataAnnotations;
using Clinic.Care.DAL.Models.MedicalRecord;
using Microsoft.AspNetCore.Identity;
using ClinicCare.DAL.Models.Appointment;
namespace ClinicCare.DAL.Models; 

public class User : IdentityUser<Guid>
{
    
    [Required]
    [MaxLength(50,ErrorMessage ="Name must be less than 50 characters")]
    public string Name { get; set; }=string.Empty;
    [Required]
    public DateTime BirthDate { get; set; }
    
    [Required] 
    [MaxLength(10,ErrorMessage = "Gender must be less than 10 characters")]
    public string Gender { get; set; }=string.Empty;
     
    
    public string? DeviceToken{ get; set; }=string.Empty;
    
    
    public UserRole Role { get; set; } 
    
    public string? ProfilePictureUrl { get; set; }=string.Empty;
    
    
    public virtual ICollection<Appointment.Appointment> Appointments { get; set; }
        = new List<Appointment.Appointment>();
    
    
    public virtual ICollection<MedicalRecord> PatientMedicalRecords { get; set; }
        = new List<MedicalRecord>();

    public virtual ICollection<MedicalRecord> DoctorMedicalRecords { get; set; }
        = new List<MedicalRecord>();
   
}