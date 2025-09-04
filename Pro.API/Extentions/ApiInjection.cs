using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Pro.API.Responses;
using Pro.Application.Common.Errors;

namespace Pro.API.Extentions
{
    public static class ApiInjection
    {


        public static IServiceCollection AddApiInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();

            services.Configure<ApiBehaviorOptions>(op =>
            {
                op.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState
                    .Where(e => e.Value?.Errors.Count > 0)
                                        .ToDictionary(
                                           key => key.Key,
                                           err => err.Value?.Errors.Select(e => e.ErrorMessage)
                                         );

                    var response = ApiResponse<object>.Failure(
                        Error.Validation("validation error on one or more fields", errors!),
                        "Validation failed"
                    );

                    return new BadRequestObjectResult(response);
                };
            });


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(op =>
                {
                    op.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = configuration["JWT:Issuer"],
                        ValidAudience = configuration["JWT:Audience"],
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["jwt:Key"]!)),
                        ClockSkew = TimeSpan.Zero,
                    };
                });







            services.AddEndpointsApiExplorer();
            return services;
        }

    }
}
