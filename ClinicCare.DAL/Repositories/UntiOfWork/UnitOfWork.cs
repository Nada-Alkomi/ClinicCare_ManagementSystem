using Clinic.Care.DAL.Models.MedicalRecord;
using Clinic.Care.DAL.Repositories.GenericRepo;
using ClinicCare.DAL.Data;
using ClinicCare.DAL.Models;
using ClinicCare.DAL.Models.Appointment;
using ClinicCare.DAL.Models.Notification;

namespace Clinic.Care.DAL.Repositories.UntiOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public IGenericRepo<Appointment> Appointments { get; }
    public IGenericRepo<User> Users { get; }
    public IGenericRepo<MedicalRecord> MedicalRecords { get; }
    public IGenericRepo<Notification> Notifications { get; } 
    
    public UnitOfWork(AppDbContext context)    
    {
        _context = context;
        Appointments = new GenericRepo<Appointment>(_context);
        Users = new GenericRepo<User>(_context);
        MedicalRecords = new GenericRepo<MedicalRecord>(_context);
        Notifications = new GenericRepo<Notification>(_context); 
    } 

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

   
    public void Dispose()
    {
        _context.Dispose();
    }
}