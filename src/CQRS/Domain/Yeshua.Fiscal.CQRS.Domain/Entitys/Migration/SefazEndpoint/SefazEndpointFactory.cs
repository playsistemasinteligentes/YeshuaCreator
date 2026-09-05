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
                                public class SefazEndpointFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public SefazEndpointFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public SefazEndpointFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ISefazEndpointEntity Create(int? id, int produtofiscal, string uf, int ambiente, string servico, string versao, string url, int ativo )
                            {
                                return Create(null, id, produtofiscal, uf, ambiente, servico, versao, url, ativo);
                            }

                            public ISefazEndpointEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int produtofiscal, string uf, int ambiente, string servico, string versao, string url, int ativo )
                            {
                            var entity = new SefazEndpointEntity(id, produtofiscal, uf, ambiente, servico, versao, url, ativo );


                            var trackingMask = _trackingPolicy?.GetMask("SefazEndpoint", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new SefazEndpointDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration