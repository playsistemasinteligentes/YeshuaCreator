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
    public class ySagaStepQueryRead : QueryBase, IySagaStepQueryRead
    {
        protected readonly IExecutionContext _executionContext;
        public ySagaStepQueryRead(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel ySagaStepQuery(Command.Read.ySagaStepReadCommand Command , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $@" select [Id], [SagaId], [StepKey], [IndexOrder], [CorrelationId], [Status], [ExecutionCount], [LastExecutionAt], [CompletedAt], [ErrorMessage], [Payload], [RetryCount], [TenantID], [Deleted], [Changed], [UserId] from [ySagaStep] ";
if (Command.Id.HasValue) dict["Id"] = Command.Id.Value;
if (Command.Id.HasValue) whereClauses.Add($"[Id] = @Id");
if (Command.SagaId.HasValue) dict["SagaId"] = Command.SagaId.Value;
if (Command.SagaId.HasValue) whereClauses.Add($"[SagaId] = @SagaId");
if (!string.IsNullOrEmpty(Command.StepKey)) dict["StepKey"] = $"%{Command.StepKey}%";
if (!string.IsNullOrEmpty(Command.StepKey)) whereClauses.Add($"[StepKey] like @StepKey");
if (Command.IndexOrder.HasValue) dict["IndexOrder"] = Command.IndexOrder.Value;
if (Command.IndexOrder.HasValue) whereClauses.Add($"[IndexOrder] = @IndexOrder");
if (!string.IsNullOrEmpty(Command.CorrelationId)) dict["CorrelationId"] = $"%{Command.CorrelationId}%";
if (!string.IsNullOrEmpty(Command.CorrelationId)) whereClauses.Add($"[CorrelationId] like @CorrelationId");
if (Command.Status.HasValue)
{
    dict["Status"] = Command.Status.Value;
    whereClauses.Add($"[Status] = @Status");
}
if (Command.ExecutionCount.HasValue) dict["ExecutionCount"] = Command.ExecutionCount.Value;
if (Command.ExecutionCount.HasValue) whereClauses.Add($"[ExecutionCount] = @ExecutionCount");
if (!string.IsNullOrEmpty(Command.ErrorMessage)) dict["ErrorMessage"] = $"%{Command.ErrorMessage}%";
if (!string.IsNullOrEmpty(Command.ErrorMessage)) whereClauses.Add($"[ErrorMessage] like @ErrorMessage");
if (!string.IsNullOrEmpty(Command.Payload)) dict["Payload"] = $"%{Command.Payload}%";
if (!string.IsNullOrEmpty(Command.Payload)) whereClauses.Add($"[Payload] like @Payload");
if (Command.RetryCount.HasValue) dict["RetryCount"] = Command.RetryCount.Value;
if (Command.RetryCount.HasValue) whereClauses.Add($"[RetryCount] = @RetryCount");
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
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
        public QueryModel ySagaStepSagaIdQuery(Command.Patterns.Command.SearchFKCommand Command , bool TakeOffTenantID = false)
        {
            this.Query = $@" select [Id] from [ySaga] ";
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
        public QueryModel ySagaStepTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command , bool TakeOffTenantID = false)
        {
            this.Query = $@" select [Id], [Nome] from [yTenant] ";
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
        public QueryModel ySagaStepUserIdQuery(Command.Patterns.Command.SearchFKCommand Command , bool TakeOffTenantID = false)
        {
            this.Query = $@" select [Id], [Nome] from [yUser] ";
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
        public QueryModel ExistsByIdQuery(int value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [ySagaStep] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Id"] = value; //04
                      whereClauses.Add($" [Id] = @Id ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsBySagaIdQuery(int value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [ySagaStep] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["SagaId"] = value; //04
                      whereClauses.Add($" [SagaId] = @SagaId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByStepKeyQuery(string value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [ySagaStep] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["StepKey"] = value; //04
                      whereClauses.Add($" [StepKey] = @StepKey ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByIndexOrderQuery(int value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [ySagaStep] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["IndexOrder"] = value; //04
                      whereClauses.Add($" [IndexOrder] = @IndexOrder ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCorrelationIdQuery(string value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [ySagaStep] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CorrelationId"] = value; //04
                      whereClauses.Add($" [CorrelationId] = @CorrelationId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByStatusQuery(int value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [ySagaStep] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Status"] = value; //04
                      whereClauses.Add($" [Status] = @Status ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByExecutionCountQuery(int value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [ySagaStep] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ExecutionCount"] = value; //04
                      whereClauses.Add($" [ExecutionCount] = @ExecutionCount ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByLastExecutionAtQuery(DateTime value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [ySagaStep] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["LastExecutionAt"] = value; //04
                      whereClauses.Add($" [LastExecutionAt] = @LastExecutionAt ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByCompletedAtQuery(DateTime value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [ySagaStep] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CompletedAt"] = value; //04
                      whereClauses.Add($" [CompletedAt] = @CompletedAt ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByErrorMessageQuery(string value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [ySagaStep] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ErrorMessage"] = value; //04
                      whereClauses.Add($" [ErrorMessage] = @ErrorMessage ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByPayloadQuery(string value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [ySagaStep] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Payload"] = value; //04
                      whereClauses.Add($" [Payload] = @Payload ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByRetryCountQuery(int value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [ySagaStep] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["RetryCount"] = value; //04
                      whereClauses.Add($" [RetryCount] = @RetryCount ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByTenantIDQuery(int value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [ySagaStep] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TenantID"] = value; //04
                      whereClauses.Add($" [TenantID] = @TenantID ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByDeletedQuery(bool value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [ySagaStep] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Deleted"] = value; //04
                      whereClauses.Add($" [Deleted] = @Deleted ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByChangedQuery(DateTime value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [ySagaStep] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Changed"] = value; //04
                      whereClauses.Add($" [Changed] = @Changed ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel ExistsByUserIdQuery(int value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT 1 FROM [ySagaStep] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["UserId"] = value; //04
                      whereClauses.Add($" [UserId] = @UserId ");//04
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByIdQuery(int value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [SagaId], [StepKey], [IndexOrder], [CorrelationId], [Status], [ExecutionCount], [LastExecutionAt], [CompletedAt], [ErrorMessage], [Payload], [RetryCount], [TenantID], [Deleted], [Changed], [UserId] FROM [ySagaStep] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Id"] = value; //06
                      whereClauses.Add($" [Id] = @Id ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstBySagaIdQuery(int value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [SagaId], [StepKey], [IndexOrder], [CorrelationId], [Status], [ExecutionCount], [LastExecutionAt], [CompletedAt], [ErrorMessage], [Payload], [RetryCount], [TenantID], [Deleted], [Changed], [UserId] FROM [ySagaStep] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["SagaId"] = value; //06
                      whereClauses.Add($" [SagaId] = @SagaId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByStepKeyQuery(string value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [SagaId], [StepKey], [IndexOrder], [CorrelationId], [Status], [ExecutionCount], [LastExecutionAt], [CompletedAt], [ErrorMessage], [Payload], [RetryCount], [TenantID], [Deleted], [Changed], [UserId] FROM [ySagaStep] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["StepKey"] = value; //06
                      whereClauses.Add($" [StepKey] = @StepKey ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByIndexOrderQuery(int value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [SagaId], [StepKey], [IndexOrder], [CorrelationId], [Status], [ExecutionCount], [LastExecutionAt], [CompletedAt], [ErrorMessage], [Payload], [RetryCount], [TenantID], [Deleted], [Changed], [UserId] FROM [ySagaStep] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["IndexOrder"] = value; //06
                      whereClauses.Add($" [IndexOrder] = @IndexOrder ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCorrelationIdQuery(string value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [SagaId], [StepKey], [IndexOrder], [CorrelationId], [Status], [ExecutionCount], [LastExecutionAt], [CompletedAt], [ErrorMessage], [Payload], [RetryCount], [TenantID], [Deleted], [Changed], [UserId] FROM [ySagaStep] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CorrelationId"] = value; //06
                      whereClauses.Add($" [CorrelationId] = @CorrelationId ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByStatusQuery(int value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [SagaId], [StepKey], [IndexOrder], [CorrelationId], [Status], [ExecutionCount], [LastExecutionAt], [CompletedAt], [ErrorMessage], [Payload], [RetryCount], [TenantID], [Deleted], [Changed], [UserId] FROM [ySagaStep] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Status"] = value; //06
                      whereClauses.Add($" [Status] = @Status ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByExecutionCountQuery(int value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [SagaId], [StepKey], [IndexOrder], [CorrelationId], [Status], [ExecutionCount], [LastExecutionAt], [CompletedAt], [ErrorMessage], [Payload], [RetryCount], [TenantID], [Deleted], [Changed], [UserId] FROM [ySagaStep] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ExecutionCount"] = value; //06
                      whereClauses.Add($" [ExecutionCount] = @ExecutionCount ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByLastExecutionAtQuery(DateTime value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [SagaId], [StepKey], [IndexOrder], [CorrelationId], [Status], [ExecutionCount], [LastExecutionAt], [CompletedAt], [ErrorMessage], [Payload], [RetryCount], [TenantID], [Deleted], [Changed], [UserId] FROM [ySagaStep] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["LastExecutionAt"] = value; //06
                      whereClauses.Add($" [LastExecutionAt] = @LastExecutionAt ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByCompletedAtQuery(DateTime value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [SagaId], [StepKey], [IndexOrder], [CorrelationId], [Status], [ExecutionCount], [LastExecutionAt], [CompletedAt], [ErrorMessage], [Payload], [RetryCount], [TenantID], [Deleted], [Changed], [UserId] FROM [ySagaStep] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["CompletedAt"] = value; //06
                      whereClauses.Add($" [CompletedAt] = @CompletedAt ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByErrorMessageQuery(string value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [SagaId], [StepKey], [IndexOrder], [CorrelationId], [Status], [ExecutionCount], [LastExecutionAt], [CompletedAt], [ErrorMessage], [Payload], [RetryCount], [TenantID], [Deleted], [Changed], [UserId] FROM [ySagaStep] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["ErrorMessage"] = value; //06
                      whereClauses.Add($" [ErrorMessage] = @ErrorMessage ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByPayloadQuery(string value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [SagaId], [StepKey], [IndexOrder], [CorrelationId], [Status], [ExecutionCount], [LastExecutionAt], [CompletedAt], [ErrorMessage], [Payload], [RetryCount], [TenantID], [Deleted], [Changed], [UserId] FROM [ySagaStep] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Payload"] = value; //06
                      whereClauses.Add($" [Payload] = @Payload ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByRetryCountQuery(int value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [SagaId], [StepKey], [IndexOrder], [CorrelationId], [Status], [ExecutionCount], [LastExecutionAt], [CompletedAt], [ErrorMessage], [Payload], [RetryCount], [TenantID], [Deleted], [Changed], [UserId] FROM [ySagaStep] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["RetryCount"] = value; //06
                      whereClauses.Add($" [RetryCount] = @RetryCount ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByTenantIDQuery(int value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [SagaId], [StepKey], [IndexOrder], [CorrelationId], [Status], [ExecutionCount], [LastExecutionAt], [CompletedAt], [ErrorMessage], [Payload], [RetryCount], [TenantID], [Deleted], [Changed], [UserId] FROM [ySagaStep] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["TenantID"] = value; //06
                      whereClauses.Add($" [TenantID] = @TenantID ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByDeletedQuery(bool value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [SagaId], [StepKey], [IndexOrder], [CorrelationId], [Status], [ExecutionCount], [LastExecutionAt], [CompletedAt], [ErrorMessage], [Payload], [RetryCount], [TenantID], [Deleted], [Changed], [UserId] FROM [ySagaStep] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Deleted"] = value; //06
                      whereClauses.Add($" [Deleted] = @Deleted ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByChangedQuery(DateTime value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [SagaId], [StepKey], [IndexOrder], [CorrelationId], [Status], [ExecutionCount], [LastExecutionAt], [CompletedAt], [ErrorMessage], [Payload], [RetryCount], [TenantID], [Deleted], [Changed], [UserId] FROM [ySagaStep] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
 dict["Deleted"] = 0;
 whereClauses.Add($"[Deleted] = @Deleted");
                      dict["Changed"] = value; //06
                      whereClauses.Add($" [Changed] = @Changed ");//06
            if (whereClauses.Any()) 
            this.Query += $" WHERE ({string.Join(" AND ", whereClauses)})"; 
            this.Parameters = parameters;
            return new QueryModel(this.Query, parameters);
        }
        public QueryModel FirstByUserIdQuery(int value , bool TakeOffTenantID = false)
        {
            var whereClauses = new List<string>();
            dynamic parameters = new ExpandoObject();
            var dict = (IDictionary<string, object>)parameters;
            this.Query = $"SELECT [Id], [SagaId], [StepKey], [IndexOrder], [CorrelationId], [Status], [ExecutionCount], [LastExecutionAt], [CompletedAt], [ErrorMessage], [Payload], [RetryCount], [TenantID], [Deleted], [Changed], [UserId] FROM [ySagaStep] ";
if (!TakeOffTenantID)  dict["TenantID"] = _executionContext.TenantID;
if (!TakeOffTenantID)  whereClauses.Add($"[TenantID] = @TenantID");
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