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
    public class GrupoProdutoAbstratoQueryRead : QueryBase, IGrupoProdutoAbstratoQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public GrupoProdutoAbstratoQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel GrupoProdutoAbstratoQuery(Command.Read.GrupoProdutoAbstratoReadCommand Command )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select GRP_ID, GRP_DESCRICAO, TEM_ID, GRP_TIPO, GRP_PAP_ONDA, GRP_PAP_GRAMATURA, GRP_PAP_ALTURA, GRP_PAP_NOME_COMERCIAL, GRP_ATIVO, GRP_DT_CRIACAO, GRP_PAPEL1, GRP_PAPEL2, GRP_PAPEL3, GRP_PAPEL4, GRP_PAPEL5, GRP_ID_INTEGRACAO, GRP_ID_INTEGRACAO_ERP, GRP_TYPE, GRP_PERFORMANCE, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, GRP_RESINA, GRP_ENDURECEDOR_MIOLO, VIN_ID, GRP_COLUNA_DE, GRP_COLUNA_ATE, GRP_CRUSH, GRP_ID_FAMILIA, GRP_REFILE_LARGURA, GRP_REFILE_COMPRIMENTO, GRP_TIPO_LAP, GRP_LAP_PROLONGADO, GRP_TAMANHO_LAP_OND_SIMPLES, GRP_TAMANHO_LAP_OND_DUPLA, GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, GRP_FEFCO, GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, GRP_PREFIXO_ID_PRODUTO, GRP_COLUNA_CAIXA, GRP_COLUNA_CHAPA, GRP_MULLEN, GRP_TENDENCIA_TOLERANCIA_PEDIDO, GRP_PERCENTUAL_PERDA_MEDIA, GRP_FILTRA_SEQ_TRANS, GRP_IMG_CAIXA, TenantID, Deleted, Changed, UserId from GrupoProdutoAbstrato ";
if (!string.IsNullOrEmpty(Command.GRP_ID)) dict["GRP_ID"] = $"%{Command.GRP_ID}%";
if (!string.IsNullOrEmpty(Command.GRP_ID)) whereClauses.Add($"GRP_ID like @GRP_ID");
if (!string.IsNullOrEmpty(Command.GRP_DESCRICAO)) dict["GRP_DESCRICAO"] = $"%{Command.GRP_DESCRICAO}%";
if (!string.IsNullOrEmpty(Command.GRP_DESCRICAO)) whereClauses.Add($"GRP_DESCRICAO like @GRP_DESCRICAO");
if (Command.TEM_ID.HasValue) dict["TEM_ID"] = Command.TEM_ID.Value;
if (Command.TEM_ID.HasValue) whereClauses.Add($"TEM_ID = @TEM_ID");
if (!string.IsNullOrEmpty(Command.GRP_PAP_ONDA)) dict["GRP_PAP_ONDA"] = $"%{Command.GRP_PAP_ONDA}%";
if (!string.IsNullOrEmpty(Command.GRP_PAP_ONDA)) whereClauses.Add($"GRP_PAP_ONDA like @GRP_PAP_ONDA");
if (!string.IsNullOrEmpty(Command.GRP_PAP_NOME_COMERCIAL)) dict["GRP_PAP_NOME_COMERCIAL"] = $"%{Command.GRP_PAP_NOME_COMERCIAL}%";
if (!string.IsNullOrEmpty(Command.GRP_PAP_NOME_COMERCIAL)) whereClauses.Add($"GRP_PAP_NOME_COMERCIAL like @GRP_PAP_NOME_COMERCIAL");
if (!string.IsNullOrEmpty(Command.GRP_ATIVO)) dict["GRP_ATIVO"] = $"%{Command.GRP_ATIVO}%";
if (!string.IsNullOrEmpty(Command.GRP_ATIVO)) whereClauses.Add($"GRP_ATIVO like @GRP_ATIVO");
if (!string.IsNullOrEmpty(Command.GRP_PAPEL1)) dict["GRP_PAPEL1"] = $"%{Command.GRP_PAPEL1}%";
if (!string.IsNullOrEmpty(Command.GRP_PAPEL1)) whereClauses.Add($"GRP_PAPEL1 like @GRP_PAPEL1");
if (!string.IsNullOrEmpty(Command.GRP_PAPEL2)) dict["GRP_PAPEL2"] = $"%{Command.GRP_PAPEL2}%";
if (!string.IsNullOrEmpty(Command.GRP_PAPEL2)) whereClauses.Add($"GRP_PAPEL2 like @GRP_PAPEL2");
if (!string.IsNullOrEmpty(Command.GRP_PAPEL3)) dict["GRP_PAPEL3"] = $"%{Command.GRP_PAPEL3}%";
if (!string.IsNullOrEmpty(Command.GRP_PAPEL3)) whereClauses.Add($"GRP_PAPEL3 like @GRP_PAPEL3");
if (!string.IsNullOrEmpty(Command.GRP_PAPEL4)) dict["GRP_PAPEL4"] = $"%{Command.GRP_PAPEL4}%";
if (!string.IsNullOrEmpty(Command.GRP_PAPEL4)) whereClauses.Add($"GRP_PAPEL4 like @GRP_PAPEL4");
if (!string.IsNullOrEmpty(Command.GRP_PAPEL5)) dict["GRP_PAPEL5"] = $"%{Command.GRP_PAPEL5}%";
if (!string.IsNullOrEmpty(Command.GRP_PAPEL5)) whereClauses.Add($"GRP_PAPEL5 like @GRP_PAPEL5");
if (!string.IsNullOrEmpty(Command.GRP_ID_INTEGRACAO)) dict["GRP_ID_INTEGRACAO"] = $"%{Command.GRP_ID_INTEGRACAO}%";
if (!string.IsNullOrEmpty(Command.GRP_ID_INTEGRACAO)) whereClauses.Add($"GRP_ID_INTEGRACAO like @GRP_ID_INTEGRACAO");
if (!string.IsNullOrEmpty(Command.GRP_ID_INTEGRACAO_ERP)) dict["GRP_ID_INTEGRACAO_ERP"] = $"%{Command.GRP_ID_INTEGRACAO_ERP}%";
if (!string.IsNullOrEmpty(Command.GRP_ID_INTEGRACAO_ERP)) whereClauses.Add($"GRP_ID_INTEGRACAO_ERP like @GRP_ID_INTEGRACAO_ERP");
if (Command.GRP_TYPE.HasValue) dict["GRP_TYPE"] = Command.GRP_TYPE.Value;
if (Command.GRP_TYPE.HasValue) whereClauses.Add($"GRP_TYPE = @GRP_TYPE");
if (!string.IsNullOrEmpty(Command.GRP_RESINA)) dict["GRP_RESINA"] = $"%{Command.GRP_RESINA}%";
if (!string.IsNullOrEmpty(Command.GRP_RESINA)) whereClauses.Add($"GRP_RESINA like @GRP_RESINA");
if (!string.IsNullOrEmpty(Command.GRP_ENDURECEDOR_MIOLO)) dict["GRP_ENDURECEDOR_MIOLO"] = $"%{Command.GRP_ENDURECEDOR_MIOLO}%";
if (!string.IsNullOrEmpty(Command.GRP_ENDURECEDOR_MIOLO)) whereClauses.Add($"GRP_ENDURECEDOR_MIOLO like @GRP_ENDURECEDOR_MIOLO");
if (Command.VIN_ID.HasValue) dict["VIN_ID"] = Command.VIN_ID.Value;
if (Command.VIN_ID.HasValue) whereClauses.Add($"VIN_ID = @VIN_ID");
if (!string.IsNullOrEmpty(Command.GRP_ID_FAMILIA)) dict["GRP_ID_FAMILIA"] = $"%{Command.GRP_ID_FAMILIA}%";
if (!string.IsNullOrEmpty(Command.GRP_ID_FAMILIA)) whereClauses.Add($"GRP_ID_FAMILIA like @GRP_ID_FAMILIA");
if (!string.IsNullOrEmpty(Command.GRP_TIPO_LAP)) dict["GRP_TIPO_LAP"] = $"%{Command.GRP_TIPO_LAP}%";
if (!string.IsNullOrEmpty(Command.GRP_TIPO_LAP)) whereClauses.Add($"GRP_TIPO_LAP like @GRP_TIPO_LAP");
if (!string.IsNullOrEmpty(Command.GRP_LAP_PROLONGADO)) dict["GRP_LAP_PROLONGADO"] = $"%{Command.GRP_LAP_PROLONGADO}%";
if (!string.IsNullOrEmpty(Command.GRP_LAP_PROLONGADO)) whereClauses.Add($"GRP_LAP_PROLONGADO like @GRP_LAP_PROLONGADO");
if (!string.IsNullOrEmpty(Command.GRP_FEFCO)) dict["GRP_FEFCO"] = $"%{Command.GRP_FEFCO}%";
if (!string.IsNullOrEmpty(Command.GRP_FEFCO)) whereClauses.Add($"GRP_FEFCO like @GRP_FEFCO");
if (Command.GRP_TOLERANCIA_DIMENCAO_CHAPA_DE.HasValue) dict["GRP_TOLERANCIA_DIMENCAO_CHAPA_DE"] = Command.GRP_TOLERANCIA_DIMENCAO_CHAPA_DE.Value;
if (Command.GRP_TOLERANCIA_DIMENCAO_CHAPA_DE.HasValue) whereClauses.Add($"GRP_TOLERANCIA_DIMENCAO_CHAPA_DE = @GRP_TOLERANCIA_DIMENCAO_CHAPA_DE");
if (Command.GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE.HasValue) dict["GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE"] = Command.GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE.Value;
if (Command.GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE.HasValue) whereClauses.Add($"GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE = @GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE");
if (!string.IsNullOrEmpty(Command.GRP_PREFIXO_ID_PRODUTO)) dict["GRP_PREFIXO_ID_PRODUTO"] = $"%{Command.GRP_PREFIXO_ID_PRODUTO}%";
if (!string.IsNullOrEmpty(Command.GRP_PREFIXO_ID_PRODUTO)) whereClauses.Add($"GRP_PREFIXO_ID_PRODUTO like @GRP_PREFIXO_ID_PRODUTO");
if (Command.GRP_TENDENCIA_TOLERANCIA_PEDIDO.HasValue) dict["GRP_TENDENCIA_TOLERANCIA_PEDIDO"] = Command.GRP_TENDENCIA_TOLERANCIA_PEDIDO.Value;
if (Command.GRP_TENDENCIA_TOLERANCIA_PEDIDO.HasValue) whereClauses.Add($"GRP_TENDENCIA_TOLERANCIA_PEDIDO = @GRP_TENDENCIA_TOLERANCIA_PEDIDO");
if (Command.GRP_FILTRA_SEQ_TRANS.HasValue) dict["GRP_FILTRA_SEQ_TRANS"] = Command.GRP_FILTRA_SEQ_TRANS.Value;
if (Command.GRP_FILTRA_SEQ_TRANS.HasValue) whereClauses.Add($"GRP_FILTRA_SEQ_TRANS = @GRP_FILTRA_SEQ_TRANS");
if (!string.IsNullOrEmpty(Command.GRP_IMG_CAIXA)) dict["GRP_IMG_CAIXA"] = $"%{Command.GRP_IMG_CAIXA}%";
if (!string.IsNullOrEmpty(Command.GRP_IMG_CAIXA)) whereClauses.Add($"GRP_IMG_CAIXA like @GRP_IMG_CAIXA");
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
            Query += " ORDER BY GRP_ID OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel GrupoProdutoAbstratoGRP_PAP_ONDAQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select OND_ID from Onda ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["OND_ID"] = numero; //01
                      whereClauses.Add($" OND_ID = @OND_ID");//01 
                 }
                 else 
                 {
                      dict["OND_ID"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" OND_ID like @OND_ID ");//02
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
        public QueryModel GrupoProdutoAbstratoVIN_IDQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select VIN_ID from Vinco ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["VIN_ID"] = numero; //01
                      whereClauses.Add($" VIN_ID = @VIN_ID");//01 
                 }
                 else 
                 {
                      dict["VIN_ID"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" VIN_ID like @VIN_ID ");//02
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
        public QueryModel GrupoProdutoAbstratoTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel GrupoProdutoAbstratoUserIdQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel ExistsByGRP_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM GrupoProdutoAbstrato ";
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
        public QueryModel ExistsByGRP_DESCRICAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_DESCRICAO"] = value; //04
                      whereClauses.Add($" GRP_DESCRICAO = @GRP_DESCRICAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTEM_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TEM_ID"] = value; //04
                      whereClauses.Add($" TEM_ID = @TEM_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRP_TIPOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_TIPO"] = value; //04
                      whereClauses.Add($" GRP_TIPO = @GRP_TIPO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRP_PAP_ONDAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_PAP_ONDA"] = value; //04
                      whereClauses.Add($" GRP_PAP_ONDA = @GRP_PAP_ONDA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRP_PAP_GRAMATURAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_PAP_GRAMATURA"] = value; //04
                      whereClauses.Add($" GRP_PAP_GRAMATURA = @GRP_PAP_GRAMATURA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRP_PAP_ALTURAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_PAP_ALTURA"] = value; //04
                      whereClauses.Add($" GRP_PAP_ALTURA = @GRP_PAP_ALTURA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRP_PAP_NOME_COMERCIALQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_PAP_NOME_COMERCIAL"] = value; //04
                      whereClauses.Add($" GRP_PAP_NOME_COMERCIAL = @GRP_PAP_NOME_COMERCIAL ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRP_ATIVOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_ATIVO"] = value; //04
                      whereClauses.Add($" GRP_ATIVO = @GRP_ATIVO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRP_DT_CRIACAOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_DT_CRIACAO"] = value; //04
                      whereClauses.Add($" GRP_DT_CRIACAO = @GRP_DT_CRIACAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRP_PAPEL1Query(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_PAPEL1"] = value; //04
                      whereClauses.Add($" GRP_PAPEL1 = @GRP_PAPEL1 ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRP_PAPEL2Query(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_PAPEL2"] = value; //04
                      whereClauses.Add($" GRP_PAPEL2 = @GRP_PAPEL2 ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRP_PAPEL3Query(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_PAPEL3"] = value; //04
                      whereClauses.Add($" GRP_PAPEL3 = @GRP_PAPEL3 ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRP_PAPEL4Query(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_PAPEL4"] = value; //04
                      whereClauses.Add($" GRP_PAPEL4 = @GRP_PAPEL4 ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRP_PAPEL5Query(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_PAPEL5"] = value; //04
                      whereClauses.Add($" GRP_PAPEL5 = @GRP_PAPEL5 ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRP_ID_INTEGRACAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_ID_INTEGRACAO"] = value; //04
                      whereClauses.Add($" GRP_ID_INTEGRACAO = @GRP_ID_INTEGRACAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRP_ID_INTEGRACAO_ERPQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_ID_INTEGRACAO_ERP"] = value; //04
                      whereClauses.Add($" GRP_ID_INTEGRACAO_ERP = @GRP_ID_INTEGRACAO_ERP ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRP_TYPEQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_TYPE"] = value; //04
                      whereClauses.Add($" GRP_TYPE = @GRP_TYPE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRP_PERFORMANCEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_PERFORMANCE"] = value; //04
                      whereClauses.Add($" GRP_PERFORMANCE = @GRP_PERFORMANCE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO"] = value; //04
                      whereClauses.Add($" GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO = @GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRP_RESINAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_RESINA"] = value; //04
                      whereClauses.Add($" GRP_RESINA = @GRP_RESINA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRP_ENDURECEDOR_MIOLOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_ENDURECEDOR_MIOLO"] = value; //04
                      whereClauses.Add($" GRP_ENDURECEDOR_MIOLO = @GRP_ENDURECEDOR_MIOLO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByVIN_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["VIN_ID"] = value; //04
                      whereClauses.Add($" VIN_ID = @VIN_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRP_COLUNA_DEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_COLUNA_DE"] = value; //04
                      whereClauses.Add($" GRP_COLUNA_DE = @GRP_COLUNA_DE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRP_COLUNA_ATEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_COLUNA_ATE"] = value; //04
                      whereClauses.Add($" GRP_COLUNA_ATE = @GRP_COLUNA_ATE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRP_CRUSHQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_CRUSH"] = value; //04
                      whereClauses.Add($" GRP_CRUSH = @GRP_CRUSH ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRP_ID_FAMILIAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_ID_FAMILIA"] = value; //04
                      whereClauses.Add($" GRP_ID_FAMILIA = @GRP_ID_FAMILIA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRP_REFILE_LARGURAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_REFILE_LARGURA"] = value; //04
                      whereClauses.Add($" GRP_REFILE_LARGURA = @GRP_REFILE_LARGURA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRP_REFILE_COMPRIMENTOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_REFILE_COMPRIMENTO"] = value; //04
                      whereClauses.Add($" GRP_REFILE_COMPRIMENTO = @GRP_REFILE_COMPRIMENTO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRP_TIPO_LAPQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_TIPO_LAP"] = value; //04
                      whereClauses.Add($" GRP_TIPO_LAP = @GRP_TIPO_LAP ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRP_LAP_PROLONGADOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_LAP_PROLONGADO"] = value; //04
                      whereClauses.Add($" GRP_LAP_PROLONGADO = @GRP_LAP_PROLONGADO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRP_TAMANHO_LAP_OND_SIMPLESQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_TAMANHO_LAP_OND_SIMPLES"] = value; //04
                      whereClauses.Add($" GRP_TAMANHO_LAP_OND_SIMPLES = @GRP_TAMANHO_LAP_OND_SIMPLES ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRP_TAMANHO_LAP_OND_DUPLAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_TAMANHO_LAP_OND_DUPLA"] = value; //04
                      whereClauses.Add($" GRP_TAMANHO_LAP_OND_DUPLA = @GRP_TAMANHO_LAP_OND_DUPLA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLESQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES"] = value; //04
                      whereClauses.Add($" GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES = @GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRP_TAMANHO_LAP_PROLONGADO_OND_DUPLAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA"] = value; //04
                      whereClauses.Add($" GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA = @GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRP_FEFCOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_FEFCO"] = value; //04
                      whereClauses.Add($" GRP_FEFCO = @GRP_FEFCO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRP_TOLERANCIA_DIMENCAO_CHAPA_DEQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_TOLERANCIA_DIMENCAO_CHAPA_DE"] = value; //04
                      whereClauses.Add($" GRP_TOLERANCIA_DIMENCAO_CHAPA_DE = @GRP_TOLERANCIA_DIMENCAO_CHAPA_DE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRP_TOLERANCIA_DIMENCAO_CHAPA_ATEQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE"] = value; //04
                      whereClauses.Add($" GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE = @GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRP_PREFIXO_ID_PRODUTOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_PREFIXO_ID_PRODUTO"] = value; //04
                      whereClauses.Add($" GRP_PREFIXO_ID_PRODUTO = @GRP_PREFIXO_ID_PRODUTO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRP_COLUNA_CAIXAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_COLUNA_CAIXA"] = value; //04
                      whereClauses.Add($" GRP_COLUNA_CAIXA = @GRP_COLUNA_CAIXA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRP_COLUNA_CHAPAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_COLUNA_CHAPA"] = value; //04
                      whereClauses.Add($" GRP_COLUNA_CHAPA = @GRP_COLUNA_CHAPA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRP_MULLENQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_MULLEN"] = value; //04
                      whereClauses.Add($" GRP_MULLEN = @GRP_MULLEN ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRP_TENDENCIA_TOLERANCIA_PEDIDOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_TENDENCIA_TOLERANCIA_PEDIDO"] = value; //04
                      whereClauses.Add($" GRP_TENDENCIA_TOLERANCIA_PEDIDO = @GRP_TENDENCIA_TOLERANCIA_PEDIDO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRP_PERCENTUAL_PERDA_MEDIAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_PERCENTUAL_PERDA_MEDIA"] = value; //04
                      whereClauses.Add($" GRP_PERCENTUAL_PERDA_MEDIA = @GRP_PERCENTUAL_PERDA_MEDIA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRP_FILTRA_SEQ_TRANSQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_FILTRA_SEQ_TRANS"] = value; //04
                      whereClauses.Add($" GRP_FILTRA_SEQ_TRANS = @GRP_FILTRA_SEQ_TRANS ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGRP_IMG_CAIXAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_IMG_CAIXA"] = value; //04
                      whereClauses.Add($" GRP_IMG_CAIXA = @GRP_IMG_CAIXA ");//04
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
            this.Query = $"SELECT 1 FROM GrupoProdutoAbstrato ";
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
            this.Query = $"SELECT 1 FROM GrupoProdutoAbstrato ";
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
            this.Query = $"SELECT 1 FROM GrupoProdutoAbstrato ";
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
            this.Query = $"SELECT 1 FROM GrupoProdutoAbstrato ";
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
        public QueryModel FirstByGRP_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT GRP_ID, GRP_DESCRICAO, TEM_ID, GRP_TIPO, GRP_PAP_ONDA, GRP_PAP_GRAMATURA, GRP_PAP_ALTURA, GRP_PAP_NOME_COMERCIAL, GRP_ATIVO, GRP_DT_CRIACAO, GRP_PAPEL1, GRP_PAPEL2, GRP_PAPEL3, GRP_PAPEL4, GRP_PAPEL5, GRP_ID_INTEGRACAO, GRP_ID_INTEGRACAO_ERP, GRP_TYPE, GRP_PERFORMANCE, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, GRP_RESINA, GRP_ENDURECEDOR_MIOLO, VIN_ID, GRP_COLUNA_DE, GRP_COLUNA_ATE, GRP_CRUSH, GRP_ID_FAMILIA, GRP_REFILE_LARGURA, GRP_REFILE_COMPRIMENTO, GRP_TIPO_LAP, GRP_LAP_PROLONGADO, GRP_TAMANHO_LAP_OND_SIMPLES, GRP_TAMANHO_LAP_OND_DUPLA, GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, GRP_FEFCO, GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, GRP_PREFIXO_ID_PRODUTO, GRP_COLUNA_CAIXA, GRP_COLUNA_CHAPA, GRP_MULLEN, GRP_TENDENCIA_TOLERANCIA_PEDIDO, GRP_PERCENTUAL_PERDA_MEDIA, GRP_FILTRA_SEQ_TRANS, GRP_IMG_CAIXA, TenantID, Deleted, Changed, UserId FROM GrupoProdutoAbstrato ";
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
        public QueryModel FirstByGRP_DESCRICAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT GRP_ID, GRP_DESCRICAO, TEM_ID, GRP_TIPO, GRP_PAP_ONDA, GRP_PAP_GRAMATURA, GRP_PAP_ALTURA, GRP_PAP_NOME_COMERCIAL, GRP_ATIVO, GRP_DT_CRIACAO, GRP_PAPEL1, GRP_PAPEL2, GRP_PAPEL3, GRP_PAPEL4, GRP_PAPEL5, GRP_ID_INTEGRACAO, GRP_ID_INTEGRACAO_ERP, GRP_TYPE, GRP_PERFORMANCE, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, GRP_RESINA, GRP_ENDURECEDOR_MIOLO, VIN_ID, GRP_COLUNA_DE, GRP_COLUNA_ATE, GRP_CRUSH, GRP_ID_FAMILIA, GRP_REFILE_LARGURA, GRP_REFILE_COMPRIMENTO, GRP_TIPO_LAP, GRP_LAP_PROLONGADO, GRP_TAMANHO_LAP_OND_SIMPLES, GRP_TAMANHO_LAP_OND_DUPLA, GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, GRP_FEFCO, GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, GRP_PREFIXO_ID_PRODUTO, GRP_COLUNA_CAIXA, GRP_COLUNA_CHAPA, GRP_MULLEN, GRP_TENDENCIA_TOLERANCIA_PEDIDO, GRP_PERCENTUAL_PERDA_MEDIA, GRP_FILTRA_SEQ_TRANS, GRP_IMG_CAIXA, TenantID, Deleted, Changed, UserId FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_DESCRICAO"] = value; //06
                      whereClauses.Add($" GRP_DESCRICAO = @GRP_DESCRICAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTEM_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT GRP_ID, GRP_DESCRICAO, TEM_ID, GRP_TIPO, GRP_PAP_ONDA, GRP_PAP_GRAMATURA, GRP_PAP_ALTURA, GRP_PAP_NOME_COMERCIAL, GRP_ATIVO, GRP_DT_CRIACAO, GRP_PAPEL1, GRP_PAPEL2, GRP_PAPEL3, GRP_PAPEL4, GRP_PAPEL5, GRP_ID_INTEGRACAO, GRP_ID_INTEGRACAO_ERP, GRP_TYPE, GRP_PERFORMANCE, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, GRP_RESINA, GRP_ENDURECEDOR_MIOLO, VIN_ID, GRP_COLUNA_DE, GRP_COLUNA_ATE, GRP_CRUSH, GRP_ID_FAMILIA, GRP_REFILE_LARGURA, GRP_REFILE_COMPRIMENTO, GRP_TIPO_LAP, GRP_LAP_PROLONGADO, GRP_TAMANHO_LAP_OND_SIMPLES, GRP_TAMANHO_LAP_OND_DUPLA, GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, GRP_FEFCO, GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, GRP_PREFIXO_ID_PRODUTO, GRP_COLUNA_CAIXA, GRP_COLUNA_CHAPA, GRP_MULLEN, GRP_TENDENCIA_TOLERANCIA_PEDIDO, GRP_PERCENTUAL_PERDA_MEDIA, GRP_FILTRA_SEQ_TRANS, GRP_IMG_CAIXA, TenantID, Deleted, Changed, UserId FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TEM_ID"] = value; //06
                      whereClauses.Add($" TEM_ID = @TEM_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRP_TIPOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT GRP_ID, GRP_DESCRICAO, TEM_ID, GRP_TIPO, GRP_PAP_ONDA, GRP_PAP_GRAMATURA, GRP_PAP_ALTURA, GRP_PAP_NOME_COMERCIAL, GRP_ATIVO, GRP_DT_CRIACAO, GRP_PAPEL1, GRP_PAPEL2, GRP_PAPEL3, GRP_PAPEL4, GRP_PAPEL5, GRP_ID_INTEGRACAO, GRP_ID_INTEGRACAO_ERP, GRP_TYPE, GRP_PERFORMANCE, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, GRP_RESINA, GRP_ENDURECEDOR_MIOLO, VIN_ID, GRP_COLUNA_DE, GRP_COLUNA_ATE, GRP_CRUSH, GRP_ID_FAMILIA, GRP_REFILE_LARGURA, GRP_REFILE_COMPRIMENTO, GRP_TIPO_LAP, GRP_LAP_PROLONGADO, GRP_TAMANHO_LAP_OND_SIMPLES, GRP_TAMANHO_LAP_OND_DUPLA, GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, GRP_FEFCO, GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, GRP_PREFIXO_ID_PRODUTO, GRP_COLUNA_CAIXA, GRP_COLUNA_CHAPA, GRP_MULLEN, GRP_TENDENCIA_TOLERANCIA_PEDIDO, GRP_PERCENTUAL_PERDA_MEDIA, GRP_FILTRA_SEQ_TRANS, GRP_IMG_CAIXA, TenantID, Deleted, Changed, UserId FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_TIPO"] = value; //06
                      whereClauses.Add($" GRP_TIPO = @GRP_TIPO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRP_PAP_ONDAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT GRP_ID, GRP_DESCRICAO, TEM_ID, GRP_TIPO, GRP_PAP_ONDA, GRP_PAP_GRAMATURA, GRP_PAP_ALTURA, GRP_PAP_NOME_COMERCIAL, GRP_ATIVO, GRP_DT_CRIACAO, GRP_PAPEL1, GRP_PAPEL2, GRP_PAPEL3, GRP_PAPEL4, GRP_PAPEL5, GRP_ID_INTEGRACAO, GRP_ID_INTEGRACAO_ERP, GRP_TYPE, GRP_PERFORMANCE, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, GRP_RESINA, GRP_ENDURECEDOR_MIOLO, VIN_ID, GRP_COLUNA_DE, GRP_COLUNA_ATE, GRP_CRUSH, GRP_ID_FAMILIA, GRP_REFILE_LARGURA, GRP_REFILE_COMPRIMENTO, GRP_TIPO_LAP, GRP_LAP_PROLONGADO, GRP_TAMANHO_LAP_OND_SIMPLES, GRP_TAMANHO_LAP_OND_DUPLA, GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, GRP_FEFCO, GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, GRP_PREFIXO_ID_PRODUTO, GRP_COLUNA_CAIXA, GRP_COLUNA_CHAPA, GRP_MULLEN, GRP_TENDENCIA_TOLERANCIA_PEDIDO, GRP_PERCENTUAL_PERDA_MEDIA, GRP_FILTRA_SEQ_TRANS, GRP_IMG_CAIXA, TenantID, Deleted, Changed, UserId FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_PAP_ONDA"] = value; //06
                      whereClauses.Add($" GRP_PAP_ONDA = @GRP_PAP_ONDA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRP_PAP_GRAMATURAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT GRP_ID, GRP_DESCRICAO, TEM_ID, GRP_TIPO, GRP_PAP_ONDA, GRP_PAP_GRAMATURA, GRP_PAP_ALTURA, GRP_PAP_NOME_COMERCIAL, GRP_ATIVO, GRP_DT_CRIACAO, GRP_PAPEL1, GRP_PAPEL2, GRP_PAPEL3, GRP_PAPEL4, GRP_PAPEL5, GRP_ID_INTEGRACAO, GRP_ID_INTEGRACAO_ERP, GRP_TYPE, GRP_PERFORMANCE, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, GRP_RESINA, GRP_ENDURECEDOR_MIOLO, VIN_ID, GRP_COLUNA_DE, GRP_COLUNA_ATE, GRP_CRUSH, GRP_ID_FAMILIA, GRP_REFILE_LARGURA, GRP_REFILE_COMPRIMENTO, GRP_TIPO_LAP, GRP_LAP_PROLONGADO, GRP_TAMANHO_LAP_OND_SIMPLES, GRP_TAMANHO_LAP_OND_DUPLA, GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, GRP_FEFCO, GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, GRP_PREFIXO_ID_PRODUTO, GRP_COLUNA_CAIXA, GRP_COLUNA_CHAPA, GRP_MULLEN, GRP_TENDENCIA_TOLERANCIA_PEDIDO, GRP_PERCENTUAL_PERDA_MEDIA, GRP_FILTRA_SEQ_TRANS, GRP_IMG_CAIXA, TenantID, Deleted, Changed, UserId FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_PAP_GRAMATURA"] = value; //06
                      whereClauses.Add($" GRP_PAP_GRAMATURA = @GRP_PAP_GRAMATURA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRP_PAP_ALTURAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT GRP_ID, GRP_DESCRICAO, TEM_ID, GRP_TIPO, GRP_PAP_ONDA, GRP_PAP_GRAMATURA, GRP_PAP_ALTURA, GRP_PAP_NOME_COMERCIAL, GRP_ATIVO, GRP_DT_CRIACAO, GRP_PAPEL1, GRP_PAPEL2, GRP_PAPEL3, GRP_PAPEL4, GRP_PAPEL5, GRP_ID_INTEGRACAO, GRP_ID_INTEGRACAO_ERP, GRP_TYPE, GRP_PERFORMANCE, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, GRP_RESINA, GRP_ENDURECEDOR_MIOLO, VIN_ID, GRP_COLUNA_DE, GRP_COLUNA_ATE, GRP_CRUSH, GRP_ID_FAMILIA, GRP_REFILE_LARGURA, GRP_REFILE_COMPRIMENTO, GRP_TIPO_LAP, GRP_LAP_PROLONGADO, GRP_TAMANHO_LAP_OND_SIMPLES, GRP_TAMANHO_LAP_OND_DUPLA, GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, GRP_FEFCO, GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, GRP_PREFIXO_ID_PRODUTO, GRP_COLUNA_CAIXA, GRP_COLUNA_CHAPA, GRP_MULLEN, GRP_TENDENCIA_TOLERANCIA_PEDIDO, GRP_PERCENTUAL_PERDA_MEDIA, GRP_FILTRA_SEQ_TRANS, GRP_IMG_CAIXA, TenantID, Deleted, Changed, UserId FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_PAP_ALTURA"] = value; //06
                      whereClauses.Add($" GRP_PAP_ALTURA = @GRP_PAP_ALTURA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRP_PAP_NOME_COMERCIALQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT GRP_ID, GRP_DESCRICAO, TEM_ID, GRP_TIPO, GRP_PAP_ONDA, GRP_PAP_GRAMATURA, GRP_PAP_ALTURA, GRP_PAP_NOME_COMERCIAL, GRP_ATIVO, GRP_DT_CRIACAO, GRP_PAPEL1, GRP_PAPEL2, GRP_PAPEL3, GRP_PAPEL4, GRP_PAPEL5, GRP_ID_INTEGRACAO, GRP_ID_INTEGRACAO_ERP, GRP_TYPE, GRP_PERFORMANCE, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, GRP_RESINA, GRP_ENDURECEDOR_MIOLO, VIN_ID, GRP_COLUNA_DE, GRP_COLUNA_ATE, GRP_CRUSH, GRP_ID_FAMILIA, GRP_REFILE_LARGURA, GRP_REFILE_COMPRIMENTO, GRP_TIPO_LAP, GRP_LAP_PROLONGADO, GRP_TAMANHO_LAP_OND_SIMPLES, GRP_TAMANHO_LAP_OND_DUPLA, GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, GRP_FEFCO, GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, GRP_PREFIXO_ID_PRODUTO, GRP_COLUNA_CAIXA, GRP_COLUNA_CHAPA, GRP_MULLEN, GRP_TENDENCIA_TOLERANCIA_PEDIDO, GRP_PERCENTUAL_PERDA_MEDIA, GRP_FILTRA_SEQ_TRANS, GRP_IMG_CAIXA, TenantID, Deleted, Changed, UserId FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_PAP_NOME_COMERCIAL"] = value; //06
                      whereClauses.Add($" GRP_PAP_NOME_COMERCIAL = @GRP_PAP_NOME_COMERCIAL ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRP_ATIVOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT GRP_ID, GRP_DESCRICAO, TEM_ID, GRP_TIPO, GRP_PAP_ONDA, GRP_PAP_GRAMATURA, GRP_PAP_ALTURA, GRP_PAP_NOME_COMERCIAL, GRP_ATIVO, GRP_DT_CRIACAO, GRP_PAPEL1, GRP_PAPEL2, GRP_PAPEL3, GRP_PAPEL4, GRP_PAPEL5, GRP_ID_INTEGRACAO, GRP_ID_INTEGRACAO_ERP, GRP_TYPE, GRP_PERFORMANCE, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, GRP_RESINA, GRP_ENDURECEDOR_MIOLO, VIN_ID, GRP_COLUNA_DE, GRP_COLUNA_ATE, GRP_CRUSH, GRP_ID_FAMILIA, GRP_REFILE_LARGURA, GRP_REFILE_COMPRIMENTO, GRP_TIPO_LAP, GRP_LAP_PROLONGADO, GRP_TAMANHO_LAP_OND_SIMPLES, GRP_TAMANHO_LAP_OND_DUPLA, GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, GRP_FEFCO, GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, GRP_PREFIXO_ID_PRODUTO, GRP_COLUNA_CAIXA, GRP_COLUNA_CHAPA, GRP_MULLEN, GRP_TENDENCIA_TOLERANCIA_PEDIDO, GRP_PERCENTUAL_PERDA_MEDIA, GRP_FILTRA_SEQ_TRANS, GRP_IMG_CAIXA, TenantID, Deleted, Changed, UserId FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_ATIVO"] = value; //06
                      whereClauses.Add($" GRP_ATIVO = @GRP_ATIVO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRP_DT_CRIACAOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT GRP_ID, GRP_DESCRICAO, TEM_ID, GRP_TIPO, GRP_PAP_ONDA, GRP_PAP_GRAMATURA, GRP_PAP_ALTURA, GRP_PAP_NOME_COMERCIAL, GRP_ATIVO, GRP_DT_CRIACAO, GRP_PAPEL1, GRP_PAPEL2, GRP_PAPEL3, GRP_PAPEL4, GRP_PAPEL5, GRP_ID_INTEGRACAO, GRP_ID_INTEGRACAO_ERP, GRP_TYPE, GRP_PERFORMANCE, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, GRP_RESINA, GRP_ENDURECEDOR_MIOLO, VIN_ID, GRP_COLUNA_DE, GRP_COLUNA_ATE, GRP_CRUSH, GRP_ID_FAMILIA, GRP_REFILE_LARGURA, GRP_REFILE_COMPRIMENTO, GRP_TIPO_LAP, GRP_LAP_PROLONGADO, GRP_TAMANHO_LAP_OND_SIMPLES, GRP_TAMANHO_LAP_OND_DUPLA, GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, GRP_FEFCO, GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, GRP_PREFIXO_ID_PRODUTO, GRP_COLUNA_CAIXA, GRP_COLUNA_CHAPA, GRP_MULLEN, GRP_TENDENCIA_TOLERANCIA_PEDIDO, GRP_PERCENTUAL_PERDA_MEDIA, GRP_FILTRA_SEQ_TRANS, GRP_IMG_CAIXA, TenantID, Deleted, Changed, UserId FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_DT_CRIACAO"] = value; //06
                      whereClauses.Add($" GRP_DT_CRIACAO = @GRP_DT_CRIACAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRP_PAPEL1Query(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT GRP_ID, GRP_DESCRICAO, TEM_ID, GRP_TIPO, GRP_PAP_ONDA, GRP_PAP_GRAMATURA, GRP_PAP_ALTURA, GRP_PAP_NOME_COMERCIAL, GRP_ATIVO, GRP_DT_CRIACAO, GRP_PAPEL1, GRP_PAPEL2, GRP_PAPEL3, GRP_PAPEL4, GRP_PAPEL5, GRP_ID_INTEGRACAO, GRP_ID_INTEGRACAO_ERP, GRP_TYPE, GRP_PERFORMANCE, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, GRP_RESINA, GRP_ENDURECEDOR_MIOLO, VIN_ID, GRP_COLUNA_DE, GRP_COLUNA_ATE, GRP_CRUSH, GRP_ID_FAMILIA, GRP_REFILE_LARGURA, GRP_REFILE_COMPRIMENTO, GRP_TIPO_LAP, GRP_LAP_PROLONGADO, GRP_TAMANHO_LAP_OND_SIMPLES, GRP_TAMANHO_LAP_OND_DUPLA, GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, GRP_FEFCO, GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, GRP_PREFIXO_ID_PRODUTO, GRP_COLUNA_CAIXA, GRP_COLUNA_CHAPA, GRP_MULLEN, GRP_TENDENCIA_TOLERANCIA_PEDIDO, GRP_PERCENTUAL_PERDA_MEDIA, GRP_FILTRA_SEQ_TRANS, GRP_IMG_CAIXA, TenantID, Deleted, Changed, UserId FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_PAPEL1"] = value; //06
                      whereClauses.Add($" GRP_PAPEL1 = @GRP_PAPEL1 ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRP_PAPEL2Query(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT GRP_ID, GRP_DESCRICAO, TEM_ID, GRP_TIPO, GRP_PAP_ONDA, GRP_PAP_GRAMATURA, GRP_PAP_ALTURA, GRP_PAP_NOME_COMERCIAL, GRP_ATIVO, GRP_DT_CRIACAO, GRP_PAPEL1, GRP_PAPEL2, GRP_PAPEL3, GRP_PAPEL4, GRP_PAPEL5, GRP_ID_INTEGRACAO, GRP_ID_INTEGRACAO_ERP, GRP_TYPE, GRP_PERFORMANCE, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, GRP_RESINA, GRP_ENDURECEDOR_MIOLO, VIN_ID, GRP_COLUNA_DE, GRP_COLUNA_ATE, GRP_CRUSH, GRP_ID_FAMILIA, GRP_REFILE_LARGURA, GRP_REFILE_COMPRIMENTO, GRP_TIPO_LAP, GRP_LAP_PROLONGADO, GRP_TAMANHO_LAP_OND_SIMPLES, GRP_TAMANHO_LAP_OND_DUPLA, GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, GRP_FEFCO, GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, GRP_PREFIXO_ID_PRODUTO, GRP_COLUNA_CAIXA, GRP_COLUNA_CHAPA, GRP_MULLEN, GRP_TENDENCIA_TOLERANCIA_PEDIDO, GRP_PERCENTUAL_PERDA_MEDIA, GRP_FILTRA_SEQ_TRANS, GRP_IMG_CAIXA, TenantID, Deleted, Changed, UserId FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_PAPEL2"] = value; //06
                      whereClauses.Add($" GRP_PAPEL2 = @GRP_PAPEL2 ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRP_PAPEL3Query(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT GRP_ID, GRP_DESCRICAO, TEM_ID, GRP_TIPO, GRP_PAP_ONDA, GRP_PAP_GRAMATURA, GRP_PAP_ALTURA, GRP_PAP_NOME_COMERCIAL, GRP_ATIVO, GRP_DT_CRIACAO, GRP_PAPEL1, GRP_PAPEL2, GRP_PAPEL3, GRP_PAPEL4, GRP_PAPEL5, GRP_ID_INTEGRACAO, GRP_ID_INTEGRACAO_ERP, GRP_TYPE, GRP_PERFORMANCE, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, GRP_RESINA, GRP_ENDURECEDOR_MIOLO, VIN_ID, GRP_COLUNA_DE, GRP_COLUNA_ATE, GRP_CRUSH, GRP_ID_FAMILIA, GRP_REFILE_LARGURA, GRP_REFILE_COMPRIMENTO, GRP_TIPO_LAP, GRP_LAP_PROLONGADO, GRP_TAMANHO_LAP_OND_SIMPLES, GRP_TAMANHO_LAP_OND_DUPLA, GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, GRP_FEFCO, GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, GRP_PREFIXO_ID_PRODUTO, GRP_COLUNA_CAIXA, GRP_COLUNA_CHAPA, GRP_MULLEN, GRP_TENDENCIA_TOLERANCIA_PEDIDO, GRP_PERCENTUAL_PERDA_MEDIA, GRP_FILTRA_SEQ_TRANS, GRP_IMG_CAIXA, TenantID, Deleted, Changed, UserId FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_PAPEL3"] = value; //06
                      whereClauses.Add($" GRP_PAPEL3 = @GRP_PAPEL3 ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRP_PAPEL4Query(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT GRP_ID, GRP_DESCRICAO, TEM_ID, GRP_TIPO, GRP_PAP_ONDA, GRP_PAP_GRAMATURA, GRP_PAP_ALTURA, GRP_PAP_NOME_COMERCIAL, GRP_ATIVO, GRP_DT_CRIACAO, GRP_PAPEL1, GRP_PAPEL2, GRP_PAPEL3, GRP_PAPEL4, GRP_PAPEL5, GRP_ID_INTEGRACAO, GRP_ID_INTEGRACAO_ERP, GRP_TYPE, GRP_PERFORMANCE, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, GRP_RESINA, GRP_ENDURECEDOR_MIOLO, VIN_ID, GRP_COLUNA_DE, GRP_COLUNA_ATE, GRP_CRUSH, GRP_ID_FAMILIA, GRP_REFILE_LARGURA, GRP_REFILE_COMPRIMENTO, GRP_TIPO_LAP, GRP_LAP_PROLONGADO, GRP_TAMANHO_LAP_OND_SIMPLES, GRP_TAMANHO_LAP_OND_DUPLA, GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, GRP_FEFCO, GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, GRP_PREFIXO_ID_PRODUTO, GRP_COLUNA_CAIXA, GRP_COLUNA_CHAPA, GRP_MULLEN, GRP_TENDENCIA_TOLERANCIA_PEDIDO, GRP_PERCENTUAL_PERDA_MEDIA, GRP_FILTRA_SEQ_TRANS, GRP_IMG_CAIXA, TenantID, Deleted, Changed, UserId FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_PAPEL4"] = value; //06
                      whereClauses.Add($" GRP_PAPEL4 = @GRP_PAPEL4 ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRP_PAPEL5Query(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT GRP_ID, GRP_DESCRICAO, TEM_ID, GRP_TIPO, GRP_PAP_ONDA, GRP_PAP_GRAMATURA, GRP_PAP_ALTURA, GRP_PAP_NOME_COMERCIAL, GRP_ATIVO, GRP_DT_CRIACAO, GRP_PAPEL1, GRP_PAPEL2, GRP_PAPEL3, GRP_PAPEL4, GRP_PAPEL5, GRP_ID_INTEGRACAO, GRP_ID_INTEGRACAO_ERP, GRP_TYPE, GRP_PERFORMANCE, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, GRP_RESINA, GRP_ENDURECEDOR_MIOLO, VIN_ID, GRP_COLUNA_DE, GRP_COLUNA_ATE, GRP_CRUSH, GRP_ID_FAMILIA, GRP_REFILE_LARGURA, GRP_REFILE_COMPRIMENTO, GRP_TIPO_LAP, GRP_LAP_PROLONGADO, GRP_TAMANHO_LAP_OND_SIMPLES, GRP_TAMANHO_LAP_OND_DUPLA, GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, GRP_FEFCO, GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, GRP_PREFIXO_ID_PRODUTO, GRP_COLUNA_CAIXA, GRP_COLUNA_CHAPA, GRP_MULLEN, GRP_TENDENCIA_TOLERANCIA_PEDIDO, GRP_PERCENTUAL_PERDA_MEDIA, GRP_FILTRA_SEQ_TRANS, GRP_IMG_CAIXA, TenantID, Deleted, Changed, UserId FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_PAPEL5"] = value; //06
                      whereClauses.Add($" GRP_PAPEL5 = @GRP_PAPEL5 ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRP_ID_INTEGRACAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT GRP_ID, GRP_DESCRICAO, TEM_ID, GRP_TIPO, GRP_PAP_ONDA, GRP_PAP_GRAMATURA, GRP_PAP_ALTURA, GRP_PAP_NOME_COMERCIAL, GRP_ATIVO, GRP_DT_CRIACAO, GRP_PAPEL1, GRP_PAPEL2, GRP_PAPEL3, GRP_PAPEL4, GRP_PAPEL5, GRP_ID_INTEGRACAO, GRP_ID_INTEGRACAO_ERP, GRP_TYPE, GRP_PERFORMANCE, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, GRP_RESINA, GRP_ENDURECEDOR_MIOLO, VIN_ID, GRP_COLUNA_DE, GRP_COLUNA_ATE, GRP_CRUSH, GRP_ID_FAMILIA, GRP_REFILE_LARGURA, GRP_REFILE_COMPRIMENTO, GRP_TIPO_LAP, GRP_LAP_PROLONGADO, GRP_TAMANHO_LAP_OND_SIMPLES, GRP_TAMANHO_LAP_OND_DUPLA, GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, GRP_FEFCO, GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, GRP_PREFIXO_ID_PRODUTO, GRP_COLUNA_CAIXA, GRP_COLUNA_CHAPA, GRP_MULLEN, GRP_TENDENCIA_TOLERANCIA_PEDIDO, GRP_PERCENTUAL_PERDA_MEDIA, GRP_FILTRA_SEQ_TRANS, GRP_IMG_CAIXA, TenantID, Deleted, Changed, UserId FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_ID_INTEGRACAO"] = value; //06
                      whereClauses.Add($" GRP_ID_INTEGRACAO = @GRP_ID_INTEGRACAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRP_ID_INTEGRACAO_ERPQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT GRP_ID, GRP_DESCRICAO, TEM_ID, GRP_TIPO, GRP_PAP_ONDA, GRP_PAP_GRAMATURA, GRP_PAP_ALTURA, GRP_PAP_NOME_COMERCIAL, GRP_ATIVO, GRP_DT_CRIACAO, GRP_PAPEL1, GRP_PAPEL2, GRP_PAPEL3, GRP_PAPEL4, GRP_PAPEL5, GRP_ID_INTEGRACAO, GRP_ID_INTEGRACAO_ERP, GRP_TYPE, GRP_PERFORMANCE, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, GRP_RESINA, GRP_ENDURECEDOR_MIOLO, VIN_ID, GRP_COLUNA_DE, GRP_COLUNA_ATE, GRP_CRUSH, GRP_ID_FAMILIA, GRP_REFILE_LARGURA, GRP_REFILE_COMPRIMENTO, GRP_TIPO_LAP, GRP_LAP_PROLONGADO, GRP_TAMANHO_LAP_OND_SIMPLES, GRP_TAMANHO_LAP_OND_DUPLA, GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, GRP_FEFCO, GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, GRP_PREFIXO_ID_PRODUTO, GRP_COLUNA_CAIXA, GRP_COLUNA_CHAPA, GRP_MULLEN, GRP_TENDENCIA_TOLERANCIA_PEDIDO, GRP_PERCENTUAL_PERDA_MEDIA, GRP_FILTRA_SEQ_TRANS, GRP_IMG_CAIXA, TenantID, Deleted, Changed, UserId FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_ID_INTEGRACAO_ERP"] = value; //06
                      whereClauses.Add($" GRP_ID_INTEGRACAO_ERP = @GRP_ID_INTEGRACAO_ERP ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRP_TYPEQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT GRP_ID, GRP_DESCRICAO, TEM_ID, GRP_TIPO, GRP_PAP_ONDA, GRP_PAP_GRAMATURA, GRP_PAP_ALTURA, GRP_PAP_NOME_COMERCIAL, GRP_ATIVO, GRP_DT_CRIACAO, GRP_PAPEL1, GRP_PAPEL2, GRP_PAPEL3, GRP_PAPEL4, GRP_PAPEL5, GRP_ID_INTEGRACAO, GRP_ID_INTEGRACAO_ERP, GRP_TYPE, GRP_PERFORMANCE, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, GRP_RESINA, GRP_ENDURECEDOR_MIOLO, VIN_ID, GRP_COLUNA_DE, GRP_COLUNA_ATE, GRP_CRUSH, GRP_ID_FAMILIA, GRP_REFILE_LARGURA, GRP_REFILE_COMPRIMENTO, GRP_TIPO_LAP, GRP_LAP_PROLONGADO, GRP_TAMANHO_LAP_OND_SIMPLES, GRP_TAMANHO_LAP_OND_DUPLA, GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, GRP_FEFCO, GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, GRP_PREFIXO_ID_PRODUTO, GRP_COLUNA_CAIXA, GRP_COLUNA_CHAPA, GRP_MULLEN, GRP_TENDENCIA_TOLERANCIA_PEDIDO, GRP_PERCENTUAL_PERDA_MEDIA, GRP_FILTRA_SEQ_TRANS, GRP_IMG_CAIXA, TenantID, Deleted, Changed, UserId FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_TYPE"] = value; //06
                      whereClauses.Add($" GRP_TYPE = @GRP_TYPE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRP_PERFORMANCEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT GRP_ID, GRP_DESCRICAO, TEM_ID, GRP_TIPO, GRP_PAP_ONDA, GRP_PAP_GRAMATURA, GRP_PAP_ALTURA, GRP_PAP_NOME_COMERCIAL, GRP_ATIVO, GRP_DT_CRIACAO, GRP_PAPEL1, GRP_PAPEL2, GRP_PAPEL3, GRP_PAPEL4, GRP_PAPEL5, GRP_ID_INTEGRACAO, GRP_ID_INTEGRACAO_ERP, GRP_TYPE, GRP_PERFORMANCE, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, GRP_RESINA, GRP_ENDURECEDOR_MIOLO, VIN_ID, GRP_COLUNA_DE, GRP_COLUNA_ATE, GRP_CRUSH, GRP_ID_FAMILIA, GRP_REFILE_LARGURA, GRP_REFILE_COMPRIMENTO, GRP_TIPO_LAP, GRP_LAP_PROLONGADO, GRP_TAMANHO_LAP_OND_SIMPLES, GRP_TAMANHO_LAP_OND_DUPLA, GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, GRP_FEFCO, GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, GRP_PREFIXO_ID_PRODUTO, GRP_COLUNA_CAIXA, GRP_COLUNA_CHAPA, GRP_MULLEN, GRP_TENDENCIA_TOLERANCIA_PEDIDO, GRP_PERCENTUAL_PERDA_MEDIA, GRP_FILTRA_SEQ_TRANS, GRP_IMG_CAIXA, TenantID, Deleted, Changed, UserId FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_PERFORMANCE"] = value; //06
                      whereClauses.Add($" GRP_PERFORMANCE = @GRP_PERFORMANCE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT GRP_ID, GRP_DESCRICAO, TEM_ID, GRP_TIPO, GRP_PAP_ONDA, GRP_PAP_GRAMATURA, GRP_PAP_ALTURA, GRP_PAP_NOME_COMERCIAL, GRP_ATIVO, GRP_DT_CRIACAO, GRP_PAPEL1, GRP_PAPEL2, GRP_PAPEL3, GRP_PAPEL4, GRP_PAPEL5, GRP_ID_INTEGRACAO, GRP_ID_INTEGRACAO_ERP, GRP_TYPE, GRP_PERFORMANCE, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, GRP_RESINA, GRP_ENDURECEDOR_MIOLO, VIN_ID, GRP_COLUNA_DE, GRP_COLUNA_ATE, GRP_CRUSH, GRP_ID_FAMILIA, GRP_REFILE_LARGURA, GRP_REFILE_COMPRIMENTO, GRP_TIPO_LAP, GRP_LAP_PROLONGADO, GRP_TAMANHO_LAP_OND_SIMPLES, GRP_TAMANHO_LAP_OND_DUPLA, GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, GRP_FEFCO, GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, GRP_PREFIXO_ID_PRODUTO, GRP_COLUNA_CAIXA, GRP_COLUNA_CHAPA, GRP_MULLEN, GRP_TENDENCIA_TOLERANCIA_PEDIDO, GRP_PERCENTUAL_PERDA_MEDIA, GRP_FILTRA_SEQ_TRANS, GRP_IMG_CAIXA, TenantID, Deleted, Changed, UserId FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO"] = value; //06
                      whereClauses.Add($" GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO = @GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRP_RESINAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT GRP_ID, GRP_DESCRICAO, TEM_ID, GRP_TIPO, GRP_PAP_ONDA, GRP_PAP_GRAMATURA, GRP_PAP_ALTURA, GRP_PAP_NOME_COMERCIAL, GRP_ATIVO, GRP_DT_CRIACAO, GRP_PAPEL1, GRP_PAPEL2, GRP_PAPEL3, GRP_PAPEL4, GRP_PAPEL5, GRP_ID_INTEGRACAO, GRP_ID_INTEGRACAO_ERP, GRP_TYPE, GRP_PERFORMANCE, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, GRP_RESINA, GRP_ENDURECEDOR_MIOLO, VIN_ID, GRP_COLUNA_DE, GRP_COLUNA_ATE, GRP_CRUSH, GRP_ID_FAMILIA, GRP_REFILE_LARGURA, GRP_REFILE_COMPRIMENTO, GRP_TIPO_LAP, GRP_LAP_PROLONGADO, GRP_TAMANHO_LAP_OND_SIMPLES, GRP_TAMANHO_LAP_OND_DUPLA, GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, GRP_FEFCO, GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, GRP_PREFIXO_ID_PRODUTO, GRP_COLUNA_CAIXA, GRP_COLUNA_CHAPA, GRP_MULLEN, GRP_TENDENCIA_TOLERANCIA_PEDIDO, GRP_PERCENTUAL_PERDA_MEDIA, GRP_FILTRA_SEQ_TRANS, GRP_IMG_CAIXA, TenantID, Deleted, Changed, UserId FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_RESINA"] = value; //06
                      whereClauses.Add($" GRP_RESINA = @GRP_RESINA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRP_ENDURECEDOR_MIOLOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT GRP_ID, GRP_DESCRICAO, TEM_ID, GRP_TIPO, GRP_PAP_ONDA, GRP_PAP_GRAMATURA, GRP_PAP_ALTURA, GRP_PAP_NOME_COMERCIAL, GRP_ATIVO, GRP_DT_CRIACAO, GRP_PAPEL1, GRP_PAPEL2, GRP_PAPEL3, GRP_PAPEL4, GRP_PAPEL5, GRP_ID_INTEGRACAO, GRP_ID_INTEGRACAO_ERP, GRP_TYPE, GRP_PERFORMANCE, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, GRP_RESINA, GRP_ENDURECEDOR_MIOLO, VIN_ID, GRP_COLUNA_DE, GRP_COLUNA_ATE, GRP_CRUSH, GRP_ID_FAMILIA, GRP_REFILE_LARGURA, GRP_REFILE_COMPRIMENTO, GRP_TIPO_LAP, GRP_LAP_PROLONGADO, GRP_TAMANHO_LAP_OND_SIMPLES, GRP_TAMANHO_LAP_OND_DUPLA, GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, GRP_FEFCO, GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, GRP_PREFIXO_ID_PRODUTO, GRP_COLUNA_CAIXA, GRP_COLUNA_CHAPA, GRP_MULLEN, GRP_TENDENCIA_TOLERANCIA_PEDIDO, GRP_PERCENTUAL_PERDA_MEDIA, GRP_FILTRA_SEQ_TRANS, GRP_IMG_CAIXA, TenantID, Deleted, Changed, UserId FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_ENDURECEDOR_MIOLO"] = value; //06
                      whereClauses.Add($" GRP_ENDURECEDOR_MIOLO = @GRP_ENDURECEDOR_MIOLO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByVIN_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT GRP_ID, GRP_DESCRICAO, TEM_ID, GRP_TIPO, GRP_PAP_ONDA, GRP_PAP_GRAMATURA, GRP_PAP_ALTURA, GRP_PAP_NOME_COMERCIAL, GRP_ATIVO, GRP_DT_CRIACAO, GRP_PAPEL1, GRP_PAPEL2, GRP_PAPEL3, GRP_PAPEL4, GRP_PAPEL5, GRP_ID_INTEGRACAO, GRP_ID_INTEGRACAO_ERP, GRP_TYPE, GRP_PERFORMANCE, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, GRP_RESINA, GRP_ENDURECEDOR_MIOLO, VIN_ID, GRP_COLUNA_DE, GRP_COLUNA_ATE, GRP_CRUSH, GRP_ID_FAMILIA, GRP_REFILE_LARGURA, GRP_REFILE_COMPRIMENTO, GRP_TIPO_LAP, GRP_LAP_PROLONGADO, GRP_TAMANHO_LAP_OND_SIMPLES, GRP_TAMANHO_LAP_OND_DUPLA, GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, GRP_FEFCO, GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, GRP_PREFIXO_ID_PRODUTO, GRP_COLUNA_CAIXA, GRP_COLUNA_CHAPA, GRP_MULLEN, GRP_TENDENCIA_TOLERANCIA_PEDIDO, GRP_PERCENTUAL_PERDA_MEDIA, GRP_FILTRA_SEQ_TRANS, GRP_IMG_CAIXA, TenantID, Deleted, Changed, UserId FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["VIN_ID"] = value; //06
                      whereClauses.Add($" VIN_ID = @VIN_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRP_COLUNA_DEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT GRP_ID, GRP_DESCRICAO, TEM_ID, GRP_TIPO, GRP_PAP_ONDA, GRP_PAP_GRAMATURA, GRP_PAP_ALTURA, GRP_PAP_NOME_COMERCIAL, GRP_ATIVO, GRP_DT_CRIACAO, GRP_PAPEL1, GRP_PAPEL2, GRP_PAPEL3, GRP_PAPEL4, GRP_PAPEL5, GRP_ID_INTEGRACAO, GRP_ID_INTEGRACAO_ERP, GRP_TYPE, GRP_PERFORMANCE, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, GRP_RESINA, GRP_ENDURECEDOR_MIOLO, VIN_ID, GRP_COLUNA_DE, GRP_COLUNA_ATE, GRP_CRUSH, GRP_ID_FAMILIA, GRP_REFILE_LARGURA, GRP_REFILE_COMPRIMENTO, GRP_TIPO_LAP, GRP_LAP_PROLONGADO, GRP_TAMANHO_LAP_OND_SIMPLES, GRP_TAMANHO_LAP_OND_DUPLA, GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, GRP_FEFCO, GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, GRP_PREFIXO_ID_PRODUTO, GRP_COLUNA_CAIXA, GRP_COLUNA_CHAPA, GRP_MULLEN, GRP_TENDENCIA_TOLERANCIA_PEDIDO, GRP_PERCENTUAL_PERDA_MEDIA, GRP_FILTRA_SEQ_TRANS, GRP_IMG_CAIXA, TenantID, Deleted, Changed, UserId FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_COLUNA_DE"] = value; //06
                      whereClauses.Add($" GRP_COLUNA_DE = @GRP_COLUNA_DE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRP_COLUNA_ATEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT GRP_ID, GRP_DESCRICAO, TEM_ID, GRP_TIPO, GRP_PAP_ONDA, GRP_PAP_GRAMATURA, GRP_PAP_ALTURA, GRP_PAP_NOME_COMERCIAL, GRP_ATIVO, GRP_DT_CRIACAO, GRP_PAPEL1, GRP_PAPEL2, GRP_PAPEL3, GRP_PAPEL4, GRP_PAPEL5, GRP_ID_INTEGRACAO, GRP_ID_INTEGRACAO_ERP, GRP_TYPE, GRP_PERFORMANCE, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, GRP_RESINA, GRP_ENDURECEDOR_MIOLO, VIN_ID, GRP_COLUNA_DE, GRP_COLUNA_ATE, GRP_CRUSH, GRP_ID_FAMILIA, GRP_REFILE_LARGURA, GRP_REFILE_COMPRIMENTO, GRP_TIPO_LAP, GRP_LAP_PROLONGADO, GRP_TAMANHO_LAP_OND_SIMPLES, GRP_TAMANHO_LAP_OND_DUPLA, GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, GRP_FEFCO, GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, GRP_PREFIXO_ID_PRODUTO, GRP_COLUNA_CAIXA, GRP_COLUNA_CHAPA, GRP_MULLEN, GRP_TENDENCIA_TOLERANCIA_PEDIDO, GRP_PERCENTUAL_PERDA_MEDIA, GRP_FILTRA_SEQ_TRANS, GRP_IMG_CAIXA, TenantID, Deleted, Changed, UserId FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_COLUNA_ATE"] = value; //06
                      whereClauses.Add($" GRP_COLUNA_ATE = @GRP_COLUNA_ATE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRP_CRUSHQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT GRP_ID, GRP_DESCRICAO, TEM_ID, GRP_TIPO, GRP_PAP_ONDA, GRP_PAP_GRAMATURA, GRP_PAP_ALTURA, GRP_PAP_NOME_COMERCIAL, GRP_ATIVO, GRP_DT_CRIACAO, GRP_PAPEL1, GRP_PAPEL2, GRP_PAPEL3, GRP_PAPEL4, GRP_PAPEL5, GRP_ID_INTEGRACAO, GRP_ID_INTEGRACAO_ERP, GRP_TYPE, GRP_PERFORMANCE, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, GRP_RESINA, GRP_ENDURECEDOR_MIOLO, VIN_ID, GRP_COLUNA_DE, GRP_COLUNA_ATE, GRP_CRUSH, GRP_ID_FAMILIA, GRP_REFILE_LARGURA, GRP_REFILE_COMPRIMENTO, GRP_TIPO_LAP, GRP_LAP_PROLONGADO, GRP_TAMANHO_LAP_OND_SIMPLES, GRP_TAMANHO_LAP_OND_DUPLA, GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, GRP_FEFCO, GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, GRP_PREFIXO_ID_PRODUTO, GRP_COLUNA_CAIXA, GRP_COLUNA_CHAPA, GRP_MULLEN, GRP_TENDENCIA_TOLERANCIA_PEDIDO, GRP_PERCENTUAL_PERDA_MEDIA, GRP_FILTRA_SEQ_TRANS, GRP_IMG_CAIXA, TenantID, Deleted, Changed, UserId FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_CRUSH"] = value; //06
                      whereClauses.Add($" GRP_CRUSH = @GRP_CRUSH ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRP_ID_FAMILIAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT GRP_ID, GRP_DESCRICAO, TEM_ID, GRP_TIPO, GRP_PAP_ONDA, GRP_PAP_GRAMATURA, GRP_PAP_ALTURA, GRP_PAP_NOME_COMERCIAL, GRP_ATIVO, GRP_DT_CRIACAO, GRP_PAPEL1, GRP_PAPEL2, GRP_PAPEL3, GRP_PAPEL4, GRP_PAPEL5, GRP_ID_INTEGRACAO, GRP_ID_INTEGRACAO_ERP, GRP_TYPE, GRP_PERFORMANCE, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, GRP_RESINA, GRP_ENDURECEDOR_MIOLO, VIN_ID, GRP_COLUNA_DE, GRP_COLUNA_ATE, GRP_CRUSH, GRP_ID_FAMILIA, GRP_REFILE_LARGURA, GRP_REFILE_COMPRIMENTO, GRP_TIPO_LAP, GRP_LAP_PROLONGADO, GRP_TAMANHO_LAP_OND_SIMPLES, GRP_TAMANHO_LAP_OND_DUPLA, GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, GRP_FEFCO, GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, GRP_PREFIXO_ID_PRODUTO, GRP_COLUNA_CAIXA, GRP_COLUNA_CHAPA, GRP_MULLEN, GRP_TENDENCIA_TOLERANCIA_PEDIDO, GRP_PERCENTUAL_PERDA_MEDIA, GRP_FILTRA_SEQ_TRANS, GRP_IMG_CAIXA, TenantID, Deleted, Changed, UserId FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_ID_FAMILIA"] = value; //06
                      whereClauses.Add($" GRP_ID_FAMILIA = @GRP_ID_FAMILIA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRP_REFILE_LARGURAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT GRP_ID, GRP_DESCRICAO, TEM_ID, GRP_TIPO, GRP_PAP_ONDA, GRP_PAP_GRAMATURA, GRP_PAP_ALTURA, GRP_PAP_NOME_COMERCIAL, GRP_ATIVO, GRP_DT_CRIACAO, GRP_PAPEL1, GRP_PAPEL2, GRP_PAPEL3, GRP_PAPEL4, GRP_PAPEL5, GRP_ID_INTEGRACAO, GRP_ID_INTEGRACAO_ERP, GRP_TYPE, GRP_PERFORMANCE, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, GRP_RESINA, GRP_ENDURECEDOR_MIOLO, VIN_ID, GRP_COLUNA_DE, GRP_COLUNA_ATE, GRP_CRUSH, GRP_ID_FAMILIA, GRP_REFILE_LARGURA, GRP_REFILE_COMPRIMENTO, GRP_TIPO_LAP, GRP_LAP_PROLONGADO, GRP_TAMANHO_LAP_OND_SIMPLES, GRP_TAMANHO_LAP_OND_DUPLA, GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, GRP_FEFCO, GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, GRP_PREFIXO_ID_PRODUTO, GRP_COLUNA_CAIXA, GRP_COLUNA_CHAPA, GRP_MULLEN, GRP_TENDENCIA_TOLERANCIA_PEDIDO, GRP_PERCENTUAL_PERDA_MEDIA, GRP_FILTRA_SEQ_TRANS, GRP_IMG_CAIXA, TenantID, Deleted, Changed, UserId FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_REFILE_LARGURA"] = value; //06
                      whereClauses.Add($" GRP_REFILE_LARGURA = @GRP_REFILE_LARGURA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRP_REFILE_COMPRIMENTOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT GRP_ID, GRP_DESCRICAO, TEM_ID, GRP_TIPO, GRP_PAP_ONDA, GRP_PAP_GRAMATURA, GRP_PAP_ALTURA, GRP_PAP_NOME_COMERCIAL, GRP_ATIVO, GRP_DT_CRIACAO, GRP_PAPEL1, GRP_PAPEL2, GRP_PAPEL3, GRP_PAPEL4, GRP_PAPEL5, GRP_ID_INTEGRACAO, GRP_ID_INTEGRACAO_ERP, GRP_TYPE, GRP_PERFORMANCE, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, GRP_RESINA, GRP_ENDURECEDOR_MIOLO, VIN_ID, GRP_COLUNA_DE, GRP_COLUNA_ATE, GRP_CRUSH, GRP_ID_FAMILIA, GRP_REFILE_LARGURA, GRP_REFILE_COMPRIMENTO, GRP_TIPO_LAP, GRP_LAP_PROLONGADO, GRP_TAMANHO_LAP_OND_SIMPLES, GRP_TAMANHO_LAP_OND_DUPLA, GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, GRP_FEFCO, GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, GRP_PREFIXO_ID_PRODUTO, GRP_COLUNA_CAIXA, GRP_COLUNA_CHAPA, GRP_MULLEN, GRP_TENDENCIA_TOLERANCIA_PEDIDO, GRP_PERCENTUAL_PERDA_MEDIA, GRP_FILTRA_SEQ_TRANS, GRP_IMG_CAIXA, TenantID, Deleted, Changed, UserId FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_REFILE_COMPRIMENTO"] = value; //06
                      whereClauses.Add($" GRP_REFILE_COMPRIMENTO = @GRP_REFILE_COMPRIMENTO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRP_TIPO_LAPQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT GRP_ID, GRP_DESCRICAO, TEM_ID, GRP_TIPO, GRP_PAP_ONDA, GRP_PAP_GRAMATURA, GRP_PAP_ALTURA, GRP_PAP_NOME_COMERCIAL, GRP_ATIVO, GRP_DT_CRIACAO, GRP_PAPEL1, GRP_PAPEL2, GRP_PAPEL3, GRP_PAPEL4, GRP_PAPEL5, GRP_ID_INTEGRACAO, GRP_ID_INTEGRACAO_ERP, GRP_TYPE, GRP_PERFORMANCE, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, GRP_RESINA, GRP_ENDURECEDOR_MIOLO, VIN_ID, GRP_COLUNA_DE, GRP_COLUNA_ATE, GRP_CRUSH, GRP_ID_FAMILIA, GRP_REFILE_LARGURA, GRP_REFILE_COMPRIMENTO, GRP_TIPO_LAP, GRP_LAP_PROLONGADO, GRP_TAMANHO_LAP_OND_SIMPLES, GRP_TAMANHO_LAP_OND_DUPLA, GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, GRP_FEFCO, GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, GRP_PREFIXO_ID_PRODUTO, GRP_COLUNA_CAIXA, GRP_COLUNA_CHAPA, GRP_MULLEN, GRP_TENDENCIA_TOLERANCIA_PEDIDO, GRP_PERCENTUAL_PERDA_MEDIA, GRP_FILTRA_SEQ_TRANS, GRP_IMG_CAIXA, TenantID, Deleted, Changed, UserId FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_TIPO_LAP"] = value; //06
                      whereClauses.Add($" GRP_TIPO_LAP = @GRP_TIPO_LAP ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRP_LAP_PROLONGADOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT GRP_ID, GRP_DESCRICAO, TEM_ID, GRP_TIPO, GRP_PAP_ONDA, GRP_PAP_GRAMATURA, GRP_PAP_ALTURA, GRP_PAP_NOME_COMERCIAL, GRP_ATIVO, GRP_DT_CRIACAO, GRP_PAPEL1, GRP_PAPEL2, GRP_PAPEL3, GRP_PAPEL4, GRP_PAPEL5, GRP_ID_INTEGRACAO, GRP_ID_INTEGRACAO_ERP, GRP_TYPE, GRP_PERFORMANCE, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, GRP_RESINA, GRP_ENDURECEDOR_MIOLO, VIN_ID, GRP_COLUNA_DE, GRP_COLUNA_ATE, GRP_CRUSH, GRP_ID_FAMILIA, GRP_REFILE_LARGURA, GRP_REFILE_COMPRIMENTO, GRP_TIPO_LAP, GRP_LAP_PROLONGADO, GRP_TAMANHO_LAP_OND_SIMPLES, GRP_TAMANHO_LAP_OND_DUPLA, GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, GRP_FEFCO, GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, GRP_PREFIXO_ID_PRODUTO, GRP_COLUNA_CAIXA, GRP_COLUNA_CHAPA, GRP_MULLEN, GRP_TENDENCIA_TOLERANCIA_PEDIDO, GRP_PERCENTUAL_PERDA_MEDIA, GRP_FILTRA_SEQ_TRANS, GRP_IMG_CAIXA, TenantID, Deleted, Changed, UserId FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_LAP_PROLONGADO"] = value; //06
                      whereClauses.Add($" GRP_LAP_PROLONGADO = @GRP_LAP_PROLONGADO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRP_TAMANHO_LAP_OND_SIMPLESQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT GRP_ID, GRP_DESCRICAO, TEM_ID, GRP_TIPO, GRP_PAP_ONDA, GRP_PAP_GRAMATURA, GRP_PAP_ALTURA, GRP_PAP_NOME_COMERCIAL, GRP_ATIVO, GRP_DT_CRIACAO, GRP_PAPEL1, GRP_PAPEL2, GRP_PAPEL3, GRP_PAPEL4, GRP_PAPEL5, GRP_ID_INTEGRACAO, GRP_ID_INTEGRACAO_ERP, GRP_TYPE, GRP_PERFORMANCE, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, GRP_RESINA, GRP_ENDURECEDOR_MIOLO, VIN_ID, GRP_COLUNA_DE, GRP_COLUNA_ATE, GRP_CRUSH, GRP_ID_FAMILIA, GRP_REFILE_LARGURA, GRP_REFILE_COMPRIMENTO, GRP_TIPO_LAP, GRP_LAP_PROLONGADO, GRP_TAMANHO_LAP_OND_SIMPLES, GRP_TAMANHO_LAP_OND_DUPLA, GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, GRP_FEFCO, GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, GRP_PREFIXO_ID_PRODUTO, GRP_COLUNA_CAIXA, GRP_COLUNA_CHAPA, GRP_MULLEN, GRP_TENDENCIA_TOLERANCIA_PEDIDO, GRP_PERCENTUAL_PERDA_MEDIA, GRP_FILTRA_SEQ_TRANS, GRP_IMG_CAIXA, TenantID, Deleted, Changed, UserId FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_TAMANHO_LAP_OND_SIMPLES"] = value; //06
                      whereClauses.Add($" GRP_TAMANHO_LAP_OND_SIMPLES = @GRP_TAMANHO_LAP_OND_SIMPLES ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRP_TAMANHO_LAP_OND_DUPLAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT GRP_ID, GRP_DESCRICAO, TEM_ID, GRP_TIPO, GRP_PAP_ONDA, GRP_PAP_GRAMATURA, GRP_PAP_ALTURA, GRP_PAP_NOME_COMERCIAL, GRP_ATIVO, GRP_DT_CRIACAO, GRP_PAPEL1, GRP_PAPEL2, GRP_PAPEL3, GRP_PAPEL4, GRP_PAPEL5, GRP_ID_INTEGRACAO, GRP_ID_INTEGRACAO_ERP, GRP_TYPE, GRP_PERFORMANCE, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, GRP_RESINA, GRP_ENDURECEDOR_MIOLO, VIN_ID, GRP_COLUNA_DE, GRP_COLUNA_ATE, GRP_CRUSH, GRP_ID_FAMILIA, GRP_REFILE_LARGURA, GRP_REFILE_COMPRIMENTO, GRP_TIPO_LAP, GRP_LAP_PROLONGADO, GRP_TAMANHO_LAP_OND_SIMPLES, GRP_TAMANHO_LAP_OND_DUPLA, GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, GRP_FEFCO, GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, GRP_PREFIXO_ID_PRODUTO, GRP_COLUNA_CAIXA, GRP_COLUNA_CHAPA, GRP_MULLEN, GRP_TENDENCIA_TOLERANCIA_PEDIDO, GRP_PERCENTUAL_PERDA_MEDIA, GRP_FILTRA_SEQ_TRANS, GRP_IMG_CAIXA, TenantID, Deleted, Changed, UserId FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_TAMANHO_LAP_OND_DUPLA"] = value; //06
                      whereClauses.Add($" GRP_TAMANHO_LAP_OND_DUPLA = @GRP_TAMANHO_LAP_OND_DUPLA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLESQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT GRP_ID, GRP_DESCRICAO, TEM_ID, GRP_TIPO, GRP_PAP_ONDA, GRP_PAP_GRAMATURA, GRP_PAP_ALTURA, GRP_PAP_NOME_COMERCIAL, GRP_ATIVO, GRP_DT_CRIACAO, GRP_PAPEL1, GRP_PAPEL2, GRP_PAPEL3, GRP_PAPEL4, GRP_PAPEL5, GRP_ID_INTEGRACAO, GRP_ID_INTEGRACAO_ERP, GRP_TYPE, GRP_PERFORMANCE, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, GRP_RESINA, GRP_ENDURECEDOR_MIOLO, VIN_ID, GRP_COLUNA_DE, GRP_COLUNA_ATE, GRP_CRUSH, GRP_ID_FAMILIA, GRP_REFILE_LARGURA, GRP_REFILE_COMPRIMENTO, GRP_TIPO_LAP, GRP_LAP_PROLONGADO, GRP_TAMANHO_LAP_OND_SIMPLES, GRP_TAMANHO_LAP_OND_DUPLA, GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, GRP_FEFCO, GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, GRP_PREFIXO_ID_PRODUTO, GRP_COLUNA_CAIXA, GRP_COLUNA_CHAPA, GRP_MULLEN, GRP_TENDENCIA_TOLERANCIA_PEDIDO, GRP_PERCENTUAL_PERDA_MEDIA, GRP_FILTRA_SEQ_TRANS, GRP_IMG_CAIXA, TenantID, Deleted, Changed, UserId FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES"] = value; //06
                      whereClauses.Add($" GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES = @GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRP_TAMANHO_LAP_PROLONGADO_OND_DUPLAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT GRP_ID, GRP_DESCRICAO, TEM_ID, GRP_TIPO, GRP_PAP_ONDA, GRP_PAP_GRAMATURA, GRP_PAP_ALTURA, GRP_PAP_NOME_COMERCIAL, GRP_ATIVO, GRP_DT_CRIACAO, GRP_PAPEL1, GRP_PAPEL2, GRP_PAPEL3, GRP_PAPEL4, GRP_PAPEL5, GRP_ID_INTEGRACAO, GRP_ID_INTEGRACAO_ERP, GRP_TYPE, GRP_PERFORMANCE, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, GRP_RESINA, GRP_ENDURECEDOR_MIOLO, VIN_ID, GRP_COLUNA_DE, GRP_COLUNA_ATE, GRP_CRUSH, GRP_ID_FAMILIA, GRP_REFILE_LARGURA, GRP_REFILE_COMPRIMENTO, GRP_TIPO_LAP, GRP_LAP_PROLONGADO, GRP_TAMANHO_LAP_OND_SIMPLES, GRP_TAMANHO_LAP_OND_DUPLA, GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, GRP_FEFCO, GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, GRP_PREFIXO_ID_PRODUTO, GRP_COLUNA_CAIXA, GRP_COLUNA_CHAPA, GRP_MULLEN, GRP_TENDENCIA_TOLERANCIA_PEDIDO, GRP_PERCENTUAL_PERDA_MEDIA, GRP_FILTRA_SEQ_TRANS, GRP_IMG_CAIXA, TenantID, Deleted, Changed, UserId FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA"] = value; //06
                      whereClauses.Add($" GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA = @GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRP_FEFCOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT GRP_ID, GRP_DESCRICAO, TEM_ID, GRP_TIPO, GRP_PAP_ONDA, GRP_PAP_GRAMATURA, GRP_PAP_ALTURA, GRP_PAP_NOME_COMERCIAL, GRP_ATIVO, GRP_DT_CRIACAO, GRP_PAPEL1, GRP_PAPEL2, GRP_PAPEL3, GRP_PAPEL4, GRP_PAPEL5, GRP_ID_INTEGRACAO, GRP_ID_INTEGRACAO_ERP, GRP_TYPE, GRP_PERFORMANCE, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, GRP_RESINA, GRP_ENDURECEDOR_MIOLO, VIN_ID, GRP_COLUNA_DE, GRP_COLUNA_ATE, GRP_CRUSH, GRP_ID_FAMILIA, GRP_REFILE_LARGURA, GRP_REFILE_COMPRIMENTO, GRP_TIPO_LAP, GRP_LAP_PROLONGADO, GRP_TAMANHO_LAP_OND_SIMPLES, GRP_TAMANHO_LAP_OND_DUPLA, GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, GRP_FEFCO, GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, GRP_PREFIXO_ID_PRODUTO, GRP_COLUNA_CAIXA, GRP_COLUNA_CHAPA, GRP_MULLEN, GRP_TENDENCIA_TOLERANCIA_PEDIDO, GRP_PERCENTUAL_PERDA_MEDIA, GRP_FILTRA_SEQ_TRANS, GRP_IMG_CAIXA, TenantID, Deleted, Changed, UserId FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_FEFCO"] = value; //06
                      whereClauses.Add($" GRP_FEFCO = @GRP_FEFCO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRP_TOLERANCIA_DIMENCAO_CHAPA_DEQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT GRP_ID, GRP_DESCRICAO, TEM_ID, GRP_TIPO, GRP_PAP_ONDA, GRP_PAP_GRAMATURA, GRP_PAP_ALTURA, GRP_PAP_NOME_COMERCIAL, GRP_ATIVO, GRP_DT_CRIACAO, GRP_PAPEL1, GRP_PAPEL2, GRP_PAPEL3, GRP_PAPEL4, GRP_PAPEL5, GRP_ID_INTEGRACAO, GRP_ID_INTEGRACAO_ERP, GRP_TYPE, GRP_PERFORMANCE, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, GRP_RESINA, GRP_ENDURECEDOR_MIOLO, VIN_ID, GRP_COLUNA_DE, GRP_COLUNA_ATE, GRP_CRUSH, GRP_ID_FAMILIA, GRP_REFILE_LARGURA, GRP_REFILE_COMPRIMENTO, GRP_TIPO_LAP, GRP_LAP_PROLONGADO, GRP_TAMANHO_LAP_OND_SIMPLES, GRP_TAMANHO_LAP_OND_DUPLA, GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, GRP_FEFCO, GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, GRP_PREFIXO_ID_PRODUTO, GRP_COLUNA_CAIXA, GRP_COLUNA_CHAPA, GRP_MULLEN, GRP_TENDENCIA_TOLERANCIA_PEDIDO, GRP_PERCENTUAL_PERDA_MEDIA, GRP_FILTRA_SEQ_TRANS, GRP_IMG_CAIXA, TenantID, Deleted, Changed, UserId FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_TOLERANCIA_DIMENCAO_CHAPA_DE"] = value; //06
                      whereClauses.Add($" GRP_TOLERANCIA_DIMENCAO_CHAPA_DE = @GRP_TOLERANCIA_DIMENCAO_CHAPA_DE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRP_TOLERANCIA_DIMENCAO_CHAPA_ATEQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT GRP_ID, GRP_DESCRICAO, TEM_ID, GRP_TIPO, GRP_PAP_ONDA, GRP_PAP_GRAMATURA, GRP_PAP_ALTURA, GRP_PAP_NOME_COMERCIAL, GRP_ATIVO, GRP_DT_CRIACAO, GRP_PAPEL1, GRP_PAPEL2, GRP_PAPEL3, GRP_PAPEL4, GRP_PAPEL5, GRP_ID_INTEGRACAO, GRP_ID_INTEGRACAO_ERP, GRP_TYPE, GRP_PERFORMANCE, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, GRP_RESINA, GRP_ENDURECEDOR_MIOLO, VIN_ID, GRP_COLUNA_DE, GRP_COLUNA_ATE, GRP_CRUSH, GRP_ID_FAMILIA, GRP_REFILE_LARGURA, GRP_REFILE_COMPRIMENTO, GRP_TIPO_LAP, GRP_LAP_PROLONGADO, GRP_TAMANHO_LAP_OND_SIMPLES, GRP_TAMANHO_LAP_OND_DUPLA, GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, GRP_FEFCO, GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, GRP_PREFIXO_ID_PRODUTO, GRP_COLUNA_CAIXA, GRP_COLUNA_CHAPA, GRP_MULLEN, GRP_TENDENCIA_TOLERANCIA_PEDIDO, GRP_PERCENTUAL_PERDA_MEDIA, GRP_FILTRA_SEQ_TRANS, GRP_IMG_CAIXA, TenantID, Deleted, Changed, UserId FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE"] = value; //06
                      whereClauses.Add($" GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE = @GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRP_PREFIXO_ID_PRODUTOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT GRP_ID, GRP_DESCRICAO, TEM_ID, GRP_TIPO, GRP_PAP_ONDA, GRP_PAP_GRAMATURA, GRP_PAP_ALTURA, GRP_PAP_NOME_COMERCIAL, GRP_ATIVO, GRP_DT_CRIACAO, GRP_PAPEL1, GRP_PAPEL2, GRP_PAPEL3, GRP_PAPEL4, GRP_PAPEL5, GRP_ID_INTEGRACAO, GRP_ID_INTEGRACAO_ERP, GRP_TYPE, GRP_PERFORMANCE, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, GRP_RESINA, GRP_ENDURECEDOR_MIOLO, VIN_ID, GRP_COLUNA_DE, GRP_COLUNA_ATE, GRP_CRUSH, GRP_ID_FAMILIA, GRP_REFILE_LARGURA, GRP_REFILE_COMPRIMENTO, GRP_TIPO_LAP, GRP_LAP_PROLONGADO, GRP_TAMANHO_LAP_OND_SIMPLES, GRP_TAMANHO_LAP_OND_DUPLA, GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, GRP_FEFCO, GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, GRP_PREFIXO_ID_PRODUTO, GRP_COLUNA_CAIXA, GRP_COLUNA_CHAPA, GRP_MULLEN, GRP_TENDENCIA_TOLERANCIA_PEDIDO, GRP_PERCENTUAL_PERDA_MEDIA, GRP_FILTRA_SEQ_TRANS, GRP_IMG_CAIXA, TenantID, Deleted, Changed, UserId FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_PREFIXO_ID_PRODUTO"] = value; //06
                      whereClauses.Add($" GRP_PREFIXO_ID_PRODUTO = @GRP_PREFIXO_ID_PRODUTO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRP_COLUNA_CAIXAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT GRP_ID, GRP_DESCRICAO, TEM_ID, GRP_TIPO, GRP_PAP_ONDA, GRP_PAP_GRAMATURA, GRP_PAP_ALTURA, GRP_PAP_NOME_COMERCIAL, GRP_ATIVO, GRP_DT_CRIACAO, GRP_PAPEL1, GRP_PAPEL2, GRP_PAPEL3, GRP_PAPEL4, GRP_PAPEL5, GRP_ID_INTEGRACAO, GRP_ID_INTEGRACAO_ERP, GRP_TYPE, GRP_PERFORMANCE, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, GRP_RESINA, GRP_ENDURECEDOR_MIOLO, VIN_ID, GRP_COLUNA_DE, GRP_COLUNA_ATE, GRP_CRUSH, GRP_ID_FAMILIA, GRP_REFILE_LARGURA, GRP_REFILE_COMPRIMENTO, GRP_TIPO_LAP, GRP_LAP_PROLONGADO, GRP_TAMANHO_LAP_OND_SIMPLES, GRP_TAMANHO_LAP_OND_DUPLA, GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, GRP_FEFCO, GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, GRP_PREFIXO_ID_PRODUTO, GRP_COLUNA_CAIXA, GRP_COLUNA_CHAPA, GRP_MULLEN, GRP_TENDENCIA_TOLERANCIA_PEDIDO, GRP_PERCENTUAL_PERDA_MEDIA, GRP_FILTRA_SEQ_TRANS, GRP_IMG_CAIXA, TenantID, Deleted, Changed, UserId FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_COLUNA_CAIXA"] = value; //06
                      whereClauses.Add($" GRP_COLUNA_CAIXA = @GRP_COLUNA_CAIXA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRP_COLUNA_CHAPAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT GRP_ID, GRP_DESCRICAO, TEM_ID, GRP_TIPO, GRP_PAP_ONDA, GRP_PAP_GRAMATURA, GRP_PAP_ALTURA, GRP_PAP_NOME_COMERCIAL, GRP_ATIVO, GRP_DT_CRIACAO, GRP_PAPEL1, GRP_PAPEL2, GRP_PAPEL3, GRP_PAPEL4, GRP_PAPEL5, GRP_ID_INTEGRACAO, GRP_ID_INTEGRACAO_ERP, GRP_TYPE, GRP_PERFORMANCE, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, GRP_RESINA, GRP_ENDURECEDOR_MIOLO, VIN_ID, GRP_COLUNA_DE, GRP_COLUNA_ATE, GRP_CRUSH, GRP_ID_FAMILIA, GRP_REFILE_LARGURA, GRP_REFILE_COMPRIMENTO, GRP_TIPO_LAP, GRP_LAP_PROLONGADO, GRP_TAMANHO_LAP_OND_SIMPLES, GRP_TAMANHO_LAP_OND_DUPLA, GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, GRP_FEFCO, GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, GRP_PREFIXO_ID_PRODUTO, GRP_COLUNA_CAIXA, GRP_COLUNA_CHAPA, GRP_MULLEN, GRP_TENDENCIA_TOLERANCIA_PEDIDO, GRP_PERCENTUAL_PERDA_MEDIA, GRP_FILTRA_SEQ_TRANS, GRP_IMG_CAIXA, TenantID, Deleted, Changed, UserId FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_COLUNA_CHAPA"] = value; //06
                      whereClauses.Add($" GRP_COLUNA_CHAPA = @GRP_COLUNA_CHAPA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRP_MULLENQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT GRP_ID, GRP_DESCRICAO, TEM_ID, GRP_TIPO, GRP_PAP_ONDA, GRP_PAP_GRAMATURA, GRP_PAP_ALTURA, GRP_PAP_NOME_COMERCIAL, GRP_ATIVO, GRP_DT_CRIACAO, GRP_PAPEL1, GRP_PAPEL2, GRP_PAPEL3, GRP_PAPEL4, GRP_PAPEL5, GRP_ID_INTEGRACAO, GRP_ID_INTEGRACAO_ERP, GRP_TYPE, GRP_PERFORMANCE, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, GRP_RESINA, GRP_ENDURECEDOR_MIOLO, VIN_ID, GRP_COLUNA_DE, GRP_COLUNA_ATE, GRP_CRUSH, GRP_ID_FAMILIA, GRP_REFILE_LARGURA, GRP_REFILE_COMPRIMENTO, GRP_TIPO_LAP, GRP_LAP_PROLONGADO, GRP_TAMANHO_LAP_OND_SIMPLES, GRP_TAMANHO_LAP_OND_DUPLA, GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, GRP_FEFCO, GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, GRP_PREFIXO_ID_PRODUTO, GRP_COLUNA_CAIXA, GRP_COLUNA_CHAPA, GRP_MULLEN, GRP_TENDENCIA_TOLERANCIA_PEDIDO, GRP_PERCENTUAL_PERDA_MEDIA, GRP_FILTRA_SEQ_TRANS, GRP_IMG_CAIXA, TenantID, Deleted, Changed, UserId FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_MULLEN"] = value; //06
                      whereClauses.Add($" GRP_MULLEN = @GRP_MULLEN ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRP_TENDENCIA_TOLERANCIA_PEDIDOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT GRP_ID, GRP_DESCRICAO, TEM_ID, GRP_TIPO, GRP_PAP_ONDA, GRP_PAP_GRAMATURA, GRP_PAP_ALTURA, GRP_PAP_NOME_COMERCIAL, GRP_ATIVO, GRP_DT_CRIACAO, GRP_PAPEL1, GRP_PAPEL2, GRP_PAPEL3, GRP_PAPEL4, GRP_PAPEL5, GRP_ID_INTEGRACAO, GRP_ID_INTEGRACAO_ERP, GRP_TYPE, GRP_PERFORMANCE, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, GRP_RESINA, GRP_ENDURECEDOR_MIOLO, VIN_ID, GRP_COLUNA_DE, GRP_COLUNA_ATE, GRP_CRUSH, GRP_ID_FAMILIA, GRP_REFILE_LARGURA, GRP_REFILE_COMPRIMENTO, GRP_TIPO_LAP, GRP_LAP_PROLONGADO, GRP_TAMANHO_LAP_OND_SIMPLES, GRP_TAMANHO_LAP_OND_DUPLA, GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, GRP_FEFCO, GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, GRP_PREFIXO_ID_PRODUTO, GRP_COLUNA_CAIXA, GRP_COLUNA_CHAPA, GRP_MULLEN, GRP_TENDENCIA_TOLERANCIA_PEDIDO, GRP_PERCENTUAL_PERDA_MEDIA, GRP_FILTRA_SEQ_TRANS, GRP_IMG_CAIXA, TenantID, Deleted, Changed, UserId FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_TENDENCIA_TOLERANCIA_PEDIDO"] = value; //06
                      whereClauses.Add($" GRP_TENDENCIA_TOLERANCIA_PEDIDO = @GRP_TENDENCIA_TOLERANCIA_PEDIDO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRP_PERCENTUAL_PERDA_MEDIAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT GRP_ID, GRP_DESCRICAO, TEM_ID, GRP_TIPO, GRP_PAP_ONDA, GRP_PAP_GRAMATURA, GRP_PAP_ALTURA, GRP_PAP_NOME_COMERCIAL, GRP_ATIVO, GRP_DT_CRIACAO, GRP_PAPEL1, GRP_PAPEL2, GRP_PAPEL3, GRP_PAPEL4, GRP_PAPEL5, GRP_ID_INTEGRACAO, GRP_ID_INTEGRACAO_ERP, GRP_TYPE, GRP_PERFORMANCE, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, GRP_RESINA, GRP_ENDURECEDOR_MIOLO, VIN_ID, GRP_COLUNA_DE, GRP_COLUNA_ATE, GRP_CRUSH, GRP_ID_FAMILIA, GRP_REFILE_LARGURA, GRP_REFILE_COMPRIMENTO, GRP_TIPO_LAP, GRP_LAP_PROLONGADO, GRP_TAMANHO_LAP_OND_SIMPLES, GRP_TAMANHO_LAP_OND_DUPLA, GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, GRP_FEFCO, GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, GRP_PREFIXO_ID_PRODUTO, GRP_COLUNA_CAIXA, GRP_COLUNA_CHAPA, GRP_MULLEN, GRP_TENDENCIA_TOLERANCIA_PEDIDO, GRP_PERCENTUAL_PERDA_MEDIA, GRP_FILTRA_SEQ_TRANS, GRP_IMG_CAIXA, TenantID, Deleted, Changed, UserId FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_PERCENTUAL_PERDA_MEDIA"] = value; //06
                      whereClauses.Add($" GRP_PERCENTUAL_PERDA_MEDIA = @GRP_PERCENTUAL_PERDA_MEDIA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRP_FILTRA_SEQ_TRANSQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT GRP_ID, GRP_DESCRICAO, TEM_ID, GRP_TIPO, GRP_PAP_ONDA, GRP_PAP_GRAMATURA, GRP_PAP_ALTURA, GRP_PAP_NOME_COMERCIAL, GRP_ATIVO, GRP_DT_CRIACAO, GRP_PAPEL1, GRP_PAPEL2, GRP_PAPEL3, GRP_PAPEL4, GRP_PAPEL5, GRP_ID_INTEGRACAO, GRP_ID_INTEGRACAO_ERP, GRP_TYPE, GRP_PERFORMANCE, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, GRP_RESINA, GRP_ENDURECEDOR_MIOLO, VIN_ID, GRP_COLUNA_DE, GRP_COLUNA_ATE, GRP_CRUSH, GRP_ID_FAMILIA, GRP_REFILE_LARGURA, GRP_REFILE_COMPRIMENTO, GRP_TIPO_LAP, GRP_LAP_PROLONGADO, GRP_TAMANHO_LAP_OND_SIMPLES, GRP_TAMANHO_LAP_OND_DUPLA, GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, GRP_FEFCO, GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, GRP_PREFIXO_ID_PRODUTO, GRP_COLUNA_CAIXA, GRP_COLUNA_CHAPA, GRP_MULLEN, GRP_TENDENCIA_TOLERANCIA_PEDIDO, GRP_PERCENTUAL_PERDA_MEDIA, GRP_FILTRA_SEQ_TRANS, GRP_IMG_CAIXA, TenantID, Deleted, Changed, UserId FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_FILTRA_SEQ_TRANS"] = value; //06
                      whereClauses.Add($" GRP_FILTRA_SEQ_TRANS = @GRP_FILTRA_SEQ_TRANS ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGRP_IMG_CAIXAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT GRP_ID, GRP_DESCRICAO, TEM_ID, GRP_TIPO, GRP_PAP_ONDA, GRP_PAP_GRAMATURA, GRP_PAP_ALTURA, GRP_PAP_NOME_COMERCIAL, GRP_ATIVO, GRP_DT_CRIACAO, GRP_PAPEL1, GRP_PAPEL2, GRP_PAPEL3, GRP_PAPEL4, GRP_PAPEL5, GRP_ID_INTEGRACAO, GRP_ID_INTEGRACAO_ERP, GRP_TYPE, GRP_PERFORMANCE, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, GRP_RESINA, GRP_ENDURECEDOR_MIOLO, VIN_ID, GRP_COLUNA_DE, GRP_COLUNA_ATE, GRP_CRUSH, GRP_ID_FAMILIA, GRP_REFILE_LARGURA, GRP_REFILE_COMPRIMENTO, GRP_TIPO_LAP, GRP_LAP_PROLONGADO, GRP_TAMANHO_LAP_OND_SIMPLES, GRP_TAMANHO_LAP_OND_DUPLA, GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, GRP_FEFCO, GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, GRP_PREFIXO_ID_PRODUTO, GRP_COLUNA_CAIXA, GRP_COLUNA_CHAPA, GRP_MULLEN, GRP_TENDENCIA_TOLERANCIA_PEDIDO, GRP_PERCENTUAL_PERDA_MEDIA, GRP_FILTRA_SEQ_TRANS, GRP_IMG_CAIXA, TenantID, Deleted, Changed, UserId FROM GrupoProdutoAbstrato ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["GRP_IMG_CAIXA"] = value; //06
                      whereClauses.Add($" GRP_IMG_CAIXA = @GRP_IMG_CAIXA ");//06
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
            this.Query = $"SELECT GRP_ID, GRP_DESCRICAO, TEM_ID, GRP_TIPO, GRP_PAP_ONDA, GRP_PAP_GRAMATURA, GRP_PAP_ALTURA, GRP_PAP_NOME_COMERCIAL, GRP_ATIVO, GRP_DT_CRIACAO, GRP_PAPEL1, GRP_PAPEL2, GRP_PAPEL3, GRP_PAPEL4, GRP_PAPEL5, GRP_ID_INTEGRACAO, GRP_ID_INTEGRACAO_ERP, GRP_TYPE, GRP_PERFORMANCE, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, GRP_RESINA, GRP_ENDURECEDOR_MIOLO, VIN_ID, GRP_COLUNA_DE, GRP_COLUNA_ATE, GRP_CRUSH, GRP_ID_FAMILIA, GRP_REFILE_LARGURA, GRP_REFILE_COMPRIMENTO, GRP_TIPO_LAP, GRP_LAP_PROLONGADO, GRP_TAMANHO_LAP_OND_SIMPLES, GRP_TAMANHO_LAP_OND_DUPLA, GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, GRP_FEFCO, GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, GRP_PREFIXO_ID_PRODUTO, GRP_COLUNA_CAIXA, GRP_COLUNA_CHAPA, GRP_MULLEN, GRP_TENDENCIA_TOLERANCIA_PEDIDO, GRP_PERCENTUAL_PERDA_MEDIA, GRP_FILTRA_SEQ_TRANS, GRP_IMG_CAIXA, TenantID, Deleted, Changed, UserId FROM GrupoProdutoAbstrato ";
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
            this.Query = $"SELECT GRP_ID, GRP_DESCRICAO, TEM_ID, GRP_TIPO, GRP_PAP_ONDA, GRP_PAP_GRAMATURA, GRP_PAP_ALTURA, GRP_PAP_NOME_COMERCIAL, GRP_ATIVO, GRP_DT_CRIACAO, GRP_PAPEL1, GRP_PAPEL2, GRP_PAPEL3, GRP_PAPEL4, GRP_PAPEL5, GRP_ID_INTEGRACAO, GRP_ID_INTEGRACAO_ERP, GRP_TYPE, GRP_PERFORMANCE, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, GRP_RESINA, GRP_ENDURECEDOR_MIOLO, VIN_ID, GRP_COLUNA_DE, GRP_COLUNA_ATE, GRP_CRUSH, GRP_ID_FAMILIA, GRP_REFILE_LARGURA, GRP_REFILE_COMPRIMENTO, GRP_TIPO_LAP, GRP_LAP_PROLONGADO, GRP_TAMANHO_LAP_OND_SIMPLES, GRP_TAMANHO_LAP_OND_DUPLA, GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, GRP_FEFCO, GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, GRP_PREFIXO_ID_PRODUTO, GRP_COLUNA_CAIXA, GRP_COLUNA_CHAPA, GRP_MULLEN, GRP_TENDENCIA_TOLERANCIA_PEDIDO, GRP_PERCENTUAL_PERDA_MEDIA, GRP_FILTRA_SEQ_TRANS, GRP_IMG_CAIXA, TenantID, Deleted, Changed, UserId FROM GrupoProdutoAbstrato ";
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
            this.Query = $"SELECT GRP_ID, GRP_DESCRICAO, TEM_ID, GRP_TIPO, GRP_PAP_ONDA, GRP_PAP_GRAMATURA, GRP_PAP_ALTURA, GRP_PAP_NOME_COMERCIAL, GRP_ATIVO, GRP_DT_CRIACAO, GRP_PAPEL1, GRP_PAPEL2, GRP_PAPEL3, GRP_PAPEL4, GRP_PAPEL5, GRP_ID_INTEGRACAO, GRP_ID_INTEGRACAO_ERP, GRP_TYPE, GRP_PERFORMANCE, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, GRP_RESINA, GRP_ENDURECEDOR_MIOLO, VIN_ID, GRP_COLUNA_DE, GRP_COLUNA_ATE, GRP_CRUSH, GRP_ID_FAMILIA, GRP_REFILE_LARGURA, GRP_REFILE_COMPRIMENTO, GRP_TIPO_LAP, GRP_LAP_PROLONGADO, GRP_TAMANHO_LAP_OND_SIMPLES, GRP_TAMANHO_LAP_OND_DUPLA, GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, GRP_FEFCO, GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, GRP_PREFIXO_ID_PRODUTO, GRP_COLUNA_CAIXA, GRP_COLUNA_CHAPA, GRP_MULLEN, GRP_TENDENCIA_TOLERANCIA_PEDIDO, GRP_PERCENTUAL_PERDA_MEDIA, GRP_FILTRA_SEQ_TRANS, GRP_IMG_CAIXA, TenantID, Deleted, Changed, UserId FROM GrupoProdutoAbstrato ";
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
            this.Query = $"SELECT GRP_ID, GRP_DESCRICAO, TEM_ID, GRP_TIPO, GRP_PAP_ONDA, GRP_PAP_GRAMATURA, GRP_PAP_ALTURA, GRP_PAP_NOME_COMERCIAL, GRP_ATIVO, GRP_DT_CRIACAO, GRP_PAPEL1, GRP_PAPEL2, GRP_PAPEL3, GRP_PAPEL4, GRP_PAPEL5, GRP_ID_INTEGRACAO, GRP_ID_INTEGRACAO_ERP, GRP_TYPE, GRP_PERFORMANCE, GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO, GRP_RESINA, GRP_ENDURECEDOR_MIOLO, VIN_ID, GRP_COLUNA_DE, GRP_COLUNA_ATE, GRP_CRUSH, GRP_ID_FAMILIA, GRP_REFILE_LARGURA, GRP_REFILE_COMPRIMENTO, GRP_TIPO_LAP, GRP_LAP_PROLONGADO, GRP_TAMANHO_LAP_OND_SIMPLES, GRP_TAMANHO_LAP_OND_DUPLA, GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES, GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA, GRP_FEFCO, GRP_TOLERANCIA_DIMENCAO_CHAPA_DE, GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE, GRP_PREFIXO_ID_PRODUTO, GRP_COLUNA_CAIXA, GRP_COLUNA_CHAPA, GRP_MULLEN, GRP_TENDENCIA_TOLERANCIA_PEDIDO, GRP_PERCENTUAL_PERDA_MEDIA, GRP_FILTRA_SEQ_TRANS, GRP_IMG_CAIXA, TenantID, Deleted, Changed, UserId FROM GrupoProdutoAbstrato ";
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