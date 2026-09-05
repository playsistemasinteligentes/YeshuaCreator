// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration
// </yeshua>

using Dominio.Entitys;
using Shered.DB;
using Command.Write;
using IQuery.Write;
using Aplication.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Write
{
    public class OrderQueryWrite : QueryBase, IOrderQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public OrderQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirOrderQuery(IOrderEntity Order)
        {
            this.Query = $@" INSERT INTO [Order] ([ORD_ID], [ORD_ID_RESERVA], [ORD_ID_CONJUNTO], [PRO_ID], [PRO_ID_CONJUNTO], [CLI_ID], [ORD_PRECO_UNITARIO], [ORD_QUANTIDADE], [ORD_DATA_ENTREGA_DE], [ORD_DATA_ENTREGA_ATE], [ORD_TIPO], [ORD_TOLERANCIA_MAIS], [ORD_TOLERANCIA_MENOS], [HASH_KEY], [ORD_INICIO_JANELA_EMBARQUE], [ORD_FIM_JANELA_EMBARQUE], [ORD_EMBARQUE_ALVO], [ORD_INICIO_GRUPO_PRODUTIVO], [ORD_FIM_GRUPO_PRODUTIVO], [ORD_PESO_UNITARIO], [ORD_PESO_UNITARIO_BRUTO], [ORD_M2_UNITARIO], [ORD_MIT], [CAR_TIPO_CARREGAMENTO], [ORD_STATUS], [ORD_TIPO_FRETE], [ORD_ENDERECO_ENTREGA], [ORD_BAIRRO_ENTREGA], [UF_ID_ENTREGA], [ORD_CEP_ENTREGA], [MUN_ID_ENTREGA], [ORD_REGIAO_ENTREGA], [ORD_LARGURA], [ORD_COMPRIMENTO], [ORD_GRAMATURA], [GRP_ID], [ORD_ID_INTEGRACAO], [ORD_OBSERVACAO_OTIMIZADOR], [ORD_COR_FILA], [ORD_PED_CLI], [ORD_OP_INTEGRACAO], [ORD_LOTE_PILOTO], [ORD_PRIORIDADE], [ORD_EMISSAO], [REP_ID], [ORD_RESINA], [ORD_ENDURECEDOR_MIOLO], [PRO_ID_INTEGRACAO_ERP], [ORD_VINCOS_ONDULADEIRA], [ORD_ERP_CUSTOS_FIXOS], [ORD_ERP_CUSTOS_VARIAVEIS], [ORD_ERP_DESPESAS_VAR_VENDA], [ORD_ERP_IMPOSTOS], [ORD_STATUS_PLANEJAMENTO], [ORD_TOLERANCIA_DIMENSAO_CHAPA_DE], [ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE], [ORD_PROMOVE_DE], [ORD_PROMOVE_ATE], [ORD_TRAVA_COMPOSICAO], [ORD_TRAVA_RESINA], [ORD_PROMOVE_RESINA], [ORD_LATITUDE_ENTREGA], [ORD_LONGITUDE_ENTREGA], [OCO_ID_CANCELAMENTO], [TMP_TIPO_CARGA], [PRO_ID_PALETE], [PRO_ID_TAMPO], [ORD_PILHAS_POR_PALETE], [ORD_CHAPAS_POR_PILHA], [ORD_DATA_CANCELAMENTO], [ORD_STATUS_ESTATISTICA], [ORD_DATA_ESTATISTICA], [OCO_ID_MOTIVO_ATRASO], [OTK_VERSSAO], [TenantID], [Deleted], [Changed], [UserId]) VALUES(@ORD_ID, @ORD_ID_RESERVA, @ORD_ID_CONJUNTO, @PRO_ID, @PRO_ID_CONJUNTO, @CLI_ID, @ORD_PRECO_UNITARIO, @ORD_QUANTIDADE, @ORD_DATA_ENTREGA_DE, @ORD_DATA_ENTREGA_ATE, @ORD_TIPO, @ORD_TOLERANCIA_MAIS, @ORD_TOLERANCIA_MENOS, @HASH_KEY, @ORD_INICIO_JANELA_EMBARQUE, @ORD_FIM_JANELA_EMBARQUE, @ORD_EMBARQUE_ALVO, @ORD_INICIO_GRUPO_PRODUTIVO, @ORD_FIM_GRUPO_PRODUTIVO, @ORD_PESO_UNITARIO, @ORD_PESO_UNITARIO_BRUTO, @ORD_M2_UNITARIO, @ORD_MIT, @CAR_TIPO_CARREGAMENTO, @ORD_STATUS, @ORD_TIPO_FRETE, @ORD_ENDERECO_ENTREGA, @ORD_BAIRRO_ENTREGA, @UF_ID_ENTREGA, @ORD_CEP_ENTREGA, @MUN_ID_ENTREGA, @ORD_REGIAO_ENTREGA, @ORD_LARGURA, @ORD_COMPRIMENTO, @ORD_GRAMATURA, @GRP_ID, @ORD_ID_INTEGRACAO, @ORD_OBSERVACAO_OTIMIZADOR, @ORD_COR_FILA, @ORD_PED_CLI, @ORD_OP_INTEGRACAO, @ORD_LOTE_PILOTO, @ORD_PRIORIDADE, @ORD_EMISSAO, @REP_ID, @ORD_RESINA, @ORD_ENDURECEDOR_MIOLO, @PRO_ID_INTEGRACAO_ERP, @ORD_VINCOS_ONDULADEIRA, @ORD_ERP_CUSTOS_FIXOS, @ORD_ERP_CUSTOS_VARIAVEIS, @ORD_ERP_DESPESAS_VAR_VENDA, @ORD_ERP_IMPOSTOS, @ORD_STATUS_PLANEJAMENTO, @ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, @ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, @ORD_PROMOVE_DE, @ORD_PROMOVE_ATE, @ORD_TRAVA_COMPOSICAO, @ORD_TRAVA_RESINA, @ORD_PROMOVE_RESINA, @ORD_LATITUDE_ENTREGA, @ORD_LONGITUDE_ENTREGA, @OCO_ID_CANCELAMENTO, @TMP_TIPO_CARGA, @PRO_ID_PALETE, @PRO_ID_TAMPO, @ORD_PILHAS_POR_PALETE, @ORD_CHAPAS_POR_PILHA, @ORD_DATA_CANCELAMENTO, @ORD_STATUS_ESTATISTICA, @ORD_DATA_ESTATISTICA, @OCO_ID_MOTIVO_ATRASO, @OTK_VERSSAO, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                ORD_ID = Order.ORD_ID,
                ORD_ID_RESERVA = Order.ORD_ID_RESERVA,
                ORD_ID_CONJUNTO = Order.ORD_ID_CONJUNTO,
                PRO_ID = Order.PRO_ID,
                PRO_ID_CONJUNTO = Order.PRO_ID_CONJUNTO,
                CLI_ID = Order.CLI_ID,
                ORD_PRECO_UNITARIO = Order.ORD_PRECO_UNITARIO,
                ORD_QUANTIDADE = Order.ORD_QUANTIDADE,
                ORD_DATA_ENTREGA_DE = Order.ORD_DATA_ENTREGA_DE,
                ORD_DATA_ENTREGA_ATE = Order.ORD_DATA_ENTREGA_ATE,
                ORD_TIPO = Order.ORD_TIPO,
                ORD_TOLERANCIA_MAIS = Order.ORD_TOLERANCIA_MAIS,
                ORD_TOLERANCIA_MENOS = Order.ORD_TOLERANCIA_MENOS,
                HASH_KEY = Order.HASH_KEY,
                ORD_INICIO_JANELA_EMBARQUE = Order.ORD_INICIO_JANELA_EMBARQUE,
                ORD_FIM_JANELA_EMBARQUE = Order.ORD_FIM_JANELA_EMBARQUE,
                ORD_EMBARQUE_ALVO = Order.ORD_EMBARQUE_ALVO,
                ORD_INICIO_GRUPO_PRODUTIVO = Order.ORD_INICIO_GRUPO_PRODUTIVO,
                ORD_FIM_GRUPO_PRODUTIVO = Order.ORD_FIM_GRUPO_PRODUTIVO,
                ORD_PESO_UNITARIO = Order.ORD_PESO_UNITARIO,
                ORD_PESO_UNITARIO_BRUTO = Order.ORD_PESO_UNITARIO_BRUTO,
                ORD_M2_UNITARIO = Order.ORD_M2_UNITARIO,
                ORD_MIT = Order.ORD_MIT,
                CAR_TIPO_CARREGAMENTO = Order.CAR_TIPO_CARREGAMENTO,
                ORD_STATUS = Order.ORD_STATUS,
                ORD_TIPO_FRETE = Order.ORD_TIPO_FRETE,
                ORD_ENDERECO_ENTREGA = Order.ORD_ENDERECO_ENTREGA,
                ORD_BAIRRO_ENTREGA = Order.ORD_BAIRRO_ENTREGA,
                UF_ID_ENTREGA = Order.UF_ID_ENTREGA,
                ORD_CEP_ENTREGA = Order.ORD_CEP_ENTREGA,
                MUN_ID_ENTREGA = Order.MUN_ID_ENTREGA,
                ORD_REGIAO_ENTREGA = Order.ORD_REGIAO_ENTREGA,
                ORD_LARGURA = Order.ORD_LARGURA,
                ORD_COMPRIMENTO = Order.ORD_COMPRIMENTO,
                ORD_GRAMATURA = Order.ORD_GRAMATURA,
                GRP_ID = Order.GRP_ID,
                ORD_ID_INTEGRACAO = Order.ORD_ID_INTEGRACAO,
                ORD_OBSERVACAO_OTIMIZADOR = Order.ORD_OBSERVACAO_OTIMIZADOR,
                ORD_COR_FILA = Order.ORD_COR_FILA,
                ORD_PED_CLI = Order.ORD_PED_CLI,
                ORD_OP_INTEGRACAO = Order.ORD_OP_INTEGRACAO,
                ORD_LOTE_PILOTO = Order.ORD_LOTE_PILOTO,
                ORD_PRIORIDADE = Order.ORD_PRIORIDADE,
                ORD_EMISSAO = Order.ORD_EMISSAO,
                REP_ID = Order.REP_ID,
                ORD_RESINA = Order.ORD_RESINA,
                ORD_ENDURECEDOR_MIOLO = Order.ORD_ENDURECEDOR_MIOLO,
                PRO_ID_INTEGRACAO_ERP = Order.PRO_ID_INTEGRACAO_ERP,
                ORD_VINCOS_ONDULADEIRA = Order.ORD_VINCOS_ONDULADEIRA,
                ORD_ERP_CUSTOS_FIXOS = Order.ORD_ERP_CUSTOS_FIXOS,
                ORD_ERP_CUSTOS_VARIAVEIS = Order.ORD_ERP_CUSTOS_VARIAVEIS,
                ORD_ERP_DESPESAS_VAR_VENDA = Order.ORD_ERP_DESPESAS_VAR_VENDA,
                ORD_ERP_IMPOSTOS = Order.ORD_ERP_IMPOSTOS,
                ORD_STATUS_PLANEJAMENTO = Order.ORD_STATUS_PLANEJAMENTO,
                ORD_TOLERANCIA_DIMENSAO_CHAPA_DE = Order.ORD_TOLERANCIA_DIMENSAO_CHAPA_DE,
                ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE = Order.ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE,
                ORD_PROMOVE_DE = Order.ORD_PROMOVE_DE,
                ORD_PROMOVE_ATE = Order.ORD_PROMOVE_ATE,
                ORD_TRAVA_COMPOSICAO = Order.ORD_TRAVA_COMPOSICAO,
                ORD_TRAVA_RESINA = Order.ORD_TRAVA_RESINA,
                ORD_PROMOVE_RESINA = Order.ORD_PROMOVE_RESINA,
                ORD_LATITUDE_ENTREGA = Order.ORD_LATITUDE_ENTREGA,
                ORD_LONGITUDE_ENTREGA = Order.ORD_LONGITUDE_ENTREGA,
                OCO_ID_CANCELAMENTO = Order.OCO_ID_CANCELAMENTO,
                TMP_TIPO_CARGA = Order.TMP_TIPO_CARGA,
                PRO_ID_PALETE = Order.PRO_ID_PALETE,
                PRO_ID_TAMPO = Order.PRO_ID_TAMPO,
                ORD_PILHAS_POR_PALETE = Order.ORD_PILHAS_POR_PALETE,
                ORD_CHAPAS_POR_PILHA = Order.ORD_CHAPAS_POR_PILHA,
                ORD_DATA_CANCELAMENTO = Order.ORD_DATA_CANCELAMENTO,
                ORD_STATUS_ESTATISTICA = Order.ORD_STATUS_ESTATISTICA,
                ORD_DATA_ESTATISTICA = Order.ORD_DATA_ESTATISTICA,
                OCO_ID_MOTIVO_ATRASO = Order.OCO_ID_MOTIVO_ATRASO,
                OTK_VERSSAO = Order.OTK_VERSSAO,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOrderQuery(IOrderEntity Order)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_ID_RESERVA] = @ORD_ID_RESERVA, [ORD_ID_CONJUNTO] = @ORD_ID_CONJUNTO, [PRO_ID] = @PRO_ID, [PRO_ID_CONJUNTO] = @PRO_ID_CONJUNTO, [CLI_ID] = @CLI_ID, [ORD_PRECO_UNITARIO] = @ORD_PRECO_UNITARIO, [ORD_QUANTIDADE] = @ORD_QUANTIDADE, [ORD_DATA_ENTREGA_DE] = @ORD_DATA_ENTREGA_DE, [ORD_DATA_ENTREGA_ATE] = @ORD_DATA_ENTREGA_ATE, [ORD_TIPO] = @ORD_TIPO, [ORD_TOLERANCIA_MAIS] = @ORD_TOLERANCIA_MAIS, [ORD_TOLERANCIA_MENOS] = @ORD_TOLERANCIA_MENOS, [HASH_KEY] = @HASH_KEY, [ORD_INICIO_JANELA_EMBARQUE] = @ORD_INICIO_JANELA_EMBARQUE, [ORD_FIM_JANELA_EMBARQUE] = @ORD_FIM_JANELA_EMBARQUE, [ORD_EMBARQUE_ALVO] = @ORD_EMBARQUE_ALVO, [ORD_INICIO_GRUPO_PRODUTIVO] = @ORD_INICIO_GRUPO_PRODUTIVO, [ORD_FIM_GRUPO_PRODUTIVO] = @ORD_FIM_GRUPO_PRODUTIVO, [ORD_PESO_UNITARIO] = @ORD_PESO_UNITARIO, [ORD_PESO_UNITARIO_BRUTO] = @ORD_PESO_UNITARIO_BRUTO, [ORD_M2_UNITARIO] = @ORD_M2_UNITARIO, [ORD_MIT] = @ORD_MIT, [CAR_TIPO_CARREGAMENTO] = @CAR_TIPO_CARREGAMENTO, [ORD_STATUS] = @ORD_STATUS, [ORD_TIPO_FRETE] = @ORD_TIPO_FRETE, [ORD_ENDERECO_ENTREGA] = @ORD_ENDERECO_ENTREGA, [ORD_BAIRRO_ENTREGA] = @ORD_BAIRRO_ENTREGA, [UF_ID_ENTREGA] = @UF_ID_ENTREGA, [ORD_CEP_ENTREGA] = @ORD_CEP_ENTREGA, [MUN_ID_ENTREGA] = @MUN_ID_ENTREGA, [ORD_REGIAO_ENTREGA] = @ORD_REGIAO_ENTREGA, [ORD_LARGURA] = @ORD_LARGURA, [ORD_COMPRIMENTO] = @ORD_COMPRIMENTO, [ORD_GRAMATURA] = @ORD_GRAMATURA, [GRP_ID] = @GRP_ID, [ORD_ID_INTEGRACAO] = @ORD_ID_INTEGRACAO, [ORD_OBSERVACAO_OTIMIZADOR] = @ORD_OBSERVACAO_OTIMIZADOR, [ORD_COR_FILA] = @ORD_COR_FILA, [ORD_PED_CLI] = @ORD_PED_CLI, [ORD_OP_INTEGRACAO] = @ORD_OP_INTEGRACAO, [ORD_LOTE_PILOTO] = @ORD_LOTE_PILOTO, [ORD_PRIORIDADE] = @ORD_PRIORIDADE, [ORD_EMISSAO] = @ORD_EMISSAO, [REP_ID] = @REP_ID, [ORD_RESINA] = @ORD_RESINA, [ORD_ENDURECEDOR_MIOLO] = @ORD_ENDURECEDOR_MIOLO, [PRO_ID_INTEGRACAO_ERP] = @PRO_ID_INTEGRACAO_ERP, [ORD_VINCOS_ONDULADEIRA] = @ORD_VINCOS_ONDULADEIRA, [ORD_ERP_CUSTOS_FIXOS] = @ORD_ERP_CUSTOS_FIXOS, [ORD_ERP_CUSTOS_VARIAVEIS] = @ORD_ERP_CUSTOS_VARIAVEIS, [ORD_ERP_DESPESAS_VAR_VENDA] = @ORD_ERP_DESPESAS_VAR_VENDA, [ORD_ERP_IMPOSTOS] = @ORD_ERP_IMPOSTOS, [ORD_STATUS_PLANEJAMENTO] = @ORD_STATUS_PLANEJAMENTO, [ORD_TOLERANCIA_DIMENSAO_CHAPA_DE] = @ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, [ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE] = @ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, [ORD_PROMOVE_DE] = @ORD_PROMOVE_DE, [ORD_PROMOVE_ATE] = @ORD_PROMOVE_ATE, [ORD_TRAVA_COMPOSICAO] = @ORD_TRAVA_COMPOSICAO, [ORD_TRAVA_RESINA] = @ORD_TRAVA_RESINA, [ORD_PROMOVE_RESINA] = @ORD_PROMOVE_RESINA, [ORD_LATITUDE_ENTREGA] = @ORD_LATITUDE_ENTREGA, [ORD_LONGITUDE_ENTREGA] = @ORD_LONGITUDE_ENTREGA, [OCO_ID_CANCELAMENTO] = @OCO_ID_CANCELAMENTO, [TMP_TIPO_CARGA] = @TMP_TIPO_CARGA, [PRO_ID_PALETE] = @PRO_ID_PALETE, [PRO_ID_TAMPO] = @PRO_ID_TAMPO, [ORD_PILHAS_POR_PALETE] = @ORD_PILHAS_POR_PALETE, [ORD_CHAPAS_POR_PILHA] = @ORD_CHAPAS_POR_PILHA, [ORD_DATA_CANCELAMENTO] = @ORD_DATA_CANCELAMENTO, [ORD_STATUS_ESTATISTICA] = @ORD_STATUS_ESTATISTICA, [ORD_DATA_ESTATISTICA] = @ORD_DATA_ESTATISTICA, [OCO_ID_MOTIVO_ATRASO] = @OCO_ID_MOTIVO_ATRASO, [OTK_VERSSAO] = @OTK_VERSSAO, [Changed] = @Changed, [UserId] = @UserId WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_ID_RESERVA = Order.ORD_ID_RESERVA,
                ORD_ID_CONJUNTO = Order.ORD_ID_CONJUNTO,
                PRO_ID = Order.PRO_ID,
                PRO_ID_CONJUNTO = Order.PRO_ID_CONJUNTO,
                CLI_ID = Order.CLI_ID,
                ORD_PRECO_UNITARIO = Order.ORD_PRECO_UNITARIO,
                ORD_QUANTIDADE = Order.ORD_QUANTIDADE,
                ORD_DATA_ENTREGA_DE = Order.ORD_DATA_ENTREGA_DE,
                ORD_DATA_ENTREGA_ATE = Order.ORD_DATA_ENTREGA_ATE,
                ORD_TIPO = Order.ORD_TIPO,
                ORD_TOLERANCIA_MAIS = Order.ORD_TOLERANCIA_MAIS,
                ORD_TOLERANCIA_MENOS = Order.ORD_TOLERANCIA_MENOS,
                HASH_KEY = Order.HASH_KEY,
                ORD_INICIO_JANELA_EMBARQUE = Order.ORD_INICIO_JANELA_EMBARQUE,
                ORD_FIM_JANELA_EMBARQUE = Order.ORD_FIM_JANELA_EMBARQUE,
                ORD_EMBARQUE_ALVO = Order.ORD_EMBARQUE_ALVO,
                ORD_INICIO_GRUPO_PRODUTIVO = Order.ORD_INICIO_GRUPO_PRODUTIVO,
                ORD_FIM_GRUPO_PRODUTIVO = Order.ORD_FIM_GRUPO_PRODUTIVO,
                ORD_PESO_UNITARIO = Order.ORD_PESO_UNITARIO,
                ORD_PESO_UNITARIO_BRUTO = Order.ORD_PESO_UNITARIO_BRUTO,
                ORD_M2_UNITARIO = Order.ORD_M2_UNITARIO,
                ORD_MIT = Order.ORD_MIT,
                CAR_TIPO_CARREGAMENTO = Order.CAR_TIPO_CARREGAMENTO,
                ORD_STATUS = Order.ORD_STATUS,
                ORD_TIPO_FRETE = Order.ORD_TIPO_FRETE,
                ORD_ENDERECO_ENTREGA = Order.ORD_ENDERECO_ENTREGA,
                ORD_BAIRRO_ENTREGA = Order.ORD_BAIRRO_ENTREGA,
                UF_ID_ENTREGA = Order.UF_ID_ENTREGA,
                ORD_CEP_ENTREGA = Order.ORD_CEP_ENTREGA,
                MUN_ID_ENTREGA = Order.MUN_ID_ENTREGA,
                ORD_REGIAO_ENTREGA = Order.ORD_REGIAO_ENTREGA,
                ORD_LARGURA = Order.ORD_LARGURA,
                ORD_COMPRIMENTO = Order.ORD_COMPRIMENTO,
                ORD_GRAMATURA = Order.ORD_GRAMATURA,
                GRP_ID = Order.GRP_ID,
                ORD_ID_INTEGRACAO = Order.ORD_ID_INTEGRACAO,
                ORD_OBSERVACAO_OTIMIZADOR = Order.ORD_OBSERVACAO_OTIMIZADOR,
                ORD_COR_FILA = Order.ORD_COR_FILA,
                ORD_PED_CLI = Order.ORD_PED_CLI,
                ORD_OP_INTEGRACAO = Order.ORD_OP_INTEGRACAO,
                ORD_LOTE_PILOTO = Order.ORD_LOTE_PILOTO,
                ORD_PRIORIDADE = Order.ORD_PRIORIDADE,
                ORD_EMISSAO = Order.ORD_EMISSAO,
                REP_ID = Order.REP_ID,
                ORD_RESINA = Order.ORD_RESINA,
                ORD_ENDURECEDOR_MIOLO = Order.ORD_ENDURECEDOR_MIOLO,
                PRO_ID_INTEGRACAO_ERP = Order.PRO_ID_INTEGRACAO_ERP,
                ORD_VINCOS_ONDULADEIRA = Order.ORD_VINCOS_ONDULADEIRA,
                ORD_ERP_CUSTOS_FIXOS = Order.ORD_ERP_CUSTOS_FIXOS,
                ORD_ERP_CUSTOS_VARIAVEIS = Order.ORD_ERP_CUSTOS_VARIAVEIS,
                ORD_ERP_DESPESAS_VAR_VENDA = Order.ORD_ERP_DESPESAS_VAR_VENDA,
                ORD_ERP_IMPOSTOS = Order.ORD_ERP_IMPOSTOS,
                ORD_STATUS_PLANEJAMENTO = Order.ORD_STATUS_PLANEJAMENTO,
                ORD_TOLERANCIA_DIMENSAO_CHAPA_DE = Order.ORD_TOLERANCIA_DIMENSAO_CHAPA_DE,
                ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE = Order.ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE,
                ORD_PROMOVE_DE = Order.ORD_PROMOVE_DE,
                ORD_PROMOVE_ATE = Order.ORD_PROMOVE_ATE,
                ORD_TRAVA_COMPOSICAO = Order.ORD_TRAVA_COMPOSICAO,
                ORD_TRAVA_RESINA = Order.ORD_TRAVA_RESINA,
                ORD_PROMOVE_RESINA = Order.ORD_PROMOVE_RESINA,
                ORD_LATITUDE_ENTREGA = Order.ORD_LATITUDE_ENTREGA,
                ORD_LONGITUDE_ENTREGA = Order.ORD_LONGITUDE_ENTREGA,
                OCO_ID_CANCELAMENTO = Order.OCO_ID_CANCELAMENTO,
                TMP_TIPO_CARGA = Order.TMP_TIPO_CARGA,
                PRO_ID_PALETE = Order.PRO_ID_PALETE,
                PRO_ID_TAMPO = Order.PRO_ID_TAMPO,
                ORD_PILHAS_POR_PALETE = Order.ORD_PILHAS_POR_PALETE,
                ORD_CHAPAS_POR_PILHA = Order.ORD_CHAPAS_POR_PILHA,
                ORD_DATA_CANCELAMENTO = Order.ORD_DATA_CANCELAMENTO,
                ORD_STATUS_ESTATISTICA = Order.ORD_STATUS_ESTATISTICA,
                ORD_DATA_ESTATISTICA = Order.ORD_DATA_ESTATISTICA,
                OCO_ID_MOTIVO_ATRASO = Order.OCO_ID_MOTIVO_ATRASO,
                OTK_VERSSAO = Order.OTK_VERSSAO,
                Changed = Order.Changed,
                UserId = _executionContext.UserId,
                ORD_ID = Order.ORD_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_ID_RESERVA(string ord_id, string value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_ID_RESERVA] = @ORD_ID_RESERVA WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_ID_RESERVA = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_ID_CONJUNTO(string ord_id, string value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_ID_CONJUNTO] = @ORD_ID_CONJUNTO WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_ID_CONJUNTO = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ID(string ord_id, string value)
        {
            this.Query = $@" UPDATE [Order] SET [PRO_ID] = @PRO_ID WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                PRO_ID = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ID_CONJUNTO(string ord_id, string value)
        {
            this.Query = $@" UPDATE [Order] SET [PRO_ID_CONJUNTO] = @PRO_ID_CONJUNTO WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                PRO_ID_CONJUNTO = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCLI_ID(string ord_id, string value)
        {
            this.Query = $@" UPDATE [Order] SET [CLI_ID] = @CLI_ID WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                CLI_ID = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_PRECO_UNITARIO(string ord_id, Decimal value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_PRECO_UNITARIO] = @ORD_PRECO_UNITARIO WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_PRECO_UNITARIO = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_QUANTIDADE(string ord_id, Decimal value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_QUANTIDADE] = @ORD_QUANTIDADE WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_QUANTIDADE = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_DATA_ENTREGA_DE(string ord_id, DateTime value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_DATA_ENTREGA_DE] = @ORD_DATA_ENTREGA_DE WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_DATA_ENTREGA_DE = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_DATA_ENTREGA_ATE(string ord_id, DateTime value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_DATA_ENTREGA_ATE] = @ORD_DATA_ENTREGA_ATE WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_DATA_ENTREGA_ATE = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_TIPO(string ord_id, int value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_TIPO] = @ORD_TIPO WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_TIPO = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_TOLERANCIA_MAIS(string ord_id, Decimal value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_TOLERANCIA_MAIS] = @ORD_TOLERANCIA_MAIS WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_TOLERANCIA_MAIS = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_TOLERANCIA_MENOS(string ord_id, Decimal value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_TOLERANCIA_MENOS] = @ORD_TOLERANCIA_MENOS WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_TOLERANCIA_MENOS = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateHASH_KEY(string ord_id, string value)
        {
            this.Query = $@" UPDATE [Order] SET [HASH_KEY] = @HASH_KEY WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                HASH_KEY = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_INICIO_JANELA_EMBARQUE(string ord_id, DateTime value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_INICIO_JANELA_EMBARQUE] = @ORD_INICIO_JANELA_EMBARQUE WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_INICIO_JANELA_EMBARQUE = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_FIM_JANELA_EMBARQUE(string ord_id, DateTime value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_FIM_JANELA_EMBARQUE] = @ORD_FIM_JANELA_EMBARQUE WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_FIM_JANELA_EMBARQUE = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_EMBARQUE_ALVO(string ord_id, DateTime value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_EMBARQUE_ALVO] = @ORD_EMBARQUE_ALVO WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_EMBARQUE_ALVO = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_INICIO_GRUPO_PRODUTIVO(string ord_id, DateTime value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_INICIO_GRUPO_PRODUTIVO] = @ORD_INICIO_GRUPO_PRODUTIVO WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_INICIO_GRUPO_PRODUTIVO = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_FIM_GRUPO_PRODUTIVO(string ord_id, DateTime value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_FIM_GRUPO_PRODUTIVO] = @ORD_FIM_GRUPO_PRODUTIVO WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_FIM_GRUPO_PRODUTIVO = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_PESO_UNITARIO(string ord_id, Decimal value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_PESO_UNITARIO] = @ORD_PESO_UNITARIO WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_PESO_UNITARIO = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_PESO_UNITARIO_BRUTO(string ord_id, Decimal value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_PESO_UNITARIO_BRUTO] = @ORD_PESO_UNITARIO_BRUTO WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_PESO_UNITARIO_BRUTO = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_M2_UNITARIO(string ord_id, Decimal value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_M2_UNITARIO] = @ORD_M2_UNITARIO WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_M2_UNITARIO = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_MIT(string ord_id, string value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_MIT] = @ORD_MIT WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_MIT = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_TIPO_CARREGAMENTO(string ord_id, string value)
        {
            this.Query = $@" UPDATE [Order] SET [CAR_TIPO_CARREGAMENTO] = @CAR_TIPO_CARREGAMENTO WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                CAR_TIPO_CARREGAMENTO = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_STATUS(string ord_id, string value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_STATUS] = @ORD_STATUS WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_STATUS = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_TIPO_FRETE(string ord_id, string value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_TIPO_FRETE] = @ORD_TIPO_FRETE WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_TIPO_FRETE = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_ENDERECO_ENTREGA(string ord_id, string value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_ENDERECO_ENTREGA] = @ORD_ENDERECO_ENTREGA WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_ENDERECO_ENTREGA = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_BAIRRO_ENTREGA(string ord_id, string value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_BAIRRO_ENTREGA] = @ORD_BAIRRO_ENTREGA WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_BAIRRO_ENTREGA = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUF_ID_ENTREGA(string ord_id, string value)
        {
            this.Query = $@" UPDATE [Order] SET [UF_ID_ENTREGA] = @UF_ID_ENTREGA WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                UF_ID_ENTREGA = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_CEP_ENTREGA(string ord_id, string value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_CEP_ENTREGA] = @ORD_CEP_ENTREGA WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_CEP_ENTREGA = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMUN_ID_ENTREGA(string ord_id, string value)
        {
            this.Query = $@" UPDATE [Order] SET [MUN_ID_ENTREGA] = @MUN_ID_ENTREGA WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                MUN_ID_ENTREGA = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_REGIAO_ENTREGA(string ord_id, string value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_REGIAO_ENTREGA] = @ORD_REGIAO_ENTREGA WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_REGIAO_ENTREGA = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_LARGURA(string ord_id, Decimal value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_LARGURA] = @ORD_LARGURA WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_LARGURA = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_COMPRIMENTO(string ord_id, Decimal value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_COMPRIMENTO] = @ORD_COMPRIMENTO WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_COMPRIMENTO = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_GRAMATURA(string ord_id, Decimal value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_GRAMATURA] = @ORD_GRAMATURA WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_GRAMATURA = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_ID(string ord_id, string value)
        {
            this.Query = $@" UPDATE [Order] SET [GRP_ID] = @GRP_ID WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                GRP_ID = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_ID_INTEGRACAO(string ord_id, string value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_ID_INTEGRACAO] = @ORD_ID_INTEGRACAO WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_ID_INTEGRACAO = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_OBSERVACAO_OTIMIZADOR(string ord_id, string value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_OBSERVACAO_OTIMIZADOR] = @ORD_OBSERVACAO_OTIMIZADOR WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_OBSERVACAO_OTIMIZADOR = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_COR_FILA(string ord_id, string value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_COR_FILA] = @ORD_COR_FILA WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_COR_FILA = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_PED_CLI(string ord_id, string value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_PED_CLI] = @ORD_PED_CLI WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_PED_CLI = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_OP_INTEGRACAO(string ord_id, string value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_OP_INTEGRACAO] = @ORD_OP_INTEGRACAO WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_OP_INTEGRACAO = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_LOTE_PILOTO(string ord_id, string value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_LOTE_PILOTO] = @ORD_LOTE_PILOTO WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_LOTE_PILOTO = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_PRIORIDADE(string ord_id, int value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_PRIORIDADE] = @ORD_PRIORIDADE WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_PRIORIDADE = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_EMISSAO(string ord_id, DateTime value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_EMISSAO] = @ORD_EMISSAO WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_EMISSAO = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateREP_ID(string ord_id, string value)
        {
            this.Query = $@" UPDATE [Order] SET [REP_ID] = @REP_ID WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                REP_ID = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_RESINA(string ord_id, string value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_RESINA] = @ORD_RESINA WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_RESINA = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_ENDURECEDOR_MIOLO(string ord_id, string value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_ENDURECEDOR_MIOLO] = @ORD_ENDURECEDOR_MIOLO WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_ENDURECEDOR_MIOLO = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ID_INTEGRACAO_ERP(string ord_id, string value)
        {
            this.Query = $@" UPDATE [Order] SET [PRO_ID_INTEGRACAO_ERP] = @PRO_ID_INTEGRACAO_ERP WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                PRO_ID_INTEGRACAO_ERP = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_VINCOS_ONDULADEIRA(string ord_id, string value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_VINCOS_ONDULADEIRA] = @ORD_VINCOS_ONDULADEIRA WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_VINCOS_ONDULADEIRA = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_ERP_CUSTOS_FIXOS(string ord_id, Decimal value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_ERP_CUSTOS_FIXOS] = @ORD_ERP_CUSTOS_FIXOS WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_ERP_CUSTOS_FIXOS = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_ERP_CUSTOS_VARIAVEIS(string ord_id, Decimal value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_ERP_CUSTOS_VARIAVEIS] = @ORD_ERP_CUSTOS_VARIAVEIS WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_ERP_CUSTOS_VARIAVEIS = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_ERP_DESPESAS_VAR_VENDA(string ord_id, Decimal value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_ERP_DESPESAS_VAR_VENDA] = @ORD_ERP_DESPESAS_VAR_VENDA WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_ERP_DESPESAS_VAR_VENDA = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_ERP_IMPOSTOS(string ord_id, Decimal value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_ERP_IMPOSTOS] = @ORD_ERP_IMPOSTOS WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_ERP_IMPOSTOS = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_STATUS_PLANEJAMENTO(string ord_id, string value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_STATUS_PLANEJAMENTO] = @ORD_STATUS_PLANEJAMENTO WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_STATUS_PLANEJAMENTO = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_TOLERANCIA_DIMENSAO_CHAPA_DE(string ord_id, int value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_TOLERANCIA_DIMENSAO_CHAPA_DE] = @ORD_TOLERANCIA_DIMENSAO_CHAPA_DE WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_TOLERANCIA_DIMENSAO_CHAPA_DE = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_TOLERANCIA_DIMENSAO_CHAPA_ATE(string ord_id, int value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE] = @ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_PROMOVE_DE(string ord_id, Decimal value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_PROMOVE_DE] = @ORD_PROMOVE_DE WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_PROMOVE_DE = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_PROMOVE_ATE(string ord_id, Decimal value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_PROMOVE_ATE] = @ORD_PROMOVE_ATE WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_PROMOVE_ATE = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_TRAVA_COMPOSICAO(string ord_id, string value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_TRAVA_COMPOSICAO] = @ORD_TRAVA_COMPOSICAO WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_TRAVA_COMPOSICAO = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_TRAVA_RESINA(string ord_id, string value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_TRAVA_RESINA] = @ORD_TRAVA_RESINA WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_TRAVA_RESINA = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_PROMOVE_RESINA(string ord_id, string value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_PROMOVE_RESINA] = @ORD_PROMOVE_RESINA WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_PROMOVE_RESINA = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_LATITUDE_ENTREGA(string ord_id, Decimal value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_LATITUDE_ENTREGA] = @ORD_LATITUDE_ENTREGA WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_LATITUDE_ENTREGA = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_LONGITUDE_ENTREGA(string ord_id, Decimal value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_LONGITUDE_ENTREGA] = @ORD_LONGITUDE_ENTREGA WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_LONGITUDE_ENTREGA = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOCO_ID_CANCELAMENTO(string ord_id, string value)
        {
            this.Query = $@" UPDATE [Order] SET [OCO_ID_CANCELAMENTO] = @OCO_ID_CANCELAMENTO WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                OCO_ID_CANCELAMENTO = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTMP_TIPO_CARGA(string ord_id, string value)
        {
            this.Query = $@" UPDATE [Order] SET [TMP_TIPO_CARGA] = @TMP_TIPO_CARGA WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                TMP_TIPO_CARGA = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ID_PALETE(string ord_id, string value)
        {
            this.Query = $@" UPDATE [Order] SET [PRO_ID_PALETE] = @PRO_ID_PALETE WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                PRO_ID_PALETE = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ID_TAMPO(string ord_id, string value)
        {
            this.Query = $@" UPDATE [Order] SET [PRO_ID_TAMPO] = @PRO_ID_TAMPO WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                PRO_ID_TAMPO = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_PILHAS_POR_PALETE(string ord_id, int value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_PILHAS_POR_PALETE] = @ORD_PILHAS_POR_PALETE WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_PILHAS_POR_PALETE = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_CHAPAS_POR_PILHA(string ord_id, int value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_CHAPAS_POR_PILHA] = @ORD_CHAPAS_POR_PILHA WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_CHAPAS_POR_PILHA = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_DATA_CANCELAMENTO(string ord_id, DateTime value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_DATA_CANCELAMENTO] = @ORD_DATA_CANCELAMENTO WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_DATA_CANCELAMENTO = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_STATUS_ESTATISTICA(string ord_id, string value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_STATUS_ESTATISTICA] = @ORD_STATUS_ESTATISTICA WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_STATUS_ESTATISTICA = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_DATA_ESTATISTICA(string ord_id, DateTime value)
        {
            this.Query = $@" UPDATE [Order] SET [ORD_DATA_ESTATISTICA] = @ORD_DATA_ESTATISTICA WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_DATA_ESTATISTICA = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOCO_ID_MOTIVO_ATRASO(string ord_id, string value)
        {
            this.Query = $@" UPDATE [Order] SET [OCO_ID_MOTIVO_ATRASO] = @OCO_ID_MOTIVO_ATRASO WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                OCO_ID_MOTIVO_ATRASO = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOTK_VERSSAO(string ord_id, int value)
        {
            this.Query = $@" UPDATE [Order] SET [OTK_VERSSAO] = @OTK_VERSSAO WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                OTK_VERSSAO = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(string ord_id, int value)
        {
            this.Query = $@" UPDATE [Order] SET [TenantID] = @TenantID WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                TenantID = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(string ord_id, bool value)
        {
            this.Query = $@" UPDATE [Order] SET [Deleted] = @Deleted WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                Deleted = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(string ord_id, DateTime value)
        {
            this.Query = $@" UPDATE [Order] SET [Changed] = @Changed WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                Changed = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(string ord_id, int value)
        {
            this.Query = $@" UPDATE [Order] SET [UserId] = @UserId WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                UserId = value,
                ORD_ID = ord_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteOrderQuery(IOrderEntity Order)
        {
            this.Query = $@" DELETE FROM [Order] WHERE [ORD_ID] = @ORD_ID ";
            this.Parameters = new
            {
                ORD_ID = Order.ORD_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration