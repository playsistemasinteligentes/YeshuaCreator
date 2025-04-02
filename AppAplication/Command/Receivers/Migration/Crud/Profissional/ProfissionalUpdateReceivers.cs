using Comandos.Pateners.Command;
using Dominio.Entitys.Profissional;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Profissional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class UpdateProfissionalReceiver : ReciverBase
    {
        private readonly IProfissionalWriteRepository _repository;

        public UpdateProfissionalReceiver(IProfissionalWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
             if(comand is Command.Commands.ProfissionalCrudCommand c) 
             {    
                 var profissional = new ProfissionalEntity(c.Id, c.Nome, c.EspecialidadeId, c.Telefone);
                 if (!profissional.isValidUpdate())
                     return new State(300, profissional.getErroMensagens(), comand);

                 try
                 {
                     _repository.Update(profissional);
                     return new State(200, "OK", profissional);
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