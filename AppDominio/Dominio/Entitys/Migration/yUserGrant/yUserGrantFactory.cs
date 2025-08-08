

                            namespace Dominio.Entitys
                            {
                                public class yUserGrantFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public yUserGrantFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IyUserGrantEntity Create(int? perfilid, string grantid, bool? grant, bool? create, bool? read, bool? update, bool? delete, DateTime? validuntil )
                            {
                            var entity = new yUserGrantEntity(perfilid, grantid, grant, create, read, update, delete, validuntil );


                            var decoratedEntity = new yUserGrantDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration