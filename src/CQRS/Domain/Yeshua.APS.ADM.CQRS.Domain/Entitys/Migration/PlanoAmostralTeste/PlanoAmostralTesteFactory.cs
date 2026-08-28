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
                                public class PlanoAmostralTesteFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public PlanoAmostralTesteFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public PlanoAmostralTesteFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IPlanoAmostralTesteEntity Create(Decimal? grp_tipo, int pat_id, int? pat_qtd_caixas_de, int? pat_qtd_caixas_ate, int? pat_n_amostragem, Decimal? pat_percent_especif )
                            {
                                return Create(null, grp_tipo, pat_id, pat_qtd_caixas_de, pat_qtd_caixas_ate, pat_n_amostragem, pat_percent_especif);
                            }

                            public IPlanoAmostralTesteEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, Decimal? grp_tipo, int pat_id, int? pat_qtd_caixas_de, int? pat_qtd_caixas_ate, int? pat_n_amostragem, Decimal? pat_percent_especif )
                            {
                            var entity = new PlanoAmostralTesteEntity(grp_tipo, pat_id, pat_qtd_caixas_de, pat_qtd_caixas_ate, pat_n_amostragem, pat_percent_especif );


                            var trackingMask = _trackingPolicy?.GetMask("PlanoAmostralTeste", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new PlanoAmostralTesteDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration