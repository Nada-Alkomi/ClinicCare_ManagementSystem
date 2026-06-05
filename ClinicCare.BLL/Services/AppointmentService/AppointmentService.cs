using Clinic.Care.DAL.Repositories.UntiOfWork;
using ClinicCare.BLL.Dtos.AppointmentDtos;
using ClinicCare.BLL.Dtos.CommonResponse;
using ClinicCare.DAL.Models;
using ClinicCare.DAL.Models.Appointment; 
using ClinicCare.DAL.Models.Notification; 

namespace ClinicCare.BLL.Services.AppointmentService;

public class AppointmentService : IAppointmentService
{
    private readonly IUnitOfWork _unitOfWork;

    public AppointmentService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CommonResponse> BookAppointmentAsync(CreateAppointmentDto dto)
    {
        try
        {
            var appointmentsToday = await _unitOfWork.Appointments.FindAsync(a => 
                a.AppointmentDate.Date == dto.AppointmentDate.Date);

            int queueNumber = appointmentsToday.Any() 
                ? appointmentsToday.Max(a => a.QueueNumber) + 1 
                : 1;
           
            var appointment = new Appointment
            {
                PatientId = dto.PatientId,            
                AppointmentDate = dto.AppointmentDate,
                QueueNumber = queueNumber,
                Status = AppointmentStatus.Pending,   
                IsFollowUpReminderSent = false        
            };

            await _unitOfWork.Appointments.AddAsync(appointment);

            var notification = new Notification
            {
                UserId = dto.PatientId,
                Title = "Appointment Confirmation",
                Message = $"Your appointment has been booked successfully. Your queue number is {queueNumber}.",
                CreatedAt = DateTime.UtcNow,
                IsRead = false
            };

            await _unitOfWork.Notifications.AddAsync(notification);

            await _unitOfWork.CompleteAsync(); 

            return new CommonResponse 
            { 
                IsSuccess = true, 
                Message = $"Appointment booked successfully. Your queue number is {queueNumber}." 
            };
        }
        catch (Exception ex)
        {
            return new CommonResponse 
            { 
                IsSuccess = false, 
                Message = "An error occurred while booking your appointment. Please try again later." 
            };
        }
    }

    public async Task<CommonResponse> ConfirmAppointmentAsync(Guid id)
    {
        var appointment = await _unitOfWork.Appointments.GetByIdAsync(id);
        if (appointment == null!)
            return new CommonResponse { IsSuccess = false, Message = "Appointment not found." };

       
        appointment.Status = AppointmentStatus.Confirmed; 
        _unitOfWork.Appointments.Update(appointment);
        await _unitOfWork.CompleteAsync();

        return new CommonResponse { IsSuccess = true, Message = "Appointment confirmed successfully." };
    }

    public async Task<CommonResponse> CancelAppointmentAsync(Guid id)
    {
        var appointment = await _unitOfWork.Appointments.GetByIdAsync(id);
        if (appointment == null!)
            return new CommonResponse { IsSuccess = false, Message = "Appointment not found." };

        appointment.Status = AppointmentStatus.Cancelled; 
        _unitOfWork.Appointments.Update(appointment);
        await _unitOfWork.CompleteAsync();

        return new CommonResponse { IsSuccess = true, Message = "Appointment cancelled successfully." };
    }

    public async Task<CommonResponse> CompleteAppointmentAsync(Guid id)
    {
        var appointment = await _unitOfWork.Appointments.GetByIdAsync(id);
        if (appointment == null!)
            return new CommonResponse { IsSuccess = false, Message = "Appointment not found." };

        appointment.Status = AppointmentStatus.Completed; 
        _unitOfWork.Appointments.Update(appointment);
        await _unitOfWork.CompleteAsync();

        return new CommonResponse { IsSuccess = true, Message = "Appointment completed successfully." };
    }

    public async Task<IEnumerable<GetAllAppointmentsDto>> GetAllAppointmentsAsync()
    {
        var appointments = await _unitOfWork.Appointments.GetAllAsync(new Clinic.Care.DAL.QueryHandler.Query()); 
        
        return appointments.Select(a => new GetAllAppointmentsDto
        {
            Id = a.Id, 
            AppointmentDate = a.AppointmentDate,
            QueueNumber = a.QueueNumber,
            Status = a.Status.ToString() 
        });
    }

    public async Task<GetAppointmentByIdDto> GetAppointmentByIdAsync(Guid id)
    {
        var appointment = await _unitOfWork.Appointments.GetByIdAsync(id); 

        if (appointment == null!) return null!;

        return new GetAppointmentByIdDto
        {
            Id = appointment.Id, 
            AppointmentDate = appointment.AppointmentDate,
            QueueNumber = appointment.QueueNumber,
            Status = appointment.Status.ToString(),
        };
    }
}