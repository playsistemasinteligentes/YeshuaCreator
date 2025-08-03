

                            namespace Dominio.Entitys
                            {
                                public class YpermissionModulesFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public YpermissionModulesFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IYpermissionModulesEntity Create(string id, string description )
                            {
                            var entity = new YpermissionModulesEntity(id, description );


                            var decoratedEntity = new YpermissionModulesDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration