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
                                public class ConteudoVersaoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public ConteudoVersaoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public ConteudoVersaoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IConteudoVersaoEntity Create(string? id, string? identidadeid, string? pautaid, int? numero, string? hash, string? estado, string? snapshot )
                            {
                                return Create(null, id, identidadeid, pautaid, numero, hash, estado, snapshot);
                            }

                            public IConteudoVersaoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string? id, string? identidadeid, string? pautaid, int? numero, string? hash, string? estado, string? snapshot, ulong? trackingMask = null )
                            {
                            var entity = new ConteudoVersaoEntity(id, identidadeid, pautaid, numero, hash, estado, snapshot );


                            var effectiveTrackingMask = trackingMask ??
                                _trackingPolicy?.GetMask("ConteudoVersao", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new ConteudoVersaoDecorator(entity, _logger, context, effectiveTrackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration