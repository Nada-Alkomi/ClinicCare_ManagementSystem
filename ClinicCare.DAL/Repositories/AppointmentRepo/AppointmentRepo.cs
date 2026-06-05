using System.Linq.Expressions;
using Clinic.Care.DAL.QueryHandler;
using Clinic.Care.DAL.Repositories.GenericRepo;
using ClinicCare.DAL.Data;
using ClinicCare.DAL.Models.Appointment;

namespace Clinic.Care.DAL.Repositories.AppointmentRepo;

public class AppointmentRepo:GenericRepo<Appointment>,IAppointmentRepo
{
    public AppointmentRepo(AppDbContext context) : base(context)
    {
       
    }

    public Task<IEnumerable<Appointment>> GetAllAsync(Query query, params Expression<Func<Appointment, object>>[] include)
    {
        throw new NotImplementedException();
    }

    public Task<Appointment> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Appointment entity)
    {
        throw new NotImplementedException();
    }

    public void Update(Appointment entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Appointment entity)
    {
        throw new NotImplementedException();
    }
}