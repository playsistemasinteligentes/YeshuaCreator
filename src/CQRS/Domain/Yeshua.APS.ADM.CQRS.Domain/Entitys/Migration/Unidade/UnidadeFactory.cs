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
                                public class UnidadeFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public UnidadeFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public UnidadeFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IUnidadeEntity Create(int uni_id, string deescricao, string un )
                            {
                                return Create(null, uni_id, deescricao, un);
                            }

                            public IUnidadeEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int uni_id, string deescricao, string un )
                            {
                            var entity = new UnidadeEntity(uni_id, deescricao, un );


                            var trackingMask = _trackingPolicy?.GetMask("Unidade", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new UnidadeDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration