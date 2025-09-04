using FluentValidation;
using Pro.Application.DTOs.PropertyDtos;

namespace Pro.Application.Validators.PropertyDtoValidations
{
    public class CreateNewPeropertyDtoValidation : AbstractValidator<CreateNewPeropertyDto>
    {

        public CreateNewPeropertyDtoValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");
            //
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");
            //
            RuleFor(x => x.PropertyImg)
                .Must(x => x == null || (x.Length > 0 && (x.ContentType == "image/jpeg" || x.ContentType == "image/png")))
                .WithMessage("Property image must be a valid JPEG or PNG file.")
                .When(x => x.PropertyImg != null);

        }


    }
}
