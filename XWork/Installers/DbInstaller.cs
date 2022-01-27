using Infrastucture.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace XWork.Installers
{
    public class DbInstaller : IInstaller 
    {
        public void InstallServ(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<Context>(x => x.UseSqlServer(configuration.GetConnectionString("XWork")));
        }
    }
}
