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
                                public class TemplatesGrupoMaquinaFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public TemplatesGrupoMaquinaFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public TemplatesGrupoMaquinaFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ITemplatesGrupoMaquinaEntity Create(int? id, int tem_id, string gma_id )
                            {
                                return Create(null, id, tem_id, gma_id);
                            }

                            public ITemplatesGrupoMaquinaEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int tem_id, string gma_id )
                            {
                            var entity = new TemplatesGrupoMaquinaEntity(id, tem_id, gma_id );


                            var trackingMask = _trackingPolicy?.GetMask("TemplatesGrupoMaquina", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new TemplatesGrupoMaquinaDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration