using Clinic.Care.DAL.Models.MedicalRecord;
using Clinic.Care.DAL.Repositories.GenericRepo;
using ClinicCare.DAL.Data;

namespace Clinic.Care.DAL.Repositories.MedicalRecordRepo;

public class MedicalRecordRepo
    : GenericRepo<MedicalRecord>, IMedicalRecordRepo
{
    public MedicalRecordRepo(AppDbContext context)
        : base(context)
    {
    }
}