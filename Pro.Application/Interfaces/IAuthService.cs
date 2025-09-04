using Pro.Application.Common.Results;
using Pro.Application.DTOs.Auth;

namespace Pro.Application.Interfaces
{
    public interface IAuthService
    {
        Task<ServiceResult<string>> Login(LoginRequest loginRequest);
    }
}
