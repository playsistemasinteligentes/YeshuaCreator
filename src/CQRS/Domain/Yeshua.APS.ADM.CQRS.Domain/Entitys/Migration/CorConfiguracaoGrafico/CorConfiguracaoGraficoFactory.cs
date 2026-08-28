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
                                public class CorConfiguracaoGraficoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public CorConfiguracaoGraficoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public CorConfiguracaoGraficoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ICorConfiguracaoGraficoEntity Create(string cor_id, Decimal cor_percentual_ini, Decimal cor_percentual_fim, string cor_descricao )
                            {
                                return Create(null, cor_id, cor_percentual_ini, cor_percentual_fim, cor_descricao);
                            }

                            public ICorConfiguracaoGraficoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string cor_id, Decimal cor_percentual_ini, Decimal cor_percentual_fim, string cor_descricao )
                            {
                            var entity = new CorConfiguracaoGraficoEntity(cor_id, cor_percentual_ini, cor_percentual_fim, cor_descricao );


                            var trackingMask = _trackingPolicy?.GetMask("CorConfiguracaoGrafico", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new CorConfiguracaoGraficoDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration