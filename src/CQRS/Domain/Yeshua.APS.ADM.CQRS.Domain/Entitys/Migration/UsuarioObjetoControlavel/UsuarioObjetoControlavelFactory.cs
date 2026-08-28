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
                                public class UsuarioObjetoControlavelFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public UsuarioObjetoControlavelFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public UsuarioObjetoControlavelFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IUsuarioObjetoControlavelEntity Create(int? id, int use_id, string obj_id, string usu_objeto_acao )
                            {
                                return Create(null, id, use_id, obj_id, usu_objeto_acao);
                            }

                            public IUsuarioObjetoControlavelEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int use_id, string obj_id, string usu_objeto_acao )
                            {
                            var entity = new UsuarioObjetoControlavelEntity(id, use_id, obj_id, usu_objeto_acao );


                            var trackingMask = _trackingPolicy?.GetMask("UsuarioObjetoControlavel", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new UsuarioObjetoControlavelDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration