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
                                public class T_MAQUINAS_EQUIPESFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public T_MAQUINAS_EQUIPESFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public T_MAQUINAS_EQUIPESFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IT_MAQUINAS_EQUIPESEntity Create(int? id, string maq_id, string equ_id, int? cal_id, string cli_id )
                            {
                                return Create(null, id, maq_id, equ_id, cal_id, cli_id);
                            }

                            public IT_MAQUINAS_EQUIPESEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string maq_id, string equ_id, int? cal_id, string cli_id )
                            {
                            var entity = new T_MAQUINAS_EQUIPESEntity(id, maq_id, equ_id, cal_id, cli_id );


                            var trackingMask = _trackingPolicy?.GetMask("T_MAQUINAS_EQUIPES", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new T_MAQUINAS_EQUIPESDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration