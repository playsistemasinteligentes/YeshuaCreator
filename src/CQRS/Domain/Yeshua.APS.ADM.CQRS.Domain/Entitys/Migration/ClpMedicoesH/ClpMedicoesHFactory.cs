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
                                public class ClpMedicoesHFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public ClpMedicoesHFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public ClpMedicoesHFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IClpMedicoesHEntity Create(int id, string maquina_id, DateTime data_ini, DateTime data_fim, DateTime? clp_emissao, Decimal qtd, Decimal? grupo, int? status, string urn_id, string urm_id, int id_lote_clp, string oco_id, int? fase, string clp_origem, int? clp_lote, int? compacta, string bol_id, int? cor_sequencia )
                            {
                                return Create(null, id, maquina_id, data_ini, data_fim, clp_emissao, qtd, grupo, status, urn_id, urm_id, id_lote_clp, oco_id, fase, clp_origem, clp_lote, compacta, bol_id, cor_sequencia);
                            }

                            public IClpMedicoesHEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int id, string maquina_id, DateTime data_ini, DateTime data_fim, DateTime? clp_emissao, Decimal qtd, Decimal? grupo, int? status, string urn_id, string urm_id, int id_lote_clp, string oco_id, int? fase, string clp_origem, int? clp_lote, int? compacta, string bol_id, int? cor_sequencia )
                            {
                            var entity = new ClpMedicoesHEntity(id, maquina_id, data_ini, data_fim, clp_emissao, qtd, grupo, status, urn_id, urm_id, id_lote_clp, oco_id, fase, clp_origem, clp_lote, compacta, bol_id, cor_sequencia );


                            var trackingMask = _trackingPolicy?.GetMask("ClpMedicoesH", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new ClpMedicoesHDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration