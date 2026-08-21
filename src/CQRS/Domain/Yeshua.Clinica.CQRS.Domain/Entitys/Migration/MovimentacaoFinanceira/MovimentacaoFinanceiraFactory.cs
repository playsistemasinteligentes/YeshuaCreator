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
                                public class MovimentacaoFinanceiraFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public MovimentacaoFinanceiraFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IMovimentacaoFinanceiraEntity Create(int? id, int? pacienteid, int? servicoid, Decimal valor, int tipomovimentacao, DateTime datamovimentacao, Decimal saldoatual )
                            {
                            var entity = new MovimentacaoFinanceiraEntity(id, pacienteid, servicoid, valor, tipomovimentacao, datamovimentacao, saldoatual );


                            var decoratedEntity = new MovimentacaoFinanceiraDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration