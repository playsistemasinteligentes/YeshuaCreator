using Dominio;
using Dominio.Migration;
using Migration.Dominio.Schemas.CQRS;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Migration.Dominio.Migration.S000002;
using static System.Net.Mime.MediaTypeNames;

namespace Migration.Dominio.Migration
{
    /*
                Os 3 únicos conceitos que você precisa cravar no DSL
Command
intenção
Handler receiver
execução
Execution Policy
como isso acontece no tempo e na infraestrutura
Tudo o resto:
Outbox
Saga
Retry
Worker
Queue
Polling
👉 fica fora do DSL de domínio
👉 ou entra só como policy declarativa*/



    [Migration(000001)]
    public class S000001 : MigrationBase
    {
        public override void Up()
        {
            AddModule("ADM", "Administrativo");

            AddEntity("yTenant").AddModule("ADM")
            .AddColumn("Id", "ID").Int().Incremento().Key().DefaultValue("#_currentUser.TenantID").NeedBeWhere().CanTakeOffWhere()
            .AddColumn("CnpjCpf", "Cnpj/Cpf").Varchar(14).NotNull()
            .AddColumn("Nome", "Nome").Varchar(150).NotNull()
            .AddColumn("UserId", "User ID").Int();

            AddEntity("yUser").AddModule("ADM")
            .AddColumn("Id", "ID").Int().Incremento().Key()
            .AddColumn("Nome", "Nome Usuario").Varchar(150).NotNull()
            .AddColumn("Email", "Email").Varchar(60).NotNull()
            .AddColumn("Senha", "Senha").Varchar(60).Password()
            .AddColumn("TenantID", "TenantID").Int().FK("yTenant", "Id").DefaultValue("#_currentUser.TenantID").EditFront(false).VisivelFront(false).NeedBeWhere().CanTakeOffWhere();


            AddEntity("yStandardFields")
            .AddColumn("TenantID", "TenantID").Int().FK("yTenant", "Id").DefaultValue("#_currentUser.TenantID").EditFront(false).VisivelFront(false).NeedBeWhere()
            .NotEntity("yModule")
            .AddColumn("Deleted", "Deleted").Boolean().DefaultValue("0").NeedBeWhere().EditFront(false).VisivelFront(false)
            .NotEntity("yModule")
            .AddColumn("Changed", "Changed").DateTime().DefaultValue("#DateTime.Now").EditFront(false).VisivelFront(false)
            .NotEntity("yModule")
            .AddColumn("UserId", "User ID").Int().FK("yUser", "Id").DefaultValue("#_currentUser.UserId").EditFront(false).VisivelFront(false)
            .NotEntity("yModule");


            AddEntity("yConfigArcteture").AddModule("ADM").Cached()
            .AddColumn("Id", "ID").Int().Key()
            .AddColumn("AuditTrackerActived", "AuditTrackerActived").Int()
            .AddColumn("AuditCRUDActived", "AuditCRUDActived").Int();

            AddEntity("yConfigNotification").AddModule("ADM").Cached()
            .AddColumn("Id", "ID").Int().Key()
            .AddColumn("TenantID", "TenantID").Int().FK("yTenant", "Id").DefaultValue("#_currentUser.TenantID")
            .AddColumn("EmailSmtpClient", "EmailSmtpClient").Varchar(100)
            .AddColumn("EmailPort", "EmailPort").Int()
            .AddColumn("EmailUserName", "EmailUserName").Varchar(100)
            .AddColumn("EmailPassword", "EmailPassword").Varchar(60);

            AddEntity("yPerfil").AddModule("ADM")
            .AddColumn("Id", "ID").Int().Incremento().Key()
            .AddColumn("Description", "Descrição").Varchar(150).NotNull();

            AddEntity("yModule")
            .AddColumn("Id", "ID").Varchar(100).Key()
            .AddColumn("Description", "Descrição").Varchar(1000);

            AddEntity("yTenantModule").AddModule("ADM")
            .AddColumn("Id", "ID").Int().Incremento().Key()
            .AddColumn("ModuleId", "ID Modulo").FK("yModule", "Id").Varchar(100)
            .AddColumn("TenantID", "TenantID").Int().FK("yTenant", "Id").DefaultValue("#_currentUser.TenantID")
            .AddColumn("ValidUntil", "Valido ate").DateTime();


            AddEntity("yUserModule").AddModule("ADM")
            .AddColumn("Id", "ID").Int().Incremento().Key()
            .AddColumn("ModuleId", "ID Modulo").FK("yModule", "Id").Varchar(100).WhereClauses("id in (select ModuleId from yTenantModule where TenantID = _currentUser.TenantID)")
            .AddColumn("UserId", "User ID").Int().FK("yUser", "Id")
            .AddColumn("ValidUntil", "Valido ate").DateTime();


            AddEntity("yGrant")
            .AddColumn("Id", "ID").Varchar(100).Key()
            .AddColumn("Description", "Descrição").Varchar(1000);

            /*AddEntity("YpermissionAuthorityLevel") // modelo de allada
            .AddColumn("Id", "ID").Varchar(100).Key()
            .AddColumn("Description", "Descrição").Varchar(1000);*/

            AddEntity("yPerfilGrant").AddModule("ADM")
            .AddColumn("Id", "ID").Int().Incremento().Key()
            .AddColumn("PerfilId", "ID Perfil").FK("yPerfil", "Id").Int()
            .AddColumn("GrantId", "ID Permição").FK("yGrant", "Id").Varchar(100)
            .AddColumn("Grant", "Permite acessar").Boolean()
            .AddColumn("Create", "Permite Criar").Boolean()
            .AddColumn("Read", "Permite  Ler").Boolean()
            .AddColumn("Update", "Permite Atualizar").Boolean()
            .AddColumn("Delete", "Permite Deletar").Boolean()
            .AddColumn("ValidUntil", "Valido ate").DateTime();

            AddEntity("yUserGrant").AddModule("ADM")
            .AddColumn("Id", "ID").Int().Incremento().Key()
            .AddColumn("PerfilId", "ID Perfil").FK("yPerfil", "Id").Int()
            .AddColumn("GrantId", "ID Permição").FK("yGrant", "Id").Varchar(100)
            .AddColumn("Grant", "Permite acessar").Boolean()
            .AddColumn("Create", "Permite Criar").Boolean()
            .AddColumn("Read", "Permite  Ler").Boolean()
            .AddColumn("Update", "Permite Atualizar").Boolean()
            .AddColumn("Delete", "Permite Deletar").Boolean()
            .AddColumn("ValidUntil", "Valido ate").DateTime();
        }
    }

    [Migration(000002)]
    public class S000002 : MigrationBase
    {
        public record Account(string CpfCnpj, string nome, string email, string phone, string password, string confirmpassword);
        public record AccountResult(int TenantId, int UserId);
        public record LoginInput(string email, string password);
        public record LoginOutput(List<string> modulos, int UserId, string email, int tenantId);

        public override void Up()
        {

            AddUsecaseGroup("Y").AddUseCaseSubGrup("Contas").AddCommand("createConta", new Account("", "", "", "", "", ""), new AccountResult(1, 1)).Authorization(Authorization.Free)
            .AddEntity("yTenant").AddEntity("yUser").AddScope("Criar um tenant, e um user baseado command(string idcompany, string email, string phone, string password, string confirmpassword), controlar transação.");

            AddUsecaseGroup("Y").AddUseCaseSubGrup("Contas").AddCommand("Login", new LoginInput("", ""), new LoginOutput(new List<string>(), 1, "", 1))
                .AddEntity("yUser").AddEntity("yTenantModule").AddEntity("yUserModule");


            AddUsecaseGroup("Y").AddUseCaseSubGrup("Contas").AddCommand("RecoveryAccount", new RecoveryAccount("", TypeNotification.Email))
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
