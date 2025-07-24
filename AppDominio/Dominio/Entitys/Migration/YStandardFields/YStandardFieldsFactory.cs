

                            namespace Dominio.Entitys
                            {
                                public class YStandardFieldsFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public YStandardFieldsFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IYStandardFieldsEntity Create( )
                            {
                            var entity = new YStandardFieldsEntity( );


                            var decoratedEntity = new YStandardFieldsDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration