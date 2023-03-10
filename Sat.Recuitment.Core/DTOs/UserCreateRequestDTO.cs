using Sat.Recruitment.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public UserType UserType { get; set; }

        public decimal Money { get; set; }
    }
}
