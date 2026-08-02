

                            namespace Dominio.Entitys
                            {
                                public class yConfigNotificationFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public yConfigNotificationFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IyConfigNotificationEntity Create(int? id, string emailsmtpclient, int? emailport, string emailusername, string emailpassword )
                            {
                            var entity = new yConfigNotificationEntity(id, emailsmtpclient, emailport, emailusername, emailpassword );


                            var decoratedEntity = new yConfigNotificationDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration