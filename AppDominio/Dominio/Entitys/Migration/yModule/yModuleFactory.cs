

                            namespace Dominio.Entitys
                            {
                                public class yModuleFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public yModuleFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IyModuleEntity Create(string id, string description )
                            {
                            var entity = new yModuleEntity(id, description );


                            var decoratedEntity = new yModuleDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration