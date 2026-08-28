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
                                public class ObservacoesFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public ObservacoesFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public ObservacoesFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IObservacoesEntity Create(int obs_id, string obs_tipo, string obs_descricao, string cli_id, string maq_id, string pro_id, int? rot_seq_tranformacao, string obs_integracao )
                            {
                                return Create(null, obs_id, obs_tipo, obs_descricao, cli_id, maq_id, pro_id, rot_seq_tranformacao, obs_integracao);
                            }

                            public IObservacoesEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int obs_id, string obs_tipo, string obs_descricao, string cli_id, string maq_id, string pro_id, int? rot_seq_tranformacao, string obs_integracao )
                            {
                            var entity = new ObservacoesEntity(obs_id, obs_tipo, obs_descricao, cli_id, maq_id, pro_id, rot_seq_tranformacao, obs_integracao );


                            var trackingMask = _trackingPolicy?.GetMask("Observacoes", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new ObservacoesDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration