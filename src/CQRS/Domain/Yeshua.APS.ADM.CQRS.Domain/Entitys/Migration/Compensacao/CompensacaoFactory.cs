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
                                public class CompensacaoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public CompensacaoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public CompensacaoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public ICompensacaoEntity Create(int? id, int com_id, string grp_id, string ond_id, int? com_vinco1_ond, int? com_vinco2_ond, int? com_vinco3_ond, int? com_vinco4_ond, int? com_vinco5_ond, int? com_vinco6_ond, int? com_vinco7_ond, int? com_vinco8_ond, int? com_vinco9_ond, int? com_vinco10_ond, int? com_vinco1_conversao, int? com_vinco2_conversao, int? com_vinco3_conversao, int? com_vinco4_conversao, int? com_vinco5_conversao, int? com_vinco6_conversao, int? com_vinco7_conversao, int? com_vinco8_conversao, int? com_vinco9_conversao, int? com_vinco10_conversao )
                            {
                                return Create(null, id, com_id, grp_id, ond_id, com_vinco1_ond, com_vinco2_ond, com_vinco3_ond, com_vinco4_ond, com_vinco5_ond, com_vinco6_ond, com_vinco7_ond, com_vinco8_ond, com_vinco9_ond, com_vinco10_ond, com_vinco1_conversao, com_vinco2_conversao, com_vinco3_conversao, com_vinco4_conversao, com_vinco5_conversao, com_vinco6_conversao, com_vinco7_conversao, com_vinco8_conversao, com_vinco9_conversao, com_vinco10_conversao);
                            }

                            public ICompensacaoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int com_id, string grp_id, string ond_id, int? com_vinco1_ond, int? com_vinco2_ond, int? com_vinco3_ond, int? com_vinco4_ond, int? com_vinco5_ond, int? com_vinco6_ond, int? com_vinco7_ond, int? com_vinco8_ond, int? com_vinco9_ond, int? com_vinco10_ond, int? com_vinco1_conversao, int? com_vinco2_conversao, int? com_vinco3_conversao, int? com_vinco4_conversao, int? com_vinco5_conversao, int? com_vinco6_conversao, int? com_vinco7_conversao, int? com_vinco8_conversao, int? com_vinco9_conversao, int? com_vinco10_conversao )
                            {
                            var entity = new CompensacaoEntity(id, com_id, grp_id, ond_id, com_vinco1_ond, com_vinco2_ond, com_vinco3_ond, com_vinco4_ond, com_vinco5_ond, com_vinco6_ond, com_vinco7_ond, com_vinco8_ond, com_vinco9_ond, com_vinco10_ond, com_vinco1_conversao, com_vinco2_conversao, com_vinco3_conversao, com_vinco4_conversao, com_vinco5_conversao, com_vinco6_conversao, com_vinco7_conversao, com_vinco8_conversao, com_vinco9_conversao, com_vinco10_conversao );


                            var trackingMask = _trackingPolicy?.GetMask("Compensacao", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new CompensacaoDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration