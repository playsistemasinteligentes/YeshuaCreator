using Command.Patterns.Command;
using Command.Receivers.Write;
using Dominio.Entitys;
using Repositorio.Inputs.Repositorio.Y_Tenant;
using Repositorio.Inputs.Repositorio.Y_User;
using RepositoryInterfaces.Patterns.Command;
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
    public partial class ContasCreateContaServiceMethodReceiver : ReciverBase<object>
    {
        private readonly IY_UserWriteRepository _repositoryUserWrite;
        private readonly IY_TenantWriteRepository _repositoryTanetWrite;
        private readonly IUnitOfWork _unitOfWork;

        public ContasCreateContaServiceMethodReceiver(IY_UserWriteRepository repositoryUserWrite, IY_TenantWriteRepository repositoryTanetWrite, IUnitOfWork unitOfWork)
        {
            _repositoryUserWrite = repositoryUserWrite;
            _repositoryTanetWrite = repositoryTanetWrite;
            _unitOfWork = unitOfWork;
        }
        partial void CustomActionHook(ref State<object> state, Command.Commands.ContasCreateContaServiceMethodCommand comand)
        {
            try
            {
                //_unitOfWork.BeginTran();
                //State<Y_UserEntity> userState = new InsertY_UserReceiver(_repositoryUserWrite).Execute(new Commands.Y_UserCrudCommand() { Nome = comand.email, Email = comand.email, Senha = comand.password });
                //var usuario = userState.Data;

                //Command.Commands.Y_TenantCrudCommand companyCommand = new Commands.Y_TenantCrudCommand() { Nome = comand.email, UserIDAdmin = usuario.Id };
                //new Command.Receivers.Write.InsertY_TenantReceiver(_repositoryTanetWrite).Execute(companyCommand);

                //_unitOfWork.Commit();
            }
            catch (ReceiverException<object> rex)
            {
                _unitOfWork.Rollback();
                state = rex.State;
            }
            catch (Exception e)
            {
                Error(e, default);
            }
        }
    }
}