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
                                public class ClienteFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public ClienteFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public ClienteFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IClienteEntity Create(string cli_id, string cli_nome, string cli_fone, string cli_obs, string cli_endereco_entrega, string cli_cpf_cnpj, string cli_bairro_entrega, string cli_cep_entrega, string cli_email, string cli_integracao, string mun_id_entrega, Decimal? cli_translado, string cli_regiao_entrega, int? cli_exigente_na_impressao, Decimal? cli_tempo_medio_espera_de_descarregamento, Decimal? cli_tempo_descarregamento_unitario, Decimal? cli_percentual_janela_embarque, string rep_id, string cli_razao_social, string cli_email_monitoramento_transporte, string cli_contato, string cli_setor, string seg_id, string cli_tipo, string cli_integracao_erp, Decimal? cli_latitude_entrega, Decimal? cli_longitude_entrega )
                            {
                                return Create(null, cli_id, cli_nome, cli_fone, cli_obs, cli_endereco_entrega, cli_cpf_cnpj, cli_bairro_entrega, cli_cep_entrega, cli_email, cli_integracao, mun_id_entrega, cli_translado, cli_regiao_entrega, cli_exigente_na_impressao, cli_tempo_medio_espera_de_descarregamento, cli_tempo_descarregamento_unitario, cli_percentual_janela_embarque, rep_id, cli_razao_social, cli_email_monitoramento_transporte, cli_contato, cli_setor, seg_id, cli_tipo, cli_integracao_erp, cli_latitude_entrega, cli_longitude_entrega);
                            }

                            public IClienteEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string cli_id, string cli_nome, string cli_fone, string cli_obs, string cli_endereco_entrega, string cli_cpf_cnpj, string cli_bairro_entrega, string cli_cep_entrega, string cli_email, string cli_integracao, string mun_id_entrega, Decimal? cli_translado, string cli_regiao_entrega, int? cli_exigente_na_impressao, Decimal? cli_tempo_medio_espera_de_descarregamento, Decimal? cli_tempo_descarregamento_unitario, Decimal? cli_percentual_janela_embarque, string rep_id, string cli_razao_social, string cli_email_monitoramento_transporte, string cli_contato, string cli_setor, string seg_id, string cli_tipo, string cli_integracao_erp, Decimal? cli_latitude_entrega, Decimal? cli_longitude_entrega )
                            {
                            var entity = new ClienteEntity(cli_id, cli_nome, cli_fone, cli_obs, cli_endereco_entrega, cli_cpf_cnpj, cli_bairro_entrega, cli_cep_entrega, cli_email, cli_integracao, mun_id_entrega, cli_translado, cli_regiao_entrega, cli_exigente_na_impressao, cli_tempo_medio_espera_de_descarregamento, cli_tempo_descarregamento_unitario, cli_percentual_janela_embarque, rep_id, cli_razao_social, cli_email_monitoramento_transporte, cli_contato, cli_setor, seg_id, cli_tipo, cli_integracao_erp, cli_latitude_entrega, cli_longitude_entrega );


                            var trackingMask = _trackingPolicy?.GetMask("Cliente", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new ClienteDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration