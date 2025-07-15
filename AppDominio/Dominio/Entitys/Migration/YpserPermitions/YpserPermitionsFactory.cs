

                            namespace Dominio.Entitys
                            {
                                public class YpserPermitionsFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public YpserPermitionsFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IYpserPermitionsEntity Create(int? userid, string permitionsid )
                            {
                            var entity = new YpserPermitionsEntity(userid, permitionsid );


                            var decoratedEntity = new YpserPermitionsDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration