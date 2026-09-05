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
    public class CorridasOnduladeiraQueryRead : QueryBase, ICorridasOnduladeiraQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public CorridasOnduladeiraQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel CorridasOnduladeiraQuery(Command.Read.CorridasOnduladeiraReadCommand Command )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select [BOL_ID], [BOL_ID_ORIGEM], [PRO_LARGURA_PECA], [PRO_LARGURA_PECA_PROGRAMADO], [PRO_COMPRIMENTO_PECA], [PRO_COMPRIMENTO_PECA_PROGRAMADO], [PRO_UTILIZOU_REFILE_OBRIGATORIO], [PRO_VINCOS_RECALCULADOS], [COR_SOLVER], [COR_GRAMATURA_PAPEIS_PROGRAMADOS], [COR_CUSTO_PAPEIS_PROGRAMADOS], [COR_GRAMATURA_RESINA_PROGRAMADOS], [COR_CUSTO_RESINA_PROGRAMADOS], [COR_TOLERANCIA_MENOS], [COR_TOLERANCIA_MAIS], [COR_PILHAS_POR_PALETE], [COR_COR_FILA], [COR_M_LINEAR_REALIZADO], [PRO_ID_PALETE], [COR_STATUS_PALETE], [COR_GRUPO_PRODUTIVO], [TenantID], [Deleted], [Changed], [UserId], [COR_ID], [COR_STATUS], [COR_STATUS_INTERFACE], [MAQ_ID], [COR_ID_INTERFACE], [COR_SEQUENCIA], [COR_SEQUENCIA_ORIGEM], [ORD_ID], [FPR_SEQ_REPETICAO], [ROT_SEQ_TRANFORMACAO], [COR_FACAO], [COR_FORMATO_BOBINA], [COR_INICIO_PREVISTO], [COR_FIM_PREVISTO], [PRO_ID], [COR_QTD_PLANEJADO], [PRO_QTD_PACAS], [COR_PECAS_LARGURA] from [CorridasOnduladeira] ";
if (!string.IsNullOrEmpty(Command.BOL_ID)) dict["BOL_ID"] = $"%{Command.BOL_ID}%";
if (!string.IsNullOrEmpty(Command.BOL_ID)) whereClauses.Add($"[BOL_ID] like @BOL_ID");
if (!string.IsNullOrEmpty(Command.BOL_ID_ORIGEM)) dict["BOL_ID_ORIGEM"] = $"%{Command.BOL_ID_ORIGEM}%";
if (!string.IsNullOrEmpty(Command.BOL_ID_ORIGEM)) whereClauses.Add($"[BOL_ID_ORIGEM] like @BOL_ID_ORIGEM");
if (!string.IsNullOrEmpty(Command.PRO_VINCOS_RECALCULADOS)) dict["PRO_VINCOS_RECALCULADOS"] = $"%{Command.PRO_VINCOS_RECALCULADOS}%";
if (!string.IsNullOrEmpty(Command.PRO_VINCOS_RECALCULADOS)) whereClauses.Add($"[PRO_VINCOS_RECALCULADOS] like @PRO_VINCOS_RECALCULADOS");
if (!string.IsNullOrEmpty(Command.COR_SOLVER)) dict["COR_SOLVER"] = $"%{Command.COR_SOLVER}%";
if (!string.IsNullOrEmpty(Command.COR_SOLVER)) whereClauses.Add($"[COR_SOLVER] like @COR_SOLVER");
if (Command.COR_PILHAS_POR_PALETE.HasValue) dict["COR_PILHAS_POR_PALETE"] = Command.COR_PILHAS_POR_PALETE.Value;
if (Command.COR_PILHAS_POR_PALETE.HasValue) whereClauses.Add($"[COR_PILHAS_POR_PALETE] = @COR_PILHAS_POR_PALETE");
if (!string.IsNullOrEmpty(Command.COR_COR_FILA)) dict["COR_COR_FILA"] = $"%{Command.COR_COR_FILA}%";
if (!string.IsNullOrEmpty(Command.COR_COR_FILA)) whereClauses.Add($"[COR_COR_FILA] like @COR_COR_FILA");
if (!string.IsNullOrEmpty(Command.PRO_ID_PALETE)) dict["PRO_ID_PALETE"] = $"%{Command.PRO_ID_PALETE}%";
if (!string.IsNullOrEmpty(Command.PRO_ID_PALETE)) whereClauses.Add($"[PRO_ID_PALETE] like @PRO_ID_PALETE");
if (!string.IsNullOrEmpty(Command.COR_STATUS_PALETE)) dict["COR_STATUS_PALETE"] = $"%{Command.COR_STATUS_PALETE}%";
if (!string.IsNullOrEmpty(Command.COR_STATUS_PALETE)) whereClauses.Add($"[COR_STATUS_PALETE] like @COR_STATUS_PALETE");
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
if (Command.UserId.HasValue) dict["UserId"] = Command.UserId.Value;
if (Command.UserId.HasValue) whereClauses.Add($"[UserId] = @UserId");
if (Command.COR_ID.HasValue) dict["COR_ID"] = Command.COR_ID.Value;
if (Command.COR_ID.HasValue) whereClauses.Add($"[COR_ID] = @COR_ID");
if (!string.IsNullOrEmpty(Command.COR_STATUS)) dict["COR_STATUS"] = $"%{Command.COR_STATUS}%";
if (!string.IsNullOrEmpty(Command.COR_STATUS)) whereClauses.Add($"[COR_STATUS] like @COR_STATUS");
if (!string.IsNullOrEmpty(Command.COR_STATUS_INTERFACE)) dict["COR_STATUS_INTERFACE"] = $"%{Command.COR_STATUS_INTERFACE}%";
if (!string.IsNullOrEmpty(Command.COR_STATUS_INTERFACE)) whereClauses.Add($"[COR_STATUS_INTERFACE] like @COR_STATUS_INTERFACE");
if (!string.IsNullOrEmpty(Command.MAQ_ID)) dict["MAQ_ID"] = $"%{Command.MAQ_ID}%";
if (!string.IsNullOrEmpty(Command.MAQ_ID)) whereClauses.Add($"[MAQ_ID] like @MAQ_ID");
if (Command.COR_ID_INTERFACE.HasValue) dict["COR_ID_INTERFACE"] = Command.COR_ID_INTERFACE.Value;
if (Command.COR_ID_INTERFACE.HasValue) whereClauses.Add($"[COR_ID_INTERFACE] = @COR_ID_INTERFACE");
if (Command.COR_SEQUENCIA.HasValue) dict["COR_SEQUENCIA"] = Command.COR_SEQUENCIA.Value;
if (Command.COR_SEQUENCIA.HasValue) whereClauses.Add($"[COR_SEQUENCIA] = @COR_SEQUENCIA");
if (Command.COR_SEQUENCIA_ORIGEM.HasValue) dict["COR_SEQUENCIA_ORIGEM"] = Command.COR_SEQUENCIA_ORIGEM.Value;
if (Command.COR_SEQUENCIA_ORIGEM.HasValue) whereClauses.Add($"[COR_SEQUENCIA_ORIGEM] = @COR_SEQUENCIA_ORIGEM");
if (!string.IsNullOrEmpty(Command.ORD_ID)) dict["ORD_ID"] = $"%{Command.ORD_ID}%";
if (!string.IsNullOrEmpty(Command.ORD_ID)) whereClauses.Add($"[ORD_ID] like @ORD_ID");
if (Command.FPR_SEQ_REPETICAO.HasValue) dict["FPR_SEQ_REPETICAO"] = Command.FPR_SEQ_REPETICAO.Value;
if (Command.FPR_SEQ_REPETICAO.HasValue) whereClauses.Add($"[FPR_SEQ_REPETICAO] = @FPR_SEQ_REPETICAO");
if (Command.ROT_SEQ_TRANFORMACAO.HasValue) dict["ROT_SEQ_TRANFORMACAO"] = Command.ROT_SEQ_TRANFORMACAO.Value;
if (Command.ROT_SEQ_TRANFORMACAO.HasValue) whereClauses.Add($"[ROT_SEQ_TRANFORMACAO] = @ROT_SEQ_TRANFORMACAO");
if (Command.COR_FACAO.HasValue) dict["COR_FACAO"] = Command.COR_FACAO.Value;
if (Command.COR_FACAO.HasValue) whereClauses.Add($"[COR_FACAO] = @COR_FACAO");
if (Command.COR_FORMATO_BOBINA.HasValue) dict["COR_FORMATO_BOBINA"] = Command.COR_FORMATO_BOBINA.Value;
if (Command.COR_FORMATO_BOBINA.HasValue) whereClauses.Add($"[COR_FORMATO_BOBINA] = @COR_FORMATO_BOBINA");
if (!string.IsNullOrEmpty(Command.PRO_ID)) dict["PRO_ID"] = $"%{Command.PRO_ID}%";
if (!string.IsNullOrEmpty(Command.PRO_ID)) whereClauses.Add($"[PRO_ID] like @PRO_ID");
if (Command.COR_QTD_PLANEJADO.HasValue) dict["COR_QTD_PLANEJADO"] = Command.COR_QTD_PLANEJADO.Value;
if (Command.COR_QTD_PLANEJADO.HasValue) whereClauses.Add($"[COR_QTD_PLANEJADO] = @COR_QTD_PLANEJADO");
if (Command.PRO_QTD_PACAS.HasValue) dict["PRO_QTD_PACAS"] = Command.PRO_QTD_PACAS.Value;
if (Command.PRO_QTD_PACAS.HasValue) whereClauses.Add($"[PRO_QTD_PACAS] = @PRO_QTD_PACAS");
if (Command.COR_PECAS_LARGURA.HasValue) dict["COR_PECAS_LARGURA"] = Command.COR_PECAS_LARGURA.Value;
if (Command.COR_PECAS_LARGURA.HasValue) whereClauses.Add($"[COR_PECAS_LARGURA] = @COR_PECAS_LARGURA");
            if (whereClauses.Any()) 
                 this.Query += $" WHERE {string.Join(" AND ", whereClauses)}"; 
            int page = Command.Paginacao?.Page ?? 1;
            int pageSize = Command.Paginacao?.PageSize ?? 20;
            int offset = (page - 1) * pageSize;
            dict["Offset"] = offset;
            dict["PageSize"] = pageSize;
            Query += " ORDER BY [COR_ID] OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel CorridasOnduladeiraTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel CorridasOnduladeiraUserIdQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel ExistsByBOL_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [CorridasOnduladeira] ";
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
        public QueryModel ExistsByBOL_ID_ORIGEMQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["BOL_ID_ORIGEM"] = value; //04
                      whereClauses.Add($" [BOL_ID_ORIGEM] = @BOL_ID_ORIGEM ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_LARGURA_PECAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["PRO_LARGURA_PECA"] = value; //04
                      whereClauses.Add($" [PRO_LARGURA_PECA] = @PRO_LARGURA_PECA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_LARGURA_PECA_PROGRAMADOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["PRO_LARGURA_PECA_PROGRAMADO"] = value; //04
                      whereClauses.Add($" [PRO_LARGURA_PECA_PROGRAMADO] = @PRO_LARGURA_PECA_PROGRAMADO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_COMPRIMENTO_PECAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["PRO_COMPRIMENTO_PECA"] = value; //04
                      whereClauses.Add($" [PRO_COMPRIMENTO_PECA] = @PRO_COMPRIMENTO_PECA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_COMPRIMENTO_PECA_PROGRAMADOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["PRO_COMPRIMENTO_PECA_PROGRAMADO"] = value; //04
                      whereClauses.Add($" [PRO_COMPRIMENTO_PECA_PROGRAMADO] = @PRO_COMPRIMENTO_PECA_PROGRAMADO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_UTILIZOU_REFILE_OBRIGATORIOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["PRO_UTILIZOU_REFILE_OBRIGATORIO"] = value; //04
                      whereClauses.Add($" [PRO_UTILIZOU_REFILE_OBRIGATORIO] = @PRO_UTILIZOU_REFILE_OBRIGATORIO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_VINCOS_RECALCULADOSQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["PRO_VINCOS_RECALCULADOS"] = value; //04
                      whereClauses.Add($" [PRO_VINCOS_RECALCULADOS] = @PRO_VINCOS_RECALCULADOS ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCOR_SOLVERQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COR_SOLVER"] = value; //04
                      whereClauses.Add($" [COR_SOLVER] = @COR_SOLVER ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCOR_GRAMATURA_PAPEIS_PROGRAMADOSQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COR_GRAMATURA_PAPEIS_PROGRAMADOS"] = value; //04
                      whereClauses.Add($" [COR_GRAMATURA_PAPEIS_PROGRAMADOS] = @COR_GRAMATURA_PAPEIS_PROGRAMADOS ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCOR_CUSTO_PAPEIS_PROGRAMADOSQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COR_CUSTO_PAPEIS_PROGRAMADOS"] = value; //04
                      whereClauses.Add($" [COR_CUSTO_PAPEIS_PROGRAMADOS] = @COR_CUSTO_PAPEIS_PROGRAMADOS ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCOR_GRAMATURA_RESINA_PROGRAMADOSQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COR_GRAMATURA_RESINA_PROGRAMADOS"] = value; //04
                      whereClauses.Add($" [COR_GRAMATURA_RESINA_PROGRAMADOS] = @COR_GRAMATURA_RESINA_PROGRAMADOS ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCOR_CUSTO_RESINA_PROGRAMADOSQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COR_CUSTO_RESINA_PROGRAMADOS"] = value; //04
                      whereClauses.Add($" [COR_CUSTO_RESINA_PROGRAMADOS] = @COR_CUSTO_RESINA_PROGRAMADOS ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCOR_TOLERANCIA_MENOSQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COR_TOLERANCIA_MENOS"] = value; //04
                      whereClauses.Add($" [COR_TOLERANCIA_MENOS] = @COR_TOLERANCIA_MENOS ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCOR_TOLERANCIA_MAISQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COR_TOLERANCIA_MAIS"] = value; //04
                      whereClauses.Add($" [COR_TOLERANCIA_MAIS] = @COR_TOLERANCIA_MAIS ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCOR_PILHAS_POR_PALETEQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COR_PILHAS_POR_PALETE"] = value; //04
                      whereClauses.Add($" [COR_PILHAS_POR_PALETE] = @COR_PILHAS_POR_PALETE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCOR_COR_FILAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COR_COR_FILA"] = value; //04
                      whereClauses.Add($" [COR_COR_FILA] = @COR_COR_FILA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCOR_M_LINEAR_REALIZADOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COR_M_LINEAR_REALIZADO"] = value; //04
                      whereClauses.Add($" [COR_M_LINEAR_REALIZADO] = @COR_M_LINEAR_REALIZADO ");//04
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
            this.Query = $"SELECT 1 FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["PRO_ID_PALETE"] = value; //04
                      whereClauses.Add($" [PRO_ID_PALETE] = @PRO_ID_PALETE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCOR_STATUS_PALETEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COR_STATUS_PALETE"] = value; //04
                      whereClauses.Add($" [COR_STATUS_PALETE] = @COR_STATUS_PALETE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCOR_GRUPO_PRODUTIVOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COR_GRUPO_PRODUTIVO"] = value; //04
                      whereClauses.Add($" [COR_GRUPO_PRODUTIVO] = @COR_GRUPO_PRODUTIVO ");//04
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
            this.Query = $"SELECT 1 FROM [CorridasOnduladeira] ";
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
            this.Query = $"SELECT 1 FROM [CorridasOnduladeira] ";
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
            this.Query = $"SELECT 1 FROM [CorridasOnduladeira] ";
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
            this.Query = $"SELECT 1 FROM [CorridasOnduladeira] ";
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
        public QueryModel ExistsByCOR_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COR_ID"] = value; //04
                      whereClauses.Add($" [COR_ID] = @COR_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCOR_STATUSQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COR_STATUS"] = value; //04
                      whereClauses.Add($" [COR_STATUS] = @COR_STATUS ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCOR_STATUS_INTERFACEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COR_STATUS_INTERFACE"] = value; //04
                      whereClauses.Add($" [COR_STATUS_INTERFACE] = @COR_STATUS_INTERFACE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_ID"] = value; //04
                      whereClauses.Add($" [MAQ_ID] = @MAQ_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCOR_ID_INTERFACEQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COR_ID_INTERFACE"] = value; //04
                      whereClauses.Add($" [COR_ID_INTERFACE] = @COR_ID_INTERFACE ");//04
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
            this.Query = $"SELECT 1 FROM [CorridasOnduladeira] ";
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
        public QueryModel ExistsByCOR_SEQUENCIA_ORIGEMQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COR_SEQUENCIA_ORIGEM"] = value; //04
                      whereClauses.Add($" [COR_SEQUENCIA_ORIGEM] = @COR_SEQUENCIA_ORIGEM ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByORD_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ORD_ID"] = value; //04
                      whereClauses.Add($" [ORD_ID] = @ORD_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_SEQ_REPETICAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["FPR_SEQ_REPETICAO"] = value; //04
                      whereClauses.Add($" [FPR_SEQ_REPETICAO] = @FPR_SEQ_REPETICAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByROT_SEQ_TRANFORMACAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ROT_SEQ_TRANFORMACAO"] = value; //04
                      whereClauses.Add($" [ROT_SEQ_TRANFORMACAO] = @ROT_SEQ_TRANFORMACAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCOR_FACAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COR_FACAO"] = value; //04
                      whereClauses.Add($" [COR_FACAO] = @COR_FACAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCOR_FORMATO_BOBINAQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COR_FORMATO_BOBINA"] = value; //04
                      whereClauses.Add($" [COR_FORMATO_BOBINA] = @COR_FORMATO_BOBINA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCOR_INICIO_PREVISTOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COR_INICIO_PREVISTO"] = value; //04
                      whereClauses.Add($" [COR_INICIO_PREVISTO] = @COR_INICIO_PREVISTO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCOR_FIM_PREVISTOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COR_FIM_PREVISTO"] = value; //04
                      whereClauses.Add($" [COR_FIM_PREVISTO] = @COR_FIM_PREVISTO ");//04
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
            this.Query = $"SELECT 1 FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["PRO_ID"] = value; //04
                      whereClauses.Add($" [PRO_ID] = @PRO_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCOR_QTD_PLANEJADOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COR_QTD_PLANEJADO"] = value; //04
                      whereClauses.Add($" [COR_QTD_PLANEJADO] = @COR_QTD_PLANEJADO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_QTD_PACASQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["PRO_QTD_PACAS"] = value; //04
                      whereClauses.Add($" [PRO_QTD_PACAS] = @PRO_QTD_PACAS ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCOR_PECAS_LARGURAQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COR_PECAS_LARGURA"] = value; //04
                      whereClauses.Add($" [COR_PECAS_LARGURA] = @COR_PECAS_LARGURA ");//04
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
            this.Query = $"SELECT [BOL_ID], [BOL_ID_ORIGEM], [PRO_LARGURA_PECA], [PRO_LARGURA_PECA_PROGRAMADO], [PRO_COMPRIMENTO_PECA], [PRO_COMPRIMENTO_PECA_PROGRAMADO], [PRO_UTILIZOU_REFILE_OBRIGATORIO], [PRO_VINCOS_RECALCULADOS], [COR_SOLVER], [COR_GRAMATURA_PAPEIS_PROGRAMADOS], [COR_CUSTO_PAPEIS_PROGRAMADOS], [COR_GRAMATURA_RESINA_PROGRAMADOS], [COR_CUSTO_RESINA_PROGRAMADOS], [COR_TOLERANCIA_MENOS], [COR_TOLERANCIA_MAIS], [COR_PILHAS_POR_PALETE], [COR_COR_FILA], [COR_M_LINEAR_REALIZADO], [PRO_ID_PALETE], [COR_STATUS_PALETE], [COR_GRUPO_PRODUTIVO], [TenantID], [Deleted], [Changed], [UserId], [COR_ID], [COR_STATUS], [COR_STATUS_INTERFACE], [MAQ_ID], [COR_ID_INTERFACE], [COR_SEQUENCIA], [COR_SEQUENCIA_ORIGEM], [ORD_ID], [FPR_SEQ_REPETICAO], [ROT_SEQ_TRANFORMACAO], [COR_FACAO], [COR_FORMATO_BOBINA], [COR_INICIO_PREVISTO], [COR_FIM_PREVISTO], [PRO_ID], [COR_QTD_PLANEJADO], [PRO_QTD_PACAS], [COR_PECAS_LARGURA] FROM [CorridasOnduladeira] ";
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
        public QueryModel FirstByBOL_ID_ORIGEMQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [BOL_ID], [BOL_ID_ORIGEM], [PRO_LARGURA_PECA], [PRO_LARGURA_PECA_PROGRAMADO], [PRO_COMPRIMENTO_PECA], [PRO_COMPRIMENTO_PECA_PROGRAMADO], [PRO_UTILIZOU_REFILE_OBRIGATORIO], [PRO_VINCOS_RECALCULADOS], [COR_SOLVER], [COR_GRAMATURA_PAPEIS_PROGRAMADOS], [COR_CUSTO_PAPEIS_PROGRAMADOS], [COR_GRAMATURA_RESINA_PROGRAMADOS], [COR_CUSTO_RESINA_PROGRAMADOS], [COR_TOLERANCIA_MENOS], [COR_TOLERANCIA_MAIS], [COR_PILHAS_POR_PALETE], [COR_COR_FILA], [COR_M_LINEAR_REALIZADO], [PRO_ID_PALETE], [COR_STATUS_PALETE], [COR_GRUPO_PRODUTIVO], [TenantID], [Deleted], [Changed], [UserId], [COR_ID], [COR_STATUS], [COR_STATUS_INTERFACE], [MAQ_ID], [COR_ID_INTERFACE], [COR_SEQUENCIA], [COR_SEQUENCIA_ORIGEM], [ORD_ID], [FPR_SEQ_REPETICAO], [ROT_SEQ_TRANFORMACAO], [COR_FACAO], [COR_FORMATO_BOBINA], [COR_INICIO_PREVISTO], [COR_FIM_PREVISTO], [PRO_ID], [COR_QTD_PLANEJADO], [PRO_QTD_PACAS], [COR_PECAS_LARGURA] FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["BOL_ID_ORIGEM"] = value; //06
                      whereClauses.Add($" [BOL_ID_ORIGEM] = @BOL_ID_ORIGEM ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_LARGURA_PECAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [BOL_ID], [BOL_ID_ORIGEM], [PRO_LARGURA_PECA], [PRO_LARGURA_PECA_PROGRAMADO], [PRO_COMPRIMENTO_PECA], [PRO_COMPRIMENTO_PECA_PROGRAMADO], [PRO_UTILIZOU_REFILE_OBRIGATORIO], [PRO_VINCOS_RECALCULADOS], [COR_SOLVER], [COR_GRAMATURA_PAPEIS_PROGRAMADOS], [COR_CUSTO_PAPEIS_PROGRAMADOS], [COR_GRAMATURA_RESINA_PROGRAMADOS], [COR_CUSTO_RESINA_PROGRAMADOS], [COR_TOLERANCIA_MENOS], [COR_TOLERANCIA_MAIS], [COR_PILHAS_POR_PALETE], [COR_COR_FILA], [COR_M_LINEAR_REALIZADO], [PRO_ID_PALETE], [COR_STATUS_PALETE], [COR_GRUPO_PRODUTIVO], [TenantID], [Deleted], [Changed], [UserId], [COR_ID], [COR_STATUS], [COR_STATUS_INTERFACE], [MAQ_ID], [COR_ID_INTERFACE], [COR_SEQUENCIA], [COR_SEQUENCIA_ORIGEM], [ORD_ID], [FPR_SEQ_REPETICAO], [ROT_SEQ_TRANFORMACAO], [COR_FACAO], [COR_FORMATO_BOBINA], [COR_INICIO_PREVISTO], [COR_FIM_PREVISTO], [PRO_ID], [COR_QTD_PLANEJADO], [PRO_QTD_PACAS], [COR_PECAS_LARGURA] FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["PRO_LARGURA_PECA"] = value; //06
                      whereClauses.Add($" [PRO_LARGURA_PECA] = @PRO_LARGURA_PECA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_LARGURA_PECA_PROGRAMADOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [BOL_ID], [BOL_ID_ORIGEM], [PRO_LARGURA_PECA], [PRO_LARGURA_PECA_PROGRAMADO], [PRO_COMPRIMENTO_PECA], [PRO_COMPRIMENTO_PECA_PROGRAMADO], [PRO_UTILIZOU_REFILE_OBRIGATORIO], [PRO_VINCOS_RECALCULADOS], [COR_SOLVER], [COR_GRAMATURA_PAPEIS_PROGRAMADOS], [COR_CUSTO_PAPEIS_PROGRAMADOS], [COR_GRAMATURA_RESINA_PROGRAMADOS], [COR_CUSTO_RESINA_PROGRAMADOS], [COR_TOLERANCIA_MENOS], [COR_TOLERANCIA_MAIS], [COR_PILHAS_POR_PALETE], [COR_COR_FILA], [COR_M_LINEAR_REALIZADO], [PRO_ID_PALETE], [COR_STATUS_PALETE], [COR_GRUPO_PRODUTIVO], [TenantID], [Deleted], [Changed], [UserId], [COR_ID], [COR_STATUS], [COR_STATUS_INTERFACE], [MAQ_ID], [COR_ID_INTERFACE], [COR_SEQUENCIA], [COR_SEQUENCIA_ORIGEM], [ORD_ID], [FPR_SEQ_REPETICAO], [ROT_SEQ_TRANFORMACAO], [COR_FACAO], [COR_FORMATO_BOBINA], [COR_INICIO_PREVISTO], [COR_FIM_PREVISTO], [PRO_ID], [COR_QTD_PLANEJADO], [PRO_QTD_PACAS], [COR_PECAS_LARGURA] FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["PRO_LARGURA_PECA_PROGRAMADO"] = value; //06
                      whereClauses.Add($" [PRO_LARGURA_PECA_PROGRAMADO] = @PRO_LARGURA_PECA_PROGRAMADO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_COMPRIMENTO_PECAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [BOL_ID], [BOL_ID_ORIGEM], [PRO_LARGURA_PECA], [PRO_LARGURA_PECA_PROGRAMADO], [PRO_COMPRIMENTO_PECA], [PRO_COMPRIMENTO_PECA_PROGRAMADO], [PRO_UTILIZOU_REFILE_OBRIGATORIO], [PRO_VINCOS_RECALCULADOS], [COR_SOLVER], [COR_GRAMATURA_PAPEIS_PROGRAMADOS], [COR_CUSTO_PAPEIS_PROGRAMADOS], [COR_GRAMATURA_RESINA_PROGRAMADOS], [COR_CUSTO_RESINA_PROGRAMADOS], [COR_TOLERANCIA_MENOS], [COR_TOLERANCIA_MAIS], [COR_PILHAS_POR_PALETE], [COR_COR_FILA], [COR_M_LINEAR_REALIZADO], [PRO_ID_PALETE], [COR_STATUS_PALETE], [COR_GRUPO_PRODUTIVO], [TenantID], [Deleted], [Changed], [UserId], [COR_ID], [COR_STATUS], [COR_STATUS_INTERFACE], [MAQ_ID], [COR_ID_INTERFACE], [COR_SEQUENCIA], [COR_SEQUENCIA_ORIGEM], [ORD_ID], [FPR_SEQ_REPETICAO], [ROT_SEQ_TRANFORMACAO], [COR_FACAO], [COR_FORMATO_BOBINA], [COR_INICIO_PREVISTO], [COR_FIM_PREVISTO], [PRO_ID], [COR_QTD_PLANEJADO], [PRO_QTD_PACAS], [COR_PECAS_LARGURA] FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["PRO_COMPRIMENTO_PECA"] = value; //06
                      whereClauses.Add($" [PRO_COMPRIMENTO_PECA] = @PRO_COMPRIMENTO_PECA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_COMPRIMENTO_PECA_PROGRAMADOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [BOL_ID], [BOL_ID_ORIGEM], [PRO_LARGURA_PECA], [PRO_LARGURA_PECA_PROGRAMADO], [PRO_COMPRIMENTO_PECA], [PRO_COMPRIMENTO_PECA_PROGRAMADO], [PRO_UTILIZOU_REFILE_OBRIGATORIO], [PRO_VINCOS_RECALCULADOS], [COR_SOLVER], [COR_GRAMATURA_PAPEIS_PROGRAMADOS], [COR_CUSTO_PAPEIS_PROGRAMADOS], [COR_GRAMATURA_RESINA_PROGRAMADOS], [COR_CUSTO_RESINA_PROGRAMADOS], [COR_TOLERANCIA_MENOS], [COR_TOLERANCIA_MAIS], [COR_PILHAS_POR_PALETE], [COR_COR_FILA], [COR_M_LINEAR_REALIZADO], [PRO_ID_PALETE], [COR_STATUS_PALETE], [COR_GRUPO_PRODUTIVO], [TenantID], [Deleted], [Changed], [UserId], [COR_ID], [COR_STATUS], [COR_STATUS_INTERFACE], [MAQ_ID], [COR_ID_INTERFACE], [COR_SEQUENCIA], [COR_SEQUENCIA_ORIGEM], [ORD_ID], [FPR_SEQ_REPETICAO], [ROT_SEQ_TRANFORMACAO], [COR_FACAO], [COR_FORMATO_BOBINA], [COR_INICIO_PREVISTO], [COR_FIM_PREVISTO], [PRO_ID], [COR_QTD_PLANEJADO], [PRO_QTD_PACAS], [COR_PECAS_LARGURA] FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["PRO_COMPRIMENTO_PECA_PROGRAMADO"] = value; //06
                      whereClauses.Add($" [PRO_COMPRIMENTO_PECA_PROGRAMADO] = @PRO_COMPRIMENTO_PECA_PROGRAMADO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_UTILIZOU_REFILE_OBRIGATORIOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [BOL_ID], [BOL_ID_ORIGEM], [PRO_LARGURA_PECA], [PRO_LARGURA_PECA_PROGRAMADO], [PRO_COMPRIMENTO_PECA], [PRO_COMPRIMENTO_PECA_PROGRAMADO], [PRO_UTILIZOU_REFILE_OBRIGATORIO], [PRO_VINCOS_RECALCULADOS], [COR_SOLVER], [COR_GRAMATURA_PAPEIS_PROGRAMADOS], [COR_CUSTO_PAPEIS_PROGRAMADOS], [COR_GRAMATURA_RESINA_PROGRAMADOS], [COR_CUSTO_RESINA_PROGRAMADOS], [COR_TOLERANCIA_MENOS], [COR_TOLERANCIA_MAIS], [COR_PILHAS_POR_PALETE], [COR_COR_FILA], [COR_M_LINEAR_REALIZADO], [PRO_ID_PALETE], [COR_STATUS_PALETE], [COR_GRUPO_PRODUTIVO], [TenantID], [Deleted], [Changed], [UserId], [COR_ID], [COR_STATUS], [COR_STATUS_INTERFACE], [MAQ_ID], [COR_ID_INTERFACE], [COR_SEQUENCIA], [COR_SEQUENCIA_ORIGEM], [ORD_ID], [FPR_SEQ_REPETICAO], [ROT_SEQ_TRANFORMACAO], [COR_FACAO], [COR_FORMATO_BOBINA], [COR_INICIO_PREVISTO], [COR_FIM_PREVISTO], [PRO_ID], [COR_QTD_PLANEJADO], [PRO_QTD_PACAS], [COR_PECAS_LARGURA] FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["PRO_UTILIZOU_REFILE_OBRIGATORIO"] = value; //06
                      whereClauses.Add($" [PRO_UTILIZOU_REFILE_OBRIGATORIO] = @PRO_UTILIZOU_REFILE_OBRIGATORIO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_VINCOS_RECALCULADOSQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [BOL_ID], [BOL_ID_ORIGEM], [PRO_LARGURA_PECA], [PRO_LARGURA_PECA_PROGRAMADO], [PRO_COMPRIMENTO_PECA], [PRO_COMPRIMENTO_PECA_PROGRAMADO], [PRO_UTILIZOU_REFILE_OBRIGATORIO], [PRO_VINCOS_RECALCULADOS], [COR_SOLVER], [COR_GRAMATURA_PAPEIS_PROGRAMADOS], [COR_CUSTO_PAPEIS_PROGRAMADOS], [COR_GRAMATURA_RESINA_PROGRAMADOS], [COR_CUSTO_RESINA_PROGRAMADOS], [COR_TOLERANCIA_MENOS], [COR_TOLERANCIA_MAIS], [COR_PILHAS_POR_PALETE], [COR_COR_FILA], [COR_M_LINEAR_REALIZADO], [PRO_ID_PALETE], [COR_STATUS_PALETE], [COR_GRUPO_PRODUTIVO], [TenantID], [Deleted], [Changed], [UserId], [COR_ID], [COR_STATUS], [COR_STATUS_INTERFACE], [MAQ_ID], [COR_ID_INTERFACE], [COR_SEQUENCIA], [COR_SEQUENCIA_ORIGEM], [ORD_ID], [FPR_SEQ_REPETICAO], [ROT_SEQ_TRANFORMACAO], [COR_FACAO], [COR_FORMATO_BOBINA], [COR_INICIO_PREVISTO], [COR_FIM_PREVISTO], [PRO_ID], [COR_QTD_PLANEJADO], [PRO_QTD_PACAS], [COR_PECAS_LARGURA] FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["PRO_VINCOS_RECALCULADOS"] = value; //06
                      whereClauses.Add($" [PRO_VINCOS_RECALCULADOS] = @PRO_VINCOS_RECALCULADOS ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCOR_SOLVERQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [BOL_ID], [BOL_ID_ORIGEM], [PRO_LARGURA_PECA], [PRO_LARGURA_PECA_PROGRAMADO], [PRO_COMPRIMENTO_PECA], [PRO_COMPRIMENTO_PECA_PROGRAMADO], [PRO_UTILIZOU_REFILE_OBRIGATORIO], [PRO_VINCOS_RECALCULADOS], [COR_SOLVER], [COR_GRAMATURA_PAPEIS_PROGRAMADOS], [COR_CUSTO_PAPEIS_PROGRAMADOS], [COR_GRAMATURA_RESINA_PROGRAMADOS], [COR_CUSTO_RESINA_PROGRAMADOS], [COR_TOLERANCIA_MENOS], [COR_TOLERANCIA_MAIS], [COR_PILHAS_POR_PALETE], [COR_COR_FILA], [COR_M_LINEAR_REALIZADO], [PRO_ID_PALETE], [COR_STATUS_PALETE], [COR_GRUPO_PRODUTIVO], [TenantID], [Deleted], [Changed], [UserId], [COR_ID], [COR_STATUS], [COR_STATUS_INTERFACE], [MAQ_ID], [COR_ID_INTERFACE], [COR_SEQUENCIA], [COR_SEQUENCIA_ORIGEM], [ORD_ID], [FPR_SEQ_REPETICAO], [ROT_SEQ_TRANFORMACAO], [COR_FACAO], [COR_FORMATO_BOBINA], [COR_INICIO_PREVISTO], [COR_FIM_PREVISTO], [PRO_ID], [COR_QTD_PLANEJADO], [PRO_QTD_PACAS], [COR_PECAS_LARGURA] FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COR_SOLVER"] = value; //06
                      whereClauses.Add($" [COR_SOLVER] = @COR_SOLVER ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCOR_GRAMATURA_PAPEIS_PROGRAMADOSQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [BOL_ID], [BOL_ID_ORIGEM], [PRO_LARGURA_PECA], [PRO_LARGURA_PECA_PROGRAMADO], [PRO_COMPRIMENTO_PECA], [PRO_COMPRIMENTO_PECA_PROGRAMADO], [PRO_UTILIZOU_REFILE_OBRIGATORIO], [PRO_VINCOS_RECALCULADOS], [COR_SOLVER], [COR_GRAMATURA_PAPEIS_PROGRAMADOS], [COR_CUSTO_PAPEIS_PROGRAMADOS], [COR_GRAMATURA_RESINA_PROGRAMADOS], [COR_CUSTO_RESINA_PROGRAMADOS], [COR_TOLERANCIA_MENOS], [COR_TOLERANCIA_MAIS], [COR_PILHAS_POR_PALETE], [COR_COR_FILA], [COR_M_LINEAR_REALIZADO], [PRO_ID_PALETE], [COR_STATUS_PALETE], [COR_GRUPO_PRODUTIVO], [TenantID], [Deleted], [Changed], [UserId], [COR_ID], [COR_STATUS], [COR_STATUS_INTERFACE], [MAQ_ID], [COR_ID_INTERFACE], [COR_SEQUENCIA], [COR_SEQUENCIA_ORIGEM], [ORD_ID], [FPR_SEQ_REPETICAO], [ROT_SEQ_TRANFORMACAO], [COR_FACAO], [COR_FORMATO_BOBINA], [COR_INICIO_PREVISTO], [COR_FIM_PREVISTO], [PRO_ID], [COR_QTD_PLANEJADO], [PRO_QTD_PACAS], [COR_PECAS_LARGURA] FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COR_GRAMATURA_PAPEIS_PROGRAMADOS"] = value; //06
                      whereClauses.Add($" [COR_GRAMATURA_PAPEIS_PROGRAMADOS] = @COR_GRAMATURA_PAPEIS_PROGRAMADOS ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCOR_CUSTO_PAPEIS_PROGRAMADOSQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [BOL_ID], [BOL_ID_ORIGEM], [PRO_LARGURA_PECA], [PRO_LARGURA_PECA_PROGRAMADO], [PRO_COMPRIMENTO_PECA], [PRO_COMPRIMENTO_PECA_PROGRAMADO], [PRO_UTILIZOU_REFILE_OBRIGATORIO], [PRO_VINCOS_RECALCULADOS], [COR_SOLVER], [COR_GRAMATURA_PAPEIS_PROGRAMADOS], [COR_CUSTO_PAPEIS_PROGRAMADOS], [COR_GRAMATURA_RESINA_PROGRAMADOS], [COR_CUSTO_RESINA_PROGRAMADOS], [COR_TOLERANCIA_MENOS], [COR_TOLERANCIA_MAIS], [COR_PILHAS_POR_PALETE], [COR_COR_FILA], [COR_M_LINEAR_REALIZADO], [PRO_ID_PALETE], [COR_STATUS_PALETE], [COR_GRUPO_PRODUTIVO], [TenantID], [Deleted], [Changed], [UserId], [COR_ID], [COR_STATUS], [COR_STATUS_INTERFACE], [MAQ_ID], [COR_ID_INTERFACE], [COR_SEQUENCIA], [COR_SEQUENCIA_ORIGEM], [ORD_ID], [FPR_SEQ_REPETICAO], [ROT_SEQ_TRANFORMACAO], [COR_FACAO], [COR_FORMATO_BOBINA], [COR_INICIO_PREVISTO], [COR_FIM_PREVISTO], [PRO_ID], [COR_QTD_PLANEJADO], [PRO_QTD_PACAS], [COR_PECAS_LARGURA] FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COR_CUSTO_PAPEIS_PROGRAMADOS"] = value; //06
                      whereClauses.Add($" [COR_CUSTO_PAPEIS_PROGRAMADOS] = @COR_CUSTO_PAPEIS_PROGRAMADOS ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCOR_GRAMATURA_RESINA_PROGRAMADOSQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [BOL_ID], [BOL_ID_ORIGEM], [PRO_LARGURA_PECA], [PRO_LARGURA_PECA_PROGRAMADO], [PRO_COMPRIMENTO_PECA], [PRO_COMPRIMENTO_PECA_PROGRAMADO], [PRO_UTILIZOU_REFILE_OBRIGATORIO], [PRO_VINCOS_RECALCULADOS], [COR_SOLVER], [COR_GRAMATURA_PAPEIS_PROGRAMADOS], [COR_CUSTO_PAPEIS_PROGRAMADOS], [COR_GRAMATURA_RESINA_PROGRAMADOS], [COR_CUSTO_RESINA_PROGRAMADOS], [COR_TOLERANCIA_MENOS], [COR_TOLERANCIA_MAIS], [COR_PILHAS_POR_PALETE], [COR_COR_FILA], [COR_M_LINEAR_REALIZADO], [PRO_ID_PALETE], [COR_STATUS_PALETE], [COR_GRUPO_PRODUTIVO], [TenantID], [Deleted], [Changed], [UserId], [COR_ID], [COR_STATUS], [COR_STATUS_INTERFACE], [MAQ_ID], [COR_ID_INTERFACE], [COR_SEQUENCIA], [COR_SEQUENCIA_ORIGEM], [ORD_ID], [FPR_SEQ_REPETICAO], [ROT_SEQ_TRANFORMACAO], [COR_FACAO], [COR_FORMATO_BOBINA], [COR_INICIO_PREVISTO], [COR_FIM_PREVISTO], [PRO_ID], [COR_QTD_PLANEJADO], [PRO_QTD_PACAS], [COR_PECAS_LARGURA] FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COR_GRAMATURA_RESINA_PROGRAMADOS"] = value; //06
                      whereClauses.Add($" [COR_GRAMATURA_RESINA_PROGRAMADOS] = @COR_GRAMATURA_RESINA_PROGRAMADOS ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCOR_CUSTO_RESINA_PROGRAMADOSQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [BOL_ID], [BOL_ID_ORIGEM], [PRO_LARGURA_PECA], [PRO_LARGURA_PECA_PROGRAMADO], [PRO_COMPRIMENTO_PECA], [PRO_COMPRIMENTO_PECA_PROGRAMADO], [PRO_UTILIZOU_REFILE_OBRIGATORIO], [PRO_VINCOS_RECALCULADOS], [COR_SOLVER], [COR_GRAMATURA_PAPEIS_PROGRAMADOS], [COR_CUSTO_PAPEIS_PROGRAMADOS], [COR_GRAMATURA_RESINA_PROGRAMADOS], [COR_CUSTO_RESINA_PROGRAMADOS], [COR_TOLERANCIA_MENOS], [COR_TOLERANCIA_MAIS], [COR_PILHAS_POR_PALETE], [COR_COR_FILA], [COR_M_LINEAR_REALIZADO], [PRO_ID_PALETE], [COR_STATUS_PALETE], [COR_GRUPO_PRODUTIVO], [TenantID], [Deleted], [Changed], [UserId], [COR_ID], [COR_STATUS], [COR_STATUS_INTERFACE], [MAQ_ID], [COR_ID_INTERFACE], [COR_SEQUENCIA], [COR_SEQUENCIA_ORIGEM], [ORD_ID], [FPR_SEQ_REPETICAO], [ROT_SEQ_TRANFORMACAO], [COR_FACAO], [COR_FORMATO_BOBINA], [COR_INICIO_PREVISTO], [COR_FIM_PREVISTO], [PRO_ID], [COR_QTD_PLANEJADO], [PRO_QTD_PACAS], [COR_PECAS_LARGURA] FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COR_CUSTO_RESINA_PROGRAMADOS"] = value; //06
                      whereClauses.Add($" [COR_CUSTO_RESINA_PROGRAMADOS] = @COR_CUSTO_RESINA_PROGRAMADOS ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCOR_TOLERANCIA_MENOSQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [BOL_ID], [BOL_ID_ORIGEM], [PRO_LARGURA_PECA], [PRO_LARGURA_PECA_PROGRAMADO], [PRO_COMPRIMENTO_PECA], [PRO_COMPRIMENTO_PECA_PROGRAMADO], [PRO_UTILIZOU_REFILE_OBRIGATORIO], [PRO_VINCOS_RECALCULADOS], [COR_SOLVER], [COR_GRAMATURA_PAPEIS_PROGRAMADOS], [COR_CUSTO_PAPEIS_PROGRAMADOS], [COR_GRAMATURA_RESINA_PROGRAMADOS], [COR_CUSTO_RESINA_PROGRAMADOS], [COR_TOLERANCIA_MENOS], [COR_TOLERANCIA_MAIS], [COR_PILHAS_POR_PALETE], [COR_COR_FILA], [COR_M_LINEAR_REALIZADO], [PRO_ID_PALETE], [COR_STATUS_PALETE], [COR_GRUPO_PRODUTIVO], [TenantID], [Deleted], [Changed], [UserId], [COR_ID], [COR_STATUS], [COR_STATUS_INTERFACE], [MAQ_ID], [COR_ID_INTERFACE], [COR_SEQUENCIA], [COR_SEQUENCIA_ORIGEM], [ORD_ID], [FPR_SEQ_REPETICAO], [ROT_SEQ_TRANFORMACAO], [COR_FACAO], [COR_FORMATO_BOBINA], [COR_INICIO_PREVISTO], [COR_FIM_PREVISTO], [PRO_ID], [COR_QTD_PLANEJADO], [PRO_QTD_PACAS], [COR_PECAS_LARGURA] FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COR_TOLERANCIA_MENOS"] = value; //06
                      whereClauses.Add($" [COR_TOLERANCIA_MENOS] = @COR_TOLERANCIA_MENOS ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCOR_TOLERANCIA_MAISQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [BOL_ID], [BOL_ID_ORIGEM], [PRO_LARGURA_PECA], [PRO_LARGURA_PECA_PROGRAMADO], [PRO_COMPRIMENTO_PECA], [PRO_COMPRIMENTO_PECA_PROGRAMADO], [PRO_UTILIZOU_REFILE_OBRIGATORIO], [PRO_VINCOS_RECALCULADOS], [COR_SOLVER], [COR_GRAMATURA_PAPEIS_PROGRAMADOS], [COR_CUSTO_PAPEIS_PROGRAMADOS], [COR_GRAMATURA_RESINA_PROGRAMADOS], [COR_CUSTO_RESINA_PROGRAMADOS], [COR_TOLERANCIA_MENOS], [COR_TOLERANCIA_MAIS], [COR_PILHAS_POR_PALETE], [COR_COR_FILA], [COR_M_LINEAR_REALIZADO], [PRO_ID_PALETE], [COR_STATUS_PALETE], [COR_GRUPO_PRODUTIVO], [TenantID], [Deleted], [Changed], [UserId], [COR_ID], [COR_STATUS], [COR_STATUS_INTERFACE], [MAQ_ID], [COR_ID_INTERFACE], [COR_SEQUENCIA], [COR_SEQUENCIA_ORIGEM], [ORD_ID], [FPR_SEQ_REPETICAO], [ROT_SEQ_TRANFORMACAO], [COR_FACAO], [COR_FORMATO_BOBINA], [COR_INICIO_PREVISTO], [COR_FIM_PREVISTO], [PRO_ID], [COR_QTD_PLANEJADO], [PRO_QTD_PACAS], [COR_PECAS_LARGURA] FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COR_TOLERANCIA_MAIS"] = value; //06
                      whereClauses.Add($" [COR_TOLERANCIA_MAIS] = @COR_TOLERANCIA_MAIS ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCOR_PILHAS_POR_PALETEQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [BOL_ID], [BOL_ID_ORIGEM], [PRO_LARGURA_PECA], [PRO_LARGURA_PECA_PROGRAMADO], [PRO_COMPRIMENTO_PECA], [PRO_COMPRIMENTO_PECA_PROGRAMADO], [PRO_UTILIZOU_REFILE_OBRIGATORIO], [PRO_VINCOS_RECALCULADOS], [COR_SOLVER], [COR_GRAMATURA_PAPEIS_PROGRAMADOS], [COR_CUSTO_PAPEIS_PROGRAMADOS], [COR_GRAMATURA_RESINA_PROGRAMADOS], [COR_CUSTO_RESINA_PROGRAMADOS], [COR_TOLERANCIA_MENOS], [COR_TOLERANCIA_MAIS], [COR_PILHAS_POR_PALETE], [COR_COR_FILA], [COR_M_LINEAR_REALIZADO], [PRO_ID_PALETE], [COR_STATUS_PALETE], [COR_GRUPO_PRODUTIVO], [TenantID], [Deleted], [Changed], [UserId], [COR_ID], [COR_STATUS], [COR_STATUS_INTERFACE], [MAQ_ID], [COR_ID_INTERFACE], [COR_SEQUENCIA], [COR_SEQUENCIA_ORIGEM], [ORD_ID], [FPR_SEQ_REPETICAO], [ROT_SEQ_TRANFORMACAO], [COR_FACAO], [COR_FORMATO_BOBINA], [COR_INICIO_PREVISTO], [COR_FIM_PREVISTO], [PRO_ID], [COR_QTD_PLANEJADO], [PRO_QTD_PACAS], [COR_PECAS_LARGURA] FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COR_PILHAS_POR_PALETE"] = value; //06
                      whereClauses.Add($" [COR_PILHAS_POR_PALETE] = @COR_PILHAS_POR_PALETE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCOR_COR_FILAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [BOL_ID], [BOL_ID_ORIGEM], [PRO_LARGURA_PECA], [PRO_LARGURA_PECA_PROGRAMADO], [PRO_COMPRIMENTO_PECA], [PRO_COMPRIMENTO_PECA_PROGRAMADO], [PRO_UTILIZOU_REFILE_OBRIGATORIO], [PRO_VINCOS_RECALCULADOS], [COR_SOLVER], [COR_GRAMATURA_PAPEIS_PROGRAMADOS], [COR_CUSTO_PAPEIS_PROGRAMADOS], [COR_GRAMATURA_RESINA_PROGRAMADOS], [COR_CUSTO_RESINA_PROGRAMADOS], [COR_TOLERANCIA_MENOS], [COR_TOLERANCIA_MAIS], [COR_PILHAS_POR_PALETE], [COR_COR_FILA], [COR_M_LINEAR_REALIZADO], [PRO_ID_PALETE], [COR_STATUS_PALETE], [COR_GRUPO_PRODUTIVO], [TenantID], [Deleted], [Changed], [UserId], [COR_ID], [COR_STATUS], [COR_STATUS_INTERFACE], [MAQ_ID], [COR_ID_INTERFACE], [COR_SEQUENCIA], [COR_SEQUENCIA_ORIGEM], [ORD_ID], [FPR_SEQ_REPETICAO], [ROT_SEQ_TRANFORMACAO], [COR_FACAO], [COR_FORMATO_BOBINA], [COR_INICIO_PREVISTO], [COR_FIM_PREVISTO], [PRO_ID], [COR_QTD_PLANEJADO], [PRO_QTD_PACAS], [COR_PECAS_LARGURA] FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COR_COR_FILA"] = value; //06
                      whereClauses.Add($" [COR_COR_FILA] = @COR_COR_FILA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCOR_M_LINEAR_REALIZADOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [BOL_ID], [BOL_ID_ORIGEM], [PRO_LARGURA_PECA], [PRO_LARGURA_PECA_PROGRAMADO], [PRO_COMPRIMENTO_PECA], [PRO_COMPRIMENTO_PECA_PROGRAMADO], [PRO_UTILIZOU_REFILE_OBRIGATORIO], [PRO_VINCOS_RECALCULADOS], [COR_SOLVER], [COR_GRAMATURA_PAPEIS_PROGRAMADOS], [COR_CUSTO_PAPEIS_PROGRAMADOS], [COR_GRAMATURA_RESINA_PROGRAMADOS], [COR_CUSTO_RESINA_PROGRAMADOS], [COR_TOLERANCIA_MENOS], [COR_TOLERANCIA_MAIS], [COR_PILHAS_POR_PALETE], [COR_COR_FILA], [COR_M_LINEAR_REALIZADO], [PRO_ID_PALETE], [COR_STATUS_PALETE], [COR_GRUPO_PRODUTIVO], [TenantID], [Deleted], [Changed], [UserId], [COR_ID], [COR_STATUS], [COR_STATUS_INTERFACE], [MAQ_ID], [COR_ID_INTERFACE], [COR_SEQUENCIA], [COR_SEQUENCIA_ORIGEM], [ORD_ID], [FPR_SEQ_REPETICAO], [ROT_SEQ_TRANFORMACAO], [COR_FACAO], [COR_FORMATO_BOBINA], [COR_INICIO_PREVISTO], [COR_FIM_PREVISTO], [PRO_ID], [COR_QTD_PLANEJADO], [PRO_QTD_PACAS], [COR_PECAS_LARGURA] FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COR_M_LINEAR_REALIZADO"] = value; //06
                      whereClauses.Add($" [COR_M_LINEAR_REALIZADO] = @COR_M_LINEAR_REALIZADO ");//06
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
            this.Query = $"SELECT [BOL_ID], [BOL_ID_ORIGEM], [PRO_LARGURA_PECA], [PRO_LARGURA_PECA_PROGRAMADO], [PRO_COMPRIMENTO_PECA], [PRO_COMPRIMENTO_PECA_PROGRAMADO], [PRO_UTILIZOU_REFILE_OBRIGATORIO], [PRO_VINCOS_RECALCULADOS], [COR_SOLVER], [COR_GRAMATURA_PAPEIS_PROGRAMADOS], [COR_CUSTO_PAPEIS_PROGRAMADOS], [COR_GRAMATURA_RESINA_PROGRAMADOS], [COR_CUSTO_RESINA_PROGRAMADOS], [COR_TOLERANCIA_MENOS], [COR_TOLERANCIA_MAIS], [COR_PILHAS_POR_PALETE], [COR_COR_FILA], [COR_M_LINEAR_REALIZADO], [PRO_ID_PALETE], [COR_STATUS_PALETE], [COR_GRUPO_PRODUTIVO], [TenantID], [Deleted], [Changed], [UserId], [COR_ID], [COR_STATUS], [COR_STATUS_INTERFACE], [MAQ_ID], [COR_ID_INTERFACE], [COR_SEQUENCIA], [COR_SEQUENCIA_ORIGEM], [ORD_ID], [FPR_SEQ_REPETICAO], [ROT_SEQ_TRANFORMACAO], [COR_FACAO], [COR_FORMATO_BOBINA], [COR_INICIO_PREVISTO], [COR_FIM_PREVISTO], [PRO_ID], [COR_QTD_PLANEJADO], [PRO_QTD_PACAS], [COR_PECAS_LARGURA] FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["PRO_ID_PALETE"] = value; //06
                      whereClauses.Add($" [PRO_ID_PALETE] = @PRO_ID_PALETE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCOR_STATUS_PALETEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [BOL_ID], [BOL_ID_ORIGEM], [PRO_LARGURA_PECA], [PRO_LARGURA_PECA_PROGRAMADO], [PRO_COMPRIMENTO_PECA], [PRO_COMPRIMENTO_PECA_PROGRAMADO], [PRO_UTILIZOU_REFILE_OBRIGATORIO], [PRO_VINCOS_RECALCULADOS], [COR_SOLVER], [COR_GRAMATURA_PAPEIS_PROGRAMADOS], [COR_CUSTO_PAPEIS_PROGRAMADOS], [COR_GRAMATURA_RESINA_PROGRAMADOS], [COR_CUSTO_RESINA_PROGRAMADOS], [COR_TOLERANCIA_MENOS], [COR_TOLERANCIA_MAIS], [COR_PILHAS_POR_PALETE], [COR_COR_FILA], [COR_M_LINEAR_REALIZADO], [PRO_ID_PALETE], [COR_STATUS_PALETE], [COR_GRUPO_PRODUTIVO], [TenantID], [Deleted], [Changed], [UserId], [COR_ID], [COR_STATUS], [COR_STATUS_INTERFACE], [MAQ_ID], [COR_ID_INTERFACE], [COR_SEQUENCIA], [COR_SEQUENCIA_ORIGEM], [ORD_ID], [FPR_SEQ_REPETICAO], [ROT_SEQ_TRANFORMACAO], [COR_FACAO], [COR_FORMATO_BOBINA], [COR_INICIO_PREVISTO], [COR_FIM_PREVISTO], [PRO_ID], [COR_QTD_PLANEJADO], [PRO_QTD_PACAS], [COR_PECAS_LARGURA] FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COR_STATUS_PALETE"] = value; //06
                      whereClauses.Add($" [COR_STATUS_PALETE] = @COR_STATUS_PALETE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCOR_GRUPO_PRODUTIVOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [BOL_ID], [BOL_ID_ORIGEM], [PRO_LARGURA_PECA], [PRO_LARGURA_PECA_PROGRAMADO], [PRO_COMPRIMENTO_PECA], [PRO_COMPRIMENTO_PECA_PROGRAMADO], [PRO_UTILIZOU_REFILE_OBRIGATORIO], [PRO_VINCOS_RECALCULADOS], [COR_SOLVER], [COR_GRAMATURA_PAPEIS_PROGRAMADOS], [COR_CUSTO_PAPEIS_PROGRAMADOS], [COR_GRAMATURA_RESINA_PROGRAMADOS], [COR_CUSTO_RESINA_PROGRAMADOS], [COR_TOLERANCIA_MENOS], [COR_TOLERANCIA_MAIS], [COR_PILHAS_POR_PALETE], [COR_COR_FILA], [COR_M_LINEAR_REALIZADO], [PRO_ID_PALETE], [COR_STATUS_PALETE], [COR_GRUPO_PRODUTIVO], [TenantID], [Deleted], [Changed], [UserId], [COR_ID], [COR_STATUS], [COR_STATUS_INTERFACE], [MAQ_ID], [COR_ID_INTERFACE], [COR_SEQUENCIA], [COR_SEQUENCIA_ORIGEM], [ORD_ID], [FPR_SEQ_REPETICAO], [ROT_SEQ_TRANFORMACAO], [COR_FACAO], [COR_FORMATO_BOBINA], [COR_INICIO_PREVISTO], [COR_FIM_PREVISTO], [PRO_ID], [COR_QTD_PLANEJADO], [PRO_QTD_PACAS], [COR_PECAS_LARGURA] FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COR_GRUPO_PRODUTIVO"] = value; //06
                      whereClauses.Add($" [COR_GRUPO_PRODUTIVO] = @COR_GRUPO_PRODUTIVO ");//06
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
            this.Query = $"SELECT [BOL_ID], [BOL_ID_ORIGEM], [PRO_LARGURA_PECA], [PRO_LARGURA_PECA_PROGRAMADO], [PRO_COMPRIMENTO_PECA], [PRO_COMPRIMENTO_PECA_PROGRAMADO], [PRO_UTILIZOU_REFILE_OBRIGATORIO], [PRO_VINCOS_RECALCULADOS], [COR_SOLVER], [COR_GRAMATURA_PAPEIS_PROGRAMADOS], [COR_CUSTO_PAPEIS_PROGRAMADOS], [COR_GRAMATURA_RESINA_PROGRAMADOS], [COR_CUSTO_RESINA_PROGRAMADOS], [COR_TOLERANCIA_MENOS], [COR_TOLERANCIA_MAIS], [COR_PILHAS_POR_PALETE], [COR_COR_FILA], [COR_M_LINEAR_REALIZADO], [PRO_ID_PALETE], [COR_STATUS_PALETE], [COR_GRUPO_PRODUTIVO], [TenantID], [Deleted], [Changed], [UserId], [COR_ID], [COR_STATUS], [COR_STATUS_INTERFACE], [MAQ_ID], [COR_ID_INTERFACE], [COR_SEQUENCIA], [COR_SEQUENCIA_ORIGEM], [ORD_ID], [FPR_SEQ_REPETICAO], [ROT_SEQ_TRANFORMACAO], [COR_FACAO], [COR_FORMATO_BOBINA], [COR_INICIO_PREVISTO], [COR_FIM_PREVISTO], [PRO_ID], [COR_QTD_PLANEJADO], [PRO_QTD_PACAS], [COR_PECAS_LARGURA] FROM [CorridasOnduladeira] ";
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
            this.Query = $"SELECT [BOL_ID], [BOL_ID_ORIGEM], [PRO_LARGURA_PECA], [PRO_LARGURA_PECA_PROGRAMADO], [PRO_COMPRIMENTO_PECA], [PRO_COMPRIMENTO_PECA_PROGRAMADO], [PRO_UTILIZOU_REFILE_OBRIGATORIO], [PRO_VINCOS_RECALCULADOS], [COR_SOLVER], [COR_GRAMATURA_PAPEIS_PROGRAMADOS], [COR_CUSTO_PAPEIS_PROGRAMADOS], [COR_GRAMATURA_RESINA_PROGRAMADOS], [COR_CUSTO_RESINA_PROGRAMADOS], [COR_TOLERANCIA_MENOS], [COR_TOLERANCIA_MAIS], [COR_PILHAS_POR_PALETE], [COR_COR_FILA], [COR_M_LINEAR_REALIZADO], [PRO_ID_PALETE], [COR_STATUS_PALETE], [COR_GRUPO_PRODUTIVO], [TenantID], [Deleted], [Changed], [UserId], [COR_ID], [COR_STATUS], [COR_STATUS_INTERFACE], [MAQ_ID], [COR_ID_INTERFACE], [COR_SEQUENCIA], [COR_SEQUENCIA_ORIGEM], [ORD_ID], [FPR_SEQ_REPETICAO], [ROT_SEQ_TRANFORMACAO], [COR_FACAO], [COR_FORMATO_BOBINA], [COR_INICIO_PREVISTO], [COR_FIM_PREVISTO], [PRO_ID], [COR_QTD_PLANEJADO], [PRO_QTD_PACAS], [COR_PECAS_LARGURA] FROM [CorridasOnduladeira] ";
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
            this.Query = $"SELECT [BOL_ID], [BOL_ID_ORIGEM], [PRO_LARGURA_PECA], [PRO_LARGURA_PECA_PROGRAMADO], [PRO_COMPRIMENTO_PECA], [PRO_COMPRIMENTO_PECA_PROGRAMADO], [PRO_UTILIZOU_REFILE_OBRIGATORIO], [PRO_VINCOS_RECALCULADOS], [COR_SOLVER], [COR_GRAMATURA_PAPEIS_PROGRAMADOS], [COR_CUSTO_PAPEIS_PROGRAMADOS], [COR_GRAMATURA_RESINA_PROGRAMADOS], [COR_CUSTO_RESINA_PROGRAMADOS], [COR_TOLERANCIA_MENOS], [COR_TOLERANCIA_MAIS], [COR_PILHAS_POR_PALETE], [COR_COR_FILA], [COR_M_LINEAR_REALIZADO], [PRO_ID_PALETE], [COR_STATUS_PALETE], [COR_GRUPO_PRODUTIVO], [TenantID], [Deleted], [Changed], [UserId], [COR_ID], [COR_STATUS], [COR_STATUS_INTERFACE], [MAQ_ID], [COR_ID_INTERFACE], [COR_SEQUENCIA], [COR_SEQUENCIA_ORIGEM], [ORD_ID], [FPR_SEQ_REPETICAO], [ROT_SEQ_TRANFORMACAO], [COR_FACAO], [COR_FORMATO_BOBINA], [COR_INICIO_PREVISTO], [COR_FIM_PREVISTO], [PRO_ID], [COR_QTD_PLANEJADO], [PRO_QTD_PACAS], [COR_PECAS_LARGURA] FROM [CorridasOnduladeira] ";
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
            this.Query = $"SELECT [BOL_ID], [BOL_ID_ORIGEM], [PRO_LARGURA_PECA], [PRO_LARGURA_PECA_PROGRAMADO], [PRO_COMPRIMENTO_PECA], [PRO_COMPRIMENTO_PECA_PROGRAMADO], [PRO_UTILIZOU_REFILE_OBRIGATORIO], [PRO_VINCOS_RECALCULADOS], [COR_SOLVER], [COR_GRAMATURA_PAPEIS_PROGRAMADOS], [COR_CUSTO_PAPEIS_PROGRAMADOS], [COR_GRAMATURA_RESINA_PROGRAMADOS], [COR_CUSTO_RESINA_PROGRAMADOS], [COR_TOLERANCIA_MENOS], [COR_TOLERANCIA_MAIS], [COR_PILHAS_POR_PALETE], [COR_COR_FILA], [COR_M_LINEAR_REALIZADO], [PRO_ID_PALETE], [COR_STATUS_PALETE], [COR_GRUPO_PRODUTIVO], [TenantID], [Deleted], [Changed], [UserId], [COR_ID], [COR_STATUS], [COR_STATUS_INTERFACE], [MAQ_ID], [COR_ID_INTERFACE], [COR_SEQUENCIA], [COR_SEQUENCIA_ORIGEM], [ORD_ID], [FPR_SEQ_REPETICAO], [ROT_SEQ_TRANFORMACAO], [COR_FACAO], [COR_FORMATO_BOBINA], [COR_INICIO_PREVISTO], [COR_FIM_PREVISTO], [PRO_ID], [COR_QTD_PLANEJADO], [PRO_QTD_PACAS], [COR_PECAS_LARGURA] FROM [CorridasOnduladeira] ";
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
        public QueryModel FirstByCOR_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [BOL_ID], [BOL_ID_ORIGEM], [PRO_LARGURA_PECA], [PRO_LARGURA_PECA_PROGRAMADO], [PRO_COMPRIMENTO_PECA], [PRO_COMPRIMENTO_PECA_PROGRAMADO], [PRO_UTILIZOU_REFILE_OBRIGATORIO], [PRO_VINCOS_RECALCULADOS], [COR_SOLVER], [COR_GRAMATURA_PAPEIS_PROGRAMADOS], [COR_CUSTO_PAPEIS_PROGRAMADOS], [COR_GRAMATURA_RESINA_PROGRAMADOS], [COR_CUSTO_RESINA_PROGRAMADOS], [COR_TOLERANCIA_MENOS], [COR_TOLERANCIA_MAIS], [COR_PILHAS_POR_PALETE], [COR_COR_FILA], [COR_M_LINEAR_REALIZADO], [PRO_ID_PALETE], [COR_STATUS_PALETE], [COR_GRUPO_PRODUTIVO], [TenantID], [Deleted], [Changed], [UserId], [COR_ID], [COR_STATUS], [COR_STATUS_INTERFACE], [MAQ_ID], [COR_ID_INTERFACE], [COR_SEQUENCIA], [COR_SEQUENCIA_ORIGEM], [ORD_ID], [FPR_SEQ_REPETICAO], [ROT_SEQ_TRANFORMACAO], [COR_FACAO], [COR_FORMATO_BOBINA], [COR_INICIO_PREVISTO], [COR_FIM_PREVISTO], [PRO_ID], [COR_QTD_PLANEJADO], [PRO_QTD_PACAS], [COR_PECAS_LARGURA] FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COR_ID"] = value; //06
                      whereClauses.Add($" [COR_ID] = @COR_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCOR_STATUSQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [BOL_ID], [BOL_ID_ORIGEM], [PRO_LARGURA_PECA], [PRO_LARGURA_PECA_PROGRAMADO], [PRO_COMPRIMENTO_PECA], [PRO_COMPRIMENTO_PECA_PROGRAMADO], [PRO_UTILIZOU_REFILE_OBRIGATORIO], [PRO_VINCOS_RECALCULADOS], [COR_SOLVER], [COR_GRAMATURA_PAPEIS_PROGRAMADOS], [COR_CUSTO_PAPEIS_PROGRAMADOS], [COR_GRAMATURA_RESINA_PROGRAMADOS], [COR_CUSTO_RESINA_PROGRAMADOS], [COR_TOLERANCIA_MENOS], [COR_TOLERANCIA_MAIS], [COR_PILHAS_POR_PALETE], [COR_COR_FILA], [COR_M_LINEAR_REALIZADO], [PRO_ID_PALETE], [COR_STATUS_PALETE], [COR_GRUPO_PRODUTIVO], [TenantID], [Deleted], [Changed], [UserId], [COR_ID], [COR_STATUS], [COR_STATUS_INTERFACE], [MAQ_ID], [COR_ID_INTERFACE], [COR_SEQUENCIA], [COR_SEQUENCIA_ORIGEM], [ORD_ID], [FPR_SEQ_REPETICAO], [ROT_SEQ_TRANFORMACAO], [COR_FACAO], [COR_FORMATO_BOBINA], [COR_INICIO_PREVISTO], [COR_FIM_PREVISTO], [PRO_ID], [COR_QTD_PLANEJADO], [PRO_QTD_PACAS], [COR_PECAS_LARGURA] FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COR_STATUS"] = value; //06
                      whereClauses.Add($" [COR_STATUS] = @COR_STATUS ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCOR_STATUS_INTERFACEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [BOL_ID], [BOL_ID_ORIGEM], [PRO_LARGURA_PECA], [PRO_LARGURA_PECA_PROGRAMADO], [PRO_COMPRIMENTO_PECA], [PRO_COMPRIMENTO_PECA_PROGRAMADO], [PRO_UTILIZOU_REFILE_OBRIGATORIO], [PRO_VINCOS_RECALCULADOS], [COR_SOLVER], [COR_GRAMATURA_PAPEIS_PROGRAMADOS], [COR_CUSTO_PAPEIS_PROGRAMADOS], [COR_GRAMATURA_RESINA_PROGRAMADOS], [COR_CUSTO_RESINA_PROGRAMADOS], [COR_TOLERANCIA_MENOS], [COR_TOLERANCIA_MAIS], [COR_PILHAS_POR_PALETE], [COR_COR_FILA], [COR_M_LINEAR_REALIZADO], [PRO_ID_PALETE], [COR_STATUS_PALETE], [COR_GRUPO_PRODUTIVO], [TenantID], [Deleted], [Changed], [UserId], [COR_ID], [COR_STATUS], [COR_STATUS_INTERFACE], [MAQ_ID], [COR_ID_INTERFACE], [COR_SEQUENCIA], [COR_SEQUENCIA_ORIGEM], [ORD_ID], [FPR_SEQ_REPETICAO], [ROT_SEQ_TRANFORMACAO], [COR_FACAO], [COR_FORMATO_BOBINA], [COR_INICIO_PREVISTO], [COR_FIM_PREVISTO], [PRO_ID], [COR_QTD_PLANEJADO], [PRO_QTD_PACAS], [COR_PECAS_LARGURA] FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COR_STATUS_INTERFACE"] = value; //06
                      whereClauses.Add($" [COR_STATUS_INTERFACE] = @COR_STATUS_INTERFACE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [BOL_ID], [BOL_ID_ORIGEM], [PRO_LARGURA_PECA], [PRO_LARGURA_PECA_PROGRAMADO], [PRO_COMPRIMENTO_PECA], [PRO_COMPRIMENTO_PECA_PROGRAMADO], [PRO_UTILIZOU_REFILE_OBRIGATORIO], [PRO_VINCOS_RECALCULADOS], [COR_SOLVER], [COR_GRAMATURA_PAPEIS_PROGRAMADOS], [COR_CUSTO_PAPEIS_PROGRAMADOS], [COR_GRAMATURA_RESINA_PROGRAMADOS], [COR_CUSTO_RESINA_PROGRAMADOS], [COR_TOLERANCIA_MENOS], [COR_TOLERANCIA_MAIS], [COR_PILHAS_POR_PALETE], [COR_COR_FILA], [COR_M_LINEAR_REALIZADO], [PRO_ID_PALETE], [COR_STATUS_PALETE], [COR_GRUPO_PRODUTIVO], [TenantID], [Deleted], [Changed], [UserId], [COR_ID], [COR_STATUS], [COR_STATUS_INTERFACE], [MAQ_ID], [COR_ID_INTERFACE], [COR_SEQUENCIA], [COR_SEQUENCIA_ORIGEM], [ORD_ID], [FPR_SEQ_REPETICAO], [ROT_SEQ_TRANFORMACAO], [COR_FACAO], [COR_FORMATO_BOBINA], [COR_INICIO_PREVISTO], [COR_FIM_PREVISTO], [PRO_ID], [COR_QTD_PLANEJADO], [PRO_QTD_PACAS], [COR_PECAS_LARGURA] FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_ID"] = value; //06
                      whereClauses.Add($" [MAQ_ID] = @MAQ_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCOR_ID_INTERFACEQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [BOL_ID], [BOL_ID_ORIGEM], [PRO_LARGURA_PECA], [PRO_LARGURA_PECA_PROGRAMADO], [PRO_COMPRIMENTO_PECA], [PRO_COMPRIMENTO_PECA_PROGRAMADO], [PRO_UTILIZOU_REFILE_OBRIGATORIO], [PRO_VINCOS_RECALCULADOS], [COR_SOLVER], [COR_GRAMATURA_PAPEIS_PROGRAMADOS], [COR_CUSTO_PAPEIS_PROGRAMADOS], [COR_GRAMATURA_RESINA_PROGRAMADOS], [COR_CUSTO_RESINA_PROGRAMADOS], [COR_TOLERANCIA_MENOS], [COR_TOLERANCIA_MAIS], [COR_PILHAS_POR_PALETE], [COR_COR_FILA], [COR_M_LINEAR_REALIZADO], [PRO_ID_PALETE], [COR_STATUS_PALETE], [COR_GRUPO_PRODUTIVO], [TenantID], [Deleted], [Changed], [UserId], [COR_ID], [COR_STATUS], [COR_STATUS_INTERFACE], [MAQ_ID], [COR_ID_INTERFACE], [COR_SEQUENCIA], [COR_SEQUENCIA_ORIGEM], [ORD_ID], [FPR_SEQ_REPETICAO], [ROT_SEQ_TRANFORMACAO], [COR_FACAO], [COR_FORMATO_BOBINA], [COR_INICIO_PREVISTO], [COR_FIM_PREVISTO], [PRO_ID], [COR_QTD_PLANEJADO], [PRO_QTD_PACAS], [COR_PECAS_LARGURA] FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COR_ID_INTERFACE"] = value; //06
                      whereClauses.Add($" [COR_ID_INTERFACE] = @COR_ID_INTERFACE ");//06
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
            this.Query = $"SELECT [BOL_ID], [BOL_ID_ORIGEM], [PRO_LARGURA_PECA], [PRO_LARGURA_PECA_PROGRAMADO], [PRO_COMPRIMENTO_PECA], [PRO_COMPRIMENTO_PECA_PROGRAMADO], [PRO_UTILIZOU_REFILE_OBRIGATORIO], [PRO_VINCOS_RECALCULADOS], [COR_SOLVER], [COR_GRAMATURA_PAPEIS_PROGRAMADOS], [COR_CUSTO_PAPEIS_PROGRAMADOS], [COR_GRAMATURA_RESINA_PROGRAMADOS], [COR_CUSTO_RESINA_PROGRAMADOS], [COR_TOLERANCIA_MENOS], [COR_TOLERANCIA_MAIS], [COR_PILHAS_POR_PALETE], [COR_COR_FILA], [COR_M_LINEAR_REALIZADO], [PRO_ID_PALETE], [COR_STATUS_PALETE], [COR_GRUPO_PRODUTIVO], [TenantID], [Deleted], [Changed], [UserId], [COR_ID], [COR_STATUS], [COR_STATUS_INTERFACE], [MAQ_ID], [COR_ID_INTERFACE], [COR_SEQUENCIA], [COR_SEQUENCIA_ORIGEM], [ORD_ID], [FPR_SEQ_REPETICAO], [ROT_SEQ_TRANFORMACAO], [COR_FACAO], [COR_FORMATO_BOBINA], [COR_INICIO_PREVISTO], [COR_FIM_PREVISTO], [PRO_ID], [COR_QTD_PLANEJADO], [PRO_QTD_PACAS], [COR_PECAS_LARGURA] FROM [CorridasOnduladeira] ";
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
        public QueryModel FirstByCOR_SEQUENCIA_ORIGEMQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [BOL_ID], [BOL_ID_ORIGEM], [PRO_LARGURA_PECA], [PRO_LARGURA_PECA_PROGRAMADO], [PRO_COMPRIMENTO_PECA], [PRO_COMPRIMENTO_PECA_PROGRAMADO], [PRO_UTILIZOU_REFILE_OBRIGATORIO], [PRO_VINCOS_RECALCULADOS], [COR_SOLVER], [COR_GRAMATURA_PAPEIS_PROGRAMADOS], [COR_CUSTO_PAPEIS_PROGRAMADOS], [COR_GRAMATURA_RESINA_PROGRAMADOS], [COR_CUSTO_RESINA_PROGRAMADOS], [COR_TOLERANCIA_MENOS], [COR_TOLERANCIA_MAIS], [COR_PILHAS_POR_PALETE], [COR_COR_FILA], [COR_M_LINEAR_REALIZADO], [PRO_ID_PALETE], [COR_STATUS_PALETE], [COR_GRUPO_PRODUTIVO], [TenantID], [Deleted], [Changed], [UserId], [COR_ID], [COR_STATUS], [COR_STATUS_INTERFACE], [MAQ_ID], [COR_ID_INTERFACE], [COR_SEQUENCIA], [COR_SEQUENCIA_ORIGEM], [ORD_ID], [FPR_SEQ_REPETICAO], [ROT_SEQ_TRANFORMACAO], [COR_FACAO], [COR_FORMATO_BOBINA], [COR_INICIO_PREVISTO], [COR_FIM_PREVISTO], [PRO_ID], [COR_QTD_PLANEJADO], [PRO_QTD_PACAS], [COR_PECAS_LARGURA] FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COR_SEQUENCIA_ORIGEM"] = value; //06
                      whereClauses.Add($" [COR_SEQUENCIA_ORIGEM] = @COR_SEQUENCIA_ORIGEM ");//06
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
            this.Query = $"SELECT [BOL_ID], [BOL_ID_ORIGEM], [PRO_LARGURA_PECA], [PRO_LARGURA_PECA_PROGRAMADO], [PRO_COMPRIMENTO_PECA], [PRO_COMPRIMENTO_PECA_PROGRAMADO], [PRO_UTILIZOU_REFILE_OBRIGATORIO], [PRO_VINCOS_RECALCULADOS], [COR_SOLVER], [COR_GRAMATURA_PAPEIS_PROGRAMADOS], [COR_CUSTO_PAPEIS_PROGRAMADOS], [COR_GRAMATURA_RESINA_PROGRAMADOS], [COR_CUSTO_RESINA_PROGRAMADOS], [COR_TOLERANCIA_MENOS], [COR_TOLERANCIA_MAIS], [COR_PILHAS_POR_PALETE], [COR_COR_FILA], [COR_M_LINEAR_REALIZADO], [PRO_ID_PALETE], [COR_STATUS_PALETE], [COR_GRUPO_PRODUTIVO], [TenantID], [Deleted], [Changed], [UserId], [COR_ID], [COR_STATUS], [COR_STATUS_INTERFACE], [MAQ_ID], [COR_ID_INTERFACE], [COR_SEQUENCIA], [COR_SEQUENCIA_ORIGEM], [ORD_ID], [FPR_SEQ_REPETICAO], [ROT_SEQ_TRANFORMACAO], [COR_FACAO], [COR_FORMATO_BOBINA], [COR_INICIO_PREVISTO], [COR_FIM_PREVISTO], [PRO_ID], [COR_QTD_PLANEJADO], [PRO_QTD_PACAS], [COR_PECAS_LARGURA] FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ORD_ID"] = value; //06
                      whereClauses.Add($" [ORD_ID] = @ORD_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_SEQ_REPETICAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [BOL_ID], [BOL_ID_ORIGEM], [PRO_LARGURA_PECA], [PRO_LARGURA_PECA_PROGRAMADO], [PRO_COMPRIMENTO_PECA], [PRO_COMPRIMENTO_PECA_PROGRAMADO], [PRO_UTILIZOU_REFILE_OBRIGATORIO], [PRO_VINCOS_RECALCULADOS], [COR_SOLVER], [COR_GRAMATURA_PAPEIS_PROGRAMADOS], [COR_CUSTO_PAPEIS_PROGRAMADOS], [COR_GRAMATURA_RESINA_PROGRAMADOS], [COR_CUSTO_RESINA_PROGRAMADOS], [COR_TOLERANCIA_MENOS], [COR_TOLERANCIA_MAIS], [COR_PILHAS_POR_PALETE], [COR_COR_FILA], [COR_M_LINEAR_REALIZADO], [PRO_ID_PALETE], [COR_STATUS_PALETE], [COR_GRUPO_PRODUTIVO], [TenantID], [Deleted], [Changed], [UserId], [COR_ID], [COR_STATUS], [COR_STATUS_INTERFACE], [MAQ_ID], [COR_ID_INTERFACE], [COR_SEQUENCIA], [COR_SEQUENCIA_ORIGEM], [ORD_ID], [FPR_SEQ_REPETICAO], [ROT_SEQ_TRANFORMACAO], [COR_FACAO], [COR_FORMATO_BOBINA], [COR_INICIO_PREVISTO], [COR_FIM_PREVISTO], [PRO_ID], [COR_QTD_PLANEJADO], [PRO_QTD_PACAS], [COR_PECAS_LARGURA] FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["FPR_SEQ_REPETICAO"] = value; //06
                      whereClauses.Add($" [FPR_SEQ_REPETICAO] = @FPR_SEQ_REPETICAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByROT_SEQ_TRANFORMACAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [BOL_ID], [BOL_ID_ORIGEM], [PRO_LARGURA_PECA], [PRO_LARGURA_PECA_PROGRAMADO], [PRO_COMPRIMENTO_PECA], [PRO_COMPRIMENTO_PECA_PROGRAMADO], [PRO_UTILIZOU_REFILE_OBRIGATORIO], [PRO_VINCOS_RECALCULADOS], [COR_SOLVER], [COR_GRAMATURA_PAPEIS_PROGRAMADOS], [COR_CUSTO_PAPEIS_PROGRAMADOS], [COR_GRAMATURA_RESINA_PROGRAMADOS], [COR_CUSTO_RESINA_PROGRAMADOS], [COR_TOLERANCIA_MENOS], [COR_TOLERANCIA_MAIS], [COR_PILHAS_POR_PALETE], [COR_COR_FILA], [COR_M_LINEAR_REALIZADO], [PRO_ID_PALETE], [COR_STATUS_PALETE], [COR_GRUPO_PRODUTIVO], [TenantID], [Deleted], [Changed], [UserId], [COR_ID], [COR_STATUS], [COR_STATUS_INTERFACE], [MAQ_ID], [COR_ID_INTERFACE], [COR_SEQUENCIA], [COR_SEQUENCIA_ORIGEM], [ORD_ID], [FPR_SEQ_REPETICAO], [ROT_SEQ_TRANFORMACAO], [COR_FACAO], [COR_FORMATO_BOBINA], [COR_INICIO_PREVISTO], [COR_FIM_PREVISTO], [PRO_ID], [COR_QTD_PLANEJADO], [PRO_QTD_PACAS], [COR_PECAS_LARGURA] FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ROT_SEQ_TRANFORMACAO"] = value; //06
                      whereClauses.Add($" [ROT_SEQ_TRANFORMACAO] = @ROT_SEQ_TRANFORMACAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCOR_FACAOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [BOL_ID], [BOL_ID_ORIGEM], [PRO_LARGURA_PECA], [PRO_LARGURA_PECA_PROGRAMADO], [PRO_COMPRIMENTO_PECA], [PRO_COMPRIMENTO_PECA_PROGRAMADO], [PRO_UTILIZOU_REFILE_OBRIGATORIO], [PRO_VINCOS_RECALCULADOS], [COR_SOLVER], [COR_GRAMATURA_PAPEIS_PROGRAMADOS], [COR_CUSTO_PAPEIS_PROGRAMADOS], [COR_GRAMATURA_RESINA_PROGRAMADOS], [COR_CUSTO_RESINA_PROGRAMADOS], [COR_TOLERANCIA_MENOS], [COR_TOLERANCIA_MAIS], [COR_PILHAS_POR_PALETE], [COR_COR_FILA], [COR_M_LINEAR_REALIZADO], [PRO_ID_PALETE], [COR_STATUS_PALETE], [COR_GRUPO_PRODUTIVO], [TenantID], [Deleted], [Changed], [UserId], [COR_ID], [COR_STATUS], [COR_STATUS_INTERFACE], [MAQ_ID], [COR_ID_INTERFACE], [COR_SEQUENCIA], [COR_SEQUENCIA_ORIGEM], [ORD_ID], [FPR_SEQ_REPETICAO], [ROT_SEQ_TRANFORMACAO], [COR_FACAO], [COR_FORMATO_BOBINA], [COR_INICIO_PREVISTO], [COR_FIM_PREVISTO], [PRO_ID], [COR_QTD_PLANEJADO], [PRO_QTD_PACAS], [COR_PECAS_LARGURA] FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COR_FACAO"] = value; //06
                      whereClauses.Add($" [COR_FACAO] = @COR_FACAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCOR_FORMATO_BOBINAQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [BOL_ID], [BOL_ID_ORIGEM], [PRO_LARGURA_PECA], [PRO_LARGURA_PECA_PROGRAMADO], [PRO_COMPRIMENTO_PECA], [PRO_COMPRIMENTO_PECA_PROGRAMADO], [PRO_UTILIZOU_REFILE_OBRIGATORIO], [PRO_VINCOS_RECALCULADOS], [COR_SOLVER], [COR_GRAMATURA_PAPEIS_PROGRAMADOS], [COR_CUSTO_PAPEIS_PROGRAMADOS], [COR_GRAMATURA_RESINA_PROGRAMADOS], [COR_CUSTO_RESINA_PROGRAMADOS], [COR_TOLERANCIA_MENOS], [COR_TOLERANCIA_MAIS], [COR_PILHAS_POR_PALETE], [COR_COR_FILA], [COR_M_LINEAR_REALIZADO], [PRO_ID_PALETE], [COR_STATUS_PALETE], [COR_GRUPO_PRODUTIVO], [TenantID], [Deleted], [Changed], [UserId], [COR_ID], [COR_STATUS], [COR_STATUS_INTERFACE], [MAQ_ID], [COR_ID_INTERFACE], [COR_SEQUENCIA], [COR_SEQUENCIA_ORIGEM], [ORD_ID], [FPR_SEQ_REPETICAO], [ROT_SEQ_TRANFORMACAO], [COR_FACAO], [COR_FORMATO_BOBINA], [COR_INICIO_PREVISTO], [COR_FIM_PREVISTO], [PRO_ID], [COR_QTD_PLANEJADO], [PRO_QTD_PACAS], [COR_PECAS_LARGURA] FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COR_FORMATO_BOBINA"] = value; //06
                      whereClauses.Add($" [COR_FORMATO_BOBINA] = @COR_FORMATO_BOBINA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCOR_INICIO_PREVISTOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [BOL_ID], [BOL_ID_ORIGEM], [PRO_LARGURA_PECA], [PRO_LARGURA_PECA_PROGRAMADO], [PRO_COMPRIMENTO_PECA], [PRO_COMPRIMENTO_PECA_PROGRAMADO], [PRO_UTILIZOU_REFILE_OBRIGATORIO], [PRO_VINCOS_RECALCULADOS], [COR_SOLVER], [COR_GRAMATURA_PAPEIS_PROGRAMADOS], [COR_CUSTO_PAPEIS_PROGRAMADOS], [COR_GRAMATURA_RESINA_PROGRAMADOS], [COR_CUSTO_RESINA_PROGRAMADOS], [COR_TOLERANCIA_MENOS], [COR_TOLERANCIA_MAIS], [COR_PILHAS_POR_PALETE], [COR_COR_FILA], [COR_M_LINEAR_REALIZADO], [PRO_ID_PALETE], [COR_STATUS_PALETE], [COR_GRUPO_PRODUTIVO], [TenantID], [Deleted], [Changed], [UserId], [COR_ID], [COR_STATUS], [COR_STATUS_INTERFACE], [MAQ_ID], [COR_ID_INTERFACE], [COR_SEQUENCIA], [COR_SEQUENCIA_ORIGEM], [ORD_ID], [FPR_SEQ_REPETICAO], [ROT_SEQ_TRANFORMACAO], [COR_FACAO], [COR_FORMATO_BOBINA], [COR_INICIO_PREVISTO], [COR_FIM_PREVISTO], [PRO_ID], [COR_QTD_PLANEJADO], [PRO_QTD_PACAS], [COR_PECAS_LARGURA] FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COR_INICIO_PREVISTO"] = value; //06
                      whereClauses.Add($" [COR_INICIO_PREVISTO] = @COR_INICIO_PREVISTO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCOR_FIM_PREVISTOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [BOL_ID], [BOL_ID_ORIGEM], [PRO_LARGURA_PECA], [PRO_LARGURA_PECA_PROGRAMADO], [PRO_COMPRIMENTO_PECA], [PRO_COMPRIMENTO_PECA_PROGRAMADO], [PRO_UTILIZOU_REFILE_OBRIGATORIO], [PRO_VINCOS_RECALCULADOS], [COR_SOLVER], [COR_GRAMATURA_PAPEIS_PROGRAMADOS], [COR_CUSTO_PAPEIS_PROGRAMADOS], [COR_GRAMATURA_RESINA_PROGRAMADOS], [COR_CUSTO_RESINA_PROGRAMADOS], [COR_TOLERANCIA_MENOS], [COR_TOLERANCIA_MAIS], [COR_PILHAS_POR_PALETE], [COR_COR_FILA], [COR_M_LINEAR_REALIZADO], [PRO_ID_PALETE], [COR_STATUS_PALETE], [COR_GRUPO_PRODUTIVO], [TenantID], [Deleted], [Changed], [UserId], [COR_ID], [COR_STATUS], [COR_STATUS_INTERFACE], [MAQ_ID], [COR_ID_INTERFACE], [COR_SEQUENCIA], [COR_SEQUENCIA_ORIGEM], [ORD_ID], [FPR_SEQ_REPETICAO], [ROT_SEQ_TRANFORMACAO], [COR_FACAO], [COR_FORMATO_BOBINA], [COR_INICIO_PREVISTO], [COR_FIM_PREVISTO], [PRO_ID], [COR_QTD_PLANEJADO], [PRO_QTD_PACAS], [COR_PECAS_LARGURA] FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COR_FIM_PREVISTO"] = value; //06
                      whereClauses.Add($" [COR_FIM_PREVISTO] = @COR_FIM_PREVISTO ");//06
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
            this.Query = $"SELECT [BOL_ID], [BOL_ID_ORIGEM], [PRO_LARGURA_PECA], [PRO_LARGURA_PECA_PROGRAMADO], [PRO_COMPRIMENTO_PECA], [PRO_COMPRIMENTO_PECA_PROGRAMADO], [PRO_UTILIZOU_REFILE_OBRIGATORIO], [PRO_VINCOS_RECALCULADOS], [COR_SOLVER], [COR_GRAMATURA_PAPEIS_PROGRAMADOS], [COR_CUSTO_PAPEIS_PROGRAMADOS], [COR_GRAMATURA_RESINA_PROGRAMADOS], [COR_CUSTO_RESINA_PROGRAMADOS], [COR_TOLERANCIA_MENOS], [COR_TOLERANCIA_MAIS], [COR_PILHAS_POR_PALETE], [COR_COR_FILA], [COR_M_LINEAR_REALIZADO], [PRO_ID_PALETE], [COR_STATUS_PALETE], [COR_GRUPO_PRODUTIVO], [TenantID], [Deleted], [Changed], [UserId], [COR_ID], [COR_STATUS], [COR_STATUS_INTERFACE], [MAQ_ID], [COR_ID_INTERFACE], [COR_SEQUENCIA], [COR_SEQUENCIA_ORIGEM], [ORD_ID], [FPR_SEQ_REPETICAO], [ROT_SEQ_TRANFORMACAO], [COR_FACAO], [COR_FORMATO_BOBINA], [COR_INICIO_PREVISTO], [COR_FIM_PREVISTO], [PRO_ID], [COR_QTD_PLANEJADO], [PRO_QTD_PACAS], [COR_PECAS_LARGURA] FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["PRO_ID"] = value; //06
                      whereClauses.Add($" [PRO_ID] = @PRO_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCOR_QTD_PLANEJADOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [BOL_ID], [BOL_ID_ORIGEM], [PRO_LARGURA_PECA], [PRO_LARGURA_PECA_PROGRAMADO], [PRO_COMPRIMENTO_PECA], [PRO_COMPRIMENTO_PECA_PROGRAMADO], [PRO_UTILIZOU_REFILE_OBRIGATORIO], [PRO_VINCOS_RECALCULADOS], [COR_SOLVER], [COR_GRAMATURA_PAPEIS_PROGRAMADOS], [COR_CUSTO_PAPEIS_PROGRAMADOS], [COR_GRAMATURA_RESINA_PROGRAMADOS], [COR_CUSTO_RESINA_PROGRAMADOS], [COR_TOLERANCIA_MENOS], [COR_TOLERANCIA_MAIS], [COR_PILHAS_POR_PALETE], [COR_COR_FILA], [COR_M_LINEAR_REALIZADO], [PRO_ID_PALETE], [COR_STATUS_PALETE], [COR_GRUPO_PRODUTIVO], [TenantID], [Deleted], [Changed], [UserId], [COR_ID], [COR_STATUS], [COR_STATUS_INTERFACE], [MAQ_ID], [COR_ID_INTERFACE], [COR_SEQUENCIA], [COR_SEQUENCIA_ORIGEM], [ORD_ID], [FPR_SEQ_REPETICAO], [ROT_SEQ_TRANFORMACAO], [COR_FACAO], [COR_FORMATO_BOBINA], [COR_INICIO_PREVISTO], [COR_FIM_PREVISTO], [PRO_ID], [COR_QTD_PLANEJADO], [PRO_QTD_PACAS], [COR_PECAS_LARGURA] FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COR_QTD_PLANEJADO"] = value; //06
                      whereClauses.Add($" [COR_QTD_PLANEJADO] = @COR_QTD_PLANEJADO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_QTD_PACASQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [BOL_ID], [BOL_ID_ORIGEM], [PRO_LARGURA_PECA], [PRO_LARGURA_PECA_PROGRAMADO], [PRO_COMPRIMENTO_PECA], [PRO_COMPRIMENTO_PECA_PROGRAMADO], [PRO_UTILIZOU_REFILE_OBRIGATORIO], [PRO_VINCOS_RECALCULADOS], [COR_SOLVER], [COR_GRAMATURA_PAPEIS_PROGRAMADOS], [COR_CUSTO_PAPEIS_PROGRAMADOS], [COR_GRAMATURA_RESINA_PROGRAMADOS], [COR_CUSTO_RESINA_PROGRAMADOS], [COR_TOLERANCIA_MENOS], [COR_TOLERANCIA_MAIS], [COR_PILHAS_POR_PALETE], [COR_COR_FILA], [COR_M_LINEAR_REALIZADO], [PRO_ID_PALETE], [COR_STATUS_PALETE], [COR_GRUPO_PRODUTIVO], [TenantID], [Deleted], [Changed], [UserId], [COR_ID], [COR_STATUS], [COR_STATUS_INTERFACE], [MAQ_ID], [COR_ID_INTERFACE], [COR_SEQUENCIA], [COR_SEQUENCIA_ORIGEM], [ORD_ID], [FPR_SEQ_REPETICAO], [ROT_SEQ_TRANFORMACAO], [COR_FACAO], [COR_FORMATO_BOBINA], [COR_INICIO_PREVISTO], [COR_FIM_PREVISTO], [PRO_ID], [COR_QTD_PLANEJADO], [PRO_QTD_PACAS], [COR_PECAS_LARGURA] FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["PRO_QTD_PACAS"] = value; //06
                      whereClauses.Add($" [PRO_QTD_PACAS] = @PRO_QTD_PACAS ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCOR_PECAS_LARGURAQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [BOL_ID], [BOL_ID_ORIGEM], [PRO_LARGURA_PECA], [PRO_LARGURA_PECA_PROGRAMADO], [PRO_COMPRIMENTO_PECA], [PRO_COMPRIMENTO_PECA_PROGRAMADO], [PRO_UTILIZOU_REFILE_OBRIGATORIO], [PRO_VINCOS_RECALCULADOS], [COR_SOLVER], [COR_GRAMATURA_PAPEIS_PROGRAMADOS], [COR_CUSTO_PAPEIS_PROGRAMADOS], [COR_GRAMATURA_RESINA_PROGRAMADOS], [COR_CUSTO_RESINA_PROGRAMADOS], [COR_TOLERANCIA_MENOS], [COR_TOLERANCIA_MAIS], [COR_PILHAS_POR_PALETE], [COR_COR_FILA], [COR_M_LINEAR_REALIZADO], [PRO_ID_PALETE], [COR_STATUS_PALETE], [COR_GRUPO_PRODUTIVO], [TenantID], [Deleted], [Changed], [UserId], [COR_ID], [COR_STATUS], [COR_STATUS_INTERFACE], [MAQ_ID], [COR_ID_INTERFACE], [COR_SEQUENCIA], [COR_SEQUENCIA_ORIGEM], [ORD_ID], [FPR_SEQ_REPETICAO], [ROT_SEQ_TRANFORMACAO], [COR_FACAO], [COR_FORMATO_BOBINA], [COR_INICIO_PREVISTO], [COR_FIM_PREVISTO], [PRO_ID], [COR_QTD_PLANEJADO], [PRO_QTD_PACAS], [COR_PECAS_LARGURA] FROM [CorridasOnduladeira] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["COR_PECAS_LARGURA"] = value; //06
                      whereClauses.Add($" [COR_PECAS_LARGURA] = @COR_PECAS_LARGURA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration