

                            namespace Dominio.Entitys
                            {
                                public class MDFeFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public MDFeFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IMDFeEntity Create(int? id, string chaveacesso, int serie, int numero, string ufcarregamento, string ufdescarregamento, string placaveiculo, DateTime emitidoem, DateTime? autorizadoem, DateTime? iniciadoem, DateTime? encerradoem, DateTime? canceladoem, int situacao )
                            {
                            var entity = new MDFeEntity(id, chaveacesso, serie, numero, ufcarregamento, ufdescarregamento, placaveiculo, emitidoem, autorizadoem, iniciadoem, encerradoem, canceladoem, situacao );


                            var decoratedEntity = new MDFeDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration