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
    public class RoteiroQueryRead : QueryBase, IRoteiroQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public RoteiroQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel RoteiroQuery(Command.Read.RoteiroReadCommand Command )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select MaquinaId, ProdutoId, SequenciaTransformacao, GrupoMaquinaId, PecasPorPulso, PrioridadeInformada, Acao, Performance, TempoSetup, TempoSetupAjuste, ProximaSequenciaTransformacao, Status, HierarquiaSequenciaTransformacao, AvaliaCusto, Operacoes, ExcecaoOperacoes, PercentualInicioPassoAnterior, LinhaDireta, TemplateDeTestesId, TenantID, Deleted, Changed, UserId from Roteiro ";
if (!string.IsNullOrEmpty(Command.MaquinaId)) dict["MaquinaId"] = $"%{Command.MaquinaId}%";
if (!string.IsNullOrEmpty(Command.MaquinaId)) whereClauses.Add($"MaquinaId like @MaquinaId");
if (!string.IsNullOrEmpty(Command.ProdutoId)) dict["ProdutoId"] = $"%{Command.ProdutoId}%";
if (!string.IsNullOrEmpty(Command.ProdutoId)) whereClauses.Add($"ProdutoId like @ProdutoId");
if (Command.SequenciaTransformacao.HasValue) dict["SequenciaTransformacao"] = Command.SequenciaTransformacao.Value;
if (Command.SequenciaTransformacao.HasValue) whereClauses.Add($"SequenciaTransformacao = @SequenciaTransformacao");
if (!string.IsNullOrEmpty(Command.GrupoMaquinaId)) dict["GrupoMaquinaId"] = $"%{Command.GrupoMaquinaId}%";
if (!string.IsNullOrEmpty(Command.GrupoMaquinaId)) whereClauses.Add($"GrupoMaquinaId like @GrupoMaquinaId");
if (!string.IsNullOrEmpty(Command.Acao)) dict["Acao"] = $"%{Command.Acao}%";
if (!string.IsNullOrEmpty(Command.Acao)) whereClauses.Add($"Acao like @Acao");
if (Command.ProximaSequenciaTransformacao.HasValue) dict["ProximaSequenciaTransformacao"] = Command.ProximaSequenciaTransformacao.Value;
if (Command.ProximaSequenciaTransformacao.HasValue) whereClauses.Add($"ProximaSequenciaTransformacao = @ProximaSequenciaTransformacao");
if (!string.IsNullOrEmpty(Command.Status)) dict["Status"] = $"%{Command.Status}%";
if (!string.IsNullOrEmpty(Command.Status)) whereClauses.Add($"Status like @Status");
if (Command.AvaliaCusto.HasValue) dict["AvaliaCusto"] = Command.AvaliaCusto.Value;
if (Command.AvaliaCusto.HasValue) whereClauses.Add($"AvaliaCusto = @AvaliaCusto");
if (!string.IsNullOrEmpty(Command.Operacoes)) dict["Operacoes"] = $"%{Command.Operacoes}%";
if (!string.IsNullOrEmpty(Command.Operacoes)) whereClauses.Add($"Operacoes like @Operacoes");
if (!string.IsNullOrEmpty(Command.ExcecaoOperacoes)) dict["ExcecaoOperacoes"] = $"%{Command.ExcecaoOperacoes}%";
if (!string.IsNullOrEmpty(Command.ExcecaoOperacoes)) whereClauses.Add($"ExcecaoOperacoes like @ExcecaoOperacoes");
if (!string.IsNullOrEmpty(Command.LinhaDireta)) dict["LinhaDireta"] = $"%{Command.LinhaDireta}%";
if (!string.IsNullOrEmpty(Command.LinhaDireta)) whereClauses.Add($"LinhaDireta like @LinhaDireta");
if (Command.TemplateDeTestesId.HasValue) dict["TemplateDeTestesId"] = Command.TemplateDeTestesId.Value;
if (Command.TemplateDeTestesId.HasValue) whereClauses.Add($"TemplateDeTestesId = @TemplateDeTestesId");
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
            Query += " ORDER BY MaquinaId OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel RoteiroMaquinaIdQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel RoteiroProdutoIdQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel RoteiroGrupoMaquinaIdQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select Id, Descricao from GrupoMaquina ";
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
        public QueryModel RoteiroTemplateDeTestesIdQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select Id, Descricao from TemplateDeTestes ";
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
        public QueryModel RoteiroTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel RoteiroUserIdQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel ExistsByMaquinaIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Roteiro ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MaquinaId"] = value; //04
                      whereClauses.Add($" MaquinaId = @MaquinaId ");//04
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
            this.Query = $"SELECT 1 FROM Roteiro ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ProdutoId"] = value; //04
                      whereClauses.Add($" ProdutoId = @ProdutoId ");//04
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
            this.Query = $"SELECT 1 FROM Roteiro ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["SequenciaTransformacao"] = value; //04
                      whereClauses.Add($" SequenciaTransformacao = @SequenciaTransformacao ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGrupoMaquinaIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Roteiro ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GrupoMaquinaId"] = value; //04
                      whereClauses.Add($" GrupoMaquinaId = @GrupoMaquinaId ");//04
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
            this.Query = $"SELECT 1 FROM Roteiro ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PecasPorPulso"] = value; //04
                      whereClauses.Add($" PecasPorPulso = @PecasPorPulso ");//04
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
            this.Query = $"SELECT 1 FROM Roteiro ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PrioridadeInformada"] = value; //04
                      whereClauses.Add($" PrioridadeInformada = @PrioridadeInformada ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByAcaoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Roteiro ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Acao"] = value; //04
                      whereClauses.Add($" Acao = @Acao ");//04
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
            this.Query = $"SELECT 1 FROM Roteiro ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Performance"] = value; //04
                      whereClauses.Add($" Performance = @Performance ");//04
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
            this.Query = $"SELECT 1 FROM Roteiro ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TempoSetup"] = value; //04
                      whereClauses.Add($" TempoSetup = @TempoSetup ");//04
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
            this.Query = $"SELECT 1 FROM Roteiro ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TempoSetupAjuste"] = value; //04
                      whereClauses.Add($" TempoSetupAjuste = @TempoSetupAjuste ");//04
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
            this.Query = $"SELECT 1 FROM Roteiro ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ProximaSequenciaTransformacao"] = value; //04
                      whereClauses.Add($" ProximaSequenciaTransformacao = @ProximaSequenciaTransformacao ");//04
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
            this.Query = $"SELECT 1 FROM Roteiro ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Status"] = value; //04
                      whereClauses.Add($" Status = @Status ");//04
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
            this.Query = $"SELECT 1 FROM Roteiro ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["HierarquiaSequenciaTransformacao"] = value; //04
                      whereClauses.Add($" HierarquiaSequenciaTransformacao = @HierarquiaSequenciaTransformacao ");//04
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
            this.Query = $"SELECT 1 FROM Roteiro ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["AvaliaCusto"] = value; //04
                      whereClauses.Add($" AvaliaCusto = @AvaliaCusto ");//04
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
            this.Query = $"SELECT 1 FROM Roteiro ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Operacoes"] = value; //04
                      whereClauses.Add($" Operacoes = @Operacoes ");//04
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
            this.Query = $"SELECT 1 FROM Roteiro ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ExcecaoOperacoes"] = value; //04
                      whereClauses.Add($" ExcecaoOperacoes = @ExcecaoOperacoes ");//04
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
            this.Query = $"SELECT 1 FROM Roteiro ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PercentualInicioPassoAnterior"] = value; //04
                      whereClauses.Add($" PercentualInicioPassoAnterior = @PercentualInicioPassoAnterior ");//04
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
            this.Query = $"SELECT 1 FROM Roteiro ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["LinhaDireta"] = value; //04
                      whereClauses.Add($" LinhaDireta = @LinhaDireta ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTemplateDeTestesIdQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Roteiro ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TemplateDeTestesId"] = value; //04
                      whereClauses.Add($" TemplateDeTestesId = @TemplateDeTestesId ");//04
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
            this.Query = $"SELECT 1 FROM Roteiro ";
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
            this.Query = $"SELECT 1 FROM Roteiro ";
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
            this.Query = $"SELECT 1 FROM Roteiro ";
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
            this.Query = $"SELECT 1 FROM Roteiro ";
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
        public QueryModel FirstByMaquinaIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT MaquinaId, ProdutoId, SequenciaTransformacao, GrupoMaquinaId, PecasPorPulso, PrioridadeInformada, Acao, Performance, TempoSetup, TempoSetupAjuste, ProximaSequenciaTransformacao, Status, HierarquiaSequenciaTransformacao, AvaliaCusto, Operacoes, ExcecaoOperacoes, PercentualInicioPassoAnterior, LinhaDireta, TemplateDeTestesId, TenantID, Deleted, Changed, UserId FROM Roteiro ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MaquinaId"] = value; //06
                      whereClauses.Add($" MaquinaId = @MaquinaId ");//06
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
            this.Query = $"SELECT MaquinaId, ProdutoId, SequenciaTransformacao, GrupoMaquinaId, PecasPorPulso, PrioridadeInformada, Acao, Performance, TempoSetup, TempoSetupAjuste, ProximaSequenciaTransformacao, Status, HierarquiaSequenciaTransformacao, AvaliaCusto, Operacoes, ExcecaoOperacoes, PercentualInicioPassoAnterior, LinhaDireta, TemplateDeTestesId, TenantID, Deleted, Changed, UserId FROM Roteiro ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ProdutoId"] = value; //06
                      whereClauses.Add($" ProdutoId = @ProdutoId ");//06
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
            this.Query = $"SELECT MaquinaId, ProdutoId, SequenciaTransformacao, GrupoMaquinaId, PecasPorPulso, PrioridadeInformada, Acao, Performance, TempoSetup, TempoSetupAjuste, ProximaSequenciaTransformacao, Status, HierarquiaSequenciaTransformacao, AvaliaCusto, Operacoes, ExcecaoOperacoes, PercentualInicioPassoAnterior, LinhaDireta, TemplateDeTestesId, TenantID, Deleted, Changed, UserId FROM Roteiro ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["SequenciaTransformacao"] = value; //06
                      whereClauses.Add($" SequenciaTransformacao = @SequenciaTransformacao ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGrupoMaquinaIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT MaquinaId, ProdutoId, SequenciaTransformacao, GrupoMaquinaId, PecasPorPulso, PrioridadeInformada, Acao, Performance, TempoSetup, TempoSetupAjuste, ProximaSequenciaTransformacao, Status, HierarquiaSequenciaTransformacao, AvaliaCusto, Operacoes, ExcecaoOperacoes, PercentualInicioPassoAnterior, LinhaDireta, TemplateDeTestesId, TenantID, Deleted, Changed, UserId FROM Roteiro ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GrupoMaquinaId"] = value; //06
                      whereClauses.Add($" GrupoMaquinaId = @GrupoMaquinaId ");//06
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
            this.Query = $"SELECT MaquinaId, ProdutoId, SequenciaTransformacao, GrupoMaquinaId, PecasPorPulso, PrioridadeInformada, Acao, Performance, TempoSetup, TempoSetupAjuste, ProximaSequenciaTransformacao, Status, HierarquiaSequenciaTransformacao, AvaliaCusto, Operacoes, ExcecaoOperacoes, PercentualInicioPassoAnterior, LinhaDireta, TemplateDeTestesId, TenantID, Deleted, Changed, UserId FROM Roteiro ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PecasPorPulso"] = value; //06
                      whereClauses.Add($" PecasPorPulso = @PecasPorPulso ");//06
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
            this.Query = $"SELECT MaquinaId, ProdutoId, SequenciaTransformacao, GrupoMaquinaId, PecasPorPulso, PrioridadeInformada, Acao, Performance, TempoSetup, TempoSetupAjuste, ProximaSequenciaTransformacao, Status, HierarquiaSequenciaTransformacao, AvaliaCusto, Operacoes, ExcecaoOperacoes, PercentualInicioPassoAnterior, LinhaDireta, TemplateDeTestesId, TenantID, Deleted, Changed, UserId FROM Roteiro ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PrioridadeInformada"] = value; //06
                      whereClauses.Add($" PrioridadeInformada = @PrioridadeInformada ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByAcaoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT MaquinaId, ProdutoId, SequenciaTransformacao, GrupoMaquinaId, PecasPorPulso, PrioridadeInformada, Acao, Performance, TempoSetup, TempoSetupAjuste, ProximaSequenciaTransformacao, Status, HierarquiaSequenciaTransformacao, AvaliaCusto, Operacoes, ExcecaoOperacoes, PercentualInicioPassoAnterior, LinhaDireta, TemplateDeTestesId, TenantID, Deleted, Changed, UserId FROM Roteiro ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Acao"] = value; //06
                      whereClauses.Add($" Acao = @Acao ");//06
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
            this.Query = $"SELECT MaquinaId, ProdutoId, SequenciaTransformacao, GrupoMaquinaId, PecasPorPulso, PrioridadeInformada, Acao, Performance, TempoSetup, TempoSetupAjuste, ProximaSequenciaTransformacao, Status, HierarquiaSequenciaTransformacao, AvaliaCusto, Operacoes, ExcecaoOperacoes, PercentualInicioPassoAnterior, LinhaDireta, TemplateDeTestesId, TenantID, Deleted, Changed, UserId FROM Roteiro ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Performance"] = value; //06
                      whereClauses.Add($" Performance = @Performance ");//06
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
            this.Query = $"SELECT MaquinaId, ProdutoId, SequenciaTransformacao, GrupoMaquinaId, PecasPorPulso, PrioridadeInformada, Acao, Performance, TempoSetup, TempoSetupAjuste, ProximaSequenciaTransformacao, Status, HierarquiaSequenciaTransformacao, AvaliaCusto, Operacoes, ExcecaoOperacoes, PercentualInicioPassoAnterior, LinhaDireta, TemplateDeTestesId, TenantID, Deleted, Changed, UserId FROM Roteiro ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TempoSetup"] = value; //06
                      whereClauses.Add($" TempoSetup = @TempoSetup ");//06
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
            this.Query = $"SELECT MaquinaId, ProdutoId, SequenciaTransformacao, GrupoMaquinaId, PecasPorPulso, PrioridadeInformada, Acao, Performance, TempoSetup, TempoSetupAjuste, ProximaSequenciaTransformacao, Status, HierarquiaSequenciaTransformacao, AvaliaCusto, Operacoes, ExcecaoOperacoes, PercentualInicioPassoAnterior, LinhaDireta, TemplateDeTestesId, TenantID, Deleted, Changed, UserId FROM Roteiro ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TempoSetupAjuste"] = value; //06
                      whereClauses.Add($" TempoSetupAjuste = @TempoSetupAjuste ");//06
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
            this.Query = $"SELECT MaquinaId, ProdutoId, SequenciaTransformacao, GrupoMaquinaId, PecasPorPulso, PrioridadeInformada, Acao, Performance, TempoSetup, TempoSetupAjuste, ProximaSequenciaTransformacao, Status, HierarquiaSequenciaTransformacao, AvaliaCusto, Operacoes, ExcecaoOperacoes, PercentualInicioPassoAnterior, LinhaDireta, TemplateDeTestesId, TenantID, Deleted, Changed, UserId FROM Roteiro ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ProximaSequenciaTransformacao"] = value; //06
                      whereClauses.Add($" ProximaSequenciaTransformacao = @ProximaSequenciaTransformacao ");//06
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
            this.Query = $"SELECT MaquinaId, ProdutoId, SequenciaTransformacao, GrupoMaquinaId, PecasPorPulso, PrioridadeInformada, Acao, Performance, TempoSetup, TempoSetupAjuste, ProximaSequenciaTransformacao, Status, HierarquiaSequenciaTransformacao, AvaliaCusto, Operacoes, ExcecaoOperacoes, PercentualInicioPassoAnterior, LinhaDireta, TemplateDeTestesId, TenantID, Deleted, Changed, UserId FROM Roteiro ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Status"] = value; //06
                      whereClauses.Add($" Status = @Status ");//06
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
            this.Query = $"SELECT MaquinaId, ProdutoId, SequenciaTransformacao, GrupoMaquinaId, PecasPorPulso, PrioridadeInformada, Acao, Performance, TempoSetup, TempoSetupAjuste, ProximaSequenciaTransformacao, Status, HierarquiaSequenciaTransformacao, AvaliaCusto, Operacoes, ExcecaoOperacoes, PercentualInicioPassoAnterior, LinhaDireta, TemplateDeTestesId, TenantID, Deleted, Changed, UserId FROM Roteiro ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["HierarquiaSequenciaTransformacao"] = value; //06
                      whereClauses.Add($" HierarquiaSequenciaTransformacao = @HierarquiaSequenciaTransformacao ");//06
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
            this.Query = $"SELECT MaquinaId, ProdutoId, SequenciaTransformacao, GrupoMaquinaId, PecasPorPulso, PrioridadeInformada, Acao, Performance, TempoSetup, TempoSetupAjuste, ProximaSequenciaTransformacao, Status, HierarquiaSequenciaTransformacao, AvaliaCusto, Operacoes, ExcecaoOperacoes, PercentualInicioPassoAnterior, LinhaDireta, TemplateDeTestesId, TenantID, Deleted, Changed, UserId FROM Roteiro ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["AvaliaCusto"] = value; //06
                      whereClauses.Add($" AvaliaCusto = @AvaliaCusto ");//06
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
            this.Query = $"SELECT MaquinaId, ProdutoId, SequenciaTransformacao, GrupoMaquinaId, PecasPorPulso, PrioridadeInformada, Acao, Performance, TempoSetup, TempoSetupAjuste, ProximaSequenciaTransformacao, Status, HierarquiaSequenciaTransformacao, AvaliaCusto, Operacoes, ExcecaoOperacoes, PercentualInicioPassoAnterior, LinhaDireta, TemplateDeTestesId, TenantID, Deleted, Changed, UserId FROM Roteiro ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Operacoes"] = value; //06
                      whereClauses.Add($" Operacoes = @Operacoes ");//06
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
            this.Query = $"SELECT MaquinaId, ProdutoId, SequenciaTransformacao, GrupoMaquinaId, PecasPorPulso, PrioridadeInformada, Acao, Performance, TempoSetup, TempoSetupAjuste, ProximaSequenciaTransformacao, Status, HierarquiaSequenciaTransformacao, AvaliaCusto, Operacoes, ExcecaoOperacoes, PercentualInicioPassoAnterior, LinhaDireta, TemplateDeTestesId, TenantID, Deleted, Changed, UserId FROM Roteiro ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ExcecaoOperacoes"] = value; //06
                      whereClauses.Add($" ExcecaoOperacoes = @ExcecaoOperacoes ");//06
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
            this.Query = $"SELECT MaquinaId, ProdutoId, SequenciaTransformacao, GrupoMaquinaId, PecasPorPulso, PrioridadeInformada, Acao, Performance, TempoSetup, TempoSetupAjuste, ProximaSequenciaTransformacao, Status, HierarquiaSequenciaTransformacao, AvaliaCusto, Operacoes, ExcecaoOperacoes, PercentualInicioPassoAnterior, LinhaDireta, TemplateDeTestesId, TenantID, Deleted, Changed, UserId FROM Roteiro ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PercentualInicioPassoAnterior"] = value; //06
                      whereClauses.Add($" PercentualInicioPassoAnterior = @PercentualInicioPassoAnterior ");//06
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
            this.Query = $"SELECT MaquinaId, ProdutoId, SequenciaTransformacao, GrupoMaquinaId, PecasPorPulso, PrioridadeInformada, Acao, Performance, TempoSetup, TempoSetupAjuste, ProximaSequenciaTransformacao, Status, HierarquiaSequenciaTransformacao, AvaliaCusto, Operacoes, ExcecaoOperacoes, PercentualInicioPassoAnterior, LinhaDireta, TemplateDeTestesId, TenantID, Deleted, Changed, UserId FROM Roteiro ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["LinhaDireta"] = value; //06
                      whereClauses.Add($" LinhaDireta = @LinhaDireta ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTemplateDeTestesIdQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT MaquinaId, ProdutoId, SequenciaTransformacao, GrupoMaquinaId, PecasPorPulso, PrioridadeInformada, Acao, Performance, TempoSetup, TempoSetupAjuste, ProximaSequenciaTransformacao, Status, HierarquiaSequenciaTransformacao, AvaliaCusto, Operacoes, ExcecaoOperacoes, PercentualInicioPassoAnterior, LinhaDireta, TemplateDeTestesId, TenantID, Deleted, Changed, UserId FROM Roteiro ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TemplateDeTestesId"] = value; //06
                      whereClauses.Add($" TemplateDeTestesId = @TemplateDeTestesId ");//06
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
            this.Query = $"SELECT MaquinaId, ProdutoId, SequenciaTransformacao, GrupoMaquinaId, PecasPorPulso, PrioridadeInformada, Acao, Performance, TempoSetup, TempoSetupAjuste, ProximaSequenciaTransformacao, Status, HierarquiaSequenciaTransformacao, AvaliaCusto, Operacoes, ExcecaoOperacoes, PercentualInicioPassoAnterior, LinhaDireta, TemplateDeTestesId, TenantID, Deleted, Changed, UserId FROM Roteiro ";
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
            this.Query = $"SELECT MaquinaId, ProdutoId, SequenciaTransformacao, GrupoMaquinaId, PecasPorPulso, PrioridadeInformada, Acao, Performance, TempoSetup, TempoSetupAjuste, ProximaSequenciaTransformacao, Status, HierarquiaSequenciaTransformacao, AvaliaCusto, Operacoes, ExcecaoOperacoes, PercentualInicioPassoAnterior, LinhaDireta, TemplateDeTestesId, TenantID, Deleted, Changed, UserId FROM Roteiro ";
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
            this.Query = $"SELECT MaquinaId, ProdutoId, SequenciaTransformacao, GrupoMaquinaId, PecasPorPulso, PrioridadeInformada, Acao, Performance, TempoSetup, TempoSetupAjuste, ProximaSequenciaTransformacao, Status, HierarquiaSequenciaTransformacao, AvaliaCusto, Operacoes, ExcecaoOperacoes, PercentualInicioPassoAnterior, LinhaDireta, TemplateDeTestesId, TenantID, Deleted, Changed, UserId FROM Roteiro ";
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
            this.Query = $"SELECT MaquinaId, ProdutoId, SequenciaTransformacao, GrupoMaquinaId, PecasPorPulso, PrioridadeInformada, Acao, Performance, TempoSetup, TempoSetupAjuste, ProximaSequenciaTransformacao, Status, HierarquiaSequenciaTransformacao, AvaliaCusto, Operacoes, ExcecaoOperacoes, PercentualInicioPassoAnterior, LinhaDireta, TemplateDeTestesId, TenantID, Deleted, Changed, UserId FROM Roteiro ";
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