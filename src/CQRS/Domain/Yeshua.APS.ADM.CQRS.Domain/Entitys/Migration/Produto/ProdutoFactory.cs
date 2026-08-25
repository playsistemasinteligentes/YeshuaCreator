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
                                public class ProdutoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public ProdutoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public ProdutoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IProdutoEntity Create(string id, string descricao, string status )
                            {
                                return Create(null, id, descricao, status);
                            }

                            public IProdutoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string id, string descricao, string status )
                            {
                            var entity = new ProdutoEntity(id, descricao, status );


                            var trackingMask = _trackingPolicy?.GetMask("Produto", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new ProdutoDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration