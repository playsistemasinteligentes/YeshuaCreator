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
                                public class FechamentoTesteFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public FechamentoTesteFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public FechamentoTesteFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IFechamentoTesteEntity Create(int? id, int fec_id, int? fec_qtd, string grp_id )
                            {
                                return Create(null, id, fec_id, fec_qtd, grp_id);
                            }

                            public IFechamentoTesteEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int fec_id, int? fec_qtd, string grp_id )
                            {
                            var entity = new FechamentoTesteEntity(id, fec_id, fec_qtd, grp_id );


                            var trackingMask = _trackingPolicy?.GetMask("FechamentoTeste", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new FechamentoTesteDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration