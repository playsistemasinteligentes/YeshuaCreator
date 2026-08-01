

                            namespace Dominio.Entitys
                            {
                                public class EspecialidadeFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public EspecialidadeFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IEspecialidadeEntity Create(int? id, string descricao )
                            {
                            var entity = new EspecialidadeEntity(id, descricao );


                            var decoratedEntity = new EspecialidadeDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration