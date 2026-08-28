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
                                public class BoletimEstudoFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public BoletimEstudoFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public BoletimEstudoFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IBoletimEstudoEntity Create(int? id, string bol_id, string bol_id_origem, string bol_solver, string bol_integracao, Decimal? bol_sequencia, Decimal grp_pap_gramatura_programado, string grp_id_programado, string grp_papel1_programado, string grp_papel2_programado, string grp_papel3_programado, string grp_papel4_programado, string grp_papel5_programado, string bol_status_interface, string bol_tipo, int? bol_formato, Decimal? bol_gramatura_papeis_programados, Decimal? bol_gramatura_papeis_realizado, Decimal? bol_custo_papeis_programados, Decimal? bol_custo_papeis_realizado, Decimal? bol_gramatura_resina_programados, Decimal? bol_custo_resina_programados, int? bol_refile_obrigatorio )
                            {
                                return Create(null, id, bol_id, bol_id_origem, bol_solver, bol_integracao, bol_sequencia, grp_pap_gramatura_programado, grp_id_programado, grp_papel1_programado, grp_papel2_programado, grp_papel3_programado, grp_papel4_programado, grp_papel5_programado, bol_status_interface, bol_tipo, bol_formato, bol_gramatura_papeis_programados, bol_gramatura_papeis_realizado, bol_custo_papeis_programados, bol_custo_papeis_realizado, bol_gramatura_resina_programados, bol_custo_resina_programados, bol_refile_obrigatorio);
                            }

                            public IBoletimEstudoEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, string bol_id, string bol_id_origem, string bol_solver, string bol_integracao, Decimal? bol_sequencia, Decimal grp_pap_gramatura_programado, string grp_id_programado, string grp_papel1_programado, string grp_papel2_programado, string grp_papel3_programado, string grp_papel4_programado, string grp_papel5_programado, string bol_status_interface, string bol_tipo, int? bol_formato, Decimal? bol_gramatura_papeis_programados, Decimal? bol_gramatura_papeis_realizado, Decimal? bol_custo_papeis_programados, Decimal? bol_custo_papeis_realizado, Decimal? bol_gramatura_resina_programados, Decimal? bol_custo_resina_programados, int? bol_refile_obrigatorio )
                            {
                            var entity = new BoletimEstudoEntity(id, bol_id, bol_id_origem, bol_solver, bol_integracao, bol_sequencia, grp_pap_gramatura_programado, grp_id_programado, grp_papel1_programado, grp_papel2_programado, grp_papel3_programado, grp_papel4_programado, grp_papel5_programado, bol_status_interface, bol_tipo, bol_formato, bol_gramatura_papeis_programados, bol_gramatura_papeis_realizado, bol_custo_papeis_programados, bol_custo_papeis_realizado, bol_gramatura_resina_programados, bol_custo_resina_programados, bol_refile_obrigatorio );


                            var trackingMask = _trackingPolicy?.GetMask("BoletimEstudo", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new BoletimEstudoDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration