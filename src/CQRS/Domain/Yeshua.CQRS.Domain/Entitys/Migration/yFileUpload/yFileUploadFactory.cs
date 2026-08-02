

                            namespace Dominio.Entitys
                            {
                                public class yFileUploadFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public yFileUploadFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IyFileUploadEntity Create(int? id, string type, int status, string filepath, long? filesize, string entitytype, string entityid, DateTime createdat, DateTime? completedat )
                            {
                            var entity = new yFileUploadEntity(id, type, status, filepath, filesize, entitytype, entityid, createdat, completedat );


                            var decoratedEntity = new yFileUploadDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration