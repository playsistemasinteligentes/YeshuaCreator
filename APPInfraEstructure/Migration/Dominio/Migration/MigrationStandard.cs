using Dominio.Migration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migration.Dominio.Migration
{
    [Migration(000001)]
    public class S000001 : MigrationBase
    {
        public override void Up()
        {
            AddEntity("Y_User")
            .AddColumn("Id", "ID").Int().Incremento().Key()
            .AddColumn("Nome", "Nome da Clínica").Varchar(150).NotNull()
            .AddColumn("Email", "Email").Varchar(60).NotNull()
            .AddColumn("Senha", "Senha").Varchar(60).Password();

            AddEntity("Y_Company")
            .AddColumn("Id", "ID").Int().Incremento().Key()
            .AddColumn("Nome", "Nome").Varchar(150).NotNull()
            .AddColumn("ProxyServer", "ProxyServer").Varchar(150).BackEndField()
            .AddColumn("UserIDAdmin", "Administrador").FK("Y_User", "Id").Int();

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
}
