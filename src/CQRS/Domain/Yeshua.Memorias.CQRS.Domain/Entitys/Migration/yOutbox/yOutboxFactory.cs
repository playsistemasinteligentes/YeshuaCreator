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
                                public class yOutboxFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public yOutboxFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public yOutboxFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IyOutboxEntity Create(int? id, string? messageid, string type, string? entitytype, string? entityid, string? correlationid, string payload, int status, int transporttype, string? transportdata, DateTime createdat, DateTime? sentat, int retrycount, string? lasterror, DateTime? processingat, DateTime? nextattemptat, int? sagaid, int? sagastepid )
                            {
                                return Create(null, id, messageid, type, entitytype, entityid, correlationid, payload, status, transporttype, transportdata, createdat, sentat, retrycount, lasterror, processingat, nextattemptat, sagaid, sagastepid);
                            }

                            public IyOutboxEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string? messageid, string type, string? entitytype, string? entityid, string? correlationid, string payload, int status, int transporttype, string? transportdata, DateTime createdat, DateTime? sentat, int retrycount, string? lasterror, DateTime? processingat, DateTime? nextattemptat, int? sagaid, int? sagastepid )
                            {
                            var entity = new yOutboxEntity(id, messageid, type, entitytype, entityid, correlationid, payload, status, transporttype, transportdata, createdat, sentat, retrycount, lasterror, processingat, nextattemptat, sagaid, sagastepid );


                            var trackingMask = _trackingPolicy?.GetMask("yOutbox", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new yOutboxDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration