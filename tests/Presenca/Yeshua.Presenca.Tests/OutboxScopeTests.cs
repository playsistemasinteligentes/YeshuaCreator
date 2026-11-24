using System.Diagnostics;
using System.Security.Claims;
using Aplication.Interfaces.Services;
using Command.Patterns.OutBox;
using Dominio.Interfaces;
using Dominio.Operational;
using Shared.Operational;
namespace Presenca.Tests;
public sealed class OutboxScopeTests
{
 [Fact] public void Disabled_policy_creates_no_identity_scope_or_record_activity()
 {
  var context=new Context();var sink=new Sink();var logger=new Shered.Logger.Logger(new Policy(false),sink);
  using var poll=new Activity("poll").Start();
  using(var ignored=OutboxRecordScope.Begin(logger,context,"42",1,10,default))
  {Assert.Same(poll,Activity.Current);Assert.Equal(0,context.Begins);Assert.False(context.TryGetOperationalIdentity(out _));}
  Assert.Empty(sink.Payloads);
 }
 [Fact] public void Enabled_record_is_an_independent_current_root_and_restores_polling_context()
 {
  var context=new Context();var logger=new Shered.Logger.Logger(new Policy(true),new Sink());
  using var listener=new ActivityListener{ShouldListenTo=s=>s.Name==OperationalActivity.SourceName,Sample=(ref ActivityCreationOptions<ActivityContext> _)=>ActivitySamplingResult.AllData};
  ActivitySource.AddActivityListener(listener);using var poll=new Activity("poll").Start();
  var previous=new OperationalExecutionIdentity("root-business","operation-business","execution-previous",null);
  string? first=null;
  for(var attempt=0;attempt<2;attempt++)
  {
   using(OutboxRecordScope.Begin(logger,context,"42",1,10,previous))
   {
    var current=Activity.Current;Assert.NotNull(current);Assert.Equal("Outbox.Record",current.OperationName);
    Assert.Null(current.ParentId);Assert.NotEqual(poll.TraceId,current.TraceId);
    Assert.Equal("root-business",current.GetTagItem("yeshua.root_operation_id"));
    Assert.True(context.TryGetOperationalIdentity(out var identity));Assert.Equal(previous.OperationId,identity.OperationId);Assert.Equal(previous.ExecutionId,identity.CausationId);
    if(first is not null)Assert.NotEqual(first,current.TraceId.ToString());first=current.TraceId.ToString();previous=identity;
   }
   Assert.Same(poll,Activity.Current);Assert.False(context.TryGetOperationalIdentity(out _));
  }
 }
 private sealed class Policy(bool enabled):IOperationalTelemetryPolicy
 {public OperationalTelemetryDecision Evaluate(string c,string? o=null,string? e=null,string? r=null)=>new(enabled,enabled?"Information":"None",enabled?"D1":"D0");}
 private sealed class Sink:IOperationalLogSink
 {public List<string> Payloads {get;}=[];public void Write(string l,string c,ReadOnlySpan<byte> p)=>Payloads.Add(System.Text.Encoding.UTF8.GetString(p));}
 private sealed class Context:IExecutionContext
 {
  private readonly OperationalExecutionIdentityState _identity=new();public int Begins {get;private set;}
  public int UserId=>10;public int TenantID=>1;public IEnumerable<Claim> Claims=>[];public string TraceId=>throw new InvalidOperationException("No eager trace fallback");public ExecutionOrigin Origem=>ExecutionOrigin.Worker;public string ProcessingScope=>"scope-tests";
  public void SetUserId(int id){}public void SetTenantId(int id){}public void SetTraceId(string id){}public void SetOrigem(ExecutionOrigin origin){}
  public bool TryGetOperationalIdentity(out OperationalExecutionIdentity identity)=>_identity.TryGetCurrent(out identity);
  public IDisposable BeginOperationalExecution(OperationalExecutionIdentity parent,string operation,bool continueOperation=true){Begins++;return _identity.BeginFrom(parent,operation,continueOperation);}
 }
}
