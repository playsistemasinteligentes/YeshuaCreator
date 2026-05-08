//scope;
using Aplication.Interfaces.Services;
using Command.UseCase;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;

namespace Command.Receivers.UseCase
{
    public partial class CreateContaHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IyTenantReadRepository _repReadY_Tenant;
        private readonly IyTenantWriteRepository _repWriteY_Tenant;
        private readonly IyUserReadRepository _repReadY_User;
        private readonly IyUserWriteRepository _repWriteY_User;

        public CreateContaHandler(
    IUnitOfWork unitOfWork,
    IyTenantReadRepository repReadY_Tenant,
    IyTenantWriteRepository repWriteY_Tenant,
    IyUserReadRepository repReadY_User,
    IyUserWriteRepository repWriteY_User,
    Dominio.Interfaces.ILogger logger,
    Aplication.Interfaces.Services.IExecutionContext context)
    : base(logger, context)
        {
            _unitOfWork = unitOfWork;
            _repReadY_Tenant = repReadY_Tenant;
            _repWriteY_Tenant = repWriteY_Tenant;
            _repReadY_User = repReadY_User;
            _repWriteY_User = repWriteY_User;
            _logger = logger;
            _executionContext = context;
        }

        partial void CustomActionHook(ref State<CreateContaOutputCommand> state, CreateContaInputCommand comand)
{
            try
            {

                // Validação básica
                if (string.IsNullOrEmpty(comand.CpfCnpj))
                    throw new ReceiverException<CreateContaOutputCommand>(Error("Cpf / Cnpj é obrigatório", default));

                if (string.IsNullOrWhiteSpace(comand.email))
                    throw new ReceiverException<CreateContaOutputCommand>(Error("Email é obrigatório", default));

                if (string.IsNullOrWhiteSpace(comand.nome))
                    throw new ReceiverException<CreateContaOutputCommand>(Error("Nome é obrigatório", default));

                if (comand.password != comand.confirmpassword)
                    throw new ReceiverException<CreateContaOutputCommand>(Error("Senhas não conferem", default));

                if (_repReadY_Tenant.ExistsByCnpjCpf(comand.CpfCnpj))
                    throw new ReceiverException<CreateContaOutputCommand>(Error("Conta já existente.", default));

                if (_repReadY_User.ExistsByEmail(comand.email))
                    if (_repReadY_Tenant.ExistsByUserId(_repReadY_User.FirstByEmail(comand.email).id))
                        throw new ReceiverException<CreateContaOutputCommand>(Error("Conta existente.", default));

                _unitOfWork.BeginTran();

                var tenant = new yTenantFactory(_logger).Create(
                    comand.CpfCnpj,
                    comand.nome,
                    null
                );
                _repWriteY_Tenant.Insert(tenant);

                if (!tenant.isValidInsert())
                    throw new ReceiverException<CreateContaOutputCommand>(Error(string.Join("; ", tenant.getErroMensagens()), default));

                if (!tenant.Id.HasValue)
                    throw new ReceiverException<CreateContaOutputCommand>(Error("Erro ao criar Tenant, Id não gerado", default));

                // Criação do User usando Factory (padrão seu)
                var user = new yUserFactory(_logger).Create(
                    null,
                    comand.email,
                    comand.email, // Nome: Aqui você decide o valor real, coloquei email como exemplo
                    comand.password);

                _executionContext.SetTenantId(tenant.Id.Value);

                if (!user.isValidInsert())
                    throw new ReceiverException<CreateContaOutputCommand>(Error(string.Join("; ", user.getErroMensagens()), default));

                _repWriteY_User.Insert(user);

                _repWriteY_Tenant.UpdateUserId(tenant.Id.Value, user.Id.Value);

                _unitOfWork.Commit();

                state = Success("Conta criada com sucesso", new CreateContaOutputCommand { TenantId = tenant.Id.Value, UserId = user.Id.Value });
            }
            catch (ReceiverException<CreateContaOutputCommand>)
            {
                _unitOfWork.Rollback();
                throw;
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                throw new ReceiverException<CreateContaOutputCommand>(Error(ex, default));
            }

        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase