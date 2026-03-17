using Dominio.Migration;
using Migration.Dominio;
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
            var ai_tasks = new QueueTopology("ai.tasks", ExchangeType.Topic, "audio.transcribe.worker", "audio.transcribe");
            var ai_results = new QueueTopology("ai.results", ExchangeType.Topic, "audio.transcribed.inbox", "audio.transcribed");
            var ai_dead = new QueueTopology("ai.results", ExchangeType.Topic, "audio.transcribe.dead", "audio.transcribe");

            AddUsecaseGroup("Worker").AddUseCaseSubGrup("WorkerPolling").AddUseCaseCommand("OutBox", new LoginInput("", ""), new LoginOutput(new List<string>(), 1, "", 1))
            .AddEntity<yOutbox>().IsWorker();

            AddUsecaseGroup("Worker").AddUseCaseSubGrup("WorkerPolling").AddUseCaseCommand("Inbox", new LoginInput("", ""), new LoginOutput(new List<string>(), 1, "", 1))
            .AddEntity<yInbox>().IsWorker();

            AddUsecaseGroup("Worker").AddUseCaseSubGrup("WorkerListener").AddUseCaseCommand("InBox", new LoginInput("", ""), new LoginOutput(new List<string>(), 1, "", 1))
            .AddEntity<yInbox>().IsListener();





            /*to
             
             // pendencia montar via motor 
var topology = new QueueTopology
{
    Exchanges =
    {
        new ExchangeDefinition
        {
            Name = "ai.tasks",
            Type = "topic",
            Bindings =
            {
                new QueueBindingDefinition
                {
                    QueueName = "audio.transcribe.worker",
                    RoutingKey = "audio.transcribe"
                }
            }
        },
        new ExchangeDefinition
        {
            Name = "ai.results",
            Type = "topic",
            Bindings =
            {
                new QueueBindingDefinition
                {
                    QueueName = "audio.transcribed.inbox",
                    RoutingKey = "audio.transcribed"
                }
            }
        },
        new ExchangeDefinition
        {
            Name = "ai.dead",
            Type = "topic",
            Bindings =
            {
                new QueueBindingDefinition
                {
                    QueueName = "audio.transcribe.dead",
                    RoutingKey = "audio.transcribe"
                }
            }
        }
    }
};
             
             */



            //AddQuery<Sesoes>("Standard", q => q
            //.WhereContext("Hoje", s => s.DataInicio >= DateTime.Today && s.DataInicio < DateTime.Today.AddDays(1))
            // .WhereContext("Semana", s => s.DataInicio >= DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek) && s.DataInicio < DateTime.Today.AddDays(7 - (int)DateTime.Today.DayOfWeek))
            //.WhereContext("D30", s => s.DataInicio >= DateTime.Today && s.DataInicio < DateTime.Today.AddDays(30))
            // .Where("Geral", s => s.DataInicio >= DateTime.Today && s.DataFim <= DateTime.Today && s.StatusAgendamento == 0 && s.StatusProntuario == 0)

            // .Select(s => new { s.Id, s.DataInicio, s.Paciente.Nome, s.StatusAgendamento, s.StatusProntuario }));

        }
    }
}
