using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Write;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class InsertMovimentoFinanceiroReceiver : ReciverBase<ICommand, IMovimentoFinanceiroEntity>
    {
        private readonly IMovimentoFinanceiroWriteRepository _repository;
        private readonly ILogger _logger;

        public InsertMovimentoFinanceiroReceiver(
            IMovimentoFinanceiroWriteRepository repository,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IMovimentoFinanceiroEntity> Action(ICommand comand)
        {
             if(comand is Command.Write.MovimentoFinanceiroCrudCommand c) 
             {    
                 var movimentofinanceiro = new MovimentoFinanceiroFactory(_logger).Create(c.Id, c.IdOrigem, c.ContaDebitoId, c.Valor, c.DataMovimento, c.DataVencimento, c.Status);
                 if (!movimentofinanceiro.isValidInsert())
                     return ValidationError(movimentofinanceiro.getErroMensagens(), null);

                 try
                 {
                     _repository.Insert(movimentofinanceiro);
                     return Success("OK", movimentofinanceiro);
                 }
                 catch (Exception e)
                 {
                    return Error(e, movimentofinanceiro);
                 }
            }
            else 
            {
                 return Error("ErroConversao", default);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration