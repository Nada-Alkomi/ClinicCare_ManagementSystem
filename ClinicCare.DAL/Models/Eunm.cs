
namespace ClinicCare.DAL.Models; 

public enum AppointmentStatus
{
    Pending = 1,
    Confirmed = 2,
    Cancelled = 3,
    Completed = 4
}


public enum UserRole
{
    Patient = 1,
    Admin = 2,
    Doctor = 3
}