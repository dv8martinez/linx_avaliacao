using LINX.Avaliacao.Domain.Interfaces.Services;

using LINX.Avaliacao.Service.Balancos;
using LINX.Avaliacao.Service.TipoBalancos;
using Microsoft.Extensions.DependencyInjection;

namespace LINX.Avaliacao.CrossCutting.DependenyInjection
{
  public class ConfigureService
  {
    public static void ConfigureDependencyServices(IServiceCollection serviceCollection)
    {
      serviceCollection.AddTransient<ITipoBalancoService, TipoBalancoService>();
      serviceCollection.AddTransient<IBalancoService, BalancoService>();
    }
  }
}
