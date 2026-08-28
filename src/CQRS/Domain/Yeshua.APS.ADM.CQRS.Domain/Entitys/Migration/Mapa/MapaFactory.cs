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
                                public class MapaFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public MapaFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public MapaFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IMapaEntity Create(int? id, int map_id, string pon_id, string pon_id_vizinho, Decimal map_distancia, Decimal? map_custo_pedagio_por_eixo, int? rod_id, Decimal? map_altura_rod )
                            {
                                return Create(null, id, map_id, pon_id, pon_id_vizinho, map_distancia, map_custo_pedagio_por_eixo, rod_id, map_altura_rod);
                            }

                            public IMapaEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int map_id, string pon_id, string pon_id_vizinho, Decimal map_distancia, Decimal? map_custo_pedagio_por_eixo, int? rod_id, Decimal? map_altura_rod )
                            {
                            var entity = new MapaEntity(id, map_id, pon_id, pon_id_vizinho, map_distancia, map_custo_pedagio_por_eixo, rod_id, map_altura_rod );


                            var trackingMask = _trackingPolicy?.GetMask("Mapa", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new MapaDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration