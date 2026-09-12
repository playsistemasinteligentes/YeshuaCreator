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
                                public class CTeParticipanteSnapshotFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public CTeParticipanteSnapshotFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public CTeParticipanteSnapshotFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ICTeParticipanteSnapshotEntity Create(int? id, int ctesolicitacaofiscalid, string papel, string documento, string? nome, string? inscricaoestadual, string? uf, string? municipiocodigoibge, string? enderecojson )
                            {
                                return Create(null, id, ctesolicitacaofiscalid, papel, documento, nome, inscricaoestadual, uf, municipiocodigoibge, enderecojson);
                            }

                            public ICTeParticipanteSnapshotEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int ctesolicitacaofiscalid, string papel, string documento, string? nome, string? inscricaoestadual, string? uf, string? municipiocodigoibge, string? enderecojson )
                            {
                            var entity = new CTeParticipanteSnapshotEntity(id, ctesolicitacaofiscalid, papel, documento, nome, inscricaoestadual, uf, municipiocodigoibge, enderecojson );


                            var trackingMask = _trackingPolicy?.GetMask("CTeParticipanteSnapshot", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new CTeParticipanteSnapshotDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration