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
                                    } public IyTenantEntity Create(string cnpjcpf, string nome, int? userid )
                            {
                                return Create(null, cnpjcpf, nome, userid);
                            }

                            public IyTenantEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string cnpjcpf, string nome, int? userid )
                            {
                            var entity = new yTenantEntity(cnpjcpf, nome, userid );


                            var trackingMask = _trackingPolicy?.GetMask("yTenant", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new yTenantDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration