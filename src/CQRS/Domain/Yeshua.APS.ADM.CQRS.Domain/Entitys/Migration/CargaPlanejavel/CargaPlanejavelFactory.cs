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
                                public class CargaPlanejavelFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public CargaPlanejavelFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public CargaPlanejavelFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ICargaPlanejavelEntity Create(string cargaid, string status, string transportadoraid, string veiculoid, int? tipoveiculoid, Decimal? pesoteorico, Decimal? volumeteorico, DateTime? iniciojanelaembarque, DateTime? fimjanelaembarque, DateTime? embarquealvo, int? quantidadepedidos, string alertasresumo )
                            {
                                return Create(null, cargaid, status, transportadoraid, veiculoid, tipoveiculoid, pesoteorico, volumeteorico, iniciojanelaembarque, fimjanelaembarque, embarquealvo, quantidadepedidos, alertasresumo);
                            }

                            public ICargaPlanejavelEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string cargaid, string status, string transportadoraid, string veiculoid, int? tipoveiculoid, Decimal? pesoteorico, Decimal? volumeteorico, DateTime? iniciojanelaembarque, DateTime? fimjanelaembarque, DateTime? embarquealvo, int? quantidadepedidos, string alertasresumo )
                            {
                            var entity = new CargaPlanejavelEntity(cargaid, status, transportadoraid, veiculoid, tipoveiculoid, pesoteorico, volumeteorico, iniciojanelaembarque, fimjanelaembarque, embarquealvo, quantidadepedidos, alertasresumo );


                            var trackingMask = _trackingPolicy?.GetMask("CargaPlanejavel", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new CargaPlanejavelDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration