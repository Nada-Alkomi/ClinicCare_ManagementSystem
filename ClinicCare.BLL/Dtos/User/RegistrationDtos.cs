using System.ComponentModel.DataAnnotations;

namespace ClinicCare.BLL.Dtos.User;

public class RegistrationDtos
{
    [Required]
    [MaxLength(50,ErrorMessage ="Name must be less than 50 characters")]
    public string Name { get; set; }=string.Empty;
    [Required]
    [EmailAddress(ErrorMessage ="Please enter email address")]
    public string Email { get; set; }=string.Empty;
    
    [Required]
    [MinLength(6,ErrorMessage ="Password must be at least 6 characters")]
    public string Password { get; set; }=string.Empty;
    
    [Required]
    [Compare(nameof(Password),ErrorMessage ="Password and confirm password must match")]
    public string ConfirmPassword { get; set; }=string.Empty;
    [Required]
    [MaxLength(100)]
    public string Gender { get; set; }=string.Empty;
    [Required]
    [Phone]
    [RegularExpression(@"^01[0125][0-9]{8}$", ErrorMessage = "Please enter a valid Egyptian phone number")]
    public string PhoneNumber { get; set; }=string.Empty;
   
    
}