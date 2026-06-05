using Clinic.Care.DAL.Models.MedicalRecord;
using ClinicCare.DAL.ModelConfigurations;
using ClinicCare.DAL.Models;
using ClinicCare.DAL.Models.Appointment;
using ClinicCare.DAL.Models.Notification;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClinicCare.DAL.Data;

public class AppDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {
        
    }

   

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        new MedicalRecordConfiguration().Configure(modelBuilder.Entity<MedicalRecord>());
         new AppointmentConfiguration().Configure(modelBuilder.Entity<Appointment>());
         new UserConfiguration().Configure(modelBuilder.Entity<User>());
         new NotificationConfiguration().Configure(modelBuilder.Entity<Notification>());

      
    }
    
    public DbSet<Appointment> Appointments=>Set<Appointment>();
    public DbSet<MedicalRecord> MedicalRecords=>Set<MedicalRecord>();
    public DbSet<User> Users =>Set<User>();
    public DbSet<Notification> Notifications => Set<Notification>();
}
