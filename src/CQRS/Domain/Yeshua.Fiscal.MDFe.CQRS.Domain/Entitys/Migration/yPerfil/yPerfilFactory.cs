

                            namespace Dominio.Entitys
                            {
                                public class yPerfilFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public yPerfilFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IyPerfilEntity Create(int? id, string description )
                            {
                            var entity = new yPerfilEntity(id, description );


                            var decoratedEntity = new yPerfilDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration