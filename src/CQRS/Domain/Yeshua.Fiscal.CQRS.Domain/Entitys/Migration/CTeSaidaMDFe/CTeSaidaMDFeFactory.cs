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
                                public class CTeSaidaMDFeFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public CTeSaidaMDFeFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public CTeSaidaMDFeFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ICTeSaidaMDFeEntity Create(int? id, int ctetentativaemissaoid, string correlationid, string chaveacessocte, string snapshothash, string? outboxmessageid, DateTime? publicadoemutc, string? ultimoerro, int status )
                            {
                                return Create(null, id, ctetentativaemissaoid, correlationid, chaveacessocte, snapshothash, outboxmessageid, publicadoemutc, ultimoerro, status);
                            }

                            public ICTeSaidaMDFeEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int ctetentativaemissaoid, string correlationid, string chaveacessocte, string snapshothash, string? outboxmessageid, DateTime? publicadoemutc, string? ultimoerro, int status )
                            {
                            var entity = new CTeSaidaMDFeEntity(id, ctetentativaemissaoid, correlationid, chaveacessocte, snapshothash, outboxmessageid, publicadoemutc, ultimoerro, status );


                            var trackingMask = _trackingPolicy?.GetMask("CTeSaidaMDFe", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new CTeSaidaMDFeDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration