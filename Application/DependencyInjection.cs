using Application.Dtos.AccountDtos;
using Application.Dtos.Validators;
using Application.Interfaces;
using Application.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IValidator<AccountRegister>, UserRegisterValidator>();
            services.AddScoped<ISPersonalData, PersonalDataServ>();
            services.AddScoped<ISLocation, LocationServ>();
            services.AddScoped<ISAccount, AccountServ>();
            services.AddScoped<ISZusStatement, ZusStatementServ>(); 
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
