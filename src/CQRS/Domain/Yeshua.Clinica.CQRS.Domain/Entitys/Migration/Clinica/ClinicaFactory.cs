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
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public ClinicaFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public ClinicaFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IClinicaEntity Create(int? id, string nome, string endereco, string telefone )
                            {
                                return Create(null, id, nome, endereco, telefone);
                            }

                            public IClinicaEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string nome, string endereco, string telefone )
                            {
                            var entity = new ClinicaEntity(id, nome, endereco, telefone );


                            var trackingMask = _trackingPolicy?.GetMask("Clinica", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new ClinicaDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration