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
                                public class PlanoacaoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public PlanoacaoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public PlanoacaoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IPlanoacaoEntity Create(int pla_id, string pla_descricao, int? met_id, string pla_status, DateTime? pla_data, string pla_metaperiodo, string pla_vlrperiodo, string pla_metaculado, string pla_vlracumulado, string pla_referencia, int use_id )
                            {
                                return Create(null, pla_id, pla_descricao, met_id, pla_status, pla_data, pla_metaperiodo, pla_vlrperiodo, pla_metaculado, pla_vlracumulado, pla_referencia, use_id);
                            }

                            public IPlanoacaoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int pla_id, string pla_descricao, int? met_id, string pla_status, DateTime? pla_data, string pla_metaperiodo, string pla_vlrperiodo, string pla_metaculado, string pla_vlracumulado, string pla_referencia, int use_id )
                            {
                            var entity = new PlanoacaoEntity(pla_id, pla_descricao, met_id, pla_status, pla_data, pla_metaperiodo, pla_vlrperiodo, pla_metaculado, pla_vlracumulado, pla_referencia, use_id );


                            var trackingMask = _trackingPolicy?.GetMask("Planoacao", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new PlanoacaoDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration