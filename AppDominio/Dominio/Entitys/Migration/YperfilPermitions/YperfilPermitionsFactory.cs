

                            namespace Dominio.Entitys
                            {
                                public class YperfilPermitionsFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public YperfilPermitionsFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IYperfilPermitionsEntity Create(int? perfilid, string permitionsid )
                            {
                            var entity = new YperfilPermitionsEntity(perfilid, permitionsid );


                            var decoratedEntity = new YperfilPermitionsDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration