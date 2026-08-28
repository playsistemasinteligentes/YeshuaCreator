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
                                public class MunicipioFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public MunicipioFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public MunicipioFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IMunicipioEntity Create(string mun_id, string mun_nome, string uf_cod, string mun_codigo_ibge, Decimal? mun_latitude, Decimal? mun_longitude, string mun_id_integracao_erp, string mun_codigo_siafi, string mun_codigo_cnpj, Decimal? mun_distancia_km )
                            {
                                return Create(null, mun_id, mun_nome, uf_cod, mun_codigo_ibge, mun_latitude, mun_longitude, mun_id_integracao_erp, mun_codigo_siafi, mun_codigo_cnpj, mun_distancia_km);
                            }

                            public IMunicipioEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string mun_id, string mun_nome, string uf_cod, string mun_codigo_ibge, Decimal? mun_latitude, Decimal? mun_longitude, string mun_id_integracao_erp, string mun_codigo_siafi, string mun_codigo_cnpj, Decimal? mun_distancia_km )
                            {
                            var entity = new MunicipioEntity(mun_id, mun_nome, uf_cod, mun_codigo_ibge, mun_latitude, mun_longitude, mun_id_integracao_erp, mun_codigo_siafi, mun_codigo_cnpj, mun_distancia_km );


                            var trackingMask = _trackingPolicy?.GetMask("Municipio", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new MunicipioDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration