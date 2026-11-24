using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Command.Patterns.OutBox;
using Shared.Operational;
using Shared.ModuleTransport;
namespace Presenca.Distribution;
public static class PresencaRegistration
{
 public static void AddPresenca(this IServiceCollection services,IConfiguration configuration)
 {
  var options=new PresencaOptions();configuration.GetSection("Presenca").Bind(options);
  // Values are materialized from Apps.Presenca in the existing unified private credentials loader.
  if(options.Enabled&&string.IsNullOrWhiteSpace(configuration["YeshuaProcessing:Scope"]))throw new InvalidOperationException("YeshuaProcessing:Scope obrigatório.");
  var roots=options.Canais.Values.Where(p=>options.Enabled).Where(p=>p.Plataforma=="Portal").Select(p=>Path.GetFullPath(p.ReleaseRoot)).ToArray();
  if(roots.Distinct(StringComparer.Ordinal).Count()!=roots.Length)throw new InvalidOperationException("Cada perfil de portal exige um diretório de releases exclusivo.");
  services.AddSingleton(options);
  services.AddHttpClient("Presenca.Distribution",c=>c.Timeout=TimeSpan.FromSeconds(45)).RemoveAllLoggers()
   .ConfigurePrimaryHttpMessageHandler(()=>new HttpClientHandler{AllowAutoRedirect=false})
   .AddHttpMessageHandler<OperationalHttpTelemetryHandler>();
  services.AddHttpClient("Presenca.Modules",c=>c.Timeout=TimeSpan.FromSeconds(30)).RemoveAllLoggers()
   .ConfigurePrimaryHttpMessageHandler(()=>new HttpClientHandler{AllowAutoRedirect=false})
   .AddHttpMessageHandler<YeshuaModuleAuthenticationHandler>().AddHttpMessageHandler<OperationalHttpTelemetryHandler>();
  services.AddScoped<IOutboxDeliveryFactory,PresencaDeliveryFactory>();
 }
}
