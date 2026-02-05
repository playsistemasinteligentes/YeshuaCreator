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
    public class DeleteMovimentoFinanceiroReceiver : ReciverBase <IMovimentoFinanceiroEntity>
    {
        private readonly IMovimentoFinanceiroWriteRepository _repository;
        private readonly ILogger _logger;

        public DeleteMovimentoFinanceiroReceiver(IMovimentoFinanceiroWriteRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IMovimentoFinanceiroEntity> Action(ICommand comand)
        {
             if(comand is Command.Write.MovimentoFinanceiroCrudCommand c) 
             {    
                 var movimentofinanceiro = new MovimentoFinanceiroFactory(_logger).Create(c.Id, c.IdOrigem, c.ContaDebitoId, c.ContaCreditoId, c.Valor, c.DataMovimento, c.DataVencimento, c.Status);
                 if (!movimentofinanceiro.isValidDelete())
                     return ValidationError(movimentofinanceiro.getErroMensagens(), comand);

                 try
                 {
                     _repository.Delete(movimentofinanceiro);
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