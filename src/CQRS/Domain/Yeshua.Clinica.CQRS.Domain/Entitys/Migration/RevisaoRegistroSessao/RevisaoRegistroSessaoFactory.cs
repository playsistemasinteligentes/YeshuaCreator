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
                                public class RevisaoRegistroSessaoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public RevisaoRegistroSessaoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public RevisaoRegistroSessaoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IRevisaoRegistroSessaoEntity Create(int? id, int sessaoid, int versao, int autoruserid, DateTime revisadoem, string? motivo, string registro )
                            {
                                return Create(null, id, sessaoid, versao, autoruserid, revisadoem, motivo, registro);
                            }

                            public IRevisaoRegistroSessaoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int sessaoid, int versao, int autoruserid, DateTime revisadoem, string? motivo, string registro, ulong? trackingMask = null )
                            {
                            var entity = new RevisaoRegistroSessaoEntity(id, sessaoid, versao, autoruserid, revisadoem, motivo, registro );


                            var effectiveTrackingMask = trackingMask ??
                                _trackingPolicy?.GetMask("RevisaoRegistroSessao", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new RevisaoRegistroSessaoDecorator(entity, _logger, context, effectiveTrackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration