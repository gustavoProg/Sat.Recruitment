using Sat.Recruitment.Recruitment.Core.DTOs;
using System.Threading.Tasks;

namespace Sat.Recruitment.Service.Interfaces
{
    public interface IUserService
    {
        Task<UserCreateResponseDTO> CreateUserAsync(UserCreateRequestDTO user);
    }
}
