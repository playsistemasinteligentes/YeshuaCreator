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
                                public class yUsageConsumptionFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public yUsageConsumptionFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public yUsageConsumptionFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IyUsageConsumptionEntity Create(string? id, string resourcekey, string operationid, Decimal units, bool usesperiod, int status )
                            {
                                return Create(null, id, resourcekey, operationid, units, usesperiod, status);
                            }

                            public IyUsageConsumptionEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string? id, string resourcekey, string operationid, Decimal units, bool usesperiod, int status, ulong? trackingMask = null )
                            {
                            var entity = new yUsageConsumptionEntity(id, resourcekey, operationid, units, usesperiod, status );


                            var effectiveTrackingMask = trackingMask ??
                                _trackingPolicy?.GetMask("yUsageConsumption", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new yUsageConsumptionDecorator(entity, _logger, context, effectiveTrackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration