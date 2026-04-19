

                            namespace Dominio.Entitys
                            {
                                public class yInboxFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public yInboxFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IyInboxEntity Create(int? id, string type, string entitytype, string entityid, string payload, int status, DateTime createdat, DateTime? sentat, int retrycount, string lasterror, int? sagaid, int? sagastepid )
                            {
                            var entity = new yInboxEntity(id, type, entitytype, entityid, payload, status, createdat, sentat, retrycount, lasterror, sagaid, sagastepid );


                            var decoratedEntity = new yInboxDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration