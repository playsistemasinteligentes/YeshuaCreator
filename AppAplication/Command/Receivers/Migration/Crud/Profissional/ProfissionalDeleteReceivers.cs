using Comandos.Pateners.Command;
using Dominio.Entitys;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Profissional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class DeleteProfissionalReceiver : ReciverBase <ProfissionalEntity>
    {
        private readonly IProfissionalWriteRepository _repository;

        public DeleteProfissionalReceiver(IProfissionalWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State<ProfissionalEntity> Action(ICommand comand)
        {
             if(comand is Command.Commands.ProfissionalCrudCommand c) 
             {    
                 var profissional = new ProfissionalEntity(c.Id, c.Nome, c.EspecialidadeId, c.Telefone);
                 if (!profissional.isValidDelete())
                     return ValidationError(profissional.getErroMensagens(), comand);

                 try
                 {
                     _repository.Delete(profissional);
                     return Success("OK", profissional);
                 }
                 catch (Exception e)
                 {
                    return Error(e, profissional);
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