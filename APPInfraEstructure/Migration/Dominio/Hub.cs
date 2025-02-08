
using Dominio.TiposPrimitivos;
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

        public Descricao Name { get; set; }

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
        public Hub AddMenu(string name)
        {
            var menu = new Menu(this, name);
            return this.Agents.Last().AddMenu(menu);
        }
        public Hub AddSubMenu(string name)
        {
            var menu = new Menu(this, name);
            return this.Agents.Last().Menus.Last().AddSubMenu(menu).Hub;
        }
        public Hub AddMenuOption(int id, string name)
        {
            return this.Agents.Last().Menus.Last().AddOption(id, name).Hub;
        }
        public Hub AddSubMenuOption(int id, string name)
        {
            return this.Agents.Last().Menus.Last().SubMenus.Last().AddOption(id, name).Hub;
        }
    }
}