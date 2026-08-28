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
                                public class TipoMovimentoEstoqueFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public TipoMovimentoEstoqueFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public TipoMovimentoEstoqueFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ITipoMovimentoEstoqueEntity Create(string tip_id, string tip_descricao, int tip_type, int spr )
                            {
                                return Create(null, tip_id, tip_descricao, tip_type, spr);
                            }

                            public ITipoMovimentoEstoqueEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string tip_id, string tip_descricao, int tip_type, int spr )
                            {
                            var entity = new TipoMovimentoEstoqueEntity(tip_id, tip_descricao, tip_type, spr );


                            var trackingMask = _trackingPolicy?.GetMask("TipoMovimentoEstoque", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new TipoMovimentoEstoqueDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration