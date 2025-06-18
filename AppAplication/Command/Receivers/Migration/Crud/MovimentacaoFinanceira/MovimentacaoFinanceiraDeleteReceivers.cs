using Comandos.Pateners.Command;
using Dominio.Entitys;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.MovimentacaoFinanceira;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class DeleteMovimentacaoFinanceiraReceiver : ReciverBase <MovimentacaoFinanceiraEntity>
    {
        private readonly IMovimentacaoFinanceiraWriteRepository _repository;

        public DeleteMovimentacaoFinanceiraReceiver(IMovimentacaoFinanceiraWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State<MovimentacaoFinanceiraEntity> Action(ICommand comand)
        {
             if(comand is Command.Commands.MovimentacaoFinanceiraCrudCommand c) 
             {    
                 var movimentacaofinanceira = new MovimentacaoFinanceiraEntity(c.Id, c.PacienteId, c.ServicoId, c.Valor, c.TipoMovimentacao, c.DataMovimentacao, c.SaldoAtual);
                 if (!movimentacaofinanceira.isValidDelete())
                     return ValidationError(movimentacaofinanceira.getErroMensagens(), comand);

                 try
                 {
                     _repository.Delete(movimentacaofinanceira);
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