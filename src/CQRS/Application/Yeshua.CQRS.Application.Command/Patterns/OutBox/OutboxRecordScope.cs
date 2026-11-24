using Aplication.Interfaces.Services;
using Dominio.Interfaces;
using Dominio.Operational;
using System.Diagnostics;
namespace Command.Patterns.OutBox;
// Shared Outbox execution edge: polling is not the parent trace of a delivered record.
public static class OutboxRecordScope
{
 public static IDisposable Begin(ILogger logger,IExecutionContext context,string recordId,int tenant,int actor,OperationalExecutionIdentity parent)
 {
  var policy=logger.Evaluate("Outbox","Deliver","yOutbox",recordId,parent.OperationId,tenant,actor);
  if(!policy.Enabled)return Empty.Instance;
  var scope=context.BeginOperationalExecution(parent,"Outbox.Record");
  var previousActivity=Activity.Current;
  var activity=OperationalActivity.StartRoot("Outbox.Record");
  if(activity is not null)Activity.Current=activity;
  activity?.SetTag("yeshua.component","Outbox");activity?.SetTag("yeshua.tenant_id",tenant);activity?.SetTag("enduser.id",actor);
  if(context.TryGetOperationalIdentity(out var identity))OperationalActivity.SetIdentity(activity,identity);
  return new Active(scope,activity,previousActivity);
 }
 private sealed class Empty:IDisposable {public static readonly Empty Instance=new();public void Dispose(){} }
 private sealed class Active(IDisposable scope,Activity? activity,Activity? previous):IDisposable
 {
  public void Dispose()
  {
   try {activity?.Dispose();}
   finally {Activity.Current=previous;scope.Dispose();}
  }
 }
}
