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
                                public class MaquinaFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public MaquinaFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public MaquinaFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IMaquinaEntity Create(string id, string descricao, string status, int? cal_id, string maq_control_ip, string gma_id, DateTime? maq_ultima_atualizacao, int? maq_sirene_semaforo, string maq_cor_semaforo, string maq_id_maq_pai, int? maq_tipo_contador, string maq_tipo_planejamento, int? maq_avalia_custo, int? fpr_id_op_produzindo, int? maq_congela_fila, int? maq_tempo_min_parada, int? maq_qtd_cores, string maq_id_integracao, string maq_id_integracao_erp, Decimal? maq_hierarquia_seq_transformacao, string equ_id, Decimal? maq_percentual_inicio_passo_anterior, string maq_acompanha_lote_piloto, int? maq_id_sensor, int? maq_debouncing_low, int? maq_debouncing_hight, int? maq_tipo_sinal, int? tem_id, Decimal? maq_comprimento_chapa_de, Decimal? maq_comprimento_chapa_ate, Decimal? maq_largura_chapa_de, Decimal? maq_largura_chapa_ate, Decimal? maq_comprimento_chapa_de_facao_superior, Decimal? maq_comprimento_chapa_ate_facao_superior, Decimal? maq_comprimento_chapa_de_facao_inferior, Decimal? maq_comprimento_chapa_ate_facao_inferior, Decimal? maq_comprimento_entre_vinco_de, Decimal? maq_comprimento_entre_vinco_ate, Decimal? maq_largura_entre_vinco_de, Decimal? maq_largura_entre_vinco_ate, Decimal? maq_altura_entre_vinco_de, Decimal? maq_altura_entre_vinco_ate, Decimal? maq_comprimento_mais_largura_entre_vinco_de, Decimal? maq_comprimento_mais_largura_entre_vinco_ate, Decimal? maq_aba_de, Decimal? maq_aba_ate, Decimal? maq_lap_de, Decimal? maq_lap_ate, string maq_ondas, string maq_prolonga_lap, Decimal? maq_largura_impressao, Decimal? maq_comprimento_impressao, Decimal? maq_rolo_dispositivo_de, Decimal? maq_rolo_dispositivo_ate, string maq_familias, Decimal? maq_refile_minimo, Decimal? maq_largura_util, Decimal? maq_total_aco, string maq_fechamento, Decimal? maq_operacao_vincar, Decimal? maq_operacao_monta_divisao, Decimal? maq_operacao_serrar, string maq_tipo_lap, Decimal? maq_indice_paradas_por_op, int? maq_perda_maxima, int? maq_total_pecas_refilando, int? maq_total_pecas_nao_refilando, int? maq_total_vincos )
                            {
                                return Create(null, id, descricao, status, cal_id, maq_control_ip, gma_id, maq_ultima_atualizacao, maq_sirene_semaforo, maq_cor_semaforo, maq_id_maq_pai, maq_tipo_contador, maq_tipo_planejamento, maq_avalia_custo, fpr_id_op_produzindo, maq_congela_fila, maq_tempo_min_parada, maq_qtd_cores, maq_id_integracao, maq_id_integracao_erp, maq_hierarquia_seq_transformacao, equ_id, maq_percentual_inicio_passo_anterior, maq_acompanha_lote_piloto, maq_id_sensor, maq_debouncing_low, maq_debouncing_hight, maq_tipo_sinal, tem_id, maq_comprimento_chapa_de, maq_comprimento_chapa_ate, maq_largura_chapa_de, maq_largura_chapa_ate, maq_comprimento_chapa_de_facao_superior, maq_comprimento_chapa_ate_facao_superior, maq_comprimento_chapa_de_facao_inferior, maq_comprimento_chapa_ate_facao_inferior, maq_comprimento_entre_vinco_de, maq_comprimento_entre_vinco_ate, maq_largura_entre_vinco_de, maq_largura_entre_vinco_ate, maq_altura_entre_vinco_de, maq_altura_entre_vinco_ate, maq_comprimento_mais_largura_entre_vinco_de, maq_comprimento_mais_largura_entre_vinco_ate, maq_aba_de, maq_aba_ate, maq_lap_de, maq_lap_ate, maq_ondas, maq_prolonga_lap, maq_largura_impressao, maq_comprimento_impressao, maq_rolo_dispositivo_de, maq_rolo_dispositivo_ate, maq_familias, maq_refile_minimo, maq_largura_util, maq_total_aco, maq_fechamento, maq_operacao_vincar, maq_operacao_monta_divisao, maq_operacao_serrar, maq_tipo_lap, maq_indice_paradas_por_op, maq_perda_maxima, maq_total_pecas_refilando, maq_total_pecas_nao_refilando, maq_total_vincos);
                            }

                            public IMaquinaEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string id, string descricao, string status, int? cal_id, string maq_control_ip, string gma_id, DateTime? maq_ultima_atualizacao, int? maq_sirene_semaforo, string maq_cor_semaforo, string maq_id_maq_pai, int? maq_tipo_contador, string maq_tipo_planejamento, int? maq_avalia_custo, int? fpr_id_op_produzindo, int? maq_congela_fila, int? maq_tempo_min_parada, int? maq_qtd_cores, string maq_id_integracao, string maq_id_integracao_erp, Decimal? maq_hierarquia_seq_transformacao, string equ_id, Decimal? maq_percentual_inicio_passo_anterior, string maq_acompanha_lote_piloto, int? maq_id_sensor, int? maq_debouncing_low, int? maq_debouncing_hight, int? maq_tipo_sinal, int? tem_id, Decimal? maq_comprimento_chapa_de, Decimal? maq_comprimento_chapa_ate, Decimal? maq_largura_chapa_de, Decimal? maq_largura_chapa_ate, Decimal? maq_comprimento_chapa_de_facao_superior, Decimal? maq_comprimento_chapa_ate_facao_superior, Decimal? maq_comprimento_chapa_de_facao_inferior, Decimal? maq_comprimento_chapa_ate_facao_inferior, Decimal? maq_comprimento_entre_vinco_de, Decimal? maq_comprimento_entre_vinco_ate, Decimal? maq_largura_entre_vinco_de, Decimal? maq_largura_entre_vinco_ate, Decimal? maq_altura_entre_vinco_de, Decimal? maq_altura_entre_vinco_ate, Decimal? maq_comprimento_mais_largura_entre_vinco_de, Decimal? maq_comprimento_mais_largura_entre_vinco_ate, Decimal? maq_aba_de, Decimal? maq_aba_ate, Decimal? maq_lap_de, Decimal? maq_lap_ate, string maq_ondas, string maq_prolonga_lap, Decimal? maq_largura_impressao, Decimal? maq_comprimento_impressao, Decimal? maq_rolo_dispositivo_de, Decimal? maq_rolo_dispositivo_ate, string maq_familias, Decimal? maq_refile_minimo, Decimal? maq_largura_util, Decimal? maq_total_aco, string maq_fechamento, Decimal? maq_operacao_vincar, Decimal? maq_operacao_monta_divisao, Decimal? maq_operacao_serrar, string maq_tipo_lap, Decimal? maq_indice_paradas_por_op, int? maq_perda_maxima, int? maq_total_pecas_refilando, int? maq_total_pecas_nao_refilando, int? maq_total_vincos )
                            {
                            var entity = new MaquinaEntity(id, descricao, status, cal_id, maq_control_ip, gma_id, maq_ultima_atualizacao, maq_sirene_semaforo, maq_cor_semaforo, maq_id_maq_pai, maq_tipo_contador, maq_tipo_planejamento, maq_avalia_custo, fpr_id_op_produzindo, maq_congela_fila, maq_tempo_min_parada, maq_qtd_cores, maq_id_integracao, maq_id_integracao_erp, maq_hierarquia_seq_transformacao, equ_id, maq_percentual_inicio_passo_anterior, maq_acompanha_lote_piloto, maq_id_sensor, maq_debouncing_low, maq_debouncing_hight, maq_tipo_sinal, tem_id, maq_comprimento_chapa_de, maq_comprimento_chapa_ate, maq_largura_chapa_de, maq_largura_chapa_ate, maq_comprimento_chapa_de_facao_superior, maq_comprimento_chapa_ate_facao_superior, maq_comprimento_chapa_de_facao_inferior, maq_comprimento_chapa_ate_facao_inferior, maq_comprimento_entre_vinco_de, maq_comprimento_entre_vinco_ate, maq_largura_entre_vinco_de, maq_largura_entre_vinco_ate, maq_altura_entre_vinco_de, maq_altura_entre_vinco_ate, maq_comprimento_mais_largura_entre_vinco_de, maq_comprimento_mais_largura_entre_vinco_ate, maq_aba_de, maq_aba_ate, maq_lap_de, maq_lap_ate, maq_ondas, maq_prolonga_lap, maq_largura_impressao, maq_comprimento_impressao, maq_rolo_dispositivo_de, maq_rolo_dispositivo_ate, maq_familias, maq_refile_minimo, maq_largura_util, maq_total_aco, maq_fechamento, maq_operacao_vincar, maq_operacao_monta_divisao, maq_operacao_serrar, maq_tipo_lap, maq_indice_paradas_por_op, maq_perda_maxima, maq_total_pecas_refilando, maq_total_pecas_nao_refilando, maq_total_vincos );


                            var trackingMask = _trackingPolicy?.GetMask("Maquina", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new MaquinaDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration