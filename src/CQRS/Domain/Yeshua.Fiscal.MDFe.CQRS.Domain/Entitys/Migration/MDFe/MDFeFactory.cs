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
                                public class MDFeFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public MDFeFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public MDFeFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IMDFeEntity Create(int? id, string chaveacesso, int serie, int numero, string ufcarregamento, string ufdescarregamento, string placaveiculo, DateTime emitidoem, DateTime? autorizadoem, DateTime? iniciadoem, DateTime? encerradoem, DateTime? canceladoem, int situacao )
                            {
                                return Create(null, id, chaveacesso, serie, numero, ufcarregamento, ufdescarregamento, placaveiculo, emitidoem, autorizadoem, iniciadoem, encerradoem, canceladoem, situacao);
                            }

                            public IMDFeEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string chaveacesso, int serie, int numero, string ufcarregamento, string ufdescarregamento, string placaveiculo, DateTime emitidoem, DateTime? autorizadoem, DateTime? iniciadoem, DateTime? encerradoem, DateTime? canceladoem, int situacao )
                            {
                            var entity = new MDFeEntity(id, chaveacesso, serie, numero, ufcarregamento, ufdescarregamento, placaveiculo, emitidoem, autorizadoem, iniciadoem, encerradoem, canceladoem, situacao );


                            var trackingMask = _trackingPolicy?.GetMask("MDFe", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new MDFeDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration