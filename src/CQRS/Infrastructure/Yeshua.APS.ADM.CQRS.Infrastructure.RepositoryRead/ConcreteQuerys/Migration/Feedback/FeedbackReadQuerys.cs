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
    public class FeedbackQueryRead : QueryBase, IFeedbackQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public FeedbackQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel FeedbackQuery(Command.Read.FeedbackReadCommand Command )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select [Id], [DataInicial], [Datafinal], [MaquinaId], [OcorrenciaId], [TurnoId], [TurmaId], [UsuarioId], [OrderId], [ProdutoId], [Observacoes], [Grupo], [DiaTurma], [SequenciaTransformacao], [SequenciaRepeticao], [QuantidadePulsos], [QuantidadePecasPorPulso], [FEE_QTD_TOTAL_PRODUCAO_AJUSTADA], [BOL_ID], [COR_SEQUENCIA], [TenantID], [Deleted], [Changed], [UserId] from [Feedback] ";
if (Command.Id.HasValue) dict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"[Id] = @Id");
if (!string.IsNullOrEmpty(Command.MaquinaId)) dict["MaquinaId"] = $"%{Command.MaquinaId}%";
if (!string.IsNullOrEmpty(Command.MaquinaId)) whereClauses.Add($"[MaquinaId] like @MaquinaId");
if (!string.IsNullOrEmpty(Command.OcorrenciaId)) dict["OcorrenciaId"] = $"%{Command.OcorrenciaId}%";
if (!string.IsNullOrEmpty(Command.OcorrenciaId)) whereClauses.Add($"[OcorrenciaId] like @OcorrenciaId");
if (!string.IsNullOrEmpty(Command.TurnoId)) dict["TurnoId"] = $"%{Command.TurnoId}%";
if (!string.IsNullOrEmpty(Command.TurnoId)) whereClauses.Add($"[TurnoId] like @TurnoId");
if (!string.IsNullOrEmpty(Command.TurmaId)) dict["TurmaId"] = $"%{Command.TurmaId}%";
if (!string.IsNullOrEmpty(Command.TurmaId)) whereClauses.Add($"[TurmaId] like @TurmaId");
if (Command.UsuarioId.HasValue) dict["UsuarioId"] = Command.UsuarioId.Value;
if (Command.UsuarioId.HasValue) whereClauses.Add($"[UsuarioId] = @UsuarioId");
if (!string.IsNullOrEmpty(Command.OrderId)) dict["OrderId"] = $"%{Command.OrderId}%";
if (!string.IsNullOrEmpty(Command.OrderId)) whereClauses.Add($"[OrderId] like @OrderId");
if (!string.IsNullOrEmpty(Command.ProdutoId)) dict["ProdutoId"] = $"%{Command.ProdutoId}%";
if (!string.IsNullOrEmpty(Command.ProdutoId)) whereClauses.Add($"[ProdutoId] like @ProdutoId");
if (!string.IsNullOrEmpty(Command.Observacoes)) dict["Observacoes"] = $"%{Command.Observacoes}%";
if (!string.IsNullOrEmpty(Command.Observacoes)) whereClauses.Add($"[Observacoes] like @Observacoes");
if (!string.IsNullOrEmpty(Command.DiaTurma)) dict["DiaTurma"] = $"%{Command.DiaTurma}%";
if (!string.IsNullOrEmpty(Command.DiaTurma)) whereClauses.Add($"[DiaTurma] like @DiaTurma");
if (Command.SequenciaTransformacao.HasValue) dict["SequenciaTransformacao"] = Command.SequenciaTransformacao.Value;
if (Command.SequenciaTransformacao.HasValue) whereClauses.Add($"[SequenciaTransformacao] = @SequenciaTransformacao");
if (Command.SequenciaRepeticao.HasValue) dict["SequenciaRepeticao"] = Command.SequenciaRepeticao.Value;
if (Command.SequenciaRepeticao.HasValue) whereClauses.Add($"[SequenciaRepeticao] = @SequenciaRepeticao");
if (!string.IsNullOrEmpty(Command.BOL_ID)) dict["BOL_ID"] = $"%{Command.BOL_ID}%";
if (!string.IsNullOrEmpty(Command.BOL_ID)) whereClauses.Add($"[BOL_ID] like @BOL_ID");
if (Command.COR_SEQUENCIA.HasValue) dict["COR_SEQUENCIA"] = Command.COR_SEQUENCIA.Value;
if (Command.COR_SEQUENCIA.HasValue) whereClauses.Add($"[COR_SEQUENCIA] = @COR_SEQUENCIA");
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
if (Command.UserId.HasValue) dict["UserId"] = Command.UserId.Value;
if (Command.UserId.HasValue) whereClauses.Add($"[UserId] = @UserId");
            if (whereClauses.Any()) 
                 this.Query += $" WHERE {string.Join(" AND ", whereClauses)}"; 
            int page = Command.Paginacao?.Page ?? 1;
            int pageSize = Command.Paginacao?.PageSize ?? 20;
            int offset = (page - 1) * pageSize;
            dict["Offset"] = offset;
            dict["PageSize"] = pageSize;
            Query += " ORDER BY [Id] OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel FeedbackOcorrenciaIdQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select [OCO_ID] from [Ocorrencia] ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["OCO_ID"] = numero; //01
                      whereClauses.Add($" [OCO_ID] = @OCO_ID");//01 
                 }
                 else 
                 {
                      dict["OCO_ID"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" [OCO_ID] like @OCO_ID ");//02
                 }
           }
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel FeedbackTurnoIdQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select [Id], [Descricao] from [Turno] ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["Id"] = numero; //01
                      whereClauses.Add($" [Id] = @Id");//01 
                 }
                 else 
                 {
                      dict["Id"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" [Id] like @Id ");//02
                      dict["Descricao"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" [Descricao] like @Descricao ");//02
                 }
           }
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel FeedbackTurmaIdQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select [Id], [Descricao] from [Turma] ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["Id"] = numero; //01
                      whereClauses.Add($" [Id] = @Id");//01 
                 }
                 else 
                 {
                      dict["Id"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" [Id] like @Id ");//02
                      dict["Descricao"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" [Descricao] like @Descricao ");//02
                 }
           }
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel FeedbackUsuarioIdQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select [USE_ID] from [Usuario] ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["USE_ID"] = numero; //01
                      whereClauses.Add($" [USE_ID] = @USE_ID");//01 
                 }
                 else 
                 {
                      dict["USE_ID"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" [USE_ID] like @USE_ID ");//02
                 }
           }
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel FeedbackTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select [Id], [Nome] from [yTenant] ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["Id"] = numero; //01
                      whereClauses.Add($" [Id] = @Id");//01 
                 }
                 else 
                 {
                      dict["Id"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" [Id] like @Id ");//02
                      dict["Nome"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" [Nome] like @Nome ");//02
                 }
           }
 dict["Id"] = _executionContext.TenantID;
 whereClauses.Add($"[Id] = @Id");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel FeedbackUserIdQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select [Id], [Nome] from [yUser] ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["Id"] = numero; //01
                      whereClauses.Add($" [Id] = @Id");//01 
                 }
                 else 
                 {
                      dict["Id"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" [Id] like @Id ");//02
                      dict["Nome"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" [Nome] like @Nome ");//02
                 }
           }
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters); 
        }
        public QueryModel ExistsByIdQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Feedback] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Id"] = value; //04
                      whereClauses.Add($" [Id] = @Id ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByDataInicialQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Feedback] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["DataInicial"] = value; //04
                      whereClauses.Add($" [DataInicial] = @DataInicial ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByDatafinalQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Feedback] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Datafinal"] = value; //04
                      whereClauses.Add($" [Datafinal] = @Datafinal ");//04
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
            this.Query = $"SELECT 1 FROM [Feedback] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MaquinaId"] = value; //04
                      whereClauses.Add($" [MaquinaId] = @MaquinaId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByOcorrenciaIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Feedback] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["OcorrenciaId"] = value; //04
                      whereClauses.Add($" [OcorrenciaId] = @OcorrenciaId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTurnoIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Feedback] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TurnoId"] = value; //04
                      whereClauses.Add($" [TurnoId] = @TurnoId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTurmaIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Feedback] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TurmaId"] = value; //04
                      whereClauses.Add($" [TurmaId] = @TurmaId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByUsuarioIdQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Feedback] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["UsuarioId"] = value; //04
                      whereClauses.Add($" [UsuarioId] = @UsuarioId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByOrderIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Feedback] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["OrderId"] = value; //04
                      whereClauses.Add($" [OrderId] = @OrderId ");//04
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
            this.Query = $"SELECT 1 FROM [Feedback] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ProdutoId"] = value; //04
                      whereClauses.Add($" [ProdutoId] = @ProdutoId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByObservacoesQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Feedback] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Observacoes"] = value; //04
                      whereClauses.Add($" [Observacoes] = @Observacoes ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGrupoQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Feedback] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Grupo"] = value; //04
                      whereClauses.Add($" [Grupo] = @Grupo ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByDiaTurmaQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Feedback] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["DiaTurma"] = value; //04
                      whereClauses.Add($" [DiaTurma] = @DiaTurma ");//04
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
            this.Query = $"SELECT 1 FROM [Feedback] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["SequenciaTransformacao"] = value; //04
                      whereClauses.Add($" [SequenciaTransformacao] = @SequenciaTransformacao ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsBySequenciaRepeticaoQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Feedback] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["SequenciaRepeticao"] = value; //04
                      whereClauses.Add($" [SequenciaRepeticao] = @SequenciaRepeticao ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByQuantidadePulsosQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Feedback] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["QuantidadePulsos"] = value; //04
                      whereClauses.Add($" [QuantidadePulsos] = @QuantidadePulsos ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByQuantidadePecasPorPulsoQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Feedback] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["QuantidadePecasPorPulso"] = value; //04
                      whereClauses.Add($" [QuantidadePecasPorPulso] = @QuantidadePecasPorPulso ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFEE_QTD_TOTAL_PRODUCAO_AJUSTADAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Feedback] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["FEE_QTD_TOTAL_PRODUCAO_AJUSTADA"] = value; //04
                      whereClauses.Add($" [FEE_QTD_TOTAL_PRODUCAO_AJUSTADA] = @FEE_QTD_TOTAL_PRODUCAO_AJUSTADA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByBOL_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Feedback] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["BOL_ID"] = value; //04
                      whereClauses.Add($" [BOL_ID] = @BOL_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCOR_SEQUENCIAQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Feedback] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COR_SEQUENCIA"] = value; //04
                      whereClauses.Add($" [COR_SEQUENCIA] = @COR_SEQUENCIA ");//04
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
            this.Query = $"SELECT 1 FROM [Feedback] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TenantID"] = value; //04
                      whereClauses.Add($" [TenantID] = @TenantID ");//04
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
            this.Query = $"SELECT 1 FROM [Feedback] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Deleted"] = value; //04
                      whereClauses.Add($" [Deleted] = @Deleted ");//04
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
            this.Query = $"SELECT 1 FROM [Feedback] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Changed"] = value; //04
                      whereClauses.Add($" [Changed] = @Changed ");//04
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
            this.Query = $"SELECT 1 FROM [Feedback] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["UserId"] = value; //04
                      whereClauses.Add($" [UserId] = @UserId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByIdQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [DataInicial], [Datafinal], [MaquinaId], [OcorrenciaId], [TurnoId], [TurmaId], [UsuarioId], [OrderId], [ProdutoId], [Observacoes], [Grupo], [DiaTurma], [SequenciaTransformacao], [SequenciaRepeticao], [QuantidadePulsos], [QuantidadePecasPorPulso], [FEE_QTD_TOTAL_PRODUCAO_AJUSTADA], [BOL_ID], [COR_SEQUENCIA], [TenantID], [Deleted], [Changed], [UserId] FROM [Feedback] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Id"] = value; //06
                      whereClauses.Add($" [Id] = @Id ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByDataInicialQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [DataInicial], [Datafinal], [MaquinaId], [OcorrenciaId], [TurnoId], [TurmaId], [UsuarioId], [OrderId], [ProdutoId], [Observacoes], [Grupo], [DiaTurma], [SequenciaTransformacao], [SequenciaRepeticao], [QuantidadePulsos], [QuantidadePecasPorPulso], [FEE_QTD_TOTAL_PRODUCAO_AJUSTADA], [BOL_ID], [COR_SEQUENCIA], [TenantID], [Deleted], [Changed], [UserId] FROM [Feedback] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["DataInicial"] = value; //06
                      whereClauses.Add($" [DataInicial] = @DataInicial ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByDatafinalQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [DataInicial], [Datafinal], [MaquinaId], [OcorrenciaId], [TurnoId], [TurmaId], [UsuarioId], [OrderId], [ProdutoId], [Observacoes], [Grupo], [DiaTurma], [SequenciaTransformacao], [SequenciaRepeticao], [QuantidadePulsos], [QuantidadePecasPorPulso], [FEE_QTD_TOTAL_PRODUCAO_AJUSTADA], [BOL_ID], [COR_SEQUENCIA], [TenantID], [Deleted], [Changed], [UserId] FROM [Feedback] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Datafinal"] = value; //06
                      whereClauses.Add($" [Datafinal] = @Datafinal ");//06
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
            this.Query = $"SELECT [Id], [DataInicial], [Datafinal], [MaquinaId], [OcorrenciaId], [TurnoId], [TurmaId], [UsuarioId], [OrderId], [ProdutoId], [Observacoes], [Grupo], [DiaTurma], [SequenciaTransformacao], [SequenciaRepeticao], [QuantidadePulsos], [QuantidadePecasPorPulso], [FEE_QTD_TOTAL_PRODUCAO_AJUSTADA], [BOL_ID], [COR_SEQUENCIA], [TenantID], [Deleted], [Changed], [UserId] FROM [Feedback] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MaquinaId"] = value; //06
                      whereClauses.Add($" [MaquinaId] = @MaquinaId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByOcorrenciaIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [DataInicial], [Datafinal], [MaquinaId], [OcorrenciaId], [TurnoId], [TurmaId], [UsuarioId], [OrderId], [ProdutoId], [Observacoes], [Grupo], [DiaTurma], [SequenciaTransformacao], [SequenciaRepeticao], [QuantidadePulsos], [QuantidadePecasPorPulso], [FEE_QTD_TOTAL_PRODUCAO_AJUSTADA], [BOL_ID], [COR_SEQUENCIA], [TenantID], [Deleted], [Changed], [UserId] FROM [Feedback] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["OcorrenciaId"] = value; //06
                      whereClauses.Add($" [OcorrenciaId] = @OcorrenciaId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTurnoIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [DataInicial], [Datafinal], [MaquinaId], [OcorrenciaId], [TurnoId], [TurmaId], [UsuarioId], [OrderId], [ProdutoId], [Observacoes], [Grupo], [DiaTurma], [SequenciaTransformacao], [SequenciaRepeticao], [QuantidadePulsos], [QuantidadePecasPorPulso], [FEE_QTD_TOTAL_PRODUCAO_AJUSTADA], [BOL_ID], [COR_SEQUENCIA], [TenantID], [Deleted], [Changed], [UserId] FROM [Feedback] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TurnoId"] = value; //06
                      whereClauses.Add($" [TurnoId] = @TurnoId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTurmaIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [DataInicial], [Datafinal], [MaquinaId], [OcorrenciaId], [TurnoId], [TurmaId], [UsuarioId], [OrderId], [ProdutoId], [Observacoes], [Grupo], [DiaTurma], [SequenciaTransformacao], [SequenciaRepeticao], [QuantidadePulsos], [QuantidadePecasPorPulso], [FEE_QTD_TOTAL_PRODUCAO_AJUSTADA], [BOL_ID], [COR_SEQUENCIA], [TenantID], [Deleted], [Changed], [UserId] FROM [Feedback] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TurmaId"] = value; //06
                      whereClauses.Add($" [TurmaId] = @TurmaId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByUsuarioIdQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [DataInicial], [Datafinal], [MaquinaId], [OcorrenciaId], [TurnoId], [TurmaId], [UsuarioId], [OrderId], [ProdutoId], [Observacoes], [Grupo], [DiaTurma], [SequenciaTransformacao], [SequenciaRepeticao], [QuantidadePulsos], [QuantidadePecasPorPulso], [FEE_QTD_TOTAL_PRODUCAO_AJUSTADA], [BOL_ID], [COR_SEQUENCIA], [TenantID], [Deleted], [Changed], [UserId] FROM [Feedback] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["UsuarioId"] = value; //06
                      whereClauses.Add($" [UsuarioId] = @UsuarioId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByOrderIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [DataInicial], [Datafinal], [MaquinaId], [OcorrenciaId], [TurnoId], [TurmaId], [UsuarioId], [OrderId], [ProdutoId], [Observacoes], [Grupo], [DiaTurma], [SequenciaTransformacao], [SequenciaRepeticao], [QuantidadePulsos], [QuantidadePecasPorPulso], [FEE_QTD_TOTAL_PRODUCAO_AJUSTADA], [BOL_ID], [COR_SEQUENCIA], [TenantID], [Deleted], [Changed], [UserId] FROM [Feedback] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["OrderId"] = value; //06
                      whereClauses.Add($" [OrderId] = @OrderId ");//06
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
            this.Query = $"SELECT [Id], [DataInicial], [Datafinal], [MaquinaId], [OcorrenciaId], [TurnoId], [TurmaId], [UsuarioId], [OrderId], [ProdutoId], [Observacoes], [Grupo], [DiaTurma], [SequenciaTransformacao], [SequenciaRepeticao], [QuantidadePulsos], [QuantidadePecasPorPulso], [FEE_QTD_TOTAL_PRODUCAO_AJUSTADA], [BOL_ID], [COR_SEQUENCIA], [TenantID], [Deleted], [Changed], [UserId] FROM [Feedback] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ProdutoId"] = value; //06
                      whereClauses.Add($" [ProdutoId] = @ProdutoId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByObservacoesQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [DataInicial], [Datafinal], [MaquinaId], [OcorrenciaId], [TurnoId], [TurmaId], [UsuarioId], [OrderId], [ProdutoId], [Observacoes], [Grupo], [DiaTurma], [SequenciaTransformacao], [SequenciaRepeticao], [QuantidadePulsos], [QuantidadePecasPorPulso], [FEE_QTD_TOTAL_PRODUCAO_AJUSTADA], [BOL_ID], [COR_SEQUENCIA], [TenantID], [Deleted], [Changed], [UserId] FROM [Feedback] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Observacoes"] = value; //06
                      whereClauses.Add($" [Observacoes] = @Observacoes ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGrupoQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [DataInicial], [Datafinal], [MaquinaId], [OcorrenciaId], [TurnoId], [TurmaId], [UsuarioId], [OrderId], [ProdutoId], [Observacoes], [Grupo], [DiaTurma], [SequenciaTransformacao], [SequenciaRepeticao], [QuantidadePulsos], [QuantidadePecasPorPulso], [FEE_QTD_TOTAL_PRODUCAO_AJUSTADA], [BOL_ID], [COR_SEQUENCIA], [TenantID], [Deleted], [Changed], [UserId] FROM [Feedback] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Grupo"] = value; //06
                      whereClauses.Add($" [Grupo] = @Grupo ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByDiaTurmaQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [DataInicial], [Datafinal], [MaquinaId], [OcorrenciaId], [TurnoId], [TurmaId], [UsuarioId], [OrderId], [ProdutoId], [Observacoes], [Grupo], [DiaTurma], [SequenciaTransformacao], [SequenciaRepeticao], [QuantidadePulsos], [QuantidadePecasPorPulso], [FEE_QTD_TOTAL_PRODUCAO_AJUSTADA], [BOL_ID], [COR_SEQUENCIA], [TenantID], [Deleted], [Changed], [UserId] FROM [Feedback] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["DiaTurma"] = value; //06
                      whereClauses.Add($" [DiaTurma] = @DiaTurma ");//06
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
            this.Query = $"SELECT [Id], [DataInicial], [Datafinal], [MaquinaId], [OcorrenciaId], [TurnoId], [TurmaId], [UsuarioId], [OrderId], [ProdutoId], [Observacoes], [Grupo], [DiaTurma], [SequenciaTransformacao], [SequenciaRepeticao], [QuantidadePulsos], [QuantidadePecasPorPulso], [FEE_QTD_TOTAL_PRODUCAO_AJUSTADA], [BOL_ID], [COR_SEQUENCIA], [TenantID], [Deleted], [Changed], [UserId] FROM [Feedback] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["SequenciaTransformacao"] = value; //06
                      whereClauses.Add($" [SequenciaTransformacao] = @SequenciaTransformacao ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstBySequenciaRepeticaoQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [DataInicial], [Datafinal], [MaquinaId], [OcorrenciaId], [TurnoId], [TurmaId], [UsuarioId], [OrderId], [ProdutoId], [Observacoes], [Grupo], [DiaTurma], [SequenciaTransformacao], [SequenciaRepeticao], [QuantidadePulsos], [QuantidadePecasPorPulso], [FEE_QTD_TOTAL_PRODUCAO_AJUSTADA], [BOL_ID], [COR_SEQUENCIA], [TenantID], [Deleted], [Changed], [UserId] FROM [Feedback] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["SequenciaRepeticao"] = value; //06
                      whereClauses.Add($" [SequenciaRepeticao] = @SequenciaRepeticao ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByQuantidadePulsosQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [DataInicial], [Datafinal], [MaquinaId], [OcorrenciaId], [TurnoId], [TurmaId], [UsuarioId], [OrderId], [ProdutoId], [Observacoes], [Grupo], [DiaTurma], [SequenciaTransformacao], [SequenciaRepeticao], [QuantidadePulsos], [QuantidadePecasPorPulso], [FEE_QTD_TOTAL_PRODUCAO_AJUSTADA], [BOL_ID], [COR_SEQUENCIA], [TenantID], [Deleted], [Changed], [UserId] FROM [Feedback] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["QuantidadePulsos"] = value; //06
                      whereClauses.Add($" [QuantidadePulsos] = @QuantidadePulsos ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByQuantidadePecasPorPulsoQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [DataInicial], [Datafinal], [MaquinaId], [OcorrenciaId], [TurnoId], [TurmaId], [UsuarioId], [OrderId], [ProdutoId], [Observacoes], [Grupo], [DiaTurma], [SequenciaTransformacao], [SequenciaRepeticao], [QuantidadePulsos], [QuantidadePecasPorPulso], [FEE_QTD_TOTAL_PRODUCAO_AJUSTADA], [BOL_ID], [COR_SEQUENCIA], [TenantID], [Deleted], [Changed], [UserId] FROM [Feedback] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["QuantidadePecasPorPulso"] = value; //06
                      whereClauses.Add($" [QuantidadePecasPorPulso] = @QuantidadePecasPorPulso ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFEE_QTD_TOTAL_PRODUCAO_AJUSTADAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [DataInicial], [Datafinal], [MaquinaId], [OcorrenciaId], [TurnoId], [TurmaId], [UsuarioId], [OrderId], [ProdutoId], [Observacoes], [Grupo], [DiaTurma], [SequenciaTransformacao], [SequenciaRepeticao], [QuantidadePulsos], [QuantidadePecasPorPulso], [FEE_QTD_TOTAL_PRODUCAO_AJUSTADA], [BOL_ID], [COR_SEQUENCIA], [TenantID], [Deleted], [Changed], [UserId] FROM [Feedback] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["FEE_QTD_TOTAL_PRODUCAO_AJUSTADA"] = value; //06
                      whereClauses.Add($" [FEE_QTD_TOTAL_PRODUCAO_AJUSTADA] = @FEE_QTD_TOTAL_PRODUCAO_AJUSTADA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByBOL_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [DataInicial], [Datafinal], [MaquinaId], [OcorrenciaId], [TurnoId], [TurmaId], [UsuarioId], [OrderId], [ProdutoId], [Observacoes], [Grupo], [DiaTurma], [SequenciaTransformacao], [SequenciaRepeticao], [QuantidadePulsos], [QuantidadePecasPorPulso], [FEE_QTD_TOTAL_PRODUCAO_AJUSTADA], [BOL_ID], [COR_SEQUENCIA], [TenantID], [Deleted], [Changed], [UserId] FROM [Feedback] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["BOL_ID"] = value; //06
                      whereClauses.Add($" [BOL_ID] = @BOL_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCOR_SEQUENCIAQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [DataInicial], [Datafinal], [MaquinaId], [OcorrenciaId], [TurnoId], [TurmaId], [UsuarioId], [OrderId], [ProdutoId], [Observacoes], [Grupo], [DiaTurma], [SequenciaTransformacao], [SequenciaRepeticao], [QuantidadePulsos], [QuantidadePecasPorPulso], [FEE_QTD_TOTAL_PRODUCAO_AJUSTADA], [BOL_ID], [COR_SEQUENCIA], [TenantID], [Deleted], [Changed], [UserId] FROM [Feedback] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COR_SEQUENCIA"] = value; //06
                      whereClauses.Add($" [COR_SEQUENCIA] = @COR_SEQUENCIA ");//06
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
            this.Query = $"SELECT [Id], [DataInicial], [Datafinal], [MaquinaId], [OcorrenciaId], [TurnoId], [TurmaId], [UsuarioId], [OrderId], [ProdutoId], [Observacoes], [Grupo], [DiaTurma], [SequenciaTransformacao], [SequenciaRepeticao], [QuantidadePulsos], [QuantidadePecasPorPulso], [FEE_QTD_TOTAL_PRODUCAO_AJUSTADA], [BOL_ID], [COR_SEQUENCIA], [TenantID], [Deleted], [Changed], [UserId] FROM [Feedback] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TenantID"] = value; //06
                      whereClauses.Add($" [TenantID] = @TenantID ");//06
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
            this.Query = $"SELECT [Id], [DataInicial], [Datafinal], [MaquinaId], [OcorrenciaId], [TurnoId], [TurmaId], [UsuarioId], [OrderId], [ProdutoId], [Observacoes], [Grupo], [DiaTurma], [SequenciaTransformacao], [SequenciaRepeticao], [QuantidadePulsos], [QuantidadePecasPorPulso], [FEE_QTD_TOTAL_PRODUCAO_AJUSTADA], [BOL_ID], [COR_SEQUENCIA], [TenantID], [Deleted], [Changed], [UserId] FROM [Feedback] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Deleted"] = value; //06
                      whereClauses.Add($" [Deleted] = @Deleted ");//06
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
            this.Query = $"SELECT [Id], [DataInicial], [Datafinal], [MaquinaId], [OcorrenciaId], [TurnoId], [TurmaId], [UsuarioId], [OrderId], [ProdutoId], [Observacoes], [Grupo], [DiaTurma], [SequenciaTransformacao], [SequenciaRepeticao], [QuantidadePulsos], [QuantidadePecasPorPulso], [FEE_QTD_TOTAL_PRODUCAO_AJUSTADA], [BOL_ID], [COR_SEQUENCIA], [TenantID], [Deleted], [Changed], [UserId] FROM [Feedback] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Changed"] = value; //06
                      whereClauses.Add($" [Changed] = @Changed ");//06
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
            this.Query = $"SELECT [Id], [DataInicial], [Datafinal], [MaquinaId], [OcorrenciaId], [TurnoId], [TurmaId], [UsuarioId], [OrderId], [ProdutoId], [Observacoes], [Grupo], [DiaTurma], [SequenciaTransformacao], [SequenciaRepeticao], [QuantidadePulsos], [QuantidadePecasPorPulso], [FEE_QTD_TOTAL_PRODUCAO_AJUSTADA], [BOL_ID], [COR_SEQUENCIA], [TenantID], [Deleted], [Changed], [UserId] FROM [Feedback] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["UserId"] = value; //06
                      whereClauses.Add($" [UserId] = @UserId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration