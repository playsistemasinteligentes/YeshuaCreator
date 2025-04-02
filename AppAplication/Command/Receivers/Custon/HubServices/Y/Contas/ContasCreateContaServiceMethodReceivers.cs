using Comandos.Pateners.Command;
using Dominio.TiposPrimitivos;
using Repositorio.Inputs.Repositorio.Clinica;
using Repositorio.Inputs.Repositorio.Y_Company;
using Repositorio.Inputs.Repositorio.Y_User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.HubServiceMethod
{
    public partial class ContasCreateContaServiceMethodReceiver
    {
        private readonly IY_UserWriteRepository _repositoryUserWrite;
        private readonly IY_CompanyWriteRepository _repositoryCompanyWrite;

        public ContasCreateContaServiceMethodReceiver(IY_UserWriteRepository repositoryUserWrite, IY_CompanyWriteRepository repositoryCompanyWrite)
        {
            _repositoryUserWrite = repositoryUserWrite;
            _repositoryCompanyWrite = repositoryCompanyWrite;
        }
        partial void CustomActionHook(ref State state, Command.Commands.ContasCreateContaServiceMethodCommand comand)
        {

            Command.Receivers.Write.InsertY_UserReceiver userReceiver = new Command.Receivers.Write.InsertY_UserReceiver(_repositoryUserWrite);
            Command.Commands.Y_UserCrudCommand userCommand = new Commands.Y_UserCrudCommand() { Nome = comand.email, Email = comand.email, Senha = comand.password };
            State userState = userReceiver.Execute(userCommand);
            var usuario = userState.Data as Dominio.Entitys.Y_User.Y_UserEntity;

            Command.Receivers.Write.InsertY_CompanyReceiver companyReceiver = new Command.Receivers.Write.InsertY_CompanyReceiver(_repositoryCompanyWrite);
            Command.Commands.Y_CompanyCrudCommand companyCommand = new Commands.Y_CompanyCrudCommand()
            { Nome = comand.email, UserIDAdmin = usuario.Id };
            State companyState = companyReceiver.Execute(companyCommand);


            state = new State(201, "Custom Action Applied", comand);
        }
    }
}