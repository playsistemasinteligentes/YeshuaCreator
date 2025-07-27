

                            namespace Dominio.Entitys
                            {
                                public class YconfigNotificationFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public YconfigNotificationFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IYconfigNotificationEntity Create(int? id, int? tenantid, string emailsmtpclient, int? emailport, string emailusername, string emailpassword )
                            {
                            var entity = new YconfigNotificationEntity(id, tenantid, emailsmtpclient, emailport, emailusername, emailpassword );


                            var decoratedEntity = new YconfigNotificationDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration