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
                                public class RecursosFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public RecursosFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public RecursosFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IRecursosEntity Create(string rec_id, string rec_descricao, int? cal_id, string rec_control_ip, string gre_id )
                            {
                                return Create(null, rec_id, rec_descricao, cal_id, rec_control_ip, gre_id);
                            }

                            public IRecursosEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string rec_id, string rec_descricao, int? cal_id, string rec_control_ip, string gre_id )
                            {
                            var entity = new RecursosEntity(rec_id, rec_descricao, cal_id, rec_control_ip, gre_id );


                            var trackingMask = _trackingPolicy?.GetMask("Recursos", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new RecursosDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration