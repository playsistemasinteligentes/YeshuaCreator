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
                                public class CorridasOnduladeiraEstudoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public CorridasOnduladeiraEstudoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public CorridasOnduladeiraEstudoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ICorridasOnduladeiraEstudoEntity Create(int? id, string bol_id, string bol_id_origem, Decimal? pro_largura_peca, Decimal? pro_largura_peca_programado, Decimal? pro_comprimento_peca, Decimal? pro_comprimento_peca_programado, Decimal? pro_utilizou_refile_obrigatorio, string pro_vincos_recalculados, string cor_solver, Decimal? cor_gramatura_papeis_programados, Decimal? cor_custo_papeis_programados, Decimal? cor_gramatura_resina_programados, Decimal? cor_custo_resina_programados, Decimal? cor_tolerancia_menos, Decimal? cor_tolerancia_mais, int? cor_pilhas_por_palete, Decimal? cor_m_linear_realizado, string pro_id_palete, string cor_status_palete, Decimal? cor_grupo_produtivo )
                            {
                                return Create(null, id, bol_id, bol_id_origem, pro_largura_peca, pro_largura_peca_programado, pro_comprimento_peca, pro_comprimento_peca_programado, pro_utilizou_refile_obrigatorio, pro_vincos_recalculados, cor_solver, cor_gramatura_papeis_programados, cor_custo_papeis_programados, cor_gramatura_resina_programados, cor_custo_resina_programados, cor_tolerancia_menos, cor_tolerancia_mais, cor_pilhas_por_palete, cor_m_linear_realizado, pro_id_palete, cor_status_palete, cor_grupo_produtivo);
                            }

                            public ICorridasOnduladeiraEstudoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string bol_id, string bol_id_origem, Decimal? pro_largura_peca, Decimal? pro_largura_peca_programado, Decimal? pro_comprimento_peca, Decimal? pro_comprimento_peca_programado, Decimal? pro_utilizou_refile_obrigatorio, string pro_vincos_recalculados, string cor_solver, Decimal? cor_gramatura_papeis_programados, Decimal? cor_custo_papeis_programados, Decimal? cor_gramatura_resina_programados, Decimal? cor_custo_resina_programados, Decimal? cor_tolerancia_menos, Decimal? cor_tolerancia_mais, int? cor_pilhas_por_palete, Decimal? cor_m_linear_realizado, string pro_id_palete, string cor_status_palete, Decimal? cor_grupo_produtivo )
                            {
                            var entity = new CorridasOnduladeiraEstudoEntity(id, bol_id, bol_id_origem, pro_largura_peca, pro_largura_peca_programado, pro_comprimento_peca, pro_comprimento_peca_programado, pro_utilizou_refile_obrigatorio, pro_vincos_recalculados, cor_solver, cor_gramatura_papeis_programados, cor_custo_papeis_programados, cor_gramatura_resina_programados, cor_custo_resina_programados, cor_tolerancia_menos, cor_tolerancia_mais, cor_pilhas_por_palete, cor_m_linear_realizado, pro_id_palete, cor_status_palete, cor_grupo_produtivo );


                            var trackingMask = _trackingPolicy?.GetMask("CorridasOnduladeiraEstudo", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new CorridasOnduladeiraEstudoDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration