// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureAPIEndpointsMigration
// </yeshua>

using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Modules;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Shared.Operational;
namespace API.Migrations
{
public static class Endpoints
{
public static void MapEndpoints(this WebApplication app)
{
app.MapGet("/yapi/operational/identity", ([FromServices] IRuntimeIdentityProvider identityProvider) =>
    Results.Ok(identityProvider.Current))
    .AllowAnonymous();

app.MapGet("/yapi/operational/telemetry", ([FromServices] Dominio.Interfaces.ILogger logger) =>
    Results.Ok(logger.Snapshot()))
    .AllowAnonymous();

app.MapGet("/yapi/operational/logging-policy", ([FromServices] Yeshua.Generated.OperationalControl.IOperationalLoggingPolicyAccessor policyAccessor) =>
    Results.Ok(policyAccessor.Current))
    .AllowAnonymous();

app.MapGet("/yapi/health/live", ([FromServices] IRuntimeIdentityProvider identityProvider) =>
    Results.Ok(new
    {
        Status = "Healthy",
        Check = "Liveness",
        Identity = identityProvider.Current,
        ObservedAtUtc = DateTimeOffset.UtcNow
    }))
    .AllowAnonymous();

app.MapGet("/yapi/health/ready", ([FromServices] IRuntimeIdentityProvider identityProvider) =>
    Results.Ok(new
    {
        Status = "Ready",
        Check = "Readiness",
        Dependencies = "NotEvaluated",
        Identity = identityProvider.Current,
        ObservedAtUtc = DateTimeOffset.UtcNow
    }))
    .AllowAnonymous();

app.MapPost("/yapi/Produto/PostProduto", async ([FromServices] Command.Receivers.Write.InsertProdutoReceiver receiver, [FromBody] Command.Write.ProdutoCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.ProdutoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ProdutoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/Maquina/PostMaquina", async ([FromServices] Command.Receivers.Write.InsertMaquinaReceiver receiver, [FromBody] Command.Write.MaquinaCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.MaquinaEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.MaquinaEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/GrupoMaquina/PostGrupoMaquina", async ([FromServices] Command.Receivers.Write.InsertGrupoMaquinaReceiver receiver, [FromBody] Command.Write.GrupoMaquinaCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.GrupoMaquinaEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.GrupoMaquinaEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/TemplateDeTestes/PostTemplateDeTestes", async ([FromServices] Command.Receivers.Write.InsertTemplateDeTestesReceiver receiver, [FromBody] Command.Write.TemplateDeTestesCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.TemplateDeTestesEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.TemplateDeTestesEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/Roteiro/PostRoteiro", async ([FromServices] Command.Receivers.Write.InsertRoteiroReceiver receiver, [FromBody] Command.Write.RoteiroCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.RoteiroEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.RoteiroEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yFileUpload/PostyFileUpload", async ([FromServices] Command.Receivers.Write.InsertyFileUploadReceiver receiver, [FromBody] Command.Write.yFileUploadCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yFileUploadEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yFileUploadEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/ySaga/PostySaga", async ([FromServices] Command.Receivers.Write.InsertySagaReceiver receiver, [FromBody] Command.Write.ySagaCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.ySagaEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ySagaEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/ySagaStep/PostySagaStep", async ([FromServices] Command.Receivers.Write.InsertySagaStepReceiver receiver, [FromBody] Command.Write.ySagaStepCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.ySagaStepEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ySagaStepEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yOutbox/PostyOutbox", async ([FromServices] Command.Receivers.Write.InsertyOutboxReceiver receiver, [FromBody] Command.Write.yOutboxCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yOutboxEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yOutboxEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yInbox/PostyInbox", async ([FromServices] Command.Receivers.Write.InsertyInboxReceiver receiver, [FromBody] Command.Write.yInboxCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yInboxEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yInboxEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yTenant/PostyTenant", async ([FromServices] Command.Receivers.Write.InsertyTenantReceiver receiver, [FromBody] Command.Write.yTenantCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yTenantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yTenantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yUser/PostyUser", async ([FromServices] Command.Receivers.Write.InsertyUserReceiver receiver, [FromBody] Command.Write.yUserCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yUserEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yUserEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yConfigArcteture/PostyConfigArcteture", async ([FromServices] Command.Receivers.Write.InsertyConfigArctetureReceiver receiver, [FromBody] Command.Write.yConfigArctetureCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yConfigArctetureEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yConfigArctetureEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yConfigNotification/PostyConfigNotification", async ([FromServices] Command.Receivers.Write.InsertyConfigNotificationReceiver receiver, [FromBody] Command.Write.yConfigNotificationCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yConfigNotificationEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yConfigNotificationEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yPerfil/PostyPerfil", async ([FromServices] Command.Receivers.Write.InsertyPerfilReceiver receiver, [FromBody] Command.Write.yPerfilCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yPerfilEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yPerfilEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yModule/PostyModule", async ([FromServices] Command.Receivers.Write.InsertyModuleReceiver receiver, [FromBody] Command.Write.yModuleCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yModuleEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yModuleEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yTenantModule/PostyTenantModule", async ([FromServices] Command.Receivers.Write.InsertyTenantModuleReceiver receiver, [FromBody] Command.Write.yTenantModuleCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yTenantModuleEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yTenantModuleEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yUserModule/PostyUserModule", async ([FromServices] Command.Receivers.Write.InsertyUserModuleReceiver receiver, [FromBody] Command.Write.yUserModuleCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yUserModuleEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yUserModuleEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yGrant/PostyGrant", async ([FromServices] Command.Receivers.Write.InsertyGrantReceiver receiver, [FromBody] Command.Write.yGrantCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yGrantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yGrantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yPerfilGrant/PostyPerfilGrant", async ([FromServices] Command.Receivers.Write.InsertyPerfilGrantReceiver receiver, [FromBody] Command.Write.yPerfilGrantCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yPerfilGrantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yPerfilGrantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yUserGrant/PostyUserGrant", async ([FromServices] Command.Receivers.Write.InsertyUserGrantReceiver receiver, [FromBody] Command.Write.yUserGrantCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yUserGrantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yUserGrantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/Produto/PutProduto", async ([FromServices] Command.Receivers.Write.UpdateProdutoReceiver receiver, [FromBody] Command.Write.ProdutoCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.ProdutoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ProdutoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/Maquina/PutMaquina", async ([FromServices] Command.Receivers.Write.UpdateMaquinaReceiver receiver, [FromBody] Command.Write.MaquinaCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.MaquinaEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.MaquinaEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/GrupoMaquina/PutGrupoMaquina", async ([FromServices] Command.Receivers.Write.UpdateGrupoMaquinaReceiver receiver, [FromBody] Command.Write.GrupoMaquinaCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.GrupoMaquinaEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.GrupoMaquinaEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/TemplateDeTestes/PutTemplateDeTestes", async ([FromServices] Command.Receivers.Write.UpdateTemplateDeTestesReceiver receiver, [FromBody] Command.Write.TemplateDeTestesCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.TemplateDeTestesEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.TemplateDeTestesEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/Roteiro/PutRoteiro", async ([FromServices] Command.Receivers.Write.UpdateRoteiroReceiver receiver, [FromBody] Command.Write.RoteiroCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.RoteiroEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.RoteiroEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/yFileUpload/PutyFileUpload", async ([FromServices] Command.Receivers.Write.UpdateyFileUploadReceiver receiver, [FromBody] Command.Write.yFileUploadCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yFileUploadEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yFileUploadEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/ySaga/PutySaga", async ([FromServices] Command.Receivers.Write.UpdateySagaReceiver receiver, [FromBody] Command.Write.ySagaCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.ySagaEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ySagaEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/ySagaStep/PutySagaStep", async ([FromServices] Command.Receivers.Write.UpdateySagaStepReceiver receiver, [FromBody] Command.Write.ySagaStepCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.ySagaStepEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ySagaStepEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/yOutbox/PutyOutbox", async ([FromServices] Command.Receivers.Write.UpdateyOutboxReceiver receiver, [FromBody] Command.Write.yOutboxCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yOutboxEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yOutboxEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/yInbox/PutyInbox", async ([FromServices] Command.Receivers.Write.UpdateyInboxReceiver receiver, [FromBody] Command.Write.yInboxCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yInboxEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yInboxEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/yTenant/PutyTenant", async ([FromServices] Command.Receivers.Write.UpdateyTenantReceiver receiver, [FromBody] Command.Write.yTenantCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yTenantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yTenantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/yUser/PutyUser", async ([FromServices] Command.Receivers.Write.UpdateyUserReceiver receiver, [FromBody] Command.Write.yUserCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yUserEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yUserEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/yConfigArcteture/PutyConfigArcteture", async ([FromServices] Command.Receivers.Write.UpdateyConfigArctetureReceiver receiver, [FromBody] Command.Write.yConfigArctetureCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yConfigArctetureEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yConfigArctetureEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/yConfigNotification/PutyConfigNotification", async ([FromServices] Command.Receivers.Write.UpdateyConfigNotificationReceiver receiver, [FromBody] Command.Write.yConfigNotificationCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yConfigNotificationEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yConfigNotificationEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/yPerfil/PutyPerfil", async ([FromServices] Command.Receivers.Write.UpdateyPerfilReceiver receiver, [FromBody] Command.Write.yPerfilCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yPerfilEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yPerfilEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/yModule/PutyModule", async ([FromServices] Command.Receivers.Write.UpdateyModuleReceiver receiver, [FromBody] Command.Write.yModuleCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yModuleEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yModuleEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/yTenantModule/PutyTenantModule", async ([FromServices] Command.Receivers.Write.UpdateyTenantModuleReceiver receiver, [FromBody] Command.Write.yTenantModuleCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yTenantModuleEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yTenantModuleEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/yUserModule/PutyUserModule", async ([FromServices] Command.Receivers.Write.UpdateyUserModuleReceiver receiver, [FromBody] Command.Write.yUserModuleCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yUserModuleEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yUserModuleEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/yGrant/PutyGrant", async ([FromServices] Command.Receivers.Write.UpdateyGrantReceiver receiver, [FromBody] Command.Write.yGrantCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yGrantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yGrantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/yPerfilGrant/PutyPerfilGrant", async ([FromServices] Command.Receivers.Write.UpdateyPerfilGrantReceiver receiver, [FromBody] Command.Write.yPerfilGrantCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yPerfilGrantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yPerfilGrantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/yUserGrant/PutyUserGrant", async ([FromServices] Command.Receivers.Write.UpdateyUserGrantReceiver receiver, [FromBody] Command.Write.yUserGrantCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yUserGrantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yUserGrantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/Produto/DeleteProduto", async ([FromServices] Command.Receivers.Write.DeleteProdutoReceiver receiver, [FromBody] Command.Write.ProdutoCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.ProdutoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ProdutoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/Maquina/DeleteMaquina", async ([FromServices] Command.Receivers.Write.DeleteMaquinaReceiver receiver, [FromBody] Command.Write.MaquinaCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.MaquinaEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.MaquinaEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/GrupoMaquina/DeleteGrupoMaquina", async ([FromServices] Command.Receivers.Write.DeleteGrupoMaquinaReceiver receiver, [FromBody] Command.Write.GrupoMaquinaCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.GrupoMaquinaEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.GrupoMaquinaEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/TemplateDeTestes/DeleteTemplateDeTestes", async ([FromServices] Command.Receivers.Write.DeleteTemplateDeTestesReceiver receiver, [FromBody] Command.Write.TemplateDeTestesCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.TemplateDeTestesEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.TemplateDeTestesEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/Roteiro/DeleteRoteiro", async ([FromServices] Command.Receivers.Write.DeleteRoteiroReceiver receiver, [FromBody] Command.Write.RoteiroCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.RoteiroEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.RoteiroEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/yFileUpload/DeleteyFileUpload", async ([FromServices] Command.Receivers.Write.DeleteyFileUploadReceiver receiver, [FromBody] Command.Write.yFileUploadCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yFileUploadEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yFileUploadEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/ySaga/DeleteySaga", async ([FromServices] Command.Receivers.Write.DeleteySagaReceiver receiver, [FromBody] Command.Write.ySagaCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.ySagaEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ySagaEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/ySagaStep/DeleteySagaStep", async ([FromServices] Command.Receivers.Write.DeleteySagaStepReceiver receiver, [FromBody] Command.Write.ySagaStepCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.ySagaStepEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ySagaStepEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/yOutbox/DeleteyOutbox", async ([FromServices] Command.Receivers.Write.DeleteyOutboxReceiver receiver, [FromBody] Command.Write.yOutboxCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yOutboxEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yOutboxEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/yInbox/DeleteyInbox", async ([FromServices] Command.Receivers.Write.DeleteyInboxReceiver receiver, [FromBody] Command.Write.yInboxCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yInboxEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yInboxEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/yTenant/DeleteyTenant", async ([FromServices] Command.Receivers.Write.DeleteyTenantReceiver receiver, [FromBody] Command.Write.yTenantCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yTenantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yTenantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/yUser/DeleteyUser", async ([FromServices] Command.Receivers.Write.DeleteyUserReceiver receiver, [FromBody] Command.Write.yUserCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yUserEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yUserEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/yConfigArcteture/DeleteyConfigArcteture", async ([FromServices] Command.Receivers.Write.DeleteyConfigArctetureReceiver receiver, [FromBody] Command.Write.yConfigArctetureCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yConfigArctetureEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yConfigArctetureEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/yConfigNotification/DeleteyConfigNotification", async ([FromServices] Command.Receivers.Write.DeleteyConfigNotificationReceiver receiver, [FromBody] Command.Write.yConfigNotificationCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yConfigNotificationEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yConfigNotificationEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/yPerfil/DeleteyPerfil", async ([FromServices] Command.Receivers.Write.DeleteyPerfilReceiver receiver, [FromBody] Command.Write.yPerfilCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yPerfilEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yPerfilEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/yModule/DeleteyModule", async ([FromServices] Command.Receivers.Write.DeleteyModuleReceiver receiver, [FromBody] Command.Write.yModuleCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yModuleEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yModuleEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/yTenantModule/DeleteyTenantModule", async ([FromServices] Command.Receivers.Write.DeleteyTenantModuleReceiver receiver, [FromBody] Command.Write.yTenantModuleCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yTenantModuleEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yTenantModuleEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/yUserModule/DeleteyUserModule", async ([FromServices] Command.Receivers.Write.DeleteyUserModuleReceiver receiver, [FromBody] Command.Write.yUserModuleCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yUserModuleEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yUserModuleEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/yGrant/DeleteyGrant", async ([FromServices] Command.Receivers.Write.DeleteyGrantReceiver receiver, [FromBody] Command.Write.yGrantCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yGrantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yGrantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/yPerfilGrant/DeleteyPerfilGrant", async ([FromServices] Command.Receivers.Write.DeleteyPerfilGrantReceiver receiver, [FromBody] Command.Write.yPerfilGrantCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yPerfilGrantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yPerfilGrantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/yUserGrant/DeleteyUserGrant", async ([FromServices] Command.Receivers.Write.DeleteyUserGrantReceiver receiver, [FromBody] Command.Write.yUserGrantCrudCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yUserGrantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yUserGrantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();



                    app.MapGet("/yapi/getMenu", (HttpContext context) =>
                    {
                        var modulesClaim = context.User.Claims.FirstOrDefault(c => c.Type == "userModules")?.Value;
                        if (modulesClaim == null)
                            return Results.Unauthorized();

                        var moduleKeys = modulesClaim.Split(',', StringSplitOptions.RemoveEmptyEntries);
                        var userModules = StaticModules.Modules
                            .Where(m => moduleKeys.Contains(m.Key))
                            .ToList();

                        var result = userModules.Select(m => new
                        {
                            id = m.Key,
                            description = m.Title,
                            children = m.Menus.Select(menu => new
                            {
                                description = menu.Title,
                                endpoint = $"/getMetaData{menu.Title}",
                                type = "crud"
                            }).ToList()
                        }).ToList();

                        return Results.Ok(result);
                    }).RequireAuthorization();
            
app.MapPost("/yapi/Produto/ReadProduto", async ([FromServices] Command.Receivers.Read.ProdutoReadReceiver receiver, [FromBody] Command.Read.ProdutoReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.ProdutoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ProdutoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/Maquina/ReadMaquina", async ([FromServices] Command.Receivers.Read.MaquinaReadReceiver receiver, [FromBody] Command.Read.MaquinaReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.MaquinaEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.MaquinaEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/GrupoMaquina/ReadGrupoMaquina", async ([FromServices] Command.Receivers.Read.GrupoMaquinaReadReceiver receiver, [FromBody] Command.Read.GrupoMaquinaReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.GrupoMaquinaEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.GrupoMaquinaEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/TemplateDeTestes/ReadTemplateDeTestes", async ([FromServices] Command.Receivers.Read.TemplateDeTestesReadReceiver receiver, [FromBody] Command.Read.TemplateDeTestesReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.TemplateDeTestesEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.TemplateDeTestesEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/Roteiro/ReadRoteiro", async ([FromServices] Command.Receivers.Read.RoteiroReadReceiver receiver, [FromBody] Command.Read.RoteiroReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.RoteiroEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.RoteiroEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/ConsultaPedido/ReadConsultaPedido", async ([FromServices] Command.Receivers.Read.ConsultaPedidoReadReceiver receiver, [FromBody] Command.Read.ConsultaPedidoReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.ConsultaPedidoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ConsultaPedidoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/RoteiroPedido/ReadRoteiroPedido", async ([FromServices] Command.Receivers.Read.RoteiroPedidoReadReceiver receiver, [FromBody] Command.Read.RoteiroPedidoReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.RoteiroPedidoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.RoteiroPedidoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yFileUpload/ReadyFileUpload", async ([FromServices] Command.Receivers.Read.yFileUploadReadReceiver receiver, [FromBody] Command.Read.yFileUploadReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yFileUploadEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yFileUploadEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/ySaga/ReadySaga", async ([FromServices] Command.Receivers.Read.ySagaReadReceiver receiver, [FromBody] Command.Read.ySagaReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.ySagaEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ySagaEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/ySagaStep/ReadySagaStep", async ([FromServices] Command.Receivers.Read.ySagaStepReadReceiver receiver, [FromBody] Command.Read.ySagaStepReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.ySagaStepEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ySagaStepEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yOutbox/ReadyOutbox", async ([FromServices] Command.Receivers.Read.yOutboxReadReceiver receiver, [FromBody] Command.Read.yOutboxReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yOutboxEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yOutboxEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yInbox/ReadyInbox", async ([FromServices] Command.Receivers.Read.yInboxReadReceiver receiver, [FromBody] Command.Read.yInboxReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yInboxEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yInboxEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yTenant/ReadyTenant", async ([FromServices] Command.Receivers.Read.yTenantReadReceiver receiver, [FromBody] Command.Read.yTenantReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yTenantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yTenantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yUser/ReadyUser", async ([FromServices] Command.Receivers.Read.yUserReadReceiver receiver, [FromBody] Command.Read.yUserReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yUserEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yUserEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yConfigArcteture/ReadyConfigArcteture", async ([FromServices] Command.Receivers.Read.yConfigArctetureReadReceiver receiver, [FromBody] Command.Read.yConfigArctetureReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yConfigArctetureEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yConfigArctetureEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yConfigNotification/ReadyConfigNotification", async ([FromServices] Command.Receivers.Read.yConfigNotificationReadReceiver receiver, [FromBody] Command.Read.yConfigNotificationReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yConfigNotificationEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yConfigNotificationEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yPerfil/ReadyPerfil", async ([FromServices] Command.Receivers.Read.yPerfilReadReceiver receiver, [FromBody] Command.Read.yPerfilReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yPerfilEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yPerfilEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yModule/ReadyModule", async ([FromServices] Command.Receivers.Read.yModuleReadReceiver receiver, [FromBody] Command.Read.yModuleReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yModuleEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yModuleEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yTenantModule/ReadyTenantModule", async ([FromServices] Command.Receivers.Read.yTenantModuleReadReceiver receiver, [FromBody] Command.Read.yTenantModuleReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yTenantModuleEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yTenantModuleEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yUserModule/ReadyUserModule", async ([FromServices] Command.Receivers.Read.yUserModuleReadReceiver receiver, [FromBody] Command.Read.yUserModuleReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yUserModuleEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yUserModuleEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yGrant/ReadyGrant", async ([FromServices] Command.Receivers.Read.yGrantReadReceiver receiver, [FromBody] Command.Read.yGrantReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yGrantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yGrantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yPerfilGrant/ReadyPerfilGrant", async ([FromServices] Command.Receivers.Read.yPerfilGrantReadReceiver receiver, [FromBody] Command.Read.yPerfilGrantReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yPerfilGrantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yPerfilGrantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yUserGrant/ReadyUserGrant", async ([FromServices] Command.Receivers.Read.yUserGrantReadReceiver receiver, [FromBody] Command.Read.yUserGrantReadCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yUserGrantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yUserGrantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yOutbox/ReadyOutboxProximaPendente", async ([FromServices] Command.Receivers.Read.yOutboxReadQueryProximaPendenteReceiver receiver, [FromBody] Command.Read.yOutboxProximaPendenteCommand command) =>
{
 return await Task.FromResult(StateResults.Try(() => receiver.Execute(command)));
}).Produces<State<Dominio.Entitys.yOutboxEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yOutboxEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/Produto/ProdutoReadFKTenantID", async ([FromServices] Command.Receivers.Read.ProdutoReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/Produto/ProdutoReadFKUserId", async ([FromServices] Command.Receivers.Read.ProdutoReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/Maquina/MaquinaReadFKTenantID", async ([FromServices] Command.Receivers.Read.MaquinaReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/Maquina/MaquinaReadFKUserId", async ([FromServices] Command.Receivers.Read.MaquinaReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/GrupoMaquina/GrupoMaquinaReadFKTenantID", async ([FromServices] Command.Receivers.Read.GrupoMaquinaReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/GrupoMaquina/GrupoMaquinaReadFKUserId", async ([FromServices] Command.Receivers.Read.GrupoMaquinaReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/TemplateDeTestes/TemplateDeTestesReadFKTenantID", async ([FromServices] Command.Receivers.Read.TemplateDeTestesReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/TemplateDeTestes/TemplateDeTestesReadFKUserId", async ([FromServices] Command.Receivers.Read.TemplateDeTestesReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/Roteiro/RoteiroReadFKMaquinaId", async ([FromServices] Command.Receivers.Read.RoteiroReadFKMaquinaIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/Roteiro/RoteiroReadFKProdutoId", async ([FromServices] Command.Receivers.Read.RoteiroReadFKProdutoIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/Roteiro/RoteiroReadFKGrupoMaquinaId", async ([FromServices] Command.Receivers.Read.RoteiroReadFKGrupoMaquinaIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/Roteiro/RoteiroReadFKTemplateDeTestesId", async ([FromServices] Command.Receivers.Read.RoteiroReadFKTemplateDeTestesIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/Roteiro/RoteiroReadFKTenantID", async ([FromServices] Command.Receivers.Read.RoteiroReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/Roteiro/RoteiroReadFKUserId", async ([FromServices] Command.Receivers.Read.RoteiroReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/ConsultaPedido/ConsultaPedidoReadFKProdutoId", async ([FromServices] Command.Receivers.Read.ConsultaPedidoReadFKProdutoIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/RoteiroPedido/RoteiroPedidoReadFKPedidoId", async ([FromServices] Command.Receivers.Read.RoteiroPedidoReadFKPedidoIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/RoteiroPedido/RoteiroPedidoReadFKMaquinaId", async ([FromServices] Command.Receivers.Read.RoteiroPedidoReadFKMaquinaIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/RoteiroPedido/RoteiroPedidoReadFKProdutoId", async ([FromServices] Command.Receivers.Read.RoteiroPedidoReadFKProdutoIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yFileUpload/yFileUploadReadFKTenantID", async ([FromServices] Command.Receivers.Read.yFileUploadReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yFileUpload/yFileUploadReadFKUserId", async ([FromServices] Command.Receivers.Read.yFileUploadReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/ySaga/ySagaReadFKTenantID", async ([FromServices] Command.Receivers.Read.ySagaReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/ySaga/ySagaReadFKUserId", async ([FromServices] Command.Receivers.Read.ySagaReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/ySagaStep/ySagaStepReadFKSagaId", async ([FromServices] Command.Receivers.Read.ySagaStepReadFKSagaIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/ySagaStep/ySagaStepReadFKTenantID", async ([FromServices] Command.Receivers.Read.ySagaStepReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/ySagaStep/ySagaStepReadFKUserId", async ([FromServices] Command.Receivers.Read.ySagaStepReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yOutbox/yOutboxReadFKSagaId", async ([FromServices] Command.Receivers.Read.yOutboxReadFKSagaIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yOutbox/yOutboxReadFKSagaStepId", async ([FromServices] Command.Receivers.Read.yOutboxReadFKSagaStepIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yOutbox/yOutboxReadFKTenantID", async ([FromServices] Command.Receivers.Read.yOutboxReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yOutbox/yOutboxReadFKUserId", async ([FromServices] Command.Receivers.Read.yOutboxReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yInbox/yInboxReadFKSagaId", async ([FromServices] Command.Receivers.Read.yInboxReadFKSagaIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yInbox/yInboxReadFKSagaStepId", async ([FromServices] Command.Receivers.Read.yInboxReadFKSagaStepIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yInbox/yInboxReadFKTenantID", async ([FromServices] Command.Receivers.Read.yInboxReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yInbox/yInboxReadFKUserId", async ([FromServices] Command.Receivers.Read.yInboxReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yUser/yUserReadFKTenantID", async ([FromServices] Command.Receivers.Read.yUserReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yConfigArcteture/yConfigArctetureReadFKTenantID", async ([FromServices] Command.Receivers.Read.yConfigArctetureReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yConfigArcteture/yConfigArctetureReadFKUserId", async ([FromServices] Command.Receivers.Read.yConfigArctetureReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yConfigNotification/yConfigNotificationReadFKTenantID", async ([FromServices] Command.Receivers.Read.yConfigNotificationReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yConfigNotification/yConfigNotificationReadFKUserId", async ([FromServices] Command.Receivers.Read.yConfigNotificationReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yPerfil/yPerfilReadFKTenantID", async ([FromServices] Command.Receivers.Read.yPerfilReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yPerfil/yPerfilReadFKUserId", async ([FromServices] Command.Receivers.Read.yPerfilReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yTenantModule/yTenantModuleReadFKModuleId", async ([FromServices] Command.Receivers.Read.yTenantModuleReadFKModuleIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yTenantModule/yTenantModuleReadFKTenantID", async ([FromServices] Command.Receivers.Read.yTenantModuleReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yTenantModule/yTenantModuleReadFKUserId", async ([FromServices] Command.Receivers.Read.yTenantModuleReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yUserModule/yUserModuleReadFKModuleId", async ([FromServices] Command.Receivers.Read.yUserModuleReadFKModuleIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yUserModule/yUserModuleReadFKUserId", async ([FromServices] Command.Receivers.Read.yUserModuleReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yUserModule/yUserModuleReadFKTenantID", async ([FromServices] Command.Receivers.Read.yUserModuleReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yGrant/yGrantReadFKTenantID", async ([FromServices] Command.Receivers.Read.yGrantReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yGrant/yGrantReadFKUserId", async ([FromServices] Command.Receivers.Read.yGrantReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yPerfilGrant/yPerfilGrantReadFKPerfilId", async ([FromServices] Command.Receivers.Read.yPerfilGrantReadFKPerfilIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yPerfilGrant/yPerfilGrantReadFKGrantId", async ([FromServices] Command.Receivers.Read.yPerfilGrantReadFKGrantIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yPerfilGrant/yPerfilGrantReadFKTenantID", async ([FromServices] Command.Receivers.Read.yPerfilGrantReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yPerfilGrant/yPerfilGrantReadFKUserId", async ([FromServices] Command.Receivers.Read.yPerfilGrantReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yUserGrant/yUserGrantReadFKPerfilId", async ([FromServices] Command.Receivers.Read.yUserGrantReadFKPerfilIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yUserGrant/yUserGrantReadFKGrantId", async ([FromServices] Command.Receivers.Read.yUserGrantReadFKGrantIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yUserGrant/yUserGrantReadFKTenantID", async ([FromServices] Command.Receivers.Read.yUserGrantReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yUserGrant/yUserGrantReadFKUserId", async ([FromServices] Command.Receivers.Read.yUserGrantReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapGet("/yapi/getMetaDataProduto", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "Produto",
        entityDescription = "Produto",
        source = new
        {
            kind = "table",
            name = "Produto"
        },
        capabilities = new
        {
            create = true,
            update = true,
            delete = true
        },
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
                endpoint = "/Produto/ReadProduto",
            resultFields = new[]
            {
                new { id = "id", label = "Codigo do Produto", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "descricao", label = "Descricao do Produto", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status do Produto", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "Codigo do Produto", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "descricao", label = "Descricao do Produto", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status do Produto", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "Codigo do Produto", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "descricao", label = "Descricao do Produto", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "status", label = "Status do Produto", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
            create = "/Produto/PostProduto",
            read = "/Produto/ReadProduto",
            update = "/Produto/PutProduto",
            delete = "/Produto/DeleteProduto"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDataMaquina", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "Maquina",
        entityDescription = "Maquina",
        source = new
        {
            kind = "table",
            name = "Maquina"
        },
        capabilities = new
        {
            create = true,
            update = true,
            delete = true
        },
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
                endpoint = "/Maquina/ReadMaquina",
            resultFields = new[]
            {
                new { id = "id", label = "Codigo da Maquina", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "descricao", label = "Descricao da Maquina", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status da Maquina", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "Codigo da Maquina", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "descricao", label = "Descricao da Maquina", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status da Maquina", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "Codigo da Maquina", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "descricao", label = "Descricao da Maquina", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "status", label = "Status da Maquina", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
            create = "/Maquina/PostMaquina",
            read = "/Maquina/ReadMaquina",
            update = "/Maquina/PutMaquina",
            delete = "/Maquina/DeleteMaquina"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDataGrupoMaquina", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "GrupoMaquina",
        entityDescription = "GrupoMaquina",
        source = new
        {
            kind = "table",
            name = "GrupoMaquina"
        },
        capabilities = new
        {
            create = true,
            update = true,
            delete = true
        },
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
                endpoint = "/GrupoMaquina/ReadGrupoMaquina",
            resultFields = new[]
            {
                new { id = "id", label = "Codigo do Grupo de Maquina", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "descricao", label = "Descricao do Grupo de Maquina", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status do Grupo de Maquina", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "Codigo do Grupo de Maquina", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "descricao", label = "Descricao do Grupo de Maquina", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status do Grupo de Maquina", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "Codigo do Grupo de Maquina", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "descricao", label = "Descricao do Grupo de Maquina", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "status", label = "Status do Grupo de Maquina", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
            create = "/GrupoMaquina/PostGrupoMaquina",
            read = "/GrupoMaquina/ReadGrupoMaquina",
            update = "/GrupoMaquina/PutGrupoMaquina",
            delete = "/GrupoMaquina/DeleteGrupoMaquina"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDataTemplateDeTestes", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "TemplateDeTestes",
        entityDescription = "TemplateDeTestes",
        source = new
        {
            kind = "table",
            name = "TemplateDeTestes"
        },
        capabilities = new
        {
            create = true,
            update = true,
            delete = true
        },
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
                endpoint = "/TemplateDeTestes/ReadTemplateDeTestes",
            resultFields = new[]
            {
                new { id = "id", label = "Template de Testes", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "descricao", label = "Descricao do Template", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "Template de Testes", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "descricao", label = "Descricao do Template", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "Template de Testes", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "descricao", label = "Descricao do Template", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
            create = "/TemplateDeTestes/PostTemplateDeTestes",
            read = "/TemplateDeTestes/ReadTemplateDeTestes",
            update = "/TemplateDeTestes/PutTemplateDeTestes",
            delete = "/TemplateDeTestes/DeleteTemplateDeTestes"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDataRoteiro", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "Roteiro",
        entityDescription = "Roteiro",
        source = new
        {
            kind = "table",
            name = "Roteiro"
        },
        capabilities = new
        {
            create = true,
            update = true,
            delete = true
        },
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
                endpoint = "/Roteiro/ReadRoteiro",
            resultFields = new[]
            {
                new { id = "id", label = "Id", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "maquinaid", label = "Codigo da Maquina", type = "string", isFk = true, endPontGetMetadata = "/getMetaDataMaquina", fksDisplayFields = new string[]{ "descricao" }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "produtoid", label = "Codigo do Produto", type = "string", isFk = true, endPontGetMetadata = "/getMetaDataProduto", fksDisplayFields = new string[]{ "descricao" }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "sequenciatransformacao", label = "Sequencia de Transformacao", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "grupomaquinaid", label = "Grupo de Maquinas", type = "string", isFk = true, endPontGetMetadata = "/getMetaDataGrupoMaquina", fksDisplayFields = new string[]{ "descricao" }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "pecasporpulso", label = "Quantidade de Pecas por Pulso", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "prioridadeinformada", label = "Grau de Prioridade", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "acao", label = "Maquina Excecao", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "performance", label = "Performance Pulsos por Segundo", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "temposetup", label = "Setup em Segundos", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "temposetupajuste", label = "Tempo Setup Ajuste em Segundos", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "proximasequenciatransformacao", label = "Proxima Sequencia de Transformacao", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "hierarquiasequenciatransformacao", label = "Hierarquia Calculo", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "avaliacusto", label = "Avalia Custo", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "operacoes", label = "Operacoes", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "excecaooperacoes", label = "Excecao Operacoes", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "percentualiniciopassoanterior", label = "Percentual Inicio Passo Anterior", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "linhadireta", label = "Linha Direta", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "templatedetestesid", label = "Template de Testes", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataTemplateDeTestes", fksDisplayFields = new string[]{ "descricao" }, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "Id", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "maquinaid", label = "Codigo da Maquina", type = "string", isFk = true, endPontGetMetadata = "/getMetaDataMaquina", fksDisplayFields = new string[]{ "descricao" }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "produtoid", label = "Codigo do Produto", type = "string", isFk = true, endPontGetMetadata = "/getMetaDataProduto", fksDisplayFields = new string[]{ "descricao" }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "sequenciatransformacao", label = "Sequencia de Transformacao", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "grupomaquinaid", label = "Grupo de Maquinas", type = "string", isFk = true, endPontGetMetadata = "/getMetaDataGrupoMaquina", fksDisplayFields = new string[]{ "descricao" }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "pecasporpulso", label = "Quantidade de Pecas por Pulso", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "prioridadeinformada", label = "Grau de Prioridade", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "acao", label = "Maquina Excecao", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "performance", label = "Performance Pulsos por Segundo", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "temposetup", label = "Setup em Segundos", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "temposetupajuste", label = "Tempo Setup Ajuste em Segundos", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "proximasequenciatransformacao", label = "Proxima Sequencia de Transformacao", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "hierarquiasequenciatransformacao", label = "Hierarquia Calculo", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "avaliacusto", label = "Avalia Custo", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "operacoes", label = "Operacoes", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "excecaooperacoes", label = "Excecao Operacoes", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "percentualiniciopassoanterior", label = "Percentual Inicio Passo Anterior", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "linhadireta", label = "Linha Direta", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "templatedetestesid", label = "Template de Testes", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataTemplateDeTestes", fksDisplayFields = new string[]{ "descricao" }, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
                maquinaid = "/Roteiro/RoteiroReadFKMaquinaId",
                produtoid = "/Roteiro/RoteiroReadFKProdutoId",
                grupomaquinaid = "/Roteiro/RoteiroReadFKGrupoMaquinaId",
                templatedetestesid = "/Roteiro/RoteiroReadFKTemplateDeTestesId",
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "Id", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "maquinaid", label = "Codigo da Maquina", type = "string", required = false, displaygroup = "Principal", isFk = true, endPontGetMetadata = "/getMetaDataMaquina", fksDisplayFields = new string[]{ "descricao" }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "produtoid", label = "Codigo do Produto", type = "string", required = false, displaygroup = "Principal", isFk = true, endPontGetMetadata = "/getMetaDataProduto", fksDisplayFields = new string[]{ "descricao" }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "sequenciatransformacao", label = "Sequencia de Transformacao", type = "int", required = false, displaygroup = "Principal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "grupomaquinaid", label = "Grupo de Maquinas", type = "string", required = false, displaygroup = "Principal", isFk = true, endPontGetMetadata = "/getMetaDataGrupoMaquina", fksDisplayFields = new string[]{ "descricao" }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "pecasporpulso", label = "Quantidade de Pecas por Pulso", type = "Decimal", required = false, displaygroup = "Principal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "prioridadeinformada", label = "Grau de Prioridade", type = "Decimal", required = false, displaygroup = "Principal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "acao", label = "Maquina Excecao", type = "string", required = false, displaygroup = "Principal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "performance", label = "Performance Pulsos por Segundo", type = "Decimal", required = false, displaygroup = "Principal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "temposetup", label = "Setup em Segundos", type = "Decimal", required = false, displaygroup = "Principal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "temposetupajuste", label = "Tempo Setup Ajuste em Segundos", type = "Decimal", required = false, displaygroup = "Principal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "proximasequenciatransformacao", label = "Proxima Sequencia de Transformacao", type = "int", required = false, displaygroup = "Principal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "status", label = "Status", type = "string", required = false, displaygroup = "Principal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "hierarquiasequenciatransformacao", label = "Hierarquia Calculo", type = "Decimal", required = false, displaygroup = "Principal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "avaliacusto", label = "Avalia Custo", type = "int", required = false, displaygroup = "Principal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "operacoes", label = "Operacoes", type = "string", required = false, displaygroup = "Principal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "excecaooperacoes", label = "Excecao Operacoes", type = "string", required = false, displaygroup = "Principal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "percentualiniciopassoanterior", label = "Percentual Inicio Passo Anterior", type = "Decimal", required = false, displaygroup = "Principal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "linhadireta", label = "Linha Direta", type = "string", required = false, displaygroup = "Principal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "templatedetestesid", label = "Template de Testes", type = "int", required = false, displaygroup = "Qualidade", isFk = true, endPontGetMetadata = "/getMetaDataTemplateDeTestes", fksDisplayFields = new string[]{ "descricao" }, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
                 maquinaid = "/Roteiro/RoteiroReadFKMaquinaId",
                 produtoid = "/Roteiro/RoteiroReadFKProdutoId",
                 grupomaquinaid = "/Roteiro/RoteiroReadFKGrupoMaquinaId",
                 templatedetestesid = "/Roteiro/RoteiroReadFKTemplateDeTestesId",
            create = "/Roteiro/PostRoteiro",
            read = "/Roteiro/ReadRoteiro",
            update = "/Roteiro/PutRoteiro",
            delete = "/Roteiro/DeleteRoteiro"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDataConsultaPedido", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "ConsultaPedido",
        entityDescription = "Consulta de Pedido",
        source = new
        {
            kind = "view",
            name = "V_CONSULTA_PEDIDO"
        },
        capabilities = new
        {
            create = false,
            update = false,
            delete = false
        },
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
                endpoint = "/ConsultaPedido/ReadConsultaPedido",
            resultFields = new[]
            {
                new { id = "pedidoid", label = "Pedido", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "clienteid", label = "Cliente", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "clientenome", label = "Nome do Cliente", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "razaosocial", label = "Razao Social", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "produtoid", label = "Produto", type = "string", isFk = true, endPontGetMetadata = "/getMetaDataProduto", fksDisplayFields = new string[]{ "descricao" }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "produtodescricao", label = "Descricao do Produto", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status do Pedido", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "estagio", label = "Estagio", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "dataentregade", label = "Entrega de", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "dataentregaate", label = "Entrega ate", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "embarquealvo", label = "Embarque Alvo", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "quantidade", label = "Quantidade", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "saldoaproduzir", label = "Saldo a Produzir", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "saldoaexpedir", label = "Saldo a Expedir", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "corfila", label = "Cor da Fila", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "pedidocliente", label = "Pedido do Cliente", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "pedidoid", label = "Pedido", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "clienteid", label = "Cliente", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "clientenome", label = "Nome do Cliente", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "razaosocial", label = "Razao Social", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "produtoid", label = "Produto", type = "string", isFk = true, endPontGetMetadata = "/getMetaDataProduto", fksDisplayFields = new string[]{ "descricao" }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "produtodescricao", label = "Descricao do Produto", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status do Pedido", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "estagio", label = "Estagio", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "dataentregade", label = "Entrega de", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "dataentregaate", label = "Entrega ate", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "embarquealvo", label = "Embarque Alvo", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "quantidade", label = "Quantidade", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "saldoaproduzir", label = "Saldo a Produzir", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "saldoaexpedir", label = "Saldo a Expedir", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "corfila", label = "Cor da Fila", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "pedidocliente", label = "Pedido do Cliente", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
                produtoid = "/ConsultaPedido/ConsultaPedidoReadFKProdutoId",
            }
            },
        },
        formFields = new[]
        {
            new { id = "pedidoid", label = "Pedido", type = "string", required = false, displaygroup = "Pedido", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "clienteid", label = "Cliente", type = "string", required = false, displaygroup = "Cliente", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "clientenome", label = "Nome do Cliente", type = "string", required = false, displaygroup = "Cliente", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "razaosocial", label = "Razao Social", type = "string", required = false, displaygroup = "Cliente", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "produtoid", label = "Produto", type = "string", required = false, displaygroup = "Produto", isFk = true, endPontGetMetadata = "/getMetaDataProduto", fksDisplayFields = new string[]{ "descricao" }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "produtodescricao", label = "Descricao do Produto", type = "string", required = false, displaygroup = "Produto", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "status", label = "Status do Pedido", type = "string", required = false, displaygroup = "Pedido", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "estagio", label = "Estagio", type = "string", required = false, displaygroup = "Pedido", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "dataentregade", label = "Entrega de", type = "DateTime", required = false, displaygroup = "Datas", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "dataentregaate", label = "Entrega ate", type = "DateTime", required = false, displaygroup = "Datas", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "embarquealvo", label = "Embarque Alvo", type = "DateTime", required = false, displaygroup = "Datas", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "quantidade", label = "Quantidade", type = "Decimal", required = false, displaygroup = "Saldos", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "saldoaproduzir", label = "Saldo a Produzir", type = "Decimal", required = false, displaygroup = "Saldos", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "saldoaexpedir", label = "Saldo a Expedir", type = "Decimal", required = false, displaygroup = "Saldos", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "corfila", label = "Cor da Fila", type = "string", required = false, displaygroup = "Pedido", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "pedidocliente", label = "Pedido do Cliente", type = "string", required = false, displaygroup = "Pedido", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = new[]
        {
            new
            {
                id = "Roteiro",
                title = "Roteiro",
                entity = "RoteiroPedido",
                parentField = "pedidoid",
                childField = "pedidoid",
                endpoint = "/RoteiroPedido/ReadRoteiroPedido"
            },
        },
        customTabs = new[]
        {
            new
            {
                id = "Tracker",
                title = "Tracker",
                useCase = "ConsultaPedido.ObterTracker",
                frontComponent = "ConsultaPedidoTracker"
            },
        },
        actions = Array.Empty<object>(),
        endpoints = new
        {
                 produtoid = "/ConsultaPedido/ConsultaPedidoReadFKProdutoId",
            create = "",
            read = "/ConsultaPedido/ReadConsultaPedido",
            update = "",
            delete = ""
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDataRoteiroPedido", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "RoteiroPedido",
        entityDescription = "Roteiro do Pedido",
        source = new
        {
            kind = "view",
            name = "V_ROTEIRO_PEDIDO"
        },
        capabilities = new
        {
            create = false,
            update = false,
            delete = false
        },
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
                endpoint = "/RoteiroPedido/ReadRoteiroPedido",
            resultFields = new[]
            {
                new { id = "pedidoid", label = "Pedido", type = "string", isFk = true, endPontGetMetadata = "/getMetaDataConsultaPedido", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "maquinaid", label = "Maquina", type = "string", isFk = true, endPontGetMetadata = "/getMetaDataMaquina", fksDisplayFields = new string[]{ "descricao" }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "produtoid", label = "Produto", type = "string", isFk = true, endPontGetMetadata = "/getMetaDataProduto", fksDisplayFields = new string[]{ "descricao" }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "sequenciatransformacao", label = "Sequencia de Transformacao", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "statuscadastro", label = "Status do Cadastro", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "tipoplanejamento", label = "Tipo de Planejamento", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "calendarioid", label = "Calendario", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "hierarquiasequenciatransformacao", label = "Hierarquia Calculo", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "proximasequenciatransformacao", label = "Proxima Sequencia", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "performance", label = "Performance", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "temposetup", label = "Tempo Setup", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "temposetupajuste", label = "Tempo Setup Ajuste", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "pecasporpulso", label = "Pecas por Pulso", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "prioridadeinformada", label = "Prioridade Informada", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "operacoes", label = "Operacoes", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "excecaooperacoes", label = "Excecao Operacoes", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "linhadireta", label = "Linha Direta", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "avaliacusto", label = "Avalia Custo", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "percentualiniciopassoanterior", label = "Percentual Inicio Passo Anterior", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "maquinalargurautil", label = "Largura Util da Maquina", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "grupotipo", label = "Tipo do Grupo", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "grupoperformancemetrolinear", label = "Performance Metro Linear", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "pedidoid", label = "Pedido", type = "string", isFk = true, endPontGetMetadata = "/getMetaDataConsultaPedido", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "maquinaid", label = "Maquina", type = "string", isFk = true, endPontGetMetadata = "/getMetaDataMaquina", fksDisplayFields = new string[]{ "descricao" }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "produtoid", label = "Produto", type = "string", isFk = true, endPontGetMetadata = "/getMetaDataProduto", fksDisplayFields = new string[]{ "descricao" }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "sequenciatransformacao", label = "Sequencia de Transformacao", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "statuscadastro", label = "Status do Cadastro", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "tipoplanejamento", label = "Tipo de Planejamento", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "calendarioid", label = "Calendario", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "hierarquiasequenciatransformacao", label = "Hierarquia Calculo", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "proximasequenciatransformacao", label = "Proxima Sequencia", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "performance", label = "Performance", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "temposetup", label = "Tempo Setup", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "temposetupajuste", label = "Tempo Setup Ajuste", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "pecasporpulso", label = "Pecas por Pulso", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "prioridadeinformada", label = "Prioridade Informada", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "operacoes", label = "Operacoes", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "excecaooperacoes", label = "Excecao Operacoes", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "linhadireta", label = "Linha Direta", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "avaliacusto", label = "Avalia Custo", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "percentualiniciopassoanterior", label = "Percentual Inicio Passo Anterior", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "maquinalargurautil", label = "Largura Util da Maquina", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "grupotipo", label = "Tipo do Grupo", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "grupoperformancemetrolinear", label = "Performance Metro Linear", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
                pedidoid = "/RoteiroPedido/RoteiroPedidoReadFKPedidoId",
                maquinaid = "/RoteiroPedido/RoteiroPedidoReadFKMaquinaId",
                produtoid = "/RoteiroPedido/RoteiroPedidoReadFKProdutoId",
            }
            },
        },
        formFields = new[]
        {
            new { id = "pedidoid", label = "Pedido", type = "string", required = false, displaygroup = "Principal", isFk = true, endPontGetMetadata = "/getMetaDataConsultaPedido", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "maquinaid", label = "Maquina", type = "string", required = false, displaygroup = "Principal", isFk = true, endPontGetMetadata = "/getMetaDataMaquina", fksDisplayFields = new string[]{ "descricao" }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "produtoid", label = "Produto", type = "string", required = false, displaygroup = "Principal", isFk = true, endPontGetMetadata = "/getMetaDataProduto", fksDisplayFields = new string[]{ "descricao" }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "sequenciatransformacao", label = "Sequencia de Transformacao", type = "int", required = false, displaygroup = "Principal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "statuscadastro", label = "Status do Cadastro", type = "string", required = false, displaygroup = "Principal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "tipoplanejamento", label = "Tipo de Planejamento", type = "string", required = false, displaygroup = "Principal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "calendarioid", label = "Calendario", type = "int", required = false, displaygroup = "Principal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "hierarquiasequenciatransformacao", label = "Hierarquia Calculo", type = "Decimal", required = false, displaygroup = "Principal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "proximasequenciatransformacao", label = "Proxima Sequencia", type = "int", required = false, displaygroup = "Principal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "performance", label = "Performance", type = "Decimal", required = false, displaygroup = "Principal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "temposetup", label = "Tempo Setup", type = "Decimal", required = false, displaygroup = "Principal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "temposetupajuste", label = "Tempo Setup Ajuste", type = "Decimal", required = false, displaygroup = "Principal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "pecasporpulso", label = "Pecas por Pulso", type = "Decimal", required = false, displaygroup = "Principal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "prioridadeinformada", label = "Prioridade Informada", type = "Decimal", required = false, displaygroup = "Principal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "status", label = "Status", type = "string", required = false, displaygroup = "Principal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "operacoes", label = "Operacoes", type = "string", required = false, displaygroup = "Principal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "excecaooperacoes", label = "Excecao Operacoes", type = "string", required = false, displaygroup = "Principal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "linhadireta", label = "Linha Direta", type = "string", required = false, displaygroup = "Principal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "avaliacusto", label = "Avalia Custo", type = "int", required = false, displaygroup = "Custo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "percentualiniciopassoanterior", label = "Percentual Inicio Passo Anterior", type = "Decimal", required = false, displaygroup = "Custo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "maquinalargurautil", label = "Largura Util da Maquina", type = "Decimal", required = false, displaygroup = "Custo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "grupotipo", label = "Tipo do Grupo", type = "Decimal", required = false, displaygroup = "Custo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "grupoperformancemetrolinear", label = "Performance Metro Linear", type = "Decimal", required = false, displaygroup = "Custo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
                 pedidoid = "/RoteiroPedido/RoteiroPedidoReadFKPedidoId",
                 maquinaid = "/RoteiroPedido/RoteiroPedidoReadFKMaquinaId",
                 produtoid = "/RoteiroPedido/RoteiroPedidoReadFKProdutoId",
            create = "",
            read = "/RoteiroPedido/ReadRoteiroPedido",
            update = "",
            delete = ""
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDatayFileUpload", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "yFileUpload",
        entityDescription = "yFileUpload",
        source = new
        {
            kind = "table",
            name = "yFileUpload"
        },
        capabilities = new
        {
            create = true,
            update = true,
            delete = true
        },
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
                endpoint = "/yFileUpload/ReadyFileUpload",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "type", label = "Tipo do Arquivo", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status do Upload", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "Pending" }, new { value = 1, display = "Completed" }, new { value = 2, display = "Failed" },}, },
                new { id = "filepath", label = "Caminho do Arquivo", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "filesize", label = "Tamanho do Arquivo", type = "long", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "entitytype", label = "Entity Type", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "entityid", label = "Entity Id", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "createdat", label = "Criado em", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "completedat", label = "Finalizado em", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "type", label = "Tipo do Arquivo", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status do Upload", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "Pending" }, new { value = 1, display = "Completed" }, new { value = 2, display = "Failed" },}, },
                new { id = "filepath", label = "Caminho do Arquivo", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "filesize", label = "Tamanho do Arquivo", type = "long", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "entitytype", label = "Entity Type", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "entityid", label = "Entity Id", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "createdat", label = "Criado em", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "completedat", label = "Finalizado em", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "type", label = "Tipo do Arquivo", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "status", label = "Status do Upload", type = "enum", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "Pending" }, new { value = 1, display = "Completed" }, new { value = 2, display = "Failed" },}, },
            new { id = "filepath", label = "Caminho do Arquivo", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "filesize", label = "Tamanho do Arquivo", type = "long", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "entitytype", label = "Entity Type", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "entityid", label = "Entity Id", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "createdat", label = "Criado em", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "completedat", label = "Finalizado em", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
            create = "/yFileUpload/PostyFileUpload",
            read = "/yFileUpload/ReadyFileUpload",
            update = "/yFileUpload/PutyFileUpload",
            delete = "/yFileUpload/DeleteyFileUpload"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDataySaga", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "ySaga",
        entityDescription = "ySaga",
        source = new
        {
            kind = "table",
            name = "ySaga"
        },
        capabilities = new
        {
            create = true,
            update = true,
            delete = true
        },
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
                endpoint = "/ySaga/ReadySaga",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "correlationid", label = "CorrelationId", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "type", label = "Type", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "NotStarted" }, new { value = 1, display = "InProgress" }, new { value = 2, display = "Completed" }, new { value = 3, display = "Failed" },}, },
                new { id = "keycurrentstep", label = "Key Step Atual", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "createdat", label = "Criado em", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "completedat", label = "Finalizado em", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "entitytype", label = "Entity Type", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "entityid", label = "Entity Id", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "nextexecutionat", label = "Proxima execucao", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "lockedat", label = "LockedAt", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "lockedby", label = "LockedBy", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "correlationid", label = "CorrelationId", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "type", label = "Type", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "NotStarted" }, new { value = 1, display = "InProgress" }, new { value = 2, display = "Completed" }, new { value = 3, display = "Failed" },}, },
                new { id = "keycurrentstep", label = "Key Step Atual", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "createdat", label = "Criado em", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "completedat", label = "Finalizado em", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "entitytype", label = "Entity Type", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "entityid", label = "Entity Id", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "nextexecutionat", label = "Proxima execucao", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "lockedat", label = "LockedAt", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "lockedby", label = "LockedBy", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "correlationid", label = "CorrelationId", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "type", label = "Type", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "status", label = "Status", type = "enum", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "NotStarted" }, new { value = 1, display = "InProgress" }, new { value = 2, display = "Completed" }, new { value = 3, display = "Failed" },}, },
            new { id = "keycurrentstep", label = "Key Step Atual", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "createdat", label = "Criado em", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "completedat", label = "Finalizado em", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "entitytype", label = "Entity Type", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "entityid", label = "Entity Id", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "nextexecutionat", label = "Proxima execucao", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "lockedat", label = "LockedAt", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "lockedby", label = "LockedBy", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
            create = "/ySaga/PostySaga",
            read = "/ySaga/ReadySaga",
            update = "/ySaga/PutySaga",
            delete = "/ySaga/DeleteySaga"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDataySagaStep", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "ySagaStep",
        entityDescription = "ySagaStep",
        source = new
        {
            kind = "table",
            name = "ySagaStep"
        },
        capabilities = new
        {
            create = true,
            update = true,
            delete = true
        },
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
                endpoint = "/ySagaStep/ReadySagaStep",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "sagaid", label = "Saga", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataySaga", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "stepkey", label = "Step Key", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "indexorder", label = "Index Order", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "correlationid", label = "CorrelationId", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "Created" }, new { value = 1, display = "Pending" }, new { value = 2, display = "InProgress" }, new { value = 3, display = "WaitingResponse" }, new { value = 4, display = "PendingApply" }, new { value = 5, display = "Completed" }, new { value = 6, display = "Failed" },}, },
                new { id = "executioncount", label = "Execuções", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "lastexecutionat", label = "Última Execução", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "completedat", label = "Finalizado em", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "errormessage", label = "Erro", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "payload", label = "Payload", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "retrycount", label = "Tentativas", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "sagaid", label = "Saga", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataySaga", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "stepkey", label = "Step Key", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "indexorder", label = "Index Order", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "correlationid", label = "CorrelationId", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "Created" }, new { value = 1, display = "Pending" }, new { value = 2, display = "InProgress" }, new { value = 3, display = "WaitingResponse" }, new { value = 4, display = "PendingApply" }, new { value = 5, display = "Completed" }, new { value = 6, display = "Failed" },}, },
                new { id = "executioncount", label = "Execuções", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "lastexecutionat", label = "Última Execução", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "completedat", label = "Finalizado em", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "errormessage", label = "Erro", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "payload", label = "Payload", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "retrycount", label = "Tentativas", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
                sagaid = "/ySagaStep/ySagaStepReadFKSagaId",
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "sagaid", label = "Saga", type = "int", required = false, displaygroup = "Geral", isFk = true, endPontGetMetadata = "/getMetaDataySaga", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "stepkey", label = "Step Key", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "indexorder", label = "Index Order", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "correlationid", label = "CorrelationId", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "status", label = "Status", type = "enum", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "Created" }, new { value = 1, display = "Pending" }, new { value = 2, display = "InProgress" }, new { value = 3, display = "WaitingResponse" }, new { value = 4, display = "PendingApply" }, new { value = 5, display = "Completed" }, new { value = 6, display = "Failed" },}, },
            new { id = "executioncount", label = "Execuções", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "lastexecutionat", label = "Última Execução", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "completedat", label = "Finalizado em", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "errormessage", label = "Erro", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "payload", label = "Payload", type = "memo", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "retrycount", label = "Tentativas", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
                 sagaid = "/ySagaStep/ySagaStepReadFKSagaId",
            create = "/ySagaStep/PostySagaStep",
            read = "/ySagaStep/ReadySagaStep",
            update = "/ySagaStep/PutySagaStep",
            delete = "/ySagaStep/DeleteySagaStep"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDatayOutbox", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "yOutbox",
        entityDescription = "yOutbox",
        source = new
        {
            kind = "table",
            name = "yOutbox"
        },
        capabilities = new
        {
            create = true,
            update = true,
            delete = true
        },
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
                endpoint = "/yOutbox/ReadyOutbox",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "type", label = "Tipo da Mensagem", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "payload", label = "Payload", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = Array.Empty<object>(),
            quickSearches = new[]
            {
                new { id = "ProximaPendente", label = "ProximaPendente", icon = "calendar-day", endpoint = "/yOutbox/ReadyOutboxProximaPendente" },
            },
            fkEndpoints = new
            {
                sagaid = "/yOutbox/yOutboxReadFKSagaId",
                sagastepid = "/yOutbox/yOutboxReadFKSagaStepId",
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "messageid", label = "Message Id", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "type", label = "Tipo da Mensagem", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "entitytype", label = "Entity Type", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "entityid", label = "Entity Id", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "correlationid", label = "Correlation Id", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "payload", label = "Payload", type = "memo", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "status", label = "Status", type = "enum", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "Pending" }, new { value = 1, display = "Sent" }, new { value = 2, display = "Failed" }, new { value = 9, display = "Processing" },}, },
            new { id = "transporttype", label = "Tipo de Transporte", type = "enum", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Queue" }, new { value = 2, display = "Http" }, new { value = 3, display = "Socket" },}, },
            new { id = "transportdata", label = "Dados do transporte", type = "memo", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "createdat", label = "Criado em", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "sentat", label = "Enviado em", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "retrycount", label = "Tentativas", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "lasterror", label = "Último Erro", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "processingat", label = "Processando em", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "nextattemptat", label = "Próxima tentativa", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "sagaid", label = "SagaId", type = "int", required = false, displaygroup = "Geral", isFk = true, endPontGetMetadata = "/getMetaDataySaga", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "sagastepid", label = "SagaStepId", type = "int", required = false, displaygroup = "Geral", isFk = true, endPontGetMetadata = "/getMetaDataySagaStep", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
                 sagaid = "/yOutbox/yOutboxReadFKSagaId",
                 sagastepid = "/yOutbox/yOutboxReadFKSagaStepId",
            create = "/yOutbox/PostyOutbox",
            read = "/yOutbox/ReadyOutbox",
            update = "/yOutbox/PutyOutbox",
            delete = "/yOutbox/DeleteyOutbox"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDatayInbox", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "yInbox",
        entityDescription = "yInbox",
        source = new
        {
            kind = "table",
            name = "yInbox"
        },
        capabilities = new
        {
            create = true,
            update = true,
            delete = true
        },
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
                endpoint = "/yInbox/ReadyInbox",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "messageid", label = "Message Id", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "type", label = "Tipo da Mensagem", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "entitytype", label = "Entity Type", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "entityid", label = "Entity Id", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "correlationid", label = "Correlation Id", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "payload", label = "Payload", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "Pending" }, new { value = 1, display = "Sent" }, new { value = 2, display = "Failed" }, new { value = 9, display = "Processing" },}, },
                new { id = "createdat", label = "Criado em", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "retrycount", label = "Tentativas", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "lasterror", label = "Último Erro", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "processingat", label = "Processando em", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "nextattemptat", label = "Próxima tentativa", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "sagaid", label = "SagaId", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataySaga", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "sagastepid", label = "SagaStepId", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataySagaStep", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "messageid", label = "Message Id", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "type", label = "Tipo da Mensagem", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "entitytype", label = "Entity Type", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "entityid", label = "Entity Id", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "correlationid", label = "Correlation Id", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "payload", label = "Payload", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "Pending" }, new { value = 1, display = "Sent" }, new { value = 2, display = "Failed" }, new { value = 9, display = "Processing" },}, },
                new { id = "createdat", label = "Criado em", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "retrycount", label = "Tentativas", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "lasterror", label = "Último Erro", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "processingat", label = "Processando em", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "nextattemptat", label = "Próxima tentativa", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "sagaid", label = "SagaId", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataySaga", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "sagastepid", label = "SagaStepId", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataySagaStep", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
                sagaid = "/yInbox/yInboxReadFKSagaId",
                sagastepid = "/yInbox/yInboxReadFKSagaStepId",
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "messageid", label = "Message Id", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "type", label = "Tipo da Mensagem", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "entitytype", label = "Entity Type", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "entityid", label = "Entity Id", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "correlationid", label = "Correlation Id", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "payload", label = "Payload", type = "memo", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "status", label = "Status", type = "enum", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "Pending" }, new { value = 1, display = "Sent" }, new { value = 2, display = "Failed" }, new { value = 9, display = "Processing" },}, },
            new { id = "createdat", label = "Criado em", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "retrycount", label = "Tentativas", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "lasterror", label = "Último Erro", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "processingat", label = "Processando em", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "nextattemptat", label = "Próxima tentativa", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "sagaid", label = "SagaId", type = "int", required = false, displaygroup = "Geral", isFk = true, endPontGetMetadata = "/getMetaDataySaga", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "sagastepid", label = "SagaStepId", type = "int", required = false, displaygroup = "Geral", isFk = true, endPontGetMetadata = "/getMetaDataySagaStep", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
                 sagaid = "/yInbox/yInboxReadFKSagaId",
                 sagastepid = "/yInbox/yInboxReadFKSagaStepId",
            create = "/yInbox/PostyInbox",
            read = "/yInbox/ReadyInbox",
            update = "/yInbox/PutyInbox",
            delete = "/yInbox/DeleteyInbox"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDatayTenant", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "yTenant",
        entityDescription = "yTenant",
        source = new
        {
            kind = "table",
            name = "yTenant"
        },
        capabilities = new
        {
            create = true,
            update = true,
            delete = true
        },
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
                endpoint = "/yTenant/ReadyTenant",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "cnpjcpf", label = "Cnpj/Cpf", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "nome", label = "Nome", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "userid", label = "User ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "cnpjcpf", label = "Cnpj/Cpf", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "nome", label = "Nome", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "userid", label = "User ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "cnpjcpf", label = "Cnpj/Cpf", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "nome", label = "Nome", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "userid", label = "User ID", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
            create = "/yTenant/PostyTenant",
            read = "/yTenant/ReadyTenant",
            update = "/yTenant/PutyTenant",
            delete = "/yTenant/DeleteyTenant"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDatayUser", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "yUser",
        entityDescription = "yUser",
        source = new
        {
            kind = "table",
            name = "yUser"
        },
        capabilities = new
        {
            create = true,
            update = true,
            delete = true
        },
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
                endpoint = "/yUser/ReadyUser",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "nome", label = "Nome Usuario", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "email", label = "Email", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "senha", label = "Senha", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "nome", label = "Nome Usuario", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "email", label = "Email", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "senha", label = "Senha", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "nome", label = "Nome Usuario", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "email", label = "Email", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "senha", label = "Senha", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
            create = "/yUser/PostyUser",
            read = "/yUser/ReadyUser",
            update = "/yUser/PutyUser",
            delete = "/yUser/DeleteyUser"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDatayConfigArcteture", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "yConfigArcteture",
        entityDescription = "yConfigArcteture",
        source = new
        {
            kind = "table",
            name = "yConfigArcteture"
        },
        capabilities = new
        {
            create = true,
            update = true,
            delete = true
        },
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
                endpoint = "/yConfigArcteture/ReadyConfigArcteture",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "audittrackeractived", label = "AuditTrackerActived", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "auditcrudactived", label = "AuditCRUDActived", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "audittrackeractived", label = "AuditTrackerActived", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "auditcrudactived", label = "AuditCRUDActived", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "audittrackeractived", label = "AuditTrackerActived", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "auditcrudactived", label = "AuditCRUDActived", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
            create = "/yConfigArcteture/PostyConfigArcteture",
            read = "/yConfigArcteture/ReadyConfigArcteture",
            update = "/yConfigArcteture/PutyConfigArcteture",
            delete = "/yConfigArcteture/DeleteyConfigArcteture"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDatayConfigNotification", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "yConfigNotification",
        entityDescription = "yConfigNotification",
        source = new
        {
            kind = "table",
            name = "yConfigNotification"
        },
        capabilities = new
        {
            create = true,
            update = true,
            delete = true
        },
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
                endpoint = "/yConfigNotification/ReadyConfigNotification",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "tenantid", label = "TenantID", type = "int", isFk = true, endPontGetMetadata = "/getMetaDatayTenant", fksDisplayFields = new string[]{ "nome" }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "emailsmtpclient", label = "EmailSmtpClient", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "emailport", label = "EmailPort", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "emailusername", label = "EmailUserName", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "emailpassword", label = "EmailPassword", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "tenantid", label = "TenantID", type = "int", isFk = true, endPontGetMetadata = "/getMetaDatayTenant", fksDisplayFields = new string[]{ "nome" }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "emailsmtpclient", label = "EmailSmtpClient", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "emailport", label = "EmailPort", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "emailusername", label = "EmailUserName", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "emailpassword", label = "EmailPassword", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
                tenantid = "/yConfigNotification/yConfigNotificationReadFKTenantID",
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "tenantid", label = "TenantID", type = "int", required = false, displaygroup = "Geral", isFk = true, endPontGetMetadata = "/getMetaDatayTenant", fksDisplayFields = new string[]{ "nome" }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "emailsmtpclient", label = "EmailSmtpClient", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "emailport", label = "EmailPort", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "emailusername", label = "EmailUserName", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "emailpassword", label = "EmailPassword", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
                 tenantid = "/yConfigNotification/yConfigNotificationReadFKTenantID",
            create = "/yConfigNotification/PostyConfigNotification",
            read = "/yConfigNotification/ReadyConfigNotification",
            update = "/yConfigNotification/PutyConfigNotification",
            delete = "/yConfigNotification/DeleteyConfigNotification"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDatayPerfil", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "yPerfil",
        entityDescription = "yPerfil",
        source = new
        {
            kind = "table",
            name = "yPerfil"
        },
        capabilities = new
        {
            create = true,
            update = true,
            delete = true
        },
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
                endpoint = "/yPerfil/ReadyPerfil",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "description", label = "Descrição", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "description", label = "Descrição", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "description", label = "Descrição", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
            create = "/yPerfil/PostyPerfil",
            read = "/yPerfil/ReadyPerfil",
            update = "/yPerfil/PutyPerfil",
            delete = "/yPerfil/DeleteyPerfil"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDatayModule", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "yModule",
        entityDescription = "yModule",
        source = new
        {
            kind = "table",
            name = "yModule"
        },
        capabilities = new
        {
            create = true,
            update = true,
            delete = true
        },
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
                endpoint = "/yModule/ReadyModule",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "description", label = "Descrição", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "description", label = "Descrição", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "description", label = "Descrição", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
            create = "/yModule/PostyModule",
            read = "/yModule/ReadyModule",
            update = "/yModule/PutyModule",
            delete = "/yModule/DeleteyModule"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDatayTenantModule", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "yTenantModule",
        entityDescription = "yTenantModule",
        source = new
        {
            kind = "table",
            name = "yTenantModule"
        },
        capabilities = new
        {
            create = true,
            update = true,
            delete = true
        },
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
                endpoint = "/yTenantModule/ReadyTenantModule",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "moduleid", label = "ID Modulo", type = "string", isFk = true, endPontGetMetadata = "/getMetaDatayModule", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "tenantid", label = "TenantID", type = "int", isFk = true, endPontGetMetadata = "/getMetaDatayTenant", fksDisplayFields = new string[]{ "nome" }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "validuntil", label = "Valido ate", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "moduleid", label = "ID Modulo", type = "string", isFk = true, endPontGetMetadata = "/getMetaDatayModule", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "tenantid", label = "TenantID", type = "int", isFk = true, endPontGetMetadata = "/getMetaDatayTenant", fksDisplayFields = new string[]{ "nome" }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "validuntil", label = "Valido ate", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
                moduleid = "/yTenantModule/yTenantModuleReadFKModuleId",
                tenantid = "/yTenantModule/yTenantModuleReadFKTenantID",
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "moduleid", label = "ID Modulo", type = "string", required = false, displaygroup = "Geral", isFk = true, endPontGetMetadata = "/getMetaDatayModule", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "tenantid", label = "TenantID", type = "int", required = false, displaygroup = "Geral", isFk = true, endPontGetMetadata = "/getMetaDatayTenant", fksDisplayFields = new string[]{ "nome" }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "validuntil", label = "Valido ate", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
                 moduleid = "/yTenantModule/yTenantModuleReadFKModuleId",
                 tenantid = "/yTenantModule/yTenantModuleReadFKTenantID",
            create = "/yTenantModule/PostyTenantModule",
            read = "/yTenantModule/ReadyTenantModule",
            update = "/yTenantModule/PutyTenantModule",
            delete = "/yTenantModule/DeleteyTenantModule"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDatayUserModule", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "yUserModule",
        entityDescription = "yUserModule",
        source = new
        {
            kind = "table",
            name = "yUserModule"
        },
        capabilities = new
        {
            create = true,
            update = true,
            delete = true
        },
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
                endpoint = "/yUserModule/ReadyUserModule",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "moduleid", label = "ID Modulo", type = "string", isFk = true, endPontGetMetadata = "/getMetaDatayModule", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "userid", label = "User ID", type = "int", isFk = true, endPontGetMetadata = "/getMetaDatayUser", fksDisplayFields = new string[]{ "nome" }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "validuntil", label = "Valido ate", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "moduleid", label = "ID Modulo", type = "string", isFk = true, endPontGetMetadata = "/getMetaDatayModule", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "userid", label = "User ID", type = "int", isFk = true, endPontGetMetadata = "/getMetaDatayUser", fksDisplayFields = new string[]{ "nome" }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "validuntil", label = "Valido ate", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
                moduleid = "/yUserModule/yUserModuleReadFKModuleId",
                userid = "/yUserModule/yUserModuleReadFKUserId",
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "moduleid", label = "ID Modulo", type = "string", required = false, displaygroup = "Geral", isFk = true, endPontGetMetadata = "/getMetaDatayModule", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "userid", label = "User ID", type = "int", required = false, displaygroup = "Geral", isFk = true, endPontGetMetadata = "/getMetaDatayUser", fksDisplayFields = new string[]{ "nome" }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "validuntil", label = "Valido ate", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
                 moduleid = "/yUserModule/yUserModuleReadFKModuleId",
                 userid = "/yUserModule/yUserModuleReadFKUserId",
            create = "/yUserModule/PostyUserModule",
            read = "/yUserModule/ReadyUserModule",
            update = "/yUserModule/PutyUserModule",
            delete = "/yUserModule/DeleteyUserModule"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDatayGrant", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "yGrant",
        entityDescription = "yGrant",
        source = new
        {
            kind = "table",
            name = "yGrant"
        },
        capabilities = new
        {
            create = true,
            update = true,
            delete = true
        },
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
                endpoint = "/yGrant/ReadyGrant",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "description", label = "Descrição", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "description", label = "Descrição", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "description", label = "Descrição", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
            create = "/yGrant/PostyGrant",
            read = "/yGrant/ReadyGrant",
            update = "/yGrant/PutyGrant",
            delete = "/yGrant/DeleteyGrant"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDatayPerfilGrant", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "yPerfilGrant",
        entityDescription = "yPerfilGrant",
        source = new
        {
            kind = "table",
            name = "yPerfilGrant"
        },
        capabilities = new
        {
            create = true,
            update = true,
            delete = true
        },
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
                endpoint = "/yPerfilGrant/ReadyPerfilGrant",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "perfilid", label = "ID Perfil", type = "int", isFk = true, endPontGetMetadata = "/getMetaDatayPerfil", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "grantid", label = "ID Permição", type = "string", isFk = true, endPontGetMetadata = "/getMetaDatayGrant", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "cangrant", label = "Permite acessar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "cancreate", label = "Permite Criar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "canread", label = "Permite Ler", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "canupdate", label = "Permite Atualizar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "candelete", label = "Permite Deletar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "validuntil", label = "Valido ate", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "perfilid", label = "ID Perfil", type = "int", isFk = true, endPontGetMetadata = "/getMetaDatayPerfil", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "grantid", label = "ID Permição", type = "string", isFk = true, endPontGetMetadata = "/getMetaDatayGrant", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "cangrant", label = "Permite acessar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "cancreate", label = "Permite Criar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "canread", label = "Permite Ler", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "canupdate", label = "Permite Atualizar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "candelete", label = "Permite Deletar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "validuntil", label = "Valido ate", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
                perfilid = "/yPerfilGrant/yPerfilGrantReadFKPerfilId",
                grantid = "/yPerfilGrant/yPerfilGrantReadFKGrantId",
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "perfilid", label = "ID Perfil", type = "int", required = false, displaygroup = "Geral", isFk = true, endPontGetMetadata = "/getMetaDatayPerfil", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "grantid", label = "ID Permição", type = "string", required = false, displaygroup = "Geral", isFk = true, endPontGetMetadata = "/getMetaDatayGrant", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "cangrant", label = "Permite acessar", type = "bool", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "cancreate", label = "Permite Criar", type = "bool", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "canread", label = "Permite Ler", type = "bool", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "canupdate", label = "Permite Atualizar", type = "bool", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "candelete", label = "Permite Deletar", type = "bool", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "validuntil", label = "Valido ate", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
                 perfilid = "/yPerfilGrant/yPerfilGrantReadFKPerfilId",
                 grantid = "/yPerfilGrant/yPerfilGrantReadFKGrantId",
            create = "/yPerfilGrant/PostyPerfilGrant",
            read = "/yPerfilGrant/ReadyPerfilGrant",
            update = "/yPerfilGrant/PutyPerfilGrant",
            delete = "/yPerfilGrant/DeleteyPerfilGrant"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDatayUserGrant", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "yUserGrant",
        entityDescription = "yUserGrant",
        source = new
        {
            kind = "table",
            name = "yUserGrant"
        },
        capabilities = new
        {
            create = true,
            update = true,
            delete = true
        },
        search = new[]{
            new {
                id = "Standard",
                description = "Standard",
                endpoint = "/yUserGrant/ReadyUserGrant",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "perfilid", label = "ID Perfil", type = "int", isFk = true, endPontGetMetadata = "/getMetaDatayPerfil", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "grantid", label = "ID Permição", type = "string", isFk = true, endPontGetMetadata = "/getMetaDatayGrant", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "cangrant", label = "Permite acessar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "cancreate", label = "Permite Criar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "canread", label = "Permite Ler", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "canupdate", label = "Permite Atualizar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "candelete", label = "Permite Deletar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "validuntil", label = "Valido ate", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "perfilid", label = "ID Perfil", type = "int", isFk = true, endPontGetMetadata = "/getMetaDatayPerfil", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "grantid", label = "ID Permição", type = "string", isFk = true, endPontGetMetadata = "/getMetaDatayGrant", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "cangrant", label = "Permite acessar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "cancreate", label = "Permite Criar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "canread", label = "Permite Ler", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "canupdate", label = "Permite Atualizar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "candelete", label = "Permite Deletar", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "validuntil", label = "Valido ate", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
                perfilid = "/yUserGrant/yUserGrantReadFKPerfilId",
                grantid = "/yUserGrant/yUserGrantReadFKGrantId",
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "perfilid", label = "ID Perfil", type = "int", required = false, displaygroup = "Geral", isFk = true, endPontGetMetadata = "/getMetaDatayPerfil", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "grantid", label = "ID Permição", type = "string", required = false, displaygroup = "Geral", isFk = true, endPontGetMetadata = "/getMetaDatayGrant", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "cangrant", label = "Permite acessar", type = "bool", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "cancreate", label = "Permite Criar", type = "bool", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "canread", label = "Permite Ler", type = "bool", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "canupdate", label = "Permite Atualizar", type = "bool", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "candelete", label = "Permite Deletar", type = "bool", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "validuntil", label = "Valido ate", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
                 perfilid = "/yUserGrant/yUserGrantReadFKPerfilId",
                 grantid = "/yUserGrant/yUserGrantReadFKGrantId",
            create = "/yUserGrant/PostyUserGrant",
            read = "/yUserGrant/ReadyUserGrant",
            update = "/yUserGrant/PutyUserGrant",
            delete = "/yUserGrant/DeleteyUserGrant"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
#region ServicesMethod
app.MapPost("/yapi/FileUpload/InfraStarSessionUploadUseCase", async ([FromServices] Command.Receivers.UseCase.StarSessionUploadHandler receiver, [FromBody] Command.UseCase.StarSessionUploadInputCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/FileUpload/InfraSendFileUseCase", async ([FromServices] Command.Receivers.UseCase.SendFileHandler receiver, [FromBody] Command.UseCase.SendFileInputCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/Y/ContascreateContaUseCase", async ([FromServices] Command.Receivers.UseCase.CreateContaHandler receiver, [FromBody] Command.UseCase.CreateContaInputCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
});


app.MapPost("/yapi/Y/ContasLoginUseCase", async ([FromServices] Command.Receivers.UseCase.LoginHandler receiver, [FromBody] Command.UseCase.LoginInputCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/Y/ContasRecoveryAccountUseCase", async ([FromServices] Command.Receivers.UseCase.RecoveryAccountHandler receiver, [FromBody] Command.UseCase.RecoveryAccountInputCommand command) =>
{
try
{
var result = receiver.Execute(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


#endregion
}
}
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureAPIEndpointsMigration