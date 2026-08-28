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
                                public class PontosMapaFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public PontosMapaFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public PontosMapaFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IPontosMapaEntity Create(string pon_id, string pon_descricao, string pon_tipo, Decimal? pon_latitude, Decimal? pon_longitude, Decimal? pon_distancia_km )
                            {
                                return Create(null, pon_id, pon_descricao, pon_tipo, pon_latitude, pon_longitude, pon_distancia_km);
                            }

                            public IPontosMapaEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string pon_id, string pon_descricao, string pon_tipo, Decimal? pon_latitude, Decimal? pon_longitude, Decimal? pon_distancia_km )
                            {
                            var entity = new PontosMapaEntity(pon_id, pon_descricao, pon_tipo, pon_latitude, pon_longitude, pon_distancia_km );


                            var trackingMask = _trackingPolicy?.GetMask("PontosMapa", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new PontosMapaDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration