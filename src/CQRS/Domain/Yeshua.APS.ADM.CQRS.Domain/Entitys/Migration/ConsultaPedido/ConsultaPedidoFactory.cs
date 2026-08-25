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
                                public class ConsultaPedidoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public ConsultaPedidoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public ConsultaPedidoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IConsultaPedidoEntity Create(string pedidoid, string clienteid, string clientenome, string razaosocial, string produtoid, string produtodescricao, string status, string estagio, DateTime dataentregade, DateTime dataentregaate, DateTime? embarquealvo, Decimal quantidade, Decimal saldoaproduzir, Decimal? saldoaexpedir, string corfila, string pedidocliente )
                            {
                                return Create(null, pedidoid, clienteid, clientenome, razaosocial, produtoid, produtodescricao, status, estagio, dataentregade, dataentregaate, embarquealvo, quantidade, saldoaproduzir, saldoaexpedir, corfila, pedidocliente);
                            }

                            public IConsultaPedidoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string pedidoid, string clienteid, string clientenome, string razaosocial, string produtoid, string produtodescricao, string status, string estagio, DateTime dataentregade, DateTime dataentregaate, DateTime? embarquealvo, Decimal quantidade, Decimal saldoaproduzir, Decimal? saldoaexpedir, string corfila, string pedidocliente )
                            {
                            var entity = new ConsultaPedidoEntity(pedidoid, clienteid, clientenome, razaosocial, produtoid, produtodescricao, status, estagio, dataentregade, dataentregaate, embarquealvo, quantidade, saldoaproduzir, saldoaexpedir, corfila, pedidocliente );


                            var trackingMask = _trackingPolicy?.GetMask("ConsultaPedido", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new ConsultaPedidoDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration