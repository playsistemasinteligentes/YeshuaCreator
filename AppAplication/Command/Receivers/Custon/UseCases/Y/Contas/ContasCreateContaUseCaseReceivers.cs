
using Command.UseCase;
using Dominio.Entitys;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;

namespace Command.Receivers.UseCase
{
    public partial class ContasCreateContaUseCaseReceiver
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IYtenantReadRepository _repReadY_Tenant;
        private readonly IYtenantWriteRepository _repWriteY_Tenant;
        private readonly IYuserReadRepository _repReadY_User;
        private readonly IYuserWriteRepository _repWriteY_User;
        public ContasCreateContaUseCaseReceiver(IUnitOfWork unitOfWork, ILogger logger, IYtenantReadRepository repReadY_Tenant, IYtenantWriteRepository repWriteY_Tenant, IYuserReadRepository repReadY_User, IYuserWriteRepository repWriteY_User)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _repReadY_Tenant = repReadY_Tenant;
            _repWriteY_Tenant = repWriteY_Tenant;
            _repReadY_User = repReadY_User;
            _repWriteY_User = repWriteY_User;
        }

        partial void CustomActionHook(ref State<object> state, ContasCreateContaUseCaseCommand comand)
        {
            try
            {

                // Validação básica
                if (comand.CpfCnpj == 0)
                    throw new ReceiverException<object>(Error("Cpf / Cnpj é obrigatório", default));

                if (string.IsNullOrWhiteSpace(comand.email))
                    throw new ReceiverException<object>(Error("Email é obrigatório", default));

                if (string.IsNullOrWhiteSpace(comand.nome))
                    throw new ReceiverException<object>(Error("Nome é obrigatório", default));

                if (comand.password != comand.confirmpassword)
                    throw new ReceiverException<object>(Error("Senhas não conferem", default));

                if (_repReadY_Tenant.ExistsByCnpjCpf(comand.CpfCnpj))
                    throw new ReceiverException<object>(Error("Conta já existente.", default));

                if (_repReadY_User.ExistsByEmail(comand.email))
                    if (_repReadY_Tenant.ExistsByUserIDAdmin(_repReadY_User.FirstByEmail(comand.email).id))
                        throw new ReceiverException<object>(Error("Conta existente.", default));

                _unitOfWork.BeginTran();

                var tenant = new YtenantFactory(_logger).Create(
                    null,
                    comand.CpfCnpj,
                    comand.nome,
                    null
                );
                _repWriteY_Tenant.Insert(tenant);

                if (!tenant.isValidInsert())
                    throw new ReceiverException<object>(Error(string.Join("; ", tenant.getErroMensagens()), default));

                if (!tenant.Id.HasValue)
                    throw new ReceiverException<object>(Error("Erro ao criar Tenant, Id não gerado", default));

                // Criação do User usando Factory (padrão seu)
                var user = new YuserFactory(_logger).Create(
                    null,
                    comand.email,
                    comand.email, // Nome: Aqui você decide o valor real, coloquei email como exemplo
                    comand.password,
                    tenant.Id.Value
                );

                if (!user.isValidInsert())
                    throw new ReceiverException<object>(Error(string.Join("; ", user.getErroMensagens()), default));

                _repWriteY_User.Insert(user);

                tenant.UserIDAdmin = user.Id.Value;
                _repWriteY_Tenant.UpdateUserIDAdmin(tenant);

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

    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase