

                            namespace Dominio.Entitys
                            {
                                public class yTenantModuleFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public yTenantModuleFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IyTenantModuleEntity Create(int? id, string moduleid, DateTime? validuntil )
                            {
                            var entity = new yTenantModuleEntity(id, moduleid, validuntil );


                            var decoratedEntity = new yTenantModuleDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration