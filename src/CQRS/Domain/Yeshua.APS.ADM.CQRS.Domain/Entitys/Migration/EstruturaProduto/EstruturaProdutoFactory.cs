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
                                public class EstruturaProdutoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public EstruturaProdutoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public EstruturaProdutoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IEstruturaProdutoEntity Create(int? id, DateTime est_data_validade, string pro_id_produto, string pro_id_componente, Decimal est_quant, DateTime est_data_inclusao, Decimal est_base_producao, string est_tipo_requisicao, string est_codigo_de_excecao )
                            {
                                return Create(null, id, est_data_validade, pro_id_produto, pro_id_componente, est_quant, est_data_inclusao, est_base_producao, est_tipo_requisicao, est_codigo_de_excecao);
                            }

                            public IEstruturaProdutoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, DateTime est_data_validade, string pro_id_produto, string pro_id_componente, Decimal est_quant, DateTime est_data_inclusao, Decimal est_base_producao, string est_tipo_requisicao, string est_codigo_de_excecao )
                            {
                            var entity = new EstruturaProdutoEntity(id, est_data_validade, pro_id_produto, pro_id_componente, est_quant, est_data_inclusao, est_base_producao, est_tipo_requisicao, est_codigo_de_excecao );


                            var trackingMask = _trackingPolicy?.GetMask("EstruturaProduto", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new EstruturaProdutoDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration