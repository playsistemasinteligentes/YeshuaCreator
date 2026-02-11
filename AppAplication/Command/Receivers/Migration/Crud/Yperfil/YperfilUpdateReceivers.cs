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
    public class UpdateyPerfilReceiver : ReciverBase<ICommand, IyPerfilEntity>
    {
        private readonly IyPerfilWriteRepository _repository;
        private readonly ILogger _logger;

        public UpdateyPerfilReceiver(IyPerfilWriteRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IyPerfilEntity> Action(ICommand comand)
        {
             if(comand is Command.Write.yPerfilCrudCommand c) 
             {    
                 var yperfil = new yPerfilFactory(_logger).Create(c.Id, c.Description);
                 if (!yperfil.isValidUpdate())
                     return ValidationError(yperfil.getErroMensagens(), null);

                 try
                 {
                     _repository.Update(yperfil);
                     return Success("OK", yperfil);
                 }
                 catch (Exception e)
                 {
                    return Error(e, yperfil);
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