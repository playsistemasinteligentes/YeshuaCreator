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
                                public class TiposVincoProdutosFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public TiposVincoProdutosFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public TiposVincoProdutosFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ITiposVincoProdutosEntity Create(int? id, int id2 )
                            {
                                return Create(null, id, id2);
                            }

                            public ITiposVincoProdutosEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int id2 )
                            {
                            var entity = new TiposVincoProdutosEntity(id, id2 );


                            var trackingMask = _trackingPolicy?.GetMask("TiposVincoProdutos", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new TiposVincoProdutosDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration