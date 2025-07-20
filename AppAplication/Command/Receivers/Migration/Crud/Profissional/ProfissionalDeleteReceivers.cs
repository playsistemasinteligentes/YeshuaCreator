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
    public class DeleteProfissionalReceiver : ReciverBase <IProfissionalEntity>
    {
        private readonly IProfissionalWriteRepository _repository;
        private readonly ILogger _logger;

        public DeleteProfissionalReceiver(IProfissionalWriteRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IProfissionalEntity> Action(ICommand comand)
        {
             if(comand is Command.Write.ProfissionalCrudCommand c) 
             {    
                 var profissional = new ProfissionalFactory(_logger).Create(c.Id, c.Nome, c.EspecialidadeId, c.Telefone);
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