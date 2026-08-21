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
                                public class yConfigArctetureFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public yConfigArctetureFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IyConfigArctetureEntity Create(int? id, int? audittrackeractived, int? auditcrudactived )
                            {
                            var entity = new yConfigArctetureEntity(id, audittrackeractived, auditcrudactived );


                            var decoratedEntity = new yConfigArctetureDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration