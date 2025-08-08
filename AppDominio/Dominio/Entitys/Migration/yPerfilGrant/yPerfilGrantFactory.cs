

                            namespace Dominio.Entitys
                            {
                                public class yPerfilGrantFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public yPerfilGrantFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IyPerfilGrantEntity Create(int? perfilid, string grantid, bool? grant, bool? create, bool? read, bool? update, bool? delete, DateTime? validuntil )
                            {
                            var entity = new yPerfilGrantEntity(perfilid, grantid, grant, create, read, update, delete, validuntil );


                            var decoratedEntity = new yPerfilGrantDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration