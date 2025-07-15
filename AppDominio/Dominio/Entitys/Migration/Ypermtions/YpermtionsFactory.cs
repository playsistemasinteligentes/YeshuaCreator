

                            namespace Dominio.Entitys
                            {
                                public class YpermtionsFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public YpermtionsFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IYpermtionsEntity Create(string id, string description )
                            {
                            var entity = new YpermtionsEntity(id, description );


                            var decoratedEntity = new YpermtionsDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration