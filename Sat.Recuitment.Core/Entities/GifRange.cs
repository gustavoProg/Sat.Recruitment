using Sat.Recruitment.Core.Enums;

namespace Sat.Recruitment.Core.Entities
{
    public class GifRange
    {
        public UserType UserType { get; set; }

        public decimal Min { get; set; }

        public decimal Max { get; set; }

        public decimal Percentage { get; set; }
    }
}
