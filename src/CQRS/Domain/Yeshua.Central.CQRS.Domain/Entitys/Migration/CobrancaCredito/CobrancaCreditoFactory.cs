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
                                public class CobrancaCreditoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public CobrancaCreditoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public CobrancaCreditoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ICobrancaCreditoEntity Create(string? id, Decimal creditos, Decimal valor, int status, DateTime criadaemutc, DateTime venceemutc, string moeda, string provedor, DateTime? pagaemutc )
                            {
                                return Create(null, id, creditos, valor, status, criadaemutc, venceemutc, moeda, provedor, pagaemutc);
                            }

                            public ICobrancaCreditoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string? id, Decimal creditos, Decimal valor, int status, DateTime criadaemutc, DateTime venceemutc, string moeda, string provedor, DateTime? pagaemutc, ulong? trackingMask = null )
                            {
                            var entity = new CobrancaCreditoEntity(id, creditos, valor, status, criadaemutc, venceemutc, moeda, provedor, pagaemutc );


                            var effectiveTrackingMask = trackingMask ??
                                _trackingPolicy?.GetMask("CobrancaCredito", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new CobrancaCreditoDecorator(entity, _logger, context, effectiveTrackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration