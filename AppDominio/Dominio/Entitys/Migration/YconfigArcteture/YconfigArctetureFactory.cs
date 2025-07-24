

                            namespace Dominio.Entitys
                            {
                                public class YconfigArctetureFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public YconfigArctetureFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IYconfigArctetureEntity Create(int? id, int? audittrackeractived, int? auditcrudactived )
                            {
                            var entity = new YconfigArctetureEntity(id, audittrackeractived, auditcrudactived );


                            var decoratedEntity = new YconfigArctetureDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration