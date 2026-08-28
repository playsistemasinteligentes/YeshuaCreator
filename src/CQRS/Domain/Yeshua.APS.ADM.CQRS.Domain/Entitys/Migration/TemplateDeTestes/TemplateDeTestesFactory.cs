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
                                public class TemplateDeTestesFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public TemplateDeTestesFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public TemplateDeTestesFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ITemplateDeTestesEntity Create(int? id, string descricao, string observacao )
                            {
                                return Create(null, id, descricao, observacao);
                            }

                            public ITemplateDeTestesEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string descricao, string observacao )
                            {
                            var entity = new TemplateDeTestesEntity(id, descricao, observacao );


                            var trackingMask = _trackingPolicy?.GetMask("TemplateDeTestes", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new TemplateDeTestesDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration