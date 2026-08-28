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
    public class CargaQueryRead : QueryBase, ICargaQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public CargaQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel CargaQuery(Command.Read.CargaReadCommand Command )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select Id, CAR_ID, CAR_PREVISAO_MATERIA_PRIMA, CAR_DATA_INICIO_PREVISTO, CAR_DATA_INICIO_REALIZADO, CAR_DATA_FIM_PREVISTO, CAR_DATA_FIM_REALIZADO, CAR_INICIO_JANELA_EMBARQUE, CAR_FIM_JANELA_EMBARQUE, CAR_EMBARQUE_ALVO, CAR_STATUS, CAR_PESO_TEORICO, CAR_VOLUME_TEORICO, CAR_PESO_REAL, CAR_VOLUME_REAL, CAR_PESO_EMBALAGEM, CAR_PESO_ENTRADA, CAR_PESO_SAIDA, CAR_ID_DOCA, VEI_PLACA, TIP_ID, TRA_ID, CAR_GRUPO_PRODUTIVO, ROT_ID, CAR_OBSERVACAO_DE_TRANSPORTE, CAR_JUSTIFICATIVA_DE_CARREGAMENTO, OCO_ID, CAR_ID_JUNTADA, CAR_OBSERVACAO_OTIMIZADOR, CAR_ID_INTEGRACAO_BALANCA, CAR_PESAGEM_LIBERADA, CAR_OBS_LIERACAO, OCO_ID_LIERACAO, CAR_DATA_ENTRADA_VEICULO, CAR_DATA_SAIDA_VEICULO, CAR_DATA_ROMANEIO_CONSOLIDADO, CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO, CAR_DIFERENCA_PESAGEM, CAR_DATA_AGENCIAMENTO, TURN_ID, TURM_ID, TenantID, Deleted, Changed, UserId from Carga ";
if (Command.Id.HasValue) dict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"Id = @Id");
if (!string.IsNullOrEmpty(Command.CAR_ID)) dict["CAR_ID"] = $"%{Command.CAR_ID}%";
if (!string.IsNullOrEmpty(Command.CAR_ID)) whereClauses.Add($"CAR_ID like @CAR_ID");
if (!string.IsNullOrEmpty(Command.CAR_ID_DOCA)) dict["CAR_ID_DOCA"] = $"%{Command.CAR_ID_DOCA}%";
if (!string.IsNullOrEmpty(Command.CAR_ID_DOCA)) whereClauses.Add($"CAR_ID_DOCA like @CAR_ID_DOCA");
if (!string.IsNullOrEmpty(Command.VEI_PLACA)) dict["VEI_PLACA"] = $"%{Command.VEI_PLACA}%";
if (!string.IsNullOrEmpty(Command.VEI_PLACA)) whereClauses.Add($"VEI_PLACA like @VEI_PLACA");
if (Command.TIP_ID.HasValue) dict["TIP_ID"] = Command.TIP_ID.Value;
if (Command.TIP_ID.HasValue) whereClauses.Add($"TIP_ID = @TIP_ID");
if (!string.IsNullOrEmpty(Command.TRA_ID)) dict["TRA_ID"] = $"%{Command.TRA_ID}%";
if (!string.IsNullOrEmpty(Command.TRA_ID)) whereClauses.Add($"TRA_ID like @TRA_ID");
if (!string.IsNullOrEmpty(Command.ROT_ID)) dict["ROT_ID"] = $"%{Command.ROT_ID}%";
if (!string.IsNullOrEmpty(Command.ROT_ID)) whereClauses.Add($"ROT_ID like @ROT_ID");
if (!string.IsNullOrEmpty(Command.CAR_OBSERVACAO_DE_TRANSPORTE)) dict["CAR_OBSERVACAO_DE_TRANSPORTE"] = $"%{Command.CAR_OBSERVACAO_DE_TRANSPORTE}%";
if (!string.IsNullOrEmpty(Command.CAR_OBSERVACAO_DE_TRANSPORTE)) whereClauses.Add($"CAR_OBSERVACAO_DE_TRANSPORTE like @CAR_OBSERVACAO_DE_TRANSPORTE");
if (!string.IsNullOrEmpty(Command.CAR_JUSTIFICATIVA_DE_CARREGAMENTO)) dict["CAR_JUSTIFICATIVA_DE_CARREGAMENTO"] = $"%{Command.CAR_JUSTIFICATIVA_DE_CARREGAMENTO}%";
if (!string.IsNullOrEmpty(Command.CAR_JUSTIFICATIVA_DE_CARREGAMENTO)) whereClauses.Add($"CAR_JUSTIFICATIVA_DE_CARREGAMENTO like @CAR_JUSTIFICATIVA_DE_CARREGAMENTO");
if (!string.IsNullOrEmpty(Command.OCO_ID)) dict["OCO_ID"] = $"%{Command.OCO_ID}%";
if (!string.IsNullOrEmpty(Command.OCO_ID)) whereClauses.Add($"OCO_ID like @OCO_ID");
if (!string.IsNullOrEmpty(Command.CAR_ID_JUNTADA)) dict["CAR_ID_JUNTADA"] = $"%{Command.CAR_ID_JUNTADA}%";
if (!string.IsNullOrEmpty(Command.CAR_ID_JUNTADA)) whereClauses.Add($"CAR_ID_JUNTADA like @CAR_ID_JUNTADA");
if (!string.IsNullOrEmpty(Command.CAR_OBSERVACAO_OTIMIZADOR)) dict["CAR_OBSERVACAO_OTIMIZADOR"] = $"%{Command.CAR_OBSERVACAO_OTIMIZADOR}%";
if (!string.IsNullOrEmpty(Command.CAR_OBSERVACAO_OTIMIZADOR)) whereClauses.Add($"CAR_OBSERVACAO_OTIMIZADOR like @CAR_OBSERVACAO_OTIMIZADOR");
if (!string.IsNullOrEmpty(Command.CAR_ID_INTEGRACAO_BALANCA)) dict["CAR_ID_INTEGRACAO_BALANCA"] = $"%{Command.CAR_ID_INTEGRACAO_BALANCA}%";
if (!string.IsNullOrEmpty(Command.CAR_ID_INTEGRACAO_BALANCA)) whereClauses.Add($"CAR_ID_INTEGRACAO_BALANCA like @CAR_ID_INTEGRACAO_BALANCA");
if (!string.IsNullOrEmpty(Command.CAR_PESAGEM_LIBERADA)) dict["CAR_PESAGEM_LIBERADA"] = $"%{Command.CAR_PESAGEM_LIBERADA}%";
if (!string.IsNullOrEmpty(Command.CAR_PESAGEM_LIBERADA)) whereClauses.Add($"CAR_PESAGEM_LIBERADA like @CAR_PESAGEM_LIBERADA");
if (!string.IsNullOrEmpty(Command.CAR_OBS_LIERACAO)) dict["CAR_OBS_LIERACAO"] = $"%{Command.CAR_OBS_LIERACAO}%";
if (!string.IsNullOrEmpty(Command.CAR_OBS_LIERACAO)) whereClauses.Add($"CAR_OBS_LIERACAO like @CAR_OBS_LIERACAO");
if (!string.IsNullOrEmpty(Command.OCO_ID_LIERACAO)) dict["OCO_ID_LIERACAO"] = $"%{Command.OCO_ID_LIERACAO}%";
if (!string.IsNullOrEmpty(Command.OCO_ID_LIERACAO)) whereClauses.Add($"OCO_ID_LIERACAO like @OCO_ID_LIERACAO");
if (!string.IsNullOrEmpty(Command.CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO)) dict["CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO"] = $"%{Command.CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO}%";
if (!string.IsNullOrEmpty(Command.CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO)) whereClauses.Add($"CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO like @CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO");
if (!string.IsNullOrEmpty(Command.TURN_ID)) dict["TURN_ID"] = $"%{Command.TURN_ID}%";
if (!string.IsNullOrEmpty(Command.TURN_ID)) whereClauses.Add($"TURN_ID like @TURN_ID");
if (!string.IsNullOrEmpty(Command.TURM_ID)) dict["TURM_ID"] = $"%{Command.TURM_ID}%";
if (!string.IsNullOrEmpty(Command.TURM_ID)) whereClauses.Add($"TURM_ID like @TURM_ID");
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
        public QueryModel CargaOCO_IDQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel CargaTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel CargaUserIdQuery(Command.Patterns.Command.SearchFKCommand Command )
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
            this.Query = $"SELECT 1 FROM Carga ";
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
        public QueryModel ExistsByCAR_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_ID"] = value; //04
                      whereClauses.Add($" CAR_ID = @CAR_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCAR_PREVISAO_MATERIA_PRIMAQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_PREVISAO_MATERIA_PRIMA"] = value; //04
                      whereClauses.Add($" CAR_PREVISAO_MATERIA_PRIMA = @CAR_PREVISAO_MATERIA_PRIMA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCAR_DATA_INICIO_PREVISTOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_DATA_INICIO_PREVISTO"] = value; //04
                      whereClauses.Add($" CAR_DATA_INICIO_PREVISTO = @CAR_DATA_INICIO_PREVISTO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCAR_DATA_INICIO_REALIZADOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_DATA_INICIO_REALIZADO"] = value; //04
                      whereClauses.Add($" CAR_DATA_INICIO_REALIZADO = @CAR_DATA_INICIO_REALIZADO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCAR_DATA_FIM_PREVISTOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_DATA_FIM_PREVISTO"] = value; //04
                      whereClauses.Add($" CAR_DATA_FIM_PREVISTO = @CAR_DATA_FIM_PREVISTO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCAR_DATA_FIM_REALIZADOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_DATA_FIM_REALIZADO"] = value; //04
                      whereClauses.Add($" CAR_DATA_FIM_REALIZADO = @CAR_DATA_FIM_REALIZADO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCAR_INICIO_JANELA_EMBARQUEQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_INICIO_JANELA_EMBARQUE"] = value; //04
                      whereClauses.Add($" CAR_INICIO_JANELA_EMBARQUE = @CAR_INICIO_JANELA_EMBARQUE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCAR_FIM_JANELA_EMBARQUEQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_FIM_JANELA_EMBARQUE"] = value; //04
                      whereClauses.Add($" CAR_FIM_JANELA_EMBARQUE = @CAR_FIM_JANELA_EMBARQUE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCAR_EMBARQUE_ALVOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_EMBARQUE_ALVO"] = value; //04
                      whereClauses.Add($" CAR_EMBARQUE_ALVO = @CAR_EMBARQUE_ALVO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCAR_STATUSQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_STATUS"] = value; //04
                      whereClauses.Add($" CAR_STATUS = @CAR_STATUS ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCAR_PESO_TEORICOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_PESO_TEORICO"] = value; //04
                      whereClauses.Add($" CAR_PESO_TEORICO = @CAR_PESO_TEORICO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCAR_VOLUME_TEORICOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_VOLUME_TEORICO"] = value; //04
                      whereClauses.Add($" CAR_VOLUME_TEORICO = @CAR_VOLUME_TEORICO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCAR_PESO_REALQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_PESO_REAL"] = value; //04
                      whereClauses.Add($" CAR_PESO_REAL = @CAR_PESO_REAL ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCAR_VOLUME_REALQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_VOLUME_REAL"] = value; //04
                      whereClauses.Add($" CAR_VOLUME_REAL = @CAR_VOLUME_REAL ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCAR_PESO_EMBALAGEMQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_PESO_EMBALAGEM"] = value; //04
                      whereClauses.Add($" CAR_PESO_EMBALAGEM = @CAR_PESO_EMBALAGEM ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCAR_PESO_ENTRADAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_PESO_ENTRADA"] = value; //04
                      whereClauses.Add($" CAR_PESO_ENTRADA = @CAR_PESO_ENTRADA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCAR_PESO_SAIDAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_PESO_SAIDA"] = value; //04
                      whereClauses.Add($" CAR_PESO_SAIDA = @CAR_PESO_SAIDA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCAR_ID_DOCAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_ID_DOCA"] = value; //04
                      whereClauses.Add($" CAR_ID_DOCA = @CAR_ID_DOCA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByVEI_PLACAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["VEI_PLACA"] = value; //04
                      whereClauses.Add($" VEI_PLACA = @VEI_PLACA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTIP_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TIP_ID"] = value; //04
                      whereClauses.Add($" TIP_ID = @TIP_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTRA_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TRA_ID"] = value; //04
                      whereClauses.Add($" TRA_ID = @TRA_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCAR_GRUPO_PRODUTIVOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_GRUPO_PRODUTIVO"] = value; //04
                      whereClauses.Add($" CAR_GRUPO_PRODUTIVO = @CAR_GRUPO_PRODUTIVO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByROT_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ROT_ID"] = value; //04
                      whereClauses.Add($" ROT_ID = @ROT_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCAR_OBSERVACAO_DE_TRANSPORTEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_OBSERVACAO_DE_TRANSPORTE"] = value; //04
                      whereClauses.Add($" CAR_OBSERVACAO_DE_TRANSPORTE = @CAR_OBSERVACAO_DE_TRANSPORTE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCAR_JUSTIFICATIVA_DE_CARREGAMENTOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_JUSTIFICATIVA_DE_CARREGAMENTO"] = value; //04
                      whereClauses.Add($" CAR_JUSTIFICATIVA_DE_CARREGAMENTO = @CAR_JUSTIFICATIVA_DE_CARREGAMENTO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByOCO_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["OCO_ID"] = value; //04
                      whereClauses.Add($" OCO_ID = @OCO_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCAR_ID_JUNTADAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_ID_JUNTADA"] = value; //04
                      whereClauses.Add($" CAR_ID_JUNTADA = @CAR_ID_JUNTADA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCAR_OBSERVACAO_OTIMIZADORQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_OBSERVACAO_OTIMIZADOR"] = value; //04
                      whereClauses.Add($" CAR_OBSERVACAO_OTIMIZADOR = @CAR_OBSERVACAO_OTIMIZADOR ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCAR_ID_INTEGRACAO_BALANCAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_ID_INTEGRACAO_BALANCA"] = value; //04
                      whereClauses.Add($" CAR_ID_INTEGRACAO_BALANCA = @CAR_ID_INTEGRACAO_BALANCA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCAR_PESAGEM_LIBERADAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_PESAGEM_LIBERADA"] = value; //04
                      whereClauses.Add($" CAR_PESAGEM_LIBERADA = @CAR_PESAGEM_LIBERADA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCAR_OBS_LIERACAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_OBS_LIERACAO"] = value; //04
                      whereClauses.Add($" CAR_OBS_LIERACAO = @CAR_OBS_LIERACAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByOCO_ID_LIERACAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["OCO_ID_LIERACAO"] = value; //04
                      whereClauses.Add($" OCO_ID_LIERACAO = @OCO_ID_LIERACAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCAR_DATA_ENTRADA_VEICULOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_DATA_ENTRADA_VEICULO"] = value; //04
                      whereClauses.Add($" CAR_DATA_ENTRADA_VEICULO = @CAR_DATA_ENTRADA_VEICULO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCAR_DATA_SAIDA_VEICULOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_DATA_SAIDA_VEICULO"] = value; //04
                      whereClauses.Add($" CAR_DATA_SAIDA_VEICULO = @CAR_DATA_SAIDA_VEICULO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCAR_DATA_ROMANEIO_CONSOLIDADOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_DATA_ROMANEIO_CONSOLIDADO"] = value; //04
                      whereClauses.Add($" CAR_DATA_ROMANEIO_CONSOLIDADO = @CAR_DATA_ROMANEIO_CONSOLIDADO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCAR_DIA_TURMA_ROMANEIO_CONSOLIDADOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO"] = value; //04
                      whereClauses.Add($" CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO = @CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCAR_DIFERENCA_PESAGEMQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_DIFERENCA_PESAGEM"] = value; //04
                      whereClauses.Add($" CAR_DIFERENCA_PESAGEM = @CAR_DIFERENCA_PESAGEM ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCAR_DATA_AGENCIAMENTOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_DATA_AGENCIAMENTO"] = value; //04
                      whereClauses.Add($" CAR_DATA_AGENCIAMENTO = @CAR_DATA_AGENCIAMENTO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTURN_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TURN_ID"] = value; //04
                      whereClauses.Add($" TURN_ID = @TURN_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTURM_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TURM_ID"] = value; //04
                      whereClauses.Add($" TURM_ID = @TURM_ID ");//04
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
            this.Query = $"SELECT 1 FROM Carga ";
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
            this.Query = $"SELECT 1 FROM Carga ";
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
            this.Query = $"SELECT 1 FROM Carga ";
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
            this.Query = $"SELECT 1 FROM Carga ";
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
            this.Query = $"SELECT Id, CAR_ID, CAR_PREVISAO_MATERIA_PRIMA, CAR_DATA_INICIO_PREVISTO, CAR_DATA_INICIO_REALIZADO, CAR_DATA_FIM_PREVISTO, CAR_DATA_FIM_REALIZADO, CAR_INICIO_JANELA_EMBARQUE, CAR_FIM_JANELA_EMBARQUE, CAR_EMBARQUE_ALVO, CAR_STATUS, CAR_PESO_TEORICO, CAR_VOLUME_TEORICO, CAR_PESO_REAL, CAR_VOLUME_REAL, CAR_PESO_EMBALAGEM, CAR_PESO_ENTRADA, CAR_PESO_SAIDA, CAR_ID_DOCA, VEI_PLACA, TIP_ID, TRA_ID, CAR_GRUPO_PRODUTIVO, ROT_ID, CAR_OBSERVACAO_DE_TRANSPORTE, CAR_JUSTIFICATIVA_DE_CARREGAMENTO, OCO_ID, CAR_ID_JUNTADA, CAR_OBSERVACAO_OTIMIZADOR, CAR_ID_INTEGRACAO_BALANCA, CAR_PESAGEM_LIBERADA, CAR_OBS_LIERACAO, OCO_ID_LIERACAO, CAR_DATA_ENTRADA_VEICULO, CAR_DATA_SAIDA_VEICULO, CAR_DATA_ROMANEIO_CONSOLIDADO, CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO, CAR_DIFERENCA_PESAGEM, CAR_DATA_AGENCIAMENTO, TURN_ID, TURM_ID, TenantID, Deleted, Changed, UserId FROM Carga ";
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
        public QueryModel FirstByCAR_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, CAR_ID, CAR_PREVISAO_MATERIA_PRIMA, CAR_DATA_INICIO_PREVISTO, CAR_DATA_INICIO_REALIZADO, CAR_DATA_FIM_PREVISTO, CAR_DATA_FIM_REALIZADO, CAR_INICIO_JANELA_EMBARQUE, CAR_FIM_JANELA_EMBARQUE, CAR_EMBARQUE_ALVO, CAR_STATUS, CAR_PESO_TEORICO, CAR_VOLUME_TEORICO, CAR_PESO_REAL, CAR_VOLUME_REAL, CAR_PESO_EMBALAGEM, CAR_PESO_ENTRADA, CAR_PESO_SAIDA, CAR_ID_DOCA, VEI_PLACA, TIP_ID, TRA_ID, CAR_GRUPO_PRODUTIVO, ROT_ID, CAR_OBSERVACAO_DE_TRANSPORTE, CAR_JUSTIFICATIVA_DE_CARREGAMENTO, OCO_ID, CAR_ID_JUNTADA, CAR_OBSERVACAO_OTIMIZADOR, CAR_ID_INTEGRACAO_BALANCA, CAR_PESAGEM_LIBERADA, CAR_OBS_LIERACAO, OCO_ID_LIERACAO, CAR_DATA_ENTRADA_VEICULO, CAR_DATA_SAIDA_VEICULO, CAR_DATA_ROMANEIO_CONSOLIDADO, CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO, CAR_DIFERENCA_PESAGEM, CAR_DATA_AGENCIAMENTO, TURN_ID, TURM_ID, TenantID, Deleted, Changed, UserId FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_ID"] = value; //06
                      whereClauses.Add($" CAR_ID = @CAR_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCAR_PREVISAO_MATERIA_PRIMAQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, CAR_ID, CAR_PREVISAO_MATERIA_PRIMA, CAR_DATA_INICIO_PREVISTO, CAR_DATA_INICIO_REALIZADO, CAR_DATA_FIM_PREVISTO, CAR_DATA_FIM_REALIZADO, CAR_INICIO_JANELA_EMBARQUE, CAR_FIM_JANELA_EMBARQUE, CAR_EMBARQUE_ALVO, CAR_STATUS, CAR_PESO_TEORICO, CAR_VOLUME_TEORICO, CAR_PESO_REAL, CAR_VOLUME_REAL, CAR_PESO_EMBALAGEM, CAR_PESO_ENTRADA, CAR_PESO_SAIDA, CAR_ID_DOCA, VEI_PLACA, TIP_ID, TRA_ID, CAR_GRUPO_PRODUTIVO, ROT_ID, CAR_OBSERVACAO_DE_TRANSPORTE, CAR_JUSTIFICATIVA_DE_CARREGAMENTO, OCO_ID, CAR_ID_JUNTADA, CAR_OBSERVACAO_OTIMIZADOR, CAR_ID_INTEGRACAO_BALANCA, CAR_PESAGEM_LIBERADA, CAR_OBS_LIERACAO, OCO_ID_LIERACAO, CAR_DATA_ENTRADA_VEICULO, CAR_DATA_SAIDA_VEICULO, CAR_DATA_ROMANEIO_CONSOLIDADO, CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO, CAR_DIFERENCA_PESAGEM, CAR_DATA_AGENCIAMENTO, TURN_ID, TURM_ID, TenantID, Deleted, Changed, UserId FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_PREVISAO_MATERIA_PRIMA"] = value; //06
                      whereClauses.Add($" CAR_PREVISAO_MATERIA_PRIMA = @CAR_PREVISAO_MATERIA_PRIMA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCAR_DATA_INICIO_PREVISTOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, CAR_ID, CAR_PREVISAO_MATERIA_PRIMA, CAR_DATA_INICIO_PREVISTO, CAR_DATA_INICIO_REALIZADO, CAR_DATA_FIM_PREVISTO, CAR_DATA_FIM_REALIZADO, CAR_INICIO_JANELA_EMBARQUE, CAR_FIM_JANELA_EMBARQUE, CAR_EMBARQUE_ALVO, CAR_STATUS, CAR_PESO_TEORICO, CAR_VOLUME_TEORICO, CAR_PESO_REAL, CAR_VOLUME_REAL, CAR_PESO_EMBALAGEM, CAR_PESO_ENTRADA, CAR_PESO_SAIDA, CAR_ID_DOCA, VEI_PLACA, TIP_ID, TRA_ID, CAR_GRUPO_PRODUTIVO, ROT_ID, CAR_OBSERVACAO_DE_TRANSPORTE, CAR_JUSTIFICATIVA_DE_CARREGAMENTO, OCO_ID, CAR_ID_JUNTADA, CAR_OBSERVACAO_OTIMIZADOR, CAR_ID_INTEGRACAO_BALANCA, CAR_PESAGEM_LIBERADA, CAR_OBS_LIERACAO, OCO_ID_LIERACAO, CAR_DATA_ENTRADA_VEICULO, CAR_DATA_SAIDA_VEICULO, CAR_DATA_ROMANEIO_CONSOLIDADO, CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO, CAR_DIFERENCA_PESAGEM, CAR_DATA_AGENCIAMENTO, TURN_ID, TURM_ID, TenantID, Deleted, Changed, UserId FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_DATA_INICIO_PREVISTO"] = value; //06
                      whereClauses.Add($" CAR_DATA_INICIO_PREVISTO = @CAR_DATA_INICIO_PREVISTO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCAR_DATA_INICIO_REALIZADOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, CAR_ID, CAR_PREVISAO_MATERIA_PRIMA, CAR_DATA_INICIO_PREVISTO, CAR_DATA_INICIO_REALIZADO, CAR_DATA_FIM_PREVISTO, CAR_DATA_FIM_REALIZADO, CAR_INICIO_JANELA_EMBARQUE, CAR_FIM_JANELA_EMBARQUE, CAR_EMBARQUE_ALVO, CAR_STATUS, CAR_PESO_TEORICO, CAR_VOLUME_TEORICO, CAR_PESO_REAL, CAR_VOLUME_REAL, CAR_PESO_EMBALAGEM, CAR_PESO_ENTRADA, CAR_PESO_SAIDA, CAR_ID_DOCA, VEI_PLACA, TIP_ID, TRA_ID, CAR_GRUPO_PRODUTIVO, ROT_ID, CAR_OBSERVACAO_DE_TRANSPORTE, CAR_JUSTIFICATIVA_DE_CARREGAMENTO, OCO_ID, CAR_ID_JUNTADA, CAR_OBSERVACAO_OTIMIZADOR, CAR_ID_INTEGRACAO_BALANCA, CAR_PESAGEM_LIBERADA, CAR_OBS_LIERACAO, OCO_ID_LIERACAO, CAR_DATA_ENTRADA_VEICULO, CAR_DATA_SAIDA_VEICULO, CAR_DATA_ROMANEIO_CONSOLIDADO, CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO, CAR_DIFERENCA_PESAGEM, CAR_DATA_AGENCIAMENTO, TURN_ID, TURM_ID, TenantID, Deleted, Changed, UserId FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_DATA_INICIO_REALIZADO"] = value; //06
                      whereClauses.Add($" CAR_DATA_INICIO_REALIZADO = @CAR_DATA_INICIO_REALIZADO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCAR_DATA_FIM_PREVISTOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, CAR_ID, CAR_PREVISAO_MATERIA_PRIMA, CAR_DATA_INICIO_PREVISTO, CAR_DATA_INICIO_REALIZADO, CAR_DATA_FIM_PREVISTO, CAR_DATA_FIM_REALIZADO, CAR_INICIO_JANELA_EMBARQUE, CAR_FIM_JANELA_EMBARQUE, CAR_EMBARQUE_ALVO, CAR_STATUS, CAR_PESO_TEORICO, CAR_VOLUME_TEORICO, CAR_PESO_REAL, CAR_VOLUME_REAL, CAR_PESO_EMBALAGEM, CAR_PESO_ENTRADA, CAR_PESO_SAIDA, CAR_ID_DOCA, VEI_PLACA, TIP_ID, TRA_ID, CAR_GRUPO_PRODUTIVO, ROT_ID, CAR_OBSERVACAO_DE_TRANSPORTE, CAR_JUSTIFICATIVA_DE_CARREGAMENTO, OCO_ID, CAR_ID_JUNTADA, CAR_OBSERVACAO_OTIMIZADOR, CAR_ID_INTEGRACAO_BALANCA, CAR_PESAGEM_LIBERADA, CAR_OBS_LIERACAO, OCO_ID_LIERACAO, CAR_DATA_ENTRADA_VEICULO, CAR_DATA_SAIDA_VEICULO, CAR_DATA_ROMANEIO_CONSOLIDADO, CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO, CAR_DIFERENCA_PESAGEM, CAR_DATA_AGENCIAMENTO, TURN_ID, TURM_ID, TenantID, Deleted, Changed, UserId FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_DATA_FIM_PREVISTO"] = value; //06
                      whereClauses.Add($" CAR_DATA_FIM_PREVISTO = @CAR_DATA_FIM_PREVISTO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCAR_DATA_FIM_REALIZADOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, CAR_ID, CAR_PREVISAO_MATERIA_PRIMA, CAR_DATA_INICIO_PREVISTO, CAR_DATA_INICIO_REALIZADO, CAR_DATA_FIM_PREVISTO, CAR_DATA_FIM_REALIZADO, CAR_INICIO_JANELA_EMBARQUE, CAR_FIM_JANELA_EMBARQUE, CAR_EMBARQUE_ALVO, CAR_STATUS, CAR_PESO_TEORICO, CAR_VOLUME_TEORICO, CAR_PESO_REAL, CAR_VOLUME_REAL, CAR_PESO_EMBALAGEM, CAR_PESO_ENTRADA, CAR_PESO_SAIDA, CAR_ID_DOCA, VEI_PLACA, TIP_ID, TRA_ID, CAR_GRUPO_PRODUTIVO, ROT_ID, CAR_OBSERVACAO_DE_TRANSPORTE, CAR_JUSTIFICATIVA_DE_CARREGAMENTO, OCO_ID, CAR_ID_JUNTADA, CAR_OBSERVACAO_OTIMIZADOR, CAR_ID_INTEGRACAO_BALANCA, CAR_PESAGEM_LIBERADA, CAR_OBS_LIERACAO, OCO_ID_LIERACAO, CAR_DATA_ENTRADA_VEICULO, CAR_DATA_SAIDA_VEICULO, CAR_DATA_ROMANEIO_CONSOLIDADO, CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO, CAR_DIFERENCA_PESAGEM, CAR_DATA_AGENCIAMENTO, TURN_ID, TURM_ID, TenantID, Deleted, Changed, UserId FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_DATA_FIM_REALIZADO"] = value; //06
                      whereClauses.Add($" CAR_DATA_FIM_REALIZADO = @CAR_DATA_FIM_REALIZADO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCAR_INICIO_JANELA_EMBARQUEQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, CAR_ID, CAR_PREVISAO_MATERIA_PRIMA, CAR_DATA_INICIO_PREVISTO, CAR_DATA_INICIO_REALIZADO, CAR_DATA_FIM_PREVISTO, CAR_DATA_FIM_REALIZADO, CAR_INICIO_JANELA_EMBARQUE, CAR_FIM_JANELA_EMBARQUE, CAR_EMBARQUE_ALVO, CAR_STATUS, CAR_PESO_TEORICO, CAR_VOLUME_TEORICO, CAR_PESO_REAL, CAR_VOLUME_REAL, CAR_PESO_EMBALAGEM, CAR_PESO_ENTRADA, CAR_PESO_SAIDA, CAR_ID_DOCA, VEI_PLACA, TIP_ID, TRA_ID, CAR_GRUPO_PRODUTIVO, ROT_ID, CAR_OBSERVACAO_DE_TRANSPORTE, CAR_JUSTIFICATIVA_DE_CARREGAMENTO, OCO_ID, CAR_ID_JUNTADA, CAR_OBSERVACAO_OTIMIZADOR, CAR_ID_INTEGRACAO_BALANCA, CAR_PESAGEM_LIBERADA, CAR_OBS_LIERACAO, OCO_ID_LIERACAO, CAR_DATA_ENTRADA_VEICULO, CAR_DATA_SAIDA_VEICULO, CAR_DATA_ROMANEIO_CONSOLIDADO, CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO, CAR_DIFERENCA_PESAGEM, CAR_DATA_AGENCIAMENTO, TURN_ID, TURM_ID, TenantID, Deleted, Changed, UserId FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_INICIO_JANELA_EMBARQUE"] = value; //06
                      whereClauses.Add($" CAR_INICIO_JANELA_EMBARQUE = @CAR_INICIO_JANELA_EMBARQUE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCAR_FIM_JANELA_EMBARQUEQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, CAR_ID, CAR_PREVISAO_MATERIA_PRIMA, CAR_DATA_INICIO_PREVISTO, CAR_DATA_INICIO_REALIZADO, CAR_DATA_FIM_PREVISTO, CAR_DATA_FIM_REALIZADO, CAR_INICIO_JANELA_EMBARQUE, CAR_FIM_JANELA_EMBARQUE, CAR_EMBARQUE_ALVO, CAR_STATUS, CAR_PESO_TEORICO, CAR_VOLUME_TEORICO, CAR_PESO_REAL, CAR_VOLUME_REAL, CAR_PESO_EMBALAGEM, CAR_PESO_ENTRADA, CAR_PESO_SAIDA, CAR_ID_DOCA, VEI_PLACA, TIP_ID, TRA_ID, CAR_GRUPO_PRODUTIVO, ROT_ID, CAR_OBSERVACAO_DE_TRANSPORTE, CAR_JUSTIFICATIVA_DE_CARREGAMENTO, OCO_ID, CAR_ID_JUNTADA, CAR_OBSERVACAO_OTIMIZADOR, CAR_ID_INTEGRACAO_BALANCA, CAR_PESAGEM_LIBERADA, CAR_OBS_LIERACAO, OCO_ID_LIERACAO, CAR_DATA_ENTRADA_VEICULO, CAR_DATA_SAIDA_VEICULO, CAR_DATA_ROMANEIO_CONSOLIDADO, CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO, CAR_DIFERENCA_PESAGEM, CAR_DATA_AGENCIAMENTO, TURN_ID, TURM_ID, TenantID, Deleted, Changed, UserId FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_FIM_JANELA_EMBARQUE"] = value; //06
                      whereClauses.Add($" CAR_FIM_JANELA_EMBARQUE = @CAR_FIM_JANELA_EMBARQUE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCAR_EMBARQUE_ALVOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, CAR_ID, CAR_PREVISAO_MATERIA_PRIMA, CAR_DATA_INICIO_PREVISTO, CAR_DATA_INICIO_REALIZADO, CAR_DATA_FIM_PREVISTO, CAR_DATA_FIM_REALIZADO, CAR_INICIO_JANELA_EMBARQUE, CAR_FIM_JANELA_EMBARQUE, CAR_EMBARQUE_ALVO, CAR_STATUS, CAR_PESO_TEORICO, CAR_VOLUME_TEORICO, CAR_PESO_REAL, CAR_VOLUME_REAL, CAR_PESO_EMBALAGEM, CAR_PESO_ENTRADA, CAR_PESO_SAIDA, CAR_ID_DOCA, VEI_PLACA, TIP_ID, TRA_ID, CAR_GRUPO_PRODUTIVO, ROT_ID, CAR_OBSERVACAO_DE_TRANSPORTE, CAR_JUSTIFICATIVA_DE_CARREGAMENTO, OCO_ID, CAR_ID_JUNTADA, CAR_OBSERVACAO_OTIMIZADOR, CAR_ID_INTEGRACAO_BALANCA, CAR_PESAGEM_LIBERADA, CAR_OBS_LIERACAO, OCO_ID_LIERACAO, CAR_DATA_ENTRADA_VEICULO, CAR_DATA_SAIDA_VEICULO, CAR_DATA_ROMANEIO_CONSOLIDADO, CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO, CAR_DIFERENCA_PESAGEM, CAR_DATA_AGENCIAMENTO, TURN_ID, TURM_ID, TenantID, Deleted, Changed, UserId FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_EMBARQUE_ALVO"] = value; //06
                      whereClauses.Add($" CAR_EMBARQUE_ALVO = @CAR_EMBARQUE_ALVO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCAR_STATUSQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, CAR_ID, CAR_PREVISAO_MATERIA_PRIMA, CAR_DATA_INICIO_PREVISTO, CAR_DATA_INICIO_REALIZADO, CAR_DATA_FIM_PREVISTO, CAR_DATA_FIM_REALIZADO, CAR_INICIO_JANELA_EMBARQUE, CAR_FIM_JANELA_EMBARQUE, CAR_EMBARQUE_ALVO, CAR_STATUS, CAR_PESO_TEORICO, CAR_VOLUME_TEORICO, CAR_PESO_REAL, CAR_VOLUME_REAL, CAR_PESO_EMBALAGEM, CAR_PESO_ENTRADA, CAR_PESO_SAIDA, CAR_ID_DOCA, VEI_PLACA, TIP_ID, TRA_ID, CAR_GRUPO_PRODUTIVO, ROT_ID, CAR_OBSERVACAO_DE_TRANSPORTE, CAR_JUSTIFICATIVA_DE_CARREGAMENTO, OCO_ID, CAR_ID_JUNTADA, CAR_OBSERVACAO_OTIMIZADOR, CAR_ID_INTEGRACAO_BALANCA, CAR_PESAGEM_LIBERADA, CAR_OBS_LIERACAO, OCO_ID_LIERACAO, CAR_DATA_ENTRADA_VEICULO, CAR_DATA_SAIDA_VEICULO, CAR_DATA_ROMANEIO_CONSOLIDADO, CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO, CAR_DIFERENCA_PESAGEM, CAR_DATA_AGENCIAMENTO, TURN_ID, TURM_ID, TenantID, Deleted, Changed, UserId FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_STATUS"] = value; //06
                      whereClauses.Add($" CAR_STATUS = @CAR_STATUS ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCAR_PESO_TEORICOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, CAR_ID, CAR_PREVISAO_MATERIA_PRIMA, CAR_DATA_INICIO_PREVISTO, CAR_DATA_INICIO_REALIZADO, CAR_DATA_FIM_PREVISTO, CAR_DATA_FIM_REALIZADO, CAR_INICIO_JANELA_EMBARQUE, CAR_FIM_JANELA_EMBARQUE, CAR_EMBARQUE_ALVO, CAR_STATUS, CAR_PESO_TEORICO, CAR_VOLUME_TEORICO, CAR_PESO_REAL, CAR_VOLUME_REAL, CAR_PESO_EMBALAGEM, CAR_PESO_ENTRADA, CAR_PESO_SAIDA, CAR_ID_DOCA, VEI_PLACA, TIP_ID, TRA_ID, CAR_GRUPO_PRODUTIVO, ROT_ID, CAR_OBSERVACAO_DE_TRANSPORTE, CAR_JUSTIFICATIVA_DE_CARREGAMENTO, OCO_ID, CAR_ID_JUNTADA, CAR_OBSERVACAO_OTIMIZADOR, CAR_ID_INTEGRACAO_BALANCA, CAR_PESAGEM_LIBERADA, CAR_OBS_LIERACAO, OCO_ID_LIERACAO, CAR_DATA_ENTRADA_VEICULO, CAR_DATA_SAIDA_VEICULO, CAR_DATA_ROMANEIO_CONSOLIDADO, CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO, CAR_DIFERENCA_PESAGEM, CAR_DATA_AGENCIAMENTO, TURN_ID, TURM_ID, TenantID, Deleted, Changed, UserId FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_PESO_TEORICO"] = value; //06
                      whereClauses.Add($" CAR_PESO_TEORICO = @CAR_PESO_TEORICO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCAR_VOLUME_TEORICOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, CAR_ID, CAR_PREVISAO_MATERIA_PRIMA, CAR_DATA_INICIO_PREVISTO, CAR_DATA_INICIO_REALIZADO, CAR_DATA_FIM_PREVISTO, CAR_DATA_FIM_REALIZADO, CAR_INICIO_JANELA_EMBARQUE, CAR_FIM_JANELA_EMBARQUE, CAR_EMBARQUE_ALVO, CAR_STATUS, CAR_PESO_TEORICO, CAR_VOLUME_TEORICO, CAR_PESO_REAL, CAR_VOLUME_REAL, CAR_PESO_EMBALAGEM, CAR_PESO_ENTRADA, CAR_PESO_SAIDA, CAR_ID_DOCA, VEI_PLACA, TIP_ID, TRA_ID, CAR_GRUPO_PRODUTIVO, ROT_ID, CAR_OBSERVACAO_DE_TRANSPORTE, CAR_JUSTIFICATIVA_DE_CARREGAMENTO, OCO_ID, CAR_ID_JUNTADA, CAR_OBSERVACAO_OTIMIZADOR, CAR_ID_INTEGRACAO_BALANCA, CAR_PESAGEM_LIBERADA, CAR_OBS_LIERACAO, OCO_ID_LIERACAO, CAR_DATA_ENTRADA_VEICULO, CAR_DATA_SAIDA_VEICULO, CAR_DATA_ROMANEIO_CONSOLIDADO, CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO, CAR_DIFERENCA_PESAGEM, CAR_DATA_AGENCIAMENTO, TURN_ID, TURM_ID, TenantID, Deleted, Changed, UserId FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_VOLUME_TEORICO"] = value; //06
                      whereClauses.Add($" CAR_VOLUME_TEORICO = @CAR_VOLUME_TEORICO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCAR_PESO_REALQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, CAR_ID, CAR_PREVISAO_MATERIA_PRIMA, CAR_DATA_INICIO_PREVISTO, CAR_DATA_INICIO_REALIZADO, CAR_DATA_FIM_PREVISTO, CAR_DATA_FIM_REALIZADO, CAR_INICIO_JANELA_EMBARQUE, CAR_FIM_JANELA_EMBARQUE, CAR_EMBARQUE_ALVO, CAR_STATUS, CAR_PESO_TEORICO, CAR_VOLUME_TEORICO, CAR_PESO_REAL, CAR_VOLUME_REAL, CAR_PESO_EMBALAGEM, CAR_PESO_ENTRADA, CAR_PESO_SAIDA, CAR_ID_DOCA, VEI_PLACA, TIP_ID, TRA_ID, CAR_GRUPO_PRODUTIVO, ROT_ID, CAR_OBSERVACAO_DE_TRANSPORTE, CAR_JUSTIFICATIVA_DE_CARREGAMENTO, OCO_ID, CAR_ID_JUNTADA, CAR_OBSERVACAO_OTIMIZADOR, CAR_ID_INTEGRACAO_BALANCA, CAR_PESAGEM_LIBERADA, CAR_OBS_LIERACAO, OCO_ID_LIERACAO, CAR_DATA_ENTRADA_VEICULO, CAR_DATA_SAIDA_VEICULO, CAR_DATA_ROMANEIO_CONSOLIDADO, CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO, CAR_DIFERENCA_PESAGEM, CAR_DATA_AGENCIAMENTO, TURN_ID, TURM_ID, TenantID, Deleted, Changed, UserId FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_PESO_REAL"] = value; //06
                      whereClauses.Add($" CAR_PESO_REAL = @CAR_PESO_REAL ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCAR_VOLUME_REALQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, CAR_ID, CAR_PREVISAO_MATERIA_PRIMA, CAR_DATA_INICIO_PREVISTO, CAR_DATA_INICIO_REALIZADO, CAR_DATA_FIM_PREVISTO, CAR_DATA_FIM_REALIZADO, CAR_INICIO_JANELA_EMBARQUE, CAR_FIM_JANELA_EMBARQUE, CAR_EMBARQUE_ALVO, CAR_STATUS, CAR_PESO_TEORICO, CAR_VOLUME_TEORICO, CAR_PESO_REAL, CAR_VOLUME_REAL, CAR_PESO_EMBALAGEM, CAR_PESO_ENTRADA, CAR_PESO_SAIDA, CAR_ID_DOCA, VEI_PLACA, TIP_ID, TRA_ID, CAR_GRUPO_PRODUTIVO, ROT_ID, CAR_OBSERVACAO_DE_TRANSPORTE, CAR_JUSTIFICATIVA_DE_CARREGAMENTO, OCO_ID, CAR_ID_JUNTADA, CAR_OBSERVACAO_OTIMIZADOR, CAR_ID_INTEGRACAO_BALANCA, CAR_PESAGEM_LIBERADA, CAR_OBS_LIERACAO, OCO_ID_LIERACAO, CAR_DATA_ENTRADA_VEICULO, CAR_DATA_SAIDA_VEICULO, CAR_DATA_ROMANEIO_CONSOLIDADO, CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO, CAR_DIFERENCA_PESAGEM, CAR_DATA_AGENCIAMENTO, TURN_ID, TURM_ID, TenantID, Deleted, Changed, UserId FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_VOLUME_REAL"] = value; //06
                      whereClauses.Add($" CAR_VOLUME_REAL = @CAR_VOLUME_REAL ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCAR_PESO_EMBALAGEMQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, CAR_ID, CAR_PREVISAO_MATERIA_PRIMA, CAR_DATA_INICIO_PREVISTO, CAR_DATA_INICIO_REALIZADO, CAR_DATA_FIM_PREVISTO, CAR_DATA_FIM_REALIZADO, CAR_INICIO_JANELA_EMBARQUE, CAR_FIM_JANELA_EMBARQUE, CAR_EMBARQUE_ALVO, CAR_STATUS, CAR_PESO_TEORICO, CAR_VOLUME_TEORICO, CAR_PESO_REAL, CAR_VOLUME_REAL, CAR_PESO_EMBALAGEM, CAR_PESO_ENTRADA, CAR_PESO_SAIDA, CAR_ID_DOCA, VEI_PLACA, TIP_ID, TRA_ID, CAR_GRUPO_PRODUTIVO, ROT_ID, CAR_OBSERVACAO_DE_TRANSPORTE, CAR_JUSTIFICATIVA_DE_CARREGAMENTO, OCO_ID, CAR_ID_JUNTADA, CAR_OBSERVACAO_OTIMIZADOR, CAR_ID_INTEGRACAO_BALANCA, CAR_PESAGEM_LIBERADA, CAR_OBS_LIERACAO, OCO_ID_LIERACAO, CAR_DATA_ENTRADA_VEICULO, CAR_DATA_SAIDA_VEICULO, CAR_DATA_ROMANEIO_CONSOLIDADO, CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO, CAR_DIFERENCA_PESAGEM, CAR_DATA_AGENCIAMENTO, TURN_ID, TURM_ID, TenantID, Deleted, Changed, UserId FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_PESO_EMBALAGEM"] = value; //06
                      whereClauses.Add($" CAR_PESO_EMBALAGEM = @CAR_PESO_EMBALAGEM ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCAR_PESO_ENTRADAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, CAR_ID, CAR_PREVISAO_MATERIA_PRIMA, CAR_DATA_INICIO_PREVISTO, CAR_DATA_INICIO_REALIZADO, CAR_DATA_FIM_PREVISTO, CAR_DATA_FIM_REALIZADO, CAR_INICIO_JANELA_EMBARQUE, CAR_FIM_JANELA_EMBARQUE, CAR_EMBARQUE_ALVO, CAR_STATUS, CAR_PESO_TEORICO, CAR_VOLUME_TEORICO, CAR_PESO_REAL, CAR_VOLUME_REAL, CAR_PESO_EMBALAGEM, CAR_PESO_ENTRADA, CAR_PESO_SAIDA, CAR_ID_DOCA, VEI_PLACA, TIP_ID, TRA_ID, CAR_GRUPO_PRODUTIVO, ROT_ID, CAR_OBSERVACAO_DE_TRANSPORTE, CAR_JUSTIFICATIVA_DE_CARREGAMENTO, OCO_ID, CAR_ID_JUNTADA, CAR_OBSERVACAO_OTIMIZADOR, CAR_ID_INTEGRACAO_BALANCA, CAR_PESAGEM_LIBERADA, CAR_OBS_LIERACAO, OCO_ID_LIERACAO, CAR_DATA_ENTRADA_VEICULO, CAR_DATA_SAIDA_VEICULO, CAR_DATA_ROMANEIO_CONSOLIDADO, CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO, CAR_DIFERENCA_PESAGEM, CAR_DATA_AGENCIAMENTO, TURN_ID, TURM_ID, TenantID, Deleted, Changed, UserId FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_PESO_ENTRADA"] = value; //06
                      whereClauses.Add($" CAR_PESO_ENTRADA = @CAR_PESO_ENTRADA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCAR_PESO_SAIDAQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, CAR_ID, CAR_PREVISAO_MATERIA_PRIMA, CAR_DATA_INICIO_PREVISTO, CAR_DATA_INICIO_REALIZADO, CAR_DATA_FIM_PREVISTO, CAR_DATA_FIM_REALIZADO, CAR_INICIO_JANELA_EMBARQUE, CAR_FIM_JANELA_EMBARQUE, CAR_EMBARQUE_ALVO, CAR_STATUS, CAR_PESO_TEORICO, CAR_VOLUME_TEORICO, CAR_PESO_REAL, CAR_VOLUME_REAL, CAR_PESO_EMBALAGEM, CAR_PESO_ENTRADA, CAR_PESO_SAIDA, CAR_ID_DOCA, VEI_PLACA, TIP_ID, TRA_ID, CAR_GRUPO_PRODUTIVO, ROT_ID, CAR_OBSERVACAO_DE_TRANSPORTE, CAR_JUSTIFICATIVA_DE_CARREGAMENTO, OCO_ID, CAR_ID_JUNTADA, CAR_OBSERVACAO_OTIMIZADOR, CAR_ID_INTEGRACAO_BALANCA, CAR_PESAGEM_LIBERADA, CAR_OBS_LIERACAO, OCO_ID_LIERACAO, CAR_DATA_ENTRADA_VEICULO, CAR_DATA_SAIDA_VEICULO, CAR_DATA_ROMANEIO_CONSOLIDADO, CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO, CAR_DIFERENCA_PESAGEM, CAR_DATA_AGENCIAMENTO, TURN_ID, TURM_ID, TenantID, Deleted, Changed, UserId FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_PESO_SAIDA"] = value; //06
                      whereClauses.Add($" CAR_PESO_SAIDA = @CAR_PESO_SAIDA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCAR_ID_DOCAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, CAR_ID, CAR_PREVISAO_MATERIA_PRIMA, CAR_DATA_INICIO_PREVISTO, CAR_DATA_INICIO_REALIZADO, CAR_DATA_FIM_PREVISTO, CAR_DATA_FIM_REALIZADO, CAR_INICIO_JANELA_EMBARQUE, CAR_FIM_JANELA_EMBARQUE, CAR_EMBARQUE_ALVO, CAR_STATUS, CAR_PESO_TEORICO, CAR_VOLUME_TEORICO, CAR_PESO_REAL, CAR_VOLUME_REAL, CAR_PESO_EMBALAGEM, CAR_PESO_ENTRADA, CAR_PESO_SAIDA, CAR_ID_DOCA, VEI_PLACA, TIP_ID, TRA_ID, CAR_GRUPO_PRODUTIVO, ROT_ID, CAR_OBSERVACAO_DE_TRANSPORTE, CAR_JUSTIFICATIVA_DE_CARREGAMENTO, OCO_ID, CAR_ID_JUNTADA, CAR_OBSERVACAO_OTIMIZADOR, CAR_ID_INTEGRACAO_BALANCA, CAR_PESAGEM_LIBERADA, CAR_OBS_LIERACAO, OCO_ID_LIERACAO, CAR_DATA_ENTRADA_VEICULO, CAR_DATA_SAIDA_VEICULO, CAR_DATA_ROMANEIO_CONSOLIDADO, CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO, CAR_DIFERENCA_PESAGEM, CAR_DATA_AGENCIAMENTO, TURN_ID, TURM_ID, TenantID, Deleted, Changed, UserId FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_ID_DOCA"] = value; //06
                      whereClauses.Add($" CAR_ID_DOCA = @CAR_ID_DOCA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByVEI_PLACAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, CAR_ID, CAR_PREVISAO_MATERIA_PRIMA, CAR_DATA_INICIO_PREVISTO, CAR_DATA_INICIO_REALIZADO, CAR_DATA_FIM_PREVISTO, CAR_DATA_FIM_REALIZADO, CAR_INICIO_JANELA_EMBARQUE, CAR_FIM_JANELA_EMBARQUE, CAR_EMBARQUE_ALVO, CAR_STATUS, CAR_PESO_TEORICO, CAR_VOLUME_TEORICO, CAR_PESO_REAL, CAR_VOLUME_REAL, CAR_PESO_EMBALAGEM, CAR_PESO_ENTRADA, CAR_PESO_SAIDA, CAR_ID_DOCA, VEI_PLACA, TIP_ID, TRA_ID, CAR_GRUPO_PRODUTIVO, ROT_ID, CAR_OBSERVACAO_DE_TRANSPORTE, CAR_JUSTIFICATIVA_DE_CARREGAMENTO, OCO_ID, CAR_ID_JUNTADA, CAR_OBSERVACAO_OTIMIZADOR, CAR_ID_INTEGRACAO_BALANCA, CAR_PESAGEM_LIBERADA, CAR_OBS_LIERACAO, OCO_ID_LIERACAO, CAR_DATA_ENTRADA_VEICULO, CAR_DATA_SAIDA_VEICULO, CAR_DATA_ROMANEIO_CONSOLIDADO, CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO, CAR_DIFERENCA_PESAGEM, CAR_DATA_AGENCIAMENTO, TURN_ID, TURM_ID, TenantID, Deleted, Changed, UserId FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["VEI_PLACA"] = value; //06
                      whereClauses.Add($" VEI_PLACA = @VEI_PLACA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTIP_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, CAR_ID, CAR_PREVISAO_MATERIA_PRIMA, CAR_DATA_INICIO_PREVISTO, CAR_DATA_INICIO_REALIZADO, CAR_DATA_FIM_PREVISTO, CAR_DATA_FIM_REALIZADO, CAR_INICIO_JANELA_EMBARQUE, CAR_FIM_JANELA_EMBARQUE, CAR_EMBARQUE_ALVO, CAR_STATUS, CAR_PESO_TEORICO, CAR_VOLUME_TEORICO, CAR_PESO_REAL, CAR_VOLUME_REAL, CAR_PESO_EMBALAGEM, CAR_PESO_ENTRADA, CAR_PESO_SAIDA, CAR_ID_DOCA, VEI_PLACA, TIP_ID, TRA_ID, CAR_GRUPO_PRODUTIVO, ROT_ID, CAR_OBSERVACAO_DE_TRANSPORTE, CAR_JUSTIFICATIVA_DE_CARREGAMENTO, OCO_ID, CAR_ID_JUNTADA, CAR_OBSERVACAO_OTIMIZADOR, CAR_ID_INTEGRACAO_BALANCA, CAR_PESAGEM_LIBERADA, CAR_OBS_LIERACAO, OCO_ID_LIERACAO, CAR_DATA_ENTRADA_VEICULO, CAR_DATA_SAIDA_VEICULO, CAR_DATA_ROMANEIO_CONSOLIDADO, CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO, CAR_DIFERENCA_PESAGEM, CAR_DATA_AGENCIAMENTO, TURN_ID, TURM_ID, TenantID, Deleted, Changed, UserId FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TIP_ID"] = value; //06
                      whereClauses.Add($" TIP_ID = @TIP_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTRA_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, CAR_ID, CAR_PREVISAO_MATERIA_PRIMA, CAR_DATA_INICIO_PREVISTO, CAR_DATA_INICIO_REALIZADO, CAR_DATA_FIM_PREVISTO, CAR_DATA_FIM_REALIZADO, CAR_INICIO_JANELA_EMBARQUE, CAR_FIM_JANELA_EMBARQUE, CAR_EMBARQUE_ALVO, CAR_STATUS, CAR_PESO_TEORICO, CAR_VOLUME_TEORICO, CAR_PESO_REAL, CAR_VOLUME_REAL, CAR_PESO_EMBALAGEM, CAR_PESO_ENTRADA, CAR_PESO_SAIDA, CAR_ID_DOCA, VEI_PLACA, TIP_ID, TRA_ID, CAR_GRUPO_PRODUTIVO, ROT_ID, CAR_OBSERVACAO_DE_TRANSPORTE, CAR_JUSTIFICATIVA_DE_CARREGAMENTO, OCO_ID, CAR_ID_JUNTADA, CAR_OBSERVACAO_OTIMIZADOR, CAR_ID_INTEGRACAO_BALANCA, CAR_PESAGEM_LIBERADA, CAR_OBS_LIERACAO, OCO_ID_LIERACAO, CAR_DATA_ENTRADA_VEICULO, CAR_DATA_SAIDA_VEICULO, CAR_DATA_ROMANEIO_CONSOLIDADO, CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO, CAR_DIFERENCA_PESAGEM, CAR_DATA_AGENCIAMENTO, TURN_ID, TURM_ID, TenantID, Deleted, Changed, UserId FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TRA_ID"] = value; //06
                      whereClauses.Add($" TRA_ID = @TRA_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCAR_GRUPO_PRODUTIVOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, CAR_ID, CAR_PREVISAO_MATERIA_PRIMA, CAR_DATA_INICIO_PREVISTO, CAR_DATA_INICIO_REALIZADO, CAR_DATA_FIM_PREVISTO, CAR_DATA_FIM_REALIZADO, CAR_INICIO_JANELA_EMBARQUE, CAR_FIM_JANELA_EMBARQUE, CAR_EMBARQUE_ALVO, CAR_STATUS, CAR_PESO_TEORICO, CAR_VOLUME_TEORICO, CAR_PESO_REAL, CAR_VOLUME_REAL, CAR_PESO_EMBALAGEM, CAR_PESO_ENTRADA, CAR_PESO_SAIDA, CAR_ID_DOCA, VEI_PLACA, TIP_ID, TRA_ID, CAR_GRUPO_PRODUTIVO, ROT_ID, CAR_OBSERVACAO_DE_TRANSPORTE, CAR_JUSTIFICATIVA_DE_CARREGAMENTO, OCO_ID, CAR_ID_JUNTADA, CAR_OBSERVACAO_OTIMIZADOR, CAR_ID_INTEGRACAO_BALANCA, CAR_PESAGEM_LIBERADA, CAR_OBS_LIERACAO, OCO_ID_LIERACAO, CAR_DATA_ENTRADA_VEICULO, CAR_DATA_SAIDA_VEICULO, CAR_DATA_ROMANEIO_CONSOLIDADO, CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO, CAR_DIFERENCA_PESAGEM, CAR_DATA_AGENCIAMENTO, TURN_ID, TURM_ID, TenantID, Deleted, Changed, UserId FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_GRUPO_PRODUTIVO"] = value; //06
                      whereClauses.Add($" CAR_GRUPO_PRODUTIVO = @CAR_GRUPO_PRODUTIVO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByROT_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, CAR_ID, CAR_PREVISAO_MATERIA_PRIMA, CAR_DATA_INICIO_PREVISTO, CAR_DATA_INICIO_REALIZADO, CAR_DATA_FIM_PREVISTO, CAR_DATA_FIM_REALIZADO, CAR_INICIO_JANELA_EMBARQUE, CAR_FIM_JANELA_EMBARQUE, CAR_EMBARQUE_ALVO, CAR_STATUS, CAR_PESO_TEORICO, CAR_VOLUME_TEORICO, CAR_PESO_REAL, CAR_VOLUME_REAL, CAR_PESO_EMBALAGEM, CAR_PESO_ENTRADA, CAR_PESO_SAIDA, CAR_ID_DOCA, VEI_PLACA, TIP_ID, TRA_ID, CAR_GRUPO_PRODUTIVO, ROT_ID, CAR_OBSERVACAO_DE_TRANSPORTE, CAR_JUSTIFICATIVA_DE_CARREGAMENTO, OCO_ID, CAR_ID_JUNTADA, CAR_OBSERVACAO_OTIMIZADOR, CAR_ID_INTEGRACAO_BALANCA, CAR_PESAGEM_LIBERADA, CAR_OBS_LIERACAO, OCO_ID_LIERACAO, CAR_DATA_ENTRADA_VEICULO, CAR_DATA_SAIDA_VEICULO, CAR_DATA_ROMANEIO_CONSOLIDADO, CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO, CAR_DIFERENCA_PESAGEM, CAR_DATA_AGENCIAMENTO, TURN_ID, TURM_ID, TenantID, Deleted, Changed, UserId FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ROT_ID"] = value; //06
                      whereClauses.Add($" ROT_ID = @ROT_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCAR_OBSERVACAO_DE_TRANSPORTEQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, CAR_ID, CAR_PREVISAO_MATERIA_PRIMA, CAR_DATA_INICIO_PREVISTO, CAR_DATA_INICIO_REALIZADO, CAR_DATA_FIM_PREVISTO, CAR_DATA_FIM_REALIZADO, CAR_INICIO_JANELA_EMBARQUE, CAR_FIM_JANELA_EMBARQUE, CAR_EMBARQUE_ALVO, CAR_STATUS, CAR_PESO_TEORICO, CAR_VOLUME_TEORICO, CAR_PESO_REAL, CAR_VOLUME_REAL, CAR_PESO_EMBALAGEM, CAR_PESO_ENTRADA, CAR_PESO_SAIDA, CAR_ID_DOCA, VEI_PLACA, TIP_ID, TRA_ID, CAR_GRUPO_PRODUTIVO, ROT_ID, CAR_OBSERVACAO_DE_TRANSPORTE, CAR_JUSTIFICATIVA_DE_CARREGAMENTO, OCO_ID, CAR_ID_JUNTADA, CAR_OBSERVACAO_OTIMIZADOR, CAR_ID_INTEGRACAO_BALANCA, CAR_PESAGEM_LIBERADA, CAR_OBS_LIERACAO, OCO_ID_LIERACAO, CAR_DATA_ENTRADA_VEICULO, CAR_DATA_SAIDA_VEICULO, CAR_DATA_ROMANEIO_CONSOLIDADO, CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO, CAR_DIFERENCA_PESAGEM, CAR_DATA_AGENCIAMENTO, TURN_ID, TURM_ID, TenantID, Deleted, Changed, UserId FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_OBSERVACAO_DE_TRANSPORTE"] = value; //06
                      whereClauses.Add($" CAR_OBSERVACAO_DE_TRANSPORTE = @CAR_OBSERVACAO_DE_TRANSPORTE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCAR_JUSTIFICATIVA_DE_CARREGAMENTOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, CAR_ID, CAR_PREVISAO_MATERIA_PRIMA, CAR_DATA_INICIO_PREVISTO, CAR_DATA_INICIO_REALIZADO, CAR_DATA_FIM_PREVISTO, CAR_DATA_FIM_REALIZADO, CAR_INICIO_JANELA_EMBARQUE, CAR_FIM_JANELA_EMBARQUE, CAR_EMBARQUE_ALVO, CAR_STATUS, CAR_PESO_TEORICO, CAR_VOLUME_TEORICO, CAR_PESO_REAL, CAR_VOLUME_REAL, CAR_PESO_EMBALAGEM, CAR_PESO_ENTRADA, CAR_PESO_SAIDA, CAR_ID_DOCA, VEI_PLACA, TIP_ID, TRA_ID, CAR_GRUPO_PRODUTIVO, ROT_ID, CAR_OBSERVACAO_DE_TRANSPORTE, CAR_JUSTIFICATIVA_DE_CARREGAMENTO, OCO_ID, CAR_ID_JUNTADA, CAR_OBSERVACAO_OTIMIZADOR, CAR_ID_INTEGRACAO_BALANCA, CAR_PESAGEM_LIBERADA, CAR_OBS_LIERACAO, OCO_ID_LIERACAO, CAR_DATA_ENTRADA_VEICULO, CAR_DATA_SAIDA_VEICULO, CAR_DATA_ROMANEIO_CONSOLIDADO, CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO, CAR_DIFERENCA_PESAGEM, CAR_DATA_AGENCIAMENTO, TURN_ID, TURM_ID, TenantID, Deleted, Changed, UserId FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_JUSTIFICATIVA_DE_CARREGAMENTO"] = value; //06
                      whereClauses.Add($" CAR_JUSTIFICATIVA_DE_CARREGAMENTO = @CAR_JUSTIFICATIVA_DE_CARREGAMENTO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByOCO_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, CAR_ID, CAR_PREVISAO_MATERIA_PRIMA, CAR_DATA_INICIO_PREVISTO, CAR_DATA_INICIO_REALIZADO, CAR_DATA_FIM_PREVISTO, CAR_DATA_FIM_REALIZADO, CAR_INICIO_JANELA_EMBARQUE, CAR_FIM_JANELA_EMBARQUE, CAR_EMBARQUE_ALVO, CAR_STATUS, CAR_PESO_TEORICO, CAR_VOLUME_TEORICO, CAR_PESO_REAL, CAR_VOLUME_REAL, CAR_PESO_EMBALAGEM, CAR_PESO_ENTRADA, CAR_PESO_SAIDA, CAR_ID_DOCA, VEI_PLACA, TIP_ID, TRA_ID, CAR_GRUPO_PRODUTIVO, ROT_ID, CAR_OBSERVACAO_DE_TRANSPORTE, CAR_JUSTIFICATIVA_DE_CARREGAMENTO, OCO_ID, CAR_ID_JUNTADA, CAR_OBSERVACAO_OTIMIZADOR, CAR_ID_INTEGRACAO_BALANCA, CAR_PESAGEM_LIBERADA, CAR_OBS_LIERACAO, OCO_ID_LIERACAO, CAR_DATA_ENTRADA_VEICULO, CAR_DATA_SAIDA_VEICULO, CAR_DATA_ROMANEIO_CONSOLIDADO, CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO, CAR_DIFERENCA_PESAGEM, CAR_DATA_AGENCIAMENTO, TURN_ID, TURM_ID, TenantID, Deleted, Changed, UserId FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["OCO_ID"] = value; //06
                      whereClauses.Add($" OCO_ID = @OCO_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCAR_ID_JUNTADAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, CAR_ID, CAR_PREVISAO_MATERIA_PRIMA, CAR_DATA_INICIO_PREVISTO, CAR_DATA_INICIO_REALIZADO, CAR_DATA_FIM_PREVISTO, CAR_DATA_FIM_REALIZADO, CAR_INICIO_JANELA_EMBARQUE, CAR_FIM_JANELA_EMBARQUE, CAR_EMBARQUE_ALVO, CAR_STATUS, CAR_PESO_TEORICO, CAR_VOLUME_TEORICO, CAR_PESO_REAL, CAR_VOLUME_REAL, CAR_PESO_EMBALAGEM, CAR_PESO_ENTRADA, CAR_PESO_SAIDA, CAR_ID_DOCA, VEI_PLACA, TIP_ID, TRA_ID, CAR_GRUPO_PRODUTIVO, ROT_ID, CAR_OBSERVACAO_DE_TRANSPORTE, CAR_JUSTIFICATIVA_DE_CARREGAMENTO, OCO_ID, CAR_ID_JUNTADA, CAR_OBSERVACAO_OTIMIZADOR, CAR_ID_INTEGRACAO_BALANCA, CAR_PESAGEM_LIBERADA, CAR_OBS_LIERACAO, OCO_ID_LIERACAO, CAR_DATA_ENTRADA_VEICULO, CAR_DATA_SAIDA_VEICULO, CAR_DATA_ROMANEIO_CONSOLIDADO, CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO, CAR_DIFERENCA_PESAGEM, CAR_DATA_AGENCIAMENTO, TURN_ID, TURM_ID, TenantID, Deleted, Changed, UserId FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_ID_JUNTADA"] = value; //06
                      whereClauses.Add($" CAR_ID_JUNTADA = @CAR_ID_JUNTADA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCAR_OBSERVACAO_OTIMIZADORQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, CAR_ID, CAR_PREVISAO_MATERIA_PRIMA, CAR_DATA_INICIO_PREVISTO, CAR_DATA_INICIO_REALIZADO, CAR_DATA_FIM_PREVISTO, CAR_DATA_FIM_REALIZADO, CAR_INICIO_JANELA_EMBARQUE, CAR_FIM_JANELA_EMBARQUE, CAR_EMBARQUE_ALVO, CAR_STATUS, CAR_PESO_TEORICO, CAR_VOLUME_TEORICO, CAR_PESO_REAL, CAR_VOLUME_REAL, CAR_PESO_EMBALAGEM, CAR_PESO_ENTRADA, CAR_PESO_SAIDA, CAR_ID_DOCA, VEI_PLACA, TIP_ID, TRA_ID, CAR_GRUPO_PRODUTIVO, ROT_ID, CAR_OBSERVACAO_DE_TRANSPORTE, CAR_JUSTIFICATIVA_DE_CARREGAMENTO, OCO_ID, CAR_ID_JUNTADA, CAR_OBSERVACAO_OTIMIZADOR, CAR_ID_INTEGRACAO_BALANCA, CAR_PESAGEM_LIBERADA, CAR_OBS_LIERACAO, OCO_ID_LIERACAO, CAR_DATA_ENTRADA_VEICULO, CAR_DATA_SAIDA_VEICULO, CAR_DATA_ROMANEIO_CONSOLIDADO, CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO, CAR_DIFERENCA_PESAGEM, CAR_DATA_AGENCIAMENTO, TURN_ID, TURM_ID, TenantID, Deleted, Changed, UserId FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_OBSERVACAO_OTIMIZADOR"] = value; //06
                      whereClauses.Add($" CAR_OBSERVACAO_OTIMIZADOR = @CAR_OBSERVACAO_OTIMIZADOR ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCAR_ID_INTEGRACAO_BALANCAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, CAR_ID, CAR_PREVISAO_MATERIA_PRIMA, CAR_DATA_INICIO_PREVISTO, CAR_DATA_INICIO_REALIZADO, CAR_DATA_FIM_PREVISTO, CAR_DATA_FIM_REALIZADO, CAR_INICIO_JANELA_EMBARQUE, CAR_FIM_JANELA_EMBARQUE, CAR_EMBARQUE_ALVO, CAR_STATUS, CAR_PESO_TEORICO, CAR_VOLUME_TEORICO, CAR_PESO_REAL, CAR_VOLUME_REAL, CAR_PESO_EMBALAGEM, CAR_PESO_ENTRADA, CAR_PESO_SAIDA, CAR_ID_DOCA, VEI_PLACA, TIP_ID, TRA_ID, CAR_GRUPO_PRODUTIVO, ROT_ID, CAR_OBSERVACAO_DE_TRANSPORTE, CAR_JUSTIFICATIVA_DE_CARREGAMENTO, OCO_ID, CAR_ID_JUNTADA, CAR_OBSERVACAO_OTIMIZADOR, CAR_ID_INTEGRACAO_BALANCA, CAR_PESAGEM_LIBERADA, CAR_OBS_LIERACAO, OCO_ID_LIERACAO, CAR_DATA_ENTRADA_VEICULO, CAR_DATA_SAIDA_VEICULO, CAR_DATA_ROMANEIO_CONSOLIDADO, CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO, CAR_DIFERENCA_PESAGEM, CAR_DATA_AGENCIAMENTO, TURN_ID, TURM_ID, TenantID, Deleted, Changed, UserId FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_ID_INTEGRACAO_BALANCA"] = value; //06
                      whereClauses.Add($" CAR_ID_INTEGRACAO_BALANCA = @CAR_ID_INTEGRACAO_BALANCA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCAR_PESAGEM_LIBERADAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, CAR_ID, CAR_PREVISAO_MATERIA_PRIMA, CAR_DATA_INICIO_PREVISTO, CAR_DATA_INICIO_REALIZADO, CAR_DATA_FIM_PREVISTO, CAR_DATA_FIM_REALIZADO, CAR_INICIO_JANELA_EMBARQUE, CAR_FIM_JANELA_EMBARQUE, CAR_EMBARQUE_ALVO, CAR_STATUS, CAR_PESO_TEORICO, CAR_VOLUME_TEORICO, CAR_PESO_REAL, CAR_VOLUME_REAL, CAR_PESO_EMBALAGEM, CAR_PESO_ENTRADA, CAR_PESO_SAIDA, CAR_ID_DOCA, VEI_PLACA, TIP_ID, TRA_ID, CAR_GRUPO_PRODUTIVO, ROT_ID, CAR_OBSERVACAO_DE_TRANSPORTE, CAR_JUSTIFICATIVA_DE_CARREGAMENTO, OCO_ID, CAR_ID_JUNTADA, CAR_OBSERVACAO_OTIMIZADOR, CAR_ID_INTEGRACAO_BALANCA, CAR_PESAGEM_LIBERADA, CAR_OBS_LIERACAO, OCO_ID_LIERACAO, CAR_DATA_ENTRADA_VEICULO, CAR_DATA_SAIDA_VEICULO, CAR_DATA_ROMANEIO_CONSOLIDADO, CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO, CAR_DIFERENCA_PESAGEM, CAR_DATA_AGENCIAMENTO, TURN_ID, TURM_ID, TenantID, Deleted, Changed, UserId FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_PESAGEM_LIBERADA"] = value; //06
                      whereClauses.Add($" CAR_PESAGEM_LIBERADA = @CAR_PESAGEM_LIBERADA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCAR_OBS_LIERACAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, CAR_ID, CAR_PREVISAO_MATERIA_PRIMA, CAR_DATA_INICIO_PREVISTO, CAR_DATA_INICIO_REALIZADO, CAR_DATA_FIM_PREVISTO, CAR_DATA_FIM_REALIZADO, CAR_INICIO_JANELA_EMBARQUE, CAR_FIM_JANELA_EMBARQUE, CAR_EMBARQUE_ALVO, CAR_STATUS, CAR_PESO_TEORICO, CAR_VOLUME_TEORICO, CAR_PESO_REAL, CAR_VOLUME_REAL, CAR_PESO_EMBALAGEM, CAR_PESO_ENTRADA, CAR_PESO_SAIDA, CAR_ID_DOCA, VEI_PLACA, TIP_ID, TRA_ID, CAR_GRUPO_PRODUTIVO, ROT_ID, CAR_OBSERVACAO_DE_TRANSPORTE, CAR_JUSTIFICATIVA_DE_CARREGAMENTO, OCO_ID, CAR_ID_JUNTADA, CAR_OBSERVACAO_OTIMIZADOR, CAR_ID_INTEGRACAO_BALANCA, CAR_PESAGEM_LIBERADA, CAR_OBS_LIERACAO, OCO_ID_LIERACAO, CAR_DATA_ENTRADA_VEICULO, CAR_DATA_SAIDA_VEICULO, CAR_DATA_ROMANEIO_CONSOLIDADO, CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO, CAR_DIFERENCA_PESAGEM, CAR_DATA_AGENCIAMENTO, TURN_ID, TURM_ID, TenantID, Deleted, Changed, UserId FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_OBS_LIERACAO"] = value; //06
                      whereClauses.Add($" CAR_OBS_LIERACAO = @CAR_OBS_LIERACAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByOCO_ID_LIERACAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, CAR_ID, CAR_PREVISAO_MATERIA_PRIMA, CAR_DATA_INICIO_PREVISTO, CAR_DATA_INICIO_REALIZADO, CAR_DATA_FIM_PREVISTO, CAR_DATA_FIM_REALIZADO, CAR_INICIO_JANELA_EMBARQUE, CAR_FIM_JANELA_EMBARQUE, CAR_EMBARQUE_ALVO, CAR_STATUS, CAR_PESO_TEORICO, CAR_VOLUME_TEORICO, CAR_PESO_REAL, CAR_VOLUME_REAL, CAR_PESO_EMBALAGEM, CAR_PESO_ENTRADA, CAR_PESO_SAIDA, CAR_ID_DOCA, VEI_PLACA, TIP_ID, TRA_ID, CAR_GRUPO_PRODUTIVO, ROT_ID, CAR_OBSERVACAO_DE_TRANSPORTE, CAR_JUSTIFICATIVA_DE_CARREGAMENTO, OCO_ID, CAR_ID_JUNTADA, CAR_OBSERVACAO_OTIMIZADOR, CAR_ID_INTEGRACAO_BALANCA, CAR_PESAGEM_LIBERADA, CAR_OBS_LIERACAO, OCO_ID_LIERACAO, CAR_DATA_ENTRADA_VEICULO, CAR_DATA_SAIDA_VEICULO, CAR_DATA_ROMANEIO_CONSOLIDADO, CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO, CAR_DIFERENCA_PESAGEM, CAR_DATA_AGENCIAMENTO, TURN_ID, TURM_ID, TenantID, Deleted, Changed, UserId FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["OCO_ID_LIERACAO"] = value; //06
                      whereClauses.Add($" OCO_ID_LIERACAO = @OCO_ID_LIERACAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCAR_DATA_ENTRADA_VEICULOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, CAR_ID, CAR_PREVISAO_MATERIA_PRIMA, CAR_DATA_INICIO_PREVISTO, CAR_DATA_INICIO_REALIZADO, CAR_DATA_FIM_PREVISTO, CAR_DATA_FIM_REALIZADO, CAR_INICIO_JANELA_EMBARQUE, CAR_FIM_JANELA_EMBARQUE, CAR_EMBARQUE_ALVO, CAR_STATUS, CAR_PESO_TEORICO, CAR_VOLUME_TEORICO, CAR_PESO_REAL, CAR_VOLUME_REAL, CAR_PESO_EMBALAGEM, CAR_PESO_ENTRADA, CAR_PESO_SAIDA, CAR_ID_DOCA, VEI_PLACA, TIP_ID, TRA_ID, CAR_GRUPO_PRODUTIVO, ROT_ID, CAR_OBSERVACAO_DE_TRANSPORTE, CAR_JUSTIFICATIVA_DE_CARREGAMENTO, OCO_ID, CAR_ID_JUNTADA, CAR_OBSERVACAO_OTIMIZADOR, CAR_ID_INTEGRACAO_BALANCA, CAR_PESAGEM_LIBERADA, CAR_OBS_LIERACAO, OCO_ID_LIERACAO, CAR_DATA_ENTRADA_VEICULO, CAR_DATA_SAIDA_VEICULO, CAR_DATA_ROMANEIO_CONSOLIDADO, CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO, CAR_DIFERENCA_PESAGEM, CAR_DATA_AGENCIAMENTO, TURN_ID, TURM_ID, TenantID, Deleted, Changed, UserId FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_DATA_ENTRADA_VEICULO"] = value; //06
                      whereClauses.Add($" CAR_DATA_ENTRADA_VEICULO = @CAR_DATA_ENTRADA_VEICULO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCAR_DATA_SAIDA_VEICULOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, CAR_ID, CAR_PREVISAO_MATERIA_PRIMA, CAR_DATA_INICIO_PREVISTO, CAR_DATA_INICIO_REALIZADO, CAR_DATA_FIM_PREVISTO, CAR_DATA_FIM_REALIZADO, CAR_INICIO_JANELA_EMBARQUE, CAR_FIM_JANELA_EMBARQUE, CAR_EMBARQUE_ALVO, CAR_STATUS, CAR_PESO_TEORICO, CAR_VOLUME_TEORICO, CAR_PESO_REAL, CAR_VOLUME_REAL, CAR_PESO_EMBALAGEM, CAR_PESO_ENTRADA, CAR_PESO_SAIDA, CAR_ID_DOCA, VEI_PLACA, TIP_ID, TRA_ID, CAR_GRUPO_PRODUTIVO, ROT_ID, CAR_OBSERVACAO_DE_TRANSPORTE, CAR_JUSTIFICATIVA_DE_CARREGAMENTO, OCO_ID, CAR_ID_JUNTADA, CAR_OBSERVACAO_OTIMIZADOR, CAR_ID_INTEGRACAO_BALANCA, CAR_PESAGEM_LIBERADA, CAR_OBS_LIERACAO, OCO_ID_LIERACAO, CAR_DATA_ENTRADA_VEICULO, CAR_DATA_SAIDA_VEICULO, CAR_DATA_ROMANEIO_CONSOLIDADO, CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO, CAR_DIFERENCA_PESAGEM, CAR_DATA_AGENCIAMENTO, TURN_ID, TURM_ID, TenantID, Deleted, Changed, UserId FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_DATA_SAIDA_VEICULO"] = value; //06
                      whereClauses.Add($" CAR_DATA_SAIDA_VEICULO = @CAR_DATA_SAIDA_VEICULO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCAR_DATA_ROMANEIO_CONSOLIDADOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, CAR_ID, CAR_PREVISAO_MATERIA_PRIMA, CAR_DATA_INICIO_PREVISTO, CAR_DATA_INICIO_REALIZADO, CAR_DATA_FIM_PREVISTO, CAR_DATA_FIM_REALIZADO, CAR_INICIO_JANELA_EMBARQUE, CAR_FIM_JANELA_EMBARQUE, CAR_EMBARQUE_ALVO, CAR_STATUS, CAR_PESO_TEORICO, CAR_VOLUME_TEORICO, CAR_PESO_REAL, CAR_VOLUME_REAL, CAR_PESO_EMBALAGEM, CAR_PESO_ENTRADA, CAR_PESO_SAIDA, CAR_ID_DOCA, VEI_PLACA, TIP_ID, TRA_ID, CAR_GRUPO_PRODUTIVO, ROT_ID, CAR_OBSERVACAO_DE_TRANSPORTE, CAR_JUSTIFICATIVA_DE_CARREGAMENTO, OCO_ID, CAR_ID_JUNTADA, CAR_OBSERVACAO_OTIMIZADOR, CAR_ID_INTEGRACAO_BALANCA, CAR_PESAGEM_LIBERADA, CAR_OBS_LIERACAO, OCO_ID_LIERACAO, CAR_DATA_ENTRADA_VEICULO, CAR_DATA_SAIDA_VEICULO, CAR_DATA_ROMANEIO_CONSOLIDADO, CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO, CAR_DIFERENCA_PESAGEM, CAR_DATA_AGENCIAMENTO, TURN_ID, TURM_ID, TenantID, Deleted, Changed, UserId FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_DATA_ROMANEIO_CONSOLIDADO"] = value; //06
                      whereClauses.Add($" CAR_DATA_ROMANEIO_CONSOLIDADO = @CAR_DATA_ROMANEIO_CONSOLIDADO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCAR_DIA_TURMA_ROMANEIO_CONSOLIDADOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, CAR_ID, CAR_PREVISAO_MATERIA_PRIMA, CAR_DATA_INICIO_PREVISTO, CAR_DATA_INICIO_REALIZADO, CAR_DATA_FIM_PREVISTO, CAR_DATA_FIM_REALIZADO, CAR_INICIO_JANELA_EMBARQUE, CAR_FIM_JANELA_EMBARQUE, CAR_EMBARQUE_ALVO, CAR_STATUS, CAR_PESO_TEORICO, CAR_VOLUME_TEORICO, CAR_PESO_REAL, CAR_VOLUME_REAL, CAR_PESO_EMBALAGEM, CAR_PESO_ENTRADA, CAR_PESO_SAIDA, CAR_ID_DOCA, VEI_PLACA, TIP_ID, TRA_ID, CAR_GRUPO_PRODUTIVO, ROT_ID, CAR_OBSERVACAO_DE_TRANSPORTE, CAR_JUSTIFICATIVA_DE_CARREGAMENTO, OCO_ID, CAR_ID_JUNTADA, CAR_OBSERVACAO_OTIMIZADOR, CAR_ID_INTEGRACAO_BALANCA, CAR_PESAGEM_LIBERADA, CAR_OBS_LIERACAO, OCO_ID_LIERACAO, CAR_DATA_ENTRADA_VEICULO, CAR_DATA_SAIDA_VEICULO, CAR_DATA_ROMANEIO_CONSOLIDADO, CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO, CAR_DIFERENCA_PESAGEM, CAR_DATA_AGENCIAMENTO, TURN_ID, TURM_ID, TenantID, Deleted, Changed, UserId FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO"] = value; //06
                      whereClauses.Add($" CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO = @CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCAR_DIFERENCA_PESAGEMQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, CAR_ID, CAR_PREVISAO_MATERIA_PRIMA, CAR_DATA_INICIO_PREVISTO, CAR_DATA_INICIO_REALIZADO, CAR_DATA_FIM_PREVISTO, CAR_DATA_FIM_REALIZADO, CAR_INICIO_JANELA_EMBARQUE, CAR_FIM_JANELA_EMBARQUE, CAR_EMBARQUE_ALVO, CAR_STATUS, CAR_PESO_TEORICO, CAR_VOLUME_TEORICO, CAR_PESO_REAL, CAR_VOLUME_REAL, CAR_PESO_EMBALAGEM, CAR_PESO_ENTRADA, CAR_PESO_SAIDA, CAR_ID_DOCA, VEI_PLACA, TIP_ID, TRA_ID, CAR_GRUPO_PRODUTIVO, ROT_ID, CAR_OBSERVACAO_DE_TRANSPORTE, CAR_JUSTIFICATIVA_DE_CARREGAMENTO, OCO_ID, CAR_ID_JUNTADA, CAR_OBSERVACAO_OTIMIZADOR, CAR_ID_INTEGRACAO_BALANCA, CAR_PESAGEM_LIBERADA, CAR_OBS_LIERACAO, OCO_ID_LIERACAO, CAR_DATA_ENTRADA_VEICULO, CAR_DATA_SAIDA_VEICULO, CAR_DATA_ROMANEIO_CONSOLIDADO, CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO, CAR_DIFERENCA_PESAGEM, CAR_DATA_AGENCIAMENTO, TURN_ID, TURM_ID, TenantID, Deleted, Changed, UserId FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_DIFERENCA_PESAGEM"] = value; //06
                      whereClauses.Add($" CAR_DIFERENCA_PESAGEM = @CAR_DIFERENCA_PESAGEM ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCAR_DATA_AGENCIAMENTOQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, CAR_ID, CAR_PREVISAO_MATERIA_PRIMA, CAR_DATA_INICIO_PREVISTO, CAR_DATA_INICIO_REALIZADO, CAR_DATA_FIM_PREVISTO, CAR_DATA_FIM_REALIZADO, CAR_INICIO_JANELA_EMBARQUE, CAR_FIM_JANELA_EMBARQUE, CAR_EMBARQUE_ALVO, CAR_STATUS, CAR_PESO_TEORICO, CAR_VOLUME_TEORICO, CAR_PESO_REAL, CAR_VOLUME_REAL, CAR_PESO_EMBALAGEM, CAR_PESO_ENTRADA, CAR_PESO_SAIDA, CAR_ID_DOCA, VEI_PLACA, TIP_ID, TRA_ID, CAR_GRUPO_PRODUTIVO, ROT_ID, CAR_OBSERVACAO_DE_TRANSPORTE, CAR_JUSTIFICATIVA_DE_CARREGAMENTO, OCO_ID, CAR_ID_JUNTADA, CAR_OBSERVACAO_OTIMIZADOR, CAR_ID_INTEGRACAO_BALANCA, CAR_PESAGEM_LIBERADA, CAR_OBS_LIERACAO, OCO_ID_LIERACAO, CAR_DATA_ENTRADA_VEICULO, CAR_DATA_SAIDA_VEICULO, CAR_DATA_ROMANEIO_CONSOLIDADO, CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO, CAR_DIFERENCA_PESAGEM, CAR_DATA_AGENCIAMENTO, TURN_ID, TURM_ID, TenantID, Deleted, Changed, UserId FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CAR_DATA_AGENCIAMENTO"] = value; //06
                      whereClauses.Add($" CAR_DATA_AGENCIAMENTO = @CAR_DATA_AGENCIAMENTO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTURN_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, CAR_ID, CAR_PREVISAO_MATERIA_PRIMA, CAR_DATA_INICIO_PREVISTO, CAR_DATA_INICIO_REALIZADO, CAR_DATA_FIM_PREVISTO, CAR_DATA_FIM_REALIZADO, CAR_INICIO_JANELA_EMBARQUE, CAR_FIM_JANELA_EMBARQUE, CAR_EMBARQUE_ALVO, CAR_STATUS, CAR_PESO_TEORICO, CAR_VOLUME_TEORICO, CAR_PESO_REAL, CAR_VOLUME_REAL, CAR_PESO_EMBALAGEM, CAR_PESO_ENTRADA, CAR_PESO_SAIDA, CAR_ID_DOCA, VEI_PLACA, TIP_ID, TRA_ID, CAR_GRUPO_PRODUTIVO, ROT_ID, CAR_OBSERVACAO_DE_TRANSPORTE, CAR_JUSTIFICATIVA_DE_CARREGAMENTO, OCO_ID, CAR_ID_JUNTADA, CAR_OBSERVACAO_OTIMIZADOR, CAR_ID_INTEGRACAO_BALANCA, CAR_PESAGEM_LIBERADA, CAR_OBS_LIERACAO, OCO_ID_LIERACAO, CAR_DATA_ENTRADA_VEICULO, CAR_DATA_SAIDA_VEICULO, CAR_DATA_ROMANEIO_CONSOLIDADO, CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO, CAR_DIFERENCA_PESAGEM, CAR_DATA_AGENCIAMENTO, TURN_ID, TURM_ID, TenantID, Deleted, Changed, UserId FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TURN_ID"] = value; //06
                      whereClauses.Add($" TURN_ID = @TURN_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTURM_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, CAR_ID, CAR_PREVISAO_MATERIA_PRIMA, CAR_DATA_INICIO_PREVISTO, CAR_DATA_INICIO_REALIZADO, CAR_DATA_FIM_PREVISTO, CAR_DATA_FIM_REALIZADO, CAR_INICIO_JANELA_EMBARQUE, CAR_FIM_JANELA_EMBARQUE, CAR_EMBARQUE_ALVO, CAR_STATUS, CAR_PESO_TEORICO, CAR_VOLUME_TEORICO, CAR_PESO_REAL, CAR_VOLUME_REAL, CAR_PESO_EMBALAGEM, CAR_PESO_ENTRADA, CAR_PESO_SAIDA, CAR_ID_DOCA, VEI_PLACA, TIP_ID, TRA_ID, CAR_GRUPO_PRODUTIVO, ROT_ID, CAR_OBSERVACAO_DE_TRANSPORTE, CAR_JUSTIFICATIVA_DE_CARREGAMENTO, OCO_ID, CAR_ID_JUNTADA, CAR_OBSERVACAO_OTIMIZADOR, CAR_ID_INTEGRACAO_BALANCA, CAR_PESAGEM_LIBERADA, CAR_OBS_LIERACAO, OCO_ID_LIERACAO, CAR_DATA_ENTRADA_VEICULO, CAR_DATA_SAIDA_VEICULO, CAR_DATA_ROMANEIO_CONSOLIDADO, CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO, CAR_DIFERENCA_PESAGEM, CAR_DATA_AGENCIAMENTO, TURN_ID, TURM_ID, TenantID, Deleted, Changed, UserId FROM Carga ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TURM_ID"] = value; //06
                      whereClauses.Add($" TURM_ID = @TURM_ID ");//06
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
            this.Query = $"SELECT Id, CAR_ID, CAR_PREVISAO_MATERIA_PRIMA, CAR_DATA_INICIO_PREVISTO, CAR_DATA_INICIO_REALIZADO, CAR_DATA_FIM_PREVISTO, CAR_DATA_FIM_REALIZADO, CAR_INICIO_JANELA_EMBARQUE, CAR_FIM_JANELA_EMBARQUE, CAR_EMBARQUE_ALVO, CAR_STATUS, CAR_PESO_TEORICO, CAR_VOLUME_TEORICO, CAR_PESO_REAL, CAR_VOLUME_REAL, CAR_PESO_EMBALAGEM, CAR_PESO_ENTRADA, CAR_PESO_SAIDA, CAR_ID_DOCA, VEI_PLACA, TIP_ID, TRA_ID, CAR_GRUPO_PRODUTIVO, ROT_ID, CAR_OBSERVACAO_DE_TRANSPORTE, CAR_JUSTIFICATIVA_DE_CARREGAMENTO, OCO_ID, CAR_ID_JUNTADA, CAR_OBSERVACAO_OTIMIZADOR, CAR_ID_INTEGRACAO_BALANCA, CAR_PESAGEM_LIBERADA, CAR_OBS_LIERACAO, OCO_ID_LIERACAO, CAR_DATA_ENTRADA_VEICULO, CAR_DATA_SAIDA_VEICULO, CAR_DATA_ROMANEIO_CONSOLIDADO, CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO, CAR_DIFERENCA_PESAGEM, CAR_DATA_AGENCIAMENTO, TURN_ID, TURM_ID, TenantID, Deleted, Changed, UserId FROM Carga ";
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
            this.Query = $"SELECT Id, CAR_ID, CAR_PREVISAO_MATERIA_PRIMA, CAR_DATA_INICIO_PREVISTO, CAR_DATA_INICIO_REALIZADO, CAR_DATA_FIM_PREVISTO, CAR_DATA_FIM_REALIZADO, CAR_INICIO_JANELA_EMBARQUE, CAR_FIM_JANELA_EMBARQUE, CAR_EMBARQUE_ALVO, CAR_STATUS, CAR_PESO_TEORICO, CAR_VOLUME_TEORICO, CAR_PESO_REAL, CAR_VOLUME_REAL, CAR_PESO_EMBALAGEM, CAR_PESO_ENTRADA, CAR_PESO_SAIDA, CAR_ID_DOCA, VEI_PLACA, TIP_ID, TRA_ID, CAR_GRUPO_PRODUTIVO, ROT_ID, CAR_OBSERVACAO_DE_TRANSPORTE, CAR_JUSTIFICATIVA_DE_CARREGAMENTO, OCO_ID, CAR_ID_JUNTADA, CAR_OBSERVACAO_OTIMIZADOR, CAR_ID_INTEGRACAO_BALANCA, CAR_PESAGEM_LIBERADA, CAR_OBS_LIERACAO, OCO_ID_LIERACAO, CAR_DATA_ENTRADA_VEICULO, CAR_DATA_SAIDA_VEICULO, CAR_DATA_ROMANEIO_CONSOLIDADO, CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO, CAR_DIFERENCA_PESAGEM, CAR_DATA_AGENCIAMENTO, TURN_ID, TURM_ID, TenantID, Deleted, Changed, UserId FROM Carga ";
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
            this.Query = $"SELECT Id, CAR_ID, CAR_PREVISAO_MATERIA_PRIMA, CAR_DATA_INICIO_PREVISTO, CAR_DATA_INICIO_REALIZADO, CAR_DATA_FIM_PREVISTO, CAR_DATA_FIM_REALIZADO, CAR_INICIO_JANELA_EMBARQUE, CAR_FIM_JANELA_EMBARQUE, CAR_EMBARQUE_ALVO, CAR_STATUS, CAR_PESO_TEORICO, CAR_VOLUME_TEORICO, CAR_PESO_REAL, CAR_VOLUME_REAL, CAR_PESO_EMBALAGEM, CAR_PESO_ENTRADA, CAR_PESO_SAIDA, CAR_ID_DOCA, VEI_PLACA, TIP_ID, TRA_ID, CAR_GRUPO_PRODUTIVO, ROT_ID, CAR_OBSERVACAO_DE_TRANSPORTE, CAR_JUSTIFICATIVA_DE_CARREGAMENTO, OCO_ID, CAR_ID_JUNTADA, CAR_OBSERVACAO_OTIMIZADOR, CAR_ID_INTEGRACAO_BALANCA, CAR_PESAGEM_LIBERADA, CAR_OBS_LIERACAO, OCO_ID_LIERACAO, CAR_DATA_ENTRADA_VEICULO, CAR_DATA_SAIDA_VEICULO, CAR_DATA_ROMANEIO_CONSOLIDADO, CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO, CAR_DIFERENCA_PESAGEM, CAR_DATA_AGENCIAMENTO, TURN_ID, TURM_ID, TenantID, Deleted, Changed, UserId FROM Carga ";
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
            this.Query = $"SELECT Id, CAR_ID, CAR_PREVISAO_MATERIA_PRIMA, CAR_DATA_INICIO_PREVISTO, CAR_DATA_INICIO_REALIZADO, CAR_DATA_FIM_PREVISTO, CAR_DATA_FIM_REALIZADO, CAR_INICIO_JANELA_EMBARQUE, CAR_FIM_JANELA_EMBARQUE, CAR_EMBARQUE_ALVO, CAR_STATUS, CAR_PESO_TEORICO, CAR_VOLUME_TEORICO, CAR_PESO_REAL, CAR_VOLUME_REAL, CAR_PESO_EMBALAGEM, CAR_PESO_ENTRADA, CAR_PESO_SAIDA, CAR_ID_DOCA, VEI_PLACA, TIP_ID, TRA_ID, CAR_GRUPO_PRODUTIVO, ROT_ID, CAR_OBSERVACAO_DE_TRANSPORTE, CAR_JUSTIFICATIVA_DE_CARREGAMENTO, OCO_ID, CAR_ID_JUNTADA, CAR_OBSERVACAO_OTIMIZADOR, CAR_ID_INTEGRACAO_BALANCA, CAR_PESAGEM_LIBERADA, CAR_OBS_LIERACAO, OCO_ID_LIERACAO, CAR_DATA_ENTRADA_VEICULO, CAR_DATA_SAIDA_VEICULO, CAR_DATA_ROMANEIO_CONSOLIDADO, CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO, CAR_DIFERENCA_PESAGEM, CAR_DATA_AGENCIAMENTO, TURN_ID, TURM_ID, TenantID, Deleted, Changed, UserId FROM Carga ";
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