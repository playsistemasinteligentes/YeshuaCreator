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
                                public class RespInspVisualFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public RespInspVisualFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public RespInspVisualFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IRespInspVisualEntity Create(int? id, int riv_id, int? ipv_id, int? iti_id, string riv_status )
                            {
                                return Create(null, id, riv_id, ipv_id, iti_id, riv_status);
                            }

                            public IRespInspVisualEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int riv_id, int? ipv_id, int? iti_id, string riv_status )
                            {
                            var entity = new RespInspVisualEntity(id, riv_id, ipv_id, iti_id, riv_status );


                            var trackingMask = _trackingPolicy?.GetMask("RespInspVisual", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new RespInspVisualDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration