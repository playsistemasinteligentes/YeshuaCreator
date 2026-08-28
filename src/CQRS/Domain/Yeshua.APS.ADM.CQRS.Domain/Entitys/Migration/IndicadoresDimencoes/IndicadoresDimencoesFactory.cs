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
                                public class IndicadoresDimencoesFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public IndicadoresDimencoesFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public IndicadoresDimencoesFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IIndicadoresDimencoesEntity Create(int? id, int dim_id, int ind_id, string dim_descricao, string dim_sql, string dim_conexao )
                            {
                                return Create(null, id, dim_id, ind_id, dim_descricao, dim_sql, dim_conexao);
                            }

                            public IIndicadoresDimencoesEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int dim_id, int ind_id, string dim_descricao, string dim_sql, string dim_conexao )
                            {
                            var entity = new IndicadoresDimencoesEntity(id, dim_id, ind_id, dim_descricao, dim_sql, dim_conexao );


                            var trackingMask = _trackingPolicy?.GetMask("IndicadoresDimencoes", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new IndicadoresDimencoesDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration