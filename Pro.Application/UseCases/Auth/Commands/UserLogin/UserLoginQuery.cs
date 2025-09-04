using MediatR;
using Pro.Application.Common.Results;
using Pro.Application.DTOs.Auth;

namespace Pro.Application.UseCases.Auth.Commands.UserLogin
{
    public record UserLoginQuery(LoginRequest LoginRequest) : IRequest<ServiceResult<LoginResponse>>
    {
    }
}
