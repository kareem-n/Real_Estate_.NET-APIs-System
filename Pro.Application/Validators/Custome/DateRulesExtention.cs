using System.Globalization;
using FluentValidation;

namespace Pro.Application.Validators.Custome
{
    public static class DateRulesExtention
    {

        public static IRuleBuilderOptions<T, string> MustBeDate<T>(this IRuleBuilder<T, string> builder)
        {
            return builder.Must(date => DateTime.TryParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
                  .WithMessage("Invalid date format. Please use 'dd-mm-yyyy' format.");
        }

        public static IRuleBuilderOptions<T, string> MustBeAtLeastAge<T>(this IRuleBuilder<T, string> builder, short age)
        {
            return builder
                .MustBeDate()
                .Must(date =>
                {
                    if (DateTime.TryParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedDate))
                    {
                        return parsedDate <= DateTime.Now.AddYears(-age);
                    }
                    return false;

                });


        }

    }
}
