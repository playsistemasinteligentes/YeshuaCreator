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
                                    } public IRoteiroEntity Create(string maquinaid, string produtoid, int sequenciatransformacao, string grupomaquinaid, Decimal? pecasporpulso, Decimal? prioridadeinformada, string acao, Decimal performance, Decimal? temposetup, Decimal? temposetupajuste, int? proximasequenciatransformacao, string status, Decimal? hierarquiasequenciatransformacao, int? avaliacusto, string operacoes, string excecaooperacoes, Decimal? percentualiniciopassoanterior, string linhadireta, int? templatedetestesid )
                            {
                                return Create(null, maquinaid, produtoid, sequenciatransformacao, grupomaquinaid, pecasporpulso, prioridadeinformada, acao, performance, temposetup, temposetupajuste, proximasequenciatransformacao, status, hierarquiasequenciatransformacao, avaliacusto, operacoes, excecaooperacoes, percentualiniciopassoanterior, linhadireta, templatedetestesid);
                            }

                            public IRoteiroEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string maquinaid, string produtoid, int sequenciatransformacao, string grupomaquinaid, Decimal? pecasporpulso, Decimal? prioridadeinformada, string acao, Decimal performance, Decimal? temposetup, Decimal? temposetupajuste, int? proximasequenciatransformacao, string status, Decimal? hierarquiasequenciatransformacao, int? avaliacusto, string operacoes, string excecaooperacoes, Decimal? percentualiniciopassoanterior, string linhadireta, int? templatedetestesid )
                            {
                            var entity = new RoteiroEntity(maquinaid, produtoid, sequenciatransformacao, grupomaquinaid, pecasporpulso, prioridadeinformada, acao, performance, temposetup, temposetupajuste, proximasequenciatransformacao, status, hierarquiasequenciatransformacao, avaliacusto, operacoes, excecaooperacoes, percentualiniciopassoanterior, linhadireta, templatedetestesid );


                            var trackingMask = _trackingPolicy?.GetMask("Roteiro", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new RoteiroDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration