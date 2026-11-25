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
                                public class ReciboEntradaFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public ReciboEntradaFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public ReciboEntradaFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IReciboEntradaEntity Create(string? id, string? identidadeid, string? operacao, string? hash, string? resultado )
                            {
                                return Create(null, id, identidadeid, operacao, hash, resultado);
                            }

                            public IReciboEntradaEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string? id, string? identidadeid, string? operacao, string? hash, string? resultado, ulong? trackingMask = null )
                            {
                            var entity = new ReciboEntradaEntity(id, identidadeid, operacao, hash, resultado );


                            var effectiveTrackingMask = trackingMask ??
                                _trackingPolicy?.GetMask("ReciboEntrada", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new ReciboEntradaDecorator(entity, _logger, context, effectiveTrackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration