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
                                public class yUserModuleFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public yUserModuleFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public yUserModuleFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IyUserModuleEntity Create(int? id, string moduleid, int? userid, DateTime? validuntil )
                            {
                                return Create(null, id, moduleid, userid, validuntil);
                            }

                            public IyUserModuleEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string moduleid, int? userid, DateTime? validuntil )
                            {
                            var entity = new yUserModuleEntity(id, moduleid, userid, validuntil );


                            var trackingMask = _trackingPolicy?.GetMask("yUserModule", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new yUserModuleDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration