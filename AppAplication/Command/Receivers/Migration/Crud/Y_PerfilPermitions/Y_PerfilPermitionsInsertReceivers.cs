using Comandos.Pateners.Command;
using Dominio.Entitys;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Y_PerfilPermitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class InsertY_PerfilPermitionsReceiver : ReciverBase <Y_PerfilPermitionsEntity>
    {
        private readonly IY_PerfilPermitionsWriteRepository _repository;

        public InsertY_PerfilPermitionsReceiver(IY_PerfilPermitionsWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State<Y_PerfilPermitionsEntity> Action(ICommand comand)
        {
             if(comand is Command.Commands.Y_PerfilPermitionsCrudCommand c) 
             {    
                 var y_perfilpermitions = new Y_PerfilPermitionsEntity(c.PerfilId, c.PermitionsId);
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