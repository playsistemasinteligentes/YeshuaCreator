//scope;

using Command.Commands;
using Command.Patterns.Command;
using Command.Read;
using Command.UseCase;
using Dominio.Entitys;
using Dominio.Interfaces.Strategy;
using IRepository.Read;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;


namespace Command.Receivers.UseCase
{
    public partial class RecoveryAccountHandler
    {

        private readonly IINotificationFactory _factory;
        private readonly IMessage _messege;
        private readonly IyUserReadRepository _userRep;
        // Injete a fábrica no construtor
        public RecoveryAccountHandler(
            IINotificationFactory factory,
            IMessage messege,
            IyUserReadRepository userRep,
            Dominio.Interfaces.ILogger logger,
            Aplication.Interfaces.Services.IExecutionContext context)
            : base(logger, context)
        {
            _factory = factory;
            _messege = messege;
            _userRep = userRep;
        }

        partial void CustomActionHook(ref State<RecoveryAccountOutputCommand> state, RecoveryAccountInputCommand comand)
        {
            var notification = _factory.GetType(comand.typeNotification);
            var us = new yUserReadCommand();
            us.Email = comand.email;
            var user = _userRep.getyUser(us);
            _messege.Destination = user.Items.ElementAt(0).email;
            _messege.Subject = "Recuperação de email";
            _messege.Body = $@"
                                <!DOCTYPE html>
                                <html>
                                <body style='font-family: Arial, sans-serif; color: #333; line-height: 1.6;'>
                                  <div style='max-width: 600px; margin: auto; padding: 20px; border: 1px solid #ddd; border-radius: 8px;'>
                                    <h2 style='color: #2E86C1;'>Recuperação de Senha</h2>
                                    <p>Olá,</p>
                                    <p>Recebemos uma solicitação para redefinir sua senha. Use a senha temporária abaixo para acessar sua conta:</p>

                                    <div style='padding: 15px; background-color: #f4f4f4; border-radius: 5px; font-size: 18px; font-weight: bold; text-align: center;'>
                                      {user.Items.ElementAt(0).senha}
                                    </div>

                                    <p>Recomendamos que você altere essa senha assim que acessar sua conta.</p>

                                    <p>Se você não solicitou essa recuperação, ignore este e-mail.</p>

                                    <p>Atenciosamente,<br/>
                                    Equipe de Suporte</p>
                                  </div>
                                </body>
                                </html>";





            notification.SendNotification(_messege);

        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationCommandReceiversUseCase