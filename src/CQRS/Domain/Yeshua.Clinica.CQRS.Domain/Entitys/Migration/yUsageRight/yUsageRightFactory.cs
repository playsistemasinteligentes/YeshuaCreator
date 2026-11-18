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
                                public class yUsageRightFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public yUsageRightFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public yUsageRightFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IyUsageRightEntity Create(string? id, string resourcekey, DateTime? perioduntilutc, Decimal grantedunits, Decimal reservedunits, Decimal consumedunits )
                            {
                                return Create(null, id, resourcekey, perioduntilutc, grantedunits, reservedunits, consumedunits);
                            }

                            public IyUsageRightEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string? id, string resourcekey, DateTime? perioduntilutc, Decimal grantedunits, Decimal reservedunits, Decimal consumedunits, ulong? trackingMask = null )
                            {
                            var entity = new yUsageRightEntity(id, resourcekey, perioduntilutc, grantedunits, reservedunits, consumedunits );


                            var effectiveTrackingMask = trackingMask ??
                                _trackingPolicy?.GetMask("yUsageRight", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new yUsageRightDecorator(entity, _logger, context, effectiveTrackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration