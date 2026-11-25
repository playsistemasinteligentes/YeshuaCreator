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
                                public class PlataformaFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public PlataformaFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public PlataformaFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IPlataformaEntity Create(string? id, string? codigo, string? capacidades )
                            {
                                return Create(null, id, codigo, capacidades);
                            }

                            public IPlataformaEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string? id, string? codigo, string? capacidades, ulong? trackingMask = null )
                            {
                            var entity = new PlataformaEntity(id, codigo, capacidades );


                            var effectiveTrackingMask = trackingMask ??
                                _trackingPolicy?.GetMask("Plataforma", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new PlataformaDecorator(entity, _logger, context, effectiveTrackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration