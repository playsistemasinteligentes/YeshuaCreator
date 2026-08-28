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
                                public class RegistrosOnduladeiraFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public RegistrosOnduladeiraFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public RegistrosOnduladeiraFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IRegistrosOnduladeiraEntity Create(int? id, int reg_id, string reg_resposta, string reg_status, DateTime reg_data_inicio )
                            {
                                return Create(null, id, reg_id, reg_resposta, reg_status, reg_data_inicio);
                            }

                            public IRegistrosOnduladeiraEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int reg_id, string reg_resposta, string reg_status, DateTime reg_data_inicio )
                            {
                            var entity = new RegistrosOnduladeiraEntity(id, reg_id, reg_resposta, reg_status, reg_data_inicio );


                            var trackingMask = _trackingPolicy?.GetMask("RegistrosOnduladeira", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new RegistrosOnduladeiraDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration