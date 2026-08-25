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
    public class RoteiroPedidoQueryRead : QueryBase, IRoteiroPedidoQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public RoteiroPedidoQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel RoteiroPedidoQuery(Command.Read.RoteiroPedidoReadCommand Command )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select ORD_ID AS PedidoId, MAQ_ID AS MaquinaId, PRO_ID AS ProdutoId, ROT_SEQ_TRANFORMACAO AS SequenciaTransformacao, STATUS_CADASTRO AS StatusCadastro, MAQ_TIPO_PLANEJAMENTO AS TipoPlanejamento, CAL_ID AS CalendarioId, HIERARQUIA_SEQ_TRANSFORMACAO AS HierarquiaSequenciaTransformacao, ROT_VA_PARA_SEQ_TRANSFORMACAO AS ProximaSequenciaTransformacao, ROT_PERFORMANCE AS Performance, ROT_TEMPO_SETUP AS TempoSetup, ROT_TEMPO_SETUP_AJUSTE AS TempoSetupAjuste, ROT_PECAS_POR_PULSO AS PecasPorPulso, ROT_PRIORIDADE_INFORMADA AS PrioridadeInformada, ROT_STATUS AS Status, ROT_OPERACOES AS Operacoes, ROT_EXCECAO_OPERACOES AS ExcecaoOperacoes, ROT_LINHA_DIRETA AS LinhaDireta, AVALIA_CUSTO AS AvaliaCusto, PERCENTUAL_INICIO_PASSO_ANTERIOR AS PercentualInicioPassoAnterior, MAQ_LARGURA_UTIL AS MaquinaLarguraUtil, GRP_TIPO AS GrupoTipo, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO AS GrupoPerformanceMetroLinear from V_ROTEIRO_PEDIDO ";
if (!string.IsNullOrEmpty(Command.PedidoId)) dict["PedidoId"] = $"%{Command.PedidoId}%";
if (!string.IsNullOrEmpty(Command.PedidoId)) whereClauses.Add($"ORD_ID like @PedidoId");
if (!string.IsNullOrEmpty(Command.MaquinaId)) dict["MaquinaId"] = $"%{Command.MaquinaId}%";
if (!string.IsNullOrEmpty(Command.MaquinaId)) whereClauses.Add($"MAQ_ID like @MaquinaId");
if (!string.IsNullOrEmpty(Command.ProdutoId)) dict["ProdutoId"] = $"%{Command.ProdutoId}%";
if (!string.IsNullOrEmpty(Command.ProdutoId)) whereClauses.Add($"PRO_ID like @ProdutoId");
if (Command.SequenciaTransformacao.HasValue) dict["SequenciaTransformacao"] = Command.SequenciaTransformacao.Value;
if (Command.SequenciaTransformacao.HasValue) whereClauses.Add($"ROT_SEQ_TRANFORMACAO = @SequenciaTransformacao");
if (!string.IsNullOrEmpty(Command.StatusCadastro)) dict["StatusCadastro"] = $"%{Command.StatusCadastro}%";
if (!string.IsNullOrEmpty(Command.StatusCadastro)) whereClauses.Add($"STATUS_CADASTRO like @StatusCadastro");
if (!string.IsNullOrEmpty(Command.TipoPlanejamento)) dict["TipoPlanejamento"] = $"%{Command.TipoPlanejamento}%";
if (!string.IsNullOrEmpty(Command.TipoPlanejamento)) whereClauses.Add($"MAQ_TIPO_PLANEJAMENTO like @TipoPlanejamento");
if (Command.CalendarioId.HasValue) dict["CalendarioId"] = Command.CalendarioId.Value;
if (Command.CalendarioId.HasValue) whereClauses.Add($"CAL_ID = @CalendarioId");
if (Command.ProximaSequenciaTransformacao.HasValue) dict["ProximaSequenciaTransformacao"] = Command.ProximaSequenciaTransformacao.Value;
if (Command.ProximaSequenciaTransformacao.HasValue) whereClauses.Add($"ROT_VA_PARA_SEQ_TRANSFORMACAO = @ProximaSequenciaTransformacao");
if (!string.IsNullOrEmpty(Command.Status)) dict["Status"] = $"%{Command.Status}%";
if (!string.IsNullOrEmpty(Command.Status)) whereClauses.Add($"ROT_STATUS like @Status");
if (!string.IsNullOrEmpty(Command.Operacoes)) dict["Operacoes"] = $"%{Command.Operacoes}%";
if (!string.IsNullOrEmpty(Command.Operacoes)) whereClauses.Add($"ROT_OPERACOES like @Operacoes");
if (!string.IsNullOrEmpty(Command.ExcecaoOperacoes)) dict["ExcecaoOperacoes"] = $"%{Command.ExcecaoOperacoes}%";
if (!string.IsNullOrEmpty(Command.ExcecaoOperacoes)) whereClauses.Add($"ROT_EXCECAO_OPERACOES like @ExcecaoOperacoes");
if (!string.IsNullOrEmpty(Command.LinhaDireta)) dict["LinhaDireta"] = $"%{Command.LinhaDireta}%";
if (!string.IsNullOrEmpty(Command.LinhaDireta)) whereClauses.Add($"ROT_LINHA_DIRETA like @LinhaDireta");
if (Command.AvaliaCusto.HasValue) dict["AvaliaCusto"] = Command.AvaliaCusto.Value;
if (Command.AvaliaCusto.HasValue) whereClauses.Add($"AVALIA_CUSTO = @AvaliaCusto");
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
        public QueryModel RoteiroPedidoPedidoIdQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select ORD_ID AS PedidoId from V_CONSULTA_PEDIDO ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["PedidoId"] = numero; //01
                      whereClauses.Add($" ORD_ID = @PedidoId");//01 
                 }
                 else 
                 {
                      dict["PedidoId"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" ORD_ID like @PedidoId ");//02
                 }
           }
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel RoteiroPedidoMaquinaIdQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select Id, Descricao from Maquina ";
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
                      dict["Descricao"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" Descricao like @Descricao ");//02
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
        public QueryModel RoteiroPedidoProdutoIdQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select Id, Descricao from Produto ";
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
                      dict["Descricao"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" Descricao like @Descricao ");//02
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
        public QueryModel ExistsByPedidoIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM V_ROTEIRO_PEDIDO ";
                      dict["PedidoId"] = value; //04
                      whereClauses.Add($" ORD_ID = @PedidoId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMaquinaIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM V_ROTEIRO_PEDIDO ";
                      dict["MaquinaId"] = value; //04
                      whereClauses.Add($" MAQ_ID = @MaquinaId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByProdutoIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM V_ROTEIRO_PEDIDO ";
                      dict["ProdutoId"] = value; //04
                      whereClauses.Add($" PRO_ID = @ProdutoId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsBySequenciaTransformacaoQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM V_ROTEIRO_PEDIDO ";
                      dict["SequenciaTransformacao"] = value; //04
                      whereClauses.Add($" ROT_SEQ_TRANFORMACAO = @SequenciaTransformacao ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByStatusCadastroQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM V_ROTEIRO_PEDIDO ";
                      dict["StatusCadastro"] = value; //04
                      whereClauses.Add($" STATUS_CADASTRO = @StatusCadastro ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTipoPlanejamentoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM V_ROTEIRO_PEDIDO ";
                      dict["TipoPlanejamento"] = value; //04
                      whereClauses.Add($" MAQ_TIPO_PLANEJAMENTO = @TipoPlanejamento ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCalendarioIdQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM V_ROTEIRO_PEDIDO ";
                      dict["CalendarioId"] = value; //04
                      whereClauses.Add($" CAL_ID = @CalendarioId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByHierarquiaSequenciaTransformacaoQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM V_ROTEIRO_PEDIDO ";
                      dict["HierarquiaSequenciaTransformacao"] = value; //04
                      whereClauses.Add($" HIERARQUIA_SEQ_TRANSFORMACAO = @HierarquiaSequenciaTransformacao ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByProximaSequenciaTransformacaoQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM V_ROTEIRO_PEDIDO ";
                      dict["ProximaSequenciaTransformacao"] = value; //04
                      whereClauses.Add($" ROT_VA_PARA_SEQ_TRANSFORMACAO = @ProximaSequenciaTransformacao ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPerformanceQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM V_ROTEIRO_PEDIDO ";
                      dict["Performance"] = value; //04
                      whereClauses.Add($" ROT_PERFORMANCE = @Performance ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTempoSetupQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM V_ROTEIRO_PEDIDO ";
                      dict["TempoSetup"] = value; //04
                      whereClauses.Add($" ROT_TEMPO_SETUP = @TempoSetup ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTempoSetupAjusteQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM V_ROTEIRO_PEDIDO ";
                      dict["TempoSetupAjuste"] = value; //04
                      whereClauses.Add($" ROT_TEMPO_SETUP_AJUSTE = @TempoSetupAjuste ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPecasPorPulsoQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM V_ROTEIRO_PEDIDO ";
                      dict["PecasPorPulso"] = value; //04
                      whereClauses.Add($" ROT_PECAS_POR_PULSO = @PecasPorPulso ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPrioridadeInformadaQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM V_ROTEIRO_PEDIDO ";
                      dict["PrioridadeInformada"] = value; //04
                      whereClauses.Add($" ROT_PRIORIDADE_INFORMADA = @PrioridadeInformada ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByStatusQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM V_ROTEIRO_PEDIDO ";
                      dict["Status"] = value; //04
                      whereClauses.Add($" ROT_STATUS = @Status ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByOperacoesQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM V_ROTEIRO_PEDIDO ";
                      dict["Operacoes"] = value; //04
                      whereClauses.Add($" ROT_OPERACOES = @Operacoes ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByExcecaoOperacoesQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM V_ROTEIRO_PEDIDO ";
                      dict["ExcecaoOperacoes"] = value; //04
                      whereClauses.Add($" ROT_EXCECAO_OPERACOES = @ExcecaoOperacoes ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByLinhaDiretaQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM V_ROTEIRO_PEDIDO ";
                      dict["LinhaDireta"] = value; //04
                      whereClauses.Add($" ROT_LINHA_DIRETA = @LinhaDireta ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByAvaliaCustoQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM V_ROTEIRO_PEDIDO ";
                      dict["AvaliaCusto"] = value; //04
                      whereClauses.Add($" AVALIA_CUSTO = @AvaliaCusto ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPercentualInicioPassoAnteriorQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM V_ROTEIRO_PEDIDO ";
                      dict["PercentualInicioPassoAnterior"] = value; //04
                      whereClauses.Add($" PERCENTUAL_INICIO_PASSO_ANTERIOR = @PercentualInicioPassoAnterior ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMaquinaLarguraUtilQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM V_ROTEIRO_PEDIDO ";
                      dict["MaquinaLarguraUtil"] = value; //04
                      whereClauses.Add($" MAQ_LARGURA_UTIL = @MaquinaLarguraUtil ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGrupoTipoQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM V_ROTEIRO_PEDIDO ";
                      dict["GrupoTipo"] = value; //04
                      whereClauses.Add($" GRP_TIPO = @GrupoTipo ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGrupoPerformanceMetroLinearQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM V_ROTEIRO_PEDIDO ";
                      dict["GrupoPerformanceMetroLinear"] = value; //04
                      whereClauses.Add($" GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO = @GrupoPerformanceMetroLinear ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPedidoIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID AS PedidoId, MAQ_ID AS MaquinaId, PRO_ID AS ProdutoId, ROT_SEQ_TRANFORMACAO AS SequenciaTransformacao, STATUS_CADASTRO AS StatusCadastro, MAQ_TIPO_PLANEJAMENTO AS TipoPlanejamento, CAL_ID AS CalendarioId, HIERARQUIA_SEQ_TRANSFORMACAO AS HierarquiaSequenciaTransformacao, ROT_VA_PARA_SEQ_TRANSFORMACAO AS ProximaSequenciaTransformacao, ROT_PERFORMANCE AS Performance, ROT_TEMPO_SETUP AS TempoSetup, ROT_TEMPO_SETUP_AJUSTE AS TempoSetupAjuste, ROT_PECAS_POR_PULSO AS PecasPorPulso, ROT_PRIORIDADE_INFORMADA AS PrioridadeInformada, ROT_STATUS AS Status, ROT_OPERACOES AS Operacoes, ROT_EXCECAO_OPERACOES AS ExcecaoOperacoes, ROT_LINHA_DIRETA AS LinhaDireta, AVALIA_CUSTO AS AvaliaCusto, PERCENTUAL_INICIO_PASSO_ANTERIOR AS PercentualInicioPassoAnterior, MAQ_LARGURA_UTIL AS MaquinaLarguraUtil, GRP_TIPO AS GrupoTipo, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO AS GrupoPerformanceMetroLinear FROM V_ROTEIRO_PEDIDO ";
                      dict["PedidoId"] = value; //06
                      whereClauses.Add($" ORD_ID = @PedidoId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMaquinaIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID AS PedidoId, MAQ_ID AS MaquinaId, PRO_ID AS ProdutoId, ROT_SEQ_TRANFORMACAO AS SequenciaTransformacao, STATUS_CADASTRO AS StatusCadastro, MAQ_TIPO_PLANEJAMENTO AS TipoPlanejamento, CAL_ID AS CalendarioId, HIERARQUIA_SEQ_TRANSFORMACAO AS HierarquiaSequenciaTransformacao, ROT_VA_PARA_SEQ_TRANSFORMACAO AS ProximaSequenciaTransformacao, ROT_PERFORMANCE AS Performance, ROT_TEMPO_SETUP AS TempoSetup, ROT_TEMPO_SETUP_AJUSTE AS TempoSetupAjuste, ROT_PECAS_POR_PULSO AS PecasPorPulso, ROT_PRIORIDADE_INFORMADA AS PrioridadeInformada, ROT_STATUS AS Status, ROT_OPERACOES AS Operacoes, ROT_EXCECAO_OPERACOES AS ExcecaoOperacoes, ROT_LINHA_DIRETA AS LinhaDireta, AVALIA_CUSTO AS AvaliaCusto, PERCENTUAL_INICIO_PASSO_ANTERIOR AS PercentualInicioPassoAnterior, MAQ_LARGURA_UTIL AS MaquinaLarguraUtil, GRP_TIPO AS GrupoTipo, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO AS GrupoPerformanceMetroLinear FROM V_ROTEIRO_PEDIDO ";
                      dict["MaquinaId"] = value; //06
                      whereClauses.Add($" MAQ_ID = @MaquinaId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByProdutoIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID AS PedidoId, MAQ_ID AS MaquinaId, PRO_ID AS ProdutoId, ROT_SEQ_TRANFORMACAO AS SequenciaTransformacao, STATUS_CADASTRO AS StatusCadastro, MAQ_TIPO_PLANEJAMENTO AS TipoPlanejamento, CAL_ID AS CalendarioId, HIERARQUIA_SEQ_TRANSFORMACAO AS HierarquiaSequenciaTransformacao, ROT_VA_PARA_SEQ_TRANSFORMACAO AS ProximaSequenciaTransformacao, ROT_PERFORMANCE AS Performance, ROT_TEMPO_SETUP AS TempoSetup, ROT_TEMPO_SETUP_AJUSTE AS TempoSetupAjuste, ROT_PECAS_POR_PULSO AS PecasPorPulso, ROT_PRIORIDADE_INFORMADA AS PrioridadeInformada, ROT_STATUS AS Status, ROT_OPERACOES AS Operacoes, ROT_EXCECAO_OPERACOES AS ExcecaoOperacoes, ROT_LINHA_DIRETA AS LinhaDireta, AVALIA_CUSTO AS AvaliaCusto, PERCENTUAL_INICIO_PASSO_ANTERIOR AS PercentualInicioPassoAnterior, MAQ_LARGURA_UTIL AS MaquinaLarguraUtil, GRP_TIPO AS GrupoTipo, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO AS GrupoPerformanceMetroLinear FROM V_ROTEIRO_PEDIDO ";
                      dict["ProdutoId"] = value; //06
                      whereClauses.Add($" PRO_ID = @ProdutoId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstBySequenciaTransformacaoQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID AS PedidoId, MAQ_ID AS MaquinaId, PRO_ID AS ProdutoId, ROT_SEQ_TRANFORMACAO AS SequenciaTransformacao, STATUS_CADASTRO AS StatusCadastro, MAQ_TIPO_PLANEJAMENTO AS TipoPlanejamento, CAL_ID AS CalendarioId, HIERARQUIA_SEQ_TRANSFORMACAO AS HierarquiaSequenciaTransformacao, ROT_VA_PARA_SEQ_TRANSFORMACAO AS ProximaSequenciaTransformacao, ROT_PERFORMANCE AS Performance, ROT_TEMPO_SETUP AS TempoSetup, ROT_TEMPO_SETUP_AJUSTE AS TempoSetupAjuste, ROT_PECAS_POR_PULSO AS PecasPorPulso, ROT_PRIORIDADE_INFORMADA AS PrioridadeInformada, ROT_STATUS AS Status, ROT_OPERACOES AS Operacoes, ROT_EXCECAO_OPERACOES AS ExcecaoOperacoes, ROT_LINHA_DIRETA AS LinhaDireta, AVALIA_CUSTO AS AvaliaCusto, PERCENTUAL_INICIO_PASSO_ANTERIOR AS PercentualInicioPassoAnterior, MAQ_LARGURA_UTIL AS MaquinaLarguraUtil, GRP_TIPO AS GrupoTipo, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO AS GrupoPerformanceMetroLinear FROM V_ROTEIRO_PEDIDO ";
                      dict["SequenciaTransformacao"] = value; //06
                      whereClauses.Add($" ROT_SEQ_TRANFORMACAO = @SequenciaTransformacao ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByStatusCadastroQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID AS PedidoId, MAQ_ID AS MaquinaId, PRO_ID AS ProdutoId, ROT_SEQ_TRANFORMACAO AS SequenciaTransformacao, STATUS_CADASTRO AS StatusCadastro, MAQ_TIPO_PLANEJAMENTO AS TipoPlanejamento, CAL_ID AS CalendarioId, HIERARQUIA_SEQ_TRANSFORMACAO AS HierarquiaSequenciaTransformacao, ROT_VA_PARA_SEQ_TRANSFORMACAO AS ProximaSequenciaTransformacao, ROT_PERFORMANCE AS Performance, ROT_TEMPO_SETUP AS TempoSetup, ROT_TEMPO_SETUP_AJUSTE AS TempoSetupAjuste, ROT_PECAS_POR_PULSO AS PecasPorPulso, ROT_PRIORIDADE_INFORMADA AS PrioridadeInformada, ROT_STATUS AS Status, ROT_OPERACOES AS Operacoes, ROT_EXCECAO_OPERACOES AS ExcecaoOperacoes, ROT_LINHA_DIRETA AS LinhaDireta, AVALIA_CUSTO AS AvaliaCusto, PERCENTUAL_INICIO_PASSO_ANTERIOR AS PercentualInicioPassoAnterior, MAQ_LARGURA_UTIL AS MaquinaLarguraUtil, GRP_TIPO AS GrupoTipo, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO AS GrupoPerformanceMetroLinear FROM V_ROTEIRO_PEDIDO ";
                      dict["StatusCadastro"] = value; //06
                      whereClauses.Add($" STATUS_CADASTRO = @StatusCadastro ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTipoPlanejamentoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID AS PedidoId, MAQ_ID AS MaquinaId, PRO_ID AS ProdutoId, ROT_SEQ_TRANFORMACAO AS SequenciaTransformacao, STATUS_CADASTRO AS StatusCadastro, MAQ_TIPO_PLANEJAMENTO AS TipoPlanejamento, CAL_ID AS CalendarioId, HIERARQUIA_SEQ_TRANSFORMACAO AS HierarquiaSequenciaTransformacao, ROT_VA_PARA_SEQ_TRANSFORMACAO AS ProximaSequenciaTransformacao, ROT_PERFORMANCE AS Performance, ROT_TEMPO_SETUP AS TempoSetup, ROT_TEMPO_SETUP_AJUSTE AS TempoSetupAjuste, ROT_PECAS_POR_PULSO AS PecasPorPulso, ROT_PRIORIDADE_INFORMADA AS PrioridadeInformada, ROT_STATUS AS Status, ROT_OPERACOES AS Operacoes, ROT_EXCECAO_OPERACOES AS ExcecaoOperacoes, ROT_LINHA_DIRETA AS LinhaDireta, AVALIA_CUSTO AS AvaliaCusto, PERCENTUAL_INICIO_PASSO_ANTERIOR AS PercentualInicioPassoAnterior, MAQ_LARGURA_UTIL AS MaquinaLarguraUtil, GRP_TIPO AS GrupoTipo, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO AS GrupoPerformanceMetroLinear FROM V_ROTEIRO_PEDIDO ";
                      dict["TipoPlanejamento"] = value; //06
                      whereClauses.Add($" MAQ_TIPO_PLANEJAMENTO = @TipoPlanejamento ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCalendarioIdQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID AS PedidoId, MAQ_ID AS MaquinaId, PRO_ID AS ProdutoId, ROT_SEQ_TRANFORMACAO AS SequenciaTransformacao, STATUS_CADASTRO AS StatusCadastro, MAQ_TIPO_PLANEJAMENTO AS TipoPlanejamento, CAL_ID AS CalendarioId, HIERARQUIA_SEQ_TRANSFORMACAO AS HierarquiaSequenciaTransformacao, ROT_VA_PARA_SEQ_TRANSFORMACAO AS ProximaSequenciaTransformacao, ROT_PERFORMANCE AS Performance, ROT_TEMPO_SETUP AS TempoSetup, ROT_TEMPO_SETUP_AJUSTE AS TempoSetupAjuste, ROT_PECAS_POR_PULSO AS PecasPorPulso, ROT_PRIORIDADE_INFORMADA AS PrioridadeInformada, ROT_STATUS AS Status, ROT_OPERACOES AS Operacoes, ROT_EXCECAO_OPERACOES AS ExcecaoOperacoes, ROT_LINHA_DIRETA AS LinhaDireta, AVALIA_CUSTO AS AvaliaCusto, PERCENTUAL_INICIO_PASSO_ANTERIOR AS PercentualInicioPassoAnterior, MAQ_LARGURA_UTIL AS MaquinaLarguraUtil, GRP_TIPO AS GrupoTipo, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO AS GrupoPerformanceMetroLinear FROM V_ROTEIRO_PEDIDO ";
                      dict["CalendarioId"] = value; //06
                      whereClauses.Add($" CAL_ID = @CalendarioId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByHierarquiaSequenciaTransformacaoQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID AS PedidoId, MAQ_ID AS MaquinaId, PRO_ID AS ProdutoId, ROT_SEQ_TRANFORMACAO AS SequenciaTransformacao, STATUS_CADASTRO AS StatusCadastro, MAQ_TIPO_PLANEJAMENTO AS TipoPlanejamento, CAL_ID AS CalendarioId, HIERARQUIA_SEQ_TRANSFORMACAO AS HierarquiaSequenciaTransformacao, ROT_VA_PARA_SEQ_TRANSFORMACAO AS ProximaSequenciaTransformacao, ROT_PERFORMANCE AS Performance, ROT_TEMPO_SETUP AS TempoSetup, ROT_TEMPO_SETUP_AJUSTE AS TempoSetupAjuste, ROT_PECAS_POR_PULSO AS PecasPorPulso, ROT_PRIORIDADE_INFORMADA AS PrioridadeInformada, ROT_STATUS AS Status, ROT_OPERACOES AS Operacoes, ROT_EXCECAO_OPERACOES AS ExcecaoOperacoes, ROT_LINHA_DIRETA AS LinhaDireta, AVALIA_CUSTO AS AvaliaCusto, PERCENTUAL_INICIO_PASSO_ANTERIOR AS PercentualInicioPassoAnterior, MAQ_LARGURA_UTIL AS MaquinaLarguraUtil, GRP_TIPO AS GrupoTipo, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO AS GrupoPerformanceMetroLinear FROM V_ROTEIRO_PEDIDO ";
                      dict["HierarquiaSequenciaTransformacao"] = value; //06
                      whereClauses.Add($" HIERARQUIA_SEQ_TRANSFORMACAO = @HierarquiaSequenciaTransformacao ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByProximaSequenciaTransformacaoQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID AS PedidoId, MAQ_ID AS MaquinaId, PRO_ID AS ProdutoId, ROT_SEQ_TRANFORMACAO AS SequenciaTransformacao, STATUS_CADASTRO AS StatusCadastro, MAQ_TIPO_PLANEJAMENTO AS TipoPlanejamento, CAL_ID AS CalendarioId, HIERARQUIA_SEQ_TRANSFORMACAO AS HierarquiaSequenciaTransformacao, ROT_VA_PARA_SEQ_TRANSFORMACAO AS ProximaSequenciaTransformacao, ROT_PERFORMANCE AS Performance, ROT_TEMPO_SETUP AS TempoSetup, ROT_TEMPO_SETUP_AJUSTE AS TempoSetupAjuste, ROT_PECAS_POR_PULSO AS PecasPorPulso, ROT_PRIORIDADE_INFORMADA AS PrioridadeInformada, ROT_STATUS AS Status, ROT_OPERACOES AS Operacoes, ROT_EXCECAO_OPERACOES AS ExcecaoOperacoes, ROT_LINHA_DIRETA AS LinhaDireta, AVALIA_CUSTO AS AvaliaCusto, PERCENTUAL_INICIO_PASSO_ANTERIOR AS PercentualInicioPassoAnterior, MAQ_LARGURA_UTIL AS MaquinaLarguraUtil, GRP_TIPO AS GrupoTipo, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO AS GrupoPerformanceMetroLinear FROM V_ROTEIRO_PEDIDO ";
                      dict["ProximaSequenciaTransformacao"] = value; //06
                      whereClauses.Add($" ROT_VA_PARA_SEQ_TRANSFORMACAO = @ProximaSequenciaTransformacao ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPerformanceQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID AS PedidoId, MAQ_ID AS MaquinaId, PRO_ID AS ProdutoId, ROT_SEQ_TRANFORMACAO AS SequenciaTransformacao, STATUS_CADASTRO AS StatusCadastro, MAQ_TIPO_PLANEJAMENTO AS TipoPlanejamento, CAL_ID AS CalendarioId, HIERARQUIA_SEQ_TRANSFORMACAO AS HierarquiaSequenciaTransformacao, ROT_VA_PARA_SEQ_TRANSFORMACAO AS ProximaSequenciaTransformacao, ROT_PERFORMANCE AS Performance, ROT_TEMPO_SETUP AS TempoSetup, ROT_TEMPO_SETUP_AJUSTE AS TempoSetupAjuste, ROT_PECAS_POR_PULSO AS PecasPorPulso, ROT_PRIORIDADE_INFORMADA AS PrioridadeInformada, ROT_STATUS AS Status, ROT_OPERACOES AS Operacoes, ROT_EXCECAO_OPERACOES AS ExcecaoOperacoes, ROT_LINHA_DIRETA AS LinhaDireta, AVALIA_CUSTO AS AvaliaCusto, PERCENTUAL_INICIO_PASSO_ANTERIOR AS PercentualInicioPassoAnterior, MAQ_LARGURA_UTIL AS MaquinaLarguraUtil, GRP_TIPO AS GrupoTipo, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO AS GrupoPerformanceMetroLinear FROM V_ROTEIRO_PEDIDO ";
                      dict["Performance"] = value; //06
                      whereClauses.Add($" ROT_PERFORMANCE = @Performance ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTempoSetupQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID AS PedidoId, MAQ_ID AS MaquinaId, PRO_ID AS ProdutoId, ROT_SEQ_TRANFORMACAO AS SequenciaTransformacao, STATUS_CADASTRO AS StatusCadastro, MAQ_TIPO_PLANEJAMENTO AS TipoPlanejamento, CAL_ID AS CalendarioId, HIERARQUIA_SEQ_TRANSFORMACAO AS HierarquiaSequenciaTransformacao, ROT_VA_PARA_SEQ_TRANSFORMACAO AS ProximaSequenciaTransformacao, ROT_PERFORMANCE AS Performance, ROT_TEMPO_SETUP AS TempoSetup, ROT_TEMPO_SETUP_AJUSTE AS TempoSetupAjuste, ROT_PECAS_POR_PULSO AS PecasPorPulso, ROT_PRIORIDADE_INFORMADA AS PrioridadeInformada, ROT_STATUS AS Status, ROT_OPERACOES AS Operacoes, ROT_EXCECAO_OPERACOES AS ExcecaoOperacoes, ROT_LINHA_DIRETA AS LinhaDireta, AVALIA_CUSTO AS AvaliaCusto, PERCENTUAL_INICIO_PASSO_ANTERIOR AS PercentualInicioPassoAnterior, MAQ_LARGURA_UTIL AS MaquinaLarguraUtil, GRP_TIPO AS GrupoTipo, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO AS GrupoPerformanceMetroLinear FROM V_ROTEIRO_PEDIDO ";
                      dict["TempoSetup"] = value; //06
                      whereClauses.Add($" ROT_TEMPO_SETUP = @TempoSetup ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTempoSetupAjusteQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID AS PedidoId, MAQ_ID AS MaquinaId, PRO_ID AS ProdutoId, ROT_SEQ_TRANFORMACAO AS SequenciaTransformacao, STATUS_CADASTRO AS StatusCadastro, MAQ_TIPO_PLANEJAMENTO AS TipoPlanejamento, CAL_ID AS CalendarioId, HIERARQUIA_SEQ_TRANSFORMACAO AS HierarquiaSequenciaTransformacao, ROT_VA_PARA_SEQ_TRANSFORMACAO AS ProximaSequenciaTransformacao, ROT_PERFORMANCE AS Performance, ROT_TEMPO_SETUP AS TempoSetup, ROT_TEMPO_SETUP_AJUSTE AS TempoSetupAjuste, ROT_PECAS_POR_PULSO AS PecasPorPulso, ROT_PRIORIDADE_INFORMADA AS PrioridadeInformada, ROT_STATUS AS Status, ROT_OPERACOES AS Operacoes, ROT_EXCECAO_OPERACOES AS ExcecaoOperacoes, ROT_LINHA_DIRETA AS LinhaDireta, AVALIA_CUSTO AS AvaliaCusto, PERCENTUAL_INICIO_PASSO_ANTERIOR AS PercentualInicioPassoAnterior, MAQ_LARGURA_UTIL AS MaquinaLarguraUtil, GRP_TIPO AS GrupoTipo, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO AS GrupoPerformanceMetroLinear FROM V_ROTEIRO_PEDIDO ";
                      dict["TempoSetupAjuste"] = value; //06
                      whereClauses.Add($" ROT_TEMPO_SETUP_AJUSTE = @TempoSetupAjuste ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPecasPorPulsoQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID AS PedidoId, MAQ_ID AS MaquinaId, PRO_ID AS ProdutoId, ROT_SEQ_TRANFORMACAO AS SequenciaTransformacao, STATUS_CADASTRO AS StatusCadastro, MAQ_TIPO_PLANEJAMENTO AS TipoPlanejamento, CAL_ID AS CalendarioId, HIERARQUIA_SEQ_TRANSFORMACAO AS HierarquiaSequenciaTransformacao, ROT_VA_PARA_SEQ_TRANSFORMACAO AS ProximaSequenciaTransformacao, ROT_PERFORMANCE AS Performance, ROT_TEMPO_SETUP AS TempoSetup, ROT_TEMPO_SETUP_AJUSTE AS TempoSetupAjuste, ROT_PECAS_POR_PULSO AS PecasPorPulso, ROT_PRIORIDADE_INFORMADA AS PrioridadeInformada, ROT_STATUS AS Status, ROT_OPERACOES AS Operacoes, ROT_EXCECAO_OPERACOES AS ExcecaoOperacoes, ROT_LINHA_DIRETA AS LinhaDireta, AVALIA_CUSTO AS AvaliaCusto, PERCENTUAL_INICIO_PASSO_ANTERIOR AS PercentualInicioPassoAnterior, MAQ_LARGURA_UTIL AS MaquinaLarguraUtil, GRP_TIPO AS GrupoTipo, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO AS GrupoPerformanceMetroLinear FROM V_ROTEIRO_PEDIDO ";
                      dict["PecasPorPulso"] = value; //06
                      whereClauses.Add($" ROT_PECAS_POR_PULSO = @PecasPorPulso ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPrioridadeInformadaQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID AS PedidoId, MAQ_ID AS MaquinaId, PRO_ID AS ProdutoId, ROT_SEQ_TRANFORMACAO AS SequenciaTransformacao, STATUS_CADASTRO AS StatusCadastro, MAQ_TIPO_PLANEJAMENTO AS TipoPlanejamento, CAL_ID AS CalendarioId, HIERARQUIA_SEQ_TRANSFORMACAO AS HierarquiaSequenciaTransformacao, ROT_VA_PARA_SEQ_TRANSFORMACAO AS ProximaSequenciaTransformacao, ROT_PERFORMANCE AS Performance, ROT_TEMPO_SETUP AS TempoSetup, ROT_TEMPO_SETUP_AJUSTE AS TempoSetupAjuste, ROT_PECAS_POR_PULSO AS PecasPorPulso, ROT_PRIORIDADE_INFORMADA AS PrioridadeInformada, ROT_STATUS AS Status, ROT_OPERACOES AS Operacoes, ROT_EXCECAO_OPERACOES AS ExcecaoOperacoes, ROT_LINHA_DIRETA AS LinhaDireta, AVALIA_CUSTO AS AvaliaCusto, PERCENTUAL_INICIO_PASSO_ANTERIOR AS PercentualInicioPassoAnterior, MAQ_LARGURA_UTIL AS MaquinaLarguraUtil, GRP_TIPO AS GrupoTipo, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO AS GrupoPerformanceMetroLinear FROM V_ROTEIRO_PEDIDO ";
                      dict["PrioridadeInformada"] = value; //06
                      whereClauses.Add($" ROT_PRIORIDADE_INFORMADA = @PrioridadeInformada ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByStatusQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID AS PedidoId, MAQ_ID AS MaquinaId, PRO_ID AS ProdutoId, ROT_SEQ_TRANFORMACAO AS SequenciaTransformacao, STATUS_CADASTRO AS StatusCadastro, MAQ_TIPO_PLANEJAMENTO AS TipoPlanejamento, CAL_ID AS CalendarioId, HIERARQUIA_SEQ_TRANSFORMACAO AS HierarquiaSequenciaTransformacao, ROT_VA_PARA_SEQ_TRANSFORMACAO AS ProximaSequenciaTransformacao, ROT_PERFORMANCE AS Performance, ROT_TEMPO_SETUP AS TempoSetup, ROT_TEMPO_SETUP_AJUSTE AS TempoSetupAjuste, ROT_PECAS_POR_PULSO AS PecasPorPulso, ROT_PRIORIDADE_INFORMADA AS PrioridadeInformada, ROT_STATUS AS Status, ROT_OPERACOES AS Operacoes, ROT_EXCECAO_OPERACOES AS ExcecaoOperacoes, ROT_LINHA_DIRETA AS LinhaDireta, AVALIA_CUSTO AS AvaliaCusto, PERCENTUAL_INICIO_PASSO_ANTERIOR AS PercentualInicioPassoAnterior, MAQ_LARGURA_UTIL AS MaquinaLarguraUtil, GRP_TIPO AS GrupoTipo, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO AS GrupoPerformanceMetroLinear FROM V_ROTEIRO_PEDIDO ";
                      dict["Status"] = value; //06
                      whereClauses.Add($" ROT_STATUS = @Status ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByOperacoesQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID AS PedidoId, MAQ_ID AS MaquinaId, PRO_ID AS ProdutoId, ROT_SEQ_TRANFORMACAO AS SequenciaTransformacao, STATUS_CADASTRO AS StatusCadastro, MAQ_TIPO_PLANEJAMENTO AS TipoPlanejamento, CAL_ID AS CalendarioId, HIERARQUIA_SEQ_TRANSFORMACAO AS HierarquiaSequenciaTransformacao, ROT_VA_PARA_SEQ_TRANSFORMACAO AS ProximaSequenciaTransformacao, ROT_PERFORMANCE AS Performance, ROT_TEMPO_SETUP AS TempoSetup, ROT_TEMPO_SETUP_AJUSTE AS TempoSetupAjuste, ROT_PECAS_POR_PULSO AS PecasPorPulso, ROT_PRIORIDADE_INFORMADA AS PrioridadeInformada, ROT_STATUS AS Status, ROT_OPERACOES AS Operacoes, ROT_EXCECAO_OPERACOES AS ExcecaoOperacoes, ROT_LINHA_DIRETA AS LinhaDireta, AVALIA_CUSTO AS AvaliaCusto, PERCENTUAL_INICIO_PASSO_ANTERIOR AS PercentualInicioPassoAnterior, MAQ_LARGURA_UTIL AS MaquinaLarguraUtil, GRP_TIPO AS GrupoTipo, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO AS GrupoPerformanceMetroLinear FROM V_ROTEIRO_PEDIDO ";
                      dict["Operacoes"] = value; //06
                      whereClauses.Add($" ROT_OPERACOES = @Operacoes ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByExcecaoOperacoesQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID AS PedidoId, MAQ_ID AS MaquinaId, PRO_ID AS ProdutoId, ROT_SEQ_TRANFORMACAO AS SequenciaTransformacao, STATUS_CADASTRO AS StatusCadastro, MAQ_TIPO_PLANEJAMENTO AS TipoPlanejamento, CAL_ID AS CalendarioId, HIERARQUIA_SEQ_TRANSFORMACAO AS HierarquiaSequenciaTransformacao, ROT_VA_PARA_SEQ_TRANSFORMACAO AS ProximaSequenciaTransformacao, ROT_PERFORMANCE AS Performance, ROT_TEMPO_SETUP AS TempoSetup, ROT_TEMPO_SETUP_AJUSTE AS TempoSetupAjuste, ROT_PECAS_POR_PULSO AS PecasPorPulso, ROT_PRIORIDADE_INFORMADA AS PrioridadeInformada, ROT_STATUS AS Status, ROT_OPERACOES AS Operacoes, ROT_EXCECAO_OPERACOES AS ExcecaoOperacoes, ROT_LINHA_DIRETA AS LinhaDireta, AVALIA_CUSTO AS AvaliaCusto, PERCENTUAL_INICIO_PASSO_ANTERIOR AS PercentualInicioPassoAnterior, MAQ_LARGURA_UTIL AS MaquinaLarguraUtil, GRP_TIPO AS GrupoTipo, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO AS GrupoPerformanceMetroLinear FROM V_ROTEIRO_PEDIDO ";
                      dict["ExcecaoOperacoes"] = value; //06
                      whereClauses.Add($" ROT_EXCECAO_OPERACOES = @ExcecaoOperacoes ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByLinhaDiretaQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID AS PedidoId, MAQ_ID AS MaquinaId, PRO_ID AS ProdutoId, ROT_SEQ_TRANFORMACAO AS SequenciaTransformacao, STATUS_CADASTRO AS StatusCadastro, MAQ_TIPO_PLANEJAMENTO AS TipoPlanejamento, CAL_ID AS CalendarioId, HIERARQUIA_SEQ_TRANSFORMACAO AS HierarquiaSequenciaTransformacao, ROT_VA_PARA_SEQ_TRANSFORMACAO AS ProximaSequenciaTransformacao, ROT_PERFORMANCE AS Performance, ROT_TEMPO_SETUP AS TempoSetup, ROT_TEMPO_SETUP_AJUSTE AS TempoSetupAjuste, ROT_PECAS_POR_PULSO AS PecasPorPulso, ROT_PRIORIDADE_INFORMADA AS PrioridadeInformada, ROT_STATUS AS Status, ROT_OPERACOES AS Operacoes, ROT_EXCECAO_OPERACOES AS ExcecaoOperacoes, ROT_LINHA_DIRETA AS LinhaDireta, AVALIA_CUSTO AS AvaliaCusto, PERCENTUAL_INICIO_PASSO_ANTERIOR AS PercentualInicioPassoAnterior, MAQ_LARGURA_UTIL AS MaquinaLarguraUtil, GRP_TIPO AS GrupoTipo, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO AS GrupoPerformanceMetroLinear FROM V_ROTEIRO_PEDIDO ";
                      dict["LinhaDireta"] = value; //06
                      whereClauses.Add($" ROT_LINHA_DIRETA = @LinhaDireta ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByAvaliaCustoQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID AS PedidoId, MAQ_ID AS MaquinaId, PRO_ID AS ProdutoId, ROT_SEQ_TRANFORMACAO AS SequenciaTransformacao, STATUS_CADASTRO AS StatusCadastro, MAQ_TIPO_PLANEJAMENTO AS TipoPlanejamento, CAL_ID AS CalendarioId, HIERARQUIA_SEQ_TRANSFORMACAO AS HierarquiaSequenciaTransformacao, ROT_VA_PARA_SEQ_TRANSFORMACAO AS ProximaSequenciaTransformacao, ROT_PERFORMANCE AS Performance, ROT_TEMPO_SETUP AS TempoSetup, ROT_TEMPO_SETUP_AJUSTE AS TempoSetupAjuste, ROT_PECAS_POR_PULSO AS PecasPorPulso, ROT_PRIORIDADE_INFORMADA AS PrioridadeInformada, ROT_STATUS AS Status, ROT_OPERACOES AS Operacoes, ROT_EXCECAO_OPERACOES AS ExcecaoOperacoes, ROT_LINHA_DIRETA AS LinhaDireta, AVALIA_CUSTO AS AvaliaCusto, PERCENTUAL_INICIO_PASSO_ANTERIOR AS PercentualInicioPassoAnterior, MAQ_LARGURA_UTIL AS MaquinaLarguraUtil, GRP_TIPO AS GrupoTipo, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO AS GrupoPerformanceMetroLinear FROM V_ROTEIRO_PEDIDO ";
                      dict["AvaliaCusto"] = value; //06
                      whereClauses.Add($" AVALIA_CUSTO = @AvaliaCusto ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPercentualInicioPassoAnteriorQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID AS PedidoId, MAQ_ID AS MaquinaId, PRO_ID AS ProdutoId, ROT_SEQ_TRANFORMACAO AS SequenciaTransformacao, STATUS_CADASTRO AS StatusCadastro, MAQ_TIPO_PLANEJAMENTO AS TipoPlanejamento, CAL_ID AS CalendarioId, HIERARQUIA_SEQ_TRANSFORMACAO AS HierarquiaSequenciaTransformacao, ROT_VA_PARA_SEQ_TRANSFORMACAO AS ProximaSequenciaTransformacao, ROT_PERFORMANCE AS Performance, ROT_TEMPO_SETUP AS TempoSetup, ROT_TEMPO_SETUP_AJUSTE AS TempoSetupAjuste, ROT_PECAS_POR_PULSO AS PecasPorPulso, ROT_PRIORIDADE_INFORMADA AS PrioridadeInformada, ROT_STATUS AS Status, ROT_OPERACOES AS Operacoes, ROT_EXCECAO_OPERACOES AS ExcecaoOperacoes, ROT_LINHA_DIRETA AS LinhaDireta, AVALIA_CUSTO AS AvaliaCusto, PERCENTUAL_INICIO_PASSO_ANTERIOR AS PercentualInicioPassoAnterior, MAQ_LARGURA_UTIL AS MaquinaLarguraUtil, GRP_TIPO AS GrupoTipo, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO AS GrupoPerformanceMetroLinear FROM V_ROTEIRO_PEDIDO ";
                      dict["PercentualInicioPassoAnterior"] = value; //06
                      whereClauses.Add($" PERCENTUAL_INICIO_PASSO_ANTERIOR = @PercentualInicioPassoAnterior ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMaquinaLarguraUtilQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID AS PedidoId, MAQ_ID AS MaquinaId, PRO_ID AS ProdutoId, ROT_SEQ_TRANFORMACAO AS SequenciaTransformacao, STATUS_CADASTRO AS StatusCadastro, MAQ_TIPO_PLANEJAMENTO AS TipoPlanejamento, CAL_ID AS CalendarioId, HIERARQUIA_SEQ_TRANSFORMACAO AS HierarquiaSequenciaTransformacao, ROT_VA_PARA_SEQ_TRANSFORMACAO AS ProximaSequenciaTransformacao, ROT_PERFORMANCE AS Performance, ROT_TEMPO_SETUP AS TempoSetup, ROT_TEMPO_SETUP_AJUSTE AS TempoSetupAjuste, ROT_PECAS_POR_PULSO AS PecasPorPulso, ROT_PRIORIDADE_INFORMADA AS PrioridadeInformada, ROT_STATUS AS Status, ROT_OPERACOES AS Operacoes, ROT_EXCECAO_OPERACOES AS ExcecaoOperacoes, ROT_LINHA_DIRETA AS LinhaDireta, AVALIA_CUSTO AS AvaliaCusto, PERCENTUAL_INICIO_PASSO_ANTERIOR AS PercentualInicioPassoAnterior, MAQ_LARGURA_UTIL AS MaquinaLarguraUtil, GRP_TIPO AS GrupoTipo, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO AS GrupoPerformanceMetroLinear FROM V_ROTEIRO_PEDIDO ";
                      dict["MaquinaLarguraUtil"] = value; //06
                      whereClauses.Add($" MAQ_LARGURA_UTIL = @MaquinaLarguraUtil ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGrupoTipoQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID AS PedidoId, MAQ_ID AS MaquinaId, PRO_ID AS ProdutoId, ROT_SEQ_TRANFORMACAO AS SequenciaTransformacao, STATUS_CADASTRO AS StatusCadastro, MAQ_TIPO_PLANEJAMENTO AS TipoPlanejamento, CAL_ID AS CalendarioId, HIERARQUIA_SEQ_TRANSFORMACAO AS HierarquiaSequenciaTransformacao, ROT_VA_PARA_SEQ_TRANSFORMACAO AS ProximaSequenciaTransformacao, ROT_PERFORMANCE AS Performance, ROT_TEMPO_SETUP AS TempoSetup, ROT_TEMPO_SETUP_AJUSTE AS TempoSetupAjuste, ROT_PECAS_POR_PULSO AS PecasPorPulso, ROT_PRIORIDADE_INFORMADA AS PrioridadeInformada, ROT_STATUS AS Status, ROT_OPERACOES AS Operacoes, ROT_EXCECAO_OPERACOES AS ExcecaoOperacoes, ROT_LINHA_DIRETA AS LinhaDireta, AVALIA_CUSTO AS AvaliaCusto, PERCENTUAL_INICIO_PASSO_ANTERIOR AS PercentualInicioPassoAnterior, MAQ_LARGURA_UTIL AS MaquinaLarguraUtil, GRP_TIPO AS GrupoTipo, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO AS GrupoPerformanceMetroLinear FROM V_ROTEIRO_PEDIDO ";
                      dict["GrupoTipo"] = value; //06
                      whereClauses.Add($" GRP_TIPO = @GrupoTipo ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGrupoPerformanceMetroLinearQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT ORD_ID AS PedidoId, MAQ_ID AS MaquinaId, PRO_ID AS ProdutoId, ROT_SEQ_TRANFORMACAO AS SequenciaTransformacao, STATUS_CADASTRO AS StatusCadastro, MAQ_TIPO_PLANEJAMENTO AS TipoPlanejamento, CAL_ID AS CalendarioId, HIERARQUIA_SEQ_TRANSFORMACAO AS HierarquiaSequenciaTransformacao, ROT_VA_PARA_SEQ_TRANSFORMACAO AS ProximaSequenciaTransformacao, ROT_PERFORMANCE AS Performance, ROT_TEMPO_SETUP AS TempoSetup, ROT_TEMPO_SETUP_AJUSTE AS TempoSetupAjuste, ROT_PECAS_POR_PULSO AS PecasPorPulso, ROT_PRIORIDADE_INFORMADA AS PrioridadeInformada, ROT_STATUS AS Status, ROT_OPERACOES AS Operacoes, ROT_EXCECAO_OPERACOES AS ExcecaoOperacoes, ROT_LINHA_DIRETA AS LinhaDireta, AVALIA_CUSTO AS AvaliaCusto, PERCENTUAL_INICIO_PASSO_ANTERIOR AS PercentualInicioPassoAnterior, MAQ_LARGURA_UTIL AS MaquinaLarguraUtil, GRP_TIPO AS GrupoTipo, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO AS GrupoPerformanceMetroLinear FROM V_ROTEIRO_PEDIDO ";
                      dict["GrupoPerformanceMetroLinear"] = value; //06
                      whereClauses.Add($" GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO = @GrupoPerformanceMetroLinear ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration