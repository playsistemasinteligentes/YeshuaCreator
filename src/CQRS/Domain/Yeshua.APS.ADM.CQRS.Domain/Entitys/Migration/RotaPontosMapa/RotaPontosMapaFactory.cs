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
                                public class RotaPontosMapaFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public RotaPontosMapaFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public RotaPontosMapaFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IRotaPontosMapaEntity Create(int? id, string rot_id, string pon_id_destino, string pon_id_origem, Decimal? rot_custo_total, string pon_id_roteiro, int? rot_ordem_roteiro, string rot_tipo, Decimal? rot_distancia )
                            {
                                return Create(null, id, rot_id, pon_id_destino, pon_id_origem, rot_custo_total, pon_id_roteiro, rot_ordem_roteiro, rot_tipo, rot_distancia);
                            }

                            public IRotaPontosMapaEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string rot_id, string pon_id_destino, string pon_id_origem, Decimal? rot_custo_total, string pon_id_roteiro, int? rot_ordem_roteiro, string rot_tipo, Decimal? rot_distancia )
                            {
                            var entity = new RotaPontosMapaEntity(id, rot_id, pon_id_destino, pon_id_origem, rot_custo_total, pon_id_roteiro, rot_ordem_roteiro, rot_tipo, rot_distancia );


                            var trackingMask = _trackingPolicy?.GetMask("RotaPontosMapa", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new RotaPontosMapaDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration