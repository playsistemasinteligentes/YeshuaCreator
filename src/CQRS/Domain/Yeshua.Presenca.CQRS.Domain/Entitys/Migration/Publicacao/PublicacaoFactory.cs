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
                                public class PublicacaoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public PublicacaoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public PublicacaoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IPublicacaoEntity Create(string? id, string? identidadeid, string? versaoid, string? hash )
                            {
                                return Create(null, id, identidadeid, versaoid, hash);
                            }

                            public IPublicacaoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string? id, string? identidadeid, string? versaoid, string? hash, ulong? trackingMask = null )
                            {
                            var entity = new PublicacaoEntity(id, identidadeid, versaoid, hash );


                            var effectiveTrackingMask = trackingMask ??
                                _trackingPolicy?.GetMask("Publicacao", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new PublicacaoDecorator(entity, _logger, context, effectiveTrackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration