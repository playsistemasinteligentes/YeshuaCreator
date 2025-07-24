

                            namespace Dominio.Entitys
                            {
                                public class YconfigNotificationFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public YconfigNotificationFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IYconfigNotificationEntity Create(int? id, string emailadress, string emailpassword )
                            {
                            var entity = new YconfigNotificationEntity(id, emailadress, emailpassword );


                            var decoratedEntity = new YconfigNotificationDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration