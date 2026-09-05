using Dominio.Migration;
using Migration.Dominio.Schemas.CQRS;

namespace Yeshua.Studio.APS.ADM.Migrations;

[Migration(000004)]
public class M000004 : MigrationBase
{
    public override void Up()
    {
        AddEntity("PedidoPlanejavel", "Pedido Planejavel").FromView("PedidoPlanejavel").AddModule("APSADM")
            .AddColumn("PedidoId", "Pedido").Varchar(60).Key().NotNull()
            .AddColumn("ClienteId", "Cliente").Varchar(30).NotNull()
            .AddColumn("ClienteNome", "Nome do Cliente").Varchar(100).NotNull()
            .AddColumn("Estado", "Estado").Varchar(2).NotNull()
            .AddColumn("Municipio", "Municipio").Varchar(100).NotNull()
            .AddColumn("Regiao", "Regiao").Varchar(100)
            .AddColumn("Bairro", "Bairro").Varchar(100)
            .AddColumn("RotaId", "Rota").Varchar(100)
            .AddColumn("EmbarqueAlvo", "Embarque Alvo").DateTime()
            .AddColumn("DataEntregaDe", "Entrega De").DateTime()
            .AddColumn("DataEntregaAte", "Entrega Ate").DateTime()
            .AddColumn("Peso", "Peso").Decimal(18, 6)
            .AddColumn("Volume", "Volume").Decimal(18, 6)
            .AddColumn("SaldoAExpedir", "Saldo A Expedir").Decimal(18, 6)
            .AddColumn("Status", "Status").Varchar(30)
            .AddColumn("CargaAtualId", "Carga Atual").Varchar(30)
            .AddColumn("VersaoPlanejamento", "Versao Planejamento").Varchar(60)
            .AddColumn("AlertasResumo", "Alertas").Varchar(500);

        AddEntity("CargaPlanejavel", "Carga Planejavel").FromView("CargaPlanejavel").AddModule("APSADM")
            .AddColumn("CargaId", "Carga").Varchar(30).Key().NotNull()
            .AddColumn("Status", "Status").Varchar(30)
            .AddColumn("TransportadoraId", "Transportadora").Varchar(30)
            .AddColumn("VeiculoId", "Veiculo").Varchar(30)
            .AddColumn("TipoVeiculoId", "Tipo Veiculo").Int()
            .AddColumn("PesoTeorico", "Peso Teorico").Decimal(18, 6)
            .AddColumn("VolumeTeorico", "Volume Teorico").Decimal(18, 6)
            .AddColumn("InicioJanelaEmbarque", "Inicio Janela Embarque").DateTime()
            .AddColumn("FimJanelaEmbarque", "Fim Janela Embarque").DateTime()
            .AddColumn("EmbarqueAlvo", "Embarque Alvo").DateTime()
            .AddColumn("QuantidadePedidos", "Quantidade Pedidos").Int()
            .AddColumn("AlertasResumo", "Alertas").Varchar(500);

        AddEntity("OpcaoPlanejamentoTransporte", "Opcao Planejamento Transporte").FromView("OpcaoPlanejamentoTransporte").AddModule("APSADM")
            .AddColumn("OpcaoId", "Opcao").Varchar(60).Key().NotNull()
            .AddColumn("GrupoDecisaoId", "Grupo Decisao").Varchar(60).NotNull()
            .AddColumn("Peso", "Peso").Decimal(18, 6)
            .AddColumn("Volume", "Volume").Decimal(18, 6)
            .AddColumn("CustoEstimado", "Custo Estimado").Decimal(18, 6)
            .AddColumn("AderenciaCubagem", "Aderencia Cubagem").Decimal(18, 6)
            .AddColumn("AderenciaJanelaEntrega", "Aderencia Janela Entrega").Decimal(18, 6)
            .AddColumn("RiscoResumo", "Risco").Varchar(500)
            .AddColumn("PedidosResumo", "Pedidos").Varchar(1000, true)
            .AddColumn("OpcoesConflitantesResumo", "Opcoes Conflitantes").Varchar(1000, true);

        AddEntity("CenarioPlanejamentoTransporte", "Cenario Planejamento Transporte").FromView("CenarioPlanejamentoTransporte").AddModule("APSADM")
            .AddColumn("CenarioId", "Cenario").Varchar(60).Key().NotNull()
            .AddColumn("Descricao", "Descricao").Varchar(200).NotNull()
            .AddColumn("Objetivo", "Objetivo").Varchar(100).NotNull()
            .AddColumn("QuantidadeCargas", "Quantidade Cargas").Int()
            .AddColumn("QuantidadePedidosNaoAtendidos", "Pedidos Nao Atendidos").Int()
            .AddColumn("CustoTotal", "Custo Total").Decimal(18, 6)
            .AddColumn("AderenciaCubagem", "Aderencia Cubagem").Decimal(18, 6)
            .AddColumn("AtrasoPrevisto", "Atraso Previsto").Decimal(18, 6)
            .AddColumn("AlertasResumo", "Alertas").Varchar(500);

        AddEntity("ExperienciaPlanejamentoTransporte", "Experiencia Planejamento Transporte").AddModule("APSADM")
            .AddColumn("Id", "Id").Int().Incremento().Key()
            .AddColumn("Tipo", "Tipo").Int().NotNull()
                .Enumerable(1, "RoteiroBom")
                .Enumerable(2, "RoteiroRuim")
                .Enumerable(3, "CombinacaoImpraticavel")
                .Enumerable(4, "RestricaoHumana")
            .AddColumn("Referencia", "Referencia").Varchar(100)
            .AddColumn("PedidoId", "Pedido").Varchar(60)
            .AddColumn("ClienteId", "Cliente").Varchar(30)
            .AddColumn("Municipio", "Municipio").Varchar(100)
            .AddColumn("Regiao", "Regiao").Varchar(100)
            .AddColumn("RotaId", "Rota").Varchar(100)
            .AddColumn("Peso", "Peso").Decimal(18, 6)
            .AddColumn("Volume", "Volume").Decimal(18, 6)
            .AddColumn("Observacao", "Observacao").Varchar(2000, true)
            .AddColumn("CriadoEm", "Criado Em").DateTime().NotNull()
            .AddColumn("CriadoPor", "Criado Por").Varchar(80).NotNull();

        var planejamento = AddUsecaseGroup("APSADM")
            .AddUseCaseSubGrup("PlanejamentoTransporte");

        planejamento
            .AddSaga("CargaStandard")
            .AddStepGroup("montagemCarga")
                .AddStep("criarCarga")
            .AddStepGroup("dadosTransporte")
                .AddStep("definirDadosTransporte")
            .AddStepGroup("preparacaoFiscal")
                .AddStep("prepararCargaParaFiscal")
                .AddStep("publicarCargaProntaParaEmissaoFiscal")
                    .PublishYeshuaModuleEvent(
                        "Fiscal",
                        "CargaProntaParaEmissaoFiscal",
                        1,
                        "EmissaoFiscalCargaStandard")
                    .DeliverByYeshuaApi()
            .AddStepGroup("retornoFiscal")
                .AddStep("aguardarResultadoFiscalDaCarga")
                .AddStep("liberarCargaParaExpedicao");

        AddCustomPage(
            "APSADM",
            "Planejamento Transporte",
            "planejamento-transporte",
            "apsadm.planejamento-transporte.tela",
            "Planejamento");

        AddMenuGroup("APSADM", "Planejamento",
            "Carga",
            "CargaPlanejavel",
            "CargaPrevista",
            "CenarioPlanejamentoTransporte",
            "ConsultaPedido",
            "ExperienciaPlanejamentoTransporte",
            "OpcaoPlanejamentoTransporte",
            "PedidoPlanejavel",
            "Planejamento Transporte",
            "Roteiro",
            "RoteiroPedido");

        AddMenuGroupByPrefix("APSADM", "Tabelas Legado", "T_");
        AddMenuGroupByPrefix("APSADM", "Sistema", "y");
        AddRemainingMenuGroup("APSADM", "Cadastros APS");

        planejamento
            .AddCommand("BuscarContextoPlanejamentoTransporte",
                new BuscarContextoPlanejamentoTransporteInput(DateTime.Today, DateTime.Today, string.Empty, 500),
                new BuscarContextoPlanejamentoTransporteOutput(string.Empty, DateTime.MinValue, 0, 0, new List<PlanejamentoLenteResumo>()))
            .Authorization(Authorization.User)
            .AddScope("apsadm.planejamento-transporte.contexto.buscar")
            .AddEntity("PedidoPlanejavel")
            .AddEntity("CargaPlanejavel");

        planejamento
            .AddCommand("ListarLentesPlanejamentoTransporte",
                new ListarLentesPlanejamentoTransporteInput(string.Empty),
                new ListarLentesPlanejamentoTransporteOutput(new List<PlanejamentoLenteResumo>()))
            .Authorization(Authorization.User)
            .AddScope("apsadm.planejamento-transporte.lentes.listar")
            .AddEntity("PedidoPlanejavel");

        planejamento
            .AddCommand("AbrirNoLentePlanejamentoTransporte",
                new AbrirNoLentePlanejamentoTransporteInput(string.Empty, string.Empty, string.Empty, 0),
                new AbrirNoLentePlanejamentoTransporteOutput(new List<PlanejamentoNoLenteResumo>(), new List<PedidoPlanejamentoEnvelope>()))
            .Authorization(Authorization.User)
            .AddScope("apsadm.planejamento-transporte.lente.abrir-no")
            .AddEntity("PedidoPlanejavel");

        planejamento
            .AddCommand("RevalidarSelecaoPlanejamentoTransporte",
                new RevalidarSelecaoPlanejamentoTransporteInput(string.Empty, new List<PedidoPlanejamentoRef>()),
                new RevalidarSelecaoPlanejamentoTransporteOutput(true, string.Empty, new List<PedidoPlanejamentoEnvelope>()))
            .Authorization(Authorization.User)
            .AddScope("apsadm.planejamento-transporte.selecao.revalidar")
            .AddEntity("PedidoPlanejavel");

        planejamento
            .AddCommand("CriarCargaDaSelecaoPlanejamentoTransporte",
                new CriarCargaDaSelecaoPlanejamentoTransporteInput(string.Empty, new List<PedidoPlanejamentoRef>(), string.Empty, string.Empty),
                new CriarCargaDaSelecaoPlanejamentoTransporteOutput(string.Empty, false, string.Empty))
            .Authorization(Authorization.User)
            .AddScope("apsadm.planejamento-transporte.carga.criar")
            .AddEntity("Carga")
            .AddEntity("ItenCarga");

        planejamento
            .AddCommand("ListarCargasAbertasPlanejamentoTransporte",
                new ListarCargasAbertasPlanejamentoTransporteInput(string.Empty),
                new ListarCargasAbertasPlanejamentoTransporteOutput(new List<CargaPlanejamentoEnvelope>()))
            .Authorization(Authorization.User)
            .AddScope("apsadm.planejamento-transporte.cargas-abertas.listar")
            .AddEntity("CargaPlanejavel");

        planejamento
            .AddCommand("RemoverPedidoDaCargaPlanejamentoTransporte",
                new RemoverPedidoDaCargaPlanejamentoTransporteInput(string.Empty, string.Empty, string.Empty),
                new OperacaoCargaPlanejamentoTransporteOutput(false, string.Empty))
            .Authorization(Authorization.User)
            .AddScope("apsadm.planejamento-transporte.carga.remover-pedido")
            .AddEntity("Carga")
            .AddEntity("ItenCarga");

        planejamento
            .AddCommand("TrocarPedidoEntreCargasPlanejamentoTransporte",
                new TrocarPedidoEntreCargasPlanejamentoTransporteInput(string.Empty, string.Empty, string.Empty, string.Empty),
                new OperacaoCargaPlanejamentoTransporteOutput(false, string.Empty))
            .Authorization(Authorization.User)
            .AddScope("apsadm.planejamento-transporte.carga.trocar-pedido")
            .AddEntity("Carga")
            .AddEntity("ItenCarga");

        planejamento
            .AddCommand("UnirCargasPlanejamentoTransporte",
                new UnirCargasPlanejamentoTransporteInput(string.Empty, string.Empty, string.Empty),
                new OperacaoCargaPlanejamentoTransporteOutput(false, string.Empty))
            .Authorization(Authorization.User)
            .AddScope("apsadm.planejamento-transporte.carga.unir")
            .AddEntity("Carga")
            .AddEntity("ItenCarga");

        planejamento
            .AddCommand("DividirCargaPlanejamentoTransporte",
                new DividirCargaPlanejamentoTransporteInput(string.Empty, new List<PedidoPlanejamentoRef>(), new List<PedidoPlanejamentoRef>()),
                new OperacaoCargaPlanejamentoTransporteOutput(false, string.Empty))
            .Authorization(Authorization.User)
            .AddScope("apsadm.planejamento-transporte.carga.dividir")
            .AddEntity("Carga")
            .AddEntity("ItenCarga");

        planejamento
            .AddCommand("GerarGruposDecisaoPlanejamentoTransporte",
                new GerarGruposDecisaoPlanejamentoTransporteInput(string.Empty, string.Empty, new List<PedidoPlanejamentoRef>()),
                new GerarGruposDecisaoPlanejamentoTransporteOutput(new List<OpcaoPlanejamentoEnvelope>()))
            .Authorization(Authorization.User)
            .AddScope("apsadm.planejamento-transporte.grupos-decisao.gerar")
            .AddEntity("OpcaoPlanejamentoTransporte");

        planejamento
            .AddCommand("AceitarOpcaoPlanejamentoTransporte",
                new AceitarOpcaoPlanejamentoTransporteInput(string.Empty, string.Empty),
                new OperacaoCargaPlanejamentoTransporteOutput(false, string.Empty))
            .Authorization(Authorization.User)
            .AddScope("apsadm.planejamento-transporte.opcao.aceitar")
            .AddEntity("OpcaoPlanejamentoTransporte")
            .AddEntity("Carga")
            .AddEntity("ItenCarga");

        planejamento
            .AddCommand("DescartarOpcaoPlanejamentoTransporte",
                new DescartarOpcaoPlanejamentoTransporteInput(string.Empty, string.Empty),
                new OperacaoCargaPlanejamentoTransporteOutput(false, string.Empty))
            .Authorization(Authorization.User)
            .AddScope("apsadm.planejamento-transporte.opcao.descartar")
            .AddEntity("OpcaoPlanejamentoTransporte");

        planejamento
            .AddCommand("GerarCenariosPlanejamentoTransporte",
                new GerarCenariosPlanejamentoTransporteInput(string.Empty, string.Empty),
                new GerarCenariosPlanejamentoTransporteOutput(new List<CenarioPlanejamentoEnvelope>()))
            .Authorization(Authorization.User)
            .AddScope("apsadm.planejamento-transporte.cenarios.gerar")
            .AddEntity("CenarioPlanejamentoTransporte");

        planejamento
            .AddCommand("AplicarCenarioPlanejamentoTransporte",
                new AplicarCenarioPlanejamentoTransporteInput(string.Empty, string.Empty),
                new OperacaoCargaPlanejamentoTransporteOutput(false, string.Empty))
            .Authorization(Authorization.User)
            .AddScope("apsadm.planejamento-transporte.cenario.aplicar")
            .AddEntity("CenarioPlanejamentoTransporte")
            .AddEntity("Carga")
            .AddEntity("ItenCarga");

        planejamento
            .AddCommand("CatalogarExperienciaPlanejamentoTransporte",
                new CatalogarExperienciaPlanejamentoTransporteInput(1, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty),
                new OperacaoCargaPlanejamentoTransporteOutput(false, string.Empty))
            .Authorization(Authorization.User)
            .AddScope("apsadm.planejamento-transporte.experiencia.catalogar")
            .AddEntity("ExperienciaPlanejamentoTransporte");
    }
}

