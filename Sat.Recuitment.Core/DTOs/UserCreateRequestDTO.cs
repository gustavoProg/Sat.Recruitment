using System.ComponentModel.DataAnnotations;

namespace Sat.Recruitment.Recruitment.Core.DTOs
{
    public class UserCreateRequestDTO
    {
        [Required(ErrorMessage = "The name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The email is required"), EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "The address is required")]
        public string Address { get; set; }


        [Required(ErrorMessage = "The phone is required")]
        public string Phone { get; set; }

        public string UserType { get; set; }

        public string Money { get; set; }
    }
}
