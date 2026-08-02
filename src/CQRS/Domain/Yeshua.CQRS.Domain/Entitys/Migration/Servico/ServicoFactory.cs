

                            namespace Dominio.Entitys
                            {
                                public class ServicoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public ServicoFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IServicoEntity Create(int? id, int? gruposervicoid, string nome, Decimal valor )
                            {
                            var entity = new ServicoEntity(id, gruposervicoid, nome, valor );


                            var decoratedEntity = new ServicoDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration