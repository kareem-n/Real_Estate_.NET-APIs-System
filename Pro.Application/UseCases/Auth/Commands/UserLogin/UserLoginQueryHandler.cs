using MediatR;
using Microsoft.AspNetCore.Identity;
using Pro.Application.Common.Errors;
using Pro.Application.Common.Results;
using Pro.Application.DTOs.Auth;
using Pro.Domain.Interfaces.Services;
using Pro.Domain.Models;

namespace Pro.Application.UseCases.Auth.Commands.UserLogin
{
    public class UserLoginQueryHandler : IRequestHandler<UserLoginQuery, ServiceResult<LoginResponse>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokensGeneratorService tokensGeneratorService;

        public UserLoginQueryHandler
        (
                UserManager<AppUser> userManager,
                ITokensGeneratorService tokensGeneratorService
        )
        {
            _userManager = userManager;
            this.tokensGeneratorService = tokensGeneratorService;
        }
        public async Task<ServiceResult<LoginResponse>> Handle(UserLoginQuery request, CancellationToken cancellationToken)
        {

            var user = await _userManager.FindByEmailAsync(request.LoginRequest.email);

            if (
                user == null
                ||
                !await _userManager.CheckPasswordAsync(user, request.LoginRequest.password)
            )
            {
                return ServiceResult<LoginResponse>
                    .Failure(Error.Validation($"Email or Password might be wrong", null!), "Invalid Credentials");
            }

            var accessToken = await tokensGeneratorService.GenerateJWTToken(user);

            var response = new LoginResponse(
                accessToken: accessToken,
                userId: user.Id,
                email: user.Email!,
                username: user.UserName!
            );

            return ServiceResult<LoginResponse>.Success(response, "Login successful");


        }

    }
}
