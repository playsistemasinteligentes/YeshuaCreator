// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeEntityMigration
// </yeshua>



                            namespace Dominio.Entitys
                            {
                                public class yUserModuleFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public yUserModuleFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IyUserModuleEntity Create(int? id, string moduleid, int? userid, DateTime? validuntil )
                            {
                            var entity = new yUserModuleEntity(id, moduleid, userid, validuntil );


                            var decoratedEntity = new yUserModuleDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration