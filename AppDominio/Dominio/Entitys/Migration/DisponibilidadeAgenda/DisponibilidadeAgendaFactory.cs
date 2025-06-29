

                            namespace Dominio.Entitys
                            {
                                public class DisponibilidadeAgendaFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public DisponibilidadeAgendaFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IDisponibilidadeAgendaEntity Create(int? id, int? profissionalid, DateTime datahora )
                            {
                            var entity = new DisponibilidadeAgendaEntity(id, profissionalid, datahora );


                            var decoratedEntity = new DisponibilidadeAgendaDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration