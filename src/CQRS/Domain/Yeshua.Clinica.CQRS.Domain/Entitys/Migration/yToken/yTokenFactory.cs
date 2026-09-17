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
                                public class yTokenFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public yTokenFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public yTokenFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IyTokenEntity Create(int? id, string tokenhash, string? description, string connectorkey, DateTime? validuntil, DateTime? lastusedat )
                            {
                                return Create(null, id, tokenhash, description, connectorkey, validuntil, lastusedat);
                            }

                            public IyTokenEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string tokenhash, string? description, string connectorkey, DateTime? validuntil, DateTime? lastusedat )
                            {
                            var entity = new yTokenEntity(id, tokenhash, description, connectorkey, validuntil, lastusedat );


                            var trackingMask = _trackingPolicy?.GetMask("yToken", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new yTokenDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration