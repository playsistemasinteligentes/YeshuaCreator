using Comandos.Pateners.Command;
using Dominio.Entitys.Servico;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class UpdateServicoReceiver : ReciverBase
    {
        private readonly IServicoWriteRepository _repository;

        public UpdateServicoReceiver(IServicoWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
             if(comand is Command.Commands.ServicoCrudCommand c) 
             {    
                 var servico = new ServicoEntity(c.Id, c.GrupoServicoId, c.Nome, c.Valor);
                 if (!servico.isValidUpdate())
                     return ValidationError(servico.getErroMensagens(), comand);

                 try
                 {
                     _repository.Update(servico);
                     return Success("OK", servico);
                 }
                 catch (Exception e)
                 {
                     return Error(e, comand);
                 }
            }
            else 
            {
                 return Error("ErroConversao", comand);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration