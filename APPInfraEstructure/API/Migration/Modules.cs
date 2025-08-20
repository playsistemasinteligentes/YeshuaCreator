namespace Modules
{
    public class Module
    {
        public string Key { get; set; }
        public string Title { get; set; }
        public List<Menu> Menus { get; set; } = new();

        public Module(string key, string title)
        {
            Key = key;
            Title = title;
        }

        public Module AddMenu(Menu menu)
        {
            Menus.Add(menu);
            return this;
        }
    }

    public class Menu
    {
        public string Title { get; set; }
        public List<SubMenu> SubMenus { get; set; } = new();

        public Menu(string title)
        {
            Title = title;
        }

        public Menu AddSubMenu(SubMenu submenu)
        {
            SubMenus.Add(submenu);
            return this;
        }
    }

    public class SubMenu
    {
        public string Title { get; set; }
        public string Route { get; set; }

        public SubMenu(string title, string route)
        {
            Title = title;
            Route = route;
        }
    }

public static class StaticModules
{
    public static readonly List<Module> Modules = new List<Module>();

    static StaticModules()
    {
        Modules.Clear();
        Modules.Add(new Module("PSI", ""));
        Modules.LastOrDefault().Menus.Add(new Menu("Especialidade"));
        Modules.LastOrDefault().Menus.Add(new Menu("Profissional"));
        Modules.LastOrDefault().Menus.Add(new Menu("DisponibilidadeAgenda"));
        Modules.LastOrDefault().Menus.Add(new Menu("GrupoServico"));
        Modules.LastOrDefault().Menus.Add(new Menu("Servico"));
        Modules.LastOrDefault().Menus.Add(new Menu("Paciente"));
        Modules.LastOrDefault().Menus.Add(new Menu("MovimentacaoFinanceira"));
        Modules.LastOrDefault().Menus.Add(new Menu("Sesoes"));
        Modules.Add(new Module("ADM", "Administrativo"));
        Modules.LastOrDefault().Menus.Add(new Menu("yTenant"));
        Modules.LastOrDefault().Menus.Add(new Menu("yUser"));
        Modules.LastOrDefault().Menus.Add(new Menu("yConfigArcteture"));
        Modules.LastOrDefault().Menus.Add(new Menu("yConfigNotification"));
        Modules.LastOrDefault().Menus.Add(new Menu("yPerfil"));
        Modules.LastOrDefault().Menus.Add(new Menu("yTenantModule"));
        Modules.LastOrDefault().Menus.Add(new Menu("yUserModule"));
        Modules.LastOrDefault().Menus.Add(new Menu("yPerfilGrant"));
        Modules.LastOrDefault().Menus.Add(new Menu("yUserGrant"));
    }
}
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureModulesMigration