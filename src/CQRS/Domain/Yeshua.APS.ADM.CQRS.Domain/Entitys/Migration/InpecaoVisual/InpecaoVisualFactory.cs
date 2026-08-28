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
                                public class InpecaoVisualFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public InpecaoVisualFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public InpecaoVisualFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IInpecaoVisualEntity Create(int? id, int ipv_id )
                            {
                                return Create(null, id, ipv_id);
                            }

                            public IInpecaoVisualEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int ipv_id )
                            {
                            var entity = new InpecaoVisualEntity(id, ipv_id );


                            var trackingMask = _trackingPolicy?.GetMask("InpecaoVisual", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new InpecaoVisualDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration