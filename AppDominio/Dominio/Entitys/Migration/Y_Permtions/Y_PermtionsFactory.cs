

                            namespace Dominio.Entitys
                            {
                                public class Y_PermtionsFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public Y_PermtionsFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IY_PermtionsEntity Create(string id, string description )
                            {
                            var entity = new Y_PermtionsEntity(id, description );


                            var decoratedEntity = new Y_PermtionsDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration