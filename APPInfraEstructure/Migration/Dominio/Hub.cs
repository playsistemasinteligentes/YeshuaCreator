
using Migration.Dominio.Schemas;

namespace Dominio
{
    public class Hub
    {
        public Hub(string name)
        {
            Name = name;
        }
        public List<Agent> Agents = new List<Agent>();

        public string Name { get; set; }

        public Hub AddAgents(string agente)
        {
            return AddAgent(agente);
        }
        public Hub AddAgent(string name)
        {
            var col = new Agent(name, "", this);
            Agents.Add(col);
            return this;
        }

        public Hub AddAgentMetod(string name, string description)
        {
            var method = new Method(this, name, description);
            return this.Agents.Last().AddMethod(method);
        }
        public Hub AddInteractionMenu(string name)
        {
            var menu = new InteractionMenu(this, name);
            return this.Agents.Last().AddInteractionMenu(menu);
        }
        public Hub AddOption(int id, string name)
        {
            return this.Agents.Last().InteractionMenu.Last().AddOption(id, name).Hub;
        }



    }
}