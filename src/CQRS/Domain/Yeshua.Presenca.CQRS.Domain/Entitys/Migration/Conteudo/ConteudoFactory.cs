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
                                public class ConteudoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public ConteudoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public ConteudoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IConteudoEntity Create(string? id, string? identidadeid, string? pautaid )
                            {
                                return Create(null, id, identidadeid, pautaid);
                            }

                            public IConteudoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string? id, string? identidadeid, string? pautaid, ulong? trackingMask = null )
                            {
                            var entity = new ConteudoEntity(id, identidadeid, pautaid );


                            var effectiveTrackingMask = trackingMask ??
                                _trackingPolicy?.GetMask("Conteudo", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new ConteudoDecorator(entity, _logger, context, effectiveTrackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration