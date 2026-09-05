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
                                public class MDFeEncerramentoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public MDFeEncerramentoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public MDFeEncerramentoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IMDFeEncerramentoEntity Create(int? id, int mdfeid, string chaveacesso, string ufcarregamento, string ufdescarregamento, string placaveiculo, DateTime solicitadoem, DateTime? autorizadoem, string protocolo, string codigoretorno, string mensagemretorno )
                            {
                                return Create(null, id, mdfeid, chaveacesso, ufcarregamento, ufdescarregamento, placaveiculo, solicitadoem, autorizadoem, protocolo, codigoretorno, mensagemretorno);
                            }

                            public IMDFeEncerramentoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int mdfeid, string chaveacesso, string ufcarregamento, string ufdescarregamento, string placaveiculo, DateTime solicitadoem, DateTime? autorizadoem, string protocolo, string codigoretorno, string mensagemretorno )
                            {
                            var entity = new MDFeEncerramentoEntity(id, mdfeid, chaveacesso, ufcarregamento, ufdescarregamento, placaveiculo, solicitadoem, autorizadoem, protocolo, codigoretorno, mensagemretorno );


                            var trackingMask = _trackingPolicy?.GetMask("MDFeEncerramento", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new MDFeEncerramentoDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration