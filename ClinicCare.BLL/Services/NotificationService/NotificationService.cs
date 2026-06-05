using ClinicCare.BLL.Dtos.CommonResponse;
using ClinicCare.BLL.Dtos.NotificationDto; 
using ClinicCare.DAL.Models.Notification; 
using Clinic.Care.DAL.Repositories.UntiOfWork;

namespace ClinicCare.BLL.Services.NotificationService;

public class NotificationService : INotificationService
{
    private readonly IUnitOfWork _unitOfWork;

    public NotificationService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

  
    public async Task SendNotificationAsync(Guid userId, string title, string message)
    {
        var notification = new Notification
        {
            UserId = userId,
            Title = title,
            Message = message,
            IsRead = false,
            CreatedAt = DateTime.UtcNow
        };

        await _unitOfWork.Notifications.AddAsync(notification);
        await _unitOfWork.CompleteAsync();
    }

    public async Task<IEnumerable<NotificationDto>> GetUserNotificationsAsync(Guid userId)
    {
       
        var notifications = await _unitOfWork.Notifications.FindAsync(n => n.UserId == userId);
    
        return notifications
            .OrderByDescending(n => n.CreatedAt)
            .Select(n => new NotificationDto
            {
                Id = n.Id,
                Title = n.Title,
                Message = n.Message,
                IsRead = n.IsRead,
                CreatedAt = n.CreatedAt
            });
    }

  
    public async Task<CommonResponse> MarkAsReadAsync(Guid notificationId)
    {
        var notification = await _unitOfWork.Notifications.GetByIdAsync(notificationId);
        
        if (notification == null)
            return new CommonResponse("Notification not found", false);

        notification.IsRead = true;
        _unitOfWork.Notifications.Update(notification);
        await _unitOfWork.CompleteAsync();

        return new CommonResponse("Notification marked as read", true);
    }

 
    public async Task<CommonResponse> DeleteNotificationAsync(Guid notificationId)
    {
        var notification = await _unitOfWork.Notifications.GetByIdAsync(notificationId);
        
        if (notification == null)
            return new CommonResponse("Notification not found", false);

        _unitOfWork.Notifications.Delete(notification);
        await _unitOfWork.CompleteAsync();

        return new CommonResponse("Notification deleted successfully", true);
    }
}