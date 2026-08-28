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
                                public class ItenCargaFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public ItenCargaFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public ItenCargaFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IItenCargaEntity Create(int? id, string car_id, string ord_id, DateTime itc_entrega_planejada, DateTime itc_entrega_realizada, int itc_ordem_entrega, Decimal itc_qtd_planejada, Decimal itc_qtd_realizada, string ord_hash_key, string not_id, DateTime? not_emissao )
                            {
                                return Create(null, id, car_id, ord_id, itc_entrega_planejada, itc_entrega_realizada, itc_ordem_entrega, itc_qtd_planejada, itc_qtd_realizada, ord_hash_key, not_id, not_emissao);
                            }

                            public IItenCargaEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string car_id, string ord_id, DateTime itc_entrega_planejada, DateTime itc_entrega_realizada, int itc_ordem_entrega, Decimal itc_qtd_planejada, Decimal itc_qtd_realizada, string ord_hash_key, string not_id, DateTime? not_emissao )
                            {
                            var entity = new ItenCargaEntity(id, car_id, ord_id, itc_entrega_planejada, itc_entrega_realizada, itc_ordem_entrega, itc_qtd_planejada, itc_qtd_realizada, ord_hash_key, not_id, not_emissao );


                            var trackingMask = _trackingPolicy?.GetMask("ItenCarga", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new ItenCargaDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration