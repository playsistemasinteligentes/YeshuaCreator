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
                                public class ProfissionalFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public ProfissionalFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public ProfissionalFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IProfissionalEntity Create(int? id, string nome, int? especialidadeid, string telefone )
                            {
                                return Create(null, id, nome, especialidadeid, telefone);
                            }

                            public IProfissionalEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string nome, int? especialidadeid, string telefone )
                            {
                            var entity = new ProfissionalEntity(id, nome, especialidadeid, telefone );


                            var trackingMask = _trackingPolicy?.GetMask("Profissional", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new ProfissionalDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration