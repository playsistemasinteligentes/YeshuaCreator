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
                                public class RelatoriosFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public RelatoriosFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public RelatoriosFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IRelatoriosEntity Create(int rel_id, string rel_nome_relatorio, string rel_nome_campo, string rel_tipo_campo, int? rel_pos_x, int? rel_pos_y, int? rel_tamanho_fonte )
                            {
                                return Create(null, rel_id, rel_nome_relatorio, rel_nome_campo, rel_tipo_campo, rel_pos_x, rel_pos_y, rel_tamanho_fonte);
                            }

                            public IRelatoriosEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int rel_id, string rel_nome_relatorio, string rel_nome_campo, string rel_tipo_campo, int? rel_pos_x, int? rel_pos_y, int? rel_tamanho_fonte )
                            {
                            var entity = new RelatoriosEntity(rel_id, rel_nome_relatorio, rel_nome_campo, rel_tipo_campo, rel_pos_x, rel_pos_y, rel_tamanho_fonte );


                            var trackingMask = _trackingPolicy?.GetMask("Relatorios", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new RelatoriosDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration