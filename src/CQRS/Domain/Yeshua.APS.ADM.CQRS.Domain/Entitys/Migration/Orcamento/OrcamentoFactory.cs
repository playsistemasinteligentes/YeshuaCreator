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
                                public class OrcamentoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public OrcamentoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public OrcamentoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IOrcamentoEntity Create(int? id, int orc_id, string rep_id, string con_id, string orc_tipo_frete, DateTime? orc_emissao, string cli_id, int ver_id )
                            {
                                return Create(null, id, orc_id, rep_id, con_id, orc_tipo_frete, orc_emissao, cli_id, ver_id);
                            }

                            public IOrcamentoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int orc_id, string rep_id, string con_id, string orc_tipo_frete, DateTime? orc_emissao, string cli_id, int ver_id )
                            {
                            var entity = new OrcamentoEntity(id, orc_id, rep_id, con_id, orc_tipo_frete, orc_emissao, cli_id, ver_id );


                            var trackingMask = _trackingPolicy?.GetMask("Orcamento", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new OrcamentoDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration