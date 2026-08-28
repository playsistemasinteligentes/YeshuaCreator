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
                                public class ClpMedicoesFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public ClpMedicoesFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public ClpMedicoesFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IClpMedicoesEntity Create(int? id, int id2, string maquinaid, DateTime datainicio, DateTime datafim, DateTime? emissao, Decimal quantidade, Decimal? grupo, int? status, string turnoid, string turmaid, int idloteclp, string ocorrenciaid, int? fase, string clporigem, int? clp_lote, int? compacta, string bol_id, int? cor_sequencia )
                            {
                                return Create(null, id, id2, maquinaid, datainicio, datafim, emissao, quantidade, grupo, status, turnoid, turmaid, idloteclp, ocorrenciaid, fase, clporigem, clp_lote, compacta, bol_id, cor_sequencia);
                            }

                            public IClpMedicoesEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int id2, string maquinaid, DateTime datainicio, DateTime datafim, DateTime? emissao, Decimal quantidade, Decimal? grupo, int? status, string turnoid, string turmaid, int idloteclp, string ocorrenciaid, int? fase, string clporigem, int? clp_lote, int? compacta, string bol_id, int? cor_sequencia )
                            {
                            var entity = new ClpMedicoesEntity(id, id2, maquinaid, datainicio, datafim, emissao, quantidade, grupo, status, turnoid, turmaid, idloteclp, ocorrenciaid, fase, clporigem, clp_lote, compacta, bol_id, cor_sequencia );


                            var trackingMask = _trackingPolicy?.GetMask("ClpMedicoes", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new ClpMedicoesDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration