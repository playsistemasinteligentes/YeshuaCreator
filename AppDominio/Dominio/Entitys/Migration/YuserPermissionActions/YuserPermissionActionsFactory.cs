

                            namespace Dominio.Entitys
                            {
                                public class YuserPermissionActionsFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public YuserPermissionActionsFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IYuserPermissionActionsEntity Create(int? perfilid, string permissionactionsid, bool? grant, bool? create, bool? read, bool? update, bool? delete, DateTime? validuntil )
                            {
                            var entity = new YuserPermissionActionsEntity(perfilid, permissionactionsid, grant, create, read, update, delete, validuntil );


                            var decoratedEntity = new YuserPermissionActionsDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration