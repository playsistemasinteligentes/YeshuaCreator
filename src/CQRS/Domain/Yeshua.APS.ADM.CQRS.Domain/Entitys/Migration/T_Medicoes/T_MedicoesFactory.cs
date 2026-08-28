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
                                public class T_MedicoesFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;
                                    private readonly Dominio.Interfaces.IDomainTrackingPolicy? _trackingPolicy;

                                    public T_MedicoesFactory(Dominio.Interfaces.ILogger logger)
                                        : this(logger, null)
                                    {
                                    }

                                    public T_MedicoesFactory(
                                        Dominio.Interfaces.ILogger logger,
                                        Dominio.Interfaces.IDomainTrackingPolicy? trackingPolicy)
                                    {
                                        _logger = logger;
                                        _trackingPolicy = trackingPolicy;
                                    } public IT_MedicoesEntity Create(int? id, int med_id, int? ind_id, int? met_id, int? uni_id, DateTime med_data, string med_valor, string med_ac_ano, string med_datamedicao, Decimal? med_ponderacao, string dim_id, string dim_descricao, string dim_subdimensao_id, string dim_sub_descricao, string per_id, string per_descricao, string fat_id, string fat_descricao, string med_sql, string dom_empresa, string dom_filial, string med_valor_disper )
                            {
                                return Create(null, id, med_id, ind_id, met_id, uni_id, med_data, med_valor, med_ac_ano, med_datamedicao, med_ponderacao, dim_id, dim_descricao, dim_subdimensao_id, dim_sub_descricao, per_id, per_descricao, fat_id, fat_descricao, med_sql, dom_empresa, dom_filial, med_valor_disper);
                            }

                            public IT_MedicoesEntity Create(
                                Dominio.Patterns.Domain.DomainOperationContext? context, int? id, int med_id, int? ind_id, int? met_id, int? uni_id, DateTime med_data, string med_valor, string med_ac_ano, string med_datamedicao, Decimal? med_ponderacao, string dim_id, string dim_descricao, string dim_subdimensao_id, string dim_sub_descricao, string per_id, string per_descricao, string fat_id, string fat_descricao, string med_sql, string dom_empresa, string dom_filial, string med_valor_disper )
                            {
                            var entity = new T_MedicoesEntity(id, med_id, ind_id, met_id, uni_id, med_data, med_valor, med_ac_ano, med_datamedicao, med_ponderacao, dim_id, dim_descricao, dim_subdimensao_id, dim_sub_descricao, per_id, per_descricao, fat_id, fat_descricao, med_sql, dom_empresa, dom_filial, med_valor_disper );


                            var trackingMask = _trackingPolicy?.GetMask("T_Medicoes", context?.Intent, context?.RecordId) ?? 0UL;
                            var decoratedEntity = new T_MedicoesDecorator(entity, _logger, context, trackingMask);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration