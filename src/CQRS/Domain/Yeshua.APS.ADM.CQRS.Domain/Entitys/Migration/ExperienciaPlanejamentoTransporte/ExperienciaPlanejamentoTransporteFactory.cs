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
                                public class ExperienciaPlanejamentoTransporteFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public ExperienciaPlanejamentoTransporteFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public ExperienciaPlanejamentoTransporteFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IExperienciaPlanejamentoTransporteEntity Create(int? id, int tipo, string referencia, string pedidoid, string clienteid, string municipio, string regiao, string rotaid, Decimal? peso, Decimal? volume, string observacao, DateTime criadoem, string criadopor )
                            {
                                return Create(null, id, tipo, referencia, pedidoid, clienteid, municipio, regiao, rotaid, peso, volume, observacao, criadoem, criadopor);
                            }

                            public IExperienciaPlanejamentoTransporteEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int tipo, string referencia, string pedidoid, string clienteid, string municipio, string regiao, string rotaid, Decimal? peso, Decimal? volume, string observacao, DateTime criadoem, string criadopor )
                            {
                            var entity = new ExperienciaPlanejamentoTransporteEntity(id, tipo, referencia, pedidoid, clienteid, municipio, regiao, rotaid, peso, volume, observacao, criadoem, criadopor );


                            var trackingMask = _trackingPolicy?.GetMask("ExperienciaPlanejamentoTransporte", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new ExperienciaPlanejamentoTransporteDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration