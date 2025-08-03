

                            namespace Dominio.Entitys
                            {
                                public class YpermissionActionsFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public YpermissionActionsFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IYpermissionActionsEntity Create(string id, string description )
                            {
                            var entity = new YpermissionActionsEntity(id, description );


                            var decoratedEntity = new YpermissionActionsDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration