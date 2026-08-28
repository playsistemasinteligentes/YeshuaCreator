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
                                public class PlotagemFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public PlotagemFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public PlotagemFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IPlotagemEntity Create(int? id, int plo_id, string plo_nome, string plo_dimensao, string plo_x, string plo_y, string plo_z, string plo_grafico, int? con_id )
                            {
                                return Create(null, id, plo_id, plo_nome, plo_dimensao, plo_x, plo_y, plo_z, plo_grafico, con_id);
                            }

                            public IPlotagemEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int plo_id, string plo_nome, string plo_dimensao, string plo_x, string plo_y, string plo_z, string plo_grafico, int? con_id )
                            {
                            var entity = new PlotagemEntity(id, plo_id, plo_nome, plo_dimensao, plo_x, plo_y, plo_z, plo_grafico, con_id );


                            var trackingMask = _trackingPolicy?.GetMask("Plotagem", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new PlotagemDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration