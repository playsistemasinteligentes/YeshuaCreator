

                            namespace Dominio.Entitys
                            {
                                public class Y_UserPermitionsFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public Y_UserPermitionsFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IY_UserPermitionsEntity Create(int? userid, string permitionsid )
                            {
                            var entity = new Y_UserPermitionsEntity(userid, permitionsid );


                            var decoratedEntity = new Y_UserPermitionsDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration