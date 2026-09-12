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
                                public class MDFeVeiculoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public MDFeVeiculoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public MDFeVeiculoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IMDFeVeiculoEntity Create(int? id, int mdfesolicitacaofiscalid, string placa, string? renavam, Decimal? tara, Decimal? capacidadekg, Decimal? capacidadem3 )
                            {
                                return Create(null, id, mdfesolicitacaofiscalid, placa, renavam, tara, capacidadekg, capacidadem3);
                            }

                            public IMDFeVeiculoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int mdfesolicitacaofiscalid, string placa, string? renavam, Decimal? tara, Decimal? capacidadekg, Decimal? capacidadem3 )
                            {
                            var entity = new MDFeVeiculoEntity(id, mdfesolicitacaofiscalid, placa, renavam, tara, capacidadekg, capacidadem3 );


                            var trackingMask = _trackingPolicy?.GetMask("MDFeVeiculo", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new MDFeVeiculoDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration