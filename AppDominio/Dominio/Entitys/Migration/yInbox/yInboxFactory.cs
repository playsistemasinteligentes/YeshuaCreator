

                            namespace Dominio.Entitys
                            {
                                public class yInboxFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public yInboxFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IyInboxEntity Create(int? id, string correlationid, string type, string payload, int status, DateTime createdat, DateTime? sentat, int retrycount, string lasterror )
                            {
                            var entity = new yInboxEntity(id, correlationid, type, payload, status, createdat, sentat, retrycount, lasterror );


                            var decoratedEntity = new yInboxDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration