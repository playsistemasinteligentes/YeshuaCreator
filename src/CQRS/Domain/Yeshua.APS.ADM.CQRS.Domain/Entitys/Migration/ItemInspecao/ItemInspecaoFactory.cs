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
                                public class ItemInspecaoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public ItemInspecaoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public ItemInspecaoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IItemInspecaoEntity Create(int? id, int iti_id, string iti_desc )
                            {
                                return Create(null, id, iti_id, iti_desc);
                            }

                            public IItemInspecaoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int iti_id, string iti_desc )
                            {
                            var entity = new ItemInspecaoEntity(id, iti_id, iti_desc );


                            var trackingMask = _trackingPolicy?.GetMask("ItemInspecao", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new ItemInspecaoDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration