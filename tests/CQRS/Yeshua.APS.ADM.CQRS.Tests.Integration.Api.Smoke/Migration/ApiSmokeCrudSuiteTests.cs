// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.CSharpCQRS.WriteIntegrationApiSmokeSuiteFile
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
// evidence: TechnicalSmoke
// </operational-spec>

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Smoke.Migration;

[Trait("TestPurpose", "TechnicalSmoke")]
[Trait("SpecificationGate", "G7")]
[Trait("DiagnosticDepth", "D0")]
[Trait("ExecutionMode", "Live")]
public sealed class ApiSmokeCrudSuiteTests
{
    [IntegrationFact]
    public async Task Crud_smoke_suite_should_run_entities_in_dependency_order()
    {
        ApiSmokeTestContext.Clear();

        var deleteSteps = new Stack<Func<Task>>();
        var deleteErrors = new List<Exception>();
        Exception? testError = null;

        try
        {
            var step1 = new GrupoMaquina.GrupoMaquinaCrudApiSmokeTests();
            deleteSteps.Push(step1.DeleteAsync);
            await step1.ExecuteAsync();

            var step2 = new TemplateDeTestes.TemplateDeTestesCrudApiSmokeTests();
            deleteSteps.Push(step2.DeleteAsync);
            await step2.ExecuteAsync();

            var step3 = new T_AGENDA_SCHEDULE.T_AGENDA_SCHEDULECrudApiSmokeTests();
            deleteSteps.Push(step3.DeleteAsync);
            await step3.ExecuteAsync();

            var step4 = new BoletimEstudo.BoletimEstudoCrudApiSmokeTests();
            deleteSteps.Push(step4.DeleteAsync);
            await step4.ExecuteAsync();

            var step5 = new Calendario.CalendarioCrudApiSmokeTests();
            deleteSteps.Push(step5.DeleteAsync);
            await step5.ExecuteAsync();

            var step6 = new CalendarioDisponibilidadeVeiculos.CalendarioDisponibilidadeVeiculosCrudApiSmokeTests();
            deleteSteps.Push(step6.DeleteAsync);
            await step6.ExecuteAsync();

            var step7 = new Canhotos.CanhotosCrudApiSmokeTests();
            deleteSteps.Push(step7.DeleteAsync);
            await step7.ExecuteAsync();

            var step8 = new CargaPrevista.CargaPrevistaCrudApiSmokeTests();
            deleteSteps.Push(step8.DeleteAsync);
            await step8.ExecuteAsync();

            var step9 = new Cargos.CargosCrudApiSmokeTests();
            deleteSteps.Push(step9.DeleteAsync);
            await step9.ExecuteAsync();

            var step10 = new ClpMedicoes.ClpMedicoesCrudApiSmokeTests();
            deleteSteps.Push(step10.DeleteAsync);
            await step10.ExecuteAsync();

            var step11 = new ClpMedicoesH.ClpMedicoesHCrudApiSmokeTests();
            deleteSteps.Push(step11.DeleteAsync);
            await step11.ExecuteAsync();

            var step12 = new CondicaoPagamento.CondicaoPagamentoCrudApiSmokeTests();
            deleteSteps.Push(step12.DeleteAsync);
            await step12.ExecuteAsync();

            var step13 = new Configuracoes.ConfiguracoesCrudApiSmokeTests();
            deleteSteps.Push(step13.DeleteAsync);
            await step13.ExecuteAsync();

            var step14 = new Consultas.ConsultasCrudApiSmokeTests();
            deleteSteps.Push(step14.DeleteAsync);
            await step14.ExecuteAsync();

            var step15 = new ConsultasGrupos.ConsultasGruposCrudApiSmokeTests();
            deleteSteps.Push(step15.DeleteAsync);
            await step15.ExecuteAsync();

            var step16 = new ConsultasIndicadores.ConsultasIndicadoresCrudApiSmokeTests();
            deleteSteps.Push(step16.DeleteAsync);
            await step16.ExecuteAsync();

            var step17 = new CorConfiguracaoGrafico.CorConfiguracaoGraficoCrudApiSmokeTests();
            deleteSteps.Push(step17.DeleteAsync);
            await step17.ExecuteAsync();

            var step18 = new CorridasOnduladeira.CorridasOnduladeiraCrudApiSmokeTests();
            deleteSteps.Push(step18.DeleteAsync);
            await step18.ExecuteAsync();

            var step19 = new CorridasOnduladeiraEstudo.CorridasOnduladeiraEstudoCrudApiSmokeTests();
            deleteSteps.Push(step19.DeleteAsync);
            await step19.ExecuteAsync();

            var step20 = new Cotas.CotasCrudApiSmokeTests();
            deleteSteps.Push(step20.DeleteAsync);
            await step20.ExecuteAsync();

            var step21 = new T_Departamentos.T_DepartamentosCrudApiSmokeTests();
            deleteSteps.Push(step21.DeleteAsync);
            await step21.ExecuteAsync();

            var step22 = new Enderecos.EnderecosCrudApiSmokeTests();
            deleteSteps.Push(step22.DeleteAsync);
            await step22.ExecuteAsync();

            var step23 = new Equipe.EquipeCrudApiSmokeTests();
            deleteSteps.Push(step23.DeleteAsync);
            await step23.ExecuteAsync();

            var step24 = new Estradas.EstradasCrudApiSmokeTests();
            deleteSteps.Push(step24.DeleteAsync);
            await step24.ExecuteAsync();

            var step25 = new EstruturaProduto.EstruturaProdutoCrudApiSmokeTests();
            deleteSteps.Push(step25.DeleteAsync);
            await step25.ExecuteAsync();

            var step26 = new FechamentoTeste.FechamentoTesteCrudApiSmokeTests();
            deleteSteps.Push(step26.DeleteAsync);
            await step26.ExecuteAsync();

            var step27 = new FilaProducaoPrevista.FilaProducaoPrevistaCrudApiSmokeTests();
            deleteSteps.Push(step27.DeleteAsync);
            await step27.ExecuteAsync();

            var step28 = new T_Grupo.T_GrupoCrudApiSmokeTests();
            deleteSteps.Push(step28.DeleteAsync);
            await step28.ExecuteAsync();

            var step29 = new GrupoRecurso.GrupoRecursoCrudApiSmokeTests();
            deleteSteps.Push(step29.DeleteAsync);
            await step29.ExecuteAsync();

            var step30 = new GrupoSegmento.GrupoSegmentoCrudApiSmokeTests();
            deleteSteps.Push(step30.DeleteAsync);
            await step30.ExecuteAsync();

            var step31 = new Impressora.ImpressoraCrudApiSmokeTests();
            deleteSteps.Push(step31.DeleteAsync);
            await step31.ExecuteAsync();

            var step32 = new InpecaoVisual.InpecaoVisualCrudApiSmokeTests();
            deleteSteps.Push(step32.DeleteAsync);
            await step32.ExecuteAsync();

            var step33 = new ItemInspecao.ItemInspecaoCrudApiSmokeTests();
            deleteSteps.Push(step33.DeleteAsync);
            await step33.ExecuteAsync();

            var step34 = new ItemTestavel.ItemTestavelCrudApiSmokeTests();
            deleteSteps.Push(step34.DeleteAsync);
            await step34.ExecuteAsync();

            var step35 = new ItenCalendarioDisponibilidadeVeiculos.ItenCalendarioDisponibilidadeVeiculosCrudApiSmokeTests();
            deleteSteps.Push(step35.DeleteAsync);
            await step35.ExecuteAsync();

            var step36 = new ItensEstruturaImpressao.ItensEstruturaImpressaoCrudApiSmokeTests();
            deleteSteps.Push(step36.DeleteAsync);
            await step36.ExecuteAsync();

            var step37 = new LaudoTesteFisico.LaudoTesteFisicoCrudApiSmokeTests();
            deleteSteps.Push(step37.DeleteAsync);
            await step37.ExecuteAsync();

            var step38 = new Logs.LogsCrudApiSmokeTests();
            deleteSteps.Push(step38.DeleteAsync);
            await step38.ExecuteAsync();

            var step39 = new Loock.LoockCrudApiSmokeTests();
            deleteSteps.Push(step39.DeleteAsync);
            await step39.ExecuteAsync();

            var step40 = new LoteTeste.LoteTesteCrudApiSmokeTests();
            deleteSteps.Push(step40.DeleteAsync);
            await step40.ExecuteAsync();

            var step41 = new Lotes.LotesCrudApiSmokeTests();
            deleteSteps.Push(step41.DeleteAsync);
            await step41.ExecuteAsync();

            var step42 = new MaquinaGrupoMaquina.MaquinaGrupoMaquinaCrudApiSmokeTests();
            deleteSteps.Push(step42.DeleteAsync);
            await step42.ExecuteAsync();

            var step43 = new MaquinaImpressora.MaquinaImpressoraCrudApiSmokeTests();
            deleteSteps.Push(step43.DeleteAsync);
            await step43.ExecuteAsync();

            var step44 = new T_MAQUINAS_EQUIPES.T_MAQUINAS_EQUIPESCrudApiSmokeTests();
            deleteSteps.Push(step44.DeleteAsync);
            await step44.ExecuteAsync();

            var step45 = new T_Medicoes.T_MedicoesCrudApiSmokeTests();
            deleteSteps.Push(step45.DeleteAsync);
            await step45.ExecuteAsync();

            var step46 = new MedicoesOnduladeira.MedicoesOnduladeiraCrudApiSmokeTests();
            deleteSteps.Push(step46.DeleteAsync);
            await step46.ExecuteAsync();

            var step47 = new MedidasTeste.MedidasTesteCrudApiSmokeTests();
            deleteSteps.Push(step47.DeleteAsync);
            await step47.ExecuteAsync();

            var step48 = new MemoriaDeCalculo.MemoriaDeCalculoCrudApiSmokeTests();
            deleteSteps.Push(step48.DeleteAsync);
            await step48.ExecuteAsync();

            var step49 = new Mensagem.MensagemCrudApiSmokeTests();
            deleteSteps.Push(step49.DeleteAsync);
            await step49.ExecuteAsync();

            var step50 = new Meses.MesesCrudApiSmokeTests();
            deleteSteps.Push(step50.DeleteAsync);
            await step50.ExecuteAsync();

            var step51 = new Municipio.MunicipioCrudApiSmokeTests();
            deleteSteps.Push(step51.DeleteAsync);
            await step51.ExecuteAsync();

            var step52 = new T_Negocio.T_NegocioCrudApiSmokeTests();
            deleteSteps.Push(step52.DeleteAsync);
            await step52.ExecuteAsync();

            var step53 = new ObjetoControlavel.ObjetoControlavelCrudApiSmokeTests();
            deleteSteps.Push(step53.DeleteAsync);
            await step53.ExecuteAsync();

            var step54 = new Operacoes.OperacoesCrudApiSmokeTests();
            deleteSteps.Push(step54.DeleteAsync);
            await step54.ExecuteAsync();

            var step55 = new OptAlteracaoDimencoes.OptAlteracaoDimencoesCrudApiSmokeTests();
            deleteSteps.Push(step55.DeleteAsync);
            await step55.ExecuteAsync();

            var step56 = new Param.ParamCrudApiSmokeTests();
            deleteSteps.Push(step56.DeleteAsync);
            await step56.ExecuteAsync();

            var step57 = new ParametrosDeCusto.ParametrosDeCustoCrudApiSmokeTests();
            deleteSteps.Push(step57.DeleteAsync);
            await step57.ExecuteAsync();

            var step58 = new PendenciasInterface.PendenciasInterfaceCrudApiSmokeTests();
            deleteSteps.Push(step58.DeleteAsync);
            await step58.ExecuteAsync();

            var step59 = new Perfil.PerfilCrudApiSmokeTests();
            deleteSteps.Push(step59.DeleteAsync);
            await step59.ExecuteAsync();

            var step60 = new PerfilObjetoControlavel.PerfilObjetoControlavelCrudApiSmokeTests();
            deleteSteps.Push(step60.DeleteAsync);
            await step60.ExecuteAsync();

            var step61 = new PeriodicidadeTeste.PeriodicidadeTesteCrudApiSmokeTests();
            deleteSteps.Push(step61.DeleteAsync);
            await step61.ExecuteAsync();

            var step62 = new PlanoAmostralTeste.PlanoAmostralTesteCrudApiSmokeTests();
            deleteSteps.Push(step62.DeleteAsync);
            await step62.ExecuteAsync();

            var step63 = new Plotagem.PlotagemCrudApiSmokeTests();
            deleteSteps.Push(step63.DeleteAsync);
            await step63.ExecuteAsync();

            var step64 = new PoliticaOnduladeira.PoliticaOnduladeiraCrudApiSmokeTests();
            deleteSteps.Push(step64.DeleteAsync);
            await step64.ExecuteAsync();

            var step65 = new PontosMapa.PontosMapaCrudApiSmokeTests();
            deleteSteps.Push(step65.DeleteAsync);
            await step65.ExecuteAsync();

            var step66 = new T_PREFERENCIAS.T_PREFERENCIASCrudApiSmokeTests();
            deleteSteps.Push(step66.DeleteAsync);
            await step66.ExecuteAsync();

            var step67 = new ProtocoloOnduladeira.ProtocoloOnduladeiraCrudApiSmokeTests();
            deleteSteps.Push(step67.DeleteAsync);
            await step67.ExecuteAsync();

            var step68 = new Recursos.RecursosCrudApiSmokeTests();
            deleteSteps.Push(step68.DeleteAsync);
            await step68.ExecuteAsync();

            var step69 = new RegistrosOnduladeira.RegistrosOnduladeiraCrudApiSmokeTests();
            deleteSteps.Push(step69.DeleteAsync);
            await step69.ExecuteAsync();

            var step70 = new Representantes.RepresentantesCrudApiSmokeTests();
            deleteSteps.Push(step70.DeleteAsync);
            await step70.ExecuteAsync();

            var step71 = new RespInspVisual.RespInspVisualCrudApiSmokeTests();
            deleteSteps.Push(step71.DeleteAsync);
            await step71.ExecuteAsync();

            var step72 = new RestricoesDeRodagem.RestricoesDeRodagemCrudApiSmokeTests();
            deleteSteps.Push(step72.DeleteAsync);
            await step72.ExecuteAsync();

            var step73 = new ResultLote.ResultLoteCrudApiSmokeTests();
            deleteSteps.Push(step73.DeleteAsync);
            await step73.ExecuteAsync();

            var step74 = new ResultMedida.ResultMedidaCrudApiSmokeTests();
            deleteSteps.Push(step74.DeleteAsync);
            await step74.ExecuteAsync();

            var step75 = new Rodovias.RodoviasCrudApiSmokeTests();
            deleteSteps.Push(step75.DeleteAsync);
            await step75.ExecuteAsync();

            var step76 = new RotaRealizada.RotaRealizadaCrudApiSmokeTests();
            deleteSteps.Push(step76.DeleteAsync);
            await step76.ExecuteAsync();

            var step77 = new RotaPontosMapa.RotaPontosMapaCrudApiSmokeTests();
            deleteSteps.Push(step77.DeleteAsync);
            await step77.ExecuteAsync();

            var step78 = new Segmento.SegmentoCrudApiSmokeTests();
            deleteSteps.Push(step78.DeleteAsync);
            await step78.ExecuteAsync();

            var step79 = new SegmentosProdutos.SegmentosProdutosCrudApiSmokeTests();
            deleteSteps.Push(step79.DeleteAsync);
            await step79.ExecuteAsync();

            var step80 = new Semaforo.SemaforoCrudApiSmokeTests();
            deleteSteps.Push(step80.DeleteAsync);
            await step80.ExecuteAsync();

            var step81 = new SubOcorrencia.SubOcorrenciaCrudApiSmokeTests();
            deleteSteps.Push(step81.DeleteAsync);
            await step81.ExecuteAsync();

            var step82 = new Tabela.TabelaCrudApiSmokeTests();
            deleteSteps.Push(step82.DeleteAsync);
            await step82.ExecuteAsync();

            var step83 = new TemplatesGrupoMaquina.TemplatesGrupoMaquinaCrudApiSmokeTests();
            deleteSteps.Push(step83.DeleteAsync);
            await step83.ExecuteAsync();

            var step84 = new TemplatesMaquinas.TemplatesMaquinasCrudApiSmokeTests();
            deleteSteps.Push(step84.DeleteAsync);
            await step84.ExecuteAsync();

            var step85 = new TemposLogisticos.TemposLogisticosCrudApiSmokeTests();
            deleteSteps.Push(step85.DeleteAsync);
            await step85.ExecuteAsync();

            var step86 = new TipoABNT.TipoABNTCrudApiSmokeTests();
            deleteSteps.Push(step86.DeleteAsync);
            await step86.ExecuteAsync();

            var step87 = new TipoCarroceria.TipoCarroceriaCrudApiSmokeTests();
            deleteSteps.Push(step87.DeleteAsync);
            await step87.ExecuteAsync();

            var step88 = new TipoDispositivo.TipoDispositivoCrudApiSmokeTests();
            deleteSteps.Push(step88.DeleteAsync);
            await step88.ExecuteAsync();

            var step89 = new TipoDispositivoMaquina.TipoDispositivoMaquinaCrudApiSmokeTests();
            deleteSteps.Push(step89.DeleteAsync);
            await step89.ExecuteAsync();

            var step90 = new TipoInspecaoItens.TipoInspecaoItensCrudApiSmokeTests();
            deleteSteps.Push(step90.DeleteAsync);
            await step90.ExecuteAsync();

            var step91 = new TipoInspecaoVisual.TipoInspecaoVisualCrudApiSmokeTests();
            deleteSteps.Push(step91.DeleteAsync);
            await step91.ExecuteAsync();

            var step92 = new TipoMovimentoEstoque.TipoMovimentoEstoqueCrudApiSmokeTests();
            deleteSteps.Push(step92.DeleteAsync);
            await step92.ExecuteAsync();

            var step93 = new TipoOcorrencia.TipoOcorrenciaCrudApiSmokeTests();
            deleteSteps.Push(step93.DeleteAsync);
            await step93.ExecuteAsync();

            var step94 = new TipoVeiculo.TipoVeiculoCrudApiSmokeTests();
            deleteSteps.Push(step94.DeleteAsync);
            await step94.ExecuteAsync();

            var step95 = new Vinco.VincoCrudApiSmokeTests();
            deleteSteps.Push(step95.DeleteAsync);
            await step95.ExecuteAsync();

            var step96 = new TiposVincoGruposProdutos.TiposVincoGruposProdutosCrudApiSmokeTests();
            deleteSteps.Push(step96.DeleteAsync);
            await step96.ExecuteAsync();

            var step97 = new TiposVincoOndas.TiposVincoOndasCrudApiSmokeTests();
            deleteSteps.Push(step97.DeleteAsync);
            await step97.ExecuteAsync();

            var step98 = new TiposVincoProdutos.TiposVincoProdutosCrudApiSmokeTests();
            deleteSteps.Push(step98.DeleteAsync);
            await step98.ExecuteAsync();

            var step99 = new Transportadora.TransportadoraCrudApiSmokeTests();
            deleteSteps.Push(step99.DeleteAsync);
            await step99.ExecuteAsync();

            var step100 = new Turma.TurmaCrudApiSmokeTests();
            deleteSteps.Push(step100.DeleteAsync);
            await step100.ExecuteAsync();

            var step101 = new Turno.TurnoCrudApiSmokeTests();
            deleteSteps.Push(step101.DeleteAsync);
            await step101.ExecuteAsync();

            var step102 = new Unidade.UnidadeCrudApiSmokeTests();
            deleteSteps.Push(step102.DeleteAsync);
            await step102.ExecuteAsync();

            var step103 = new UnidadeMedida.UnidadeMedidaCrudApiSmokeTests();
            deleteSteps.Push(step103.DeleteAsync);
            await step103.ExecuteAsync();

            var step104 = new Usuario.UsuarioCrudApiSmokeTests();
            deleteSteps.Push(step104.DeleteAsync);
            await step104.ExecuteAsync();

            var step105 = new UsuarioObjetoControlavel.UsuarioObjetoControlavelCrudApiSmokeTests();
            deleteSteps.Push(step105.DeleteAsync);
            await step105.ExecuteAsync();

            var step106 = new UsuarioPerfil.UsuarioPerfilCrudApiSmokeTests();
            deleteSteps.Push(step106.DeleteAsync);
            await step106.ExecuteAsync();

            var step107 = new UsuariosCarga.UsuariosCargaCrudApiSmokeTests();
            deleteSteps.Push(step107.DeleteAsync);
            await step107.ExecuteAsync();

            var step108 = new Variavel.VariavelCrudApiSmokeTests();
            deleteSteps.Push(step108.DeleteAsync);
            await step108.ExecuteAsync();

            var step109 = new VariavelPlotagem.VariavelPlotagemCrudApiSmokeTests();
            deleteSteps.Push(step109.DeleteAsync);
            await step109.ExecuteAsync();

            var step110 = new Veiculo.VeiculoCrudApiSmokeTests();
            deleteSteps.Push(step110.DeleteAsync);
            await step110.ExecuteAsync();

            var step111 = new VersaoCusto.VersaoCustoCrudApiSmokeTests();
            deleteSteps.Push(step111.DeleteAsync);
            await step111.ExecuteAsync();

            var step112 = new VerssaoCusto.VerssaoCustoCrudApiSmokeTests();
            deleteSteps.Push(step112.DeleteAsync);
            await step112.ExecuteAsync();

            var step113 = new Cabvisao.CabvisaoCrudApiSmokeTests();
            deleteSteps.Push(step113.DeleteAsync);
            await step113.ExecuteAsync();

            var step114 = new Planocontas.PlanocontasCrudApiSmokeTests();
            deleteSteps.Push(step114.DeleteAsync);
            await step114.ExecuteAsync();

            var step115 = new Unidade_Unidade.Unidade_UnidadeCrudApiSmokeTests();
            deleteSteps.Push(step115.DeleteAsync);
            await step115.ExecuteAsync();

            var step116 = new Visoes.VisoesCrudApiSmokeTests();
            deleteSteps.Push(step116.DeleteAsync);
            await step116.ExecuteAsync();

            var step117 = new Relatorios.RelatoriosCrudApiSmokeTests();
            deleteSteps.Push(step117.DeleteAsync);
            await step117.ExecuteAsync();

            var step118 = new InspecaoVisual.InspecaoVisualCrudApiSmokeTests();
            deleteSteps.Push(step118.DeleteAsync);
            await step118.ExecuteAsync();

            var step119 = new TemplateTipoInspecaoVisual.TemplateTipoInspecaoVisualCrudApiSmokeTests();
            deleteSteps.Push(step119.DeleteAsync);
            await step119.ExecuteAsync();

            var step120 = new TipoAvaliacao.TipoAvaliacaoCrudApiSmokeTests();
            deleteSteps.Push(step120.DeleteAsync);
            await step120.ExecuteAsync();

            var step121 = new ExperienciaPlanejamentoTransporte.ExperienciaPlanejamentoTransporteCrudApiSmokeTests();
            deleteSteps.Push(step121.DeleteAsync);
            await step121.ExecuteAsync();

            var step122 = new yFileUpload.yFileUploadCrudApiSmokeTests();
            deleteSteps.Push(step122.DeleteAsync);
            await step122.ExecuteAsync();

            var step123 = new ySaga.ySagaCrudApiSmokeTests();
            deleteSteps.Push(step123.DeleteAsync);
            await step123.ExecuteAsync();

            var step124 = new ySagaStep.ySagaStepCrudApiSmokeTests();
            deleteSteps.Push(step124.DeleteAsync);
            await step124.ExecuteAsync();

            var step125 = new yOutbox.yOutboxCrudApiSmokeTests();
            deleteSteps.Push(step125.DeleteAsync);
            await step125.ExecuteAsync();

            var step126 = new yInbox.yInboxCrudApiSmokeTests();
            deleteSteps.Push(step126.DeleteAsync);
            await step126.ExecuteAsync();

            var step127 = new yToken.yTokenCrudApiSmokeTests();
            deleteSteps.Push(step127.DeleteAsync);
            await step127.ExecuteAsync();

            var step128 = new yUser.yUserCrudApiSmokeTests();
            deleteSteps.Push(step128.DeleteAsync);
            await step128.ExecuteAsync();

            var step129 = new yConfigArcteture.yConfigArctetureCrudApiSmokeTests();
            deleteSteps.Push(step129.DeleteAsync);
            await step129.ExecuteAsync();

            var step130 = new yConfigNotification.yConfigNotificationCrudApiSmokeTests();
            deleteSteps.Push(step130.DeleteAsync);
            await step130.ExecuteAsync();

            var step131 = new yPerfil.yPerfilCrudApiSmokeTests();
            deleteSteps.Push(step131.DeleteAsync);
            await step131.ExecuteAsync();

            var step132 = new yModule.yModuleCrudApiSmokeTests();
            deleteSteps.Push(step132.DeleteAsync);
            await step132.ExecuteAsync();

            var step133 = new yTenantModule.yTenantModuleCrudApiSmokeTests();
            deleteSteps.Push(step133.DeleteAsync);
            await step133.ExecuteAsync();

            var step134 = new yUserModule.yUserModuleCrudApiSmokeTests();
            deleteSteps.Push(step134.DeleteAsync);
            await step134.ExecuteAsync();

            var step135 = new yGrant.yGrantCrudApiSmokeTests();
            deleteSteps.Push(step135.DeleteAsync);
            await step135.ExecuteAsync();

            var step136 = new yPerfilGrant.yPerfilGrantCrudApiSmokeTests();
            deleteSteps.Push(step136.DeleteAsync);
            await step136.ExecuteAsync();

            var step137 = new yUserGrant.yUserGrantCrudApiSmokeTests();
            deleteSteps.Push(step137.DeleteAsync);
            await step137.ExecuteAsync();

            var step138 = new Maquina.MaquinaCrudApiSmokeTests();
            deleteSteps.Push(step138.DeleteAsync);
            await step138.ExecuteAsync();

            var step139 = new Auditoria.AuditoriaCrudApiSmokeTests();
            deleteSteps.Push(step139.DeleteAsync);
            await step139.ExecuteAsync();

            var step140 = new Cliente.ClienteCrudApiSmokeTests();
            deleteSteps.Push(step140.DeleteAsync);
            await step140.ExecuteAsync();

            var step141 = new Colaborador.ColaboradorCrudApiSmokeTests();
            deleteSteps.Push(step141.DeleteAsync);
            await step141.ExecuteAsync();

            var step142 = new EstruturaImpressao.EstruturaImpressaoCrudApiSmokeTests();
            deleteSteps.Push(step142.DeleteAsync);
            await step142.ExecuteAsync();

            var step143 = new T_HORARIO_RECEBIMENTO.T_HORARIO_RECEBIMENTOCrudApiSmokeTests();
            deleteSteps.Push(step143.DeleteAsync);
            await step143.ExecuteAsync();

            var step144 = new T_Indicadores.T_IndicadoresCrudApiSmokeTests();
            deleteSteps.Push(step144.DeleteAsync);
            await step144.ExecuteAsync();

            var step145 = new IndicadoresDepartamentos.IndicadoresDepartamentosCrudApiSmokeTests();
            deleteSteps.Push(step145.DeleteAsync);
            await step145.ExecuteAsync();

            var step146 = new IndicadoresDimencoes.IndicadoresDimencoesCrudApiSmokeTests();
            deleteSteps.Push(step146.DeleteAsync);
            await step146.ExecuteAsync();

            var step147 = new IndicadoresFatosDimencoes.IndicadoresFatosDimencoesCrudApiSmokeTests();
            deleteSteps.Push(step147.DeleteAsync);
            await step147.ExecuteAsync();

            var step148 = new IndicadoresPeriodosDimencoes.IndicadoresPeriodosDimencoesCrudApiSmokeTests();
            deleteSteps.Push(step148.DeleteAsync);
            await step148.ExecuteAsync();

            var step149 = new ItensCalendario.ItensCalendarioCrudApiSmokeTests();
            deleteSteps.Push(step149.DeleteAsync);
            await step149.ExecuteAsync();

            var step150 = new LogsDatabase.LogsDatabaseCrudApiSmokeTests();
            deleteSteps.Push(step150.DeleteAsync);
            await step150.ExecuteAsync();

            var step151 = new Mapa.MapaCrudApiSmokeTests();
            deleteSteps.Push(step151.DeleteAsync);
            await step151.ExecuteAsync();

            var step152 = new T_Metas.T_MetasCrudApiSmokeTests();
            deleteSteps.Push(step152.DeleteAsync);
            await step152.ExecuteAsync();

            var step153 = new Observacoes.ObservacoesCrudApiSmokeTests();
            deleteSteps.Push(step153.DeleteAsync);
            await step153.ExecuteAsync();

            var step154 = new Ocorrencia.OcorrenciaCrudApiSmokeTests();
            deleteSteps.Push(step154.DeleteAsync);
            await step154.ExecuteAsync();

            var step155 = new Onda.OndaCrudApiSmokeTests();
            deleteSteps.Push(step155.DeleteAsync);
            await step155.ExecuteAsync();

            var step156 = new Orcamento.OrcamentoCrudApiSmokeTests();
            deleteSteps.Push(step156.DeleteAsync);
            await step156.ExecuteAsync();

            var step157 = new Order.OrderCrudApiSmokeTests();
            deleteSteps.Push(step157.DeleteAsync);
            await step157.ExecuteAsync();

            var step158 = new Planoacao.PlanoacaoCrudApiSmokeTests();
            deleteSteps.Push(step158.DeleteAsync);
            await step158.ExecuteAsync();

            var step159 = new TempoSetupOnduladeira.TempoSetupOnduladeiraCrudApiSmokeTests();
            deleteSteps.Push(step159.DeleteAsync);
            await step159.ExecuteAsync();

            var step160 = new TesteFisico.TesteFisicoCrudApiSmokeTests();
            deleteSteps.Push(step160.DeleteAsync);
            await step160.ExecuteAsync();

            var step161 = new TipoTeste.TipoTesteCrudApiSmokeTests();
            deleteSteps.Push(step161.DeleteAsync);
            await step161.ExecuteAsync();

            var step162 = new Uniuser.UniuserCrudApiSmokeTests();
            deleteSteps.Push(step162.DeleteAsync);
            await step162.ExecuteAsync();

            var step163 = new T_USER_GRUPO.T_USER_GRUPOCrudApiSmokeTests();
            deleteSteps.Push(step163.DeleteAsync);
            await step163.ExecuteAsync();

            var step164 = new Movimentos.MovimentosCrudApiSmokeTests();
            deleteSteps.Push(step164.DeleteAsync);
            await step164.ExecuteAsync();

            var step165 = new TemplateTipoTeste.TemplateTipoTesteCrudApiSmokeTests();
            deleteSteps.Push(step165.DeleteAsync);
            await step165.ExecuteAsync();

            var step166 = new Carga.CargaCrudApiSmokeTests();
            deleteSteps.Push(step166.DeleteAsync);
            await step166.ExecuteAsync();

            var step167 = new EstruturaCusto.EstruturaCustoCrudApiSmokeTests();
            deleteSteps.Push(step167.DeleteAsync);
            await step167.ExecuteAsync();

            var step168 = new Etiqueta.EtiquetaCrudApiSmokeTests();
            deleteSteps.Push(step168.DeleteAsync);
            await step168.ExecuteAsync();

            var step169 = new T_Favoritos.T_FavoritosCrudApiSmokeTests();
            deleteSteps.Push(step169.DeleteAsync);
            await step169.ExecuteAsync();

            var step170 = new Feedback.FeedbackCrudApiSmokeTests();
            deleteSteps.Push(step170.DeleteAsync);
            await step170.ExecuteAsync();

            var step171 = new FilaProducao.FilaProducaoCrudApiSmokeTests();
            deleteSteps.Push(step171.DeleteAsync);
            await step171.ExecuteAsync();

            var step172 = new GrupoIndicador.GrupoIndicadorCrudApiSmokeTests();
            deleteSteps.Push(step172.DeleteAsync);
            await step172.ExecuteAsync();

            var step173 = new GrupoProdutoAbstrato.GrupoProdutoAbstratoCrudApiSmokeTests();
            deleteSteps.Push(step173.DeleteAsync);
            await step173.ExecuteAsync();

            var step174 = new InformacoesComplementares.InformacoesComplementaresCrudApiSmokeTests();
            deleteSteps.Push(step174.DeleteAsync);
            await step174.ExecuteAsync();

            var step175 = new ItenCarga.ItenCargaCrudApiSmokeTests();
            deleteSteps.Push(step175.DeleteAsync);
            await step175.ExecuteAsync();

            var step176 = new ItensOrcamento.ItensOrcamentoCrudApiSmokeTests();
            deleteSteps.Push(step176.DeleteAsync);
            await step176.ExecuteAsync();

            var step177 = new ItensPacked.ItensPackedCrudApiSmokeTests();
            deleteSteps.Push(step177.DeleteAsync);
            await step177.ExecuteAsync();

            var step178 = new MovimentoEstoque.MovimentoEstoqueCrudApiSmokeTests();
            deleteSteps.Push(step178.DeleteAsync);
            await step178.ExecuteAsync();

            var step179 = new OrderTrack.OrderTrackCrudApiSmokeTests();
            deleteSteps.Push(step179.DeleteAsync);
            await step179.ExecuteAsync();

            var step180 = new TargetProduto.TargetProdutoCrudApiSmokeTests();
            deleteSteps.Push(step180.DeleteAsync);
            await step180.ExecuteAsync();

            var step181 = new Produto.ProdutoCrudApiSmokeTests();
            deleteSteps.Push(step181.DeleteAsync);
            await step181.ExecuteAsync();

            var step182 = new Roteiro.RoteiroCrudApiSmokeTests();
            deleteSteps.Push(step182.DeleteAsync);
            await step182.ExecuteAsync();

            var step183 = new Boletim.BoletimCrudApiSmokeTests();
            deleteSteps.Push(step183.DeleteAsync);
            await step183.ExecuteAsync();

            var step184 = new Compensacao.CompensacaoCrudApiSmokeTests();
            deleteSteps.Push(step184.DeleteAsync);
            await step184.ExecuteAsync();

            var step185 = new T_FeedbackMovEstoque.T_FeedbackMovEstoqueCrudApiSmokeTests();
            deleteSteps.Push(step185.DeleteAsync);
            await step185.ExecuteAsync();

            var step186 = new Saga.CargaStandard.CargaStandardSagaApiSmokeTests();
            await step186.CargaStandard_saga_should_run_with_real_api_and_infrastructure();

        }
        catch (Exception ex)
        {
            testError = ex;
        }
        finally
        {
            while (deleteSteps.Count > 0)
            {
                try
                {
                    await deleteSteps.Pop()();
                }
                catch (Exception ex)
                {
                    deleteErrors.Add(ex);
                }
            }
        }

        if (testError is not null)
            System.Runtime.ExceptionServices.ExceptionDispatchInfo.Capture(testError).Throw();

        if (deleteErrors.Count > 0)
            throw new AggregateException("One or more API smoke cleanup steps failed.", deleteErrors);
    }
}
