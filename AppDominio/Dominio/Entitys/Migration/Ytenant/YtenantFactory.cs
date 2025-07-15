

                            namespace Dominio.Entitys
                            {
                                public class YtenantFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public YtenantFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IYtenantEntity Create(int? id, int cnpjcpf, string nome, int? useridadmin )
                            {
                            var entity = new YtenantEntity(id, cnpjcpf, nome, useridadmin );


                            var decoratedEntity = new YtenantDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration