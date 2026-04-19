

                            namespace Dominio.Entitys
                            {
                                public class yOutboxFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public yOutboxFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IyOutboxEntity Create(int? id, string type, string entitytype, string entityid, string payload, int status, DateTime createdat, DateTime? sentat, int retrycount, string lasterror, int? sagaid, int? sagastepid )
                            {
                            var entity = new yOutboxEntity(id, type, entitytype, entityid, payload, status, createdat, sentat, retrycount, lasterror, sagaid, sagastepid );


                            var decoratedEntity = new yOutboxDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration