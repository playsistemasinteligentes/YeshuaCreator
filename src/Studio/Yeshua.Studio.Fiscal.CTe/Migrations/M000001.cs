using Dominio.Migration;
using Migration.Dominio.Schemas.CQRS;

namespace Yeshua.Studio.Fiscal.CTe.Migrations;

[Migration(000001)]
public class M000001 : MigrationBase
{
    public override void Up()
    {
        AddModule("FCTE", "Fiscal CT-e");

        AddEntity("CTeEntradaOficial", "Entrada Oficial CT-e").AddModule("FCTE")
            .AddColumn("Id", "ID").Int().Incremento().Key()
            .AddColumn("CorrelationId", "CorrelationId").Varchar(100).NotNull()
            .AddColumn("SourceApplication", "Aplicacao Origem").Varchar(100).NotNull()
            .AddColumn("SourceModule", "Modulo Origem").Varchar(100)
            .AddColumn("SourceMessageId", "Mensagem Origem").Varchar(100).NotNull()
            .AddColumn("MessageType", "Tipo da Mensagem").Varchar(120).NotNull()
            .AddColumn("MessageVersion", "Versao da Mensagem").Varchar(20).NotNull()
            .AddColumn("ReceivedAtUtc", "Recebido em UTC").DateTime().NotNull()
            .AddColumn("PayloadHash", "Hash do Payload").Varchar(100).NotNull()
            .AddColumn("PayloadStorageKey", "Storage do Payload").Varchar(500)
            .AddColumn("Status", "Status da Entrada").Int().NotNull()
                .Enumerable(1, "Recebida")
                .Enumerable(2, "Normalizada")
                .Enumerable(3, "Rejeitada")
                .Enumerable(4, "Processada")
                .Enumerable(5, "Falha");

        AddEntity("CTeRomaneioConsolidado", "Romaneio Consolidado Para CT-e").AddModule("FCTE")
            .AddColumn("Id", "ID").Int().Incremento().Key()
            .AddColumn("EntradaOficialId", "Entrada Oficial").FK("CTeEntradaOficial", "Id").Int().NotNull()
            .AddColumn("CorrelationId", "CorrelationId").Varchar(100).NotNull()
            .AddColumn("RomaneioId", "Romaneio").Varchar(80).NotNull()
            .AddColumn("CargaId", "Carga").Varchar(80)
            .AddColumn("ConsolidadoEmUtc", "Consolidado em UTC").DateTime().NotNull()
            .AddColumn("UFInicio", "UF Inicio").Varchar(2).NotNull()
            .AddColumn("UFFim", "UF Fim").Varchar(2).NotNull()
            .AddColumn("MunicipioInicioCodigoIbge", "Municipio Inicio").Varchar(7)
            .AddColumn("MunicipioFimCodigoIbge", "Municipio Fim").Varchar(7)
            .AddColumn("EmitenteDocumento", "Emitente Documento").Varchar(14)
            .AddColumn("TomadorDocumento", "Tomador Documento").Varchar(14)
            .AddColumn("RotaSnapshotJson", "Snapshot da Rota").Varchar(4000)
            .AddColumn("CargaSnapshotJson", "Snapshot da Carga").Varchar(8000)
            .AddColumn("PreferenciasFiscaisJson", "Preferencias Fiscais").Varchar(4000)
            .AddColumn("Status", "Status do Romaneio").Int().NotNull()
                .Enumerable(1, "Recebido")
                .Enumerable(2, "SolicitacaoCriada")
                .Enumerable(3, "PendenteDados")
                .Enumerable(4, "Rejeitado")
                .Enumerable(5, "Processado");

        AddEntity("CTeSolicitacaoFiscal", "Solicitacao Fiscal CT-e").AddModule("FCTE")
            .AddColumn("Id", "ID").Int().Incremento().Key()
            .AddColumn("EntradaOficialId", "Entrada Oficial").FK("CTeEntradaOficial", "Id").Int()
            .AddColumn("RomaneioConsolidadoId", "Romaneio Consolidado").FK("CTeRomaneioConsolidado", "Id").Int()
            .AddColumn("CorrelationId", "CorrelationId").Varchar(100).NotNull()
            .AddColumn("Ambiente", "Ambiente").Int().NotNull()
                .Enumerable(1, "Producao")
                .Enumerable(2, "Homologacao")
            .AddColumn("UFEmitente", "UF Emitente").Varchar(2).NotNull()
            .AddColumn("EmitenteDocumento", "Emitente Documento").Varchar(14).NotNull()
            .AddColumn("ProdutoFiscal", "Produto Fiscal").Int().NotNull()
                .Enumerable(57, "CTe")
            .AddColumn("TipoCTe", "Tipo CT-e").Int().NotNull()
                .Enumerable(0, "Normal")
                .Enumerable(1, "Complementar")
                .Enumerable(2, "Anulacao")
                .Enumerable(3, "Substituicao")
            .AddColumn("TipoServico", "Tipo Servico").Int().NotNull()
                .Enumerable(0, "Normal")
                .Enumerable(1, "Subcontratacao")
                .Enumerable(2, "Redespacho")
                .Enumerable(3, "RedespachoIntermediario")
                .Enumerable(4, "Multimodal")
            .AddColumn("Modal", "Modal").Int().NotNull()
                .Enumerable(1, "Rodoviario")
                .Enumerable(2, "Aereo")
                .Enumerable(3, "Aquaviario")
                .Enumerable(4, "Ferroviario")
                .Enumerable(5, "Dutoviario")
                .Enumerable(6, "Multimodal")
            .AddColumn("Globalizado", "Globalizado").Int().NotNull()
                .Enumerable(0, "Nao")
                .Enumerable(1, "Sim")
            .AddColumn("UFInicio", "UF Inicio").Varchar(2).NotNull()
            .AddColumn("UFFim", "UF Fim").Varchar(2).NotNull()
            .AddColumn("MunicipioInicioCodigoIbge", "Municipio Inicio").Varchar(7)
            .AddColumn("MunicipioFimCodigoIbge", "Municipio Fim").Varchar(7)
            .AddColumn("ValorServico", "Valor Servico").Decimal(18, 2)
            .AddColumn("ValorCarga", "Valor Carga").Decimal(18, 2)
            .AddColumn("PreferenciasManifestoJson", "Preferencias Manifesto").Varchar(4000)
            .AddColumn("Status", "Status da Solicitacao").Int().NotNull()
                .Enumerable(1, "Aberta")
                .Enumerable(2, "Classificada")
                .Enumerable(3, "ProntaParaEmissao")
                .Enumerable(4, "Autorizada")
                .Enumerable(5, "Rejeitada")
                .Enumerable(6, "FalhaTecnica");

        AddEntity("CTeDocumentoOriginario", "Documento Originario CT-e").AddModule("FCTE")
            .AddColumn("Id", "ID").Int().Incremento().Key()
            .AddColumn("CTeSolicitacaoFiscalId", "Solicitacao CT-e").FK("CTeSolicitacaoFiscal", "Id").Int().NotNull()
            .AddColumn("TipoDocumento", "Tipo Documento").Varchar(30).NotNull()
            .AddColumn("ChaveAcesso", "Chave de Acesso").Varchar(44)
            .AddColumn("Numero", "Numero").Varchar(30)
            .AddColumn("Serie", "Serie").Varchar(10)
            .AddColumn("EmitenteDocumento", "Emitente Documento").Varchar(14)
            .AddColumn("DestinatarioDocumento", "Destinatario Documento").Varchar(14)
            .AddColumn("ValorDocumento", "Valor Documento").Decimal(18, 2)
            .AddColumn("PesoBruto", "Peso Bruto").Decimal(18, 6)
            .AddColumn("SnapshotJson", "Snapshot").Varchar(8000);

        AddEntity("CTeParticipanteSnapshot", "Participante CT-e").AddModule("FCTE")
            .AddColumn("Id", "ID").Int().Incremento().Key()
            .AddColumn("CTeSolicitacaoFiscalId", "Solicitacao CT-e").FK("CTeSolicitacaoFiscal", "Id").Int().NotNull()
            .AddColumn("Papel", "Papel").Varchar(40).NotNull()
            .AddColumn("Documento", "Documento").Varchar(14).NotNull()
            .AddColumn("Nome", "Nome").Varchar(200)
            .AddColumn("InscricaoEstadual", "Inscricao Estadual").Varchar(30)
            .AddColumn("UF", "UF").Varchar(2)
            .AddColumn("MunicipioCodigoIbge", "Municipio IBGE").Varchar(7)
            .AddColumn("EnderecoJson", "Endereco").Varchar(4000);

        AddEntity("CTeTentativaEmissao", "Tentativa de Emissao CT-e").AddModule("FCTE")
            .AddColumn("Id", "ID").Int().Incremento().Key()
            .AddColumn("CTeSolicitacaoFiscalId", "Solicitacao CT-e").FK("CTeSolicitacaoFiscal", "Id").Int().NotNull()
            .AddColumn("ChaveAcesso", "Chave de Acesso").Varchar(44)
            .AddColumn("Numero", "Numero").Int()
            .AddColumn("Serie", "Serie").Int()
            .AddColumn("Tentativa", "Tentativa").Int().NotNull()
            .AddColumn("XmlAssinadoStorageKey", "XML Assinado").Varchar(500)
            .AddColumn("XmlProcStorageKey", "procCTe").Varchar(500)
            .AddColumn("XmlHash", "Hash XML").Varchar(100)
            .AddColumn("CodigoRetorno", "cStat").Varchar(10)
            .AddColumn("MensagemRetorno", "xMotivo").Varchar(1000)
            .AddColumn("ProtocoloAutorizacao", "Protocolo").Varchar(30)
            .AddColumn("EnviadoEmUtc", "Enviado em UTC").DateTime()
            .AddColumn("AutorizadoEmUtc", "Autorizado em UTC").DateTime()
            .AddColumn("Status", "Status da Emissao").Int().NotNull()
                .Enumerable(1, "Pendente")
                .Enumerable(2, "Enviado")
                .Enumerable(3, "Autorizado")
                .Enumerable(4, "Rejeitado")
                .Enumerable(5, "FalhaTecnica");

        AddEntity("CTeSaidaMDFe", "Saida CT-e para MDF-e").AddModule("FCTE")
            .AddColumn("Id", "ID").Int().Incremento().Key()
            .AddColumn("CTeTentativaEmissaoId", "Tentativa CT-e").FK("CTeTentativaEmissao", "Id").Int().NotNull()
            .AddColumn("CorrelationId", "CorrelationId").Varchar(100).NotNull()
            .AddColumn("ChaveAcessoCTe", "Chave CT-e").Varchar(44).NotNull()
            .AddColumn("SnapshotHash", "Hash Snapshot").Varchar(100).NotNull()
            .AddColumn("OutboxMessageId", "Mensagem Outbox").Varchar(100)
            .AddColumn("PublicadoEmUtc", "Publicado em UTC").DateTime()
            .AddColumn("UltimoErro", "Ultimo Erro").Varchar(2000)
            .AddColumn("Status", "Status da Saida").Int().NotNull()
                .Enumerable(1, "AguardandoPublicacao")
                .Enumerable(2, "PublicadoOutbox")
                .Enumerable(3, "EntregueInboxMDFe")
                .Enumerable(4, "ConsumidoPeloMDFe")
                .Enumerable(5, "FalhaNaEntrega");

        AddUsecaseGroup("FiscalCTe")
            .AddUseCaseSubGrup("Entrada")
            .AddCommand(
                "ReceberRomaneioConsolidadoParaCTe",
                new ReceberRomaneioConsolidadoParaCTeInput(
                    string.Empty,
                    0,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty),
                new ReceberRomaneioConsolidadoParaCTeOutput(string.Empty, false, string.Empty))
            .Authorization(Authorization.User)
            .AddScope("cte.romaneio.receber")
            .AddEntity("CTeRomaneioConsolidado");

        AddUsecaseGroup("FiscalCTe")
            .AddUseCaseSubGrup("Emissao")
            .AddCommand(
                "SolicitarEmissaoCTe",
                new SolicitarEmissaoCTeInput(0, string.Empty, string.Empty, 1, 57, 0, 0, 1),
                new SolicitarEmissaoCTeOutput(0, string.Empty, string.Empty, false))
            .Authorization(Authorization.User)
            .AddScope("cte.emissao.solicitar")
            .AddEntity("CTeSolicitacaoFiscal");

        AddUsecaseGroup("FiscalCTe")
            .AddUseCaseSubGrup("Emissao")
            .AddCommand(
                "AutorizarCTe",
                new AutorizarCTeInput(0, 1),
                new AutorizarCTeOutput(0, string.Empty, false, string.Empty, string.Empty))
            .Authorization(Authorization.User)
            .AddScope("cte.emissao.autorizar")
            .AddEntity("CTeTentativaEmissao");

        AddUsecaseGroup("FiscalCTe")
            .AddUseCaseSubGrup("IntegracaoMDFe")
            .AddCommand(
                "PublicarCTeAutorizadoParaMDFe",
                new PublicarCTeAutorizadoParaMDFeInput(0, string.Empty),
                new PublicarCTeAutorizadoParaMDFeOutput(false, string.Empty))
            .Authorization(Authorization.User)
            .AddScope("cte.mdfe.publicar")
            .AddEntity("CTeSaidaMDFe");

        // pendencia: a integracao CT-e -> MDF-e deve publicar snapshot em yOutbox
        // e ser consumida pelo MDF-e via yInbox/worker; nao usar SOAP/REST interno.
        // pendencia: adapters SOAP/REST de legado devem ficar em modulos anteriores
        // de recepcao/carga/integracao, convertendo contratos externos para mensagens oficiais.
    }
}

public sealed record ReceberRomaneioConsolidadoParaCTeInput(
    string CorrelationId,
    int TenantId,
    string SourceApplication,
    string SourceModule,
    string SourceMessageId,
    string RomaneioId,
    string CargaId,
    string UFInicio,
    string UFFim,
    string MunicipioInicioCodigoIbge,
    string MunicipioFimCodigoIbge,
    string EmitenteDocumento,
    string TomadorDocumento,
    string RotaSnapshotJson,
    string CargaSnapshotJson,
    string PreferenciasFiscaisJson,
    string PayloadHash,
    string PayloadStorageKey);

public sealed record ReceberRomaneioConsolidadoParaCTeOutput(
    string CorrelationId,
    bool Accepted,
    string Mensagem);

public sealed record SolicitarEmissaoCTeInput(
    int RomaneioConsolidadoId,
    string UFEmitente,
    string EmitenteDocumento,
    int Ambiente,
    int ProdutoFiscal,
    int TipoCTe,
    int TipoServico,
    int Modal);

public sealed record SolicitarEmissaoCTeOutput(
    int SolicitacaoId,
    string CorrelationId,
    string Status,
    bool ProntoParaAutorizar);

public sealed record AutorizarCTeInput(
    int SolicitacaoId,
    int SincronoAteAutorizacao);

public sealed record AutorizarCTeOutput(
    int TentativaId,
    string ChaveAcesso,
    bool Autorizado,
    string Protocolo,
    string Mensagem);

public sealed record PublicarCTeAutorizadoParaMDFeInput(
    int TentativaEmissaoId,
    string ChaveAcessoCTe);

public sealed record PublicarCTeAutorizadoParaMDFeOutput(
    bool Publicado,
    string Mensagem);
