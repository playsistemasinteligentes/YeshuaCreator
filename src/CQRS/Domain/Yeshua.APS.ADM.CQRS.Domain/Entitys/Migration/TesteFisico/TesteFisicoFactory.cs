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
                                public class TesteFisicoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public TesteFisicoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public TesteFisicoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ITesteFisicoEntity Create(int? id, int tes_id, int? ite_id, int? usr_id, string tes_nome_tecnico, int? tes_amostra, string tes_op, Decimal? tes_valor_numerico, DateTime? tes_valor_data, string tes_valor_texto, DateTime? tes_emissao, string ord_id, string pro_id, string maq_id, int? fpr_seq_repeticao, int? fpr_seq_tranformacao )
                            {
                                return Create(null, id, tes_id, ite_id, usr_id, tes_nome_tecnico, tes_amostra, tes_op, tes_valor_numerico, tes_valor_data, tes_valor_texto, tes_emissao, ord_id, pro_id, maq_id, fpr_seq_repeticao, fpr_seq_tranformacao);
                            }

                            public ITesteFisicoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int tes_id, int? ite_id, int? usr_id, string tes_nome_tecnico, int? tes_amostra, string tes_op, Decimal? tes_valor_numerico, DateTime? tes_valor_data, string tes_valor_texto, DateTime? tes_emissao, string ord_id, string pro_id, string maq_id, int? fpr_seq_repeticao, int? fpr_seq_tranformacao )
                            {
                            var entity = new TesteFisicoEntity(id, tes_id, ite_id, usr_id, tes_nome_tecnico, tes_amostra, tes_op, tes_valor_numerico, tes_valor_data, tes_valor_texto, tes_emissao, ord_id, pro_id, maq_id, fpr_seq_repeticao, fpr_seq_tranformacao );


                            var trackingMask = _trackingPolicy?.GetMask("TesteFisico", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new TesteFisicoDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration