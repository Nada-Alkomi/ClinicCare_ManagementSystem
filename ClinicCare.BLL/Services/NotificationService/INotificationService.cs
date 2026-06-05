using ClinicCare.BLL.Dtos.NotificationDto;
using ClinicCare.BLL.Dtos.CommonResponse;
using ClinicCare.BLL.Dtos.NotificationDto;

namespace ClinicCare.BLL.Services.NotificationService;

public interface INotificationService
{
   
    Task SendNotificationAsync(Guid userId, string title, string message);

    
    Task<IEnumerable<NotificationDto>> GetUserNotificationsAsync(Guid userId);

  
    Task<CommonResponse> MarkAsReadAsync(Guid notificationId);

   
    Task<CommonResponse> DeleteNotificationAsync(Guid notificationId);
}