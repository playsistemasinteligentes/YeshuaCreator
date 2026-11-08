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
                                public class CTeComplementoIcmsFiscalFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public CTeComplementoIcmsFiscalFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public CTeComplementoIcmsFiscalFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ICTeComplementoIcmsFiscalEntity Create(int? id, int ctesolicitacaofiscalid, Decimal valorprestacaocomplementar, string cst, Decimal valorbasecalculo, Decimal aliquotaicms, Decimal valoricms )
                            {
                                return Create(null, id, ctesolicitacaofiscalid, valorprestacaocomplementar, cst, valorbasecalculo, aliquotaicms, valoricms);
                            }

                            public ICTeComplementoIcmsFiscalEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int ctesolicitacaofiscalid, Decimal valorprestacaocomplementar, string cst, Decimal valorbasecalculo, Decimal aliquotaicms, Decimal valoricms, ulong? trackingMask = null )
                            {
                            var entity = new CTeComplementoIcmsFiscalEntity(id, ctesolicitacaofiscalid, valorprestacaocomplementar, cst, valorbasecalculo, aliquotaicms, valoricms );


                            var effectiveTrackingMask = trackingMask ??
                                _trackingPolicy?.GetMask("CTeComplementoIcmsFiscal", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new CTeComplementoIcmsFiscalDecorator(entity, _logger, context, effectiveTrackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration