

                            namespace Dominio.Entitys
                            {
                                public class PacienteFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public PacienteFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IPacienteEntity Create(int? id, string nome, string telefone, DateTime? datanascimento, int? genero, string escolaridade, string profissao, string endereco, string nomeresponsavel, string telefoneresponsavel, string principaisqueixas, string observacaoadicional )
                            {
                            var entity = new PacienteEntity(id, nome, telefone, datanascimento, genero, escolaridade, profissao, endereco, nomeresponsavel, telefoneresponsavel, principaisqueixas, observacaoadicional );


                            var decoratedEntity = new PacienteDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration