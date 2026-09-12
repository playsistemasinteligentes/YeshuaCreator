using Dominio.Migration;
using Migration.Dominio.Schemas.CQRS;

namespace Yeshua.Studio.Fiscal.Migrations;

[Migration(000003)]
public class M000003 : MigrationBase
{
    public override void Up()
    {
        AddEntity("EmissaoFiscalTransporte", "Emissao Fiscal Transporte").AddModule("FIS")
            .AddColumn("Id", "ID").Int().Incremento().Key().Group("Identificacao")
            .AddColumn("CorrelationId", "CorrelationId").Varchar(100).NotNull().Group("Origem")
            .AddColumn("OrigemFluxo", "Origem do Fluxo").Int().NotNull().Group("Origem")
                .Enumerable(1, "Contingencia")
                .Enumerable(2, "APS")
                .Enumerable(3, "IntegracaoExterna")
            .AddColumn("CargaId", "Carga").Varchar(80).Group("Operacao")
            .AddColumn("RomaneioId", "Romaneio").Varchar(80).Group("Operacao")
            .AddColumn("Ambiente", "Ambiente").Int().NotNull().Group("SEFAZ")
                .Enumerable(1, "Producao")
                .Enumerable(2, "Homologacao")
            .AddColumn("EmitenteDocumento", "Emitente").Varchar(14).Group("Participantes")
            .AddColumn("TomadorDocumento", "Tomador").Varchar(14).Group("Participantes")
            .AddColumn("TransportadorDocumento", "Transportador").Varchar(14).Group("Participantes")
            .AddColumn("UFInicio", "UF Inicio").Varchar(2).Group("Rota")
            .AddColumn("UFFim", "UF Fim").Varchar(2).Group("Rota")
            .AddColumn("MunicipioInicioCodigoIbge", "Municipio Inicio").Varchar(7).Group("Rota")
            .AddColumn("MunicipioFimCodigoIbge", "Municipio Fim").Varchar(7).Group("Rota")
            .AddColumn("QuantidadeNFe", "Quantidade NF-e").Int().Group("Documentos")
            .AddColumn("QuantidadeCTe", "Quantidade CT-e").Int().Group("Documentos")
            .AddColumn("QuantidadeMDFe", "Quantidade MDF-e").Int().Group("Documentos")
            .AddColumn("ValorCarga", "Valor Carga").Decimal(18, 2).Group("Valores")
            .AddColumn("PesoBruto", "Peso Bruto").Decimal(18, 6).Group("Valores")
            .AddColumn("Volume", "Volume").Decimal(18, 6).Group("Valores")
            .AddColumn("UltimaMensagem", "Ultima Mensagem").Varchar(2000).Group("Diagnostico")
            .AddColumn("CriadoEmUtc", "Criado em UTC").DateTime().NotNull().Group("Operacao")
            .AddColumn("AtualizadoEmUtc", "Atualizado em UTC").DateTime().Group("Operacao")
            .AddColumn("ConcluidoEmUtc", "Concluido em UTC").DateTime().Group("Operacao")
            .AddColumn("Status", "Status").Int().NotNull().Group("Status")
                .Enumerable(1, "Aberta")
                .Enumerable(2, "RecebendoDocumentos")
                .Enumerable(3, "PreparandoEmissao")
                .Enumerable(4, "EmitindoCTe")
                .Enumerable(5, "EmitindoMDFe")
                .Enumerable(6, "Concluida")
                .Enumerable(7, "Rejeitada")
                .Enumerable(8, "FalhaTecnica");

        AddEntity("ContingenciaFiscal", "Contingencia Fiscal").AddModule("CONT")
            .AddColumn("Id", "ID").Int().Incremento().Key().Group("Identificacao")
            .AddColumn("EmissaoFiscalTransporteId", "Emissao Fiscal").FK("EmissaoFiscalTransporte", "Id").RelationTab("Contingencias", "Contingencias").Int().Group("Vinculo")
            .AddColumn("EntradaFiscalContingenciaId", "Entrada Contingencia").FK("EntradaFiscalContingencia", "Id").Int().Group("Vinculo")
            .AddColumn("CorrelationId", "CorrelationId").Varchar(100).NotNull().Group("Origem")
            .AddColumn("CargaId", "Carga").Varchar(80).NotNull().Group("Operacao")
            .AddColumn("TipoSolicitante", "Tipo Solicitante").Int().NotNull().Group("Solicitante")
                .Enumerable(1, "Transportador")
                .Enumerable(2, "Embarcador")
                .Enumerable(3, "CooperativaSubcontratante")
            .AddColumn("Ambiente", "Ambiente").Int().NotNull().Group("SEFAZ")
                .Enumerable(1, "Producao")
                .Enumerable(2, "Homologacao")
            .AddColumn("EmitenteDocumento", "Emitente").Varchar(14).Group("Participantes")
            .AddColumn("TomadorDocumento", "Tomador").Varchar(14).Group("Participantes")
            .AddColumn("TransportadorDocumento", "Transportador").Varchar(14).Group("Participantes")
            .AddColumn("QuantidadeDocumentos", "Quantidade Documentos").Int().Group("Documentos")
            .AddColumn("QuantidadeCTe", "Quantidade CT-e").Int().Group("Documentos")
            .AddColumn("QuantidadeMDFe", "Quantidade MDF-e").Int().Group("Documentos")
            .AddColumn("ValorCarga", "Valor Carga").Decimal(18, 2).Group("Valores")
            .AddColumn("PesoBruto", "Peso Bruto").Decimal(18, 6).Group("Valores")
            .AddColumn("UltimaMensagem", "Ultima Mensagem").Varchar(2000).Group("Diagnostico")
            .AddColumn("CriadoEmUtc", "Criado em UTC").DateTime().NotNull().Group("Operacao")
            .AddColumn("AtualizadoEmUtc", "Atualizado em UTC").DateTime().Group("Operacao")
            .AddColumn("ConcluidoEmUtc", "Concluido em UTC").DateTime().Group("Operacao")
            .AddColumn("Status", "Status").Int().NotNull().Group("Status")
                .Enumerable(1, "Iniciada")
                .Enumerable(2, "AguardandoUsuario")
                .Enumerable(3, "EmProcessamento")
                .Enumerable(4, "EmissaoFiscalSolicitada")
                .Enumerable(5, "Finalizada")
                .Enumerable(6, "Rejeitada")
                .Enumerable(7, "FalhaTecnica");

        AddEntity("EmissaoFiscalTransporteDocumento", "Documento da Emissao Fiscal").AddModule("DFE")
            .AddColumn("Id", "ID").Int().Incremento().Key().Group("Identificacao")
            .AddColumn("EmissaoFiscalTransporteId", "Emissao Fiscal").FK("EmissaoFiscalTransporte", "Id").RelationTab("Documentos", "Documentos").Int().NotNull().Group("Vinculo")
            .AddColumn("DocumentoFiscalId", "Documento Fiscal").FK("DocumentoFiscal", "Id").Int().Group("Vinculo")
            .AddColumn("DocumentoFiscalOriginarioId", "Documento Originario").FK("DocumentoFiscalOriginario", "Id").Int().Group("Vinculo")
            .AddColumn("NFeProdutoSnapshotId", "NF-e Produto").FK("NFeProdutoSnapshot", "Id").Int().Group("Vinculo")
            .AddColumn("ProdutoFiscal", "Produto Fiscal").Int().NotNull().Group("Identificacao")
                .Enumerable(55, "NFe")
                .Enumerable(57, "CTe")
                .Enumerable(58, "MDFe")
            .AddColumn("Papel", "Papel").Int().NotNull().Group("Identificacao")
                .Enumerable(1, "Originario")
                .Enumerable(2, "Gerado")
                .Enumerable(3, "Evento")
            .AddColumn("TipoEvento", "Tipo Evento").Varchar(40).Group("Evento")
            .AddColumn("ChaveAcesso", "Chave de Acesso").Varchar(44).Group("Identificacao")
            .AddColumn("XmlStorageKey", "XML").Varchar(500).Group("Arquivos")
            .AddColumn("PdfStorageKey", "PDF").Varchar(500).Group("Arquivos")
            .AddColumn("Protocolo", "Protocolo").Varchar(30).Group("SEFAZ")
            .AddColumn("CodigoRetorno", "cStat").Varchar(10).Group("SEFAZ")
            .AddColumn("MensagemRetorno", "xMotivo").Varchar(1000).Group("SEFAZ")
            .AddColumn("CriadoEmUtc", "Criado em UTC").DateTime().NotNull().Group("Operacao")
            .AddColumn("Status", "Status").Int().NotNull().Group("Status")
                .Enumerable(1, "Recebido")
                .Enumerable(2, "Disponivel")
                .Enumerable(3, "Autorizado")
                .Enumerable(4, "Rejeitado")
                .Enumerable(5, "Cancelado")
                .Enumerable(6, "Encerrado")
                .Enumerable(7, "FalhaTecnica");

        AddMenuGroup("FIS", "Emissoes",
            "EmissaoFiscalTransporte");

        AddMenuGroup("CONT", "Contingencia Fiscal",
            "ContingenciaFiscal",
            "EntradaFiscalContingencia");

        AddMenuGroup("DFE", "Documentos Fiscais",
            "EmissaoFiscalTransporteDocumento",
            "DocumentoFiscal",
            "DocumentoFiscalOriginario",
            "NFeProdutoSnapshot");
    }
}
