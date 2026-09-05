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
    public class MaquinaQueryRead : QueryBase, IMaquinaQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public MaquinaQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel MaquinaQuery(Command.Read.MaquinaReadCommand Command )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] from [Maquina] ";
if (!string.IsNullOrEmpty(Command.Id)) dict["Id"] = $"%{Command.Id}%";
if (!string.IsNullOrEmpty(Command.Id)) whereClauses.Add($"[Id] like @Id");
if (!string.IsNullOrEmpty(Command.Descricao)) dict["Descricao"] = $"%{Command.Descricao}%";
if (!string.IsNullOrEmpty(Command.Descricao)) whereClauses.Add($"[Descricao] like @Descricao");
if (!string.IsNullOrEmpty(Command.Status)) dict["Status"] = $"%{Command.Status}%";
if (!string.IsNullOrEmpty(Command.Status)) whereClauses.Add($"[Status] like @Status");
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
if (Command.UserId.HasValue) dict["UserId"] = Command.UserId.Value;
if (Command.UserId.HasValue) whereClauses.Add($"[UserId] = @UserId");
if (Command.CAL_ID.HasValue) dict["CAL_ID"] = Command.CAL_ID.Value;
if (Command.CAL_ID.HasValue) whereClauses.Add($"[CAL_ID] = @CAL_ID");
if (!string.IsNullOrEmpty(Command.MAQ_CONTROL_IP)) dict["MAQ_CONTROL_IP"] = $"%{Command.MAQ_CONTROL_IP}%";
if (!string.IsNullOrEmpty(Command.MAQ_CONTROL_IP)) whereClauses.Add($"[MAQ_CONTROL_IP] like @MAQ_CONTROL_IP");
if (!string.IsNullOrEmpty(Command.GMA_ID)) dict["GMA_ID"] = $"%{Command.GMA_ID}%";
if (!string.IsNullOrEmpty(Command.GMA_ID)) whereClauses.Add($"[GMA_ID] like @GMA_ID");
if (Command.MAQ_SIRENE_SEMAFORO.HasValue) dict["MAQ_SIRENE_SEMAFORO"] = Command.MAQ_SIRENE_SEMAFORO.Value;
if (Command.MAQ_SIRENE_SEMAFORO.HasValue) whereClauses.Add($"[MAQ_SIRENE_SEMAFORO] = @MAQ_SIRENE_SEMAFORO");
if (!string.IsNullOrEmpty(Command.MAQ_COR_SEMAFORO)) dict["MAQ_COR_SEMAFORO"] = $"%{Command.MAQ_COR_SEMAFORO}%";
if (!string.IsNullOrEmpty(Command.MAQ_COR_SEMAFORO)) whereClauses.Add($"[MAQ_COR_SEMAFORO] like @MAQ_COR_SEMAFORO");
if (!string.IsNullOrEmpty(Command.MAQ_ID_MAQ_PAI)) dict["MAQ_ID_MAQ_PAI"] = $"%{Command.MAQ_ID_MAQ_PAI}%";
if (!string.IsNullOrEmpty(Command.MAQ_ID_MAQ_PAI)) whereClauses.Add($"[MAQ_ID_MAQ_PAI] like @MAQ_ID_MAQ_PAI");
if (Command.MAQ_TIPO_CONTADOR.HasValue) dict["MAQ_TIPO_CONTADOR"] = Command.MAQ_TIPO_CONTADOR.Value;
if (Command.MAQ_TIPO_CONTADOR.HasValue) whereClauses.Add($"[MAQ_TIPO_CONTADOR] = @MAQ_TIPO_CONTADOR");
if (!string.IsNullOrEmpty(Command.MAQ_TIPO_PLANEJAMENTO)) dict["MAQ_TIPO_PLANEJAMENTO"] = $"%{Command.MAQ_TIPO_PLANEJAMENTO}%";
if (!string.IsNullOrEmpty(Command.MAQ_TIPO_PLANEJAMENTO)) whereClauses.Add($"[MAQ_TIPO_PLANEJAMENTO] like @MAQ_TIPO_PLANEJAMENTO");
if (Command.MAQ_AVALIA_CUSTO.HasValue) dict["MAQ_AVALIA_CUSTO"] = Command.MAQ_AVALIA_CUSTO.Value;
if (Command.MAQ_AVALIA_CUSTO.HasValue) whereClauses.Add($"[MAQ_AVALIA_CUSTO] = @MAQ_AVALIA_CUSTO");
if (Command.FPR_ID_OP_PRODUZINDO.HasValue) dict["FPR_ID_OP_PRODUZINDO"] = Command.FPR_ID_OP_PRODUZINDO.Value;
if (Command.FPR_ID_OP_PRODUZINDO.HasValue) whereClauses.Add($"[FPR_ID_OP_PRODUZINDO] = @FPR_ID_OP_PRODUZINDO");
if (Command.MAQ_CONGELA_FILA.HasValue) dict["MAQ_CONGELA_FILA"] = Command.MAQ_CONGELA_FILA.Value;
if (Command.MAQ_CONGELA_FILA.HasValue) whereClauses.Add($"[MAQ_CONGELA_FILA] = @MAQ_CONGELA_FILA");
if (Command.MAQ_TEMPO_MIN_PARADA.HasValue) dict["MAQ_TEMPO_MIN_PARADA"] = Command.MAQ_TEMPO_MIN_PARADA.Value;
if (Command.MAQ_TEMPO_MIN_PARADA.HasValue) whereClauses.Add($"[MAQ_TEMPO_MIN_PARADA] = @MAQ_TEMPO_MIN_PARADA");
if (Command.MAQ_QTD_CORES.HasValue) dict["MAQ_QTD_CORES"] = Command.MAQ_QTD_CORES.Value;
if (Command.MAQ_QTD_CORES.HasValue) whereClauses.Add($"[MAQ_QTD_CORES] = @MAQ_QTD_CORES");
if (!string.IsNullOrEmpty(Command.MAQ_ID_INTEGRACAO)) dict["MAQ_ID_INTEGRACAO"] = $"%{Command.MAQ_ID_INTEGRACAO}%";
if (!string.IsNullOrEmpty(Command.MAQ_ID_INTEGRACAO)) whereClauses.Add($"[MAQ_ID_INTEGRACAO] like @MAQ_ID_INTEGRACAO");
if (!string.IsNullOrEmpty(Command.MAQ_ID_INTEGRACAO_ERP)) dict["MAQ_ID_INTEGRACAO_ERP"] = $"%{Command.MAQ_ID_INTEGRACAO_ERP}%";
if (!string.IsNullOrEmpty(Command.MAQ_ID_INTEGRACAO_ERP)) whereClauses.Add($"[MAQ_ID_INTEGRACAO_ERP] like @MAQ_ID_INTEGRACAO_ERP");
if (!string.IsNullOrEmpty(Command.EQU_ID)) dict["EQU_ID"] = $"%{Command.EQU_ID}%";
if (!string.IsNullOrEmpty(Command.EQU_ID)) whereClauses.Add($"[EQU_ID] like @EQU_ID");
if (!string.IsNullOrEmpty(Command.MAQ_ACOMPANHA_LOTE_PILOTO)) dict["MAQ_ACOMPANHA_LOTE_PILOTO"] = $"%{Command.MAQ_ACOMPANHA_LOTE_PILOTO}%";
if (!string.IsNullOrEmpty(Command.MAQ_ACOMPANHA_LOTE_PILOTO)) whereClauses.Add($"[MAQ_ACOMPANHA_LOTE_PILOTO] like @MAQ_ACOMPANHA_LOTE_PILOTO");
if (Command.MAQ_ID_SENSOR.HasValue) dict["MAQ_ID_SENSOR"] = Command.MAQ_ID_SENSOR.Value;
if (Command.MAQ_ID_SENSOR.HasValue) whereClauses.Add($"[MAQ_ID_SENSOR] = @MAQ_ID_SENSOR");
if (Command.MAQ_DEBOUNCING_LOW.HasValue) dict["MAQ_DEBOUNCING_LOW"] = Command.MAQ_DEBOUNCING_LOW.Value;
if (Command.MAQ_DEBOUNCING_LOW.HasValue) whereClauses.Add($"[MAQ_DEBOUNCING_LOW] = @MAQ_DEBOUNCING_LOW");
if (Command.MAQ_DEBOUNCING_HIGHT.HasValue) dict["MAQ_DEBOUNCING_HIGHT"] = Command.MAQ_DEBOUNCING_HIGHT.Value;
if (Command.MAQ_DEBOUNCING_HIGHT.HasValue) whereClauses.Add($"[MAQ_DEBOUNCING_HIGHT] = @MAQ_DEBOUNCING_HIGHT");
if (Command.MAQ_TIPO_SINAL.HasValue) dict["MAQ_TIPO_SINAL"] = Command.MAQ_TIPO_SINAL.Value;
if (Command.MAQ_TIPO_SINAL.HasValue) whereClauses.Add($"[MAQ_TIPO_SINAL] = @MAQ_TIPO_SINAL");
if (Command.TEM_ID.HasValue) dict["TEM_ID"] = Command.TEM_ID.Value;
if (Command.TEM_ID.HasValue) whereClauses.Add($"[TEM_ID] = @TEM_ID");
if (!string.IsNullOrEmpty(Command.MAQ_ONDAS)) dict["MAQ_ONDAS"] = $"%{Command.MAQ_ONDAS}%";
if (!string.IsNullOrEmpty(Command.MAQ_ONDAS)) whereClauses.Add($"[MAQ_ONDAS] like @MAQ_ONDAS");
if (!string.IsNullOrEmpty(Command.MAQ_PROLONGA_LAP)) dict["MAQ_PROLONGA_LAP"] = $"%{Command.MAQ_PROLONGA_LAP}%";
if (!string.IsNullOrEmpty(Command.MAQ_PROLONGA_LAP)) whereClauses.Add($"[MAQ_PROLONGA_LAP] like @MAQ_PROLONGA_LAP");
if (!string.IsNullOrEmpty(Command.MAQ_FAMILIAS)) dict["MAQ_FAMILIAS"] = $"%{Command.MAQ_FAMILIAS}%";
if (!string.IsNullOrEmpty(Command.MAQ_FAMILIAS)) whereClauses.Add($"[MAQ_FAMILIAS] like @MAQ_FAMILIAS");
if (!string.IsNullOrEmpty(Command.MAQ_FECHAMENTO)) dict["MAQ_FECHAMENTO"] = $"%{Command.MAQ_FECHAMENTO}%";
if (!string.IsNullOrEmpty(Command.MAQ_FECHAMENTO)) whereClauses.Add($"[MAQ_FECHAMENTO] like @MAQ_FECHAMENTO");
if (!string.IsNullOrEmpty(Command.MAQ_TIPO_LAP)) dict["MAQ_TIPO_LAP"] = $"%{Command.MAQ_TIPO_LAP}%";
if (!string.IsNullOrEmpty(Command.MAQ_TIPO_LAP)) whereClauses.Add($"[MAQ_TIPO_LAP] like @MAQ_TIPO_LAP");
if (Command.MAQ_PERDA_MAXIMA.HasValue) dict["MAQ_PERDA_MAXIMA"] = Command.MAQ_PERDA_MAXIMA.Value;
if (Command.MAQ_PERDA_MAXIMA.HasValue) whereClauses.Add($"[MAQ_PERDA_MAXIMA] = @MAQ_PERDA_MAXIMA");
if (Command.MAQ_TOTAL_PECAS_REFILANDO.HasValue) dict["MAQ_TOTAL_PECAS_REFILANDO"] = Command.MAQ_TOTAL_PECAS_REFILANDO.Value;
if (Command.MAQ_TOTAL_PECAS_REFILANDO.HasValue) whereClauses.Add($"[MAQ_TOTAL_PECAS_REFILANDO] = @MAQ_TOTAL_PECAS_REFILANDO");
if (Command.MAQ_TOTAL_PECAS_NAO_REFILANDO.HasValue) dict["MAQ_TOTAL_PECAS_NAO_REFILANDO"] = Command.MAQ_TOTAL_PECAS_NAO_REFILANDO.Value;
if (Command.MAQ_TOTAL_PECAS_NAO_REFILANDO.HasValue) whereClauses.Add($"[MAQ_TOTAL_PECAS_NAO_REFILANDO] = @MAQ_TOTAL_PECAS_NAO_REFILANDO");
if (Command.MAQ_TOTAL_VINCOS.HasValue) dict["MAQ_TOTAL_VINCOS"] = Command.MAQ_TOTAL_VINCOS.Value;
if (Command.MAQ_TOTAL_VINCOS.HasValue) whereClauses.Add($"[MAQ_TOTAL_VINCOS] = @MAQ_TOTAL_VINCOS");
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
        public QueryModel MaquinaTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel MaquinaUserIdQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel MaquinaCAL_IDQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select [CAL_ID] from [Calendario] ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["CAL_ID"] = numero; //01
                      whereClauses.Add($" [CAL_ID] = @CAL_ID");//01 
                 }
                 else 
                 {
                      dict["CAL_ID"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" [CAL_ID] like @CAL_ID ");//02
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
        public QueryModel ExistsByIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
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
        public QueryModel ExistsByDescricaoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Descricao"] = value; //04
                      whereClauses.Add($" [Descricao] = @Descricao ");//04
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
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Status"] = value; //04
                      whereClauses.Add($" [Status] = @Status ");//04
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
            this.Query = $"SELECT 1 FROM [Maquina] ";
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
            this.Query = $"SELECT 1 FROM [Maquina] ";
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
            this.Query = $"SELECT 1 FROM [Maquina] ";
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
            this.Query = $"SELECT 1 FROM [Maquina] ";
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
        public QueryModel ExistsByCAL_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CAL_ID"] = value; //04
                      whereClauses.Add($" [CAL_ID] = @CAL_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_CONTROL_IPQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_CONTROL_IP"] = value; //04
                      whereClauses.Add($" [MAQ_CONTROL_IP] = @MAQ_CONTROL_IP ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByGMA_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["GMA_ID"] = value; //04
                      whereClauses.Add($" [GMA_ID] = @GMA_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_ULTIMA_ATUALIZACAOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_ULTIMA_ATUALIZACAO"] = value; //04
                      whereClauses.Add($" [MAQ_ULTIMA_ATUALIZACAO] = @MAQ_ULTIMA_ATUALIZACAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_SIRENE_SEMAFOROQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_SIRENE_SEMAFORO"] = value; //04
                      whereClauses.Add($" [MAQ_SIRENE_SEMAFORO] = @MAQ_SIRENE_SEMAFORO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_COR_SEMAFOROQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_COR_SEMAFORO"] = value; //04
                      whereClauses.Add($" [MAQ_COR_SEMAFORO] = @MAQ_COR_SEMAFORO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_ID_MAQ_PAIQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_ID_MAQ_PAI"] = value; //04
                      whereClauses.Add($" [MAQ_ID_MAQ_PAI] = @MAQ_ID_MAQ_PAI ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_TIPO_CONTADORQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_TIPO_CONTADOR"] = value; //04
                      whereClauses.Add($" [MAQ_TIPO_CONTADOR] = @MAQ_TIPO_CONTADOR ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_TIPO_PLANEJAMENTOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_TIPO_PLANEJAMENTO"] = value; //04
                      whereClauses.Add($" [MAQ_TIPO_PLANEJAMENTO] = @MAQ_TIPO_PLANEJAMENTO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_AVALIA_CUSTOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_AVALIA_CUSTO"] = value; //04
                      whereClauses.Add($" [MAQ_AVALIA_CUSTO] = @MAQ_AVALIA_CUSTO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFPR_ID_OP_PRODUZINDOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["FPR_ID_OP_PRODUZINDO"] = value; //04
                      whereClauses.Add($" [FPR_ID_OP_PRODUZINDO] = @FPR_ID_OP_PRODUZINDO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_CONGELA_FILAQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_CONGELA_FILA"] = value; //04
                      whereClauses.Add($" [MAQ_CONGELA_FILA] = @MAQ_CONGELA_FILA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_TEMPO_MIN_PARADAQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_TEMPO_MIN_PARADA"] = value; //04
                      whereClauses.Add($" [MAQ_TEMPO_MIN_PARADA] = @MAQ_TEMPO_MIN_PARADA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_QTD_CORESQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_QTD_CORES"] = value; //04
                      whereClauses.Add($" [MAQ_QTD_CORES] = @MAQ_QTD_CORES ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_ID_INTEGRACAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_ID_INTEGRACAO"] = value; //04
                      whereClauses.Add($" [MAQ_ID_INTEGRACAO] = @MAQ_ID_INTEGRACAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_ID_INTEGRACAO_ERPQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_ID_INTEGRACAO_ERP"] = value; //04
                      whereClauses.Add($" [MAQ_ID_INTEGRACAO_ERP] = @MAQ_ID_INTEGRACAO_ERP ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_HIERARQUIA_SEQ_TRANSFORMACAOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_HIERARQUIA_SEQ_TRANSFORMACAO"] = value; //04
                      whereClauses.Add($" [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO] = @MAQ_HIERARQUIA_SEQ_TRANSFORMACAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByEQU_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["EQU_ID"] = value; //04
                      whereClauses.Add($" [EQU_ID] = @EQU_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_PERCENTUAL_INICIO_PASSO_ANTERIORQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR"] = value; //04
                      whereClauses.Add($" [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR] = @MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_ACOMPANHA_LOTE_PILOTOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_ACOMPANHA_LOTE_PILOTO"] = value; //04
                      whereClauses.Add($" [MAQ_ACOMPANHA_LOTE_PILOTO] = @MAQ_ACOMPANHA_LOTE_PILOTO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_ID_SENSORQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_ID_SENSOR"] = value; //04
                      whereClauses.Add($" [MAQ_ID_SENSOR] = @MAQ_ID_SENSOR ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_DEBOUNCING_LOWQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_DEBOUNCING_LOW"] = value; //04
                      whereClauses.Add($" [MAQ_DEBOUNCING_LOW] = @MAQ_DEBOUNCING_LOW ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_DEBOUNCING_HIGHTQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_DEBOUNCING_HIGHT"] = value; //04
                      whereClauses.Add($" [MAQ_DEBOUNCING_HIGHT] = @MAQ_DEBOUNCING_HIGHT ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_TIPO_SINALQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_TIPO_SINAL"] = value; //04
                      whereClauses.Add($" [MAQ_TIPO_SINAL] = @MAQ_TIPO_SINAL ");//04
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
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TEM_ID"] = value; //04
                      whereClauses.Add($" [TEM_ID] = @TEM_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_COMPRIMENTO_CHAPA_DEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_COMPRIMENTO_CHAPA_DE"] = value; //04
                      whereClauses.Add($" [MAQ_COMPRIMENTO_CHAPA_DE] = @MAQ_COMPRIMENTO_CHAPA_DE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_COMPRIMENTO_CHAPA_ATEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_COMPRIMENTO_CHAPA_ATE"] = value; //04
                      whereClauses.Add($" [MAQ_COMPRIMENTO_CHAPA_ATE] = @MAQ_COMPRIMENTO_CHAPA_ATE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_LARGURA_CHAPA_DEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_LARGURA_CHAPA_DE"] = value; //04
                      whereClauses.Add($" [MAQ_LARGURA_CHAPA_DE] = @MAQ_LARGURA_CHAPA_DE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_LARGURA_CHAPA_ATEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_LARGURA_CHAPA_ATE"] = value; //04
                      whereClauses.Add($" [MAQ_LARGURA_CHAPA_ATE] = @MAQ_LARGURA_CHAPA_ATE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIORQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR"] = value; //04
                      whereClauses.Add($" [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR] = @MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIORQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR"] = value; //04
                      whereClauses.Add($" [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR] = @MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIORQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR"] = value; //04
                      whereClauses.Add($" [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR] = @MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIORQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR"] = value; //04
                      whereClauses.Add($" [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR] = @MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_COMPRIMENTO_ENTRE_VINCO_DEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_COMPRIMENTO_ENTRE_VINCO_DE"] = value; //04
                      whereClauses.Add($" [MAQ_COMPRIMENTO_ENTRE_VINCO_DE] = @MAQ_COMPRIMENTO_ENTRE_VINCO_DE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_COMPRIMENTO_ENTRE_VINCO_ATEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_COMPRIMENTO_ENTRE_VINCO_ATE"] = value; //04
                      whereClauses.Add($" [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE] = @MAQ_COMPRIMENTO_ENTRE_VINCO_ATE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_LARGURA_ENTRE_VINCO_DEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_LARGURA_ENTRE_VINCO_DE"] = value; //04
                      whereClauses.Add($" [MAQ_LARGURA_ENTRE_VINCO_DE] = @MAQ_LARGURA_ENTRE_VINCO_DE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_LARGURA_ENTRE_VINCO_ATEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_LARGURA_ENTRE_VINCO_ATE"] = value; //04
                      whereClauses.Add($" [MAQ_LARGURA_ENTRE_VINCO_ATE] = @MAQ_LARGURA_ENTRE_VINCO_ATE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_ALTURA_ENTRE_VINCO_DEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_ALTURA_ENTRE_VINCO_DE"] = value; //04
                      whereClauses.Add($" [MAQ_ALTURA_ENTRE_VINCO_DE] = @MAQ_ALTURA_ENTRE_VINCO_DE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_ALTURA_ENTRE_VINCO_ATEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_ALTURA_ENTRE_VINCO_ATE"] = value; //04
                      whereClauses.Add($" [MAQ_ALTURA_ENTRE_VINCO_ATE] = @MAQ_ALTURA_ENTRE_VINCO_ATE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE"] = value; //04
                      whereClauses.Add($" [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE] = @MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE"] = value; //04
                      whereClauses.Add($" [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE] = @MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_ABA_DEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_ABA_DE"] = value; //04
                      whereClauses.Add($" [MAQ_ABA_DE] = @MAQ_ABA_DE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_ABA_ATEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_ABA_ATE"] = value; //04
                      whereClauses.Add($" [MAQ_ABA_ATE] = @MAQ_ABA_ATE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_LAP_DEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_LAP_DE"] = value; //04
                      whereClauses.Add($" [MAQ_LAP_DE] = @MAQ_LAP_DE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_LAP_ATEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_LAP_ATE"] = value; //04
                      whereClauses.Add($" [MAQ_LAP_ATE] = @MAQ_LAP_ATE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_ONDASQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_ONDAS"] = value; //04
                      whereClauses.Add($" [MAQ_ONDAS] = @MAQ_ONDAS ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_PROLONGA_LAPQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_PROLONGA_LAP"] = value; //04
                      whereClauses.Add($" [MAQ_PROLONGA_LAP] = @MAQ_PROLONGA_LAP ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_LARGURA_IMPRESSAOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_LARGURA_IMPRESSAO"] = value; //04
                      whereClauses.Add($" [MAQ_LARGURA_IMPRESSAO] = @MAQ_LARGURA_IMPRESSAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_COMPRIMENTO_IMPRESSAOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_COMPRIMENTO_IMPRESSAO"] = value; //04
                      whereClauses.Add($" [MAQ_COMPRIMENTO_IMPRESSAO] = @MAQ_COMPRIMENTO_IMPRESSAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_ROLO_DISPOSITIVO_DEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_ROLO_DISPOSITIVO_DE"] = value; //04
                      whereClauses.Add($" [MAQ_ROLO_DISPOSITIVO_DE] = @MAQ_ROLO_DISPOSITIVO_DE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_ROLO_DISPOSITIVO_ATEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_ROLO_DISPOSITIVO_ATE"] = value; //04
                      whereClauses.Add($" [MAQ_ROLO_DISPOSITIVO_ATE] = @MAQ_ROLO_DISPOSITIVO_ATE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_FAMILIASQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_FAMILIAS"] = value; //04
                      whereClauses.Add($" [MAQ_FAMILIAS] = @MAQ_FAMILIAS ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_REFILE_MINIMOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_REFILE_MINIMO"] = value; //04
                      whereClauses.Add($" [MAQ_REFILE_MINIMO] = @MAQ_REFILE_MINIMO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_LARGURA_UTILQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_LARGURA_UTIL"] = value; //04
                      whereClauses.Add($" [MAQ_LARGURA_UTIL] = @MAQ_LARGURA_UTIL ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_TOTAL_ACOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_TOTAL_ACO"] = value; //04
                      whereClauses.Add($" [MAQ_TOTAL_ACO] = @MAQ_TOTAL_ACO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_FECHAMENTOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_FECHAMENTO"] = value; //04
                      whereClauses.Add($" [MAQ_FECHAMENTO] = @MAQ_FECHAMENTO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_OPERACAO_VINCARQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_OPERACAO_VINCAR"] = value; //04
                      whereClauses.Add($" [MAQ_OPERACAO_VINCAR] = @MAQ_OPERACAO_VINCAR ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_OPERACAO_MONTA_DIVISAOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_OPERACAO_MONTA_DIVISAO"] = value; //04
                      whereClauses.Add($" [MAQ_OPERACAO_MONTA_DIVISAO] = @MAQ_OPERACAO_MONTA_DIVISAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_OPERACAO_SERRARQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_OPERACAO_SERRAR"] = value; //04
                      whereClauses.Add($" [MAQ_OPERACAO_SERRAR] = @MAQ_OPERACAO_SERRAR ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_TIPO_LAPQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_TIPO_LAP"] = value; //04
                      whereClauses.Add($" [MAQ_TIPO_LAP] = @MAQ_TIPO_LAP ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_INDICE_PARADAS_POR_OPQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_INDICE_PARADAS_POR_OP"] = value; //04
                      whereClauses.Add($" [MAQ_INDICE_PARADAS_POR_OP] = @MAQ_INDICE_PARADAS_POR_OP ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_PERDA_MAXIMAQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_PERDA_MAXIMA"] = value; //04
                      whereClauses.Add($" [MAQ_PERDA_MAXIMA] = @MAQ_PERDA_MAXIMA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_TOTAL_PECAS_REFILANDOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_TOTAL_PECAS_REFILANDO"] = value; //04
                      whereClauses.Add($" [MAQ_TOTAL_PECAS_REFILANDO] = @MAQ_TOTAL_PECAS_REFILANDO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_TOTAL_PECAS_NAO_REFILANDOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_TOTAL_PECAS_NAO_REFILANDO"] = value; //04
                      whereClauses.Add($" [MAQ_TOTAL_PECAS_NAO_REFILANDO] = @MAQ_TOTAL_PECAS_NAO_REFILANDO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMAQ_TOTAL_VINCOSQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_TOTAL_VINCOS"] = value; //04
                      whereClauses.Add($" [MAQ_TOTAL_VINCOS] = @MAQ_TOTAL_VINCOS ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
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
        public QueryModel FirstByDescricaoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Descricao"] = value; //06
                      whereClauses.Add($" [Descricao] = @Descricao ");//06
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
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Status"] = value; //06
                      whereClauses.Add($" [Status] = @Status ");//06
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
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
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
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
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
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
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
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
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
        public QueryModel FirstByCAL_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CAL_ID"] = value; //06
                      whereClauses.Add($" [CAL_ID] = @CAL_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_CONTROL_IPQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_CONTROL_IP"] = value; //06
                      whereClauses.Add($" [MAQ_CONTROL_IP] = @MAQ_CONTROL_IP ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByGMA_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["GMA_ID"] = value; //06
                      whereClauses.Add($" [GMA_ID] = @GMA_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_ULTIMA_ATUALIZACAOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_ULTIMA_ATUALIZACAO"] = value; //06
                      whereClauses.Add($" [MAQ_ULTIMA_ATUALIZACAO] = @MAQ_ULTIMA_ATUALIZACAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_SIRENE_SEMAFOROQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_SIRENE_SEMAFORO"] = value; //06
                      whereClauses.Add($" [MAQ_SIRENE_SEMAFORO] = @MAQ_SIRENE_SEMAFORO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_COR_SEMAFOROQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_COR_SEMAFORO"] = value; //06
                      whereClauses.Add($" [MAQ_COR_SEMAFORO] = @MAQ_COR_SEMAFORO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_ID_MAQ_PAIQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_ID_MAQ_PAI"] = value; //06
                      whereClauses.Add($" [MAQ_ID_MAQ_PAI] = @MAQ_ID_MAQ_PAI ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_TIPO_CONTADORQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_TIPO_CONTADOR"] = value; //06
                      whereClauses.Add($" [MAQ_TIPO_CONTADOR] = @MAQ_TIPO_CONTADOR ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_TIPO_PLANEJAMENTOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_TIPO_PLANEJAMENTO"] = value; //06
                      whereClauses.Add($" [MAQ_TIPO_PLANEJAMENTO] = @MAQ_TIPO_PLANEJAMENTO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_AVALIA_CUSTOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_AVALIA_CUSTO"] = value; //06
                      whereClauses.Add($" [MAQ_AVALIA_CUSTO] = @MAQ_AVALIA_CUSTO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFPR_ID_OP_PRODUZINDOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["FPR_ID_OP_PRODUZINDO"] = value; //06
                      whereClauses.Add($" [FPR_ID_OP_PRODUZINDO] = @FPR_ID_OP_PRODUZINDO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_CONGELA_FILAQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_CONGELA_FILA"] = value; //06
                      whereClauses.Add($" [MAQ_CONGELA_FILA] = @MAQ_CONGELA_FILA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_TEMPO_MIN_PARADAQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_TEMPO_MIN_PARADA"] = value; //06
                      whereClauses.Add($" [MAQ_TEMPO_MIN_PARADA] = @MAQ_TEMPO_MIN_PARADA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_QTD_CORESQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_QTD_CORES"] = value; //06
                      whereClauses.Add($" [MAQ_QTD_CORES] = @MAQ_QTD_CORES ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_ID_INTEGRACAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_ID_INTEGRACAO"] = value; //06
                      whereClauses.Add($" [MAQ_ID_INTEGRACAO] = @MAQ_ID_INTEGRACAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_ID_INTEGRACAO_ERPQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_ID_INTEGRACAO_ERP"] = value; //06
                      whereClauses.Add($" [MAQ_ID_INTEGRACAO_ERP] = @MAQ_ID_INTEGRACAO_ERP ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_HIERARQUIA_SEQ_TRANSFORMACAOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_HIERARQUIA_SEQ_TRANSFORMACAO"] = value; //06
                      whereClauses.Add($" [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO] = @MAQ_HIERARQUIA_SEQ_TRANSFORMACAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByEQU_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["EQU_ID"] = value; //06
                      whereClauses.Add($" [EQU_ID] = @EQU_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_PERCENTUAL_INICIO_PASSO_ANTERIORQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR"] = value; //06
                      whereClauses.Add($" [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR] = @MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_ACOMPANHA_LOTE_PILOTOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_ACOMPANHA_LOTE_PILOTO"] = value; //06
                      whereClauses.Add($" [MAQ_ACOMPANHA_LOTE_PILOTO] = @MAQ_ACOMPANHA_LOTE_PILOTO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_ID_SENSORQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_ID_SENSOR"] = value; //06
                      whereClauses.Add($" [MAQ_ID_SENSOR] = @MAQ_ID_SENSOR ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_DEBOUNCING_LOWQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_DEBOUNCING_LOW"] = value; //06
                      whereClauses.Add($" [MAQ_DEBOUNCING_LOW] = @MAQ_DEBOUNCING_LOW ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_DEBOUNCING_HIGHTQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_DEBOUNCING_HIGHT"] = value; //06
                      whereClauses.Add($" [MAQ_DEBOUNCING_HIGHT] = @MAQ_DEBOUNCING_HIGHT ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_TIPO_SINALQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_TIPO_SINAL"] = value; //06
                      whereClauses.Add($" [MAQ_TIPO_SINAL] = @MAQ_TIPO_SINAL ");//06
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
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TEM_ID"] = value; //06
                      whereClauses.Add($" [TEM_ID] = @TEM_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_COMPRIMENTO_CHAPA_DEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_COMPRIMENTO_CHAPA_DE"] = value; //06
                      whereClauses.Add($" [MAQ_COMPRIMENTO_CHAPA_DE] = @MAQ_COMPRIMENTO_CHAPA_DE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_COMPRIMENTO_CHAPA_ATEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_COMPRIMENTO_CHAPA_ATE"] = value; //06
                      whereClauses.Add($" [MAQ_COMPRIMENTO_CHAPA_ATE] = @MAQ_COMPRIMENTO_CHAPA_ATE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_LARGURA_CHAPA_DEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_LARGURA_CHAPA_DE"] = value; //06
                      whereClauses.Add($" [MAQ_LARGURA_CHAPA_DE] = @MAQ_LARGURA_CHAPA_DE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_LARGURA_CHAPA_ATEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_LARGURA_CHAPA_ATE"] = value; //06
                      whereClauses.Add($" [MAQ_LARGURA_CHAPA_ATE] = @MAQ_LARGURA_CHAPA_ATE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIORQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR"] = value; //06
                      whereClauses.Add($" [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR] = @MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIORQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR"] = value; //06
                      whereClauses.Add($" [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR] = @MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIORQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR"] = value; //06
                      whereClauses.Add($" [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR] = @MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIORQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR"] = value; //06
                      whereClauses.Add($" [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR] = @MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_COMPRIMENTO_ENTRE_VINCO_DEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_COMPRIMENTO_ENTRE_VINCO_DE"] = value; //06
                      whereClauses.Add($" [MAQ_COMPRIMENTO_ENTRE_VINCO_DE] = @MAQ_COMPRIMENTO_ENTRE_VINCO_DE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_COMPRIMENTO_ENTRE_VINCO_ATEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_COMPRIMENTO_ENTRE_VINCO_ATE"] = value; //06
                      whereClauses.Add($" [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE] = @MAQ_COMPRIMENTO_ENTRE_VINCO_ATE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_LARGURA_ENTRE_VINCO_DEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_LARGURA_ENTRE_VINCO_DE"] = value; //06
                      whereClauses.Add($" [MAQ_LARGURA_ENTRE_VINCO_DE] = @MAQ_LARGURA_ENTRE_VINCO_DE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_LARGURA_ENTRE_VINCO_ATEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_LARGURA_ENTRE_VINCO_ATE"] = value; //06
                      whereClauses.Add($" [MAQ_LARGURA_ENTRE_VINCO_ATE] = @MAQ_LARGURA_ENTRE_VINCO_ATE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_ALTURA_ENTRE_VINCO_DEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_ALTURA_ENTRE_VINCO_DE"] = value; //06
                      whereClauses.Add($" [MAQ_ALTURA_ENTRE_VINCO_DE] = @MAQ_ALTURA_ENTRE_VINCO_DE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_ALTURA_ENTRE_VINCO_ATEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_ALTURA_ENTRE_VINCO_ATE"] = value; //06
                      whereClauses.Add($" [MAQ_ALTURA_ENTRE_VINCO_ATE] = @MAQ_ALTURA_ENTRE_VINCO_ATE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE"] = value; //06
                      whereClauses.Add($" [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE] = @MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE"] = value; //06
                      whereClauses.Add($" [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE] = @MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_ABA_DEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_ABA_DE"] = value; //06
                      whereClauses.Add($" [MAQ_ABA_DE] = @MAQ_ABA_DE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_ABA_ATEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_ABA_ATE"] = value; //06
                      whereClauses.Add($" [MAQ_ABA_ATE] = @MAQ_ABA_ATE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_LAP_DEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_LAP_DE"] = value; //06
                      whereClauses.Add($" [MAQ_LAP_DE] = @MAQ_LAP_DE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_LAP_ATEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_LAP_ATE"] = value; //06
                      whereClauses.Add($" [MAQ_LAP_ATE] = @MAQ_LAP_ATE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_ONDASQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_ONDAS"] = value; //06
                      whereClauses.Add($" [MAQ_ONDAS] = @MAQ_ONDAS ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_PROLONGA_LAPQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_PROLONGA_LAP"] = value; //06
                      whereClauses.Add($" [MAQ_PROLONGA_LAP] = @MAQ_PROLONGA_LAP ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_LARGURA_IMPRESSAOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_LARGURA_IMPRESSAO"] = value; //06
                      whereClauses.Add($" [MAQ_LARGURA_IMPRESSAO] = @MAQ_LARGURA_IMPRESSAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_COMPRIMENTO_IMPRESSAOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_COMPRIMENTO_IMPRESSAO"] = value; //06
                      whereClauses.Add($" [MAQ_COMPRIMENTO_IMPRESSAO] = @MAQ_COMPRIMENTO_IMPRESSAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_ROLO_DISPOSITIVO_DEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_ROLO_DISPOSITIVO_DE"] = value; //06
                      whereClauses.Add($" [MAQ_ROLO_DISPOSITIVO_DE] = @MAQ_ROLO_DISPOSITIVO_DE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_ROLO_DISPOSITIVO_ATEQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_ROLO_DISPOSITIVO_ATE"] = value; //06
                      whereClauses.Add($" [MAQ_ROLO_DISPOSITIVO_ATE] = @MAQ_ROLO_DISPOSITIVO_ATE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_FAMILIASQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_FAMILIAS"] = value; //06
                      whereClauses.Add($" [MAQ_FAMILIAS] = @MAQ_FAMILIAS ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_REFILE_MINIMOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_REFILE_MINIMO"] = value; //06
                      whereClauses.Add($" [MAQ_REFILE_MINIMO] = @MAQ_REFILE_MINIMO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_LARGURA_UTILQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_LARGURA_UTIL"] = value; //06
                      whereClauses.Add($" [MAQ_LARGURA_UTIL] = @MAQ_LARGURA_UTIL ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_TOTAL_ACOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_TOTAL_ACO"] = value; //06
                      whereClauses.Add($" [MAQ_TOTAL_ACO] = @MAQ_TOTAL_ACO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_FECHAMENTOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_FECHAMENTO"] = value; //06
                      whereClauses.Add($" [MAQ_FECHAMENTO] = @MAQ_FECHAMENTO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_OPERACAO_VINCARQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_OPERACAO_VINCAR"] = value; //06
                      whereClauses.Add($" [MAQ_OPERACAO_VINCAR] = @MAQ_OPERACAO_VINCAR ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_OPERACAO_MONTA_DIVISAOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_OPERACAO_MONTA_DIVISAO"] = value; //06
                      whereClauses.Add($" [MAQ_OPERACAO_MONTA_DIVISAO] = @MAQ_OPERACAO_MONTA_DIVISAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_OPERACAO_SERRARQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_OPERACAO_SERRAR"] = value; //06
                      whereClauses.Add($" [MAQ_OPERACAO_SERRAR] = @MAQ_OPERACAO_SERRAR ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_TIPO_LAPQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_TIPO_LAP"] = value; //06
                      whereClauses.Add($" [MAQ_TIPO_LAP] = @MAQ_TIPO_LAP ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_INDICE_PARADAS_POR_OPQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_INDICE_PARADAS_POR_OP"] = value; //06
                      whereClauses.Add($" [MAQ_INDICE_PARADAS_POR_OP] = @MAQ_INDICE_PARADAS_POR_OP ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_PERDA_MAXIMAQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_PERDA_MAXIMA"] = value; //06
                      whereClauses.Add($" [MAQ_PERDA_MAXIMA] = @MAQ_PERDA_MAXIMA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_TOTAL_PECAS_REFILANDOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_TOTAL_PECAS_REFILANDO"] = value; //06
                      whereClauses.Add($" [MAQ_TOTAL_PECAS_REFILANDO] = @MAQ_TOTAL_PECAS_REFILANDO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_TOTAL_PECAS_NAO_REFILANDOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_TOTAL_PECAS_NAO_REFILANDO"] = value; //06
                      whereClauses.Add($" [MAQ_TOTAL_PECAS_NAO_REFILANDO] = @MAQ_TOTAL_PECAS_NAO_REFILANDO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMAQ_TOTAL_VINCOSQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [CAL_ID], [MAQ_CONTROL_IP], [GMA_ID], [MAQ_ULTIMA_ATUALIZACAO], [MAQ_SIRENE_SEMAFORO], [MAQ_COR_SEMAFORO], [MAQ_ID_MAQ_PAI], [MAQ_TIPO_CONTADOR], [MAQ_TIPO_PLANEJAMENTO], [MAQ_AVALIA_CUSTO], [FPR_ID_OP_PRODUZINDO], [MAQ_CONGELA_FILA], [MAQ_TEMPO_MIN_PARADA], [MAQ_QTD_CORES], [MAQ_ID_INTEGRACAO], [MAQ_ID_INTEGRACAO_ERP], [MAQ_HIERARQUIA_SEQ_TRANSFORMACAO], [EQU_ID], [MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR], [MAQ_ACOMPANHA_LOTE_PILOTO], [MAQ_ID_SENSOR], [MAQ_DEBOUNCING_LOW], [MAQ_DEBOUNCING_HIGHT], [MAQ_TIPO_SINAL], [TEM_ID], [MAQ_COMPRIMENTO_CHAPA_DE], [MAQ_COMPRIMENTO_CHAPA_ATE], [MAQ_LARGURA_CHAPA_DE], [MAQ_LARGURA_CHAPA_ATE], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR], [MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR], [MAQ_COMPRIMENTO_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_ENTRE_VINCO_ATE], [MAQ_LARGURA_ENTRE_VINCO_DE], [MAQ_LARGURA_ENTRE_VINCO_ATE], [MAQ_ALTURA_ENTRE_VINCO_DE], [MAQ_ALTURA_ENTRE_VINCO_ATE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE], [MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE], [MAQ_ABA_DE], [MAQ_ABA_ATE], [MAQ_LAP_DE], [MAQ_LAP_ATE], [MAQ_ONDAS], [MAQ_PROLONGA_LAP], [MAQ_LARGURA_IMPRESSAO], [MAQ_COMPRIMENTO_IMPRESSAO], [MAQ_ROLO_DISPOSITIVO_DE], [MAQ_ROLO_DISPOSITIVO_ATE], [MAQ_FAMILIAS], [MAQ_REFILE_MINIMO], [MAQ_LARGURA_UTIL], [MAQ_TOTAL_ACO], [MAQ_FECHAMENTO], [MAQ_OPERACAO_VINCAR], [MAQ_OPERACAO_MONTA_DIVISAO], [MAQ_OPERACAO_SERRAR], [MAQ_TIPO_LAP], [MAQ_INDICE_PARADAS_POR_OP], [MAQ_PERDA_MAXIMA], [MAQ_TOTAL_PECAS_REFILANDO], [MAQ_TOTAL_PECAS_NAO_REFILANDO], [MAQ_TOTAL_VINCOS] FROM [Maquina] ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["MAQ_TOTAL_VINCOS"] = value; //06
                      whereClauses.Add($" [MAQ_TOTAL_VINCOS] = @MAQ_TOTAL_VINCOS ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration