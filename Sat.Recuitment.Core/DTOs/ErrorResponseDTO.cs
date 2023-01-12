using Sat.Recruitment.Core.Enums;

namespace Sat.Recruitment.Core.DTOs
{
    public class ErrorResponseDTO
    {
        public string Code { get; set; }

        public string Message { get; set; }

        public ErrorResponseDTO(ApplicationErrors error, string message)
        {
            Code = $"{((int)error).ToString().PadLeft(3, '0')}-{error}";

            Message = message;
        }
    }

}
