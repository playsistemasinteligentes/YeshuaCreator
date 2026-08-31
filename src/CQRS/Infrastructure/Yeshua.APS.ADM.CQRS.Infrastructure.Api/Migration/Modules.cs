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
        Modules.Add(new Module("APSADM", "A P S  A D M"));
        Modules.LastOrDefault().Menus.Add(new Menu("Produto"));
        Modules.LastOrDefault().Menus.Add(new Menu("Maquina"));
        Modules.LastOrDefault().Menus.Add(new Menu("GrupoMaquina"));
        Modules.LastOrDefault().Menus.Add(new Menu("TemplateDeTestes"));
        Modules.LastOrDefault().Menus.Add(new Menu("Roteiro"));
        Modules.LastOrDefault().Menus.Add(new Menu("ConsultaPedido"));
        Modules.LastOrDefault().Menus.Add(new Menu("RoteiroPedido"));
        Modules.LastOrDefault().Menus.Add(new Menu("T_AGENDA_SCHEDULE"));
        Modules.LastOrDefault().Menus.Add(new Menu("Auditoria"));
        Modules.LastOrDefault().Menus.Add(new Menu("Boletim"));
        Modules.LastOrDefault().Menus.Add(new Menu("BoletimEstudo"));
        Modules.LastOrDefault().Menus.Add(new Menu("Calendario"));
        Modules.LastOrDefault().Menus.Add(new Menu("CalendarioDisponibilidadeVeiculos"));
        Modules.LastOrDefault().Menus.Add(new Menu("Canhotos"));
        Modules.LastOrDefault().Menus.Add(new Menu("Carga"));
        Modules.LastOrDefault().Menus.Add(new Menu("CargaPrevista"));
        Modules.LastOrDefault().Menus.Add(new Menu("Cargos"));
        Modules.LastOrDefault().Menus.Add(new Menu("Cliente"));
        Modules.LastOrDefault().Menus.Add(new Menu("ClpMedicoes"));
        Modules.LastOrDefault().Menus.Add(new Menu("ClpMedicoesH"));
        Modules.LastOrDefault().Menus.Add(new Menu("Colaborador"));
        Modules.LastOrDefault().Menus.Add(new Menu("Compensacao"));
        Modules.LastOrDefault().Menus.Add(new Menu("CondicaoPagamento"));
        Modules.LastOrDefault().Menus.Add(new Menu("Configuracoes"));
        Modules.LastOrDefault().Menus.Add(new Menu("Consultas"));
        Modules.LastOrDefault().Menus.Add(new Menu("ConsultasGrupos"));
        Modules.LastOrDefault().Menus.Add(new Menu("ConsultasIndicadores"));
        Modules.LastOrDefault().Menus.Add(new Menu("CorConfiguracaoGrafico"));
        Modules.LastOrDefault().Menus.Add(new Menu("CorridasOnduladeira"));
        Modules.LastOrDefault().Menus.Add(new Menu("CorridasOnduladeiraEstudo"));
        Modules.LastOrDefault().Menus.Add(new Menu("Cotas"));
        Modules.LastOrDefault().Menus.Add(new Menu("T_Departamentos"));
        Modules.LastOrDefault().Menus.Add(new Menu("Enderecos"));
        Modules.LastOrDefault().Menus.Add(new Menu("Equipe"));
        Modules.LastOrDefault().Menus.Add(new Menu("Estradas"));
        Modules.LastOrDefault().Menus.Add(new Menu("EstruturaCusto"));
        Modules.LastOrDefault().Menus.Add(new Menu("EstruturaImpressao"));
        Modules.LastOrDefault().Menus.Add(new Menu("EstruturaProduto"));
        Modules.LastOrDefault().Menus.Add(new Menu("Etiqueta"));
        Modules.LastOrDefault().Menus.Add(new Menu("T_Favoritos"));
        Modules.LastOrDefault().Menus.Add(new Menu("FechamentoTeste"));
        Modules.LastOrDefault().Menus.Add(new Menu("Feedback"));
        Modules.LastOrDefault().Menus.Add(new Menu("T_FeedbackMovEstoque"));
        Modules.LastOrDefault().Menus.Add(new Menu("FilaProducao"));
        Modules.LastOrDefault().Menus.Add(new Menu("FilaProducaoPrevista"));
        Modules.LastOrDefault().Menus.Add(new Menu("T_Grupo"));
        Modules.LastOrDefault().Menus.Add(new Menu("GrupoIndicador"));
        Modules.LastOrDefault().Menus.Add(new Menu("GrupoProdutoAbstrato"));
        Modules.LastOrDefault().Menus.Add(new Menu("GrupoRecurso"));
        Modules.LastOrDefault().Menus.Add(new Menu("GrupoSegmento"));
        Modules.LastOrDefault().Menus.Add(new Menu("T_HORARIO_RECEBIMENTO"));
        Modules.LastOrDefault().Menus.Add(new Menu("Impressora"));
        Modules.LastOrDefault().Menus.Add(new Menu("T_Indicadores"));
        Modules.LastOrDefault().Menus.Add(new Menu("IndicadoresDepartamentos"));
        Modules.LastOrDefault().Menus.Add(new Menu("IndicadoresDimencoes"));
        Modules.LastOrDefault().Menus.Add(new Menu("IndicadoresFatosDimencoes"));
        Modules.LastOrDefault().Menus.Add(new Menu("IndicadoresPeriodosDimencoes"));
        Modules.LastOrDefault().Menus.Add(new Menu("InformacoesComplementares"));
        Modules.LastOrDefault().Menus.Add(new Menu("InpecaoVisual"));
        Modules.LastOrDefault().Menus.Add(new Menu("ItemInspecao"));
        Modules.LastOrDefault().Menus.Add(new Menu("ItemTestavel"));
        Modules.LastOrDefault().Menus.Add(new Menu("ItensCalendario"));
        Modules.LastOrDefault().Menus.Add(new Menu("ItenCalendarioDisponibilidadeVeiculos"));
        Modules.LastOrDefault().Menus.Add(new Menu("ItenCarga"));
        Modules.LastOrDefault().Menus.Add(new Menu("ItensEstruturaImpressao"));
        Modules.LastOrDefault().Menus.Add(new Menu("ItensOrcamento"));
        Modules.LastOrDefault().Menus.Add(new Menu("ItensPacked"));
        Modules.LastOrDefault().Menus.Add(new Menu("LaudoTesteFisico"));
        Modules.LastOrDefault().Menus.Add(new Menu("Logs"));
        Modules.LastOrDefault().Menus.Add(new Menu("LogsDatabase"));
        Modules.LastOrDefault().Menus.Add(new Menu("Loock"));
        Modules.LastOrDefault().Menus.Add(new Menu("LoteTeste"));
        Modules.LastOrDefault().Menus.Add(new Menu("Lotes"));
        Modules.LastOrDefault().Menus.Add(new Menu("Mapa"));
        Modules.LastOrDefault().Menus.Add(new Menu("MaquinaGrupoMaquina"));
        Modules.LastOrDefault().Menus.Add(new Menu("MaquinaImpressora"));
        Modules.LastOrDefault().Menus.Add(new Menu("T_MAQUINAS_EQUIPES"));
        Modules.LastOrDefault().Menus.Add(new Menu("T_Medicoes"));
        Modules.LastOrDefault().Menus.Add(new Menu("MedicoesOnduladeira"));
        Modules.LastOrDefault().Menus.Add(new Menu("MedidasTeste"));
        Modules.LastOrDefault().Menus.Add(new Menu("MemoriaDeCalculo"));
        Modules.LastOrDefault().Menus.Add(new Menu("Mensagem"));
        Modules.LastOrDefault().Menus.Add(new Menu("Meses"));
        Modules.LastOrDefault().Menus.Add(new Menu("T_Metas"));
        Modules.LastOrDefault().Menus.Add(new Menu("MovimentoEstoque"));
        Modules.LastOrDefault().Menus.Add(new Menu("Municipio"));
        Modules.LastOrDefault().Menus.Add(new Menu("T_Negocio"));
        Modules.LastOrDefault().Menus.Add(new Menu("ObjetoControlavel"));
        Modules.LastOrDefault().Menus.Add(new Menu("Observacoes"));
        Modules.LastOrDefault().Menus.Add(new Menu("Ocorrencia"));
        Modules.LastOrDefault().Menus.Add(new Menu("Onda"));
        Modules.LastOrDefault().Menus.Add(new Menu("Operacoes"));
        Modules.LastOrDefault().Menus.Add(new Menu("OptAlteracaoDimencoes"));
        Modules.LastOrDefault().Menus.Add(new Menu("Orcamento"));
        Modules.LastOrDefault().Menus.Add(new Menu("OrderTrack"));
        Modules.LastOrDefault().Menus.Add(new Menu("Order"));
        Modules.LastOrDefault().Menus.Add(new Menu("Param"));
        Modules.LastOrDefault().Menus.Add(new Menu("ParametrosDeCusto"));
        Modules.LastOrDefault().Menus.Add(new Menu("PendenciasInterface"));
        Modules.LastOrDefault().Menus.Add(new Menu("Perfil"));
        Modules.LastOrDefault().Menus.Add(new Menu("PerfilObjetoControlavel"));
        Modules.LastOrDefault().Menus.Add(new Menu("PeriodicidadeTeste"));
        Modules.LastOrDefault().Menus.Add(new Menu("PlanoAmostralTeste"));
        Modules.LastOrDefault().Menus.Add(new Menu("Planoacao"));
        Modules.LastOrDefault().Menus.Add(new Menu("Plotagem"));
        Modules.LastOrDefault().Menus.Add(new Menu("PoliticaOnduladeira"));
        Modules.LastOrDefault().Menus.Add(new Menu("PontosMapa"));
        Modules.LastOrDefault().Menus.Add(new Menu("T_PREFERENCIAS"));
        Modules.LastOrDefault().Menus.Add(new Menu("ProtocoloOnduladeira"));
        Modules.LastOrDefault().Menus.Add(new Menu("Recursos"));
        Modules.LastOrDefault().Menus.Add(new Menu("RegistrosOnduladeira"));
        Modules.LastOrDefault().Menus.Add(new Menu("Representantes"));
        Modules.LastOrDefault().Menus.Add(new Menu("RespInspVisual"));
        Modules.LastOrDefault().Menus.Add(new Menu("RestricoesDeRodagem"));
        Modules.LastOrDefault().Menus.Add(new Menu("ResultLote"));
        Modules.LastOrDefault().Menus.Add(new Menu("ResultMedida"));
        Modules.LastOrDefault().Menus.Add(new Menu("Rodovias"));
        Modules.LastOrDefault().Menus.Add(new Menu("RotaRealizada"));
        Modules.LastOrDefault().Menus.Add(new Menu("RotaPontosMapa"));
        Modules.LastOrDefault().Menus.Add(new Menu("Segmento"));
        Modules.LastOrDefault().Menus.Add(new Menu("SegmentosProdutos"));
        Modules.LastOrDefault().Menus.Add(new Menu("Semaforo"));
        Modules.LastOrDefault().Menus.Add(new Menu("SubOcorrencia"));
        Modules.LastOrDefault().Menus.Add(new Menu("Tabela"));
        Modules.LastOrDefault().Menus.Add(new Menu("TargetProduto"));
        Modules.LastOrDefault().Menus.Add(new Menu("TemplatesGrupoMaquina"));
        Modules.LastOrDefault().Menus.Add(new Menu("TemplatesMaquinas"));
        Modules.LastOrDefault().Menus.Add(new Menu("TempoSetupOnduladeira"));
        Modules.LastOrDefault().Menus.Add(new Menu("TemposLogisticos"));
        Modules.LastOrDefault().Menus.Add(new Menu("TesteFisico"));
        Modules.LastOrDefault().Menus.Add(new Menu("TipoABNT"));
        Modules.LastOrDefault().Menus.Add(new Menu("TipoCarroceria"));
        Modules.LastOrDefault().Menus.Add(new Menu("TipoDispositivo"));
        Modules.LastOrDefault().Menus.Add(new Menu("TipoDispositivoMaquina"));
        Modules.LastOrDefault().Menus.Add(new Menu("TipoInspecaoItens"));
        Modules.LastOrDefault().Menus.Add(new Menu("TipoInspecaoVisual"));
        Modules.LastOrDefault().Menus.Add(new Menu("TipoMovimentoEstoque"));
        Modules.LastOrDefault().Menus.Add(new Menu("TipoOcorrencia"));
        Modules.LastOrDefault().Menus.Add(new Menu("TipoTeste"));
        Modules.LastOrDefault().Menus.Add(new Menu("TipoVeiculo"));
        Modules.LastOrDefault().Menus.Add(new Menu("Vinco"));
        Modules.LastOrDefault().Menus.Add(new Menu("TiposVincoGruposProdutos"));
        Modules.LastOrDefault().Menus.Add(new Menu("TiposVincoOndas"));
        Modules.LastOrDefault().Menus.Add(new Menu("TiposVincoProdutos"));
        Modules.LastOrDefault().Menus.Add(new Menu("Transportadora"));
        Modules.LastOrDefault().Menus.Add(new Menu("Turma"));
        Modules.LastOrDefault().Menus.Add(new Menu("Turno"));
        Modules.LastOrDefault().Menus.Add(new Menu("Unidade"));
        Modules.LastOrDefault().Menus.Add(new Menu("UnidadeMedida"));
        Modules.LastOrDefault().Menus.Add(new Menu("Uniuser"));
        Modules.LastOrDefault().Menus.Add(new Menu("T_USER_GRUPO"));
        Modules.LastOrDefault().Menus.Add(new Menu("Usuario"));
        Modules.LastOrDefault().Menus.Add(new Menu("UsuarioObjetoControlavel"));
        Modules.LastOrDefault().Menus.Add(new Menu("UsuarioPerfil"));
        Modules.LastOrDefault().Menus.Add(new Menu("UsuariosCarga"));
        Modules.LastOrDefault().Menus.Add(new Menu("Variavel"));
        Modules.LastOrDefault().Menus.Add(new Menu("VariavelPlotagem"));
        Modules.LastOrDefault().Menus.Add(new Menu("Veiculo"));
        Modules.LastOrDefault().Menus.Add(new Menu("VersaoCusto"));
        Modules.LastOrDefault().Menus.Add(new Menu("VerssaoCusto"));
        Modules.LastOrDefault().Menus.Add(new Menu("Cabvisao"));
        Modules.LastOrDefault().Menus.Add(new Menu("Movimentos"));
        Modules.LastOrDefault().Menus.Add(new Menu("Planocontas"));
        Modules.LastOrDefault().Menus.Add(new Menu("Unidade_Unidade"));
        Modules.LastOrDefault().Menus.Add(new Menu("Visoes"));
        Modules.LastOrDefault().Menus.Add(new Menu("Relatorios"));
        Modules.LastOrDefault().Menus.Add(new Menu("InspecaoVisual"));
        Modules.LastOrDefault().Menus.Add(new Menu("TemplateTipoInspecaoVisual"));
        Modules.LastOrDefault().Menus.Add(new Menu("TemplateTipoTeste"));
        Modules.LastOrDefault().Menus.Add(new Menu("TipoAvaliacao"));
        Modules.LastOrDefault().Menus.Add(new Menu("PedidoPlanejavel"));
        Modules.LastOrDefault().Menus.Add(new Menu("CargaPlanejavel"));
        Modules.LastOrDefault().Menus.Add(new Menu("OpcaoPlanejamentoTransporte"));
        Modules.LastOrDefault().Menus.Add(new Menu("CenarioPlanejamentoTransporte"));
        Modules.LastOrDefault().Menus.Add(new Menu("ExperienciaPlanejamentoTransporte"));
        Modules.Add(new Module("ADM", "Administrativo"));
        Modules.LastOrDefault().Menus.Add(new Menu("yFileUpload"));
        Modules.LastOrDefault().Menus.Add(new Menu("ySaga"));
        Modules.LastOrDefault().Menus.Add(new Menu("ySagaStep"));
        Modules.LastOrDefault().Menus.Add(new Menu("yOutbox"));
        Modules.LastOrDefault().Menus.Add(new Menu("yInbox"));
        Modules.LastOrDefault().Menus.Add(new Menu("yToken"));
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