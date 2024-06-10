using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API_QLSV.Installers
{
    public interface IInstaller
    {
        void InstallServices(IServiceCollection services, IConfiguration configuration);
    }
}
