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
                                public class GrupoMaquinaFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public GrupoMaquinaFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public GrupoMaquinaFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IGrupoMaquinaEntity Create(string id, string descricao, string status, string gma_tipo_planejamento )
                            {
                                return Create(null, id, descricao, status, gma_tipo_planejamento);
                            }

                            public IGrupoMaquinaEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string id, string descricao, string status, string gma_tipo_planejamento )
                            {
                            var entity = new GrupoMaquinaEntity(id, descricao, status, gma_tipo_planejamento );


                            var trackingMask = _trackingPolicy?.GetMask("GrupoMaquina", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new GrupoMaquinaDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration