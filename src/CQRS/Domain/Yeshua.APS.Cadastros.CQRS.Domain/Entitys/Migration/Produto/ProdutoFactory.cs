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
                                    } public IProdutoEntity Create(string pro_id, string pro_descricao, string pro_status )
                            {
                                return Create(null, pro_id, pro_descricao, pro_status);
                            }

                            public IProdutoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string pro_id, string pro_descricao, string pro_status )
                            {
                            var entity = new ProdutoEntity(pro_id, pro_descricao, pro_status );


                            var trackingMask = _trackingPolicy?.GetMask("Produto", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new ProdutoDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration