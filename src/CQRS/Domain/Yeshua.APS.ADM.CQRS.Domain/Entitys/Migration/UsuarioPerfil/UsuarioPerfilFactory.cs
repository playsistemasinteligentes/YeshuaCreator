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
                                public class UsuarioPerfilFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public UsuarioPerfilFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public UsuarioPerfilFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IUsuarioPerfilEntity Create(int? id, int use_id, int per_id )
                            {
                                return Create(null, id, use_id, per_id);
                            }

                            public IUsuarioPerfilEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int use_id, int per_id )
                            {
                            var entity = new UsuarioPerfilEntity(id, use_id, per_id );


                            var trackingMask = _trackingPolicy?.GetMask("UsuarioPerfil", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new UsuarioPerfilDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration