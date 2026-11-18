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
                                public class DireitoUsoContratadoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public DireitoUsoContratadoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public DireitoUsoContratadoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IDireitoUsoContratadoEntity Create(string? id, string resourcekey, DateTime? perioduntilutc, Decimal grantedunits )
                            {
                                return Create(null, id, resourcekey, perioduntilutc, grantedunits);
                            }

                            public IDireitoUsoContratadoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string? id, string resourcekey, DateTime? perioduntilutc, Decimal grantedunits, ulong? trackingMask = null )
                            {
                            var entity = new DireitoUsoContratadoEntity(id, resourcekey, perioduntilutc, grantedunits );


                            var effectiveTrackingMask = trackingMask ??
                                _trackingPolicy?.GetMask("DireitoUsoContratado", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new DireitoUsoContratadoDecorator(entity, _logger, context, effectiveTrackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration