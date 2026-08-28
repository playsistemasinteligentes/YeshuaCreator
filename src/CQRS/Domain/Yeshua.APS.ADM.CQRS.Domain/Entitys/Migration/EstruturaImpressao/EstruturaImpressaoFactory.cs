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
                                public class EstruturaImpressaoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public EstruturaImpressaoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public EstruturaImpressaoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IEstruturaImpressaoEntity Create(int est_id, string html_estrutura, string cli_id, string est_descricao )
                            {
                                return Create(null, est_id, html_estrutura, cli_id, est_descricao);
                            }

                            public IEstruturaImpressaoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int est_id, string html_estrutura, string cli_id, string est_descricao )
                            {
                            var entity = new EstruturaImpressaoEntity(est_id, html_estrutura, cli_id, est_descricao );


                            var trackingMask = _trackingPolicy?.GetMask("EstruturaImpressao", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new EstruturaImpressaoDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration