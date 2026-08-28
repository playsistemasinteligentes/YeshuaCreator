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
                                public class TurmaFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public TurmaFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public TurmaFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ITurmaEntity Create(string id, string descricao, DateTime? turm_hora_ini_dia1, DateTime? turm_hora_fim_dia1, DateTime? turm_hora_ini_dia2, DateTime? turm_hora_fim_dia2, DateTime? turm_hora_ini_dia3, DateTime? turm_hora_fim_dia3, DateTime? turm_hora_ini_dia4, DateTime? turm_hora_fim_dia4, DateTime? turm_hora_ini_dia5, DateTime? turm_hora_fim_dia5, DateTime? turm_hora_ini_dia6, DateTime? turm_hora_fim_dia6, DateTime? turm_hora_ini_dia7, DateTime? turm_hora_fim_dia7 )
                            {
                                return Create(null, id, descricao, turm_hora_ini_dia1, turm_hora_fim_dia1, turm_hora_ini_dia2, turm_hora_fim_dia2, turm_hora_ini_dia3, turm_hora_fim_dia3, turm_hora_ini_dia4, turm_hora_fim_dia4, turm_hora_ini_dia5, turm_hora_fim_dia5, turm_hora_ini_dia6, turm_hora_fim_dia6, turm_hora_ini_dia7, turm_hora_fim_dia7);
                            }

                            public ITurmaEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string id, string descricao, DateTime? turm_hora_ini_dia1, DateTime? turm_hora_fim_dia1, DateTime? turm_hora_ini_dia2, DateTime? turm_hora_fim_dia2, DateTime? turm_hora_ini_dia3, DateTime? turm_hora_fim_dia3, DateTime? turm_hora_ini_dia4, DateTime? turm_hora_fim_dia4, DateTime? turm_hora_ini_dia5, DateTime? turm_hora_fim_dia5, DateTime? turm_hora_ini_dia6, DateTime? turm_hora_fim_dia6, DateTime? turm_hora_ini_dia7, DateTime? turm_hora_fim_dia7 )
                            {
                            var entity = new TurmaEntity(id, descricao, turm_hora_ini_dia1, turm_hora_fim_dia1, turm_hora_ini_dia2, turm_hora_fim_dia2, turm_hora_ini_dia3, turm_hora_fim_dia3, turm_hora_ini_dia4, turm_hora_fim_dia4, turm_hora_ini_dia5, turm_hora_fim_dia5, turm_hora_ini_dia6, turm_hora_fim_dia6, turm_hora_ini_dia7, turm_hora_fim_dia7 );


                            var trackingMask = _trackingPolicy?.GetMask("Turma", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new TurmaDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration