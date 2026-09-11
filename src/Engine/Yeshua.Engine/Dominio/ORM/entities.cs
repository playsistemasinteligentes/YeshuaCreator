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

namespace MyApp.Domain.Entities
{
    public class DocumentoFiscal
    {
        public int? Id { get; set; }
        public string CorrelationId { get; set; }
        public int ProdutoFiscal { get; set; }
        public string ChaveAcesso { get; set; }
        public int? Serie { get; set; }
        public int? Numero { get; set; }
        public int Ambiente { get; set; }
        public string UFEmitente { get; set; }
        public string EmitenteDocumento { get; set; }
        public string DestinatarioDocumento { get; set; }
        public string XmlStorageKey { get; set; }
        public string XmlHash { get; set; }
        public string ProtocoloAutorizacao { get; set; }
        public string CodigoRetorno { get; set; }
        public string MensagemRetorno { get; set; }
        public int Status { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<DocumentoFiscal> Query() => new MyApp.QueryBuilder.Query<DocumentoFiscal>();
    }

    public class DocumentoFiscalOriginario
    {
        public int? Id { get; set; }
        public int? DocumentoFiscalId { get; set; }
        public DocumentoFiscal DocumentoFiscal { get; set; }
        public string CorrelationId { get; set; }
        public string SourceApplication { get; set; }
        public string SourceModule { get; set; }
        public string SourceMessageId { get; set; }
        public string TipoDocumento { get; set; }
        public string ChaveAcesso { get; set; }
        public string Numero { get; set; }
        public string Serie { get; set; }
        public string EmitenteDocumento { get; set; }
        public string DestinatarioDocumento { get; set; }
        public Decimal? ValorDocumento { get; set; }
        public Decimal? PesoBruto { get; set; }
        public Decimal? Volume { get; set; }
        public string SnapshotJson { get; set; }
        public int Status { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<DocumentoFiscalOriginario> Query() => new MyApp.QueryBuilder.Query<DocumentoFiscalOriginario>();
    }

    public class NFeProdutoSnapshot
    {
        public int? Id { get; set; }
        public int? DocumentoFiscalOriginarioId { get; set; }
        public DocumentoFiscalOriginario DocumentoFiscalOriginario { get; set; }
        public string CorrelationId { get; set; }
        public string CargaId { get; set; }
        public string PedidoId { get; set; }
        public string ChaveAcesso { get; set; }
        public string EmitenteDocumento { get; set; }
        public string DestinatarioDocumento { get; set; }
        public string UFOrigem { get; set; }
        public string UFDestino { get; set; }
        public string MunicipioOrigemCodigoIbge { get; set; }
        public string MunicipioDestinoCodigoIbge { get; set; }
        public Decimal? ValorDocumento { get; set; }
        public Decimal? PesoBruto { get; set; }
        public Decimal? Volume { get; set; }
        public string XmlStorageKey { get; set; }
        public string SnapshotJson { get; set; }
        public int Status { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<NFeProdutoSnapshot> Query() => new MyApp.QueryBuilder.Query<NFeProdutoSnapshot>();
    }

    public class CTeEntradaOficial
    {
        public int? Id { get; set; }
        public string CorrelationId { get; set; }
        public string SourceApplication { get; set; }
        public string SourceModule { get; set; }
        public string SourceMessageId { get; set; }
        public string MessageType { get; set; }
        public string MessageVersion { get; set; }
        public DateTime ReceivedAtUtc { get; set; }
        public string PayloadHash { get; set; }
        public string PayloadStorageKey { get; set; }
        public int Status { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<CTeEntradaOficial> Query() => new MyApp.QueryBuilder.Query<CTeEntradaOficial>();
    }

    public class CTeRomaneioConsolidado
    {
        public int? Id { get; set; }
        public int EntradaOficialId { get; set; }
        public CTeEntradaOficial CTeEntradaOficial { get; set; }
        public string CorrelationId { get; set; }
        public string RomaneioId { get; set; }
        public string CargaId { get; set; }
        public DateTime ConsolidadoEmUtc { get; set; }
        public string UFInicio { get; set; }
        public string UFFim { get; set; }
        public string MunicipioInicioCodigoIbge { get; set; }
        public string MunicipioFimCodigoIbge { get; set; }
        public string EmitenteDocumento { get; set; }
        public string TomadorDocumento { get; set; }
        public string RotaSnapshotJson { get; set; }
        public string CargaSnapshotJson { get; set; }
        public string PreferenciasFiscaisJson { get; set; }
        public int Status { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<CTeRomaneioConsolidado> Query() => new MyApp.QueryBuilder.Query<CTeRomaneioConsolidado>();
    }

    public class CTeSolicitacaoFiscal
    {
        public int? Id { get; set; }
        public int? EntradaOficialId { get; set; }
        public CTeEntradaOficial CTeEntradaOficial { get; set; }
        public int? RomaneioConsolidadoId { get; set; }
        public CTeRomaneioConsolidado CTeRomaneioConsolidado { get; set; }
        public string CorrelationId { get; set; }
        public int Ambiente { get; set; }
        public string UFEmitente { get; set; }
        public string EmitenteDocumento { get; set; }
        public int ProdutoFiscal { get; set; }
        public int TipoCTe { get; set; }
        public int TipoServico { get; set; }
        public int Modal { get; set; }
        public int Globalizado { get; set; }
        public string UFInicio { get; set; }
        public string UFFim { get; set; }
        public string MunicipioInicioCodigoIbge { get; set; }
        public string MunicipioFimCodigoIbge { get; set; }
        public Decimal? ValorServico { get; set; }
        public Decimal? ValorCarga { get; set; }
        public string PreferenciasManifestoJson { get; set; }
        public int Status { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<CTeSolicitacaoFiscal> Query() => new MyApp.QueryBuilder.Query<CTeSolicitacaoFiscal>();
    }

    public class CTeDocumentoOriginario
    {
        public int? Id { get; set; }
        public int CTeSolicitacaoFiscalId { get; set; }
        public CTeSolicitacaoFiscal CTeSolicitacaoFiscal { get; set; }
        public int? DocumentoFiscalOriginarioId { get; set; }
        public DocumentoFiscalOriginario DocumentoFiscalOriginario { get; set; }
        public string TipoDocumento { get; set; }
        public string ChaveAcesso { get; set; }
        public string Numero { get; set; }
        public string Serie { get; set; }
        public string EmitenteDocumento { get; set; }
        public string DestinatarioDocumento { get; set; }
        public Decimal? ValorDocumento { get; set; }
        public Decimal? PesoBruto { get; set; }
        public string SnapshotJson { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<CTeDocumentoOriginario> Query() => new MyApp.QueryBuilder.Query<CTeDocumentoOriginario>();
    }

    public class CTeParticipanteSnapshot
    {
        public int? Id { get; set; }
        public int CTeSolicitacaoFiscalId { get; set; }
        public CTeSolicitacaoFiscal CTeSolicitacaoFiscal { get; set; }
        public string Papel { get; set; }
        public string Documento { get; set; }
        public string Nome { get; set; }
        public string InscricaoEstadual { get; set; }
        public string UF { get; set; }
        public string MunicipioCodigoIbge { get; set; }
        public string EnderecoJson { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<CTeParticipanteSnapshot> Query() => new MyApp.QueryBuilder.Query<CTeParticipanteSnapshot>();
    }

    public class CTeTentativaEmissao
    {
        public int? Id { get; set; }
        public int CTeSolicitacaoFiscalId { get; set; }
        public CTeSolicitacaoFiscal CTeSolicitacaoFiscal { get; set; }
        public string ChaveAcesso { get; set; }
        public int? Numero { get; set; }
        public int? Serie { get; set; }
        public int Tentativa { get; set; }
        public string XmlAssinadoStorageKey { get; set; }
        public string XmlProcStorageKey { get; set; }
        public string XmlHash { get; set; }
        public string CodigoRetorno { get; set; }
        public string MensagemRetorno { get; set; }
        public string ProtocoloAutorizacao { get; set; }
        public DateTime? EnviadoEmUtc { get; set; }
        public DateTime? AutorizadoEmUtc { get; set; }
        public int Status { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<CTeTentativaEmissao> Query() => new MyApp.QueryBuilder.Query<CTeTentativaEmissao>();
    }

    public class CTeSaidaMDFe
    {
        public int? Id { get; set; }
        public int CTeTentativaEmissaoId { get; set; }
        public CTeTentativaEmissao CTeTentativaEmissao { get; set; }
        public string CorrelationId { get; set; }
        public string ChaveAcessoCTe { get; set; }
        public string SnapshotHash { get; set; }
        public string OutboxMessageId { get; set; }
        public DateTime? PublicadoEmUtc { get; set; }
        public string UltimoErro { get; set; }
        public int Status { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<CTeSaidaMDFe> Query() => new MyApp.QueryBuilder.Query<CTeSaidaMDFe>();
    }

    public class MDFe
    {
        public int? Id { get; set; }
        public string ChaveAcesso { get; set; }
        public int Serie { get; set; }
        public int Numero { get; set; }
        public string UfCarregamento { get; set; }
        public string UfDescarregamento { get; set; }
        public string PlacaVeiculo { get; set; }
        public DateTime EmitidoEm { get; set; }
        public DateTime? AutorizadoEm { get; set; }
        public DateTime? IniciadoEm { get; set; }
        public DateTime? EncerradoEm { get; set; }
        public DateTime? CanceladoEm { get; set; }
        public int Situacao { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<MDFe> Query() => new MyApp.QueryBuilder.Query<MDFe>();
    }

    public class MDFeSolicitacaoFiscal
    {
        public int? Id { get; set; }
        public string CorrelationId { get; set; }
        public string CargaId { get; set; }
        public int Ambiente { get; set; }
        public string UFCarregamento { get; set; }
        public string UFDescarregamento { get; set; }
        public string PlacaVeiculo { get; set; }
        public string CondutorDocumento { get; set; }
        public string DocumentosOriginariosJson { get; set; }
        public string TransporteSnapshotJson { get; set; }
        public int Status { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<MDFeSolicitacaoFiscal> Query() => new MyApp.QueryBuilder.Query<MDFeSolicitacaoFiscal>();
    }

    public class MDFeDocumentoOriginario
    {
        public int? Id { get; set; }
        public int MDFeSolicitacaoFiscalId { get; set; }
        public MDFeSolicitacaoFiscal MDFeSolicitacaoFiscal { get; set; }
        public int? DocumentoFiscalOriginarioId { get; set; }
        public DocumentoFiscalOriginario DocumentoFiscalOriginario { get; set; }
        public string TipoDocumento { get; set; }
        public string ChaveAcesso { get; set; }
        public string SnapshotJson { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<MDFeDocumentoOriginario> Query() => new MyApp.QueryBuilder.Query<MDFeDocumentoOriginario>();
    }

    public class MDFePercurso
    {
        public int? Id { get; set; }
        public int MDFeSolicitacaoFiscalId { get; set; }
        public MDFeSolicitacaoFiscal MDFeSolicitacaoFiscal { get; set; }
        public string UF { get; set; }
        public int Ordem { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<MDFePercurso> Query() => new MyApp.QueryBuilder.Query<MDFePercurso>();
    }

    public class MDFeVeiculo
    {
        public int? Id { get; set; }
        public int MDFeSolicitacaoFiscalId { get; set; }
        public MDFeSolicitacaoFiscal MDFeSolicitacaoFiscal { get; set; }
        public string Placa { get; set; }
        public string Renavam { get; set; }
        public Decimal? Tara { get; set; }
        public Decimal? CapacidadeKg { get; set; }
        public Decimal? CapacidadeM3 { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<MDFeVeiculo> Query() => new MyApp.QueryBuilder.Query<MDFeVeiculo>();
    }

    public class MDFeCondutor
    {
        public int? Id { get; set; }
        public int MDFeSolicitacaoFiscalId { get; set; }
        public MDFeSolicitacaoFiscal MDFeSolicitacaoFiscal { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<MDFeCondutor> Query() => new MyApp.QueryBuilder.Query<MDFeCondutor>();
    }

    public class MDFeTentativaEmissao
    {
        public int? Id { get; set; }
        public int MDFeSolicitacaoFiscalId { get; set; }
        public MDFeSolicitacaoFiscal MDFeSolicitacaoFiscal { get; set; }
        public string ChaveAcesso { get; set; }
        public int? Numero { get; set; }
        public int? Serie { get; set; }
        public int Tentativa { get; set; }
        public string XmlAssinadoStorageKey { get; set; }
        public string XmlProcStorageKey { get; set; }
        public string XmlHash { get; set; }
        public string CodigoRetorno { get; set; }
        public string MensagemRetorno { get; set; }
        public string ProtocoloAutorizacao { get; set; }
        public DateTime? EnviadoEmUtc { get; set; }
        public DateTime? AutorizadoEmUtc { get; set; }
        public int Status { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<MDFeTentativaEmissao> Query() => new MyApp.QueryBuilder.Query<MDFeTentativaEmissao>();
    }

    public class MDFeEncerramento
    {
        public int? Id { get; set; }
        public int MDFeId { get; set; }
        public MDFe MDFe { get; set; }
        public string ChaveAcesso { get; set; }
        public string UfCarregamento { get; set; }
        public string UfDescarregamento { get; set; }
        public string PlacaVeiculo { get; set; }
        public DateTime SolicitadoEm { get; set; }
        public DateTime? AutorizadoEm { get; set; }
        public string Protocolo { get; set; }
        public string CodigoRetorno { get; set; }
        public string MensagemRetorno { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<MDFeEncerramento> Query() => new MyApp.QueryBuilder.Query<MDFeEncerramento>();
    }

    public class SefazEndpoint
    {
        public int? Id { get; set; }
        public int ProdutoFiscal { get; set; }
        public string UF { get; set; }
        public int Ambiente { get; set; }
        public string Servico { get; set; }
        public string Versao { get; set; }
        public string Url { get; set; }
        public int Ativo { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<SefazEndpoint> Query() => new MyApp.QueryBuilder.Query<SefazEndpoint>();
    }

    public class CertificadoDigital
    {
        public int? Id { get; set; }
        public string Apelido { get; set; }
        public string DocumentoTitular { get; set; }
        public string StorageKey { get; set; }
        public string Thumbprint { get; set; }
        public DateTime? ValidoDe { get; set; }
        public DateTime? ValidoAte { get; set; }
        public int Ativo { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<CertificadoDigital> Query() => new MyApp.QueryBuilder.Query<CertificadoDigital>();
    }

    public class EntradaFiscalContingencia
    {
        public int? Id { get; set; }
        public string CorrelationId { get; set; }
        public string CargaId { get; set; }
        public int TipoSolicitante { get; set; }
        public int Ambiente { get; set; }
        public string SourceApplication { get; set; }
        public string SourceModule { get; set; }
        public string SourceMessageId { get; set; }
        public string EmitenteFiscalDocumento { get; set; }
        public string TomadorDocumento { get; set; }
        public string TransportadorDocumento { get; set; }
        public string RemetenteDocumento { get; set; }
        public string DestinatarioDocumento { get; set; }
        public string UFInicio { get; set; }
        public string UFFim { get; set; }
        public string MunicipioInicioCodigoIbge { get; set; }
        public string MunicipioFimCodigoIbge { get; set; }
        public string RNTRC { get; set; }
        public string PlacaVeiculo { get; set; }
        public string UFVeiculo { get; set; }
        public string CondutorDocumento { get; set; }
        public string CondutorNome { get; set; }
        public int? QuantidadeDocumentos { get; set; }
        public Decimal? ValorCarga { get; set; }
        public Decimal? PesoBruto { get; set; }
        public Decimal? Volume { get; set; }
        public string PendenciasJson { get; set; }
        public string SnapshotJson { get; set; }
        public string EmissaoFiscalCorrelationId { get; set; }
        public int? EmissaoFiscalSagaId { get; set; }
        public DateTime CriadoEmUtc { get; set; }
        public DateTime? AtualizadoEmUtc { get; set; }
        public int Status { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }

        public static MyApp.QueryBuilder.Query<EntradaFiscalContingencia> Query() => new MyApp.QueryBuilder.Query<EntradaFiscalContingencia>();
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

    public class yToken
    {
        public int? Id { get; set; }
        public string TokenHash { get; set; }
        public string Description { get; set; }
        public string ConnectorKey { get; set; }
        public bool Active { get; set; }
        public DateTime? ValidUntil { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastUsedAt { get; set; }
        public int? TenantID { get; set; }
        public yTenant yTenant { get; set; }
        public int? UserId { get; set; }
        public yUser yUser { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? Changed { get; set; }

        public static MyApp.QueryBuilder.Query<yToken> Query() => new MyApp.QueryBuilder.Query<yToken>();
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