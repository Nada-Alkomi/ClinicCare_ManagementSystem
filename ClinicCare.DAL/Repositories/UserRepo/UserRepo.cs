using Clinic.Care.DAL.Repositories.AppointmentRepo;
using Clinic.Care.DAL.Repositories.GenericRepo;
using Clinic.Care.DAL.Repositories.MedicalRecordRepo;
using ClinicCare.DAL.Data;
using ClinicCare.DAL.Models;

namespace Clinic.Care.DAL.Repositories.UserRepo;

public class UserRepo : GenericRepo<User>, IUserRepo
{
    public UserRepo(AppDbContext context): base(context)
    {
    }

 
    
    
}