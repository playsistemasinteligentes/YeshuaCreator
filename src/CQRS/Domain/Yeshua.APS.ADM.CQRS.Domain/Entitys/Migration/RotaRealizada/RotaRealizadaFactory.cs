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
                                public class RotaRealizadaFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public RotaRealizadaFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public RotaRealizadaFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IRotaRealizadaEntity Create(int rot_id, string car_id, DateTime? rot_data_hora, Decimal? rot_lat, Decimal? rot_long )
                            {
                                return Create(null, rot_id, car_id, rot_data_hora, rot_lat, rot_long);
                            }

                            public IRotaRealizadaEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int rot_id, string car_id, DateTime? rot_data_hora, Decimal? rot_lat, Decimal? rot_long )
                            {
                            var entity = new RotaRealizadaEntity(rot_id, car_id, rot_data_hora, rot_lat, rot_long );


                            var trackingMask = _trackingPolicy?.GetMask("RotaRealizada", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new RotaRealizadaDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration