using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;
using Pro.API.Extentions;
using Pro.API.Middlewares;
using Pro.Application.Extentions;
using Pro.Infrastructure.Extenstions;
using Scalar.AspNetCore;


namespace Pro.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddFluentValidationClientsideAdapters();


            builder.Services.AddOpenApi(options =>
            {
                options.AddDocumentTransformer((document, context, cancellationToken) =>
                {
                    document.Components ??= new();
                    document.Components.SecuritySchemes["Bearer"] = new OpenApiSecurityScheme
                    {
                        Type = SecuritySchemeType.Http,
                        Scheme = "bearer",
                        BearerFormat = "JWT",
                        In = ParameterLocation.Header,
                        Description = "Enter JWT token like: Bearer {token}"
                    };

                    document.SecurityRequirements.Add(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            Array.Empty<string>()
                        }
                    });

                    return Task.CompletedTask;
                });
            });


            builder.Services.AddScoped<ExceptionMiddleware>();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddApiInjection(builder.Configuration);
            builder.Services.AddApplicationServices();
            builder.Services.AddInfrastructure();


            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference("scalar");

            }


            app.UseMiddleware<ExceptionMiddleware>();

            app.UseStaticFiles();

            app.UseHttpsRedirection();
            app.UseRouting();


            app.UseAuthorization();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
