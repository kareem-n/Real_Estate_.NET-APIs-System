using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Pro.Application.UseCases;
using Pro.Application.Validators.Auth;

namespace Pro.Application.Extentions
{
    public static class ApplicationInjection
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddValidatorsFromAssemblyContaining<LoginRequestValidation>();

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblyContaining<MediatRAssemblyMarker>();
            });


            //services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
