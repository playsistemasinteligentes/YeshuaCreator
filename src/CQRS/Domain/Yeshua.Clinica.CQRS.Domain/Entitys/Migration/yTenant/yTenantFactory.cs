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
                                public class yTenantFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public yTenantFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IyTenantEntity Create(string cnpjcpf, string nome, int? userid )
                            {
                            var entity = new yTenantEntity(cnpjcpf, nome, userid );


                            var decoratedEntity = new yTenantDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration