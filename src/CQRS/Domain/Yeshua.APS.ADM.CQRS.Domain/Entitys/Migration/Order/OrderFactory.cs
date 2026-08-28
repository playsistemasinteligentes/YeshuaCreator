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
                                public class OrderFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public OrderFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public OrderFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IOrderEntity Create(string ord_id, string ord_id_reserva, string ord_id_conjunto, string pro_id, string pro_id_conjunto, string cli_id, Decimal? ord_preco_unitario, Decimal ord_quantidade, DateTime ord_data_entrega_de, DateTime ord_data_entrega_ate, int? ord_tipo, Decimal? ord_tolerancia_mais, Decimal? ord_tolerancia_menos, string hash_key, DateTime? ord_inicio_janela_embarque, DateTime? ord_fim_janela_embarque, DateTime? ord_embarque_alvo, DateTime? ord_inicio_grupo_produtivo, DateTime? ord_fim_grupo_produtivo, Decimal? ord_peso_unitario, Decimal? ord_peso_unitario_bruto, Decimal? ord_m2_unitario, string ord_mit, string car_tipo_carregamento, string ord_status, string ord_tipo_frete, string ord_endereco_entrega, string ord_bairro_entrega, string uf_id_entrega, string ord_cep_entrega, string mun_id_entrega, string ord_regiao_entrega, Decimal? ord_largura, Decimal? ord_comprimento, Decimal? ord_gramatura, string grp_id, string ord_id_integracao, string ord_observacao_otimizador, string ord_cor_fila, string ord_ped_cli, string ord_op_integracao, string ord_lote_piloto, int? ord_prioridade, DateTime? ord_emissao, string rep_id, string ord_resina, string ord_endurecedor_miolo, string pro_id_integracao_erp, string ord_vincos_onduladeira, Decimal? ord_erp_custos_fixos, Decimal? ord_erp_custos_variaveis, Decimal? ord_erp_despesas_var_venda, Decimal? ord_erp_impostos, string ord_status_planejamento, int? ord_tolerancia_dimensao_chapa_de, int? ord_tolerancia_dimensao_chapa_ate, Decimal? ord_promove_de, Decimal? ord_promove_ate, string ord_trava_composicao, string ord_trava_resina, string ord_promove_resina, Decimal? ord_latitude_entrega, Decimal? ord_longitude_entrega, string oco_id_cancelamento, string tmp_tipo_carga, string pro_id_palete, string pro_id_tampo, int? ord_pilhas_por_palete, int? ord_chapas_por_pilha, DateTime? ord_data_cancelamento, string ord_status_estatistica, DateTime? ord_data_estatistica, string oco_id_motivo_atraso, int? otk_verssao )
                            {
                                return Create(null, ord_id, ord_id_reserva, ord_id_conjunto, pro_id, pro_id_conjunto, cli_id, ord_preco_unitario, ord_quantidade, ord_data_entrega_de, ord_data_entrega_ate, ord_tipo, ord_tolerancia_mais, ord_tolerancia_menos, hash_key, ord_inicio_janela_embarque, ord_fim_janela_embarque, ord_embarque_alvo, ord_inicio_grupo_produtivo, ord_fim_grupo_produtivo, ord_peso_unitario, ord_peso_unitario_bruto, ord_m2_unitario, ord_mit, car_tipo_carregamento, ord_status, ord_tipo_frete, ord_endereco_entrega, ord_bairro_entrega, uf_id_entrega, ord_cep_entrega, mun_id_entrega, ord_regiao_entrega, ord_largura, ord_comprimento, ord_gramatura, grp_id, ord_id_integracao, ord_observacao_otimizador, ord_cor_fila, ord_ped_cli, ord_op_integracao, ord_lote_piloto, ord_prioridade, ord_emissao, rep_id, ord_resina, ord_endurecedor_miolo, pro_id_integracao_erp, ord_vincos_onduladeira, ord_erp_custos_fixos, ord_erp_custos_variaveis, ord_erp_despesas_var_venda, ord_erp_impostos, ord_status_planejamento, ord_tolerancia_dimensao_chapa_de, ord_tolerancia_dimensao_chapa_ate, ord_promove_de, ord_promove_ate, ord_trava_composicao, ord_trava_resina, ord_promove_resina, ord_latitude_entrega, ord_longitude_entrega, oco_id_cancelamento, tmp_tipo_carga, pro_id_palete, pro_id_tampo, ord_pilhas_por_palete, ord_chapas_por_pilha, ord_data_cancelamento, ord_status_estatistica, ord_data_estatistica, oco_id_motivo_atraso, otk_verssao);
                            }

                            public IOrderEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string ord_id, string ord_id_reserva, string ord_id_conjunto, string pro_id, string pro_id_conjunto, string cli_id, Decimal? ord_preco_unitario, Decimal ord_quantidade, DateTime ord_data_entrega_de, DateTime ord_data_entrega_ate, int? ord_tipo, Decimal? ord_tolerancia_mais, Decimal? ord_tolerancia_menos, string hash_key, DateTime? ord_inicio_janela_embarque, DateTime? ord_fim_janela_embarque, DateTime? ord_embarque_alvo, DateTime? ord_inicio_grupo_produtivo, DateTime? ord_fim_grupo_produtivo, Decimal? ord_peso_unitario, Decimal? ord_peso_unitario_bruto, Decimal? ord_m2_unitario, string ord_mit, string car_tipo_carregamento, string ord_status, string ord_tipo_frete, string ord_endereco_entrega, string ord_bairro_entrega, string uf_id_entrega, string ord_cep_entrega, string mun_id_entrega, string ord_regiao_entrega, Decimal? ord_largura, Decimal? ord_comprimento, Decimal? ord_gramatura, string grp_id, string ord_id_integracao, string ord_observacao_otimizador, string ord_cor_fila, string ord_ped_cli, string ord_op_integracao, string ord_lote_piloto, int? ord_prioridade, DateTime? ord_emissao, string rep_id, string ord_resina, string ord_endurecedor_miolo, string pro_id_integracao_erp, string ord_vincos_onduladeira, Decimal? ord_erp_custos_fixos, Decimal? ord_erp_custos_variaveis, Decimal? ord_erp_despesas_var_venda, Decimal? ord_erp_impostos, string ord_status_planejamento, int? ord_tolerancia_dimensao_chapa_de, int? ord_tolerancia_dimensao_chapa_ate, Decimal? ord_promove_de, Decimal? ord_promove_ate, string ord_trava_composicao, string ord_trava_resina, string ord_promove_resina, Decimal? ord_latitude_entrega, Decimal? ord_longitude_entrega, string oco_id_cancelamento, string tmp_tipo_carga, string pro_id_palete, string pro_id_tampo, int? ord_pilhas_por_palete, int? ord_chapas_por_pilha, DateTime? ord_data_cancelamento, string ord_status_estatistica, DateTime? ord_data_estatistica, string oco_id_motivo_atraso, int? otk_verssao )
                            {
                            var entity = new OrderEntity(ord_id, ord_id_reserva, ord_id_conjunto, pro_id, pro_id_conjunto, cli_id, ord_preco_unitario, ord_quantidade, ord_data_entrega_de, ord_data_entrega_ate, ord_tipo, ord_tolerancia_mais, ord_tolerancia_menos, hash_key, ord_inicio_janela_embarque, ord_fim_janela_embarque, ord_embarque_alvo, ord_inicio_grupo_produtivo, ord_fim_grupo_produtivo, ord_peso_unitario, ord_peso_unitario_bruto, ord_m2_unitario, ord_mit, car_tipo_carregamento, ord_status, ord_tipo_frete, ord_endereco_entrega, ord_bairro_entrega, uf_id_entrega, ord_cep_entrega, mun_id_entrega, ord_regiao_entrega, ord_largura, ord_comprimento, ord_gramatura, grp_id, ord_id_integracao, ord_observacao_otimizador, ord_cor_fila, ord_ped_cli, ord_op_integracao, ord_lote_piloto, ord_prioridade, ord_emissao, rep_id, ord_resina, ord_endurecedor_miolo, pro_id_integracao_erp, ord_vincos_onduladeira, ord_erp_custos_fixos, ord_erp_custos_variaveis, ord_erp_despesas_var_venda, ord_erp_impostos, ord_status_planejamento, ord_tolerancia_dimensao_chapa_de, ord_tolerancia_dimensao_chapa_ate, ord_promove_de, ord_promove_ate, ord_trava_composicao, ord_trava_resina, ord_promove_resina, ord_latitude_entrega, ord_longitude_entrega, oco_id_cancelamento, tmp_tipo_carga, pro_id_palete, pro_id_tampo, ord_pilhas_por_palete, ord_chapas_por_pilha, ord_data_cancelamento, ord_status_estatistica, ord_data_estatistica, oco_id_motivo_atraso, otk_verssao );


                            var trackingMask = _trackingPolicy?.GetMask("Order", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new OrderDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration