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
                                public class PerfilObjetoControlavelFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public PerfilObjetoControlavelFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public PerfilObjetoControlavelFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IPerfilObjetoControlavelEntity Create(int? id, int per_id, string obj_id, string peo_acao )
                            {
                                return Create(null, id, per_id, obj_id, peo_acao);
                            }

                            public IPerfilObjetoControlavelEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int per_id, string obj_id, string peo_acao )
                            {
                            var entity = new PerfilObjetoControlavelEntity(id, per_id, obj_id, peo_acao );


                            var trackingMask = _trackingPolicy?.GetMask("PerfilObjetoControlavel", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new PerfilObjetoControlavelDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration