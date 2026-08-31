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
                                public class CenarioPlanejamentoTransporteFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public CenarioPlanejamentoTransporteFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public CenarioPlanejamentoTransporteFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ICenarioPlanejamentoTransporteEntity Create(string cenarioid, string descricao, string objetivo, int? quantidadecargas, int? quantidadepedidosnaoatendidos, Decimal? custototal, Decimal? aderenciacubagem, Decimal? atrasoprevisto, string alertasresumo )
                            {
                                return Create(null, cenarioid, descricao, objetivo, quantidadecargas, quantidadepedidosnaoatendidos, custototal, aderenciacubagem, atrasoprevisto, alertasresumo);
                            }

                            public ICenarioPlanejamentoTransporteEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string cenarioid, string descricao, string objetivo, int? quantidadecargas, int? quantidadepedidosnaoatendidos, Decimal? custototal, Decimal? aderenciacubagem, Decimal? atrasoprevisto, string alertasresumo )
                            {
                            var entity = new CenarioPlanejamentoTransporteEntity(cenarioid, descricao, objetivo, quantidadecargas, quantidadepedidosnaoatendidos, custototal, aderenciacubagem, atrasoprevisto, alertasresumo );


                            var trackingMask = _trackingPolicy?.GetMask("CenarioPlanejamentoTransporte", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new CenarioPlanejamentoTransporteDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration