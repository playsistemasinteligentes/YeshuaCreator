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
    public class MovimentoEstoqueQueryRead : QueryBase, IMovimentoEstoqueQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public MovimentoEstoqueQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel MovimentoEstoqueQuery(Command.Read.MovimentoEstoqueReadCommand Command )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select Id, ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId from MovimentoEstoque ";
if (Command.Id.HasValue) dict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"Id = @Id");
if (!string.IsNullOrEmpty(Command.ProdutoId)) dict["ProdutoId"] = $"%{Command.ProdutoId}%";
if (!string.IsNullOrEmpty(Command.ProdutoId)) whereClauses.Add($"ProdutoId like @ProdutoId");
if (!string.IsNullOrEmpty(Command.OrderId)) dict["OrderId"] = $"%{Command.OrderId}%";
if (!string.IsNullOrEmpty(Command.OrderId)) whereClauses.Add($"OrderId like @OrderId");
if (!string.IsNullOrEmpty(Command.Tipo)) dict["Tipo"] = $"%{Command.Tipo}%";
if (!string.IsNullOrEmpty(Command.Tipo)) whereClauses.Add($"Tipo like @Tipo");
if (!string.IsNullOrEmpty(Command.TurnoId)) dict["TurnoId"] = $"%{Command.TurnoId}%";
if (!string.IsNullOrEmpty(Command.TurnoId)) whereClauses.Add($"TurnoId like @TurnoId");
if (!string.IsNullOrEmpty(Command.TurmaId)) dict["TurmaId"] = $"%{Command.TurmaId}%";
if (!string.IsNullOrEmpty(Command.TurmaId)) whereClauses.Add($"TurmaId like @TurmaId");
if (!string.IsNullOrEmpty(Command.DiaTurma)) dict["DiaTurma"] = $"%{Command.DiaTurma}%";
if (!string.IsNullOrEmpty(Command.DiaTurma)) whereClauses.Add($"DiaTurma like @DiaTurma");
if (!string.IsNullOrEmpty(Command.Lote)) dict["Lote"] = $"%{Command.Lote}%";
if (!string.IsNullOrEmpty(Command.Lote)) whereClauses.Add($"Lote like @Lote");
if (!string.IsNullOrEmpty(Command.SubLote)) dict["SubLote"] = $"%{Command.SubLote}%";
if (!string.IsNullOrEmpty(Command.SubLote)) whereClauses.Add($"SubLote like @SubLote");
if (!string.IsNullOrEmpty(Command.MaquinaId)) dict["MaquinaId"] = $"%{Command.MaquinaId}%";
if (!string.IsNullOrEmpty(Command.MaquinaId)) whereClauses.Add($"MaquinaId like @MaquinaId");
if (Command.USE_ID.HasValue) dict["USE_ID"] = Command.USE_ID.Value;
if (Command.USE_ID.HasValue) whereClauses.Add($"USE_ID = @USE_ID");
if (!string.IsNullOrEmpty(Command.Observacao)) dict["Observacao"] = $"%{Command.Observacao}%";
if (!string.IsNullOrEmpty(Command.Observacao)) whereClauses.Add($"Observacao like @Observacao");
if (!string.IsNullOrEmpty(Command.OcorrenciaId)) dict["OcorrenciaId"] = $"%{Command.OcorrenciaId}%";
if (!string.IsNullOrEmpty(Command.OcorrenciaId)) whereClauses.Add($"OcorrenciaId like @OcorrenciaId");
if (!string.IsNullOrEmpty(Command.Armazem)) dict["Armazem"] = $"%{Command.Armazem}%";
if (!string.IsNullOrEmpty(Command.Armazem)) whereClauses.Add($"Armazem like @Armazem");
if (!string.IsNullOrEmpty(Command.Endereco)) dict["Endereco"] = $"%{Command.Endereco}%";
if (!string.IsNullOrEmpty(Command.Endereco)) whereClauses.Add($"Endereco like @Endereco");
if (!string.IsNullOrEmpty(Command.Estorno)) dict["Estorno"] = $"%{Command.Estorno}%";
if (!string.IsNullOrEmpty(Command.Estorno)) whereClauses.Add($"Estorno like @Estorno");
if (Command.SequenciaTransformacao.HasValue) dict["SequenciaTransformacao"] = Command.SequenciaTransformacao.Value;
if (Command.SequenciaTransformacao.HasValue) whereClauses.Add($"SequenciaTransformacao = @SequenciaTransformacao");
if (Command.SequenciaRepeticao.HasValue) dict["SequenciaRepeticao"] = Command.SequenciaRepeticao.Value;
if (Command.SequenciaRepeticao.HasValue) whereClauses.Add($"SequenciaRepeticao = @SequenciaRepeticao");
if (!string.IsNullOrEmpty(Command.ObsOpParcial)) dict["ObsOpParcial"] = $"%{Command.ObsOpParcial}%";
if (!string.IsNullOrEmpty(Command.ObsOpParcial)) whereClauses.Add($"ObsOpParcial like @ObsOpParcial");
if (!string.IsNullOrEmpty(Command.OcoIdOpParcial)) dict["OcoIdOpParcial"] = $"%{Command.OcoIdOpParcial}%";
if (!string.IsNullOrEmpty(Command.OcoIdOpParcial)) whereClauses.Add($"OcoIdOpParcial like @OcoIdOpParcial");
if (!string.IsNullOrEmpty(Command.MOV_ID_INTEGRACAO)) dict["MOV_ID_INTEGRACAO"] = $"%{Command.MOV_ID_INTEGRACAO}%";
if (!string.IsNullOrEmpty(Command.MOV_ID_INTEGRACAO)) whereClauses.Add($"MOV_ID_INTEGRACAO like @MOV_ID_INTEGRACAO");
if (!string.IsNullOrEmpty(Command.MOV_ID_INTEGRACAO_ERP)) dict["MOV_ID_INTEGRACAO_ERP"] = $"%{Command.MOV_ID_INTEGRACAO_ERP}%";
if (!string.IsNullOrEmpty(Command.MOV_ID_INTEGRACAO_ERP)) whereClauses.Add($"MOV_ID_INTEGRACAO_ERP like @MOV_ID_INTEGRACAO_ERP");
if (!string.IsNullOrEmpty(Command.CAR_ID)) dict["CAR_ID"] = $"%{Command.CAR_ID}%";
if (!string.IsNullOrEmpty(Command.CAR_ID)) whereClauses.Add($"CAR_ID like @CAR_ID");
if (Command.MOV_ID_DESTINO.HasValue) dict["MOV_ID_DESTINO"] = Command.MOV_ID_DESTINO.Value;
if (Command.MOV_ID_DESTINO.HasValue) whereClauses.Add($"MOV_ID_DESTINO = @MOV_ID_DESTINO");
if (!string.IsNullOrEmpty(Command.PRO_ID_DESTINO)) dict["PRO_ID_DESTINO"] = $"%{Command.PRO_ID_DESTINO}%";
if (!string.IsNullOrEmpty(Command.PRO_ID_DESTINO)) whereClauses.Add($"PRO_ID_DESTINO like @PRO_ID_DESTINO");
if (!string.IsNullOrEmpty(Command.MOV_LOTE_DESTINO)) dict["MOV_LOTE_DESTINO"] = $"%{Command.MOV_LOTE_DESTINO}%";
if (!string.IsNullOrEmpty(Command.MOV_LOTE_DESTINO)) whereClauses.Add($"MOV_LOTE_DESTINO like @MOV_LOTE_DESTINO");
if (!string.IsNullOrEmpty(Command.MOV_SUB_LOTE_DESTINO)) dict["MOV_SUB_LOTE_DESTINO"] = $"%{Command.MOV_SUB_LOTE_DESTINO}%";
if (!string.IsNullOrEmpty(Command.MOV_SUB_LOTE_DESTINO)) whereClauses.Add($"MOV_SUB_LOTE_DESTINO like @MOV_SUB_LOTE_DESTINO");
if (Command.MOV_ID_ORIGEM.HasValue) dict["MOV_ID_ORIGEM"] = Command.MOV_ID_ORIGEM.Value;
if (Command.MOV_ID_ORIGEM.HasValue) whereClauses.Add($"MOV_ID_ORIGEM = @MOV_ID_ORIGEM");
if (!string.IsNullOrEmpty(Command.PRO_ID_ORIGEM)) dict["PRO_ID_ORIGEM"] = $"%{Command.PRO_ID_ORIGEM}%";
if (!string.IsNullOrEmpty(Command.PRO_ID_ORIGEM)) whereClauses.Add($"PRO_ID_ORIGEM like @PRO_ID_ORIGEM");
if (!string.IsNullOrEmpty(Command.MOV_LOTE_ORIGEM)) dict["MOV_LOTE_ORIGEM"] = $"%{Command.MOV_LOTE_ORIGEM}%";
if (!string.IsNullOrEmpty(Command.MOV_LOTE_ORIGEM)) whereClauses.Add($"MOV_LOTE_ORIGEM like @MOV_LOTE_ORIGEM");
if (!string.IsNullOrEmpty(Command.MOV_SUB_LOTE_ORIGEM)) dict["MOV_SUB_LOTE_ORIGEM"] = $"%{Command.MOV_SUB_LOTE_ORIGEM}%";
if (!string.IsNullOrEmpty(Command.MOV_SUB_LOTE_ORIGEM)) whereClauses.Add($"MOV_SUB_LOTE_ORIGEM like @MOV_SUB_LOTE_ORIGEM");
if (Command.MOV_TYPE.HasValue) dict["MOV_TYPE"] = Command.MOV_TYPE.Value;
if (Command.MOV_TYPE.HasValue) whereClauses.Add($"MOV_TYPE = @MOV_TYPE");
if (!string.IsNullOrEmpty(Command.MOV_DOC)) dict["MOV_DOC"] = $"%{Command.MOV_DOC}%";
if (!string.IsNullOrEmpty(Command.MOV_DOC)) whereClauses.Add($"MOV_DOC like @MOV_DOC");
if (!string.IsNullOrEmpty(Command.MOV_APROVEITAMENTO)) dict["MOV_APROVEITAMENTO"] = $"%{Command.MOV_APROVEITAMENTO}%";
if (!string.IsNullOrEmpty(Command.MOV_APROVEITAMENTO)) whereClauses.Add($"MOV_APROVEITAMENTO like @MOV_APROVEITAMENTO");
if (!string.IsNullOrEmpty(Command.MOV_RETIDO)) dict["MOV_RETIDO"] = $"%{Command.MOV_RETIDO}%";
if (!string.IsNullOrEmpty(Command.MOV_RETIDO)) whereClauses.Add($"MOV_RETIDO like @MOV_RETIDO");
if (!string.IsNullOrEmpty(Command.MOV_VINCOS_ONDULADEIRA)) dict["MOV_VINCOS_ONDULADEIRA"] = $"%{Command.MOV_VINCOS_ONDULADEIRA}%";
if (!string.IsNullOrEmpty(Command.MOV_VINCOS_ONDULADEIRA)) whereClauses.Add($"MOV_VINCOS_ONDULADEIRA like @MOV_VINCOS_ONDULADEIRA");
if (!string.IsNullOrEmpty(Command.BOL_ID)) dict["BOL_ID"] = $"%{Command.BOL_ID}%";
if (!string.IsNullOrEmpty(Command.BOL_ID)) whereClauses.Add($"BOL_ID like @BOL_ID");
if (!string.IsNullOrEmpty(Command.ORD_ID_ORIGEM)) dict["ORD_ID_ORIGEM"] = $"%{Command.ORD_ID_ORIGEM}%";
if (!string.IsNullOrEmpty(Command.ORD_ID_ORIGEM)) whereClauses.Add($"ORD_ID_ORIGEM like @ORD_ID_ORIGEM");
if (Command.COR_SEQUENCIA.HasValue) dict["COR_SEQUENCIA"] = Command.COR_SEQUENCIA.Value;
if (Command.COR_SEQUENCIA.HasValue) whereClauses.Add($"COR_SEQUENCIA = @COR_SEQUENCIA");
if (Command.VER_ID.HasValue) dict["VER_ID"] = Command.VER_ID.Value;
if (Command.VER_ID.HasValue) whereClauses.Add($"VER_ID = @VER_ID");
if (!string.IsNullOrEmpty(Command.MOV_TIPO_CUSTO)) dict["MOV_TIPO_CUSTO"] = $"%{Command.MOV_TIPO_CUSTO}%";
if (!string.IsNullOrEmpty(Command.MOV_TIPO_CUSTO)) whereClauses.Add($"MOV_TIPO_CUSTO like @MOV_TIPO_CUSTO");
if (!string.IsNullOrEmpty(Command.MOV_GRUPO_CONTABIL)) dict["MOV_GRUPO_CONTABIL"] = $"%{Command.MOV_GRUPO_CONTABIL}%";
if (!string.IsNullOrEmpty(Command.MOV_GRUPO_CONTABIL)) whereClauses.Add($"MOV_GRUPO_CONTABIL like @MOV_GRUPO_CONTABIL");
if (!string.IsNullOrEmpty(Command.FOR_ID)) dict["FOR_ID"] = $"%{Command.FOR_ID}%";
if (!string.IsNullOrEmpty(Command.FOR_ID)) whereClauses.Add($"FOR_ID like @FOR_ID");
if (!string.IsNullOrEmpty(Command.CLI_ID)) dict["CLI_ID"] = $"%{Command.CLI_ID}%";
if (!string.IsNullOrEmpty(Command.CLI_ID)) whereClauses.Add($"CLI_ID like @CLI_ID");
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
        public QueryModel MovimentoEstoqueOrderIdQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select ORD_ID from Order ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["ORD_ID"] = numero; //01
                      whereClauses.Add($" ORD_ID = @ORD_ID");//01 
                 }
                 else 
                 {
                      dict["ORD_ID"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" ORD_ID like @ORD_ID ");//02
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
        public QueryModel MovimentoEstoqueTipoQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select TIP_ID from TipoMovimentoEstoque ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["TIP_ID"] = numero; //01
                      whereClauses.Add($" TIP_ID = @TIP_ID");//01 
                 }
                 else 
                 {
                      dict["TIP_ID"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" TIP_ID like @TIP_ID ");//02
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
        public QueryModel MovimentoEstoqueTurnoIdQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select Id, Descricao from Turno ";
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
        public QueryModel MovimentoEstoqueTurmaIdQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select Id, Descricao from Turma ";
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
        public QueryModel MovimentoEstoqueOcorrenciaIdQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel MovimentoEstoqueCLI_IDQuery(Command.Patterns.Command.SearchFKCommand Command )
        {
            this.Query = $@" select CLI_ID from Cliente ";
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            if (!string.IsNullOrEmpty(Command.searchFK)) 
            {
                 if (int.TryParse(Command.searchFK, out int numero)) 
                 {
                      dict["CLI_ID"] = numero; //01
                      whereClauses.Add($" CLI_ID = @CLI_ID");//01 
                 }
                 else 
                 {
                      dict["CLI_ID"] = $"%{Command.searchFK}%";//02 
                      whereClauses.Add($" CLI_ID like @CLI_ID ");//02
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
        public QueryModel MovimentoEstoqueTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command )
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
        public QueryModel MovimentoEstoqueUserIdQuery(Command.Patterns.Command.SearchFKCommand Command )
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
            this.Query = $"SELECT 1 FROM MovimentoEstoque ";
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
        public QueryModel ExistsByProdutoIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM MovimentoEstoque ";
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
        public QueryModel ExistsByOrderIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["OrderId"] = value; //04
                      whereClauses.Add($" OrderId = @OrderId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTipoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Tipo"] = value; //04
                      whereClauses.Add($" Tipo = @Tipo ");//04
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
            this.Query = $"SELECT 1 FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TurnoId"] = value; //04
                      whereClauses.Add($" TurnoId = @TurnoId ");//04
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
            this.Query = $"SELECT 1 FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TurmaId"] = value; //04
                      whereClauses.Add($" TurmaId = @TurmaId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByQuantidadeQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Quantidade"] = value; //04
                      whereClauses.Add($" Quantidade = @Quantidade ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMOV_PESO_UNITARIOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MOV_PESO_UNITARIO"] = value; //04
                      whereClauses.Add($" MOV_PESO_UNITARIO = @MOV_PESO_UNITARIO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByDataHoraCriacaoQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["DataHoraCriacao"] = value; //04
                      whereClauses.Add($" DataHoraCriacao = @DataHoraCriacao ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByDataHoraEmissaoQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["DataHoraEmissao"] = value; //04
                      whereClauses.Add($" DataHoraEmissao = @DataHoraEmissao ");//04
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
            this.Query = $"SELECT 1 FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["DiaTurma"] = value; //04
                      whereClauses.Add($" DiaTurma = @DiaTurma ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByLoteQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Lote"] = value; //04
                      whereClauses.Add($" Lote = @Lote ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsBySubLoteQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["SubLote"] = value; //04
                      whereClauses.Add($" SubLote = @SubLote ");//04
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
            this.Query = $"SELECT 1 FROM MovimentoEstoque ";
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
        public QueryModel ExistsByUSE_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["USE_ID"] = value; //04
                      whereClauses.Add($" USE_ID = @USE_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByObservacaoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Observacao"] = value; //04
                      whereClauses.Add($" Observacao = @Observacao ");//04
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
            this.Query = $"SELECT 1 FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["OcorrenciaId"] = value; //04
                      whereClauses.Add($" OcorrenciaId = @OcorrenciaId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByArmazemQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Armazem"] = value; //04
                      whereClauses.Add($" Armazem = @Armazem ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByEnderecoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Endereco"] = value; //04
                      whereClauses.Add($" Endereco = @Endereco ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByEstornoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Estorno"] = value; //04
                      whereClauses.Add($" Estorno = @Estorno ");//04
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
            this.Query = $"SELECT 1 FROM MovimentoEstoque ";
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
        public QueryModel ExistsBySequenciaRepeticaoQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["SequenciaRepeticao"] = value; //04
                      whereClauses.Add($" SequenciaRepeticao = @SequenciaRepeticao ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByObsOpParcialQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ObsOpParcial"] = value; //04
                      whereClauses.Add($" ObsOpParcial = @ObsOpParcial ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByOcoIdOpParcialQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["OcoIdOpParcial"] = value; //04
                      whereClauses.Add($" OcoIdOpParcial = @OcoIdOpParcial ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMOV_ID_INTEGRACAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MOV_ID_INTEGRACAO"] = value; //04
                      whereClauses.Add($" MOV_ID_INTEGRACAO = @MOV_ID_INTEGRACAO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMOV_ID_INTEGRACAO_ERPQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MOV_ID_INTEGRACAO_ERP"] = value; //04
                      whereClauses.Add($" MOV_ID_INTEGRACAO_ERP = @MOV_ID_INTEGRACAO_ERP ");//04
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
            this.Query = $"SELECT 1 FROM MovimentoEstoque ";
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
        public QueryModel ExistsByMOV_ID_DESTINOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MOV_ID_DESTINO"] = value; //04
                      whereClauses.Add($" MOV_ID_DESTINO = @MOV_ID_DESTINO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_ID_DESTINOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ID_DESTINO"] = value; //04
                      whereClauses.Add($" PRO_ID_DESTINO = @PRO_ID_DESTINO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMOV_LOTE_DESTINOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MOV_LOTE_DESTINO"] = value; //04
                      whereClauses.Add($" MOV_LOTE_DESTINO = @MOV_LOTE_DESTINO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMOV_SUB_LOTE_DESTINOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MOV_SUB_LOTE_DESTINO"] = value; //04
                      whereClauses.Add($" MOV_SUB_LOTE_DESTINO = @MOV_SUB_LOTE_DESTINO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMOV_ID_ORIGEMQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MOV_ID_ORIGEM"] = value; //04
                      whereClauses.Add($" MOV_ID_ORIGEM = @MOV_ID_ORIGEM ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPRO_ID_ORIGEMQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ID_ORIGEM"] = value; //04
                      whereClauses.Add($" PRO_ID_ORIGEM = @PRO_ID_ORIGEM ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMOV_LOTE_ORIGEMQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MOV_LOTE_ORIGEM"] = value; //04
                      whereClauses.Add($" MOV_LOTE_ORIGEM = @MOV_LOTE_ORIGEM ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMOV_SUB_LOTE_ORIGEMQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MOV_SUB_LOTE_ORIGEM"] = value; //04
                      whereClauses.Add($" MOV_SUB_LOTE_ORIGEM = @MOV_SUB_LOTE_ORIGEM ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMOV_TYPEQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MOV_TYPE"] = value; //04
                      whereClauses.Add($" MOV_TYPE = @MOV_TYPE ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMOV_DOCQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MOV_DOC"] = value; //04
                      whereClauses.Add($" MOV_DOC = @MOV_DOC ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMOV_APROVEITAMENTOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MOV_APROVEITAMENTO"] = value; //04
                      whereClauses.Add($" MOV_APROVEITAMENTO = @MOV_APROVEITAMENTO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMOV_RETIDOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MOV_RETIDO"] = value; //04
                      whereClauses.Add($" MOV_RETIDO = @MOV_RETIDO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMOV_VINCOS_ONDULADEIRAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MOV_VINCOS_ONDULADEIRA"] = value; //04
                      whereClauses.Add($" MOV_VINCOS_ONDULADEIRA = @MOV_VINCOS_ONDULADEIRA ");//04
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
            this.Query = $"SELECT 1 FROM MovimentoEstoque ";
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
        public QueryModel ExistsByORD_ID_ORIGEMQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_ID_ORIGEM"] = value; //04
                      whereClauses.Add($" ORD_ID_ORIGEM = @ORD_ID_ORIGEM ");//04
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
            this.Query = $"SELECT 1 FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["COR_SEQUENCIA"] = value; //04
                      whereClauses.Add($" COR_SEQUENCIA = @COR_SEQUENCIA ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByVER_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["VER_ID"] = value; //04
                      whereClauses.Add($" VER_ID = @VER_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMOV_TIPO_CUSTOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MOV_TIPO_CUSTO"] = value; //04
                      whereClauses.Add($" MOV_TIPO_CUSTO = @MOV_TIPO_CUSTO ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByMOV_GRUPO_CONTABILQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MOV_GRUPO_CONTABIL"] = value; //04
                      whereClauses.Add($" MOV_GRUPO_CONTABIL = @MOV_GRUPO_CONTABIL ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByFOR_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FOR_ID"] = value; //04
                      whereClauses.Add($" FOR_ID = @FOR_ID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCLI_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CLI_ID"] = value; //04
                      whereClauses.Add($" CLI_ID = @CLI_ID ");//04
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
            this.Query = $"SELECT 1 FROM MovimentoEstoque ";
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
            this.Query = $"SELECT 1 FROM MovimentoEstoque ";
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
            this.Query = $"SELECT 1 FROM MovimentoEstoque ";
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
            this.Query = $"SELECT 1 FROM MovimentoEstoque ";
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
            this.Query = $"SELECT Id, ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId FROM MovimentoEstoque ";
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
        public QueryModel FirstByProdutoIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId FROM MovimentoEstoque ";
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
        public QueryModel FirstByOrderIdQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["OrderId"] = value; //06
                      whereClauses.Add($" OrderId = @OrderId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTipoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Tipo"] = value; //06
                      whereClauses.Add($" Tipo = @Tipo ");//06
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
            this.Query = $"SELECT Id, ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TurnoId"] = value; //06
                      whereClauses.Add($" TurnoId = @TurnoId ");//06
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
            this.Query = $"SELECT Id, ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["TurmaId"] = value; //06
                      whereClauses.Add($" TurmaId = @TurmaId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByQuantidadeQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Quantidade"] = value; //06
                      whereClauses.Add($" Quantidade = @Quantidade ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMOV_PESO_UNITARIOQuery(Decimal value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MOV_PESO_UNITARIO"] = value; //06
                      whereClauses.Add($" MOV_PESO_UNITARIO = @MOV_PESO_UNITARIO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByDataHoraCriacaoQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["DataHoraCriacao"] = value; //06
                      whereClauses.Add($" DataHoraCriacao = @DataHoraCriacao ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByDataHoraEmissaoQuery(DateTime value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["DataHoraEmissao"] = value; //06
                      whereClauses.Add($" DataHoraEmissao = @DataHoraEmissao ");//06
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
            this.Query = $"SELECT Id, ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["DiaTurma"] = value; //06
                      whereClauses.Add($" DiaTurma = @DiaTurma ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByLoteQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Lote"] = value; //06
                      whereClauses.Add($" Lote = @Lote ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstBySubLoteQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["SubLote"] = value; //06
                      whereClauses.Add($" SubLote = @SubLote ");//06
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
            this.Query = $"SELECT Id, ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId FROM MovimentoEstoque ";
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
        public QueryModel FirstByUSE_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["USE_ID"] = value; //06
                      whereClauses.Add($" USE_ID = @USE_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByObservacaoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Observacao"] = value; //06
                      whereClauses.Add($" Observacao = @Observacao ");//06
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
            this.Query = $"SELECT Id, ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["OcorrenciaId"] = value; //06
                      whereClauses.Add($" OcorrenciaId = @OcorrenciaId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByArmazemQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Armazem"] = value; //06
                      whereClauses.Add($" Armazem = @Armazem ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByEnderecoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Endereco"] = value; //06
                      whereClauses.Add($" Endereco = @Endereco ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByEstornoQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["Estorno"] = value; //06
                      whereClauses.Add($" Estorno = @Estorno ");//06
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
            this.Query = $"SELECT Id, ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId FROM MovimentoEstoque ";
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
        public QueryModel FirstBySequenciaRepeticaoQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["SequenciaRepeticao"] = value; //06
                      whereClauses.Add($" SequenciaRepeticao = @SequenciaRepeticao ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByObsOpParcialQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ObsOpParcial"] = value; //06
                      whereClauses.Add($" ObsOpParcial = @ObsOpParcial ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByOcoIdOpParcialQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["OcoIdOpParcial"] = value; //06
                      whereClauses.Add($" OcoIdOpParcial = @OcoIdOpParcial ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMOV_ID_INTEGRACAOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MOV_ID_INTEGRACAO"] = value; //06
                      whereClauses.Add($" MOV_ID_INTEGRACAO = @MOV_ID_INTEGRACAO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMOV_ID_INTEGRACAO_ERPQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MOV_ID_INTEGRACAO_ERP"] = value; //06
                      whereClauses.Add($" MOV_ID_INTEGRACAO_ERP = @MOV_ID_INTEGRACAO_ERP ");//06
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
            this.Query = $"SELECT Id, ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId FROM MovimentoEstoque ";
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
        public QueryModel FirstByMOV_ID_DESTINOQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MOV_ID_DESTINO"] = value; //06
                      whereClauses.Add($" MOV_ID_DESTINO = @MOV_ID_DESTINO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_ID_DESTINOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ID_DESTINO"] = value; //06
                      whereClauses.Add($" PRO_ID_DESTINO = @PRO_ID_DESTINO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMOV_LOTE_DESTINOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MOV_LOTE_DESTINO"] = value; //06
                      whereClauses.Add($" MOV_LOTE_DESTINO = @MOV_LOTE_DESTINO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMOV_SUB_LOTE_DESTINOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MOV_SUB_LOTE_DESTINO"] = value; //06
                      whereClauses.Add($" MOV_SUB_LOTE_DESTINO = @MOV_SUB_LOTE_DESTINO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMOV_ID_ORIGEMQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MOV_ID_ORIGEM"] = value; //06
                      whereClauses.Add($" MOV_ID_ORIGEM = @MOV_ID_ORIGEM ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPRO_ID_ORIGEMQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["PRO_ID_ORIGEM"] = value; //06
                      whereClauses.Add($" PRO_ID_ORIGEM = @PRO_ID_ORIGEM ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMOV_LOTE_ORIGEMQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MOV_LOTE_ORIGEM"] = value; //06
                      whereClauses.Add($" MOV_LOTE_ORIGEM = @MOV_LOTE_ORIGEM ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMOV_SUB_LOTE_ORIGEMQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MOV_SUB_LOTE_ORIGEM"] = value; //06
                      whereClauses.Add($" MOV_SUB_LOTE_ORIGEM = @MOV_SUB_LOTE_ORIGEM ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMOV_TYPEQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MOV_TYPE"] = value; //06
                      whereClauses.Add($" MOV_TYPE = @MOV_TYPE ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMOV_DOCQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MOV_DOC"] = value; //06
                      whereClauses.Add($" MOV_DOC = @MOV_DOC ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMOV_APROVEITAMENTOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MOV_APROVEITAMENTO"] = value; //06
                      whereClauses.Add($" MOV_APROVEITAMENTO = @MOV_APROVEITAMENTO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMOV_RETIDOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MOV_RETIDO"] = value; //06
                      whereClauses.Add($" MOV_RETIDO = @MOV_RETIDO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMOV_VINCOS_ONDULADEIRAQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MOV_VINCOS_ONDULADEIRA"] = value; //06
                      whereClauses.Add($" MOV_VINCOS_ONDULADEIRA = @MOV_VINCOS_ONDULADEIRA ");//06
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
            this.Query = $"SELECT Id, ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId FROM MovimentoEstoque ";
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
        public QueryModel FirstByORD_ID_ORIGEMQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["ORD_ID_ORIGEM"] = value; //06
                      whereClauses.Add($" ORD_ID_ORIGEM = @ORD_ID_ORIGEM ");//06
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
            this.Query = $"SELECT Id, ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["COR_SEQUENCIA"] = value; //06
                      whereClauses.Add($" COR_SEQUENCIA = @COR_SEQUENCIA ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByVER_IDQuery(int value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["VER_ID"] = value; //06
                      whereClauses.Add($" VER_ID = @VER_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMOV_TIPO_CUSTOQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MOV_TIPO_CUSTO"] = value; //06
                      whereClauses.Add($" MOV_TIPO_CUSTO = @MOV_TIPO_CUSTO ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByMOV_GRUPO_CONTABILQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["MOV_GRUPO_CONTABIL"] = value; //06
                      whereClauses.Add($" MOV_GRUPO_CONTABIL = @MOV_GRUPO_CONTABIL ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByFOR_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["FOR_ID"] = value; //06
                      whereClauses.Add($" FOR_ID = @FOR_ID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCLI_IDQuery(string value )
        {
            this.Parameters = null;
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT Id, ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId FROM MovimentoEstoque ";
 dict["TenantID"] = _executionContext.TenantID;
 whereClauses.Add($"TenantID = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"Deleted = @Deleted");
                      dict["CLI_ID"] = value; //06
                      whereClauses.Add($" CLI_ID = @CLI_ID ");//06
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
            this.Query = $"SELECT Id, ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId FROM MovimentoEstoque ";
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
            this.Query = $"SELECT Id, ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId FROM MovimentoEstoque ";
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
            this.Query = $"SELECT Id, ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId FROM MovimentoEstoque ";
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
            this.Query = $"SELECT Id, ProdutoId, OrderId, Tipo, TurnoId, TurmaId, Quantidade, MOV_PESO_UNITARIO, DataHoraCriacao, DataHoraEmissao, DiaTurma, Lote, SubLote, MaquinaId, USE_ID, Observacao, OcorrenciaId, Armazem, Endereco, Estorno, SequenciaTransformacao, SequenciaRepeticao, ObsOpParcial, OcoIdOpParcial, MOV_ID_INTEGRACAO, MOV_ID_INTEGRACAO_ERP, CAR_ID, MOV_ID_DESTINO, PRO_ID_DESTINO, MOV_LOTE_DESTINO, MOV_SUB_LOTE_DESTINO, MOV_ID_ORIGEM, PRO_ID_ORIGEM, MOV_LOTE_ORIGEM, MOV_SUB_LOTE_ORIGEM, MOV_TYPE, MOV_DOC, MOV_APROVEITAMENTO, MOV_RETIDO, MOV_VINCOS_ONDULADEIRA, BOL_ID, ORD_ID_ORIGEM, COR_SEQUENCIA, VER_ID, MOV_TIPO_CUSTO, MOV_GRUPO_CONTABIL, FOR_ID, CLI_ID, TenantID, Deleted, Changed, UserId FROM MovimentoEstoque ";
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