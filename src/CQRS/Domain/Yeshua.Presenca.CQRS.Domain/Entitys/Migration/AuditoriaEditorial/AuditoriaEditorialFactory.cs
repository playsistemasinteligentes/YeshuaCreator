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
                                public class AuditoriaEditorialFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public AuditoriaEditorialFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public AuditoriaEditorialFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IAuditoriaEditorialEntity Create(string? id, string? identidadeid, string? operacao, string? registroid, string? motivo )
                            {
                                return Create(null, id, identidadeid, operacao, registroid, motivo);
                            }

                            public IAuditoriaEditorialEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string? id, string? identidadeid, string? operacao, string? registroid, string? motivo, ulong? trackingMask = null )
                            {
                            var entity = new AuditoriaEditorialEntity(id, identidadeid, operacao, registroid, motivo );


                            var effectiveTrackingMask = trackingMask ??
                                _trackingPolicy?.GetMask("AuditoriaEditorial", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new AuditoriaEditorialDecorator(entity, _logger, context, effectiveTrackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration