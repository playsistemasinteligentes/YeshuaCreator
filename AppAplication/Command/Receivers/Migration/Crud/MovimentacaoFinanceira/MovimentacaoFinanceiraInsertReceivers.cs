using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Inputs.Repositorio.MovimentacaoFinanceira;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class InsertMovimentacaoFinanceiraReceiver : ReciverBase <IMovimentacaoFinanceiraEntity>
    {
        private readonly IMovimentacaoFinanceiraWriteRepository _repository;
        private readonly ILogger _logger;

        public InsertMovimentacaoFinanceiraReceiver(IMovimentacaoFinanceiraWriteRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IMovimentacaoFinanceiraEntity> Action(ICommand comand)
        {
             if(comand is Command.Commands.MovimentacaoFinanceiraCrudCommand c) 
             {    
                 var movimentacaofinanceira = new MovimentacaoFinanceiraFactory(_logger).Create(c.Id, c.PacienteId, c.ServicoId, c.Valor, c.TipoMovimentacao, c.DataMovimentacao, c.SaldoAtual);
                 if (!movimentacaofinanceira.isValidInsert())
                     return ValidationError(movimentacaofinanceira.getErroMensagens(), comand);

                 try
                 {
                     _repository.Insert(movimentacaofinanceira);
                     return Success("OK", movimentacaofinanceira);
                 }
                 catch (Exception e)
                 {
                    return Error(e, movimentacaofinanceira);
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