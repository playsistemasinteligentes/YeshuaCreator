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
                                public class yInboxFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public yInboxFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public yInboxFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IyInboxEntity Create(int? id, string messageid, string type, string entitytype, string entityid, string correlationid, string payload, int status, DateTime createdat, int retrycount, string lasterror, DateTime? processingat, DateTime? nextattemptat, int? sagaid, int? sagastepid )
                            {
                                return Create(null, id, messageid, type, entitytype, entityid, correlationid, payload, status, createdat, retrycount, lasterror, processingat, nextattemptat, sagaid, sagastepid);
                            }

                            public IyInboxEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string messageid, string type, string entitytype, string entityid, string correlationid, string payload, int status, DateTime createdat, int retrycount, string lasterror, DateTime? processingat, DateTime? nextattemptat, int? sagaid, int? sagastepid )
                            {
                            var entity = new yInboxEntity(id, messageid, type, entitytype, entityid, correlationid, payload, status, createdat, retrycount, lasterror, processingat, nextattemptat, sagaid, sagastepid );


                            var trackingMask = _trackingPolicy?.GetMask("yInbox", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new yInboxDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration