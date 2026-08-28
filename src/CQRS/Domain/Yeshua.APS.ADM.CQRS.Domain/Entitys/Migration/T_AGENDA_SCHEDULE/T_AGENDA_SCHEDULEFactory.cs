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
                                public class T_AGENDA_SCHEDULEFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public T_AGENDA_SCHEDULEFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public T_AGENDA_SCHEDULEFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IT_AGENDA_SCHEDULEEntity Create(int? id, int age_id, DateTime? age_data_especifica, string age_horario_inicio, string age_horario_fim, string age_segunda, string age_terca, string age_quarta, string age_quinta, string age_sexta, string age_sabado, string age_domingo, Decimal? age_intervalo, string age_ordem_execucao, string age_parametros, string age_excecao, string age_descricao )
                            {
                                return Create(null, id, age_id, age_data_especifica, age_horario_inicio, age_horario_fim, age_segunda, age_terca, age_quarta, age_quinta, age_sexta, age_sabado, age_domingo, age_intervalo, age_ordem_execucao, age_parametros, age_excecao, age_descricao);
                            }

                            public IT_AGENDA_SCHEDULEEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int age_id, DateTime? age_data_especifica, string age_horario_inicio, string age_horario_fim, string age_segunda, string age_terca, string age_quarta, string age_quinta, string age_sexta, string age_sabado, string age_domingo, Decimal? age_intervalo, string age_ordem_execucao, string age_parametros, string age_excecao, string age_descricao )
                            {
                            var entity = new T_AGENDA_SCHEDULEEntity(id, age_id, age_data_especifica, age_horario_inicio, age_horario_fim, age_segunda, age_terca, age_quarta, age_quinta, age_sexta, age_sabado, age_domingo, age_intervalo, age_ordem_execucao, age_parametros, age_excecao, age_descricao );


                            var trackingMask = _trackingPolicy?.GetMask("T_AGENDA_SCHEDULE", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new T_AGENDA_SCHEDULEDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration