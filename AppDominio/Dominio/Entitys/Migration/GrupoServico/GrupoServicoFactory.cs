

                            namespace Dominio.Entitys
                            {
                                public class GrupoServicoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public GrupoServicoFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IGrupoServicoEntity Create(int? id, string descricao )
                            {
                            var entity = new GrupoServicoEntity(id, descricao );


                            var decoratedEntity = new GrupoServicoDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration