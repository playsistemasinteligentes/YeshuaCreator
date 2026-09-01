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
                                public class yConfigArctetureFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public yConfigArctetureFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public yConfigArctetureFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IyConfigArctetureEntity Create(int? id, int? audittrackeractived, int? auditcrudactived )
                            {
                                return Create(null, id, audittrackeractived, auditcrudactived);
                            }

                            public IyConfigArctetureEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int? audittrackeractived, int? auditcrudactived )
                            {
                            var entity = new yConfigArctetureEntity(id, audittrackeractived, auditcrudactived );


                            var trackingMask = _trackingPolicy?.GetMask("yConfigArcteture", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new yConfigArctetureDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration