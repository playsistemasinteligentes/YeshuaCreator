using Dominio.Interfaces;
using Command.Commands;
using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Repositorio.Inputs.Repositorio.Y_User;
using Read.RepositoryInterfaces;

namespace Command.Receivers.UseCase
{
    public partial class ContasLoginUseCaseReceiver
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IY_UserReadRepository _repReadY_User;
        private readonly IY_UserWriteRepository _repWriteY_User;
        public ContasLoginUseCaseReceiver(IUnitOfWork unitOfWork, ILogger logger, IY_UserReadRepository repReadY_User, IY_UserWriteRepository repWriteY_User)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _repReadY_User = repReadY_User;
            _repWriteY_User = repWriteY_User;
        }
        partial void CustomActionHook(ref State<object> state, ContasLoginUseCaseCommand command)
        {
            try
            {
                var user = _repReadY_User.FirstByEmail(command.email);
                if (user == null)
                    throw new ReceiverException<object>(Error("Erro login.", default));

                if (user.senha != command.password)
                {
                    throw new ReceiverException<object>(Error("Erro login.", default));
                }

                state = Success("Login válido", user);
            }

            catch (ReceiverException<object> ex)
            {
                state = ex.State;
                throw;
            }
            catch (Exception ex)
            {
                throw new ReceiverException<object>(Error(ex, default));
            }
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase