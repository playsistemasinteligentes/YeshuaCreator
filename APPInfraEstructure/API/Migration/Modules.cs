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
        Modules.Add(new Module("PSI", "Clinica  Psicologia"));
        Modules.LastOrDefault().Menus.Add(new Menu("Clinica"));
        Modules.Add(new Module("ADM", "Administrativo"));
        Modules.LastOrDefault().Menus.Add(new Menu("Ytenant"));
        Modules.LastOrDefault().Menus.Add(new Menu("Yuser"));
        Modules.LastOrDefault().Menus.Add(new Menu("YconfigArcteture"));
        Modules.LastOrDefault().Menus.Add(new Menu("YconfigNotification"));
        Modules.LastOrDefault().Menus.Add(new Menu("Yperfil"));
        Modules.LastOrDefault().Menus.Add(new Menu("YtenantPermissionMudules"));
        Modules.LastOrDefault().Menus.Add(new Menu("YperfilPermissionActions"));
        Modules.LastOrDefault().Menus.Add(new Menu("YuserPermissionActions"));
    }
}
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureModulesMigration