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
                                public class ItensEstruturaImpressaoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public ItensEstruturaImpressaoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public ItensEstruturaImpressaoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IItensEstruturaImpressaoEntity Create(int? id, int ies_custom_font_size )
                            {
                                return Create(null, id, ies_custom_font_size);
                            }

                            public IItensEstruturaImpressaoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int ies_custom_font_size )
                            {
                            var entity = new ItensEstruturaImpressaoEntity(id, ies_custom_font_size );


                            var trackingMask = _trackingPolicy?.GetMask("ItensEstruturaImpressao", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new ItensEstruturaImpressaoDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration