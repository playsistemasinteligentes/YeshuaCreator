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
                                public class TipoABNTFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public TipoABNTFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public TipoABNTFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ITipoABNTEntity Create(int? id, string abn_id, string abn_descricao )
                            {
                                return Create(null, id, abn_id, abn_descricao);
                            }

                            public ITipoABNTEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string abn_id, string abn_descricao )
                            {
                            var entity = new TipoABNTEntity(id, abn_id, abn_descricao );


                            var trackingMask = _trackingPolicy?.GetMask("TipoABNT", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new TipoABNTDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration