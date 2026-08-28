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
                                public class GrupoProdutoAbstratoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public GrupoProdutoAbstratoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public GrupoProdutoAbstratoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IGrupoProdutoAbstratoEntity Create(string grp_id, string grp_descricao, int? tem_id, Decimal? grp_tipo, string grp_pap_onda, Decimal? grp_pap_gramatura, Decimal? grp_pap_altura, string grp_pap_nome_comercial, string grp_ativo, DateTime? grp_dt_criacao, string grp_papel1, string grp_papel2, string grp_papel3, string grp_papel4, string grp_papel5, string grp_id_integracao, string grp_id_integracao_erp, int? grp_type, Decimal? grp_performance, Decimal? grp_performance_metro_linear_por_segundo, string grp_resina, string grp_endurecedor_miolo, int vin_id, Decimal? grp_coluna_de, Decimal? grp_coluna_ate, Decimal? grp_crush, string grp_id_familia, Decimal? grp_refile_largura, Decimal? grp_refile_comprimento, string grp_tipo_lap, string grp_lap_prolongado, Decimal? grp_tamanho_lap_ond_simples, Decimal? grp_tamanho_lap_ond_dupla, Decimal? grp_tamanho_lap_prolongado_ond_simples, Decimal? grp_tamanho_lap_prolongado_ond_dupla, string grp_fefco, int? grp_tolerancia_dimencao_chapa_de, int? grp_tolerancia_dimencao_chapa_ate, string grp_prefixo_id_produto, Decimal? grp_coluna_caixa, Decimal? grp_coluna_chapa, Decimal? grp_mullen, int? grp_tendencia_tolerancia_pedido, Decimal? grp_percentual_perda_media, int? grp_filtra_seq_trans, string grp_img_caixa )
                            {
                                return Create(null, grp_id, grp_descricao, tem_id, grp_tipo, grp_pap_onda, grp_pap_gramatura, grp_pap_altura, grp_pap_nome_comercial, grp_ativo, grp_dt_criacao, grp_papel1, grp_papel2, grp_papel3, grp_papel4, grp_papel5, grp_id_integracao, grp_id_integracao_erp, grp_type, grp_performance, grp_performance_metro_linear_por_segundo, grp_resina, grp_endurecedor_miolo, vin_id, grp_coluna_de, grp_coluna_ate, grp_crush, grp_id_familia, grp_refile_largura, grp_refile_comprimento, grp_tipo_lap, grp_lap_prolongado, grp_tamanho_lap_ond_simples, grp_tamanho_lap_ond_dupla, grp_tamanho_lap_prolongado_ond_simples, grp_tamanho_lap_prolongado_ond_dupla, grp_fefco, grp_tolerancia_dimencao_chapa_de, grp_tolerancia_dimencao_chapa_ate, grp_prefixo_id_produto, grp_coluna_caixa, grp_coluna_chapa, grp_mullen, grp_tendencia_tolerancia_pedido, grp_percentual_perda_media, grp_filtra_seq_trans, grp_img_caixa);
                            }

                            public IGrupoProdutoAbstratoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string grp_id, string grp_descricao, int? tem_id, Decimal? grp_tipo, string grp_pap_onda, Decimal? grp_pap_gramatura, Decimal? grp_pap_altura, string grp_pap_nome_comercial, string grp_ativo, DateTime? grp_dt_criacao, string grp_papel1, string grp_papel2, string grp_papel3, string grp_papel4, string grp_papel5, string grp_id_integracao, string grp_id_integracao_erp, int? grp_type, Decimal? grp_performance, Decimal? grp_performance_metro_linear_por_segundo, string grp_resina, string grp_endurecedor_miolo, int vin_id, Decimal? grp_coluna_de, Decimal? grp_coluna_ate, Decimal? grp_crush, string grp_id_familia, Decimal? grp_refile_largura, Decimal? grp_refile_comprimento, string grp_tipo_lap, string grp_lap_prolongado, Decimal? grp_tamanho_lap_ond_simples, Decimal? grp_tamanho_lap_ond_dupla, Decimal? grp_tamanho_lap_prolongado_ond_simples, Decimal? grp_tamanho_lap_prolongado_ond_dupla, string grp_fefco, int? grp_tolerancia_dimencao_chapa_de, int? grp_tolerancia_dimencao_chapa_ate, string grp_prefixo_id_produto, Decimal? grp_coluna_caixa, Decimal? grp_coluna_chapa, Decimal? grp_mullen, int? grp_tendencia_tolerancia_pedido, Decimal? grp_percentual_perda_media, int? grp_filtra_seq_trans, string grp_img_caixa )
                            {
                            var entity = new GrupoProdutoAbstratoEntity(grp_id, grp_descricao, tem_id, grp_tipo, grp_pap_onda, grp_pap_gramatura, grp_pap_altura, grp_pap_nome_comercial, grp_ativo, grp_dt_criacao, grp_papel1, grp_papel2, grp_papel3, grp_papel4, grp_papel5, grp_id_integracao, grp_id_integracao_erp, grp_type, grp_performance, grp_performance_metro_linear_por_segundo, grp_resina, grp_endurecedor_miolo, vin_id, grp_coluna_de, grp_coluna_ate, grp_crush, grp_id_familia, grp_refile_largura, grp_refile_comprimento, grp_tipo_lap, grp_lap_prolongado, grp_tamanho_lap_ond_simples, grp_tamanho_lap_ond_dupla, grp_tamanho_lap_prolongado_ond_simples, grp_tamanho_lap_prolongado_ond_dupla, grp_fefco, grp_tolerancia_dimencao_chapa_de, grp_tolerancia_dimencao_chapa_ate, grp_prefixo_id_produto, grp_coluna_caixa, grp_coluna_chapa, grp_mullen, grp_tendencia_tolerancia_pedido, grp_percentual_perda_media, grp_filtra_seq_trans, grp_img_caixa );


                            var trackingMask = _trackingPolicy?.GetMask("GrupoProdutoAbstrato", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new GrupoProdutoAbstratoDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration