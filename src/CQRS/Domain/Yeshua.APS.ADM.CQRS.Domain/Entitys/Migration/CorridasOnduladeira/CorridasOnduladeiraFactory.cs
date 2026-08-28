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
                                public class CorridasOnduladeiraFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public CorridasOnduladeiraFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public CorridasOnduladeiraFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ICorridasOnduladeiraEntity Create(string bol_id, string bol_id_origem, Decimal? pro_largura_peca, Decimal? pro_largura_peca_programado, Decimal? pro_comprimento_peca, Decimal? pro_comprimento_peca_programado, Decimal? pro_utilizou_refile_obrigatorio, string pro_vincos_recalculados, string cor_solver, Decimal? cor_gramatura_papeis_programados, Decimal? cor_custo_papeis_programados, Decimal? cor_gramatura_resina_programados, Decimal? cor_custo_resina_programados, Decimal? cor_tolerancia_menos, Decimal? cor_tolerancia_mais, int? cor_pilhas_por_palete, string cor_cor_fila, Decimal? cor_m_linear_realizado, string pro_id_palete, string cor_status_palete, Decimal? cor_grupo_produtivo, int cor_id, string cor_status, string cor_status_interface, string maq_id, int? cor_id_interface, int? cor_sequencia, int? cor_sequencia_origem, string ord_id, int? fpr_seq_repeticao, int? rot_seq_tranformacao, int? cor_facao, int? cor_formato_bobina, DateTime? cor_inicio_previsto, DateTime? cor_fim_previsto, string pro_id, int? cor_qtd_planejado, int? pro_qtd_pacas, int? cor_pecas_largura )
                            {
                                return Create(null, bol_id, bol_id_origem, pro_largura_peca, pro_largura_peca_programado, pro_comprimento_peca, pro_comprimento_peca_programado, pro_utilizou_refile_obrigatorio, pro_vincos_recalculados, cor_solver, cor_gramatura_papeis_programados, cor_custo_papeis_programados, cor_gramatura_resina_programados, cor_custo_resina_programados, cor_tolerancia_menos, cor_tolerancia_mais, cor_pilhas_por_palete, cor_cor_fila, cor_m_linear_realizado, pro_id_palete, cor_status_palete, cor_grupo_produtivo, cor_id, cor_status, cor_status_interface, maq_id, cor_id_interface, cor_sequencia, cor_sequencia_origem, ord_id, fpr_seq_repeticao, rot_seq_tranformacao, cor_facao, cor_formato_bobina, cor_inicio_previsto, cor_fim_previsto, pro_id, cor_qtd_planejado, pro_qtd_pacas, cor_pecas_largura);
                            }

                            public ICorridasOnduladeiraEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string bol_id, string bol_id_origem, Decimal? pro_largura_peca, Decimal? pro_largura_peca_programado, Decimal? pro_comprimento_peca, Decimal? pro_comprimento_peca_programado, Decimal? pro_utilizou_refile_obrigatorio, string pro_vincos_recalculados, string cor_solver, Decimal? cor_gramatura_papeis_programados, Decimal? cor_custo_papeis_programados, Decimal? cor_gramatura_resina_programados, Decimal? cor_custo_resina_programados, Decimal? cor_tolerancia_menos, Decimal? cor_tolerancia_mais, int? cor_pilhas_por_palete, string cor_cor_fila, Decimal? cor_m_linear_realizado, string pro_id_palete, string cor_status_palete, Decimal? cor_grupo_produtivo, int cor_id, string cor_status, string cor_status_interface, string maq_id, int? cor_id_interface, int? cor_sequencia, int? cor_sequencia_origem, string ord_id, int? fpr_seq_repeticao, int? rot_seq_tranformacao, int? cor_facao, int? cor_formato_bobina, DateTime? cor_inicio_previsto, DateTime? cor_fim_previsto, string pro_id, int? cor_qtd_planejado, int? pro_qtd_pacas, int? cor_pecas_largura )
                            {
                            var entity = new CorridasOnduladeiraEntity(bol_id, bol_id_origem, pro_largura_peca, pro_largura_peca_programado, pro_comprimento_peca, pro_comprimento_peca_programado, pro_utilizou_refile_obrigatorio, pro_vincos_recalculados, cor_solver, cor_gramatura_papeis_programados, cor_custo_papeis_programados, cor_gramatura_resina_programados, cor_custo_resina_programados, cor_tolerancia_menos, cor_tolerancia_mais, cor_pilhas_por_palete, cor_cor_fila, cor_m_linear_realizado, pro_id_palete, cor_status_palete, cor_grupo_produtivo, cor_id, cor_status, cor_status_interface, maq_id, cor_id_interface, cor_sequencia, cor_sequencia_origem, ord_id, fpr_seq_repeticao, rot_seq_tranformacao, cor_facao, cor_formato_bobina, cor_inicio_previsto, cor_fim_previsto, pro_id, cor_qtd_planejado, pro_qtd_pacas, cor_pecas_largura );


                            var trackingMask = _trackingPolicy?.GetMask("CorridasOnduladeira", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new CorridasOnduladeiraDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration