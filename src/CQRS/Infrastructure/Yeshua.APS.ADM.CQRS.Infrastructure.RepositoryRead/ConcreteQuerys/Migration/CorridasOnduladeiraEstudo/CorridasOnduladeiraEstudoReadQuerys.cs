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
    public class CorridasOnduladeiraEstudoQueryRead : QueryBase, ICorridasOnduladeiraEstudoQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public CorridasOnduladeiraEstudoQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel CorridasOnduladeiraEstudoQuery(Command.Read.CorridasOnduladeiraEstudoReadCommand Command )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select Id, BOL_ID, BOL_ID_ORIGEM, PRO_LARGURA_PECA, PRO_LARGURA_PECA_PROGRAMADO, PRO_COMPRIMENTO_PECA, PRO_COMPRIMENTO_PECA_PROGRAMADO, PRO_UTILIZOU_REFILE_OBRIGATORIO, PRO_VINCOS_RECALCULADOS, COR_SOLVER, COR_GRAMATURA_PAPEIS_PROGRAMADOS, COR_CUSTO_PAPEIS_PROGRAMADOS, COR_GRAMATURA_RESINA_PROGRAMADOS, COR_CUSTO_RESINA_PROGRAMADOS, COR_TOLERANCIA_MENOS, COR_TOLERANCIA_MAIS, COR_PILHAS_POR_PALETE, COR_M_LINEAR_REALIZADO, PRO_ID_PALETE, COR_STATUS_PALETE, COR_GRUPO_PRODUTIVO, TenantID, Deleted, Changed, UserId from CorridasOnduladeiraEstudo ";
if (Command.Id.HasValue) dict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"Id = @Id");
if (!string.IsNullOrEmpty(Command.BOL_ID)) dict["BOL_ID"] = $"%{Command.BOL_ID}%";
if (!string.IsNullOrEmpty(Command.BOL_ID)) whereClauses.Add($"BOL_ID like @BOL_ID");
if (!string.IsNullOrEmpty(Command.BOL_ID_ORIGEM)) dict["BOL_ID_ORIGEM"] = $"%{Command.BOL_ID_ORIGEM}%";
if (!string.IsNullOrEmpty(Command.BOL_ID_ORIGEM)) whereClauses.Add($"BOL_ID_ORIGEM like @BOL_ID_ORIGEM");
if (!string.IsNullOrEmpty(Command.PRO_VINCOS_RECALCULADOS)) dict["PRO_VINCOS_RECALCULADOS"] = $"%{Command.PRO_VINCOS_RECALCULADOS}%";
if (!string.IsNullOrEmpty(Command.PRO_VINCOS_RECALCULADOS)) whereClauses.Add($"PRO_VINCOS_RECALCULADOS like @PRO_VINCOS_RECALCULADOS");
if (!string.IsNullOrEmpty(Command.COR_SOLVER)) dict["COR_SOLVER"] = $"%{Command.COR_SOLVER}%";
if (!string.IsNullOrEmpty(Command.COR_SOLVER)) whereClauses.Add($"COR_SOLVER like @COR_SOLVER");
if (Command.COR_PILHAS_POR_PALETE.HasValue) dict["COR_PILHAS_POR_PALETE"] = Command.COR_PILHAS_POR_PALETE.Value;
if (Command.COR_PILHAS_POR_PALETE.HasValue) whereClauses.Add($"COR_PILHAS_POR_PALETE = @COR_PILHAS_POR_PALETE");
if (!string.IsNullOrEmpty(Command.PRO_ID_PALETE)) dict["PRO_ID_PALETE"] = $"%{Command.PRO_ID_PALETE}%";
if (!string.IsNullOrEmpty(Command.PRO_ID_PALETE)) whereClauses.Add($"PRO_ID_PALETE like @PRO_ID_PALETE");
if (!string.IsNullOrEmpty(Command.COR_STATUS_PALETE)) dict["COR_STATUS_PALETE"] = $"%{Command.COR_STATUS_PALETE}%";
if (!string.IsNullOrEmpty(Command.COR_STATUS_PALETE)) whereClauses.Add($"COR_STATUS_PALETE like @COR_STATUS_PALETE");
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
            Query += " ORDER BY Id OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel CorridasOnduladeiraEstudoTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel CorridasOnduladeiraEstudoUserIdQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel ExistsByIdQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CorridasOnduladeiraEstudo ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Id"] = value; //04
                      whereClauses.Add($" Id = @Id ");//04
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
            this.Query = $"SELECT 1 FROM CorridasOnduladeiraEstudo ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["BOL_ID"] = value; //04
                      whereClauses.Add($" BOL_ID = @BOL_ID ");//04
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
            this.Query = $"SELECT 1 FROM CorridasOnduladeiraEstudo ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["BOL_ID_ORIGEM"] = value; //04
                      whereClauses.Add($" BOL_ID_ORIGEM = @BOL_ID_ORIGEM ");//04
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
            this.Query = $"SELECT 1 FROM CorridasOnduladeiraEstudo ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_LARGURA_PECA"] = value; //04
                      whereClauses.Add($" PRO_LARGURA_PECA = @PRO_LARGURA_PECA ");//04
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
            this.Query = $"SELECT 1 FROM CorridasOnduladeiraEstudo ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_LARGURA_PECA_PROGRAMADO"] = value; //04
                      whereClauses.Add($" PRO_LARGURA_PECA_PROGRAMADO = @PRO_LARGURA_PECA_PROGRAMADO ");//04
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
            this.Query = $"SELECT 1 FROM CorridasOnduladeiraEstudo ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_COMPRIMENTO_PECA"] = value; //04
                      whereClauses.Add($" PRO_COMPRIMENTO_PECA = @PRO_COMPRIMENTO_PECA ");//04
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
            this.Query = $"SELECT 1 FROM CorridasOnduladeiraEstudo ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_COMPRIMENTO_PECA_PROGRAMADO"] = value; //04
                      whereClauses.Add($" PRO_COMPRIMENTO_PECA_PROGRAMADO = @PRO_COMPRIMENTO_PECA_PROGRAMADO ");//04
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
            this.Query = $"SELECT 1 FROM CorridasOnduladeiraEstudo ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_UTILIZOU_REFILE_OBRIGATORIO"] = value; //04
                      whereClauses.Add($" PRO_UTILIZOU_REFILE_OBRIGATORIO = @PRO_UTILIZOU_REFILE_OBRIGATORIO ");//04
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
            this.Query = $"SELECT 1 FROM CorridasOnduladeiraEstudo ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_VINCOS_RECALCULADOS"] = value; //04
                      whereClauses.Add($" PRO_VINCOS_RECALCULADOS = @PRO_VINCOS_RECALCULADOS ");//04
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
            this.Query = $"SELECT 1 FROM CorridasOnduladeiraEstudo ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["COR_SOLVER"] = value; //04
                      whereClauses.Add($" COR_SOLVER = @COR_SOLVER ");//04
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
            this.Query = $"SELECT 1 FROM CorridasOnduladeiraEstudo ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["COR_GRAMATURA_PAPEIS_PROGRAMADOS"] = value; //04
                      whereClauses.Add($" COR_GRAMATURA_PAPEIS_PROGRAMADOS = @COR_GRAMATURA_PAPEIS_PROGRAMADOS ");//04
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
            this.Query = $"SELECT 1 FROM CorridasOnduladeiraEstudo ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["COR_CUSTO_PAPEIS_PROGRAMADOS"] = value; //04
                      whereClauses.Add($" COR_CUSTO_PAPEIS_PROGRAMADOS = @COR_CUSTO_PAPEIS_PROGRAMADOS ");//04
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
            this.Query = $"SELECT 1 FROM CorridasOnduladeiraEstudo ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["COR_GRAMATURA_RESINA_PROGRAMADOS"] = value; //04
                      whereClauses.Add($" COR_GRAMATURA_RESINA_PROGRAMADOS = @COR_GRAMATURA_RESINA_PROGRAMADOS ");//04
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
            this.Query = $"SELECT 1 FROM CorridasOnduladeiraEstudo ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["COR_CUSTO_RESINA_PROGRAMADOS"] = value; //04
                      whereClauses.Add($" COR_CUSTO_RESINA_PROGRAMADOS = @COR_CUSTO_RESINA_PROGRAMADOS ");//04
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
            this.Query = $"SELECT 1 FROM CorridasOnduladeiraEstudo ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["COR_TOLERANCIA_MENOS"] = value; //04
                      whereClauses.Add($" COR_TOLERANCIA_MENOS = @COR_TOLERANCIA_MENOS ");//04
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
            this.Query = $"SELECT 1 FROM CorridasOnduladeiraEstudo ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["COR_TOLERANCIA_MAIS"] = value; //04
                      whereClauses.Add($" COR_TOLERANCIA_MAIS = @COR_TOLERANCIA_MAIS ");//04
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
            this.Query = $"SELECT 1 FROM CorridasOnduladeiraEstudo ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["COR_PILHAS_POR_PALETE"] = value; //04
                      whereClauses.Add($" COR_PILHAS_POR_PALETE = @COR_PILHAS_POR_PALETE ");//04
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
            this.Query = $"SELECT 1 FROM CorridasOnduladeiraEstudo ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["COR_M_LINEAR_REALIZADO"] = value; //04
                      whereClauses.Add($" COR_M_LINEAR_REALIZADO = @COR_M_LINEAR_REALIZADO ");//04
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
            this.Query = $"SELECT 1 FROM CorridasOnduladeiraEstudo ";
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
        public QueryModel ExistsByCOR_STATUS_PALETEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM CorridasOnduladeiraEstudo ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["COR_STATUS_PALETE"] = value; //04
                      whereClauses.Add($" COR_STATUS_PALETE = @COR_STATUS_PALETE ");//04
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
            this.Query = $"SELECT 1 FROM CorridasOnduladeiraEstudo ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["COR_GRUPO_PRODUTIVO"] = value; //04
                      whereClauses.Add($" COR_GRUPO_PRODUTIVO = @COR_GRUPO_PRODUTIVO ");//04
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
            this.Query = $"SELECT 1 FROM CorridasOnduladeiraEstudo ";
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
            this.Query = $"SELECT 1 FROM CorridasOnduladeiraEstudo ";
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
            this.Query = $"SELECT 1 FROM CorridasOnduladeiraEstudo ";
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
            this.Query = $"SELECT 1 FROM CorridasOnduladeiraEstudo ";
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
        public QueryModel FirstByIdQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, BOL_ID, BOL_ID_ORIGEM, PRO_LARGURA_PECA, PRO_LARGURA_PECA_PROGRAMADO, PRO_COMPRIMENTO_PECA, PRO_COMPRIMENTO_PECA_PROGRAMADO, PRO_UTILIZOU_REFILE_OBRIGATORIO, PRO_VINCOS_RECALCULADOS, COR_SOLVER, COR_GRAMATURA_PAPEIS_PROGRAMADOS, COR_CUSTO_PAPEIS_PROGRAMADOS, COR_GRAMATURA_RESINA_PROGRAMADOS, COR_CUSTO_RESINA_PROGRAMADOS, COR_TOLERANCIA_MENOS, COR_TOLERANCIA_MAIS, COR_PILHAS_POR_PALETE, COR_M_LINEAR_REALIZADO, PRO_ID_PALETE, COR_STATUS_PALETE, COR_GRUPO_PRODUTIVO, TenantID, Deleted, Changed, UserId FROM CorridasOnduladeiraEstudo ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Id"] = value; //06
                      whereClauses.Add($" Id = @Id ");//06
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
            this.Query = $"SELECT Id, BOL_ID, BOL_ID_ORIGEM, PRO_LARGURA_PECA, PRO_LARGURA_PECA_PROGRAMADO, PRO_COMPRIMENTO_PECA, PRO_COMPRIMENTO_PECA_PROGRAMADO, PRO_UTILIZOU_REFILE_OBRIGATORIO, PRO_VINCOS_RECALCULADOS, COR_SOLVER, COR_GRAMATURA_PAPEIS_PROGRAMADOS, COR_CUSTO_PAPEIS_PROGRAMADOS, COR_GRAMATURA_RESINA_PROGRAMADOS, COR_CUSTO_RESINA_PROGRAMADOS, COR_TOLERANCIA_MENOS, COR_TOLERANCIA_MAIS, COR_PILHAS_POR_PALETE, COR_M_LINEAR_REALIZADO, PRO_ID_PALETE, COR_STATUS_PALETE, COR_GRUPO_PRODUTIVO, TenantID, Deleted, Changed, UserId FROM CorridasOnduladeiraEstudo ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["BOL_ID"] = value; //06
                      whereClauses.Add($" BOL_ID = @BOL_ID ");//06
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
            this.Query = $"SELECT Id, BOL_ID, BOL_ID_ORIGEM, PRO_LARGURA_PECA, PRO_LARGURA_PECA_PROGRAMADO, PRO_COMPRIMENTO_PECA, PRO_COMPRIMENTO_PECA_PROGRAMADO, PRO_UTILIZOU_REFILE_OBRIGATORIO, PRO_VINCOS_RECALCULADOS, COR_SOLVER, COR_GRAMATURA_PAPEIS_PROGRAMADOS, COR_CUSTO_PAPEIS_PROGRAMADOS, COR_GRAMATURA_RESINA_PROGRAMADOS, COR_CUSTO_RESINA_PROGRAMADOS, COR_TOLERANCIA_MENOS, COR_TOLERANCIA_MAIS, COR_PILHAS_POR_PALETE, COR_M_LINEAR_REALIZADO, PRO_ID_PALETE, COR_STATUS_PALETE, COR_GRUPO_PRODUTIVO, TenantID, Deleted, Changed, UserId FROM CorridasOnduladeiraEstudo ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["BOL_ID_ORIGEM"] = value; //06
                      whereClauses.Add($" BOL_ID_ORIGEM = @BOL_ID_ORIGEM ");//06
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
            this.Query = $"SELECT Id, BOL_ID, BOL_ID_ORIGEM, PRO_LARGURA_PECA, PRO_LARGURA_PECA_PROGRAMADO, PRO_COMPRIMENTO_PECA, PRO_COMPRIMENTO_PECA_PROGRAMADO, PRO_UTILIZOU_REFILE_OBRIGATORIO, PRO_VINCOS_RECALCULADOS, COR_SOLVER, COR_GRAMATURA_PAPEIS_PROGRAMADOS, COR_CUSTO_PAPEIS_PROGRAMADOS, COR_GRAMATURA_RESINA_PROGRAMADOS, COR_CUSTO_RESINA_PROGRAMADOS, COR_TOLERANCIA_MENOS, COR_TOLERANCIA_MAIS, COR_PILHAS_POR_PALETE, COR_M_LINEAR_REALIZADO, PRO_ID_PALETE, COR_STATUS_PALETE, COR_GRUPO_PRODUTIVO, TenantID, Deleted, Changed, UserId FROM CorridasOnduladeiraEstudo ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_LARGURA_PECA"] = value; //06
                      whereClauses.Add($" PRO_LARGURA_PECA = @PRO_LARGURA_PECA ");//06
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
            this.Query = $"SELECT Id, BOL_ID, BOL_ID_ORIGEM, PRO_LARGURA_PECA, PRO_LARGURA_PECA_PROGRAMADO, PRO_COMPRIMENTO_PECA, PRO_COMPRIMENTO_PECA_PROGRAMADO, PRO_UTILIZOU_REFILE_OBRIGATORIO, PRO_VINCOS_RECALCULADOS, COR_SOLVER, COR_GRAMATURA_PAPEIS_PROGRAMADOS, COR_CUSTO_PAPEIS_PROGRAMADOS, COR_GRAMATURA_RESINA_PROGRAMADOS, COR_CUSTO_RESINA_PROGRAMADOS, COR_TOLERANCIA_MENOS, COR_TOLERANCIA_MAIS, COR_PILHAS_POR_PALETE, COR_M_LINEAR_REALIZADO, PRO_ID_PALETE, COR_STATUS_PALETE, COR_GRUPO_PRODUTIVO, TenantID, Deleted, Changed, UserId FROM CorridasOnduladeiraEstudo ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_LARGURA_PECA_PROGRAMADO"] = value; //06
                      whereClauses.Add($" PRO_LARGURA_PECA_PROGRAMADO = @PRO_LARGURA_PECA_PROGRAMADO ");//06
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
            this.Query = $"SELECT Id, BOL_ID, BOL_ID_ORIGEM, PRO_LARGURA_PECA, PRO_LARGURA_PECA_PROGRAMADO, PRO_COMPRIMENTO_PECA, PRO_COMPRIMENTO_PECA_PROGRAMADO, PRO_UTILIZOU_REFILE_OBRIGATORIO, PRO_VINCOS_RECALCULADOS, COR_SOLVER, COR_GRAMATURA_PAPEIS_PROGRAMADOS, COR_CUSTO_PAPEIS_PROGRAMADOS, COR_GRAMATURA_RESINA_PROGRAMADOS, COR_CUSTO_RESINA_PROGRAMADOS, COR_TOLERANCIA_MENOS, COR_TOLERANCIA_MAIS, COR_PILHAS_POR_PALETE, COR_M_LINEAR_REALIZADO, PRO_ID_PALETE, COR_STATUS_PALETE, COR_GRUPO_PRODUTIVO, TenantID, Deleted, Changed, UserId FROM CorridasOnduladeiraEstudo ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_COMPRIMENTO_PECA"] = value; //06
                      whereClauses.Add($" PRO_COMPRIMENTO_PECA = @PRO_COMPRIMENTO_PECA ");//06
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
            this.Query = $"SELECT Id, BOL_ID, BOL_ID_ORIGEM, PRO_LARGURA_PECA, PRO_LARGURA_PECA_PROGRAMADO, PRO_COMPRIMENTO_PECA, PRO_COMPRIMENTO_PECA_PROGRAMADO, PRO_UTILIZOU_REFILE_OBRIGATORIO, PRO_VINCOS_RECALCULADOS, COR_SOLVER, COR_GRAMATURA_PAPEIS_PROGRAMADOS, COR_CUSTO_PAPEIS_PROGRAMADOS, COR_GRAMATURA_RESINA_PROGRAMADOS, COR_CUSTO_RESINA_PROGRAMADOS, COR_TOLERANCIA_MENOS, COR_TOLERANCIA_MAIS, COR_PILHAS_POR_PALETE, COR_M_LINEAR_REALIZADO, PRO_ID_PALETE, COR_STATUS_PALETE, COR_GRUPO_PRODUTIVO, TenantID, Deleted, Changed, UserId FROM CorridasOnduladeiraEstudo ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_COMPRIMENTO_PECA_PROGRAMADO"] = value; //06
                      whereClauses.Add($" PRO_COMPRIMENTO_PECA_PROGRAMADO = @PRO_COMPRIMENTO_PECA_PROGRAMADO ");//06
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
            this.Query = $"SELECT Id, BOL_ID, BOL_ID_ORIGEM, PRO_LARGURA_PECA, PRO_LARGURA_PECA_PROGRAMADO, PRO_COMPRIMENTO_PECA, PRO_COMPRIMENTO_PECA_PROGRAMADO, PRO_UTILIZOU_REFILE_OBRIGATORIO, PRO_VINCOS_RECALCULADOS, COR_SOLVER, COR_GRAMATURA_PAPEIS_PROGRAMADOS, COR_CUSTO_PAPEIS_PROGRAMADOS, COR_GRAMATURA_RESINA_PROGRAMADOS, COR_CUSTO_RESINA_PROGRAMADOS, COR_TOLERANCIA_MENOS, COR_TOLERANCIA_MAIS, COR_PILHAS_POR_PALETE, COR_M_LINEAR_REALIZADO, PRO_ID_PALETE, COR_STATUS_PALETE, COR_GRUPO_PRODUTIVO, TenantID, Deleted, Changed, UserId FROM CorridasOnduladeiraEstudo ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_UTILIZOU_REFILE_OBRIGATORIO"] = value; //06
                      whereClauses.Add($" PRO_UTILIZOU_REFILE_OBRIGATORIO = @PRO_UTILIZOU_REFILE_OBRIGATORIO ");//06
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
            this.Query = $"SELECT Id, BOL_ID, BOL_ID_ORIGEM, PRO_LARGURA_PECA, PRO_LARGURA_PECA_PROGRAMADO, PRO_COMPRIMENTO_PECA, PRO_COMPRIMENTO_PECA_PROGRAMADO, PRO_UTILIZOU_REFILE_OBRIGATORIO, PRO_VINCOS_RECALCULADOS, COR_SOLVER, COR_GRAMATURA_PAPEIS_PROGRAMADOS, COR_CUSTO_PAPEIS_PROGRAMADOS, COR_GRAMATURA_RESINA_PROGRAMADOS, COR_CUSTO_RESINA_PROGRAMADOS, COR_TOLERANCIA_MENOS, COR_TOLERANCIA_MAIS, COR_PILHAS_POR_PALETE, COR_M_LINEAR_REALIZADO, PRO_ID_PALETE, COR_STATUS_PALETE, COR_GRUPO_PRODUTIVO, TenantID, Deleted, Changed, UserId FROM CorridasOnduladeiraEstudo ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_VINCOS_RECALCULADOS"] = value; //06
                      whereClauses.Add($" PRO_VINCOS_RECALCULADOS = @PRO_VINCOS_RECALCULADOS ");//06
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
            this.Query = $"SELECT Id, BOL_ID, BOL_ID_ORIGEM, PRO_LARGURA_PECA, PRO_LARGURA_PECA_PROGRAMADO, PRO_COMPRIMENTO_PECA, PRO_COMPRIMENTO_PECA_PROGRAMADO, PRO_UTILIZOU_REFILE_OBRIGATORIO, PRO_VINCOS_RECALCULADOS, COR_SOLVER, COR_GRAMATURA_PAPEIS_PROGRAMADOS, COR_CUSTO_PAPEIS_PROGRAMADOS, COR_GRAMATURA_RESINA_PROGRAMADOS, COR_CUSTO_RESINA_PROGRAMADOS, COR_TOLERANCIA_MENOS, COR_TOLERANCIA_MAIS, COR_PILHAS_POR_PALETE, COR_M_LINEAR_REALIZADO, PRO_ID_PALETE, COR_STATUS_PALETE, COR_GRUPO_PRODUTIVO, TenantID, Deleted, Changed, UserId FROM CorridasOnduladeiraEstudo ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["COR_SOLVER"] = value; //06
                      whereClauses.Add($" COR_SOLVER = @COR_SOLVER ");//06
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
            this.Query = $"SELECT Id, BOL_ID, BOL_ID_ORIGEM, PRO_LARGURA_PECA, PRO_LARGURA_PECA_PROGRAMADO, PRO_COMPRIMENTO_PECA, PRO_COMPRIMENTO_PECA_PROGRAMADO, PRO_UTILIZOU_REFILE_OBRIGATORIO, PRO_VINCOS_RECALCULADOS, COR_SOLVER, COR_GRAMATURA_PAPEIS_PROGRAMADOS, COR_CUSTO_PAPEIS_PROGRAMADOS, COR_GRAMATURA_RESINA_PROGRAMADOS, COR_CUSTO_RESINA_PROGRAMADOS, COR_TOLERANCIA_MENOS, COR_TOLERANCIA_MAIS, COR_PILHAS_POR_PALETE, COR_M_LINEAR_REALIZADO, PRO_ID_PALETE, COR_STATUS_PALETE, COR_GRUPO_PRODUTIVO, TenantID, Deleted, Changed, UserId FROM CorridasOnduladeiraEstudo ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["COR_GRAMATURA_PAPEIS_PROGRAMADOS"] = value; //06
                      whereClauses.Add($" COR_GRAMATURA_PAPEIS_PROGRAMADOS = @COR_GRAMATURA_PAPEIS_PROGRAMADOS ");//06
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
            this.Query = $"SELECT Id, BOL_ID, BOL_ID_ORIGEM, PRO_LARGURA_PECA, PRO_LARGURA_PECA_PROGRAMADO, PRO_COMPRIMENTO_PECA, PRO_COMPRIMENTO_PECA_PROGRAMADO, PRO_UTILIZOU_REFILE_OBRIGATORIO, PRO_VINCOS_RECALCULADOS, COR_SOLVER, COR_GRAMATURA_PAPEIS_PROGRAMADOS, COR_CUSTO_PAPEIS_PROGRAMADOS, COR_GRAMATURA_RESINA_PROGRAMADOS, COR_CUSTO_RESINA_PROGRAMADOS, COR_TOLERANCIA_MENOS, COR_TOLERANCIA_MAIS, COR_PILHAS_POR_PALETE, COR_M_LINEAR_REALIZADO, PRO_ID_PALETE, COR_STATUS_PALETE, COR_GRUPO_PRODUTIVO, TenantID, Deleted, Changed, UserId FROM CorridasOnduladeiraEstudo ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["COR_CUSTO_PAPEIS_PROGRAMADOS"] = value; //06
                      whereClauses.Add($" COR_CUSTO_PAPEIS_PROGRAMADOS = @COR_CUSTO_PAPEIS_PROGRAMADOS ");//06
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
            this.Query = $"SELECT Id, BOL_ID, BOL_ID_ORIGEM, PRO_LARGURA_PECA, PRO_LARGURA_PECA_PROGRAMADO, PRO_COMPRIMENTO_PECA, PRO_COMPRIMENTO_PECA_PROGRAMADO, PRO_UTILIZOU_REFILE_OBRIGATORIO, PRO_VINCOS_RECALCULADOS, COR_SOLVER, COR_GRAMATURA_PAPEIS_PROGRAMADOS, COR_CUSTO_PAPEIS_PROGRAMADOS, COR_GRAMATURA_RESINA_PROGRAMADOS, COR_CUSTO_RESINA_PROGRAMADOS, COR_TOLERANCIA_MENOS, COR_TOLERANCIA_MAIS, COR_PILHAS_POR_PALETE, COR_M_LINEAR_REALIZADO, PRO_ID_PALETE, COR_STATUS_PALETE, COR_GRUPO_PRODUTIVO, TenantID, Deleted, Changed, UserId FROM CorridasOnduladeiraEstudo ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["COR_GRAMATURA_RESINA_PROGRAMADOS"] = value; //06
                      whereClauses.Add($" COR_GRAMATURA_RESINA_PROGRAMADOS = @COR_GRAMATURA_RESINA_PROGRAMADOS ");//06
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
            this.Query = $"SELECT Id, BOL_ID, BOL_ID_ORIGEM, PRO_LARGURA_PECA, PRO_LARGURA_PECA_PROGRAMADO, PRO_COMPRIMENTO_PECA, PRO_COMPRIMENTO_PECA_PROGRAMADO, PRO_UTILIZOU_REFILE_OBRIGATORIO, PRO_VINCOS_RECALCULADOS, COR_SOLVER, COR_GRAMATURA_PAPEIS_PROGRAMADOS, COR_CUSTO_PAPEIS_PROGRAMADOS, COR_GRAMATURA_RESINA_PROGRAMADOS, COR_CUSTO_RESINA_PROGRAMADOS, COR_TOLERANCIA_MENOS, COR_TOLERANCIA_MAIS, COR_PILHAS_POR_PALETE, COR_M_LINEAR_REALIZADO, PRO_ID_PALETE, COR_STATUS_PALETE, COR_GRUPO_PRODUTIVO, TenantID, Deleted, Changed, UserId FROM CorridasOnduladeiraEstudo ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["COR_CUSTO_RESINA_PROGRAMADOS"] = value; //06
                      whereClauses.Add($" COR_CUSTO_RESINA_PROGRAMADOS = @COR_CUSTO_RESINA_PROGRAMADOS ");//06
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
            this.Query = $"SELECT Id, BOL_ID, BOL_ID_ORIGEM, PRO_LARGURA_PECA, PRO_LARGURA_PECA_PROGRAMADO, PRO_COMPRIMENTO_PECA, PRO_COMPRIMENTO_PECA_PROGRAMADO, PRO_UTILIZOU_REFILE_OBRIGATORIO, PRO_VINCOS_RECALCULADOS, COR_SOLVER, COR_GRAMATURA_PAPEIS_PROGRAMADOS, COR_CUSTO_PAPEIS_PROGRAMADOS, COR_GRAMATURA_RESINA_PROGRAMADOS, COR_CUSTO_RESINA_PROGRAMADOS, COR_TOLERANCIA_MENOS, COR_TOLERANCIA_MAIS, COR_PILHAS_POR_PALETE, COR_M_LINEAR_REALIZADO, PRO_ID_PALETE, COR_STATUS_PALETE, COR_GRUPO_PRODUTIVO, TenantID, Deleted, Changed, UserId FROM CorridasOnduladeiraEstudo ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["COR_TOLERANCIA_MENOS"] = value; //06
                      whereClauses.Add($" COR_TOLERANCIA_MENOS = @COR_TOLERANCIA_MENOS ");//06
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
            this.Query = $"SELECT Id, BOL_ID, BOL_ID_ORIGEM, PRO_LARGURA_PECA, PRO_LARGURA_PECA_PROGRAMADO, PRO_COMPRIMENTO_PECA, PRO_COMPRIMENTO_PECA_PROGRAMADO, PRO_UTILIZOU_REFILE_OBRIGATORIO, PRO_VINCOS_RECALCULADOS, COR_SOLVER, COR_GRAMATURA_PAPEIS_PROGRAMADOS, COR_CUSTO_PAPEIS_PROGRAMADOS, COR_GRAMATURA_RESINA_PROGRAMADOS, COR_CUSTO_RESINA_PROGRAMADOS, COR_TOLERANCIA_MENOS, COR_TOLERANCIA_MAIS, COR_PILHAS_POR_PALETE, COR_M_LINEAR_REALIZADO, PRO_ID_PALETE, COR_STATUS_PALETE, COR_GRUPO_PRODUTIVO, TenantID, Deleted, Changed, UserId FROM CorridasOnduladeiraEstudo ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["COR_TOLERANCIA_MAIS"] = value; //06
                      whereClauses.Add($" COR_TOLERANCIA_MAIS = @COR_TOLERANCIA_MAIS ");//06
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
            this.Query = $"SELECT Id, BOL_ID, BOL_ID_ORIGEM, PRO_LARGURA_PECA, PRO_LARGURA_PECA_PROGRAMADO, PRO_COMPRIMENTO_PECA, PRO_COMPRIMENTO_PECA_PROGRAMADO, PRO_UTILIZOU_REFILE_OBRIGATORIO, PRO_VINCOS_RECALCULADOS, COR_SOLVER, COR_GRAMATURA_PAPEIS_PROGRAMADOS, COR_CUSTO_PAPEIS_PROGRAMADOS, COR_GRAMATURA_RESINA_PROGRAMADOS, COR_CUSTO_RESINA_PROGRAMADOS, COR_TOLERANCIA_MENOS, COR_TOLERANCIA_MAIS, COR_PILHAS_POR_PALETE, COR_M_LINEAR_REALIZADO, PRO_ID_PALETE, COR_STATUS_PALETE, COR_GRUPO_PRODUTIVO, TenantID, Deleted, Changed, UserId FROM CorridasOnduladeiraEstudo ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["COR_PILHAS_POR_PALETE"] = value; //06
                      whereClauses.Add($" COR_PILHAS_POR_PALETE = @COR_PILHAS_POR_PALETE ");//06
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
            this.Query = $"SELECT Id, BOL_ID, BOL_ID_ORIGEM, PRO_LARGURA_PECA, PRO_LARGURA_PECA_PROGRAMADO, PRO_COMPRIMENTO_PECA, PRO_COMPRIMENTO_PECA_PROGRAMADO, PRO_UTILIZOU_REFILE_OBRIGATORIO, PRO_VINCOS_RECALCULADOS, COR_SOLVER, COR_GRAMATURA_PAPEIS_PROGRAMADOS, COR_CUSTO_PAPEIS_PROGRAMADOS, COR_GRAMATURA_RESINA_PROGRAMADOS, COR_CUSTO_RESINA_PROGRAMADOS, COR_TOLERANCIA_MENOS, COR_TOLERANCIA_MAIS, COR_PILHAS_POR_PALETE, COR_M_LINEAR_REALIZADO, PRO_ID_PALETE, COR_STATUS_PALETE, COR_GRUPO_PRODUTIVO, TenantID, Deleted, Changed, UserId FROM CorridasOnduladeiraEstudo ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["COR_M_LINEAR_REALIZADO"] = value; //06
                      whereClauses.Add($" COR_M_LINEAR_REALIZADO = @COR_M_LINEAR_REALIZADO ");//06
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
            this.Query = $"SELECT Id, BOL_ID, BOL_ID_ORIGEM, PRO_LARGURA_PECA, PRO_LARGURA_PECA_PROGRAMADO, PRO_COMPRIMENTO_PECA, PRO_COMPRIMENTO_PECA_PROGRAMADO, PRO_UTILIZOU_REFILE_OBRIGATORIO, PRO_VINCOS_RECALCULADOS, COR_SOLVER, COR_GRAMATURA_PAPEIS_PROGRAMADOS, COR_CUSTO_PAPEIS_PROGRAMADOS, COR_GRAMATURA_RESINA_PROGRAMADOS, COR_CUSTO_RESINA_PROGRAMADOS, COR_TOLERANCIA_MENOS, COR_TOLERANCIA_MAIS, COR_PILHAS_POR_PALETE, COR_M_LINEAR_REALIZADO, PRO_ID_PALETE, COR_STATUS_PALETE, COR_GRUPO_PRODUTIVO, TenantID, Deleted, Changed, UserId FROM CorridasOnduladeiraEstudo ";
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
        public QueryModel FirstByCOR_STATUS_PALETEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, BOL_ID, BOL_ID_ORIGEM, PRO_LARGURA_PECA, PRO_LARGURA_PECA_PROGRAMADO, PRO_COMPRIMENTO_PECA, PRO_COMPRIMENTO_PECA_PROGRAMADO, PRO_UTILIZOU_REFILE_OBRIGATORIO, PRO_VINCOS_RECALCULADOS, COR_SOLVER, COR_GRAMATURA_PAPEIS_PROGRAMADOS, COR_CUSTO_PAPEIS_PROGRAMADOS, COR_GRAMATURA_RESINA_PROGRAMADOS, COR_CUSTO_RESINA_PROGRAMADOS, COR_TOLERANCIA_MENOS, COR_TOLERANCIA_MAIS, COR_PILHAS_POR_PALETE, COR_M_LINEAR_REALIZADO, PRO_ID_PALETE, COR_STATUS_PALETE, COR_GRUPO_PRODUTIVO, TenantID, Deleted, Changed, UserId FROM CorridasOnduladeiraEstudo ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["COR_STATUS_PALETE"] = value; //06
                      whereClauses.Add($" COR_STATUS_PALETE = @COR_STATUS_PALETE ");//06
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
            this.Query = $"SELECT Id, BOL_ID, BOL_ID_ORIGEM, PRO_LARGURA_PECA, PRO_LARGURA_PECA_PROGRAMADO, PRO_COMPRIMENTO_PECA, PRO_COMPRIMENTO_PECA_PROGRAMADO, PRO_UTILIZOU_REFILE_OBRIGATORIO, PRO_VINCOS_RECALCULADOS, COR_SOLVER, COR_GRAMATURA_PAPEIS_PROGRAMADOS, COR_CUSTO_PAPEIS_PROGRAMADOS, COR_GRAMATURA_RESINA_PROGRAMADOS, COR_CUSTO_RESINA_PROGRAMADOS, COR_TOLERANCIA_MENOS, COR_TOLERANCIA_MAIS, COR_PILHAS_POR_PALETE, COR_M_LINEAR_REALIZADO, PRO_ID_PALETE, COR_STATUS_PALETE, COR_GRUPO_PRODUTIVO, TenantID, Deleted, Changed, UserId FROM CorridasOnduladeiraEstudo ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["COR_GRUPO_PRODUTIVO"] = value; //06
                      whereClauses.Add($" COR_GRUPO_PRODUTIVO = @COR_GRUPO_PRODUTIVO ");//06
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
            this.Query = $"SELECT Id, BOL_ID, BOL_ID_ORIGEM, PRO_LARGURA_PECA, PRO_LARGURA_PECA_PROGRAMADO, PRO_COMPRIMENTO_PECA, PRO_COMPRIMENTO_PECA_PROGRAMADO, PRO_UTILIZOU_REFILE_OBRIGATORIO, PRO_VINCOS_RECALCULADOS, COR_SOLVER, COR_GRAMATURA_PAPEIS_PROGRAMADOS, COR_CUSTO_PAPEIS_PROGRAMADOS, COR_GRAMATURA_RESINA_PROGRAMADOS, COR_CUSTO_RESINA_PROGRAMADOS, COR_TOLERANCIA_MENOS, COR_TOLERANCIA_MAIS, COR_PILHAS_POR_PALETE, COR_M_LINEAR_REALIZADO, PRO_ID_PALETE, COR_STATUS_PALETE, COR_GRUPO_PRODUTIVO, TenantID, Deleted, Changed, UserId FROM CorridasOnduladeiraEstudo ";
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
            this.Query = $"SELECT Id, BOL_ID, BOL_ID_ORIGEM, PRO_LARGURA_PECA, PRO_LARGURA_PECA_PROGRAMADO, PRO_COMPRIMENTO_PECA, PRO_COMPRIMENTO_PECA_PROGRAMADO, PRO_UTILIZOU_REFILE_OBRIGATORIO, PRO_VINCOS_RECALCULADOS, COR_SOLVER, COR_GRAMATURA_PAPEIS_PROGRAMADOS, COR_CUSTO_PAPEIS_PROGRAMADOS, COR_GRAMATURA_RESINA_PROGRAMADOS, COR_CUSTO_RESINA_PROGRAMADOS, COR_TOLERANCIA_MENOS, COR_TOLERANCIA_MAIS, COR_PILHAS_POR_PALETE, COR_M_LINEAR_REALIZADO, PRO_ID_PALETE, COR_STATUS_PALETE, COR_GRUPO_PRODUTIVO, TenantID, Deleted, Changed, UserId FROM CorridasOnduladeiraEstudo ";
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
            this.Query = $"SELECT Id, BOL_ID, BOL_ID_ORIGEM, PRO_LARGURA_PECA, PRO_LARGURA_PECA_PROGRAMADO, PRO_COMPRIMENTO_PECA, PRO_COMPRIMENTO_PECA_PROGRAMADO, PRO_UTILIZOU_REFILE_OBRIGATORIO, PRO_VINCOS_RECALCULADOS, COR_SOLVER, COR_GRAMATURA_PAPEIS_PROGRAMADOS, COR_CUSTO_PAPEIS_PROGRAMADOS, COR_GRAMATURA_RESINA_PROGRAMADOS, COR_CUSTO_RESINA_PROGRAMADOS, COR_TOLERANCIA_MENOS, COR_TOLERANCIA_MAIS, COR_PILHAS_POR_PALETE, COR_M_LINEAR_REALIZADO, PRO_ID_PALETE, COR_STATUS_PALETE, COR_GRUPO_PRODUTIVO, TenantID, Deleted, Changed, UserId FROM CorridasOnduladeiraEstudo ";
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
            this.Query = $"SELECT Id, BOL_ID, BOL_ID_ORIGEM, PRO_LARGURA_PECA, PRO_LARGURA_PECA_PROGRAMADO, PRO_COMPRIMENTO_PECA, PRO_COMPRIMENTO_PECA_PROGRAMADO, PRO_UTILIZOU_REFILE_OBRIGATORIO, PRO_VINCOS_RECALCULADOS, COR_SOLVER, COR_GRAMATURA_PAPEIS_PROGRAMADOS, COR_CUSTO_PAPEIS_PROGRAMADOS, COR_GRAMATURA_RESINA_PROGRAMADOS, COR_CUSTO_RESINA_PROGRAMADOS, COR_TOLERANCIA_MENOS, COR_TOLERANCIA_MAIS, COR_PILHAS_POR_PALETE, COR_M_LINEAR_REALIZADO, PRO_ID_PALETE, COR_STATUS_PALETE, COR_GRUPO_PRODUTIVO, TenantID, Deleted, Changed, UserId FROM CorridasOnduladeiraEstudo ";
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