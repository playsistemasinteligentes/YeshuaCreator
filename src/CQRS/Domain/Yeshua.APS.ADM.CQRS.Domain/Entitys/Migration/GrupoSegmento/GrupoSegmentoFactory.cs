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
                                public class GrupoSegmentoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public GrupoSegmentoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public GrupoSegmentoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IGrupoSegmentoEntity Create(int? id, string grs_id, string grs_descricao, string grs_integracao_erp )
                            {
                                return Create(null, id, grs_id, grs_descricao, grs_integracao_erp);
                            }

                            public IGrupoSegmentoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string grs_id, string grs_descricao, string grs_integracao_erp )
                            {
                            var entity = new GrupoSegmentoEntity(id, grs_id, grs_descricao, grs_integracao_erp );


                            var trackingMask = _trackingPolicy?.GetMask("GrupoSegmento", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new GrupoSegmentoDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration