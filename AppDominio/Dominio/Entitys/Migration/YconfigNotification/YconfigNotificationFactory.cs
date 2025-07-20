

                            namespace Dominio.Entitys
                            {
                                public class YconfigNotificationFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public YconfigNotificationFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IYconfigNotificationEntity Create(int? id, string emailadress, string emailpassword, int? tenantid )
                            {
                            var entity = new YconfigNotificationEntity(id, emailadress, emailpassword, tenantid );


                            var decoratedEntity = new YconfigNotificationDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration