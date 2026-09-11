using Dominio.Migration;
using Migration.Dominio.Schemas.CQRS;

namespace Yeshua.Studio.Fiscal.Migrations;

[Migration(000002)]
public class M000002 : MigrationBase
{
    public override void Up()
    {
        AddEntity("EntradaFiscalContingencia", "Entrada Fiscal Contingencia").AddModule("CONT")
            .AddColumn("Id", "ID").Int().Incremento().Key().Group("Identificacao")
            .AddColumn("CorrelationId", "CorrelationId").Varchar(100).NotNull().Group("Origem")
            .AddColumn("CargaId", "Carga").Varchar(80).NotNull().Group("Operacao")
            .AddColumn("TipoSolicitante", "Tipo Solicitante").Int().NotNull().Group("Solicitante")
                .Enumerable(1, "Transportador")
                .Enumerable(2, "Embarcador")
                .Enumerable(3, "CooperativaSubcontratante")
            .AddColumn("Ambiente", "Ambiente").Int().NotNull().Group("SEFAZ")
                .Enumerable(1, "Producao")
                .Enumerable(2, "Homologacao")
            .AddColumn("SourceApplication", "Aplicacao Origem").Varchar(100).NotNull().Group("Origem")
            .AddColumn("SourceModule", "Modulo Origem").Varchar(100).Group("Origem")
            .AddColumn("SourceMessageId", "Mensagem Origem").Varchar(100).NotNull().Group("Origem")
            .AddColumn("EmitenteFiscalDocumento", "Emitente Fiscal").Varchar(14).Group("Participantes")
            .AddColumn("TomadorDocumento", "Tomador").Varchar(14).Group("Participantes")
            .AddColumn("TransportadorDocumento", "Transportador").Varchar(14).Group("Participantes")
            .AddColumn("RemetenteDocumento", "Remetente").Varchar(14).Group("Participantes")
            .AddColumn("DestinatarioDocumento", "Destinatario").Varchar(14).Group("Participantes")
            .AddColumn("UFInicio", "UF Inicio").Varchar(2).Group("Rota")
            .AddColumn("UFFim", "UF Fim").Varchar(2).Group("Rota")
            .AddColumn("MunicipioInicioCodigoIbge", "Municipio Inicio").Varchar(7).Group("Rota")
            .AddColumn("MunicipioFimCodigoIbge", "Municipio Fim").Varchar(7).Group("Rota")
            .AddColumn("RNTRC", "RNTRC").Varchar(20).Group("Transporte")
            .AddColumn("PlacaVeiculo", "Placa Veiculo").Varchar(7).Group("Transporte")
            .AddColumn("UFVeiculo", "UF Veiculo").Varchar(2).Group("Transporte")
            .AddColumn("CondutorDocumento", "CPF Condutor").Varchar(14).Group("Transporte")
            .AddColumn("CondutorNome", "Nome Condutor").Varchar(120).Group("Transporte")
            .AddColumn("QuantidadeDocumentos", "Quantidade Documentos").Int().Group("Documentos")
            .AddColumn("ValorCarga", "Valor Carga").Decimal(18, 2).Group("Valores")
            .AddColumn("PesoBruto", "Peso Bruto").Decimal(18, 6).Group("Valores")
            .AddColumn("Volume", "Volume").Decimal(18, 6).Group("Valores")
            .AddColumn("PendenciasJson", "Pendencias").Varchar(4000).Group("Diagnostico")
            .AddColumn("SnapshotJson", "Snapshot").Varchar(8000).Group("Snapshot")
            .AddColumn("EmissaoFiscalCorrelationId", "CorrelationId Emissao Fiscal").Varchar(100).Group("Emissao")
            .AddColumn("EmissaoFiscalSagaId", "Saga Emissao Fiscal").Int().Group("Emissao")
            .AddColumn("CriadoEmUtc", "Criado em UTC").DateTime().NotNull().Group("Operacao")
            .AddColumn("AtualizadoEmUtc", "Atualizado em UTC").DateTime().Group("Operacao")
            .AddColumn("Status", "Status").Int().NotNull().Group("Status")
                .Enumerable(1, "Recebida")
                .Enumerable(2, "DadosInferidos")
                .Enumerable(3, "PendenteComplemento")
                .Enumerable(4, "ProntaParaEmissao")
                .Enumerable(5, "EmissaoFiscalSolicitada")
                .Enumerable(6, "Finalizada")
                .Enumerable(7, "Rejeitada")
                .Enumerable(8, "FalhaTecnica");
    }
}
