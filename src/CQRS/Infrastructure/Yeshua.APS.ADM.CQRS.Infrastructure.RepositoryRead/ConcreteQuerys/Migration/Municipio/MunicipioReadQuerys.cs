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
    public class MunicipioQueryRead : QueryBase, IMunicipioQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public MunicipioQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel MunicipioQuery(Command.Read.MunicipioReadCommand Command )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select MUN_ID, MUN_NOME, UF_COD, MUN_CODIGO_IBGE, MUN_LATITUDE, MUN_LONGITUDE, MUN_ID_INTEGRACAO_ERP, MUN_CODIGO_SIAFI, MUN_CODIGO_CNPJ, MUN_DISTANCIA_KM, TenantID, Deleted, Changed, UserId from Municipio ";
if (!string.IsNullOrEmpty(Command.MUN_ID)) dict["MUN_ID"] = $"%{Command.MUN_ID}%";
if (!string.IsNullOrEmpty(Command.MUN_ID)) whereClauses.Add($"MUN_ID like @MUN_ID");
if (!string.IsNullOrEmpty(Command.MUN_NOME)) dict["MUN_NOME"] = $"%{Command.MUN_NOME}%";
if (!string.IsNullOrEmpty(Command.MUN_NOME)) whereClauses.Add($"MUN_NOME like @MUN_NOME");
if (!string.IsNullOrEmpty(Command.UF_COD)) dict["UF_COD"] = $"%{Command.UF_COD}%";
if (!string.IsNullOrEmpty(Command.UF_COD)) whereClauses.Add($"UF_COD like @UF_COD");
if (!string.IsNullOrEmpty(Command.MUN_CODIGO_IBGE)) dict["MUN_CODIGO_IBGE"] = $"%{Command.MUN_CODIGO_IBGE}%";
if (!string.IsNullOrEmpty(Command.MUN_CODIGO_IBGE)) whereClauses.Add($"MUN_CODIGO_IBGE like @MUN_CODIGO_IBGE");
if (!string.IsNullOrEmpty(Command.MUN_ID_INTEGRACAO_ERP)) dict["MUN_ID_INTEGRACAO_ERP"] = $"%{Command.MUN_ID_INTEGRACAO_ERP}%";
if (!string.IsNullOrEmpty(Command.MUN_ID_INTEGRACAO_ERP)) whereClauses.Add($"MUN_ID_INTEGRACAO_ERP like @MUN_ID_INTEGRACAO_ERP");
if (!string.IsNullOrEmpty(Command.MUN_CODIGO_SIAFI)) dict["MUN_CODIGO_SIAFI"] = $"%{Command.MUN_CODIGO_SIAFI}%";
if (!string.IsNullOrEmpty(Command.MUN_CODIGO_SIAFI)) whereClauses.Add($"MUN_CODIGO_SIAFI like @MUN_CODIGO_SIAFI");
if (!string.IsNullOrEmpty(Command.MUN_CODIGO_CNPJ)) dict["MUN_CODIGO_CNPJ"] = $"%{Command.MUN_CODIGO_CNPJ}%";
if (!string.IsNullOrEmpty(Command.MUN_CODIGO_CNPJ)) whereClauses.Add($"MUN_CODIGO_CNPJ like @MUN_CODIGO_CNPJ");
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
            Query += " ORDER BY MUN_ID OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel MunicipioTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel MunicipioUserIdQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel ExistsByMUN_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Municipio ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MUN_ID"] = value; //04
                      whereClauses.Add($" MUN_ID = @MUN_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMUN_NOMEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Municipio ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MUN_NOME"] = value; //04
                      whereClauses.Add($" MUN_NOME = @MUN_NOME ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByUF_CODQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Municipio ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["UF_COD"] = value; //04
                      whereClauses.Add($" UF_COD = @UF_COD ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMUN_CODIGO_IBGEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Municipio ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MUN_CODIGO_IBGE"] = value; //04
                      whereClauses.Add($" MUN_CODIGO_IBGE = @MUN_CODIGO_IBGE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMUN_LATITUDEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Municipio ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MUN_LATITUDE"] = value; //04
                      whereClauses.Add($" MUN_LATITUDE = @MUN_LATITUDE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMUN_LONGITUDEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Municipio ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MUN_LONGITUDE"] = value; //04
                      whereClauses.Add($" MUN_LONGITUDE = @MUN_LONGITUDE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMUN_ID_INTEGRACAO_ERPQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Municipio ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MUN_ID_INTEGRACAO_ERP"] = value; //04
                      whereClauses.Add($" MUN_ID_INTEGRACAO_ERP = @MUN_ID_INTEGRACAO_ERP ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMUN_CODIGO_SIAFIQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Municipio ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MUN_CODIGO_SIAFI"] = value; //04
                      whereClauses.Add($" MUN_CODIGO_SIAFI = @MUN_CODIGO_SIAFI ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMUN_CODIGO_CNPJQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Municipio ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MUN_CODIGO_CNPJ"] = value; //04
                      whereClauses.Add($" MUN_CODIGO_CNPJ = @MUN_CODIGO_CNPJ ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMUN_DISTANCIA_KMQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Municipio ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MUN_DISTANCIA_KM"] = value; //04
                      whereClauses.Add($" MUN_DISTANCIA_KM = @MUN_DISTANCIA_KM ");//04
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
            this.Query = $"SELECT 1 FROM Municipio ";
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
            this.Query = $"SELECT 1 FROM Municipio ";
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
            this.Query = $"SELECT 1 FROM Municipio ";
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
            this.Query = $"SELECT 1 FROM Municipio ";
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
        public QueryModel FirstByMUN_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT MUN_ID, MUN_NOME, UF_COD, MUN_CODIGO_IBGE, MUN_LATITUDE, MUN_LONGITUDE, MUN_ID_INTEGRACAO_ERP, MUN_CODIGO_SIAFI, MUN_CODIGO_CNPJ, MUN_DISTANCIA_KM, TenantID, Deleted, Changed, UserId FROM Municipio ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MUN_ID"] = value; //06
                      whereClauses.Add($" MUN_ID = @MUN_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMUN_NOMEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT MUN_ID, MUN_NOME, UF_COD, MUN_CODIGO_IBGE, MUN_LATITUDE, MUN_LONGITUDE, MUN_ID_INTEGRACAO_ERP, MUN_CODIGO_SIAFI, MUN_CODIGO_CNPJ, MUN_DISTANCIA_KM, TenantID, Deleted, Changed, UserId FROM Municipio ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MUN_NOME"] = value; //06
                      whereClauses.Add($" MUN_NOME = @MUN_NOME ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByUF_CODQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT MUN_ID, MUN_NOME, UF_COD, MUN_CODIGO_IBGE, MUN_LATITUDE, MUN_LONGITUDE, MUN_ID_INTEGRACAO_ERP, MUN_CODIGO_SIAFI, MUN_CODIGO_CNPJ, MUN_DISTANCIA_KM, TenantID, Deleted, Changed, UserId FROM Municipio ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["UF_COD"] = value; //06
                      whereClauses.Add($" UF_COD = @UF_COD ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMUN_CODIGO_IBGEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT MUN_ID, MUN_NOME, UF_COD, MUN_CODIGO_IBGE, MUN_LATITUDE, MUN_LONGITUDE, MUN_ID_INTEGRACAO_ERP, MUN_CODIGO_SIAFI, MUN_CODIGO_CNPJ, MUN_DISTANCIA_KM, TenantID, Deleted, Changed, UserId FROM Municipio ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MUN_CODIGO_IBGE"] = value; //06
                      whereClauses.Add($" MUN_CODIGO_IBGE = @MUN_CODIGO_IBGE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMUN_LATITUDEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT MUN_ID, MUN_NOME, UF_COD, MUN_CODIGO_IBGE, MUN_LATITUDE, MUN_LONGITUDE, MUN_ID_INTEGRACAO_ERP, MUN_CODIGO_SIAFI, MUN_CODIGO_CNPJ, MUN_DISTANCIA_KM, TenantID, Deleted, Changed, UserId FROM Municipio ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MUN_LATITUDE"] = value; //06
                      whereClauses.Add($" MUN_LATITUDE = @MUN_LATITUDE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMUN_LONGITUDEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT MUN_ID, MUN_NOME, UF_COD, MUN_CODIGO_IBGE, MUN_LATITUDE, MUN_LONGITUDE, MUN_ID_INTEGRACAO_ERP, MUN_CODIGO_SIAFI, MUN_CODIGO_CNPJ, MUN_DISTANCIA_KM, TenantID, Deleted, Changed, UserId FROM Municipio ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MUN_LONGITUDE"] = value; //06
                      whereClauses.Add($" MUN_LONGITUDE = @MUN_LONGITUDE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMUN_ID_INTEGRACAO_ERPQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT MUN_ID, MUN_NOME, UF_COD, MUN_CODIGO_IBGE, MUN_LATITUDE, MUN_LONGITUDE, MUN_ID_INTEGRACAO_ERP, MUN_CODIGO_SIAFI, MUN_CODIGO_CNPJ, MUN_DISTANCIA_KM, TenantID, Deleted, Changed, UserId FROM Municipio ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MUN_ID_INTEGRACAO_ERP"] = value; //06
                      whereClauses.Add($" MUN_ID_INTEGRACAO_ERP = @MUN_ID_INTEGRACAO_ERP ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMUN_CODIGO_SIAFIQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT MUN_ID, MUN_NOME, UF_COD, MUN_CODIGO_IBGE, MUN_LATITUDE, MUN_LONGITUDE, MUN_ID_INTEGRACAO_ERP, MUN_CODIGO_SIAFI, MUN_CODIGO_CNPJ, MUN_DISTANCIA_KM, TenantID, Deleted, Changed, UserId FROM Municipio ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MUN_CODIGO_SIAFI"] = value; //06
                      whereClauses.Add($" MUN_CODIGO_SIAFI = @MUN_CODIGO_SIAFI ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMUN_CODIGO_CNPJQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT MUN_ID, MUN_NOME, UF_COD, MUN_CODIGO_IBGE, MUN_LATITUDE, MUN_LONGITUDE, MUN_ID_INTEGRACAO_ERP, MUN_CODIGO_SIAFI, MUN_CODIGO_CNPJ, MUN_DISTANCIA_KM, TenantID, Deleted, Changed, UserId FROM Municipio ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MUN_CODIGO_CNPJ"] = value; //06
                      whereClauses.Add($" MUN_CODIGO_CNPJ = @MUN_CODIGO_CNPJ ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMUN_DISTANCIA_KMQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT MUN_ID, MUN_NOME, UF_COD, MUN_CODIGO_IBGE, MUN_LATITUDE, MUN_LONGITUDE, MUN_ID_INTEGRACAO_ERP, MUN_CODIGO_SIAFI, MUN_CODIGO_CNPJ, MUN_DISTANCIA_KM, TenantID, Deleted, Changed, UserId FROM Municipio ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MUN_DISTANCIA_KM"] = value; //06
                      whereClauses.Add($" MUN_DISTANCIA_KM = @MUN_DISTANCIA_KM ");//06
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
            this.Query = $"SELECT MUN_ID, MUN_NOME, UF_COD, MUN_CODIGO_IBGE, MUN_LATITUDE, MUN_LONGITUDE, MUN_ID_INTEGRACAO_ERP, MUN_CODIGO_SIAFI, MUN_CODIGO_CNPJ, MUN_DISTANCIA_KM, TenantID, Deleted, Changed, UserId FROM Municipio ";
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
            this.Query = $"SELECT MUN_ID, MUN_NOME, UF_COD, MUN_CODIGO_IBGE, MUN_LATITUDE, MUN_LONGITUDE, MUN_ID_INTEGRACAO_ERP, MUN_CODIGO_SIAFI, MUN_CODIGO_CNPJ, MUN_DISTANCIA_KM, TenantID, Deleted, Changed, UserId FROM Municipio ";
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
            this.Query = $"SELECT MUN_ID, MUN_NOME, UF_COD, MUN_CODIGO_IBGE, MUN_LATITUDE, MUN_LONGITUDE, MUN_ID_INTEGRACAO_ERP, MUN_CODIGO_SIAFI, MUN_CODIGO_CNPJ, MUN_DISTANCIA_KM, TenantID, Deleted, Changed, UserId FROM Municipio ";
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
            this.Query = $"SELECT MUN_ID, MUN_NOME, UF_COD, MUN_CODIGO_IBGE, MUN_LATITUDE, MUN_LONGITUDE, MUN_ID_INTEGRACAO_ERP, MUN_CODIGO_SIAFI, MUN_CODIGO_CNPJ, MUN_DISTANCIA_KM, TenantID, Deleted, Changed, UserId FROM Municipio ";
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