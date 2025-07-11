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
            AddEntity("Y_Tenant")
            .AddColumn("Id", "ID").Int().Incremento().Key()
            .AddColumn("Nome", "Nome").Varchar(150).NotNull()
            .AddColumn("ProxyServer", "ProxyServer").Varchar(150).BackEndField();

            AddEntity("Y_User")
            .AddColumn("Id", "ID").Int().Incremento().Key()
            .AddColumn("Nome", "Nome da Clínica").Varchar(150).NotNull()
            .AddColumn("Email", "Email").Varchar(60).NotNull()
            .AddColumn("Senha", "Senha").Varchar(60).Password()
            .AddColumn("TenantID", "Administrador").FK("Y_Tenant", "Id").Int();


            AddEntity("Y_Tenant_Configuration").Cached()
            .AddColumn("Id", "ID").Int().Key()
            .AddColumn("AuditTrackerActived", "AuditTrackerActived").Int()
            .AddColumn("AuditCRUDActived", "AuditCRUDActived").Int()
            .AddColumn("TenantID", "Administrador").FK("Y_Tenant", "Id").Int();

            AddEntity("Y_Perfil")
            .AddColumn("Id", "ID").Int().Incremento().Key()
            .AddColumn("Description", "Descrição").Varchar(150).NotNull();

            AddEntity("Y_Permtions")
            .AddColumn("Id", "ID").Varchar(100).Key()
            .AddColumn("Description", "Descrição").Varchar(1000);

            AddEntity("Y_PerfilPermitions")
            .AddColumn("PerfilId", "ID Perfil").FK("Y_Perfil", "Id").Int()
            .AddColumn("PermitionsId", "ID Permição").FK("Y_Permtions", "Id").Varchar(100);

            AddEntity("Y_UserPermitions")
            .AddColumn("UserId", "User ID").FK("Y_User", "Id").Int()
            .AddColumn("PermitionsId", "ID Permição").FK("Y_Permtions", "Id").Varchar(100);
        }
    }

    [Migration(000002)]
    public class S000002 : MigrationBase
    {
        public override void Up()
        {

            AlterEntity("Y_Tenant").AddColumn("UserIDAdmin", "Administrador").FK("Y_User", "Id").Int();


            AddUsecaseGroup("Y").AddUseCaseSubGrup("Contas").AddUseCase("createConta", new Account("", "", "", "", "")).Authorization(Authorization.Free)
            .AddEntity("Y_Tenant").AddEntity("Y_User").AddScope("Criar um tenant, e um user baseado command(string idcompany, string email, string phone, string password, string confirmpassword), controlar transação.");

            AddUsecaseGroup("Y").AddUseCaseSubGrup("Contas").AddUseCase("Login", new LoginUserEndPassword("", ""));

            AddUsecaseGroup("Y").AddUseCaseSubGrup("Contas").AddUseCase("RecoveryAccount", new RecoveryAccount("", TypeNotification.Email))
                .AddScope("Implemente use case para recuperação de contas, use strategy para implementar os diferentes tipos de mensagens de recuperação, use CustomActionHook")
                .Strategy(typeof(INotification));
        }
        public record Account(string idcompany, string email, string phone, string password, string confirmpassword);
        public record LoginUserEndPassword(string email, string password);
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
