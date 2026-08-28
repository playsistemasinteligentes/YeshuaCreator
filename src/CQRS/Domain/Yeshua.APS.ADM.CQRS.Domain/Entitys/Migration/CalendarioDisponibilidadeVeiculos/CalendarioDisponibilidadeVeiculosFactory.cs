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
                                public class CalendarioDisponibilidadeVeiculosFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public CalendarioDisponibilidadeVeiculosFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public CalendarioDisponibilidadeVeiculosFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ICalendarioDisponibilidadeVeiculosEntity Create(int? id, int cdv_id, DateTime? cdv_data_de, DateTime? cdv_data_ate, int? cdv_segunda, int? cdv_terca, int? cdv_quarta, int? cdv_quinta, int? cdv_sexta, int? cdv_sabado, int? cdv_domingo )
                            {
                                return Create(null, id, cdv_id, cdv_data_de, cdv_data_ate, cdv_segunda, cdv_terca, cdv_quarta, cdv_quinta, cdv_sexta, cdv_sabado, cdv_domingo);
                            }

                            public ICalendarioDisponibilidadeVeiculosEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int cdv_id, DateTime? cdv_data_de, DateTime? cdv_data_ate, int? cdv_segunda, int? cdv_terca, int? cdv_quarta, int? cdv_quinta, int? cdv_sexta, int? cdv_sabado, int? cdv_domingo )
                            {
                            var entity = new CalendarioDisponibilidadeVeiculosEntity(id, cdv_id, cdv_data_de, cdv_data_ate, cdv_segunda, cdv_terca, cdv_quarta, cdv_quinta, cdv_sexta, cdv_sabado, cdv_domingo );


                            var trackingMask = _trackingPolicy?.GetMask("CalendarioDisponibilidadeVeiculos", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new CalendarioDisponibilidadeVeiculosDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration