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
                                public class FeedbackFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public FeedbackFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public FeedbackFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IFeedbackEntity Create(int id, DateTime datainicial, DateTime datafinal, string maquinaid, string ocorrenciaid, string turnoid, string turmaid, int usuarioid, string orderid, string produtoid, string observacoes, Decimal grupo, string diaturma, int? sequenciatransformacao, int? sequenciarepeticao, Decimal quantidadepulsos, Decimal? quantidadepecasporpulso, Decimal? fee_qtd_total_producao_ajustada, string bol_id, int? cor_sequencia )
                            {
                                return Create(null, id, datainicial, datafinal, maquinaid, ocorrenciaid, turnoid, turmaid, usuarioid, orderid, produtoid, observacoes, grupo, diaturma, sequenciatransformacao, sequenciarepeticao, quantidadepulsos, quantidadepecasporpulso, fee_qtd_total_producao_ajustada, bol_id, cor_sequencia);
                            }

                            public IFeedbackEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int id, DateTime datainicial, DateTime datafinal, string maquinaid, string ocorrenciaid, string turnoid, string turmaid, int usuarioid, string orderid, string produtoid, string observacoes, Decimal grupo, string diaturma, int? sequenciatransformacao, int? sequenciarepeticao, Decimal quantidadepulsos, Decimal? quantidadepecasporpulso, Decimal? fee_qtd_total_producao_ajustada, string bol_id, int? cor_sequencia )
                            {
                            var entity = new FeedbackEntity(id, datainicial, datafinal, maquinaid, ocorrenciaid, turnoid, turmaid, usuarioid, orderid, produtoid, observacoes, grupo, diaturma, sequenciatransformacao, sequenciarepeticao, quantidadepulsos, quantidadepecasporpulso, fee_qtd_total_producao_ajustada, bol_id, cor_sequencia );


                            var trackingMask = _trackingPolicy?.GetMask("Feedback", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new FeedbackDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration