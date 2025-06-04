using Comandos.Pateners.Command;
using Repositorio.Inputs.Repositorio.Y_Company;
using Repositorio.Inputs.Repositorio.Y_User;
using RepositoryInterfaces.Patterns.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Command.Receivers.HubServiceMethod
{
    public partial class ContasCreateContaServiceMethodReceiver
    {
        private readonly IY_UserWriteRepository _repositoryUserWrite;
        private readonly IY_CompanyWriteRepository _repositoryCompanyWrite;
        private readonly IUnitOfWork _unitOfWork;

        public ContasCreateContaServiceMethodReceiver(IY_UserWriteRepository repositoryUserWrite, IY_CompanyWriteRepository repositoryCompanyWrite, IUnitOfWork unitOfWork)
        {
            _repositoryUserWrite = repositoryUserWrite;
            _repositoryCompanyWrite = repositoryCompanyWrite;
            _unitOfWork = unitOfWork;
        }
        partial void CustomActionHook(ref State state, Command.Commands.ContasCreateContaServiceMethodCommand comand)
        {
            try
            {
                _unitOfWork.BeginTran();
                State userState = new Command.Receivers.Write.InsertY_UserReceiver(_repositoryUserWrite).Execute(new Commands.Y_UserCrudCommand() { Nome = comand.email, Email = comand.email, Senha = comand.password });
                var usuario = userState.Data as Dominio.Entitys.Y_User.Y_UserEntity;

                Command.Commands.Y_CompanyCrudCommand companyCommand = new Commands.Y_CompanyCrudCommand() { Nome = comand.email, UserIDAdmin = usuario.Id };
                new Command.Receivers.Write.InsertY_CompanyReceiver(_repositoryCompanyWrite).Execute(companyCommand);

                _unitOfWork.Commit();
            }
            catch (ReceiverException rex)
            {
                _unitOfWork.Rollback();
                state = rex.State;
            }
            catch (Exception e)
            {
                Error(e, comand);
            }
        }
    }
}