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
                                public class LoockFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public LoockFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public LoockFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ILoockEntity Create(int? id, string loo_id, string loo_descricao, string loo_conteudo )
                            {
                                return Create(null, id, loo_id, loo_descricao, loo_conteudo);
                            }

                            public ILoockEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string loo_id, string loo_descricao, string loo_conteudo )
                            {
                            var entity = new LoockEntity(id, loo_id, loo_descricao, loo_conteudo );


                            var trackingMask = _trackingPolicy?.GetMask("Loock", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new LoockDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration