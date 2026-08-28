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
                                public class ObjetoControlavelFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public ObjetoControlavelFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public ObjetoControlavelFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IObjetoControlavelEntity Create(int? id, string obj_id, string obj_descricao, string obj_tipo, string obj_grupo )
                            {
                                return Create(null, id, obj_id, obj_descricao, obj_tipo, obj_grupo);
                            }

                            public IObjetoControlavelEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string obj_id, string obj_descricao, string obj_tipo, string obj_grupo )
                            {
                            var entity = new ObjetoControlavelEntity(id, obj_id, obj_descricao, obj_tipo, obj_grupo );


                            var trackingMask = _trackingPolicy?.GetMask("ObjetoControlavel", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new ObjetoControlavelDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration