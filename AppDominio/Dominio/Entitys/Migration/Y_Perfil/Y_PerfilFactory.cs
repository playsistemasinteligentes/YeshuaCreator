

                            namespace Dominio.Entitys
                            {
                                public class Y_PerfilFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public Y_PerfilFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IY_PerfilEntity Create(int? id, string description )
                            {
                            var entity = new Y_PerfilEntity(id, description );


                            var decoratedEntity = new Y_PerfilDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration