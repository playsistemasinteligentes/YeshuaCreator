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
                                public class TipoCarroceriaFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public TipoCarroceriaFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public TipoCarroceriaFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ITipoCarroceriaEntity Create(int? id, string tca_id, string tca_descricao )
                            {
                                return Create(null, id, tca_id, tca_descricao);
                            }

                            public ITipoCarroceriaEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string tca_id, string tca_descricao )
                            {
                            var entity = new TipoCarroceriaEntity(id, tca_id, tca_descricao );


                            var trackingMask = _trackingPolicy?.GetMask("TipoCarroceria", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new TipoCarroceriaDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration