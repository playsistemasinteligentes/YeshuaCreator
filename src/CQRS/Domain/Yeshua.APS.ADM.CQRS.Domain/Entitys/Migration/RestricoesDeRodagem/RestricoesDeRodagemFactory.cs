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
                                public class RestricoesDeRodagemFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public RestricoesDeRodagemFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public RestricoesDeRodagemFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IRestricoesDeRodagemEntity Create(int? id, int res_id, string res_tipo, string res_hora_ini, string res_hora_fim, Decimal? res_velocidade_hora_rush, int? tve_id, int? map_id )
                            {
                                return Create(null, id, res_id, res_tipo, res_hora_ini, res_hora_fim, res_velocidade_hora_rush, tve_id, map_id);
                            }

                            public IRestricoesDeRodagemEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int res_id, string res_tipo, string res_hora_ini, string res_hora_fim, Decimal? res_velocidade_hora_rush, int? tve_id, int? map_id )
                            {
                            var entity = new RestricoesDeRodagemEntity(id, res_id, res_tipo, res_hora_ini, res_hora_fim, res_velocidade_hora_rush, tve_id, map_id );


                            var trackingMask = _trackingPolicy?.GetMask("RestricoesDeRodagem", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new RestricoesDeRodagemDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration