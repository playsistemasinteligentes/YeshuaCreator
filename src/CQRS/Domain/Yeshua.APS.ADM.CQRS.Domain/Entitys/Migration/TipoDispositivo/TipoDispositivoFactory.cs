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
                                public class TipoDispositivoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public TipoDispositivoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public TipoDispositivoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ITipoDispositivoEntity Create(int? id, string tdi_id, string tdi_descricao )
                            {
                                return Create(null, id, tdi_id, tdi_descricao);
                            }

                            public ITipoDispositivoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string tdi_id, string tdi_descricao )
                            {
                            var entity = new TipoDispositivoEntity(id, tdi_id, tdi_descricao );


                            var trackingMask = _trackingPolicy?.GetMask("TipoDispositivo", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new TipoDispositivoDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration