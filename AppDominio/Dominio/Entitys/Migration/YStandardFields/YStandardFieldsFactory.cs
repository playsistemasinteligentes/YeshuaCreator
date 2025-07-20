

                            namespace Dominio.Entitys
                            {
                                public class YStandardFieldsFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public YStandardFieldsFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IYStandardFieldsEntity Create(bool? deleted )
                            {
                            var entity = new YStandardFieldsEntity(deleted );


                            var decoratedEntity = new YStandardFieldsDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration