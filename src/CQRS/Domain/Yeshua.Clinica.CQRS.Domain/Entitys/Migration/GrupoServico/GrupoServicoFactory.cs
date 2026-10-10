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
                                public class GrupoServicoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public GrupoServicoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public GrupoServicoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IGrupoServicoEntity Create(int? id, string descricao )
                            {
                                return Create(null, id, descricao);
                            }

                            public IGrupoServicoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string descricao, ulong? trackingMask = null )
                            {
                            var entity = new GrupoServicoEntity(id, descricao );


                            var effectiveTrackingMask = trackingMask ??
                                _trackingPolicy?.GetMask("GrupoServico", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new GrupoServicoDecorator(entity, _logger, context, effectiveTrackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration