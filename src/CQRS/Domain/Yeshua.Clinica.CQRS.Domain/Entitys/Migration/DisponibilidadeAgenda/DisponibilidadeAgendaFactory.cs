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
                                public class DisponibilidadeAgendaFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public DisponibilidadeAgendaFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public DisponibilidadeAgendaFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IDisponibilidadeAgendaEntity Create(int? id, int? profissionalid, DateTime datahora )
                            {
                                return Create(null, id, profissionalid, datahora);
                            }

                            public IDisponibilidadeAgendaEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int? profissionalid, DateTime datahora )
                            {
                            var entity = new DisponibilidadeAgendaEntity(id, profissionalid, datahora );


                            var trackingMask = _trackingPolicy?.GetMask("DisponibilidadeAgenda", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new DisponibilidadeAgendaDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration