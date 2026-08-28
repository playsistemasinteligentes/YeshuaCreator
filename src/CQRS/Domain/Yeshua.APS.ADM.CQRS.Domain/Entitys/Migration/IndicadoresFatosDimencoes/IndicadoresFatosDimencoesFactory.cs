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
                                public class IndicadoresFatosDimencoesFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public IndicadoresFatosDimencoesFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public IndicadoresFatosDimencoesFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IIndicadoresFatosDimencoesEntity Create(int? id, string fat_id, int ind_id, int dim_id, string fat_descricao )
                            {
                                return Create(null, id, fat_id, ind_id, dim_id, fat_descricao);
                            }

                            public IIndicadoresFatosDimencoesEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string fat_id, int ind_id, int dim_id, string fat_descricao )
                            {
                            var entity = new IndicadoresFatosDimencoesEntity(id, fat_id, ind_id, dim_id, fat_descricao );


                            var trackingMask = _trackingPolicy?.GetMask("IndicadoresFatosDimencoes", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new IndicadoresFatosDimencoesDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration