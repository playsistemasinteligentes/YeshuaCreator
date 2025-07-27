using Dominio;
using Dominio.Migration;
using Migration.Dominio.Schemas.CQRS;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Migration.Dominio.Migration.S000002;

namespace Migration.Dominio.Migration
{
    [Migration(000001)]
    public class S000001 : MigrationBase
    {
        public override void Up()
        {
            AddEntity("Ytenant")
            .AddColumn("Id", "ID").Int().Incremento().Key()
            .AddColumn("CnpjCpf", "Cnpj/Cpf").Int().NotNull()
            .AddColumn("Nome", "Nome").Varchar(150).NotNull()
            .AddColumn("UserId", "User ID").Int();

            AddEntity("Yuser")
            .AddColumn("Id", "ID").Int().Incremento().Key()
            .AddColumn("Nome", "Nome Usuario").Varchar(150).NotNull()
            .AddColumn("Email", "Email").Varchar(60).NotNull()
            .AddColumn("Senha", "Senha").Varchar(60).Password()
            .AddColumn("TenantID", "TenantID").Int().FK("Ytenant", "Id").StandardValue("#_correntUser.TenantID");


            AddEntity("YStandardFields")
            .AddColumn("TenantID", "TenantID").Int().FK("Ytenant", "Id").StandardField("#_correntUser.TenantID").BackEndField(true)
            .AddColumn("Deleted", "Deleted").Boolean().StandardField("0").BackEndField(true)
            .AddColumn("Changed", "Changed").DateTime().StandardField("#DateTime.Now").BackEndField(false)
            .AddColumn("UserId", "User ID").Int().FK("Yuser", "Id").StandardField("#_correntUser.UserId").BackEndField(false);


            AddEntity("YconfigArcteture").Cached()
            .AddColumn("Id", "ID").Int().Key()
            .AddColumn("AuditTrackerActived", "AuditTrackerActived").Int()
            .AddColumn("AuditCRUDActived", "AuditCRUDActived").Int();

            AddEntity("YconfigNotification").Cached()
            .AddColumn("Id", "ID").Int().Key()
            .AddColumn("TenantID", "TenantID").Int().FK("Ytenant", "Id").StandardValue("#_correntUser.TenantID")
            .AddColumn("EmailSmtpClient", "EmailSmtpClient").Varchar(100)
            .AddColumn("EmailPort", "EmailPort").Int()
            .AddColumn("EmailUserName", "EmailUserName").Varchar(100)
            .AddColumn("EmailPassword", "EmailPassword").Varchar(60);

            AddEntity("Yperfil")
            .AddColumn("Id", "ID").Int().Incremento().Key()
            .AddColumn("Description", "Descrição").Varchar(150).NotNull();

            AddEntity("Ypermtions")
            .AddColumn("Id", "ID").Varchar(100).Key()
            .AddColumn("Description", "Descrição").Varchar(1000);

            AddEntity("YperfilPermitions")
            .AddColumn("PerfilId", "ID Perfil").FK("Yperfil", "Id").Int()
            .AddColumn("PermitionsId", "ID Permição").FK("Ypermtions", "Id").Varchar(100);

            AddEntity("YuserPermitions")
            .AddColumn("PermitionsId", "ID Permição").FK("Ypermtions", "Id").Varchar(100)
            .AddColumn("UserId", "User ID").Int().FK("Yuser", "Id");
        }
    }

    [Migration(000002)]
    public class S000002 : MigrationBase
    {
        public record Account(int CpfCnpj, string nome, string email, string phone, string password, string confirmpassword);
        public record LoginUserEndPassword(string email, string password);
        public override void Up()
        {

            //AlterEntity("Ytenant").AddColumn("UserIDAdmin", "Administrador").FK("Yuser", "Id").Int();


            AddUsecaseGroup("Y").AddUseCaseSubGrup("Contas").AddUseCase("createConta", new Account(0, "", "", "", "", "")).Authorization(Authorization.Free)
            .AddEntity("Ytenant").AddEntity("Yuser").AddScope("Criar um tenant, e um user baseado command(string idcompany, string email, string phone, string password, string confirmpassword), controlar transação.");

            AddUsecaseGroup("Y").AddUseCaseSubGrup("Contas").AddUseCase("Login", new LoginUserEndPassword("", ""))
                .AddEntity("Yuser");



            AddUsecaseGroup("Y").AddUseCaseSubGrup("Contas").AddUseCase("RecoveryAccount", new RecoveryAccount("", TypeNotification.Email))
                .AddScope("Implemente use case para recuperação de contas, use strategy para implementar os diferentes tipos de mensagens de recuperação, use CustomActionHook")
                .Strategy(typeof(INotification)).AddAgregateStrategy(typeof(Message));
        }
        public record RecoveryAccount(string email, TypeNotification typeNotification);
        public enum TypeNotification
        {
            Email = 1,
            SMS = 2,
            Whatsapp = 3
        }

        public interface INotification
        {
            TypeNotification Type { get; }
            void SendNotification(IMessage menssege);
        }
        public interface IMessage
        {
            public string Destination { get; set; }
            public string Body { get; set; }
            public string? Subject { get; set; }
            public byte[]? Attachment { get; set; }
        }
        public class Message : IMessage
        {
            public string Destination { get; set; }
            public string Body { get; set; }
            public string? Subject { get; set; } = null;
            public byte[]? Attachment { get; set; } = null;
        }
    }




}
