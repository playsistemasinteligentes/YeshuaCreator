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
                                public class T_FeedbackMovEstoqueFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public T_FeedbackMovEstoqueFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public T_FeedbackMovEstoqueFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IT_FeedbackMovEstoqueEntity Create(int? id, int feedbackid, int movimentoestoqueid )
                            {
                                return Create(null, id, feedbackid, movimentoestoqueid);
                            }

                            public IT_FeedbackMovEstoqueEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int feedbackid, int movimentoestoqueid )
                            {
                            var entity = new T_FeedbackMovEstoqueEntity(id, feedbackid, movimentoestoqueid );


                            var trackingMask = _trackingPolicy?.GetMask("T_FeedbackMovEstoque", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new T_FeedbackMovEstoqueDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration