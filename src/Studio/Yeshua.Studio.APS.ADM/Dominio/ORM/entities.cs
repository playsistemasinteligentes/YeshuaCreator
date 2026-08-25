// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeEntityInternalMigration
// </yeshua>

using System;

namespace Yeshua.Studio.APS.ADM.Domain.Entities
{
    public class Produto
    {
        public string Id { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Produto> Query() => new MyApp.QueryBuilder.Query<Produto>();
    }

    public class Maquina
    {
        public string Id { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Maquina> Query() => new MyApp.QueryBuilder.Query<Maquina>();
    }

    public class GrupoMaquina
    {
        public string Id { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<GrupoMaquina> Query() => new MyApp.QueryBuilder.Query<GrupoMaquina>();
    }

    public class TemplateDeTestes
    {
        public int? Id { get; set; }
        public string Descricao { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<TemplateDeTestes> Query() => new MyApp.QueryBuilder.Query<TemplateDeTestes>();
    }

    public class Roteiro
    {
        public string MaquinaId { get; set; }
        public Maquina Maquina { get; set; }
        public string ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int SequenciaTransformacao { get; set; }
        public string GrupoMaquinaId { get; set; }
        public GrupoMaquina GrupoMaquina { get; set; }
        public Decimal? PecasPorPulso { get; set; }
        public Decimal? PrioridadeInformada { get; set; }
        public string Acao { get; set; }
        public Decimal Performance { get; set; }
        public Decimal? TempoSetup { get; set; }
        public Decimal? TempoSetupAjuste { get; set; }
        public int? ProximaSequenciaTransformacao { get; set; }
        public string Status { get; set; }
        public Decimal? HierarquiaSequenciaTransformacao { get; set; }
        public int? AvaliaCusto { get; set; }
        public string Operacoes { get; set; }
        public string ExcecaoOperacoes { get; set; }
        public Decimal? PercentualInicioPassoAnterior { get; set; }
        public string LinhaDireta { get; set; }
        public int? TemplateDeTestesId { get; set; }
        public TemplateDeTestes TemplateDeTestes { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Roteiro> Query() => new MyApp.QueryBuilder.Query<Roteiro>();
    }

    public class ConsultaPedido
    {
        public string PedidoId { get; set; }
        public string ClienteId { get; set; }
        public string ClienteNome { get; set; }
        public string RazaoSocial { get; set; }
        public string ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public string ProdutoDescricao { get; set; }
        public string Status { get; set; }
        public string Estagio { get; set; }
        public DateTime DataEntregaDe { get; set; }
        public DateTime DataEntregaAte { get; set; }
        public DateTime? EmbarqueAlvo { get; set; }
        public Decimal Quantidade { get; set; }
        public Decimal SaldoAProduzir { get; set; }
        public Decimal? SaldoAExpedir { get; set; }
        public string CorFila { get; set; }
        public string PedidoCliente { get; set; }

        public static MyApp.QueryBuilder.Query<ConsultaPedido> Query() => new MyApp.QueryBuilder.Query<ConsultaPedido>();
    }

    public class RoteiroPedido
    {
        public string PedidoId { get; set; }
        public ConsultaPedido ConsultaPedido { get; set; }
        public string MaquinaId { get; set; }
        public Maquina Maquina { get; set; }
        public string ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int SequenciaTransformacao { get; set; }
        public string StatusCadastro { get; set; }
        public string TipoPlanejamento { get; set; }
        public int CalendarioId { get; set; }
        public Decimal? HierarquiaSequenciaTransformacao { get; set; }
        public int? ProximaSequenciaTransformacao { get; set; }
        public Decimal? Performance { get; set; }
        public Decimal? TempoSetup { get; set; }
        public Decimal? TempoSetupAjuste { get; set; }
        public Decimal? PecasPorPulso { get; set; }
        public Decimal? PrioridadeInformada { get; set; }
        public string Status { get; set; }
        public string Operacoes { get; set; }
        public string ExcecaoOperacoes { get; set; }
        public string LinhaDireta { get; set; }
        public int? AvaliaCusto { get; set; }
        public Decimal? PercentualInicioPassoAnterior { get; set; }
        public Decimal? MaquinaLarguraUtil { get; set; }
        public Decimal? GrupoTipo { get; set; }
        public Decimal GrupoPerformanceMetroLinear { get; set; }

        public static MyApp.QueryBuilder.Query<RoteiroPedido> Query() => new MyApp.QueryBuilder.Query<RoteiroPedido>();
    }

    public class yFileUpload
    {
        public int? Id { get; set; }
        public string Type { get; set; }
        public int Status { get; set; }
        public string FilePath { get; set; }
        public long? FileSize { get; set; }
        public string EntityType { get; set; }
        public string EntityId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<yFileUpload> Query() => new MyApp.QueryBuilder.Query<yFileUpload>();
    }

    public class ySaga
    {
        public int? Id { get; set; }
        public string CorrelationId { get; set; }
        public string Type { get; set; }
        public int Status { get; set; }
        public string KeyCurrentStep { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public string EntityType { get; set; }
        public string EntityId { get; set; }
        public DateTime? NextExecutionAt { get; set; }
        public DateTime? LockedAt { get; set; }
        public string LockedBy { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<ySaga> Query() => new MyApp.QueryBuilder.Query<ySaga>();
    }

    public class ySagaStep
    {
        public int? Id { get; set; }
        public int SagaId { get; set; }
        public ySaga ySaga { get; set; }
        public string StepKey { get; set; }
        public int IndexOrder { get; set; }
        public string CorrelationId { get; set; }
        public int Status { get; set; }
        public int ExecutionCount { get; set; }
        public DateTime? LastExecutionAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public string ErrorMessage { get; set; }
        public string Payload { get; set; }
        public int RetryCount { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<ySagaStep> Query() => new MyApp.QueryBuilder.Query<ySagaStep>();
    }

    public class yOutbox
    {
        public int? Id { get; set; }
        public string MessageId { get; set; }
        public string Type { get; set; }
        public string EntityType { get; set; }
        public string EntityId { get; set; }
        public string CorrelationId { get; set; }
        public string Payload { get; set; }
        public int Status { get; set; }
        public int TransportType { get; set; }
        public string TransportData { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? SentAt { get; set; }
        public int RetryCount { get; set; }
        public string LastError { get; set; }
        public DateTime? ProcessingAt { get; set; }
        public DateTime? NextAttemptAt { get; set; }
        public int? SagaId { get; set; }
        public ySaga ySaga { get; set; }
        public int? SagaStepId { get; set; }
        public ySagaStep ySagaStep { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<yOutbox> Query() => new MyApp.QueryBuilder.Query<yOutbox>();
    }

    public class yInbox
    {
        public int? Id { get; set; }
        public string MessageId { get; set; }
        public string Type { get; set; }
        public string EntityType { get; set; }
        public string EntityId { get; set; }
        public string CorrelationId { get; set; }
        public string Payload { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public int RetryCount { get; set; }
        public string LastError { get; set; }
        public DateTime? ProcessingAt { get; set; }
        public DateTime? NextAttemptAt { get; set; }
        public int? SagaId { get; set; }
        public ySaga ySaga { get; set; }
        public int? SagaStepId { get; set; }
        public ySagaStep ySagaStep { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<yInbox> Query() => new MyApp.QueryBuilder.Query<yInbox>();
    }

    public class yTenant
    {
        public int? Id { get; set; }
        public string CnpjCpf { get; set; }
        public string Nome { get; set; }
        public int? UserId { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }

        public static MyApp.QueryBuilder.Query<yTenant> Query() => new MyApp.QueryBuilder.Query<yTenant>();
    }

    public class yUser
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }

        public static MyApp.QueryBuilder.Query<yUser> Query() => new MyApp.QueryBuilder.Query<yUser>();
    }

    public class yConfigArcteture
    {
        public int? Id { get; set; }
        public int? AuditTrackerActived { get; set; }
        public int? AuditCRUDActived { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<yConfigArcteture> Query() => new MyApp.QueryBuilder.Query<yConfigArcteture>();
    }

    public class yConfigNotification
    {
        public int? Id { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public string EmailSmtpClient { get; set; }
        public int? EmailPort { get; set; }
        public string EmailUserName { get; set; }
        public string EmailPassword { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<yConfigNotification> Query() => new MyApp.QueryBuilder.Query<yConfigNotification>();
    }

    public class yPerfil
    {
        public int? Id { get; set; }
        public string Description { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<yPerfil> Query() => new MyApp.QueryBuilder.Query<yPerfil>();
    }

    public class yModule
    {
        public string Id { get; set; }
        public string Description { get; set; }

        public static MyApp.QueryBuilder.Query<yModule> Query() => new MyApp.QueryBuilder.Query<yModule>();
    }

    public class yTenantModule
    {
        public int? Id { get; set; }
        public string ModuleId { get; set; }
        public yModule yModule { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public DateTime? ValidUntil { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<yTenantModule> Query() => new MyApp.QueryBuilder.Query<yTenantModule>();
    }

    public class yUserModule
    {
        public int? Id { get; set; }
        public string ModuleId { get; set; }
        public yModule yModule { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }
        public DateTime? ValidUntil { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }

        public static MyApp.QueryBuilder.Query<yUserModule> Query() => new MyApp.QueryBuilder.Query<yUserModule>();
    }

    public class yGrant
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<yGrant> Query() => new MyApp.QueryBuilder.Query<yGrant>();
    }

    public class yPerfilGrant
    {
        public int? Id { get; set; }
        public int? PerfilId { get; set; }
        public yPerfil yPerfil { get; set; }
        public string GrantId { get; set; }
        public yGrant yGrant { get; set; }
        public bool? CanGrant { get; set; }
        public bool? CanCreate { get; set; }
        public bool? CanRead { get; set; }
        public bool? CanUpdate { get; set; }
        public bool? CanDelete { get; set; }
        public DateTime? ValidUntil { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<yPerfilGrant> Query() => new MyApp.QueryBuilder.Query<yPerfilGrant>();
    }

    public class yUserGrant
    {
        public int? Id { get; set; }
        public int? PerfilId { get; set; }
        public yPerfil yPerfil { get; set; }
        public string GrantId { get; set; }
        public yGrant yGrant { get; set; }
        public bool? CanGrant { get; set; }
        public bool? CanCreate { get; set; }
        public bool? CanRead { get; set; }
        public bool? CanUpdate { get; set; }
        public bool? CanDelete { get; set; }
        public DateTime? ValidUntil { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<yUserGrant> Query() => new MyApp.QueryBuilder.Query<yUserGrant>();
    }

}
//Dominio.Schemas.CQRS.SourceCodeEntityInternalMigration