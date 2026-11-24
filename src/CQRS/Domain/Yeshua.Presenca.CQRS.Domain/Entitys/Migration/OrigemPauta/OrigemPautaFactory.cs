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
                                public class OrigemPautaFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public OrigemPautaFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public OrigemPautaFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IOrigemPautaEntity Create(string? id, string? identidadeid, string? pautaid, string? produtor, string? movimentoid )
                            {
                                return Create(null, id, identidadeid, pautaid, produtor, movimentoid);
                            }

                            public IOrigemPautaEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string? id, string? identidadeid, string? pautaid, string? produtor, string? movimentoid, ulong? trackingMask = null )
                            {
                            var entity = new OrigemPautaEntity(id, identidadeid, pautaid, produtor, movimentoid );


                            var effectiveTrackingMask = trackingMask ??
                                _trackingPolicy?.GetMask("OrigemPauta", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new OrigemPautaDecorator(entity, _logger, context, effectiveTrackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration