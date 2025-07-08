
using Dominio.TiposPrimitivos;

namespace Dominio
{
    public class Menu
    {
        public Menu(UseCaseGroup hub, string name)
        {
            Hub = hub;
            Name = name;
            Options = new Dictionary<int, Descricao>();
            SubMenus = new List<Menu>();
        }

        public UseCaseGroup Hub { get; set; }
        public Descricao Name { get; set; }
        public Dictionary<int, Descricao> Options { get; set; }
        public List<Menu> SubMenus { get; set; }

        public Menu AddOption(int id, string name)
        {
            Options.Add(id, name);
            return this;
        }

        public Menu AddSubMenu(Menu menu)
        {
            SubMenus.Add(menu);
            return this;
        }
    }
}