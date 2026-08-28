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
                                public class MovimentosFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public MovimentosFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public MovimentosFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IMovimentosEntity Create(int mov_id, string mov_data, Decimal mov_valor, int mov_plaid, int mov_unid, int? tr_unidade_uni_id )
                            {
                                return Create(null, mov_id, mov_data, mov_valor, mov_plaid, mov_unid, tr_unidade_uni_id);
                            }

                            public IMovimentosEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int mov_id, string mov_data, Decimal mov_valor, int mov_plaid, int mov_unid, int? tr_unidade_uni_id )
                            {
                            var entity = new MovimentosEntity(mov_id, mov_data, mov_valor, mov_plaid, mov_unid, tr_unidade_uni_id );


                            var trackingMask = _trackingPolicy?.GetMask("Movimentos", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new MovimentosDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration