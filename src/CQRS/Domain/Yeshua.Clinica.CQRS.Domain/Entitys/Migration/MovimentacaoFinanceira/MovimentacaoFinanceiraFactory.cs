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
                                public class MovimentacaoFinanceiraFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public MovimentacaoFinanceiraFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public MovimentacaoFinanceiraFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IMovimentacaoFinanceiraEntity Create(int? id, int? pacienteid, int? servicoid, Decimal valor, int tipomovimentacao, DateTime datamovimentacao, Decimal saldoatual )
                            {
                                return Create(null, id, pacienteid, servicoid, valor, tipomovimentacao, datamovimentacao, saldoatual);
                            }

                            public IMovimentacaoFinanceiraEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int? pacienteid, int? servicoid, Decimal valor, int tipomovimentacao, DateTime datamovimentacao, Decimal saldoatual )
                            {
                            var entity = new MovimentacaoFinanceiraEntity(id, pacienteid, servicoid, valor, tipomovimentacao, datamovimentacao, saldoatual );


                            var trackingMask = _trackingPolicy?.GetMask("MovimentacaoFinanceira", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new MovimentacaoFinanceiraDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration