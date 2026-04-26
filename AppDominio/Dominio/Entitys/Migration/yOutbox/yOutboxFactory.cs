

                            namespace Dominio.Entitys
                            {
                                public class yOutboxFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public yOutboxFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IyOutboxEntity Create(int? id, string messageid, string type, string entitytype, string entityid, string payload, int status, int transporttype, string transportdata, DateTime createdat, DateTime? sentat, int retrycount, string lasterror, DateTime? processingat, DateTime? nextattemptat, int? sagaid, int? sagastepid )
                            {
                            var entity = new yOutboxEntity(id, messageid, type, entitytype, entityid, payload, status, transporttype, transportdata, createdat, sentat, retrycount, lasterror, processingat, nextattemptat, sagaid, sagastepid );


                            var decoratedEntity = new yOutboxDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration