using Dominio.Migration;
using Migration.Dominio.Schemas.CQRS;

namespace Yeshua.Studio.Fiscal.Migrations;

[Migration(000001)]
public class M000001 : MigrationBase
{
    public override void Up()
    {
        AddModule("FIS", "Fiscal");
        AddModule("DFE", "Documentos Fiscais Eletronicos");
        AddModule("CTE", "CT-e");
        AddModule("MDFE", "MDF-e");
        AddModule("NFE", "NF-e");
        AddModule("SEFAZ", "SEFAZ");
        AddModule("CONT", "Contingencia Fiscal");

        AddEntity("DocumentoFiscal", "Documento Fiscal").AddModule("DFE")
            .AddColumn("Id", "ID").Int().Incremento().Key().Group("Identificacao")
            .AddColumn("CorrelationId", "CorrelationId").Varchar(100).NotNull().Group("Origem")
            .AddColumn("ProdutoFiscal", "Produto Fiscal").Int().NotNull().Group("Identificacao")
                .Enumerable(55, "NFe")
                .Enumerable(57, "CTe")
                .Enumerable(58, "MDFe")
            .AddColumn("ChaveAcesso", "Chave de Acesso").Varchar(44).Group("Identificacao")
            .AddColumn("Serie", "Serie").Int().Group("Identificacao")
            .AddColumn("Numero", "Numero").Int().Group("Identificacao")
            .AddColumn("Ambiente", "Ambiente").Int().NotNull().Group("SEFAZ")
                .Enumerable(1, "Producao")
                .Enumerable(2, "Homologacao")
            .AddColumn("UFEmitente", "UF Emitente").Varchar(2).Group("SEFAZ")
            .AddColumn("EmitenteDocumento", "Emitente Documento").Varchar(14).Group("Participantes")
            .AddColumn("DestinatarioDocumento", "Destinatario Documento").Varchar(14).Group("Participantes")
            .AddColumn("XmlStorageKey", "XML").Varchar(500).Group("Arquivos")
            .AddColumn("XmlHash", "Hash XML").Varchar(100).Group("Arquivos")
            .AddColumn("ProtocoloAutorizacao", "Protocolo").Varchar(30).Group("SEFAZ")
            .AddColumn("CodigoRetorno", "cStat").Varchar(10).Group("SEFAZ")
            .AddColumn("MensagemRetorno", "xMotivo").Varchar(1000).Group("SEFAZ")
            .AddColumn("Status", "Status").Int().NotNull().Group("Status")
                .Enumerable(1, "Recebido")
                .Enumerable(2, "Preparado")
                .Enumerable(3, "Enviado")
                .Enumerable(4, "Autorizado")
                .Enumerable(5, "Rejeitado")
                .Enumerable(6, "Cancelado")
                .Enumerable(7, "FalhaTecnica");

        AddEntity("DocumentoFiscalOriginario", "Documento Fiscal Originario").AddModule("DFE")
            .AddColumn("Id", "ID").Int().Incremento().Key().Group("Identificacao")
            .AddColumn("DocumentoFiscalId", "Documento Fiscal").FK("DocumentoFiscal", "Id").Int().Group("Vinculo")
            .AddColumn("CorrelationId", "CorrelationId").Varchar(100).NotNull().Group("Origem")
            .AddColumn("SourceApplication", "Aplicacao Origem").Varchar(100).NotNull().Group("Origem")
            .AddColumn("SourceModule", "Modulo Origem").Varchar(100).Group("Origem")
            .AddColumn("SourceMessageId", "Mensagem Origem").Varchar(100).NotNull().Group("Origem")
            .AddColumn("TipoDocumento", "Tipo Documento").Varchar(30).NotNull().Group("Identificacao")
            .AddColumn("ChaveAcesso", "Chave de Acesso").Varchar(44).Group("Identificacao")
            .AddColumn("Numero", "Numero").Varchar(30).Group("Identificacao")
            .AddColumn("Serie", "Serie").Varchar(10).Group("Identificacao")
            .AddColumn("EmitenteDocumento", "Emitente Documento").Varchar(14).Group("Participantes")
            .AddColumn("DestinatarioDocumento", "Destinatario Documento").Varchar(14).Group("Participantes")
            .AddColumn("ValorDocumento", "Valor Documento").Decimal(18, 2).Group("Valores")
            .AddColumn("PesoBruto", "Peso Bruto").Decimal(18, 6).Group("Valores")
            .AddColumn("Volume", "Volume").Decimal(18, 6).Group("Valores")
            .AddColumn("SnapshotJson", "Snapshot").Varchar(8000).Group("Snapshot")
            .AddColumn("Status", "Status").Int().NotNull().Group("Status")
                .Enumerable(1, "Recebido")
                .Enumerable(2, "Vinculado")
                .Enumerable(3, "Rejeitado");

        AddEntity("NFeProdutoSnapshot", "NF-e de Produto").AddModule("NFE")
            .AddColumn("Id", "ID").Int().Incremento().Key().Group("Identificacao")
            .AddColumn("DocumentoFiscalOriginarioId", "Documento Originario").FK("DocumentoFiscalOriginario", "Id").Int().Group("Vinculo")
            .AddColumn("CorrelationId", "CorrelationId").Varchar(100).NotNull().Group("Origem")
            .AddColumn("CargaId", "Carga").Varchar(80).Group("Operacao")
            .AddColumn("PedidoId", "Pedido").Varchar(80).Group("Operacao")
            .AddColumn("ChaveAcesso", "Chave de Acesso").Varchar(44).NotNull().Group("Identificacao")
            .AddColumn("EmitenteDocumento", "Emitente Documento").Varchar(14).Group("Participantes")
            .AddColumn("DestinatarioDocumento", "Destinatario Documento").Varchar(14).Group("Participantes")
            .AddColumn("UFOrigem", "UF Origem").Varchar(2).Group("Rota")
            .AddColumn("UFDestino", "UF Destino").Varchar(2).Group("Rota")
            .AddColumn("MunicipioOrigemCodigoIbge", "Municipio Origem").Varchar(7).Group("Rota")
            .AddColumn("MunicipioDestinoCodigoIbge", "Municipio Destino").Varchar(7).Group("Rota")
            .AddColumn("ValorDocumento", "Valor Documento").Decimal(18, 2).Group("Valores")
            .AddColumn("PesoBruto", "Peso Bruto").Decimal(18, 6).Group("Valores")
            .AddColumn("Volume", "Volume").Decimal(18, 6).Group("Valores")
            .AddColumn("XmlStorageKey", "XML").Varchar(500).Group("Arquivos")
            .AddColumn("SnapshotJson", "Snapshot").Varchar(8000).Group("Snapshot")
            .AddColumn("Status", "Status").Int().NotNull().Group("Status")
                .Enumerable(1, "Recebida")
                .Enumerable(2, "DisponivelParaCTe")
                .Enumerable(3, "VinculadaAoCTe")
                .Enumerable(4, "Rejeitada");

        AddEntity("CTeEntradaOficial", "Entrada Oficial CT-e").AddModule("CTE")
            .AddColumn("Id", "ID").Int().Incremento().Key().Group("Identificacao")
            .AddColumn("CorrelationId", "CorrelationId").Varchar(100).NotNull().Group("Origem")
            .AddColumn("SourceApplication", "Aplicacao Origem").Varchar(100).NotNull().Group("Origem")
            .AddColumn("SourceModule", "Modulo Origem").Varchar(100).Group("Origem")
            .AddColumn("SourceMessageId", "Mensagem Origem").Varchar(100).NotNull().Group("Origem")
            .AddColumn("MessageType", "Tipo da Mensagem").Varchar(120).NotNull().Group("Origem")
            .AddColumn("MessageVersion", "Versao da Mensagem").Varchar(20).NotNull().Group("Origem")
            .AddColumn("ReceivedAtUtc", "Recebido em UTC").DateTime().NotNull().Group("Origem")
            .AddColumn("PayloadHash", "Hash do Payload").Varchar(100).NotNull().Group("Payload")
            .AddColumn("PayloadStorageKey", "Storage do Payload").Varchar(500).Group("Payload")
            .AddColumn("Status", "Status da Entrada").Int().NotNull().Group("Status")
                .Enumerable(1, "Recebida")
                .Enumerable(2, "Normalizada")
                .Enumerable(3, "Rejeitada")
                .Enumerable(4, "Processada")
                .Enumerable(5, "Falha");

        AddEntity("CTeRomaneioConsolidado", "Romaneio Consolidado Para CT-e").AddModule("CTE")
            .AddColumn("Id", "ID").Int().Incremento().Key().Group("Identificacao")
            .AddColumn("EntradaOficialId", "Entrada Oficial").FK("CTeEntradaOficial", "Id").Int().NotNull().Group("Vinculo")
            .AddColumn("CorrelationId", "CorrelationId").Varchar(100).NotNull().Group("Origem")
            .AddColumn("RomaneioId", "Romaneio").Varchar(80).NotNull().Group("Operacao")
            .AddColumn("CargaId", "Carga").Varchar(80).Group("Operacao")
            .AddColumn("ConsolidadoEmUtc", "Consolidado em UTC").DateTime().NotNull().Group("Operacao")
            .AddColumn("UFInicio", "UF Inicio").Varchar(2).NotNull().Group("Rota")
            .AddColumn("UFFim", "UF Fim").Varchar(2).NotNull().Group("Rota")
            .AddColumn("MunicipioInicioCodigoIbge", "Municipio Inicio").Varchar(7).Group("Rota")
            .AddColumn("MunicipioFimCodigoIbge", "Municipio Fim").Varchar(7).Group("Rota")
            .AddColumn("EmitenteDocumento", "Emitente Documento").Varchar(14).Group("Participantes")
            .AddColumn("TomadorDocumento", "Tomador Documento").Varchar(14).Group("Participantes")
            .AddColumn("RotaSnapshotJson", "Snapshot da Rota").Varchar(4000).Group("Snapshot")
            .AddColumn("CargaSnapshotJson", "Snapshot da Carga").Varchar(8000).Group("Snapshot")
            .AddColumn("PreferenciasFiscaisJson", "Preferencias Fiscais").Varchar(4000).Group("Snapshot")
            .AddColumn("Status", "Status do Romaneio").Int().NotNull().Group("Status")
                .Enumerable(1, "Recebido")
                .Enumerable(2, "SolicitacaoCriada")
                .Enumerable(3, "PendenteDados")
                .Enumerable(4, "Rejeitado")
                .Enumerable(5, "Processado");

        AddEntity("CTeSolicitacaoFiscal", "Solicitacao Fiscal CT-e").AddModule("CTE")
            .AddColumn("Id", "ID").Int().Incremento().Key().Group("Identificacao")
            .AddColumn("EntradaOficialId", "Entrada Oficial").FK("CTeEntradaOficial", "Id").Int().Group("Vinculo")
            .AddColumn("RomaneioConsolidadoId", "Romaneio Consolidado").FK("CTeRomaneioConsolidado", "Id").Int().Group("Vinculo")
            .AddColumn("CorrelationId", "CorrelationId").Varchar(100).NotNull().Group("Origem")
            .AddColumn("Ambiente", "Ambiente").Int().NotNull().Group("SEFAZ")
                .Enumerable(1, "Producao")
                .Enumerable(2, "Homologacao")
            .AddColumn("UFEmitente", "UF Emitente").Varchar(2).NotNull().Group("SEFAZ")
            .AddColumn("EmitenteDocumento", "Emitente Documento").Varchar(14).NotNull().Group("Participantes")
            .AddColumn("ProdutoFiscal", "Produto Fiscal").Int().NotNull().Group("Identificacao")
                .Enumerable(57, "CTe")
            .AddColumn("TipoCTe", "Tipo CT-e").Int().NotNull().Group("Identificacao")
                .Enumerable(0, "Normal")
                .Enumerable(1, "Complementar")
                .Enumerable(2, "Anulacao")
                .Enumerable(3, "Substituicao")
            .AddColumn("TipoServico", "Tipo Servico").Int().NotNull().Group("Servico")
                .Enumerable(0, "Normal")
                .Enumerable(1, "Subcontratacao")
                .Enumerable(2, "Redespacho")
                .Enumerable(3, "RedespachoIntermediario")
                .Enumerable(4, "Multimodal")
            .AddColumn("Modal", "Modal").Int().NotNull().Group("Servico")
                .Enumerable(1, "Rodoviario")
                .Enumerable(2, "Aereo")
                .Enumerable(3, "Aquaviario")
                .Enumerable(4, "Ferroviario")
                .Enumerable(5, "Dutoviario")
                .Enumerable(6, "Multimodal")
            .AddColumn("Globalizado", "Globalizado").Int().NotNull().Group("Servico")
                .Enumerable(0, "Nao")
                .Enumerable(1, "Sim")
            .AddColumn("UFInicio", "UF Inicio").Varchar(2).NotNull().Group("Rota")
            .AddColumn("UFFim", "UF Fim").Varchar(2).NotNull().Group("Rota")
            .AddColumn("MunicipioInicioCodigoIbge", "Municipio Inicio").Varchar(7).Group("Rota")
            .AddColumn("MunicipioFimCodigoIbge", "Municipio Fim").Varchar(7).Group("Rota")
            .AddColumn("ValorServico", "Valor Servico").Decimal(18, 2).Group("Valores")
            .AddColumn("ValorCarga", "Valor Carga").Decimal(18, 2).Group("Valores")
            .AddColumn("PreferenciasManifestoJson", "Preferencias Manifesto").Varchar(4000).Group("Snapshot")
            .AddColumn("Status", "Status da Solicitacao").Int().NotNull().Group("Status")
                .Enumerable(1, "Aberta")
                .Enumerable(2, "Classificada")
                .Enumerable(3, "ProntaParaEmissao")
                .Enumerable(4, "Autorizada")
                .Enumerable(5, "Rejeitada")
                .Enumerable(6, "FalhaTecnica");

        AddEntity("CTeDocumentoOriginario", "Documento Originario CT-e").AddModule("CTE")
            .AddColumn("Id", "ID").Int().Incremento().Key().Group("Identificacao")
            .AddColumn("CTeSolicitacaoFiscalId", "Solicitacao CT-e").FK("CTeSolicitacaoFiscal", "Id").Int().NotNull().Group("Vinculo")
            .AddColumn("DocumentoFiscalOriginarioId", "Documento Originario").FK("DocumentoFiscalOriginario", "Id").Int().Group("Vinculo")
            .AddColumn("TipoDocumento", "Tipo Documento").Varchar(30).NotNull().Group("Identificacao")
            .AddColumn("ChaveAcesso", "Chave de Acesso").Varchar(44).Group("Identificacao")
            .AddColumn("Numero", "Numero").Varchar(30).Group("Identificacao")
            .AddColumn("Serie", "Serie").Varchar(10).Group("Identificacao")
            .AddColumn("EmitenteDocumento", "Emitente Documento").Varchar(14).Group("Participantes")
            .AddColumn("DestinatarioDocumento", "Destinatario Documento").Varchar(14).Group("Participantes")
            .AddColumn("ValorDocumento", "Valor Documento").Decimal(18, 2).Group("Valores")
            .AddColumn("PesoBruto", "Peso Bruto").Decimal(18, 6).Group("Valores")
            .AddColumn("SnapshotJson", "Snapshot").Varchar(8000).Group("Snapshot");

        AddEntity("CTeParticipanteSnapshot", "Participante CT-e").AddModule("CTE")
            .AddColumn("Id", "ID").Int().Incremento().Key().Group("Identificacao")
            .AddColumn("CTeSolicitacaoFiscalId", "Solicitacao CT-e").FK("CTeSolicitacaoFiscal", "Id").Int().NotNull().Group("Vinculo")
            .AddColumn("Papel", "Papel").Varchar(40).NotNull().Group("Identificacao")
            .AddColumn("Documento", "Documento").Varchar(14).NotNull().Group("Identificacao")
            .AddColumn("Nome", "Nome").Varchar(200).Group("Identificacao")
            .AddColumn("InscricaoEstadual", "Inscricao Estadual").Varchar(30).Group("Fiscal")
            .AddColumn("UF", "UF").Varchar(2).Group("Endereco")
            .AddColumn("MunicipioCodigoIbge", "Municipio IBGE").Varchar(7).Group("Endereco")
            .AddColumn("EnderecoJson", "Endereco").Varchar(4000).Group("Endereco");

        AddEntity("CTeTentativaEmissao", "Tentativa de Emissao CT-e").AddModule("CTE")
            .AddColumn("Id", "ID").Int().Incremento().Key().Group("Identificacao")
            .AddColumn("CTeSolicitacaoFiscalId", "Solicitacao CT-e").FK("CTeSolicitacaoFiscal", "Id").Int().NotNull().Group("Vinculo")
            .AddColumn("ChaveAcesso", "Chave de Acesso").Varchar(44).Group("Identificacao")
            .AddColumn("Numero", "Numero").Int().Group("Identificacao")
            .AddColumn("Serie", "Serie").Int().Group("Identificacao")
            .AddColumn("Tentativa", "Tentativa").Int().NotNull().Group("Operacao")
            .AddColumn("XmlAssinadoStorageKey", "XML Assinado").Varchar(500).Group("Arquivos")
            .AddColumn("XmlProcStorageKey", "procCTe").Varchar(500).Group("Arquivos")
            .AddColumn("XmlHash", "Hash XML").Varchar(100).Group("Arquivos")
            .AddColumn("CodigoRetorno", "cStat").Varchar(10).Group("SEFAZ")
            .AddColumn("MensagemRetorno", "xMotivo").Varchar(1000).Group("SEFAZ")
            .AddColumn("ProtocoloAutorizacao", "Protocolo").Varchar(30).Group("SEFAZ")
            .AddColumn("EnviadoEmUtc", "Enviado em UTC").DateTime().Group("SEFAZ")
            .AddColumn("AutorizadoEmUtc", "Autorizado em UTC").DateTime().Group("SEFAZ")
            .AddColumn("Status", "Status da Emissao").Int().NotNull().Group("Status")
                .Enumerable(1, "Pendente")
                .Enumerable(2, "Enviado")
                .Enumerable(3, "Autorizado")
                .Enumerable(4, "Rejeitado")
                .Enumerable(5, "FalhaTecnica");

        AddEntity("CTeSaidaMDFe", "Saida CT-e para MDF-e").AddModule("CTE")
            .AddColumn("Id", "ID").Int().Incremento().Key().Group("Identificacao")
            .AddColumn("CTeTentativaEmissaoId", "Tentativa CT-e").FK("CTeTentativaEmissao", "Id").Int().NotNull().Group("Vinculo")
            .AddColumn("CorrelationId", "CorrelationId").Varchar(100).NotNull().Group("Origem")
            .AddColumn("ChaveAcessoCTe", "Chave CT-e").Varchar(44).NotNull().Group("Identificacao")
            .AddColumn("SnapshotHash", "Hash Snapshot").Varchar(100).NotNull().Group("Snapshot")
            .AddColumn("OutboxMessageId", "Mensagem Outbox").Varchar(100).Group("Entrega")
            .AddColumn("PublicadoEmUtc", "Publicado em UTC").DateTime().Group("Entrega")
            .AddColumn("UltimoErro", "Ultimo Erro").Varchar(2000).Group("Entrega")
            .AddColumn("Status", "Status da Saida").Int().NotNull().Group("Status")
                .Enumerable(1, "AguardandoPublicacao")
                .Enumerable(2, "PublicadoOutbox")
                .Enumerable(3, "EntregueInboxMDFe")
                .Enumerable(4, "ConsumidoPeloMDFe")
                .Enumerable(5, "FalhaNaEntrega");

        AddEntity("MDFe", "MDF-e").AddModule("MDFE")
            .AddColumn("Id", "ID").Int().Incremento().Key()
            .AddColumn("ChaveAcesso", "Chave de Acesso").Varchar(44).NotNull()
            .AddColumn("Serie", "Serie").Int().NotNull()
            .AddColumn("Numero", "Numero").Int().NotNull()
            .AddColumn("UfCarregamento", "UF de Carregamento").Varchar(2).NotNull()
            .AddColumn("UfDescarregamento", "UF de Descarregamento").Varchar(2).NotNull()
            .AddColumn("PlacaVeiculo", "Placa do Veiculo").Varchar(7).NotNull()
            .AddColumn("EmitidoEm", "Emitido em").DateTime().NotNull()
            .AddColumn("AutorizadoEm", "Autorizado em").DateTime()
            .AddColumn("IniciadoEm", "Inicio do Transporte").DateTime()
            .AddColumn("EncerradoEm", "Encerrado em").DateTime()
            .AddColumn("CanceladoEm", "Cancelado em").DateTime()
            .AddColumn("Situacao", "Situacao do MDF-e").Int().NotNull()
                .Enumerable(1, "Autorizado")
                .Enumerable(2, "EmTransporte")
                .Enumerable(3, "Encerrado")
                .Enumerable(4, "Cancelado");

        AddEntity("MDFeSolicitacaoFiscal", "Solicitacao Fiscal MDF-e").AddModule("MDFE")
            .AddColumn("Id", "ID").Int().Incremento().Key().Group("Identificacao")
            .AddColumn("CorrelationId", "CorrelationId").Varchar(100).NotNull().Group("Origem")
            .AddColumn("CargaId", "Carga").Varchar(80).Group("Operacao")
            .AddColumn("Ambiente", "Ambiente").Int().NotNull().Group("SEFAZ")
                .Enumerable(1, "Producao")
                .Enumerable(2, "Homologacao")
            .AddColumn("UFCarregamento", "UF de Carregamento").Varchar(2).NotNull().Group("Rota")
            .AddColumn("UFDescarregamento", "UF de Descarregamento").Varchar(2).NotNull().Group("Rota")
            .AddColumn("PlacaVeiculo", "Placa do Veiculo").Varchar(7).Group("Transporte")
            .AddColumn("CondutorDocumento", "Documento do Condutor").Varchar(14).Group("Transporte")
            .AddColumn("DocumentosOriginariosJson", "Documentos Originarios").Varchar(8000).Group("Snapshot")
            .AddColumn("TransporteSnapshotJson", "Snapshot Transporte").Varchar(8000).Group("Snapshot")
            .AddColumn("Status", "Status").Int().NotNull().Group("Status")
                .Enumerable(1, "Aberta")
                .Enumerable(2, "ProntaParaEmissao")
                .Enumerable(3, "Autorizada")
                .Enumerable(4, "Rejeitada")
                .Enumerable(5, "FalhaTecnica");

        AddEntity("MDFeDocumentoOriginario", "Documento Originario MDF-e").AddModule("MDFE")
            .AddColumn("Id", "ID").Int().Incremento().Key().Group("Identificacao")
            .AddColumn("MDFeSolicitacaoFiscalId", "Solicitacao MDF-e").FK("MDFeSolicitacaoFiscal", "Id").Int().NotNull().Group("Vinculo")
            .AddColumn("DocumentoFiscalOriginarioId", "Documento Originario").FK("DocumentoFiscalOriginario", "Id").Int().Group("Vinculo")
            .AddColumn("TipoDocumento", "Tipo Documento").Varchar(30).NotNull().Group("Identificacao")
            .AddColumn("ChaveAcesso", "Chave de Acesso").Varchar(44).Group("Identificacao")
            .AddColumn("SnapshotJson", "Snapshot").Varchar(8000).Group("Snapshot");

        AddEntity("MDFePercurso", "Percurso MDF-e").AddModule("MDFE")
            .AddColumn("Id", "ID").Int().Incremento().Key().Group("Identificacao")
            .AddColumn("MDFeSolicitacaoFiscalId", "Solicitacao MDF-e").FK("MDFeSolicitacaoFiscal", "Id").Int().NotNull().Group("Vinculo")
            .AddColumn("UF", "UF").Varchar(2).NotNull().Group("Percurso")
            .AddColumn("Ordem", "Ordem").Int().NotNull().Group("Percurso");

        AddEntity("MDFeVeiculo", "Veiculo MDF-e").AddModule("MDFE")
            .AddColumn("Id", "ID").Int().Incremento().Key().Group("Identificacao")
            .AddColumn("MDFeSolicitacaoFiscalId", "Solicitacao MDF-e").FK("MDFeSolicitacaoFiscal", "Id").Int().NotNull().Group("Vinculo")
            .AddColumn("Placa", "Placa").Varchar(7).NotNull().Group("Veiculo")
            .AddColumn("Renavam", "Renavam").Varchar(20).Group("Veiculo")
            .AddColumn("Tara", "Tara").Decimal(18, 6).Group("Veiculo")
            .AddColumn("CapacidadeKg", "Capacidade KG").Decimal(18, 6).Group("Veiculo")
            .AddColumn("CapacidadeM3", "Capacidade M3").Decimal(18, 6).Group("Veiculo");

        AddEntity("MDFeCondutor", "Condutor MDF-e").AddModule("MDFE")
            .AddColumn("Id", "ID").Int().Incremento().Key().Group("Identificacao")
            .AddColumn("MDFeSolicitacaoFiscalId", "Solicitacao MDF-e").FK("MDFeSolicitacaoFiscal", "Id").Int().NotNull().Group("Vinculo")
            .AddColumn("Nome", "Nome").Varchar(200).NotNull().Group("Condutor")
            .AddColumn("Documento", "Documento").Varchar(14).NotNull().Group("Condutor");

        AddEntity("MDFeTentativaEmissao", "Tentativa de Emissao MDF-e").AddModule("MDFE")
            .AddColumn("Id", "ID").Int().Incremento().Key().Group("Identificacao")
            .AddColumn("MDFeSolicitacaoFiscalId", "Solicitacao MDF-e").FK("MDFeSolicitacaoFiscal", "Id").Int().NotNull().Group("Vinculo")
            .AddColumn("ChaveAcesso", "Chave de Acesso").Varchar(44).Group("Identificacao")
            .AddColumn("Numero", "Numero").Int().Group("Identificacao")
            .AddColumn("Serie", "Serie").Int().Group("Identificacao")
            .AddColumn("Tentativa", "Tentativa").Int().NotNull().Group("Operacao")
            .AddColumn("XmlAssinadoStorageKey", "XML Assinado").Varchar(500).Group("Arquivos")
            .AddColumn("XmlProcStorageKey", "procMDFe").Varchar(500).Group("Arquivos")
            .AddColumn("XmlHash", "Hash XML").Varchar(100).Group("Arquivos")
            .AddColumn("CodigoRetorno", "cStat").Varchar(10).Group("SEFAZ")
            .AddColumn("MensagemRetorno", "xMotivo").Varchar(1000).Group("SEFAZ")
            .AddColumn("ProtocoloAutorizacao", "Protocolo").Varchar(30).Group("SEFAZ")
            .AddColumn("EnviadoEmUtc", "Enviado em UTC").DateTime().Group("SEFAZ")
            .AddColumn("AutorizadoEmUtc", "Autorizado em UTC").DateTime().Group("SEFAZ")
            .AddColumn("Status", "Status da Emissao").Int().NotNull().Group("Status")
                .Enumerable(1, "Pendente")
                .Enumerable(2, "Enviado")
                .Enumerable(3, "Autorizado")
                .Enumerable(4, "Rejeitado")
                .Enumerable(5, "FalhaTecnica");

        AddEntity("MDFeEncerramento", "Encerramento MDF-e").AddModule("MDFE")
            .AddColumn("Id", "ID").Int().Incremento().Key()
            .AddColumn("MDFeId", "MDF-e").FK("MDFe", "Id").Int().NotNull()
            .AddColumn("ChaveAcesso", "Chave de Acesso").Varchar(44).NotNull()
            .AddColumn("UfCarregamento", "UF de Carregamento").Varchar(2).NotNull()
            .AddColumn("UfDescarregamento", "UF de Descarregamento").Varchar(2).NotNull()
            .AddColumn("PlacaVeiculo", "Placa do Veiculo").Varchar(7).NotNull()
            .AddColumn("SolicitadoEm", "Solicitado em").DateTime().NotNull()
            .AddColumn("AutorizadoEm", "Autorizado em").DateTime()
            .AddColumn("Protocolo", "Protocolo SEFAZ").Varchar(20)
            .AddColumn("CodigoRetorno", "Codigo de Retorno").Varchar(10)
            .AddColumn("MensagemRetorno", "Mensagem de Retorno").Varchar(500);

        AddEntity("SefazEndpoint", "Endpoint SEFAZ").AddModule("SEFAZ")
            .AddColumn("Id", "ID").Int().Incremento().Key().Group("Identificacao")
            .AddColumn("ProdutoFiscal", "Produto Fiscal").Int().NotNull().Group("Servico")
                .Enumerable(55, "NFe")
                .Enumerable(57, "CTe")
                .Enumerable(58, "MDFe")
            .AddColumn("UF", "UF").Varchar(2).NotNull().Group("Servico")
            .AddColumn("Ambiente", "Ambiente").Int().NotNull().Group("Servico")
                .Enumerable(1, "Producao")
                .Enumerable(2, "Homologacao")
            .AddColumn("Servico", "Servico").Varchar(120).NotNull().Group("Servico")
            .AddColumn("Versao", "Versao").Varchar(20).NotNull().Group("Servico")
            .AddColumn("Url", "URL").Varchar(1000).NotNull().Group("Servico")
            .AddColumn("Ativo", "Ativo").Int().NotNull().Group("Status")
                .Enumerable(0, "Nao")
                .Enumerable(1, "Sim");

        AddEntity("CertificadoDigital", "Certificado Digital").AddModule("SEFAZ")
            .AddColumn("Id", "ID").Int().Incremento().Key().Group("Identificacao")
            .AddColumn("Apelido", "Apelido").Varchar(120).NotNull().Group("Identificacao")
            .AddColumn("DocumentoTitular", "Documento Titular").Varchar(14).NotNull().Group("Titular")
            .AddColumn("StorageKey", "Arquivo").Varchar(500).NotNull().Group("Arquivo")
            .AddColumn("Thumbprint", "Thumbprint").Varchar(100).Group("Arquivo")
            .AddColumn("ValidoDe", "Valido de").DateTime().Group("Validade")
            .AddColumn("ValidoAte", "Valido ate").DateTime().Group("Validade")
            .AddColumn("Ativo", "Ativo").Int().NotNull().Group("Status")
                .Enumerable(0, "Nao")
                .Enumerable(1, "Sim");

        AddUsecaseGroup("Fiscal")
            .AddUseCaseSubGrup("Entrada")
            .AddCommand(
                "ReceberNotasFiscaisProduto",
                new ReceberNotasFiscaisProdutoInput(
                    string.Empty,
                    0,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty),
                new ReceberNotasFiscaisProdutoOutput(string.Empty, false, 0, string.Empty))
            .Authorization(Authorization.User)
            .AddScope("fiscal.nfe-produto.receber")
            .AddEntity("NFeProdutoSnapshot");

        AddUsecaseGroup("Fiscal")
            .AddUseCaseSubGrup("Entrada")
            .AddCommand(
                "InformarDocumentosOriginariosDaCarga",
                new InformarDocumentosOriginariosDaCargaInput(
                    string.Empty,
                    0,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty),
                new InformarDocumentosOriginariosDaCargaOutput(string.Empty, false, 0, string.Empty))
            .Authorization(Authorization.User)
            .AddScope("fiscal.documentos-originarios-carga.informar")
            .AddEntity("NFeProdutoSnapshot");

        AddUsecaseGroup("Fiscal")
            .AddUseCaseSubGrup("Contingencia")
            .AddCommand(
                "IniciarContingenciaFiscal",
                new IniciarContingenciaFiscalInput(
                    string.Empty,
                    0,
                    1,
                    2,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    string.Empty),
                new IniciarContingenciaFiscalOutput(string.Empty, false, 0, string.Empty, string.Empty))
            .Authorization(Authorization.User)
            .AddScope("fiscal.contingencia.iniciar")
            .AddEntity("EntradaFiscalContingencia");

        AddUsecaseGroup("Fiscal")
            .AddUseCaseSubGrup("CTe")
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
            .AddScope("fiscal.cte.romaneio.receber")
            .AddEntity("CTeRomaneioConsolidado");

        AddUsecaseGroup("Fiscal")
            .AddUseCaseSubGrup("CTe")
            .AddCommand(
                "SolicitarEmissaoCTe",
                new SolicitarEmissaoCTeInput(0, string.Empty, string.Empty, 1, 57, 0, 0, 1),
                new SolicitarEmissaoCTeOutput(0, string.Empty, string.Empty, false))
            .Authorization(Authorization.User)
            .AddScope("fiscal.cte.emissao.solicitar")
            .AddEntity("CTeSolicitacaoFiscal");

        AddUsecaseGroup("Fiscal")
            .AddUseCaseSubGrup("CTe")
            .AddCommand(
                "AutorizarCTe",
                new AutorizarCTeInput(0, 1),
                new AutorizarCTeOutput(0, string.Empty, false, string.Empty, string.Empty))
            .Authorization(Authorization.User)
            .AddScope("fiscal.cte.emissao.autorizar")
            .AddEntity("CTeTentativaEmissao");

        AddUsecaseGroup("Fiscal")
            .AddUseCaseSubGrup("CTe")
            .AddCommand(
                "PublicarCTeAutorizadoParaMDFe",
                new PublicarCTeAutorizadoParaMDFeInput(0, string.Empty),
                new PublicarCTeAutorizadoParaMDFeOutput(false, string.Empty))
            .Authorization(Authorization.User)
            .AddScope("fiscal.cte.mdfe.publicar")
            .AddEntity("CTeSaidaMDFe");

        AddUsecaseGroup("Fiscal")
            .AddUseCaseSubGrup("MDFe")
            .AddCommand(
                "SolicitarEmissaoMDFe",
                new SolicitarEmissaoMDFeInput(string.Empty, string.Empty, 1, string.Empty, string.Empty, string.Empty, string.Empty),
                new SolicitarEmissaoMDFeOutput(0, string.Empty, string.Empty, false))
            .Authorization(Authorization.User)
            .AddScope("fiscal.mdfe.emissao.solicitar")
            .AddEntity("MDFeSolicitacaoFiscal");

        AddUsecaseGroup("Fiscal")
            .AddUseCaseSubGrup("MDFe")
            .AddCommand(
                "AutorizarMDFe",
                new AutorizarMDFeInput(0, 1),
                new AutorizarMDFeOutput(0, string.Empty, false, string.Empty, string.Empty))
            .Authorization(Authorization.User)
            .AddScope("fiscal.mdfe.emissao.autorizar")
            .AddEntity("MDFeTentativaEmissao");

        AddUsecaseGroup("Fiscal")
            .AddUseCaseSubGrup("MDFe")
            .AddCommand(
                "EncerrarMDFe",
                new EncerrarMDFeInput(string.Empty, string.Empty, string.Empty, string.Empty),
                new EncerrarMDFeOutput(string.Empty, false, string.Empty, string.Empty, null))
            .Authorization(Authorization.User)
            .AddScope("fiscal.mdfe.encerrar")
            .AddEntity("MDFe");

        AddUsecaseGroup("Fiscal")
            .AddUseCaseSubGrup("SEFAZ")
            .AddCommand(
                "ValidarCertificadoDigital",
                new ValidarCertificadoDigitalInput(0),
                new ValidarCertificadoDigitalOutput(false, string.Empty, null))
            .Authorization(Authorization.User)
            .AddScope("fiscal.certificado.validar")
            .AddEntity("CertificadoDigital");

        AddUsecaseGroup("Fiscal")
            .AddUseCaseSubGrup("EmissaoFiscal")
            .AddSaga("EmissaoFiscalCargaStandard")
                .StartsFromYeshuaModuleEvent(
                    "APSADM",
                    "CargaProntaParaEmissaoFiscal",
                    1,
                    "CargaStandard",
                    "publicarCargaProntaParaEmissaoFiscal")
            .AddStepGroup("entrada")
                .AddStep("receberCargaProntaParaEmissaoFiscal")
                .AddStepWait("aguardarDocumentosOriginariosDaCarga")
                .AddStep("prepararEntradaFiscalDaCarga")
            .AddStepGroup("ctePreparacao")
                .AddStep("montarSolicitacoesCTe")
                .AddStep("prepararCTe")
            .AddStepGroup("cteSefaz")
                .AddStep("autorizarCTeNaSefaz")
                .AddStep("publicarCTeAutorizadoParaMDFe")
            .AddStepGroup("mdfePreparacao")
                .AddStep("montarSolicitacaoMDFe")
                .AddStep("prepararMDFe")
            .AddStepGroup("mdfeSefaz")
                .AddStep("autorizarMDFeNaSefaz")
                .AddStep("publicarDocumentosFiscaisDaCargaConcluidos")
                    .PublishYeshuaModuleEvent(
                        "APSADM",
                        "DocumentosFiscaisDaCargaConcluidos",
                        1,
                        "CargaStandard")
                    .DeliverByYeshuaApi();

        AddUsecaseGroup("Fiscal")
            .AddUseCaseSubGrup("Contingencia")
            .AddSaga("ContingenciaFiscalStandard")
            .AddStepGroup("documentos")
                .AddStepWait("receberNotasFiscaisDaContingencia")
                    .HttpApi("InformarNotasFiscaisContingencia",
                        new ContingenciaFiscalStepInput(string.Empty, 0, string.Empty, 0, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty),
                        new ContingenciaFiscalStepOutput(string.Empty, string.Empty, string.Empty, 0, 0, 0, false, string.Empty))
                    .Sync()
                    .Authorization(Authorization.User)
                    .AddScope("fiscal.contingencia.notas.informar")
                    .AddEntity("EntradaFiscalContingencia")
                .AddStep("analisarNotasFiscaisDaContingencia")
            .AddStepGroup("agrupamento")
                .AddStepWait("escolherModeloAgrupamentoCTe")
                    .HttpApi("EscolherModeloAgrupamentoCTeContingencia",
                        new ContingenciaFiscalStepInput(string.Empty, 0, string.Empty, 0, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty),
                        new ContingenciaFiscalStepOutput(string.Empty, string.Empty, string.Empty, 0, 0, 0, false, string.Empty))
                    .Sync()
                    .Authorization(Authorization.User)
                    .AddScope("fiscal.contingencia.agrupamento.informar")
                    .AddEntity("EntradaFiscalContingencia")
                .AddStep("simularAgrupamentoCTe")
            .AddStepGroup("frete")
                .AddStepWait("informarFreteERateio")
                    .HttpApi("InformarFreteERateioContingencia",
                        new ContingenciaFiscalStepInput(string.Empty, 0, string.Empty, 0, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty),
                        new ContingenciaFiscalStepOutput(string.Empty, string.Empty, string.Empty, 0, 0, 0, false, string.Empty))
                    .Sync()
                    .Authorization(Authorization.User)
                    .AddScope("fiscal.contingencia.frete.informar")
                    .AddEntity("EntradaFiscalContingencia")
                .AddStep("simularRateioFrete")
            .AddStepGroup("transporte")
                .AddStepWait("informarDadosTransporte")
                    .HttpApi("InformarDadosTransporteContingencia",
                        new ContingenciaFiscalStepInput(string.Empty, 0, string.Empty, 0, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty),
                        new ContingenciaFiscalStepOutput(string.Empty, string.Empty, string.Empty, 0, 0, 0, false, string.Empty))
                    .Sync()
                    .Authorization(Authorization.User)
                    .AddScope("fiscal.contingencia.transporte.informar")
                    .AddEntity("EntradaFiscalContingencia")
                .AddStep("validarPlanoEmissaoFiscal")
            .AddStepGroup("confirmacao")
                .AddStepWait("confirmarPlanoEmissaoFiscal")
                    .HttpApi("ConfirmarPlanoEmissaoFiscalContingencia",
                        new ContingenciaFiscalStepInput(string.Empty, 0, string.Empty, 0, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty),
                        new ContingenciaFiscalStepOutput(string.Empty, string.Empty, string.Empty, 0, 0, 0, false, string.Empty))
                    .Sync()
                    .Authorization(Authorization.User)
                    .AddScope("fiscal.contingencia.plano.confirmar")
                    .AddEntity("EntradaFiscalContingencia")
                .AddStep("publicarPlanoParaSagaFiscal")
            .AddStepGroup("emissao")
                .AddStepWait("aguardarResultadoEmissaoFiscal")
                    .HttpApi("InformarResultadoEmissaoFiscalContingencia",
                        new ContingenciaFiscalStepInput(string.Empty, 0, string.Empty, 0, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty),
                        new ContingenciaFiscalStepOutput(string.Empty, string.Empty, string.Empty, 0, 0, 0, false, string.Empty))
                    .Authorization(Authorization.User)
                    .AddScope("fiscal.contingencia.resultado-emissao.informar")
                    .AddEntity("EntradaFiscalContingencia")
            .AddStepGroup("finalizacao")
                .AddStep("finalizarContingenciaFiscal");

        AddUsecaseGroup("Fiscal")
            .AddUseCaseSubGrup("EncerramentoFiscal")
            .AddSaga("EncerramentoMDFeStandard")
            .AddStepGroup("solicitacao")
                .AddStep("solicitarEncerramentoMDFe")
            .AddStepGroup("preparacao")
                .AddStep("prepararEventoEncerramentoMDFe")
            .AddStepGroup("sefaz")
                .AddStep("autorizarEncerramentoMDFeNaSefaz")
            .AddStepGroup("publicacao")
                .AddStep("publicarMDFeEncerrado")
                    .PublishYeshuaModuleEvent(
                        "APSADM",
                        "MDFeEncerrado",
                        1,
                        "CargaStandard",
                        false)
                    .DeliverByYeshuaApi();

        AddMenuGroup("DFE", "Entrada Fiscal",
            "DocumentoFiscal",
            "DocumentoFiscalOriginario",
            "NFeProdutoSnapshot");

        AddMenuGroup("CTE", "CT-e",
            "CTeEntradaOficial",
            "CTeRomaneioConsolidado",
            "CTeSolicitacaoFiscal",
            "CTeTentativaEmissao",
            "CTeSaidaMDFe");

        AddMenuGroup("MDFE", "MDF-e",
            "MDFe",
            "MDFeSolicitacaoFiscal",
            "MDFeTentativaEmissao",
            "MDFeEncerramento");

        AddMenuGroup("SEFAZ", "Operacao SEFAZ",
            "SefazEndpoint",
            "CertificadoDigital");

        AddCustomPage(
            "CONT",
            "Nova Contingencia Fiscal",
            "contingencia-fiscal",
            "fiscal.contingencia.tela",
            "Contingencia Fiscal");

        AddMenuGroup("CONT", "Contingencia Fiscal",
            "Nova Contingencia Fiscal",
            "EntradaFiscalContingencia");

        // pendencia: eventos CT-e -> MDF-e devem usar outbox/inbox quando forem
        // fluxos entre processos; dentro do Fiscal unificado, manter a intencao em
        // commands/receivers e preservar os snapshots legais.
    }
}

