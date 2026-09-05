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
                                public class CertificadoDigitalFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public CertificadoDigitalFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public CertificadoDigitalFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ICertificadoDigitalEntity Create(int? id, string apelido, string documentotitular, string storagekey, string thumbprint, DateTime? validode, DateTime? validoate, int ativo )
                            {
                                return Create(null, id, apelido, documentotitular, storagekey, thumbprint, validode, validoate, ativo);
                            }

                            public ICertificadoDigitalEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string apelido, string documentotitular, string storagekey, string thumbprint, DateTime? validode, DateTime? validoate, int ativo )
                            {
                            var entity = new CertificadoDigitalEntity(id, apelido, documentotitular, storagekey, thumbprint, validode, validoate, ativo );


                            var trackingMask = _trackingPolicy?.GetMask("CertificadoDigital", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new CertificadoDigitalDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration