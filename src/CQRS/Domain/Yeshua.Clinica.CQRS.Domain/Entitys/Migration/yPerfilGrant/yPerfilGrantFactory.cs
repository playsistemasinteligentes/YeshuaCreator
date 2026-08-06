

                            namespace Dominio.Entitys
                            {
                                public class yPerfilGrantFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public yPerfilGrantFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IyPerfilGrantEntity Create(int? id, int? perfilid, string grantid, bool? cangrant, bool? cancreate, bool? canread, bool? canupdate, bool? candelete, DateTime? validuntil )
                            {
                            var entity = new yPerfilGrantEntity(id, perfilid, grantid, cangrant, cancreate, canread, canupdate, candelete, validuntil );


                            var decoratedEntity = new yPerfilGrantDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration