

                            namespace Dominio.Entitys
                            {
                                public class YuserFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public YuserFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IYuserEntity Create(int? id, string nome, string email, string senha )
                            {
                            var entity = new YuserEntity(id, nome, email, senha );


                            var decoratedEntity = new YuserDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration