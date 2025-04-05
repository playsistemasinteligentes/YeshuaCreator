using Comandos.Pateners.Command;
using Dominio.Entitys.Y_Company;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Y_Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class InsertY_CompanyReceiver : ReciverBase
    {
        private readonly IY_CompanyWriteRepository _repository;

        public InsertY_CompanyReceiver(IY_CompanyWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State Action(ICommand comand)
        {
             if(comand is Command.Commands.Y_CompanyCrudCommand c) 
             {    
                 var y_company = new Y_CompanyEntity(c.Id, c.Nome, c.ProxyServer, c.UserIDAdmin);
                 if (!y_company.isValidInsert())
                     return ValidationError(y_company.getErroMensagens(), comand);

                 try
                 {
                     _repository.Insert(y_company);
                     return Success("OK", y_company);
                 }
                 catch (Exception e)
                 {
                     return Error(e, comand);
                 }
            }
            else 
            {
                 return Error("ErroConversao", comand);
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversMigration