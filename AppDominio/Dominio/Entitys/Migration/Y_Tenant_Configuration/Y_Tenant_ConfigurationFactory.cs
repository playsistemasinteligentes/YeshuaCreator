

                            namespace Dominio.Entitys
                            {
                                public class Y_Tenant_ConfigurationFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public Y_Tenant_ConfigurationFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IY_Tenant_ConfigurationEntity Create(int? id, int? audittrackeractived, int? auditcrudactived, int? tenantid )
                            {
                            var entity = new Y_Tenant_ConfigurationEntity(id, audittrackeractived, auditcrudactived, tenantid );


                            var decoratedEntity = new Y_Tenant_ConfigurationDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration