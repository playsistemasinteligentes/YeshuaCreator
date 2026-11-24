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
                                public class yTenantFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public yTenantFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public yTenantFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IyTenantEntity Create(int id, string cnpjcpf, string nome, int? userid )
                            {
                                return Create(null, id, cnpjcpf, nome, userid);
                            }

                            public IyTenantEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int id, string cnpjcpf, string nome, int? userid, ulong? trackingMask = null )
                            {
                            var entity = new yTenantEntity(id, cnpjcpf, nome, userid );


                            var effectiveTrackingMask = trackingMask ??
                                _trackingPolicy?.GetMask("yTenant", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new yTenantDecorator(entity, _logger, context, effectiveTrackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration