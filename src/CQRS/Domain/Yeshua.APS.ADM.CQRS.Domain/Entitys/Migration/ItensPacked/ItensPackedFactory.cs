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
                                public class ItensPackedFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public ItensPackedFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public ItensPackedFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IItensPackedEntity Create(int? id, int ipa_id, string car_id, string pro_id, string ord_id, Decimal? ipa_coordc, Decimal? ipa_coordl, Decimal? ipa_coorda, Decimal? ipa_dimc, Decimal? ipa_diml, Decimal? ipa_dima, Decimal? ipa_qtd_por_palete )
                            {
                                return Create(null, id, ipa_id, car_id, pro_id, ord_id, ipa_coordc, ipa_coordl, ipa_coorda, ipa_dimc, ipa_diml, ipa_dima, ipa_qtd_por_palete);
                            }

                            public IItensPackedEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int ipa_id, string car_id, string pro_id, string ord_id, Decimal? ipa_coordc, Decimal? ipa_coordl, Decimal? ipa_coorda, Decimal? ipa_dimc, Decimal? ipa_diml, Decimal? ipa_dima, Decimal? ipa_qtd_por_palete )
                            {
                            var entity = new ItensPackedEntity(id, ipa_id, car_id, pro_id, ord_id, ipa_coordc, ipa_coordl, ipa_coorda, ipa_dimc, ipa_diml, ipa_dima, ipa_qtd_por_palete );


                            var trackingMask = _trackingPolicy?.GetMask("ItensPacked", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new ItensPackedDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration