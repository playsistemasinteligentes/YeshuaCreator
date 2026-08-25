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
                                public class RoteiroFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public RoteiroFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public RoteiroFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IRoteiroEntity Create(string maq_id, string pro_id, int rot_seq_tranformacao, string gma_id, Decimal? rot_pecas_por_pulso, Decimal? rot_prioridade_informada, string rot_acao, Decimal rot_performance, Decimal? rot_tempo_setup, Decimal? rot_tempo_setup_ajuste, int? rot_va_para_seq_transformacao, string rot_status, Decimal? rot_hierarquia_seq_transformacao, int? rot_avalia_custo, string rot_operacoes, string rot_excecao_operacoes, Decimal? rot_percentual_inicio_passo_anterior, string rot_linha_direta, int? tem_id )
                            {
                                return Create(null, maq_id, pro_id, rot_seq_tranformacao, gma_id, rot_pecas_por_pulso, rot_prioridade_informada, rot_acao, rot_performance, rot_tempo_setup, rot_tempo_setup_ajuste, rot_va_para_seq_transformacao, rot_status, rot_hierarquia_seq_transformacao, rot_avalia_custo, rot_operacoes, rot_excecao_operacoes, rot_percentual_inicio_passo_anterior, rot_linha_direta, tem_id);
                            }

                            public IRoteiroEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string maq_id, string pro_id, int rot_seq_tranformacao, string gma_id, Decimal? rot_pecas_por_pulso, Decimal? rot_prioridade_informada, string rot_acao, Decimal rot_performance, Decimal? rot_tempo_setup, Decimal? rot_tempo_setup_ajuste, int? rot_va_para_seq_transformacao, string rot_status, Decimal? rot_hierarquia_seq_transformacao, int? rot_avalia_custo, string rot_operacoes, string rot_excecao_operacoes, Decimal? rot_percentual_inicio_passo_anterior, string rot_linha_direta, int? tem_id )
                            {
                            var entity = new RoteiroEntity(maq_id, pro_id, rot_seq_tranformacao, gma_id, rot_pecas_por_pulso, rot_prioridade_informada, rot_acao, rot_performance, rot_tempo_setup, rot_tempo_setup_ajuste, rot_va_para_seq_transformacao, rot_status, rot_hierarquia_seq_transformacao, rot_avalia_custo, rot_operacoes, rot_excecao_operacoes, rot_percentual_inicio_passo_anterior, rot_linha_direta, tem_id );


                            var trackingMask = _trackingPolicy?.GetMask("Roteiro", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new RoteiroDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration