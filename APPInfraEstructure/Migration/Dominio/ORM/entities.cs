using System;

namespace MyApp.Domain.Entities
{
    public class PlanoConta
    {
        public int? Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public int Tipo { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<PlanoConta> Query() => new MyApp.QueryBuilder.Query<PlanoConta>();
    }

    public class MovimentoFinanceiro
    {
        public int? Id { get; set; }
        public string IdOrigem { get; set; }
        public int ContaDebitoId { get; set; }
        public PlanoConta PlanoConta { get; set; }
        public Decimal Valor { get; set; }
        public DateTime DataMovimento { get; set; }
        public DateTime? DataVencimento { get; set; }
        public int Status { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<MovimentoFinanceiro> Query() => new MyApp.QueryBuilder.Query<MovimentoFinanceiro>();
    }

    public class Especialidade
    {
        public int? Id { get; set; }
        public string Descricao { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Especialidade> Query() => new MyApp.QueryBuilder.Query<Especialidade>();
    }

    public class Profissional
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public int? EspecialidadeId { get; set; }
        public Especialidade Especialidade { get; set; }
        public string Telefone { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Profissional> Query() => new MyApp.QueryBuilder.Query<Profissional>();
    }

    public class DisponibilidadeAgenda
    {
        public int? Id { get; set; }
        public int? ProfissionalId { get; set; }
        public Profissional Profissional { get; set; }
        public DateTime DataHora { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<DisponibilidadeAgenda> Query() => new MyApp.QueryBuilder.Query<DisponibilidadeAgenda>();
    }

    public class GrupoServico
    {
        public int? Id { get; set; }
        public string Descricao { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<GrupoServico> Query() => new MyApp.QueryBuilder.Query<GrupoServico>();
    }

    public class Servico
    {
        public int? Id { get; set; }
        public int? GrupoServicoId { get; set; }
        public GrupoServico GrupoServico { get; set; }
        public string Nome { get; set; }
        public Decimal Valor { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Servico> Query() => new MyApp.QueryBuilder.Query<Servico>();
    }

    public class Paciente
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public DateTime? DataNascimento { get; set; }
        public int? Genero { get; set; }
        public string Escolaridade { get; set; }
        public string Profissao { get; set; }
        public string Endereco { get; set; }
        public string NomeResponsavel { get; set; }
        public string TelefoneResponsavel { get; set; }
        public string Observacao { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Paciente> Query() => new MyApp.QueryBuilder.Query<Paciente>();
    }

    public class MovimentacaoFinanceira
    {
        public int? Id { get; set; }
        public int? PacienteId { get; set; }
        public Paciente Paciente { get; set; }
        public int? ServicoId { get; set; }
        public Servico Servico { get; set; }
        public Decimal Valor { get; set; }
        public int TipoMovimentacao { get; set; }
        public DateTime DataMovimentacao { get; set; }
        public Decimal SaldoAtual { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<MovimentacaoFinanceira> Query() => new MyApp.QueryBuilder.Query<MovimentacaoFinanceira>();
    }

    public class Sesoes
    {
        public int? PacienteId { get; set; }
        public Paciente Paciente { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int? StatusAgendamento { get; set; }
        public int? StatusProntuario { get; set; }
        public string Prontuario { get; set; }
        public string QueixaPrincipal { get; set; }
        public string RegistroDocumental { get; set; }
        public string SintomasRelatados { get; set; }
        public int? MudancasDesdeUltimaSessaao { get; set; }
        public string ComportamentoObservado { get; set; }
        public string EstadoEmocionalGeral { get; set; }
        public string DiscursoPensamentos { get; set; }
        public string UsoMedicacao { get; set; }
        public string TecnicasUtilizadas { get; set; }
        public string QuestionamentosReflexoesAbordadas { get; set; }
        public string ExerciciosTarefasSugeridas { get; set; }
        public string DiagnoosticoHipoteseDiagnoostica { get; set; }
        public string ObjetivosCurtoPrazo { get; set; }
        public string ObjetivosLongoPrazo { get; set; }
        public string FrequenciaSugeridaSessooes { get; set; }
        public string EncaminhamentoOutrosProfissionais { get; set; }
        public string InformacoesRelevantesFuturasConsultas { get; set; }
        public string FeedbackPacienteSobreProcessoTerapeeutico { get; set; }
        public int? Id { get; set; }
        public int? ServicoId { get; set; }
        public Servico Servico { get; set; }
        public int? MovimentacaoFinanceiraId { get; set; }
        public MovimentacaoFinanceira MovimentacaoFinanceira { get; set; }
        public int? ProfissionalId { get; set; }
        public Profissional Profissional { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Sesoes> Query() => new MyApp.QueryBuilder.Query<Sesoes>();
    }

    public class Clinica
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<Clinica> Query() => new MyApp.QueryBuilder.Query<Clinica>();
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
        public bool? Grant { get; set; }
        public bool? Create { get; set; }
        public bool? Read { get; set; }
        public bool? Update { get; set; }
        public bool? Delete { get; set; }
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
        public bool? Grant { get; set; }
        public bool? Create { get; set; }
        public bool? Read { get; set; }
        public bool? Update { get; set; }
        public bool? Delete { get; set; }
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