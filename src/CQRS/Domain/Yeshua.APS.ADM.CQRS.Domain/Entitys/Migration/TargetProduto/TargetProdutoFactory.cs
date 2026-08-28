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
                                public class TargetProdutoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public TargetProdutoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public TargetProdutoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ITargetProdutoEntity Create(int tar_id, int? mov_id, string ord_id, string pro_id, string maq_id, string uni_id, string turm_id, string turn_id, int? use_id, string tar_dia_turma, Decimal tar_meta_performance, Decimal? tar_realizado_performance, Decimal? tar_percentual_realizado_performance, Decimal? tar_proxima_meta_performance, Decimal tar_meta_tempo_setup, Decimal? tar_realizado_tempo_setup, Decimal? tar_proxima_meta_tempo_setup, Decimal tar_meta_tempo_setup_ajuste, Decimal? tar_realizado_tempo_setup_ajuste, Decimal? tar_proxima_meta_tempo_setup_ajuste, string oco_id_performance, string tar_obs_performance, string oco_id_setup, string tar_obs_setup, string oco_id_setupa, string tar_obs_setupa, string tar_tipo_feedback_performance, string tar_tipo_feedback_setup, string tar_tipo_feedback_setup_ajuste, Decimal? tar_qtd_setup_ajuste, Decimal? tar_qtd, int? tar_parametro_time_work_stop_machine, int? tar_parametro_tempo_quebra_de_lote, int? rot_seq_tranformacao, int? fpr_seq_repeticao, Decimal? tar_performance_max_verde, Decimal? tar_performance_min_verde, Decimal? tar_setup_max_verde, Decimal? tar_setup_min_verde, Decimal? tar_setupa_max_verde, Decimal? tar_setupa_min_verde, Decimal? tar_performance_min_amarelo, Decimal? tar_setup_max_amarelo, Decimal? tar_setupa_max_amarelo, string tar_obs_op_parcial, string tar_oco_id_op_parcial, string tar_cor_performance, string tar_cor_setup_geral, string tar_cor_setup, string tar_cor_setupa, DateTime? tar_dia_turma_d, Decimal? fee_qtd_pecas_por_pulso, Decimal? tar_qtd_perdas, DateTime? tar_data_inicial, DateTime? tar_data_final, string tar_aprovado, int? tar_tempo_produzindo )
                            {
                                return Create(null, tar_id, mov_id, ord_id, pro_id, maq_id, uni_id, turm_id, turn_id, use_id, tar_dia_turma, tar_meta_performance, tar_realizado_performance, tar_percentual_realizado_performance, tar_proxima_meta_performance, tar_meta_tempo_setup, tar_realizado_tempo_setup, tar_proxima_meta_tempo_setup, tar_meta_tempo_setup_ajuste, tar_realizado_tempo_setup_ajuste, tar_proxima_meta_tempo_setup_ajuste, oco_id_performance, tar_obs_performance, oco_id_setup, tar_obs_setup, oco_id_setupa, tar_obs_setupa, tar_tipo_feedback_performance, tar_tipo_feedback_setup, tar_tipo_feedback_setup_ajuste, tar_qtd_setup_ajuste, tar_qtd, tar_parametro_time_work_stop_machine, tar_parametro_tempo_quebra_de_lote, rot_seq_tranformacao, fpr_seq_repeticao, tar_performance_max_verde, tar_performance_min_verde, tar_setup_max_verde, tar_setup_min_verde, tar_setupa_max_verde, tar_setupa_min_verde, tar_performance_min_amarelo, tar_setup_max_amarelo, tar_setupa_max_amarelo, tar_obs_op_parcial, tar_oco_id_op_parcial, tar_cor_performance, tar_cor_setup_geral, tar_cor_setup, tar_cor_setupa, tar_dia_turma_d, fee_qtd_pecas_por_pulso, tar_qtd_perdas, tar_data_inicial, tar_data_final, tar_aprovado, tar_tempo_produzindo);
                            }

                            public ITargetProdutoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int tar_id, int? mov_id, string ord_id, string pro_id, string maq_id, string uni_id, string turm_id, string turn_id, int? use_id, string tar_dia_turma, Decimal tar_meta_performance, Decimal? tar_realizado_performance, Decimal? tar_percentual_realizado_performance, Decimal? tar_proxima_meta_performance, Decimal tar_meta_tempo_setup, Decimal? tar_realizado_tempo_setup, Decimal? tar_proxima_meta_tempo_setup, Decimal tar_meta_tempo_setup_ajuste, Decimal? tar_realizado_tempo_setup_ajuste, Decimal? tar_proxima_meta_tempo_setup_ajuste, string oco_id_performance, string tar_obs_performance, string oco_id_setup, string tar_obs_setup, string oco_id_setupa, string tar_obs_setupa, string tar_tipo_feedback_performance, string tar_tipo_feedback_setup, string tar_tipo_feedback_setup_ajuste, Decimal? tar_qtd_setup_ajuste, Decimal? tar_qtd, int? tar_parametro_time_work_stop_machine, int? tar_parametro_tempo_quebra_de_lote, int? rot_seq_tranformacao, int? fpr_seq_repeticao, Decimal? tar_performance_max_verde, Decimal? tar_performance_min_verde, Decimal? tar_setup_max_verde, Decimal? tar_setup_min_verde, Decimal? tar_setupa_max_verde, Decimal? tar_setupa_min_verde, Decimal? tar_performance_min_amarelo, Decimal? tar_setup_max_amarelo, Decimal? tar_setupa_max_amarelo, string tar_obs_op_parcial, string tar_oco_id_op_parcial, string tar_cor_performance, string tar_cor_setup_geral, string tar_cor_setup, string tar_cor_setupa, DateTime? tar_dia_turma_d, Decimal? fee_qtd_pecas_por_pulso, Decimal? tar_qtd_perdas, DateTime? tar_data_inicial, DateTime? tar_data_final, string tar_aprovado, int? tar_tempo_produzindo )
                            {
                            var entity = new TargetProdutoEntity(tar_id, mov_id, ord_id, pro_id, maq_id, uni_id, turm_id, turn_id, use_id, tar_dia_turma, tar_meta_performance, tar_realizado_performance, tar_percentual_realizado_performance, tar_proxima_meta_performance, tar_meta_tempo_setup, tar_realizado_tempo_setup, tar_proxima_meta_tempo_setup, tar_meta_tempo_setup_ajuste, tar_realizado_tempo_setup_ajuste, tar_proxima_meta_tempo_setup_ajuste, oco_id_performance, tar_obs_performance, oco_id_setup, tar_obs_setup, oco_id_setupa, tar_obs_setupa, tar_tipo_feedback_performance, tar_tipo_feedback_setup, tar_tipo_feedback_setup_ajuste, tar_qtd_setup_ajuste, tar_qtd, tar_parametro_time_work_stop_machine, tar_parametro_tempo_quebra_de_lote, rot_seq_tranformacao, fpr_seq_repeticao, tar_performance_max_verde, tar_performance_min_verde, tar_setup_max_verde, tar_setup_min_verde, tar_setupa_max_verde, tar_setupa_min_verde, tar_performance_min_amarelo, tar_setup_max_amarelo, tar_setupa_max_amarelo, tar_obs_op_parcial, tar_oco_id_op_parcial, tar_cor_performance, tar_cor_setup_geral, tar_cor_setup, tar_cor_setupa, tar_dia_turma_d, fee_qtd_pecas_por_pulso, tar_qtd_perdas, tar_data_inicial, tar_data_final, tar_aprovado, tar_tempo_produzindo );


                            var trackingMask = _trackingPolicy?.GetMask("TargetProduto", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new TargetProdutoDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration