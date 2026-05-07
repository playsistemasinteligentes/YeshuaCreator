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
    public class UpdateProfissionalReceiver : ReciverBase<ICommand, IProfissionalEntity>
    {
        private readonly IProfissionalWriteRepository _repository;
        private readonly ILogger _logger;

        public UpdateProfissionalReceiver(
            IProfissionalWriteRepository repository,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IProfissionalEntity> Action(ICommand comand)
        {
             if(comand is Command.Write.ProfissionalCrudCommand c) 
             {    
                 var profissional = new ProfissionalFactory(_logger).Create(c.Id, c.Nome, c.EspecialidadeId, c.Telefone);
                 if (!profissional.isValidUpdate())
                     return ValidationError(profissional.getErroMensagens(), null);

                 try
                 {
                     _repository.Update(profissional);
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