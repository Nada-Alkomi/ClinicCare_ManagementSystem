using System.Security.Principal;
using Microsoft.AspNetCore.Identity;
namespace Clinic.Care.DAL.Models;
public class AppUser:IdentityUser
{
    public string FullName { get; set; } = string.Empty;
   
    public string? Address { get; set; }
    public string? ProfilePicture { get; set; }
    
}

