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
                                public class CotasFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public CotasFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public CotasFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ICotasEntity Create(int? id, int cot_id, DateTime? cot_data_de, DateTime? cot_data_ate, Decimal? cot_valor, Decimal? cot_ocupado, int rep_id )
                            {
                                return Create(null, id, cot_id, cot_data_de, cot_data_ate, cot_valor, cot_ocupado, rep_id);
                            }

                            public ICotasEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int cot_id, DateTime? cot_data_de, DateTime? cot_data_ate, Decimal? cot_valor, Decimal? cot_ocupado, int rep_id )
                            {
                            var entity = new CotasEntity(id, cot_id, cot_data_de, cot_data_ate, cot_valor, cot_ocupado, rep_id );


                            var trackingMask = _trackingPolicy?.GetMask("Cotas", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new CotasDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration