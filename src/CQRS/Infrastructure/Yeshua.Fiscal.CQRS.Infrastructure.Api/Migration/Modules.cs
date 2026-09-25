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
        var menuGroup0_0 = new Menu("Entrada Fiscal", "", "menuGroup");
        menuGroup0_0.AddSubMenu(new SubMenu("DocumentoFiscal", "/getMetaDataDocumentoFiscal", "crud", "", ""));
        menuGroup0_0.AddSubMenu(new SubMenu("DocumentoFiscalOriginario", "/getMetaDataDocumentoFiscalOriginario", "crud", "", ""));
        menuGroup0_0.AddSubMenu(new SubMenu("NFeProdutoSnapshot", "/getMetaDataNFeProdutoSnapshot", "crud", "", ""));
        Modules[Modules.Count - 1].Menus.Add(menuGroup0_0);
        var menuGroup0_1 = new Menu("CT-e", "", "menuGroup");
        menuGroup0_1.AddSubMenu(new SubMenu("CTeEntradaOficial", "/getMetaDataCTeEntradaOficial", "crud", "", ""));
        menuGroup0_1.AddSubMenu(new SubMenu("CTeRomaneioConsolidado", "/getMetaDataCTeRomaneioConsolidado", "crud", "", ""));
        menuGroup0_1.AddSubMenu(new SubMenu("CTeSolicitacaoFiscal", "/getMetaDataCTeSolicitacaoFiscal", "crud", "", ""));
        menuGroup0_1.AddSubMenu(new SubMenu("CTeTentativaEmissao", "/getMetaDataCTeTentativaEmissao", "crud", "", ""));
        menuGroup0_1.AddSubMenu(new SubMenu("CTeSaidaMDFe", "/getMetaDataCTeSaidaMDFe", "crud", "", ""));
        Modules[Modules.Count - 1].Menus.Add(menuGroup0_1);
        var menuGroup0_2 = new Menu("MDF-e", "", "menuGroup");
        menuGroup0_2.AddSubMenu(new SubMenu("MDFe", "/getMetaDataMDFe", "crud", "", ""));
        menuGroup0_2.AddSubMenu(new SubMenu("MDFeSolicitacaoFiscal", "/getMetaDataMDFeSolicitacaoFiscal", "crud", "", ""));
        menuGroup0_2.AddSubMenu(new SubMenu("MDFeTentativaEmissao", "/getMetaDataMDFeTentativaEmissao", "crud", "", ""));
        menuGroup0_2.AddSubMenu(new SubMenu("MDFeEncerramento", "/getMetaDataMDFeEncerramento", "crud", "", ""));
        Modules[Modules.Count - 1].Menus.Add(menuGroup0_2);
        var menuGroup0_3 = new Menu("Operacao SEFAZ", "", "menuGroup");
        menuGroup0_3.AddSubMenu(new SubMenu("SefazEndpoint", "/getMetaDataSefazEndpoint", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("CertificadoDigital", "/getMetaDataCertificadoDigital", "crud", "", ""));
        Modules[Modules.Count - 1].Menus.Add(menuGroup0_3);
        var menuGroup0_4 = new Menu("Contingencia Fiscal", "", "menuGroup");
        menuGroup0_4.AddSubMenu(new SubMenu("Nova Contingencia Fiscal", "#contingencia-fiscal", "customPage", "contingencia-fiscal", "fiscal.contingencia.tela"));
        menuGroup0_4.AddSubMenu(new SubMenu("EntradaFiscalContingencia", "/getMetaDataEntradaFiscalContingencia", "crud", "", ""));
        menuGroup0_4.AddSubMenu(new SubMenu("ContingenciaFiscal", "/getMetaDataContingenciaFiscal", "crud", "", ""));
        Modules[Modules.Count - 1].Menus.Add(menuGroup0_4);
        var menuGroup0_5 = new Menu("Emissoes", "", "menuGroup");
        menuGroup0_5.AddSubMenu(new SubMenu("EmissaoFiscalTransporte", "/getMetaDataEmissaoFiscalTransporte", "crud", "", ""));
        Modules[Modules.Count - 1].Menus.Add(menuGroup0_5);
        var menuGroup0_6 = new Menu("Documentos Fiscais", "", "menuGroup");
        menuGroup0_6.AddSubMenu(new SubMenu("EmissaoFiscalTransporteDocumento", "/getMetaDataEmissaoFiscalTransporteDocumento", "crud", "", ""));
        Modules[Modules.Count - 1].Menus.Add(menuGroup0_6);
        Modules[Modules.Count - 1].Menus.Add(new Menu("CTeDocumentoOriginario", "/getMetaDataCTeDocumentoOriginario", "crud", "", ""));
        Modules[Modules.Count - 1].Menus.Add(new Menu("CTeParticipanteSnapshot", "/getMetaDataCTeParticipanteSnapshot", "crud", "", ""));
        Modules[Modules.Count - 1].Menus.Add(new Menu("MDFeDocumentoOriginario", "/getMetaDataMDFeDocumentoOriginario", "crud", "", ""));
        Modules[Modules.Count - 1].Menus.Add(new Menu("MDFePercurso", "/getMetaDataMDFePercurso", "crud", "", ""));
        Modules[Modules.Count - 1].Menus.Add(new Menu("MDFeVeiculo", "/getMetaDataMDFeVeiculo", "crud", "", ""));
        Modules[Modules.Count - 1].Menus.Add(new Menu("MDFeCondutor", "/getMetaDataMDFeCondutor", "crud", "", ""));
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
        Continuations.Add(new ModuleContinuation("APSADM", "CargaStandard", "publicarCargaProntaParaEmissaoFiscal", "CargaProntaParaEmissaoFiscal", 1, "Fiscal", "EmissaoFiscalCargaStandard", true, "StartsFrom", "", "", ""));
        Continuations.Add(new ModuleContinuation("Fiscal", "EmissaoFiscalCargaStandard", "publicarDocumentosFiscaisDaCargaConcluidos", "DocumentosFiscaisDaCargaConcluidos", 1, "APSADM", "CargaStandard", true, "Publishes", "YeshuaApi", "/yapi/APSADM/Inbox/YeshuaModuleEvent", "YeshuaModules:APSADM:BaseUrl"));
        Continuations.Add(new ModuleContinuation("Fiscal", "EncerramentoMDFeStandard", "publicarMDFeEncerrado", "MDFeEncerrado", 1, "APSADM", "CargaStandard", false, "Publishes", "YeshuaApi", "/yapi/APSADM/Inbox/YeshuaModuleEvent", "YeshuaModules:APSADM:BaseUrl"));
    }
}
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureModulesMigration