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
                                public class CanalFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public CanalFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public CanalFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ICanalEntity Create(string? id, string? identidadeid, string? plataforma, string? destino, string? conexao )
                            {
                                return Create(null, id, identidadeid, plataforma, destino, conexao);
                            }

                            public ICanalEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string? id, string? identidadeid, string? plataforma, string? destino, string? conexao, ulong? trackingMask = null )
                            {
                            var entity = new CanalEntity(id, identidadeid, plataforma, destino, conexao );


                            var effectiveTrackingMask = trackingMask ??
                                _trackingPolicy?.GetMask("Canal", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new CanalDecorator(entity, _logger, context, effectiveTrackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration