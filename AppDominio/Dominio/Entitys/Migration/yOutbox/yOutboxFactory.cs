

                            namespace Dominio.Entitys
                            {
                                public class yOutboxFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public yOutboxFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IyOutboxEntity Create(int? id, string correlationid, string type, string payload, int status, DateTime createdat, DateTime? sentat, int retrycount, string lasterror )
                            {
                            var entity = new yOutboxEntity(id, correlationid, type, payload, status, createdat, sentat, retrycount, lasterror );


                            var decoratedEntity = new yOutboxDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration