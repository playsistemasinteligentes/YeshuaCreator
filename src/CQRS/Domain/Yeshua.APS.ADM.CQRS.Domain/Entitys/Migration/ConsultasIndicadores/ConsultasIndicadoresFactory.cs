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
                                public class ConsultasIndicadoresFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public ConsultasIndicadoresFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public ConsultasIndicadoresFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IConsultasIndicadoresEntity Create(int? id, int? con_id, int? ind_id )
                            {
                                return Create(null, id, con_id, ind_id);
                            }

                            public IConsultasIndicadoresEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int? con_id, int? ind_id )
                            {
                            var entity = new ConsultasIndicadoresEntity(id, con_id, ind_id );


                            var trackingMask = _trackingPolicy?.GetMask("ConsultasIndicadores", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new ConsultasIndicadoresDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration