

                            namespace Dominio.Entitys
                            {
                                public class YtenantPermissionMudulesFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public YtenantPermissionMudulesFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IYtenantPermissionMudulesEntity Create(int? id, string permissionmodulesid, int? tenantid, DateTime? validuntil )
                            {
                            var entity = new YtenantPermissionMudulesEntity(id, permissionmodulesid, tenantid, validuntil );


                            var decoratedEntity = new YtenantPermissionMudulesDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration