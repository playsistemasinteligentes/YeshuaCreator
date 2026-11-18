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
                                public class MovimentoCreditoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public MovimentoCreditoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public MovimentoCreditoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IMovimentoCreditoEntity Create(string? id, string tipo, string referencia, Decimal quantidade, Decimal saldoapos, DateTime criadoemutc )
                            {
                                return Create(null, id, tipo, referencia, quantidade, saldoapos, criadoemutc);
                            }

                            public IMovimentoCreditoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string? id, string tipo, string referencia, Decimal quantidade, Decimal saldoapos, DateTime criadoemutc, ulong? trackingMask = null )
                            {
                            var entity = new MovimentoCreditoEntity(id, tipo, referencia, quantidade, saldoapos, criadoemutc );


                            var effectiveTrackingMask = trackingMask ??
                                _trackingPolicy?.GetMask("MovimentoCredito", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new MovimentoCreditoDecorator(entity, _logger, context, effectiveTrackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration