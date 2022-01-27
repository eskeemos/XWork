using Application;
using FluentValidation.AspNetCore;
using Infrastucture;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace XWork.Installers
{
    public class MvcInstaller : IInstaller  
    {
        public void InstallServ(IServiceCollection services, IConfiguration configuration)
        {
            services.AddInfrastructure();
            services.AddApplication();
            services.AddControllers().AddFluentValidation();
            services.AddControllers();
        }
    }
}
