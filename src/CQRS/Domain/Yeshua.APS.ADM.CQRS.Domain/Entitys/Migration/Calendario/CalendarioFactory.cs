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
                                public class CalendarioFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public CalendarioFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public CalendarioFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ICalendarioEntity Create(int cal_id, string cal_descricao, int? cal_divide_dia_em )
                            {
                                return Create(null, cal_id, cal_descricao, cal_divide_dia_em);
                            }

                            public ICalendarioEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int cal_id, string cal_descricao, int? cal_divide_dia_em )
                            {
                            var entity = new CalendarioEntity(cal_id, cal_descricao, cal_divide_dia_em );


                            var trackingMask = _trackingPolicy?.GetMask("Calendario", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new CalendarioDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration