using System.ComponentModel.DataAnnotations;

namespace SafetyClone_project.Models
{
    public class UserLogin
    {
        [Required]
        public long Id { get; set; }
        public string  Email{get; set;}
        [Required]
        public string Password { get; set;}
        [Required]
        public string RoleName { get; set;}
    }
}
