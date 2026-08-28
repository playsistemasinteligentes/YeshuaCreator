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
                                public class InformacoesComplementaresFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public InformacoesComplementaresFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public InformacoesComplementaresFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IInformacoesComplementaresEntity Create(int inf_id, string inf_descricao, Decimal inf_valor, int met_id, string inf_data )
                            {
                                return Create(null, inf_id, inf_descricao, inf_valor, met_id, inf_data);
                            }

                            public IInformacoesComplementaresEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int inf_id, string inf_descricao, Decimal inf_valor, int met_id, string inf_data )
                            {
                            var entity = new InformacoesComplementaresEntity(inf_id, inf_descricao, inf_valor, met_id, inf_data );


                            var trackingMask = _trackingPolicy?.GetMask("InformacoesComplementares", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new InformacoesComplementaresDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration