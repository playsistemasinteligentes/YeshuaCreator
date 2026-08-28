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
                                public class UniuserFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public UniuserFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public UniuserFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IUniuserEntity Create(int usergru_id, int uni_id, int use_id )
                            {
                                return Create(null, usergru_id, uni_id, use_id);
                            }

                            public IUniuserEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int usergru_id, int uni_id, int use_id )
                            {
                            var entity = new UniuserEntity(usergru_id, uni_id, use_id );


                            var trackingMask = _trackingPolicy?.GetMask("Uniuser", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new UniuserDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration