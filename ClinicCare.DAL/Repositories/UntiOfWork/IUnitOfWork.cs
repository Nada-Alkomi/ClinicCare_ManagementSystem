using Clinic.Care.DAL.Models.MedicalRecord;
using Clinic.Care.DAL.Repositories.GenericRepo;
using ClinicCare.DAL.Models;
using ClinicCare.DAL.Models.Appointment;
using ClinicCare.DAL.Models.Notification; 

namespace Clinic.Care.DAL.Repositories.UntiOfWork;

public interface IUnitOfWork : IDisposable
{
    IGenericRepo<Appointment> Appointments { get; }
    IGenericRepo<User> Users { get; }
    IGenericRepo<MedicalRecord> MedicalRecords { get; }
    IGenericRepo<Notification> Notifications { get; } 

    Task<int> CompleteAsync(); 
}