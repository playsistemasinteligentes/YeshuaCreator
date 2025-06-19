using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Repositorio.Inputs.Repositorio.Y_PerfilPermitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class DeleteY_PerfilPermitionsReceiver : ReciverBase <Y_PerfilPermitionsEntity>
    {
        private readonly IY_PerfilPermitionsWriteRepository _repository;

        public DeleteY_PerfilPermitionsReceiver(IY_PerfilPermitionsWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State<Y_PerfilPermitionsEntity> Action(ICommand comand)
        {
             if(comand is Command.Commands.Y_PerfilPermitionsCrudCommand c) 
             {    
                 var y_perfilpermitions = new Y_PerfilPermitionsEntity(c.PerfilId, c.PermitionsId);
                 if (!y_perfilpermitions.isValidDelete())
                     return ValidationError(y_perfilpermitions.getErroMensagens(), comand);

                 try
                 {
                     _repository.Delete(y_perfilpermitions);
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