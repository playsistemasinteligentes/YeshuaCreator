using Dominio;
using Dominio.Migration;
using Microsoft.AspNetCore.Http;
using Migration.Dominio.Schemas.CQRS;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Templates;
using static Migration.Dominio.Migration.S000002;
using static System.Net.Mime.MediaTypeNames;

namespace Migration.Dominio.Migration
{
    [Migration(000004)]
    public class S000004 : MigrationBase
    {
        public override void Up()
        {
            AddEntity("yToken").AddModule("ADM")
                .AddColumn("Id", "ID").Int().Incremento().Key()
                .AddColumn("TokenHash", "Hash do Token").Varchar(200).NotNull()
                .AddColumn("Description", "Descricao").Varchar(200)
                .AddColumn("ConnectorKey", "Conector").Varchar(100).NotNull()
                .AddColumn("Active", "Ativo").Boolean().NotNull().DefaultValue("1")
                .AddColumn("ValidUntil", "Valido ate").DateTime()
                .AddColumn("CreatedAt", "Criado em").DateTime().NotNull().DefaultValue("#DateTime.Now")
                .AddColumn("LastUsedAt", "Ultimo uso").DateTime()
                .AddColumn("TenantID", "TenantID").Int().FK("yTenant", "Id").DefaultValue("#_executionContext.TenantID").EditFront(false).VisivelFront(false).NeedBeWhere().CanTakeOffWhere()
                .AddColumn("UserId", "User ID").Int().FK("yUser", "Id").DefaultValue("#_executionContext.UserId").EditFront(false).VisivelFront(false);
        }
    }
}
