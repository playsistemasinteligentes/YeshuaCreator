// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.CSharpCQRS.WriteIntegrationApiSeedSuiteFile
// </yeshua>

// <operational-spec>
// standard: OPERATIONAL_SUPPORT_ADOPTION_STANDARD
// gates: G7
// depths: D0
// severities: notApplicable
// modes: Live
// dataClassification: OperationalData
// identities: Application,Environment,Version
// technicalOutcomes: Success,Failure
// businessOutcomes: notApplicable
// evidence: TestDataSeed
// </operational-spec>

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Seed.Migration;

[Trait("TestPurpose", "TestDataSeed")]
[Trait("SpecificationGate", "G7")]
[Trait("DiagnosticDepth", "D0")]
[Trait("ExecutionMode", "Live")]
public sealed class ApiSeedCrudSuiteTests
{
    [IntegrationFact]
    public async Task Crud_seed_suite_should_create_entities_in_dependency_order_without_cleanup()
    {
        ApiSeedTestContext.Clear();

        var step1 = new GrupoMaquina.GrupoMaquinaCrudApiSeedTests();
        await step1.ExecuteAsync();

        var step2 = new TemplateDeTestes.TemplateDeTestesCrudApiSeedTests();
        await step2.ExecuteAsync();

        var step3 = new T_AGENDA_SCHEDULE.T_AGENDA_SCHEDULECrudApiSeedTests();
        await step3.ExecuteAsync();

        var step4 = new BoletimEstudo.BoletimEstudoCrudApiSeedTests();
        await step4.ExecuteAsync();

        var step5 = new Calendario.CalendarioCrudApiSeedTests();
        await step5.ExecuteAsync();

        var step6 = new CalendarioDisponibilidadeVeiculos.CalendarioDisponibilidadeVeiculosCrudApiSeedTests();
        await step6.ExecuteAsync();

        var step7 = new Canhotos.CanhotosCrudApiSeedTests();
        await step7.ExecuteAsync();

        var step8 = new CargaPrevista.CargaPrevistaCrudApiSeedTests();
        await step8.ExecuteAsync();

        var step9 = new Cargos.CargosCrudApiSeedTests();
        await step9.ExecuteAsync();

        var step10 = new ClpMedicoes.ClpMedicoesCrudApiSeedTests();
        await step10.ExecuteAsync();

        var step11 = new ClpMedicoesH.ClpMedicoesHCrudApiSeedTests();
        await step11.ExecuteAsync();

        var step12 = new CondicaoPagamento.CondicaoPagamentoCrudApiSeedTests();
        await step12.ExecuteAsync();

        var step13 = new Configuracoes.ConfiguracoesCrudApiSeedTests();
        await step13.ExecuteAsync();

        var step14 = new Consultas.ConsultasCrudApiSeedTests();
        await step14.ExecuteAsync();

        var step15 = new ConsultasGrupos.ConsultasGruposCrudApiSeedTests();
        await step15.ExecuteAsync();

        var step16 = new ConsultasIndicadores.ConsultasIndicadoresCrudApiSeedTests();
        await step16.ExecuteAsync();

        var step17 = new CorConfiguracaoGrafico.CorConfiguracaoGraficoCrudApiSeedTests();
        await step17.ExecuteAsync();

        var step18 = new CorridasOnduladeira.CorridasOnduladeiraCrudApiSeedTests();
        await step18.ExecuteAsync();

        var step19 = new CorridasOnduladeiraEstudo.CorridasOnduladeiraEstudoCrudApiSeedTests();
        await step19.ExecuteAsync();

        var step20 = new Cotas.CotasCrudApiSeedTests();
        await step20.ExecuteAsync();

        var step21 = new T_Departamentos.T_DepartamentosCrudApiSeedTests();
        await step21.ExecuteAsync();

        var step22 = new Enderecos.EnderecosCrudApiSeedTests();
        await step22.ExecuteAsync();

        var step23 = new Equipe.EquipeCrudApiSeedTests();
        await step23.ExecuteAsync();

        var step24 = new Estradas.EstradasCrudApiSeedTests();
        await step24.ExecuteAsync();

        var step25 = new EstruturaProduto.EstruturaProdutoCrudApiSeedTests();
        await step25.ExecuteAsync();

        var step26 = new FechamentoTeste.FechamentoTesteCrudApiSeedTests();
        await step26.ExecuteAsync();

        var step27 = new FilaProducaoPrevista.FilaProducaoPrevistaCrudApiSeedTests();
        await step27.ExecuteAsync();

        var step28 = new T_Grupo.T_GrupoCrudApiSeedTests();
        await step28.ExecuteAsync();

        var step29 = new GrupoRecurso.GrupoRecursoCrudApiSeedTests();
        await step29.ExecuteAsync();

        var step30 = new GrupoSegmento.GrupoSegmentoCrudApiSeedTests();
        await step30.ExecuteAsync();

        var step31 = new Impressora.ImpressoraCrudApiSeedTests();
        await step31.ExecuteAsync();

        var step32 = new InpecaoVisual.InpecaoVisualCrudApiSeedTests();
        await step32.ExecuteAsync();

        var step33 = new ItemInspecao.ItemInspecaoCrudApiSeedTests();
        await step33.ExecuteAsync();

        var step34 = new ItemTestavel.ItemTestavelCrudApiSeedTests();
        await step34.ExecuteAsync();

        var step35 = new ItenCalendarioDisponibilidadeVeiculos.ItenCalendarioDisponibilidadeVeiculosCrudApiSeedTests();
        await step35.ExecuteAsync();

        var step36 = new ItensEstruturaImpressao.ItensEstruturaImpressaoCrudApiSeedTests();
        await step36.ExecuteAsync();

        var step37 = new LaudoTesteFisico.LaudoTesteFisicoCrudApiSeedTests();
        await step37.ExecuteAsync();

        var step38 = new Logs.LogsCrudApiSeedTests();
        await step38.ExecuteAsync();

        var step39 = new Loock.LoockCrudApiSeedTests();
        await step39.ExecuteAsync();

        var step40 = new LoteTeste.LoteTesteCrudApiSeedTests();
        await step40.ExecuteAsync();

        var step41 = new Lotes.LotesCrudApiSeedTests();
        await step41.ExecuteAsync();

        var step42 = new MaquinaGrupoMaquina.MaquinaGrupoMaquinaCrudApiSeedTests();
        await step42.ExecuteAsync();

        var step43 = new MaquinaImpressora.MaquinaImpressoraCrudApiSeedTests();
        await step43.ExecuteAsync();

        var step44 = new T_MAQUINAS_EQUIPES.T_MAQUINAS_EQUIPESCrudApiSeedTests();
        await step44.ExecuteAsync();

        var step45 = new T_Medicoes.T_MedicoesCrudApiSeedTests();
        await step45.ExecuteAsync();

        var step46 = new MedicoesOnduladeira.MedicoesOnduladeiraCrudApiSeedTests();
        await step46.ExecuteAsync();

        var step47 = new MedidasTeste.MedidasTesteCrudApiSeedTests();
        await step47.ExecuteAsync();

        var step48 = new MemoriaDeCalculo.MemoriaDeCalculoCrudApiSeedTests();
        await step48.ExecuteAsync();

        var step49 = new Mensagem.MensagemCrudApiSeedTests();
        await step49.ExecuteAsync();

        var step50 = new Meses.MesesCrudApiSeedTests();
        await step50.ExecuteAsync();

        var step51 = new Municipio.MunicipioCrudApiSeedTests();
        await step51.ExecuteAsync();

        var step52 = new T_Negocio.T_NegocioCrudApiSeedTests();
        await step52.ExecuteAsync();

        var step53 = new ObjetoControlavel.ObjetoControlavelCrudApiSeedTests();
        await step53.ExecuteAsync();

        var step54 = new Operacoes.OperacoesCrudApiSeedTests();
        await step54.ExecuteAsync();

        var step55 = new OptAlteracaoDimencoes.OptAlteracaoDimencoesCrudApiSeedTests();
        await step55.ExecuteAsync();

        var step56 = new Param.ParamCrudApiSeedTests();
        await step56.ExecuteAsync();

        var step57 = new ParametrosDeCusto.ParametrosDeCustoCrudApiSeedTests();
        await step57.ExecuteAsync();

        var step58 = new PendenciasInterface.PendenciasInterfaceCrudApiSeedTests();
        await step58.ExecuteAsync();

        var step59 = new Perfil.PerfilCrudApiSeedTests();
        await step59.ExecuteAsync();

        var step60 = new PerfilObjetoControlavel.PerfilObjetoControlavelCrudApiSeedTests();
        await step60.ExecuteAsync();

        var step61 = new PeriodicidadeTeste.PeriodicidadeTesteCrudApiSeedTests();
        await step61.ExecuteAsync();

        var step62 = new PlanoAmostralTeste.PlanoAmostralTesteCrudApiSeedTests();
        await step62.ExecuteAsync();

        var step63 = new Plotagem.PlotagemCrudApiSeedTests();
        await step63.ExecuteAsync();

        var step64 = new PoliticaOnduladeira.PoliticaOnduladeiraCrudApiSeedTests();
        await step64.ExecuteAsync();

        var step65 = new PontosMapa.PontosMapaCrudApiSeedTests();
        await step65.ExecuteAsync();

        var step66 = new T_PREFERENCIAS.T_PREFERENCIASCrudApiSeedTests();
        await step66.ExecuteAsync();

        var step67 = new ProtocoloOnduladeira.ProtocoloOnduladeiraCrudApiSeedTests();
        await step67.ExecuteAsync();

        var step68 = new Recursos.RecursosCrudApiSeedTests();
        await step68.ExecuteAsync();

        var step69 = new RegistrosOnduladeira.RegistrosOnduladeiraCrudApiSeedTests();
        await step69.ExecuteAsync();

        var step70 = new Representantes.RepresentantesCrudApiSeedTests();
        await step70.ExecuteAsync();

        var step71 = new RespInspVisual.RespInspVisualCrudApiSeedTests();
        await step71.ExecuteAsync();

        var step72 = new RestricoesDeRodagem.RestricoesDeRodagemCrudApiSeedTests();
        await step72.ExecuteAsync();

        var step73 = new ResultLote.ResultLoteCrudApiSeedTests();
        await step73.ExecuteAsync();

        var step74 = new ResultMedida.ResultMedidaCrudApiSeedTests();
        await step74.ExecuteAsync();

        var step75 = new Rodovias.RodoviasCrudApiSeedTests();
        await step75.ExecuteAsync();

        var step76 = new RotaRealizada.RotaRealizadaCrudApiSeedTests();
        await step76.ExecuteAsync();

        var step77 = new RotaPontosMapa.RotaPontosMapaCrudApiSeedTests();
        await step77.ExecuteAsync();

        var step78 = new Segmento.SegmentoCrudApiSeedTests();
        await step78.ExecuteAsync();

        var step79 = new SegmentosProdutos.SegmentosProdutosCrudApiSeedTests();
        await step79.ExecuteAsync();

        var step80 = new Semaforo.SemaforoCrudApiSeedTests();
        await step80.ExecuteAsync();

        var step81 = new SubOcorrencia.SubOcorrenciaCrudApiSeedTests();
        await step81.ExecuteAsync();

        var step82 = new Tabela.TabelaCrudApiSeedTests();
        await step82.ExecuteAsync();

        var step83 = new TemplatesGrupoMaquina.TemplatesGrupoMaquinaCrudApiSeedTests();
        await step83.ExecuteAsync();

        var step84 = new TemplatesMaquinas.TemplatesMaquinasCrudApiSeedTests();
        await step84.ExecuteAsync();

        var step85 = new TemposLogisticos.TemposLogisticosCrudApiSeedTests();
        await step85.ExecuteAsync();

        var step86 = new TipoABNT.TipoABNTCrudApiSeedTests();
        await step86.ExecuteAsync();

        var step87 = new TipoCarroceria.TipoCarroceriaCrudApiSeedTests();
        await step87.ExecuteAsync();

        var step88 = new TipoDispositivo.TipoDispositivoCrudApiSeedTests();
        await step88.ExecuteAsync();

        var step89 = new TipoDispositivoMaquina.TipoDispositivoMaquinaCrudApiSeedTests();
        await step89.ExecuteAsync();

        var step90 = new TipoInspecaoItens.TipoInspecaoItensCrudApiSeedTests();
        await step90.ExecuteAsync();

        var step91 = new TipoInspecaoVisual.TipoInspecaoVisualCrudApiSeedTests();
        await step91.ExecuteAsync();

        var step92 = new TipoMovimentoEstoque.TipoMovimentoEstoqueCrudApiSeedTests();
        await step92.ExecuteAsync();

        var step93 = new TipoOcorrencia.TipoOcorrenciaCrudApiSeedTests();
        await step93.ExecuteAsync();

        var step94 = new TipoVeiculo.TipoVeiculoCrudApiSeedTests();
        await step94.ExecuteAsync();

        var step95 = new Vinco.VincoCrudApiSeedTests();
        await step95.ExecuteAsync();

        var step96 = new TiposVincoGruposProdutos.TiposVincoGruposProdutosCrudApiSeedTests();
        await step96.ExecuteAsync();

        var step97 = new TiposVincoOndas.TiposVincoOndasCrudApiSeedTests();
        await step97.ExecuteAsync();

        var step98 = new TiposVincoProdutos.TiposVincoProdutosCrudApiSeedTests();
        await step98.ExecuteAsync();

        var step99 = new Transportadora.TransportadoraCrudApiSeedTests();
        await step99.ExecuteAsync();

        var step100 = new Turma.TurmaCrudApiSeedTests();
        await step100.ExecuteAsync();

        var step101 = new Turno.TurnoCrudApiSeedTests();
        await step101.ExecuteAsync();

        var step102 = new Unidade.UnidadeCrudApiSeedTests();
        await step102.ExecuteAsync();

        var step103 = new UnidadeMedida.UnidadeMedidaCrudApiSeedTests();
        await step103.ExecuteAsync();

        var step104 = new Usuario.UsuarioCrudApiSeedTests();
        await step104.ExecuteAsync();

        var step105 = new UsuarioObjetoControlavel.UsuarioObjetoControlavelCrudApiSeedTests();
        await step105.ExecuteAsync();

        var step106 = new UsuarioPerfil.UsuarioPerfilCrudApiSeedTests();
        await step106.ExecuteAsync();

        var step107 = new UsuariosCarga.UsuariosCargaCrudApiSeedTests();
        await step107.ExecuteAsync();

        var step108 = new Variavel.VariavelCrudApiSeedTests();
        await step108.ExecuteAsync();

        var step109 = new VariavelPlotagem.VariavelPlotagemCrudApiSeedTests();
        await step109.ExecuteAsync();

        var step110 = new Veiculo.VeiculoCrudApiSeedTests();
        await step110.ExecuteAsync();

        var step111 = new VersaoCusto.VersaoCustoCrudApiSeedTests();
        await step111.ExecuteAsync();

        var step112 = new VerssaoCusto.VerssaoCustoCrudApiSeedTests();
        await step112.ExecuteAsync();

        var step113 = new Cabvisao.CabvisaoCrudApiSeedTests();
        await step113.ExecuteAsync();

        var step114 = new Planocontas.PlanocontasCrudApiSeedTests();
        await step114.ExecuteAsync();

        var step115 = new Unidade_Unidade.Unidade_UnidadeCrudApiSeedTests();
        await step115.ExecuteAsync();

        var step116 = new Visoes.VisoesCrudApiSeedTests();
        await step116.ExecuteAsync();

        var step117 = new Relatorios.RelatoriosCrudApiSeedTests();
        await step117.ExecuteAsync();

        var step118 = new InspecaoVisual.InspecaoVisualCrudApiSeedTests();
        await step118.ExecuteAsync();

        var step119 = new TemplateTipoInspecaoVisual.TemplateTipoInspecaoVisualCrudApiSeedTests();
        await step119.ExecuteAsync();

        var step120 = new TipoAvaliacao.TipoAvaliacaoCrudApiSeedTests();
        await step120.ExecuteAsync();

        var step121 = new ExperienciaPlanejamentoTransporte.ExperienciaPlanejamentoTransporteCrudApiSeedTests();
        await step121.ExecuteAsync();

        var step122 = new yFileUpload.yFileUploadCrudApiSeedTests();
        await step122.ExecuteAsync();

        var step123 = new ySaga.ySagaCrudApiSeedTests();
        await step123.ExecuteAsync();

        var step124 = new ySagaStep.ySagaStepCrudApiSeedTests();
        await step124.ExecuteAsync();

        var step125 = new yOutbox.yOutboxCrudApiSeedTests();
        await step125.ExecuteAsync();

        var step126 = new yInbox.yInboxCrudApiSeedTests();
        await step126.ExecuteAsync();

        var step127 = new yToken.yTokenCrudApiSeedTests();
        await step127.ExecuteAsync();

        var step128 = new yUser.yUserCrudApiSeedTests();
        await step128.ExecuteAsync();

        var step129 = new yConfigArcteture.yConfigArctetureCrudApiSeedTests();
        await step129.ExecuteAsync();

        var step130 = new yConfigNotification.yConfigNotificationCrudApiSeedTests();
        await step130.ExecuteAsync();

        var step131 = new yPerfil.yPerfilCrudApiSeedTests();
        await step131.ExecuteAsync();

        var step132 = new yModule.yModuleCrudApiSeedTests();
        await step132.ExecuteAsync();

        var step133 = new yTenantModule.yTenantModuleCrudApiSeedTests();
        await step133.ExecuteAsync();

        var step134 = new yUserModule.yUserModuleCrudApiSeedTests();
        await step134.ExecuteAsync();

        var step135 = new yGrant.yGrantCrudApiSeedTests();
        await step135.ExecuteAsync();

        var step136 = new yPerfilGrant.yPerfilGrantCrudApiSeedTests();
        await step136.ExecuteAsync();

        var step137 = new yUserGrant.yUserGrantCrudApiSeedTests();
        await step137.ExecuteAsync();

        var step138 = new Maquina.MaquinaCrudApiSeedTests();
        await step138.ExecuteAsync();

        var step139 = new Auditoria.AuditoriaCrudApiSeedTests();
        await step139.ExecuteAsync();

        var step140 = new Cliente.ClienteCrudApiSeedTests();
        await step140.ExecuteAsync();

        var step141 = new Colaborador.ColaboradorCrudApiSeedTests();
        await step141.ExecuteAsync();

        var step142 = new EstruturaImpressao.EstruturaImpressaoCrudApiSeedTests();
        await step142.ExecuteAsync();

        var step143 = new T_HORARIO_RECEBIMENTO.T_HORARIO_RECEBIMENTOCrudApiSeedTests();
        await step143.ExecuteAsync();

        var step144 = new T_Indicadores.T_IndicadoresCrudApiSeedTests();
        await step144.ExecuteAsync();

        var step145 = new IndicadoresDepartamentos.IndicadoresDepartamentosCrudApiSeedTests();
        await step145.ExecuteAsync();

        var step146 = new IndicadoresDimencoes.IndicadoresDimencoesCrudApiSeedTests();
        await step146.ExecuteAsync();

        var step147 = new IndicadoresFatosDimencoes.IndicadoresFatosDimencoesCrudApiSeedTests();
        await step147.ExecuteAsync();

        var step148 = new IndicadoresPeriodosDimencoes.IndicadoresPeriodosDimencoesCrudApiSeedTests();
        await step148.ExecuteAsync();

        var step149 = new ItensCalendario.ItensCalendarioCrudApiSeedTests();
        await step149.ExecuteAsync();

        var step150 = new LogsDatabase.LogsDatabaseCrudApiSeedTests();
        await step150.ExecuteAsync();

        var step151 = new Mapa.MapaCrudApiSeedTests();
        await step151.ExecuteAsync();

        var step152 = new T_Metas.T_MetasCrudApiSeedTests();
        await step152.ExecuteAsync();

        var step153 = new Observacoes.ObservacoesCrudApiSeedTests();
        await step153.ExecuteAsync();

        var step154 = new Ocorrencia.OcorrenciaCrudApiSeedTests();
        await step154.ExecuteAsync();

        var step155 = new Onda.OndaCrudApiSeedTests();
        await step155.ExecuteAsync();

        var step156 = new Orcamento.OrcamentoCrudApiSeedTests();
        await step156.ExecuteAsync();

        var step157 = new Order.OrderCrudApiSeedTests();
        await step157.ExecuteAsync();

        var step158 = new Planoacao.PlanoacaoCrudApiSeedTests();
        await step158.ExecuteAsync();

        var step159 = new TempoSetupOnduladeira.TempoSetupOnduladeiraCrudApiSeedTests();
        await step159.ExecuteAsync();

        var step160 = new TesteFisico.TesteFisicoCrudApiSeedTests();
        await step160.ExecuteAsync();

        var step161 = new TipoTeste.TipoTesteCrudApiSeedTests();
        await step161.ExecuteAsync();

        var step162 = new Uniuser.UniuserCrudApiSeedTests();
        await step162.ExecuteAsync();

        var step163 = new T_USER_GRUPO.T_USER_GRUPOCrudApiSeedTests();
        await step163.ExecuteAsync();

        var step164 = new Movimentos.MovimentosCrudApiSeedTests();
        await step164.ExecuteAsync();

        var step165 = new TemplateTipoTeste.TemplateTipoTesteCrudApiSeedTests();
        await step165.ExecuteAsync();

        var step166 = new Carga.CargaCrudApiSeedTests();
        await step166.ExecuteAsync();

        var step167 = new EstruturaCusto.EstruturaCustoCrudApiSeedTests();
        await step167.ExecuteAsync();

        var step168 = new Etiqueta.EtiquetaCrudApiSeedTests();
        await step168.ExecuteAsync();

        var step169 = new T_Favoritos.T_FavoritosCrudApiSeedTests();
        await step169.ExecuteAsync();

        var step170 = new Feedback.FeedbackCrudApiSeedTests();
        await step170.ExecuteAsync();

        var step171 = new FilaProducao.FilaProducaoCrudApiSeedTests();
        await step171.ExecuteAsync();

        var step172 = new GrupoIndicador.GrupoIndicadorCrudApiSeedTests();
        await step172.ExecuteAsync();

        var step173 = new GrupoProdutoAbstrato.GrupoProdutoAbstratoCrudApiSeedTests();
        await step173.ExecuteAsync();

        var step174 = new InformacoesComplementares.InformacoesComplementaresCrudApiSeedTests();
        await step174.ExecuteAsync();

        var step175 = new ItenCarga.ItenCargaCrudApiSeedTests();
        await step175.ExecuteAsync();

        var step176 = new ItensOrcamento.ItensOrcamentoCrudApiSeedTests();
        await step176.ExecuteAsync();

        var step177 = new ItensPacked.ItensPackedCrudApiSeedTests();
        await step177.ExecuteAsync();

        var step178 = new MovimentoEstoque.MovimentoEstoqueCrudApiSeedTests();
        await step178.ExecuteAsync();

        var step179 = new OrderTrack.OrderTrackCrudApiSeedTests();
        await step179.ExecuteAsync();

        var step180 = new TargetProduto.TargetProdutoCrudApiSeedTests();
        await step180.ExecuteAsync();

        var step181 = new Produto.ProdutoCrudApiSeedTests();
        await step181.ExecuteAsync();

        var step182 = new Roteiro.RoteiroCrudApiSeedTests();
        await step182.ExecuteAsync();

        var step183 = new Boletim.BoletimCrudApiSeedTests();
        await step183.ExecuteAsync();

        var step184 = new Compensacao.CompensacaoCrudApiSeedTests();
        await step184.ExecuteAsync();

        var step185 = new T_FeedbackMovEstoque.T_FeedbackMovEstoqueCrudApiSeedTests();
        await step185.ExecuteAsync();

    }
}
