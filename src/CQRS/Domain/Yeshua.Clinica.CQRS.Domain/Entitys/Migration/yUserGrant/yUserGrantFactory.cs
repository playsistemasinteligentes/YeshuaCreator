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
                                public class yUserGrantFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public yUserGrantFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IyUserGrantEntity Create(int? id, int? perfilid, string grantid, bool? cangrant, bool? cancreate, bool? canread, bool? canupdate, bool? candelete, DateTime? validuntil )
                            {
                            var entity = new yUserGrantEntity(id, perfilid, grantid, cangrant, cancreate, canread, canupdate, candelete, validuntil );


                            var decoratedEntity = new yUserGrantDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration