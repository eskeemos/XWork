using Infrastucture.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
