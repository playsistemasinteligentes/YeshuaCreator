

                            namespace Dominio.Entitys
                            {
                                public class YperfilFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public YperfilFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IYperfilEntity Create(int? id, string description )
                            {
                            var entity = new YperfilEntity(id, description );


                            var decoratedEntity = new YperfilDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration