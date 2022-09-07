using LINX.Avaliacao.Domain.Interfaces.Services;
using LINX.Avaliacao.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LINX.Avaliacao.Workers
{
  public class Worker : BackgroundService
  {
    private readonly ILogger<Worker> _logger;    
    private readonly IServiceScopeFactory _scope;
    private Timer _timer;
    private int _reloadTime = 0;
    private int executionCount = 0;

    public Worker(ILogger<Worker> logger, IServiceScopeFactory scope)
    {
      _logger = logger;
      
      _reloadTime = 1;
      _scope = scope;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {

      _logger.LogInformation("[### SERVICE STARTED ###]");
      return base.StartAsync(stoppingToken);


    }

    public override async Task StartAsync(CancellationToken cancellationToken)
    {
      try
      {
        _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromDays(_reloadTime));
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "[### ERROR IN SENDIND DATA ###]");
        await StopAsync(cancellationToken);
        await StartAsync(cancellationToken);
        return;
      }
    }

    public override Task StopAsync(CancellationToken cancellationToken)
    {
      _logger.LogInformation("[### SERVICE STOPED ###]");
      _timer?.Change(Timeout.Infinite, 0);

      //return base.StopAsync(cancellationToken);
      return Task.CompletedTask;
    }

    public override void Dispose()
    {
      base.Dispose();
    }

    private void DoWork(object state)
    {
      try
      {
        var count = Interlocked.Increment(ref executionCount);
        _logger.LogInformation("[Timed Hosted Service is working. Count: {Count}]", count);
        Task.Run(() =>
        {
          using (var scope = _scope.CreateScope())
          {
            var service = scope.ServiceProvider.GetService<IBalancoService>();

            var results =  service.GetAll(DateTime.Now).Result;

            if(results.Items.Any()){
              var receitas = results.Items.Where(r => r.Tipo.Descricao.Contains("Despesas")).Sum(s => s.Valor);
              var despesas = results.Items.Where(d => d.Tipo.Descricao.Contains("Despesas")).Sum(s => s.Valor); ;

              var balancoDia = (receitas - despesas);

              if (balancoDia < 0) 
              {
                var result = EmailService.EnviarEmail(balancoDia).Result;
              }
            }
          }

        });
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
  }
}