public sealed record PlanejamentoLenteResumo(string LenteId, string Descricao, string Niveis, bool ExpansaoRemota);

public sealed record PlanejamentoNoLenteResumo(string NoId, string ParentNoId, string Descricao, int Nivel, int QuantidadePedidos, decimal Peso, decimal Volume, bool TemFilhos);

public sealed record PedidoPlanejamentoRef(string PedidoId, string VersaoPlanejamento);

public sealed record PedidoPlanejamentoEnvelope(string PedidoId, string ClienteNome, string Estado, string Municipio, string Regiao, string Bairro, string RotaId, decimal Peso, decimal Volume, DateTime EmbarqueAlvo, string VersaoPlanejamento, string AlertasResumo);

public sealed record CargaPlanejamentoEnvelope(string CargaId, string Status, decimal Peso, decimal Volume, int QuantidadePedidos, string AlertasResumo);

public sealed record OpcaoPlanejamentoEnvelope(string OpcaoId, string GrupoDecisaoId, decimal Peso, decimal Volume, decimal CustoEstimado, decimal AderenciaCubagem, string RiscoResumo, string PedidosResumo);

public sealed record CenarioPlanejamentoEnvelope(string CenarioId, string Descricao, string Objetivo, int QuantidadeCargas, int QuantidadePedidosNaoAtendidos, decimal CustoTotal, string AlertasResumo);

public sealed record BuscarContextoPlanejamentoTransporteInput(DateTime EmbarqueDe, DateTime EmbarqueAte, string PlantaId, int LimitePedidos);

public sealed record BuscarContextoPlanejamentoTransporteOutput(string ContextoId, DateTime GeradoEm, int QuantidadePedidos, int QuantidadeCargas, List<PlanejamentoLenteResumo> Lentes);

public sealed record ListarLentesPlanejamentoTransporteInput(string ContextoId);

public sealed record ListarLentesPlanejamentoTransporteOutput(List<PlanejamentoLenteResumo> Lentes);

public sealed record AbrirNoLentePlanejamentoTransporteInput(string ContextoId, string LenteId, string NoId, int Nivel);

public sealed record AbrirNoLentePlanejamentoTransporteOutput(List<PlanejamentoNoLenteResumo> Nos, List<PedidoPlanejamentoEnvelope> Pedidos);

public sealed record RevalidarSelecaoPlanejamentoTransporteInput(string ContextoId, List<PedidoPlanejamentoRef> Pedidos);

public sealed record RevalidarSelecaoPlanejamentoTransporteOutput(bool Valida, string Mensagem, List<PedidoPlanejamentoEnvelope> PedidosInvalidos);

public sealed record CriarCargaDaSelecaoPlanejamentoTransporteInput(string ContextoId, List<PedidoPlanejamentoRef> Pedidos, string TipoVeiculoId, string Observacao);

public sealed record CriarCargaDaSelecaoPlanejamentoTransporteOutput(string CargaId, bool Criada, string Mensagem);

public sealed record ListarCargasAbertasPlanejamentoTransporteInput(string ContextoId);

public sealed record ListarCargasAbertasPlanejamentoTransporteOutput(List<CargaPlanejamentoEnvelope> Cargas);

public sealed record RemoverPedidoDaCargaPlanejamentoTransporteInput(string CargaId, string PedidoId, string Motivo);

public sealed record TrocarPedidoEntreCargasPlanejamentoTransporteInput(string CargaOrigemId, string CargaDestinoId, string PedidoId, string Motivo);

public sealed record UnirCargasPlanejamentoTransporteInput(string CargaOrigemId, string CargaDestinoId, string Motivo);

public sealed record DividirCargaPlanejamentoTransporteInput(string CargaId, List<PedidoPlanejamentoRef> PedidosPrimeiraCarga, List<PedidoPlanejamentoRef> PedidosSegundaCarga);

public sealed record GerarGruposDecisaoPlanejamentoTransporteInput(string ContextoId, string Objetivo, List<PedidoPlanejamentoRef> Pedidos);

public sealed record GerarGruposDecisaoPlanejamentoTransporteOutput(List<OpcaoPlanejamentoEnvelope> Opcoes);

public sealed record AceitarOpcaoPlanejamentoTransporteInput(string ContextoId, string OpcaoId);

public sealed record DescartarOpcaoPlanejamentoTransporteInput(string ContextoId, string OpcaoId);

public sealed record GerarCenariosPlanejamentoTransporteInput(string ContextoId, string Objetivo);

public sealed record GerarCenariosPlanejamentoTransporteOutput(List<CenarioPlanejamentoEnvelope> Cenarios);

public sealed record AplicarCenarioPlanejamentoTransporteInput(string ContextoId, string CenarioId);

public sealed record CatalogarExperienciaPlanejamentoTransporteInput(int Tipo, string Referencia, string PedidoId, string ClienteId, string Municipio, string Regiao, string RotaId, string Observacao);

public sealed record OperacaoCargaPlanejamentoTransporteOutput(bool Sucesso, string Mensagem);
