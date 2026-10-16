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
                                public class CanalStandardFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public CanalStandardFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public CanalStandardFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ICanalStandardEntity Create(int? id, string canalid, string conexaoyoutubeid, int credencialtenantid, bool ativo, long totalreservas, DateTime? ultimareservaemutc )
                            {
                                return Create(null, id, canalid, conexaoyoutubeid, credencialtenantid, ativo, totalreservas, ultimareservaemutc);
                            }

                            public ICanalStandardEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string canalid, string conexaoyoutubeid, int credencialtenantid, bool ativo, long totalreservas, DateTime? ultimareservaemutc, ulong? trackingMask = null )
                            {
                            var entity = new CanalStandardEntity(id, canalid, conexaoyoutubeid, credencialtenantid, ativo, totalreservas, ultimareservaemutc );


                            var effectiveTrackingMask = trackingMask ??
                                _trackingPolicy?.GetMask("CanalStandard", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new CanalStandardDecorator(entity, _logger, context, effectiveTrackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration