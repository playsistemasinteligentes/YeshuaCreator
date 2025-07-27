

                            namespace Dominio.Entitys
                            {
                                public class YuserPermitionsFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public YuserPermitionsFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IYuserPermitionsEntity Create(string permitionsid, int? userid )
                            {
                            var entity = new YuserPermitionsEntity(permitionsid, userid );


                            var decoratedEntity = new YuserPermitionsDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration