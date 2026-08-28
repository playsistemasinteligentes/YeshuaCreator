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
                                public class FilaProducaoPrevistaFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public FilaProducaoPrevistaFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public FilaProducaoPrevistaFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IFilaProducaoPrevistaEntity Create(int? id, string ord_id, string rot_pro_id, Decimal fpr_quantidade_prevista, string rot_maq_id, DateTime fpr_data_inicio_prevista, DateTime fpr_data_fim_prevista, DateTime fpr_data_fim_maxima, int rot_seq_tranformacao, int fpr_seq_repeticao, string fpr_obs_producao, string fpr_status, Decimal? fpr_tempo_decorrido_setup, Decimal? fpr_tempo_decorrido_setupa, Decimal? fpr_tempo_decorrido_performanc, Decimal? fpr_tempo_deco_pequena_parada, Decimal? fpr_qtd_performance, Decimal? fpr_qtd_setup, Decimal? fpr_qtd_produzida, Decimal? fpr_tempo_teorico_performance, Decimal? fpr_tempo_restante_performanc, Decimal? fpr_velocidade_p_atingir_meta, Decimal? fpr_qtd_restante, Decimal? fpr_velo_atu_pc_segundo, Decimal? fpr_performance_projetada, Decimal? fpr_tempo_restante_total, DateTime? fpr_fim_previsto_atual, int? fpr_produzindo, Decimal? fpr_ordem_na_fila, string fpr_id_integracao, string fpr_truncado, DateTime? fpr_data_trunc_ini, DateTime? fpr_data_trunc_fim, int fpr_id, string fpr_cor_fila, string maq_id_manual, string maq_id_restringida, DateTime fpr_previsao_materia_prima, DateTime? fpr_data_necessidade_inicio_producao, DateTime? fpr_data_necessidade_fim_producao, Decimal? fpr_grupo_produtivo, DateTime? fpr_inicio_grupo_produtivo, DateTime? fpr_fim_grupo_produtivo, string fpr_cor_bico1, string fpr_cor_bico2, string fpr_cor_bico3, string fpr_cor_bico4, string fpr_cor_bico5, Decimal? fpr_meta_setup, string fpr_ord_id_reprogramado, int? fpr_prioridade, int? fpr_seq_inclusao_fila, int? fpr_hierarquia_seq_transformacao, int? fpr_id_origem, DateTime? fpr_data_entrega, string equ_id, Decimal? fpr_grupo_produtivo_manual, DateTime? fpr_emissao, string fpr_motivo_pula_fila, string oco_id, string fpr_peso_unitario, string fpr_m2_unitario )
                            {
                                return Create(null, id, ord_id, rot_pro_id, fpr_quantidade_prevista, rot_maq_id, fpr_data_inicio_prevista, fpr_data_fim_prevista, fpr_data_fim_maxima, rot_seq_tranformacao, fpr_seq_repeticao, fpr_obs_producao, fpr_status, fpr_tempo_decorrido_setup, fpr_tempo_decorrido_setupa, fpr_tempo_decorrido_performanc, fpr_tempo_deco_pequena_parada, fpr_qtd_performance, fpr_qtd_setup, fpr_qtd_produzida, fpr_tempo_teorico_performance, fpr_tempo_restante_performanc, fpr_velocidade_p_atingir_meta, fpr_qtd_restante, fpr_velo_atu_pc_segundo, fpr_performance_projetada, fpr_tempo_restante_total, fpr_fim_previsto_atual, fpr_produzindo, fpr_ordem_na_fila, fpr_id_integracao, fpr_truncado, fpr_data_trunc_ini, fpr_data_trunc_fim, fpr_id, fpr_cor_fila, maq_id_manual, maq_id_restringida, fpr_previsao_materia_prima, fpr_data_necessidade_inicio_producao, fpr_data_necessidade_fim_producao, fpr_grupo_produtivo, fpr_inicio_grupo_produtivo, fpr_fim_grupo_produtivo, fpr_cor_bico1, fpr_cor_bico2, fpr_cor_bico3, fpr_cor_bico4, fpr_cor_bico5, fpr_meta_setup, fpr_ord_id_reprogramado, fpr_prioridade, fpr_seq_inclusao_fila, fpr_hierarquia_seq_transformacao, fpr_id_origem, fpr_data_entrega, equ_id, fpr_grupo_produtivo_manual, fpr_emissao, fpr_motivo_pula_fila, oco_id, fpr_peso_unitario, fpr_m2_unitario);
                            }

                            public IFilaProducaoPrevistaEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string ord_id, string rot_pro_id, Decimal fpr_quantidade_prevista, string rot_maq_id, DateTime fpr_data_inicio_prevista, DateTime fpr_data_fim_prevista, DateTime fpr_data_fim_maxima, int rot_seq_tranformacao, int fpr_seq_repeticao, string fpr_obs_producao, string fpr_status, Decimal? fpr_tempo_decorrido_setup, Decimal? fpr_tempo_decorrido_setupa, Decimal? fpr_tempo_decorrido_performanc, Decimal? fpr_tempo_deco_pequena_parada, Decimal? fpr_qtd_performance, Decimal? fpr_qtd_setup, Decimal? fpr_qtd_produzida, Decimal? fpr_tempo_teorico_performance, Decimal? fpr_tempo_restante_performanc, Decimal? fpr_velocidade_p_atingir_meta, Decimal? fpr_qtd_restante, Decimal? fpr_velo_atu_pc_segundo, Decimal? fpr_performance_projetada, Decimal? fpr_tempo_restante_total, DateTime? fpr_fim_previsto_atual, int? fpr_produzindo, Decimal? fpr_ordem_na_fila, string fpr_id_integracao, string fpr_truncado, DateTime? fpr_data_trunc_ini, DateTime? fpr_data_trunc_fim, int fpr_id, string fpr_cor_fila, string maq_id_manual, string maq_id_restringida, DateTime fpr_previsao_materia_prima, DateTime? fpr_data_necessidade_inicio_producao, DateTime? fpr_data_necessidade_fim_producao, Decimal? fpr_grupo_produtivo, DateTime? fpr_inicio_grupo_produtivo, DateTime? fpr_fim_grupo_produtivo, string fpr_cor_bico1, string fpr_cor_bico2, string fpr_cor_bico3, string fpr_cor_bico4, string fpr_cor_bico5, Decimal? fpr_meta_setup, string fpr_ord_id_reprogramado, int? fpr_prioridade, int? fpr_seq_inclusao_fila, int? fpr_hierarquia_seq_transformacao, int? fpr_id_origem, DateTime? fpr_data_entrega, string equ_id, Decimal? fpr_grupo_produtivo_manual, DateTime? fpr_emissao, string fpr_motivo_pula_fila, string oco_id, string fpr_peso_unitario, string fpr_m2_unitario )
                            {
                            var entity = new FilaProducaoPrevistaEntity(id, ord_id, rot_pro_id, fpr_quantidade_prevista, rot_maq_id, fpr_data_inicio_prevista, fpr_data_fim_prevista, fpr_data_fim_maxima, rot_seq_tranformacao, fpr_seq_repeticao, fpr_obs_producao, fpr_status, fpr_tempo_decorrido_setup, fpr_tempo_decorrido_setupa, fpr_tempo_decorrido_performanc, fpr_tempo_deco_pequena_parada, fpr_qtd_performance, fpr_qtd_setup, fpr_qtd_produzida, fpr_tempo_teorico_performance, fpr_tempo_restante_performanc, fpr_velocidade_p_atingir_meta, fpr_qtd_restante, fpr_velo_atu_pc_segundo, fpr_performance_projetada, fpr_tempo_restante_total, fpr_fim_previsto_atual, fpr_produzindo, fpr_ordem_na_fila, fpr_id_integracao, fpr_truncado, fpr_data_trunc_ini, fpr_data_trunc_fim, fpr_id, fpr_cor_fila, maq_id_manual, maq_id_restringida, fpr_previsao_materia_prima, fpr_data_necessidade_inicio_producao, fpr_data_necessidade_fim_producao, fpr_grupo_produtivo, fpr_inicio_grupo_produtivo, fpr_fim_grupo_produtivo, fpr_cor_bico1, fpr_cor_bico2, fpr_cor_bico3, fpr_cor_bico4, fpr_cor_bico5, fpr_meta_setup, fpr_ord_id_reprogramado, fpr_prioridade, fpr_seq_inclusao_fila, fpr_hierarquia_seq_transformacao, fpr_id_origem, fpr_data_entrega, equ_id, fpr_grupo_produtivo_manual, fpr_emissao, fpr_motivo_pula_fila, oco_id, fpr_peso_unitario, fpr_m2_unitario );


                            var trackingMask = _trackingPolicy?.GetMask("FilaProducaoPrevista", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new FilaProducaoPrevistaDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration