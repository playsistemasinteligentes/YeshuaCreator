using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Presenca.Tests;

public sealed class BrowserJourneyFactAttribute : FactAttribute
{
 public BrowserJourneyFactAttribute()
 {
  if(string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("PRESENCA_PLAYWRIGHT_MODULE")))
   Skip="Chromium journey requires the explicitly prepared PRESENCA_PLAYWRIGHT_MODULE; no browser installation is performed by tests.";
 }
}

// Loopback-only bridge to WebApplicationFactory: the browser uses real Front and actual API endpoints.
// It owns no SQL, channel credentials, production JWT or worker endpoint.
internal static class BrowserApiJourney
{
 public static async Task Run(HttpClient api,string publisher,string marker,int queues,bool createDraft)
 {
  var root=new DirectoryInfo(AppContext.BaseDirectory);
  while(root!=null&&!Directory.Exists(Path.Combine(root.FullName,"scripts/presenca")))root=root.Parent;
  Assert.NotNull(root);
  var front=Path.Combine(root.FullName,"src/CQRS/Infrastructure/Yeshua.Central.CQRS.Infrastructure.Front/wwwroot");
  var builder=WebApplication.CreateBuilder();builder.WebHost.UseUrls("http://127.0.0.1:0");builder.Logging.ClearProviders();
  await using var relay=builder.Build();
  relay.Run(async context=>
  {
   var path=context.Request.Path.Value??"";
   if(path=="/")
   {
    context.Response.ContentType="text/html";
    await context.Response.WriteAsync("<div id='app'></div><script>window.environments={urlApi:'/yapi'}</script><script type='module'>import {renderRedacao} from '/Custon/Apps/Presenca/pages/redacao.js';await renderRedacao();</script>");return;
   }
   if(path=="/spa/scripts/ServicesGlobal/apiFetch.js")
   {
    context.Response.ContentType="text/javascript";
    await context.Response.WriteAsync("export const apiFetch=(...args)=>fetch(...args);export const getApiErrorMessage=(p,s)=>p.message||`HTTP ${s}`;");return;
   }
   if(path is "/Custon/Apps/Presenca/pages/redacao.html" or "/Custon/Apps/Presenca/pages/redacao.js")
   {
    context.Response.ContentType=path.EndsWith(".js",StringComparison.Ordinal)?"text/javascript":"text/html";
    await context.Response.Body.WriteAsync(await File.ReadAllBytesAsync(Path.Combine(front,path.TrimStart('/'))));return;
   }
   if(context.Request.Method=="POST"&&path.StartsWith("/yapi/Presenca/Editorial",StringComparison.Ordinal))
   {
    using var reader=new StreamReader(context.Request.Body);
    using var response=await api.PostAsync(path,new StringContent(await reader.ReadToEndAsync(),Encoding.UTF8,"application/json"));
    context.Response.StatusCode=(int)response.StatusCode;context.Response.ContentType="application/json";
    await response.Content.CopyToAsync(context.Response.Body);return;
   }
   context.Response.StatusCode=404;
  });
  await relay.StartAsync();
  try
  {
   var origin=relay.Services.GetRequiredService<IServer>().Features.Get<IServerAddressesFeature>()!.Addresses.Single();
   var start=new ProcessStartInfo("node"){UseShellExecute=false,RedirectStandardOutput=true,RedirectStandardError=true,WorkingDirectory=root.FullName};
   start.ArgumentList.Add("tests/Presenca/Browser/api-journey.mjs");
   foreach(var key in start.Environment.Keys.Where(k=>new[]{"SQL","PASSWORD","TOKEN","SECRET","CREDENTIAL","PRIVATE","YESHUA"}.Any(part=>k.Contains(part,StringComparison.OrdinalIgnoreCase))).ToArray())start.Environment.Remove(key);
   start.Environment["PRESENCA_HOMOLOGATION_ORIGIN"]=origin;
   start.Environment["PRESENCA_HOMOLOGATION_PUBLISHER"]=publisher;
   start.Environment["PRESENCA_HOMOLOGATION_MARKER"]=marker;
   start.Environment["PRESENCA_HOMOLOGATION_QUEUES"]=queues.ToString(System.Globalization.CultureInfo.InvariantCulture);
   start.Environment["PRESENCA_HOMOLOGATION_CREATE"]=createDraft?"yes":"no";
   using var process=Process.Start(start)!;
   var stdout=process.StandardOutput.ReadToEndAsync();var stderr=process.StandardError.ReadToEndAsync();
   using var timeout=new CancellationTokenSource(TimeSpan.FromSeconds(90));
   try{await process.WaitForExitAsync(timeout.Token);}
   catch{process.Kill(true);throw;}
   Assert.True(process.ExitCode==0,(await stdout)+"\n"+(await stderr));
  }
  finally{await relay.StopAsync();}
 }
}
