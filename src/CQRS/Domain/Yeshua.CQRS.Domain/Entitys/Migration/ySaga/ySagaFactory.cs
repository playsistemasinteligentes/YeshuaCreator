

                            namespace Dominio.Entitys
                            {
                                public class ySagaFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public ySagaFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IySagaEntity Create(int? id, string correlationid, string type, int status, string keycurrentstep, DateTime createdat, DateTime? completedat, string entitytype, string entityid, DateTime? nextexecutionat, DateTime? lockedat, string lockedby )
                            {
                            var entity = new ySagaEntity(id, correlationid, type, status, keycurrentstep, createdat, completedat, entitytype, entityid, nextexecutionat, lockedat, lockedby );


                            var decoratedEntity = new ySagaDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration