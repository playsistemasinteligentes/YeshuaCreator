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
                                public class yFileUploadFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public yFileUploadFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public yFileUploadFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IyFileUploadEntity Create(int? id, string type, int status, string? filepath, long? filesize, string? entitytype, string? entityid, DateTime createdat, DateTime? completedat )
                            {
                                return Create(null, id, type, status, filepath, filesize, entitytype, entityid, createdat, completedat);
                            }

                            public IyFileUploadEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string type, int status, string? filepath, long? filesize, string? entitytype, string? entityid, DateTime createdat, DateTime? completedat )
                            {
                            var entity = new yFileUploadEntity(id, type, status, filepath, filesize, entitytype, entityid, createdat, completedat );


                            var trackingMask = _trackingPolicy?.GetMask("yFileUpload", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new yFileUploadDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration