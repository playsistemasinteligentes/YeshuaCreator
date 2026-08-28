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
                                public class T_IndicadoresFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public T_IndicadoresFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public T_IndicadoresFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IT_IndicadoresEntity Create(int ind_id, string ind_descricao, int neg_id, string desc_calculo, int ind_tipocomparador, int? ind_grafico, string ind_conexao, DateTime? ind_dtcriacao, string resposavelind, string resposavelcarga, string procextracao, string per_id, string dim_id, string dom_empresa, string dom_filial )
                            {
                                return Create(null, ind_id, ind_descricao, neg_id, desc_calculo, ind_tipocomparador, ind_grafico, ind_conexao, ind_dtcriacao, resposavelind, resposavelcarga, procextracao, per_id, dim_id, dom_empresa, dom_filial);
                            }

                            public IT_IndicadoresEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int ind_id, string ind_descricao, int neg_id, string desc_calculo, int ind_tipocomparador, int? ind_grafico, string ind_conexao, DateTime? ind_dtcriacao, string resposavelind, string resposavelcarga, string procextracao, string per_id, string dim_id, string dom_empresa, string dom_filial )
                            {
                            var entity = new T_IndicadoresEntity(ind_id, ind_descricao, neg_id, desc_calculo, ind_tipocomparador, ind_grafico, ind_conexao, ind_dtcriacao, resposavelind, resposavelcarga, procextracao, per_id, dim_id, dom_empresa, dom_filial );


                            var trackingMask = _trackingPolicy?.GetMask("T_Indicadores", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new T_IndicadoresDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration