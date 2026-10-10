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
                                public class yTenantApplicationFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public yTenantApplicationFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public yTenantApplicationFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IyTenantApplicationEntity Create(int? id, string applicationkey, DateTime validuntil )
                            {
                                return Create(null, id, applicationkey, validuntil);
                            }

                            public IyTenantApplicationEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string applicationkey, DateTime validuntil )
                            {
                            var entity = new yTenantApplicationEntity(id, applicationkey, validuntil );


                            var trackingMask = _trackingPolicy?.GetMask("yTenantApplication", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new yTenantApplicationDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration