using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace API_QLSV.Configurator
{
    public interface IAppConfigurator
    {
        void Configure(IApplicationBuilder app, IWebHostEnvironment env);
    }
}
