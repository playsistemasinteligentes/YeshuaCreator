// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeEntityMigration
// </yeshua>



                            namespace Dominio.Entitys
                            {
                                public class LogsDatabaseFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public LogsDatabaseFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public LogsDatabaseFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ILogsDatabaseEntity Create(int logs_id, string logs_table, string logs_key, string logs_key1, string logs_key2, string logs_key3, string logs_key4, string logs_column, string logs_before, string logs_after, string logs_action, DateTime logs_date, int use_id, string logs_origem )
                            {
                                return Create(null, logs_id, logs_table, logs_key, logs_key1, logs_key2, logs_key3, logs_key4, logs_column, logs_before, logs_after, logs_action, logs_date, use_id, logs_origem);
                            }

                            public ILogsDatabaseEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int logs_id, string logs_table, string logs_key, string logs_key1, string logs_key2, string logs_key3, string logs_key4, string logs_column, string logs_before, string logs_after, string logs_action, DateTime logs_date, int use_id, string logs_origem )
                            {
                            var entity = new LogsDatabaseEntity(logs_id, logs_table, logs_key, logs_key1, logs_key2, logs_key3, logs_key4, logs_column, logs_before, logs_after, logs_action, logs_date, use_id, logs_origem );


                            var trackingMask = _trackingPolicy?.GetMask("LogsDatabase", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new LogsDatabaseDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration