

                            namespace Dominio.Entitys
                            {
                                public class MDFeEncerramentoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public MDFeEncerramentoFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IMDFeEncerramentoEntity Create(int? id, int mdfeid, string chaveacesso, string ufcarregamento, string ufdescarregamento, string placaveiculo, DateTime solicitadoem, DateTime? autorizadoem, string protocolo, string codigoretorno, string mensagemretorno )
                            {
                            var entity = new MDFeEncerramentoEntity(id, mdfeid, chaveacesso, ufcarregamento, ufdescarregamento, placaveiculo, solicitadoem, autorizadoem, protocolo, codigoretorno, mensagemretorno );


                            var decoratedEntity = new MDFeEncerramentoDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration