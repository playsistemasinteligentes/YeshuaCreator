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
                                public class TipoVeiculoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public TipoVeiculoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public TipoVeiculoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ITipoVeiculoEntity Create(int? id, int tip_id, string tip_descricao, int? tip_qtd_disponivel, Decimal? tip_valor_km, Decimal? tip_valor_diaria, Decimal? tip_valor_ajudante, Decimal? tip_qtd_eixos, Decimal? tip_velocidade_media, Decimal? tip_capacidade_altura, Decimal? tip_capacidade_comprimento, Decimal? tip_capacidade_largura, Decimal? tip_capacidade_altura_pescoco_e, Decimal? tip_capacidade_comprimento_pescoco_e, Decimal? tip_capacidade_largura_pescoco_e, Decimal? tip_capacidade_altura_pescoco_d, Decimal? tip_capacidade_comprimento_pescoco_d, Decimal? tip_capacidade_largura_pescoco_d, Decimal? tip_capacidade_m3 )
                            {
                                return Create(null, id, tip_id, tip_descricao, tip_qtd_disponivel, tip_valor_km, tip_valor_diaria, tip_valor_ajudante, tip_qtd_eixos, tip_velocidade_media, tip_capacidade_altura, tip_capacidade_comprimento, tip_capacidade_largura, tip_capacidade_altura_pescoco_e, tip_capacidade_comprimento_pescoco_e, tip_capacidade_largura_pescoco_e, tip_capacidade_altura_pescoco_d, tip_capacidade_comprimento_pescoco_d, tip_capacidade_largura_pescoco_d, tip_capacidade_m3);
                            }

                            public ITipoVeiculoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int tip_id, string tip_descricao, int? tip_qtd_disponivel, Decimal? tip_valor_km, Decimal? tip_valor_diaria, Decimal? tip_valor_ajudante, Decimal? tip_qtd_eixos, Decimal? tip_velocidade_media, Decimal? tip_capacidade_altura, Decimal? tip_capacidade_comprimento, Decimal? tip_capacidade_largura, Decimal? tip_capacidade_altura_pescoco_e, Decimal? tip_capacidade_comprimento_pescoco_e, Decimal? tip_capacidade_largura_pescoco_e, Decimal? tip_capacidade_altura_pescoco_d, Decimal? tip_capacidade_comprimento_pescoco_d, Decimal? tip_capacidade_largura_pescoco_d, Decimal? tip_capacidade_m3 )
                            {
                            var entity = new TipoVeiculoEntity(id, tip_id, tip_descricao, tip_qtd_disponivel, tip_valor_km, tip_valor_diaria, tip_valor_ajudante, tip_qtd_eixos, tip_velocidade_media, tip_capacidade_altura, tip_capacidade_comprimento, tip_capacidade_largura, tip_capacidade_altura_pescoco_e, tip_capacidade_comprimento_pescoco_e, tip_capacidade_largura_pescoco_e, tip_capacidade_altura_pescoco_d, tip_capacidade_comprimento_pescoco_d, tip_capacidade_largura_pescoco_d, tip_capacidade_m3 );


                            var trackingMask = _trackingPolicy?.GetMask("TipoVeiculo", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new TipoVeiculoDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration