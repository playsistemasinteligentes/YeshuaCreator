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
                                public class ySagaFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public ySagaFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public ySagaFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IySagaEntity Create(int? id, string correlationid, string type, int status, string? keycurrentstep, DateTime createdat, DateTime? completedat, string? entitytype, string? entityid, DateTime? nextexecutionat, DateTime? lockedat, string? lockedby )
                            {
                                return Create(null, id, correlationid, type, status, keycurrentstep, createdat, completedat, entitytype, entityid, nextexecutionat, lockedat, lockedby);
                            }

                            public IySagaEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string correlationid, string type, int status, string? keycurrentstep, DateTime createdat, DateTime? completedat, string? entitytype, string? entityid, DateTime? nextexecutionat, DateTime? lockedat, string? lockedby )
                            {
                            var entity = new ySagaEntity(id, correlationid, type, status, keycurrentstep, createdat, completedat, entitytype, entityid, nextexecutionat, lockedat, lockedby );


                            var trackingMask = _trackingPolicy?.GetMask("ySaga", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new ySagaDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration