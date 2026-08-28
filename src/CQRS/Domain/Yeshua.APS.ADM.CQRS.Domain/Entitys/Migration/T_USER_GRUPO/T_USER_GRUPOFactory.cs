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
                                public class T_USER_GRUPOFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public T_USER_GRUPOFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public T_USER_GRUPOFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IT_USER_GRUPOEntity Create(int? id, int gru_id, int id_usuario )
                            {
                                return Create(null, id, gru_id, id_usuario);
                            }

                            public IT_USER_GRUPOEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int gru_id, int id_usuario )
                            {
                            var entity = new T_USER_GRUPOEntity(id, gru_id, id_usuario );


                            var trackingMask = _trackingPolicy?.GetMask("T_USER_GRUPO", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new T_USER_GRUPODecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration