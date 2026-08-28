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
                                public class VincoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public VincoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public VincoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IVincoEntity Create(int vin_id, string vin_descricao, string vin_id_deslocamento )
                            {
                                return Create(null, vin_id, vin_descricao, vin_id_deslocamento);
                            }

                            public IVincoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int vin_id, string vin_descricao, string vin_id_deslocamento )
                            {
                            var entity = new VincoEntity(vin_id, vin_descricao, vin_id_deslocamento );


                            var trackingMask = _trackingPolicy?.GetMask("Vinco", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new VincoDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration