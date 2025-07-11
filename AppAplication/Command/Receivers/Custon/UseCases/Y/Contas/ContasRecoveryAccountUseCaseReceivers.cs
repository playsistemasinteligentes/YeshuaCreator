using Command.Commands;
using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
//using using Repositorio.Inputs.Repositorio.Implemente use case para recuperação de contas, use strategy para implementar os diferentes tipos de mensagens de recuperação, use CustomActionHook;

namespace Command.Receivers.UseCase
{
    public partial class ContasRecoveryAccountUseCaseReceiver
    {
/*
private readonly IUnitOfWork _unitOfWork;
private readonly IImplemente use case para recuperação de contas, use strategy para implementar os diferentes tipos de mensagens de recuperação, use CustomActionHook _Implemente use case para recuperação de contas, use strategy para implementar os diferentes tipos de mensagens de recuperação, use CustomActionHook;
partial void CustomActionHook(ref State<object> state, Command.Commands.ContasCreateContaServiceMethodCommand comand)
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
*/
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase