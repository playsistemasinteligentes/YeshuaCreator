

                            namespace Dominio.Entitys
                            {
                                public class ProfissionalFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public ProfissionalFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IProfissionalEntity Create(int? id, string nome, int? especialidadeid, string telefone )
                            {
                            var entity = new ProfissionalEntity(id, nome, especialidadeid, telefone );


                            var decoratedEntity = new ProfissionalDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration