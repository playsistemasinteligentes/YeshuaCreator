using Dominio.Migration;
using Migration.Dominio.Schemas.CQRS;

namespace Yeshua.Studio.APS.ADM.Migrations;

[Migration(000001)]
public class M000001 : MigrationBase
{
    public override void Up()
    {
        AddModule("APSADM", "APS ADM");

        AddEntity("Produto").LegacySource("V_PRODUTOS").AddModule("APSADM")
            .AddColumn("Id", "Codigo do Produto").Varchar(30).Key().LegacyColumn("PRO_ID", "varchar(30)")
            .AddColumn("Descricao", "Descricao do Produto").Varchar(150).LegacyColumn("PRO_DESCRICAO", "varchar(100)")
            .AddColumn("Status", "Status do Produto").Varchar(2).LegacyColumn("PRO_STATUS", "varchar(2)");

        AddEntity("Maquina").LegacySource("T_MAQUINA").AddModule("APSADM")
            .AddColumn("Id", "Codigo da Maquina").Varchar(30).Key().LegacyColumn("MAQ_ID", "varchar(30)")
            .AddColumn("Descricao", "Descricao da Maquina").Varchar(150).LegacyColumn("MAQ_DESCRICAO", "varchar(100)")
            .AddColumn("Status", "Status da Maquina").Varchar(2).LegacyColumn("MAQ_STATUS", "varchar(30)");

        AddEntity("GrupoMaquina").LegacySource("T_GRUPO_MAQUINA").AddModule("APSADM")
            .AddColumn("Id", "Codigo do Grupo de Maquina").Varchar(30).Key().LegacyColumn("GMA_ID", "varchar(30)")
            .AddColumn("Descricao", "Descricao do Grupo de Maquina").Varchar(150).LegacyColumn("GMA_DESCRICAO", "varchar(100)")
            .AddColumn("Status", "Status do Grupo de Maquina").Varchar(2).LegacyColumn("GMA_STATUS", "varchar(2)");

        AddEntity("TemplateDeTestes").LegacySource("T_TEMPLATE_DE_TESTES").AddModule("APSADM")
            .AddColumn("Id", "Template de Testes").Int().Incremento().Key().LegacyColumn("TEM_ID", "int")
            .AddColumn("Descricao", "Descricao do Template").Varchar(150).LegacyColumn("TEM_DESCRICAO", "varchar(200)");

        AddEntity("Roteiro").LegacySource("T_ROTEIROS").AddModule("APSADM")
            .AddColumn("Id", "Id").Int().Incremento().Key()
            .AddColumn("MaquinaId", "Codigo da Maquina").FK("Maquina", "Id").Varchar(30).NotNull().Group("Principal").LegacyColumn("MAQ_ID", "varchar(30)")
            .AddColumn("ProdutoId", "Codigo do Produto").FK("Produto", "Id").Varchar(30).NotNull().Group("Principal").LegacyColumn("PRO_ID", "varchar(30)")
            .AddColumn("SequenciaTransformacao", "Sequencia de Transformacao").Int().NotNull().Group("Principal").LegacyColumn("ROT_SEQ_TRANFORMACAO", "int")
            .AddColumn("GrupoMaquinaId", "Grupo de Maquinas").FK("GrupoMaquina", "Id").Varchar(30).Group("Principal").LegacyColumn("GMA_ID", "varchar(30)")
            .AddColumn("PecasPorPulso", "Quantidade de Pecas por Pulso").Decimal(18, 6).Group("Principal").LegacyColumn("ROT_PECAS_POR_PULSO", "float", "float_to_decimal_18_6")
            .AddColumn("PrioridadeInformada", "Grau de Prioridade").Decimal(18, 6).Group("Principal").LegacyColumn("ROT_PRIORIDADE_INFORMADA", "float", "float_to_decimal_18_6")
            .AddColumn("Acao", "Maquina Excecao").Varchar(2).Group("Principal").LegacyColumn("ROT_ACAO", "varchar(2)")
            .AddColumn("Performance", "Performance Pulsos por Segundo").Decimal(18, 6).NotNull().Group("Principal").LegacyColumn("ROT_PERFORMANCE", "float", "float_to_decimal_18_6")
            .AddColumn("TempoSetup", "Setup em Segundos").Decimal(18, 6).Group("Principal").LegacyColumn("ROT_TEMPO_SETUP", "float", "float_to_decimal_18_6")
            .AddColumn("TempoSetupAjuste", "Tempo Setup Ajuste em Segundos").Decimal(18, 6).Group("Principal").LegacyColumn("ROT_TEMPO_SETUP_AJUSTE", "float", "float_to_decimal_18_6")
            .AddColumn("ProximaSequenciaTransformacao", "Proxima Sequencia de Transformacao").Int().Group("Principal").LegacyColumn("ROT_VA_PARA_SEQ_TRANSFORMACAO", "int")
            .AddColumn("Status", "Status").Varchar(2).Group("Principal").LegacyColumn("ROT_STATUS", "varchar(2)")
            .AddColumn("HierarquiaSequenciaTransformacao", "Hierarquia Calculo").Decimal(18, 6).Group("Principal").LegacyColumn("ROT_HIERARQUIA_SEQ_TRANSFORMACAO", "float", "float_to_decimal_18_6")
            .AddColumn("AvaliaCusto", "Avalia Custo").Int().Group("Principal").LegacyColumn("ROT_AVALIA_CUSTO", "int")
            .AddColumn("Operacoes", "Operacoes").Varchar(100).Group("Principal").LegacyColumn("ROT_OPERACOES", "varchar(100)")
            .AddColumn("ExcecaoOperacoes", "Excecao Operacoes").Varchar(100).Group("Principal").LegacyColumn("ROT_EXCECAO_OPERACOES", "varchar(100)")
            .AddColumn("PercentualInicioPassoAnterior", "Percentual Inicio Passo Anterior").Decimal(18, 6).Group("Principal").LegacyColumn("ROT_PERCENTUAL_INICIO_PASSO_ANTERIOR", "float", "float_to_decimal_18_6")
            .AddColumn("LinhaDireta", "Linha Direta").Varchar(2).Group("Principal").LegacyColumn("ROT_LINHA_DIRETA", "varchar(2)")
            .AddColumn("TemplateDeTestesId", "Template de Testes").FK("TemplateDeTestes", "Id").Int().Group("Qualidade").LegacyColumn("TEM_ID", "int");

        AddEntity("ConsultaPedido", "Consulta de Pedido").FromView("V_CONSULTA_PEDIDO").LegacySource("V_CONSULTA_PEDIDO").AddModule("APSADM")
            .AddColumn("PedidoId", "Pedido").Varchar(60).NotNull().Key().Group("Pedido").LegacyColumn("ORD_ID", "varchar(60)")
            .AddColumn("ClienteId", "Cliente").Varchar(30).NotNull().Group("Cliente").LegacyColumn("CLI_ID", "varchar(30)")
            .AddColumn("ClienteNome", "Nome do Cliente").Varchar(100).NotNull().Group("Cliente").LegacyColumn("CLIENTE", "varchar(100)")
            .AddColumn("RazaoSocial", "Razao Social").Varchar(200).Group("Cliente").LegacyColumn("RAZAO_SOCIAL", "varchar(200)")
            .AddColumn("ProdutoId", "Produto").FK("Produto", "Id").Varchar(30).NotNull().Group("Produto").LegacyColumn("PRO_ID", "varchar(30)")
            .AddColumn("ProdutoDescricao", "Descricao do Produto").Varchar(100).NotNull().Group("Produto").LegacyColumn("PRO_DESCRICAO", "varchar(100)")
            .AddColumn("Status", "Status do Pedido").Varchar(30).Group("Pedido").LegacyColumn("ORD_STATUS", "varchar(30)")
            .AddColumn("Estagio", "Estagio").Varchar(16).NotNull().Group("Pedido").LegacyColumn("ESTAGIO", "varchar(16)")
            .AddColumn("DataEntregaDe", "Entrega de").DateTime().NotNull().Group("Datas").LegacyColumn("ORD_DATA_ENTREGA_DE", "datetime")
            .AddColumn("DataEntregaAte", "Entrega ate").DateTime().NotNull().Group("Datas").LegacyColumn("ORD_DATA_ENTREGA_ATE", "datetime")
            .AddColumn("EmbarqueAlvo", "Embarque Alvo").DateTime().Group("Datas").LegacyColumn("ORD_EMBARQUE_ALVO", "datetime")
            .AddColumn("Quantidade", "Quantidade").Decimal(18, 6).NotNull().Group("Saldos").LegacyColumn("ORD_QUANTIDADE", "float", "float_to_decimal_18_6")
            .AddColumn("SaldoAProduzir", "Saldo a Produzir").Decimal(18, 6).NotNull().Group("Saldos").LegacyColumn("SALDO_A_PRODUZIR_PA", "float", "float_to_decimal_18_6")
            .AddColumn("SaldoAExpedir", "Saldo a Expedir").Decimal(18, 6).Group("Saldos").LegacyColumn("SALDO_A_EXPEDIR", "float", "float_to_decimal_18_6")
            .AddColumn("CorFila", "Cor da Fila").Varchar(30).Group("Pedido").LegacyColumn("ORD_COR_FILA", "varchar(30)")
            .AddColumn("PedidoCliente", "Pedido do Cliente").Varchar(100).Group("Pedido").LegacyColumn("ORD_PED_CLI", "varchar(100)")
            .CustomTab("Tracker", "Tracker")
                .UseCase("ConsultaPedido.ObterTracker")
                .FrontComponent("ConsultaPedidoTracker")
                .Done();

        AddEntity("RoteiroPedido", "Roteiro do Pedido").FromView("V_ROTEIRO_PEDIDO").LegacySource("V_ROTEIRO_PEDIDO").AddModule("APSADM")
            .AddColumn("PedidoId", "Pedido").FK("ConsultaPedido", "PedidoId").RelationTab("Roteiro", "Roteiro").Varchar(60).NotNull().Key().Group("Principal").LegacyColumn("ORD_ID", "varchar(60)")
            .AddColumn("MaquinaId", "Maquina").FK("Maquina", "Id").Varchar(30).NotNull().Key().Group("Principal").LegacyColumn("MAQ_ID", "varchar(30)")
            .AddColumn("ProdutoId", "Produto").FK("Produto", "Id").Varchar(30).NotNull().Key().Group("Principal").LegacyColumn("PRO_ID", "varchar(30)")
            .AddColumn("SequenciaTransformacao", "Sequencia de Transformacao").Int().NotNull().Key().Group("Principal").LegacyColumn("ROT_SEQ_TRANFORMACAO", "int")
            .AddColumn("StatusCadastro", "Status do Cadastro").Varchar(8).NotNull().Group("Principal").LegacyColumn("STATUS_CADASTRO", "varchar(8)")
            .AddColumn("TipoPlanejamento", "Tipo de Planejamento").Varchar(60).Group("Principal").LegacyColumn("MAQ_TIPO_PLANEJAMENTO", "varchar(60)")
            .AddColumn("CalendarioId", "Calendario").Int().NotNull().Group("Principal").LegacyColumn("CAL_ID", "int")
            .AddColumn("HierarquiaSequenciaTransformacao", "Hierarquia Calculo").Decimal(18, 6).Group("Principal").LegacyColumn("HIERARQUIA_SEQ_TRANSFORMACAO", "float", "float_to_decimal_18_6")
            .AddColumn("ProximaSequenciaTransformacao", "Proxima Sequencia").Int().Group("Principal").LegacyColumn("ROT_VA_PARA_SEQ_TRANSFORMACAO", "int")
            .AddColumn("Performance", "Performance").Decimal(18, 6).Group("Principal").LegacyColumn("ROT_PERFORMANCE", "float", "float_to_decimal_18_6")
            .AddColumn("TempoSetup", "Tempo Setup").Decimal(18, 6).Group("Principal").LegacyColumn("ROT_TEMPO_SETUP", "float", "float_to_decimal_18_6")
            .AddColumn("TempoSetupAjuste", "Tempo Setup Ajuste").Decimal(18, 6).Group("Principal").LegacyColumn("ROT_TEMPO_SETUP_AJUSTE", "float", "float_to_decimal_18_6")
            .AddColumn("PecasPorPulso", "Pecas por Pulso").Decimal(18, 6).Group("Principal").LegacyColumn("ROT_PECAS_POR_PULSO", "float", "float_to_decimal_18_6")
            .AddColumn("PrioridadeInformada", "Prioridade Informada").Decimal(18, 6).Group("Principal").LegacyColumn("ROT_PRIORIDADE_INFORMADA", "float", "float_to_decimal_18_6")
            .AddColumn("Status", "Status").Varchar(2).Group("Principal").LegacyColumn("ROT_STATUS", "varchar(2)")
            .AddColumn("Operacoes", "Operacoes").Varchar(100).NotNull().Group("Principal").LegacyColumn("ROT_OPERACOES", "varchar(100)")
            .AddColumn("ExcecaoOperacoes", "Excecao Operacoes").Varchar(100).NotNull().Group("Principal").LegacyColumn("ROT_EXCECAO_OPERACOES", "varchar(100)")
            .AddColumn("LinhaDireta", "Linha Direta").Varchar(1).NotNull().Group("Principal").LegacyColumn("ROT_LINHA_DIRETA", "varchar(1)")
            .AddColumn("AvaliaCusto", "Avalia Custo").Int().Group("Custo").LegacyColumn("AVALIA_CUSTO", "int")
            .AddColumn("PercentualInicioPassoAnterior", "Percentual Inicio Passo Anterior").Decimal(18, 6).Group("Custo").LegacyColumn("PERCENTUAL_INICIO_PASSO_ANTERIOR", "float", "float_to_decimal_18_6")
            .AddColumn("MaquinaLarguraUtil", "Largura Util da Maquina").Decimal(18, 6).Group("Custo").LegacyColumn("MAQ_LARGURA_UTIL", "float", "float_to_decimal_18_6")
            .AddColumn("GrupoTipo", "Tipo do Grupo").Decimal(18, 6).Group("Custo").LegacyColumn("GRP_TIPO", "float", "float_to_decimal_18_6")
            .AddColumn("GrupoPerformanceMetroLinear", "Performance Metro Linear").Decimal(18, 6).NotNull().Group("Custo").LegacyColumn("GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO", "float", "float_to_decimal_18_6");
    }
}
