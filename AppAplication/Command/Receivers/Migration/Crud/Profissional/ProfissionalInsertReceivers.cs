using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Repositorio.Inputs.Repositorio.Profissional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class InsertProfissionalReceiver : ReciverBase <ProfissionalEntity>
    {
        private readonly IProfissionalWriteRepository _repository;

        public InsertProfissionalReceiver(IProfissionalWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State<ProfissionalEntity> Action(ICommand comand)
        {
             if(comand is Command.Commands.ProfissionalCrudCommand c) 
             {    
                 var profissional = new ProfissionalEntity(c.Id, c.Nome, c.EspecialidadeId, c.Telefone);
                 if (!profissional.isValidInsert())
                     return ValidationError(profissional.getErroMensagens(), comand);

                 try
                 {
                     _repository.Insert(profissional);
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