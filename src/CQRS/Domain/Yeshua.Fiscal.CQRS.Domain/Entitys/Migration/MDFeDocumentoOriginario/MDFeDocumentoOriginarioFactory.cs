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
                                public class MDFeDocumentoOriginarioFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public MDFeDocumentoOriginarioFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public MDFeDocumentoOriginarioFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IMDFeDocumentoOriginarioEntity Create(int? id, int mdfesolicitacaofiscalid, int? documentofiscaloriginarioid, string tipodocumento, string? chaveacesso, string? snapshotjson )
                            {
                                return Create(null, id, mdfesolicitacaofiscalid, documentofiscaloriginarioid, tipodocumento, chaveacesso, snapshotjson);
                            }

                            public IMDFeDocumentoOriginarioEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int mdfesolicitacaofiscalid, int? documentofiscaloriginarioid, string tipodocumento, string? chaveacesso, string? snapshotjson )
                            {
                            var entity = new MDFeDocumentoOriginarioEntity(id, mdfesolicitacaofiscalid, documentofiscaloriginarioid, tipodocumento, chaveacesso, snapshotjson );


                            var trackingMask = _trackingPolicy?.GetMask("MDFeDocumentoOriginario", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new MDFeDocumentoOriginarioDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration