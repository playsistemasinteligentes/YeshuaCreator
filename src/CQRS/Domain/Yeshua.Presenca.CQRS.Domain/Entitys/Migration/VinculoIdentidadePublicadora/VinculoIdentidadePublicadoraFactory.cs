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
                                public class VinculoIdentidadePublicadoraFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public VinculoIdentidadePublicadoraFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public VinculoIdentidadePublicadoraFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IVinculoIdentidadePublicadoraEntity Create(string? id, string? identidadeid, int? usuarioid, int? permissoes, int? versao )
                            {
                                return Create(null, id, identidadeid, usuarioid, permissoes, versao);
                            }

                            public IVinculoIdentidadePublicadoraEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string? id, string? identidadeid, int? usuarioid, int? permissoes, int? versao, ulong? trackingMask = null )
                            {
                            var entity = new VinculoIdentidadePublicadoraEntity(id, identidadeid, usuarioid, permissoes, versao );


                            var effectiveTrackingMask = trackingMask ??
                                _trackingPolicy?.GetMask("VinculoIdentidadePublicadora", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new VinculoIdentidadePublicadoraDecorator(entity, _logger, context, effectiveTrackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration