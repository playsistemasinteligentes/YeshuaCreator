

                            namespace Dominio.Entitys
                            {
                                public class ySagaStepFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public ySagaStepFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IySagaStepEntity Create(int? id, int sagaid, string key, int order, int status, int executioncount, DateTime? lastexecutionat, DateTime? completedat, string errormessage, string payload, int retrycount )
                            {
                            var entity = new ySagaStepEntity(id, sagaid, key, order, status, executioncount, lastexecutionat, completedat, errormessage, payload, retrycount );


                            var decoratedEntity = new ySagaStepDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration