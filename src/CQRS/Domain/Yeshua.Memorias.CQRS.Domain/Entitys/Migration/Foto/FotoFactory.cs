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
                                public class FotoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public FotoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public FotoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IFotoEntity Create(int? id, string storagekey, string nomeoriginal, string contenttype, string? hasharquivo, DateTime? capturadaemutc, int? largura, int? altura, int status )
                            {
                                return Create(null, id, storagekey, nomeoriginal, contenttype, hasharquivo, capturadaemutc, largura, altura, status);
                            }

                            public IFotoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string storagekey, string nomeoriginal, string contenttype, string? hasharquivo, DateTime? capturadaemutc, int? largura, int? altura, int status )
                            {
                            var entity = new FotoEntity(id, storagekey, nomeoriginal, contenttype, hasharquivo, capturadaemutc, largura, altura, status );


                            var trackingMask = _trackingPolicy?.GetMask("Foto", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new FotoDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration