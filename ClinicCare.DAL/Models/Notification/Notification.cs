using ClinicCare.DAL.Models.BaseModel;

namespace ClinicCare.DAL.Models.Notification;

public class Notification : BaseModel<Guid>
{
    public Guid UserId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public bool IsRead { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public virtual User User { get; set; } = null!; 
}
