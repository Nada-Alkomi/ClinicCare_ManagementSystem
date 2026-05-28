using System.ComponentModel.DataAnnotations;

namespace ClinicCare.BLL.Dtos.User;

public class LoginDtos
{
    [Required]
    [EmailAddress(ErrorMessage ="Please enter email address")]
    public string Email { get; set; }=string.Empty;
    [Required]
     [MinLength(6,ErrorMessage ="Password must be at least 6 characters")]
    public string Password { get; set; }=string.Empty;
}