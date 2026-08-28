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
    public class BoletimQueryRead : QueryBase, IBoletimQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public BoletimQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel BoletimQuery(Command.Read.BoletimReadCommand Command )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select Id, BOL_ID, BOL_ID_ORIGEM, BOL_SOLVER, BOL_INTEGRACAO, BOL_SEQUENCIA, GRP_PAP_GRAMATURA_PROGRAMADO, GRP_ID_PROGRAMADO, GRP_PAPEL1_PROGRAMADO, GRP_PAPEL2_PROGRAMADO, GRP_PAPEL3_PROGRAMADO, GRP_PAPEL4_PROGRAMADO, GRP_PAPEL5_PROGRAMADO, BOL_STATUS_INTERFACE, BOL_TIPO, BOL_FORMATO, BOL_GRAMATURA_PAPEIS_PROGRAMADOS, BOL_GRAMATURA_PAPEIS_REALIZADO, BOL_CUSTO_PAPEIS_PROGRAMADOS, BOL_CUSTO_PAPEIS_REALIZADO, BOL_GRAMATURA_RESINA_PROGRAMADOS, BOL_CUSTO_RESINA_PROGRAMADOS, BOL_REFILE_OBRIGATORIO, BOL_OBS, TenantID, Deleted, Changed, UserId from Boletim ";
if (Command.Id.HasValue) dict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"Id = @Id");
if (!string.IsNullOrEmpty(Command.BOL_ID)) dict["BOL_ID"] = $"%{Command.BOL_ID}%";
if (!string.IsNullOrEmpty(Command.BOL_ID)) whereClauses.Add($"BOL_ID like @BOL_ID");
if (!string.IsNullOrEmpty(Command.BOL_ID_ORIGEM)) dict["BOL_ID_ORIGEM"] = $"%{Command.BOL_ID_ORIGEM}%";
if (!string.IsNullOrEmpty(Command.BOL_ID_ORIGEM)) whereClauses.Add($"BOL_ID_ORIGEM like @BOL_ID_ORIGEM");
if (!string.IsNullOrEmpty(Command.BOL_SOLVER)) dict["BOL_SOLVER"] = $"%{Command.BOL_SOLVER}%";
if (!string.IsNullOrEmpty(Command.BOL_SOLVER)) whereClauses.Add($"BOL_SOLVER like @BOL_SOLVER");
if (!string.IsNullOrEmpty(Command.BOL_INTEGRACAO)) dict["BOL_INTEGRACAO"] = $"%{Command.BOL_INTEGRACAO}%";
if (!string.IsNullOrEmpty(Command.BOL_INTEGRACAO)) whereClauses.Add($"BOL_INTEGRACAO like @BOL_INTEGRACAO");
if (!string.IsNullOrEmpty(Command.GRP_ID_PROGRAMADO)) dict["GRP_ID_PROGRAMADO"] = $"%{Command.GRP_ID_PROGRAMADO}%";
if (!string.IsNullOrEmpty(Command.GRP_ID_PROGRAMADO)) whereClauses.Add($"GRP_ID_PROGRAMADO like @GRP_ID_PROGRAMADO");
if (!string.IsNullOrEmpty(Command.GRP_PAPEL1_PROGRAMADO)) dict["GRP_PAPEL1_PROGRAMADO"] = $"%{Command.GRP_PAPEL1_PROGRAMADO}%";
if (!string.IsNullOrEmpty(Command.GRP_PAPEL1_PROGRAMADO)) whereClauses.Add($"GRP_PAPEL1_PROGRAMADO like @GRP_PAPEL1_PROGRAMADO");
if (!string.IsNullOrEmpty(Command.GRP_PAPEL2_PROGRAMADO)) dict["GRP_PAPEL2_PROGRAMADO"] = $"%{Command.GRP_PAPEL2_PROGRAMADO}%";
if (!string.IsNullOrEmpty(Command.GRP_PAPEL2_PROGRAMADO)) whereClauses.Add($"GRP_PAPEL2_PROGRAMADO like @GRP_PAPEL2_PROGRAMADO");
if (!string.IsNullOrEmpty(Command.GRP_PAPEL3_PROGRAMADO)) dict["GRP_PAPEL3_PROGRAMADO"] = $"%{Command.GRP_PAPEL3_PROGRAMADO}%";
if (!string.IsNullOrEmpty(Command.GRP_PAPEL3_PROGRAMADO)) whereClauses.Add($"GRP_PAPEL3_PROGRAMADO like @GRP_PAPEL3_PROGRAMADO");
if (!string.IsNullOrEmpty(Command.GRP_PAPEL4_PROGRAMADO)) dict["GRP_PAPEL4_PROGRAMADO"] = $"%{Command.GRP_PAPEL4_PROGRAMADO}%";
if (!string.IsNullOrEmpty(Command.GRP_PAPEL4_PROGRAMADO)) whereClauses.Add($"GRP_PAPEL4_PROGRAMADO like @GRP_PAPEL4_PROGRAMADO");
if (!string.IsNullOrEmpty(Command.GRP_PAPEL5_PROGRAMADO)) dict["GRP_PAPEL5_PROGRAMADO"] = $"%{Command.GRP_PAPEL5_PROGRAMADO}%";
if (!string.IsNullOrEmpty(Command.GRP_PAPEL5_PROGRAMADO)) whereClauses.Add($"GRP_PAPEL5_PROGRAMADO like @GRP_PAPEL5_PROGRAMADO");
if (!string.IsNullOrEmpty(Command.BOL_STATUS_INTERFACE)) dict["BOL_STATUS_INTERFACE"] = $"%{Command.BOL_STATUS_INTERFACE}%";
if (!string.IsNullOrEmpty(Command.BOL_STATUS_INTERFACE)) whereClauses.Add($"BOL_STATUS_INTERFACE like @BOL_STATUS_INTERFACE");
if (!string.IsNullOrEmpty(Command.BOL_TIPO)) dict["BOL_TIPO"] = $"%{Command.BOL_TIPO}%";
if (!string.IsNullOrEmpty(Command.BOL_TIPO)) whereClauses.Add($"BOL_TIPO like @BOL_TIPO");
if (Command.BOL_FORMATO.HasValue) dict["BOL_FORMATO"] = Command.BOL_FORMATO.Value;
if (Command.BOL_FORMATO.HasValue) whereClauses.Add($"BOL_FORMATO = @BOL_FORMATO");
if (Command.BOL_REFILE_OBRIGATORIO.HasValue) dict["BOL_REFILE_OBRIGATORIO"] = Command.BOL_REFILE_OBRIGATORIO.Value;
if (Command.BOL_REFILE_OBRIGATORIO.HasValue) whereClauses.Add($"BOL_REFILE_OBRIGATORIO = @BOL_REFILE_OBRIGATORIO");
if (!string.IsNullOrEmpty(Command.BOL_OBS)) dict["BOL_OBS"] = $"%{Command.BOL_OBS}%";
if (!string.IsNullOrEmpty(Command.BOL_OBS)) whereClauses.Add($"BOL_OBS like @BOL_OBS");
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
        public QueryModel BoletimGRP_ID_PROGRAMADOQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select GRP_ID from GrupoProdutoAbstrato ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["GRP_ID"] = numero; //01
                      whereClauses.Add($" GRP_ID = @GRP_ID");//01 
                 }
                 else 
                 {
                      dict["GRP_ID"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" GRP_ID like @GRP_ID ");//02
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
        public QueryModel BoletimTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel BoletimUserIdQuery(Command.Patterns.Command.SearchFKCommand Command )
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
            this.Query = $"SELECT 1 FROM Boletim ";
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
            this.Query = $"SELECT 1 FROM Boletim ";
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
            this.Query = $"SELECT 1 FROM Boletim ";
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
        public QueryModel ExistsByBOL_SOLVERQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Boletim ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["BOL_SOLVER"] = value; //04
                      whereClauses.Add($" BOL_SOLVER = @BOL_SOLVER ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByBOL_INTEGRACAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Boletim ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["BOL_INTEGRACAO"] = value; //04
                      whereClauses.Add($" BOL_INTEGRACAO = @BOL_INTEGRACAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByBOL_SEQUENCIAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Boletim ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["BOL_SEQUENCIA"] = value; //04
                      whereClauses.Add($" BOL_SEQUENCIA = @BOL_SEQUENCIA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRP_PAP_GRAMATURA_PROGRAMADOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Boletim ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_PAP_GRAMATURA_PROGRAMADO"] = value; //04
                      whereClauses.Add($" GRP_PAP_GRAMATURA_PROGRAMADO = @GRP_PAP_GRAMATURA_PROGRAMADO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRP_ID_PROGRAMADOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Boletim ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_ID_PROGRAMADO"] = value; //04
                      whereClauses.Add($" GRP_ID_PROGRAMADO = @GRP_ID_PROGRAMADO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRP_PAPEL1_PROGRAMADOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Boletim ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_PAPEL1_PROGRAMADO"] = value; //04
                      whereClauses.Add($" GRP_PAPEL1_PROGRAMADO = @GRP_PAPEL1_PROGRAMADO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRP_PAPEL2_PROGRAMADOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Boletim ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_PAPEL2_PROGRAMADO"] = value; //04
                      whereClauses.Add($" GRP_PAPEL2_PROGRAMADO = @GRP_PAPEL2_PROGRAMADO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRP_PAPEL3_PROGRAMADOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Boletim ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_PAPEL3_PROGRAMADO"] = value; //04
                      whereClauses.Add($" GRP_PAPEL3_PROGRAMADO = @GRP_PAPEL3_PROGRAMADO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRP_PAPEL4_PROGRAMADOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Boletim ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_PAPEL4_PROGRAMADO"] = value; //04
                      whereClauses.Add($" GRP_PAPEL4_PROGRAMADO = @GRP_PAPEL4_PROGRAMADO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRP_PAPEL5_PROGRAMADOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Boletim ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_PAPEL5_PROGRAMADO"] = value; //04
                      whereClauses.Add($" GRP_PAPEL5_PROGRAMADO = @GRP_PAPEL5_PROGRAMADO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByBOL_STATUS_INTERFACEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Boletim ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["BOL_STATUS_INTERFACE"] = value; //04
                      whereClauses.Add($" BOL_STATUS_INTERFACE = @BOL_STATUS_INTERFACE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByBOL_TIPOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Boletim ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["BOL_TIPO"] = value; //04
                      whereClauses.Add($" BOL_TIPO = @BOL_TIPO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByBOL_FORMATOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Boletim ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["BOL_FORMATO"] = value; //04
                      whereClauses.Add($" BOL_FORMATO = @BOL_FORMATO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByBOL_GRAMATURA_PAPEIS_PROGRAMADOSQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Boletim ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["BOL_GRAMATURA_PAPEIS_PROGRAMADOS"] = value; //04
                      whereClauses.Add($" BOL_GRAMATURA_PAPEIS_PROGRAMADOS = @BOL_GRAMATURA_PAPEIS_PROGRAMADOS ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByBOL_GRAMATURA_PAPEIS_REALIZADOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Boletim ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["BOL_GRAMATURA_PAPEIS_REALIZADO"] = value; //04
                      whereClauses.Add($" BOL_GRAMATURA_PAPEIS_REALIZADO = @BOL_GRAMATURA_PAPEIS_REALIZADO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByBOL_CUSTO_PAPEIS_PROGRAMADOSQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Boletim ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["BOL_CUSTO_PAPEIS_PROGRAMADOS"] = value; //04
                      whereClauses.Add($" BOL_CUSTO_PAPEIS_PROGRAMADOS = @BOL_CUSTO_PAPEIS_PROGRAMADOS ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByBOL_CUSTO_PAPEIS_REALIZADOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Boletim ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["BOL_CUSTO_PAPEIS_REALIZADO"] = value; //04
                      whereClauses.Add($" BOL_CUSTO_PAPEIS_REALIZADO = @BOL_CUSTO_PAPEIS_REALIZADO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByBOL_GRAMATURA_RESINA_PROGRAMADOSQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Boletim ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["BOL_GRAMATURA_RESINA_PROGRAMADOS"] = value; //04
                      whereClauses.Add($" BOL_GRAMATURA_RESINA_PROGRAMADOS = @BOL_GRAMATURA_RESINA_PROGRAMADOS ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByBOL_CUSTO_RESINA_PROGRAMADOSQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Boletim ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["BOL_CUSTO_RESINA_PROGRAMADOS"] = value; //04
                      whereClauses.Add($" BOL_CUSTO_RESINA_PROGRAMADOS = @BOL_CUSTO_RESINA_PROGRAMADOS ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByBOL_REFILE_OBRIGATORIOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Boletim ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["BOL_REFILE_OBRIGATORIO"] = value; //04
                      whereClauses.Add($" BOL_REFILE_OBRIGATORIO = @BOL_REFILE_OBRIGATORIO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByBOL_OBSQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Boletim ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["BOL_OBS"] = value; //04
                      whereClauses.Add($" BOL_OBS = @BOL_OBS ");//04
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
            this.Query = $"SELECT 1 FROM Boletim ";
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
            this.Query = $"SELECT 1 FROM Boletim ";
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
            this.Query = $"SELECT 1 FROM Boletim ";
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
            this.Query = $"SELECT 1 FROM Boletim ";
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
            this.Query = $"SELECT Id, BOL_ID, BOL_ID_ORIGEM, BOL_SOLVER, BOL_INTEGRACAO, BOL_SEQUENCIA, GRP_PAP_GRAMATURA_PROGRAMADO, GRP_ID_PROGRAMADO, GRP_PAPEL1_PROGRAMADO, GRP_PAPEL2_PROGRAMADO, GRP_PAPEL3_PROGRAMADO, GRP_PAPEL4_PROGRAMADO, GRP_PAPEL5_PROGRAMADO, BOL_STATUS_INTERFACE, BOL_TIPO, BOL_FORMATO, BOL_GRAMATURA_PAPEIS_PROGRAMADOS, BOL_GRAMATURA_PAPEIS_REALIZADO, BOL_CUSTO_PAPEIS_PROGRAMADOS, BOL_CUSTO_PAPEIS_REALIZADO, BOL_GRAMATURA_RESINA_PROGRAMADOS, BOL_CUSTO_RESINA_PROGRAMADOS, BOL_REFILE_OBRIGATORIO, BOL_OBS, TenantID, Deleted, Changed, UserId FROM Boletim ";
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
            this.Query = $"SELECT Id, BOL_ID, BOL_ID_ORIGEM, BOL_SOLVER, BOL_INTEGRACAO, BOL_SEQUENCIA, GRP_PAP_GRAMATURA_PROGRAMADO, GRP_ID_PROGRAMADO, GRP_PAPEL1_PROGRAMADO, GRP_PAPEL2_PROGRAMADO, GRP_PAPEL3_PROGRAMADO, GRP_PAPEL4_PROGRAMADO, GRP_PAPEL5_PROGRAMADO, BOL_STATUS_INTERFACE, BOL_TIPO, BOL_FORMATO, BOL_GRAMATURA_PAPEIS_PROGRAMADOS, BOL_GRAMATURA_PAPEIS_REALIZADO, BOL_CUSTO_PAPEIS_PROGRAMADOS, BOL_CUSTO_PAPEIS_REALIZADO, BOL_GRAMATURA_RESINA_PROGRAMADOS, BOL_CUSTO_RESINA_PROGRAMADOS, BOL_REFILE_OBRIGATORIO, BOL_OBS, TenantID, Deleted, Changed, UserId FROM Boletim ";
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
            this.Query = $"SELECT Id, BOL_ID, BOL_ID_ORIGEM, BOL_SOLVER, BOL_INTEGRACAO, BOL_SEQUENCIA, GRP_PAP_GRAMATURA_PROGRAMADO, GRP_ID_PROGRAMADO, GRP_PAPEL1_PROGRAMADO, GRP_PAPEL2_PROGRAMADO, GRP_PAPEL3_PROGRAMADO, GRP_PAPEL4_PROGRAMADO, GRP_PAPEL5_PROGRAMADO, BOL_STATUS_INTERFACE, BOL_TIPO, BOL_FORMATO, BOL_GRAMATURA_PAPEIS_PROGRAMADOS, BOL_GRAMATURA_PAPEIS_REALIZADO, BOL_CUSTO_PAPEIS_PROGRAMADOS, BOL_CUSTO_PAPEIS_REALIZADO, BOL_GRAMATURA_RESINA_PROGRAMADOS, BOL_CUSTO_RESINA_PROGRAMADOS, BOL_REFILE_OBRIGATORIO, BOL_OBS, TenantID, Deleted, Changed, UserId FROM Boletim ";
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
        public QueryModel FirstByBOL_SOLVERQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, BOL_ID, BOL_ID_ORIGEM, BOL_SOLVER, BOL_INTEGRACAO, BOL_SEQUENCIA, GRP_PAP_GRAMATURA_PROGRAMADO, GRP_ID_PROGRAMADO, GRP_PAPEL1_PROGRAMADO, GRP_PAPEL2_PROGRAMADO, GRP_PAPEL3_PROGRAMADO, GRP_PAPEL4_PROGRAMADO, GRP_PAPEL5_PROGRAMADO, BOL_STATUS_INTERFACE, BOL_TIPO, BOL_FORMATO, BOL_GRAMATURA_PAPEIS_PROGRAMADOS, BOL_GRAMATURA_PAPEIS_REALIZADO, BOL_CUSTO_PAPEIS_PROGRAMADOS, BOL_CUSTO_PAPEIS_REALIZADO, BOL_GRAMATURA_RESINA_PROGRAMADOS, BOL_CUSTO_RESINA_PROGRAMADOS, BOL_REFILE_OBRIGATORIO, BOL_OBS, TenantID, Deleted, Changed, UserId FROM Boletim ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["BOL_SOLVER"] = value; //06
                      whereClauses.Add($" BOL_SOLVER = @BOL_SOLVER ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByBOL_INTEGRACAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, BOL_ID, BOL_ID_ORIGEM, BOL_SOLVER, BOL_INTEGRACAO, BOL_SEQUENCIA, GRP_PAP_GRAMATURA_PROGRAMADO, GRP_ID_PROGRAMADO, GRP_PAPEL1_PROGRAMADO, GRP_PAPEL2_PROGRAMADO, GRP_PAPEL3_PROGRAMADO, GRP_PAPEL4_PROGRAMADO, GRP_PAPEL5_PROGRAMADO, BOL_STATUS_INTERFACE, BOL_TIPO, BOL_FORMATO, BOL_GRAMATURA_PAPEIS_PROGRAMADOS, BOL_GRAMATURA_PAPEIS_REALIZADO, BOL_CUSTO_PAPEIS_PROGRAMADOS, BOL_CUSTO_PAPEIS_REALIZADO, BOL_GRAMATURA_RESINA_PROGRAMADOS, BOL_CUSTO_RESINA_PROGRAMADOS, BOL_REFILE_OBRIGATORIO, BOL_OBS, TenantID, Deleted, Changed, UserId FROM Boletim ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["BOL_INTEGRACAO"] = value; //06
                      whereClauses.Add($" BOL_INTEGRACAO = @BOL_INTEGRACAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByBOL_SEQUENCIAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, BOL_ID, BOL_ID_ORIGEM, BOL_SOLVER, BOL_INTEGRACAO, BOL_SEQUENCIA, GRP_PAP_GRAMATURA_PROGRAMADO, GRP_ID_PROGRAMADO, GRP_PAPEL1_PROGRAMADO, GRP_PAPEL2_PROGRAMADO, GRP_PAPEL3_PROGRAMADO, GRP_PAPEL4_PROGRAMADO, GRP_PAPEL5_PROGRAMADO, BOL_STATUS_INTERFACE, BOL_TIPO, BOL_FORMATO, BOL_GRAMATURA_PAPEIS_PROGRAMADOS, BOL_GRAMATURA_PAPEIS_REALIZADO, BOL_CUSTO_PAPEIS_PROGRAMADOS, BOL_CUSTO_PAPEIS_REALIZADO, BOL_GRAMATURA_RESINA_PROGRAMADOS, BOL_CUSTO_RESINA_PROGRAMADOS, BOL_REFILE_OBRIGATORIO, BOL_OBS, TenantID, Deleted, Changed, UserId FROM Boletim ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["BOL_SEQUENCIA"] = value; //06
                      whereClauses.Add($" BOL_SEQUENCIA = @BOL_SEQUENCIA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRP_PAP_GRAMATURA_PROGRAMADOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, BOL_ID, BOL_ID_ORIGEM, BOL_SOLVER, BOL_INTEGRACAO, BOL_SEQUENCIA, GRP_PAP_GRAMATURA_PROGRAMADO, GRP_ID_PROGRAMADO, GRP_PAPEL1_PROGRAMADO, GRP_PAPEL2_PROGRAMADO, GRP_PAPEL3_PROGRAMADO, GRP_PAPEL4_PROGRAMADO, GRP_PAPEL5_PROGRAMADO, BOL_STATUS_INTERFACE, BOL_TIPO, BOL_FORMATO, BOL_GRAMATURA_PAPEIS_PROGRAMADOS, BOL_GRAMATURA_PAPEIS_REALIZADO, BOL_CUSTO_PAPEIS_PROGRAMADOS, BOL_CUSTO_PAPEIS_REALIZADO, BOL_GRAMATURA_RESINA_PROGRAMADOS, BOL_CUSTO_RESINA_PROGRAMADOS, BOL_REFILE_OBRIGATORIO, BOL_OBS, TenantID, Deleted, Changed, UserId FROM Boletim ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_PAP_GRAMATURA_PROGRAMADO"] = value; //06
                      whereClauses.Add($" GRP_PAP_GRAMATURA_PROGRAMADO = @GRP_PAP_GRAMATURA_PROGRAMADO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRP_ID_PROGRAMADOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, BOL_ID, BOL_ID_ORIGEM, BOL_SOLVER, BOL_INTEGRACAO, BOL_SEQUENCIA, GRP_PAP_GRAMATURA_PROGRAMADO, GRP_ID_PROGRAMADO, GRP_PAPEL1_PROGRAMADO, GRP_PAPEL2_PROGRAMADO, GRP_PAPEL3_PROGRAMADO, GRP_PAPEL4_PROGRAMADO, GRP_PAPEL5_PROGRAMADO, BOL_STATUS_INTERFACE, BOL_TIPO, BOL_FORMATO, BOL_GRAMATURA_PAPEIS_PROGRAMADOS, BOL_GRAMATURA_PAPEIS_REALIZADO, BOL_CUSTO_PAPEIS_PROGRAMADOS, BOL_CUSTO_PAPEIS_REALIZADO, BOL_GRAMATURA_RESINA_PROGRAMADOS, BOL_CUSTO_RESINA_PROGRAMADOS, BOL_REFILE_OBRIGATORIO, BOL_OBS, TenantID, Deleted, Changed, UserId FROM Boletim ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_ID_PROGRAMADO"] = value; //06
                      whereClauses.Add($" GRP_ID_PROGRAMADO = @GRP_ID_PROGRAMADO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRP_PAPEL1_PROGRAMADOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, BOL_ID, BOL_ID_ORIGEM, BOL_SOLVER, BOL_INTEGRACAO, BOL_SEQUENCIA, GRP_PAP_GRAMATURA_PROGRAMADO, GRP_ID_PROGRAMADO, GRP_PAPEL1_PROGRAMADO, GRP_PAPEL2_PROGRAMADO, GRP_PAPEL3_PROGRAMADO, GRP_PAPEL4_PROGRAMADO, GRP_PAPEL5_PROGRAMADO, BOL_STATUS_INTERFACE, BOL_TIPO, BOL_FORMATO, BOL_GRAMATURA_PAPEIS_PROGRAMADOS, BOL_GRAMATURA_PAPEIS_REALIZADO, BOL_CUSTO_PAPEIS_PROGRAMADOS, BOL_CUSTO_PAPEIS_REALIZADO, BOL_GRAMATURA_RESINA_PROGRAMADOS, BOL_CUSTO_RESINA_PROGRAMADOS, BOL_REFILE_OBRIGATORIO, BOL_OBS, TenantID, Deleted, Changed, UserId FROM Boletim ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_PAPEL1_PROGRAMADO"] = value; //06
                      whereClauses.Add($" GRP_PAPEL1_PROGRAMADO = @GRP_PAPEL1_PROGRAMADO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRP_PAPEL2_PROGRAMADOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, BOL_ID, BOL_ID_ORIGEM, BOL_SOLVER, BOL_INTEGRACAO, BOL_SEQUENCIA, GRP_PAP_GRAMATURA_PROGRAMADO, GRP_ID_PROGRAMADO, GRP_PAPEL1_PROGRAMADO, GRP_PAPEL2_PROGRAMADO, GRP_PAPEL3_PROGRAMADO, GRP_PAPEL4_PROGRAMADO, GRP_PAPEL5_PROGRAMADO, BOL_STATUS_INTERFACE, BOL_TIPO, BOL_FORMATO, BOL_GRAMATURA_PAPEIS_PROGRAMADOS, BOL_GRAMATURA_PAPEIS_REALIZADO, BOL_CUSTO_PAPEIS_PROGRAMADOS, BOL_CUSTO_PAPEIS_REALIZADO, BOL_GRAMATURA_RESINA_PROGRAMADOS, BOL_CUSTO_RESINA_PROGRAMADOS, BOL_REFILE_OBRIGATORIO, BOL_OBS, TenantID, Deleted, Changed, UserId FROM Boletim ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_PAPEL2_PROGRAMADO"] = value; //06
                      whereClauses.Add($" GRP_PAPEL2_PROGRAMADO = @GRP_PAPEL2_PROGRAMADO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRP_PAPEL3_PROGRAMADOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, BOL_ID, BOL_ID_ORIGEM, BOL_SOLVER, BOL_INTEGRACAO, BOL_SEQUENCIA, GRP_PAP_GRAMATURA_PROGRAMADO, GRP_ID_PROGRAMADO, GRP_PAPEL1_PROGRAMADO, GRP_PAPEL2_PROGRAMADO, GRP_PAPEL3_PROGRAMADO, GRP_PAPEL4_PROGRAMADO, GRP_PAPEL5_PROGRAMADO, BOL_STATUS_INTERFACE, BOL_TIPO, BOL_FORMATO, BOL_GRAMATURA_PAPEIS_PROGRAMADOS, BOL_GRAMATURA_PAPEIS_REALIZADO, BOL_CUSTO_PAPEIS_PROGRAMADOS, BOL_CUSTO_PAPEIS_REALIZADO, BOL_GRAMATURA_RESINA_PROGRAMADOS, BOL_CUSTO_RESINA_PROGRAMADOS, BOL_REFILE_OBRIGATORIO, BOL_OBS, TenantID, Deleted, Changed, UserId FROM Boletim ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_PAPEL3_PROGRAMADO"] = value; //06
                      whereClauses.Add($" GRP_PAPEL3_PROGRAMADO = @GRP_PAPEL3_PROGRAMADO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRP_PAPEL4_PROGRAMADOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, BOL_ID, BOL_ID_ORIGEM, BOL_SOLVER, BOL_INTEGRACAO, BOL_SEQUENCIA, GRP_PAP_GRAMATURA_PROGRAMADO, GRP_ID_PROGRAMADO, GRP_PAPEL1_PROGRAMADO, GRP_PAPEL2_PROGRAMADO, GRP_PAPEL3_PROGRAMADO, GRP_PAPEL4_PROGRAMADO, GRP_PAPEL5_PROGRAMADO, BOL_STATUS_INTERFACE, BOL_TIPO, BOL_FORMATO, BOL_GRAMATURA_PAPEIS_PROGRAMADOS, BOL_GRAMATURA_PAPEIS_REALIZADO, BOL_CUSTO_PAPEIS_PROGRAMADOS, BOL_CUSTO_PAPEIS_REALIZADO, BOL_GRAMATURA_RESINA_PROGRAMADOS, BOL_CUSTO_RESINA_PROGRAMADOS, BOL_REFILE_OBRIGATORIO, BOL_OBS, TenantID, Deleted, Changed, UserId FROM Boletim ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_PAPEL4_PROGRAMADO"] = value; //06
                      whereClauses.Add($" GRP_PAPEL4_PROGRAMADO = @GRP_PAPEL4_PROGRAMADO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRP_PAPEL5_PROGRAMADOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, BOL_ID, BOL_ID_ORIGEM, BOL_SOLVER, BOL_INTEGRACAO, BOL_SEQUENCIA, GRP_PAP_GRAMATURA_PROGRAMADO, GRP_ID_PROGRAMADO, GRP_PAPEL1_PROGRAMADO, GRP_PAPEL2_PROGRAMADO, GRP_PAPEL3_PROGRAMADO, GRP_PAPEL4_PROGRAMADO, GRP_PAPEL5_PROGRAMADO, BOL_STATUS_INTERFACE, BOL_TIPO, BOL_FORMATO, BOL_GRAMATURA_PAPEIS_PROGRAMADOS, BOL_GRAMATURA_PAPEIS_REALIZADO, BOL_CUSTO_PAPEIS_PROGRAMADOS, BOL_CUSTO_PAPEIS_REALIZADO, BOL_GRAMATURA_RESINA_PROGRAMADOS, BOL_CUSTO_RESINA_PROGRAMADOS, BOL_REFILE_OBRIGATORIO, BOL_OBS, TenantID, Deleted, Changed, UserId FROM Boletim ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_PAPEL5_PROGRAMADO"] = value; //06
                      whereClauses.Add($" GRP_PAPEL5_PROGRAMADO = @GRP_PAPEL5_PROGRAMADO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByBOL_STATUS_INTERFACEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, BOL_ID, BOL_ID_ORIGEM, BOL_SOLVER, BOL_INTEGRACAO, BOL_SEQUENCIA, GRP_PAP_GRAMATURA_PROGRAMADO, GRP_ID_PROGRAMADO, GRP_PAPEL1_PROGRAMADO, GRP_PAPEL2_PROGRAMADO, GRP_PAPEL3_PROGRAMADO, GRP_PAPEL4_PROGRAMADO, GRP_PAPEL5_PROGRAMADO, BOL_STATUS_INTERFACE, BOL_TIPO, BOL_FORMATO, BOL_GRAMATURA_PAPEIS_PROGRAMADOS, BOL_GRAMATURA_PAPEIS_REALIZADO, BOL_CUSTO_PAPEIS_PROGRAMADOS, BOL_CUSTO_PAPEIS_REALIZADO, BOL_GRAMATURA_RESINA_PROGRAMADOS, BOL_CUSTO_RESINA_PROGRAMADOS, BOL_REFILE_OBRIGATORIO, BOL_OBS, TenantID, Deleted, Changed, UserId FROM Boletim ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["BOL_STATUS_INTERFACE"] = value; //06
                      whereClauses.Add($" BOL_STATUS_INTERFACE = @BOL_STATUS_INTERFACE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByBOL_TIPOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, BOL_ID, BOL_ID_ORIGEM, BOL_SOLVER, BOL_INTEGRACAO, BOL_SEQUENCIA, GRP_PAP_GRAMATURA_PROGRAMADO, GRP_ID_PROGRAMADO, GRP_PAPEL1_PROGRAMADO, GRP_PAPEL2_PROGRAMADO, GRP_PAPEL3_PROGRAMADO, GRP_PAPEL4_PROGRAMADO, GRP_PAPEL5_PROGRAMADO, BOL_STATUS_INTERFACE, BOL_TIPO, BOL_FORMATO, BOL_GRAMATURA_PAPEIS_PROGRAMADOS, BOL_GRAMATURA_PAPEIS_REALIZADO, BOL_CUSTO_PAPEIS_PROGRAMADOS, BOL_CUSTO_PAPEIS_REALIZADO, BOL_GRAMATURA_RESINA_PROGRAMADOS, BOL_CUSTO_RESINA_PROGRAMADOS, BOL_REFILE_OBRIGATORIO, BOL_OBS, TenantID, Deleted, Changed, UserId FROM Boletim ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["BOL_TIPO"] = value; //06
                      whereClauses.Add($" BOL_TIPO = @BOL_TIPO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByBOL_FORMATOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, BOL_ID, BOL_ID_ORIGEM, BOL_SOLVER, BOL_INTEGRACAO, BOL_SEQUENCIA, GRP_PAP_GRAMATURA_PROGRAMADO, GRP_ID_PROGRAMADO, GRP_PAPEL1_PROGRAMADO, GRP_PAPEL2_PROGRAMADO, GRP_PAPEL3_PROGRAMADO, GRP_PAPEL4_PROGRAMADO, GRP_PAPEL5_PROGRAMADO, BOL_STATUS_INTERFACE, BOL_TIPO, BOL_FORMATO, BOL_GRAMATURA_PAPEIS_PROGRAMADOS, BOL_GRAMATURA_PAPEIS_REALIZADO, BOL_CUSTO_PAPEIS_PROGRAMADOS, BOL_CUSTO_PAPEIS_REALIZADO, BOL_GRAMATURA_RESINA_PROGRAMADOS, BOL_CUSTO_RESINA_PROGRAMADOS, BOL_REFILE_OBRIGATORIO, BOL_OBS, TenantID, Deleted, Changed, UserId FROM Boletim ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["BOL_FORMATO"] = value; //06
                      whereClauses.Add($" BOL_FORMATO = @BOL_FORMATO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByBOL_GRAMATURA_PAPEIS_PROGRAMADOSQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, BOL_ID, BOL_ID_ORIGEM, BOL_SOLVER, BOL_INTEGRACAO, BOL_SEQUENCIA, GRP_PAP_GRAMATURA_PROGRAMADO, GRP_ID_PROGRAMADO, GRP_PAPEL1_PROGRAMADO, GRP_PAPEL2_PROGRAMADO, GRP_PAPEL3_PROGRAMADO, GRP_PAPEL4_PROGRAMADO, GRP_PAPEL5_PROGRAMADO, BOL_STATUS_INTERFACE, BOL_TIPO, BOL_FORMATO, BOL_GRAMATURA_PAPEIS_PROGRAMADOS, BOL_GRAMATURA_PAPEIS_REALIZADO, BOL_CUSTO_PAPEIS_PROGRAMADOS, BOL_CUSTO_PAPEIS_REALIZADO, BOL_GRAMATURA_RESINA_PROGRAMADOS, BOL_CUSTO_RESINA_PROGRAMADOS, BOL_REFILE_OBRIGATORIO, BOL_OBS, TenantID, Deleted, Changed, UserId FROM Boletim ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["BOL_GRAMATURA_PAPEIS_PROGRAMADOS"] = value; //06
                      whereClauses.Add($" BOL_GRAMATURA_PAPEIS_PROGRAMADOS = @BOL_GRAMATURA_PAPEIS_PROGRAMADOS ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByBOL_GRAMATURA_PAPEIS_REALIZADOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, BOL_ID, BOL_ID_ORIGEM, BOL_SOLVER, BOL_INTEGRACAO, BOL_SEQUENCIA, GRP_PAP_GRAMATURA_PROGRAMADO, GRP_ID_PROGRAMADO, GRP_PAPEL1_PROGRAMADO, GRP_PAPEL2_PROGRAMADO, GRP_PAPEL3_PROGRAMADO, GRP_PAPEL4_PROGRAMADO, GRP_PAPEL5_PROGRAMADO, BOL_STATUS_INTERFACE, BOL_TIPO, BOL_FORMATO, BOL_GRAMATURA_PAPEIS_PROGRAMADOS, BOL_GRAMATURA_PAPEIS_REALIZADO, BOL_CUSTO_PAPEIS_PROGRAMADOS, BOL_CUSTO_PAPEIS_REALIZADO, BOL_GRAMATURA_RESINA_PROGRAMADOS, BOL_CUSTO_RESINA_PROGRAMADOS, BOL_REFILE_OBRIGATORIO, BOL_OBS, TenantID, Deleted, Changed, UserId FROM Boletim ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["BOL_GRAMATURA_PAPEIS_REALIZADO"] = value; //06
                      whereClauses.Add($" BOL_GRAMATURA_PAPEIS_REALIZADO = @BOL_GRAMATURA_PAPEIS_REALIZADO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByBOL_CUSTO_PAPEIS_PROGRAMADOSQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, BOL_ID, BOL_ID_ORIGEM, BOL_SOLVER, BOL_INTEGRACAO, BOL_SEQUENCIA, GRP_PAP_GRAMATURA_PROGRAMADO, GRP_ID_PROGRAMADO, GRP_PAPEL1_PROGRAMADO, GRP_PAPEL2_PROGRAMADO, GRP_PAPEL3_PROGRAMADO, GRP_PAPEL4_PROGRAMADO, GRP_PAPEL5_PROGRAMADO, BOL_STATUS_INTERFACE, BOL_TIPO, BOL_FORMATO, BOL_GRAMATURA_PAPEIS_PROGRAMADOS, BOL_GRAMATURA_PAPEIS_REALIZADO, BOL_CUSTO_PAPEIS_PROGRAMADOS, BOL_CUSTO_PAPEIS_REALIZADO, BOL_GRAMATURA_RESINA_PROGRAMADOS, BOL_CUSTO_RESINA_PROGRAMADOS, BOL_REFILE_OBRIGATORIO, BOL_OBS, TenantID, Deleted, Changed, UserId FROM Boletim ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["BOL_CUSTO_PAPEIS_PROGRAMADOS"] = value; //06
                      whereClauses.Add($" BOL_CUSTO_PAPEIS_PROGRAMADOS = @BOL_CUSTO_PAPEIS_PROGRAMADOS ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByBOL_CUSTO_PAPEIS_REALIZADOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, BOL_ID, BOL_ID_ORIGEM, BOL_SOLVER, BOL_INTEGRACAO, BOL_SEQUENCIA, GRP_PAP_GRAMATURA_PROGRAMADO, GRP_ID_PROGRAMADO, GRP_PAPEL1_PROGRAMADO, GRP_PAPEL2_PROGRAMADO, GRP_PAPEL3_PROGRAMADO, GRP_PAPEL4_PROGRAMADO, GRP_PAPEL5_PROGRAMADO, BOL_STATUS_INTERFACE, BOL_TIPO, BOL_FORMATO, BOL_GRAMATURA_PAPEIS_PROGRAMADOS, BOL_GRAMATURA_PAPEIS_REALIZADO, BOL_CUSTO_PAPEIS_PROGRAMADOS, BOL_CUSTO_PAPEIS_REALIZADO, BOL_GRAMATURA_RESINA_PROGRAMADOS, BOL_CUSTO_RESINA_PROGRAMADOS, BOL_REFILE_OBRIGATORIO, BOL_OBS, TenantID, Deleted, Changed, UserId FROM Boletim ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["BOL_CUSTO_PAPEIS_REALIZADO"] = value; //06
                      whereClauses.Add($" BOL_CUSTO_PAPEIS_REALIZADO = @BOL_CUSTO_PAPEIS_REALIZADO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByBOL_GRAMATURA_RESINA_PROGRAMADOSQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, BOL_ID, BOL_ID_ORIGEM, BOL_SOLVER, BOL_INTEGRACAO, BOL_SEQUENCIA, GRP_PAP_GRAMATURA_PROGRAMADO, GRP_ID_PROGRAMADO, GRP_PAPEL1_PROGRAMADO, GRP_PAPEL2_PROGRAMADO, GRP_PAPEL3_PROGRAMADO, GRP_PAPEL4_PROGRAMADO, GRP_PAPEL5_PROGRAMADO, BOL_STATUS_INTERFACE, BOL_TIPO, BOL_FORMATO, BOL_GRAMATURA_PAPEIS_PROGRAMADOS, BOL_GRAMATURA_PAPEIS_REALIZADO, BOL_CUSTO_PAPEIS_PROGRAMADOS, BOL_CUSTO_PAPEIS_REALIZADO, BOL_GRAMATURA_RESINA_PROGRAMADOS, BOL_CUSTO_RESINA_PROGRAMADOS, BOL_REFILE_OBRIGATORIO, BOL_OBS, TenantID, Deleted, Changed, UserId FROM Boletim ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["BOL_GRAMATURA_RESINA_PROGRAMADOS"] = value; //06
                      whereClauses.Add($" BOL_GRAMATURA_RESINA_PROGRAMADOS = @BOL_GRAMATURA_RESINA_PROGRAMADOS ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByBOL_CUSTO_RESINA_PROGRAMADOSQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, BOL_ID, BOL_ID_ORIGEM, BOL_SOLVER, BOL_INTEGRACAO, BOL_SEQUENCIA, GRP_PAP_GRAMATURA_PROGRAMADO, GRP_ID_PROGRAMADO, GRP_PAPEL1_PROGRAMADO, GRP_PAPEL2_PROGRAMADO, GRP_PAPEL3_PROGRAMADO, GRP_PAPEL4_PROGRAMADO, GRP_PAPEL5_PROGRAMADO, BOL_STATUS_INTERFACE, BOL_TIPO, BOL_FORMATO, BOL_GRAMATURA_PAPEIS_PROGRAMADOS, BOL_GRAMATURA_PAPEIS_REALIZADO, BOL_CUSTO_PAPEIS_PROGRAMADOS, BOL_CUSTO_PAPEIS_REALIZADO, BOL_GRAMATURA_RESINA_PROGRAMADOS, BOL_CUSTO_RESINA_PROGRAMADOS, BOL_REFILE_OBRIGATORIO, BOL_OBS, TenantID, Deleted, Changed, UserId FROM Boletim ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["BOL_CUSTO_RESINA_PROGRAMADOS"] = value; //06
                      whereClauses.Add($" BOL_CUSTO_RESINA_PROGRAMADOS = @BOL_CUSTO_RESINA_PROGRAMADOS ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByBOL_REFILE_OBRIGATORIOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, BOL_ID, BOL_ID_ORIGEM, BOL_SOLVER, BOL_INTEGRACAO, BOL_SEQUENCIA, GRP_PAP_GRAMATURA_PROGRAMADO, GRP_ID_PROGRAMADO, GRP_PAPEL1_PROGRAMADO, GRP_PAPEL2_PROGRAMADO, GRP_PAPEL3_PROGRAMADO, GRP_PAPEL4_PROGRAMADO, GRP_PAPEL5_PROGRAMADO, BOL_STATUS_INTERFACE, BOL_TIPO, BOL_FORMATO, BOL_GRAMATURA_PAPEIS_PROGRAMADOS, BOL_GRAMATURA_PAPEIS_REALIZADO, BOL_CUSTO_PAPEIS_PROGRAMADOS, BOL_CUSTO_PAPEIS_REALIZADO, BOL_GRAMATURA_RESINA_PROGRAMADOS, BOL_CUSTO_RESINA_PROGRAMADOS, BOL_REFILE_OBRIGATORIO, BOL_OBS, TenantID, Deleted, Changed, UserId FROM Boletim ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["BOL_REFILE_OBRIGATORIO"] = value; //06
                      whereClauses.Add($" BOL_REFILE_OBRIGATORIO = @BOL_REFILE_OBRIGATORIO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByBOL_OBSQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, BOL_ID, BOL_ID_ORIGEM, BOL_SOLVER, BOL_INTEGRACAO, BOL_SEQUENCIA, GRP_PAP_GRAMATURA_PROGRAMADO, GRP_ID_PROGRAMADO, GRP_PAPEL1_PROGRAMADO, GRP_PAPEL2_PROGRAMADO, GRP_PAPEL3_PROGRAMADO, GRP_PAPEL4_PROGRAMADO, GRP_PAPEL5_PROGRAMADO, BOL_STATUS_INTERFACE, BOL_TIPO, BOL_FORMATO, BOL_GRAMATURA_PAPEIS_PROGRAMADOS, BOL_GRAMATURA_PAPEIS_REALIZADO, BOL_CUSTO_PAPEIS_PROGRAMADOS, BOL_CUSTO_PAPEIS_REALIZADO, BOL_GRAMATURA_RESINA_PROGRAMADOS, BOL_CUSTO_RESINA_PROGRAMADOS, BOL_REFILE_OBRIGATORIO, BOL_OBS, TenantID, Deleted, Changed, UserId FROM Boletim ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["BOL_OBS"] = value; //06
                      whereClauses.Add($" BOL_OBS = @BOL_OBS ");//06
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
            this.Query = $"SELECT Id, BOL_ID, BOL_ID_ORIGEM, BOL_SOLVER, BOL_INTEGRACAO, BOL_SEQUENCIA, GRP_PAP_GRAMATURA_PROGRAMADO, GRP_ID_PROGRAMADO, GRP_PAPEL1_PROGRAMADO, GRP_PAPEL2_PROGRAMADO, GRP_PAPEL3_PROGRAMADO, GRP_PAPEL4_PROGRAMADO, GRP_PAPEL5_PROGRAMADO, BOL_STATUS_INTERFACE, BOL_TIPO, BOL_FORMATO, BOL_GRAMATURA_PAPEIS_PROGRAMADOS, BOL_GRAMATURA_PAPEIS_REALIZADO, BOL_CUSTO_PAPEIS_PROGRAMADOS, BOL_CUSTO_PAPEIS_REALIZADO, BOL_GRAMATURA_RESINA_PROGRAMADOS, BOL_CUSTO_RESINA_PROGRAMADOS, BOL_REFILE_OBRIGATORIO, BOL_OBS, TenantID, Deleted, Changed, UserId FROM Boletim ";
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
            this.Query = $"SELECT Id, BOL_ID, BOL_ID_ORIGEM, BOL_SOLVER, BOL_INTEGRACAO, BOL_SEQUENCIA, GRP_PAP_GRAMATURA_PROGRAMADO, GRP_ID_PROGRAMADO, GRP_PAPEL1_PROGRAMADO, GRP_PAPEL2_PROGRAMADO, GRP_PAPEL3_PROGRAMADO, GRP_PAPEL4_PROGRAMADO, GRP_PAPEL5_PROGRAMADO, BOL_STATUS_INTERFACE, BOL_TIPO, BOL_FORMATO, BOL_GRAMATURA_PAPEIS_PROGRAMADOS, BOL_GRAMATURA_PAPEIS_REALIZADO, BOL_CUSTO_PAPEIS_PROGRAMADOS, BOL_CUSTO_PAPEIS_REALIZADO, BOL_GRAMATURA_RESINA_PROGRAMADOS, BOL_CUSTO_RESINA_PROGRAMADOS, BOL_REFILE_OBRIGATORIO, BOL_OBS, TenantID, Deleted, Changed, UserId FROM Boletim ";
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
            this.Query = $"SELECT Id, BOL_ID, BOL_ID_ORIGEM, BOL_SOLVER, BOL_INTEGRACAO, BOL_SEQUENCIA, GRP_PAP_GRAMATURA_PROGRAMADO, GRP_ID_PROGRAMADO, GRP_PAPEL1_PROGRAMADO, GRP_PAPEL2_PROGRAMADO, GRP_PAPEL3_PROGRAMADO, GRP_PAPEL4_PROGRAMADO, GRP_PAPEL5_PROGRAMADO, BOL_STATUS_INTERFACE, BOL_TIPO, BOL_FORMATO, BOL_GRAMATURA_PAPEIS_PROGRAMADOS, BOL_GRAMATURA_PAPEIS_REALIZADO, BOL_CUSTO_PAPEIS_PROGRAMADOS, BOL_CUSTO_PAPEIS_REALIZADO, BOL_GRAMATURA_RESINA_PROGRAMADOS, BOL_CUSTO_RESINA_PROGRAMADOS, BOL_REFILE_OBRIGATORIO, BOL_OBS, TenantID, Deleted, Changed, UserId FROM Boletim ";
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
            this.Query = $"SELECT Id, BOL_ID, BOL_ID_ORIGEM, BOL_SOLVER, BOL_INTEGRACAO, BOL_SEQUENCIA, GRP_PAP_GRAMATURA_PROGRAMADO, GRP_ID_PROGRAMADO, GRP_PAPEL1_PROGRAMADO, GRP_PAPEL2_PROGRAMADO, GRP_PAPEL3_PROGRAMADO, GRP_PAPEL4_PROGRAMADO, GRP_PAPEL5_PROGRAMADO, BOL_STATUS_INTERFACE, BOL_TIPO, BOL_FORMATO, BOL_GRAMATURA_PAPEIS_PROGRAMADOS, BOL_GRAMATURA_PAPEIS_REALIZADO, BOL_CUSTO_PAPEIS_PROGRAMADOS, BOL_CUSTO_PAPEIS_REALIZADO, BOL_GRAMATURA_RESINA_PROGRAMADOS, BOL_CUSTO_RESINA_PROGRAMADOS, BOL_REFILE_OBRIGATORIO, BOL_OBS, TenantID, Deleted, Changed, UserId FROM Boletim ";
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