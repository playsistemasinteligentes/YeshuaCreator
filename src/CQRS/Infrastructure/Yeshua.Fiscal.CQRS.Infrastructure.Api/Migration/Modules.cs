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
        Modules.Add(new Module("FIS", "Fiscal"));
        Modules.Add(new Module("DFE", "Documentos  Fiscais  Eletronicos"));
        var menuGroup1_0 = new Menu("Entrada Fiscal", "", "menuGroup");
        menuGroup1_0.AddSubMenu(new SubMenu("DocumentoFiscal", "/getMetaDataDocumentoFiscal", "crud", "", ""));
        menuGroup1_0.AddSubMenu(new SubMenu("DocumentoFiscalOriginario", "/getMetaDataDocumentoFiscalOriginario", "crud", "", ""));
        Modules.LastOrDefault().Menus.Add(menuGroup1_0);
        Modules.Add(new Module("CTE", "C T-e"));
        var menuGroup2_0 = new Menu("CT-e", "", "menuGroup");
        menuGroup2_0.AddSubMenu(new SubMenu("CTeEntradaOficial", "/getMetaDataCTeEntradaOficial", "crud", "", ""));
        menuGroup2_0.AddSubMenu(new SubMenu("CTeRomaneioConsolidado", "/getMetaDataCTeRomaneioConsolidado", "crud", "", ""));
        menuGroup2_0.AddSubMenu(new SubMenu("CTeSolicitacaoFiscal", "/getMetaDataCTeSolicitacaoFiscal", "crud", "", ""));
        menuGroup2_0.AddSubMenu(new SubMenu("CTeTentativaEmissao", "/getMetaDataCTeTentativaEmissao", "crud", "", ""));
        menuGroup2_0.AddSubMenu(new SubMenu("CTeSaidaMDFe", "/getMetaDataCTeSaidaMDFe", "crud", "", ""));
        Modules.LastOrDefault().Menus.Add(menuGroup2_0);
        Modules.LastOrDefault().Menus.Add(new Menu("CTeDocumentoOriginario", "/getMetaDataCTeDocumentoOriginario", "crud", "", ""));
        Modules.LastOrDefault().Menus.Add(new Menu("CTeParticipanteSnapshot", "/getMetaDataCTeParticipanteSnapshot", "crud", "", ""));
        Modules.Add(new Module("MDFE", "M D F-e"));
        var menuGroup3_0 = new Menu("MDF-e", "", "menuGroup");
        menuGroup3_0.AddSubMenu(new SubMenu("MDFe", "/getMetaDataMDFe", "crud", "", ""));
        menuGroup3_0.AddSubMenu(new SubMenu("MDFeSolicitacaoFiscal", "/getMetaDataMDFeSolicitacaoFiscal", "crud", "", ""));
        menuGroup3_0.AddSubMenu(new SubMenu("MDFeTentativaEmissao", "/getMetaDataMDFeTentativaEmissao", "crud", "", ""));
        menuGroup3_0.AddSubMenu(new SubMenu("MDFeEncerramento", "/getMetaDataMDFeEncerramento", "crud", "", ""));
        Modules.LastOrDefault().Menus.Add(menuGroup3_0);
        Modules.LastOrDefault().Menus.Add(new Menu("MDFeDocumentoOriginario", "/getMetaDataMDFeDocumentoOriginario", "crud", "", ""));
        Modules.LastOrDefault().Menus.Add(new Menu("MDFePercurso", "/getMetaDataMDFePercurso", "crud", "", ""));
        Modules.LastOrDefault().Menus.Add(new Menu("MDFeVeiculo", "/getMetaDataMDFeVeiculo", "crud", "", ""));
        Modules.LastOrDefault().Menus.Add(new Menu("MDFeCondutor", "/getMetaDataMDFeCondutor", "crud", "", ""));
        Modules.Add(new Module("NFE", "N F-e"));
        Modules.LastOrDefault().Menus.Add(new Menu("NFeProdutoSnapshot", "/getMetaDataNFeProdutoSnapshot", "crud", "", ""));
        Modules.Add(new Module("SEFAZ", "S E F A Z"));
        var menuGroup5_0 = new Menu("Operacao SEFAZ", "", "menuGroup");
        menuGroup5_0.AddSubMenu(new SubMenu("SefazEndpoint", "/getMetaDataSefazEndpoint", "crud", "", ""));
        menuGroup5_0.AddSubMenu(new SubMenu("CertificadoDigital", "/getMetaDataCertificadoDigital", "crud", "", ""));
        Modules.LastOrDefault().Menus.Add(menuGroup5_0);
        Modules.Add(new Module("ADM", "Administrativo"));
        Modules.LastOrDefault().Menus.Add(new Menu("yFileUpload", "/getMetaDatayFileUpload", "crud", "", ""));
        Modules.LastOrDefault().Menus.Add(new Menu("ySaga", "/getMetaDataySaga", "crud", "", ""));
        Modules.LastOrDefault().Menus.Add(new Menu("ySagaStep", "/getMetaDataySagaStep", "crud", "", ""));
        Modules.LastOrDefault().Menus.Add(new Menu("yOutbox", "/getMetaDatayOutbox", "crud", "", ""));
        Modules.LastOrDefault().Menus.Add(new Menu("yInbox", "/getMetaDatayInbox", "crud", "", ""));
        Modules.LastOrDefault().Menus.Add(new Menu("yToken", "/getMetaDatayToken", "crud", "", ""));
        Modules.LastOrDefault().Menus.Add(new Menu("yTenant", "/getMetaDatayTenant", "crud", "", ""));
        Modules.LastOrDefault().Menus.Add(new Menu("yUser", "/getMetaDatayUser", "crud", "", ""));
        Modules.LastOrDefault().Menus.Add(new Menu("yConfigArcteture", "/getMetaDatayConfigArcteture", "crud", "", ""));
        Modules.LastOrDefault().Menus.Add(new Menu("yConfigNotification", "/getMetaDatayConfigNotification", "crud", "", ""));
        Modules.LastOrDefault().Menus.Add(new Menu("yPerfil", "/getMetaDatayPerfil", "crud", "", ""));
        Modules.LastOrDefault().Menus.Add(new Menu("yTenantModule", "/getMetaDatayTenantModule", "crud", "", ""));
        Modules.LastOrDefault().Menus.Add(new Menu("yUserModule", "/getMetaDatayUserModule", "crud", "", ""));
        Modules.LastOrDefault().Menus.Add(new Menu("yPerfilGrant", "/getMetaDatayPerfilGrant", "crud", "", ""));
        Modules.LastOrDefault().Menus.Add(new Menu("yUserGrant", "/getMetaDatayUserGrant", "crud", "", ""));
    }
}

public static class StaticYeshuaModuleContinuations
{
    public static readonly List<ModuleContinuation> Continuations = new List<ModuleContinuation>();

    static StaticYeshuaModuleContinuations()
    {
        Continuations.Clear();
        Continuations.Add(new ModuleContinuation("APSADM", "CargaStandard", "publicarCargaProntaParaEmissaoFiscal", "CargaProntaParaEmissaoFiscal", 1, "Fiscal", "EmissaoFiscalCargaStandard", true, "StartsFrom", "", "", ""));
        Continuations.Add(new ModuleContinuation("Fiscal", "EmissaoFiscalCargaStandard", "publicarDocumentosFiscaisDaCargaConcluidos", "DocumentosFiscaisDaCargaConcluidos", 1, "APSADM", "CargaStandard", true, "Publishes", "YeshuaApi", "/yapi/APSADM/Inbox/YeshuaModuleEvent", "YeshuaModules:APSADM:BaseUrl"));
        Continuations.Add(new ModuleContinuation("Fiscal", "EncerramentoMDFeStandard", "publicarMDFeEncerrado", "MDFeEncerrado", 1, "APSADM", "CargaStandard", false, "Publishes", "YeshuaApi", "/yapi/APSADM/Inbox/YeshuaModuleEvent", "YeshuaModules:APSADM:BaseUrl"));
    }
}
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureModulesMigration