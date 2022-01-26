using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace XWork.Installers
{
    public class AuthInstaller : IInstaller
    {
        public void InstallServ(IServiceCollection services, IConfiguration configuration)
        {
            var auth = new Auth();
            configuration.GetSection("Authentication").Bind(auth);

            services.AddSingleton(auth);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = "XWork";
                x.DefaultScheme = "XWork";
                x.DefaultChallengeScheme = "XWork";
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = auth.Issuer,
                    ValidAudience = auth.Issuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(auth.JwtKey))
                };
            });
        }
    }
}
