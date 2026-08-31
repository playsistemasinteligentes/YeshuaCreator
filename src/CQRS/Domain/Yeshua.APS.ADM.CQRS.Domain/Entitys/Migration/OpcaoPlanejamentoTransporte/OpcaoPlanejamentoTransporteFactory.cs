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
                                public class OpcaoPlanejamentoTransporteFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public OpcaoPlanejamentoTransporteFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public OpcaoPlanejamentoTransporteFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IOpcaoPlanejamentoTransporteEntity Create(string opcaoid, string grupodecisaoid, Decimal? peso, Decimal? volume, Decimal? custoestimado, Decimal? aderenciacubagem, Decimal? aderenciajanelaentrega, string riscoresumo, string pedidosresumo, string opcoesconflitantesresumo )
                            {
                                return Create(null, opcaoid, grupodecisaoid, peso, volume, custoestimado, aderenciacubagem, aderenciajanelaentrega, riscoresumo, pedidosresumo, opcoesconflitantesresumo);
                            }

                            public IOpcaoPlanejamentoTransporteEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string opcaoid, string grupodecisaoid, Decimal? peso, Decimal? volume, Decimal? custoestimado, Decimal? aderenciacubagem, Decimal? aderenciajanelaentrega, string riscoresumo, string pedidosresumo, string opcoesconflitantesresumo )
                            {
                            var entity = new OpcaoPlanejamentoTransporteEntity(opcaoid, grupodecisaoid, peso, volume, custoestimado, aderenciacubagem, aderenciajanelaentrega, riscoresumo, pedidosresumo, opcoesconflitantesresumo );


                            var trackingMask = _trackingPolicy?.GetMask("OpcaoPlanejamentoTransporte", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new OpcaoPlanejamentoTransporteDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration