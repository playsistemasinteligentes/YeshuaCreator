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
using Microsoft.AspNetCore.Hosting;
using System.Security.Claims;
using System.IO;
using System.Xml.Linq;
using System.Text.RegularExpressions;
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

app.MapPost("/yapi/DocumentoFiscal/PostDocumentoFiscal", async ([FromServices] Command.Receivers.Write.InsertDocumentoFiscalReceiver receiver, [FromBody] Command.Write.DocumentoFiscalCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.DocumentoFiscalEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.DocumentoFiscalEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/DocumentoFiscalOriginario/PostDocumentoFiscalOriginario", async ([FromServices] Command.Receivers.Write.InsertDocumentoFiscalOriginarioReceiver receiver, [FromBody] Command.Write.DocumentoFiscalOriginarioCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.DocumentoFiscalOriginarioEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.DocumentoFiscalOriginarioEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/NFeProdutoSnapshot/PostNFeProdutoSnapshot", async ([FromServices] Command.Receivers.Write.InsertNFeProdutoSnapshotReceiver receiver, [FromBody] Command.Write.NFeProdutoSnapshotCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.NFeProdutoSnapshotEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.NFeProdutoSnapshotEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/CTeEntradaOficial/PostCTeEntradaOficial", async ([FromServices] Command.Receivers.Write.InsertCTeEntradaOficialReceiver receiver, [FromBody] Command.Write.CTeEntradaOficialCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.CTeEntradaOficialEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.CTeEntradaOficialEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/CTeRomaneioConsolidado/PostCTeRomaneioConsolidado", async ([FromServices] Command.Receivers.Write.InsertCTeRomaneioConsolidadoReceiver receiver, [FromBody] Command.Write.CTeRomaneioConsolidadoCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.CTeRomaneioConsolidadoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.CTeRomaneioConsolidadoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/CTeSolicitacaoFiscal/PostCTeSolicitacaoFiscal", async ([FromServices] Command.Receivers.Write.InsertCTeSolicitacaoFiscalReceiver receiver, [FromBody] Command.Write.CTeSolicitacaoFiscalCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.CTeSolicitacaoFiscalEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.CTeSolicitacaoFiscalEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/CTeDocumentoOriginario/PostCTeDocumentoOriginario", async ([FromServices] Command.Receivers.Write.InsertCTeDocumentoOriginarioReceiver receiver, [FromBody] Command.Write.CTeDocumentoOriginarioCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.CTeDocumentoOriginarioEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.CTeDocumentoOriginarioEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/CTeParticipanteSnapshot/PostCTeParticipanteSnapshot", async ([FromServices] Command.Receivers.Write.InsertCTeParticipanteSnapshotReceiver receiver, [FromBody] Command.Write.CTeParticipanteSnapshotCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.CTeParticipanteSnapshotEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.CTeParticipanteSnapshotEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/CTeTentativaEmissao/PostCTeTentativaEmissao", async ([FromServices] Command.Receivers.Write.InsertCTeTentativaEmissaoReceiver receiver, [FromBody] Command.Write.CTeTentativaEmissaoCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.CTeTentativaEmissaoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.CTeTentativaEmissaoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/CTeSaidaMDFe/PostCTeSaidaMDFe", async ([FromServices] Command.Receivers.Write.InsertCTeSaidaMDFeReceiver receiver, [FromBody] Command.Write.CTeSaidaMDFeCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.CTeSaidaMDFeEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.CTeSaidaMDFeEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/MDFe/PostMDFe", async ([FromServices] Command.Receivers.Write.InsertMDFeReceiver receiver, [FromBody] Command.Write.MDFeCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.MDFeEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.MDFeEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/MDFeSolicitacaoFiscal/PostMDFeSolicitacaoFiscal", async ([FromServices] Command.Receivers.Write.InsertMDFeSolicitacaoFiscalReceiver receiver, [FromBody] Command.Write.MDFeSolicitacaoFiscalCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.MDFeSolicitacaoFiscalEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.MDFeSolicitacaoFiscalEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/MDFeDocumentoOriginario/PostMDFeDocumentoOriginario", async ([FromServices] Command.Receivers.Write.InsertMDFeDocumentoOriginarioReceiver receiver, [FromBody] Command.Write.MDFeDocumentoOriginarioCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.MDFeDocumentoOriginarioEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.MDFeDocumentoOriginarioEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/MDFePercurso/PostMDFePercurso", async ([FromServices] Command.Receivers.Write.InsertMDFePercursoReceiver receiver, [FromBody] Command.Write.MDFePercursoCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.MDFePercursoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.MDFePercursoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/MDFeVeiculo/PostMDFeVeiculo", async ([FromServices] Command.Receivers.Write.InsertMDFeVeiculoReceiver receiver, [FromBody] Command.Write.MDFeVeiculoCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.MDFeVeiculoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.MDFeVeiculoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/MDFeCondutor/PostMDFeCondutor", async ([FromServices] Command.Receivers.Write.InsertMDFeCondutorReceiver receiver, [FromBody] Command.Write.MDFeCondutorCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.MDFeCondutorEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.MDFeCondutorEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/MDFeTentativaEmissao/PostMDFeTentativaEmissao", async ([FromServices] Command.Receivers.Write.InsertMDFeTentativaEmissaoReceiver receiver, [FromBody] Command.Write.MDFeTentativaEmissaoCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.MDFeTentativaEmissaoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.MDFeTentativaEmissaoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/MDFeEncerramento/PostMDFeEncerramento", async ([FromServices] Command.Receivers.Write.InsertMDFeEncerramentoReceiver receiver, [FromBody] Command.Write.MDFeEncerramentoCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.MDFeEncerramentoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.MDFeEncerramentoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/SefazEndpoint/PostSefazEndpoint", async ([FromServices] Command.Receivers.Write.InsertSefazEndpointReceiver receiver, [FromBody] Command.Write.SefazEndpointCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.SefazEndpointEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.SefazEndpointEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/CertificadoDigital/PostCertificadoDigital", async ([FromServices] Command.Receivers.Write.InsertCertificadoDigitalReceiver receiver, [FromBody] Command.Write.CertificadoDigitalCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.CertificadoDigitalEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.CertificadoDigitalEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yFileUpload/PostyFileUpload", async ([FromServices] Command.Receivers.Write.InsertyFileUploadReceiver receiver, [FromBody] Command.Write.yFileUploadCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yFileUploadEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yFileUploadEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/ySaga/PostySaga", async ([FromServices] Command.Receivers.Write.InsertySagaReceiver receiver, [FromBody] Command.Write.ySagaCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.ySagaEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ySagaEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/ySagaStep/PostySagaStep", async ([FromServices] Command.Receivers.Write.InsertySagaStepReceiver receiver, [FromBody] Command.Write.ySagaStepCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.ySagaStepEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ySagaStepEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yOutbox/PostyOutbox", async ([FromServices] Command.Receivers.Write.InsertyOutboxReceiver receiver, [FromBody] Command.Write.yOutboxCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yOutboxEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yOutboxEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yInbox/PostyInbox", async ([FromServices] Command.Receivers.Write.InsertyInboxReceiver receiver, [FromBody] Command.Write.yInboxCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yInboxEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yInboxEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yToken/PostyToken", async ([FromServices] Command.Receivers.Write.InsertyTokenReceiver receiver, [FromBody] Command.Write.yTokenCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yTokenEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yTokenEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yTenant/PostyTenant", async ([FromServices] Command.Receivers.Write.InsertyTenantReceiver receiver, [FromBody] Command.Write.yTenantCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yTenantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yTenantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yUser/PostyUser", async ([FromServices] Command.Receivers.Write.InsertyUserReceiver receiver, [FromBody] Command.Write.yUserCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yUserEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yUserEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yConfigArcteture/PostyConfigArcteture", async ([FromServices] Command.Receivers.Write.InsertyConfigArctetureReceiver receiver, [FromBody] Command.Write.yConfigArctetureCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yConfigArctetureEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yConfigArctetureEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yConfigNotification/PostyConfigNotification", async ([FromServices] Command.Receivers.Write.InsertyConfigNotificationReceiver receiver, [FromBody] Command.Write.yConfigNotificationCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yConfigNotificationEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yConfigNotificationEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yPerfil/PostyPerfil", async ([FromServices] Command.Receivers.Write.InsertyPerfilReceiver receiver, [FromBody] Command.Write.yPerfilCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yPerfilEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yPerfilEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yModule/PostyModule", async ([FromServices] Command.Receivers.Write.InsertyModuleReceiver receiver, [FromBody] Command.Write.yModuleCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yModuleEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yModuleEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yTenantModule/PostyTenantModule", async ([FromServices] Command.Receivers.Write.InsertyTenantModuleReceiver receiver, [FromBody] Command.Write.yTenantModuleCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yTenantModuleEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yTenantModuleEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yUserModule/PostyUserModule", async ([FromServices] Command.Receivers.Write.InsertyUserModuleReceiver receiver, [FromBody] Command.Write.yUserModuleCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yUserModuleEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yUserModuleEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yGrant/PostyGrant", async ([FromServices] Command.Receivers.Write.InsertyGrantReceiver receiver, [FromBody] Command.Write.yGrantCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yGrantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yGrantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yPerfilGrant/PostyPerfilGrant", async ([FromServices] Command.Receivers.Write.InsertyPerfilGrantReceiver receiver, [FromBody] Command.Write.yPerfilGrantCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yPerfilGrantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yPerfilGrantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yUserGrant/PostyUserGrant", async ([FromServices] Command.Receivers.Write.InsertyUserGrantReceiver receiver, [FromBody] Command.Write.yUserGrantCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yUserGrantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yUserGrantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/DocumentoFiscal/PutDocumentoFiscal", async ([FromServices] Command.Receivers.Write.UpdateDocumentoFiscalReceiver receiver, [FromBody] Command.Write.DocumentoFiscalCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.DocumentoFiscalEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.DocumentoFiscalEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/DocumentoFiscalOriginario/PutDocumentoFiscalOriginario", async ([FromServices] Command.Receivers.Write.UpdateDocumentoFiscalOriginarioReceiver receiver, [FromBody] Command.Write.DocumentoFiscalOriginarioCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.DocumentoFiscalOriginarioEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.DocumentoFiscalOriginarioEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/NFeProdutoSnapshot/PutNFeProdutoSnapshot", async ([FromServices] Command.Receivers.Write.UpdateNFeProdutoSnapshotReceiver receiver, [FromBody] Command.Write.NFeProdutoSnapshotCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.NFeProdutoSnapshotEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.NFeProdutoSnapshotEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/CTeEntradaOficial/PutCTeEntradaOficial", async ([FromServices] Command.Receivers.Write.UpdateCTeEntradaOficialReceiver receiver, [FromBody] Command.Write.CTeEntradaOficialCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.CTeEntradaOficialEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.CTeEntradaOficialEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/CTeRomaneioConsolidado/PutCTeRomaneioConsolidado", async ([FromServices] Command.Receivers.Write.UpdateCTeRomaneioConsolidadoReceiver receiver, [FromBody] Command.Write.CTeRomaneioConsolidadoCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.CTeRomaneioConsolidadoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.CTeRomaneioConsolidadoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/CTeSolicitacaoFiscal/PutCTeSolicitacaoFiscal", async ([FromServices] Command.Receivers.Write.UpdateCTeSolicitacaoFiscalReceiver receiver, [FromBody] Command.Write.CTeSolicitacaoFiscalCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.CTeSolicitacaoFiscalEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.CTeSolicitacaoFiscalEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/CTeDocumentoOriginario/PutCTeDocumentoOriginario", async ([FromServices] Command.Receivers.Write.UpdateCTeDocumentoOriginarioReceiver receiver, [FromBody] Command.Write.CTeDocumentoOriginarioCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.CTeDocumentoOriginarioEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.CTeDocumentoOriginarioEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/CTeParticipanteSnapshot/PutCTeParticipanteSnapshot", async ([FromServices] Command.Receivers.Write.UpdateCTeParticipanteSnapshotReceiver receiver, [FromBody] Command.Write.CTeParticipanteSnapshotCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.CTeParticipanteSnapshotEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.CTeParticipanteSnapshotEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/CTeTentativaEmissao/PutCTeTentativaEmissao", async ([FromServices] Command.Receivers.Write.UpdateCTeTentativaEmissaoReceiver receiver, [FromBody] Command.Write.CTeTentativaEmissaoCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.CTeTentativaEmissaoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.CTeTentativaEmissaoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/CTeSaidaMDFe/PutCTeSaidaMDFe", async ([FromServices] Command.Receivers.Write.UpdateCTeSaidaMDFeReceiver receiver, [FromBody] Command.Write.CTeSaidaMDFeCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.CTeSaidaMDFeEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.CTeSaidaMDFeEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/MDFe/PutMDFe", async ([FromServices] Command.Receivers.Write.UpdateMDFeReceiver receiver, [FromBody] Command.Write.MDFeCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.MDFeEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.MDFeEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/MDFeSolicitacaoFiscal/PutMDFeSolicitacaoFiscal", async ([FromServices] Command.Receivers.Write.UpdateMDFeSolicitacaoFiscalReceiver receiver, [FromBody] Command.Write.MDFeSolicitacaoFiscalCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.MDFeSolicitacaoFiscalEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.MDFeSolicitacaoFiscalEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/MDFeDocumentoOriginario/PutMDFeDocumentoOriginario", async ([FromServices] Command.Receivers.Write.UpdateMDFeDocumentoOriginarioReceiver receiver, [FromBody] Command.Write.MDFeDocumentoOriginarioCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.MDFeDocumentoOriginarioEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.MDFeDocumentoOriginarioEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/MDFePercurso/PutMDFePercurso", async ([FromServices] Command.Receivers.Write.UpdateMDFePercursoReceiver receiver, [FromBody] Command.Write.MDFePercursoCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.MDFePercursoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.MDFePercursoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/MDFeVeiculo/PutMDFeVeiculo", async ([FromServices] Command.Receivers.Write.UpdateMDFeVeiculoReceiver receiver, [FromBody] Command.Write.MDFeVeiculoCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.MDFeVeiculoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.MDFeVeiculoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/MDFeCondutor/PutMDFeCondutor", async ([FromServices] Command.Receivers.Write.UpdateMDFeCondutorReceiver receiver, [FromBody] Command.Write.MDFeCondutorCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.MDFeCondutorEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.MDFeCondutorEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/MDFeTentativaEmissao/PutMDFeTentativaEmissao", async ([FromServices] Command.Receivers.Write.UpdateMDFeTentativaEmissaoReceiver receiver, [FromBody] Command.Write.MDFeTentativaEmissaoCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.MDFeTentativaEmissaoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.MDFeTentativaEmissaoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/MDFeEncerramento/PutMDFeEncerramento", async ([FromServices] Command.Receivers.Write.UpdateMDFeEncerramentoReceiver receiver, [FromBody] Command.Write.MDFeEncerramentoCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.MDFeEncerramentoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.MDFeEncerramentoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/SefazEndpoint/PutSefazEndpoint", async ([FromServices] Command.Receivers.Write.UpdateSefazEndpointReceiver receiver, [FromBody] Command.Write.SefazEndpointCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.SefazEndpointEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.SefazEndpointEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/CertificadoDigital/PutCertificadoDigital", async ([FromServices] Command.Receivers.Write.UpdateCertificadoDigitalReceiver receiver, [FromBody] Command.Write.CertificadoDigitalCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.CertificadoDigitalEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.CertificadoDigitalEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/yFileUpload/PutyFileUpload", async ([FromServices] Command.Receivers.Write.UpdateyFileUploadReceiver receiver, [FromBody] Command.Write.yFileUploadCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yFileUploadEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yFileUploadEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/ySaga/PutySaga", async ([FromServices] Command.Receivers.Write.UpdateySagaReceiver receiver, [FromBody] Command.Write.ySagaCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.ySagaEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ySagaEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/ySagaStep/PutySagaStep", async ([FromServices] Command.Receivers.Write.UpdateySagaStepReceiver receiver, [FromBody] Command.Write.ySagaStepCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.ySagaStepEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ySagaStepEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/yOutbox/PutyOutbox", async ([FromServices] Command.Receivers.Write.UpdateyOutboxReceiver receiver, [FromBody] Command.Write.yOutboxCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yOutboxEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yOutboxEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/yInbox/PutyInbox", async ([FromServices] Command.Receivers.Write.UpdateyInboxReceiver receiver, [FromBody] Command.Write.yInboxCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yInboxEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yInboxEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/yToken/PutyToken", async ([FromServices] Command.Receivers.Write.UpdateyTokenReceiver receiver, [FromBody] Command.Write.yTokenCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yTokenEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yTokenEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/yTenant/PutyTenant", async ([FromServices] Command.Receivers.Write.UpdateyTenantReceiver receiver, [FromBody] Command.Write.yTenantCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yTenantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yTenantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/yUser/PutyUser", async ([FromServices] Command.Receivers.Write.UpdateyUserReceiver receiver, [FromBody] Command.Write.yUserCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yUserEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yUserEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/yConfigArcteture/PutyConfigArcteture", async ([FromServices] Command.Receivers.Write.UpdateyConfigArctetureReceiver receiver, [FromBody] Command.Write.yConfigArctetureCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yConfigArctetureEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yConfigArctetureEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/yConfigNotification/PutyConfigNotification", async ([FromServices] Command.Receivers.Write.UpdateyConfigNotificationReceiver receiver, [FromBody] Command.Write.yConfigNotificationCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yConfigNotificationEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yConfigNotificationEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/yPerfil/PutyPerfil", async ([FromServices] Command.Receivers.Write.UpdateyPerfilReceiver receiver, [FromBody] Command.Write.yPerfilCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yPerfilEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yPerfilEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/yModule/PutyModule", async ([FromServices] Command.Receivers.Write.UpdateyModuleReceiver receiver, [FromBody] Command.Write.yModuleCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yModuleEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yModuleEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/yTenantModule/PutyTenantModule", async ([FromServices] Command.Receivers.Write.UpdateyTenantModuleReceiver receiver, [FromBody] Command.Write.yTenantModuleCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yTenantModuleEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yTenantModuleEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/yUserModule/PutyUserModule", async ([FromServices] Command.Receivers.Write.UpdateyUserModuleReceiver receiver, [FromBody] Command.Write.yUserModuleCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yUserModuleEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yUserModuleEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/yGrant/PutyGrant", async ([FromServices] Command.Receivers.Write.UpdateyGrantReceiver receiver, [FromBody] Command.Write.yGrantCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yGrantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yGrantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/yPerfilGrant/PutyPerfilGrant", async ([FromServices] Command.Receivers.Write.UpdateyPerfilGrantReceiver receiver, [FromBody] Command.Write.yPerfilGrantCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yPerfilGrantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yPerfilGrantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/yUserGrant/PutyUserGrant", async ([FromServices] Command.Receivers.Write.UpdateyUserGrantReceiver receiver, [FromBody] Command.Write.yUserGrantCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yUserGrantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yUserGrantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/DocumentoFiscal/DeleteDocumentoFiscal", async ([FromServices] Command.Receivers.Write.DeleteDocumentoFiscalReceiver receiver, [FromBody] Command.Write.DocumentoFiscalCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.DocumentoFiscalEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.DocumentoFiscalEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/DocumentoFiscalOriginario/DeleteDocumentoFiscalOriginario", async ([FromServices] Command.Receivers.Write.DeleteDocumentoFiscalOriginarioReceiver receiver, [FromBody] Command.Write.DocumentoFiscalOriginarioCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.DocumentoFiscalOriginarioEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.DocumentoFiscalOriginarioEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/NFeProdutoSnapshot/DeleteNFeProdutoSnapshot", async ([FromServices] Command.Receivers.Write.DeleteNFeProdutoSnapshotReceiver receiver, [FromBody] Command.Write.NFeProdutoSnapshotCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.NFeProdutoSnapshotEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.NFeProdutoSnapshotEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/CTeEntradaOficial/DeleteCTeEntradaOficial", async ([FromServices] Command.Receivers.Write.DeleteCTeEntradaOficialReceiver receiver, [FromBody] Command.Write.CTeEntradaOficialCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.CTeEntradaOficialEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.CTeEntradaOficialEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/CTeRomaneioConsolidado/DeleteCTeRomaneioConsolidado", async ([FromServices] Command.Receivers.Write.DeleteCTeRomaneioConsolidadoReceiver receiver, [FromBody] Command.Write.CTeRomaneioConsolidadoCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.CTeRomaneioConsolidadoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.CTeRomaneioConsolidadoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/CTeSolicitacaoFiscal/DeleteCTeSolicitacaoFiscal", async ([FromServices] Command.Receivers.Write.DeleteCTeSolicitacaoFiscalReceiver receiver, [FromBody] Command.Write.CTeSolicitacaoFiscalCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.CTeSolicitacaoFiscalEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.CTeSolicitacaoFiscalEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/CTeDocumentoOriginario/DeleteCTeDocumentoOriginario", async ([FromServices] Command.Receivers.Write.DeleteCTeDocumentoOriginarioReceiver receiver, [FromBody] Command.Write.CTeDocumentoOriginarioCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.CTeDocumentoOriginarioEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.CTeDocumentoOriginarioEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/CTeParticipanteSnapshot/DeleteCTeParticipanteSnapshot", async ([FromServices] Command.Receivers.Write.DeleteCTeParticipanteSnapshotReceiver receiver, [FromBody] Command.Write.CTeParticipanteSnapshotCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.CTeParticipanteSnapshotEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.CTeParticipanteSnapshotEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/CTeTentativaEmissao/DeleteCTeTentativaEmissao", async ([FromServices] Command.Receivers.Write.DeleteCTeTentativaEmissaoReceiver receiver, [FromBody] Command.Write.CTeTentativaEmissaoCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.CTeTentativaEmissaoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.CTeTentativaEmissaoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/CTeSaidaMDFe/DeleteCTeSaidaMDFe", async ([FromServices] Command.Receivers.Write.DeleteCTeSaidaMDFeReceiver receiver, [FromBody] Command.Write.CTeSaidaMDFeCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.CTeSaidaMDFeEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.CTeSaidaMDFeEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/MDFe/DeleteMDFe", async ([FromServices] Command.Receivers.Write.DeleteMDFeReceiver receiver, [FromBody] Command.Write.MDFeCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.MDFeEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.MDFeEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/MDFeSolicitacaoFiscal/DeleteMDFeSolicitacaoFiscal", async ([FromServices] Command.Receivers.Write.DeleteMDFeSolicitacaoFiscalReceiver receiver, [FromBody] Command.Write.MDFeSolicitacaoFiscalCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.MDFeSolicitacaoFiscalEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.MDFeSolicitacaoFiscalEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/MDFeDocumentoOriginario/DeleteMDFeDocumentoOriginario", async ([FromServices] Command.Receivers.Write.DeleteMDFeDocumentoOriginarioReceiver receiver, [FromBody] Command.Write.MDFeDocumentoOriginarioCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.MDFeDocumentoOriginarioEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.MDFeDocumentoOriginarioEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/MDFePercurso/DeleteMDFePercurso", async ([FromServices] Command.Receivers.Write.DeleteMDFePercursoReceiver receiver, [FromBody] Command.Write.MDFePercursoCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.MDFePercursoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.MDFePercursoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/MDFeVeiculo/DeleteMDFeVeiculo", async ([FromServices] Command.Receivers.Write.DeleteMDFeVeiculoReceiver receiver, [FromBody] Command.Write.MDFeVeiculoCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.MDFeVeiculoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.MDFeVeiculoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/MDFeCondutor/DeleteMDFeCondutor", async ([FromServices] Command.Receivers.Write.DeleteMDFeCondutorReceiver receiver, [FromBody] Command.Write.MDFeCondutorCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.MDFeCondutorEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.MDFeCondutorEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/MDFeTentativaEmissao/DeleteMDFeTentativaEmissao", async ([FromServices] Command.Receivers.Write.DeleteMDFeTentativaEmissaoReceiver receiver, [FromBody] Command.Write.MDFeTentativaEmissaoCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.MDFeTentativaEmissaoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.MDFeTentativaEmissaoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/MDFeEncerramento/DeleteMDFeEncerramento", async ([FromServices] Command.Receivers.Write.DeleteMDFeEncerramentoReceiver receiver, [FromBody] Command.Write.MDFeEncerramentoCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.MDFeEncerramentoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.MDFeEncerramentoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/SefazEndpoint/DeleteSefazEndpoint", async ([FromServices] Command.Receivers.Write.DeleteSefazEndpointReceiver receiver, [FromBody] Command.Write.SefazEndpointCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.SefazEndpointEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.SefazEndpointEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/CertificadoDigital/DeleteCertificadoDigital", async ([FromServices] Command.Receivers.Write.DeleteCertificadoDigitalReceiver receiver, [FromBody] Command.Write.CertificadoDigitalCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.CertificadoDigitalEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.CertificadoDigitalEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/yFileUpload/DeleteyFileUpload", async ([FromServices] Command.Receivers.Write.DeleteyFileUploadReceiver receiver, [FromBody] Command.Write.yFileUploadCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yFileUploadEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yFileUploadEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/ySaga/DeleteySaga", async ([FromServices] Command.Receivers.Write.DeleteySagaReceiver receiver, [FromBody] Command.Write.ySagaCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.ySagaEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ySagaEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/ySagaStep/DeleteySagaStep", async ([FromServices] Command.Receivers.Write.DeleteySagaStepReceiver receiver, [FromBody] Command.Write.ySagaStepCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.ySagaStepEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ySagaStepEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/yOutbox/DeleteyOutbox", async ([FromServices] Command.Receivers.Write.DeleteyOutboxReceiver receiver, [FromBody] Command.Write.yOutboxCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yOutboxEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yOutboxEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/yInbox/DeleteyInbox", async ([FromServices] Command.Receivers.Write.DeleteyInboxReceiver receiver, [FromBody] Command.Write.yInboxCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yInboxEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yInboxEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/yToken/DeleteyToken", async ([FromServices] Command.Receivers.Write.DeleteyTokenReceiver receiver, [FromBody] Command.Write.yTokenCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yTokenEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yTokenEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/yTenant/DeleteyTenant", async ([FromServices] Command.Receivers.Write.DeleteyTenantReceiver receiver, [FromBody] Command.Write.yTenantCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yTenantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yTenantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/yUser/DeleteyUser", async ([FromServices] Command.Receivers.Write.DeleteyUserReceiver receiver, [FromBody] Command.Write.yUserCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yUserEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yUserEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/yConfigArcteture/DeleteyConfigArcteture", async ([FromServices] Command.Receivers.Write.DeleteyConfigArctetureReceiver receiver, [FromBody] Command.Write.yConfigArctetureCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yConfigArctetureEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yConfigArctetureEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/yConfigNotification/DeleteyConfigNotification", async ([FromServices] Command.Receivers.Write.DeleteyConfigNotificationReceiver receiver, [FromBody] Command.Write.yConfigNotificationCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yConfigNotificationEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yConfigNotificationEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/yPerfil/DeleteyPerfil", async ([FromServices] Command.Receivers.Write.DeleteyPerfilReceiver receiver, [FromBody] Command.Write.yPerfilCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yPerfilEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yPerfilEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/yModule/DeleteyModule", async ([FromServices] Command.Receivers.Write.DeleteyModuleReceiver receiver, [FromBody] Command.Write.yModuleCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yModuleEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yModuleEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/yTenantModule/DeleteyTenantModule", async ([FromServices] Command.Receivers.Write.DeleteyTenantModuleReceiver receiver, [FromBody] Command.Write.yTenantModuleCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yTenantModuleEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yTenantModuleEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/yUserModule/DeleteyUserModule", async ([FromServices] Command.Receivers.Write.DeleteyUserModuleReceiver receiver, [FromBody] Command.Write.yUserModuleCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yUserModuleEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yUserModuleEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/yGrant/DeleteyGrant", async ([FromServices] Command.Receivers.Write.DeleteyGrantReceiver receiver, [FromBody] Command.Write.yGrantCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yGrantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yGrantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/yPerfilGrant/DeleteyPerfilGrant", async ([FromServices] Command.Receivers.Write.DeleteyPerfilGrantReceiver receiver, [FromBody] Command.Write.yPerfilGrantCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yPerfilGrantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yPerfilGrantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/yUserGrant/DeleteyUserGrant", async ([FromServices] Command.Receivers.Write.DeleteyUserGrantReceiver receiver, [FromBody] Command.Write.yUserGrantCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
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
                                endpoint = string.IsNullOrWhiteSpace(menu.Endpoint) ? $"/getMetaData{menu.Title}" : menu.Endpoint,
                                type = string.IsNullOrWhiteSpace(menu.Type) ? "crud" : menu.Type,
                                page = menu.Page,
                                scope = menu.Scope,
                                children = menu.SubMenus.Select(subMenu => new
                                {
                                    description = subMenu.Title,
                                    endpoint = string.IsNullOrWhiteSpace(subMenu.Endpoint) ? $"/getMetaData{subMenu.Title}" : subMenu.Endpoint,
                                    type = string.IsNullOrWhiteSpace(subMenu.Type) ? "crud" : subMenu.Type,
                                    page = subMenu.Page,
                                    scope = subMenu.Scope
                                }).ToList()
                            }).ToList()
                        }).ToList();

                        return Results.Ok(result);
                    }).RequireAuthorization();
            
app.MapPost("/yapi/DocumentoFiscal/ReadDocumentoFiscal", async ([FromServices] Command.Receivers.Read.DocumentoFiscalReadReceiver receiver, [FromBody] Command.Read.DocumentoFiscalReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.DocumentoFiscalEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.DocumentoFiscalEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/DocumentoFiscalOriginario/ReadDocumentoFiscalOriginario", async ([FromServices] Command.Receivers.Read.DocumentoFiscalOriginarioReadReceiver receiver, [FromBody] Command.Read.DocumentoFiscalOriginarioReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.DocumentoFiscalOriginarioEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.DocumentoFiscalOriginarioEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/NFeProdutoSnapshot/ReadNFeProdutoSnapshot", async ([FromServices] Command.Receivers.Read.NFeProdutoSnapshotReadReceiver receiver, [FromBody] Command.Read.NFeProdutoSnapshotReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.NFeProdutoSnapshotEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.NFeProdutoSnapshotEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/CTeEntradaOficial/ReadCTeEntradaOficial", async ([FromServices] Command.Receivers.Read.CTeEntradaOficialReadReceiver receiver, [FromBody] Command.Read.CTeEntradaOficialReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.CTeEntradaOficialEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.CTeEntradaOficialEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/CTeRomaneioConsolidado/ReadCTeRomaneioConsolidado", async ([FromServices] Command.Receivers.Read.CTeRomaneioConsolidadoReadReceiver receiver, [FromBody] Command.Read.CTeRomaneioConsolidadoReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.CTeRomaneioConsolidadoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.CTeRomaneioConsolidadoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/CTeSolicitacaoFiscal/ReadCTeSolicitacaoFiscal", async ([FromServices] Command.Receivers.Read.CTeSolicitacaoFiscalReadReceiver receiver, [FromBody] Command.Read.CTeSolicitacaoFiscalReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.CTeSolicitacaoFiscalEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.CTeSolicitacaoFiscalEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/CTeDocumentoOriginario/ReadCTeDocumentoOriginario", async ([FromServices] Command.Receivers.Read.CTeDocumentoOriginarioReadReceiver receiver, [FromBody] Command.Read.CTeDocumentoOriginarioReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.CTeDocumentoOriginarioEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.CTeDocumentoOriginarioEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/CTeParticipanteSnapshot/ReadCTeParticipanteSnapshot", async ([FromServices] Command.Receivers.Read.CTeParticipanteSnapshotReadReceiver receiver, [FromBody] Command.Read.CTeParticipanteSnapshotReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.CTeParticipanteSnapshotEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.CTeParticipanteSnapshotEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/CTeTentativaEmissao/ReadCTeTentativaEmissao", async ([FromServices] Command.Receivers.Read.CTeTentativaEmissaoReadReceiver receiver, [FromBody] Command.Read.CTeTentativaEmissaoReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.CTeTentativaEmissaoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.CTeTentativaEmissaoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/CTeSaidaMDFe/ReadCTeSaidaMDFe", async ([FromServices] Command.Receivers.Read.CTeSaidaMDFeReadReceiver receiver, [FromBody] Command.Read.CTeSaidaMDFeReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.CTeSaidaMDFeEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.CTeSaidaMDFeEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/MDFe/ReadMDFe", async ([FromServices] Command.Receivers.Read.MDFeReadReceiver receiver, [FromBody] Command.Read.MDFeReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.MDFeEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.MDFeEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/MDFeSolicitacaoFiscal/ReadMDFeSolicitacaoFiscal", async ([FromServices] Command.Receivers.Read.MDFeSolicitacaoFiscalReadReceiver receiver, [FromBody] Command.Read.MDFeSolicitacaoFiscalReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.MDFeSolicitacaoFiscalEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.MDFeSolicitacaoFiscalEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/MDFeDocumentoOriginario/ReadMDFeDocumentoOriginario", async ([FromServices] Command.Receivers.Read.MDFeDocumentoOriginarioReadReceiver receiver, [FromBody] Command.Read.MDFeDocumentoOriginarioReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.MDFeDocumentoOriginarioEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.MDFeDocumentoOriginarioEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/MDFePercurso/ReadMDFePercurso", async ([FromServices] Command.Receivers.Read.MDFePercursoReadReceiver receiver, [FromBody] Command.Read.MDFePercursoReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.MDFePercursoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.MDFePercursoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/MDFeVeiculo/ReadMDFeVeiculo", async ([FromServices] Command.Receivers.Read.MDFeVeiculoReadReceiver receiver, [FromBody] Command.Read.MDFeVeiculoReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.MDFeVeiculoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.MDFeVeiculoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/MDFeCondutor/ReadMDFeCondutor", async ([FromServices] Command.Receivers.Read.MDFeCondutorReadReceiver receiver, [FromBody] Command.Read.MDFeCondutorReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.MDFeCondutorEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.MDFeCondutorEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/MDFeTentativaEmissao/ReadMDFeTentativaEmissao", async ([FromServices] Command.Receivers.Read.MDFeTentativaEmissaoReadReceiver receiver, [FromBody] Command.Read.MDFeTentativaEmissaoReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.MDFeTentativaEmissaoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.MDFeTentativaEmissaoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/MDFeEncerramento/ReadMDFeEncerramento", async ([FromServices] Command.Receivers.Read.MDFeEncerramentoReadReceiver receiver, [FromBody] Command.Read.MDFeEncerramentoReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.MDFeEncerramentoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.MDFeEncerramentoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/SefazEndpoint/ReadSefazEndpoint", async ([FromServices] Command.Receivers.Read.SefazEndpointReadReceiver receiver, [FromBody] Command.Read.SefazEndpointReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.SefazEndpointEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.SefazEndpointEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/CertificadoDigital/ReadCertificadoDigital", async ([FromServices] Command.Receivers.Read.CertificadoDigitalReadReceiver receiver, [FromBody] Command.Read.CertificadoDigitalReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.CertificadoDigitalEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.CertificadoDigitalEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yFileUpload/ReadyFileUpload", async ([FromServices] Command.Receivers.Read.yFileUploadReadReceiver receiver, [FromBody] Command.Read.yFileUploadReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yFileUploadEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yFileUploadEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/ySaga/ReadySaga", async ([FromServices] Command.Receivers.Read.ySagaReadReceiver receiver, [FromBody] Command.Read.ySagaReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.ySagaEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ySagaEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/ySagaStep/ReadySagaStep", async ([FromServices] Command.Receivers.Read.ySagaStepReadReceiver receiver, [FromBody] Command.Read.ySagaStepReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.ySagaStepEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.ySagaStepEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yOutbox/ReadyOutbox", async ([FromServices] Command.Receivers.Read.yOutboxReadReceiver receiver, [FromBody] Command.Read.yOutboxReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yOutboxEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yOutboxEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yInbox/ReadyInbox", async ([FromServices] Command.Receivers.Read.yInboxReadReceiver receiver, [FromBody] Command.Read.yInboxReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yInboxEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yInboxEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yToken/ReadyToken", async ([FromServices] Command.Receivers.Read.yTokenReadReceiver receiver, [FromBody] Command.Read.yTokenReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yTokenEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yTokenEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yTenant/ReadyTenant", async ([FromServices] Command.Receivers.Read.yTenantReadReceiver receiver, [FromBody] Command.Read.yTenantReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yTenantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yTenantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yUser/ReadyUser", async ([FromServices] Command.Receivers.Read.yUserReadReceiver receiver, [FromBody] Command.Read.yUserReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yUserEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yUserEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yConfigArcteture/ReadyConfigArcteture", async ([FromServices] Command.Receivers.Read.yConfigArctetureReadReceiver receiver, [FromBody] Command.Read.yConfigArctetureReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yConfigArctetureEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yConfigArctetureEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yConfigNotification/ReadyConfigNotification", async ([FromServices] Command.Receivers.Read.yConfigNotificationReadReceiver receiver, [FromBody] Command.Read.yConfigNotificationReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yConfigNotificationEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yConfigNotificationEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yPerfil/ReadyPerfil", async ([FromServices] Command.Receivers.Read.yPerfilReadReceiver receiver, [FromBody] Command.Read.yPerfilReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yPerfilEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yPerfilEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yModule/ReadyModule", async ([FromServices] Command.Receivers.Read.yModuleReadReceiver receiver, [FromBody] Command.Read.yModuleReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yModuleEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yModuleEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yTenantModule/ReadyTenantModule", async ([FromServices] Command.Receivers.Read.yTenantModuleReadReceiver receiver, [FromBody] Command.Read.yTenantModuleReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yTenantModuleEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yTenantModuleEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yUserModule/ReadyUserModule", async ([FromServices] Command.Receivers.Read.yUserModuleReadReceiver receiver, [FromBody] Command.Read.yUserModuleReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yUserModuleEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yUserModuleEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yGrant/ReadyGrant", async ([FromServices] Command.Receivers.Read.yGrantReadReceiver receiver, [FromBody] Command.Read.yGrantReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yGrantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yGrantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yPerfilGrant/ReadyPerfilGrant", async ([FromServices] Command.Receivers.Read.yPerfilGrantReadReceiver receiver, [FromBody] Command.Read.yPerfilGrantReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yPerfilGrantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yPerfilGrantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yUserGrant/ReadyUserGrant", async ([FromServices] Command.Receivers.Read.yUserGrantReadReceiver receiver, [FromBody] Command.Read.yUserGrantReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yUserGrantEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yUserGrantEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/yOutbox/ReadyOutboxProximaPendente", async ([FromServices] Command.Receivers.Read.yOutboxReadQueryProximaPendenteReceiver receiver, [FromBody] Command.Read.yOutboxProximaPendenteCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yOutboxEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yOutboxEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/DocumentoFiscal/DocumentoFiscalReadFKTenantID", async ([FromServices] Command.Receivers.Read.DocumentoFiscalReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/DocumentoFiscal/DocumentoFiscalReadFKUserId", async ([FromServices] Command.Receivers.Read.DocumentoFiscalReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/DocumentoFiscalOriginario/DocumentoFiscalOriginarioReadFKDocumentoFiscalId", async ([FromServices] Command.Receivers.Read.DocumentoFiscalOriginarioReadFKDocumentoFiscalIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/DocumentoFiscalOriginario/DocumentoFiscalOriginarioReadFKTenantID", async ([FromServices] Command.Receivers.Read.DocumentoFiscalOriginarioReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/DocumentoFiscalOriginario/DocumentoFiscalOriginarioReadFKUserId", async ([FromServices] Command.Receivers.Read.DocumentoFiscalOriginarioReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/NFeProdutoSnapshot/NFeProdutoSnapshotReadFKDocumentoFiscalOriginarioId", async ([FromServices] Command.Receivers.Read.NFeProdutoSnapshotReadFKDocumentoFiscalOriginarioIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/NFeProdutoSnapshot/NFeProdutoSnapshotReadFKTenantID", async ([FromServices] Command.Receivers.Read.NFeProdutoSnapshotReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/NFeProdutoSnapshot/NFeProdutoSnapshotReadFKUserId", async ([FromServices] Command.Receivers.Read.NFeProdutoSnapshotReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/CTeEntradaOficial/CTeEntradaOficialReadFKTenantID", async ([FromServices] Command.Receivers.Read.CTeEntradaOficialReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/CTeEntradaOficial/CTeEntradaOficialReadFKUserId", async ([FromServices] Command.Receivers.Read.CTeEntradaOficialReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/CTeRomaneioConsolidado/CTeRomaneioConsolidadoReadFKEntradaOficialId", async ([FromServices] Command.Receivers.Read.CTeRomaneioConsolidadoReadFKEntradaOficialIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/CTeRomaneioConsolidado/CTeRomaneioConsolidadoReadFKTenantID", async ([FromServices] Command.Receivers.Read.CTeRomaneioConsolidadoReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/CTeRomaneioConsolidado/CTeRomaneioConsolidadoReadFKUserId", async ([FromServices] Command.Receivers.Read.CTeRomaneioConsolidadoReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/CTeSolicitacaoFiscal/CTeSolicitacaoFiscalReadFKEntradaOficialId", async ([FromServices] Command.Receivers.Read.CTeSolicitacaoFiscalReadFKEntradaOficialIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/CTeSolicitacaoFiscal/CTeSolicitacaoFiscalReadFKRomaneioConsolidadoId", async ([FromServices] Command.Receivers.Read.CTeSolicitacaoFiscalReadFKRomaneioConsolidadoIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/CTeSolicitacaoFiscal/CTeSolicitacaoFiscalReadFKTenantID", async ([FromServices] Command.Receivers.Read.CTeSolicitacaoFiscalReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/CTeSolicitacaoFiscal/CTeSolicitacaoFiscalReadFKUserId", async ([FromServices] Command.Receivers.Read.CTeSolicitacaoFiscalReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/CTeDocumentoOriginario/CTeDocumentoOriginarioReadFKCTeSolicitacaoFiscalId", async ([FromServices] Command.Receivers.Read.CTeDocumentoOriginarioReadFKCTeSolicitacaoFiscalIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/CTeDocumentoOriginario/CTeDocumentoOriginarioReadFKDocumentoFiscalOriginarioId", async ([FromServices] Command.Receivers.Read.CTeDocumentoOriginarioReadFKDocumentoFiscalOriginarioIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/CTeDocumentoOriginario/CTeDocumentoOriginarioReadFKTenantID", async ([FromServices] Command.Receivers.Read.CTeDocumentoOriginarioReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/CTeDocumentoOriginario/CTeDocumentoOriginarioReadFKUserId", async ([FromServices] Command.Receivers.Read.CTeDocumentoOriginarioReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/CTeParticipanteSnapshot/CTeParticipanteSnapshotReadFKCTeSolicitacaoFiscalId", async ([FromServices] Command.Receivers.Read.CTeParticipanteSnapshotReadFKCTeSolicitacaoFiscalIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/CTeParticipanteSnapshot/CTeParticipanteSnapshotReadFKTenantID", async ([FromServices] Command.Receivers.Read.CTeParticipanteSnapshotReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/CTeParticipanteSnapshot/CTeParticipanteSnapshotReadFKUserId", async ([FromServices] Command.Receivers.Read.CTeParticipanteSnapshotReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/CTeTentativaEmissao/CTeTentativaEmissaoReadFKCTeSolicitacaoFiscalId", async ([FromServices] Command.Receivers.Read.CTeTentativaEmissaoReadFKCTeSolicitacaoFiscalIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/CTeTentativaEmissao/CTeTentativaEmissaoReadFKTenantID", async ([FromServices] Command.Receivers.Read.CTeTentativaEmissaoReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/CTeTentativaEmissao/CTeTentativaEmissaoReadFKUserId", async ([FromServices] Command.Receivers.Read.CTeTentativaEmissaoReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/CTeSaidaMDFe/CTeSaidaMDFeReadFKCTeTentativaEmissaoId", async ([FromServices] Command.Receivers.Read.CTeSaidaMDFeReadFKCTeTentativaEmissaoIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/CTeSaidaMDFe/CTeSaidaMDFeReadFKTenantID", async ([FromServices] Command.Receivers.Read.CTeSaidaMDFeReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/CTeSaidaMDFe/CTeSaidaMDFeReadFKUserId", async ([FromServices] Command.Receivers.Read.CTeSaidaMDFeReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/MDFe/MDFeReadFKTenantID", async ([FromServices] Command.Receivers.Read.MDFeReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/MDFe/MDFeReadFKUserId", async ([FromServices] Command.Receivers.Read.MDFeReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/MDFeSolicitacaoFiscal/MDFeSolicitacaoFiscalReadFKTenantID", async ([FromServices] Command.Receivers.Read.MDFeSolicitacaoFiscalReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/MDFeSolicitacaoFiscal/MDFeSolicitacaoFiscalReadFKUserId", async ([FromServices] Command.Receivers.Read.MDFeSolicitacaoFiscalReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/MDFeDocumentoOriginario/MDFeDocumentoOriginarioReadFKMDFeSolicitacaoFiscalId", async ([FromServices] Command.Receivers.Read.MDFeDocumentoOriginarioReadFKMDFeSolicitacaoFiscalIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/MDFeDocumentoOriginario/MDFeDocumentoOriginarioReadFKDocumentoFiscalOriginarioId", async ([FromServices] Command.Receivers.Read.MDFeDocumentoOriginarioReadFKDocumentoFiscalOriginarioIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/MDFeDocumentoOriginario/MDFeDocumentoOriginarioReadFKTenantID", async ([FromServices] Command.Receivers.Read.MDFeDocumentoOriginarioReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/MDFeDocumentoOriginario/MDFeDocumentoOriginarioReadFKUserId", async ([FromServices] Command.Receivers.Read.MDFeDocumentoOriginarioReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/MDFePercurso/MDFePercursoReadFKMDFeSolicitacaoFiscalId", async ([FromServices] Command.Receivers.Read.MDFePercursoReadFKMDFeSolicitacaoFiscalIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/MDFePercurso/MDFePercursoReadFKTenantID", async ([FromServices] Command.Receivers.Read.MDFePercursoReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/MDFePercurso/MDFePercursoReadFKUserId", async ([FromServices] Command.Receivers.Read.MDFePercursoReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/MDFeVeiculo/MDFeVeiculoReadFKMDFeSolicitacaoFiscalId", async ([FromServices] Command.Receivers.Read.MDFeVeiculoReadFKMDFeSolicitacaoFiscalIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/MDFeVeiculo/MDFeVeiculoReadFKTenantID", async ([FromServices] Command.Receivers.Read.MDFeVeiculoReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/MDFeVeiculo/MDFeVeiculoReadFKUserId", async ([FromServices] Command.Receivers.Read.MDFeVeiculoReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/MDFeCondutor/MDFeCondutorReadFKMDFeSolicitacaoFiscalId", async ([FromServices] Command.Receivers.Read.MDFeCondutorReadFKMDFeSolicitacaoFiscalIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/MDFeCondutor/MDFeCondutorReadFKTenantID", async ([FromServices] Command.Receivers.Read.MDFeCondutorReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/MDFeCondutor/MDFeCondutorReadFKUserId", async ([FromServices] Command.Receivers.Read.MDFeCondutorReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/MDFeTentativaEmissao/MDFeTentativaEmissaoReadFKMDFeSolicitacaoFiscalId", async ([FromServices] Command.Receivers.Read.MDFeTentativaEmissaoReadFKMDFeSolicitacaoFiscalIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/MDFeTentativaEmissao/MDFeTentativaEmissaoReadFKTenantID", async ([FromServices] Command.Receivers.Read.MDFeTentativaEmissaoReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/MDFeTentativaEmissao/MDFeTentativaEmissaoReadFKUserId", async ([FromServices] Command.Receivers.Read.MDFeTentativaEmissaoReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/MDFeEncerramento/MDFeEncerramentoReadFKMDFeId", async ([FromServices] Command.Receivers.Read.MDFeEncerramentoReadFKMDFeIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/MDFeEncerramento/MDFeEncerramentoReadFKTenantID", async ([FromServices] Command.Receivers.Read.MDFeEncerramentoReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/MDFeEncerramento/MDFeEncerramentoReadFKUserId", async ([FromServices] Command.Receivers.Read.MDFeEncerramentoReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/SefazEndpoint/SefazEndpointReadFKTenantID", async ([FromServices] Command.Receivers.Read.SefazEndpointReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/SefazEndpoint/SefazEndpointReadFKUserId", async ([FromServices] Command.Receivers.Read.SefazEndpointReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/CertificadoDigital/CertificadoDigitalReadFKTenantID", async ([FromServices] Command.Receivers.Read.CertificadoDigitalReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/CertificadoDigital/CertificadoDigitalReadFKUserId", async ([FromServices] Command.Receivers.Read.CertificadoDigitalReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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
var result = await receiver.ExecuteAsync(command);
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
var result = await receiver.ExecuteAsync(command);
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
var result = await receiver.ExecuteAsync(command);
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
var result = await receiver.ExecuteAsync(command);
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
var result = await receiver.ExecuteAsync(command);
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
var result = await receiver.ExecuteAsync(command);
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
var result = await receiver.ExecuteAsync(command);
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
var result = await receiver.ExecuteAsync(command);
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
var result = await receiver.ExecuteAsync(command);
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
var result = await receiver.ExecuteAsync(command);
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
var result = await receiver.ExecuteAsync(command);
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
var result = await receiver.ExecuteAsync(command);
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
var result = await receiver.ExecuteAsync(command);
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
var result = await receiver.ExecuteAsync(command);
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
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/yToken/yTokenReadFKTenantID", async ([FromServices] Command.Receivers.Read.yTokenReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/yToken/yTokenReadFKUserId", async ([FromServices] Command.Receivers.Read.yTokenReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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
var result = await receiver.ExecuteAsync(command);
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
var result = await receiver.ExecuteAsync(command);
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
var result = await receiver.ExecuteAsync(command);
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
var result = await receiver.ExecuteAsync(command);
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
var result = await receiver.ExecuteAsync(command);
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
var result = await receiver.ExecuteAsync(command);
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
var result = await receiver.ExecuteAsync(command);
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
var result = await receiver.ExecuteAsync(command);
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
var result = await receiver.ExecuteAsync(command);
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
var result = await receiver.ExecuteAsync(command);
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
var result = await receiver.ExecuteAsync(command);
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
var result = await receiver.ExecuteAsync(command);
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
var result = await receiver.ExecuteAsync(command);
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
var result = await receiver.ExecuteAsync(command);
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
var result = await receiver.ExecuteAsync(command);
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
var result = await receiver.ExecuteAsync(command);
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
var result = await receiver.ExecuteAsync(command);
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
var result = await receiver.ExecuteAsync(command);
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
var result = await receiver.ExecuteAsync(command);
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
var result = await receiver.ExecuteAsync(command);
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
var result = await receiver.ExecuteAsync(command);
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
var result = await receiver.ExecuteAsync(command);
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
var result = await receiver.ExecuteAsync(command);
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


app.MapGet("/yapi/getMetaDataDocumentoFiscal", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "DocumentoFiscal",
        entityDescription = "Documento Fiscal",
        source = new
        {
            kind = "table",
            name = "DocumentoFiscal"
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
                endpoint = "/DocumentoFiscal/ReadDocumentoFiscal",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "correlationid", label = "CorrelationId", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "produtofiscal", label = "Produto Fiscal", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 55, display = "NFe" }, new { value = 57, display = "CTe" }, new { value = 58, display = "MDFe" },}, },
                new { id = "chaveacesso", label = "Chave de Acesso", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "serie", label = "Serie", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "numero", label = "Numero", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "ambiente", label = "Ambiente", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Producao" }, new { value = 2, display = "Homologacao" },}, },
                new { id = "ufemitente", label = "UF Emitente", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "emitentedocumento", label = "Emitente Documento", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "destinatariodocumento", label = "Destinatario Documento", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "xmlstoragekey", label = "XML", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "xmlhash", label = "Hash XML", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "protocoloautorizacao", label = "Protocolo", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "codigoretorno", label = "cStat", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "mensagemretorno", label = "xMotivo", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Recebido" }, new { value = 2, display = "Preparado" }, new { value = 3, display = "Enviado" }, new { value = 4, display = "Autorizado" }, new { value = 5, display = "Rejeitado" }, new { value = 6, display = "Cancelado" }, new { value = 7, display = "FalhaTecnica" },}, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "correlationid", label = "CorrelationId", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "produtofiscal", label = "Produto Fiscal", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 55, display = "NFe" }, new { value = 57, display = "CTe" }, new { value = 58, display = "MDFe" },}, },
                new { id = "chaveacesso", label = "Chave de Acesso", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "serie", label = "Serie", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "numero", label = "Numero", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "ambiente", label = "Ambiente", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Producao" }, new { value = 2, display = "Homologacao" },}, },
                new { id = "ufemitente", label = "UF Emitente", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "emitentedocumento", label = "Emitente Documento", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "destinatariodocumento", label = "Destinatario Documento", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "xmlstoragekey", label = "XML", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "xmlhash", label = "Hash XML", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "protocoloautorizacao", label = "Protocolo", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "codigoretorno", label = "cStat", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "mensagemretorno", label = "xMotivo", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Recebido" }, new { value = 2, display = "Preparado" }, new { value = 3, display = "Enviado" }, new { value = 4, display = "Autorizado" }, new { value = 5, display = "Rejeitado" }, new { value = 6, display = "Cancelado" }, new { value = 7, display = "FalhaTecnica" },}, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Identificacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "correlationid", label = "CorrelationId", type = "string", required = false, displaygroup = "Origem", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "produtofiscal", label = "Produto Fiscal", type = "enum", required = false, displaygroup = "Identificacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 55, display = "NFe" }, new { value = 57, display = "CTe" }, new { value = 58, display = "MDFe" },}, },
            new { id = "chaveacesso", label = "Chave de Acesso", type = "string", required = false, displaygroup = "Identificacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "serie", label = "Serie", type = "int", required = false, displaygroup = "Identificacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "numero", label = "Numero", type = "int", required = false, displaygroup = "Identificacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "ambiente", label = "Ambiente", type = "enum", required = false, displaygroup = "SEFAZ", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Producao" }, new { value = 2, display = "Homologacao" },}, },
            new { id = "ufemitente", label = "UF Emitente", type = "string", required = false, displaygroup = "SEFAZ", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "emitentedocumento", label = "Emitente Documento", type = "string", required = false, displaygroup = "Participantes", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "destinatariodocumento", label = "Destinatario Documento", type = "string", required = false, displaygroup = "Participantes", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "xmlstoragekey", label = "XML", type = "string", required = false, displaygroup = "Arquivos", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "xmlhash", label = "Hash XML", type = "string", required = false, displaygroup = "Arquivos", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "protocoloautorizacao", label = "Protocolo", type = "string", required = false, displaygroup = "SEFAZ", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "codigoretorno", label = "cStat", type = "string", required = false, displaygroup = "SEFAZ", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "mensagemretorno", label = "xMotivo", type = "string", required = false, displaygroup = "SEFAZ", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "status", label = "Status", type = "enum", required = false, displaygroup = "Status", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Recebido" }, new { value = 2, display = "Preparado" }, new { value = 3, display = "Enviado" }, new { value = 4, display = "Autorizado" }, new { value = 5, display = "Rejeitado" }, new { value = 6, display = "Cancelado" }, new { value = 7, display = "FalhaTecnica" },}, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
            create = "/DocumentoFiscal/PostDocumentoFiscal",
            read = "/DocumentoFiscal/ReadDocumentoFiscal",
            update = "/DocumentoFiscal/PutDocumentoFiscal",
            delete = "/DocumentoFiscal/DeleteDocumentoFiscal"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDataDocumentoFiscalOriginario", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "DocumentoFiscalOriginario",
        entityDescription = "Documento Fiscal Originario",
        source = new
        {
            kind = "table",
            name = "DocumentoFiscalOriginario"
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
                endpoint = "/DocumentoFiscalOriginario/ReadDocumentoFiscalOriginario",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "documentofiscalid", label = "Documento Fiscal", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataDocumentoFiscal", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "correlationid", label = "CorrelationId", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "sourceapplication", label = "Aplicacao Origem", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "sourcemodule", label = "Modulo Origem", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "sourcemessageid", label = "Mensagem Origem", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "tipodocumento", label = "Tipo Documento", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "chaveacesso", label = "Chave de Acesso", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "numero", label = "Numero", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "serie", label = "Serie", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "emitentedocumento", label = "Emitente Documento", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "destinatariodocumento", label = "Destinatario Documento", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "valordocumento", label = "Valor Documento", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "pesobruto", label = "Peso Bruto", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "volume", label = "Volume", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "snapshotjson", label = "Snapshot", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Recebido" }, new { value = 2, display = "Vinculado" }, new { value = 3, display = "Rejeitado" },}, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "documentofiscalid", label = "Documento Fiscal", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataDocumentoFiscal", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "correlationid", label = "CorrelationId", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "sourceapplication", label = "Aplicacao Origem", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "sourcemodule", label = "Modulo Origem", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "sourcemessageid", label = "Mensagem Origem", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "tipodocumento", label = "Tipo Documento", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "chaveacesso", label = "Chave de Acesso", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "numero", label = "Numero", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "serie", label = "Serie", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "emitentedocumento", label = "Emitente Documento", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "destinatariodocumento", label = "Destinatario Documento", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "valordocumento", label = "Valor Documento", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "pesobruto", label = "Peso Bruto", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "volume", label = "Volume", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "snapshotjson", label = "Snapshot", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Recebido" }, new { value = 2, display = "Vinculado" }, new { value = 3, display = "Rejeitado" },}, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
                documentofiscalid = "/DocumentoFiscalOriginario/DocumentoFiscalOriginarioReadFKDocumentoFiscalId",
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Identificacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "documentofiscalid", label = "Documento Fiscal", type = "int", required = false, displaygroup = "Vinculo", isFk = true, endPontGetMetadata = "/getMetaDataDocumentoFiscal", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "correlationid", label = "CorrelationId", type = "string", required = false, displaygroup = "Origem", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "sourceapplication", label = "Aplicacao Origem", type = "string", required = false, displaygroup = "Origem", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "sourcemodule", label = "Modulo Origem", type = "string", required = false, displaygroup = "Origem", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "sourcemessageid", label = "Mensagem Origem", type = "string", required = false, displaygroup = "Origem", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "tipodocumento", label = "Tipo Documento", type = "string", required = false, displaygroup = "Identificacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "chaveacesso", label = "Chave de Acesso", type = "string", required = false, displaygroup = "Identificacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "numero", label = "Numero", type = "string", required = false, displaygroup = "Identificacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "serie", label = "Serie", type = "string", required = false, displaygroup = "Identificacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "emitentedocumento", label = "Emitente Documento", type = "string", required = false, displaygroup = "Participantes", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "destinatariodocumento", label = "Destinatario Documento", type = "string", required = false, displaygroup = "Participantes", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "valordocumento", label = "Valor Documento", type = "Decimal", required = false, displaygroup = "Valores", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "pesobruto", label = "Peso Bruto", type = "Decimal", required = false, displaygroup = "Valores", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "volume", label = "Volume", type = "Decimal", required = false, displaygroup = "Valores", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "snapshotjson", label = "Snapshot", type = "memo", required = false, displaygroup = "Snapshot", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "status", label = "Status", type = "enum", required = false, displaygroup = "Status", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Recebido" }, new { value = 2, display = "Vinculado" }, new { value = 3, display = "Rejeitado" },}, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
                 documentofiscalid = "/DocumentoFiscalOriginario/DocumentoFiscalOriginarioReadFKDocumentoFiscalId",
            create = "/DocumentoFiscalOriginario/PostDocumentoFiscalOriginario",
            read = "/DocumentoFiscalOriginario/ReadDocumentoFiscalOriginario",
            update = "/DocumentoFiscalOriginario/PutDocumentoFiscalOriginario",
            delete = "/DocumentoFiscalOriginario/DeleteDocumentoFiscalOriginario"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDataNFeProdutoSnapshot", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "NFeProdutoSnapshot",
        entityDescription = "NF-e de Produto",
        source = new
        {
            kind = "table",
            name = "NFeProdutoSnapshot"
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
                endpoint = "/NFeProdutoSnapshot/ReadNFeProdutoSnapshot",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "documentofiscaloriginarioid", label = "Documento Originario", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataDocumentoFiscalOriginario", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "correlationid", label = "CorrelationId", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "cargaid", label = "Carga", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "pedidoid", label = "Pedido", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "chaveacesso", label = "Chave de Acesso", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "emitentedocumento", label = "Emitente Documento", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "destinatariodocumento", label = "Destinatario Documento", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "uforigem", label = "UF Origem", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "ufdestino", label = "UF Destino", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "municipioorigemcodigoibge", label = "Municipio Origem", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "municipiodestinocodigoibge", label = "Municipio Destino", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "valordocumento", label = "Valor Documento", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "pesobruto", label = "Peso Bruto", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "volume", label = "Volume", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "xmlstoragekey", label = "XML", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "snapshotjson", label = "Snapshot", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Recebida" }, new { value = 2, display = "DisponivelParaCTe" }, new { value = 3, display = "VinculadaAoCTe" }, new { value = 4, display = "Rejeitada" },}, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "documentofiscaloriginarioid", label = "Documento Originario", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataDocumentoFiscalOriginario", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "correlationid", label = "CorrelationId", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "cargaid", label = "Carga", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "pedidoid", label = "Pedido", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "chaveacesso", label = "Chave de Acesso", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "emitentedocumento", label = "Emitente Documento", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "destinatariodocumento", label = "Destinatario Documento", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "uforigem", label = "UF Origem", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "ufdestino", label = "UF Destino", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "municipioorigemcodigoibge", label = "Municipio Origem", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "municipiodestinocodigoibge", label = "Municipio Destino", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "valordocumento", label = "Valor Documento", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "pesobruto", label = "Peso Bruto", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "volume", label = "Volume", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "xmlstoragekey", label = "XML", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "snapshotjson", label = "Snapshot", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Recebida" }, new { value = 2, display = "DisponivelParaCTe" }, new { value = 3, display = "VinculadaAoCTe" }, new { value = 4, display = "Rejeitada" },}, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
                documentofiscaloriginarioid = "/NFeProdutoSnapshot/NFeProdutoSnapshotReadFKDocumentoFiscalOriginarioId",
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Identificacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "documentofiscaloriginarioid", label = "Documento Originario", type = "int", required = false, displaygroup = "Vinculo", isFk = true, endPontGetMetadata = "/getMetaDataDocumentoFiscalOriginario", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "correlationid", label = "CorrelationId", type = "string", required = false, displaygroup = "Origem", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "cargaid", label = "Carga", type = "string", required = false, displaygroup = "Operacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "pedidoid", label = "Pedido", type = "string", required = false, displaygroup = "Operacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "chaveacesso", label = "Chave de Acesso", type = "string", required = false, displaygroup = "Identificacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "emitentedocumento", label = "Emitente Documento", type = "string", required = false, displaygroup = "Participantes", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "destinatariodocumento", label = "Destinatario Documento", type = "string", required = false, displaygroup = "Participantes", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "uforigem", label = "UF Origem", type = "string", required = false, displaygroup = "Rota", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "ufdestino", label = "UF Destino", type = "string", required = false, displaygroup = "Rota", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "municipioorigemcodigoibge", label = "Municipio Origem", type = "string", required = false, displaygroup = "Rota", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "municipiodestinocodigoibge", label = "Municipio Destino", type = "string", required = false, displaygroup = "Rota", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "valordocumento", label = "Valor Documento", type = "Decimal", required = false, displaygroup = "Valores", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "pesobruto", label = "Peso Bruto", type = "Decimal", required = false, displaygroup = "Valores", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "volume", label = "Volume", type = "Decimal", required = false, displaygroup = "Valores", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "xmlstoragekey", label = "XML", type = "string", required = false, displaygroup = "Arquivos", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "snapshotjson", label = "Snapshot", type = "memo", required = false, displaygroup = "Snapshot", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "status", label = "Status", type = "enum", required = false, displaygroup = "Status", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Recebida" }, new { value = 2, display = "DisponivelParaCTe" }, new { value = 3, display = "VinculadaAoCTe" }, new { value = 4, display = "Rejeitada" },}, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
                 documentofiscaloriginarioid = "/NFeProdutoSnapshot/NFeProdutoSnapshotReadFKDocumentoFiscalOriginarioId",
            create = "/NFeProdutoSnapshot/PostNFeProdutoSnapshot",
            read = "/NFeProdutoSnapshot/ReadNFeProdutoSnapshot",
            update = "/NFeProdutoSnapshot/PutNFeProdutoSnapshot",
            delete = "/NFeProdutoSnapshot/DeleteNFeProdutoSnapshot"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDataCTeEntradaOficial", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "CTeEntradaOficial",
        entityDescription = "Entrada Oficial CT-e",
        source = new
        {
            kind = "table",
            name = "CTeEntradaOficial"
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
                endpoint = "/CTeEntradaOficial/ReadCTeEntradaOficial",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "correlationid", label = "CorrelationId", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "sourceapplication", label = "Aplicacao Origem", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "sourcemodule", label = "Modulo Origem", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "sourcemessageid", label = "Mensagem Origem", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "messagetype", label = "Tipo da Mensagem", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "messageversion", label = "Versao da Mensagem", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "receivedatutc", label = "Recebido em UTC", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "payloadhash", label = "Hash do Payload", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "payloadstoragekey", label = "Storage do Payload", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status da Entrada", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Recebida" }, new { value = 2, display = "Normalizada" }, new { value = 3, display = "Rejeitada" }, new { value = 4, display = "Processada" }, new { value = 5, display = "Falha" },}, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "correlationid", label = "CorrelationId", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "sourceapplication", label = "Aplicacao Origem", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "sourcemodule", label = "Modulo Origem", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "sourcemessageid", label = "Mensagem Origem", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "messagetype", label = "Tipo da Mensagem", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "messageversion", label = "Versao da Mensagem", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "receivedatutc", label = "Recebido em UTC", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "payloadhash", label = "Hash do Payload", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "payloadstoragekey", label = "Storage do Payload", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status da Entrada", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Recebida" }, new { value = 2, display = "Normalizada" }, new { value = 3, display = "Rejeitada" }, new { value = 4, display = "Processada" }, new { value = 5, display = "Falha" },}, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Identificacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "correlationid", label = "CorrelationId", type = "string", required = false, displaygroup = "Origem", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "sourceapplication", label = "Aplicacao Origem", type = "string", required = false, displaygroup = "Origem", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "sourcemodule", label = "Modulo Origem", type = "string", required = false, displaygroup = "Origem", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "sourcemessageid", label = "Mensagem Origem", type = "string", required = false, displaygroup = "Origem", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "messagetype", label = "Tipo da Mensagem", type = "string", required = false, displaygroup = "Origem", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "messageversion", label = "Versao da Mensagem", type = "string", required = false, displaygroup = "Origem", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "receivedatutc", label = "Recebido em UTC", type = "DateTime", required = false, displaygroup = "Origem", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "payloadhash", label = "Hash do Payload", type = "string", required = false, displaygroup = "Payload", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "payloadstoragekey", label = "Storage do Payload", type = "string", required = false, displaygroup = "Payload", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "status", label = "Status da Entrada", type = "enum", required = false, displaygroup = "Status", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Recebida" }, new { value = 2, display = "Normalizada" }, new { value = 3, display = "Rejeitada" }, new { value = 4, display = "Processada" }, new { value = 5, display = "Falha" },}, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
            create = "/CTeEntradaOficial/PostCTeEntradaOficial",
            read = "/CTeEntradaOficial/ReadCTeEntradaOficial",
            update = "/CTeEntradaOficial/PutCTeEntradaOficial",
            delete = "/CTeEntradaOficial/DeleteCTeEntradaOficial"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDataCTeRomaneioConsolidado", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "CTeRomaneioConsolidado",
        entityDescription = "Romaneio Consolidado Para CT-e",
        source = new
        {
            kind = "table",
            name = "CTeRomaneioConsolidado"
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
                endpoint = "/CTeRomaneioConsolidado/ReadCTeRomaneioConsolidado",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "entradaoficialid", label = "Entrada Oficial", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataCTeEntradaOficial", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "correlationid", label = "CorrelationId", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "romaneioid", label = "Romaneio", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "cargaid", label = "Carga", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "consolidadoemutc", label = "Consolidado em UTC", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "ufinicio", label = "UF Inicio", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "uffim", label = "UF Fim", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "municipioiniciocodigoibge", label = "Municipio Inicio", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "municipiofimcodigoibge", label = "Municipio Fim", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "emitentedocumento", label = "Emitente Documento", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "tomadordocumento", label = "Tomador Documento", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "rotasnapshotjson", label = "Snapshot da Rota", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "cargasnapshotjson", label = "Snapshot da Carga", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "preferenciasfiscaisjson", label = "Preferencias Fiscais", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status do Romaneio", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Recebido" }, new { value = 2, display = "SolicitacaoCriada" }, new { value = 3, display = "PendenteDados" }, new { value = 4, display = "Rejeitado" }, new { value = 5, display = "Processado" },}, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "entradaoficialid", label = "Entrada Oficial", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataCTeEntradaOficial", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "correlationid", label = "CorrelationId", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "romaneioid", label = "Romaneio", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "cargaid", label = "Carga", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "consolidadoemutc", label = "Consolidado em UTC", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "ufinicio", label = "UF Inicio", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "uffim", label = "UF Fim", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "municipioiniciocodigoibge", label = "Municipio Inicio", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "municipiofimcodigoibge", label = "Municipio Fim", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "emitentedocumento", label = "Emitente Documento", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "tomadordocumento", label = "Tomador Documento", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "rotasnapshotjson", label = "Snapshot da Rota", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "cargasnapshotjson", label = "Snapshot da Carga", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "preferenciasfiscaisjson", label = "Preferencias Fiscais", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status do Romaneio", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Recebido" }, new { value = 2, display = "SolicitacaoCriada" }, new { value = 3, display = "PendenteDados" }, new { value = 4, display = "Rejeitado" }, new { value = 5, display = "Processado" },}, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
                entradaoficialid = "/CTeRomaneioConsolidado/CTeRomaneioConsolidadoReadFKEntradaOficialId",
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Identificacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "entradaoficialid", label = "Entrada Oficial", type = "int", required = false, displaygroup = "Vinculo", isFk = true, endPontGetMetadata = "/getMetaDataCTeEntradaOficial", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "correlationid", label = "CorrelationId", type = "string", required = false, displaygroup = "Origem", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "romaneioid", label = "Romaneio", type = "string", required = false, displaygroup = "Operacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "cargaid", label = "Carga", type = "string", required = false, displaygroup = "Operacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "consolidadoemutc", label = "Consolidado em UTC", type = "DateTime", required = false, displaygroup = "Operacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "ufinicio", label = "UF Inicio", type = "string", required = false, displaygroup = "Rota", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "uffim", label = "UF Fim", type = "string", required = false, displaygroup = "Rota", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "municipioiniciocodigoibge", label = "Municipio Inicio", type = "string", required = false, displaygroup = "Rota", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "municipiofimcodigoibge", label = "Municipio Fim", type = "string", required = false, displaygroup = "Rota", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "emitentedocumento", label = "Emitente Documento", type = "string", required = false, displaygroup = "Participantes", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "tomadordocumento", label = "Tomador Documento", type = "string", required = false, displaygroup = "Participantes", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "rotasnapshotjson", label = "Snapshot da Rota", type = "memo", required = false, displaygroup = "Snapshot", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "cargasnapshotjson", label = "Snapshot da Carga", type = "memo", required = false, displaygroup = "Snapshot", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "preferenciasfiscaisjson", label = "Preferencias Fiscais", type = "memo", required = false, displaygroup = "Snapshot", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "status", label = "Status do Romaneio", type = "enum", required = false, displaygroup = "Status", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Recebido" }, new { value = 2, display = "SolicitacaoCriada" }, new { value = 3, display = "PendenteDados" }, new { value = 4, display = "Rejeitado" }, new { value = 5, display = "Processado" },}, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
                 entradaoficialid = "/CTeRomaneioConsolidado/CTeRomaneioConsolidadoReadFKEntradaOficialId",
            create = "/CTeRomaneioConsolidado/PostCTeRomaneioConsolidado",
            read = "/CTeRomaneioConsolidado/ReadCTeRomaneioConsolidado",
            update = "/CTeRomaneioConsolidado/PutCTeRomaneioConsolidado",
            delete = "/CTeRomaneioConsolidado/DeleteCTeRomaneioConsolidado"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDataCTeSolicitacaoFiscal", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "CTeSolicitacaoFiscal",
        entityDescription = "Solicitacao Fiscal CT-e",
        source = new
        {
            kind = "table",
            name = "CTeSolicitacaoFiscal"
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
                endpoint = "/CTeSolicitacaoFiscal/ReadCTeSolicitacaoFiscal",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "entradaoficialid", label = "Entrada Oficial", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataCTeEntradaOficial", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "romaneioconsolidadoid", label = "Romaneio Consolidado", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataCTeRomaneioConsolidado", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "correlationid", label = "CorrelationId", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "ambiente", label = "Ambiente", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Producao" }, new { value = 2, display = "Homologacao" },}, },
                new { id = "ufemitente", label = "UF Emitente", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "emitentedocumento", label = "Emitente Documento", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "produtofiscal", label = "Produto Fiscal", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 57, display = "CTe" },}, },
                new { id = "tipocte", label = "Tipo CT-e", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "Normal" }, new { value = 1, display = "Complementar" }, new { value = 2, display = "Anulacao" }, new { value = 3, display = "Substituicao" },}, },
                new { id = "tiposervico", label = "Tipo Servico", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "Normal" }, new { value = 1, display = "Subcontratacao" }, new { value = 2, display = "Redespacho" }, new { value = 3, display = "RedespachoIntermediario" }, new { value = 4, display = "Multimodal" },}, },
                new { id = "modal", label = "Modal", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Rodoviario" }, new { value = 2, display = "Aereo" }, new { value = 3, display = "Aquaviario" }, new { value = 4, display = "Ferroviario" }, new { value = 5, display = "Dutoviario" }, new { value = 6, display = "Multimodal" },}, },
                new { id = "globalizado", label = "Globalizado", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "Nao" }, new { value = 1, display = "Sim" },}, },
                new { id = "ufinicio", label = "UF Inicio", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "uffim", label = "UF Fim", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "municipioiniciocodigoibge", label = "Municipio Inicio", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "municipiofimcodigoibge", label = "Municipio Fim", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "valorservico", label = "Valor Servico", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "valorcarga", label = "Valor Carga", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "preferenciasmanifestojson", label = "Preferencias Manifesto", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status da Solicitacao", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Aberta" }, new { value = 2, display = "Classificada" }, new { value = 3, display = "ProntaParaEmissao" }, new { value = 4, display = "Autorizada" }, new { value = 5, display = "Rejeitada" }, new { value = 6, display = "FalhaTecnica" },}, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "entradaoficialid", label = "Entrada Oficial", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataCTeEntradaOficial", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "romaneioconsolidadoid", label = "Romaneio Consolidado", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataCTeRomaneioConsolidado", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "correlationid", label = "CorrelationId", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "ambiente", label = "Ambiente", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Producao" }, new { value = 2, display = "Homologacao" },}, },
                new { id = "ufemitente", label = "UF Emitente", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "emitentedocumento", label = "Emitente Documento", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "produtofiscal", label = "Produto Fiscal", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 57, display = "CTe" },}, },
                new { id = "tipocte", label = "Tipo CT-e", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "Normal" }, new { value = 1, display = "Complementar" }, new { value = 2, display = "Anulacao" }, new { value = 3, display = "Substituicao" },}, },
                new { id = "tiposervico", label = "Tipo Servico", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "Normal" }, new { value = 1, display = "Subcontratacao" }, new { value = 2, display = "Redespacho" }, new { value = 3, display = "RedespachoIntermediario" }, new { value = 4, display = "Multimodal" },}, },
                new { id = "modal", label = "Modal", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Rodoviario" }, new { value = 2, display = "Aereo" }, new { value = 3, display = "Aquaviario" }, new { value = 4, display = "Ferroviario" }, new { value = 5, display = "Dutoviario" }, new { value = 6, display = "Multimodal" },}, },
                new { id = "globalizado", label = "Globalizado", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "Nao" }, new { value = 1, display = "Sim" },}, },
                new { id = "ufinicio", label = "UF Inicio", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "uffim", label = "UF Fim", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "municipioiniciocodigoibge", label = "Municipio Inicio", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "municipiofimcodigoibge", label = "Municipio Fim", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "valorservico", label = "Valor Servico", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "valorcarga", label = "Valor Carga", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "preferenciasmanifestojson", label = "Preferencias Manifesto", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status da Solicitacao", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Aberta" }, new { value = 2, display = "Classificada" }, new { value = 3, display = "ProntaParaEmissao" }, new { value = 4, display = "Autorizada" }, new { value = 5, display = "Rejeitada" }, new { value = 6, display = "FalhaTecnica" },}, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
                entradaoficialid = "/CTeSolicitacaoFiscal/CTeSolicitacaoFiscalReadFKEntradaOficialId",
                romaneioconsolidadoid = "/CTeSolicitacaoFiscal/CTeSolicitacaoFiscalReadFKRomaneioConsolidadoId",
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Identificacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "entradaoficialid", label = "Entrada Oficial", type = "int", required = false, displaygroup = "Vinculo", isFk = true, endPontGetMetadata = "/getMetaDataCTeEntradaOficial", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "romaneioconsolidadoid", label = "Romaneio Consolidado", type = "int", required = false, displaygroup = "Vinculo", isFk = true, endPontGetMetadata = "/getMetaDataCTeRomaneioConsolidado", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "correlationid", label = "CorrelationId", type = "string", required = false, displaygroup = "Origem", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "ambiente", label = "Ambiente", type = "enum", required = false, displaygroup = "SEFAZ", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Producao" }, new { value = 2, display = "Homologacao" },}, },
            new { id = "ufemitente", label = "UF Emitente", type = "string", required = false, displaygroup = "SEFAZ", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "emitentedocumento", label = "Emitente Documento", type = "string", required = false, displaygroup = "Participantes", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "produtofiscal", label = "Produto Fiscal", type = "enum", required = false, displaygroup = "Identificacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 57, display = "CTe" },}, },
            new { id = "tipocte", label = "Tipo CT-e", type = "enum", required = false, displaygroup = "Identificacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "Normal" }, new { value = 1, display = "Complementar" }, new { value = 2, display = "Anulacao" }, new { value = 3, display = "Substituicao" },}, },
            new { id = "tiposervico", label = "Tipo Servico", type = "enum", required = false, displaygroup = "Servico", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "Normal" }, new { value = 1, display = "Subcontratacao" }, new { value = 2, display = "Redespacho" }, new { value = 3, display = "RedespachoIntermediario" }, new { value = 4, display = "Multimodal" },}, },
            new { id = "modal", label = "Modal", type = "enum", required = false, displaygroup = "Servico", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Rodoviario" }, new { value = 2, display = "Aereo" }, new { value = 3, display = "Aquaviario" }, new { value = 4, display = "Ferroviario" }, new { value = 5, display = "Dutoviario" }, new { value = 6, display = "Multimodal" },}, },
            new { id = "globalizado", label = "Globalizado", type = "enum", required = false, displaygroup = "Servico", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "Nao" }, new { value = 1, display = "Sim" },}, },
            new { id = "ufinicio", label = "UF Inicio", type = "string", required = false, displaygroup = "Rota", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "uffim", label = "UF Fim", type = "string", required = false, displaygroup = "Rota", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "municipioiniciocodigoibge", label = "Municipio Inicio", type = "string", required = false, displaygroup = "Rota", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "municipiofimcodigoibge", label = "Municipio Fim", type = "string", required = false, displaygroup = "Rota", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "valorservico", label = "Valor Servico", type = "Decimal", required = false, displaygroup = "Valores", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "valorcarga", label = "Valor Carga", type = "Decimal", required = false, displaygroup = "Valores", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "preferenciasmanifestojson", label = "Preferencias Manifesto", type = "memo", required = false, displaygroup = "Snapshot", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "status", label = "Status da Solicitacao", type = "enum", required = false, displaygroup = "Status", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Aberta" }, new { value = 2, display = "Classificada" }, new { value = 3, display = "ProntaParaEmissao" }, new { value = 4, display = "Autorizada" }, new { value = 5, display = "Rejeitada" }, new { value = 6, display = "FalhaTecnica" },}, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
                 entradaoficialid = "/CTeSolicitacaoFiscal/CTeSolicitacaoFiscalReadFKEntradaOficialId",
                 romaneioconsolidadoid = "/CTeSolicitacaoFiscal/CTeSolicitacaoFiscalReadFKRomaneioConsolidadoId",
            create = "/CTeSolicitacaoFiscal/PostCTeSolicitacaoFiscal",
            read = "/CTeSolicitacaoFiscal/ReadCTeSolicitacaoFiscal",
            update = "/CTeSolicitacaoFiscal/PutCTeSolicitacaoFiscal",
            delete = "/CTeSolicitacaoFiscal/DeleteCTeSolicitacaoFiscal"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDataCTeDocumentoOriginario", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "CTeDocumentoOriginario",
        entityDescription = "Documento Originario CT-e",
        source = new
        {
            kind = "table",
            name = "CTeDocumentoOriginario"
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
                endpoint = "/CTeDocumentoOriginario/ReadCTeDocumentoOriginario",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "ctesolicitacaofiscalid", label = "Solicitacao CT-e", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataCTeSolicitacaoFiscal", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "documentofiscaloriginarioid", label = "Documento Originario", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataDocumentoFiscalOriginario", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "tipodocumento", label = "Tipo Documento", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "chaveacesso", label = "Chave de Acesso", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "numero", label = "Numero", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "serie", label = "Serie", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "emitentedocumento", label = "Emitente Documento", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "destinatariodocumento", label = "Destinatario Documento", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "valordocumento", label = "Valor Documento", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "pesobruto", label = "Peso Bruto", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "snapshotjson", label = "Snapshot", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "ctesolicitacaofiscalid", label = "Solicitacao CT-e", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataCTeSolicitacaoFiscal", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "documentofiscaloriginarioid", label = "Documento Originario", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataDocumentoFiscalOriginario", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "tipodocumento", label = "Tipo Documento", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "chaveacesso", label = "Chave de Acesso", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "numero", label = "Numero", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "serie", label = "Serie", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "emitentedocumento", label = "Emitente Documento", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "destinatariodocumento", label = "Destinatario Documento", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "valordocumento", label = "Valor Documento", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "pesobruto", label = "Peso Bruto", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "snapshotjson", label = "Snapshot", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
                ctesolicitacaofiscalid = "/CTeDocumentoOriginario/CTeDocumentoOriginarioReadFKCTeSolicitacaoFiscalId",
                documentofiscaloriginarioid = "/CTeDocumentoOriginario/CTeDocumentoOriginarioReadFKDocumentoFiscalOriginarioId",
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Identificacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "ctesolicitacaofiscalid", label = "Solicitacao CT-e", type = "int", required = false, displaygroup = "Vinculo", isFk = true, endPontGetMetadata = "/getMetaDataCTeSolicitacaoFiscal", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "documentofiscaloriginarioid", label = "Documento Originario", type = "int", required = false, displaygroup = "Vinculo", isFk = true, endPontGetMetadata = "/getMetaDataDocumentoFiscalOriginario", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "tipodocumento", label = "Tipo Documento", type = "string", required = false, displaygroup = "Identificacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "chaveacesso", label = "Chave de Acesso", type = "string", required = false, displaygroup = "Identificacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "numero", label = "Numero", type = "string", required = false, displaygroup = "Identificacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "serie", label = "Serie", type = "string", required = false, displaygroup = "Identificacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "emitentedocumento", label = "Emitente Documento", type = "string", required = false, displaygroup = "Participantes", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "destinatariodocumento", label = "Destinatario Documento", type = "string", required = false, displaygroup = "Participantes", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "valordocumento", label = "Valor Documento", type = "Decimal", required = false, displaygroup = "Valores", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "pesobruto", label = "Peso Bruto", type = "Decimal", required = false, displaygroup = "Valores", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "snapshotjson", label = "Snapshot", type = "memo", required = false, displaygroup = "Snapshot", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
                 ctesolicitacaofiscalid = "/CTeDocumentoOriginario/CTeDocumentoOriginarioReadFKCTeSolicitacaoFiscalId",
                 documentofiscaloriginarioid = "/CTeDocumentoOriginario/CTeDocumentoOriginarioReadFKDocumentoFiscalOriginarioId",
            create = "/CTeDocumentoOriginario/PostCTeDocumentoOriginario",
            read = "/CTeDocumentoOriginario/ReadCTeDocumentoOriginario",
            update = "/CTeDocumentoOriginario/PutCTeDocumentoOriginario",
            delete = "/CTeDocumentoOriginario/DeleteCTeDocumentoOriginario"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDataCTeParticipanteSnapshot", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "CTeParticipanteSnapshot",
        entityDescription = "Participante CT-e",
        source = new
        {
            kind = "table",
            name = "CTeParticipanteSnapshot"
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
                endpoint = "/CTeParticipanteSnapshot/ReadCTeParticipanteSnapshot",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "ctesolicitacaofiscalid", label = "Solicitacao CT-e", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataCTeSolicitacaoFiscal", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "papel", label = "Papel", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "documento", label = "Documento", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "nome", label = "Nome", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "inscricaoestadual", label = "Inscricao Estadual", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "uf", label = "UF", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "municipiocodigoibge", label = "Municipio IBGE", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "enderecojson", label = "Endereco", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "ctesolicitacaofiscalid", label = "Solicitacao CT-e", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataCTeSolicitacaoFiscal", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "papel", label = "Papel", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "documento", label = "Documento", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "nome", label = "Nome", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "inscricaoestadual", label = "Inscricao Estadual", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "uf", label = "UF", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "municipiocodigoibge", label = "Municipio IBGE", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "enderecojson", label = "Endereco", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
                ctesolicitacaofiscalid = "/CTeParticipanteSnapshot/CTeParticipanteSnapshotReadFKCTeSolicitacaoFiscalId",
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Identificacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "ctesolicitacaofiscalid", label = "Solicitacao CT-e", type = "int", required = false, displaygroup = "Vinculo", isFk = true, endPontGetMetadata = "/getMetaDataCTeSolicitacaoFiscal", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "papel", label = "Papel", type = "string", required = false, displaygroup = "Identificacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "documento", label = "Documento", type = "string", required = false, displaygroup = "Identificacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "nome", label = "Nome", type = "string", required = false, displaygroup = "Identificacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "inscricaoestadual", label = "Inscricao Estadual", type = "string", required = false, displaygroup = "Fiscal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "uf", label = "UF", type = "string", required = false, displaygroup = "Endereco", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "municipiocodigoibge", label = "Municipio IBGE", type = "string", required = false, displaygroup = "Endereco", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "enderecojson", label = "Endereco", type = "memo", required = false, displaygroup = "Endereco", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
                 ctesolicitacaofiscalid = "/CTeParticipanteSnapshot/CTeParticipanteSnapshotReadFKCTeSolicitacaoFiscalId",
            create = "/CTeParticipanteSnapshot/PostCTeParticipanteSnapshot",
            read = "/CTeParticipanteSnapshot/ReadCTeParticipanteSnapshot",
            update = "/CTeParticipanteSnapshot/PutCTeParticipanteSnapshot",
            delete = "/CTeParticipanteSnapshot/DeleteCTeParticipanteSnapshot"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDataCTeTentativaEmissao", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "CTeTentativaEmissao",
        entityDescription = "Tentativa de Emissao CT-e",
        source = new
        {
            kind = "table",
            name = "CTeTentativaEmissao"
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
                endpoint = "/CTeTentativaEmissao/ReadCTeTentativaEmissao",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "ctesolicitacaofiscalid", label = "Solicitacao CT-e", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataCTeSolicitacaoFiscal", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "chaveacesso", label = "Chave de Acesso", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "numero", label = "Numero", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "serie", label = "Serie", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "tentativa", label = "Tentativa", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "xmlassinadostoragekey", label = "XML Assinado", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "xmlprocstoragekey", label = "procCTe", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "xmlhash", label = "Hash XML", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "codigoretorno", label = "cStat", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "mensagemretorno", label = "xMotivo", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "protocoloautorizacao", label = "Protocolo", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "enviadoemutc", label = "Enviado em UTC", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "autorizadoemutc", label = "Autorizado em UTC", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status da Emissao", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Pendente" }, new { value = 2, display = "Enviado" }, new { value = 3, display = "Autorizado" }, new { value = 4, display = "Rejeitado" }, new { value = 5, display = "FalhaTecnica" },}, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "ctesolicitacaofiscalid", label = "Solicitacao CT-e", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataCTeSolicitacaoFiscal", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "chaveacesso", label = "Chave de Acesso", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "numero", label = "Numero", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "serie", label = "Serie", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "tentativa", label = "Tentativa", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "xmlassinadostoragekey", label = "XML Assinado", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "xmlprocstoragekey", label = "procCTe", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "xmlhash", label = "Hash XML", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "codigoretorno", label = "cStat", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "mensagemretorno", label = "xMotivo", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "protocoloautorizacao", label = "Protocolo", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "enviadoemutc", label = "Enviado em UTC", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "autorizadoemutc", label = "Autorizado em UTC", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status da Emissao", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Pendente" }, new { value = 2, display = "Enviado" }, new { value = 3, display = "Autorizado" }, new { value = 4, display = "Rejeitado" }, new { value = 5, display = "FalhaTecnica" },}, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
                ctesolicitacaofiscalid = "/CTeTentativaEmissao/CTeTentativaEmissaoReadFKCTeSolicitacaoFiscalId",
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Identificacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "ctesolicitacaofiscalid", label = "Solicitacao CT-e", type = "int", required = false, displaygroup = "Vinculo", isFk = true, endPontGetMetadata = "/getMetaDataCTeSolicitacaoFiscal", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "chaveacesso", label = "Chave de Acesso", type = "string", required = false, displaygroup = "Identificacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "numero", label = "Numero", type = "int", required = false, displaygroup = "Identificacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "serie", label = "Serie", type = "int", required = false, displaygroup = "Identificacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "tentativa", label = "Tentativa", type = "int", required = false, displaygroup = "Operacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "xmlassinadostoragekey", label = "XML Assinado", type = "string", required = false, displaygroup = "Arquivos", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "xmlprocstoragekey", label = "procCTe", type = "string", required = false, displaygroup = "Arquivos", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "xmlhash", label = "Hash XML", type = "string", required = false, displaygroup = "Arquivos", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "codigoretorno", label = "cStat", type = "string", required = false, displaygroup = "SEFAZ", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "mensagemretorno", label = "xMotivo", type = "string", required = false, displaygroup = "SEFAZ", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "protocoloautorizacao", label = "Protocolo", type = "string", required = false, displaygroup = "SEFAZ", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "enviadoemutc", label = "Enviado em UTC", type = "DateTime", required = false, displaygroup = "SEFAZ", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "autorizadoemutc", label = "Autorizado em UTC", type = "DateTime", required = false, displaygroup = "SEFAZ", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "status", label = "Status da Emissao", type = "enum", required = false, displaygroup = "Status", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Pendente" }, new { value = 2, display = "Enviado" }, new { value = 3, display = "Autorizado" }, new { value = 4, display = "Rejeitado" }, new { value = 5, display = "FalhaTecnica" },}, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
                 ctesolicitacaofiscalid = "/CTeTentativaEmissao/CTeTentativaEmissaoReadFKCTeSolicitacaoFiscalId",
            create = "/CTeTentativaEmissao/PostCTeTentativaEmissao",
            read = "/CTeTentativaEmissao/ReadCTeTentativaEmissao",
            update = "/CTeTentativaEmissao/PutCTeTentativaEmissao",
            delete = "/CTeTentativaEmissao/DeleteCTeTentativaEmissao"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDataCTeSaidaMDFe", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "CTeSaidaMDFe",
        entityDescription = "Saida CT-e para MDF-e",
        source = new
        {
            kind = "table",
            name = "CTeSaidaMDFe"
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
                endpoint = "/CTeSaidaMDFe/ReadCTeSaidaMDFe",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "ctetentativaemissaoid", label = "Tentativa CT-e", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataCTeTentativaEmissao", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "correlationid", label = "CorrelationId", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "chaveacessocte", label = "Chave CT-e", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "snapshothash", label = "Hash Snapshot", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "outboxmessageid", label = "Mensagem Outbox", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "publicadoemutc", label = "Publicado em UTC", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "ultimoerro", label = "Ultimo Erro", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status da Saida", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "AguardandoPublicacao" }, new { value = 2, display = "PublicadoOutbox" }, new { value = 3, display = "EntregueInboxMDFe" }, new { value = 4, display = "ConsumidoPeloMDFe" }, new { value = 5, display = "FalhaNaEntrega" },}, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "ctetentativaemissaoid", label = "Tentativa CT-e", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataCTeTentativaEmissao", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "correlationid", label = "CorrelationId", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "chaveacessocte", label = "Chave CT-e", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "snapshothash", label = "Hash Snapshot", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "outboxmessageid", label = "Mensagem Outbox", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "publicadoemutc", label = "Publicado em UTC", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "ultimoerro", label = "Ultimo Erro", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status da Saida", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "AguardandoPublicacao" }, new { value = 2, display = "PublicadoOutbox" }, new { value = 3, display = "EntregueInboxMDFe" }, new { value = 4, display = "ConsumidoPeloMDFe" }, new { value = 5, display = "FalhaNaEntrega" },}, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
                ctetentativaemissaoid = "/CTeSaidaMDFe/CTeSaidaMDFeReadFKCTeTentativaEmissaoId",
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Identificacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "ctetentativaemissaoid", label = "Tentativa CT-e", type = "int", required = false, displaygroup = "Vinculo", isFk = true, endPontGetMetadata = "/getMetaDataCTeTentativaEmissao", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "correlationid", label = "CorrelationId", type = "string", required = false, displaygroup = "Origem", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "chaveacessocte", label = "Chave CT-e", type = "string", required = false, displaygroup = "Identificacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "snapshothash", label = "Hash Snapshot", type = "string", required = false, displaygroup = "Snapshot", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "outboxmessageid", label = "Mensagem Outbox", type = "string", required = false, displaygroup = "Entrega", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "publicadoemutc", label = "Publicado em UTC", type = "DateTime", required = false, displaygroup = "Entrega", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "ultimoerro", label = "Ultimo Erro", type = "string", required = false, displaygroup = "Entrega", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "status", label = "Status da Saida", type = "enum", required = false, displaygroup = "Status", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "AguardandoPublicacao" }, new { value = 2, display = "PublicadoOutbox" }, new { value = 3, display = "EntregueInboxMDFe" }, new { value = 4, display = "ConsumidoPeloMDFe" }, new { value = 5, display = "FalhaNaEntrega" },}, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
                 ctetentativaemissaoid = "/CTeSaidaMDFe/CTeSaidaMDFeReadFKCTeTentativaEmissaoId",
            create = "/CTeSaidaMDFe/PostCTeSaidaMDFe",
            read = "/CTeSaidaMDFe/ReadCTeSaidaMDFe",
            update = "/CTeSaidaMDFe/PutCTeSaidaMDFe",
            delete = "/CTeSaidaMDFe/DeleteCTeSaidaMDFe"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDataMDFe", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "MDFe",
        entityDescription = "MDF-e",
        source = new
        {
            kind = "table",
            name = "MDFe"
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
                endpoint = "/MDFe/ReadMDFe",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "chaveacesso", label = "Chave de Acesso", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "serie", label = "Serie", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "numero", label = "Numero", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "ufcarregamento", label = "UF de Carregamento", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "ufdescarregamento", label = "UF de Descarregamento", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "placaveiculo", label = "Placa do Veiculo", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "emitidoem", label = "Emitido em", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "autorizadoem", label = "Autorizado em", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "iniciadoem", label = "Inicio do Transporte", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "encerradoem", label = "Encerrado em", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "canceladoem", label = "Cancelado em", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "situacao", label = "Situacao do MDF-e", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Autorizado" }, new { value = 2, display = "EmTransporte" }, new { value = 3, display = "Encerrado" }, new { value = 4, display = "Cancelado" },}, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "chaveacesso", label = "Chave de Acesso", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "serie", label = "Serie", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "numero", label = "Numero", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "ufcarregamento", label = "UF de Carregamento", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "ufdescarregamento", label = "UF de Descarregamento", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "placaveiculo", label = "Placa do Veiculo", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "emitidoem", label = "Emitido em", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "autorizadoem", label = "Autorizado em", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "iniciadoem", label = "Inicio do Transporte", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "encerradoem", label = "Encerrado em", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "canceladoem", label = "Cancelado em", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "situacao", label = "Situacao do MDF-e", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Autorizado" }, new { value = 2, display = "EmTransporte" }, new { value = 3, display = "Encerrado" }, new { value = 4, display = "Cancelado" },}, },
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
            new { id = "chaveacesso", label = "Chave de Acesso", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "serie", label = "Serie", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "numero", label = "Numero", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "ufcarregamento", label = "UF de Carregamento", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "ufdescarregamento", label = "UF de Descarregamento", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "placaveiculo", label = "Placa do Veiculo", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "emitidoem", label = "Emitido em", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "autorizadoem", label = "Autorizado em", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "iniciadoem", label = "Inicio do Transporte", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "encerradoem", label = "Encerrado em", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "canceladoem", label = "Cancelado em", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "situacao", label = "Situacao do MDF-e", type = "enum", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Autorizado" }, new { value = 2, display = "EmTransporte" }, new { value = 3, display = "Encerrado" }, new { value = 4, display = "Cancelado" },}, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
            create = "/MDFe/PostMDFe",
            read = "/MDFe/ReadMDFe",
            update = "/MDFe/PutMDFe",
            delete = "/MDFe/DeleteMDFe"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDataMDFeSolicitacaoFiscal", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "MDFeSolicitacaoFiscal",
        entityDescription = "Solicitacao Fiscal MDF-e",
        source = new
        {
            kind = "table",
            name = "MDFeSolicitacaoFiscal"
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
                endpoint = "/MDFeSolicitacaoFiscal/ReadMDFeSolicitacaoFiscal",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "correlationid", label = "CorrelationId", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "cargaid", label = "Carga", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "ambiente", label = "Ambiente", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Producao" }, new { value = 2, display = "Homologacao" },}, },
                new { id = "ufcarregamento", label = "UF de Carregamento", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "ufdescarregamento", label = "UF de Descarregamento", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "placaveiculo", label = "Placa do Veiculo", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "condutordocumento", label = "Documento do Condutor", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "documentosoriginariosjson", label = "Documentos Originarios", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "transportesnapshotjson", label = "Snapshot Transporte", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Aberta" }, new { value = 2, display = "ProntaParaEmissao" }, new { value = 3, display = "Autorizada" }, new { value = 4, display = "Rejeitada" }, new { value = 5, display = "FalhaTecnica" },}, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "correlationid", label = "CorrelationId", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "cargaid", label = "Carga", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "ambiente", label = "Ambiente", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Producao" }, new { value = 2, display = "Homologacao" },}, },
                new { id = "ufcarregamento", label = "UF de Carregamento", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "ufdescarregamento", label = "UF de Descarregamento", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "placaveiculo", label = "Placa do Veiculo", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "condutordocumento", label = "Documento do Condutor", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "documentosoriginariosjson", label = "Documentos Originarios", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "transportesnapshotjson", label = "Snapshot Transporte", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Aberta" }, new { value = 2, display = "ProntaParaEmissao" }, new { value = 3, display = "Autorizada" }, new { value = 4, display = "Rejeitada" }, new { value = 5, display = "FalhaTecnica" },}, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Identificacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "correlationid", label = "CorrelationId", type = "string", required = false, displaygroup = "Origem", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "cargaid", label = "Carga", type = "string", required = false, displaygroup = "Operacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "ambiente", label = "Ambiente", type = "enum", required = false, displaygroup = "SEFAZ", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Producao" }, new { value = 2, display = "Homologacao" },}, },
            new { id = "ufcarregamento", label = "UF de Carregamento", type = "string", required = false, displaygroup = "Rota", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "ufdescarregamento", label = "UF de Descarregamento", type = "string", required = false, displaygroup = "Rota", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "placaveiculo", label = "Placa do Veiculo", type = "string", required = false, displaygroup = "Transporte", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "condutordocumento", label = "Documento do Condutor", type = "string", required = false, displaygroup = "Transporte", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "documentosoriginariosjson", label = "Documentos Originarios", type = "memo", required = false, displaygroup = "Snapshot", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "transportesnapshotjson", label = "Snapshot Transporte", type = "memo", required = false, displaygroup = "Snapshot", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "status", label = "Status", type = "enum", required = false, displaygroup = "Status", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Aberta" }, new { value = 2, display = "ProntaParaEmissao" }, new { value = 3, display = "Autorizada" }, new { value = 4, display = "Rejeitada" }, new { value = 5, display = "FalhaTecnica" },}, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
            create = "/MDFeSolicitacaoFiscal/PostMDFeSolicitacaoFiscal",
            read = "/MDFeSolicitacaoFiscal/ReadMDFeSolicitacaoFiscal",
            update = "/MDFeSolicitacaoFiscal/PutMDFeSolicitacaoFiscal",
            delete = "/MDFeSolicitacaoFiscal/DeleteMDFeSolicitacaoFiscal"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDataMDFeDocumentoOriginario", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "MDFeDocumentoOriginario",
        entityDescription = "Documento Originario MDF-e",
        source = new
        {
            kind = "table",
            name = "MDFeDocumentoOriginario"
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
                endpoint = "/MDFeDocumentoOriginario/ReadMDFeDocumentoOriginario",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "mdfesolicitacaofiscalid", label = "Solicitacao MDF-e", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataMDFeSolicitacaoFiscal", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "documentofiscaloriginarioid", label = "Documento Originario", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataDocumentoFiscalOriginario", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "tipodocumento", label = "Tipo Documento", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "chaveacesso", label = "Chave de Acesso", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "snapshotjson", label = "Snapshot", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "mdfesolicitacaofiscalid", label = "Solicitacao MDF-e", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataMDFeSolicitacaoFiscal", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "documentofiscaloriginarioid", label = "Documento Originario", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataDocumentoFiscalOriginario", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "tipodocumento", label = "Tipo Documento", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "chaveacesso", label = "Chave de Acesso", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "snapshotjson", label = "Snapshot", type = "memo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
                mdfesolicitacaofiscalid = "/MDFeDocumentoOriginario/MDFeDocumentoOriginarioReadFKMDFeSolicitacaoFiscalId",
                documentofiscaloriginarioid = "/MDFeDocumentoOriginario/MDFeDocumentoOriginarioReadFKDocumentoFiscalOriginarioId",
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Identificacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "mdfesolicitacaofiscalid", label = "Solicitacao MDF-e", type = "int", required = false, displaygroup = "Vinculo", isFk = true, endPontGetMetadata = "/getMetaDataMDFeSolicitacaoFiscal", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "documentofiscaloriginarioid", label = "Documento Originario", type = "int", required = false, displaygroup = "Vinculo", isFk = true, endPontGetMetadata = "/getMetaDataDocumentoFiscalOriginario", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "tipodocumento", label = "Tipo Documento", type = "string", required = false, displaygroup = "Identificacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "chaveacesso", label = "Chave de Acesso", type = "string", required = false, displaygroup = "Identificacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "snapshotjson", label = "Snapshot", type = "memo", required = false, displaygroup = "Snapshot", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
                 mdfesolicitacaofiscalid = "/MDFeDocumentoOriginario/MDFeDocumentoOriginarioReadFKMDFeSolicitacaoFiscalId",
                 documentofiscaloriginarioid = "/MDFeDocumentoOriginario/MDFeDocumentoOriginarioReadFKDocumentoFiscalOriginarioId",
            create = "/MDFeDocumentoOriginario/PostMDFeDocumentoOriginario",
            read = "/MDFeDocumentoOriginario/ReadMDFeDocumentoOriginario",
            update = "/MDFeDocumentoOriginario/PutMDFeDocumentoOriginario",
            delete = "/MDFeDocumentoOriginario/DeleteMDFeDocumentoOriginario"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDataMDFePercurso", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "MDFePercurso",
        entityDescription = "Percurso MDF-e",
        source = new
        {
            kind = "table",
            name = "MDFePercurso"
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
                endpoint = "/MDFePercurso/ReadMDFePercurso",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "mdfesolicitacaofiscalid", label = "Solicitacao MDF-e", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataMDFeSolicitacaoFiscal", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "uf", label = "UF", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "ordem", label = "Ordem", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "mdfesolicitacaofiscalid", label = "Solicitacao MDF-e", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataMDFeSolicitacaoFiscal", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "uf", label = "UF", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "ordem", label = "Ordem", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
                mdfesolicitacaofiscalid = "/MDFePercurso/MDFePercursoReadFKMDFeSolicitacaoFiscalId",
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Identificacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "mdfesolicitacaofiscalid", label = "Solicitacao MDF-e", type = "int", required = false, displaygroup = "Vinculo", isFk = true, endPontGetMetadata = "/getMetaDataMDFeSolicitacaoFiscal", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "uf", label = "UF", type = "string", required = false, displaygroup = "Percurso", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "ordem", label = "Ordem", type = "int", required = false, displaygroup = "Percurso", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
                 mdfesolicitacaofiscalid = "/MDFePercurso/MDFePercursoReadFKMDFeSolicitacaoFiscalId",
            create = "/MDFePercurso/PostMDFePercurso",
            read = "/MDFePercurso/ReadMDFePercurso",
            update = "/MDFePercurso/PutMDFePercurso",
            delete = "/MDFePercurso/DeleteMDFePercurso"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDataMDFeVeiculo", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "MDFeVeiculo",
        entityDescription = "Veiculo MDF-e",
        source = new
        {
            kind = "table",
            name = "MDFeVeiculo"
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
                endpoint = "/MDFeVeiculo/ReadMDFeVeiculo",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "mdfesolicitacaofiscalid", label = "Solicitacao MDF-e", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataMDFeSolicitacaoFiscal", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "placa", label = "Placa", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "renavam", label = "Renavam", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "tara", label = "Tara", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "capacidadekg", label = "Capacidade KG", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "capacidadem3", label = "Capacidade M3", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "mdfesolicitacaofiscalid", label = "Solicitacao MDF-e", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataMDFeSolicitacaoFiscal", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "placa", label = "Placa", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "renavam", label = "Renavam", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "tara", label = "Tara", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "capacidadekg", label = "Capacidade KG", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "capacidadem3", label = "Capacidade M3", type = "Decimal", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
                mdfesolicitacaofiscalid = "/MDFeVeiculo/MDFeVeiculoReadFKMDFeSolicitacaoFiscalId",
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Identificacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "mdfesolicitacaofiscalid", label = "Solicitacao MDF-e", type = "int", required = false, displaygroup = "Vinculo", isFk = true, endPontGetMetadata = "/getMetaDataMDFeSolicitacaoFiscal", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "placa", label = "Placa", type = "string", required = false, displaygroup = "Veiculo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "renavam", label = "Renavam", type = "string", required = false, displaygroup = "Veiculo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "tara", label = "Tara", type = "Decimal", required = false, displaygroup = "Veiculo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "capacidadekg", label = "Capacidade KG", type = "Decimal", required = false, displaygroup = "Veiculo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "capacidadem3", label = "Capacidade M3", type = "Decimal", required = false, displaygroup = "Veiculo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
                 mdfesolicitacaofiscalid = "/MDFeVeiculo/MDFeVeiculoReadFKMDFeSolicitacaoFiscalId",
            create = "/MDFeVeiculo/PostMDFeVeiculo",
            read = "/MDFeVeiculo/ReadMDFeVeiculo",
            update = "/MDFeVeiculo/PutMDFeVeiculo",
            delete = "/MDFeVeiculo/DeleteMDFeVeiculo"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDataMDFeCondutor", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "MDFeCondutor",
        entityDescription = "Condutor MDF-e",
        source = new
        {
            kind = "table",
            name = "MDFeCondutor"
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
                endpoint = "/MDFeCondutor/ReadMDFeCondutor",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "mdfesolicitacaofiscalid", label = "Solicitacao MDF-e", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataMDFeSolicitacaoFiscal", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "nome", label = "Nome", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "documento", label = "Documento", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "mdfesolicitacaofiscalid", label = "Solicitacao MDF-e", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataMDFeSolicitacaoFiscal", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "nome", label = "Nome", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "documento", label = "Documento", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
                mdfesolicitacaofiscalid = "/MDFeCondutor/MDFeCondutorReadFKMDFeSolicitacaoFiscalId",
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Identificacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "mdfesolicitacaofiscalid", label = "Solicitacao MDF-e", type = "int", required = false, displaygroup = "Vinculo", isFk = true, endPontGetMetadata = "/getMetaDataMDFeSolicitacaoFiscal", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "nome", label = "Nome", type = "string", required = false, displaygroup = "Condutor", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "documento", label = "Documento", type = "string", required = false, displaygroup = "Condutor", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
                 mdfesolicitacaofiscalid = "/MDFeCondutor/MDFeCondutorReadFKMDFeSolicitacaoFiscalId",
            create = "/MDFeCondutor/PostMDFeCondutor",
            read = "/MDFeCondutor/ReadMDFeCondutor",
            update = "/MDFeCondutor/PutMDFeCondutor",
            delete = "/MDFeCondutor/DeleteMDFeCondutor"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDataMDFeTentativaEmissao", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "MDFeTentativaEmissao",
        entityDescription = "Tentativa de Emissao MDF-e",
        source = new
        {
            kind = "table",
            name = "MDFeTentativaEmissao"
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
                endpoint = "/MDFeTentativaEmissao/ReadMDFeTentativaEmissao",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "mdfesolicitacaofiscalid", label = "Solicitacao MDF-e", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataMDFeSolicitacaoFiscal", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "chaveacesso", label = "Chave de Acesso", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "numero", label = "Numero", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "serie", label = "Serie", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "tentativa", label = "Tentativa", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "xmlassinadostoragekey", label = "XML Assinado", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "xmlprocstoragekey", label = "procMDFe", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "xmlhash", label = "Hash XML", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "codigoretorno", label = "cStat", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "mensagemretorno", label = "xMotivo", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "protocoloautorizacao", label = "Protocolo", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "enviadoemutc", label = "Enviado em UTC", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "autorizadoemutc", label = "Autorizado em UTC", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status da Emissao", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Pendente" }, new { value = 2, display = "Enviado" }, new { value = 3, display = "Autorizado" }, new { value = 4, display = "Rejeitado" }, new { value = 5, display = "FalhaTecnica" },}, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "mdfesolicitacaofiscalid", label = "Solicitacao MDF-e", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataMDFeSolicitacaoFiscal", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "chaveacesso", label = "Chave de Acesso", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "numero", label = "Numero", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "serie", label = "Serie", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "tentativa", label = "Tentativa", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "xmlassinadostoragekey", label = "XML Assinado", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "xmlprocstoragekey", label = "procMDFe", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "xmlhash", label = "Hash XML", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "codigoretorno", label = "cStat", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "mensagemretorno", label = "xMotivo", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "protocoloautorizacao", label = "Protocolo", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "enviadoemutc", label = "Enviado em UTC", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "autorizadoemutc", label = "Autorizado em UTC", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status da Emissao", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Pendente" }, new { value = 2, display = "Enviado" }, new { value = 3, display = "Autorizado" }, new { value = 4, display = "Rejeitado" }, new { value = 5, display = "FalhaTecnica" },}, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
                mdfesolicitacaofiscalid = "/MDFeTentativaEmissao/MDFeTentativaEmissaoReadFKMDFeSolicitacaoFiscalId",
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Identificacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "mdfesolicitacaofiscalid", label = "Solicitacao MDF-e", type = "int", required = false, displaygroup = "Vinculo", isFk = true, endPontGetMetadata = "/getMetaDataMDFeSolicitacaoFiscal", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "chaveacesso", label = "Chave de Acesso", type = "string", required = false, displaygroup = "Identificacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "numero", label = "Numero", type = "int", required = false, displaygroup = "Identificacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "serie", label = "Serie", type = "int", required = false, displaygroup = "Identificacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "tentativa", label = "Tentativa", type = "int", required = false, displaygroup = "Operacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "xmlassinadostoragekey", label = "XML Assinado", type = "string", required = false, displaygroup = "Arquivos", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "xmlprocstoragekey", label = "procMDFe", type = "string", required = false, displaygroup = "Arquivos", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "xmlhash", label = "Hash XML", type = "string", required = false, displaygroup = "Arquivos", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "codigoretorno", label = "cStat", type = "string", required = false, displaygroup = "SEFAZ", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "mensagemretorno", label = "xMotivo", type = "string", required = false, displaygroup = "SEFAZ", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "protocoloautorizacao", label = "Protocolo", type = "string", required = false, displaygroup = "SEFAZ", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "enviadoemutc", label = "Enviado em UTC", type = "DateTime", required = false, displaygroup = "SEFAZ", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "autorizadoemutc", label = "Autorizado em UTC", type = "DateTime", required = false, displaygroup = "SEFAZ", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "status", label = "Status da Emissao", type = "enum", required = false, displaygroup = "Status", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Pendente" }, new { value = 2, display = "Enviado" }, new { value = 3, display = "Autorizado" }, new { value = 4, display = "Rejeitado" }, new { value = 5, display = "FalhaTecnica" },}, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
                 mdfesolicitacaofiscalid = "/MDFeTentativaEmissao/MDFeTentativaEmissaoReadFKMDFeSolicitacaoFiscalId",
            create = "/MDFeTentativaEmissao/PostMDFeTentativaEmissao",
            read = "/MDFeTentativaEmissao/ReadMDFeTentativaEmissao",
            update = "/MDFeTentativaEmissao/PutMDFeTentativaEmissao",
            delete = "/MDFeTentativaEmissao/DeleteMDFeTentativaEmissao"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDataMDFeEncerramento", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "MDFeEncerramento",
        entityDescription = "Encerramento MDF-e",
        source = new
        {
            kind = "table",
            name = "MDFeEncerramento"
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
                endpoint = "/MDFeEncerramento/ReadMDFeEncerramento",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "mdfeid", label = "MDF-e", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataMDFe", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "chaveacesso", label = "Chave de Acesso", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "ufcarregamento", label = "UF de Carregamento", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "ufdescarregamento", label = "UF de Descarregamento", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "placaveiculo", label = "Placa do Veiculo", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "solicitadoem", label = "Solicitado em", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "autorizadoem", label = "Autorizado em", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "protocolo", label = "Protocolo SEFAZ", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "codigoretorno", label = "Codigo de Retorno", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "mensagemretorno", label = "Mensagem de Retorno", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "mdfeid", label = "MDF-e", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataMDFe", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "chaveacesso", label = "Chave de Acesso", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "ufcarregamento", label = "UF de Carregamento", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "ufdescarregamento", label = "UF de Descarregamento", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "placaveiculo", label = "Placa do Veiculo", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "solicitadoem", label = "Solicitado em", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "autorizadoem", label = "Autorizado em", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "protocolo", label = "Protocolo SEFAZ", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "codigoretorno", label = "Codigo de Retorno", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "mensagemretorno", label = "Mensagem de Retorno", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
                mdfeid = "/MDFeEncerramento/MDFeEncerramentoReadFKMDFeId",
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "mdfeid", label = "MDF-e", type = "int", required = false, displaygroup = "Geral", isFk = true, endPontGetMetadata = "/getMetaDataMDFe", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "chaveacesso", label = "Chave de Acesso", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "ufcarregamento", label = "UF de Carregamento", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "ufdescarregamento", label = "UF de Descarregamento", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "placaveiculo", label = "Placa do Veiculo", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "solicitadoem", label = "Solicitado em", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "autorizadoem", label = "Autorizado em", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "protocolo", label = "Protocolo SEFAZ", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "codigoretorno", label = "Codigo de Retorno", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "mensagemretorno", label = "Mensagem de Retorno", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
                 mdfeid = "/MDFeEncerramento/MDFeEncerramentoReadFKMDFeId",
            create = "/MDFeEncerramento/PostMDFeEncerramento",
            read = "/MDFeEncerramento/ReadMDFeEncerramento",
            update = "/MDFeEncerramento/PutMDFeEncerramento",
            delete = "/MDFeEncerramento/DeleteMDFeEncerramento"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDataSefazEndpoint", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "SefazEndpoint",
        entityDescription = "Endpoint SEFAZ",
        source = new
        {
            kind = "table",
            name = "SefazEndpoint"
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
                endpoint = "/SefazEndpoint/ReadSefazEndpoint",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "produtofiscal", label = "Produto Fiscal", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 55, display = "NFe" }, new { value = 57, display = "CTe" }, new { value = 58, display = "MDFe" },}, },
                new { id = "uf", label = "UF", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "ambiente", label = "Ambiente", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Producao" }, new { value = 2, display = "Homologacao" },}, },
                new { id = "servico", label = "Servico", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "versao", label = "Versao", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "url", label = "URL", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "ativo", label = "Ativo", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "Nao" }, new { value = 1, display = "Sim" },}, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "produtofiscal", label = "Produto Fiscal", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 55, display = "NFe" }, new { value = 57, display = "CTe" }, new { value = 58, display = "MDFe" },}, },
                new { id = "uf", label = "UF", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "ambiente", label = "Ambiente", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Producao" }, new { value = 2, display = "Homologacao" },}, },
                new { id = "servico", label = "Servico", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "versao", label = "Versao", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "url", label = "URL", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "ativo", label = "Ativo", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "Nao" }, new { value = 1, display = "Sim" },}, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Identificacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "produtofiscal", label = "Produto Fiscal", type = "enum", required = false, displaygroup = "Servico", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 55, display = "NFe" }, new { value = 57, display = "CTe" }, new { value = 58, display = "MDFe" },}, },
            new { id = "uf", label = "UF", type = "string", required = false, displaygroup = "Servico", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "ambiente", label = "Ambiente", type = "enum", required = false, displaygroup = "Servico", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Producao" }, new { value = 2, display = "Homologacao" },}, },
            new { id = "servico", label = "Servico", type = "string", required = false, displaygroup = "Servico", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "versao", label = "Versao", type = "string", required = false, displaygroup = "Servico", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "url", label = "URL", type = "string", required = false, displaygroup = "Servico", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "ativo", label = "Ativo", type = "enum", required = false, displaygroup = "Status", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "Nao" }, new { value = 1, display = "Sim" },}, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
            create = "/SefazEndpoint/PostSefazEndpoint",
            read = "/SefazEndpoint/ReadSefazEndpoint",
            update = "/SefazEndpoint/PutSefazEndpoint",
            delete = "/SefazEndpoint/DeleteSefazEndpoint"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDataCertificadoDigital", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "CertificadoDigital",
        entityDescription = "Certificado Digital",
        source = new
        {
            kind = "table",
            name = "CertificadoDigital"
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
                endpoint = "/CertificadoDigital/ReadCertificadoDigital",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "apelido", label = "Apelido", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "documentotitular", label = "Documento Titular", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "storagekey", label = "Arquivo", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "thumbprint", label = "Thumbprint", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "validode", label = "Valido de", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "validoate", label = "Valido ate", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "ativo", label = "Ativo", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "Nao" }, new { value = 1, display = "Sim" },}, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "apelido", label = "Apelido", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "documentotitular", label = "Documento Titular", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "storagekey", label = "Arquivo", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "thumbprint", label = "Thumbprint", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "validode", label = "Valido de", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "validoate", label = "Valido ate", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "ativo", label = "Ativo", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "Nao" }, new { value = 1, display = "Sim" },}, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Identificacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "apelido", label = "Apelido", type = "string", required = false, displaygroup = "Identificacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "documentotitular", label = "Documento Titular", type = "string", required = false, displaygroup = "Titular", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "storagekey", label = "Arquivo", type = "string", required = false, displaygroup = "Arquivo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "thumbprint", label = "Thumbprint", type = "string", required = false, displaygroup = "Arquivo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "validode", label = "Valido de", type = "DateTime", required = false, displaygroup = "Validade", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "validoate", label = "Valido ate", type = "DateTime", required = false, displaygroup = "Validade", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "ativo", label = "Ativo", type = "enum", required = false, displaygroup = "Status", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "Nao" }, new { value = 1, display = "Sim" },}, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
            create = "/CertificadoDigital/PostCertificadoDigital",
            read = "/CertificadoDigital/ReadCertificadoDigital",
            update = "/CertificadoDigital/PutCertificadoDigital",
            delete = "/CertificadoDigital/DeleteCertificadoDigital"
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
app.MapGet("/yapi/getMetaDatayToken", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "yToken",
        entityDescription = "yToken",
        source = new
        {
            kind = "table",
            name = "yToken"
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
                endpoint = "/yToken/ReadyToken",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "tokenhash", label = "Hash do Token", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "description", label = "Descricao", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "connectorkey", label = "Conector", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "active", label = "Ativo", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "validuntil", label = "Valido ate", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "createdat", label = "Criado em", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "lastusedat", label = "Ultimo uso", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "tokenhash", label = "Hash do Token", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "description", label = "Descricao", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "connectorkey", label = "Conector", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "active", label = "Ativo", type = "bool", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "validuntil", label = "Valido ate", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "createdat", label = "Criado em", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "lastusedat", label = "Ultimo uso", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
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
            new { id = "tokenhash", label = "Hash do Token", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "description", label = "Descricao", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "connectorkey", label = "Conector", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "active", label = "Ativo", type = "bool", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "validuntil", label = "Valido ate", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "createdat", label = "Criado em", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "lastusedat", label = "Ultimo uso", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
            create = "/yToken/PostyToken",
            read = "/yToken/ReadyToken",
            update = "/yToken/PutyToken",
            delete = "/yToken/DeleteyToken"
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
app.MapPost("/yapi/Fiscal/EntradaReceberNotasFiscaisProdutoUseCase", async ([FromServices] Command.Receivers.UseCase.ReceberNotasFiscaisProdutoHandler receiver, [FromBody] Command.UseCase.ReceberNotasFiscaisProdutoInputCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/Fiscal/CTeReceberRomaneioConsolidadoParaCTeUseCase", async ([FromServices] Command.Receivers.UseCase.ReceberRomaneioConsolidadoParaCTeHandler receiver, [FromBody] Command.UseCase.ReceberRomaneioConsolidadoParaCTeInputCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/Fiscal/CTeSolicitarEmissaoCTeUseCase", async ([FromServices] Command.Receivers.UseCase.SolicitarEmissaoCTeHandler receiver, [FromBody] Command.UseCase.SolicitarEmissaoCTeInputCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/Fiscal/CTeAutorizarCTeUseCase", async ([FromServices] Command.Receivers.UseCase.AutorizarCTeHandler receiver, [FromBody] Command.UseCase.AutorizarCTeInputCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/Fiscal/CTePublicarCTeAutorizadoParaMDFeUseCase", async ([FromServices] Command.Receivers.UseCase.PublicarCTeAutorizadoParaMDFeHandler receiver, [FromBody] Command.UseCase.PublicarCTeAutorizadoParaMDFeInputCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/Fiscal/MDFeSolicitarEmissaoMDFeUseCase", async ([FromServices] Command.Receivers.UseCase.SolicitarEmissaoMDFeHandler receiver, [FromBody] Command.UseCase.SolicitarEmissaoMDFeInputCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/Fiscal/MDFeAutorizarMDFeUseCase", async ([FromServices] Command.Receivers.UseCase.AutorizarMDFeHandler receiver, [FromBody] Command.UseCase.AutorizarMDFeInputCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/Fiscal/MDFeEncerrarMDFeUseCase", async ([FromServices] Command.Receivers.UseCase.EncerrarMDFeHandler receiver, [FromBody] Command.UseCase.EncerrarMDFeInputCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/Fiscal/SEFAZValidarCertificadoDigitalUseCase", async ([FromServices] Command.Receivers.UseCase.ValidarCertificadoDigitalHandler receiver, [FromBody] Command.UseCase.ValidarCertificadoDigitalInputCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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


app.MapPost("/yapi/FileUpload/InfraStarSessionUploadUseCase", async ([FromServices] Command.Receivers.UseCase.StarSessionUploadHandler receiver, [FromBody] Command.UseCase.StarSessionUploadInputCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
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
var result = await receiver.ExecuteAsync(command);
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
var result = await receiver.ExecuteAsync(command);
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
var result = await receiver.ExecuteAsync(command);
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
var result = await receiver.ExecuteAsync(command);
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