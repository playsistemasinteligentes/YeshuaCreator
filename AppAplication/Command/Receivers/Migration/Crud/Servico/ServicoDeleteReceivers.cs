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
    public class DeleteServicoReceiver : ReciverBase
    {
        private readonly IServicoWriteRepository _repository;

        public DeleteServicoReceiver(IServicoWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
             if(comand is Command.Commands.ServicoCrudCommand c) 
             {    
                 var servico = new ServicoEntity(c.Id, c.GrupoServicoId, c.Nome, c.Valor);
                 if (!servico.isValidDelete())
                     return new State(300, servico.getErroMensagens(), comand);

                 try
                 {
                     _repository.Delete(servico);
                     return new State(200, "OK", servico);
                 }
                 catch (Exception e)
                 {
                     return new State(500, e, comand);
                 }
            }
            else 
            {
                 return new State(500, "ErroConversao", comand);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration