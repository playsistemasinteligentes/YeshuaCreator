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
                                public class ConsultasGruposFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public ConsultasGruposFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public ConsultasGruposFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IConsultasGruposEntity Create(int? id, int? con_id, int? gru_id )
                            {
                                return Create(null, id, con_id, gru_id);
                            }

                            public IConsultasGruposEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int? con_id, int? gru_id )
                            {
                            var entity = new ConsultasGruposEntity(id, con_id, gru_id );


                            var trackingMask = _trackingPolicy?.GetMask("ConsultasGrupos", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new ConsultasGruposDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration