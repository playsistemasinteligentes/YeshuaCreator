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
                                public class CarteiraCreditoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public CarteiraCreditoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public CarteiraCreditoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ICarteiraCreditoEntity Create(string? id, Decimal saldo )
                            {
                                return Create(null, id, saldo);
                            }

                            public ICarteiraCreditoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string? id, Decimal saldo, ulong? trackingMask = null )
                            {
                            var entity = new CarteiraCreditoEntity(id, saldo );


                            var effectiveTrackingMask = trackingMask ??
                                _trackingPolicy?.GetMask("CarteiraCredito", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new CarteiraCreditoDecorator(entity, _logger, context, effectiveTrackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration