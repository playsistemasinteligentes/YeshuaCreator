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
                                public class TipoInspecaoVisualFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public TipoInspecaoVisualFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public TipoInspecaoVisualFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ITipoInspecaoVisualEntity Create(int? id, int tiv_id, string tiv_nome, string tiv_descricao, string tiv_fechamento, string tiv_amostra_aleatoria, int? tiv_n_amostras, string tiv_medida, Decimal? tiv_especificacao, Decimal? tiv_tol_mais, Decimal? tiv_tol_menos )
                            {
                                return Create(null, id, tiv_id, tiv_nome, tiv_descricao, tiv_fechamento, tiv_amostra_aleatoria, tiv_n_amostras, tiv_medida, tiv_especificacao, tiv_tol_mais, tiv_tol_menos);
                            }

                            public ITipoInspecaoVisualEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int tiv_id, string tiv_nome, string tiv_descricao, string tiv_fechamento, string tiv_amostra_aleatoria, int? tiv_n_amostras, string tiv_medida, Decimal? tiv_especificacao, Decimal? tiv_tol_mais, Decimal? tiv_tol_menos )
                            {
                            var entity = new TipoInspecaoVisualEntity(id, tiv_id, tiv_nome, tiv_descricao, tiv_fechamento, tiv_amostra_aleatoria, tiv_n_amostras, tiv_medida, tiv_especificacao, tiv_tol_mais, tiv_tol_menos );


                            var trackingMask = _trackingPolicy?.GetMask("TipoInspecaoVisual", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new TipoInspecaoVisualDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration