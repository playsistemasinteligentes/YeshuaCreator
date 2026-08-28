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
                                public class CanhotosFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public CanhotosFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public CanhotosFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ICanhotosEntity Create(int? id, string car_id, string ord_id, string not_id, DateTime? can_data_entrega, string can_img, Decimal? can_lat_entrega, Decimal? can_long_entrega )
                            {
                                return Create(null, id, car_id, ord_id, not_id, can_data_entrega, can_img, can_lat_entrega, can_long_entrega);
                            }

                            public ICanhotosEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string car_id, string ord_id, string not_id, DateTime? can_data_entrega, string can_img, Decimal? can_lat_entrega, Decimal? can_long_entrega )
                            {
                            var entity = new CanhotosEntity(id, car_id, ord_id, not_id, can_data_entrega, can_img, can_lat_entrega, can_long_entrega );


                            var trackingMask = _trackingPolicy?.GetMask("Canhotos", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new CanhotosDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration