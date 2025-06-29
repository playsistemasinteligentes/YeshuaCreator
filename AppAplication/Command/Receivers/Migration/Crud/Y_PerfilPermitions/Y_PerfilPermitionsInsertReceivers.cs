using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Dominio.Interfaces;
using Repositorio.Inputs.Repositorio.Y_PerfilPermitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class InsertY_PerfilPermitionsReceiver : ReciverBase <IY_PerfilPermitionsEntity>
    {
        private readonly IY_PerfilPermitionsWriteRepository _repository;
        private readonly ILogger _logger;

        public InsertY_PerfilPermitionsReceiver(IY_PerfilPermitionsWriteRepository repository,ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override State<IY_PerfilPermitionsEntity> Action(ICommand comand)
        {
             if(comand is Command.Commands.Y_PerfilPermitionsCrudCommand c) 
             {    
                 var y_perfilpermitions = new Y_PerfilPermitionsFactory(_logger).Create(c.PerfilId, c.PermitionsId);
                 if (!y_perfilpermitions.isValidInsert())
                     return ValidationError(y_perfilpermitions.getErroMensagens(), comand);

                 try
                 {
                     _repository.Insert(y_perfilpermitions);
                     return Success("OK", y_perfilpermitions);
                 }
                 catch (Exception e)
                 {
                    return Error(e, y_perfilpermitions);
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