using Domain.Interfaces;
using Infrastucture.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastucture
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IRPersonalData, PersonalDataRepo>();
            return services;
        }
    }
}
