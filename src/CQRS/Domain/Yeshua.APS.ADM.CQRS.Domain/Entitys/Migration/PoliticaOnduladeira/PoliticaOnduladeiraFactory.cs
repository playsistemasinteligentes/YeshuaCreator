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
                                public class PoliticaOnduladeiraFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public PoliticaOnduladeiraFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public PoliticaOnduladeiraFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IPoliticaOnduladeiraEntity Create(int? id, int pol_id, int? pol_nivel, int? pol_promocao, int? pol_dias_antecipacao, int? pol_metros_lineares )
                            {
                                return Create(null, id, pol_id, pol_nivel, pol_promocao, pol_dias_antecipacao, pol_metros_lineares);
                            }

                            public IPoliticaOnduladeiraEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int pol_id, int? pol_nivel, int? pol_promocao, int? pol_dias_antecipacao, int? pol_metros_lineares )
                            {
                            var entity = new PoliticaOnduladeiraEntity(id, pol_id, pol_nivel, pol_promocao, pol_dias_antecipacao, pol_metros_lineares );


                            var trackingMask = _trackingPolicy?.GetMask("PoliticaOnduladeira", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new PoliticaOnduladeiraDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration