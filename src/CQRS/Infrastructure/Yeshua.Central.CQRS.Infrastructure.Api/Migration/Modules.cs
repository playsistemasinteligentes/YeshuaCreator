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
        public string Endpoint { get; set; }
        public string Type { get; set; }
        public string Page { get; set; }
        public string Scope { get; set; }
        public List<SubMenu> SubMenus { get; set; } = new();

        public Menu(string title, string endpoint = "", string type = "crud", string page = "", string scope = "")
        {
            Title = title;
            Endpoint = endpoint;
            Type = type;
            Page = page;
            Scope = scope;
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
        public string Endpoint { get; set; }
        public string Type { get; set; }
        public string Page { get; set; }
        public string Scope { get; set; }

        public SubMenu(string title, string endpoint = "", string type = "crud", string page = "", string scope = "")
        {
            Title = title;
            Endpoint = endpoint;
            Type = type;
            Page = page;
            Scope = scope;
        }
    }

    public class ModuleContinuation
    {
        public string SourceModule { get; set; }
        public string SourceSaga { get; set; }
        public string SourceStep { get; set; }
        public string Contract { get; set; }
        public int ContractVersion { get; set; }
        public string TargetModule { get; set; }
        public string TargetSaga { get; set; }
        public bool Required { get; set; }
        public string Direction { get; set; }
        public string TransportKind { get; set; }
        public string Endpoint { get; set; }
        public string TargetBaseUrlConfigurationKey { get; set; }

        public ModuleContinuation(string sourceModule, string sourceSaga, string sourceStep, string contract, int contractVersion, string targetModule, string targetSaga, bool required, string direction, string transportKind = "", string endpoint = "", string targetBaseUrlConfigurationKey = "")
        {
            SourceModule = sourceModule;
            SourceSaga = sourceSaga;
            SourceStep = sourceStep;
            Contract = contract;
            ContractVersion = contractVersion;
            TargetModule = targetModule;
            TargetSaga = targetSaga;
            Required = required;
            Direction = direction;
            TransportKind = transportKind;
            Endpoint = endpoint;
            TargetBaseUrlConfigurationKey = targetBaseUrlConfigurationKey;
        }
    }

public static class StaticModules
{
    public static readonly List<Module> Modules = new List<Module>();

    static StaticModules()
    {
        Modules.Clear();
        Modules.Add(new Module("CENTRAL", "Central de  Autenticacao"));
        var menuGroup0_0 = new Menu("Plataforma", "", "menuGroup");
        menuGroup0_0.AddSubMenu(new SubMenu("Catalogo de Aplicativos", "#application-catalog", "customPage", "application-catalog", "central.catalogo.visualizar"));
        Modules[Modules.Count - 1].Menus.Add(menuGroup0_0);
        Modules.Add(new Module("ADM", "Administrativo"));
        Modules[Modules.Count - 1].Menus.Add(new Menu("yFileUpload", "/getMetaDatayFileUpload", "crud", "", ""));
        Modules[Modules.Count - 1].Menus.Add(new Menu("ySaga", "/getMetaDataySaga", "crud", "", ""));
        Modules[Modules.Count - 1].Menus.Add(new Menu("ySagaStep", "/getMetaDataySagaStep", "crud", "", ""));
        Modules[Modules.Count - 1].Menus.Add(new Menu("yOutbox", "/getMetaDatayOutbox", "crud", "", ""));
        Modules[Modules.Count - 1].Menus.Add(new Menu("yInbox", "/getMetaDatayInbox", "crud", "", ""));
        Modules[Modules.Count - 1].Menus.Add(new Menu("yToken", "/getMetaDatayToken", "crud", "", ""));
        Modules[Modules.Count - 1].Menus.Add(new Menu("yTenant", "/getMetaDatayTenant", "crud", "", ""));
        Modules[Modules.Count - 1].Menus.Add(new Menu("yUser", "/getMetaDatayUser", "crud", "", ""));
        Modules[Modules.Count - 1].Menus.Add(new Menu("yConfigArcteture", "/getMetaDatayConfigArcteture", "crud", "", ""));
        Modules[Modules.Count - 1].Menus.Add(new Menu("yConfigNotification", "/getMetaDatayConfigNotification", "crud", "", ""));
        Modules[Modules.Count - 1].Menus.Add(new Menu("yPerfil", "/getMetaDatayPerfil", "crud", "", ""));
        Modules[Modules.Count - 1].Menus.Add(new Menu("yTenantModule", "/getMetaDatayTenantModule", "crud", "", ""));
        Modules[Modules.Count - 1].Menus.Add(new Menu("yUserModule", "/getMetaDatayUserModule", "crud", "", ""));
        Modules[Modules.Count - 1].Menus.Add(new Menu("yPerfilGrant", "/getMetaDatayPerfilGrant", "crud", "", ""));
        Modules[Modules.Count - 1].Menus.Add(new Menu("yUserGrant", "/getMetaDatayUserGrant", "crud", "", ""));
    }
}

public static class StaticYeshuaModuleContinuations
{
    public static readonly List<ModuleContinuation> Continuations = new List<ModuleContinuation>();

    static StaticYeshuaModuleContinuations()
    {
        Continuations.Clear();
    }
}
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureModulesMigration