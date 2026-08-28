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
                                public class TurnoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public TurnoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public TurnoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ITurnoEntity Create(string id, string descricao, int turn_prioridade, DateTime? turn_hora_ini_dia1, DateTime? turn_hora_fim_dia1, DateTime? turn_hora_ini_dia2, DateTime? turn_hora_fim_dia2, DateTime? turn_hora_ini_dia3, DateTime? turn_hora_fim_dia3, DateTime? turn_hora_ini_dia4, DateTime? turn_hora_fim_dia4, DateTime? turn_hora_ini_dia5, DateTime? turn_hora_fim_dia5, DateTime? turn_hora_ini_dia6, DateTime? turn_hora_fim_dia6, DateTime? turn_hora_ini_dia7, DateTime? turn_hora_fim_dia7 )
                            {
                                return Create(null, id, descricao, turn_prioridade, turn_hora_ini_dia1, turn_hora_fim_dia1, turn_hora_ini_dia2, turn_hora_fim_dia2, turn_hora_ini_dia3, turn_hora_fim_dia3, turn_hora_ini_dia4, turn_hora_fim_dia4, turn_hora_ini_dia5, turn_hora_fim_dia5, turn_hora_ini_dia6, turn_hora_fim_dia6, turn_hora_ini_dia7, turn_hora_fim_dia7);
                            }

                            public ITurnoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string id, string descricao, int turn_prioridade, DateTime? turn_hora_ini_dia1, DateTime? turn_hora_fim_dia1, DateTime? turn_hora_ini_dia2, DateTime? turn_hora_fim_dia2, DateTime? turn_hora_ini_dia3, DateTime? turn_hora_fim_dia3, DateTime? turn_hora_ini_dia4, DateTime? turn_hora_fim_dia4, DateTime? turn_hora_ini_dia5, DateTime? turn_hora_fim_dia5, DateTime? turn_hora_ini_dia6, DateTime? turn_hora_fim_dia6, DateTime? turn_hora_ini_dia7, DateTime? turn_hora_fim_dia7 )
                            {
                            var entity = new TurnoEntity(id, descricao, turn_prioridade, turn_hora_ini_dia1, turn_hora_fim_dia1, turn_hora_ini_dia2, turn_hora_fim_dia2, turn_hora_ini_dia3, turn_hora_fim_dia3, turn_hora_ini_dia4, turn_hora_fim_dia4, turn_hora_ini_dia5, turn_hora_fim_dia5, turn_hora_ini_dia6, turn_hora_fim_dia6, turn_hora_ini_dia7, turn_hora_fim_dia7 );


                            var trackingMask = _trackingPolicy?.GetMask("Turno", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new TurnoDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration