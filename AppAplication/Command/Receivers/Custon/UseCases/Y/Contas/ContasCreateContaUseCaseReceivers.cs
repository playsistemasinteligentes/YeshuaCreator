using Command.Commands;
using Command.Patterns.Command;
using Dominio.Entitys;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;

namespace Command.Receivers.UseCase
{
    public partial class ContasCreateContaUseCaseReceiver
    {
        partial void CustomActionHook(ref State<object> state, ContasCreateContaUseCaseCommand comand)
        {
            try
            {
                _unitOfWork.BeginTran();

                // Validação básica
                if (string.IsNullOrWhiteSpace(comand.idcompany))
                    throw new ReceiverException<object>(Error("IdCompany é obrigatório", default));

                if (string.IsNullOrWhiteSpace(comand.email))
                    throw new ReceiverException<object>(Error("Email é obrigatório", default));

                if (comand.password != comand.confirmpassword)
                    throw new ReceiverException<object>(Error("Senhas não conferem", default));

                // Criação do Tenant usando Factory
                var tenant = new Y_TenantFactory(_logger).Create(
                    null,
                    comand.idcompany,
                    null,
                    null
                );

                if (!tenant.isValidInsert())
                    throw new ReceiverException<object>(Error(string.Join("; ", tenant.getErroMensagens()), default));

                _repWriteY_Tenant.Insert(tenant);

                if (!tenant.Id.HasValue)
                    throw new ReceiverException<object>(Error("Erro ao criar Tenant, Id não gerado", default));

                // Criação do User usando Factory (padrão seu)
                var user = new Y_UserFactory(_logger).Create(
                    null,
                    comand.email,
                    comand.email, // Nome: Aqui você decide o valor real, coloquei email como exemplo
                    comand.password,
                    tenant.Id.Value
                );

                if (!user.isValidInsert())
                    throw new ReceiverException<object>(Error(string.Join("; ", user.getErroMensagens()), default));

                _repWriteY_User.Insert(user);

                _unitOfWork.Commit();

                state = Success("Conta criada com sucesso", new { TenantId = tenant.Id, UserId = user.Id });
            }
            catch (ReceiverException<object>)
            {
                _unitOfWork.Rollback();
                throw;
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                throw new ReceiverException<object>(Error(ex, default));
            }
        }



        /*
        private readonly IUnitOfWork _unitOfWork;
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