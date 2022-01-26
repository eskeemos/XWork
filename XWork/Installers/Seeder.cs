using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using XWork.Seeders;

namespace XWork.Installers
{
    public class Seeder : IInstaller
    {
        public void InstallServ(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<RoleSeeder>();
        }
    }
}