public sealed record ReceberNotasFiscaisProdutoInput(
    string CorrelationId,
    int TenantId,
    string SourceApplication,
    string SourceModule,
    string SourceMessageId,
    string CargaId,
    string NotasFiscaisJson,
    string PayloadHash,
    string PayloadStorageKey);

public sealed record ReceberNotasFiscaisProdutoOutput(
    string CorrelationId,
    bool Accepted,
    int QuantidadeNotas,
    string Mensagem);

public sealed record InformarDocumentosOriginariosDaCargaInput(
    string CorrelationId,
    int TenantId,
    string SourceApplication,
    string SourceModule,
    string SourceMessageId,
    string CargaId,
    string DocumentosOriginariosJson,
    string PayloadHash,
    string PayloadStorageKey);

public sealed record InformarDocumentosOriginariosDaCargaOutput(
    string CorrelationId,
    bool Accepted,
    int QuantidadeDocumentos,
    string Mensagem);

public sealed record IniciarContingenciaFiscalInput(
    string CorrelationId,
    int TenantId,
    int TipoSolicitante,
    int Ambiente,
    string CargaId,
    string SourceApplication,
    string SourceModule,
    string SourceMessageId,
    string DocumentosOriginariosJson,
    string DadosComplementaresJson,
    string PayloadHash,
    string PayloadStorageKey);

public sealed record IniciarContingenciaFiscalOutput(
    string CorrelationId,
    bool Accepted,
    int EntradaFiscalContingenciaId,
    string CargaId,
    string Mensagem);

public sealed record ContingenciaFiscalStepInput(
    string CorrelationId,
    int TenantId,
    string CargaId,
    int EntradaFiscalContingenciaId,
    string UserAction,
    string DocumentosOriginariosJson,
    string DadosComplementaresJson,
    string PayloadHash,
    string PayloadStorageKey);

public sealed record ContingenciaFiscalStepOutput(
    string CorrelationId,
    string CargaId,
    string StepKey,
    int SagaId,
    int SagaStepId,
    int InboxId,
    bool Accepted,
    string Mensagem);

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

public sealed record SolicitarEmissaoMDFeInput(
    string CorrelationId,
    string CargaId,
    int Ambiente,
    string UFCarregamento,
    string UFDescarregamento,
    string PlacaVeiculo,
    string DocumentosOriginariosJson);

public sealed record SolicitarEmissaoMDFeOutput(
    int SolicitacaoId,
    string CorrelationId,
    string Status,
    bool ProntoParaAutorizar);

public sealed record AutorizarMDFeInput(
    int SolicitacaoId,
    int SincronoAteAutorizacao);

public sealed record AutorizarMDFeOutput(
    int TentativaId,
    string ChaveAcesso,
    bool Autorizado,
    string Protocolo,
    string Mensagem);

public sealed record EncerrarMDFeInput(
    string ChaveAcesso,
    string UfCarregamento,
    string UfDescarregamento,
    string PlacaVeiculo);

public sealed record EncerrarMDFeOutput(
    string ChaveAcesso,
    bool Encerrado,
    string Protocolo,
    string Mensagem,
    DateTime? EncerradoEm);

public sealed record ValidarCertificadoDigitalInput(int CertificadoDigitalId);

public sealed record ValidarCertificadoDigitalOutput(
    bool Valido,
    string Mensagem,
    DateTime? ValidoAte);
