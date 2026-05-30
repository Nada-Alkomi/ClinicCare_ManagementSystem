using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Care.DAL.Data;

public class AppDbContext:IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {
        
    }
    public DbSet<Models.AppUser> AppUsers { get; set; } = null!;
    public DbSet<Models.Patient.patient> Patients { get; set; } = null!;
    public DbSet<Models.Appointment.appointment> Appointments { get; set; } = null!;
    public DbSet<Models.MedicalRecord.medicalRecord> MedicalRecords { get; set; } = null!;

    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}