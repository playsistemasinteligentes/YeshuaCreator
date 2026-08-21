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
                                public class ClinicaFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public ClinicaFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IClinicaEntity Create(int? id, string nome, string endereco, string telefone )
                            {
                            var entity = new ClinicaEntity(id, nome, endereco, telefone );


                            var decoratedEntity = new ClinicaDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration