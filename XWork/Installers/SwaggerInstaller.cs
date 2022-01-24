using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace XWork.Installers
{
    public class SwaggerInstaller : IInstaller
    {
        public void InstallServ(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "XWork", Version = "v1" });
            });
        }
    }
}
