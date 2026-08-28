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
                                public class OperacoesFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public OperacoesFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public OperacoesFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IOperacoesEntity Create(int? id, string ope_tipo_registro, string ope_id, string gma_id, string maq_id, string pro_id, string ope_excecao, int rot_seq_tranformacao, string ord_id, int fpr_seq_repeticao )
                            {
                                return Create(null, id, ope_tipo_registro, ope_id, gma_id, maq_id, pro_id, ope_excecao, rot_seq_tranformacao, ord_id, fpr_seq_repeticao);
                            }

                            public IOperacoesEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string ope_tipo_registro, string ope_id, string gma_id, string maq_id, string pro_id, string ope_excecao, int rot_seq_tranformacao, string ord_id, int fpr_seq_repeticao )
                            {
                            var entity = new OperacoesEntity(id, ope_tipo_registro, ope_id, gma_id, maq_id, pro_id, ope_excecao, rot_seq_tranformacao, ord_id, fpr_seq_repeticao );


                            var trackingMask = _trackingPolicy?.GetMask("Operacoes", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new OperacoesDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration