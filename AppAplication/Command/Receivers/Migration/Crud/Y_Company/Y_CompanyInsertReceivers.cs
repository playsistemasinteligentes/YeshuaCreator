using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Dominio.Entitys;
using Repositorio.Inputs.Repositorio.Y_Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.Write
{
    public class InsertY_CompanyReceiver : ReciverBase <Y_CompanyEntity>
    {
        private readonly IY_CompanyWriteRepository _repository;

        public InsertY_CompanyReceiver(IY_CompanyWriteRepository repository)
        {
            _repository = repository;
        }

        protected override State<Y_CompanyEntity> Action(ICommand comand)
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
                    return Error(e, y_company);
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