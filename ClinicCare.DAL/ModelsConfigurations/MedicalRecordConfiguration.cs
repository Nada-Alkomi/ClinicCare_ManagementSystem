using Clinic.Care.DAL.Models.MedicalRecord;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicCare.DAL.ModelConfigurations;

public class MedicalRecordConfiguration : IEntityTypeConfiguration<MedicalRecord>
{
    public void Configure(EntityTypeBuilder<MedicalRecord> builder)
    {
        builder.Property(m => m.DateCreated)
            .HasColumnType("datetime2")
            .IsRequired();

        builder.Property(m => m.Diagnosis)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(m => m.Treatment)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(m => m.Prescription)
            .HasMaxLength(200);

        builder.Property(m => m.Notes)
            .HasMaxLength(300);

     
        builder.HasOne(m => m.Appointment)
            .WithOne(a => a.MedicalRecord)
            .HasForeignKey<MedicalRecord>(m => m.AppointmentId)
            .OnDelete(DeleteBehavior.Restrict);

     
        builder.HasOne(m => m.Patient)
            .WithMany(u => u.MedicalRecords)
            .HasForeignKey(m => m.PatientId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}