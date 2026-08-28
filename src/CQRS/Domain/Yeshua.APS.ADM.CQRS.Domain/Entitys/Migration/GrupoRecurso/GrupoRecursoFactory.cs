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
                                public class GrupoRecursoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public GrupoRecursoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public GrupoRecursoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IGrupoRecursoEntity Create(string gre_id, string gre_descricao )
                            {
                                return Create(null, gre_id, gre_descricao);
                            }

                            public IGrupoRecursoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string gre_id, string gre_descricao )
                            {
                            var entity = new GrupoRecursoEntity(gre_id, gre_descricao );


                            var trackingMask = _trackingPolicy?.GetMask("GrupoRecurso", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new GrupoRecursoDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration