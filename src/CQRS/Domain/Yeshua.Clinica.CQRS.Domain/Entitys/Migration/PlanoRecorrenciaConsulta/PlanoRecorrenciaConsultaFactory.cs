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
                                public class PlanoRecorrenciaConsultaFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public PlanoRecorrenciaConsultaFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public PlanoRecorrenciaConsultaFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IPlanoRecorrenciaConsultaEntity Create(string? id, int profissionalid, string plano, string? confirmacaohash, string? resultado, DateTime expiraemutc )
                            {
                                return Create(null, id, profissionalid, plano, confirmacaohash, resultado, expiraemutc);
                            }

                            public IPlanoRecorrenciaConsultaEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string? id, int profissionalid, string plano, string? confirmacaohash, string? resultado, DateTime expiraemutc, ulong? trackingMask = null )
                            {
                            var entity = new PlanoRecorrenciaConsultaEntity(id, profissionalid, plano, confirmacaohash, resultado, expiraemutc );


                            var effectiveTrackingMask = trackingMask ??
                                _trackingPolicy?.GetMask("PlanoRecorrenciaConsulta", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new PlanoRecorrenciaConsultaDecorator(entity, _logger, context, effectiveTrackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration