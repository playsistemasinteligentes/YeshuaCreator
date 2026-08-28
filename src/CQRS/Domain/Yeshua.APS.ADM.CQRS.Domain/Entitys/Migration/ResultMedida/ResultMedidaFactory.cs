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
                                public class ResultMedidaFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public ResultMedidaFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public ResultMedidaFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IResultMedidaEntity Create(int? id, int rsm_id, int? rl_id, int? mdt_id )
                            {
                                return Create(null, id, rsm_id, rl_id, mdt_id);
                            }

                            public IResultMedidaEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int rsm_id, int? rl_id, int? mdt_id )
                            {
                            var entity = new ResultMedidaEntity(id, rsm_id, rl_id, mdt_id );


                            var trackingMask = _trackingPolicy?.GetMask("ResultMedida", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new ResultMedidaDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration