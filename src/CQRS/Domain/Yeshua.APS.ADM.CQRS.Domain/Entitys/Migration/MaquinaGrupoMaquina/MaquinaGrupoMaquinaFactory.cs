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
                                public class MaquinaGrupoMaquinaFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public MaquinaGrupoMaquinaFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public MaquinaGrupoMaquinaFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IMaquinaGrupoMaquinaEntity Create(int? id, string gma_id, string maq_id )
                            {
                                return Create(null, id, gma_id, maq_id);
                            }

                            public IMaquinaGrupoMaquinaEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string gma_id, string maq_id )
                            {
                            var entity = new MaquinaGrupoMaquinaEntity(id, gma_id, maq_id );


                            var trackingMask = _trackingPolicy?.GetMask("MaquinaGrupoMaquina", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new MaquinaGrupoMaquinaDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration