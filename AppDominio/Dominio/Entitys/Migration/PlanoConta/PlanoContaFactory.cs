

                            namespace Dominio.Entitys
                            {
                                public class PlanoContaFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public PlanoContaFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IPlanoContaEntity Create(int? id, string codigo, string nome, int tipo, int? contapaiid )
                            {
                            var entity = new PlanoContaEntity(id, codigo, nome, tipo, contapaiid );


                            var decoratedEntity = new PlanoContaDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration