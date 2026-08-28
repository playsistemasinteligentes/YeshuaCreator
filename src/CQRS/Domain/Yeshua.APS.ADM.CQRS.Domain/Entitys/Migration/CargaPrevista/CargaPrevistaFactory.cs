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
                                public class CargaPrevistaFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public CargaPrevistaFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public CargaPrevistaFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ICargaPrevistaEntity Create(int? id, string car_id, string ord_id, Decimal itc_qtd_planejada, DateTime? car_previsao_materia_prima, DateTime? car_data_inicio_previsto, DateTime? car_data_inicio_realizado, DateTime? car_data_fim_previsto, DateTime? car_data_fim_realizado, DateTime? car_inicio_janela_embarque, DateTime? car_fim_janela_embarque, DateTime? car_embarque_alvo, Decimal? car_status, Decimal? car_peso_teorico, Decimal? car_volume_teorico, Decimal? car_peso_real, Decimal? car_volume_real, Decimal? car_peso_embalagem, Decimal? car_peso_entrada, Decimal? car_peso_saida, string car_id_doca, string vei_placa, int? tip_id, string tra_id, Decimal? car_grupo_produtivo, string rot_id, string car_observacao_de_transporte, string car_justificativa_de_carregamento, string oco_id, string car_id_juntada, string car_observacao_otimizador )
                            {
                                return Create(null, id, car_id, ord_id, itc_qtd_planejada, car_previsao_materia_prima, car_data_inicio_previsto, car_data_inicio_realizado, car_data_fim_previsto, car_data_fim_realizado, car_inicio_janela_embarque, car_fim_janela_embarque, car_embarque_alvo, car_status, car_peso_teorico, car_volume_teorico, car_peso_real, car_volume_real, car_peso_embalagem, car_peso_entrada, car_peso_saida, car_id_doca, vei_placa, tip_id, tra_id, car_grupo_produtivo, rot_id, car_observacao_de_transporte, car_justificativa_de_carregamento, oco_id, car_id_juntada, car_observacao_otimizador);
                            }

                            public ICargaPrevistaEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string car_id, string ord_id, Decimal itc_qtd_planejada, DateTime? car_previsao_materia_prima, DateTime? car_data_inicio_previsto, DateTime? car_data_inicio_realizado, DateTime? car_data_fim_previsto, DateTime? car_data_fim_realizado, DateTime? car_inicio_janela_embarque, DateTime? car_fim_janela_embarque, DateTime? car_embarque_alvo, Decimal? car_status, Decimal? car_peso_teorico, Decimal? car_volume_teorico, Decimal? car_peso_real, Decimal? car_volume_real, Decimal? car_peso_embalagem, Decimal? car_peso_entrada, Decimal? car_peso_saida, string car_id_doca, string vei_placa, int? tip_id, string tra_id, Decimal? car_grupo_produtivo, string rot_id, string car_observacao_de_transporte, string car_justificativa_de_carregamento, string oco_id, string car_id_juntada, string car_observacao_otimizador )
                            {
                            var entity = new CargaPrevistaEntity(id, car_id, ord_id, itc_qtd_planejada, car_previsao_materia_prima, car_data_inicio_previsto, car_data_inicio_realizado, car_data_fim_previsto, car_data_fim_realizado, car_inicio_janela_embarque, car_fim_janela_embarque, car_embarque_alvo, car_status, car_peso_teorico, car_volume_teorico, car_peso_real, car_volume_real, car_peso_embalagem, car_peso_entrada, car_peso_saida, car_id_doca, vei_placa, tip_id, tra_id, car_grupo_produtivo, rot_id, car_observacao_de_transporte, car_justificativa_de_carregamento, oco_id, car_id_juntada, car_observacao_otimizador );


                            var trackingMask = _trackingPolicy?.GetMask("CargaPrevista", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new CargaPrevistaDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration