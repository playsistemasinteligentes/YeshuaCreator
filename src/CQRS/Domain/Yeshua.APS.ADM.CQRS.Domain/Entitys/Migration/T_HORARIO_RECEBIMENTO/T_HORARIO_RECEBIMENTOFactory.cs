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
                                public class T_HORARIO_RECEBIMENTOFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public T_HORARIO_RECEBIMENTOFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public T_HORARIO_RECEBIMENTOFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IT_HORARIO_RECEBIMENTOEntity Create(int hre_dia_da_semana, DateTime hre_hora_inicial, DateTime hre_hora_final, string cli_id, int hre_id )
                            {
                                return Create(null, hre_dia_da_semana, hre_hora_inicial, hre_hora_final, cli_id, hre_id);
                            }

                            public IT_HORARIO_RECEBIMENTOEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int hre_dia_da_semana, DateTime hre_hora_inicial, DateTime hre_hora_final, string cli_id, int hre_id )
                            {
                            var entity = new T_HORARIO_RECEBIMENTOEntity(hre_dia_da_semana, hre_hora_inicial, hre_hora_final, cli_id, hre_id );


                            var trackingMask = _trackingPolicy?.GetMask("T_HORARIO_RECEBIMENTO", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new T_HORARIO_RECEBIMENTODecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration