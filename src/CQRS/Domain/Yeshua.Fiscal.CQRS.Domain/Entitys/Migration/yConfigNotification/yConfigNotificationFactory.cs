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
                                public class yConfigNotificationFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public yConfigNotificationFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public yConfigNotificationFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IyConfigNotificationEntity Create(int? id, string emailsmtpclient, int? emailport, string emailusername, string emailpassword )
                            {
                                return Create(null, id, emailsmtpclient, emailport, emailusername, emailpassword);
                            }

                            public IyConfigNotificationEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string emailsmtpclient, int? emailport, string emailusername, string emailpassword )
                            {
                            var entity = new yConfigNotificationEntity(id, emailsmtpclient, emailport, emailusername, emailpassword );


                            var trackingMask = _trackingPolicy?.GetMask("yConfigNotification", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new yConfigNotificationDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration