using MediatR;
using Microsoft.AspNetCore.Identity;
using Pro.Application.Common.Errors;
using Pro.Application.Common.Results;
using Pro.Domain.Models;

namespace Pro.Application.UseCases.Auth.Commands.UserRegister
{
    public class CreateNewUserCommandHandler
        : IRequestHandler<CreateUserCommand, ServiceResult<string>>
    {
        private readonly UserManager<AppUser> userManager;

        public CreateNewUserCommandHandler(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }



        public async Task<ServiceResult<string>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByEmailAsync(request.RegisterNewUserDto.Email)
                ??
                await userManager.FindByNameAsync(request.RegisterNewUserDto.Username);

            if (user != null)
            {
                return ServiceResult<string>.Failure(
                    Error.Conflict("Email or Username Already Exist"),
                    message: "Email or Username Already Exist"
                    );
            }

            var newUser = new AppUser
            {
                UserName = request.RegisterNewUserDto.Username,
                Email = request.RegisterNewUserDto.Email,
                FirstName = request.RegisterNewUserDto.FirstName,
                LastName = request.RegisterNewUserDto.LastName
            };

            var result = await userManager.CreateAsync(newUser, request.RegisterNewUserDto.Password);

            if (result.Succeeded)
            {
                var addToRoleState = await userManager.AddToRoleAsync(newUser, "employee");

                if (addToRoleState.Succeeded)
                {
                    return ServiceResult<string>.Success(
                        null!,
                        "User Created Successfully"
                     );

                }


            }

            var errros = result.Errors.ToDictionary(key => key.Code, err => result.Errors.Select(r => r.Description));

            return ServiceResult<string>.Failure(
                Error.Validation("One or more Error Occured", errros),
                message: "User Creation Failed"
            );


        }
    }
}
