// Escopo: Criar um tenant, e um user baseado command(string idcompany, string email, string phone, string password, string confirmpassword), controlar transação.
using Command.Commands;
using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Dominio.Interfaces;
using Repositorio.Inputs.Repositorio.Y_Tenant;
using RepositoryInterfaces.Read.Repository.Y_Tenant;
using Repositorio.Inputs.Repositorio.Y_User;
using RepositoryInterfaces.Read.Repository.Y_User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Receivers.UseCase
{
    public partial class ContasCreateContaUseCaseReceiver : ReciverBase<object>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IY_TenantReadRepository _repReadY_Tenant;
        private readonly IY_TenantWriteRepository _repWriteY_Tenant;
        private readonly IY_UserReadRepository _repReadY_User;
        private readonly IY_UserWriteRepository _repWriteY_User;
        public ContasCreateContaUseCaseReceiver(IUnitOfWork unitOfWork,ILogger logger,IY_TenantReadRepository repReadY_Tenant, IY_TenantWriteRepository repWriteY_Tenant,IY_UserReadRepository repReadY_User, IY_UserWriteRepository repWriteY_User)
        {
           _unitOfWork = unitOfWork;
           _logger = logger;
            _repReadY_Tenant = repReadY_Tenant;
            _repWriteY_Tenant = repWriteY_Tenant;
            _repReadY_User = repReadY_User;
            _repWriteY_User = repWriteY_User;
        }

        protected override State<object> Action(ICommand comand)
        {
            try
            {
                 State<object> retorno = Success("OK", (ContasCreateContaUseCaseCommand)comand);
                 if (comand is Command.Commands.ContasCreateContaUseCaseCommand specificCommand)
                 CustomActionHook(ref retorno, specificCommand);
                 return retorno;
            }
            catch (ReceiverException<object> e)
            {
                return e.State;
            }
            catch (Exception e)
            {
                return Error(e, default);
            }
        }
partial void CustomActionHook(ref State<object> state, Command.Commands.ContasCreateContaUseCaseCommand comand);
}
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase