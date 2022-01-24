using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace XWork.Installers
{
    public interface IInstaller
    {
        public void InstallServ(IServiceCollection services, IConfiguration configuration);
    }
}
