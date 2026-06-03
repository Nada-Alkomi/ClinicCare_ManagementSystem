using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ClinicCare.DAL.Models;

namespace ClinicCare.DAL.ModelConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> modelbuilder)
    {
        modelbuilder
            .HasKey(u => u.Id);
        
        modelbuilder.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(50);
        
        modelbuilder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(100);
        
        modelbuilder.Property(u => u.PhoneNumber)
            .IsRequired()
            .HasMaxLength(20);
        
        modelbuilder.Property(u => u.Gender)
            .IsRequired()
            .HasMaxLength(10);

        modelbuilder.HasMany(u => u.Appointments)
            .WithOne(a => a.Patient)
            .HasForeignKey(a => a.PatientId)
            .OnDelete(DeleteBehavior.Restrict);   
         

         
    }
}