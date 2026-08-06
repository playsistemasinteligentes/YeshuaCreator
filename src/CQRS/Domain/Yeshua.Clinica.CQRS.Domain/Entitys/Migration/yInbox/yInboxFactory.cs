

                            namespace Dominio.Entitys
                            {
                                public class yInboxFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public yInboxFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IyInboxEntity Create(int? id, string messageid, string type, string entitytype, string entityid, string correlationid, string payload, int status, DateTime createdat, int retrycount, string lasterror, DateTime? processingat, DateTime? nextattemptat, int? sagaid, int? sagastepid )
                            {
                            var entity = new yInboxEntity(id, messageid, type, entitytype, entityid, correlationid, payload, status, createdat, retrycount, lasterror, processingat, nextattemptat, sagaid, sagastepid );


                            var decoratedEntity = new yInboxDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration