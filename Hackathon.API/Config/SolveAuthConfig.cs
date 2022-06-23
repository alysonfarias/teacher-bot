using Hackathon.Application.Options;
using Hackathon.Application.Roles;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Hackathon.API.Config
{
    public static class AuthConfiguration
    {
        public static IServiceCollection SolveAuthConfig(this IServiceCollection services,
        ConfigurationManager configuration)
        {
            var settings = configuration.GetSection("Jwt").Get<TokenGeneratorOptions>();

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(settings.SecurityKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                };
            });

            services.AddAuthorization(opt =>
            {
                opt.AddPolicy(Roles.Admin, policy => policy.RequireRole(Roles.Admin));
                opt.AddPolicy(Roles.Instructor, policy => policy.RequireRole(Roles.Instructor));
                opt.AddPolicy(Roles.Student, policy => policy.RequireRole(Roles.Student));
            });

            return services;
        }
    }
}
