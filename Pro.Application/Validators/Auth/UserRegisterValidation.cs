using FluentValidation;
using Pro.Application.DTOs.Auth;
using Pro.Application.Validators.Custome;

namespace Pro.Application.Validators.Auth
{
    public class UserRegisterValidation : AbstractValidator<RegisterNewUserDto>
    {

        public UserRegisterValidation()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First Name is required")
                .MaximumLength(50)
                .WithMessage("First Name must not exceed 50 characters");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Last Name is required")
                .MaximumLength(50)
                .WithMessage("Last Name must not exceed 50 characters");

            RuleFor(x => x.DateOfBirth)
                .NotNull()
                .NotEmpty()
                .WithMessage("Date of Birth is required")
                .MustBeDate()
                .MustBeAtLeastAge(18)
                .WithMessage("Age Must be At Least 18")
            //.Must(date => DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture) <= DateTime.Now.AddYears(-18))
            //.WithMessage("You must be at least 18 years old to register")
            ;
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required")
                .EmailAddress()
                .WithMessage("Invalid email format");

            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("Username is required")
                .MaximumLength(50)
                .WithMessage("Username must not exceed 50 characters");


            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required")
                .MinimumLength(6)
                .WithMessage("Password must be at least 6 characters long")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$")
                .WithMessage("Password must contain at least one uppercase letter, one lowercase letter, one number, and one special character");

            RuleFor(x => x.ConfirmPasswrd)
                .Equal(x => x.Password)
                .WithMessage("Passwords do not match");


            RuleFor(x => x.Address)
                .MaximumLength(200)
                .WithMessage("Address must not exceed 200 characters");

        }

    }
}
