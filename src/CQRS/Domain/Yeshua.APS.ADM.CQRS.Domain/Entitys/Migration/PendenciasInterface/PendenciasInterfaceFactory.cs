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
                                public class PendenciasInterfaceFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public PendenciasInterfaceFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public PendenciasInterfaceFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IPendenciasInterfaceEntity Create(string pen_status_out, string pen_protocolo_out, string pen_id_protocolo_out, string pen_status_in, string pen_protocolo_in, string pen_id_protocolo_in, DateTime data_entrada, int pen_id )
                            {
                                return Create(null, pen_status_out, pen_protocolo_out, pen_id_protocolo_out, pen_status_in, pen_protocolo_in, pen_id_protocolo_in, data_entrada, pen_id);
                            }

                            public IPendenciasInterfaceEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string pen_status_out, string pen_protocolo_out, string pen_id_protocolo_out, string pen_status_in, string pen_protocolo_in, string pen_id_protocolo_in, DateTime data_entrada, int pen_id )
                            {
                            var entity = new PendenciasInterfaceEntity(pen_status_out, pen_protocolo_out, pen_id_protocolo_out, pen_status_in, pen_protocolo_in, pen_id_protocolo_in, data_entrada, pen_id );


                            var trackingMask = _trackingPolicy?.GetMask("PendenciasInterface", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new PendenciasInterfaceDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration