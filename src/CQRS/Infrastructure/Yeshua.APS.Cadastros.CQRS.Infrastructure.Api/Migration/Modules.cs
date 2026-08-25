// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureModulesMigration
// </yeshua>

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
        Modules.Add(new Module("CAD", "Cadastros  A P S"));
        Modules.LastOrDefault().Menus.Add(new Menu("Produto"));
        Modules.LastOrDefault().Menus.Add(new Menu("Maquina"));
        Modules.LastOrDefault().Menus.Add(new Menu("GrupoMaquina"));
        Modules.LastOrDefault().Menus.Add(new Menu("TemplateDeTestes"));
        Modules.LastOrDefault().Menus.Add(new Menu("Roteiro"));
        Modules.Add(new Module("ADM", "Administrativo"));
        Modules.LastOrDefault().Menus.Add(new Menu("yFileUpload"));
        Modules.LastOrDefault().Menus.Add(new Menu("ySaga"));
        Modules.LastOrDefault().Menus.Add(new Menu("ySagaStep"));
        Modules.LastOrDefault().Menus.Add(new Menu("yOutbox"));
        Modules.LastOrDefault().Menus.Add(new Menu("yInbox"));
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