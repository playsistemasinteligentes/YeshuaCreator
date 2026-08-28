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
                                public class T_MetasFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public T_MetasFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public T_MetasFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IT_MetasEntity Create(int met_id, string met_dtinicio, string met_dtfim, string met_alvo, int met_tipoalvo, int ind_id, Decimal? met_range01, Decimal? met_range02, Decimal? met_range03, int? dim_id, string fat_id, string dim_subdimensao_id, string per_id, string dom_empresa, string dom_filial )
                            {
                                return Create(null, met_id, met_dtinicio, met_dtfim, met_alvo, met_tipoalvo, ind_id, met_range01, met_range02, met_range03, dim_id, fat_id, dim_subdimensao_id, per_id, dom_empresa, dom_filial);
                            }

                            public IT_MetasEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int met_id, string met_dtinicio, string met_dtfim, string met_alvo, int met_tipoalvo, int ind_id, Decimal? met_range01, Decimal? met_range02, Decimal? met_range03, int? dim_id, string fat_id, string dim_subdimensao_id, string per_id, string dom_empresa, string dom_filial )
                            {
                            var entity = new T_MetasEntity(met_id, met_dtinicio, met_dtfim, met_alvo, met_tipoalvo, ind_id, met_range01, met_range02, met_range03, dim_id, fat_id, dim_subdimensao_id, per_id, dom_empresa, dom_filial );


                            var trackingMask = _trackingPolicy?.GetMask("T_Metas", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new T_MetasDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration