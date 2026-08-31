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
                                public class yUserGrantFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public yUserGrantFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public yUserGrantFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IyUserGrantEntity Create(int? id, int? perfilid, string grantid, bool? cangrant, bool? cancreate, bool? canread, bool? canupdate, bool? candelete, DateTime? validuntil )
                            {
                                return Create(null, id, perfilid, grantid, cangrant, cancreate, canread, canupdate, candelete, validuntil);
                            }

                            public IyUserGrantEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int? perfilid, string grantid, bool? cangrant, bool? cancreate, bool? canread, bool? canupdate, bool? candelete, DateTime? validuntil )
                            {
                            var entity = new yUserGrantEntity(id, perfilid, grantid, cangrant, cancreate, canread, canupdate, candelete, validuntil );


                            var trackingMask = _trackingPolicy?.GetMask("yUserGrant", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new yUserGrantDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration