

                            namespace Dominio.Entitys
                            {
                                public class MovimentoFinanceiroFactory
                                {
                                    private readonly Dominio.Interfaces.ILogger _logger;

                                    public MovimentoFinanceiroFactory(Dominio.Interfaces.ILogger logger)
                                    {
                                        _logger = logger;
                                    } public IMovimentoFinanceiroEntity Create(int? id, string idorigem, int contadebitoid, Decimal valor, DateTime datamovimento, DateTime? datavencimento, int status )
                            {
                            var entity = new MovimentoFinanceiroEntity(id, idorigem, contadebitoid, valor, datamovimento, datavencimento, status );


                            var decoratedEntity = new MovimentoFinanceiroDecorator(entity, _logger);
                            return decoratedEntity;
                                    }
                                }
                            }
//Dominio.Schemas.CQRS.SourceCodeEntityMigration