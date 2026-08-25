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
                                public class RoteiroPedidoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public RoteiroPedidoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public RoteiroPedidoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IRoteiroPedidoEntity Create(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, string statuscadastro, string tipoplanejamento, int calendarioid, Decimal? hierarquiasequenciatransformacao, int? proximasequenciatransformacao, Decimal? performance, Decimal? temposetup, Decimal? temposetupajuste, Decimal? pecasporpulso, Decimal? prioridadeinformada, string status, string operacoes, string excecaooperacoes, string linhadireta, int? avaliacusto, Decimal? percentualiniciopassoanterior, Decimal? maquinalargurautil, Decimal? grupotipo, Decimal grupoperformancemetrolinear )
                            {
                                return Create(null, pedidoid, maquinaid, produtoid, sequenciatransformacao, statuscadastro, tipoplanejamento, calendarioid, hierarquiasequenciatransformacao, proximasequenciatransformacao, performance, temposetup, temposetupajuste, pecasporpulso, prioridadeinformada, status, operacoes, excecaooperacoes, linhadireta, avaliacusto, percentualiniciopassoanterior, maquinalargurautil, grupotipo, grupoperformancemetrolinear);
                            }

                            public IRoteiroPedidoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, string statuscadastro, string tipoplanejamento, int calendarioid, Decimal? hierarquiasequenciatransformacao, int? proximasequenciatransformacao, Decimal? performance, Decimal? temposetup, Decimal? temposetupajuste, Decimal? pecasporpulso, Decimal? prioridadeinformada, string status, string operacoes, string excecaooperacoes, string linhadireta, int? avaliacusto, Decimal? percentualiniciopassoanterior, Decimal? maquinalargurautil, Decimal? grupotipo, Decimal grupoperformancemetrolinear )
                            {
                            var entity = new RoteiroPedidoEntity(pedidoid, maquinaid, produtoid, sequenciatransformacao, statuscadastro, tipoplanejamento, calendarioid, hierarquiasequenciatransformacao, proximasequenciatransformacao, performance, temposetup, temposetupajuste, pecasporpulso, prioridadeinformada, status, operacoes, excecaooperacoes, linhadireta, avaliacusto, percentualiniciopassoanterior, maquinalargurautil, grupotipo, grupoperformancemetrolinear );


                            var trackingMask = _trackingPolicy?.GetMask("RoteiroPedido", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new RoteiroPedidoDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration