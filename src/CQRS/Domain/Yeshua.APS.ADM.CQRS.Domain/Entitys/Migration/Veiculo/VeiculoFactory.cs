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
                                public class VeiculoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public VeiculoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public VeiculoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IVeiculoEntity Create(int? id, string vei_placa, string vei_uf, int tip_id, Decimal? vei_capacidade_m3, Decimal? vei_capacidade_largura, Decimal? vei_capacidade_comprimento, Decimal? vei_capacidade_altura, string vei_modelo, string vei_nome_motorista, string vei_dados_contato, string vei_cpf_motorista, string tca_id, DateTime? vei_emissao, DateTime? vei_vencimento, string vei_status )
                            {
                                return Create(null, id, vei_placa, vei_uf, tip_id, vei_capacidade_m3, vei_capacidade_largura, vei_capacidade_comprimento, vei_capacidade_altura, vei_modelo, vei_nome_motorista, vei_dados_contato, vei_cpf_motorista, tca_id, vei_emissao, vei_vencimento, vei_status);
                            }

                            public IVeiculoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string vei_placa, string vei_uf, int tip_id, Decimal? vei_capacidade_m3, Decimal? vei_capacidade_largura, Decimal? vei_capacidade_comprimento, Decimal? vei_capacidade_altura, string vei_modelo, string vei_nome_motorista, string vei_dados_contato, string vei_cpf_motorista, string tca_id, DateTime? vei_emissao, DateTime? vei_vencimento, string vei_status )
                            {
                            var entity = new VeiculoEntity(id, vei_placa, vei_uf, tip_id, vei_capacidade_m3, vei_capacidade_largura, vei_capacidade_comprimento, vei_capacidade_altura, vei_modelo, vei_nome_motorista, vei_dados_contato, vei_cpf_motorista, tca_id, vei_emissao, vei_vencimento, vei_status );


                            var trackingMask = _trackingPolicy?.GetMask("Veiculo", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new VeiculoDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration