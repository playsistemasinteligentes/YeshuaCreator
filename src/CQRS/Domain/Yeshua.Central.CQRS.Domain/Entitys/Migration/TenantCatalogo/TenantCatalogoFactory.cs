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
                                public class TenantCatalogoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public TenantCatalogoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public TenantCatalogoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ITenantCatalogoEntity Create(int? id, string catalogo, DateTime validuntil )
                            {
                                return Create(null, id, catalogo, validuntil);
                            }

                            public ITenantCatalogoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string catalogo, DateTime validuntil )
                            {
                            var entity = new TenantCatalogoEntity(id, catalogo, validuntil );


                            var trackingMask = _trackingPolicy?.GetMask("TenantCatalogo", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new TenantCatalogoDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration