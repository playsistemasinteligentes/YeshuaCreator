using Comandos.Pateners.Command;
using Dominio.Entitys.Especialidade;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Especialidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class UpdateEspecialidadeReceiver : ReciverBase
    {
        private readonly IEspecialidadeWriteRepository _repository;

        public UpdateEspecialidadeReceiver(IEspecialidadeWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
             if(comand is Command.Commands.EspecialidadeCrudCommand c) 
             {    
                 var especialidade = new EspecialidadeEntity(c.Id, c.Descricao);
                 if (!especialidade.isValidUpdate())
                     return new State(300, especialidade.getErroMensagens(), comand);

                 try
                 {
                     _repository.Update(especialidade);
                     return new State(200, "OK", especialidade);
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