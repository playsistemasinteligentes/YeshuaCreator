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
                                public class IndicadoresPeriodosDimencoesFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public IndicadoresPeriodosDimencoesFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public IndicadoresPeriodosDimencoesFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IIndicadoresPeriodosDimencoesEntity Create(int? id, string per_id, int ind_id, int dim_id, string per_descricao )
                            {
                                return Create(null, id, per_id, ind_id, dim_id, per_descricao);
                            }

                            public IIndicadoresPeriodosDimencoesEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string per_id, int ind_id, int dim_id, string per_descricao )
                            {
                            var entity = new IndicadoresPeriodosDimencoesEntity(id, per_id, ind_id, dim_id, per_descricao );


                            var trackingMask = _trackingPolicy?.GetMask("IndicadoresPeriodosDimencoes", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new IndicadoresPeriodosDimencoesDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration