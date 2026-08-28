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
                                public class OndaFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public OndaFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public OndaFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IOndaEntity Create(string ond_id, Decimal ond_espessura, Decimal? ond_peso_cola, Decimal? ond_rendimento_onda_1, Decimal? ond_rendimento_onda_2, int? ond_profundidade_vinco, string ond_id_integracao, int vin_id )
                            {
                                return Create(null, ond_id, ond_espessura, ond_peso_cola, ond_rendimento_onda_1, ond_rendimento_onda_2, ond_profundidade_vinco, ond_id_integracao, vin_id);
                            }

                            public IOndaEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string ond_id, Decimal ond_espessura, Decimal? ond_peso_cola, Decimal? ond_rendimento_onda_1, Decimal? ond_rendimento_onda_2, int? ond_profundidade_vinco, string ond_id_integracao, int vin_id )
                            {
                            var entity = new OndaEntity(ond_id, ond_espessura, ond_peso_cola, ond_rendimento_onda_1, ond_rendimento_onda_2, ond_profundidade_vinco, ond_id_integracao, vin_id );


                            var trackingMask = _trackingPolicy?.GetMask("Onda", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new OndaDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration