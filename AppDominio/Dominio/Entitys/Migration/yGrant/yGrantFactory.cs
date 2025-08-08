

                            namespace Dominio.Entitys
                            {
                                public class yGrantFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public yGrantFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IyGrantEntity Create(string id, string description )
                            {
                            var entity = new yGrantEntity(id, description );


                            var decoratedEntity = new yGrantDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration