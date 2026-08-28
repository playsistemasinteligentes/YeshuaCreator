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
                                public class TipoInspecaoItensFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public TipoInspecaoItensFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public TipoInspecaoItensFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ITipoInspecaoItensEntity Create(int? id, int tii_id, int? tiv_id, int? iti_id )
                            {
                                return Create(null, id, tii_id, tiv_id, iti_id);
                            }

                            public ITipoInspecaoItensEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int tii_id, int? tiv_id, int? iti_id )
                            {
                            var entity = new TipoInspecaoItensEntity(id, tii_id, tiv_id, iti_id );


                            var trackingMask = _trackingPolicy?.GetMask("TipoInspecaoItens", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new TipoInspecaoItensDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration