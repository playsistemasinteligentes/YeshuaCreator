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
                                public class TemposLogisticosFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public TemposLogisticosFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public TemposLogisticosFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ITemposLogisticosEntity Create(int? id, string tmp_tipo_tempo, string tmp_tipo_carga, Decimal tmp_tempo_medio_unitario, string cli_id )
                            {
                                return Create(null, id, tmp_tipo_tempo, tmp_tipo_carga, tmp_tempo_medio_unitario, cli_id);
                            }

                            public ITemposLogisticosEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string tmp_tipo_tempo, string tmp_tipo_carga, Decimal tmp_tempo_medio_unitario, string cli_id )
                            {
                            var entity = new TemposLogisticosEntity(id, tmp_tipo_tempo, tmp_tipo_carga, tmp_tempo_medio_unitario, cli_id );


                            var trackingMask = _trackingPolicy?.GetMask("TemposLogisticos", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new TemposLogisticosDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration