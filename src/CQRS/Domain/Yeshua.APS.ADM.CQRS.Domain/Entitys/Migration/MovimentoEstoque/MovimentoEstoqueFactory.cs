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
                                public class MovimentoEstoqueFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public MovimentoEstoqueFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public MovimentoEstoqueFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IMovimentoEstoqueEntity Create(int id, string produtoid, string orderid, string tipo, string turnoid, string turmaid, Decimal quantidade, Decimal mov_peso_unitario, DateTime datahoracriacao, DateTime? datahoraemissao, string diaturma, string lote, string sublote, string maquinaid, int? use_id, string observacao, string ocorrenciaid, string armazem, string endereco, string estorno, int? sequenciatransformacao, int? sequenciarepeticao, string obsopparcial, string ocoidopparcial, string mov_id_integracao, string mov_id_integracao_erp, string car_id, int? mov_id_destino, string pro_id_destino, string mov_lote_destino, string mov_sub_lote_destino, int? mov_id_origem, string pro_id_origem, string mov_lote_origem, string mov_sub_lote_origem, int? mov_type, string mov_doc, string mov_aproveitamento, string mov_retido, string mov_vincos_onduladeira, string bol_id, string ord_id_origem, int? cor_sequencia, int? ver_id, string mov_tipo_custo, string mov_grupo_contabil, string for_id, string cli_id )
                            {
                                return Create(null, id, produtoid, orderid, tipo, turnoid, turmaid, quantidade, mov_peso_unitario, datahoracriacao, datahoraemissao, diaturma, lote, sublote, maquinaid, use_id, observacao, ocorrenciaid, armazem, endereco, estorno, sequenciatransformacao, sequenciarepeticao, obsopparcial, ocoidopparcial, mov_id_integracao, mov_id_integracao_erp, car_id, mov_id_destino, pro_id_destino, mov_lote_destino, mov_sub_lote_destino, mov_id_origem, pro_id_origem, mov_lote_origem, mov_sub_lote_origem, mov_type, mov_doc, mov_aproveitamento, mov_retido, mov_vincos_onduladeira, bol_id, ord_id_origem, cor_sequencia, ver_id, mov_tipo_custo, mov_grupo_contabil, for_id, cli_id);
                            }

                            public IMovimentoEstoqueEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int id, string produtoid, string orderid, string tipo, string turnoid, string turmaid, Decimal quantidade, Decimal mov_peso_unitario, DateTime datahoracriacao, DateTime? datahoraemissao, string diaturma, string lote, string sublote, string maquinaid, int? use_id, string observacao, string ocorrenciaid, string armazem, string endereco, string estorno, int? sequenciatransformacao, int? sequenciarepeticao, string obsopparcial, string ocoidopparcial, string mov_id_integracao, string mov_id_integracao_erp, string car_id, int? mov_id_destino, string pro_id_destino, string mov_lote_destino, string mov_sub_lote_destino, int? mov_id_origem, string pro_id_origem, string mov_lote_origem, string mov_sub_lote_origem, int? mov_type, string mov_doc, string mov_aproveitamento, string mov_retido, string mov_vincos_onduladeira, string bol_id, string ord_id_origem, int? cor_sequencia, int? ver_id, string mov_tipo_custo, string mov_grupo_contabil, string for_id, string cli_id )
                            {
                            var entity = new MovimentoEstoqueEntity(id, produtoid, orderid, tipo, turnoid, turmaid, quantidade, mov_peso_unitario, datahoracriacao, datahoraemissao, diaturma, lote, sublote, maquinaid, use_id, observacao, ocorrenciaid, armazem, endereco, estorno, sequenciatransformacao, sequenciarepeticao, obsopparcial, ocoidopparcial, mov_id_integracao, mov_id_integracao_erp, car_id, mov_id_destino, pro_id_destino, mov_lote_destino, mov_sub_lote_destino, mov_id_origem, pro_id_origem, mov_lote_origem, mov_sub_lote_origem, mov_type, mov_doc, mov_aproveitamento, mov_retido, mov_vincos_onduladeira, bol_id, ord_id_origem, cor_sequencia, ver_id, mov_tipo_custo, mov_grupo_contabil, for_id, cli_id );


                            var trackingMask = _trackingPolicy?.GetMask("MovimentoEstoque", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new MovimentoEstoqueDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration