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
                                public class ItenCalendarioDisponibilidadeVeiculosFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public ItenCalendarioDisponibilidadeVeiculosFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public ItenCalendarioDisponibilidadeVeiculosFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IItenCalendarioDisponibilidadeVeiculosEntity Create(int? id, int? cdv_id, int? tip_id, int? idv_qtd )
                            {
                                return Create(null, id, cdv_id, tip_id, idv_qtd);
                            }

                            public IItenCalendarioDisponibilidadeVeiculosEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int? cdv_id, int? tip_id, int? idv_qtd )
                            {
                            var entity = new ItenCalendarioDisponibilidadeVeiculosEntity(id, cdv_id, tip_id, idv_qtd );


                            var trackingMask = _trackingPolicy?.GetMask("ItenCalendarioDisponibilidadeVeiculos", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new ItenCalendarioDisponibilidadeVeiculosDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration