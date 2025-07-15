

                            namespace Dominio.Entitys
                            {
                                public class Y_TenantFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public Y_TenantFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IY_TenantEntity Create(int? id, int cnpjcpf, string nome, int? useridadmin )
                            {
                            var entity = new Y_TenantEntity(id, cnpjcpf, nome, useridadmin );


                            var decoratedEntity = new Y_TenantDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration