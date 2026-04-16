
using Dominio.TiposPrimitivos;
using Migration.Dominio;
using Migration.Dominio.Schemas;
using Migration.Dominio.Schemas.CQRS;
using System.Collections;
using System.Reflection;
using System.Text;
using static Dapper.SqlMapper;
using static Migration.Dominio.Migration.S000002;
using static System.Formats.Asn1.AsnWriter;

namespace Dominio
{
    public class UseCaseGroup
    {


        /*
         O que é um EVENTO (de verdade)

Um Evento é:

“Algo relevante já aconteceu no domínio”

Características:

Passado, imutável

Sem intenção

Não pode falhar

Não pede permissão

Exemplos:

SessaoEncerrada

TranscricaoConcluida

PagamentoConfirmado

📌 Evento não é pedido
📌 Evento não decide fluxo
📌 Evento não garante entrega

Ele só declara um fato.
        
         Então o que é o INBOX?

Inbox não é evento.

Inbox é:

“Registro confiável de que uma mensagem externa foi recebida”

Ele representa entrada, não acontecimento de domínio.

6️⃣ Inbox × Evento — comparação direta
Aspecto	Inbox	Evento
Origem	Externa	Interna
Significado	“Recebi algo”	“Algo aconteceu”
Papel	Proteção / controle	Comunicação semântica
Pode falhar?	Sim (processamento)	Não (fato)
Reprocessável	Sim	Não (evento é imutável)
Decide fluxo?	Não	Não
Garante entrega?	Sim	Não

📌 Inbox é infra
📌 Evento é domínio

7️⃣ “Eu não poderia chamar isso de evento?”

Tecnicamente? Poder, pode.
Arquiteturalmente? Não deveria.

Porque você mistura dois mundos:

Evento fala o que aconteceu

Inbox fala o que chegou

E isso vira caos conceitual depois.*/

        /*
                Os 3 únicos conceitos que você precisa cravar no DSL
Command => intenção
Handler receiver => execução
Execution Policy => como isso acontece no tempo e na infraestrutura
Tudo o resto:
Outbox
Saga
Retry
Worker
Queue
Polling
👉 fica fora do DSL de domínio
👉 ou entra só como policy declarativa*/

        /*
         
         🔹 Existem dois tipos de declaração na DSL

Declaração estrutural (estado)

Entity

Column

Enum

FK

Constraints

Declaração comportamental (intenção)

Command

📌 Infra só enxerga comandos
📌 Entidade nunca “executa” nada*/

        public record Lista(List<int> lst);

        public UseCaseGroup(string name)
        {
            Name = name;
        }
        public List<Agent> Agents = new List<Agent>();

        public List<UseCaseSubGroup> UseCaseSubGroup = new List<UseCaseSubGroup>();
        public List<Saga> Saga = new List<Saga>();

        public Descricao Name { get; set; }

        public UseCaseGroup AddAgents(string agente)
        {
            return AddAgent(agente);
        }
        public UseCaseGroup AddUseCaseSubGrup(string name)
        {
            this.UseCaseSubGroup.Add(new UseCaseSubGroup(name));
            return this;
        }
        public UseCaseGroup AddCommand(string method, params object[] input)
        {
            UseCaseCommand _Method = new UseCaseCommand(method);
            _Method.UseCaseGroup = this;
            _Method.UseCaseSubGroup = this.UseCaseSubGroup.Last();

            if (input != null)
            {
                _Method.Inputs = new object[] { input.First() };
                _Method.Outputs = new object[] { input.Last() };
            }
            this.UseCaseSubGroup.Last().UseCaseCommand.Add(_Method);
            return this;
        }


        public UseCaseGroup AddSaga(string sagaName)
        {
            Saga _Saga = new Saga(sagaName);
            _Saga.UseCaseGroup = this;
            _Saga.UseCaseSubGroup = this.UseCaseSubGroup.Last();

            this.UseCaseSubGroup.Last().Saga.Add(_Saga);
            return this;
        }

        public UseCaseGroup AddStepGroup(string step)
        {
            SagaStep _SagaStep = new SagaStep(step);
            this.UseCaseSubGroup.Last().Saga.Last().SagaStep.Add(_SagaStep);
            return this;
        }
        public UseCaseGroup AddStep(string EventName)
        {
            SagaStepEvent _Event = new SagaStepEvent(EventName);
            this.UseCaseSubGroup.Last().Saga.Last().SagaStep.Last().InternalEvent.Add(_Event);
            this.UseCaseSubGroup.Last().Saga.Last().SagaStep.Last().LastEvent = _Event;

            return this;
        }
        public UseCaseGroup AddExternalEvent(string EventName)
        {
            SagaStepEvent _Event = new SagaStepEvent(EventName);
            this.UseCaseSubGroup.Last().Saga.Last().SagaStep.Last().ExternalEvent.Add(_Event);
            this.UseCaseSubGroup.Last().Saga.Last().SagaStep.Last().LastEvent = _Event;
            return this;
        }

        public UseCaseGroup AddOutBoxPollingWorker(QueueTopology queueTopology = null)
        {
            UseCaseCommand _Method = new UseCaseCommand($"{this.UseCaseSubGroup.Last().Saga.Last().SagaStep.Last().LastEvent.Name._value}{"OutBoxPollingWorker"}");
            _Method.UseCaseGroup = this;
            _Method.UseCaseSubGroup = this.UseCaseSubGroup.Last();
            
            object[] input = new object[2];
            input[0] = new Lista(new List<int>());
            input[1] = new Lista(new List<int>());
            _Method.Inputs = new object[] { input.First() };
            _Method.Outputs = new object[] { input.Last() };


            this.UseCaseSubGroup.Last().Saga.Last().SagaStep.Last().LastEvent.OutBoxPollingWorker = _Method;
            if (queueTopology != null)
                this.UseCaseSubGroup.Last().Saga.Last().SagaStep.Last().LastEvent.queueTopologyProducer = queueTopology;
            
            return this;
        }

        public UseCaseGroup AddInBoxPollingWorker()
        {
            UseCaseCommand _Method = new UseCaseCommand($"{this.UseCaseSubGroup.Last().Saga.Last().SagaStep.Last().LastEvent.Name._value}{"InBoxPollingWorker"}");
            _Method.UseCaseGroup = this;
            _Method.UseCaseSubGroup = this.UseCaseSubGroup.Last();
            
            object[] input = new object[2];
            input[0] = new Lista(new List<int>());
            input[1] = new Lista(new List<int>());
            _Method.Inputs = new object[] { input.First() };
            _Method.Outputs = new object[] { input.Last() };

            this.UseCaseSubGroup.Last().Saga.Last().SagaStep.Last().LastEvent.InBoxPollingWorker = _Method;
            return this;
        }


        public UseCaseGroup AddOutBoxPollingWorker(String exchangeName, ExchangeType exchangeType, string queueName, string routingKey)
        {

            QueueTopology queueTopology = new QueueTopology
            {
                Exchanges ={
                    new ExchangeDefinition{
                        Name = exchangeName,
                        Type = exchangeType,
                        Bindings ={
                            new QueueBindingDefinition{
                                QueueName = queueName,
                                RoutingKey = routingKey
                            }
                        }
                    }
                }
            };

            return AddOutBoxPollingWorker(queueTopology);
        }

        public UseCaseGroup AddQueueListenerWorker(String exchangeName, ExchangeType exchangeType, string queueName, string routingKey)
        {

            QueueTopology queueTopology = new QueueTopology
            {
                Exchanges ={
                    new ExchangeDefinition{
                        Name = exchangeName,
                        Type = exchangeType,
                        Bindings ={
                            new QueueBindingDefinition{
                                QueueName = queueName,
                                RoutingKey = routingKey
                            }
                        }
                    }
                }
            };

            return AddQueueListenerWorker(queueTopology);
        }
        public UseCaseGroup AddQueueListenerWorker(QueueTopology queueTopology)
        {
            this.UseCaseSubGroup.Last().Saga.Last().SagaStep.Last().LastEvent.queueTopology = queueTopology;

            UseCaseCommand _Method = new UseCaseCommand($"{this.UseCaseSubGroup.Last().Saga.Last().SagaStep.Last().LastEvent.Name._value}{"QueueListenerWorker"}");
            _Method.UseCaseGroup = this;
            _Method.UseCaseSubGroup = this.UseCaseSubGroup.Last();

            object[] input = new object[2];
            input[0] = new Lista(new List<int>());
            input[1] = new Lista(new List<int>());
            _Method.Inputs = new object[] { input.First() };
            _Method.Outputs = new object[] { input.Last() };

            this.UseCaseSubGroup.Last().Saga.Last().SagaStep.Last().LastEvent.QueueListenerWorker = _Method;
            return this;
        }




        public UseCaseGroup AddAgent(string name)
        {
            var col = new Agent(name, "", this);
            Agents.Add(col);
            return this;
        }

        public UseCaseGroup AddAgentMetod(string name, string description)
        {
            var method = new UseCaseCommand(this, name, description);
            return this.Agents.Last().AddMethod(method);
        }
        public UseCaseGroup AddMenu(string name)
        {
            var menu = new Menu(this, name);
            return this.Agents.Last().AddMenu(menu);
        }
        public UseCaseGroup AddSubMenu(string name)
        {
            var menu = new Menu(this, name);
            return this.Agents.Last().Menus.Last().AddSubMenu(menu).Hub;
        }
        public UseCaseGroup AddMenuOption(int id, string name)
        {
            return this.Agents.Last().Menus.Last().AddOption(id, name).Hub;
        }
        public UseCaseGroup AddSubMenuOption(int id, string name)
        {
            return this.Agents.Last().Menus.Last().SubMenus.Last().AddOption(id, name).Hub;
        }

        public UseCaseGroup Authorization(Authorization autorization)
        {
            this.UseCaseSubGroup.Last().UseCaseCommand.Last().Authorization = autorization;
            return this;
        }
        public UseCaseGroup AddScope(string scope)
        {
            this.UseCaseSubGroup.Last().UseCaseCommand.Last().AddScope(scope);
            return this;
        }

        public UseCaseGroup AddEntity(string entityName)
        {
            this.UseCaseSubGroup.Last().UseCaseCommand.Last().Entitys.Add(new Entity(entityName));
            return this;
        }

        public UseCaseGroup Strategy(Type type)
        {
            this.UseCaseSubGroup.Last().UseCaseCommand.Last().Estrategys.Add(new Dominio.Strategy(type));
            return this;
        }
        public UseCaseGroup AddAgregateStrategy(Type type)
        {
            this.UseCaseSubGroup.Last().UseCaseCommand.Last().Estrategys.Last().StrategyAgregate.Add(type);
            return this;
        }

        public UseCaseGroup IsWorker()
        {
            this.UseCaseSubGroup.Last().UseCaseCommand.Last().IsWorker = true;
            return this;
        }
        public UseCaseGroup IsListener()
        {
            this.UseCaseSubGroup.Last().UseCaseCommand.Last().IsListener = true;
            return this;
        }

        public UseCaseGroup AddEntity<T>()
        {
            this.UseCaseSubGroup.Last().UseCaseCommand.Last().Entitys.Add(new Entity(typeof(T).Name));
            return this;
        }
    }
}