// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration
// </yeshua>

using Shered.DB;
using System.Data.SqlTypes;
using Command.Read;
using IQuery.Read;
using Aplication.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using System.Threading.Tasks;

namespace Query.Read 
{
    public class OrderQueryRead : QueryBase, IOrderQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public OrderQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel OrderQuery(Command.Read.OrderReadCommand Command )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId from Order ";
if (!string.IsNullOrEmpty(Command.ORD_ID)) dict["ORD_ID"] = $"%{Command.ORD_ID}%";
if (!string.IsNullOrEmpty(Command.ORD_ID)) whereClauses.Add($"ORD_ID like @ORD_ID");
if (!string.IsNullOrEmpty(Command.ORD_ID_RESERVA)) dict["ORD_ID_RESERVA"] = $"%{Command.ORD_ID_RESERVA}%";
if (!string.IsNullOrEmpty(Command.ORD_ID_RESERVA)) whereClauses.Add($"ORD_ID_RESERVA like @ORD_ID_RESERVA");
if (!string.IsNullOrEmpty(Command.ORD_ID_CONJUNTO)) dict["ORD_ID_CONJUNTO"] = $"%{Command.ORD_ID_CONJUNTO}%";
if (!string.IsNullOrEmpty(Command.ORD_ID_CONJUNTO)) whereClauses.Add($"ORD_ID_CONJUNTO like @ORD_ID_CONJUNTO");
if (!string.IsNullOrEmpty(Command.PRO_ID)) dict["PRO_ID"] = $"%{Command.PRO_ID}%";
if (!string.IsNullOrEmpty(Command.PRO_ID)) whereClauses.Add($"PRO_ID like @PRO_ID");
if (!string.IsNullOrEmpty(Command.PRO_ID_CONJUNTO)) dict["PRO_ID_CONJUNTO"] = $"%{Command.PRO_ID_CONJUNTO}%";
if (!string.IsNullOrEmpty(Command.PRO_ID_CONJUNTO)) whereClauses.Add($"PRO_ID_CONJUNTO like @PRO_ID_CONJUNTO");
if (!string.IsNullOrEmpty(Command.CLI_ID)) dict["CLI_ID"] = $"%{Command.CLI_ID}%";
if (!string.IsNullOrEmpty(Command.CLI_ID)) whereClauses.Add($"CLI_ID like @CLI_ID");
if (Command.ORD_TIPO.HasValue) dict["ORD_TIPO"] = Command.ORD_TIPO.Value;
if (Command.ORD_TIPO.HasValue) whereClauses.Add($"ORD_TIPO = @ORD_TIPO");
if (!string.IsNullOrEmpty(Command.HASH_KEY)) dict["HASH_KEY"] = $"%{Command.HASH_KEY}%";
if (!string.IsNullOrEmpty(Command.HASH_KEY)) whereClauses.Add($"HASH_KEY like @HASH_KEY");
if (!string.IsNullOrEmpty(Command.ORD_MIT)) dict["ORD_MIT"] = $"%{Command.ORD_MIT}%";
if (!string.IsNullOrEmpty(Command.ORD_MIT)) whereClauses.Add($"ORD_MIT like @ORD_MIT");
if (!string.IsNullOrEmpty(Command.CAR_TIPO_CARREGAMENTO)) dict["CAR_TIPO_CARREGAMENTO"] = $"%{Command.CAR_TIPO_CARREGAMENTO}%";
if (!string.IsNullOrEmpty(Command.CAR_TIPO_CARREGAMENTO)) whereClauses.Add($"CAR_TIPO_CARREGAMENTO like @CAR_TIPO_CARREGAMENTO");
if (!string.IsNullOrEmpty(Command.ORD_STATUS)) dict["ORD_STATUS"] = $"%{Command.ORD_STATUS}%";
if (!string.IsNullOrEmpty(Command.ORD_STATUS)) whereClauses.Add($"ORD_STATUS like @ORD_STATUS");
if (!string.IsNullOrEmpty(Command.ORD_TIPO_FRETE)) dict["ORD_TIPO_FRETE"] = $"%{Command.ORD_TIPO_FRETE}%";
if (!string.IsNullOrEmpty(Command.ORD_TIPO_FRETE)) whereClauses.Add($"ORD_TIPO_FRETE like @ORD_TIPO_FRETE");
if (!string.IsNullOrEmpty(Command.ORD_ENDERECO_ENTREGA)) dict["ORD_ENDERECO_ENTREGA"] = $"%{Command.ORD_ENDERECO_ENTREGA}%";
if (!string.IsNullOrEmpty(Command.ORD_ENDERECO_ENTREGA)) whereClauses.Add($"ORD_ENDERECO_ENTREGA like @ORD_ENDERECO_ENTREGA");
if (!string.IsNullOrEmpty(Command.ORD_BAIRRO_ENTREGA)) dict["ORD_BAIRRO_ENTREGA"] = $"%{Command.ORD_BAIRRO_ENTREGA}%";
if (!string.IsNullOrEmpty(Command.ORD_BAIRRO_ENTREGA)) whereClauses.Add($"ORD_BAIRRO_ENTREGA like @ORD_BAIRRO_ENTREGA");
if (!string.IsNullOrEmpty(Command.UF_ID_ENTREGA)) dict["UF_ID_ENTREGA"] = $"%{Command.UF_ID_ENTREGA}%";
if (!string.IsNullOrEmpty(Command.UF_ID_ENTREGA)) whereClauses.Add($"UF_ID_ENTREGA like @UF_ID_ENTREGA");
if (!string.IsNullOrEmpty(Command.ORD_CEP_ENTREGA)) dict["ORD_CEP_ENTREGA"] = $"%{Command.ORD_CEP_ENTREGA}%";
if (!string.IsNullOrEmpty(Command.ORD_CEP_ENTREGA)) whereClauses.Add($"ORD_CEP_ENTREGA like @ORD_CEP_ENTREGA");
if (!string.IsNullOrEmpty(Command.MUN_ID_ENTREGA)) dict["MUN_ID_ENTREGA"] = $"%{Command.MUN_ID_ENTREGA}%";
if (!string.IsNullOrEmpty(Command.MUN_ID_ENTREGA)) whereClauses.Add($"MUN_ID_ENTREGA like @MUN_ID_ENTREGA");
if (!string.IsNullOrEmpty(Command.ORD_REGIAO_ENTREGA)) dict["ORD_REGIAO_ENTREGA"] = $"%{Command.ORD_REGIAO_ENTREGA}%";
if (!string.IsNullOrEmpty(Command.ORD_REGIAO_ENTREGA)) whereClauses.Add($"ORD_REGIAO_ENTREGA like @ORD_REGIAO_ENTREGA");
if (!string.IsNullOrEmpty(Command.GRP_ID)) dict["GRP_ID"] = $"%{Command.GRP_ID}%";
if (!string.IsNullOrEmpty(Command.GRP_ID)) whereClauses.Add($"GRP_ID like @GRP_ID");
if (!string.IsNullOrEmpty(Command.ORD_ID_INTEGRACAO)) dict["ORD_ID_INTEGRACAO"] = $"%{Command.ORD_ID_INTEGRACAO}%";
if (!string.IsNullOrEmpty(Command.ORD_ID_INTEGRACAO)) whereClauses.Add($"ORD_ID_INTEGRACAO like @ORD_ID_INTEGRACAO");
if (!string.IsNullOrEmpty(Command.ORD_OBSERVACAO_OTIMIZADOR)) dict["ORD_OBSERVACAO_OTIMIZADOR"] = $"%{Command.ORD_OBSERVACAO_OTIMIZADOR}%";
if (!string.IsNullOrEmpty(Command.ORD_OBSERVACAO_OTIMIZADOR)) whereClauses.Add($"ORD_OBSERVACAO_OTIMIZADOR like @ORD_OBSERVACAO_OTIMIZADOR");
if (!string.IsNullOrEmpty(Command.ORD_COR_FILA)) dict["ORD_COR_FILA"] = $"%{Command.ORD_COR_FILA}%";
if (!string.IsNullOrEmpty(Command.ORD_COR_FILA)) whereClauses.Add($"ORD_COR_FILA like @ORD_COR_FILA");
if (!string.IsNullOrEmpty(Command.ORD_PED_CLI)) dict["ORD_PED_CLI"] = $"%{Command.ORD_PED_CLI}%";
if (!string.IsNullOrEmpty(Command.ORD_PED_CLI)) whereClauses.Add($"ORD_PED_CLI like @ORD_PED_CLI");
if (!string.IsNullOrEmpty(Command.ORD_OP_INTEGRACAO)) dict["ORD_OP_INTEGRACAO"] = $"%{Command.ORD_OP_INTEGRACAO}%";
if (!string.IsNullOrEmpty(Command.ORD_OP_INTEGRACAO)) whereClauses.Add($"ORD_OP_INTEGRACAO like @ORD_OP_INTEGRACAO");
if (!string.IsNullOrEmpty(Command.ORD_LOTE_PILOTO)) dict["ORD_LOTE_PILOTO"] = $"%{Command.ORD_LOTE_PILOTO}%";
if (!string.IsNullOrEmpty(Command.ORD_LOTE_PILOTO)) whereClauses.Add($"ORD_LOTE_PILOTO like @ORD_LOTE_PILOTO");
if (Command.ORD_PRIORIDADE.HasValue) dict["ORD_PRIORIDADE"] = Command.ORD_PRIORIDADE.Value;
if (Command.ORD_PRIORIDADE.HasValue) whereClauses.Add($"ORD_PRIORIDADE = @ORD_PRIORIDADE");
if (!string.IsNullOrEmpty(Command.REP_ID)) dict["REP_ID"] = $"%{Command.REP_ID}%";
if (!string.IsNullOrEmpty(Command.REP_ID)) whereClauses.Add($"REP_ID like @REP_ID");
if (!string.IsNullOrEmpty(Command.ORD_RESINA)) dict["ORD_RESINA"] = $"%{Command.ORD_RESINA}%";
if (!string.IsNullOrEmpty(Command.ORD_RESINA)) whereClauses.Add($"ORD_RESINA like @ORD_RESINA");
if (!string.IsNullOrEmpty(Command.ORD_ENDURECEDOR_MIOLO)) dict["ORD_ENDURECEDOR_MIOLO"] = $"%{Command.ORD_ENDURECEDOR_MIOLO}%";
if (!string.IsNullOrEmpty(Command.ORD_ENDURECEDOR_MIOLO)) whereClauses.Add($"ORD_ENDURECEDOR_MIOLO like @ORD_ENDURECEDOR_MIOLO");
if (!string.IsNullOrEmpty(Command.PRO_ID_INTEGRACAO_ERP)) dict["PRO_ID_INTEGRACAO_ERP"] = $"%{Command.PRO_ID_INTEGRACAO_ERP}%";
if (!string.IsNullOrEmpty(Command.PRO_ID_INTEGRACAO_ERP)) whereClauses.Add($"PRO_ID_INTEGRACAO_ERP like @PRO_ID_INTEGRACAO_ERP");
if (!string.IsNullOrEmpty(Command.ORD_VINCOS_ONDULADEIRA)) dict["ORD_VINCOS_ONDULADEIRA"] = $"%{Command.ORD_VINCOS_ONDULADEIRA}%";
if (!string.IsNullOrEmpty(Command.ORD_VINCOS_ONDULADEIRA)) whereClauses.Add($"ORD_VINCOS_ONDULADEIRA like @ORD_VINCOS_ONDULADEIRA");
if (!string.IsNullOrEmpty(Command.ORD_STATUS_PLANEJAMENTO)) dict["ORD_STATUS_PLANEJAMENTO"] = $"%{Command.ORD_STATUS_PLANEJAMENTO}%";
if (!string.IsNullOrEmpty(Command.ORD_STATUS_PLANEJAMENTO)) whereClauses.Add($"ORD_STATUS_PLANEJAMENTO like @ORD_STATUS_PLANEJAMENTO");
if (Command.ORD_TOLERANCIA_DIMENSAO_CHAPA_DE.HasValue) dict["ORD_TOLERANCIA_DIMENSAO_CHAPA_DE"] = Command.ORD_TOLERANCIA_DIMENSAO_CHAPA_DE.Value;
if (Command.ORD_TOLERANCIA_DIMENSAO_CHAPA_DE.HasValue) whereClauses.Add($"ORD_TOLERANCIA_DIMENSAO_CHAPA_DE = @ORD_TOLERANCIA_DIMENSAO_CHAPA_DE");
if (Command.ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE.HasValue) dict["ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE"] = Command.ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE.Value;
if (Command.ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE.HasValue) whereClauses.Add($"ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE = @ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE");
if (!string.IsNullOrEmpty(Command.ORD_TRAVA_COMPOSICAO)) dict["ORD_TRAVA_COMPOSICAO"] = $"%{Command.ORD_TRAVA_COMPOSICAO}%";
if (!string.IsNullOrEmpty(Command.ORD_TRAVA_COMPOSICAO)) whereClauses.Add($"ORD_TRAVA_COMPOSICAO like @ORD_TRAVA_COMPOSICAO");
if (!string.IsNullOrEmpty(Command.ORD_TRAVA_RESINA)) dict["ORD_TRAVA_RESINA"] = $"%{Command.ORD_TRAVA_RESINA}%";
if (!string.IsNullOrEmpty(Command.ORD_TRAVA_RESINA)) whereClauses.Add($"ORD_TRAVA_RESINA like @ORD_TRAVA_RESINA");
if (!string.IsNullOrEmpty(Command.ORD_PROMOVE_RESINA)) dict["ORD_PROMOVE_RESINA"] = $"%{Command.ORD_PROMOVE_RESINA}%";
if (!string.IsNullOrEmpty(Command.ORD_PROMOVE_RESINA)) whereClauses.Add($"ORD_PROMOVE_RESINA like @ORD_PROMOVE_RESINA");
if (!string.IsNullOrEmpty(Command.OCO_ID_CANCELAMENTO)) dict["OCO_ID_CANCELAMENTO"] = $"%{Command.OCO_ID_CANCELAMENTO}%";
if (!string.IsNullOrEmpty(Command.OCO_ID_CANCELAMENTO)) whereClauses.Add($"OCO_ID_CANCELAMENTO like @OCO_ID_CANCELAMENTO");
if (!string.IsNullOrEmpty(Command.TMP_TIPO_CARGA)) dict["TMP_TIPO_CARGA"] = $"%{Command.TMP_TIPO_CARGA}%";
if (!string.IsNullOrEmpty(Command.TMP_TIPO_CARGA)) whereClauses.Add($"TMP_TIPO_CARGA like @TMP_TIPO_CARGA");
if (!string.IsNullOrEmpty(Command.PRO_ID_PALETE)) dict["PRO_ID_PALETE"] = $"%{Command.PRO_ID_PALETE}%";
if (!string.IsNullOrEmpty(Command.PRO_ID_PALETE)) whereClauses.Add($"PRO_ID_PALETE like @PRO_ID_PALETE");
if (!string.IsNullOrEmpty(Command.PRO_ID_TAMPO)) dict["PRO_ID_TAMPO"] = $"%{Command.PRO_ID_TAMPO}%";
if (!string.IsNullOrEmpty(Command.PRO_ID_TAMPO)) whereClauses.Add($"PRO_ID_TAMPO like @PRO_ID_TAMPO");
if (Command.ORD_PILHAS_POR_PALETE.HasValue) dict["ORD_PILHAS_POR_PALETE"] = Command.ORD_PILHAS_POR_PALETE.Value;
if (Command.ORD_PILHAS_POR_PALETE.HasValue) whereClauses.Add($"ORD_PILHAS_POR_PALETE = @ORD_PILHAS_POR_PALETE");
if (Command.ORD_CHAPAS_POR_PILHA.HasValue) dict["ORD_CHAPAS_POR_PILHA"] = Command.ORD_CHAPAS_POR_PILHA.Value;
if (Command.ORD_CHAPAS_POR_PILHA.HasValue) whereClauses.Add($"ORD_CHAPAS_POR_PILHA = @ORD_CHAPAS_POR_PILHA");
if (!string.IsNullOrEmpty(Command.ORD_STATUS_ESTATISTICA)) dict["ORD_STATUS_ESTATISTICA"] = $"%{Command.ORD_STATUS_ESTATISTICA}%";
if (!string.IsNullOrEmpty(Command.ORD_STATUS_ESTATISTICA)) whereClauses.Add($"ORD_STATUS_ESTATISTICA like @ORD_STATUS_ESTATISTICA");
if (!string.IsNullOrEmpty(Command.OCO_ID_MOTIVO_ATRASO)) dict["OCO_ID_MOTIVO_ATRASO"] = $"%{Command.OCO_ID_MOTIVO_ATRASO}%";
if (!string.IsNullOrEmpty(Command.OCO_ID_MOTIVO_ATRASO)) whereClauses.Add($"OCO_ID_MOTIVO_ATRASO like @OCO_ID_MOTIVO_ATRASO");
if (Command.OTK_VERSSAO.HasValue) dict["OTK_VERSSAO"] = Command.OTK_VERSSAO.Value;
if (Command.OTK_VERSSAO.HasValue) whereClauses.Add($"OTK_VERSSAO = @OTK_VERSSAO");
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
if (Command.UserId.HasValue) dict["UserId"] = Command.UserId.Value;
if (Command.UserId.HasValue) whereClauses.Add($"UserId = @UserId");
            if (whereClauses.Any()) 
                 this.Query += $" WHERE {string.Join(" AND ", whereClauses)}"; 
            int page = Command.Paginacao?.Page ?? 1;
            int pageSize = Command.Paginacao?.PageSize ?? 20;
            int offset = (page - 1) * pageSize;
            dict["Offset"] = offset;
            dict["PageSize"] = pageSize;
            Query += " ORDER BY ORD_ID OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel OrderCLI_IDQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select CLI_ID from Cliente ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["CLI_ID"] = numero; //01
                      whereClauses.Add($" CLI_ID = @CLI_ID");//01 
                 }
                 else 
                 {
                      dict["CLI_ID"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" CLI_ID like @CLI_ID ");//02
                 }
           }
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel OrderMUN_ID_ENTREGAQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select MUN_ID from Municipio ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["MUN_ID"] = numero; //01
                      whereClauses.Add($" MUN_ID = @MUN_ID");//01 
                 }
                 else 
                 {
                      dict["MUN_ID"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" MUN_ID like @MUN_ID ");//02
                 }
           }
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel OrderORD_REGIAO_ENTREGAQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select PON_ID from PontosMapa ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["PON_ID"] = numero; //01
                      whereClauses.Add($" PON_ID = @PON_ID");//01 
                 }
                 else 
                 {
                      dict["PON_ID"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" PON_ID like @PON_ID ");//02
                 }
           }
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel OrderOCO_ID_CANCELAMENTOQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select OCO_ID from Ocorrencia ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["OCO_ID"] = numero; //01
                      whereClauses.Add($" OCO_ID = @OCO_ID");//01 
                 }
                 else 
                 {
                      dict["OCO_ID"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" OCO_ID like @OCO_ID ");//02
                 }
           }
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel OrderTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select Id, Nome from yTenant ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["Id"] = numero; //01
                      whereClauses.Add($" Id = @Id");//01 
                 }
                 else 
                 {
                      dict["Id"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" Id like @Id ");//02
                      dict["Nome"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" Nome like @Nome ");//02
                 }
           }
 dict["Id"] = _executionContext.TenantID;
 whereClauses.Add($"Id = @Id");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel OrderUserIdQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select Id, Nome from yUser ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["Id"] = numero; //01
                      whereClauses.Add($" Id = @Id");//01 
                 }
                 else 
                 {
                      dict["Id"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" Id like @Id ");//02
                      dict["Nome"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" Nome like @Nome ");//02
                 }
           }
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel ExistsByORD_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_ID"] = value; //04
                      whereClauses.Add($" ORD_ID = @ORD_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_ID_RESERVAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_ID_RESERVA"] = value; //04
                      whereClauses.Add($" ORD_ID_RESERVA = @ORD_ID_RESERVA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_ID_CONJUNTOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_ID_CONJUNTO"] = value; //04
                      whereClauses.Add($" ORD_ID_CONJUNTO = @ORD_ID_CONJUNTO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ID"] = value; //04
                      whereClauses.Add($" PRO_ID = @PRO_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_ID_CONJUNTOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ID_CONJUNTO"] = value; //04
                      whereClauses.Add($" PRO_ID_CONJUNTO = @PRO_ID_CONJUNTO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCLI_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CLI_ID"] = value; //04
                      whereClauses.Add($" CLI_ID = @CLI_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_PRECO_UNITARIOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_PRECO_UNITARIO"] = value; //04
                      whereClauses.Add($" ORD_PRECO_UNITARIO = @ORD_PRECO_UNITARIO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_QUANTIDADEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_QUANTIDADE"] = value; //04
                      whereClauses.Add($" ORD_QUANTIDADE = @ORD_QUANTIDADE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_DATA_ENTREGA_DEQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_DATA_ENTREGA_DE"] = value; //04
                      whereClauses.Add($" ORD_DATA_ENTREGA_DE = @ORD_DATA_ENTREGA_DE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_DATA_ENTREGA_ATEQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_DATA_ENTREGA_ATE"] = value; //04
                      whereClauses.Add($" ORD_DATA_ENTREGA_ATE = @ORD_DATA_ENTREGA_ATE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_TIPOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_TIPO"] = value; //04
                      whereClauses.Add($" ORD_TIPO = @ORD_TIPO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_TOLERANCIA_MAISQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_TOLERANCIA_MAIS"] = value; //04
                      whereClauses.Add($" ORD_TOLERANCIA_MAIS = @ORD_TOLERANCIA_MAIS ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_TOLERANCIA_MENOSQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_TOLERANCIA_MENOS"] = value; //04
                      whereClauses.Add($" ORD_TOLERANCIA_MENOS = @ORD_TOLERANCIA_MENOS ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByHASH_KEYQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["HASH_KEY"] = value; //04
                      whereClauses.Add($" HASH_KEY = @HASH_KEY ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_INICIO_JANELA_EMBARQUEQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_INICIO_JANELA_EMBARQUE"] = value; //04
                      whereClauses.Add($" ORD_INICIO_JANELA_EMBARQUE = @ORD_INICIO_JANELA_EMBARQUE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_FIM_JANELA_EMBARQUEQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_FIM_JANELA_EMBARQUE"] = value; //04
                      whereClauses.Add($" ORD_FIM_JANELA_EMBARQUE = @ORD_FIM_JANELA_EMBARQUE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_EMBARQUE_ALVOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_EMBARQUE_ALVO"] = value; //04
                      whereClauses.Add($" ORD_EMBARQUE_ALVO = @ORD_EMBARQUE_ALVO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_INICIO_GRUPO_PRODUTIVOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_INICIO_GRUPO_PRODUTIVO"] = value; //04
                      whereClauses.Add($" ORD_INICIO_GRUPO_PRODUTIVO = @ORD_INICIO_GRUPO_PRODUTIVO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_FIM_GRUPO_PRODUTIVOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_FIM_GRUPO_PRODUTIVO"] = value; //04
                      whereClauses.Add($" ORD_FIM_GRUPO_PRODUTIVO = @ORD_FIM_GRUPO_PRODUTIVO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_PESO_UNITARIOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_PESO_UNITARIO"] = value; //04
                      whereClauses.Add($" ORD_PESO_UNITARIO = @ORD_PESO_UNITARIO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_PESO_UNITARIO_BRUTOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_PESO_UNITARIO_BRUTO"] = value; //04
                      whereClauses.Add($" ORD_PESO_UNITARIO_BRUTO = @ORD_PESO_UNITARIO_BRUTO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_M2_UNITARIOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_M2_UNITARIO"] = value; //04
                      whereClauses.Add($" ORD_M2_UNITARIO = @ORD_M2_UNITARIO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_MITQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_MIT"] = value; //04
                      whereClauses.Add($" ORD_MIT = @ORD_MIT ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCAR_TIPO_CARREGAMENTOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_TIPO_CARREGAMENTO"] = value; //04
                      whereClauses.Add($" CAR_TIPO_CARREGAMENTO = @CAR_TIPO_CARREGAMENTO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_STATUSQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_STATUS"] = value; //04
                      whereClauses.Add($" ORD_STATUS = @ORD_STATUS ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_TIPO_FRETEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_TIPO_FRETE"] = value; //04
                      whereClauses.Add($" ORD_TIPO_FRETE = @ORD_TIPO_FRETE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_ENDERECO_ENTREGAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_ENDERECO_ENTREGA"] = value; //04
                      whereClauses.Add($" ORD_ENDERECO_ENTREGA = @ORD_ENDERECO_ENTREGA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_BAIRRO_ENTREGAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_BAIRRO_ENTREGA"] = value; //04
                      whereClauses.Add($" ORD_BAIRRO_ENTREGA = @ORD_BAIRRO_ENTREGA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByUF_ID_ENTREGAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["UF_ID_ENTREGA"] = value; //04
                      whereClauses.Add($" UF_ID_ENTREGA = @UF_ID_ENTREGA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_CEP_ENTREGAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_CEP_ENTREGA"] = value; //04
                      whereClauses.Add($" ORD_CEP_ENTREGA = @ORD_CEP_ENTREGA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMUN_ID_ENTREGAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MUN_ID_ENTREGA"] = value; //04
                      whereClauses.Add($" MUN_ID_ENTREGA = @MUN_ID_ENTREGA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_REGIAO_ENTREGAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_REGIAO_ENTREGA"] = value; //04
                      whereClauses.Add($" ORD_REGIAO_ENTREGA = @ORD_REGIAO_ENTREGA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_LARGURAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_LARGURA"] = value; //04
                      whereClauses.Add($" ORD_LARGURA = @ORD_LARGURA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_COMPRIMENTOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_COMPRIMENTO"] = value; //04
                      whereClauses.Add($" ORD_COMPRIMENTO = @ORD_COMPRIMENTO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_GRAMATURAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_GRAMATURA"] = value; //04
                      whereClauses.Add($" ORD_GRAMATURA = @ORD_GRAMATURA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRP_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_ID"] = value; //04
                      whereClauses.Add($" GRP_ID = @GRP_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_ID_INTEGRACAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_ID_INTEGRACAO"] = value; //04
                      whereClauses.Add($" ORD_ID_INTEGRACAO = @ORD_ID_INTEGRACAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_OBSERVACAO_OTIMIZADORQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_OBSERVACAO_OTIMIZADOR"] = value; //04
                      whereClauses.Add($" ORD_OBSERVACAO_OTIMIZADOR = @ORD_OBSERVACAO_OTIMIZADOR ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_COR_FILAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_COR_FILA"] = value; //04
                      whereClauses.Add($" ORD_COR_FILA = @ORD_COR_FILA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_PED_CLIQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_PED_CLI"] = value; //04
                      whereClauses.Add($" ORD_PED_CLI = @ORD_PED_CLI ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_OP_INTEGRACAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_OP_INTEGRACAO"] = value; //04
                      whereClauses.Add($" ORD_OP_INTEGRACAO = @ORD_OP_INTEGRACAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_LOTE_PILOTOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_LOTE_PILOTO"] = value; //04
                      whereClauses.Add($" ORD_LOTE_PILOTO = @ORD_LOTE_PILOTO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_PRIORIDADEQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_PRIORIDADE"] = value; //04
                      whereClauses.Add($" ORD_PRIORIDADE = @ORD_PRIORIDADE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_EMISSAOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_EMISSAO"] = value; //04
                      whereClauses.Add($" ORD_EMISSAO = @ORD_EMISSAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByREP_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["REP_ID"] = value; //04
                      whereClauses.Add($" REP_ID = @REP_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_RESINAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_RESINA"] = value; //04
                      whereClauses.Add($" ORD_RESINA = @ORD_RESINA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_ENDURECEDOR_MIOLOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_ENDURECEDOR_MIOLO"] = value; //04
                      whereClauses.Add($" ORD_ENDURECEDOR_MIOLO = @ORD_ENDURECEDOR_MIOLO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_ID_INTEGRACAO_ERPQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ID_INTEGRACAO_ERP"] = value; //04
                      whereClauses.Add($" PRO_ID_INTEGRACAO_ERP = @PRO_ID_INTEGRACAO_ERP ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_VINCOS_ONDULADEIRAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_VINCOS_ONDULADEIRA"] = value; //04
                      whereClauses.Add($" ORD_VINCOS_ONDULADEIRA = @ORD_VINCOS_ONDULADEIRA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_ERP_CUSTOS_FIXOSQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_ERP_CUSTOS_FIXOS"] = value; //04
                      whereClauses.Add($" ORD_ERP_CUSTOS_FIXOS = @ORD_ERP_CUSTOS_FIXOS ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_ERP_CUSTOS_VARIAVEISQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_ERP_CUSTOS_VARIAVEIS"] = value; //04
                      whereClauses.Add($" ORD_ERP_CUSTOS_VARIAVEIS = @ORD_ERP_CUSTOS_VARIAVEIS ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_ERP_DESPESAS_VAR_VENDAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_ERP_DESPESAS_VAR_VENDA"] = value; //04
                      whereClauses.Add($" ORD_ERP_DESPESAS_VAR_VENDA = @ORD_ERP_DESPESAS_VAR_VENDA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_ERP_IMPOSTOSQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_ERP_IMPOSTOS"] = value; //04
                      whereClauses.Add($" ORD_ERP_IMPOSTOS = @ORD_ERP_IMPOSTOS ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_STATUS_PLANEJAMENTOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_STATUS_PLANEJAMENTO"] = value; //04
                      whereClauses.Add($" ORD_STATUS_PLANEJAMENTO = @ORD_STATUS_PLANEJAMENTO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_TOLERANCIA_DIMENSAO_CHAPA_DEQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_TOLERANCIA_DIMENSAO_CHAPA_DE"] = value; //04
                      whereClauses.Add($" ORD_TOLERANCIA_DIMENSAO_CHAPA_DE = @ORD_TOLERANCIA_DIMENSAO_CHAPA_DE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_TOLERANCIA_DIMENSAO_CHAPA_ATEQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE"] = value; //04
                      whereClauses.Add($" ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE = @ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_PROMOVE_DEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_PROMOVE_DE"] = value; //04
                      whereClauses.Add($" ORD_PROMOVE_DE = @ORD_PROMOVE_DE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_PROMOVE_ATEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_PROMOVE_ATE"] = value; //04
                      whereClauses.Add($" ORD_PROMOVE_ATE = @ORD_PROMOVE_ATE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_TRAVA_COMPOSICAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_TRAVA_COMPOSICAO"] = value; //04
                      whereClauses.Add($" ORD_TRAVA_COMPOSICAO = @ORD_TRAVA_COMPOSICAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_TRAVA_RESINAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_TRAVA_RESINA"] = value; //04
                      whereClauses.Add($" ORD_TRAVA_RESINA = @ORD_TRAVA_RESINA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_PROMOVE_RESINAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_PROMOVE_RESINA"] = value; //04
                      whereClauses.Add($" ORD_PROMOVE_RESINA = @ORD_PROMOVE_RESINA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_LATITUDE_ENTREGAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_LATITUDE_ENTREGA"] = value; //04
                      whereClauses.Add($" ORD_LATITUDE_ENTREGA = @ORD_LATITUDE_ENTREGA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_LONGITUDE_ENTREGAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_LONGITUDE_ENTREGA"] = value; //04
                      whereClauses.Add($" ORD_LONGITUDE_ENTREGA = @ORD_LONGITUDE_ENTREGA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByOCO_ID_CANCELAMENTOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["OCO_ID_CANCELAMENTO"] = value; //04
                      whereClauses.Add($" OCO_ID_CANCELAMENTO = @OCO_ID_CANCELAMENTO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTMP_TIPO_CARGAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TMP_TIPO_CARGA"] = value; //04
                      whereClauses.Add($" TMP_TIPO_CARGA = @TMP_TIPO_CARGA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_ID_PALETEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ID_PALETE"] = value; //04
                      whereClauses.Add($" PRO_ID_PALETE = @PRO_ID_PALETE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_ID_TAMPOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ID_TAMPO"] = value; //04
                      whereClauses.Add($" PRO_ID_TAMPO = @PRO_ID_TAMPO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_PILHAS_POR_PALETEQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_PILHAS_POR_PALETE"] = value; //04
                      whereClauses.Add($" ORD_PILHAS_POR_PALETE = @ORD_PILHAS_POR_PALETE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_CHAPAS_POR_PILHAQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_CHAPAS_POR_PILHA"] = value; //04
                      whereClauses.Add($" ORD_CHAPAS_POR_PILHA = @ORD_CHAPAS_POR_PILHA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_DATA_CANCELAMENTOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_DATA_CANCELAMENTO"] = value; //04
                      whereClauses.Add($" ORD_DATA_CANCELAMENTO = @ORD_DATA_CANCELAMENTO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_STATUS_ESTATISTICAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_STATUS_ESTATISTICA"] = value; //04
                      whereClauses.Add($" ORD_STATUS_ESTATISTICA = @ORD_STATUS_ESTATISTICA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_DATA_ESTATISTICAQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_DATA_ESTATISTICA"] = value; //04
                      whereClauses.Add($" ORD_DATA_ESTATISTICA = @ORD_DATA_ESTATISTICA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByOCO_ID_MOTIVO_ATRASOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["OCO_ID_MOTIVO_ATRASO"] = value; //04
                      whereClauses.Add($" OCO_ID_MOTIVO_ATRASO = @OCO_ID_MOTIVO_ATRASO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByOTK_VERSSAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["OTK_VERSSAO"] = value; //04
                      whereClauses.Add($" OTK_VERSSAO = @OTK_VERSSAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTenantIDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TenantID"] = value; //04
                      whereClauses.Add($" TenantID = @TenantID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByDeletedQuery(bool value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Deleted"] = value; //04
                      whereClauses.Add($" Deleted = @Deleted ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByChangedQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Changed"] = value; //04
                      whereClauses.Add($" Changed = @Changed ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByUserIdQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["UserId"] = value; //04
                      whereClauses.Add($" UserId = @UserId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_ID"] = value; //06
                      whereClauses.Add($" ORD_ID = @ORD_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_ID_RESERVAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_ID_RESERVA"] = value; //06
                      whereClauses.Add($" ORD_ID_RESERVA = @ORD_ID_RESERVA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_ID_CONJUNTOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_ID_CONJUNTO"] = value; //06
                      whereClauses.Add($" ORD_ID_CONJUNTO = @ORD_ID_CONJUNTO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ID"] = value; //06
                      whereClauses.Add($" PRO_ID = @PRO_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_ID_CONJUNTOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ID_CONJUNTO"] = value; //06
                      whereClauses.Add($" PRO_ID_CONJUNTO = @PRO_ID_CONJUNTO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCLI_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CLI_ID"] = value; //06
                      whereClauses.Add($" CLI_ID = @CLI_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_PRECO_UNITARIOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_PRECO_UNITARIO"] = value; //06
                      whereClauses.Add($" ORD_PRECO_UNITARIO = @ORD_PRECO_UNITARIO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_QUANTIDADEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_QUANTIDADE"] = value; //06
                      whereClauses.Add($" ORD_QUANTIDADE = @ORD_QUANTIDADE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_DATA_ENTREGA_DEQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_DATA_ENTREGA_DE"] = value; //06
                      whereClauses.Add($" ORD_DATA_ENTREGA_DE = @ORD_DATA_ENTREGA_DE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_DATA_ENTREGA_ATEQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_DATA_ENTREGA_ATE"] = value; //06
                      whereClauses.Add($" ORD_DATA_ENTREGA_ATE = @ORD_DATA_ENTREGA_ATE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_TIPOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_TIPO"] = value; //06
                      whereClauses.Add($" ORD_TIPO = @ORD_TIPO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_TOLERANCIA_MAISQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_TOLERANCIA_MAIS"] = value; //06
                      whereClauses.Add($" ORD_TOLERANCIA_MAIS = @ORD_TOLERANCIA_MAIS ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_TOLERANCIA_MENOSQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_TOLERANCIA_MENOS"] = value; //06
                      whereClauses.Add($" ORD_TOLERANCIA_MENOS = @ORD_TOLERANCIA_MENOS ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByHASH_KEYQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["HASH_KEY"] = value; //06
                      whereClauses.Add($" HASH_KEY = @HASH_KEY ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_INICIO_JANELA_EMBARQUEQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_INICIO_JANELA_EMBARQUE"] = value; //06
                      whereClauses.Add($" ORD_INICIO_JANELA_EMBARQUE = @ORD_INICIO_JANELA_EMBARQUE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_FIM_JANELA_EMBARQUEQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_FIM_JANELA_EMBARQUE"] = value; //06
                      whereClauses.Add($" ORD_FIM_JANELA_EMBARQUE = @ORD_FIM_JANELA_EMBARQUE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_EMBARQUE_ALVOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_EMBARQUE_ALVO"] = value; //06
                      whereClauses.Add($" ORD_EMBARQUE_ALVO = @ORD_EMBARQUE_ALVO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_INICIO_GRUPO_PRODUTIVOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_INICIO_GRUPO_PRODUTIVO"] = value; //06
                      whereClauses.Add($" ORD_INICIO_GRUPO_PRODUTIVO = @ORD_INICIO_GRUPO_PRODUTIVO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_FIM_GRUPO_PRODUTIVOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_FIM_GRUPO_PRODUTIVO"] = value; //06
                      whereClauses.Add($" ORD_FIM_GRUPO_PRODUTIVO = @ORD_FIM_GRUPO_PRODUTIVO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_PESO_UNITARIOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_PESO_UNITARIO"] = value; //06
                      whereClauses.Add($" ORD_PESO_UNITARIO = @ORD_PESO_UNITARIO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_PESO_UNITARIO_BRUTOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_PESO_UNITARIO_BRUTO"] = value; //06
                      whereClauses.Add($" ORD_PESO_UNITARIO_BRUTO = @ORD_PESO_UNITARIO_BRUTO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_M2_UNITARIOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_M2_UNITARIO"] = value; //06
                      whereClauses.Add($" ORD_M2_UNITARIO = @ORD_M2_UNITARIO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_MITQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_MIT"] = value; //06
                      whereClauses.Add($" ORD_MIT = @ORD_MIT ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCAR_TIPO_CARREGAMENTOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_TIPO_CARREGAMENTO"] = value; //06
                      whereClauses.Add($" CAR_TIPO_CARREGAMENTO = @CAR_TIPO_CARREGAMENTO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_STATUSQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_STATUS"] = value; //06
                      whereClauses.Add($" ORD_STATUS = @ORD_STATUS ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_TIPO_FRETEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_TIPO_FRETE"] = value; //06
                      whereClauses.Add($" ORD_TIPO_FRETE = @ORD_TIPO_FRETE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_ENDERECO_ENTREGAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_ENDERECO_ENTREGA"] = value; //06
                      whereClauses.Add($" ORD_ENDERECO_ENTREGA = @ORD_ENDERECO_ENTREGA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_BAIRRO_ENTREGAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_BAIRRO_ENTREGA"] = value; //06
                      whereClauses.Add($" ORD_BAIRRO_ENTREGA = @ORD_BAIRRO_ENTREGA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByUF_ID_ENTREGAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["UF_ID_ENTREGA"] = value; //06
                      whereClauses.Add($" UF_ID_ENTREGA = @UF_ID_ENTREGA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_CEP_ENTREGAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_CEP_ENTREGA"] = value; //06
                      whereClauses.Add($" ORD_CEP_ENTREGA = @ORD_CEP_ENTREGA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMUN_ID_ENTREGAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MUN_ID_ENTREGA"] = value; //06
                      whereClauses.Add($" MUN_ID_ENTREGA = @MUN_ID_ENTREGA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_REGIAO_ENTREGAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_REGIAO_ENTREGA"] = value; //06
                      whereClauses.Add($" ORD_REGIAO_ENTREGA = @ORD_REGIAO_ENTREGA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_LARGURAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_LARGURA"] = value; //06
                      whereClauses.Add($" ORD_LARGURA = @ORD_LARGURA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_COMPRIMENTOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_COMPRIMENTO"] = value; //06
                      whereClauses.Add($" ORD_COMPRIMENTO = @ORD_COMPRIMENTO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_GRAMATURAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_GRAMATURA"] = value; //06
                      whereClauses.Add($" ORD_GRAMATURA = @ORD_GRAMATURA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRP_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_ID"] = value; //06
                      whereClauses.Add($" GRP_ID = @GRP_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_ID_INTEGRACAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_ID_INTEGRACAO"] = value; //06
                      whereClauses.Add($" ORD_ID_INTEGRACAO = @ORD_ID_INTEGRACAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_OBSERVACAO_OTIMIZADORQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_OBSERVACAO_OTIMIZADOR"] = value; //06
                      whereClauses.Add($" ORD_OBSERVACAO_OTIMIZADOR = @ORD_OBSERVACAO_OTIMIZADOR ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_COR_FILAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_COR_FILA"] = value; //06
                      whereClauses.Add($" ORD_COR_FILA = @ORD_COR_FILA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_PED_CLIQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_PED_CLI"] = value; //06
                      whereClauses.Add($" ORD_PED_CLI = @ORD_PED_CLI ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_OP_INTEGRACAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_OP_INTEGRACAO"] = value; //06
                      whereClauses.Add($" ORD_OP_INTEGRACAO = @ORD_OP_INTEGRACAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_LOTE_PILOTOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_LOTE_PILOTO"] = value; //06
                      whereClauses.Add($" ORD_LOTE_PILOTO = @ORD_LOTE_PILOTO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_PRIORIDADEQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_PRIORIDADE"] = value; //06
                      whereClauses.Add($" ORD_PRIORIDADE = @ORD_PRIORIDADE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_EMISSAOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_EMISSAO"] = value; //06
                      whereClauses.Add($" ORD_EMISSAO = @ORD_EMISSAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByREP_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["REP_ID"] = value; //06
                      whereClauses.Add($" REP_ID = @REP_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_RESINAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_RESINA"] = value; //06
                      whereClauses.Add($" ORD_RESINA = @ORD_RESINA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_ENDURECEDOR_MIOLOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_ENDURECEDOR_MIOLO"] = value; //06
                      whereClauses.Add($" ORD_ENDURECEDOR_MIOLO = @ORD_ENDURECEDOR_MIOLO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_ID_INTEGRACAO_ERPQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ID_INTEGRACAO_ERP"] = value; //06
                      whereClauses.Add($" PRO_ID_INTEGRACAO_ERP = @PRO_ID_INTEGRACAO_ERP ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_VINCOS_ONDULADEIRAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_VINCOS_ONDULADEIRA"] = value; //06
                      whereClauses.Add($" ORD_VINCOS_ONDULADEIRA = @ORD_VINCOS_ONDULADEIRA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_ERP_CUSTOS_FIXOSQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_ERP_CUSTOS_FIXOS"] = value; //06
                      whereClauses.Add($" ORD_ERP_CUSTOS_FIXOS = @ORD_ERP_CUSTOS_FIXOS ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_ERP_CUSTOS_VARIAVEISQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_ERP_CUSTOS_VARIAVEIS"] = value; //06
                      whereClauses.Add($" ORD_ERP_CUSTOS_VARIAVEIS = @ORD_ERP_CUSTOS_VARIAVEIS ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_ERP_DESPESAS_VAR_VENDAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_ERP_DESPESAS_VAR_VENDA"] = value; //06
                      whereClauses.Add($" ORD_ERP_DESPESAS_VAR_VENDA = @ORD_ERP_DESPESAS_VAR_VENDA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_ERP_IMPOSTOSQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_ERP_IMPOSTOS"] = value; //06
                      whereClauses.Add($" ORD_ERP_IMPOSTOS = @ORD_ERP_IMPOSTOS ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_STATUS_PLANEJAMENTOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_STATUS_PLANEJAMENTO"] = value; //06
                      whereClauses.Add($" ORD_STATUS_PLANEJAMENTO = @ORD_STATUS_PLANEJAMENTO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_TOLERANCIA_DIMENSAO_CHAPA_DEQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_TOLERANCIA_DIMENSAO_CHAPA_DE"] = value; //06
                      whereClauses.Add($" ORD_TOLERANCIA_DIMENSAO_CHAPA_DE = @ORD_TOLERANCIA_DIMENSAO_CHAPA_DE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_TOLERANCIA_DIMENSAO_CHAPA_ATEQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE"] = value; //06
                      whereClauses.Add($" ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE = @ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_PROMOVE_DEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_PROMOVE_DE"] = value; //06
                      whereClauses.Add($" ORD_PROMOVE_DE = @ORD_PROMOVE_DE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_PROMOVE_ATEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_PROMOVE_ATE"] = value; //06
                      whereClauses.Add($" ORD_PROMOVE_ATE = @ORD_PROMOVE_ATE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_TRAVA_COMPOSICAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_TRAVA_COMPOSICAO"] = value; //06
                      whereClauses.Add($" ORD_TRAVA_COMPOSICAO = @ORD_TRAVA_COMPOSICAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_TRAVA_RESINAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_TRAVA_RESINA"] = value; //06
                      whereClauses.Add($" ORD_TRAVA_RESINA = @ORD_TRAVA_RESINA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_PROMOVE_RESINAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_PROMOVE_RESINA"] = value; //06
                      whereClauses.Add($" ORD_PROMOVE_RESINA = @ORD_PROMOVE_RESINA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_LATITUDE_ENTREGAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_LATITUDE_ENTREGA"] = value; //06
                      whereClauses.Add($" ORD_LATITUDE_ENTREGA = @ORD_LATITUDE_ENTREGA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_LONGITUDE_ENTREGAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_LONGITUDE_ENTREGA"] = value; //06
                      whereClauses.Add($" ORD_LONGITUDE_ENTREGA = @ORD_LONGITUDE_ENTREGA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByOCO_ID_CANCELAMENTOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["OCO_ID_CANCELAMENTO"] = value; //06
                      whereClauses.Add($" OCO_ID_CANCELAMENTO = @OCO_ID_CANCELAMENTO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTMP_TIPO_CARGAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TMP_TIPO_CARGA"] = value; //06
                      whereClauses.Add($" TMP_TIPO_CARGA = @TMP_TIPO_CARGA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_ID_PALETEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ID_PALETE"] = value; //06
                      whereClauses.Add($" PRO_ID_PALETE = @PRO_ID_PALETE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_ID_TAMPOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ID_TAMPO"] = value; //06
                      whereClauses.Add($" PRO_ID_TAMPO = @PRO_ID_TAMPO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_PILHAS_POR_PALETEQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_PILHAS_POR_PALETE"] = value; //06
                      whereClauses.Add($" ORD_PILHAS_POR_PALETE = @ORD_PILHAS_POR_PALETE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_CHAPAS_POR_PILHAQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_CHAPAS_POR_PILHA"] = value; //06
                      whereClauses.Add($" ORD_CHAPAS_POR_PILHA = @ORD_CHAPAS_POR_PILHA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_DATA_CANCELAMENTOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_DATA_CANCELAMENTO"] = value; //06
                      whereClauses.Add($" ORD_DATA_CANCELAMENTO = @ORD_DATA_CANCELAMENTO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_STATUS_ESTATISTICAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_STATUS_ESTATISTICA"] = value; //06
                      whereClauses.Add($" ORD_STATUS_ESTATISTICA = @ORD_STATUS_ESTATISTICA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByORD_DATA_ESTATISTICAQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_DATA_ESTATISTICA"] = value; //06
                      whereClauses.Add($" ORD_DATA_ESTATISTICA = @ORD_DATA_ESTATISTICA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByOCO_ID_MOTIVO_ATRASOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["OCO_ID_MOTIVO_ATRASO"] = value; //06
                      whereClauses.Add($" OCO_ID_MOTIVO_ATRASO = @OCO_ID_MOTIVO_ATRASO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByOTK_VERSSAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["OTK_VERSSAO"] = value; //06
                      whereClauses.Add($" OTK_VERSSAO = @OTK_VERSSAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTenantIDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TenantID"] = value; //06
                      whereClauses.Add($" TenantID = @TenantID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByDeletedQuery(bool value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Deleted"] = value; //06
                      whereClauses.Add($" Deleted = @Deleted ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByChangedQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Changed"] = value; //06
                      whereClauses.Add($" Changed = @Changed ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByUserIdQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID, ORD_ID_RESERVA, ORD_ID_CONJUNTO, PRO_ID, PRO_ID_CONJUNTO, CLI_ID, ORD_PRECO_UNITARIO, ORD_QUANTIDADE, ORD_DATA_ENTREGA_DE, ORD_DATA_ENTREGA_ATE, ORD_TIPO, ORD_TOLERANCIA_MAIS, ORD_TOLERANCIA_MENOS, HASH_KEY, ORD_INICIO_JANELA_EMBARQUE, ORD_FIM_JANELA_EMBARQUE, ORD_EMBARQUE_ALVO, ORD_INICIO_GRUPO_PRODUTIVO, ORD_FIM_GRUPO_PRODUTIVO, ORD_PESO_UNITARIO, ORD_PESO_UNITARIO_BRUTO, ORD_M2_UNITARIO, ORD_MIT, CAR_TIPO_CARREGAMENTO, ORD_STATUS, ORD_TIPO_FRETE, ORD_ENDERECO_ENTREGA, ORD_BAIRRO_ENTREGA, UF_ID_ENTREGA, ORD_CEP_ENTREGA, MUN_ID_ENTREGA, ORD_REGIAO_ENTREGA, ORD_LARGURA, ORD_COMPRIMENTO, ORD_GRAMATURA, GRP_ID, ORD_ID_INTEGRACAO, ORD_OBSERVACAO_OTIMIZADOR, ORD_COR_FILA, ORD_PED_CLI, ORD_OP_INTEGRACAO, ORD_LOTE_PILOTO, ORD_PRIORIDADE, ORD_EMISSAO, REP_ID, ORD_RESINA, ORD_ENDURECEDOR_MIOLO, PRO_ID_INTEGRACAO_ERP, ORD_VINCOS_ONDULADEIRA, ORD_ERP_CUSTOS_FIXOS, ORD_ERP_CUSTOS_VARIAVEIS, ORD_ERP_DESPESAS_VAR_VENDA, ORD_ERP_IMPOSTOS, ORD_STATUS_PLANEJAMENTO, ORD_TOLERANCIA_DIMENSAO_CHAPA_DE, ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE, ORD_PROMOVE_DE, ORD_PROMOVE_ATE, ORD_TRAVA_COMPOSICAO, ORD_TRAVA_RESINA, ORD_PROMOVE_RESINA, ORD_LATITUDE_ENTREGA, ORD_LONGITUDE_ENTREGA, OCO_ID_CANCELAMENTO, TMP_TIPO_CARGA, PRO_ID_PALETE, PRO_ID_TAMPO, ORD_PILHAS_POR_PALETE, ORD_CHAPAS_POR_PILHA, ORD_DATA_CANCELAMENTO, ORD_STATUS_ESTATISTICA, ORD_DATA_ESTATISTICA, OCO_ID_MOTIVO_ATRASO, OTK_VERSSAO, TenantID, Deleted, Changed, UserId FROM Order ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["UserId"] = value; //06
                      whereClauses.Add($" UserId = @UserId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration