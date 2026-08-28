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
                                public class TipoDispositivoMaquinaFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public TipoDispositivoMaquinaFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public TipoDispositivoMaquinaFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ITipoDispositivoMaquinaEntity Create(int? id, string tdi_id, string maq_id )
                            {
                                return Create(null, id, tdi_id, maq_id);
                            }

                            public ITipoDispositivoMaquinaEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string tdi_id, string maq_id )
                            {
                            var entity = new TipoDispositivoMaquinaEntity(id, tdi_id, maq_id );


                            var trackingMask = _trackingPolicy?.GetMask("TipoDispositivoMaquina", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new TipoDispositivoMaquinaDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration