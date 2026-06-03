using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ClinicCare.DAL.Models;
using ClinicCare.DAL.Models.Appointment;

namespace ClinicCare.DAL.ModelConfigurations;


    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.Property(a => a.AppointmentDate)
                .HasColumnType("datetime2")
                .IsRequired();

            builder.Property(a => a.QueueNumber)
                .IsRequired();

            builder.Property(a => a.Status)
                .HasConversion<string>();

            builder.Property(a => a.IsFollowUpReminderSent)
                .HasDefaultValue(false);

            builder.HasOne(a => a.Patient)
                .WithMany(u => u.Appointments)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

