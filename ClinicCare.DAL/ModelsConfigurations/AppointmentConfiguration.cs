using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ClinicCare.DAL.Models;
using ClinicCare.DAL.Models.Appointment;

namespace ClinicCare.DAL.ModelConfigurations;

public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> modelbuilder)
    {
        modelbuilder.Property(a => a.AppointmentDate)
            .HasColumnType("datetime2");
        modelbuilder.Property(a => a.QueueNumber)
            .IsRequired();
        modelbuilder.Property(a => a.Status)
            .HasConversion<string>();
        modelbuilder.HasOne(a => a.Patient)
            .WithMany(p => p.Appointments)
            .HasForeignKey(a => a.PatientId)
            .OnDelete(DeleteBehavior.Restrict);
            
        
    }

}