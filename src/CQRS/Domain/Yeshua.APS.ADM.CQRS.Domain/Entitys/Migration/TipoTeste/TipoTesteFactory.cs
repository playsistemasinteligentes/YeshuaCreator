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
                                public class TipoTesteFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public TipoTesteFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public TipoTesteFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ITipoTesteEntity Create(Decimal? tt_especificacao, string tt_origem_especificacao, string tt_imprime_no_laudo, int tt_id, string tt_nome, string tt_desc, Decimal? tt_tol_mais, Decimal? tt_tol_menos, string tt_norma, string tt_inicio_processo, int ta_id, string uni_id, int? tt_n_amostras_p_teste, int? tt_max_def_critico, int? tt_max_def_grave )
                            {
                                return Create(null, tt_especificacao, tt_origem_especificacao, tt_imprime_no_laudo, tt_id, tt_nome, tt_desc, tt_tol_mais, tt_tol_menos, tt_norma, tt_inicio_processo, ta_id, uni_id, tt_n_amostras_p_teste, tt_max_def_critico, tt_max_def_grave);
                            }

                            public ITipoTesteEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, Decimal? tt_especificacao, string tt_origem_especificacao, string tt_imprime_no_laudo, int tt_id, string tt_nome, string tt_desc, Decimal? tt_tol_mais, Decimal? tt_tol_menos, string tt_norma, string tt_inicio_processo, int ta_id, string uni_id, int? tt_n_amostras_p_teste, int? tt_max_def_critico, int? tt_max_def_grave )
                            {
                            var entity = new TipoTesteEntity(tt_especificacao, tt_origem_especificacao, tt_imprime_no_laudo, tt_id, tt_nome, tt_desc, tt_tol_mais, tt_tol_menos, tt_norma, tt_inicio_processo, ta_id, uni_id, tt_n_amostras_p_teste, tt_max_def_critico, tt_max_def_grave );


                            var trackingMask = _trackingPolicy?.GetMask("TipoTeste", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new TipoTesteDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration