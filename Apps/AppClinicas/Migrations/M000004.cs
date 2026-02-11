using Dominio.Migration;
using MyApp.Domain.Entities;
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


    [Migration(000004)]
    public class M000004 : MigrationBase
    {
        public override void Up()
        {

            AddUsecaseGroup("Worker").AddUseCaseSubGrup("Worker").AddUseCaseCommand("Inbox", new LoginInput("", ""), new LoginOutput(new List<string>(), 1, "", 1))
            .AddEntity("yUser").AddEntity("yTenantModule").AddEntity("yUserModule").IsWorker();

            AddUsecaseGroup("Worker").AddUseCaseSubGrup("Worker").AddUseCaseCommand("OutBox", new LoginInput("", ""), new LoginOutput(new List<string>(), 1, "", 1))
            .AddEntity("yUser").AddEntity("yTenantModule").AddEntity("yUserModule").IsWorker();



            //AddQuery<Sesoes>("Standard", q => q
            //.WhereContext("Hoje", s => s.DataInicio >= DateTime.Today && s.DataInicio < DateTime.Today.AddDays(1))
            // .WhereContext("Semana", s => s.DataInicio >= DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek) && s.DataInicio < DateTime.Today.AddDays(7 - (int)DateTime.Today.DayOfWeek))
            //.WhereContext("D30", s => s.DataInicio >= DateTime.Today && s.DataInicio < DateTime.Today.AddDays(30))
            // .Where("Geral", s => s.DataInicio >= DateTime.Today && s.DataFim <= DateTime.Today && s.StatusAgendamento == 0 && s.StatusProntuario == 0)

            // .Select(s => new { s.Id, s.DataInicio, s.Paciente.Nome, s.StatusAgendamento, s.StatusProntuario }));

        }
    }
}
