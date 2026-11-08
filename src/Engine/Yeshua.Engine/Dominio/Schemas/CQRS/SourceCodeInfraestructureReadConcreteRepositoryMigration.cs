using Dominio.Migration;
using Dominio.Schemas.CQRS.Abstraction;
using Migration.Dominio;
using Migration.Dominio.Schemas.CQRS;
using MyApp.QueryBuilder;
using System.Data.Common;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace Dominio.Schemas.CQRS
{
    public class SourceCodeInfraestructureReadConcreteRepositoryMigration : SourceCodeBase
    {
        private readonly Entity _entity;
        private readonly bool _cacheDecorator;

        public SourceCodeInfraestructureReadConcreteRepositoryMigration(Entity entity, bool cacheDecorator)
            : base()
        {
            _entity = entity;
            _cacheDecorator = cacheDecorator;
        }

        protected override StringBuilder GenerateCode()
        {
            if (_entity.IsInternal)
            {
                return new StringBuilder($$"""
                    using {{CQRSParam.I.NameSpaceUnitOfWork}};
                    using {{CQRSParam.I.NameSpaceIterfaceAplicationServices}};
                    using {{CQRSParam.I.NameSpaceIRepositoryRead}};
                    namespace {{CQRSParam.I.NameSpaceReadRepository}};
                    public partial class {{_entity.EntityName}}ReadRepository : I{{_entity.EntityName}}ReadRepository
                    {
                        protected readonly IUnitOfWork _unitOfWork;
                        protected readonly IExecutionContext _executionContext;
                        public {{_entity.EntityName}}ReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext)
                        {
                            _unitOfWork = unitOfWork;
                            _executionContext = executionContext;
                        }
                    }
                    """);
            }

            var sb = new StringBuilder();
            var itens = _entity.AddColumns.Where(x => x.WhereCanTakeOff).Select(colun => $"bool TakeOff{colun.Name} = false");
            string takeOff = itens.Any() ? ", " + string.Join(", ", itens) : string.Empty;
            itens = _entity.AddColumns.Where(x => x.WhereCanTakeOff).Select(colun => $"TakeOff{colun.Name}");
            string VariavaltakeOff = itens.Any() ? ", " + string.Join(", ", itens) : string.Empty;



            if (_cacheDecorator)
            {
                sb.AppendLine($"using Repositorio.Outputs;");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceInterfaceCommandsPartners};");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceInterfaceRepositoryPartners};");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceIRepositoryRead};");
                sb.AppendLine($"using RepositoryInterfaces.Services;");

                sb.AppendLine();
                sb.AppendLine($"namespace {CQRSParam.I.NameSpaceReadRepository}");
                sb.AppendLine("{");
                sb.AppendLine($"    public partial class {_entity.EntityName}ReadRepositoryCacheDecorator : I{_entity.EntityName}ReadRepository");
                sb.AppendLine("    {");
                sb.AppendLine($"    private readonly I{_entity.EntityName}ReadRepository _inner;");
                sb.AppendLine($"    private readonly ICacheService<{_entity.EntityName}DTO> _cacheById;");
                sb.AppendLine($"    private readonly ICacheService<IEnumerable<{_entity.EntityName}DTO>> _cacheAll;");
                foreach (var column in _entity.AddColumns.Where(x => x.IsFK && !x.IsBackEndField))
                    sb.AppendLine($"    private readonly ICacheService<IEnumerable<{_entity.EntityName}{column.Name}DTO>> _cacheFK{column.Name};");

                sb.AppendLine();
                // Construtor
                // Define as FKs
                var fkColumns = _entity.AddColumns.Where(x => x.IsFK && !x.IsBackEndField).ToList();

                // Início do construtor
                sb.AppendLine($"    public {_entity.EntityName}ReadRepositoryCacheDecorator(");
                sb.AppendLine($"        I{_entity.EntityName}ReadRepository inner,");
                sb.AppendLine($"        ICacheService<{_entity.EntityName}DTO> cacheById,");

                // Só coloca vírgula no `cacheAll` se houver FKs
                if (fkColumns.Any())
                    sb.AppendLine($"        ICacheService<IEnumerable<{_entity.EntityName}DTO>> cacheAll,");
                else
                    sb.AppendLine($"        ICacheService<IEnumerable<{_entity.EntityName}DTO>> cacheAll");

                // Parâmetros das FKs
                for (int i = 0; i < fkColumns.Count; i++)
                {
                    var column = fkColumns[i];
                    var comma = i < fkColumns.Count - 1 ? "," : "";
                    sb.AppendLine($"        ICacheService<IEnumerable<{_entity.EntityName}{column.Name}DTO>> cacheFK{column.Name}{comma}");
                }
                sb.Append("    )");


                sb.AppendLine("    {");
                sb.AppendLine("        _inner = inner;");
                sb.AppendLine("        _cacheById = cacheById;");
                sb.AppendLine("        _cacheAll = cacheAll;");

                foreach (var column in _entity.AddColumns.Where(x => x.IsFK && !x.IsBackEndField))
                    sb.AppendLine($"    _cacheFK{column.Name}=cacheFK{column.Name};");

                sb.AppendLine("    }");
                sb.AppendLine();



                // get{EntityName}
                sb.AppendLine($"    public DataPagination<{_entity.EntityName}DTO> get{_entity.EntityName}(ICommandRead command {takeOff})");
                sb.AppendLine("    {");
                sb.AppendLine("        bool isFullQuery = true; // Ajuste conforme sua lógica de filtros");
                sb.AppendLine($"        var key = $\"{_entity.EntityName}:All:Page:{{command.Paginacao.Page}}:PageZize:{{command.Paginacao.PageSize}}\";");

                sb.AppendLine("        if (isFullQuery)");
                sb.AppendLine("        {");
                sb.AppendLine($"            var cached = _cacheAll.Get(key {VariavaltakeOff});");
                sb.AppendLine("            if (cached != null)");
                sb.AppendLine($"                return new DataPagination<{_entity.EntityName}DTO>(cached, command.Paginacao.Page, command.Paginacao.PageSize);");

                sb.AppendLine();
                sb.AppendLine($"            var data = _inner.get{_entity.EntityName}(command {VariavaltakeOff});");
                sb.AppendLine($"            _cacheAll.Set(key, data.Items, \"{_entity.EntityName}\");");
                sb.AppendLine("            return data;");
                sb.AppendLine("        }");
                sb.AppendLine($"        return _inner.get{_entity.EntityName}(command);");
                sb.AppendLine("    }");


                foreach (var column in _entity.AddColumns.Where(x => x.IsFK && !x.IsBackEndField))
                {


                    sb.AppendLine($"        public IEnumerable<{_entity.EntityName}{column.Name}DTO> get{_entity.EntityName}{CommandType.ReadFK}{column.Name}(object command {takeOff})");
                    sb.AppendLine("        {");
                    sb.AppendLine($"            if (command is {CQRSParam.I.NameSpaceCommandsPartners}.SearchFKCommand c)");
                    sb.AppendLine($"                return get" + _entity.EntityName + CommandType.ReadFK + column.Name + $"(c {VariavaltakeOff});");
                    sb.AppendLine("            throw new NotImplementedException();");
                    sb.AppendLine("        }");

                    sb.AppendLine($"        private IEnumerable<{_entity.EntityName}{column.Name}DTO> get{_entity.EntityName}{CommandType.ReadFK}{column.Name}({CQRSParam.I.NameSpaceCommandsPartners}.SearchFKCommand command {takeOff})");
                    sb.AppendLine("        {");

                    sb.AppendLine($"            string key = $\"{_entity.EntityName}:FK:{column.Name}:{{command.searchFK}}\";");

                    sb.AppendLine($"            var cached = _cacheFK{column.Name}.Get(key {takeOff});");
                    sb.AppendLine("            if (cached != null) return cached;");
                    sb.AppendLine($"            var result = _inner.get{_entity.EntityName}{CommandType.ReadFK}{column.Name}(command {VariavaltakeOff});");
                    sb.AppendLine($"            if (result != null) _cacheFK{column.Name}.Set(key, result,\"{_entity.EntityName}\");");
                    sb.AppendLine($"            return result ?? System.Array.Empty<{_entity.EntityName}{column.Name}DTO>();");
                    sb.AppendLine("        }");


                }


                // GetById
                //sb.AppendLine($"    public {_entity.EntityName}DTO GetById(int id)");
                //sb.AppendLine("    {");
                //sb.AppendLine($"        var key = $\"{_entity.EntityName}:Id:{{id}}\";");
                //sb.AppendLine("        var cached = _cacheById.Get(key);");
                //sb.AppendLine("        if (cached != null) return cached;");
                //sb.AppendLine("        var result = _inner.GetById(id);");
                //sb.AppendLine("        if (result != null) _cacheById.Set(key, result);");
                //sb.AppendLine("        return result;");
                //sb.AppendLine("    }");


                //Exist
                foreach (var column in _entity.AddColumns.Where(x => !x.IsBackEndField && !x.IsProcessingScope))
                {
                    sb.AppendLine($"        public bool ExistsBy{column.Name}({column.getCsharpType()} value {takeOff})");
                    sb.AppendLine("        {");
                    sb.AppendLine($"                return _inner.ExistsBy{column.Name}(value {VariavaltakeOff});");
                    sb.AppendLine("        }");
                    sb.AppendLine();
                }

                //FirstBy
                foreach (var column in _entity.AddColumns.Where(x => !x.IsBackEndField && !x.IsProcessingScope))
                {
                    sb.AppendLine($"        public {_entity.EntityName}DTO FirstBy{column.Name}({column.getCsharpType()} value {takeOff})");
                    sb.AppendLine("        {");
                    sb.AppendLine($"                return _inner.FirstBy{column.Name}(value {VariavaltakeOff});");
                    sb.AppendLine("        }");
                    sb.AppendLine();
                }

                //GetAllBy
                foreach (var column in _entity.AddColumns.Where(x => !x.IsBackEndField && !x.IsProcessingScope))
                {
                    sb.AppendLine($"        public IEnumerable<{_entity.EntityName}DTO> GetAllBy{column.Name}({column.getCsharpType()} value {takeOff})");
                    sb.AppendLine("        {");
                    sb.AppendLine($"                return _inner.GetAllBy{column.Name}(value {VariavaltakeOff});");
                    sb.AppendLine("        }");
                    sb.AppendLine();
                }

                if (IsSagaEntity())
                {
                    sb.AppendLine("        public IEnumerable<ySagaDTO> ClaimRunnableSagas(int limit, string lockedBy, DateTime lockedAt, DateTime nextExecutionAt) => _inner.ClaimRunnableSagas(limit, lockedBy, lockedAt, nextExecutionAt);");
                    sb.AppendLine("        public RepositoryInterfaces.Patterns.Worker.WorkerQueueHealthSnapshot GetRunnableSagaHealth(RepositoryInterfaces.Patterns.Worker.WorkerQueueItemHealthThresholds thresholds) => _inner.GetRunnableSagaHealth(thresholds);");
                    sb.AppendLine("        public IReadOnlyList<RepositoryInterfaces.Patterns.Worker.WorkerQueueSickItem> GetSickSagaItems(RepositoryInterfaces.Patterns.Worker.WorkerQueueItemHealthThresholds thresholds, int limit) => _inner.GetSickSagaItems(thresholds, limit);");
                }


                sb.AppendLine("    }");
                sb.AppendLine("}");
                return sb;
            }
            sb.AppendLine("using Dapper;");
            sb.AppendLine($"using Repositorio.Outputs;");
            sb.AppendLine($"using {CQRSParam.I.NameSpaceInterfaceCommandsPartners};");
            sb.AppendLine($"using {CQRSParam.I.NameSpaceInterfaceRepositoryPartners};");
            sb.AppendLine($"using {CQRSParam.I.NameSpaceReadRepository};");
            sb.AppendLine($"using {CQRSParam.I.NameSpaceIRepositoryRead};");
            sb.AppendLine($"using {CQRSParam.I.NameSpaceIQueryRead};");
            sb.AppendLine($"using {CQRSParam.I.NameSpaceIterfaceAplicationServices};");
            sb.AppendLine($"using {CQRSParam.I.NameSpaceUnitOfWork};");


            sb.AppendLine("using Shered.DB.Connection;");
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Data;");
            sb.AppendLine("using System.Linq;");
            sb.AppendLine("using System.Text;");
            sb.AppendLine("using System.Threading.Tasks;");
            sb.AppendLine();
            sb.AppendLine($"namespace {CQRSParam.I.NameSpaceReadRepository}");
            sb.AppendLine("{");
            sb.AppendLine($"    public partial class {_entity.EntityName}ReadRepository : I{_entity.EntityName}ReadRepository");
            sb.AppendLine("    {");
            sb.AppendLine("        protected readonly IUnitOfWork _unitOfWork;");
            sb.AppendLine("        protected readonly IExecutionContext _executionContext;");
            sb.AppendLine($"       protected readonly I{_entity.EntityName}QueryRead _query;");
            sb.AppendLine();
            sb.AppendLine($"        public {_entity.EntityName}ReadRepository(IUnitOfWork unitOfWork, IExecutionContext executionContext,I{_entity.EntityName}QueryRead query)");
            sb.AppendLine("        {");
            sb.AppendLine("            _unitOfWork = unitOfWork;");
            sb.AppendLine("            _executionContext = executionContext;");
            sb.AppendLine("            _query = query;");
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine($"        partial void TryGet{_entity.EntityName}Custom({CQRSParam.I.NameSpaceCommandRead}.{_entity.EntityName}{CommandType.Read}Command command, ref DataPagination<{_entity.EntityName}DTO> result, ref bool handled);");
            sb.AppendLine();
            sb.AppendLine($"        public DataPagination<{_entity.EntityName}DTO> get{_entity.EntityName}(ICommandRead command {takeOff})");
            sb.AppendLine("         {");
            sb.AppendLine($"            if (command is {CQRSParam.I.NameSpaceCommandRead}.{_entity.EntityName}{CommandType.Read}Command c)");
            sb.AppendLine($"                return get{_entity.EntityName}(c {VariavaltakeOff});");
            sb.AppendLine("            throw new NotImplementedException();");
            sb.AppendLine("        }");

            sb.AppendLine($"        private DataPagination<{_entity.EntityName}DTO> get{_entity.EntityName}({CQRSParam.I.NameSpaceCommandRead}.{_entity.EntityName}{CommandType.Read}Command command {takeOff})");
            sb.AppendLine("        {");
            sb.AppendLine($"            var customResult = new DataPagination<{_entity.EntityName}DTO>();");
            sb.AppendLine("            var customHandled = false;");
            sb.AppendLine($"            TryGet{_entity.EntityName}Custom(command, ref customResult, ref customHandled);");
            sb.AppendLine("            if (customHandled)");
            sb.AppendLine("                return customResult;");
            sb.AppendLine();
            sb.AppendLine($"            var query = _query.{_entity.EntityName}Query(command {VariavaltakeOff});");
            sb.AppendLine();
            sb.AppendLine($"                var itens = _unitOfWork.Query<{_entity.EntityName}DTO>(query.Query,query.Parameters);");
            sb.AppendLine($"                return new DataPagination<{_entity.EntityName}DTO>(");
            sb.AppendLine($"                                itens,");
            sb.AppendLine($"                command.Paginacao?.Page ?? 0,");
            sb.AppendLine($"                command.Paginacao?.PageSize ?? 0,");
            sb.AppendLine($"                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);");
            sb.AppendLine("        }");
            sb.AppendLine();

            foreach (var column in _entity.AddColumns.Where(x => x.IsFK && !x.IsBackEndField))
            {

                sb.AppendLine($"        private IEnumerable<{_entity.EntityName}{column.Name}DTO> get{_entity.EntityName}{CommandType.ReadFK}{column.Name}({CQRSParam.I.NameSpaceCommandsPartners}.SearchFKCommand command {takeOff})");
                sb.AppendLine("        {");
                sb.AppendLine($"            var query = _query.{_entity.EntityName}{column.Name}Query(command {VariavaltakeOff});");
                sb.AppendLine();
                sb.AppendLine($"                var lista = _unitOfWork.Query<{_entity.EntityName}{column.Name}DTO>(query.Query,query.Parameters).ToList();");
                sb.AppendLine("            return lista;");
                sb.AppendLine("        }");
                sb.AppendLine();

                sb.AppendLine($"        public IEnumerable<{_entity.EntityName}{column.Name}DTO> get{_entity.EntityName}{CommandType.ReadFK}{column.Name}(object command {takeOff})");
                sb.AppendLine("        {");

                sb.AppendLine($"            if (command is {CQRSParam.I.NameSpaceCommandPatterns}.SearchFKCommand c)");
                sb.AppendLine("            {");
                sb.AppendLine($"                return get{_entity.EntityName}{CommandType.ReadFK}{column.Name}(c {VariavaltakeOff});");
                sb.AppendLine("            }");
                sb.AppendLine("            throw new NotImplementedException();");

                sb.AppendLine("        }");
                sb.AppendLine();


            }

            //Exist
            foreach (var column in _entity.AddColumns.Where(x => !x.IsBackEndField && !x.IsProcessingScope))
            {
                sb.AppendLine($"        public bool ExistsBy{column.Name}({column.getCsharpType()} value {takeOff})");
                sb.AppendLine("        {");
                sb.AppendLine($"            var query = _query.ExistsBy{column.Name}Query(value {VariavaltakeOff});");
                sb.AppendLine();
                sb.AppendLine("                var result = _unitOfWork.QueryFirstOrDefault<int>(query.Query, query.Parameters);");
                sb.AppendLine("                return result == 1;");
                sb.AppendLine("        }");
                sb.AppendLine();
            }

            //FirstBy
            foreach (var column in _entity.AddColumns.Where(x => !x.IsBackEndField && !x.IsProcessingScope))
            {
                sb.AppendLine($"        public {_entity.EntityName}DTO FirstBy{column.Name}({column.getCsharpType()} value {takeOff})");
                sb.AppendLine("        {");
                sb.AppendLine($"            var query = _query.FirstBy{column.Name}Query(value {VariavaltakeOff});");
                sb.AppendLine();
                sb.AppendLine($"                var result = _unitOfWork.QueryFirstOrDefault<{_entity.EntityName}DTO>(query.Query, query.Parameters);");
                sb.AppendLine("                return result;");
                sb.AppendLine("        }");
                sb.AppendLine();
            }

            //GetAllBy
            foreach (var column in _entity.AddColumns.Where(x => !x.IsBackEndField && !x.IsProcessingScope))
            {
                sb.AppendLine($"        public IEnumerable<{_entity.EntityName}DTO> GetAllBy{column.Name}({column.getCsharpType()} value {takeOff})");
                sb.AppendLine("        {");
                sb.AppendLine($"            var query = _query.FirstBy{column.Name}Query(value {VariavaltakeOff});");
                sb.AppendLine();
                sb.AppendLine($"                var result = _unitOfWork.Query<{_entity.EntityName}DTO>(query.Query,query.Parameters).ToList();");
                sb.AppendLine("                return result;");
                sb.AppendLine("        }");
                sb.AppendLine();
            }


            foreach (var query in _entity.Queries.OfType<IQueryWithMeta>())
            {
                // WhereContexts
                foreach (var ctxName in query.Meta.WhereContextParameters.Keys)
                {
                    string methodName = $"{_entity.EntityName}{ctxName}";

                    sb.AppendLine($"        public DataPagination<{_entity.EntityName}{query.Meta.QueryName}DTO> Get{methodName}(ICommandRead command {takeOff})");
                    sb.AppendLine("        {");
                    sb.AppendLine($"            if (command is {CQRSParam.I.NameSpaceCommandRead}.{methodName}Command c)");
                    sb.AppendLine("             {");
                    sb.AppendLine($"            var query = _query.{methodName}Query(c {VariavaltakeOff});");
                    sb.AppendLine();
                    sb.AppendLine($"                var itens = _unitOfWork.Query<{_entity.EntityName}{query.Meta.QueryName}DTO>(query.Query,query.Parameters);");
                    sb.AppendLine($"                return new DataPagination<{_entity.EntityName}{query.Meta.QueryName}DTO>(");
                    sb.AppendLine($"                                itens,");
                    sb.AppendLine($"                command.Paginacao?.Page ?? 0,");
                    sb.AppendLine($"                command.Paginacao?.PageSize ?? 0,");
                    sb.AppendLine($"                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);");
                    sb.AppendLine("             }");
                    sb.AppendLine("            throw new NotImplementedException();");
                    sb.AppendLine("        }");
                    sb.AppendLine();
                    sb.AppendLine();
                }

                // Wheres
                foreach (var whName in query.Meta.WhereParameters.Keys)
                {
                    string methodName = $"{_entity.EntityName}{whName}";

                    sb.AppendLine($"        public DataPagination<{_entity.EntityName}{query.Meta.QueryName}DTO> Get{methodName}(ICommandRead command {takeOff})");
                    sb.AppendLine("        {");
                    sb.AppendLine($"            if (command is {CQRSParam.I.NameSpaceCommandRead}.{methodName}Command c)");
                    sb.AppendLine("             {");
                    sb.AppendLine($"                var query = _query.{methodName}Query(c {VariavaltakeOff});");
                    sb.AppendLine();

                    sb.AppendLine($"                var itens = _unitOfWork.Query<{_entity.EntityName}{query.Meta.QueryName}DTO>(query.Query,query.Parameters);");
                    sb.AppendLine($"                return new DataPagination<{_entity.EntityName}{query.Meta.QueryName}DTO>(");
                    sb.AppendLine($"                                itens,");
                    sb.AppendLine($"                command.Paginacao?.Page ?? 0,");
                    sb.AppendLine($"                command.Paginacao?.PageSize ?? 0,");
                    sb.AppendLine($"                command.Paginacao?.PageWhithCount ?? false ? itens.Count() : 0);");

                    sb.AppendLine("             }");
                    sb.AppendLine("            throw new NotImplementedException();");
                    sb.AppendLine("        }");
                    sb.AppendLine();
                }
            }

            if (IsSagaEntity())
                AppendSagaQueueHealthMembers(sb);




            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb;
        }
        protected override StringBuilder GenerateCustonCode()
        {
            return new StringBuilder();
        }

        private bool IsSagaEntity() =>
            _entity.EntityName.Equals("ySaga", StringComparison.OrdinalIgnoreCase);

        private static void AppendSagaQueueHealthMembers(StringBuilder sb)
        {
            sb.AppendLine("""
        private static string RunnableSagaPredicate(string saga) => @"
                    " + saga + @".[Status] = 1
                    AND " + saga + @".[ProcessingScope] = @ProcessingScope
                    AND (" + saga + @".[LockedBy] IS NULL OR " + saga + @".[LockedAt] < @StaleLockLimit)
                    AND EXISTS (
                        SELECT 1
                          FROM [ySagaStep] runnableStep
                         WHERE runnableStep.[SagaId] = " + saga + @".[Id]
                           AND runnableStep.[Status] IN (1, 4)
                    )
                    AND (
                        " + saga + @".[NextExecutionAt] IS NULL
                        OR " + saga + @".[NextExecutionAt] <= @Now
                        OR EXISTS (
                            SELECT 1
                              FROM [ySagaStep] pendingApplyStep
                             WHERE pendingApplyStep.[SagaId] = " + saga + @".[Id]
                               AND pendingApplyStep.[Status] = 4
                        )
                    )";

        private static string ItemHealthProjection => @"
                WITH ItemState AS (
                    SELECT s.[Id],
                           COALESCE(NULLIF(s.[CorrelationId], ''), CONVERT(varchar(20), s.[Id])) AS ItemReference,
                           s.[Type] AS ItemType,
                           s.[Status] AS SagaStatus,
                           s.[CreatedAt],
                           s.[NextExecutionAt],
                           s.[LockedAt],
                           s.[LockedBy],
                           s.[OperationalEntityId],
                           s.[RootOperationId],
                           s.[ExecutionId],
                           currentStep.[Status] AS StepStatus,
                           COALESCE(currentStep.[ExecutionCount], 0) AS ExecutionCount,
                           COALESCE(currentStep.[RetryCount], 0) AS RetryCount,
                           currentStep.[LastExecutionAt],
                           currentStep.[ErrorMessage],
                           CASE
                               WHEN currentStep.[Status] = 4
                                   THEN COALESCE(currentStep.[LastExecutionAt], s.[CreatedAt])
                               ELSE COALESCE(s.[NextExecutionAt], s.[CreatedAt])
                           END AS EligibleSince,
                           CASE WHEN " + RunnableSagaPredicate("s") + @"
                                THEN 1 ELSE 0 END AS IsRunnable
                      FROM [ySaga] s
                      OUTER APPLY (
                          SELECT TOP (1)
                                 st.[Status],
                                 st.[ExecutionCount],
                                 st.[RetryCount],
                                 st.[LastExecutionAt],
                                 st.[ErrorMessage]
                            FROM [ySagaStep] st
                           WHERE st.[SagaId] = s.[Id]
                             AND st.[Deleted] = 0
                             AND st.[StepKey] = s.[KeyCurrentStep]
                           ORDER BY st.[IndexOrder]
                      ) currentStep
                     WHERE s.[ProcessingScope] = @ProcessingScope
                       AND s.[Deleted] = 0
                       AND s.[Status] IN (1, 3)
                ),
                ClassifiedItem AS (
                    SELECT *,
                           CASE
                               WHEN [SagaStatus] = 3 OR [StepStatus] = 6 THEN 5
                               WHEN [SagaStatus] = 1
                                AND [LockedBy] IS NOT NULL
                                AND [LockedAt] < @ProcessingStuckLimit THEN 2
                               WHEN [RetryCount] >= @RepeatedFailureCount THEN 4
                               WHEN [ExecutionCount] >= @RecurrentExecutionCount THEN 3
                               WHEN [IsRunnable] = 1
                                AND [EligibleSince] < @ExcessiveWaitLimit THEN 1
                               ELSE 0
                           END AS Disease,
                           CASE WHEN [IsRunnable] = 1
                                THEN DATEDIFF_BIG(SECOND, [EligibleSince], @Now)
                                ELSE 0 END AS EligibleAgeSeconds,
                           CASE WHEN [LockedBy] IS NOT NULL AND [LockedAt] IS NOT NULL
                                THEN DATEDIFF_BIG(SECOND, [LockedAt], @Now)
                                ELSE 0 END AS ProcessingAgeSeconds
                      FROM ItemState
                )";

        public IEnumerable<ySagaDTO> ClaimRunnableSagas(
            int limit,
            string lockedBy,
            DateTime lockedAt,
            DateTime nextExecutionAt)
        {
            var sql = @"
                WITH cte AS (
                    SELECT TOP (@Limit) *
                      FROM [ySaga] WITH (UPDLOCK, READPAST, ROWLOCK)
                     WHERE " + RunnableSagaPredicate("[ySaga]") + @"
                     ORDER BY ISNULL([NextExecutionAt], '1900-01-01') ASC
                )
                UPDATE cte
                   SET [LockedBy] = @LockedBy,
                       [LockedAt] = @LockedAt,
                       [NextExecutionAt] = @NextExecutionAt
                OUTPUT inserted.*;";

            var sagas = _unitOfWork.Query<ySagaDTO>(sql, new
            {
                Limit = Math.Clamp(limit, 1, 100),
                LockedBy = lockedBy,
                LockedAt = lockedAt,
                NextExecutionAt = nextExecutionAt,
                ProcessingScope = _executionContext.ProcessingScope,
                Now = DateTime.UtcNow,
                StaleLockLimit = lockedAt.AddMinutes(-1)
            }).ToList();

            if (sagas.Count == 0)
                return sagas;

            var ids = sagas.Select(saga => saga.id).ToArray();
            var steps = _unitOfWork
                .Query<ySagaStepDTO>(
                    "SELECT * FROM [ySagaStep] WHERE [SagaId] IN @Ids AND [Deleted] = 0",
                    new { Ids = ids })
                .ToList();
            var stepsBySaga = steps
                .GroupBy(step => step.sagaid)
                .ToDictionary(group => group.Key, group => group.ToList());

            foreach (var saga in sagas)
                if (stepsBySaga.TryGetValue(saga.id, out var sagaSteps))
                    saga.Steps = sagaSteps;

            return sagas;
        }

        public RepositoryInterfaces.Patterns.Worker.WorkerQueueHealthSnapshot GetRunnableSagaHealth(
            RepositoryInterfaces.Patterns.Worker.WorkerQueueItemHealthThresholds thresholds)
        {
            var now = DateTime.UtcNow;
            var snapshot = _unitOfWork.Query<RunnableSagaHealthRow>(
                ItemHealthProjection + @"
                SELECT COALESCE(SUM(CASE WHEN [IsRunnable] = 1 THEN 1 ELSE 0 END), 0) AS EligibleCount,
                       MIN(CASE WHEN [IsRunnable] = 1 THEN [EligibleSince] END) AS OldestEligibleAtUtc,
                       COALESCE(SUM(CASE WHEN [Disease] <> 0 THEN 1 ELSE 0 END), 0) AS SickItemCount,
                       COALESCE(SUM(CASE WHEN [Disease] = 1 THEN 1 ELSE 0 END), 0) AS ExcessiveWaitCount,
                       COALESCE(SUM(CASE WHEN [Disease] = 2 THEN 1 ELSE 0 END), 0) AS StaleProcessingCount,
                       COALESCE(SUM(CASE WHEN [Disease] = 3 THEN 1 ELSE 0 END), 0) AS RecurrentExecutionCount,
                       COALESCE(SUM(CASE WHEN [Disease] = 4 THEN 1 ELSE 0 END), 0) AS RepeatedFailureCount,
                       COALESCE(SUM(CASE WHEN [Disease] = 5 THEN 1 ELSE 0 END), 0) AS TerminalFailureCount
                  FROM ClassifiedItem;",
                HealthParameters(now, thresholds))
                .Single();

            var oldestAgeSeconds = snapshot.OldestEligibleAtUtc.HasValue
                ? Math.Max(0, (long)(now - snapshot.OldestEligibleAtUtc.Value).TotalSeconds)
                : 0;

            return new RepositoryInterfaces.Patterns.Worker.WorkerQueueHealthSnapshot(
                snapshot.EligibleCount,
                oldestAgeSeconds,
                snapshot.SickItemCount,
                snapshot.ExcessiveWaitCount,
                snapshot.StaleProcessingCount,
                snapshot.RecurrentExecutionCount,
                snapshot.RepeatedFailureCount,
                snapshot.TerminalFailureCount);
        }

        public IReadOnlyList<RepositoryInterfaces.Patterns.Worker.WorkerQueueSickItem> GetSickSagaItems(
            RepositoryInterfaces.Patterns.Worker.WorkerQueueItemHealthThresholds thresholds,
            int limit)
        {
            var now = DateTime.UtcNow;
            var rows = _unitOfWork.Query<SickSagaItemRow>(
                ItemHealthProjection + @"
                SELECT TOP (@Limit)
                       [ItemReference],
                       [ItemType],
                       [Disease],
                       [EligibleAgeSeconds],
                       [ProcessingAgeSeconds],
                       [ExecutionCount],
                       [RetryCount],
                       CASE
                           WHEN [Disease] = 5 THEN 'terminal_failed'
                           WHEN [Disease] = 4 THEN 'retry_scheduled'
                           WHEN [LockedBy] IS NOT NULL THEN 'processing'
                           WHEN [StepStatus] = 3 THEN 'waiting_response'
                           ELSE 'waiting'
                       END AS LastOutcome,
                       [OperationalEntityId],
                       [RootOperationId],
                       [ExecutionId],
                       CASE WHEN NULLIF([ErrorMessage], '') IS NULL THEN NULL
                            ELSE LOWER(CONVERT(varchar(64), HASHBYTES('SHA2_256', [ErrorMessage]), 2))
                       END AS ErrorSignature
                  FROM ClassifiedItem
                 WHERE [Disease] <> 0
                 ORDER BY CASE [Disease]
                              WHEN 5 THEN 1
                              WHEN 2 THEN 2
                              WHEN 4 THEN 3
                              WHEN 3 THEN 4
                              ELSE 5
                          END,
                          [EligibleAgeSeconds] DESC,
                          [ProcessingAgeSeconds] DESC;",
                new
                {
                    Limit = Math.Clamp(limit, 1, 100),
                    ProcessingScope = _executionContext.ProcessingScope,
                    Now = now,
                    StaleLockLimit = now.AddMinutes(-1),
                    ProcessingStuckLimit = now.AddSeconds(-thresholds.ProcessingStuckSeconds),
                    ExcessiveWaitLimit = now.AddSeconds(-thresholds.ExcessiveWaitSeconds),
                    thresholds.RecurrentExecutionCount,
                    thresholds.RepeatedFailureCount
                });

            return rows
                .Select(row => new RepositoryInterfaces.Patterns.Worker.WorkerQueueSickItem(
                    row.ItemReference,
                    row.ItemType,
                    (RepositoryInterfaces.Patterns.Worker.WorkerQueueItemDisease)row.Disease,
                    row.Disease is 2 or 5 ? "critical" : "warning",
                    Math.Max(0, row.EligibleAgeSeconds),
                    Math.Max(0, row.ProcessingAgeSeconds),
                    row.ExecutionCount,
                    row.RetryCount,
                    row.LastOutcome,
                    row.OperationalEntityId,
                    row.RootOperationId,
                    row.ExecutionId,
                    row.ErrorSignature))
                .ToList();
        }

        private object HealthParameters(
            DateTime now,
            RepositoryInterfaces.Patterns.Worker.WorkerQueueItemHealthThresholds thresholds) => new
            {
                ProcessingScope = _executionContext.ProcessingScope,
                Now = now,
                StaleLockLimit = now.AddMinutes(-1),
                ProcessingStuckLimit = now.AddSeconds(-thresholds.ProcessingStuckSeconds),
                ExcessiveWaitLimit = now.AddSeconds(-thresholds.ExcessiveWaitSeconds),
                thresholds.RecurrentExecutionCount,
                thresholds.RepeatedFailureCount
            };

        private sealed class RunnableSagaHealthRow
        {
            public long EligibleCount { get; init; }
            public DateTime? OldestEligibleAtUtc { get; init; }
            public long SickItemCount { get; init; }
            public long ExcessiveWaitCount { get; init; }
            public long StaleProcessingCount { get; init; }
            public long RecurrentExecutionCount { get; init; }
            public long RepeatedFailureCount { get; init; }
            public long TerminalFailureCount { get; init; }
        }

        private sealed class SickSagaItemRow
        {
            public string ItemReference { get; init; } = string.Empty;
            public string ItemType { get; init; } = string.Empty;
            public int Disease { get; init; }
            public long EligibleAgeSeconds { get; init; }
            public long ProcessingAgeSeconds { get; init; }
            public int ExecutionCount { get; init; }
            public int RetryCount { get; init; }
            public string LastOutcome { get; init; } = string.Empty;
            public string? OperationalEntityId { get; init; }
            public string? RootOperationId { get; init; }
            public string? ExecutionId { get; init; }
            public string? ErrorSignature { get; init; }
        }
""");
        }
    }
}
