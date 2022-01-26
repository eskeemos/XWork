using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace XWork.Installers
{
    public class PasswordHasher : IInstaller
    {
        public void InstallServ(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPasswordHasher<Account>, PasswordHasher<Account>>();  
        }
    }
}
