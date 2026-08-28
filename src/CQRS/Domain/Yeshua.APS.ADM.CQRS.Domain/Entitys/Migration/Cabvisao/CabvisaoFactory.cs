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
                                public class CabvisaoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public CabvisaoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public CabvisaoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ICabvisaoEntity Create(int cab_id, string cab_desc, int cab_status, int use_id )
                            {
                                return Create(null, cab_id, cab_desc, cab_status, use_id);
                            }

                            public ICabvisaoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int cab_id, string cab_desc, int cab_status, int use_id )
                            {
                            var entity = new CabvisaoEntity(cab_id, cab_desc, cab_status, use_id );


                            var trackingMask = _trackingPolicy?.GetMask("Cabvisao", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new CabvisaoDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration