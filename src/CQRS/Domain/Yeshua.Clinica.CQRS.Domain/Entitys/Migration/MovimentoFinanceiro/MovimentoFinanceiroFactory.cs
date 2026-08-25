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
                                public class MovimentoFinanceiroFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public MovimentoFinanceiroFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public MovimentoFinanceiroFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IMovimentoFinanceiroEntity Create(int? id, string idorigem, int contadebitoid, Decimal valor, DateTime datamovimento, DateTime? datavencimento, int status )
                            {
                                return Create(null, id, idorigem, contadebitoid, valor, datamovimento, datavencimento, status);
                            }

                            public IMovimentoFinanceiroEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string idorigem, int contadebitoid, Decimal valor, DateTime datamovimento, DateTime? datavencimento, int status )
                            {
                            var entity = new MovimentoFinanceiroEntity(id, idorigem, contadebitoid, valor, datamovimento, datavencimento, status );


                            var trackingMask = _trackingPolicy?.GetMask("MovimentoFinanceiro", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new MovimentoFinanceiroDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration