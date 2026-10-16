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
using System.Text.Json;
using System.Text;
using Shared.Operational;
using Shared.ModuleTransport;
namespace API.Migrations
{
public static class Endpoints
{
public static void MapEndpoints(this WebApplication app)
{
app.MapGet("/yapi/operational/identity", ([FromServices] IRuntimeIdentityProvider identityProvider) =>
    Results.Ok(identityProvider.Current))
    .AllowAnonymous();

app.MapPut("/yapi/operational/logging-policy", ([FromServices] Yeshua.Generated.OperationalControl.OperationalLoggingPolicyState policyState, [FromBody] Yeshua.Generated.OperationalControl.OperationalLoggingPolicyUpdate update) =>
{
    try
    {
        return Results.Ok(policyState.ApplyLocal(update));
    }
    catch (ArgumentException exception)
    {
        return Results.BadRequest(new { error = exception.Message });
    }
})
    .RequireAuthorization();

app.MapGet("/yapi/operational/catalog", ([FromServices] IRuntimeIdentityProvider identityProvider) =>
    Results.Ok(new
    {
        application = identityProvider.Current.Application,
        components = new[]
        {
            new { id = "Command", title = "Commands", description = "Execucao, falha e duracao dos commands." },
            new { id = "Saga", title = "Sagas", description = "Execucao e transicao dos steps de saga." },
            new { id = "RepositoryCounters", title = "Repositorios - contadores", description = "Contadores e tempos agregados de acesso a dados." },
            new { id = "RepositoryEvents", title = "Repositorios - eventos", description = "Eventos detalhados das operacoes de repositorio." },
            new { id = "ExternalCallEvents", title = "Chamadas externas", description = "Duracao e resultado de integracoes externas, sem conteudo sensivel." },
            new { id = "DomainTracker", title = "Rastreamento de dominio", description = "Alteracoes das entidades e campos selecionados." }
        },
        entities = new object[]
        {
            new
            {
                name = "Album",
                title = "Album",
                fields = new[]
                {
                    new { name = "Id", title = "ID", classification = "Internal" },
                    new { name = "Titulo", title = "Titulo", classification = "Internal" },
                    new { name = "Descricao", title = "Descricao", classification = "Internal" },
                    new { name = "Privacidade", title = "Privacidade no YouTube", classification = "Internal" },
                    new { name = "SegundosPorFoto", title = "Segundos por Foto", classification = "Internal" },
                    new { name = "QualidadeVideo", title = "Qualidade do Video", classification = "Internal" },
                    new { name = "ModeloVideo", title = "Modelo do Video", classification = "Internal" },
                    new { name = "MusicaId", title = "Musica", classification = "Internal" },
                    new { name = "VolumeMusica", title = "Volume da Musica (%)", classification = "Internal" },
                    new { name = "Status", title = "Status", classification = "Internal" },
                    new { name = "TenantID", title = "TenantID", classification = "Internal" },
                    new { name = "Deleted", title = "Deleted", classification = "Internal" },
                    new { name = "Changed", title = "Changed", classification = "Internal" },
                    new { name = "UserId", title = "User ID", classification = "Internal" },
                    new { name = "OperationalEntityId", title = "Identificador operacional", classification = "Internal" },
                }
            },
            new
            {
                name = "AlbumFoto",
                title = "Foto do Album",
                fields = new[]
                {
                    new { name = "Id", title = "ID", classification = "Internal" },
                    new { name = "AlbumId", title = "Album", classification = "Internal" },
                    new { name = "FotoId", title = "Foto", classification = "Internal" },
                    new { name = "Ordem", title = "Ordem", classification = "Internal" },
                    new { name = "Legenda", title = "Legenda", classification = "Internal" },
                    new { name = "Rotacao", title = "Rotacao da Foto", classification = "Internal" },
                    new { name = "TenantID", title = "TenantID", classification = "Internal" },
                    new { name = "Deleted", title = "Deleted", classification = "Internal" },
                    new { name = "Changed", title = "Changed", classification = "Internal" },
                    new { name = "UserId", title = "User ID", classification = "Internal" },
                    new { name = "OperationalEntityId", title = "Identificador operacional", classification = "Internal" },
                }
            },
            new
            {
                name = "Foto",
                title = "Foto",
                fields = new[]
                {
                    new { name = "Id", title = "ID", classification = "Internal" },
                    new { name = "StorageKey", title = "Arquivo", classification = "Internal" },
                    new { name = "NomeOriginal", title = "Nome Original", classification = "Confidential" },
                    new { name = "ContentType", title = "Tipo do Arquivo", classification = "Internal" },
                    new { name = "HashArquivo", title = "Hash", classification = "Internal" },
                    new { name = "CapturadaEmUtc", title = "Capturada em UTC", classification = "Internal" },
                    new { name = "Largura", title = "Largura", classification = "Internal" },
                    new { name = "Altura", title = "Altura", classification = "Internal" },
                    new { name = "Status", title = "Status", classification = "Internal" },
                    new { name = "TenantID", title = "TenantID", classification = "Internal" },
                    new { name = "Deleted", title = "Deleted", classification = "Internal" },
                    new { name = "Changed", title = "Changed", classification = "Internal" },
                    new { name = "UserId", title = "User ID", classification = "Internal" },
                    new { name = "OperationalEntityId", title = "Identificador operacional", classification = "Internal" },
                }
            },
            new
            {
                name = "PublicacaoAlbum",
                title = "Publicacao do Album",
                fields = new[]
                {
                    new { name = "Id", title = "ID", classification = "Internal" },
                    new { name = "AlbumId", title = "Album", classification = "Internal" },
                    new { name = "CorrelationId", title = "CorrelationId", classification = "Internal" },
                    new { name = "ManifestStorageKey", title = "Manifesto de Renderizacao", classification = "Internal" },
                    new { name = "VideoStorageKey", title = "Video Renderizado", classification = "Internal" },
                    new { name = "YouTubeVideoId", title = "Video no YouTube", classification = "Internal" },
                    new { name = "YouTubeUrl", title = "URL no YouTube", classification = "Internal" },
                    new { name = "ConexaoYouTubeId", title = "Conexao YouTube", classification = "Internal" },
                    new { name = "CanalYouTubeId", title = "Canal de Destino", classification = "Internal" },
                    new { name = "YouTubeCredentialTenantId", title = "Tenant da Conexao", classification = "Internal" },
                    new { name = "CanalStandardId", title = "Destino automatico", classification = "Internal" },
                    new { name = "PrivacidadeYouTube", title = "Visibilidade solicitada", classification = "Internal" },
                    new { name = "QualidadeVideo", title = "Qualidade do Video", classification = "Internal" },
                    new { name = "ModeloVideo", title = "Modelo do Video", classification = "Internal" },
                    new { name = "MusicaId", title = "Musica", classification = "Internal" },
                    new { name = "VolumeMusica", title = "Volume da Musica (%)", classification = "Internal" },
                    new { name = "Mensagem", title = "Mensagem", classification = "Internal" },
                    new { name = "SolicitadaEmUtc", title = "Solicitada em UTC", classification = "Internal" },
                    new { name = "PublicadaEmUtc", title = "Publicada em UTC", classification = "Internal" },
                    new { name = "Status", title = "Status", classification = "Internal" },
                    new { name = "TenantID", title = "TenantID", classification = "Internal" },
                    new { name = "Deleted", title = "Deleted", classification = "Internal" },
                    new { name = "Changed", title = "Changed", classification = "Internal" },
                    new { name = "UserId", title = "User ID", classification = "Internal" },
                    new { name = "OperationalEntityId", title = "Identificador operacional", classification = "Internal" },
                }
            },
            new
            {
                name = "yConfigArcteture",
                title = "yConfigArcteture",
                fields = new[]
                {
                    new { name = "Id", title = "ID", classification = "Internal" },
                    new { name = "AuditTrackerActived", title = "AuditTrackerActived", classification = "Internal" },
                    new { name = "AuditCRUDActived", title = "AuditCRUDActived", classification = "Internal" },
                    new { name = "TenantID", title = "TenantID", classification = "Internal" },
                    new { name = "Deleted", title = "Deleted", classification = "Internal" },
                    new { name = "Changed", title = "Changed", classification = "Internal" },
                    new { name = "UserId", title = "User ID", classification = "Internal" },
                    new { name = "OperationalEntityId", title = "Identificador operacional", classification = "Internal" },
                }
            },
            new
            {
                name = "yConfigNotification",
                title = "yConfigNotification",
                fields = new[]
                {
                    new { name = "Id", title = "ID", classification = "Internal" },
                    new { name = "TenantID", title = "TenantID", classification = "Internal" },
                    new { name = "EmailSmtpClient", title = "EmailSmtpClient", classification = "Confidential" },
                    new { name = "EmailPort", title = "EmailPort", classification = "Confidential" },
                    new { name = "EmailUserName", title = "EmailUserName", classification = "Confidential" },
                    new { name = "EmailPassword", title = "EmailPassword", classification = "NeverCapture" },
                    new { name = "Deleted", title = "Deleted", classification = "Internal" },
                    new { name = "Changed", title = "Changed", classification = "Internal" },
                    new { name = "UserId", title = "User ID", classification = "Internal" },
                    new { name = "OperationalEntityId", title = "Identificador operacional", classification = "Internal" },
                }
            },
            new
            {
                name = "yFileUpload",
                title = "yFileUpload",
                fields = new[]
                {
                    new { name = "Id", title = "ID", classification = "Internal" },
                    new { name = "Type", title = "Tipo do Arquivo", classification = "Internal" },
                    new { name = "Status", title = "Status do Upload", classification = "Internal" },
                    new { name = "FilePath", title = "Caminho do Arquivo", classification = "Internal" },
                    new { name = "FileSize", title = "Tamanho do Arquivo", classification = "Internal" },
                    new { name = "EntityType", title = "Entity Type", classification = "Internal" },
                    new { name = "EntityId", title = "Entity Id", classification = "Internal" },
                    new { name = "CreatedAt", title = "Criado em", classification = "Internal" },
                    new { name = "CompletedAt", title = "Finalizado em", classification = "Internal" },
                    new { name = "TenantID", title = "TenantID", classification = "Internal" },
                    new { name = "Deleted", title = "Deleted", classification = "Internal" },
                    new { name = "Changed", title = "Changed", classification = "Internal" },
                    new { name = "UserId", title = "User ID", classification = "Internal" },
                    new { name = "OperationalEntityId", title = "Identificador operacional", classification = "Internal" },
                }
            },
            new
            {
                name = "yGrant",
                title = "yGrant",
                fields = new[]
                {
                    new { name = "Id", title = "ID", classification = "Internal" },
                    new { name = "Description", title = "Descrição", classification = "Internal" },
                    new { name = "TenantID", title = "TenantID", classification = "Internal" },
                    new { name = "Deleted", title = "Deleted", classification = "Internal" },
                    new { name = "Changed", title = "Changed", classification = "Internal" },
                    new { name = "UserId", title = "User ID", classification = "Internal" },
                    new { name = "OperationalEntityId", title = "Identificador operacional", classification = "Internal" },
                }
            },
            new
            {
                name = "yInbox",
                title = "yInbox",
                fields = new[]
                {
                    new { name = "Id", title = "ID", classification = "Internal" },
                    new { name = "MessageId", title = "Message Id", classification = "Internal" },
                    new { name = "Type", title = "Tipo da Mensagem", classification = "Internal" },
                    new { name = "EntityType", title = "Entity Type", classification = "Internal" },
                    new { name = "EntityId", title = "Entity Id", classification = "Internal" },
                    new { name = "CorrelationId", title = "Correlation Id", classification = "Internal" },
                    new { name = "Payload", title = "Payload", classification = "Internal" },
                    new { name = "Status", title = "Status", classification = "Internal" },
                    new { name = "CreatedAt", title = "Criado em", classification = "Internal" },
                    new { name = "RetryCount", title = "Tentativas", classification = "Internal" },
                    new { name = "LastError", title = "Último Erro", classification = "Internal" },
                    new { name = "ProcessingAt", title = "Processando em", classification = "Internal" },
                    new { name = "NextAttemptAt", title = "Próxima tentativa", classification = "Internal" },
                    new { name = "RootOperationId", title = "Operacao raiz", classification = "Internal" },
                    new { name = "OperationId", title = "Operacao logica", classification = "Internal" },
                    new { name = "ExecutionId", title = "Tentativa de execucao", classification = "Internal" },
                    new { name = "CausationId", title = "Execucao causadora", classification = "Internal" },
                    new { name = "SagaId", title = "SagaId", classification = "Internal" },
                    new { name = "SagaStepId", title = "SagaStepId", classification = "Internal" },
                    new { name = "ProcessingScope", title = "Escopo de processamento", classification = "Internal" },
                    new { name = "TenantID", title = "TenantID", classification = "Internal" },
                    new { name = "Deleted", title = "Deleted", classification = "Internal" },
                    new { name = "Changed", title = "Changed", classification = "Internal" },
                    new { name = "UserId", title = "User ID", classification = "Internal" },
                    new { name = "OperationalEntityId", title = "Identificador operacional", classification = "Internal" },
                }
            },
            new
            {
                name = "yModule",
                title = "yModule",
                fields = new[]
                {
                    new { name = "Id", title = "ID", classification = "Internal" },
                    new { name = "Description", title = "Descrição", classification = "Internal" },
                }
            },
            new
            {
                name = "yOutbox",
                title = "yOutbox",
                fields = new[]
                {
                    new { name = "Id", title = "ID", classification = "Internal" },
                    new { name = "MessageId", title = "Message Id", classification = "Internal" },
                    new { name = "Type", title = "Tipo da Mensagem", classification = "Internal" },
                    new { name = "EntityType", title = "Entity Type", classification = "Internal" },
                    new { name = "EntityId", title = "Entity Id", classification = "Internal" },
                    new { name = "CorrelationId", title = "Correlation Id", classification = "Internal" },
                    new { name = "Payload", title = "Payload", classification = "Internal" },
                    new { name = "Status", title = "Status", classification = "Internal" },
                    new { name = "TransportType", title = "Tipo de Transporte", classification = "Internal" },
                    new { name = "TransportData", title = "Dados do transporte", classification = "Internal" },
                    new { name = "CreatedAt", title = "Criado em", classification = "Internal" },
                    new { name = "SentAt", title = "Enviado em", classification = "Internal" },
                    new { name = "RetryCount", title = "Tentativas", classification = "Internal" },
                    new { name = "LastError", title = "Último Erro", classification = "Internal" },
                    new { name = "ProcessingAt", title = "Processando em", classification = "Internal" },
                    new { name = "NextAttemptAt", title = "Próxima tentativa", classification = "Internal" },
                    new { name = "RootOperationId", title = "Operacao raiz", classification = "Internal" },
                    new { name = "OperationId", title = "Operacao logica", classification = "Internal" },
                    new { name = "ExecutionId", title = "Tentativa de execucao", classification = "Internal" },
                    new { name = "CausationId", title = "Execucao causadora", classification = "Internal" },
                    new { name = "SagaId", title = "SagaId", classification = "Internal" },
                    new { name = "SagaStepId", title = "SagaStepId", classification = "Internal" },
                    new { name = "ProcessingScope", title = "Escopo de processamento", classification = "Internal" },
                    new { name = "TenantID", title = "TenantID", classification = "Internal" },
                    new { name = "Deleted", title = "Deleted", classification = "Internal" },
                    new { name = "Changed", title = "Changed", classification = "Internal" },
                    new { name = "UserId", title = "User ID", classification = "Internal" },
                    new { name = "OperationalEntityId", title = "Identificador operacional", classification = "Internal" },
                }
            },
            new
            {
                name = "yPerfil",
                title = "yPerfil",
                fields = new[]
                {
                    new { name = "Id", title = "ID", classification = "Internal" },
                    new { name = "Description", title = "Descrição", classification = "Internal" },
                    new { name = "TenantID", title = "TenantID", classification = "Internal" },
                    new { name = "Deleted", title = "Deleted", classification = "Internal" },
                    new { name = "Changed", title = "Changed", classification = "Internal" },
                    new { name = "UserId", title = "User ID", classification = "Internal" },
                    new { name = "OperationalEntityId", title = "Identificador operacional", classification = "Internal" },
                }
            },
            new
            {
                name = "yPerfilGrant",
                title = "yPerfilGrant",
                fields = new[]
                {
                    new { name = "Id", title = "ID", classification = "Internal" },
                    new { name = "PerfilId", title = "ID Perfil", classification = "Internal" },
                    new { name = "GrantId", title = "ID Permição", classification = "Internal" },
                    new { name = "CanGrant", title = "Permite acessar", classification = "Internal" },
                    new { name = "CanCreate", title = "Permite Criar", classification = "Internal" },
                    new { name = "CanRead", title = "Permite Ler", classification = "Internal" },
                    new { name = "CanUpdate", title = "Permite Atualizar", classification = "Internal" },
                    new { name = "CanDelete", title = "Permite Deletar", classification = "Internal" },
                    new { name = "ValidUntil", title = "Valido ate", classification = "Internal" },
                    new { name = "TenantID", title = "TenantID", classification = "Internal" },
                    new { name = "Deleted", title = "Deleted", classification = "Internal" },
                    new { name = "Changed", title = "Changed", classification = "Internal" },
                    new { name = "UserId", title = "User ID", classification = "Internal" },
                    new { name = "OperationalEntityId", title = "Identificador operacional", classification = "Internal" },
                }
            },
            new
            {
                name = "ySaga",
                title = "ySaga",
                fields = new[]
                {
                    new { name = "Id", title = "ID", classification = "Internal" },
                    new { name = "CorrelationId", title = "CorrelationId", classification = "Internal" },
                    new { name = "Type", title = "Type", classification = "Internal" },
                    new { name = "Status", title = "Status", classification = "Internal" },
                    new { name = "KeyCurrentStep", title = "Key Step Atual", classification = "Internal" },
                    new { name = "CreatedAt", title = "Criado em", classification = "Internal" },
                    new { name = "CompletedAt", title = "Finalizado em", classification = "Internal" },
                    new { name = "EntityType", title = "Entity Type", classification = "Internal" },
                    new { name = "EntityId", title = "Entity Id", classification = "Internal" },
                    new { name = "NextExecutionAt", title = "Proxima execucao", classification = "Internal" },
                    new { name = "LockedAt", title = "LockedAt", classification = "Internal" },
                    new { name = "LockedBy", title = "LockedBy", classification = "Internal" },
                    new { name = "RootOperationId", title = "Operacao raiz", classification = "Internal" },
                    new { name = "OperationId", title = "Operacao logica", classification = "Internal" },
                    new { name = "ExecutionId", title = "Tentativa de execucao", classification = "Internal" },
                    new { name = "CausationId", title = "Execucao causadora", classification = "Internal" },
                    new { name = "ProcessingScope", title = "Escopo de processamento", classification = "Internal" },
                    new { name = "TenantID", title = "TenantID", classification = "Internal" },
                    new { name = "Deleted", title = "Deleted", classification = "Internal" },
                    new { name = "Changed", title = "Changed", classification = "Internal" },
                    new { name = "UserId", title = "User ID", classification = "Internal" },
                    new { name = "OperationalEntityId", title = "Identificador operacional", classification = "Internal" },
                }
            },
            new
            {
                name = "ySagaStep",
                title = "ySagaStep",
                fields = new[]
                {
                    new { name = "Id", title = "ID", classification = "Internal" },
                    new { name = "SagaId", title = "Saga", classification = "Internal" },
                    new { name = "StepKey", title = "Step Key", classification = "Internal" },
                    new { name = "IndexOrder", title = "Index Order", classification = "Internal" },
                    new { name = "CorrelationId", title = "CorrelationId", classification = "Internal" },
                    new { name = "Status", title = "Status", classification = "Internal" },
                    new { name = "ExecutionCount", title = "Execuções", classification = "Internal" },
                    new { name = "LastExecutionAt", title = "Última Execução", classification = "Internal" },
                    new { name = "CompletedAt", title = "Finalizado em", classification = "Internal" },
                    new { name = "ErrorMessage", title = "Erro", classification = "Internal" },
                    new { name = "Payload", title = "Payload", classification = "Internal" },
                    new { name = "RetryCount", title = "Tentativas", classification = "Internal" },
                    new { name = "RootOperationId", title = "Operacao raiz", classification = "Internal" },
                    new { name = "OperationId", title = "Operacao logica", classification = "Internal" },
                    new { name = "ExecutionId", title = "Tentativa de execucao", classification = "Internal" },
                    new { name = "CausationId", title = "Execucao causadora", classification = "Internal" },
                    new { name = "TenantID", title = "TenantID", classification = "Internal" },
                    new { name = "Deleted", title = "Deleted", classification = "Internal" },
                    new { name = "Changed", title = "Changed", classification = "Internal" },
                    new { name = "UserId", title = "User ID", classification = "Internal" },
                    new { name = "OperationalEntityId", title = "Identificador operacional", classification = "Internal" },
                }
            },
            new
            {
                name = "yTenant",
                title = "yTenant",
                fields = new[]
                {
                    new { name = "Id", title = "ID", classification = "Internal" },
                    new { name = "OperationalEntityId", title = "Identificador operacional", classification = "Internal" },
                    new { name = "CnpjCpf", title = "Cnpj/Cpf", classification = "Confidential" },
                    new { name = "Nome", title = "Nome", classification = "Confidential" },
                    new { name = "UserId", title = "User ID", classification = "Internal" },
                    new { name = "Deleted", title = "Deleted", classification = "Internal" },
                    new { name = "Changed", title = "Changed", classification = "Internal" },
                }
            },
            new
            {
                name = "yTenantApplication",
                title = "Aplicativos autorizados do tenant",
                fields = new[]
                {
                    new { name = "Id", title = "ID", classification = "Internal" },
                    new { name = "ApplicationKey", title = "Aplicativo", classification = "Internal" },
                    new { name = "TenantID", title = "TenantID", classification = "Internal" },
                    new { name = "ValidUntil", title = "Valido ate", classification = "Internal" },
                    new { name = "Deleted", title = "Deleted", classification = "Internal" },
                    new { name = "Changed", title = "Changed", classification = "Internal" },
                    new { name = "UserId", title = "User ID", classification = "Internal" },
                    new { name = "OperationalEntityId", title = "Identificador operacional", classification = "Internal" },
                }
            },
            new
            {
                name = "yTenantModule",
                title = "yTenantModule",
                fields = new[]
                {
                    new { name = "Id", title = "ID", classification = "Internal" },
                    new { name = "ModuleId", title = "ID Modulo", classification = "Internal" },
                    new { name = "TenantID", title = "TenantID", classification = "Internal" },
                    new { name = "ValidUntil", title = "Valido ate", classification = "Internal" },
                    new { name = "Deleted", title = "Deleted", classification = "Internal" },
                    new { name = "Changed", title = "Changed", classification = "Internal" },
                    new { name = "UserId", title = "User ID", classification = "Internal" },
                    new { name = "OperationalEntityId", title = "Identificador operacional", classification = "Internal" },
                }
            },
            new
            {
                name = "yToken",
                title = "yToken",
                fields = new[]
                {
                    new { name = "Id", title = "ID", classification = "Internal" },
                    new { name = "TokenHash", title = "Hash do Token", classification = "NeverCapture" },
                    new { name = "Description", title = "Descricao", classification = "Internal" },
                    new { name = "ConnectorKey", title = "Conector", classification = "Internal" },
                    new { name = "Active", title = "Ativo", classification = "Internal" },
                    new { name = "ValidUntil", title = "Valido ate", classification = "Internal" },
                    new { name = "CreatedAt", title = "Criado em", classification = "Internal" },
                    new { name = "LastUsedAt", title = "Ultimo uso", classification = "Internal" },
                    new { name = "TenantID", title = "TenantID", classification = "Internal" },
                    new { name = "UserId", title = "User ID", classification = "Internal" },
                    new { name = "Deleted", title = "Deleted", classification = "Internal" },
                    new { name = "Changed", title = "Changed", classification = "Internal" },
                    new { name = "OperationalEntityId", title = "Identificador operacional", classification = "Internal" },
                }
            },
            new
            {
                name = "yUser",
                title = "yUser",
                fields = new[]
                {
                    new { name = "Id", title = "ID", classification = "Internal" },
                    new { name = "OperationalEntityId", title = "Identificador operacional", classification = "Internal" },
                    new { name = "Nome", title = "Nome Usuario", classification = "Confidential" },
                    new { name = "Email", title = "Email", classification = "Confidential" },
                    new { name = "Senha", title = "Senha", classification = "NeverCapture" },
                    new { name = "TenantID", title = "TenantID", classification = "Internal" },
                    new { name = "Deleted", title = "Deleted", classification = "Internal" },
                    new { name = "Changed", title = "Changed", classification = "Internal" },
                }
            },
            new
            {
                name = "yUserGrant",
                title = "yUserGrant",
                fields = new[]
                {
                    new { name = "Id", title = "ID", classification = "Internal" },
                    new { name = "PerfilId", title = "ID Perfil", classification = "Internal" },
                    new { name = "GrantId", title = "ID Permição", classification = "Internal" },
                    new { name = "CanGrant", title = "Permite acessar", classification = "Internal" },
                    new { name = "CanCreate", title = "Permite Criar", classification = "Internal" },
                    new { name = "CanRead", title = "Permite Ler", classification = "Internal" },
                    new { name = "CanUpdate", title = "Permite Atualizar", classification = "Internal" },
                    new { name = "CanDelete", title = "Permite Deletar", classification = "Internal" },
                    new { name = "ValidUntil", title = "Valido ate", classification = "Internal" },
                    new { name = "TenantID", title = "TenantID", classification = "Internal" },
                    new { name = "Deleted", title = "Deleted", classification = "Internal" },
                    new { name = "Changed", title = "Changed", classification = "Internal" },
                    new { name = "UserId", title = "User ID", classification = "Internal" },
                    new { name = "OperationalEntityId", title = "Identificador operacional", classification = "Internal" },
                }
            },
            new
            {
                name = "yUserModule",
                title = "yUserModule",
                fields = new[]
                {
                    new { name = "Id", title = "ID", classification = "Internal" },
                    new { name = "ModuleId", title = "ID Modulo", classification = "Internal" },
                    new { name = "UserId", title = "User ID", classification = "Internal" },
                    new { name = "ValidUntil", title = "Valido ate", classification = "Internal" },
                    new { name = "TenantID", title = "TenantID", classification = "Internal" },
                    new { name = "Deleted", title = "Deleted", classification = "Internal" },
                    new { name = "Changed", title = "Changed", classification = "Internal" },
                    new { name = "OperationalEntityId", title = "Identificador operacional", classification = "Internal" },
                }
            },
        }
    }))
    .RequireAuthorization();

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

app.MapPost("/yapi/Foto/PostFoto", async ([FromServices] Command.Receivers.Write.InsertFotoReceiver receiver, [FromBody] Command.Write.FotoCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.FotoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.FotoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/Album/PostAlbum", async ([FromServices] Command.Receivers.Write.InsertAlbumReceiver receiver, [FromBody] Command.Write.AlbumCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.AlbumEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.AlbumEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/AlbumFoto/PostAlbumFoto", async ([FromServices] Command.Receivers.Write.InsertAlbumFotoReceiver receiver, [FromBody] Command.Write.AlbumFotoCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.AlbumFotoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.AlbumFotoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/PublicacaoAlbum/PostPublicacaoAlbum", async ([FromServices] Command.Receivers.Write.InsertPublicacaoAlbumReceiver receiver, [FromBody] Command.Write.PublicacaoAlbumCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.PublicacaoAlbumEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.PublicacaoAlbumEntity>>(StatusCodes.Status400BadRequest)
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


app.MapPost("/yapi/yTenantApplication/PostyTenantApplication", async ([FromServices] Command.Receivers.Write.InsertyTenantApplicationReceiver receiver, [FromBody] Command.Write.yTenantApplicationCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yTenantApplicationEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yTenantApplicationEntity>>(StatusCodes.Status400BadRequest)
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


app.MapPut("/yapi/Foto/PutFoto", async ([FromServices] Command.Receivers.Write.UpdateFotoReceiver receiver, [FromBody] Command.Write.FotoCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.FotoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.FotoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/Album/PutAlbum", async ([FromServices] Command.Receivers.Write.UpdateAlbumReceiver receiver, [FromBody] Command.Write.AlbumCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.AlbumEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.AlbumEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/AlbumFoto/PutAlbumFoto", async ([FromServices] Command.Receivers.Write.UpdateAlbumFotoReceiver receiver, [FromBody] Command.Write.AlbumFotoCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.AlbumFotoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.AlbumFotoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPut("/yapi/PublicacaoAlbum/PutPublicacaoAlbum", async ([FromServices] Command.Receivers.Write.UpdatePublicacaoAlbumReceiver receiver, [FromBody] Command.Write.PublicacaoAlbumCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.PublicacaoAlbumEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.PublicacaoAlbumEntity>>(StatusCodes.Status400BadRequest)
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


app.MapPut("/yapi/yTenantApplication/PutyTenantApplication", async ([FromServices] Command.Receivers.Write.UpdateyTenantApplicationReceiver receiver, [FromBody] Command.Write.yTenantApplicationCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yTenantApplicationEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yTenantApplicationEntity>>(StatusCodes.Status400BadRequest)
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


app.MapDelete("/yapi/Foto/DeleteFoto", async ([FromServices] Command.Receivers.Write.DeleteFotoReceiver receiver, [FromBody] Command.Write.FotoCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.FotoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.FotoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/Album/DeleteAlbum", async ([FromServices] Command.Receivers.Write.DeleteAlbumReceiver receiver, [FromBody] Command.Write.AlbumCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.AlbumEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.AlbumEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/AlbumFoto/DeleteAlbumFoto", async ([FromServices] Command.Receivers.Write.DeleteAlbumFotoReceiver receiver, [FromBody] Command.Write.AlbumFotoCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.AlbumFotoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.AlbumFotoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapDelete("/yapi/PublicacaoAlbum/DeletePublicacaoAlbum", async ([FromServices] Command.Receivers.Write.DeletePublicacaoAlbumReceiver receiver, [FromBody] Command.Write.PublicacaoAlbumCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.PublicacaoAlbumEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.PublicacaoAlbumEntity>>(StatusCodes.Status400BadRequest)
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


app.MapDelete("/yapi/yTenantApplication/DeleteyTenantApplication", async ([FromServices] Command.Receivers.Write.DeleteyTenantApplicationReceiver receiver, [FromBody] Command.Write.yTenantApplicationCrudCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yTenantApplicationEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yTenantApplicationEntity>>(StatusCodes.Status400BadRequest)
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



                    app.MapGet("/yapi/getMenu", async (
                        HttpContext context,
                        [FromServices] JwtSettings jwtSettings,
                        [FromServices] Command.Receivers.UseCase.OpenApplicationSessionHandler sessionHandler) =>
                    {
                        const string applicationName = "Memorias";
                        var tokenOrigin = context.User.FindFirst("tokenOrigin")?.Value;
                        var tokenApplication = context.User.FindFirst("application")?.Value;
                        var modulesClaim = context.User.Claims.FirstOrDefault(c => c.Type == "userModules")?.Value;
                        var catalogsClaim = context.User.Claims.FirstOrDefault(c => c.Type == "userCatalogs")?.Value;
                        var hasCatalogAccess = (catalogsClaim ?? string.Empty)
                            .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                            .Contains(applicationName, StringComparer.OrdinalIgnoreCase);

                        var isCentralApplication = string.Equals(
                            applicationName,
                            "Central",
                            StringComparison.OrdinalIgnoreCase);
                        var isCurrentApplicationToken = string.Equals(
                                tokenApplication,
                                applicationName,
                                StringComparison.OrdinalIgnoreCase)
                            && (string.Equals(tokenOrigin, "Application", StringComparison.OrdinalIgnoreCase)
                                || (isCentralApplication
                                    && string.Equals(tokenOrigin, "Central", StringComparison.OrdinalIgnoreCase)));

                        if (!isCurrentApplicationToken
                            && !string.IsNullOrWhiteSpace(tokenOrigin))
                        {
                            if (!hasCatalogAccess)
                                return Results.Unauthorized();

                            var tenantIdClaim = context.User.FindFirst("tenantId")?.Value;
                            var userIdClaim = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                            var email = context.User.FindFirst(ClaimTypes.Email)?.Value;
                            if (!int.TryParse(tenantIdClaim, out var tenantId)
                                || tenantId <= 0
                                || !int.TryParse(userIdClaim, out var userId)
                                || userId <= 0
                                || string.IsNullOrWhiteSpace(email))
                                return Results.Unauthorized();

                            var localUserId = userId;

                            if (!isCentralApplication)
                            {
                                var session = await sessionHandler.ExecuteAsync(
                                    new Command.UseCase.OpenApplicationSessionInputCommand
                                    {
                                        TenantId = tenantId,
                                        TenantDocument = context.User.FindFirst("tenantDocument")?.Value ?? string.Empty,
                                        TenantName = context.User.FindFirst("tenantName")?.Value ?? string.Empty,
                                        UserId = userId,
                                        UserName = context.User.FindFirst("userName")?.Value ?? email,
                                        Email = email
                                    },
                                    context.RequestAborted);

                                if (session.StatusCode is < 200 or >= 300 || session.Data is null)
                                    return Results.BadRequest(session);

                                localUserId = session.Data.UserId;
                            }

                            var claims = new List<Claim>
                            {
                                new(ClaimTypes.NameIdentifier, localUserId.ToString()),
                                new(ClaimTypes.Email, email),
                                new(ClaimTypes.Role, context.User.FindFirst(ClaimTypes.Role)?.Value ?? "Admin"),
                                new("tenantId", tenantId.ToString()),
                                new("userModules", string.Empty),
                                new("userCatalogs", catalogsClaim ?? string.Empty),
                                new("tokenOrigin", isCentralApplication ? "Central" : "Application"),
                                new("application", applicationName),
                                new("tenantDocument", context.User.FindFirst("tenantDocument")?.Value ?? string.Empty),
                                new("tenantName", context.User.FindFirst("tenantName")?.Value ?? string.Empty),
                                new("userName", context.User.FindFirst("userName")?.Value ?? email)
                            };
                            var tokenDescriptor = new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
                            {
                                Subject = new ClaimsIdentity(claims),
                                Expires = DateTime.UtcNow.AddMinutes(jwtSettings.ExpirationMinutes),
                                SigningCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(
                                    new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(
                                        System.Text.Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),
                                    Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature)
                            };
                            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
                            context.Response.Headers["X-Yeshua-Application-Token"] =
                                tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
                            context.Response.Headers.CacheControl = "no-store";
                        }

                        if (modulesClaim == null && !hasCatalogAccess)
                            return Results.Unauthorized();

                        var moduleKeys = (modulesClaim ?? string.Empty)
                            .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                        var userModules = hasCatalogAccess
                            ? StaticModules.Modules
                                .Where(m => !m.Key.Equals("ADM", StringComparison.OrdinalIgnoreCase))
                                .ToList()
                            : StaticModules.Modules
                                .Where(m => moduleKeys.Contains(m.Key, StringComparer.OrdinalIgnoreCase))
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
                    }).RequireAuthorization("ApplicationEntry");
            
app.MapPost("/yapi/Foto/ReadFoto", async ([FromServices] Command.Receivers.Read.FotoReadReceiver receiver, [FromBody] Command.Read.FotoReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.FotoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.FotoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/Album/ReadAlbum", async ([FromServices] Command.Receivers.Read.AlbumReadReceiver receiver, [FromBody] Command.Read.AlbumReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.AlbumEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.AlbumEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/AlbumFoto/ReadAlbumFoto", async ([FromServices] Command.Receivers.Read.AlbumFotoReadReceiver receiver, [FromBody] Command.Read.AlbumFotoReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.AlbumFotoEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.AlbumFotoEntity>>(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.RequireAuthorization();


app.MapPost("/yapi/PublicacaoAlbum/ReadPublicacaoAlbum", async ([FromServices] Command.Receivers.Read.PublicacaoAlbumReadReceiver receiver, [FromBody] Command.Read.PublicacaoAlbumReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.PublicacaoAlbumEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.PublicacaoAlbumEntity>>(StatusCodes.Status400BadRequest)
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


app.MapPost("/yapi/yTenantApplication/ReadyTenantApplication", async ([FromServices] Command.Receivers.Read.yTenantApplicationReadReceiver receiver, [FromBody] Command.Read.yTenantApplicationReadCommand command) =>
{
 return await StateResults.TryAsync(() => receiver.ExecuteAsync(command));
}).Produces<State<Dominio.Entitys.yTenantApplicationEntity>>(StatusCodes.Status200OK)
.Produces<State<Dominio.Entitys.yTenantApplicationEntity>>(StatusCodes.Status400BadRequest)
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


app.MapPost("/yapi/Foto/FotoReadFKTenantID", async ([FromServices] Command.Receivers.Read.FotoReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/Foto/FotoReadFKUserId", async ([FromServices] Command.Receivers.Read.FotoReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/Album/AlbumReadFKTenantID", async ([FromServices] Command.Receivers.Read.AlbumReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/Album/AlbumReadFKUserId", async ([FromServices] Command.Receivers.Read.AlbumReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/AlbumFoto/AlbumFotoReadFKAlbumId", async ([FromServices] Command.Receivers.Read.AlbumFotoReadFKAlbumIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/AlbumFoto/AlbumFotoReadFKFotoId", async ([FromServices] Command.Receivers.Read.AlbumFotoReadFKFotoIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/AlbumFoto/AlbumFotoReadFKTenantID", async ([FromServices] Command.Receivers.Read.AlbumFotoReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/AlbumFoto/AlbumFotoReadFKUserId", async ([FromServices] Command.Receivers.Read.AlbumFotoReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/PublicacaoAlbum/PublicacaoAlbumReadFKAlbumId", async ([FromServices] Command.Receivers.Read.PublicacaoAlbumReadFKAlbumIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/PublicacaoAlbum/PublicacaoAlbumReadFKTenantID", async ([FromServices] Command.Receivers.Read.PublicacaoAlbumReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/PublicacaoAlbum/PublicacaoAlbumReadFKUserId", async ([FromServices] Command.Receivers.Read.PublicacaoAlbumReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
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
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
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
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
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
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
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
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
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
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
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
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
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
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
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
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
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
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
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
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
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
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
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
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
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
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
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
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
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
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
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
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
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
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yTenantApplication/yTenantApplicationReadFKTenantID", async ([FromServices] Command.Receivers.Read.yTenantApplicationReadFKTenantIDReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/yTenantApplication/yTenantApplicationReadFKUserId", async ([FromServices] Command.Receivers.Read.yTenantApplicationReadFKUserIdReceiver receiver, [FromBody] Command.Patterns.Command.SearchFKCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
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
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
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
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
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
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
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
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
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
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
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
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
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
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
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
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
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
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
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
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
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
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
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
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
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
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
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
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
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
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
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
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
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
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
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
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
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
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
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
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
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
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
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
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
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
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapGet("/yapi/getMetaDataFoto", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "Foto",
        entityDescription = "Foto",
        source = new
        {
            kind = "table",
            name = "Foto"
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
                endpoint = "/Foto/ReadFoto",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "storagekey", label = "Arquivo", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "nomeoriginal", label = "Nome Original", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "contenttype", label = "Tipo do Arquivo", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "hasharquivo", label = "Hash", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "capturadaemutc", label = "Capturada em UTC", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "largura", label = "Largura", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "altura", label = "Altura", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Recebida" }, new { value = 2, display = "Disponivel" }, new { value = 3, display = "Invalida" },}, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "storagekey", label = "Arquivo", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "nomeoriginal", label = "Nome Original", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "contenttype", label = "Tipo do Arquivo", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "hasharquivo", label = "Hash", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "capturadaemutc", label = "Capturada em UTC", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "largura", label = "Largura", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "altura", label = "Altura", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Recebida" }, new { value = 2, display = "Disponivel" }, new { value = 3, display = "Invalida" },}, },
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
            new { id = "storagekey", label = "Arquivo", type = "string", required = false, displaygroup = "Arquivo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "nomeoriginal", label = "Nome Original", type = "string", required = false, displaygroup = "Arquivo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "contenttype", label = "Tipo do Arquivo", type = "string", required = false, displaygroup = "Arquivo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "hasharquivo", label = "Hash", type = "string", required = false, displaygroup = "Arquivo", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "capturadaemutc", label = "Capturada em UTC", type = "DateTime", required = false, displaygroup = "Imagem", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "largura", label = "Largura", type = "int", required = false, displaygroup = "Imagem", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "altura", label = "Altura", type = "int", required = false, displaygroup = "Imagem", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "status", label = "Status", type = "enum", required = false, displaygroup = "Status", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Recebida" }, new { value = 2, display = "Disponivel" }, new { value = 3, display = "Invalida" },}, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
            create = "/Foto/PostFoto",
            read = "/Foto/ReadFoto",
            update = "/Foto/PutFoto",
            delete = "/Foto/DeleteFoto"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDataAlbum", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "Album",
        entityDescription = "Album",
        source = new
        {
            kind = "table",
            name = "Album"
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
                endpoint = "/Album/ReadAlbum",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "titulo", label = "Titulo", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "descricao", label = "Descricao", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "privacidade", label = "Privacidade no YouTube", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Privado" }, new { value = 2, display = "Nao Listado" }, new { value = 3, display = "Publico" },}, },
                new { id = "segundosporfoto", label = "Segundos por Foto", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "qualidadevideo", label = "Qualidade do Video", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Economica (HD 720p)" }, new { value = 2, display = "Padrao (Full HD 1080p)" }, new { value = 3, display = "Alta (4K 2160p)" },}, },
                new { id = "modelovideo", label = "Modelo do Video", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Classico" }, new { value = 2, display = "Romantico" }, new { value = 3, display = "Aventura" }, new { value = 4, display = "Celebracao" },}, },
                new { id = "musicaid", label = "Musica", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "Sem musica" }, new { value = 1, display = "Air Prelude" }, new { value = 2, display = "Adventure Meme" }, new { value = 3, display = "Carefree" },}, },
                new { id = "volumemusica", label = "Volume da Musica (%)", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Em Edicao" }, new { value = 2, display = "Pronto Para Publicar" }, new { value = 3, display = "Publicando" }, new { value = 4, display = "Publicado" }, new { value = 5, display = "Falha" },}, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "titulo", label = "Titulo", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "descricao", label = "Descricao", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "privacidade", label = "Privacidade no YouTube", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Privado" }, new { value = 2, display = "Nao Listado" }, new { value = 3, display = "Publico" },}, },
                new { id = "segundosporfoto", label = "Segundos por Foto", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "qualidadevideo", label = "Qualidade do Video", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Economica (HD 720p)" }, new { value = 2, display = "Padrao (Full HD 1080p)" }, new { value = 3, display = "Alta (4K 2160p)" },}, },
                new { id = "modelovideo", label = "Modelo do Video", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Classico" }, new { value = 2, display = "Romantico" }, new { value = 3, display = "Aventura" }, new { value = 4, display = "Celebracao" },}, },
                new { id = "musicaid", label = "Musica", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "Sem musica" }, new { value = 1, display = "Air Prelude" }, new { value = 2, display = "Adventure Meme" }, new { value = 3, display = "Carefree" },}, },
                new { id = "volumemusica", label = "Volume da Musica (%)", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Em Edicao" }, new { value = 2, display = "Pronto Para Publicar" }, new { value = 3, display = "Publicando" }, new { value = 4, display = "Publicado" }, new { value = 5, display = "Falha" },}, },
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
            new { id = "titulo", label = "Titulo", type = "string", required = false, displaygroup = "Identificacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "descricao", label = "Descricao", type = "string", required = false, displaygroup = "Identificacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "privacidade", label = "Privacidade no YouTube", type = "enum", required = false, displaygroup = "Publicacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Privado" }, new { value = 2, display = "Nao Listado" }, new { value = 3, display = "Publico" },}, },
            new { id = "segundosporfoto", label = "Segundos por Foto", type = "int", required = false, displaygroup = "Renderizacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "qualidadevideo", label = "Qualidade do Video", type = "enum", required = false, displaygroup = "Renderizacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Economica (HD 720p)" }, new { value = 2, display = "Padrao (Full HD 1080p)" }, new { value = 3, display = "Alta (4K 2160p)" },}, },
            new { id = "modelovideo", label = "Modelo do Video", type = "enum", required = false, displaygroup = "Apresentacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Classico" }, new { value = 2, display = "Romantico" }, new { value = 3, display = "Aventura" }, new { value = 4, display = "Celebracao" },}, },
            new { id = "musicaid", label = "Musica", type = "enum", required = false, displaygroup = "Apresentacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "Sem musica" }, new { value = 1, display = "Air Prelude" }, new { value = 2, display = "Adventure Meme" }, new { value = 3, display = "Carefree" },}, },
            new { id = "volumemusica", label = "Volume da Musica (%)", type = "int", required = false, displaygroup = "Apresentacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "status", label = "Status", type = "enum", required = false, displaygroup = "Status", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Em Edicao" }, new { value = 2, display = "Pronto Para Publicar" }, new { value = 3, display = "Publicando" }, new { value = 4, display = "Publicado" }, new { value = 5, display = "Falha" },}, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
            create = "/Album/PostAlbum",
            read = "/Album/ReadAlbum",
            update = "/Album/PutAlbum",
            delete = "/Album/DeleteAlbum"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDataAlbumFoto", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "AlbumFoto",
        entityDescription = "Foto do Album",
        source = new
        {
            kind = "table",
            name = "AlbumFoto"
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
                endpoint = "/AlbumFoto/ReadAlbumFoto",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "albumid", label = "Album", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataAlbum", fksDisplayFields = new string[]{ "descricao" }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "fotoid", label = "Foto", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataFoto", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "ordem", label = "Ordem", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "legenda", label = "Legenda", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "rotacao", label = "Rotacao da Foto", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "albumid", label = "Album", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataAlbum", fksDisplayFields = new string[]{ "descricao" }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "fotoid", label = "Foto", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataFoto", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "ordem", label = "Ordem", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "legenda", label = "Legenda", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "rotacao", label = "Rotacao da Foto", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
                albumid = "/AlbumFoto/AlbumFotoReadFKAlbumId",
                fotoid = "/AlbumFoto/AlbumFotoReadFKFotoId",
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Identificacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "albumid", label = "Album", type = "int", required = false, displaygroup = "Vinculo", isFk = true, endPontGetMetadata = "/getMetaDataAlbum", fksDisplayFields = new string[]{ "descricao" }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "fotoid", label = "Foto", type = "int", required = false, displaygroup = "Vinculo", isFk = true, endPontGetMetadata = "/getMetaDataFoto", fksDisplayFields = new string[]{  }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "ordem", label = "Ordem", type = "int", required = false, displaygroup = "Apresentacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "legenda", label = "Legenda", type = "string", required = false, displaygroup = "Apresentacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "rotacao", label = "Rotacao da Foto", type = "int", required = false, displaygroup = "Apresentacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
                 albumid = "/AlbumFoto/AlbumFotoReadFKAlbumId",
                 fotoid = "/AlbumFoto/AlbumFotoReadFKFotoId",
            create = "/AlbumFoto/PostAlbumFoto",
            read = "/AlbumFoto/ReadAlbumFoto",
            update = "/AlbumFoto/PutAlbumFoto",
            delete = "/AlbumFoto/DeleteAlbumFoto"
        }
    };
    return Results.Ok(metadatacrud);
}).RequireAuthorization();
app.MapGet("/yapi/getMetaDataPublicacaoAlbum", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "PublicacaoAlbum",
        entityDescription = "Publicacao do Album",
        source = new
        {
            kind = "table",
            name = "PublicacaoAlbum"
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
                endpoint = "/PublicacaoAlbum/ReadPublicacaoAlbum",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "albumid", label = "Album", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataAlbum", fksDisplayFields = new string[]{ "descricao" }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "correlationid", label = "CorrelationId", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "manifeststoragekey", label = "Manifesto de Renderizacao", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "videostoragekey", label = "Video Renderizado", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "youtubevideoid", label = "Video no YouTube", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "youtubeurl", label = "URL no YouTube", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "canalyoutubeid", label = "Canal de Destino", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "privacidadeyoutube", label = "Visibilidade solicitada", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "qualidadevideo", label = "Qualidade do Video", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Economica (HD 720p)" }, new { value = 2, display = "Padrao (Full HD 1080p)" }, new { value = 3, display = "Alta (4K 2160p)" },}, },
                new { id = "modelovideo", label = "Modelo do Video", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Classico" }, new { value = 2, display = "Romantico" }, new { value = 3, display = "Aventura" }, new { value = 4, display = "Celebracao" },}, },
                new { id = "musicaid", label = "Musica", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "Sem musica" }, new { value = 1, display = "Air Prelude" }, new { value = 2, display = "Adventure Meme" }, new { value = 3, display = "Carefree" },}, },
                new { id = "volumemusica", label = "Volume da Musica (%)", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "mensagem", label = "Mensagem", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "solicitadaemutc", label = "Solicitada em UTC", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "publicadaemutc", label = "Publicada em UTC", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Solicitada" }, new { value = 2, display = "Preparando Manifesto" }, new { value = 3, display = "Renderizando" }, new { value = 4, display = "Enviando ao YouTube" }, new { value = 5, display = "Publicada" }, new { value = 6, display = "Falha" },}, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "albumid", label = "Album", type = "int", isFk = true, endPontGetMetadata = "/getMetaDataAlbum", fksDisplayFields = new string[]{ "descricao" }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "correlationid", label = "CorrelationId", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "manifeststoragekey", label = "Manifesto de Renderizacao", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "videostoragekey", label = "Video Renderizado", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "youtubevideoid", label = "Video no YouTube", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "youtubeurl", label = "URL no YouTube", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "canalyoutubeid", label = "Canal de Destino", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "privacidadeyoutube", label = "Visibilidade solicitada", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "qualidadevideo", label = "Qualidade do Video", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Economica (HD 720p)" }, new { value = 2, display = "Padrao (Full HD 1080p)" }, new { value = 3, display = "Alta (4K 2160p)" },}, },
                new { id = "modelovideo", label = "Modelo do Video", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Classico" }, new { value = 2, display = "Romantico" }, new { value = 3, display = "Aventura" }, new { value = 4, display = "Celebracao" },}, },
                new { id = "musicaid", label = "Musica", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "Sem musica" }, new { value = 1, display = "Air Prelude" }, new { value = 2, display = "Adventure Meme" }, new { value = 3, display = "Carefree" },}, },
                new { id = "volumemusica", label = "Volume da Musica (%)", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "mensagem", label = "Mensagem", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "solicitadaemutc", label = "Solicitada em UTC", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "publicadaemutc", label = "Publicada em UTC", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "status", label = "Status", type = "enum", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Solicitada" }, new { value = 2, display = "Preparando Manifesto" }, new { value = 3, display = "Renderizando" }, new { value = 4, display = "Enviando ao YouTube" }, new { value = 5, display = "Publicada" }, new { value = 6, display = "Falha" },}, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
                albumid = "/PublicacaoAlbum/PublicacaoAlbumReadFKAlbumId",
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Identificacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "albumid", label = "Album", type = "int", required = false, displaygroup = "Vinculo", isFk = true, endPontGetMetadata = "/getMetaDataAlbum", fksDisplayFields = new string[]{ "descricao" }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "correlationid", label = "CorrelationId", type = "string", required = false, displaygroup = "Processamento", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "manifeststoragekey", label = "Manifesto de Renderizacao", type = "string", required = false, displaygroup = "Renderizacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "videostoragekey", label = "Video Renderizado", type = "string", required = false, displaygroup = "Renderizacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "youtubevideoid", label = "Video no YouTube", type = "string", required = false, displaygroup = "YouTube", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "youtubeurl", label = "URL no YouTube", type = "string", required = false, displaygroup = "YouTube", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "canalyoutubeid", label = "Canal de Destino", type = "string", required = false, displaygroup = "YouTube", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "privacidadeyoutube", label = "Visibilidade solicitada", type = "int", required = false, displaygroup = "YouTube", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "qualidadevideo", label = "Qualidade do Video", type = "enum", required = false, displaygroup = "Renderizacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Economica (HD 720p)" }, new { value = 2, display = "Padrao (Full HD 1080p)" }, new { value = 3, display = "Alta (4K 2160p)" },}, },
            new { id = "modelovideo", label = "Modelo do Video", type = "enum", required = false, displaygroup = "Apresentacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Classico" }, new { value = 2, display = "Romantico" }, new { value = 3, display = "Aventura" }, new { value = 4, display = "Celebracao" },}, },
            new { id = "musicaid", label = "Musica", type = "enum", required = false, displaygroup = "Apresentacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 0, display = "Sem musica" }, new { value = 1, display = "Air Prelude" }, new { value = 2, display = "Adventure Meme" }, new { value = 3, display = "Carefree" },}, },
            new { id = "volumemusica", label = "Volume da Musica (%)", type = "int", required = false, displaygroup = "Apresentacao", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "mensagem", label = "Mensagem", type = "string", required = false, displaygroup = "Status", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "solicitadaemutc", label = "Solicitada em UTC", type = "DateTime", required = false, displaygroup = "Datas", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "publicadaemutc", label = "Publicada em UTC", type = "DateTime", required = false, displaygroup = "Datas", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "status", label = "Status", type = "enum", required = false, displaygroup = "Status", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[]{ new { value = 1, display = "Solicitada" }, new { value = 2, display = "Preparando Manifesto" }, new { value = 3, display = "Renderizando" }, new { value = 4, display = "Enviando ao YouTube" }, new { value = 5, display = "Publicada" }, new { value = 6, display = "Falha" },}, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
                 albumid = "/PublicacaoAlbum/PublicacaoAlbumReadFKAlbumId",
            create = "/PublicacaoAlbum/PostPublicacaoAlbum",
            read = "/PublicacaoAlbum/ReadPublicacaoAlbum",
            update = "/PublicacaoAlbum/PutPublicacaoAlbum",
            delete = "/PublicacaoAlbum/DeletePublicacaoAlbum"
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
            new { id = "payload", label = "Payload", type = "memo", required = false, displaygroup = "Saga", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
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
            new { id = "payload", label = "Payload", type = "memo", required = false, displaygroup = "Mensagem", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
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
            new { id = "payload", label = "Payload", type = "memo", required = false, displaygroup = "Mensagem", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
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
app.MapGet("/yapi/getMetaDatayTenantApplication", (HttpContext context) =>
{
    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    if (string.IsNullOrEmpty(userId))
        return Results.Unauthorized();
    var metadatacrud = new
    {
        entityName = "yTenantApplication",
        entityDescription = "Aplicativos autorizados do tenant",
        source = new
        {
            kind = "table",
            name = "yTenantApplication"
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
                endpoint = "/yTenantApplication/ReadyTenantApplication",
            resultFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "applicationkey", label = "Aplicativo", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "tenantid", label = "TenantID", type = "int", isFk = true, endPontGetMetadata = "/getMetaDatayTenant", fksDisplayFields = new string[]{ "nome" }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "validuntil", label = "Valido ate", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
                new { id = "id", label = "ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "applicationkey", label = "Aplicativo", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "tenantid", label = "TenantID", type = "int", isFk = true, endPontGetMetadata = "/getMetaDatayTenant", fksDisplayFields = new string[]{ "nome" }, options = new[] { new { value = 0, display = "" } }, },
                new { id = "validuntil", label = "Valido ate", type = "DateTime", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            quickSearches = Array.Empty<object>(),
            fkEndpoints = new 
            {
                tenantid = "/yTenantApplication/yTenantApplicationReadFKTenantID",
            }
            },
        },
        formFields = new[]
        {
            new { id = "id", label = "ID", type = "int", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "applicationkey", label = "Aplicativo", type = "string", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            new { id = "tenantid", label = "TenantID", type = "int", required = false, displaygroup = "Geral", isFk = true, endPontGetMetadata = "/getMetaDatayTenant", fksDisplayFields = new string[]{ "nome" }, options = new[] { new { value = 0, display = "" } }, },
            new { id = "validuntil", label = "Valido ate", type = "DateTime", required = false, displaygroup = "Geral", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
        },
        relationTabs = Array.Empty<object>(),
        customTabs = Array.Empty<object>(),
        actions = Array.Empty<object>(),
        endpoints = new
        {
                 tenantid = "/yTenantApplication/yTenantApplicationReadFKTenantID",
            create = "/yTenantApplication/PostyTenantApplication",
            read = "/yTenantApplication/ReadyTenantApplication",
            update = "/yTenantApplication/PutyTenantApplication",
            delete = "/yTenantApplication/DeleteyTenantApplication"
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
                new { id = "cnpjcpf", label = "Cnpj/Cpf", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "nome", label = "Nome", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "userid", label = "User ID", type = "int", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
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
                new { id = "nome", label = "Nome Usuario", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "email", label = "Email", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
                new { id = "senha", label = "Senha", type = "string", isFk = false, endPontGetMetadata = "", fksDisplayFields = new string[]{}, options = new[] { new { value = 0, display = "" } }, },
            },
            filterFields = new[]
            {
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
app.MapPost("/yapi/Memorias/AlbunsSolicitarPublicacaoAlbumUseCase", async ([FromServices] Command.Receivers.UseCase.SolicitarPublicacaoAlbumHandler receiver, [FromBody] Command.UseCase.SolicitarPublicacaoAlbumInputCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/Memorias/YouTubeIniciarConexaoYouTubeUseCase", async ([FromServices] Command.Receivers.UseCase.IniciarConexaoYouTubeHandler receiver, [FromBody] Command.UseCase.IniciarConexaoYouTubeInputCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/Memorias/YouTubeConcluirConexaoYouTubeUseCase", async ([FromServices] Command.Receivers.UseCase.ConcluirConexaoYouTubeHandler receiver, [FromBody] Command.UseCase.ConcluirConexaoYouTubeInputCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/Memorias/YouTubeConsultarConexaoYouTubeUseCase", async ([FromServices] Command.Receivers.UseCase.ConsultarConexaoYouTubeHandler receiver, [FromBody] Command.UseCase.ConsultarConexaoYouTubeInputCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/Memorias/YouTubeListarConexoesYouTubeUseCase", async ([FromServices] Command.Receivers.UseCase.ListarConexoesYouTubeHandler receiver, [FromBody] Command.UseCase.ListarConexoesYouTubeInputCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/Memorias/YouTubeDesconectarYouTubeUseCase", async ([FromServices] Command.Receivers.UseCase.DesconectarYouTubeHandler receiver, [FromBody] Command.UseCase.DesconectarYouTubeInputCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/Memorias/YouTubeRetomarPublicacaoYouTubeUseCase", async ([FromServices] Command.Receivers.UseCase.RetomarPublicacaoYouTubeHandler receiver, [FromBody] Command.UseCase.RetomarPublicacaoYouTubeInputCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/Memorias/YouTubeConsultarConfiguracaoYouTubeUseCase", async ([FromServices] Command.Receivers.UseCase.ConsultarConfiguracaoYouTubeHandler receiver, [FromBody] Command.UseCase.ConsultarConfiguracaoYouTubeInputCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/Memorias/YouTubeSalvarConfiguracaoYouTubeUseCase", async ([FromServices] Command.Receivers.UseCase.SalvarConfiguracaoYouTubeHandler receiver, [FromBody] Command.UseCase.SalvarConfiguracaoYouTubeInputCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/Memorias/FotosGirarFotoUseCase", async ([FromServices] Command.Receivers.UseCase.GirarFotoHandler receiver, [FromBody] Command.UseCase.GirarFotoInputCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/Memorias/ApresentacaoConsultarModelosVideoUseCase", async ([FromServices] Command.Receivers.UseCase.ConsultarModelosVideoHandler receiver, [FromBody] Command.UseCase.ConsultarModelosVideoInputCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
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
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/FileUpload/InfraSendFileUseCase", async ([FromServices] Command.Receivers.UseCase.SendFileHandler receiver, [FromForm] Command.UseCase.SendFileInputCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).DisableAntiforgery()
.Accepts<Command.UseCase.SendFileInputCommand>("multipart/form-data")
.RequireAuthorization();


app.MapPost("/yapi/Saga/OperacaoRetrySagaStepUseCase", async ([FromServices] Command.Receivers.UseCase.RetrySagaStepHandler receiver, [FromBody] Command.UseCase.RetrySagaStepInputCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
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
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
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
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
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
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
else
    return Results.BadRequest(result);
}
catch (Exception ex)
{
return Results.Problem(ex.Message);
}
}).RequireAuthorization();


app.MapPost("/yapi/Y/ContasOpenApplicationSessionUseCase", async ([FromServices] Command.Receivers.UseCase.OpenApplicationSessionHandler receiver, [FromBody] Command.UseCase.OpenApplicationSessionInputCommand command) =>
{
try
{
var result = await receiver.ExecuteAsync(command);
if (result.StatusCode == 200)
    return Results.Ok(result.Data);
else if (result.StatusCode == 403)
    return Results.Json(result, statusCode: 403);
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