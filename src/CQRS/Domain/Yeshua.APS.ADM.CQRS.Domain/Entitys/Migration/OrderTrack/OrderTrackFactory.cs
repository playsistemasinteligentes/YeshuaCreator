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
                                public class OrderTrackFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public OrderTrackFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public OrderTrackFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IOrderTrackEntity Create(int? id, int otk_id, Decimal otk_sequencia, int otk_verssao, string ord_id, string otk_evento, DateTime? otk_data_necessidade_de, DateTime? otk_data_necessidade_ate, DateTime? otk_data_prevista, DateTime? otk_data_realizada, int? fpr_id )
                            {
                                return Create(null, id, otk_id, otk_sequencia, otk_verssao, ord_id, otk_evento, otk_data_necessidade_de, otk_data_necessidade_ate, otk_data_prevista, otk_data_realizada, fpr_id);
                            }

                            public IOrderTrackEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int otk_id, Decimal otk_sequencia, int otk_verssao, string ord_id, string otk_evento, DateTime? otk_data_necessidade_de, DateTime? otk_data_necessidade_ate, DateTime? otk_data_prevista, DateTime? otk_data_realizada, int? fpr_id )
                            {
                            var entity = new OrderTrackEntity(id, otk_id, otk_sequencia, otk_verssao, ord_id, otk_evento, otk_data_necessidade_de, otk_data_necessidade_ate, otk_data_prevista, otk_data_realizada, fpr_id );


                            var trackingMask = _trackingPolicy?.GetMask("OrderTrack", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new OrderTrackDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration