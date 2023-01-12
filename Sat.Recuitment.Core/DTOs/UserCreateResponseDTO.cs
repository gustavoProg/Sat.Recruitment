

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Sat.Recruitment.Recruitment.Core.DTOs
{
    public class UserCreateResponseDTO
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string UserType { get; set; }

        public decimal Money { get; set; }
    }
}
