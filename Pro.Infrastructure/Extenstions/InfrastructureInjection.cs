using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pro.Domain.Interfaces.Repos;
using Pro.Domain.Interfaces.Services;
using Pro.Domain.Interfaces.UOW;
using Pro.Domain.Models;
using Pro.Infrastructure.Data;
using Pro.Infrastructure.Repos;
using Pro.Infrastructure.Services;
using Pro.Infrastructure.Services.FileHandlerService;
using Pro.Infrastructure.UOWs;

namespace Pro.Infrastructure.Extenstions
{
    public static class InfrastructureInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {


            services.AddSingleton<IFileHandlerService, FileHandlerService>();


            services.AddScoped<IUOW, UOW>();
            services.AddScoped(typeof(IBaseRepo<>), typeof(BaseRepo<>));



            services.AddDbContext<AppDbContext>(op =>
            {
                op.UseSqlServer("Data Source=.\\SQLEXPRESS;Database=testDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;");
            });


            services.AddIdentityCore<AppUser>(options =>
            {
                options.User.RequireUniqueEmail = true;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddUserManager<UserManager<AppUser>>()
                .AddRoleManager<RoleManager<IdentityRole>>()
                ;



            services.AddScoped<ITokensGeneratorService, TokensGenerationService>();

            return services;

        }
    }
}
