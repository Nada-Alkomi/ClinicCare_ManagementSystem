using Clinic.Care.DAL.Models.MedicalRecord;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ClinicCare.DAL.Models;

namespace ClinicCare.DAL.ModelConfigurations;

public class MedicalRecordConfiguration : IEntityTypeConfiguration<MedicalRecord>
{
    public void Configure(EntityTypeBuilder<MedicalRecord> modelbuilder)
    {
        modelbuilder.HasKey(m => m.Id);
        modelbuilder.Property(m => m.Diagnosis).IsRequired().HasMaxLength(500);
        modelbuilder.Property(m => m.Treatment).IsRequired().HasMaxLength(500);
        modelbuilder.Property(m => m.DateCreated).IsRequired();    
       

        modelbuilder.HasOne(m => m.Appointment)
            .WithOne(a => a.MedicalRecord)
            .HasForeignKey<MedicalRecord>(m => m.AppointmentId)
            .OnDelete(DeleteBehavior.Restrict);
                    
    }
}