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
                                public class UsuarioFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public UsuarioFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public UsuarioFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IUsuarioEntity Create(int use_id, string use_nome, string use_email, string use_senha, string turm_id, int use_ativo, string use_coderp )
                            {
                                return Create(null, use_id, use_nome, use_email, use_senha, turm_id, use_ativo, use_coderp);
                            }

                            public IUsuarioEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int use_id, string use_nome, string use_email, string use_senha, string turm_id, int use_ativo, string use_coderp )
                            {
                            var entity = new UsuarioEntity(use_id, use_nome, use_email, use_senha, turm_id, use_ativo, use_coderp );


                            var trackingMask = _trackingPolicy?.GetMask("Usuario", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new UsuarioDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration