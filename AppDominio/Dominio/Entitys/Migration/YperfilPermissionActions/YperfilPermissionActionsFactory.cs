

                            namespace Dominio.Entitys
                            {
                                public class YperfilPermissionActionsFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public YperfilPermissionActionsFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IYperfilPermissionActionsEntity Create(int? perfilid, string permissionactionsid, bool? grant, bool? create, bool? read, bool? update, bool? delete, DateTime? validuntil )
                            {
                            var entity = new YperfilPermissionActionsEntity(perfilid, permissionactionsid, grant, create, read, update, delete, validuntil );


                            var decoratedEntity = new YperfilPermissionActionsDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration