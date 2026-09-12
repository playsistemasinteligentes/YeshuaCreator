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
                                public class yTenantModuleFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public yTenantModuleFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public yTenantModuleFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IyTenantModuleEntity Create(int? id, string? moduleid, DateTime? validuntil )
                            {
                                return Create(null, id, moduleid, validuntil);
                            }

                            public IyTenantModuleEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string? moduleid, DateTime? validuntil )
                            {
                            var entity = new yTenantModuleEntity(id, moduleid, validuntil );


                            var trackingMask = _trackingPolicy?.GetMask("yTenantModule", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new yTenantModuleDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration