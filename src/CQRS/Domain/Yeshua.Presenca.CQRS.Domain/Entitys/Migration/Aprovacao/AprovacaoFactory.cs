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
                                public class AprovacaoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public AprovacaoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public AprovacaoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IAprovacaoEntity Create(string? id, string? identidadeid, string? versaoid, string? hash, string? destinos )
                            {
                                return Create(null, id, identidadeid, versaoid, hash, destinos);
                            }

                            public IAprovacaoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string? id, string? identidadeid, string? versaoid, string? hash, string? destinos, ulong? trackingMask = null )
                            {
                            var entity = new AprovacaoEntity(id, identidadeid, versaoid, hash, destinos );


                            var effectiveTrackingMask = trackingMask ??
                                _trackingPolicy?.GetMask("Aprovacao", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new AprovacaoDecorator(entity, _logger, context, effectiveTrackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration