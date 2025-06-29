

                            namespace Dominio.Entitys
                            {
                                public class Y_PerfilPermitionsFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public Y_PerfilPermitionsFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IY_PerfilPermitionsEntity Create(int? perfilid, string permitionsid )
                            {
                            var entity = new Y_PerfilPermitionsEntity(perfilid, permitionsid );


                            var decoratedEntity = new Y_PerfilPermitionsDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration