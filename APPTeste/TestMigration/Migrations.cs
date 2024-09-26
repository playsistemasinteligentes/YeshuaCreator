using Dominio.Migration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMigration
{
    [Migration(000001)]
    public class M000001 : MigrationBase
    {
        public override void Up()
        {
            AddEntity("Clinica");
            AddColumn("Id", "ID").Int().Incremento().Key();
            AddColumn("RazaoSocial").Varchar(100).NotNull();
            AddColumn("NomeReduzido").Varchar(100);
            AddColumn("Endereco").Varchar(100);
            AddColumn("Fone").Varchar(100);


            //AddColumn função.gpt(agendamento, " precisa validar se tem agenda vaga jkjadfkjgk")

            AddEntity("Paciente");
            AddColumn("Id").Int().Incremento();
            AddColumn("RazaoSocial", "Razão Social").Varchar(100);
            AddColumn("NomeReduzido").Varchar(100);


        }
    }


    [Migration(000002)]
    public class M000002 : MigrationBase
    {
        public override void Up()
        {
            AddEntity("ExecoesCalendario").
            AddColumn("Id").Int().Incremento().Key();
            AddColumn("teste").Int();
        }
    }



    [Migration(000003)]
    public class M000003 : MigrationBase
    {
        public override void Up()
        {
            AlterEntity("ExecoesCalendario")
                .AddColumn("De").DateTime()
                .AddColumn("Ate").DateTime()
                .DropColumn("teste");
            //.GPT("quero metodo que calcula desconto baseado na classe x ")
        }

    }
    [Migration(000004)]
    public class M000004 : MigrationBase
    {
        public override void Up()
        {


            AddEntity("Clinica");
            AddColumn("Id", "ID").Int().Incremento().Key();
            AddColumn("RazaoSocial").Varchar(100).NotNull();
            AddColumn("NomeReduzido").Varchar(100);
            AddColumn("Endereco").Varchar(100);
            AddColumn("Fone").Varchar(100);


            //AddColumn função.gpt(agendamento, " precisa validar se tem agenda vaga jkjadfkjgk")

            AddEntity("Paciente");
            AddColumn("Id").Int().Incremento();
            AddColumn("RazaoSocial", "Razão Social").Varchar(100);
            AddColumn("NomeReduzido").Varchar(100);


            AddEntity("Atendimento")
                .AddColumn("Id").Incremento()
                .AddColumn("Status")
                .Enumerable(1, "Inciou contato")
                .Enumerable(2, "Recebeu Menu")
                .AddColumn("UltimaInteracao").DateTime()
                .AddColumn("IDPaciente").FK("Paciente", "Id");

            //.GPT("quero metodo que calcula desconto baseado na classe x ")
        }

    }




}
