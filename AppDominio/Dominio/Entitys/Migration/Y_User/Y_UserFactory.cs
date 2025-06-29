

                            namespace Dominio.Entitys
                            {
                                public class Y_UserFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public Y_UserFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IY_UserEntity Create(int? id, string nome, string email, string senha, int? tenantid )
                            {
                            var entity = new Y_UserEntity(id, nome, email, senha, tenantid );


                            var decoratedEntity = new Y_UserDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration