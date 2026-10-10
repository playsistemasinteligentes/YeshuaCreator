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
                                public class ySagaStepFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public ySagaStepFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public ySagaStepFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IySagaStepEntity Create(int? id, int sagaid, string stepkey, int indexorder, string correlationid, int status, int executioncount, DateTime? lastexecutionat, DateTime? completedat, string? errormessage, string? payload, int retrycount )
                            {
                                return Create(null, id, sagaid, stepkey, indexorder, correlationid, status, executioncount, lastexecutionat, completedat, errormessage, payload, retrycount);
                            }

                            public IySagaStepEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int sagaid, string stepkey, int indexorder, string correlationid, int status, int executioncount, DateTime? lastexecutionat, DateTime? completedat, string? errormessage, string? payload, int retrycount )
                            {
                            var entity = new ySagaStepEntity(id, sagaid, stepkey, indexorder, correlationid, status, executioncount, lastexecutionat, completedat, errormessage, payload, retrycount );


                            var trackingMask = _trackingPolicy?.GetMask("ySagaStep", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new ySagaStepDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration