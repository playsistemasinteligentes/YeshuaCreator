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
        Modules.Add(new Module("APSADM", "A P S  A D M"));
        var menuGroup0_0 = new Menu("Planejamento", "", "menuGroup");
        menuGroup0_0.AddSubMenu(new SubMenu("Planejamento Transporte", "#planejamento-transporte", "customPage", "planejamento-transporte", "apsadm.planejamento-transporte.tela"));
        menuGroup0_0.AddSubMenu(new SubMenu("Roteiro", "/getMetaDataRoteiro", "crud", "", ""));
        menuGroup0_0.AddSubMenu(new SubMenu("ConsultaPedido", "/getMetaDataConsultaPedido", "crud", "", ""));
        menuGroup0_0.AddSubMenu(new SubMenu("RoteiroPedido", "/getMetaDataRoteiroPedido", "crud", "", ""));
        menuGroup0_0.AddSubMenu(new SubMenu("Carga", "/getMetaDataCarga", "crud", "", ""));
        menuGroup0_0.AddSubMenu(new SubMenu("CargaPrevista", "/getMetaDataCargaPrevista", "crud", "", ""));
        menuGroup0_0.AddSubMenu(new SubMenu("PedidoPlanejavel", "/getMetaDataPedidoPlanejavel", "crud", "", ""));
        menuGroup0_0.AddSubMenu(new SubMenu("CargaPlanejavel", "/getMetaDataCargaPlanejavel", "crud", "", ""));
        menuGroup0_0.AddSubMenu(new SubMenu("OpcaoPlanejamentoTransporte", "/getMetaDataOpcaoPlanejamentoTransporte", "crud", "", ""));
        menuGroup0_0.AddSubMenu(new SubMenu("CenarioPlanejamentoTransporte", "/getMetaDataCenarioPlanejamentoTransporte", "crud", "", ""));
        menuGroup0_0.AddSubMenu(new SubMenu("ExperienciaPlanejamentoTransporte", "/getMetaDataExperienciaPlanejamentoTransporte", "crud", "", ""));
        Modules.LastOrDefault().Menus.Add(menuGroup0_0);
        var menuGroup0_1 = new Menu("Tabelas Legado", "", "menuGroup");
        menuGroup0_1.AddSubMenu(new SubMenu("T_AGENDA_SCHEDULE", "/getMetaDataT_AGENDA_SCHEDULE", "crud", "", ""));
        menuGroup0_1.AddSubMenu(new SubMenu("T_Departamentos", "/getMetaDataT_Departamentos", "crud", "", ""));
        menuGroup0_1.AddSubMenu(new SubMenu("T_Favoritos", "/getMetaDataT_Favoritos", "crud", "", ""));
        menuGroup0_1.AddSubMenu(new SubMenu("T_FeedbackMovEstoque", "/getMetaDataT_FeedbackMovEstoque", "crud", "", ""));
        menuGroup0_1.AddSubMenu(new SubMenu("T_Grupo", "/getMetaDataT_Grupo", "crud", "", ""));
        menuGroup0_1.AddSubMenu(new SubMenu("T_HORARIO_RECEBIMENTO", "/getMetaDataT_HORARIO_RECEBIMENTO", "crud", "", ""));
        menuGroup0_1.AddSubMenu(new SubMenu("T_Indicadores", "/getMetaDataT_Indicadores", "crud", "", ""));
        menuGroup0_1.AddSubMenu(new SubMenu("T_MAQUINAS_EQUIPES", "/getMetaDataT_MAQUINAS_EQUIPES", "crud", "", ""));
        menuGroup0_1.AddSubMenu(new SubMenu("T_Medicoes", "/getMetaDataT_Medicoes", "crud", "", ""));
        menuGroup0_1.AddSubMenu(new SubMenu("T_Metas", "/getMetaDataT_Metas", "crud", "", ""));
        menuGroup0_1.AddSubMenu(new SubMenu("T_Negocio", "/getMetaDataT_Negocio", "crud", "", ""));
        menuGroup0_1.AddSubMenu(new SubMenu("T_PREFERENCIAS", "/getMetaDataT_PREFERENCIAS", "crud", "", ""));
        menuGroup0_1.AddSubMenu(new SubMenu("T_USER_GRUPO", "/getMetaDataT_USER_GRUPO", "crud", "", ""));
        Modules.LastOrDefault().Menus.Add(menuGroup0_1);
        var menuGroup0_3 = new Menu("Cadastros APS", "", "menuGroup");
        menuGroup0_3.AddSubMenu(new SubMenu("Produto", "/getMetaDataProduto", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Maquina", "/getMetaDataMaquina", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("GrupoMaquina", "/getMetaDataGrupoMaquina", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("TemplateDeTestes", "/getMetaDataTemplateDeTestes", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Auditoria", "/getMetaDataAuditoria", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Boletim", "/getMetaDataBoletim", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("BoletimEstudo", "/getMetaDataBoletimEstudo", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Calendario", "/getMetaDataCalendario", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("CalendarioDisponibilidadeVeiculos", "/getMetaDataCalendarioDisponibilidadeVeiculos", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Canhotos", "/getMetaDataCanhotos", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Cargos", "/getMetaDataCargos", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Cliente", "/getMetaDataCliente", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("ClpMedicoes", "/getMetaDataClpMedicoes", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("ClpMedicoesH", "/getMetaDataClpMedicoesH", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Colaborador", "/getMetaDataColaborador", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Compensacao", "/getMetaDataCompensacao", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("CondicaoPagamento", "/getMetaDataCondicaoPagamento", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Configuracoes", "/getMetaDataConfiguracoes", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Consultas", "/getMetaDataConsultas", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("ConsultasGrupos", "/getMetaDataConsultasGrupos", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("ConsultasIndicadores", "/getMetaDataConsultasIndicadores", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("CorConfiguracaoGrafico", "/getMetaDataCorConfiguracaoGrafico", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("CorridasOnduladeira", "/getMetaDataCorridasOnduladeira", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("CorridasOnduladeiraEstudo", "/getMetaDataCorridasOnduladeiraEstudo", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Cotas", "/getMetaDataCotas", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Enderecos", "/getMetaDataEnderecos", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Equipe", "/getMetaDataEquipe", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Estradas", "/getMetaDataEstradas", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("EstruturaCusto", "/getMetaDataEstruturaCusto", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("EstruturaImpressao", "/getMetaDataEstruturaImpressao", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("EstruturaProduto", "/getMetaDataEstruturaProduto", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Etiqueta", "/getMetaDataEtiqueta", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("FechamentoTeste", "/getMetaDataFechamentoTeste", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Feedback", "/getMetaDataFeedback", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("FilaProducao", "/getMetaDataFilaProducao", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("FilaProducaoPrevista", "/getMetaDataFilaProducaoPrevista", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("GrupoIndicador", "/getMetaDataGrupoIndicador", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("GrupoProdutoAbstrato", "/getMetaDataGrupoProdutoAbstrato", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("GrupoRecurso", "/getMetaDataGrupoRecurso", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("GrupoSegmento", "/getMetaDataGrupoSegmento", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Impressora", "/getMetaDataImpressora", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("IndicadoresDepartamentos", "/getMetaDataIndicadoresDepartamentos", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("IndicadoresDimencoes", "/getMetaDataIndicadoresDimencoes", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("IndicadoresFatosDimencoes", "/getMetaDataIndicadoresFatosDimencoes", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("IndicadoresPeriodosDimencoes", "/getMetaDataIndicadoresPeriodosDimencoes", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("InformacoesComplementares", "/getMetaDataInformacoesComplementares", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("InpecaoVisual", "/getMetaDataInpecaoVisual", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("ItemInspecao", "/getMetaDataItemInspecao", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("ItemTestavel", "/getMetaDataItemTestavel", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("ItensCalendario", "/getMetaDataItensCalendario", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("ItenCalendarioDisponibilidadeVeiculos", "/getMetaDataItenCalendarioDisponibilidadeVeiculos", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("ItenCarga", "/getMetaDataItenCarga", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("ItensEstruturaImpressao", "/getMetaDataItensEstruturaImpressao", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("ItensOrcamento", "/getMetaDataItensOrcamento", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("ItensPacked", "/getMetaDataItensPacked", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("LaudoTesteFisico", "/getMetaDataLaudoTesteFisico", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Logs", "/getMetaDataLogs", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("LogsDatabase", "/getMetaDataLogsDatabase", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Loock", "/getMetaDataLoock", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("LoteTeste", "/getMetaDataLoteTeste", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Lotes", "/getMetaDataLotes", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Mapa", "/getMetaDataMapa", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("MaquinaGrupoMaquina", "/getMetaDataMaquinaGrupoMaquina", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("MaquinaImpressora", "/getMetaDataMaquinaImpressora", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("MedicoesOnduladeira", "/getMetaDataMedicoesOnduladeira", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("MedidasTeste", "/getMetaDataMedidasTeste", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("MemoriaDeCalculo", "/getMetaDataMemoriaDeCalculo", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Mensagem", "/getMetaDataMensagem", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Meses", "/getMetaDataMeses", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("MovimentoEstoque", "/getMetaDataMovimentoEstoque", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Municipio", "/getMetaDataMunicipio", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("ObjetoControlavel", "/getMetaDataObjetoControlavel", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Observacoes", "/getMetaDataObservacoes", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Ocorrencia", "/getMetaDataOcorrencia", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Onda", "/getMetaDataOnda", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Operacoes", "/getMetaDataOperacoes", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("OptAlteracaoDimencoes", "/getMetaDataOptAlteracaoDimencoes", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Orcamento", "/getMetaDataOrcamento", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("OrderTrack", "/getMetaDataOrderTrack", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Order", "/getMetaDataOrder", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Param", "/getMetaDataParam", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("ParametrosDeCusto", "/getMetaDataParametrosDeCusto", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("PendenciasInterface", "/getMetaDataPendenciasInterface", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Perfil", "/getMetaDataPerfil", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("PerfilObjetoControlavel", "/getMetaDataPerfilObjetoControlavel", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("PeriodicidadeTeste", "/getMetaDataPeriodicidadeTeste", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("PlanoAmostralTeste", "/getMetaDataPlanoAmostralTeste", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Planoacao", "/getMetaDataPlanoacao", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Plotagem", "/getMetaDataPlotagem", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("PoliticaOnduladeira", "/getMetaDataPoliticaOnduladeira", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("PontosMapa", "/getMetaDataPontosMapa", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("ProtocoloOnduladeira", "/getMetaDataProtocoloOnduladeira", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Recursos", "/getMetaDataRecursos", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("RegistrosOnduladeira", "/getMetaDataRegistrosOnduladeira", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Representantes", "/getMetaDataRepresentantes", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("RespInspVisual", "/getMetaDataRespInspVisual", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("RestricoesDeRodagem", "/getMetaDataRestricoesDeRodagem", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("ResultLote", "/getMetaDataResultLote", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("ResultMedida", "/getMetaDataResultMedida", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Rodovias", "/getMetaDataRodovias", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("RotaRealizada", "/getMetaDataRotaRealizada", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("RotaPontosMapa", "/getMetaDataRotaPontosMapa", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Segmento", "/getMetaDataSegmento", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("SegmentosProdutos", "/getMetaDataSegmentosProdutos", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Semaforo", "/getMetaDataSemaforo", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("SubOcorrencia", "/getMetaDataSubOcorrencia", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Tabela", "/getMetaDataTabela", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("TargetProduto", "/getMetaDataTargetProduto", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("TemplatesGrupoMaquina", "/getMetaDataTemplatesGrupoMaquina", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("TemplatesMaquinas", "/getMetaDataTemplatesMaquinas", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("TempoSetupOnduladeira", "/getMetaDataTempoSetupOnduladeira", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("TemposLogisticos", "/getMetaDataTemposLogisticos", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("TesteFisico", "/getMetaDataTesteFisico", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("TipoABNT", "/getMetaDataTipoABNT", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("TipoCarroceria", "/getMetaDataTipoCarroceria", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("TipoDispositivo", "/getMetaDataTipoDispositivo", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("TipoDispositivoMaquina", "/getMetaDataTipoDispositivoMaquina", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("TipoInspecaoItens", "/getMetaDataTipoInspecaoItens", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("TipoInspecaoVisual", "/getMetaDataTipoInspecaoVisual", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("TipoMovimentoEstoque", "/getMetaDataTipoMovimentoEstoque", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("TipoOcorrencia", "/getMetaDataTipoOcorrencia", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("TipoTeste", "/getMetaDataTipoTeste", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("TipoVeiculo", "/getMetaDataTipoVeiculo", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Vinco", "/getMetaDataVinco", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("TiposVincoGruposProdutos", "/getMetaDataTiposVincoGruposProdutos", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("TiposVincoOndas", "/getMetaDataTiposVincoOndas", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("TiposVincoProdutos", "/getMetaDataTiposVincoProdutos", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Transportadora", "/getMetaDataTransportadora", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Turma", "/getMetaDataTurma", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Turno", "/getMetaDataTurno", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Unidade", "/getMetaDataUnidade", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("UnidadeMedida", "/getMetaDataUnidadeMedida", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Uniuser", "/getMetaDataUniuser", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Usuario", "/getMetaDataUsuario", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("UsuarioObjetoControlavel", "/getMetaDataUsuarioObjetoControlavel", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("UsuarioPerfil", "/getMetaDataUsuarioPerfil", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("UsuariosCarga", "/getMetaDataUsuariosCarga", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Variavel", "/getMetaDataVariavel", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("VariavelPlotagem", "/getMetaDataVariavelPlotagem", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Veiculo", "/getMetaDataVeiculo", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("VersaoCusto", "/getMetaDataVersaoCusto", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("VerssaoCusto", "/getMetaDataVerssaoCusto", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Cabvisao", "/getMetaDataCabvisao", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Movimentos", "/getMetaDataMovimentos", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Planocontas", "/getMetaDataPlanocontas", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Unidade_Unidade", "/getMetaDataUnidade_Unidade", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Visoes", "/getMetaDataVisoes", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("Relatorios", "/getMetaDataRelatorios", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("InspecaoVisual", "/getMetaDataInspecaoVisual", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("TemplateTipoInspecaoVisual", "/getMetaDataTemplateTipoInspecaoVisual", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("TemplateTipoTeste", "/getMetaDataTemplateTipoTeste", "crud", "", ""));
        menuGroup0_3.AddSubMenu(new SubMenu("TipoAvaliacao", "/getMetaDataTipoAvaliacao", "crud", "", ""));
        Modules.LastOrDefault().Menus.Add(menuGroup0_3);
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
        Continuations.Add(new ModuleContinuation("APSADM", "CargaStandard", "publicarCargaProntaParaEmissaoFiscal", "CargaProntaParaEmissaoFiscal", 1, "Fiscal", "EmissaoFiscalCargaStandard", true, "Publishes", "YeshuaApi", "/yapi/Fiscal/Inbox/YeshuaModuleEvent", "YeshuaModules:Fiscal:BaseUrl"));
    }
}
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureModulesMigration