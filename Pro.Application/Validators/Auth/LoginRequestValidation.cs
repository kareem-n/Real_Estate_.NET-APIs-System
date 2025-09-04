using FluentValidation;
using Pro.Application.DTOs.Auth;

namespace Pro.Application.Validators.Auth
{
    public class LoginRequestValidation : AbstractValidator<LoginRequest>
    {


        public LoginRequestValidation()
        {
            RuleFor(x => x.email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");
            RuleFor(x => x.password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");

        }


    }

}
