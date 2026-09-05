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

public static class StaticModules
{
    public static readonly List<Module> Modules = new List<Module>();

    static StaticModules()
    {
        Modules.Clear();
        Modules.Add(new Module("APSADM", "A P S  A D M"));
        var menuGroup0 = new Menu("Planejamento", "", "menuGroup");
        menuGroup0.AddSubMenu(new SubMenu("Planejamento Transporte", "#planejamento-transporte", "customPage", "planejamento-transporte", "apsadm.planejamento-transporte.tela"));
        menuGroup0.AddSubMenu(new SubMenu("Roteiro", "/getMetaDataRoteiro", "crud", "", ""));
        menuGroup0.AddSubMenu(new SubMenu("ConsultaPedido", "/getMetaDataConsultaPedido", "crud", "", ""));
        menuGroup0.AddSubMenu(new SubMenu("RoteiroPedido", "/getMetaDataRoteiroPedido", "crud", "", ""));
        menuGroup0.AddSubMenu(new SubMenu("Carga", "/getMetaDataCarga", "crud", "", ""));
        menuGroup0.AddSubMenu(new SubMenu("CargaPrevista", "/getMetaDataCargaPrevista", "crud", "", ""));
        menuGroup0.AddSubMenu(new SubMenu("PedidoPlanejavel", "/getMetaDataPedidoPlanejavel", "crud", "", ""));
        menuGroup0.AddSubMenu(new SubMenu("CargaPlanejavel", "/getMetaDataCargaPlanejavel", "crud", "", ""));
        menuGroup0.AddSubMenu(new SubMenu("OpcaoPlanejamentoTransporte", "/getMetaDataOpcaoPlanejamentoTransporte", "crud", "", ""));
        menuGroup0.AddSubMenu(new SubMenu("CenarioPlanejamentoTransporte", "/getMetaDataCenarioPlanejamentoTransporte", "crud", "", ""));
        menuGroup0.AddSubMenu(new SubMenu("ExperienciaPlanejamentoTransporte", "/getMetaDataExperienciaPlanejamentoTransporte", "crud", "", ""));
        Modules.LastOrDefault().Menus.Add(menuGroup0);
        var menuGroup1 = new Menu("Tabelas Legado", "", "menuGroup");
        menuGroup1.AddSubMenu(new SubMenu("T_AGENDA_SCHEDULE", "/getMetaDataT_AGENDA_SCHEDULE", "crud", "", ""));
        menuGroup1.AddSubMenu(new SubMenu("T_Departamentos", "/getMetaDataT_Departamentos", "crud", "", ""));
        menuGroup1.AddSubMenu(new SubMenu("T_Favoritos", "/getMetaDataT_Favoritos", "crud", "", ""));
        menuGroup1.AddSubMenu(new SubMenu("T_FeedbackMovEstoque", "/getMetaDataT_FeedbackMovEstoque", "crud", "", ""));
        menuGroup1.AddSubMenu(new SubMenu("T_Grupo", "/getMetaDataT_Grupo", "crud", "", ""));
        menuGroup1.AddSubMenu(new SubMenu("T_HORARIO_RECEBIMENTO", "/getMetaDataT_HORARIO_RECEBIMENTO", "crud", "", ""));
        menuGroup1.AddSubMenu(new SubMenu("T_Indicadores", "/getMetaDataT_Indicadores", "crud", "", ""));
        menuGroup1.AddSubMenu(new SubMenu("T_MAQUINAS_EQUIPES", "/getMetaDataT_MAQUINAS_EQUIPES", "crud", "", ""));
        menuGroup1.AddSubMenu(new SubMenu("T_Medicoes", "/getMetaDataT_Medicoes", "crud", "", ""));
        menuGroup1.AddSubMenu(new SubMenu("T_Metas", "/getMetaDataT_Metas", "crud", "", ""));
        menuGroup1.AddSubMenu(new SubMenu("T_Negocio", "/getMetaDataT_Negocio", "crud", "", ""));
        menuGroup1.AddSubMenu(new SubMenu("T_PREFERENCIAS", "/getMetaDataT_PREFERENCIAS", "crud", "", ""));
        menuGroup1.AddSubMenu(new SubMenu("T_USER_GRUPO", "/getMetaDataT_USER_GRUPO", "crud", "", ""));
        Modules.LastOrDefault().Menus.Add(menuGroup1);
        var menuGroup3 = new Menu("Cadastros APS", "", "menuGroup");
        menuGroup3.AddSubMenu(new SubMenu("Produto", "/getMetaDataProduto", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Maquina", "/getMetaDataMaquina", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("GrupoMaquina", "/getMetaDataGrupoMaquina", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("TemplateDeTestes", "/getMetaDataTemplateDeTestes", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Auditoria", "/getMetaDataAuditoria", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Boletim", "/getMetaDataBoletim", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("BoletimEstudo", "/getMetaDataBoletimEstudo", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Calendario", "/getMetaDataCalendario", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("CalendarioDisponibilidadeVeiculos", "/getMetaDataCalendarioDisponibilidadeVeiculos", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Canhotos", "/getMetaDataCanhotos", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Cargos", "/getMetaDataCargos", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Cliente", "/getMetaDataCliente", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("ClpMedicoes", "/getMetaDataClpMedicoes", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("ClpMedicoesH", "/getMetaDataClpMedicoesH", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Colaborador", "/getMetaDataColaborador", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Compensacao", "/getMetaDataCompensacao", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("CondicaoPagamento", "/getMetaDataCondicaoPagamento", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Configuracoes", "/getMetaDataConfiguracoes", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Consultas", "/getMetaDataConsultas", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("ConsultasGrupos", "/getMetaDataConsultasGrupos", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("ConsultasIndicadores", "/getMetaDataConsultasIndicadores", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("CorConfiguracaoGrafico", "/getMetaDataCorConfiguracaoGrafico", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("CorridasOnduladeira", "/getMetaDataCorridasOnduladeira", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("CorridasOnduladeiraEstudo", "/getMetaDataCorridasOnduladeiraEstudo", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Cotas", "/getMetaDataCotas", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Enderecos", "/getMetaDataEnderecos", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Equipe", "/getMetaDataEquipe", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Estradas", "/getMetaDataEstradas", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("EstruturaCusto", "/getMetaDataEstruturaCusto", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("EstruturaImpressao", "/getMetaDataEstruturaImpressao", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("EstruturaProduto", "/getMetaDataEstruturaProduto", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Etiqueta", "/getMetaDataEtiqueta", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("FechamentoTeste", "/getMetaDataFechamentoTeste", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Feedback", "/getMetaDataFeedback", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("FilaProducao", "/getMetaDataFilaProducao", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("FilaProducaoPrevista", "/getMetaDataFilaProducaoPrevista", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("GrupoIndicador", "/getMetaDataGrupoIndicador", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("GrupoProdutoAbstrato", "/getMetaDataGrupoProdutoAbstrato", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("GrupoRecurso", "/getMetaDataGrupoRecurso", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("GrupoSegmento", "/getMetaDataGrupoSegmento", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Impressora", "/getMetaDataImpressora", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("IndicadoresDepartamentos", "/getMetaDataIndicadoresDepartamentos", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("IndicadoresDimencoes", "/getMetaDataIndicadoresDimencoes", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("IndicadoresFatosDimencoes", "/getMetaDataIndicadoresFatosDimencoes", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("IndicadoresPeriodosDimencoes", "/getMetaDataIndicadoresPeriodosDimencoes", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("InformacoesComplementares", "/getMetaDataInformacoesComplementares", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("InpecaoVisual", "/getMetaDataInpecaoVisual", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("ItemInspecao", "/getMetaDataItemInspecao", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("ItemTestavel", "/getMetaDataItemTestavel", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("ItensCalendario", "/getMetaDataItensCalendario", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("ItenCalendarioDisponibilidadeVeiculos", "/getMetaDataItenCalendarioDisponibilidadeVeiculos", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("ItenCarga", "/getMetaDataItenCarga", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("ItensEstruturaImpressao", "/getMetaDataItensEstruturaImpressao", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("ItensOrcamento", "/getMetaDataItensOrcamento", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("ItensPacked", "/getMetaDataItensPacked", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("LaudoTesteFisico", "/getMetaDataLaudoTesteFisico", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Logs", "/getMetaDataLogs", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("LogsDatabase", "/getMetaDataLogsDatabase", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Loock", "/getMetaDataLoock", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("LoteTeste", "/getMetaDataLoteTeste", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Lotes", "/getMetaDataLotes", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Mapa", "/getMetaDataMapa", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("MaquinaGrupoMaquina", "/getMetaDataMaquinaGrupoMaquina", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("MaquinaImpressora", "/getMetaDataMaquinaImpressora", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("MedicoesOnduladeira", "/getMetaDataMedicoesOnduladeira", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("MedidasTeste", "/getMetaDataMedidasTeste", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("MemoriaDeCalculo", "/getMetaDataMemoriaDeCalculo", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Mensagem", "/getMetaDataMensagem", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Meses", "/getMetaDataMeses", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("MovimentoEstoque", "/getMetaDataMovimentoEstoque", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Municipio", "/getMetaDataMunicipio", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("ObjetoControlavel", "/getMetaDataObjetoControlavel", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Observacoes", "/getMetaDataObservacoes", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Ocorrencia", "/getMetaDataOcorrencia", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Onda", "/getMetaDataOnda", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Operacoes", "/getMetaDataOperacoes", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("OptAlteracaoDimencoes", "/getMetaDataOptAlteracaoDimencoes", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Orcamento", "/getMetaDataOrcamento", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("OrderTrack", "/getMetaDataOrderTrack", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Order", "/getMetaDataOrder", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Param", "/getMetaDataParam", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("ParametrosDeCusto", "/getMetaDataParametrosDeCusto", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("PendenciasInterface", "/getMetaDataPendenciasInterface", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Perfil", "/getMetaDataPerfil", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("PerfilObjetoControlavel", "/getMetaDataPerfilObjetoControlavel", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("PeriodicidadeTeste", "/getMetaDataPeriodicidadeTeste", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("PlanoAmostralTeste", "/getMetaDataPlanoAmostralTeste", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Planoacao", "/getMetaDataPlanoacao", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Plotagem", "/getMetaDataPlotagem", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("PoliticaOnduladeira", "/getMetaDataPoliticaOnduladeira", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("PontosMapa", "/getMetaDataPontosMapa", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("ProtocoloOnduladeira", "/getMetaDataProtocoloOnduladeira", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Recursos", "/getMetaDataRecursos", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("RegistrosOnduladeira", "/getMetaDataRegistrosOnduladeira", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Representantes", "/getMetaDataRepresentantes", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("RespInspVisual", "/getMetaDataRespInspVisual", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("RestricoesDeRodagem", "/getMetaDataRestricoesDeRodagem", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("ResultLote", "/getMetaDataResultLote", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("ResultMedida", "/getMetaDataResultMedida", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Rodovias", "/getMetaDataRodovias", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("RotaRealizada", "/getMetaDataRotaRealizada", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("RotaPontosMapa", "/getMetaDataRotaPontosMapa", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Segmento", "/getMetaDataSegmento", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("SegmentosProdutos", "/getMetaDataSegmentosProdutos", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Semaforo", "/getMetaDataSemaforo", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("SubOcorrencia", "/getMetaDataSubOcorrencia", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Tabela", "/getMetaDataTabela", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("TargetProduto", "/getMetaDataTargetProduto", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("TemplatesGrupoMaquina", "/getMetaDataTemplatesGrupoMaquina", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("TemplatesMaquinas", "/getMetaDataTemplatesMaquinas", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("TempoSetupOnduladeira", "/getMetaDataTempoSetupOnduladeira", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("TemposLogisticos", "/getMetaDataTemposLogisticos", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("TesteFisico", "/getMetaDataTesteFisico", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("TipoABNT", "/getMetaDataTipoABNT", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("TipoCarroceria", "/getMetaDataTipoCarroceria", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("TipoDispositivo", "/getMetaDataTipoDispositivo", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("TipoDispositivoMaquina", "/getMetaDataTipoDispositivoMaquina", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("TipoInspecaoItens", "/getMetaDataTipoInspecaoItens", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("TipoInspecaoVisual", "/getMetaDataTipoInspecaoVisual", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("TipoMovimentoEstoque", "/getMetaDataTipoMovimentoEstoque", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("TipoOcorrencia", "/getMetaDataTipoOcorrencia", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("TipoTeste", "/getMetaDataTipoTeste", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("TipoVeiculo", "/getMetaDataTipoVeiculo", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Vinco", "/getMetaDataVinco", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("TiposVincoGruposProdutos", "/getMetaDataTiposVincoGruposProdutos", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("TiposVincoOndas", "/getMetaDataTiposVincoOndas", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("TiposVincoProdutos", "/getMetaDataTiposVincoProdutos", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Transportadora", "/getMetaDataTransportadora", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Turma", "/getMetaDataTurma", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Turno", "/getMetaDataTurno", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Unidade", "/getMetaDataUnidade", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("UnidadeMedida", "/getMetaDataUnidadeMedida", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Uniuser", "/getMetaDataUniuser", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Usuario", "/getMetaDataUsuario", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("UsuarioObjetoControlavel", "/getMetaDataUsuarioObjetoControlavel", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("UsuarioPerfil", "/getMetaDataUsuarioPerfil", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("UsuariosCarga", "/getMetaDataUsuariosCarga", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Variavel", "/getMetaDataVariavel", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("VariavelPlotagem", "/getMetaDataVariavelPlotagem", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Veiculo", "/getMetaDataVeiculo", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("VersaoCusto", "/getMetaDataVersaoCusto", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("VerssaoCusto", "/getMetaDataVerssaoCusto", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Cabvisao", "/getMetaDataCabvisao", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Movimentos", "/getMetaDataMovimentos", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Planocontas", "/getMetaDataPlanocontas", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Unidade_Unidade", "/getMetaDataUnidade_Unidade", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Visoes", "/getMetaDataVisoes", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("Relatorios", "/getMetaDataRelatorios", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("InspecaoVisual", "/getMetaDataInspecaoVisual", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("TemplateTipoInspecaoVisual", "/getMetaDataTemplateTipoInspecaoVisual", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("TemplateTipoTeste", "/getMetaDataTemplateTipoTeste", "crud", "", ""));
        menuGroup3.AddSubMenu(new SubMenu("TipoAvaliacao", "/getMetaDataTipoAvaliacao", "crud", "", ""));
        Modules.LastOrDefault().Menus.Add(menuGroup3);
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
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureModulesMigration