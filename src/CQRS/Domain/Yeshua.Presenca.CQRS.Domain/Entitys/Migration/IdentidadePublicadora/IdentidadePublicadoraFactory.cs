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
                                public class IdentidadePublicadoraFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public IdentidadePublicadoraFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public IdentidadePublicadoraFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IIdentidadePublicadoraEntity Create(string? id, string? nome, int? ativa )
                            {
                                return Create(null, id, nome, ativa);
                            }

                            public IIdentidadePublicadoraEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string? id, string? nome, int? ativa, ulong? trackingMask = null )
                            {
                            var entity = new IdentidadePublicadoraEntity(id, nome, ativa );


                            var effectiveTrackingMask = trackingMask ??
                                _trackingPolicy?.GetMask("IdentidadePublicadora", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new IdentidadePublicadoraDecorator(entity, _logger, context, effectiveTrackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration