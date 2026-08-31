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
                                public class PedidoPlanejavelFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public PedidoPlanejavelFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public PedidoPlanejavelFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IPedidoPlanejavelEntity Create(string pedidoid, string clienteid, string clientenome, string estado, string municipio, string regiao, string bairro, string rotaid, DateTime? embarquealvo, DateTime? dataentregade, DateTime? dataentregaate, Decimal? peso, Decimal? volume, Decimal? saldoaexpedir, string status, string cargaatualid, string versaoplanejamento, string alertasresumo )
                            {
                                return Create(null, pedidoid, clienteid, clientenome, estado, municipio, regiao, bairro, rotaid, embarquealvo, dataentregade, dataentregaate, peso, volume, saldoaexpedir, status, cargaatualid, versaoplanejamento, alertasresumo);
                            }

                            public IPedidoPlanejavelEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, string pedidoid, string clienteid, string clientenome, string estado, string municipio, string regiao, string bairro, string rotaid, DateTime? embarquealvo, DateTime? dataentregade, DateTime? dataentregaate, Decimal? peso, Decimal? volume, Decimal? saldoaexpedir, string status, string cargaatualid, string versaoplanejamento, string alertasresumo )
                            {
                            var entity = new PedidoPlanejavelEntity(pedidoid, clienteid, clientenome, estado, municipio, regiao, bairro, rotaid, embarquealvo, dataentregade, dataentregaate, peso, volume, saldoaexpedir, status, cargaatualid, versaoplanejamento, alertasresumo );


                            var trackingMask = _trackingPolicy?.GetMask("PedidoPlanejavel", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new PedidoPlanejavelDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration