using Sat.Recruitment.Core.Enums;
using System.Text.Json.Serialization;

namespace Sat.Recruitment.Recruitment.Core.DTOs
{
    public class UserCreateResponseDTO
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public UserType UserType { get; set; }

        public decimal Money { get; set; }
    }
}
