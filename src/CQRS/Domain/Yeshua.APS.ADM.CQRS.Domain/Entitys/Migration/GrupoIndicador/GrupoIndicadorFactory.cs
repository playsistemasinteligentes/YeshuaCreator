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
                                public class GrupoIndicadorFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public GrupoIndicadorFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public GrupoIndicadorFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IGrupoIndicadorEntity Create(int gru_ind_id, int gru_id, int ind_id )
                            {
                                return Create(null, gru_ind_id, gru_id, ind_id);
                            }

                            public IGrupoIndicadorEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int gru_ind_id, int gru_id, int ind_id )
                            {
                            var entity = new GrupoIndicadorEntity(gru_ind_id, gru_id, ind_id );


                            var trackingMask = _trackingPolicy?.GetMask("GrupoIndicador", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new GrupoIndicadorDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration