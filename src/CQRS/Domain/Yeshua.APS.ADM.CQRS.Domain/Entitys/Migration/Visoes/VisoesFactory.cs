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
                                public class VisoesFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public VisoesFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public VisoesFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IVisoesEntity Create(int vis_id, int vis_planid, string vis_formula, int cab_id )
                            {
                                return Create(null, vis_id, vis_planid, vis_formula, cab_id);
                            }

                            public IVisoesEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int vis_id, int vis_planid, string vis_formula, int cab_id )
                            {
                            var entity = new VisoesEntity(vis_id, vis_planid, vis_formula, cab_id );


                            var trackingMask = _trackingPolicy?.GetMask("Visoes", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new VisoesDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration