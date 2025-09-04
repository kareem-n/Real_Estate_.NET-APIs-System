using MediatR;
using Pro.Application.Common.Results;
using Pro.Application.DTOs.Auth;

namespace Pro.Application.UseCases.Auth.Commands.UserRegister
{
    public record CreateUserCommand(RegisterNewUserDto RegisterNewUserDto) : IRequest<ServiceResult<string>>
    {
    }
}
