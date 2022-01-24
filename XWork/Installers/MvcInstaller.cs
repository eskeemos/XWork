using Application;
using Application.Interfaces;
using Application.Mapper;
using Application.Services;
using Domain.Interfaces;
using Infrastucture;
using Infrastucture.Repositories;
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
            services.AddControllers();
        }
    }
}
