using Dominio.Migration;
using Yeshua.Studio.AppClinicas.Domain.Entities;
using MyApp.QueryBuilder;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static Migration.Dominio.Migration.S000002;

namespace AppClinicas
{

    [Migration(000001)]
    public class M000001 : MigrationBase
    {
        public override void Up()
        {
            AddModule("PSI", "Clinica Psicologia");


            AddEntity("Clinica").AddModule("PSI")
            .AddColumn("Id", "ID").Int().Incremento().Key()
            .AddColumn("Nome", "Nome da Clínica").Varchar(150).NotNull()
            .AddColumn("Endereco", "Endereço da Clínica").Varchar(250).NotNull()
            .AddColumn("Telefone", "Telefone de Contato").Varchar(20).NotNull();
        }
    }

}
