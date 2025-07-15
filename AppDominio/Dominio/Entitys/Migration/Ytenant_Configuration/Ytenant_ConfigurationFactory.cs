

                            namespace Dominio.Entitys
                            {
                                public class Ytenant_ConfigurationFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public Ytenant_ConfigurationFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IYtenant_ConfigurationEntity Create(int? id, int? audittrackeractived, int? auditcrudactived, int? tenantid )
                            {
                            var entity = new Ytenant_ConfigurationEntity(id, audittrackeractived, auditcrudactived, tenantid );


                            var decoratedEntity = new Ytenant_ConfigurationDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration