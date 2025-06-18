using Microsoft.Extensions.DependencyInjection;
using Arcade.Domain.Interfaces.Repository;
using Arcade.Service.Services;

namespace CrossCutting.DependencyInjection
{
    public static class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection services)
        {
            services.AddSingleton<IPontuacaoRepository, InMemoryPontuacaoRepository>();
        }
    }
}
