using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using PSCPMSWebApi.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_QLSV.Installers
{
    public class SystemInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options => { options.AddPolicy("AllowAllHeaders", builder => { builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); }); });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "StudentManagement",
                    Version = "v1",
                    Description = "Web Api"
                });
                c.AddSecurityDefinition("clientId", new OpenApiSecurityScheme()
                {
                    Type = SecuritySchemeType.ApiKey,
                    In = ParameterLocation.Header,
                    Name = "clientId",
                    Description = "Assigned clientId"
                });
                c.AddSecurityDefinition("apiKey", new OpenApiSecurityScheme()
                {
                    Type = SecuritySchemeType.ApiKey,
                    In = ParameterLocation.Header,
                    Name = "apiKey",
                    Description = "Assigned apiKey"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                   {
                       new OpenApiSecurityScheme
                       {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "clientId"
                            }
                       },
                       new string[] {}

                    }
                }
                );
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                   {
                       new OpenApiSecurityScheme
                       {
                            //Name = "apiKey",
                            //Type = SecuritySchemeType.ApiKey,
                            //In = ParameterLocation.Header,
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "apiKey"
                            }
                       },
                       new string[] {}

                    }
                }
                );
                c.SchemaFilter<SchemaFilter>();
            });
            services.AddControllersWithViews();
        }
    }
}
