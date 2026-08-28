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
                                public class CargaFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public CargaFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public CargaFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ICargaEntity Create(int? id, string car_id, DateTime? car_previsao_materia_prima, DateTime? car_data_inicio_previsto, DateTime? car_data_inicio_realizado, DateTime? car_data_fim_previsto, DateTime? car_data_fim_realizado, DateTime? car_inicio_janela_embarque, DateTime? car_fim_janela_embarque, DateTime? car_embarque_alvo, Decimal? car_status, Decimal? car_peso_teorico, Decimal? car_volume_teorico, Decimal? car_peso_real, Decimal? car_volume_real, Decimal? car_peso_embalagem, Decimal? car_peso_entrada, Decimal? car_peso_saida, string car_id_doca, string vei_placa, int? tip_id, string tra_id, Decimal? car_grupo_produtivo, string rot_id, string car_observacao_de_transporte, string car_justificativa_de_carregamento, string oco_id, string car_id_juntada, string car_observacao_otimizador, string car_id_integracao_balanca, string car_pesagem_liberada, string car_obs_lieracao, string oco_id_lieracao, DateTime? car_data_entrada_veiculo, DateTime? car_data_saida_veiculo, DateTime? car_data_romaneio_consolidado, string car_dia_turma_romaneio_consolidado, Decimal? car_diferenca_pesagem, DateTime? car_data_agenciamento, string turn_id, string turm_id )
                            {
                                return Create(null, id, car_id, car_previsao_materia_prima, car_data_inicio_previsto, car_data_inicio_realizado, car_data_fim_previsto, car_data_fim_realizado, car_inicio_janela_embarque, car_fim_janela_embarque, car_embarque_alvo, car_status, car_peso_teorico, car_volume_teorico, car_peso_real, car_volume_real, car_peso_embalagem, car_peso_entrada, car_peso_saida, car_id_doca, vei_placa, tip_id, tra_id, car_grupo_produtivo, rot_id, car_observacao_de_transporte, car_justificativa_de_carregamento, oco_id, car_id_juntada, car_observacao_otimizador, car_id_integracao_balanca, car_pesagem_liberada, car_obs_lieracao, oco_id_lieracao, car_data_entrada_veiculo, car_data_saida_veiculo, car_data_romaneio_consolidado, car_dia_turma_romaneio_consolidado, car_diferenca_pesagem, car_data_agenciamento, turn_id, turm_id);
                            }

                            public ICargaEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string car_id, DateTime? car_previsao_materia_prima, DateTime? car_data_inicio_previsto, DateTime? car_data_inicio_realizado, DateTime? car_data_fim_previsto, DateTime? car_data_fim_realizado, DateTime? car_inicio_janela_embarque, DateTime? car_fim_janela_embarque, DateTime? car_embarque_alvo, Decimal? car_status, Decimal? car_peso_teorico, Decimal? car_volume_teorico, Decimal? car_peso_real, Decimal? car_volume_real, Decimal? car_peso_embalagem, Decimal? car_peso_entrada, Decimal? car_peso_saida, string car_id_doca, string vei_placa, int? tip_id, string tra_id, Decimal? car_grupo_produtivo, string rot_id, string car_observacao_de_transporte, string car_justificativa_de_carregamento, string oco_id, string car_id_juntada, string car_observacao_otimizador, string car_id_integracao_balanca, string car_pesagem_liberada, string car_obs_lieracao, string oco_id_lieracao, DateTime? car_data_entrada_veiculo, DateTime? car_data_saida_veiculo, DateTime? car_data_romaneio_consolidado, string car_dia_turma_romaneio_consolidado, Decimal? car_diferenca_pesagem, DateTime? car_data_agenciamento, string turn_id, string turm_id )
                            {
                            var entity = new CargaEntity(id, car_id, car_previsao_materia_prima, car_data_inicio_previsto, car_data_inicio_realizado, car_data_fim_previsto, car_data_fim_realizado, car_inicio_janela_embarque, car_fim_janela_embarque, car_embarque_alvo, car_status, car_peso_teorico, car_volume_teorico, car_peso_real, car_volume_real, car_peso_embalagem, car_peso_entrada, car_peso_saida, car_id_doca, vei_placa, tip_id, tra_id, car_grupo_produtivo, rot_id, car_observacao_de_transporte, car_justificativa_de_carregamento, oco_id, car_id_juntada, car_observacao_otimizador, car_id_integracao_balanca, car_pesagem_liberada, car_obs_lieracao, oco_id_lieracao, car_data_entrada_veiculo, car_data_saida_veiculo, car_data_romaneio_consolidado, car_dia_turma_romaneio_consolidado, car_diferenca_pesagem, car_data_agenciamento, turn_id, turm_id );


                            var trackingMask = _trackingPolicy?.GetMask("Carga", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new CargaDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration