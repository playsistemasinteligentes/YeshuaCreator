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
                                public class RodoviasFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public RodoviasFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public RodoviasFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IRodoviasEntity Create(int? id, int rod_id, string rod_descricao )
                            {
                                return Create(null, id, rod_id, rod_descricao);
                            }

                            public IRodoviasEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int rod_id, string rod_descricao )
                            {
                            var entity = new RodoviasEntity(id, rod_id, rod_descricao );


                            var trackingMask = _trackingPolicy?.GetMask("Rodovias", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new RodoviasDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration