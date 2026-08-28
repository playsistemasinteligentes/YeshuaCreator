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
                                public class TemplatesMaquinasFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public TemplatesMaquinasFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public TemplatesMaquinasFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ITemplatesMaquinasEntity Create(int? id, int tem_id, string maq_id )
                            {
                                return Create(null, id, tem_id, maq_id);
                            }

                            public ITemplatesMaquinasEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int tem_id, string maq_id )
                            {
                            var entity = new TemplatesMaquinasEntity(id, tem_id, maq_id );


                            var trackingMask = _trackingPolicy?.GetMask("TemplatesMaquinas", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new TemplatesMaquinasDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration