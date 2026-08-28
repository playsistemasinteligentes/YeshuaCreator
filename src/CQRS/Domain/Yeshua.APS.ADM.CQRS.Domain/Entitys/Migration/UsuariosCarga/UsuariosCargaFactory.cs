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
                                public class UsuariosCargaFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public UsuariosCargaFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public UsuariosCargaFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IUsuariosCargaEntity Create(int? id, int use_id, string car_id, string rgo_id )
                            {
                                return Create(null, id, use_id, car_id, rgo_id);
                            }

                            public IUsuariosCargaEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int use_id, string car_id, string rgo_id )
                            {
                            var entity = new UsuariosCargaEntity(id, use_id, car_id, rgo_id );


                            var trackingMask = _trackingPolicy?.GetMask("UsuariosCarga", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new UsuariosCargaDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration