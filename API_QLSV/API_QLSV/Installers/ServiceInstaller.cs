using API_QLSV.Adapters;
using lib;
using lib.Repositories;
using lib.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_QLSV.Installers
{
    public class ServiceInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IStudentAdapter, StudentAdapter>();
            services.AddScoped<IStudentsRepository, StudentsRepository>();
            services.AddScoped<IStudentAdapter, StudentAdapter>();
            services.AddScoped<IStudentsService, StudentsServices>();

            services.AddSingleton<ApplicationDbContext>();
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Singleton);
            services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedEmail = false)
               .AddEntityFrameworkStores<ApplicationDbContext>()
               .AddDefaultTokenProviders();
        }
    }
}
