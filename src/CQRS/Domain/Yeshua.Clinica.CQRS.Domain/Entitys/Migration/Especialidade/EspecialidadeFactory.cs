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
                                public class EspecialidadeFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public EspecialidadeFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public EspecialidadeFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IEspecialidadeEntity Create(int? id, string descricao )
                            {
                                return Create(null, id, descricao);
                            }

                            public IEspecialidadeEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string descricao )
                            {
                            var entity = new EspecialidadeEntity(id, descricao );


                            var trackingMask = _trackingPolicy?.GetMask("Especialidade", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new EspecialidadeDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration