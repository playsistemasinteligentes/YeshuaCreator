// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfrastructureOperationalControlStateMigration
// </yeshua>

using Dominio.Interfaces;
using Dominio.Entitys;

namespace Yeshua.Generated.OperationalControl;

public sealed record OperationalLoggingPolicy(
    string Application,
    string Environment,
    string Revision,
    string DefaultLevel,
    string DefaultDepth,
    IReadOnlyList<DiagnosticTarget> Targets,
    DateTimeOffset UpdatedAtUtc,
    string Source);

public sealed record DiagnosticTarget(
    string? Component,
    string? Operation,
    string? Entity,
    string? RecordId,
    string Level,
    string Depth,
    DateTimeOffset? ExpiresAtUtc)
{
    public string? Field { get; init; }
}

public readonly record struct OperationalLoggingContext(
    string? Component,
    string? Operation,
    string? Entity,
    string? RecordId)
{
    public string? Field { get; init; }
}

public readonly record struct OperationalLoggingDecision(
    bool Enabled,
    string Level,
    string Depth,
    DiagnosticTarget? MatchedTarget);

public interface IOperationalLoggingPolicyAccessor
{
    OperationalLoggingPolicy Current { get; }
    OperationalLoggingDecision Evaluate(OperationalLoggingContext context);
}

public sealed class OperationalLoggingPolicyState :
    IOperationalLoggingPolicyAccessor,
    IOperationalTelemetryPolicy,
    IDomainTrackingPolicy
{
    private OperationalLoggingPolicy _current;

    public OperationalLoggingPolicyState(string application, string environment)
    {
        _current = new OperationalLoggingPolicy(
            application,
            environment,
            "LOCAL-BASELINE",
            "Information",
            "D0",
            [],
            DateTimeOffset.UtcNow,
            "LocalBaseline");
    }

    public OperationalLoggingPolicy Current => Volatile.Read(ref _current);

    public void Replace(OperationalLoggingPolicy policy)
    {
        if (!string.Equals(
                policy.Application,
                Current.Application,
                StringComparison.OrdinalIgnoreCase) ||
            !string.Equals(
                policy.Environment,
                Current.Environment,
                StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException(
                $"Policy for '{policy.Application}/{policy.Environment}' cannot replace policy for '{Current.Application}/{Current.Environment}'.");
        }

        Interlocked.Exchange(ref _current, policy);
    }

public OperationalLoggingDecision Evaluate(OperationalLoggingContext context)
{
    return Evaluate(
        context.Component,
        context.Operation,
        context.Entity,
        context.RecordId,
        context.Field);
}

private OperationalLoggingDecision Evaluate(
    string? component,
    string? operation,
    string? entity,
    string? recordId,
    string? field = null)
{
    return Evaluate(Current, component, operation, entity, recordId, field, true);
}

private OperationalLoggingDecision Evaluate(
    OperationalLoggingPolicy policy,
    string? component,
    string? operation,
    string? entity,
    string? recordId,
    string? field,
    bool useDefault)
{
    DiagnosticTarget? target = null;
    if (policy.Targets.Count > 0)
    {
        var now = DateTimeOffset.UtcNow;
        var highestSpecificity = -1;
        foreach (var candidate in policy.Targets)
        {
            if ((candidate.ExpiresAtUtc is not null && candidate.ExpiresAtUtc <= now) ||
                !Matches(candidate.Component, component) ||
                !Matches(candidate.Operation, operation) ||
                !Matches(candidate.Entity, entity) ||
                !Matches(candidate.RecordId, recordId) ||
                !Matches(candidate.Field, field))
            {
                continue;
            }

            var specificity = Specificity(candidate);
            if (specificity <= highestSpecificity)
                continue;

            highestSpecificity = specificity;
            target = candidate;
        }
    }

        if (!useDefault && target is null)
        {
            return new OperationalLoggingDecision(
                false,
                "None",
                "D0",
                null);
        }

        var level = target?.Level ?? policy.DefaultLevel;
        var depth = target?.Depth ?? policy.DefaultDepth;
        return new OperationalLoggingDecision(
            !level.Equals("None", StringComparison.OrdinalIgnoreCase),
            level,
            depth,
            target);
    }

    OperationalTelemetryDecision IOperationalTelemetryPolicy.Evaluate(
        string component,
        string? operation,
        string? entity,
        string? recordId)
    {
    var decision = Evaluate(
        component,
        operation,
        entity,
        recordId);
        return new OperationalTelemetryDecision(
            decision.Enabled,
            decision.Level,
            decision.Depth);
    }

    OperationalTelemetryDecision IOperationalTelemetryPolicy.Evaluate(
        string component,
        string? operation,
        string? entity,
        string? recordId,
        string? field)
    {
    var decision = Evaluate(
        component,
        operation,
        entity,
        recordId,
        field);
        return new OperationalTelemetryDecision(
            decision.Enabled,
            decision.Level,
            decision.Depth);
    }

                public ulong GetMask(
                    string entity,
                    string? operation = null,
                    string? recordId = null)
                {
                    var policy = Current;
                    if (policy.Targets.Count == 0)
                        return 0UL;
                    if (!HasDomainTrackingTargets(policy))
                        return 0UL;

                    return entity switch
                    {
                        "Produto" => GetProdutoMask(policy, operation, recordId),
                        "Maquina" => GetMaquinaMask(policy, operation, recordId),
                        "GrupoMaquina" => GetGrupoMaquinaMask(policy, operation, recordId),
                        "TemplateDeTestes" => GetTemplateDeTestesMask(policy, operation, recordId),
                        "Roteiro" => GetRoteiroMask(policy, operation, recordId),
                        "ConsultaPedido" => GetConsultaPedidoMask(policy, operation, recordId),
                        "RoteiroPedido" => GetRoteiroPedidoMask(policy, operation, recordId),
                        "T_AGENDA_SCHEDULE" => GetT_AGENDA_SCHEDULEMask(policy, operation, recordId),
                        "Auditoria" => GetAuditoriaMask(policy, operation, recordId),
                        "Boletim" => GetBoletimMask(policy, operation, recordId),
                        "BoletimEstudo" => GetBoletimEstudoMask(policy, operation, recordId),
                        "Calendario" => GetCalendarioMask(policy, operation, recordId),
                        "CalendarioDisponibilidadeVeiculos" => GetCalendarioDisponibilidadeVeiculosMask(policy, operation, recordId),
                        "Canhotos" => GetCanhotosMask(policy, operation, recordId),
                        "Carga" => GetCargaMask(policy, operation, recordId),
                        "CargaPrevista" => GetCargaPrevistaMask(policy, operation, recordId),
                        "Cargos" => GetCargosMask(policy, operation, recordId),
                        "Cliente" => GetClienteMask(policy, operation, recordId),
                        "ClpMedicoes" => GetClpMedicoesMask(policy, operation, recordId),
                        "ClpMedicoesH" => GetClpMedicoesHMask(policy, operation, recordId),
                        "Colaborador" => GetColaboradorMask(policy, operation, recordId),
                        "Compensacao" => GetCompensacaoMask(policy, operation, recordId),
                        "CondicaoPagamento" => GetCondicaoPagamentoMask(policy, operation, recordId),
                        "Configuracoes" => GetConfiguracoesMask(policy, operation, recordId),
                        "Consultas" => GetConsultasMask(policy, operation, recordId),
                        "ConsultasGrupos" => GetConsultasGruposMask(policy, operation, recordId),
                        "ConsultasIndicadores" => GetConsultasIndicadoresMask(policy, operation, recordId),
                        "CorConfiguracaoGrafico" => GetCorConfiguracaoGraficoMask(policy, operation, recordId),
                        "CorridasOnduladeira" => GetCorridasOnduladeiraMask(policy, operation, recordId),
                        "CorridasOnduladeiraEstudo" => GetCorridasOnduladeiraEstudoMask(policy, operation, recordId),
                        "Cotas" => GetCotasMask(policy, operation, recordId),
                        "T_Departamentos" => GetT_DepartamentosMask(policy, operation, recordId),
                        "Enderecos" => GetEnderecosMask(policy, operation, recordId),
                        "Equipe" => GetEquipeMask(policy, operation, recordId),
                        "Estradas" => GetEstradasMask(policy, operation, recordId),
                        "EstruturaCusto" => GetEstruturaCustoMask(policy, operation, recordId),
                        "EstruturaImpressao" => GetEstruturaImpressaoMask(policy, operation, recordId),
                        "EstruturaProduto" => GetEstruturaProdutoMask(policy, operation, recordId),
                        "Etiqueta" => GetEtiquetaMask(policy, operation, recordId),
                        "T_Favoritos" => GetT_FavoritosMask(policy, operation, recordId),
                        "FechamentoTeste" => GetFechamentoTesteMask(policy, operation, recordId),
                        "Feedback" => GetFeedbackMask(policy, operation, recordId),
                        "T_FeedbackMovEstoque" => GetT_FeedbackMovEstoqueMask(policy, operation, recordId),
                        "FilaProducao" => GetFilaProducaoMask(policy, operation, recordId),
                        "FilaProducaoPrevista" => GetFilaProducaoPrevistaMask(policy, operation, recordId),
                        "T_Grupo" => GetT_GrupoMask(policy, operation, recordId),
                        "GrupoIndicador" => GetGrupoIndicadorMask(policy, operation, recordId),
                        "GrupoProdutoAbstrato" => GetGrupoProdutoAbstratoMask(policy, operation, recordId),
                        "GrupoRecurso" => GetGrupoRecursoMask(policy, operation, recordId),
                        "GrupoSegmento" => GetGrupoSegmentoMask(policy, operation, recordId),
                        "T_HORARIO_RECEBIMENTO" => GetT_HORARIO_RECEBIMENTOMask(policy, operation, recordId),
                        "Impressora" => GetImpressoraMask(policy, operation, recordId),
                        "T_Indicadores" => GetT_IndicadoresMask(policy, operation, recordId),
                        "IndicadoresDepartamentos" => GetIndicadoresDepartamentosMask(policy, operation, recordId),
                        "IndicadoresDimencoes" => GetIndicadoresDimencoesMask(policy, operation, recordId),
                        "IndicadoresFatosDimencoes" => GetIndicadoresFatosDimencoesMask(policy, operation, recordId),
                        "IndicadoresPeriodosDimencoes" => GetIndicadoresPeriodosDimencoesMask(policy, operation, recordId),
                        "InformacoesComplementares" => GetInformacoesComplementaresMask(policy, operation, recordId),
                        "InpecaoVisual" => GetInpecaoVisualMask(policy, operation, recordId),
                        "ItemInspecao" => GetItemInspecaoMask(policy, operation, recordId),
                        "ItemTestavel" => GetItemTestavelMask(policy, operation, recordId),
                        "ItensCalendario" => GetItensCalendarioMask(policy, operation, recordId),
                        "ItenCalendarioDisponibilidadeVeiculos" => GetItenCalendarioDisponibilidadeVeiculosMask(policy, operation, recordId),
                        "ItenCarga" => GetItenCargaMask(policy, operation, recordId),
                        "ItensEstruturaImpressao" => GetItensEstruturaImpressaoMask(policy, operation, recordId),
                        "ItensOrcamento" => GetItensOrcamentoMask(policy, operation, recordId),
                        "ItensPacked" => GetItensPackedMask(policy, operation, recordId),
                        "LaudoTesteFisico" => GetLaudoTesteFisicoMask(policy, operation, recordId),
                        "Logs" => GetLogsMask(policy, operation, recordId),
                        "LogsDatabase" => GetLogsDatabaseMask(policy, operation, recordId),
                        "Loock" => GetLoockMask(policy, operation, recordId),
                        "LoteTeste" => GetLoteTesteMask(policy, operation, recordId),
                        "Lotes" => GetLotesMask(policy, operation, recordId),
                        "Mapa" => GetMapaMask(policy, operation, recordId),
                        "MaquinaGrupoMaquina" => GetMaquinaGrupoMaquinaMask(policy, operation, recordId),
                        "MaquinaImpressora" => GetMaquinaImpressoraMask(policy, operation, recordId),
                        "T_MAQUINAS_EQUIPES" => GetT_MAQUINAS_EQUIPESMask(policy, operation, recordId),
                        "T_Medicoes" => GetT_MedicoesMask(policy, operation, recordId),
                        "MedicoesOnduladeira" => GetMedicoesOnduladeiraMask(policy, operation, recordId),
                        "MedidasTeste" => GetMedidasTesteMask(policy, operation, recordId),
                        "MemoriaDeCalculo" => GetMemoriaDeCalculoMask(policy, operation, recordId),
                        "Mensagem" => GetMensagemMask(policy, operation, recordId),
                        "Meses" => GetMesesMask(policy, operation, recordId),
                        "T_Metas" => GetT_MetasMask(policy, operation, recordId),
                        "MovimentoEstoque" => GetMovimentoEstoqueMask(policy, operation, recordId),
                        "Municipio" => GetMunicipioMask(policy, operation, recordId),
                        "T_Negocio" => GetT_NegocioMask(policy, operation, recordId),
                        "ObjetoControlavel" => GetObjetoControlavelMask(policy, operation, recordId),
                        "Observacoes" => GetObservacoesMask(policy, operation, recordId),
                        "Ocorrencia" => GetOcorrenciaMask(policy, operation, recordId),
                        "Onda" => GetOndaMask(policy, operation, recordId),
                        "Operacoes" => GetOperacoesMask(policy, operation, recordId),
                        "OptAlteracaoDimencoes" => GetOptAlteracaoDimencoesMask(policy, operation, recordId),
                        "Orcamento" => GetOrcamentoMask(policy, operation, recordId),
                        "OrderTrack" => GetOrderTrackMask(policy, operation, recordId),
                        "Order" => GetOrderMask(policy, operation, recordId),
                        "Param" => GetParamMask(policy, operation, recordId),
                        "ParametrosDeCusto" => GetParametrosDeCustoMask(policy, operation, recordId),
                        "PendenciasInterface" => GetPendenciasInterfaceMask(policy, operation, recordId),
                        "Perfil" => GetPerfilMask(policy, operation, recordId),
                        "PerfilObjetoControlavel" => GetPerfilObjetoControlavelMask(policy, operation, recordId),
                        "PeriodicidadeTeste" => GetPeriodicidadeTesteMask(policy, operation, recordId),
                        "PlanoAmostralTeste" => GetPlanoAmostralTesteMask(policy, operation, recordId),
                        "Planoacao" => GetPlanoacaoMask(policy, operation, recordId),
                        "Plotagem" => GetPlotagemMask(policy, operation, recordId),
                        "PoliticaOnduladeira" => GetPoliticaOnduladeiraMask(policy, operation, recordId),
                        "PontosMapa" => GetPontosMapaMask(policy, operation, recordId),
                        "T_PREFERENCIAS" => GetT_PREFERENCIASMask(policy, operation, recordId),
                        "ProtocoloOnduladeira" => GetProtocoloOnduladeiraMask(policy, operation, recordId),
                        "Recursos" => GetRecursosMask(policy, operation, recordId),
                        "RegistrosOnduladeira" => GetRegistrosOnduladeiraMask(policy, operation, recordId),
                        "Representantes" => GetRepresentantesMask(policy, operation, recordId),
                        "RespInspVisual" => GetRespInspVisualMask(policy, operation, recordId),
                        "RestricoesDeRodagem" => GetRestricoesDeRodagemMask(policy, operation, recordId),
                        "ResultLote" => GetResultLoteMask(policy, operation, recordId),
                        "ResultMedida" => GetResultMedidaMask(policy, operation, recordId),
                        "Rodovias" => GetRodoviasMask(policy, operation, recordId),
                        "RotaRealizada" => GetRotaRealizadaMask(policy, operation, recordId),
                        "RotaPontosMapa" => GetRotaPontosMapaMask(policy, operation, recordId),
                        "Segmento" => GetSegmentoMask(policy, operation, recordId),
                        "SegmentosProdutos" => GetSegmentosProdutosMask(policy, operation, recordId),
                        "Semaforo" => GetSemaforoMask(policy, operation, recordId),
                        "SubOcorrencia" => GetSubOcorrenciaMask(policy, operation, recordId),
                        "Tabela" => GetTabelaMask(policy, operation, recordId),
                        "TargetProduto" => GetTargetProdutoMask(policy, operation, recordId),
                        "TemplatesGrupoMaquina" => GetTemplatesGrupoMaquinaMask(policy, operation, recordId),
                        "TemplatesMaquinas" => GetTemplatesMaquinasMask(policy, operation, recordId),
                        "TempoSetupOnduladeira" => GetTempoSetupOnduladeiraMask(policy, operation, recordId),
                        "TemposLogisticos" => GetTemposLogisticosMask(policy, operation, recordId),
                        "TesteFisico" => GetTesteFisicoMask(policy, operation, recordId),
                        "TipoABNT" => GetTipoABNTMask(policy, operation, recordId),
                        "TipoCarroceria" => GetTipoCarroceriaMask(policy, operation, recordId),
                        "TipoDispositivo" => GetTipoDispositivoMask(policy, operation, recordId),
                        "TipoDispositivoMaquina" => GetTipoDispositivoMaquinaMask(policy, operation, recordId),
                        "TipoInspecaoItens" => GetTipoInspecaoItensMask(policy, operation, recordId),
                        "TipoInspecaoVisual" => GetTipoInspecaoVisualMask(policy, operation, recordId),
                        "TipoMovimentoEstoque" => GetTipoMovimentoEstoqueMask(policy, operation, recordId),
                        "TipoOcorrencia" => GetTipoOcorrenciaMask(policy, operation, recordId),
                        "TipoTeste" => GetTipoTesteMask(policy, operation, recordId),
                        "TipoVeiculo" => GetTipoVeiculoMask(policy, operation, recordId),
                        "Vinco" => GetVincoMask(policy, operation, recordId),
                        "TiposVincoGruposProdutos" => GetTiposVincoGruposProdutosMask(policy, operation, recordId),
                        "TiposVincoOndas" => GetTiposVincoOndasMask(policy, operation, recordId),
                        "TiposVincoProdutos" => GetTiposVincoProdutosMask(policy, operation, recordId),
                        "Transportadora" => GetTransportadoraMask(policy, operation, recordId),
                        "Turma" => GetTurmaMask(policy, operation, recordId),
                        "Turno" => GetTurnoMask(policy, operation, recordId),
                        "Unidade" => GetUnidadeMask(policy, operation, recordId),
                        "UnidadeMedida" => GetUnidadeMedidaMask(policy, operation, recordId),
                        "Uniuser" => GetUniuserMask(policy, operation, recordId),
                        "T_USER_GRUPO" => GetT_USER_GRUPOMask(policy, operation, recordId),
                        "Usuario" => GetUsuarioMask(policy, operation, recordId),
                        "UsuarioObjetoControlavel" => GetUsuarioObjetoControlavelMask(policy, operation, recordId),
                        "UsuarioPerfil" => GetUsuarioPerfilMask(policy, operation, recordId),
                        "UsuariosCarga" => GetUsuariosCargaMask(policy, operation, recordId),
                        "Variavel" => GetVariavelMask(policy, operation, recordId),
                        "VariavelPlotagem" => GetVariavelPlotagemMask(policy, operation, recordId),
                        "Veiculo" => GetVeiculoMask(policy, operation, recordId),
                        "VersaoCusto" => GetVersaoCustoMask(policy, operation, recordId),
                        "VerssaoCusto" => GetVerssaoCustoMask(policy, operation, recordId),
                        "Cabvisao" => GetCabvisaoMask(policy, operation, recordId),
                        "Movimentos" => GetMovimentosMask(policy, operation, recordId),
                        "Planocontas" => GetPlanocontasMask(policy, operation, recordId),
                        "Unidade_Unidade" => GetUnidade_UnidadeMask(policy, operation, recordId),
                        "Visoes" => GetVisoesMask(policy, operation, recordId),
                        "Relatorios" => GetRelatoriosMask(policy, operation, recordId),
                        "InspecaoVisual" => GetInspecaoVisualMask(policy, operation, recordId),
                        "TemplateTipoInspecaoVisual" => GetTemplateTipoInspecaoVisualMask(policy, operation, recordId),
                        "TemplateTipoTeste" => GetTemplateTipoTesteMask(policy, operation, recordId),
                        "TipoAvaliacao" => GetTipoAvaliacaoMask(policy, operation, recordId),
                        "PedidoPlanejavel" => GetPedidoPlanejavelMask(policy, operation, recordId),
                        "CargaPlanejavel" => GetCargaPlanejavelMask(policy, operation, recordId),
                        "OpcaoPlanejamentoTransporte" => GetOpcaoPlanejamentoTransporteMask(policy, operation, recordId),
                        "CenarioPlanejamentoTransporte" => GetCenarioPlanejamentoTransporteMask(policy, operation, recordId),
                        "ExperienciaPlanejamentoTransporte" => GetExperienciaPlanejamentoTransporteMask(policy, operation, recordId),
                        "yFileUpload" => GetyFileUploadMask(policy, operation, recordId),
                        "ySaga" => GetySagaMask(policy, operation, recordId),
                        "ySagaStep" => GetySagaStepMask(policy, operation, recordId),
                        "yOutbox" => GetyOutboxMask(policy, operation, recordId),
                        "yInbox" => GetyInboxMask(policy, operation, recordId),
                        "yToken" => GetyTokenMask(policy, operation, recordId),
                        "yTenant" => GetyTenantMask(policy, operation, recordId),
                        "yUser" => GetyUserMask(policy, operation, recordId),
                        "yConfigArcteture" => GetyConfigArctetureMask(policy, operation, recordId),
                        "yConfigNotification" => GetyConfigNotificationMask(policy, operation, recordId),
                        "yPerfil" => GetyPerfilMask(policy, operation, recordId),
                        "yModule" => GetyModuleMask(policy, operation, recordId),
                        "yTenantModule" => GetyTenantModuleMask(policy, operation, recordId),
                        "yUserModule" => GetyUserModuleMask(policy, operation, recordId),
                        "yGrant" => GetyGrantMask(policy, operation, recordId),
                        "yPerfilGrant" => GetyPerfilGrantMask(policy, operation, recordId),
                        "yUserGrant" => GetyUserGrantMask(policy, operation, recordId),
                        _ => 0UL
                    };
                }

                private ulong GetProdutoMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "Id"))
                        mask |= ProdutoTrackingFields.Id;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "Descricao"))
                        mask |= ProdutoTrackingFields.Descricao;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "Status"))
                        mask |= ProdutoTrackingFields.Status;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "TenantID"))
                        mask |= ProdutoTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "Deleted"))
                        mask |= ProdutoTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "Changed"))
                        mask |= ProdutoTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "UserId"))
                        mask |= ProdutoTrackingFields.UserId;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "PRO_ESTOQUE_ATUAL"))
                        mask |= ProdutoTrackingFields.PRO_ESTOQUE_ATUAL;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "UNI_ID"))
                        mask |= ProdutoTrackingFields.UNI_ID;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "PRO_FARDOS_POR_CAMADA"))
                        mask |= ProdutoTrackingFields.PRO_FARDOS_POR_CAMADA;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "PRO_CAMADAS_POR_PALETE"))
                        mask |= ProdutoTrackingFields.PRO_CAMADAS_POR_PALETE;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "PRO_TIPO_IDENTIFICACAO"))
                        mask |= ProdutoTrackingFields.PRO_TIPO_IDENTIFICACAO;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "PRO_GRUPO_PALETIZACAO"))
                        mask |= ProdutoTrackingFields.PRO_GRUPO_PALETIZACAO;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "PRO_PECAS_POR_FARDO"))
                        mask |= ProdutoTrackingFields.PRO_PECAS_POR_FARDO;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "PRO_ID_INTEGRACAO"))
                        mask |= ProdutoTrackingFields.PRO_ID_INTEGRACAO;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "PRO_ID_INTEGRACAO_ERP"))
                        mask |= ProdutoTrackingFields.PRO_ID_INTEGRACAO_ERP;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "GRP_ID"))
                        mask |= ProdutoTrackingFields.GRP_ID;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "TEM_ID"))
                        mask |= ProdutoTrackingFields.TEM_ID;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "PRO_LARGURA_PECA"))
                        mask |= ProdutoTrackingFields.PRO_LARGURA_PECA;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "PRO_COMPRIMENTO_PECA"))
                        mask |= ProdutoTrackingFields.PRO_COMPRIMENTO_PECA;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "PRO_ALTURA_PECA"))
                        mask |= ProdutoTrackingFields.PRO_ALTURA_PECA;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "PRO_LARGURA_EMBALADA"))
                        mask |= ProdutoTrackingFields.PRO_LARGURA_EMBALADA;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "PRO_COMPRIMENTO_EMBALADA"))
                        mask |= ProdutoTrackingFields.PRO_COMPRIMENTO_EMBALADA;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "PRO_ALTURA_EMBALADA"))
                        mask |= ProdutoTrackingFields.PRO_ALTURA_EMBALADA;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "PRO_FRENTE"))
                        mask |= ProdutoTrackingFields.PRO_FRENTE;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "PRO_ROTACIONA_COMPRIMENTO"))
                        mask |= ProdutoTrackingFields.PRO_ROTACIONA_COMPRIMENTO;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "PRO_ROTACIONA_LARGURA"))
                        mask |= ProdutoTrackingFields.PRO_ROTACIONA_LARGURA;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "PRO_ROTACIONA_ALTURA"))
                        mask |= ProdutoTrackingFields.PRO_ROTACIONA_ALTURA;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "PRO_ESCALA_COR"))
                        mask |= ProdutoTrackingFields.PRO_ESCALA_COR;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "PRO_SUB_ESCALA_COR"))
                        mask |= ProdutoTrackingFields.PRO_SUB_ESCALA_COR;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "PRO_CUSTO_SUBIDA_ESCALA_COR"))
                        mask |= ProdutoTrackingFields.PRO_CUSTO_SUBIDA_ESCALA_COR;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "PRO_CUSTO_DECIDA_ESCALA_COR"))
                        mask |= ProdutoTrackingFields.PRO_CUSTO_DECIDA_ESCALA_COR;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "TMP_TIPO_CARGA"))
                        mask |= ProdutoTrackingFields.TMP_TIPO_CARGA;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "PRO_TEMPO_CARREGAMENTO_UNITARIO"))
                        mask |= ProdutoTrackingFields.PRO_TEMPO_CARREGAMENTO_UNITARIO;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "PRO_TEMPO_DESCARREGAMENTO_UNITARIO"))
                        mask |= ProdutoTrackingFields.PRO_TEMPO_DESCARREGAMENTO_UNITARIO;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "PRO_PERCENTUAL_JANELA_EMBARQUE"))
                        mask |= ProdutoTrackingFields.PRO_PERCENTUAL_JANELA_EMBARQUE;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "PRO_TEMPO_PRODUCAO_CONJUNTO"))
                        mask |= ProdutoTrackingFields.PRO_TEMPO_PRODUCAO_CONJUNTO;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "PRO_PECAS_DA_PECA"))
                        mask |= ProdutoTrackingFields.PRO_PECAS_DA_PECA;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "PRO_TYPE"))
                        mask |= ProdutoTrackingFields.PRO_TYPE;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "PRO_COLOR_HEXA"))
                        mask |= ProdutoTrackingFields.PRO_COLOR_HEXA;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "PRO_VINCOS_LARGURA"))
                        mask |= ProdutoTrackingFields.PRO_VINCOS_LARGURA;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "PRO_VINCOS_COMPRIMENTO"))
                        mask |= ProdutoTrackingFields.PRO_VINCOS_COMPRIMENTO;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "PRO_LARGURA_INTERNA"))
                        mask |= ProdutoTrackingFields.PRO_LARGURA_INTERNA;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "PRO_COMPRIMENTO_INTERNA"))
                        mask |= ProdutoTrackingFields.PRO_COMPRIMENTO_INTERNA;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "PRO_ALTURA_INTERNA"))
                        mask |= ProdutoTrackingFields.PRO_ALTURA_INTERNA;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "PRO_COD_DESENHO"))
                        mask |= ProdutoTrackingFields.PRO_COD_DESENHO;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "PRO_FECHAMENTO"))
                        mask |= ProdutoTrackingFields.PRO_FECHAMENTO;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "PRO_TIPO_LAP"))
                        mask |= ProdutoTrackingFields.PRO_TIPO_LAP;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "PRO_TAMANHO_LAP"))
                        mask |= ProdutoTrackingFields.PRO_TAMANHO_LAP;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "PRO_LAP_PROLONGADO"))
                        mask |= ProdutoTrackingFields.PRO_LAP_PROLONGADO;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "PRO_TAMANHO_LAP_PROLONG"))
                        mask |= ProdutoTrackingFields.PRO_TAMANHO_LAP_PROLONG;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "PRO_ARRANJO_LARGURA"))
                        mask |= ProdutoTrackingFields.PRO_ARRANJO_LARGURA;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "PRO_ARRANJO_COMPRIMENTO"))
                        mask |= ProdutoTrackingFields.PRO_ARRANJO_COMPRIMENTO;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "PRO_FITILHOS_FARDO_LARG"))
                        mask |= ProdutoTrackingFields.PRO_FITILHOS_FARDO_LARG;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "PRO_FITILHOS_FARDO_COMP"))
                        mask |= ProdutoTrackingFields.PRO_FITILHOS_FARDO_COMP;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "PRO_FITILHOS_PALETE_LARG"))
                        mask |= ProdutoTrackingFields.PRO_FITILHOS_PALETE_LARG;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "PRO_FITILHOS_PALETE_COMP"))
                        mask |= ProdutoTrackingFields.PRO_FITILHOS_PALETE_COMP;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "PRO_FILME_PALETE"))
                        mask |= ProdutoTrackingFields.PRO_FILME_PALETE;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "PRO_QTD_ESPELHO"))
                        mask |= ProdutoTrackingFields.PRO_QTD_ESPELHO;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "PRO_CUSTO"))
                        mask |= ProdutoTrackingFields.PRO_CUSTO;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "PRO_AREA_LIQUIDA"))
                        mask |= ProdutoTrackingFields.PRO_AREA_LIQUIDA;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "PRO_PESO"))
                        mask |= ProdutoTrackingFields.PRO_PESO;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "PRO_TOLERANCIA_DIMENSAO_CHAPA_DE"))
                        mask |= ProdutoTrackingFields.PRO_TOLERANCIA_DIMENSAO_CHAPA_DE;
                    if (DomainFieldTracked(policy, "Produto", operation, recordId, "PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE"))
                        mask |= ProdutoTrackingFields.PRO_TOLERANCIA_DIMENSAO_CHAPA_ATE;
                    return mask;
                }

                private ulong GetMaquinaMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "Id"))
                        mask |= MaquinaTrackingFields.Id;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "Descricao"))
                        mask |= MaquinaTrackingFields.Descricao;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "Status"))
                        mask |= MaquinaTrackingFields.Status;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "TenantID"))
                        mask |= MaquinaTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "Deleted"))
                        mask |= MaquinaTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "Changed"))
                        mask |= MaquinaTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "UserId"))
                        mask |= MaquinaTrackingFields.UserId;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "CAL_ID"))
                        mask |= MaquinaTrackingFields.CAL_ID;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "MAQ_CONTROL_IP"))
                        mask |= MaquinaTrackingFields.MAQ_CONTROL_IP;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "GMA_ID"))
                        mask |= MaquinaTrackingFields.GMA_ID;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "MAQ_ULTIMA_ATUALIZACAO"))
                        mask |= MaquinaTrackingFields.MAQ_ULTIMA_ATUALIZACAO;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "MAQ_SIRENE_SEMAFORO"))
                        mask |= MaquinaTrackingFields.MAQ_SIRENE_SEMAFORO;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "MAQ_COR_SEMAFORO"))
                        mask |= MaquinaTrackingFields.MAQ_COR_SEMAFORO;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "MAQ_ID_MAQ_PAI"))
                        mask |= MaquinaTrackingFields.MAQ_ID_MAQ_PAI;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "MAQ_TIPO_CONTADOR"))
                        mask |= MaquinaTrackingFields.MAQ_TIPO_CONTADOR;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "MAQ_TIPO_PLANEJAMENTO"))
                        mask |= MaquinaTrackingFields.MAQ_TIPO_PLANEJAMENTO;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "MAQ_AVALIA_CUSTO"))
                        mask |= MaquinaTrackingFields.MAQ_AVALIA_CUSTO;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "FPR_ID_OP_PRODUZINDO"))
                        mask |= MaquinaTrackingFields.FPR_ID_OP_PRODUZINDO;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "MAQ_CONGELA_FILA"))
                        mask |= MaquinaTrackingFields.MAQ_CONGELA_FILA;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "MAQ_TEMPO_MIN_PARADA"))
                        mask |= MaquinaTrackingFields.MAQ_TEMPO_MIN_PARADA;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "MAQ_QTD_CORES"))
                        mask |= MaquinaTrackingFields.MAQ_QTD_CORES;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "MAQ_ID_INTEGRACAO"))
                        mask |= MaquinaTrackingFields.MAQ_ID_INTEGRACAO;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "MAQ_ID_INTEGRACAO_ERP"))
                        mask |= MaquinaTrackingFields.MAQ_ID_INTEGRACAO_ERP;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "MAQ_HIERARQUIA_SEQ_TRANSFORMACAO"))
                        mask |= MaquinaTrackingFields.MAQ_HIERARQUIA_SEQ_TRANSFORMACAO;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "EQU_ID"))
                        mask |= MaquinaTrackingFields.EQU_ID;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR"))
                        mask |= MaquinaTrackingFields.MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "MAQ_ACOMPANHA_LOTE_PILOTO"))
                        mask |= MaquinaTrackingFields.MAQ_ACOMPANHA_LOTE_PILOTO;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "MAQ_ID_SENSOR"))
                        mask |= MaquinaTrackingFields.MAQ_ID_SENSOR;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "MAQ_DEBOUNCING_LOW"))
                        mask |= MaquinaTrackingFields.MAQ_DEBOUNCING_LOW;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "MAQ_DEBOUNCING_HIGHT"))
                        mask |= MaquinaTrackingFields.MAQ_DEBOUNCING_HIGHT;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "MAQ_TIPO_SINAL"))
                        mask |= MaquinaTrackingFields.MAQ_TIPO_SINAL;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "TEM_ID"))
                        mask |= MaquinaTrackingFields.TEM_ID;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "MAQ_COMPRIMENTO_CHAPA_DE"))
                        mask |= MaquinaTrackingFields.MAQ_COMPRIMENTO_CHAPA_DE;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "MAQ_COMPRIMENTO_CHAPA_ATE"))
                        mask |= MaquinaTrackingFields.MAQ_COMPRIMENTO_CHAPA_ATE;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "MAQ_LARGURA_CHAPA_DE"))
                        mask |= MaquinaTrackingFields.MAQ_LARGURA_CHAPA_DE;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "MAQ_LARGURA_CHAPA_ATE"))
                        mask |= MaquinaTrackingFields.MAQ_LARGURA_CHAPA_ATE;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR"))
                        mask |= MaquinaTrackingFields.MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR"))
                        mask |= MaquinaTrackingFields.MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR"))
                        mask |= MaquinaTrackingFields.MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR"))
                        mask |= MaquinaTrackingFields.MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "MAQ_COMPRIMENTO_ENTRE_VINCO_DE"))
                        mask |= MaquinaTrackingFields.MAQ_COMPRIMENTO_ENTRE_VINCO_DE;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "MAQ_COMPRIMENTO_ENTRE_VINCO_ATE"))
                        mask |= MaquinaTrackingFields.MAQ_COMPRIMENTO_ENTRE_VINCO_ATE;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "MAQ_LARGURA_ENTRE_VINCO_DE"))
                        mask |= MaquinaTrackingFields.MAQ_LARGURA_ENTRE_VINCO_DE;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "MAQ_LARGURA_ENTRE_VINCO_ATE"))
                        mask |= MaquinaTrackingFields.MAQ_LARGURA_ENTRE_VINCO_ATE;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "MAQ_ALTURA_ENTRE_VINCO_DE"))
                        mask |= MaquinaTrackingFields.MAQ_ALTURA_ENTRE_VINCO_DE;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "MAQ_ALTURA_ENTRE_VINCO_ATE"))
                        mask |= MaquinaTrackingFields.MAQ_ALTURA_ENTRE_VINCO_ATE;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE"))
                        mask |= MaquinaTrackingFields.MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE"))
                        mask |= MaquinaTrackingFields.MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "MAQ_ABA_DE"))
                        mask |= MaquinaTrackingFields.MAQ_ABA_DE;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "MAQ_ABA_ATE"))
                        mask |= MaquinaTrackingFields.MAQ_ABA_ATE;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "MAQ_LAP_DE"))
                        mask |= MaquinaTrackingFields.MAQ_LAP_DE;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "MAQ_LAP_ATE"))
                        mask |= MaquinaTrackingFields.MAQ_LAP_ATE;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "MAQ_ONDAS"))
                        mask |= MaquinaTrackingFields.MAQ_ONDAS;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "MAQ_PROLONGA_LAP"))
                        mask |= MaquinaTrackingFields.MAQ_PROLONGA_LAP;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "MAQ_LARGURA_IMPRESSAO"))
                        mask |= MaquinaTrackingFields.MAQ_LARGURA_IMPRESSAO;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "MAQ_COMPRIMENTO_IMPRESSAO"))
                        mask |= MaquinaTrackingFields.MAQ_COMPRIMENTO_IMPRESSAO;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "MAQ_ROLO_DISPOSITIVO_DE"))
                        mask |= MaquinaTrackingFields.MAQ_ROLO_DISPOSITIVO_DE;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "MAQ_ROLO_DISPOSITIVO_ATE"))
                        mask |= MaquinaTrackingFields.MAQ_ROLO_DISPOSITIVO_ATE;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "MAQ_FAMILIAS"))
                        mask |= MaquinaTrackingFields.MAQ_FAMILIAS;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "MAQ_REFILE_MINIMO"))
                        mask |= MaquinaTrackingFields.MAQ_REFILE_MINIMO;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "MAQ_LARGURA_UTIL"))
                        mask |= MaquinaTrackingFields.MAQ_LARGURA_UTIL;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "MAQ_TOTAL_ACO"))
                        mask |= MaquinaTrackingFields.MAQ_TOTAL_ACO;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "MAQ_FECHAMENTO"))
                        mask |= MaquinaTrackingFields.MAQ_FECHAMENTO;
                    if (DomainFieldTracked(policy, "Maquina", operation, recordId, "MAQ_OPERACAO_VINCAR"))
                        mask |= MaquinaTrackingFields.MAQ_OPERACAO_VINCAR;
                    return mask;
                }

                private ulong GetGrupoMaquinaMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "GrupoMaquina", operation, recordId, "Id"))
                        mask |= GrupoMaquinaTrackingFields.Id;
                    if (DomainFieldTracked(policy, "GrupoMaquina", operation, recordId, "Descricao"))
                        mask |= GrupoMaquinaTrackingFields.Descricao;
                    if (DomainFieldTracked(policy, "GrupoMaquina", operation, recordId, "Status"))
                        mask |= GrupoMaquinaTrackingFields.Status;
                    if (DomainFieldTracked(policy, "GrupoMaquina", operation, recordId, "TenantID"))
                        mask |= GrupoMaquinaTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "GrupoMaquina", operation, recordId, "Deleted"))
                        mask |= GrupoMaquinaTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "GrupoMaquina", operation, recordId, "Changed"))
                        mask |= GrupoMaquinaTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "GrupoMaquina", operation, recordId, "UserId"))
                        mask |= GrupoMaquinaTrackingFields.UserId;
                    if (DomainFieldTracked(policy, "GrupoMaquina", operation, recordId, "GMA_TIPO_PLANEJAMENTO"))
                        mask |= GrupoMaquinaTrackingFields.GMA_TIPO_PLANEJAMENTO;
                    return mask;
                }

                private ulong GetTemplateDeTestesMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "TemplateDeTestes", operation, recordId, "Id"))
                        mask |= TemplateDeTestesTrackingFields.Id;
                    if (DomainFieldTracked(policy, "TemplateDeTestes", operation, recordId, "Descricao"))
                        mask |= TemplateDeTestesTrackingFields.Descricao;
                    if (DomainFieldTracked(policy, "TemplateDeTestes", operation, recordId, "TenantID"))
                        mask |= TemplateDeTestesTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "TemplateDeTestes", operation, recordId, "Deleted"))
                        mask |= TemplateDeTestesTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "TemplateDeTestes", operation, recordId, "Changed"))
                        mask |= TemplateDeTestesTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "TemplateDeTestes", operation, recordId, "UserId"))
                        mask |= TemplateDeTestesTrackingFields.UserId;
                    if (DomainFieldTracked(policy, "TemplateDeTestes", operation, recordId, "Observacao"))
                        mask |= TemplateDeTestesTrackingFields.Observacao;
                    return mask;
                }

                private ulong GetRoteiroMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Roteiro", operation, recordId, "Id"))
                        mask |= RoteiroTrackingFields.Id;
                    if (DomainFieldTracked(policy, "Roteiro", operation, recordId, "MaquinaId"))
                        mask |= RoteiroTrackingFields.MaquinaId;
                    if (DomainFieldTracked(policy, "Roteiro", operation, recordId, "ProdutoId"))
                        mask |= RoteiroTrackingFields.ProdutoId;
                    if (DomainFieldTracked(policy, "Roteiro", operation, recordId, "SequenciaTransformacao"))
                        mask |= RoteiroTrackingFields.SequenciaTransformacao;
                    if (DomainFieldTracked(policy, "Roteiro", operation, recordId, "GrupoMaquinaId"))
                        mask |= RoteiroTrackingFields.GrupoMaquinaId;
                    if (DomainFieldTracked(policy, "Roteiro", operation, recordId, "PecasPorPulso"))
                        mask |= RoteiroTrackingFields.PecasPorPulso;
                    if (DomainFieldTracked(policy, "Roteiro", operation, recordId, "PrioridadeInformada"))
                        mask |= RoteiroTrackingFields.PrioridadeInformada;
                    if (DomainFieldTracked(policy, "Roteiro", operation, recordId, "Acao"))
                        mask |= RoteiroTrackingFields.Acao;
                    if (DomainFieldTracked(policy, "Roteiro", operation, recordId, "Performance"))
                        mask |= RoteiroTrackingFields.Performance;
                    if (DomainFieldTracked(policy, "Roteiro", operation, recordId, "TempoSetup"))
                        mask |= RoteiroTrackingFields.TempoSetup;
                    if (DomainFieldTracked(policy, "Roteiro", operation, recordId, "TempoSetupAjuste"))
                        mask |= RoteiroTrackingFields.TempoSetupAjuste;
                    if (DomainFieldTracked(policy, "Roteiro", operation, recordId, "ProximaSequenciaTransformacao"))
                        mask |= RoteiroTrackingFields.ProximaSequenciaTransformacao;
                    if (DomainFieldTracked(policy, "Roteiro", operation, recordId, "Status"))
                        mask |= RoteiroTrackingFields.Status;
                    if (DomainFieldTracked(policy, "Roteiro", operation, recordId, "HierarquiaSequenciaTransformacao"))
                        mask |= RoteiroTrackingFields.HierarquiaSequenciaTransformacao;
                    if (DomainFieldTracked(policy, "Roteiro", operation, recordId, "AvaliaCusto"))
                        mask |= RoteiroTrackingFields.AvaliaCusto;
                    if (DomainFieldTracked(policy, "Roteiro", operation, recordId, "Operacoes"))
                        mask |= RoteiroTrackingFields.Operacoes;
                    if (DomainFieldTracked(policy, "Roteiro", operation, recordId, "ExcecaoOperacoes"))
                        mask |= RoteiroTrackingFields.ExcecaoOperacoes;
                    if (DomainFieldTracked(policy, "Roteiro", operation, recordId, "PercentualInicioPassoAnterior"))
                        mask |= RoteiroTrackingFields.PercentualInicioPassoAnterior;
                    if (DomainFieldTracked(policy, "Roteiro", operation, recordId, "LinhaDireta"))
                        mask |= RoteiroTrackingFields.LinhaDireta;
                    if (DomainFieldTracked(policy, "Roteiro", operation, recordId, "TemplateDeTestesId"))
                        mask |= RoteiroTrackingFields.TemplateDeTestesId;
                    if (DomainFieldTracked(policy, "Roteiro", operation, recordId, "TenantID"))
                        mask |= RoteiroTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Roteiro", operation, recordId, "Deleted"))
                        mask |= RoteiroTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Roteiro", operation, recordId, "Changed"))
                        mask |= RoteiroTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Roteiro", operation, recordId, "UserId"))
                        mask |= RoteiroTrackingFields.UserId;
                    return mask;
                }

                private ulong GetConsultaPedidoMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "ConsultaPedido", operation, recordId, "PedidoId"))
                        mask |= ConsultaPedidoTrackingFields.PedidoId;
                    if (DomainFieldTracked(policy, "ConsultaPedido", operation, recordId, "ClienteId"))
                        mask |= ConsultaPedidoTrackingFields.ClienteId;
                    if (DomainFieldTracked(policy, "ConsultaPedido", operation, recordId, "ClienteNome"))
                        mask |= ConsultaPedidoTrackingFields.ClienteNome;
                    if (DomainFieldTracked(policy, "ConsultaPedido", operation, recordId, "RazaoSocial"))
                        mask |= ConsultaPedidoTrackingFields.RazaoSocial;
                    if (DomainFieldTracked(policy, "ConsultaPedido", operation, recordId, "ProdutoId"))
                        mask |= ConsultaPedidoTrackingFields.ProdutoId;
                    if (DomainFieldTracked(policy, "ConsultaPedido", operation, recordId, "ProdutoDescricao"))
                        mask |= ConsultaPedidoTrackingFields.ProdutoDescricao;
                    if (DomainFieldTracked(policy, "ConsultaPedido", operation, recordId, "Status"))
                        mask |= ConsultaPedidoTrackingFields.Status;
                    if (DomainFieldTracked(policy, "ConsultaPedido", operation, recordId, "Estagio"))
                        mask |= ConsultaPedidoTrackingFields.Estagio;
                    if (DomainFieldTracked(policy, "ConsultaPedido", operation, recordId, "DataEntregaDe"))
                        mask |= ConsultaPedidoTrackingFields.DataEntregaDe;
                    if (DomainFieldTracked(policy, "ConsultaPedido", operation, recordId, "DataEntregaAte"))
                        mask |= ConsultaPedidoTrackingFields.DataEntregaAte;
                    if (DomainFieldTracked(policy, "ConsultaPedido", operation, recordId, "EmbarqueAlvo"))
                        mask |= ConsultaPedidoTrackingFields.EmbarqueAlvo;
                    if (DomainFieldTracked(policy, "ConsultaPedido", operation, recordId, "Quantidade"))
                        mask |= ConsultaPedidoTrackingFields.Quantidade;
                    if (DomainFieldTracked(policy, "ConsultaPedido", operation, recordId, "SaldoAProduzir"))
                        mask |= ConsultaPedidoTrackingFields.SaldoAProduzir;
                    if (DomainFieldTracked(policy, "ConsultaPedido", operation, recordId, "SaldoAExpedir"))
                        mask |= ConsultaPedidoTrackingFields.SaldoAExpedir;
                    if (DomainFieldTracked(policy, "ConsultaPedido", operation, recordId, "CorFila"))
                        mask |= ConsultaPedidoTrackingFields.CorFila;
                    if (DomainFieldTracked(policy, "ConsultaPedido", operation, recordId, "PedidoCliente"))
                        mask |= ConsultaPedidoTrackingFields.PedidoCliente;
                    return mask;
                }

                private ulong GetRoteiroPedidoMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "RoteiroPedido", operation, recordId, "PedidoId"))
                        mask |= RoteiroPedidoTrackingFields.PedidoId;
                    if (DomainFieldTracked(policy, "RoteiroPedido", operation, recordId, "MaquinaId"))
                        mask |= RoteiroPedidoTrackingFields.MaquinaId;
                    if (DomainFieldTracked(policy, "RoteiroPedido", operation, recordId, "ProdutoId"))
                        mask |= RoteiroPedidoTrackingFields.ProdutoId;
                    if (DomainFieldTracked(policy, "RoteiroPedido", operation, recordId, "SequenciaTransformacao"))
                        mask |= RoteiroPedidoTrackingFields.SequenciaTransformacao;
                    if (DomainFieldTracked(policy, "RoteiroPedido", operation, recordId, "StatusCadastro"))
                        mask |= RoteiroPedidoTrackingFields.StatusCadastro;
                    if (DomainFieldTracked(policy, "RoteiroPedido", operation, recordId, "TipoPlanejamento"))
                        mask |= RoteiroPedidoTrackingFields.TipoPlanejamento;
                    if (DomainFieldTracked(policy, "RoteiroPedido", operation, recordId, "CalendarioId"))
                        mask |= RoteiroPedidoTrackingFields.CalendarioId;
                    if (DomainFieldTracked(policy, "RoteiroPedido", operation, recordId, "HierarquiaSequenciaTransformacao"))
                        mask |= RoteiroPedidoTrackingFields.HierarquiaSequenciaTransformacao;
                    if (DomainFieldTracked(policy, "RoteiroPedido", operation, recordId, "ProximaSequenciaTransformacao"))
                        mask |= RoteiroPedidoTrackingFields.ProximaSequenciaTransformacao;
                    if (DomainFieldTracked(policy, "RoteiroPedido", operation, recordId, "Performance"))
                        mask |= RoteiroPedidoTrackingFields.Performance;
                    if (DomainFieldTracked(policy, "RoteiroPedido", operation, recordId, "TempoSetup"))
                        mask |= RoteiroPedidoTrackingFields.TempoSetup;
                    if (DomainFieldTracked(policy, "RoteiroPedido", operation, recordId, "TempoSetupAjuste"))
                        mask |= RoteiroPedidoTrackingFields.TempoSetupAjuste;
                    if (DomainFieldTracked(policy, "RoteiroPedido", operation, recordId, "PecasPorPulso"))
                        mask |= RoteiroPedidoTrackingFields.PecasPorPulso;
                    if (DomainFieldTracked(policy, "RoteiroPedido", operation, recordId, "PrioridadeInformada"))
                        mask |= RoteiroPedidoTrackingFields.PrioridadeInformada;
                    if (DomainFieldTracked(policy, "RoteiroPedido", operation, recordId, "Status"))
                        mask |= RoteiroPedidoTrackingFields.Status;
                    if (DomainFieldTracked(policy, "RoteiroPedido", operation, recordId, "Operacoes"))
                        mask |= RoteiroPedidoTrackingFields.Operacoes;
                    if (DomainFieldTracked(policy, "RoteiroPedido", operation, recordId, "ExcecaoOperacoes"))
                        mask |= RoteiroPedidoTrackingFields.ExcecaoOperacoes;
                    if (DomainFieldTracked(policy, "RoteiroPedido", operation, recordId, "LinhaDireta"))
                        mask |= RoteiroPedidoTrackingFields.LinhaDireta;
                    if (DomainFieldTracked(policy, "RoteiroPedido", operation, recordId, "AvaliaCusto"))
                        mask |= RoteiroPedidoTrackingFields.AvaliaCusto;
                    if (DomainFieldTracked(policy, "RoteiroPedido", operation, recordId, "PercentualInicioPassoAnterior"))
                        mask |= RoteiroPedidoTrackingFields.PercentualInicioPassoAnterior;
                    if (DomainFieldTracked(policy, "RoteiroPedido", operation, recordId, "MaquinaLarguraUtil"))
                        mask |= RoteiroPedidoTrackingFields.MaquinaLarguraUtil;
                    if (DomainFieldTracked(policy, "RoteiroPedido", operation, recordId, "GrupoTipo"))
                        mask |= RoteiroPedidoTrackingFields.GrupoTipo;
                    if (DomainFieldTracked(policy, "RoteiroPedido", operation, recordId, "GrupoPerformanceMetroLinear"))
                        mask |= RoteiroPedidoTrackingFields.GrupoPerformanceMetroLinear;
                    return mask;
                }

                private ulong GetT_AGENDA_SCHEDULEMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "T_AGENDA_SCHEDULE", operation, recordId, "Id"))
                        mask |= T_AGENDA_SCHEDULETrackingFields.Id;
                    if (DomainFieldTracked(policy, "T_AGENDA_SCHEDULE", operation, recordId, "AGE_ID"))
                        mask |= T_AGENDA_SCHEDULETrackingFields.AGE_ID;
                    if (DomainFieldTracked(policy, "T_AGENDA_SCHEDULE", operation, recordId, "AGE_DATA_ESPECIFICA"))
                        mask |= T_AGENDA_SCHEDULETrackingFields.AGE_DATA_ESPECIFICA;
                    if (DomainFieldTracked(policy, "T_AGENDA_SCHEDULE", operation, recordId, "AGE_HORARIO_INICIO"))
                        mask |= T_AGENDA_SCHEDULETrackingFields.AGE_HORARIO_INICIO;
                    if (DomainFieldTracked(policy, "T_AGENDA_SCHEDULE", operation, recordId, "AGE_HORARIO_FIM"))
                        mask |= T_AGENDA_SCHEDULETrackingFields.AGE_HORARIO_FIM;
                    if (DomainFieldTracked(policy, "T_AGENDA_SCHEDULE", operation, recordId, "AGE_SEGUNDA"))
                        mask |= T_AGENDA_SCHEDULETrackingFields.AGE_SEGUNDA;
                    if (DomainFieldTracked(policy, "T_AGENDA_SCHEDULE", operation, recordId, "AGE_TERCA"))
                        mask |= T_AGENDA_SCHEDULETrackingFields.AGE_TERCA;
                    if (DomainFieldTracked(policy, "T_AGENDA_SCHEDULE", operation, recordId, "AGE_QUARTA"))
                        mask |= T_AGENDA_SCHEDULETrackingFields.AGE_QUARTA;
                    if (DomainFieldTracked(policy, "T_AGENDA_SCHEDULE", operation, recordId, "AGE_QUINTA"))
                        mask |= T_AGENDA_SCHEDULETrackingFields.AGE_QUINTA;
                    if (DomainFieldTracked(policy, "T_AGENDA_SCHEDULE", operation, recordId, "AGE_SEXTA"))
                        mask |= T_AGENDA_SCHEDULETrackingFields.AGE_SEXTA;
                    if (DomainFieldTracked(policy, "T_AGENDA_SCHEDULE", operation, recordId, "AGE_SABADO"))
                        mask |= T_AGENDA_SCHEDULETrackingFields.AGE_SABADO;
                    if (DomainFieldTracked(policy, "T_AGENDA_SCHEDULE", operation, recordId, "AGE_DOMINGO"))
                        mask |= T_AGENDA_SCHEDULETrackingFields.AGE_DOMINGO;
                    if (DomainFieldTracked(policy, "T_AGENDA_SCHEDULE", operation, recordId, "AGE_INTERVALO"))
                        mask |= T_AGENDA_SCHEDULETrackingFields.AGE_INTERVALO;
                    if (DomainFieldTracked(policy, "T_AGENDA_SCHEDULE", operation, recordId, "AGE_ORDEM_EXECUCAO"))
                        mask |= T_AGENDA_SCHEDULETrackingFields.AGE_ORDEM_EXECUCAO;
                    if (DomainFieldTracked(policy, "T_AGENDA_SCHEDULE", operation, recordId, "AGE_PARAMETROS"))
                        mask |= T_AGENDA_SCHEDULETrackingFields.AGE_PARAMETROS;
                    if (DomainFieldTracked(policy, "T_AGENDA_SCHEDULE", operation, recordId, "AGE_EXCECAO"))
                        mask |= T_AGENDA_SCHEDULETrackingFields.AGE_EXCECAO;
                    if (DomainFieldTracked(policy, "T_AGENDA_SCHEDULE", operation, recordId, "AGE_DESCRICAO"))
                        mask |= T_AGENDA_SCHEDULETrackingFields.AGE_DESCRICAO;
                    if (DomainFieldTracked(policy, "T_AGENDA_SCHEDULE", operation, recordId, "TenantID"))
                        mask |= T_AGENDA_SCHEDULETrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "T_AGENDA_SCHEDULE", operation, recordId, "Deleted"))
                        mask |= T_AGENDA_SCHEDULETrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "T_AGENDA_SCHEDULE", operation, recordId, "Changed"))
                        mask |= T_AGENDA_SCHEDULETrackingFields.Changed;
                    if (DomainFieldTracked(policy, "T_AGENDA_SCHEDULE", operation, recordId, "UserId"))
                        mask |= T_AGENDA_SCHEDULETrackingFields.UserId;
                    return mask;
                }

                private ulong GetAuditoriaMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Auditoria", operation, recordId, "ID"))
                        mask |= AuditoriaTrackingFields.ID;
                    if (DomainFieldTracked(policy, "Auditoria", operation, recordId, "DATA"))
                        mask |= AuditoriaTrackingFields.DATA;
                    if (DomainFieldTracked(policy, "Auditoria", operation, recordId, "USE_ID"))
                        mask |= AuditoriaTrackingFields.USE_ID;
                    if (DomainFieldTracked(policy, "Auditoria", operation, recordId, "ROTINA"))
                        mask |= AuditoriaTrackingFields.ROTINA;
                    if (DomainFieldTracked(policy, "Auditoria", operation, recordId, "HISTORICO"))
                        mask |= AuditoriaTrackingFields.HISTORICO;
                    if (DomainFieldTracked(policy, "Auditoria", operation, recordId, "CHAVE"))
                        mask |= AuditoriaTrackingFields.CHAVE;
                    if (DomainFieldTracked(policy, "Auditoria", operation, recordId, "TenantID"))
                        mask |= AuditoriaTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Auditoria", operation, recordId, "Deleted"))
                        mask |= AuditoriaTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Auditoria", operation, recordId, "Changed"))
                        mask |= AuditoriaTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Auditoria", operation, recordId, "UserId"))
                        mask |= AuditoriaTrackingFields.UserId;
                    return mask;
                }

                private ulong GetBoletimMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Boletim", operation, recordId, "Id"))
                        mask |= BoletimTrackingFields.Id;
                    if (DomainFieldTracked(policy, "Boletim", operation, recordId, "BOL_ID"))
                        mask |= BoletimTrackingFields.BOL_ID;
                    if (DomainFieldTracked(policy, "Boletim", operation, recordId, "BOL_ID_ORIGEM"))
                        mask |= BoletimTrackingFields.BOL_ID_ORIGEM;
                    if (DomainFieldTracked(policy, "Boletim", operation, recordId, "BOL_SOLVER"))
                        mask |= BoletimTrackingFields.BOL_SOLVER;
                    if (DomainFieldTracked(policy, "Boletim", operation, recordId, "BOL_INTEGRACAO"))
                        mask |= BoletimTrackingFields.BOL_INTEGRACAO;
                    if (DomainFieldTracked(policy, "Boletim", operation, recordId, "BOL_SEQUENCIA"))
                        mask |= BoletimTrackingFields.BOL_SEQUENCIA;
                    if (DomainFieldTracked(policy, "Boletim", operation, recordId, "GRP_PAP_GRAMATURA_PROGRAMADO"))
                        mask |= BoletimTrackingFields.GRP_PAP_GRAMATURA_PROGRAMADO;
                    if (DomainFieldTracked(policy, "Boletim", operation, recordId, "GRP_ID_PROGRAMADO"))
                        mask |= BoletimTrackingFields.GRP_ID_PROGRAMADO;
                    if (DomainFieldTracked(policy, "Boletim", operation, recordId, "GRP_PAPEL1_PROGRAMADO"))
                        mask |= BoletimTrackingFields.GRP_PAPEL1_PROGRAMADO;
                    if (DomainFieldTracked(policy, "Boletim", operation, recordId, "GRP_PAPEL2_PROGRAMADO"))
                        mask |= BoletimTrackingFields.GRP_PAPEL2_PROGRAMADO;
                    if (DomainFieldTracked(policy, "Boletim", operation, recordId, "GRP_PAPEL3_PROGRAMADO"))
                        mask |= BoletimTrackingFields.GRP_PAPEL3_PROGRAMADO;
                    if (DomainFieldTracked(policy, "Boletim", operation, recordId, "GRP_PAPEL4_PROGRAMADO"))
                        mask |= BoletimTrackingFields.GRP_PAPEL4_PROGRAMADO;
                    if (DomainFieldTracked(policy, "Boletim", operation, recordId, "GRP_PAPEL5_PROGRAMADO"))
                        mask |= BoletimTrackingFields.GRP_PAPEL5_PROGRAMADO;
                    if (DomainFieldTracked(policy, "Boletim", operation, recordId, "BOL_STATUS_INTERFACE"))
                        mask |= BoletimTrackingFields.BOL_STATUS_INTERFACE;
                    if (DomainFieldTracked(policy, "Boletim", operation, recordId, "BOL_TIPO"))
                        mask |= BoletimTrackingFields.BOL_TIPO;
                    if (DomainFieldTracked(policy, "Boletim", operation, recordId, "BOL_FORMATO"))
                        mask |= BoletimTrackingFields.BOL_FORMATO;
                    if (DomainFieldTracked(policy, "Boletim", operation, recordId, "BOL_GRAMATURA_PAPEIS_PROGRAMADOS"))
                        mask |= BoletimTrackingFields.BOL_GRAMATURA_PAPEIS_PROGRAMADOS;
                    if (DomainFieldTracked(policy, "Boletim", operation, recordId, "BOL_GRAMATURA_PAPEIS_REALIZADO"))
                        mask |= BoletimTrackingFields.BOL_GRAMATURA_PAPEIS_REALIZADO;
                    if (DomainFieldTracked(policy, "Boletim", operation, recordId, "BOL_CUSTO_PAPEIS_PROGRAMADOS"))
                        mask |= BoletimTrackingFields.BOL_CUSTO_PAPEIS_PROGRAMADOS;
                    if (DomainFieldTracked(policy, "Boletim", operation, recordId, "BOL_CUSTO_PAPEIS_REALIZADO"))
                        mask |= BoletimTrackingFields.BOL_CUSTO_PAPEIS_REALIZADO;
                    if (DomainFieldTracked(policy, "Boletim", operation, recordId, "BOL_GRAMATURA_RESINA_PROGRAMADOS"))
                        mask |= BoletimTrackingFields.BOL_GRAMATURA_RESINA_PROGRAMADOS;
                    if (DomainFieldTracked(policy, "Boletim", operation, recordId, "BOL_CUSTO_RESINA_PROGRAMADOS"))
                        mask |= BoletimTrackingFields.BOL_CUSTO_RESINA_PROGRAMADOS;
                    if (DomainFieldTracked(policy, "Boletim", operation, recordId, "BOL_REFILE_OBRIGATORIO"))
                        mask |= BoletimTrackingFields.BOL_REFILE_OBRIGATORIO;
                    if (DomainFieldTracked(policy, "Boletim", operation, recordId, "BOL_OBS"))
                        mask |= BoletimTrackingFields.BOL_OBS;
                    if (DomainFieldTracked(policy, "Boletim", operation, recordId, "TenantID"))
                        mask |= BoletimTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Boletim", operation, recordId, "Deleted"))
                        mask |= BoletimTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Boletim", operation, recordId, "Changed"))
                        mask |= BoletimTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Boletim", operation, recordId, "UserId"))
                        mask |= BoletimTrackingFields.UserId;
                    return mask;
                }

                private ulong GetBoletimEstudoMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "BoletimEstudo", operation, recordId, "Id"))
                        mask |= BoletimEstudoTrackingFields.Id;
                    if (DomainFieldTracked(policy, "BoletimEstudo", operation, recordId, "BOL_ID"))
                        mask |= BoletimEstudoTrackingFields.BOL_ID;
                    if (DomainFieldTracked(policy, "BoletimEstudo", operation, recordId, "BOL_ID_ORIGEM"))
                        mask |= BoletimEstudoTrackingFields.BOL_ID_ORIGEM;
                    if (DomainFieldTracked(policy, "BoletimEstudo", operation, recordId, "BOL_SOLVER"))
                        mask |= BoletimEstudoTrackingFields.BOL_SOLVER;
                    if (DomainFieldTracked(policy, "BoletimEstudo", operation, recordId, "BOL_INTEGRACAO"))
                        mask |= BoletimEstudoTrackingFields.BOL_INTEGRACAO;
                    if (DomainFieldTracked(policy, "BoletimEstudo", operation, recordId, "BOL_SEQUENCIA"))
                        mask |= BoletimEstudoTrackingFields.BOL_SEQUENCIA;
                    if (DomainFieldTracked(policy, "BoletimEstudo", operation, recordId, "GRP_PAP_GRAMATURA_PROGRAMADO"))
                        mask |= BoletimEstudoTrackingFields.GRP_PAP_GRAMATURA_PROGRAMADO;
                    if (DomainFieldTracked(policy, "BoletimEstudo", operation, recordId, "GRP_ID_PROGRAMADO"))
                        mask |= BoletimEstudoTrackingFields.GRP_ID_PROGRAMADO;
                    if (DomainFieldTracked(policy, "BoletimEstudo", operation, recordId, "GRP_PAPEL1_PROGRAMADO"))
                        mask |= BoletimEstudoTrackingFields.GRP_PAPEL1_PROGRAMADO;
                    if (DomainFieldTracked(policy, "BoletimEstudo", operation, recordId, "GRP_PAPEL2_PROGRAMADO"))
                        mask |= BoletimEstudoTrackingFields.GRP_PAPEL2_PROGRAMADO;
                    if (DomainFieldTracked(policy, "BoletimEstudo", operation, recordId, "GRP_PAPEL3_PROGRAMADO"))
                        mask |= BoletimEstudoTrackingFields.GRP_PAPEL3_PROGRAMADO;
                    if (DomainFieldTracked(policy, "BoletimEstudo", operation, recordId, "GRP_PAPEL4_PROGRAMADO"))
                        mask |= BoletimEstudoTrackingFields.GRP_PAPEL4_PROGRAMADO;
                    if (DomainFieldTracked(policy, "BoletimEstudo", operation, recordId, "GRP_PAPEL5_PROGRAMADO"))
                        mask |= BoletimEstudoTrackingFields.GRP_PAPEL5_PROGRAMADO;
                    if (DomainFieldTracked(policy, "BoletimEstudo", operation, recordId, "BOL_STATUS_INTERFACE"))
                        mask |= BoletimEstudoTrackingFields.BOL_STATUS_INTERFACE;
                    if (DomainFieldTracked(policy, "BoletimEstudo", operation, recordId, "BOL_TIPO"))
                        mask |= BoletimEstudoTrackingFields.BOL_TIPO;
                    if (DomainFieldTracked(policy, "BoletimEstudo", operation, recordId, "BOL_FORMATO"))
                        mask |= BoletimEstudoTrackingFields.BOL_FORMATO;
                    if (DomainFieldTracked(policy, "BoletimEstudo", operation, recordId, "BOL_GRAMATURA_PAPEIS_PROGRAMADOS"))
                        mask |= BoletimEstudoTrackingFields.BOL_GRAMATURA_PAPEIS_PROGRAMADOS;
                    if (DomainFieldTracked(policy, "BoletimEstudo", operation, recordId, "BOL_GRAMATURA_PAPEIS_REALIZADO"))
                        mask |= BoletimEstudoTrackingFields.BOL_GRAMATURA_PAPEIS_REALIZADO;
                    if (DomainFieldTracked(policy, "BoletimEstudo", operation, recordId, "BOL_CUSTO_PAPEIS_PROGRAMADOS"))
                        mask |= BoletimEstudoTrackingFields.BOL_CUSTO_PAPEIS_PROGRAMADOS;
                    if (DomainFieldTracked(policy, "BoletimEstudo", operation, recordId, "BOL_CUSTO_PAPEIS_REALIZADO"))
                        mask |= BoletimEstudoTrackingFields.BOL_CUSTO_PAPEIS_REALIZADO;
                    if (DomainFieldTracked(policy, "BoletimEstudo", operation, recordId, "BOL_GRAMATURA_RESINA_PROGRAMADOS"))
                        mask |= BoletimEstudoTrackingFields.BOL_GRAMATURA_RESINA_PROGRAMADOS;
                    if (DomainFieldTracked(policy, "BoletimEstudo", operation, recordId, "BOL_CUSTO_RESINA_PROGRAMADOS"))
                        mask |= BoletimEstudoTrackingFields.BOL_CUSTO_RESINA_PROGRAMADOS;
                    if (DomainFieldTracked(policy, "BoletimEstudo", operation, recordId, "BOL_REFILE_OBRIGATORIO"))
                        mask |= BoletimEstudoTrackingFields.BOL_REFILE_OBRIGATORIO;
                    if (DomainFieldTracked(policy, "BoletimEstudo", operation, recordId, "TenantID"))
                        mask |= BoletimEstudoTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "BoletimEstudo", operation, recordId, "Deleted"))
                        mask |= BoletimEstudoTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "BoletimEstudo", operation, recordId, "Changed"))
                        mask |= BoletimEstudoTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "BoletimEstudo", operation, recordId, "UserId"))
                        mask |= BoletimEstudoTrackingFields.UserId;
                    return mask;
                }

                private ulong GetCalendarioMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Calendario", operation, recordId, "CAL_ID"))
                        mask |= CalendarioTrackingFields.CAL_ID;
                    if (DomainFieldTracked(policy, "Calendario", operation, recordId, "CAL_DESCRICAO"))
                        mask |= CalendarioTrackingFields.CAL_DESCRICAO;
                    if (DomainFieldTracked(policy, "Calendario", operation, recordId, "CAL_DIVIDE_DIA_EM"))
                        mask |= CalendarioTrackingFields.CAL_DIVIDE_DIA_EM;
                    if (DomainFieldTracked(policy, "Calendario", operation, recordId, "TenantID"))
                        mask |= CalendarioTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Calendario", operation, recordId, "Deleted"))
                        mask |= CalendarioTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Calendario", operation, recordId, "Changed"))
                        mask |= CalendarioTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Calendario", operation, recordId, "UserId"))
                        mask |= CalendarioTrackingFields.UserId;
                    return mask;
                }

                private ulong GetCalendarioDisponibilidadeVeiculosMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "CalendarioDisponibilidadeVeiculos", operation, recordId, "Id"))
                        mask |= CalendarioDisponibilidadeVeiculosTrackingFields.Id;
                    if (DomainFieldTracked(policy, "CalendarioDisponibilidadeVeiculos", operation, recordId, "CDV_ID"))
                        mask |= CalendarioDisponibilidadeVeiculosTrackingFields.CDV_ID;
                    if (DomainFieldTracked(policy, "CalendarioDisponibilidadeVeiculos", operation, recordId, "CDV_DATA_DE"))
                        mask |= CalendarioDisponibilidadeVeiculosTrackingFields.CDV_DATA_DE;
                    if (DomainFieldTracked(policy, "CalendarioDisponibilidadeVeiculos", operation, recordId, "CDV_DATA_ATE"))
                        mask |= CalendarioDisponibilidadeVeiculosTrackingFields.CDV_DATA_ATE;
                    if (DomainFieldTracked(policy, "CalendarioDisponibilidadeVeiculos", operation, recordId, "CDV_SEGUNDA"))
                        mask |= CalendarioDisponibilidadeVeiculosTrackingFields.CDV_SEGUNDA;
                    if (DomainFieldTracked(policy, "CalendarioDisponibilidadeVeiculos", operation, recordId, "CDV_TERCA"))
                        mask |= CalendarioDisponibilidadeVeiculosTrackingFields.CDV_TERCA;
                    if (DomainFieldTracked(policy, "CalendarioDisponibilidadeVeiculos", operation, recordId, "CDV_QUARTA"))
                        mask |= CalendarioDisponibilidadeVeiculosTrackingFields.CDV_QUARTA;
                    if (DomainFieldTracked(policy, "CalendarioDisponibilidadeVeiculos", operation, recordId, "CDV_QUINTA"))
                        mask |= CalendarioDisponibilidadeVeiculosTrackingFields.CDV_QUINTA;
                    if (DomainFieldTracked(policy, "CalendarioDisponibilidadeVeiculos", operation, recordId, "CDV_SEXTA"))
                        mask |= CalendarioDisponibilidadeVeiculosTrackingFields.CDV_SEXTA;
                    if (DomainFieldTracked(policy, "CalendarioDisponibilidadeVeiculos", operation, recordId, "CDV_SABADO"))
                        mask |= CalendarioDisponibilidadeVeiculosTrackingFields.CDV_SABADO;
                    if (DomainFieldTracked(policy, "CalendarioDisponibilidadeVeiculos", operation, recordId, "CDV_DOMINGO"))
                        mask |= CalendarioDisponibilidadeVeiculosTrackingFields.CDV_DOMINGO;
                    if (DomainFieldTracked(policy, "CalendarioDisponibilidadeVeiculos", operation, recordId, "TenantID"))
                        mask |= CalendarioDisponibilidadeVeiculosTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "CalendarioDisponibilidadeVeiculos", operation, recordId, "Deleted"))
                        mask |= CalendarioDisponibilidadeVeiculosTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "CalendarioDisponibilidadeVeiculos", operation, recordId, "Changed"))
                        mask |= CalendarioDisponibilidadeVeiculosTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "CalendarioDisponibilidadeVeiculos", operation, recordId, "UserId"))
                        mask |= CalendarioDisponibilidadeVeiculosTrackingFields.UserId;
                    return mask;
                }

                private ulong GetCanhotosMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Canhotos", operation, recordId, "Id"))
                        mask |= CanhotosTrackingFields.Id;
                    if (DomainFieldTracked(policy, "Canhotos", operation, recordId, "CAR_ID"))
                        mask |= CanhotosTrackingFields.CAR_ID;
                    if (DomainFieldTracked(policy, "Canhotos", operation, recordId, "ORD_ID"))
                        mask |= CanhotosTrackingFields.ORD_ID;
                    if (DomainFieldTracked(policy, "Canhotos", operation, recordId, "NOT_ID"))
                        mask |= CanhotosTrackingFields.NOT_ID;
                    if (DomainFieldTracked(policy, "Canhotos", operation, recordId, "CAN_DATA_ENTREGA"))
                        mask |= CanhotosTrackingFields.CAN_DATA_ENTREGA;
                    if (DomainFieldTracked(policy, "Canhotos", operation, recordId, "CAN_IMG"))
                        mask |= CanhotosTrackingFields.CAN_IMG;
                    if (DomainFieldTracked(policy, "Canhotos", operation, recordId, "CAN_LAT_ENTREGA"))
                        mask |= CanhotosTrackingFields.CAN_LAT_ENTREGA;
                    if (DomainFieldTracked(policy, "Canhotos", operation, recordId, "CAN_LONG_ENTREGA"))
                        mask |= CanhotosTrackingFields.CAN_LONG_ENTREGA;
                    if (DomainFieldTracked(policy, "Canhotos", operation, recordId, "TenantID"))
                        mask |= CanhotosTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Canhotos", operation, recordId, "Deleted"))
                        mask |= CanhotosTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Canhotos", operation, recordId, "Changed"))
                        mask |= CanhotosTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Canhotos", operation, recordId, "UserId"))
                        mask |= CanhotosTrackingFields.UserId;
                    return mask;
                }

                private ulong GetCargaMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Carga", operation, recordId, "Id"))
                        mask |= CargaTrackingFields.Id;
                    if (DomainFieldTracked(policy, "Carga", operation, recordId, "CAR_ID"))
                        mask |= CargaTrackingFields.CAR_ID;
                    if (DomainFieldTracked(policy, "Carga", operation, recordId, "CAR_PREVISAO_MATERIA_PRIMA"))
                        mask |= CargaTrackingFields.CAR_PREVISAO_MATERIA_PRIMA;
                    if (DomainFieldTracked(policy, "Carga", operation, recordId, "CAR_DATA_INICIO_PREVISTO"))
                        mask |= CargaTrackingFields.CAR_DATA_INICIO_PREVISTO;
                    if (DomainFieldTracked(policy, "Carga", operation, recordId, "CAR_DATA_INICIO_REALIZADO"))
                        mask |= CargaTrackingFields.CAR_DATA_INICIO_REALIZADO;
                    if (DomainFieldTracked(policy, "Carga", operation, recordId, "CAR_DATA_FIM_PREVISTO"))
                        mask |= CargaTrackingFields.CAR_DATA_FIM_PREVISTO;
                    if (DomainFieldTracked(policy, "Carga", operation, recordId, "CAR_DATA_FIM_REALIZADO"))
                        mask |= CargaTrackingFields.CAR_DATA_FIM_REALIZADO;
                    if (DomainFieldTracked(policy, "Carga", operation, recordId, "CAR_INICIO_JANELA_EMBARQUE"))
                        mask |= CargaTrackingFields.CAR_INICIO_JANELA_EMBARQUE;
                    if (DomainFieldTracked(policy, "Carga", operation, recordId, "CAR_FIM_JANELA_EMBARQUE"))
                        mask |= CargaTrackingFields.CAR_FIM_JANELA_EMBARQUE;
                    if (DomainFieldTracked(policy, "Carga", operation, recordId, "CAR_EMBARQUE_ALVO"))
                        mask |= CargaTrackingFields.CAR_EMBARQUE_ALVO;
                    if (DomainFieldTracked(policy, "Carga", operation, recordId, "CAR_STATUS"))
                        mask |= CargaTrackingFields.CAR_STATUS;
                    if (DomainFieldTracked(policy, "Carga", operation, recordId, "CAR_PESO_TEORICO"))
                        mask |= CargaTrackingFields.CAR_PESO_TEORICO;
                    if (DomainFieldTracked(policy, "Carga", operation, recordId, "CAR_VOLUME_TEORICO"))
                        mask |= CargaTrackingFields.CAR_VOLUME_TEORICO;
                    if (DomainFieldTracked(policy, "Carga", operation, recordId, "CAR_PESO_REAL"))
                        mask |= CargaTrackingFields.CAR_PESO_REAL;
                    if (DomainFieldTracked(policy, "Carga", operation, recordId, "CAR_VOLUME_REAL"))
                        mask |= CargaTrackingFields.CAR_VOLUME_REAL;
                    if (DomainFieldTracked(policy, "Carga", operation, recordId, "CAR_PESO_EMBALAGEM"))
                        mask |= CargaTrackingFields.CAR_PESO_EMBALAGEM;
                    if (DomainFieldTracked(policy, "Carga", operation, recordId, "CAR_PESO_ENTRADA"))
                        mask |= CargaTrackingFields.CAR_PESO_ENTRADA;
                    if (DomainFieldTracked(policy, "Carga", operation, recordId, "CAR_PESO_SAIDA"))
                        mask |= CargaTrackingFields.CAR_PESO_SAIDA;
                    if (DomainFieldTracked(policy, "Carga", operation, recordId, "CAR_ID_DOCA"))
                        mask |= CargaTrackingFields.CAR_ID_DOCA;
                    if (DomainFieldTracked(policy, "Carga", operation, recordId, "VEI_PLACA"))
                        mask |= CargaTrackingFields.VEI_PLACA;
                    if (DomainFieldTracked(policy, "Carga", operation, recordId, "TIP_ID"))
                        mask |= CargaTrackingFields.TIP_ID;
                    if (DomainFieldTracked(policy, "Carga", operation, recordId, "TRA_ID"))
                        mask |= CargaTrackingFields.TRA_ID;
                    if (DomainFieldTracked(policy, "Carga", operation, recordId, "CAR_GRUPO_PRODUTIVO"))
                        mask |= CargaTrackingFields.CAR_GRUPO_PRODUTIVO;
                    if (DomainFieldTracked(policy, "Carga", operation, recordId, "ROT_ID"))
                        mask |= CargaTrackingFields.ROT_ID;
                    if (DomainFieldTracked(policy, "Carga", operation, recordId, "CAR_OBSERVACAO_DE_TRANSPORTE"))
                        mask |= CargaTrackingFields.CAR_OBSERVACAO_DE_TRANSPORTE;
                    if (DomainFieldTracked(policy, "Carga", operation, recordId, "CAR_JUSTIFICATIVA_DE_CARREGAMENTO"))
                        mask |= CargaTrackingFields.CAR_JUSTIFICATIVA_DE_CARREGAMENTO;
                    if (DomainFieldTracked(policy, "Carga", operation, recordId, "OCO_ID"))
                        mask |= CargaTrackingFields.OCO_ID;
                    if (DomainFieldTracked(policy, "Carga", operation, recordId, "CAR_ID_JUNTADA"))
                        mask |= CargaTrackingFields.CAR_ID_JUNTADA;
                    if (DomainFieldTracked(policy, "Carga", operation, recordId, "CAR_OBSERVACAO_OTIMIZADOR"))
                        mask |= CargaTrackingFields.CAR_OBSERVACAO_OTIMIZADOR;
                    if (DomainFieldTracked(policy, "Carga", operation, recordId, "CAR_ID_INTEGRACAO_BALANCA"))
                        mask |= CargaTrackingFields.CAR_ID_INTEGRACAO_BALANCA;
                    if (DomainFieldTracked(policy, "Carga", operation, recordId, "CAR_PESAGEM_LIBERADA"))
                        mask |= CargaTrackingFields.CAR_PESAGEM_LIBERADA;
                    if (DomainFieldTracked(policy, "Carga", operation, recordId, "CAR_OBS_LIERACAO"))
                        mask |= CargaTrackingFields.CAR_OBS_LIERACAO;
                    if (DomainFieldTracked(policy, "Carga", operation, recordId, "OCO_ID_LIERACAO"))
                        mask |= CargaTrackingFields.OCO_ID_LIERACAO;
                    if (DomainFieldTracked(policy, "Carga", operation, recordId, "CAR_DATA_ENTRADA_VEICULO"))
                        mask |= CargaTrackingFields.CAR_DATA_ENTRADA_VEICULO;
                    if (DomainFieldTracked(policy, "Carga", operation, recordId, "CAR_DATA_SAIDA_VEICULO"))
                        mask |= CargaTrackingFields.CAR_DATA_SAIDA_VEICULO;
                    if (DomainFieldTracked(policy, "Carga", operation, recordId, "CAR_DATA_ROMANEIO_CONSOLIDADO"))
                        mask |= CargaTrackingFields.CAR_DATA_ROMANEIO_CONSOLIDADO;
                    if (DomainFieldTracked(policy, "Carga", operation, recordId, "CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO"))
                        mask |= CargaTrackingFields.CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO;
                    if (DomainFieldTracked(policy, "Carga", operation, recordId, "CAR_DIFERENCA_PESAGEM"))
                        mask |= CargaTrackingFields.CAR_DIFERENCA_PESAGEM;
                    if (DomainFieldTracked(policy, "Carga", operation, recordId, "CAR_DATA_AGENCIAMENTO"))
                        mask |= CargaTrackingFields.CAR_DATA_AGENCIAMENTO;
                    if (DomainFieldTracked(policy, "Carga", operation, recordId, "TURN_ID"))
                        mask |= CargaTrackingFields.TURN_ID;
                    if (DomainFieldTracked(policy, "Carga", operation, recordId, "TURM_ID"))
                        mask |= CargaTrackingFields.TURM_ID;
                    if (DomainFieldTracked(policy, "Carga", operation, recordId, "TenantID"))
                        mask |= CargaTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Carga", operation, recordId, "Deleted"))
                        mask |= CargaTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Carga", operation, recordId, "Changed"))
                        mask |= CargaTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Carga", operation, recordId, "UserId"))
                        mask |= CargaTrackingFields.UserId;
                    return mask;
                }

                private ulong GetCargaPrevistaMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "CargaPrevista", operation, recordId, "Id"))
                        mask |= CargaPrevistaTrackingFields.Id;
                    if (DomainFieldTracked(policy, "CargaPrevista", operation, recordId, "CAR_ID"))
                        mask |= CargaPrevistaTrackingFields.CAR_ID;
                    if (DomainFieldTracked(policy, "CargaPrevista", operation, recordId, "ORD_ID"))
                        mask |= CargaPrevistaTrackingFields.ORD_ID;
                    if (DomainFieldTracked(policy, "CargaPrevista", operation, recordId, "ITC_QTD_PLANEJADA"))
                        mask |= CargaPrevistaTrackingFields.ITC_QTD_PLANEJADA;
                    if (DomainFieldTracked(policy, "CargaPrevista", operation, recordId, "CAR_PREVISAO_MATERIA_PRIMA"))
                        mask |= CargaPrevistaTrackingFields.CAR_PREVISAO_MATERIA_PRIMA;
                    if (DomainFieldTracked(policy, "CargaPrevista", operation, recordId, "CAR_DATA_INICIO_PREVISTO"))
                        mask |= CargaPrevistaTrackingFields.CAR_DATA_INICIO_PREVISTO;
                    if (DomainFieldTracked(policy, "CargaPrevista", operation, recordId, "CAR_DATA_INICIO_REALIZADO"))
                        mask |= CargaPrevistaTrackingFields.CAR_DATA_INICIO_REALIZADO;
                    if (DomainFieldTracked(policy, "CargaPrevista", operation, recordId, "CAR_DATA_FIM_PREVISTO"))
                        mask |= CargaPrevistaTrackingFields.CAR_DATA_FIM_PREVISTO;
                    if (DomainFieldTracked(policy, "CargaPrevista", operation, recordId, "CAR_DATA_FIM_REALIZADO"))
                        mask |= CargaPrevistaTrackingFields.CAR_DATA_FIM_REALIZADO;
                    if (DomainFieldTracked(policy, "CargaPrevista", operation, recordId, "CAR_INICIO_JANELA_EMBARQUE"))
                        mask |= CargaPrevistaTrackingFields.CAR_INICIO_JANELA_EMBARQUE;
                    if (DomainFieldTracked(policy, "CargaPrevista", operation, recordId, "CAR_FIM_JANELA_EMBARQUE"))
                        mask |= CargaPrevistaTrackingFields.CAR_FIM_JANELA_EMBARQUE;
                    if (DomainFieldTracked(policy, "CargaPrevista", operation, recordId, "CAR_EMBARQUE_ALVO"))
                        mask |= CargaPrevistaTrackingFields.CAR_EMBARQUE_ALVO;
                    if (DomainFieldTracked(policy, "CargaPrevista", operation, recordId, "CAR_STATUS"))
                        mask |= CargaPrevistaTrackingFields.CAR_STATUS;
                    if (DomainFieldTracked(policy, "CargaPrevista", operation, recordId, "CAR_PESO_TEORICO"))
                        mask |= CargaPrevistaTrackingFields.CAR_PESO_TEORICO;
                    if (DomainFieldTracked(policy, "CargaPrevista", operation, recordId, "CAR_VOLUME_TEORICO"))
                        mask |= CargaPrevistaTrackingFields.CAR_VOLUME_TEORICO;
                    if (DomainFieldTracked(policy, "CargaPrevista", operation, recordId, "CAR_PESO_REAL"))
                        mask |= CargaPrevistaTrackingFields.CAR_PESO_REAL;
                    if (DomainFieldTracked(policy, "CargaPrevista", operation, recordId, "CAR_VOLUME_REAL"))
                        mask |= CargaPrevistaTrackingFields.CAR_VOLUME_REAL;
                    if (DomainFieldTracked(policy, "CargaPrevista", operation, recordId, "CAR_PESO_EMBALAGEM"))
                        mask |= CargaPrevistaTrackingFields.CAR_PESO_EMBALAGEM;
                    if (DomainFieldTracked(policy, "CargaPrevista", operation, recordId, "CAR_PESO_ENTRADA"))
                        mask |= CargaPrevistaTrackingFields.CAR_PESO_ENTRADA;
                    if (DomainFieldTracked(policy, "CargaPrevista", operation, recordId, "CAR_PESO_SAIDA"))
                        mask |= CargaPrevistaTrackingFields.CAR_PESO_SAIDA;
                    if (DomainFieldTracked(policy, "CargaPrevista", operation, recordId, "CAR_ID_DOCA"))
                        mask |= CargaPrevistaTrackingFields.CAR_ID_DOCA;
                    if (DomainFieldTracked(policy, "CargaPrevista", operation, recordId, "VEI_PLACA"))
                        mask |= CargaPrevistaTrackingFields.VEI_PLACA;
                    if (DomainFieldTracked(policy, "CargaPrevista", operation, recordId, "TIP_ID"))
                        mask |= CargaPrevistaTrackingFields.TIP_ID;
                    if (DomainFieldTracked(policy, "CargaPrevista", operation, recordId, "TRA_ID"))
                        mask |= CargaPrevistaTrackingFields.TRA_ID;
                    if (DomainFieldTracked(policy, "CargaPrevista", operation, recordId, "CAR_GRUPO_PRODUTIVO"))
                        mask |= CargaPrevistaTrackingFields.CAR_GRUPO_PRODUTIVO;
                    if (DomainFieldTracked(policy, "CargaPrevista", operation, recordId, "ROT_ID"))
                        mask |= CargaPrevistaTrackingFields.ROT_ID;
                    if (DomainFieldTracked(policy, "CargaPrevista", operation, recordId, "CAR_OBSERVACAO_DE_TRANSPORTE"))
                        mask |= CargaPrevistaTrackingFields.CAR_OBSERVACAO_DE_TRANSPORTE;
                    if (DomainFieldTracked(policy, "CargaPrevista", operation, recordId, "CAR_JUSTIFICATIVA_DE_CARREGAMENTO"))
                        mask |= CargaPrevistaTrackingFields.CAR_JUSTIFICATIVA_DE_CARREGAMENTO;
                    if (DomainFieldTracked(policy, "CargaPrevista", operation, recordId, "OCO_ID"))
                        mask |= CargaPrevistaTrackingFields.OCO_ID;
                    if (DomainFieldTracked(policy, "CargaPrevista", operation, recordId, "CAR_ID_JUNTADA"))
                        mask |= CargaPrevistaTrackingFields.CAR_ID_JUNTADA;
                    if (DomainFieldTracked(policy, "CargaPrevista", operation, recordId, "CAR_OBSERVACAO_OTIMIZADOR"))
                        mask |= CargaPrevistaTrackingFields.CAR_OBSERVACAO_OTIMIZADOR;
                    if (DomainFieldTracked(policy, "CargaPrevista", operation, recordId, "TenantID"))
                        mask |= CargaPrevistaTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "CargaPrevista", operation, recordId, "Deleted"))
                        mask |= CargaPrevistaTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "CargaPrevista", operation, recordId, "Changed"))
                        mask |= CargaPrevistaTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "CargaPrevista", operation, recordId, "UserId"))
                        mask |= CargaPrevistaTrackingFields.UserId;
                    return mask;
                }

                private ulong GetCargosMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Cargos", operation, recordId, "Id"))
                        mask |= CargosTrackingFields.Id;
                    if (DomainFieldTracked(policy, "Cargos", operation, recordId, "RGO_ID"))
                        mask |= CargosTrackingFields.RGO_ID;
                    if (DomainFieldTracked(policy, "Cargos", operation, recordId, "RGO_DESCRICAO"))
                        mask |= CargosTrackingFields.RGO_DESCRICAO;
                    if (DomainFieldTracked(policy, "Cargos", operation, recordId, "TenantID"))
                        mask |= CargosTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Cargos", operation, recordId, "Deleted"))
                        mask |= CargosTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Cargos", operation, recordId, "Changed"))
                        mask |= CargosTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Cargos", operation, recordId, "UserId"))
                        mask |= CargosTrackingFields.UserId;
                    return mask;
                }

                private ulong GetClienteMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Cliente", operation, recordId, "CLI_ID"))
                        mask |= ClienteTrackingFields.CLI_ID;
                    if (DomainFieldTracked(policy, "Cliente", operation, recordId, "CLI_NOME"))
                        mask |= ClienteTrackingFields.CLI_NOME;
                    if (DomainFieldTracked(policy, "Cliente", operation, recordId, "CLI_FONE"))
                        mask |= ClienteTrackingFields.CLI_FONE;
                    if (DomainFieldTracked(policy, "Cliente", operation, recordId, "CLI_OBS"))
                        mask |= ClienteTrackingFields.CLI_OBS;
                    if (DomainFieldTracked(policy, "Cliente", operation, recordId, "CLI_ENDERECO_ENTREGA"))
                        mask |= ClienteTrackingFields.CLI_ENDERECO_ENTREGA;
                    if (DomainFieldTracked(policy, "Cliente", operation, recordId, "CLI_CPF_CNPJ"))
                        mask |= ClienteTrackingFields.CLI_CPF_CNPJ;
                    if (DomainFieldTracked(policy, "Cliente", operation, recordId, "CLI_BAIRRO_ENTREGA"))
                        mask |= ClienteTrackingFields.CLI_BAIRRO_ENTREGA;
                    if (DomainFieldTracked(policy, "Cliente", operation, recordId, "CLI_CEP_ENTREGA"))
                        mask |= ClienteTrackingFields.CLI_CEP_ENTREGA;
                    if (DomainFieldTracked(policy, "Cliente", operation, recordId, "CLI_EMAIL"))
                        mask |= ClienteTrackingFields.CLI_EMAIL;
                    if (DomainFieldTracked(policy, "Cliente", operation, recordId, "CLI_INTEGRACAO"))
                        mask |= ClienteTrackingFields.CLI_INTEGRACAO;
                    if (DomainFieldTracked(policy, "Cliente", operation, recordId, "MUN_ID_ENTREGA"))
                        mask |= ClienteTrackingFields.MUN_ID_ENTREGA;
                    if (DomainFieldTracked(policy, "Cliente", operation, recordId, "CLI_TRANSLADO"))
                        mask |= ClienteTrackingFields.CLI_TRANSLADO;
                    if (DomainFieldTracked(policy, "Cliente", operation, recordId, "CLI_REGIAO_ENTREGA"))
                        mask |= ClienteTrackingFields.CLI_REGIAO_ENTREGA;
                    if (DomainFieldTracked(policy, "Cliente", operation, recordId, "CLI_EXIGENTE_NA_IMPRESSAO"))
                        mask |= ClienteTrackingFields.CLI_EXIGENTE_NA_IMPRESSAO;
                    if (DomainFieldTracked(policy, "Cliente", operation, recordId, "CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO"))
                        mask |= ClienteTrackingFields.CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO;
                    if (DomainFieldTracked(policy, "Cliente", operation, recordId, "CLI_TEMPO_DESCARREGAMENTO_UNITARIO"))
                        mask |= ClienteTrackingFields.CLI_TEMPO_DESCARREGAMENTO_UNITARIO;
                    if (DomainFieldTracked(policy, "Cliente", operation, recordId, "CLI_PERCENTUAL_JANELA_EMBARQUE"))
                        mask |= ClienteTrackingFields.CLI_PERCENTUAL_JANELA_EMBARQUE;
                    if (DomainFieldTracked(policy, "Cliente", operation, recordId, "REP_ID"))
                        mask |= ClienteTrackingFields.REP_ID;
                    if (DomainFieldTracked(policy, "Cliente", operation, recordId, "CLI_RAZAO_SOCIAL"))
                        mask |= ClienteTrackingFields.CLI_RAZAO_SOCIAL;
                    if (DomainFieldTracked(policy, "Cliente", operation, recordId, "CLI_EMAIL_MONITORAMENTO_TRANSPORTE"))
                        mask |= ClienteTrackingFields.CLI_EMAIL_MONITORAMENTO_TRANSPORTE;
                    if (DomainFieldTracked(policy, "Cliente", operation, recordId, "CLI_CONTATO"))
                        mask |= ClienteTrackingFields.CLI_CONTATO;
                    if (DomainFieldTracked(policy, "Cliente", operation, recordId, "CLI_SETOR"))
                        mask |= ClienteTrackingFields.CLI_SETOR;
                    if (DomainFieldTracked(policy, "Cliente", operation, recordId, "SEG_ID"))
                        mask |= ClienteTrackingFields.SEG_ID;
                    if (DomainFieldTracked(policy, "Cliente", operation, recordId, "CLI_TIPO"))
                        mask |= ClienteTrackingFields.CLI_TIPO;
                    if (DomainFieldTracked(policy, "Cliente", operation, recordId, "CLI_INTEGRACAO_ERP"))
                        mask |= ClienteTrackingFields.CLI_INTEGRACAO_ERP;
                    if (DomainFieldTracked(policy, "Cliente", operation, recordId, "CLI_LATITUDE_ENTREGA"))
                        mask |= ClienteTrackingFields.CLI_LATITUDE_ENTREGA;
                    if (DomainFieldTracked(policy, "Cliente", operation, recordId, "CLI_LONGITUDE_ENTREGA"))
                        mask |= ClienteTrackingFields.CLI_LONGITUDE_ENTREGA;
                    if (DomainFieldTracked(policy, "Cliente", operation, recordId, "TenantID"))
                        mask |= ClienteTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Cliente", operation, recordId, "Deleted"))
                        mask |= ClienteTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Cliente", operation, recordId, "Changed"))
                        mask |= ClienteTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Cliente", operation, recordId, "UserId"))
                        mask |= ClienteTrackingFields.UserId;
                    return mask;
                }

                private ulong GetClpMedicoesMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "ClpMedicoes", operation, recordId, "Id"))
                        mask |= ClpMedicoesTrackingFields.Id;
                    if (DomainFieldTracked(policy, "ClpMedicoes", operation, recordId, "Id2"))
                        mask |= ClpMedicoesTrackingFields.Id2;
                    if (DomainFieldTracked(policy, "ClpMedicoes", operation, recordId, "MaquinaId"))
                        mask |= ClpMedicoesTrackingFields.MaquinaId;
                    if (DomainFieldTracked(policy, "ClpMedicoes", operation, recordId, "DataInicio"))
                        mask |= ClpMedicoesTrackingFields.DataInicio;
                    if (DomainFieldTracked(policy, "ClpMedicoes", operation, recordId, "DataFim"))
                        mask |= ClpMedicoesTrackingFields.DataFim;
                    if (DomainFieldTracked(policy, "ClpMedicoes", operation, recordId, "Emissao"))
                        mask |= ClpMedicoesTrackingFields.Emissao;
                    if (DomainFieldTracked(policy, "ClpMedicoes", operation, recordId, "Quantidade"))
                        mask |= ClpMedicoesTrackingFields.Quantidade;
                    if (DomainFieldTracked(policy, "ClpMedicoes", operation, recordId, "Grupo"))
                        mask |= ClpMedicoesTrackingFields.Grupo;
                    if (DomainFieldTracked(policy, "ClpMedicoes", operation, recordId, "Status"))
                        mask |= ClpMedicoesTrackingFields.Status;
                    if (DomainFieldTracked(policy, "ClpMedicoes", operation, recordId, "TurnoId"))
                        mask |= ClpMedicoesTrackingFields.TurnoId;
                    if (DomainFieldTracked(policy, "ClpMedicoes", operation, recordId, "TurmaId"))
                        mask |= ClpMedicoesTrackingFields.TurmaId;
                    if (DomainFieldTracked(policy, "ClpMedicoes", operation, recordId, "IdLoteClp"))
                        mask |= ClpMedicoesTrackingFields.IdLoteClp;
                    if (DomainFieldTracked(policy, "ClpMedicoes", operation, recordId, "OcorrenciaId"))
                        mask |= ClpMedicoesTrackingFields.OcorrenciaId;
                    if (DomainFieldTracked(policy, "ClpMedicoes", operation, recordId, "Fase"))
                        mask |= ClpMedicoesTrackingFields.Fase;
                    if (DomainFieldTracked(policy, "ClpMedicoes", operation, recordId, "ClpOrigem"))
                        mask |= ClpMedicoesTrackingFields.ClpOrigem;
                    if (DomainFieldTracked(policy, "ClpMedicoes", operation, recordId, "CLP_LOTE"))
                        mask |= ClpMedicoesTrackingFields.CLP_LOTE;
                    if (DomainFieldTracked(policy, "ClpMedicoes", operation, recordId, "COMPACTA"))
                        mask |= ClpMedicoesTrackingFields.COMPACTA;
                    if (DomainFieldTracked(policy, "ClpMedicoes", operation, recordId, "BOL_ID"))
                        mask |= ClpMedicoesTrackingFields.BOL_ID;
                    if (DomainFieldTracked(policy, "ClpMedicoes", operation, recordId, "COR_SEQUENCIA"))
                        mask |= ClpMedicoesTrackingFields.COR_SEQUENCIA;
                    if (DomainFieldTracked(policy, "ClpMedicoes", operation, recordId, "TenantID"))
                        mask |= ClpMedicoesTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "ClpMedicoes", operation, recordId, "Deleted"))
                        mask |= ClpMedicoesTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "ClpMedicoes", operation, recordId, "Changed"))
                        mask |= ClpMedicoesTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "ClpMedicoes", operation, recordId, "UserId"))
                        mask |= ClpMedicoesTrackingFields.UserId;
                    return mask;
                }

                private ulong GetClpMedicoesHMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "ClpMedicoesH", operation, recordId, "ID"))
                        mask |= ClpMedicoesHTrackingFields.ID;
                    if (DomainFieldTracked(policy, "ClpMedicoesH", operation, recordId, "MAQUINA_ID"))
                        mask |= ClpMedicoesHTrackingFields.MAQUINA_ID;
                    if (DomainFieldTracked(policy, "ClpMedicoesH", operation, recordId, "DATA_INI"))
                        mask |= ClpMedicoesHTrackingFields.DATA_INI;
                    if (DomainFieldTracked(policy, "ClpMedicoesH", operation, recordId, "DATA_FIM"))
                        mask |= ClpMedicoesHTrackingFields.DATA_FIM;
                    if (DomainFieldTracked(policy, "ClpMedicoesH", operation, recordId, "CLP_EMISSAO"))
                        mask |= ClpMedicoesHTrackingFields.CLP_EMISSAO;
                    if (DomainFieldTracked(policy, "ClpMedicoesH", operation, recordId, "QTD"))
                        mask |= ClpMedicoesHTrackingFields.QTD;
                    if (DomainFieldTracked(policy, "ClpMedicoesH", operation, recordId, "GRUPO"))
                        mask |= ClpMedicoesHTrackingFields.GRUPO;
                    if (DomainFieldTracked(policy, "ClpMedicoesH", operation, recordId, "STATUS"))
                        mask |= ClpMedicoesHTrackingFields.STATUS;
                    if (DomainFieldTracked(policy, "ClpMedicoesH", operation, recordId, "URN_ID"))
                        mask |= ClpMedicoesHTrackingFields.URN_ID;
                    if (DomainFieldTracked(policy, "ClpMedicoesH", operation, recordId, "URM_ID"))
                        mask |= ClpMedicoesHTrackingFields.URM_ID;
                    if (DomainFieldTracked(policy, "ClpMedicoesH", operation, recordId, "ID_LOTE_CLP"))
                        mask |= ClpMedicoesHTrackingFields.ID_LOTE_CLP;
                    if (DomainFieldTracked(policy, "ClpMedicoesH", operation, recordId, "OCO_ID"))
                        mask |= ClpMedicoesHTrackingFields.OCO_ID;
                    if (DomainFieldTracked(policy, "ClpMedicoesH", operation, recordId, "FASE"))
                        mask |= ClpMedicoesHTrackingFields.FASE;
                    if (DomainFieldTracked(policy, "ClpMedicoesH", operation, recordId, "CLP_ORIGEM"))
                        mask |= ClpMedicoesHTrackingFields.CLP_ORIGEM;
                    if (DomainFieldTracked(policy, "ClpMedicoesH", operation, recordId, "CLP_LOTE"))
                        mask |= ClpMedicoesHTrackingFields.CLP_LOTE;
                    if (DomainFieldTracked(policy, "ClpMedicoesH", operation, recordId, "COMPACTA"))
                        mask |= ClpMedicoesHTrackingFields.COMPACTA;
                    if (DomainFieldTracked(policy, "ClpMedicoesH", operation, recordId, "BOL_ID"))
                        mask |= ClpMedicoesHTrackingFields.BOL_ID;
                    if (DomainFieldTracked(policy, "ClpMedicoesH", operation, recordId, "COR_SEQUENCIA"))
                        mask |= ClpMedicoesHTrackingFields.COR_SEQUENCIA;
                    if (DomainFieldTracked(policy, "ClpMedicoesH", operation, recordId, "TenantID"))
                        mask |= ClpMedicoesHTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "ClpMedicoesH", operation, recordId, "Deleted"))
                        mask |= ClpMedicoesHTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "ClpMedicoesH", operation, recordId, "Changed"))
                        mask |= ClpMedicoesHTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "ClpMedicoesH", operation, recordId, "UserId"))
                        mask |= ClpMedicoesHTrackingFields.UserId;
                    return mask;
                }

                private ulong GetColaboradorMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Colaborador", operation, recordId, "COL_CPF"))
                        mask |= ColaboradorTrackingFields.COL_CPF;
                    if (DomainFieldTracked(policy, "Colaborador", operation, recordId, "COL_NOME"))
                        mask |= ColaboradorTrackingFields.COL_NOME;
                    if (DomainFieldTracked(policy, "Colaborador", operation, recordId, "COL_NASCIMENTO"))
                        mask |= ColaboradorTrackingFields.COL_NASCIMENTO;
                    if (DomainFieldTracked(policy, "Colaborador", operation, recordId, "COL_EMAIL"))
                        mask |= ColaboradorTrackingFields.COL_EMAIL;
                    if (DomainFieldTracked(policy, "Colaborador", operation, recordId, "COL_MATRICULA"))
                        mask |= ColaboradorTrackingFields.COL_MATRICULA;
                    if (DomainFieldTracked(policy, "Colaborador", operation, recordId, "TURM_id"))
                        mask |= ColaboradorTrackingFields.TURM_id;
                    if (DomainFieldTracked(policy, "Colaborador", operation, recordId, "TenantID"))
                        mask |= ColaboradorTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Colaborador", operation, recordId, "Deleted"))
                        mask |= ColaboradorTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Colaborador", operation, recordId, "Changed"))
                        mask |= ColaboradorTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Colaborador", operation, recordId, "UserId"))
                        mask |= ColaboradorTrackingFields.UserId;
                    return mask;
                }

                private ulong GetCompensacaoMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Compensacao", operation, recordId, "Id"))
                        mask |= CompensacaoTrackingFields.Id;
                    if (DomainFieldTracked(policy, "Compensacao", operation, recordId, "COM_ID"))
                        mask |= CompensacaoTrackingFields.COM_ID;
                    if (DomainFieldTracked(policy, "Compensacao", operation, recordId, "GRP_ID"))
                        mask |= CompensacaoTrackingFields.GRP_ID;
                    if (DomainFieldTracked(policy, "Compensacao", operation, recordId, "OND_ID"))
                        mask |= CompensacaoTrackingFields.OND_ID;
                    if (DomainFieldTracked(policy, "Compensacao", operation, recordId, "COM_VINCO1_OND"))
                        mask |= CompensacaoTrackingFields.COM_VINCO1_OND;
                    if (DomainFieldTracked(policy, "Compensacao", operation, recordId, "COM_VINCO2_OND"))
                        mask |= CompensacaoTrackingFields.COM_VINCO2_OND;
                    if (DomainFieldTracked(policy, "Compensacao", operation, recordId, "COM_VINCO3_OND"))
                        mask |= CompensacaoTrackingFields.COM_VINCO3_OND;
                    if (DomainFieldTracked(policy, "Compensacao", operation, recordId, "COM_VINCO4_OND"))
                        mask |= CompensacaoTrackingFields.COM_VINCO4_OND;
                    if (DomainFieldTracked(policy, "Compensacao", operation, recordId, "COM_VINCO5_OND"))
                        mask |= CompensacaoTrackingFields.COM_VINCO5_OND;
                    if (DomainFieldTracked(policy, "Compensacao", operation, recordId, "COM_VINCO6_OND"))
                        mask |= CompensacaoTrackingFields.COM_VINCO6_OND;
                    if (DomainFieldTracked(policy, "Compensacao", operation, recordId, "COM_VINCO7_OND"))
                        mask |= CompensacaoTrackingFields.COM_VINCO7_OND;
                    if (DomainFieldTracked(policy, "Compensacao", operation, recordId, "COM_VINCO8_OND"))
                        mask |= CompensacaoTrackingFields.COM_VINCO8_OND;
                    if (DomainFieldTracked(policy, "Compensacao", operation, recordId, "COM_VINCO9_OND"))
                        mask |= CompensacaoTrackingFields.COM_VINCO9_OND;
                    if (DomainFieldTracked(policy, "Compensacao", operation, recordId, "COM_VINCO10_OND"))
                        mask |= CompensacaoTrackingFields.COM_VINCO10_OND;
                    if (DomainFieldTracked(policy, "Compensacao", operation, recordId, "COM_VINCO1_CONVERSAO"))
                        mask |= CompensacaoTrackingFields.COM_VINCO1_CONVERSAO;
                    if (DomainFieldTracked(policy, "Compensacao", operation, recordId, "COM_VINCO2_CONVERSAO"))
                        mask |= CompensacaoTrackingFields.COM_VINCO2_CONVERSAO;
                    if (DomainFieldTracked(policy, "Compensacao", operation, recordId, "COM_VINCO3_CONVERSAO"))
                        mask |= CompensacaoTrackingFields.COM_VINCO3_CONVERSAO;
                    if (DomainFieldTracked(policy, "Compensacao", operation, recordId, "COM_VINCO4_CONVERSAO"))
                        mask |= CompensacaoTrackingFields.COM_VINCO4_CONVERSAO;
                    if (DomainFieldTracked(policy, "Compensacao", operation, recordId, "COM_VINCO5_CONVERSAO"))
                        mask |= CompensacaoTrackingFields.COM_VINCO5_CONVERSAO;
                    if (DomainFieldTracked(policy, "Compensacao", operation, recordId, "COM_VINCO6_CONVERSAO"))
                        mask |= CompensacaoTrackingFields.COM_VINCO6_CONVERSAO;
                    if (DomainFieldTracked(policy, "Compensacao", operation, recordId, "COM_VINCO7_CONVERSAO"))
                        mask |= CompensacaoTrackingFields.COM_VINCO7_CONVERSAO;
                    if (DomainFieldTracked(policy, "Compensacao", operation, recordId, "COM_VINCO8_CONVERSAO"))
                        mask |= CompensacaoTrackingFields.COM_VINCO8_CONVERSAO;
                    if (DomainFieldTracked(policy, "Compensacao", operation, recordId, "COM_VINCO9_CONVERSAO"))
                        mask |= CompensacaoTrackingFields.COM_VINCO9_CONVERSAO;
                    if (DomainFieldTracked(policy, "Compensacao", operation, recordId, "COM_VINCO10_CONVERSAO"))
                        mask |= CompensacaoTrackingFields.COM_VINCO10_CONVERSAO;
                    if (DomainFieldTracked(policy, "Compensacao", operation, recordId, "TenantID"))
                        mask |= CompensacaoTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Compensacao", operation, recordId, "Deleted"))
                        mask |= CompensacaoTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Compensacao", operation, recordId, "Changed"))
                        mask |= CompensacaoTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Compensacao", operation, recordId, "UserId"))
                        mask |= CompensacaoTrackingFields.UserId;
                    return mask;
                }

                private ulong GetCondicaoPagamentoMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "CondicaoPagamento", operation, recordId, "Id"))
                        mask |= CondicaoPagamentoTrackingFields.Id;
                    if (DomainFieldTracked(policy, "CondicaoPagamento", operation, recordId, "CON_ID"))
                        mask |= CondicaoPagamentoTrackingFields.CON_ID;
                    if (DomainFieldTracked(policy, "CondicaoPagamento", operation, recordId, "CON_DESCRICAO"))
                        mask |= CondicaoPagamentoTrackingFields.CON_DESCRICAO;
                    if (DomainFieldTracked(policy, "CondicaoPagamento", operation, recordId, "CON_PARCELAS"))
                        mask |= CondicaoPagamentoTrackingFields.CON_PARCELAS;
                    if (DomainFieldTracked(policy, "CondicaoPagamento", operation, recordId, "CON_VALOR_ACRECIMO"))
                        mask |= CondicaoPagamentoTrackingFields.CON_VALOR_ACRECIMO;
                    if (DomainFieldTracked(policy, "CondicaoPagamento", operation, recordId, "CON_INTEGRACAO_ERP"))
                        mask |= CondicaoPagamentoTrackingFields.CON_INTEGRACAO_ERP;
                    if (DomainFieldTracked(policy, "CondicaoPagamento", operation, recordId, "TenantID"))
                        mask |= CondicaoPagamentoTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "CondicaoPagamento", operation, recordId, "Deleted"))
                        mask |= CondicaoPagamentoTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "CondicaoPagamento", operation, recordId, "Changed"))
                        mask |= CondicaoPagamentoTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "CondicaoPagamento", operation, recordId, "UserId"))
                        mask |= CondicaoPagamentoTrackingFields.UserId;
                    return mask;
                }

                private ulong GetConfiguracoesMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Configuracoes", operation, recordId, "CON_ID"))
                        mask |= ConfiguracoesTrackingFields.CON_ID;
                    if (DomainFieldTracked(policy, "Configuracoes", operation, recordId, "TenantID"))
                        mask |= ConfiguracoesTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Configuracoes", operation, recordId, "Deleted"))
                        mask |= ConfiguracoesTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Configuracoes", operation, recordId, "Changed"))
                        mask |= ConfiguracoesTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Configuracoes", operation, recordId, "UserId"))
                        mask |= ConfiguracoesTrackingFields.UserId;
                    return mask;
                }

                private ulong GetConsultasMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Consultas", operation, recordId, "Id"))
                        mask |= ConsultasTrackingFields.Id;
                    if (DomainFieldTracked(policy, "Consultas", operation, recordId, "CON_CASAS_DECIMAIS"))
                        mask |= ConsultasTrackingFields.CON_CASAS_DECIMAIS;
                    if (DomainFieldTracked(policy, "Consultas", operation, recordId, "CON_CONEXAO"))
                        mask |= ConsultasTrackingFields.CON_CONEXAO;
                    if (DomainFieldTracked(policy, "Consultas", operation, recordId, "TenantID"))
                        mask |= ConsultasTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Consultas", operation, recordId, "Deleted"))
                        mask |= ConsultasTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Consultas", operation, recordId, "Changed"))
                        mask |= ConsultasTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Consultas", operation, recordId, "UserId"))
                        mask |= ConsultasTrackingFields.UserId;
                    return mask;
                }

                private ulong GetConsultasGruposMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "ConsultasGrupos", operation, recordId, "Id"))
                        mask |= ConsultasGruposTrackingFields.Id;
                    if (DomainFieldTracked(policy, "ConsultasGrupos", operation, recordId, "CON_ID"))
                        mask |= ConsultasGruposTrackingFields.CON_ID;
                    if (DomainFieldTracked(policy, "ConsultasGrupos", operation, recordId, "GRU_ID"))
                        mask |= ConsultasGruposTrackingFields.GRU_ID;
                    if (DomainFieldTracked(policy, "ConsultasGrupos", operation, recordId, "TenantID"))
                        mask |= ConsultasGruposTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "ConsultasGrupos", operation, recordId, "Deleted"))
                        mask |= ConsultasGruposTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "ConsultasGrupos", operation, recordId, "Changed"))
                        mask |= ConsultasGruposTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "ConsultasGrupos", operation, recordId, "UserId"))
                        mask |= ConsultasGruposTrackingFields.UserId;
                    return mask;
                }

                private ulong GetConsultasIndicadoresMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "ConsultasIndicadores", operation, recordId, "Id"))
                        mask |= ConsultasIndicadoresTrackingFields.Id;
                    if (DomainFieldTracked(policy, "ConsultasIndicadores", operation, recordId, "CON_ID"))
                        mask |= ConsultasIndicadoresTrackingFields.CON_ID;
                    if (DomainFieldTracked(policy, "ConsultasIndicadores", operation, recordId, "IND_ID"))
                        mask |= ConsultasIndicadoresTrackingFields.IND_ID;
                    if (DomainFieldTracked(policy, "ConsultasIndicadores", operation, recordId, "TenantID"))
                        mask |= ConsultasIndicadoresTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "ConsultasIndicadores", operation, recordId, "Deleted"))
                        mask |= ConsultasIndicadoresTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "ConsultasIndicadores", operation, recordId, "Changed"))
                        mask |= ConsultasIndicadoresTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "ConsultasIndicadores", operation, recordId, "UserId"))
                        mask |= ConsultasIndicadoresTrackingFields.UserId;
                    return mask;
                }

                private ulong GetCorConfiguracaoGraficoMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "CorConfiguracaoGrafico", operation, recordId, "COR_ID"))
                        mask |= CorConfiguracaoGraficoTrackingFields.COR_ID;
                    if (DomainFieldTracked(policy, "CorConfiguracaoGrafico", operation, recordId, "COR_PERCENTUAL_INI"))
                        mask |= CorConfiguracaoGraficoTrackingFields.COR_PERCENTUAL_INI;
                    if (DomainFieldTracked(policy, "CorConfiguracaoGrafico", operation, recordId, "COR_PERCENTUAL_FIM"))
                        mask |= CorConfiguracaoGraficoTrackingFields.COR_PERCENTUAL_FIM;
                    if (DomainFieldTracked(policy, "CorConfiguracaoGrafico", operation, recordId, "COR_DESCRICAO"))
                        mask |= CorConfiguracaoGraficoTrackingFields.COR_DESCRICAO;
                    if (DomainFieldTracked(policy, "CorConfiguracaoGrafico", operation, recordId, "TenantID"))
                        mask |= CorConfiguracaoGraficoTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "CorConfiguracaoGrafico", operation, recordId, "Deleted"))
                        mask |= CorConfiguracaoGraficoTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "CorConfiguracaoGrafico", operation, recordId, "Changed"))
                        mask |= CorConfiguracaoGraficoTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "CorConfiguracaoGrafico", operation, recordId, "UserId"))
                        mask |= CorConfiguracaoGraficoTrackingFields.UserId;
                    return mask;
                }

                private ulong GetCorridasOnduladeiraMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "CorridasOnduladeira", operation, recordId, "BOL_ID"))
                        mask |= CorridasOnduladeiraTrackingFields.BOL_ID;
                    if (DomainFieldTracked(policy, "CorridasOnduladeira", operation, recordId, "BOL_ID_ORIGEM"))
                        mask |= CorridasOnduladeiraTrackingFields.BOL_ID_ORIGEM;
                    if (DomainFieldTracked(policy, "CorridasOnduladeira", operation, recordId, "PRO_LARGURA_PECA"))
                        mask |= CorridasOnduladeiraTrackingFields.PRO_LARGURA_PECA;
                    if (DomainFieldTracked(policy, "CorridasOnduladeira", operation, recordId, "PRO_LARGURA_PECA_PROGRAMADO"))
                        mask |= CorridasOnduladeiraTrackingFields.PRO_LARGURA_PECA_PROGRAMADO;
                    if (DomainFieldTracked(policy, "CorridasOnduladeira", operation, recordId, "PRO_COMPRIMENTO_PECA"))
                        mask |= CorridasOnduladeiraTrackingFields.PRO_COMPRIMENTO_PECA;
                    if (DomainFieldTracked(policy, "CorridasOnduladeira", operation, recordId, "PRO_COMPRIMENTO_PECA_PROGRAMADO"))
                        mask |= CorridasOnduladeiraTrackingFields.PRO_COMPRIMENTO_PECA_PROGRAMADO;
                    if (DomainFieldTracked(policy, "CorridasOnduladeira", operation, recordId, "PRO_UTILIZOU_REFILE_OBRIGATORIO"))
                        mask |= CorridasOnduladeiraTrackingFields.PRO_UTILIZOU_REFILE_OBRIGATORIO;
                    if (DomainFieldTracked(policy, "CorridasOnduladeira", operation, recordId, "PRO_VINCOS_RECALCULADOS"))
                        mask |= CorridasOnduladeiraTrackingFields.PRO_VINCOS_RECALCULADOS;
                    if (DomainFieldTracked(policy, "CorridasOnduladeira", operation, recordId, "COR_SOLVER"))
                        mask |= CorridasOnduladeiraTrackingFields.COR_SOLVER;
                    if (DomainFieldTracked(policy, "CorridasOnduladeira", operation, recordId, "COR_GRAMATURA_PAPEIS_PROGRAMADOS"))
                        mask |= CorridasOnduladeiraTrackingFields.COR_GRAMATURA_PAPEIS_PROGRAMADOS;
                    if (DomainFieldTracked(policy, "CorridasOnduladeira", operation, recordId, "COR_CUSTO_PAPEIS_PROGRAMADOS"))
                        mask |= CorridasOnduladeiraTrackingFields.COR_CUSTO_PAPEIS_PROGRAMADOS;
                    if (DomainFieldTracked(policy, "CorridasOnduladeira", operation, recordId, "COR_GRAMATURA_RESINA_PROGRAMADOS"))
                        mask |= CorridasOnduladeiraTrackingFields.COR_GRAMATURA_RESINA_PROGRAMADOS;
                    if (DomainFieldTracked(policy, "CorridasOnduladeira", operation, recordId, "COR_CUSTO_RESINA_PROGRAMADOS"))
                        mask |= CorridasOnduladeiraTrackingFields.COR_CUSTO_RESINA_PROGRAMADOS;
                    if (DomainFieldTracked(policy, "CorridasOnduladeira", operation, recordId, "COR_TOLERANCIA_MENOS"))
                        mask |= CorridasOnduladeiraTrackingFields.COR_TOLERANCIA_MENOS;
                    if (DomainFieldTracked(policy, "CorridasOnduladeira", operation, recordId, "COR_TOLERANCIA_MAIS"))
                        mask |= CorridasOnduladeiraTrackingFields.COR_TOLERANCIA_MAIS;
                    if (DomainFieldTracked(policy, "CorridasOnduladeira", operation, recordId, "COR_PILHAS_POR_PALETE"))
                        mask |= CorridasOnduladeiraTrackingFields.COR_PILHAS_POR_PALETE;
                    if (DomainFieldTracked(policy, "CorridasOnduladeira", operation, recordId, "COR_COR_FILA"))
                        mask |= CorridasOnduladeiraTrackingFields.COR_COR_FILA;
                    if (DomainFieldTracked(policy, "CorridasOnduladeira", operation, recordId, "COR_M_LINEAR_REALIZADO"))
                        mask |= CorridasOnduladeiraTrackingFields.COR_M_LINEAR_REALIZADO;
                    if (DomainFieldTracked(policy, "CorridasOnduladeira", operation, recordId, "PRO_ID_PALETE"))
                        mask |= CorridasOnduladeiraTrackingFields.PRO_ID_PALETE;
                    if (DomainFieldTracked(policy, "CorridasOnduladeira", operation, recordId, "COR_STATUS_PALETE"))
                        mask |= CorridasOnduladeiraTrackingFields.COR_STATUS_PALETE;
                    if (DomainFieldTracked(policy, "CorridasOnduladeira", operation, recordId, "COR_GRUPO_PRODUTIVO"))
                        mask |= CorridasOnduladeiraTrackingFields.COR_GRUPO_PRODUTIVO;
                    if (DomainFieldTracked(policy, "CorridasOnduladeira", operation, recordId, "TenantID"))
                        mask |= CorridasOnduladeiraTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "CorridasOnduladeira", operation, recordId, "Deleted"))
                        mask |= CorridasOnduladeiraTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "CorridasOnduladeira", operation, recordId, "Changed"))
                        mask |= CorridasOnduladeiraTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "CorridasOnduladeira", operation, recordId, "UserId"))
                        mask |= CorridasOnduladeiraTrackingFields.UserId;
                    if (DomainFieldTracked(policy, "CorridasOnduladeira", operation, recordId, "COR_ID"))
                        mask |= CorridasOnduladeiraTrackingFields.COR_ID;
                    if (DomainFieldTracked(policy, "CorridasOnduladeira", operation, recordId, "COR_STATUS"))
                        mask |= CorridasOnduladeiraTrackingFields.COR_STATUS;
                    if (DomainFieldTracked(policy, "CorridasOnduladeira", operation, recordId, "COR_STATUS_INTERFACE"))
                        mask |= CorridasOnduladeiraTrackingFields.COR_STATUS_INTERFACE;
                    if (DomainFieldTracked(policy, "CorridasOnduladeira", operation, recordId, "MAQ_ID"))
                        mask |= CorridasOnduladeiraTrackingFields.MAQ_ID;
                    if (DomainFieldTracked(policy, "CorridasOnduladeira", operation, recordId, "COR_ID_INTERFACE"))
                        mask |= CorridasOnduladeiraTrackingFields.COR_ID_INTERFACE;
                    if (DomainFieldTracked(policy, "CorridasOnduladeira", operation, recordId, "COR_SEQUENCIA"))
                        mask |= CorridasOnduladeiraTrackingFields.COR_SEQUENCIA;
                    if (DomainFieldTracked(policy, "CorridasOnduladeira", operation, recordId, "COR_SEQUENCIA_ORIGEM"))
                        mask |= CorridasOnduladeiraTrackingFields.COR_SEQUENCIA_ORIGEM;
                    if (DomainFieldTracked(policy, "CorridasOnduladeira", operation, recordId, "ORD_ID"))
                        mask |= CorridasOnduladeiraTrackingFields.ORD_ID;
                    if (DomainFieldTracked(policy, "CorridasOnduladeira", operation, recordId, "FPR_SEQ_REPETICAO"))
                        mask |= CorridasOnduladeiraTrackingFields.FPR_SEQ_REPETICAO;
                    if (DomainFieldTracked(policy, "CorridasOnduladeira", operation, recordId, "ROT_SEQ_TRANFORMACAO"))
                        mask |= CorridasOnduladeiraTrackingFields.ROT_SEQ_TRANFORMACAO;
                    if (DomainFieldTracked(policy, "CorridasOnduladeira", operation, recordId, "COR_FACAO"))
                        mask |= CorridasOnduladeiraTrackingFields.COR_FACAO;
                    if (DomainFieldTracked(policy, "CorridasOnduladeira", operation, recordId, "COR_FORMATO_BOBINA"))
                        mask |= CorridasOnduladeiraTrackingFields.COR_FORMATO_BOBINA;
                    if (DomainFieldTracked(policy, "CorridasOnduladeira", operation, recordId, "COR_INICIO_PREVISTO"))
                        mask |= CorridasOnduladeiraTrackingFields.COR_INICIO_PREVISTO;
                    if (DomainFieldTracked(policy, "CorridasOnduladeira", operation, recordId, "COR_FIM_PREVISTO"))
                        mask |= CorridasOnduladeiraTrackingFields.COR_FIM_PREVISTO;
                    if (DomainFieldTracked(policy, "CorridasOnduladeira", operation, recordId, "PRO_ID"))
                        mask |= CorridasOnduladeiraTrackingFields.PRO_ID;
                    if (DomainFieldTracked(policy, "CorridasOnduladeira", operation, recordId, "COR_QTD_PLANEJADO"))
                        mask |= CorridasOnduladeiraTrackingFields.COR_QTD_PLANEJADO;
                    if (DomainFieldTracked(policy, "CorridasOnduladeira", operation, recordId, "PRO_QTD_PACAS"))
                        mask |= CorridasOnduladeiraTrackingFields.PRO_QTD_PACAS;
                    if (DomainFieldTracked(policy, "CorridasOnduladeira", operation, recordId, "COR_PECAS_LARGURA"))
                        mask |= CorridasOnduladeiraTrackingFields.COR_PECAS_LARGURA;
                    return mask;
                }

                private ulong GetCorridasOnduladeiraEstudoMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "CorridasOnduladeiraEstudo", operation, recordId, "Id"))
                        mask |= CorridasOnduladeiraEstudoTrackingFields.Id;
                    if (DomainFieldTracked(policy, "CorridasOnduladeiraEstudo", operation, recordId, "BOL_ID"))
                        mask |= CorridasOnduladeiraEstudoTrackingFields.BOL_ID;
                    if (DomainFieldTracked(policy, "CorridasOnduladeiraEstudo", operation, recordId, "BOL_ID_ORIGEM"))
                        mask |= CorridasOnduladeiraEstudoTrackingFields.BOL_ID_ORIGEM;
                    if (DomainFieldTracked(policy, "CorridasOnduladeiraEstudo", operation, recordId, "PRO_LARGURA_PECA"))
                        mask |= CorridasOnduladeiraEstudoTrackingFields.PRO_LARGURA_PECA;
                    if (DomainFieldTracked(policy, "CorridasOnduladeiraEstudo", operation, recordId, "PRO_LARGURA_PECA_PROGRAMADO"))
                        mask |= CorridasOnduladeiraEstudoTrackingFields.PRO_LARGURA_PECA_PROGRAMADO;
                    if (DomainFieldTracked(policy, "CorridasOnduladeiraEstudo", operation, recordId, "PRO_COMPRIMENTO_PECA"))
                        mask |= CorridasOnduladeiraEstudoTrackingFields.PRO_COMPRIMENTO_PECA;
                    if (DomainFieldTracked(policy, "CorridasOnduladeiraEstudo", operation, recordId, "PRO_COMPRIMENTO_PECA_PROGRAMADO"))
                        mask |= CorridasOnduladeiraEstudoTrackingFields.PRO_COMPRIMENTO_PECA_PROGRAMADO;
                    if (DomainFieldTracked(policy, "CorridasOnduladeiraEstudo", operation, recordId, "PRO_UTILIZOU_REFILE_OBRIGATORIO"))
                        mask |= CorridasOnduladeiraEstudoTrackingFields.PRO_UTILIZOU_REFILE_OBRIGATORIO;
                    if (DomainFieldTracked(policy, "CorridasOnduladeiraEstudo", operation, recordId, "PRO_VINCOS_RECALCULADOS"))
                        mask |= CorridasOnduladeiraEstudoTrackingFields.PRO_VINCOS_RECALCULADOS;
                    if (DomainFieldTracked(policy, "CorridasOnduladeiraEstudo", operation, recordId, "COR_SOLVER"))
                        mask |= CorridasOnduladeiraEstudoTrackingFields.COR_SOLVER;
                    if (DomainFieldTracked(policy, "CorridasOnduladeiraEstudo", operation, recordId, "COR_GRAMATURA_PAPEIS_PROGRAMADOS"))
                        mask |= CorridasOnduladeiraEstudoTrackingFields.COR_GRAMATURA_PAPEIS_PROGRAMADOS;
                    if (DomainFieldTracked(policy, "CorridasOnduladeiraEstudo", operation, recordId, "COR_CUSTO_PAPEIS_PROGRAMADOS"))
                        mask |= CorridasOnduladeiraEstudoTrackingFields.COR_CUSTO_PAPEIS_PROGRAMADOS;
                    if (DomainFieldTracked(policy, "CorridasOnduladeiraEstudo", operation, recordId, "COR_GRAMATURA_RESINA_PROGRAMADOS"))
                        mask |= CorridasOnduladeiraEstudoTrackingFields.COR_GRAMATURA_RESINA_PROGRAMADOS;
                    if (DomainFieldTracked(policy, "CorridasOnduladeiraEstudo", operation, recordId, "COR_CUSTO_RESINA_PROGRAMADOS"))
                        mask |= CorridasOnduladeiraEstudoTrackingFields.COR_CUSTO_RESINA_PROGRAMADOS;
                    if (DomainFieldTracked(policy, "CorridasOnduladeiraEstudo", operation, recordId, "COR_TOLERANCIA_MENOS"))
                        mask |= CorridasOnduladeiraEstudoTrackingFields.COR_TOLERANCIA_MENOS;
                    if (DomainFieldTracked(policy, "CorridasOnduladeiraEstudo", operation, recordId, "COR_TOLERANCIA_MAIS"))
                        mask |= CorridasOnduladeiraEstudoTrackingFields.COR_TOLERANCIA_MAIS;
                    if (DomainFieldTracked(policy, "CorridasOnduladeiraEstudo", operation, recordId, "COR_PILHAS_POR_PALETE"))
                        mask |= CorridasOnduladeiraEstudoTrackingFields.COR_PILHAS_POR_PALETE;
                    if (DomainFieldTracked(policy, "CorridasOnduladeiraEstudo", operation, recordId, "COR_M_LINEAR_REALIZADO"))
                        mask |= CorridasOnduladeiraEstudoTrackingFields.COR_M_LINEAR_REALIZADO;
                    if (DomainFieldTracked(policy, "CorridasOnduladeiraEstudo", operation, recordId, "PRO_ID_PALETE"))
                        mask |= CorridasOnduladeiraEstudoTrackingFields.PRO_ID_PALETE;
                    if (DomainFieldTracked(policy, "CorridasOnduladeiraEstudo", operation, recordId, "COR_STATUS_PALETE"))
                        mask |= CorridasOnduladeiraEstudoTrackingFields.COR_STATUS_PALETE;
                    if (DomainFieldTracked(policy, "CorridasOnduladeiraEstudo", operation, recordId, "COR_GRUPO_PRODUTIVO"))
                        mask |= CorridasOnduladeiraEstudoTrackingFields.COR_GRUPO_PRODUTIVO;
                    if (DomainFieldTracked(policy, "CorridasOnduladeiraEstudo", operation, recordId, "TenantID"))
                        mask |= CorridasOnduladeiraEstudoTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "CorridasOnduladeiraEstudo", operation, recordId, "Deleted"))
                        mask |= CorridasOnduladeiraEstudoTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "CorridasOnduladeiraEstudo", operation, recordId, "Changed"))
                        mask |= CorridasOnduladeiraEstudoTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "CorridasOnduladeiraEstudo", operation, recordId, "UserId"))
                        mask |= CorridasOnduladeiraEstudoTrackingFields.UserId;
                    return mask;
                }

                private ulong GetCotasMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Cotas", operation, recordId, "Id"))
                        mask |= CotasTrackingFields.Id;
                    if (DomainFieldTracked(policy, "Cotas", operation, recordId, "COT_ID"))
                        mask |= CotasTrackingFields.COT_ID;
                    if (DomainFieldTracked(policy, "Cotas", operation, recordId, "COT_DATA_DE"))
                        mask |= CotasTrackingFields.COT_DATA_DE;
                    if (DomainFieldTracked(policy, "Cotas", operation, recordId, "COT_DATA_ATE"))
                        mask |= CotasTrackingFields.COT_DATA_ATE;
                    if (DomainFieldTracked(policy, "Cotas", operation, recordId, "COT_VALOR"))
                        mask |= CotasTrackingFields.COT_VALOR;
                    if (DomainFieldTracked(policy, "Cotas", operation, recordId, "COT_OCUPADO"))
                        mask |= CotasTrackingFields.COT_OCUPADO;
                    if (DomainFieldTracked(policy, "Cotas", operation, recordId, "REP_ID"))
                        mask |= CotasTrackingFields.REP_ID;
                    if (DomainFieldTracked(policy, "Cotas", operation, recordId, "TenantID"))
                        mask |= CotasTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Cotas", operation, recordId, "Deleted"))
                        mask |= CotasTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Cotas", operation, recordId, "Changed"))
                        mask |= CotasTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Cotas", operation, recordId, "UserId"))
                        mask |= CotasTrackingFields.UserId;
                    return mask;
                }

                private ulong GetT_DepartamentosMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "T_Departamentos", operation, recordId, "DEP_ID"))
                        mask |= T_DepartamentosTrackingFields.DEP_ID;
                    if (DomainFieldTracked(policy, "T_Departamentos", operation, recordId, "DEP_NOME"))
                        mask |= T_DepartamentosTrackingFields.DEP_NOME;
                    if (DomainFieldTracked(policy, "T_Departamentos", operation, recordId, "TenantID"))
                        mask |= T_DepartamentosTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "T_Departamentos", operation, recordId, "Deleted"))
                        mask |= T_DepartamentosTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "T_Departamentos", operation, recordId, "Changed"))
                        mask |= T_DepartamentosTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "T_Departamentos", operation, recordId, "UserId"))
                        mask |= T_DepartamentosTrackingFields.UserId;
                    return mask;
                }

                private ulong GetEnderecosMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Enderecos", operation, recordId, "END_ID"))
                        mask |= EnderecosTrackingFields.END_ID;
                    if (DomainFieldTracked(policy, "Enderecos", operation, recordId, "END_GRUPO"))
                        mask |= EnderecosTrackingFields.END_GRUPO;
                    if (DomainFieldTracked(policy, "Enderecos", operation, recordId, "TenantID"))
                        mask |= EnderecosTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Enderecos", operation, recordId, "Deleted"))
                        mask |= EnderecosTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Enderecos", operation, recordId, "Changed"))
                        mask |= EnderecosTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Enderecos", operation, recordId, "UserId"))
                        mask |= EnderecosTrackingFields.UserId;
                    return mask;
                }

                private ulong GetEquipeMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Equipe", operation, recordId, "Id"))
                        mask |= EquipeTrackingFields.Id;
                    if (DomainFieldTracked(policy, "Equipe", operation, recordId, "EQU_ID"))
                        mask |= EquipeTrackingFields.EQU_ID;
                    if (DomainFieldTracked(policy, "Equipe", operation, recordId, "EQU_HIERARQUIA_SEQ_TRANSFORMACAO"))
                        mask |= EquipeTrackingFields.EQU_HIERARQUIA_SEQ_TRANSFORMACAO;
                    if (DomainFieldTracked(policy, "Equipe", operation, recordId, "TenantID"))
                        mask |= EquipeTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Equipe", operation, recordId, "Deleted"))
                        mask |= EquipeTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Equipe", operation, recordId, "Changed"))
                        mask |= EquipeTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Equipe", operation, recordId, "UserId"))
                        mask |= EquipeTrackingFields.UserId;
                    return mask;
                }

                private ulong GetEstradasMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Estradas", operation, recordId, "Id"))
                        mask |= EstradasTrackingFields.Id;
                    if (DomainFieldTracked(policy, "Estradas", operation, recordId, "EST_ID"))
                        mask |= EstradasTrackingFields.EST_ID;
                    if (DomainFieldTracked(policy, "Estradas", operation, recordId, "EST_DESCRICAO"))
                        mask |= EstradasTrackingFields.EST_DESCRICAO;
                    if (DomainFieldTracked(policy, "Estradas", operation, recordId, "EST_ID_LIGACAO_PONTO_A"))
                        mask |= EstradasTrackingFields.EST_ID_LIGACAO_PONTO_A;
                    if (DomainFieldTracked(policy, "Estradas", operation, recordId, "EST_ID_LIGACAO_PONTO_B"))
                        mask |= EstradasTrackingFields.EST_ID_LIGACAO_PONTO_B;
                    if (DomainFieldTracked(policy, "Estradas", operation, recordId, "TenantID"))
                        mask |= EstradasTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Estradas", operation, recordId, "Deleted"))
                        mask |= EstradasTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Estradas", operation, recordId, "Changed"))
                        mask |= EstradasTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Estradas", operation, recordId, "UserId"))
                        mask |= EstradasTrackingFields.UserId;
                    return mask;
                }

                private ulong GetEstruturaCustoMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "EstruturaCusto", operation, recordId, "EST_ID"))
                        mask |= EstruturaCustoTrackingFields.EST_ID;
                    if (DomainFieldTracked(policy, "EstruturaCusto", operation, recordId, "ITO_ID"))
                        mask |= EstruturaCustoTrackingFields.ITO_ID;
                    if (DomainFieldTracked(policy, "EstruturaCusto", operation, recordId, "ORD_ID"))
                        mask |= EstruturaCustoTrackingFields.ORD_ID;
                    if (DomainFieldTracked(policy, "EstruturaCusto", operation, recordId, "PRO_ID"))
                        mask |= EstruturaCustoTrackingFields.PRO_ID;
                    if (DomainFieldTracked(policy, "EstruturaCusto", operation, recordId, "PRO_ID_PRODUTO"))
                        mask |= EstruturaCustoTrackingFields.PRO_ID_PRODUTO;
                    if (DomainFieldTracked(policy, "EstruturaCusto", operation, recordId, "PRO_ID_COMPONENTE"))
                        mask |= EstruturaCustoTrackingFields.PRO_ID_COMPONENTE;
                    if (DomainFieldTracked(policy, "EstruturaCusto", operation, recordId, "PRO_TIPO_CUSTO"))
                        mask |= EstruturaCustoTrackingFields.PRO_TIPO_CUSTO;
                    if (DomainFieldTracked(policy, "EstruturaCusto", operation, recordId, "PRO_GRUPO_CONTABIL"))
                        mask |= EstruturaCustoTrackingFields.PRO_GRUPO_CONTABIL;
                    if (DomainFieldTracked(policy, "EstruturaCusto", operation, recordId, "EST_ORDEM"))
                        mask |= EstruturaCustoTrackingFields.EST_ORDEM;
                    if (DomainFieldTracked(policy, "EstruturaCusto", operation, recordId, "EST_GRUPO"))
                        mask |= EstruturaCustoTrackingFields.EST_GRUPO;
                    if (DomainFieldTracked(policy, "EstruturaCusto", operation, recordId, "EST_QUANT"))
                        mask |= EstruturaCustoTrackingFields.EST_QUANT;
                    if (DomainFieldTracked(policy, "EstruturaCusto", operation, recordId, "EST_VALOR_TOTAL"))
                        mask |= EstruturaCustoTrackingFields.EST_VALOR_TOTAL;
                    if (DomainFieldTracked(policy, "EstruturaCusto", operation, recordId, "EST_DATA_BASE"))
                        mask |= EstruturaCustoTrackingFields.EST_DATA_BASE;
                    if (DomainFieldTracked(policy, "EstruturaCusto", operation, recordId, "EST_BASE_PRODUCAO"))
                        mask |= EstruturaCustoTrackingFields.EST_BASE_PRODUCAO;
                    if (DomainFieldTracked(policy, "EstruturaCusto", operation, recordId, "EST_NIVEL"))
                        mask |= EstruturaCustoTrackingFields.EST_NIVEL;
                    if (DomainFieldTracked(policy, "EstruturaCusto", operation, recordId, "FPR_SEQ_REPETICAO"))
                        mask |= EstruturaCustoTrackingFields.FPR_SEQ_REPETICAO;
                    if (DomainFieldTracked(policy, "EstruturaCusto", operation, recordId, "TenantID"))
                        mask |= EstruturaCustoTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "EstruturaCusto", operation, recordId, "Deleted"))
                        mask |= EstruturaCustoTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "EstruturaCusto", operation, recordId, "Changed"))
                        mask |= EstruturaCustoTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "EstruturaCusto", operation, recordId, "UserId"))
                        mask |= EstruturaCustoTrackingFields.UserId;
                    return mask;
                }

                private ulong GetEstruturaImpressaoMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "EstruturaImpressao", operation, recordId, "EST_ID"))
                        mask |= EstruturaImpressaoTrackingFields.EST_ID;
                    if (DomainFieldTracked(policy, "EstruturaImpressao", operation, recordId, "HTML_ESTRUTURA"))
                        mask |= EstruturaImpressaoTrackingFields.HTML_ESTRUTURA;
                    if (DomainFieldTracked(policy, "EstruturaImpressao", operation, recordId, "CLI_ID"))
                        mask |= EstruturaImpressaoTrackingFields.CLI_ID;
                    if (DomainFieldTracked(policy, "EstruturaImpressao", operation, recordId, "EST_DESCRICAO"))
                        mask |= EstruturaImpressaoTrackingFields.EST_DESCRICAO;
                    if (DomainFieldTracked(policy, "EstruturaImpressao", operation, recordId, "TenantID"))
                        mask |= EstruturaImpressaoTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "EstruturaImpressao", operation, recordId, "Deleted"))
                        mask |= EstruturaImpressaoTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "EstruturaImpressao", operation, recordId, "Changed"))
                        mask |= EstruturaImpressaoTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "EstruturaImpressao", operation, recordId, "UserId"))
                        mask |= EstruturaImpressaoTrackingFields.UserId;
                    return mask;
                }

                private ulong GetEstruturaProdutoMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "EstruturaProduto", operation, recordId, "Id"))
                        mask |= EstruturaProdutoTrackingFields.Id;
                    if (DomainFieldTracked(policy, "EstruturaProduto", operation, recordId, "EST_DATA_VALIDADE"))
                        mask |= EstruturaProdutoTrackingFields.EST_DATA_VALIDADE;
                    if (DomainFieldTracked(policy, "EstruturaProduto", operation, recordId, "PRO_ID_PRODUTO"))
                        mask |= EstruturaProdutoTrackingFields.PRO_ID_PRODUTO;
                    if (DomainFieldTracked(policy, "EstruturaProduto", operation, recordId, "PRO_ID_COMPONENTE"))
                        mask |= EstruturaProdutoTrackingFields.PRO_ID_COMPONENTE;
                    if (DomainFieldTracked(policy, "EstruturaProduto", operation, recordId, "EST_QUANT"))
                        mask |= EstruturaProdutoTrackingFields.EST_QUANT;
                    if (DomainFieldTracked(policy, "EstruturaProduto", operation, recordId, "EST_DATA_INCLUSAO"))
                        mask |= EstruturaProdutoTrackingFields.EST_DATA_INCLUSAO;
                    if (DomainFieldTracked(policy, "EstruturaProduto", operation, recordId, "EST_BASE_PRODUCAO"))
                        mask |= EstruturaProdutoTrackingFields.EST_BASE_PRODUCAO;
                    if (DomainFieldTracked(policy, "EstruturaProduto", operation, recordId, "EST_TIPO_REQUISICAO"))
                        mask |= EstruturaProdutoTrackingFields.EST_TIPO_REQUISICAO;
                    if (DomainFieldTracked(policy, "EstruturaProduto", operation, recordId, "EST_CODIGO_DE_EXCECAO"))
                        mask |= EstruturaProdutoTrackingFields.EST_CODIGO_DE_EXCECAO;
                    if (DomainFieldTracked(policy, "EstruturaProduto", operation, recordId, "TenantID"))
                        mask |= EstruturaProdutoTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "EstruturaProduto", operation, recordId, "Deleted"))
                        mask |= EstruturaProdutoTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "EstruturaProduto", operation, recordId, "Changed"))
                        mask |= EstruturaProdutoTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "EstruturaProduto", operation, recordId, "UserId"))
                        mask |= EstruturaProdutoTrackingFields.UserId;
                    return mask;
                }

                private ulong GetEtiquetaMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Etiqueta", operation, recordId, "ETI_ID"))
                        mask |= EtiquetaTrackingFields.ETI_ID;
                    if (DomainFieldTracked(policy, "Etiqueta", operation, recordId, "ETI_EMISSAO"))
                        mask |= EtiquetaTrackingFields.ETI_EMISSAO;
                    if (DomainFieldTracked(policy, "Etiqueta", operation, recordId, "ETI_CODIGO_BARRAS"))
                        mask |= EtiquetaTrackingFields.ETI_CODIGO_BARRAS;
                    if (DomainFieldTracked(policy, "Etiqueta", operation, recordId, "ETI_SEQUENCIA"))
                        mask |= EtiquetaTrackingFields.ETI_SEQUENCIA;
                    if (DomainFieldTracked(policy, "Etiqueta", operation, recordId, "ETI_NUMERO_COPIAS"))
                        mask |= EtiquetaTrackingFields.ETI_NUMERO_COPIAS;
                    if (DomainFieldTracked(policy, "Etiqueta", operation, recordId, "ETI_STATUS"))
                        mask |= EtiquetaTrackingFields.ETI_STATUS;
                    if (DomainFieldTracked(policy, "Etiqueta", operation, recordId, "ETI_DATA_FABRICACAO"))
                        mask |= EtiquetaTrackingFields.ETI_DATA_FABRICACAO;
                    if (DomainFieldTracked(policy, "Etiqueta", operation, recordId, "ETI_COD_BARRAS_ORIGINAL"))
                        mask |= EtiquetaTrackingFields.ETI_COD_BARRAS_ORIGINAL;
                    if (DomainFieldTracked(policy, "Etiqueta", operation, recordId, "ETI_OP_ORIGINAL"))
                        mask |= EtiquetaTrackingFields.ETI_OP_ORIGINAL;
                    if (DomainFieldTracked(policy, "Etiqueta", operation, recordId, "MAQ_ID"))
                        mask |= EtiquetaTrackingFields.MAQ_ID;
                    if (DomainFieldTracked(policy, "Etiqueta", operation, recordId, "IMP_ID"))
                        mask |= EtiquetaTrackingFields.IMP_ID;
                    if (DomainFieldTracked(policy, "Etiqueta", operation, recordId, "USE_ID"))
                        mask |= EtiquetaTrackingFields.USE_ID;
                    if (DomainFieldTracked(policy, "Etiqueta", operation, recordId, "ORD_ID"))
                        mask |= EtiquetaTrackingFields.ORD_ID;
                    if (DomainFieldTracked(policy, "Etiqueta", operation, recordId, "ROT_PRO_ID"))
                        mask |= EtiquetaTrackingFields.ROT_PRO_ID;
                    if (DomainFieldTracked(policy, "Etiqueta", operation, recordId, "ROT_SEQ_TRANFORMACAO"))
                        mask |= EtiquetaTrackingFields.ROT_SEQ_TRANFORMACAO;
                    if (DomainFieldTracked(policy, "Etiqueta", operation, recordId, "FPR_SEQ_REPETICAO"))
                        mask |= EtiquetaTrackingFields.FPR_SEQ_REPETICAO;
                    if (DomainFieldTracked(policy, "Etiqueta", operation, recordId, "ETI_QUANTIDADE_PALETE"))
                        mask |= EtiquetaTrackingFields.ETI_QUANTIDADE_PALETE;
                    if (DomainFieldTracked(policy, "Etiqueta", operation, recordId, "ETI_LOTE"))
                        mask |= EtiquetaTrackingFields.ETI_LOTE;
                    if (DomainFieldTracked(policy, "Etiqueta", operation, recordId, "ETI_SUB_LOTE"))
                        mask |= EtiquetaTrackingFields.ETI_SUB_LOTE;
                    if (DomainFieldTracked(policy, "Etiqueta", operation, recordId, "ETI_IMPRIMIR_DE"))
                        mask |= EtiquetaTrackingFields.ETI_IMPRIMIR_DE;
                    if (DomainFieldTracked(policy, "Etiqueta", operation, recordId, "ETI_IMPRIMIR_ATE"))
                        mask |= EtiquetaTrackingFields.ETI_IMPRIMIR_ATE;
                    if (DomainFieldTracked(policy, "Etiqueta", operation, recordId, "BOL_ID"))
                        mask |= EtiquetaTrackingFields.BOL_ID;
                    if (DomainFieldTracked(policy, "Etiqueta", operation, recordId, "COR_SEQUENCIA"))
                        mask |= EtiquetaTrackingFields.COR_SEQUENCIA;
                    if (DomainFieldTracked(policy, "Etiqueta", operation, recordId, "TenantID"))
                        mask |= EtiquetaTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Etiqueta", operation, recordId, "Deleted"))
                        mask |= EtiquetaTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Etiqueta", operation, recordId, "Changed"))
                        mask |= EtiquetaTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Etiqueta", operation, recordId, "UserId"))
                        mask |= EtiquetaTrackingFields.UserId;
                    return mask;
                }

                private ulong GetT_FavoritosMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "T_Favoritos", operation, recordId, "IDFAVORITO"))
                        mask |= T_FavoritosTrackingFields.IDFAVORITO;
                    if (DomainFieldTracked(policy, "T_Favoritos", operation, recordId, "USE_ID"))
                        mask |= T_FavoritosTrackingFields.USE_ID;
                    if (DomainFieldTracked(policy, "T_Favoritos", operation, recordId, "ID_INDICADOR"))
                        mask |= T_FavoritosTrackingFields.ID_INDICADOR;
                    if (DomainFieldTracked(policy, "T_Favoritos", operation, recordId, "TenantID"))
                        mask |= T_FavoritosTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "T_Favoritos", operation, recordId, "Deleted"))
                        mask |= T_FavoritosTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "T_Favoritos", operation, recordId, "Changed"))
                        mask |= T_FavoritosTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "T_Favoritos", operation, recordId, "UserId"))
                        mask |= T_FavoritosTrackingFields.UserId;
                    return mask;
                }

                private ulong GetFechamentoTesteMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "FechamentoTeste", operation, recordId, "Id"))
                        mask |= FechamentoTesteTrackingFields.Id;
                    if (DomainFieldTracked(policy, "FechamentoTeste", operation, recordId, "FEC_ID"))
                        mask |= FechamentoTesteTrackingFields.FEC_ID;
                    if (DomainFieldTracked(policy, "FechamentoTeste", operation, recordId, "FEC_QTD"))
                        mask |= FechamentoTesteTrackingFields.FEC_QTD;
                    if (DomainFieldTracked(policy, "FechamentoTeste", operation, recordId, "GRP_ID"))
                        mask |= FechamentoTesteTrackingFields.GRP_ID;
                    if (DomainFieldTracked(policy, "FechamentoTeste", operation, recordId, "TenantID"))
                        mask |= FechamentoTesteTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "FechamentoTeste", operation, recordId, "Deleted"))
                        mask |= FechamentoTesteTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "FechamentoTeste", operation, recordId, "Changed"))
                        mask |= FechamentoTesteTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "FechamentoTeste", operation, recordId, "UserId"))
                        mask |= FechamentoTesteTrackingFields.UserId;
                    return mask;
                }

                private ulong GetFeedbackMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Feedback", operation, recordId, "Id"))
                        mask |= FeedbackTrackingFields.Id;
                    if (DomainFieldTracked(policy, "Feedback", operation, recordId, "DataInicial"))
                        mask |= FeedbackTrackingFields.DataInicial;
                    if (DomainFieldTracked(policy, "Feedback", operation, recordId, "Datafinal"))
                        mask |= FeedbackTrackingFields.Datafinal;
                    if (DomainFieldTracked(policy, "Feedback", operation, recordId, "MaquinaId"))
                        mask |= FeedbackTrackingFields.MaquinaId;
                    if (DomainFieldTracked(policy, "Feedback", operation, recordId, "OcorrenciaId"))
                        mask |= FeedbackTrackingFields.OcorrenciaId;
                    if (DomainFieldTracked(policy, "Feedback", operation, recordId, "TurnoId"))
                        mask |= FeedbackTrackingFields.TurnoId;
                    if (DomainFieldTracked(policy, "Feedback", operation, recordId, "TurmaId"))
                        mask |= FeedbackTrackingFields.TurmaId;
                    if (DomainFieldTracked(policy, "Feedback", operation, recordId, "UsuarioId"))
                        mask |= FeedbackTrackingFields.UsuarioId;
                    if (DomainFieldTracked(policy, "Feedback", operation, recordId, "OrderId"))
                        mask |= FeedbackTrackingFields.OrderId;
                    if (DomainFieldTracked(policy, "Feedback", operation, recordId, "ProdutoId"))
                        mask |= FeedbackTrackingFields.ProdutoId;
                    if (DomainFieldTracked(policy, "Feedback", operation, recordId, "Observacoes"))
                        mask |= FeedbackTrackingFields.Observacoes;
                    if (DomainFieldTracked(policy, "Feedback", operation, recordId, "Grupo"))
                        mask |= FeedbackTrackingFields.Grupo;
                    if (DomainFieldTracked(policy, "Feedback", operation, recordId, "DiaTurma"))
                        mask |= FeedbackTrackingFields.DiaTurma;
                    if (DomainFieldTracked(policy, "Feedback", operation, recordId, "SequenciaTransformacao"))
                        mask |= FeedbackTrackingFields.SequenciaTransformacao;
                    if (DomainFieldTracked(policy, "Feedback", operation, recordId, "SequenciaRepeticao"))
                        mask |= FeedbackTrackingFields.SequenciaRepeticao;
                    if (DomainFieldTracked(policy, "Feedback", operation, recordId, "QuantidadePulsos"))
                        mask |= FeedbackTrackingFields.QuantidadePulsos;
                    if (DomainFieldTracked(policy, "Feedback", operation, recordId, "QuantidadePecasPorPulso"))
                        mask |= FeedbackTrackingFields.QuantidadePecasPorPulso;
                    if (DomainFieldTracked(policy, "Feedback", operation, recordId, "FEE_QTD_TOTAL_PRODUCAO_AJUSTADA"))
                        mask |= FeedbackTrackingFields.FEE_QTD_TOTAL_PRODUCAO_AJUSTADA;
                    if (DomainFieldTracked(policy, "Feedback", operation, recordId, "BOL_ID"))
                        mask |= FeedbackTrackingFields.BOL_ID;
                    if (DomainFieldTracked(policy, "Feedback", operation, recordId, "COR_SEQUENCIA"))
                        mask |= FeedbackTrackingFields.COR_SEQUENCIA;
                    if (DomainFieldTracked(policy, "Feedback", operation, recordId, "TenantID"))
                        mask |= FeedbackTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Feedback", operation, recordId, "Deleted"))
                        mask |= FeedbackTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Feedback", operation, recordId, "Changed"))
                        mask |= FeedbackTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Feedback", operation, recordId, "UserId"))
                        mask |= FeedbackTrackingFields.UserId;
                    return mask;
                }

                private ulong GetT_FeedbackMovEstoqueMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "T_FeedbackMovEstoque", operation, recordId, "Id"))
                        mask |= T_FeedbackMovEstoqueTrackingFields.Id;
                    if (DomainFieldTracked(policy, "T_FeedbackMovEstoque", operation, recordId, "FeedbackId"))
                        mask |= T_FeedbackMovEstoqueTrackingFields.FeedbackId;
                    if (DomainFieldTracked(policy, "T_FeedbackMovEstoque", operation, recordId, "MovimentoEstoqueId"))
                        mask |= T_FeedbackMovEstoqueTrackingFields.MovimentoEstoqueId;
                    if (DomainFieldTracked(policy, "T_FeedbackMovEstoque", operation, recordId, "TenantID"))
                        mask |= T_FeedbackMovEstoqueTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "T_FeedbackMovEstoque", operation, recordId, "Deleted"))
                        mask |= T_FeedbackMovEstoqueTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "T_FeedbackMovEstoque", operation, recordId, "Changed"))
                        mask |= T_FeedbackMovEstoqueTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "T_FeedbackMovEstoque", operation, recordId, "UserId"))
                        mask |= T_FeedbackMovEstoqueTrackingFields.UserId;
                    return mask;
                }

                private ulong GetFilaProducaoMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "Id"))
                        mask |= FilaProducaoTrackingFields.Id;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "ORD_ID"))
                        mask |= FilaProducaoTrackingFields.ORD_ID;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "ROT_PRO_ID"))
                        mask |= FilaProducaoTrackingFields.ROT_PRO_ID;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_QUANTIDADE_PREVISTA"))
                        mask |= FilaProducaoTrackingFields.FPR_QUANTIDADE_PREVISTA;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "ROT_MAQ_ID"))
                        mask |= FilaProducaoTrackingFields.ROT_MAQ_ID;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_DATA_INICIO_PREVISTA"))
                        mask |= FilaProducaoTrackingFields.FPR_DATA_INICIO_PREVISTA;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_DATA_FIM_PREVISTA"))
                        mask |= FilaProducaoTrackingFields.FPR_DATA_FIM_PREVISTA;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_DATA_FIM_MAXIMA"))
                        mask |= FilaProducaoTrackingFields.FPR_DATA_FIM_MAXIMA;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "ROT_SEQ_TRANFORMACAO"))
                        mask |= FilaProducaoTrackingFields.ROT_SEQ_TRANFORMACAO;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_SEQ_REPETICAO"))
                        mask |= FilaProducaoTrackingFields.FPR_SEQ_REPETICAO;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_OBS_PRODUCAO"))
                        mask |= FilaProducaoTrackingFields.FPR_OBS_PRODUCAO;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_STATUS"))
                        mask |= FilaProducaoTrackingFields.FPR_STATUS;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_TEMPO_DECORRIDO_SETUP"))
                        mask |= FilaProducaoTrackingFields.FPR_TEMPO_DECORRIDO_SETUP;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_TEMPO_DECORRIDO_SETUPA"))
                        mask |= FilaProducaoTrackingFields.FPR_TEMPO_DECORRIDO_SETUPA;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_TEMPO_DECORRIDO_PERFORMANC"))
                        mask |= FilaProducaoTrackingFields.FPR_TEMPO_DECORRIDO_PERFORMANC;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_TEMPO_DECO_PEQUENA_PARADA"))
                        mask |= FilaProducaoTrackingFields.FPR_TEMPO_DECO_PEQUENA_PARADA;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_QTD_PERFORMANCE"))
                        mask |= FilaProducaoTrackingFields.FPR_QTD_PERFORMANCE;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_QTD_SETUP"))
                        mask |= FilaProducaoTrackingFields.FPR_QTD_SETUP;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_QTD_PRODUZIDA"))
                        mask |= FilaProducaoTrackingFields.FPR_QTD_PRODUZIDA;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_TEMPO_TEORICO_PERFORMANCE"))
                        mask |= FilaProducaoTrackingFields.FPR_TEMPO_TEORICO_PERFORMANCE;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_TEMPO_RESTANTE_PERFORMANC"))
                        mask |= FilaProducaoTrackingFields.FPR_TEMPO_RESTANTE_PERFORMANC;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_VELOCIDADE_P_ATINGIR_META"))
                        mask |= FilaProducaoTrackingFields.FPR_VELOCIDADE_P_ATINGIR_META;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_QTD_RESTANTE"))
                        mask |= FilaProducaoTrackingFields.FPR_QTD_RESTANTE;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_VELO_ATU_PC_SEGUNDO"))
                        mask |= FilaProducaoTrackingFields.FPR_VELO_ATU_PC_SEGUNDO;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_PERFORMANCE_PROJETADA"))
                        mask |= FilaProducaoTrackingFields.FPR_PERFORMANCE_PROJETADA;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_TEMPO_RESTANTE_TOTAL"))
                        mask |= FilaProducaoTrackingFields.FPR_TEMPO_RESTANTE_TOTAL;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_FIM_PREVISTO_ATUAL"))
                        mask |= FilaProducaoTrackingFields.FPR_FIM_PREVISTO_ATUAL;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_PRODUZINDO"))
                        mask |= FilaProducaoTrackingFields.FPR_PRODUZINDO;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_ORDEM_NA_FILA"))
                        mask |= FilaProducaoTrackingFields.FPR_ORDEM_NA_FILA;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_ID_INTEGRACAO"))
                        mask |= FilaProducaoTrackingFields.FPR_ID_INTEGRACAO;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_TRUNCADO"))
                        mask |= FilaProducaoTrackingFields.FPR_TRUNCADO;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_DATA_TRUNC_INI"))
                        mask |= FilaProducaoTrackingFields.FPR_DATA_TRUNC_INI;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_DATA_TRUNC_FIM"))
                        mask |= FilaProducaoTrackingFields.FPR_DATA_TRUNC_FIM;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_ID"))
                        mask |= FilaProducaoTrackingFields.FPR_ID;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_COR_FILA"))
                        mask |= FilaProducaoTrackingFields.FPR_COR_FILA;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "MAQ_ID_MANUAL"))
                        mask |= FilaProducaoTrackingFields.MAQ_ID_MANUAL;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "MAQ_ID_RESTRINGIDA"))
                        mask |= FilaProducaoTrackingFields.MAQ_ID_RESTRINGIDA;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_PREVISAO_MATERIA_PRIMA"))
                        mask |= FilaProducaoTrackingFields.FPR_PREVISAO_MATERIA_PRIMA;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_DATA_NECESSIDADE_INICIO_PRODUCAO"))
                        mask |= FilaProducaoTrackingFields.FPR_DATA_NECESSIDADE_INICIO_PRODUCAO;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_DATA_NECESSIDADE_FIM_PRODUCAO"))
                        mask |= FilaProducaoTrackingFields.FPR_DATA_NECESSIDADE_FIM_PRODUCAO;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_GRUPO_PRODUTIVO"))
                        mask |= FilaProducaoTrackingFields.FPR_GRUPO_PRODUTIVO;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_INICIO_GRUPO_PRODUTIVO"))
                        mask |= FilaProducaoTrackingFields.FPR_INICIO_GRUPO_PRODUTIVO;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_FIM_GRUPO_PRODUTIVO"))
                        mask |= FilaProducaoTrackingFields.FPR_FIM_GRUPO_PRODUTIVO;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_COR_BICO1"))
                        mask |= FilaProducaoTrackingFields.FPR_COR_BICO1;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_COR_BICO2"))
                        mask |= FilaProducaoTrackingFields.FPR_COR_BICO2;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_COR_BICO3"))
                        mask |= FilaProducaoTrackingFields.FPR_COR_BICO3;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_COR_BICO4"))
                        mask |= FilaProducaoTrackingFields.FPR_COR_BICO4;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_COR_BICO5"))
                        mask |= FilaProducaoTrackingFields.FPR_COR_BICO5;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_META_SETUP"))
                        mask |= FilaProducaoTrackingFields.FPR_META_SETUP;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_ORD_ID_REPROGRAMADO"))
                        mask |= FilaProducaoTrackingFields.FPR_ORD_ID_REPROGRAMADO;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_PRIORIDADE"))
                        mask |= FilaProducaoTrackingFields.FPR_PRIORIDADE;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_SEQ_INCLUSAO_FILA"))
                        mask |= FilaProducaoTrackingFields.FPR_SEQ_INCLUSAO_FILA;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_HIERARQUIA_SEQ_TRANSFORMACAO"))
                        mask |= FilaProducaoTrackingFields.FPR_HIERARQUIA_SEQ_TRANSFORMACAO;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_ID_ORIGEM"))
                        mask |= FilaProducaoTrackingFields.FPR_ID_ORIGEM;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_DATA_ENTREGA"))
                        mask |= FilaProducaoTrackingFields.FPR_DATA_ENTREGA;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "EQU_ID"))
                        mask |= FilaProducaoTrackingFields.EQU_ID;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_GRUPO_PRODUTIVO_MANUAL"))
                        mask |= FilaProducaoTrackingFields.FPR_GRUPO_PRODUTIVO_MANUAL;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_EMISSAO"))
                        mask |= FilaProducaoTrackingFields.FPR_EMISSAO;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_MOTIVO_PULA_FILA"))
                        mask |= FilaProducaoTrackingFields.FPR_MOTIVO_PULA_FILA;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "OCO_ID"))
                        mask |= FilaProducaoTrackingFields.OCO_ID;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_TOLERANCIA_MENOS"))
                        mask |= FilaProducaoTrackingFields.FPR_TOLERANCIA_MENOS;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_TOLERANCIA_MAIS"))
                        mask |= FilaProducaoTrackingFields.FPR_TOLERANCIA_MAIS;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "FPR_DATA_ENCERRAMENTO"))
                        mask |= FilaProducaoTrackingFields.FPR_DATA_ENCERRAMENTO;
                    if (DomainFieldTracked(policy, "FilaProducao", operation, recordId, "TenantID"))
                        mask |= FilaProducaoTrackingFields.TenantID;
                    return mask;
                }

                private ulong GetFilaProducaoPrevistaMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "Id"))
                        mask |= FilaProducaoPrevistaTrackingFields.Id;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "ORD_ID"))
                        mask |= FilaProducaoPrevistaTrackingFields.ORD_ID;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "ROT_PRO_ID"))
                        mask |= FilaProducaoPrevistaTrackingFields.ROT_PRO_ID;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "FPR_QUANTIDADE_PREVISTA"))
                        mask |= FilaProducaoPrevistaTrackingFields.FPR_QUANTIDADE_PREVISTA;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "ROT_MAQ_ID"))
                        mask |= FilaProducaoPrevistaTrackingFields.ROT_MAQ_ID;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "FPR_DATA_INICIO_PREVISTA"))
                        mask |= FilaProducaoPrevistaTrackingFields.FPR_DATA_INICIO_PREVISTA;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "FPR_DATA_FIM_PREVISTA"))
                        mask |= FilaProducaoPrevistaTrackingFields.FPR_DATA_FIM_PREVISTA;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "FPR_DATA_FIM_MAXIMA"))
                        mask |= FilaProducaoPrevistaTrackingFields.FPR_DATA_FIM_MAXIMA;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "ROT_SEQ_TRANFORMACAO"))
                        mask |= FilaProducaoPrevistaTrackingFields.ROT_SEQ_TRANFORMACAO;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "FPR_SEQ_REPETICAO"))
                        mask |= FilaProducaoPrevistaTrackingFields.FPR_SEQ_REPETICAO;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "FPR_OBS_PRODUCAO"))
                        mask |= FilaProducaoPrevistaTrackingFields.FPR_OBS_PRODUCAO;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "FPR_STATUS"))
                        mask |= FilaProducaoPrevistaTrackingFields.FPR_STATUS;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "FPR_TEMPO_DECORRIDO_SETUP"))
                        mask |= FilaProducaoPrevistaTrackingFields.FPR_TEMPO_DECORRIDO_SETUP;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "FPR_TEMPO_DECORRIDO_SETUPA"))
                        mask |= FilaProducaoPrevistaTrackingFields.FPR_TEMPO_DECORRIDO_SETUPA;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "FPR_TEMPO_DECORRIDO_PERFORMANC"))
                        mask |= FilaProducaoPrevistaTrackingFields.FPR_TEMPO_DECORRIDO_PERFORMANC;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "FPR_TEMPO_DECO_PEQUENA_PARADA"))
                        mask |= FilaProducaoPrevistaTrackingFields.FPR_TEMPO_DECO_PEQUENA_PARADA;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "FPR_QTD_PERFORMANCE"))
                        mask |= FilaProducaoPrevistaTrackingFields.FPR_QTD_PERFORMANCE;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "FPR_QTD_SETUP"))
                        mask |= FilaProducaoPrevistaTrackingFields.FPR_QTD_SETUP;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "FPR_QTD_PRODUZIDA"))
                        mask |= FilaProducaoPrevistaTrackingFields.FPR_QTD_PRODUZIDA;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "FPR_TEMPO_TEORICO_PERFORMANCE"))
                        mask |= FilaProducaoPrevistaTrackingFields.FPR_TEMPO_TEORICO_PERFORMANCE;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "FPR_TEMPO_RESTANTE_PERFORMANC"))
                        mask |= FilaProducaoPrevistaTrackingFields.FPR_TEMPO_RESTANTE_PERFORMANC;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "FPR_VELOCIDADE_P_ATINGIR_META"))
                        mask |= FilaProducaoPrevistaTrackingFields.FPR_VELOCIDADE_P_ATINGIR_META;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "FPR_QTD_RESTANTE"))
                        mask |= FilaProducaoPrevistaTrackingFields.FPR_QTD_RESTANTE;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "FPR_VELO_ATU_PC_SEGUNDO"))
                        mask |= FilaProducaoPrevistaTrackingFields.FPR_VELO_ATU_PC_SEGUNDO;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "FPR_PERFORMANCE_PROJETADA"))
                        mask |= FilaProducaoPrevistaTrackingFields.FPR_PERFORMANCE_PROJETADA;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "FPR_TEMPO_RESTANTE_TOTAL"))
                        mask |= FilaProducaoPrevistaTrackingFields.FPR_TEMPO_RESTANTE_TOTAL;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "FPR_FIM_PREVISTO_ATUAL"))
                        mask |= FilaProducaoPrevistaTrackingFields.FPR_FIM_PREVISTO_ATUAL;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "FPR_PRODUZINDO"))
                        mask |= FilaProducaoPrevistaTrackingFields.FPR_PRODUZINDO;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "FPR_ORDEM_NA_FILA"))
                        mask |= FilaProducaoPrevistaTrackingFields.FPR_ORDEM_NA_FILA;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "FPR_ID_INTEGRACAO"))
                        mask |= FilaProducaoPrevistaTrackingFields.FPR_ID_INTEGRACAO;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "FPR_TRUNCADO"))
                        mask |= FilaProducaoPrevistaTrackingFields.FPR_TRUNCADO;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "FPR_DATA_TRUNC_INI"))
                        mask |= FilaProducaoPrevistaTrackingFields.FPR_DATA_TRUNC_INI;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "FPR_DATA_TRUNC_FIM"))
                        mask |= FilaProducaoPrevistaTrackingFields.FPR_DATA_TRUNC_FIM;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "FPR_ID"))
                        mask |= FilaProducaoPrevistaTrackingFields.FPR_ID;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "FPR_COR_FILA"))
                        mask |= FilaProducaoPrevistaTrackingFields.FPR_COR_FILA;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "MAQ_ID_MANUAL"))
                        mask |= FilaProducaoPrevistaTrackingFields.MAQ_ID_MANUAL;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "MAQ_ID_RESTRINGIDA"))
                        mask |= FilaProducaoPrevistaTrackingFields.MAQ_ID_RESTRINGIDA;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "FPR_PREVISAO_MATERIA_PRIMA"))
                        mask |= FilaProducaoPrevistaTrackingFields.FPR_PREVISAO_MATERIA_PRIMA;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "FPR_DATA_NECESSIDADE_INICIO_PRODUCAO"))
                        mask |= FilaProducaoPrevistaTrackingFields.FPR_DATA_NECESSIDADE_INICIO_PRODUCAO;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "FPR_DATA_NECESSIDADE_FIM_PRODUCAO"))
                        mask |= FilaProducaoPrevistaTrackingFields.FPR_DATA_NECESSIDADE_FIM_PRODUCAO;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "FPR_GRUPO_PRODUTIVO"))
                        mask |= FilaProducaoPrevistaTrackingFields.FPR_GRUPO_PRODUTIVO;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "FPR_INICIO_GRUPO_PRODUTIVO"))
                        mask |= FilaProducaoPrevistaTrackingFields.FPR_INICIO_GRUPO_PRODUTIVO;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "FPR_FIM_GRUPO_PRODUTIVO"))
                        mask |= FilaProducaoPrevistaTrackingFields.FPR_FIM_GRUPO_PRODUTIVO;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "FPR_COR_BICO1"))
                        mask |= FilaProducaoPrevistaTrackingFields.FPR_COR_BICO1;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "FPR_COR_BICO2"))
                        mask |= FilaProducaoPrevistaTrackingFields.FPR_COR_BICO2;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "FPR_COR_BICO3"))
                        mask |= FilaProducaoPrevistaTrackingFields.FPR_COR_BICO3;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "FPR_COR_BICO4"))
                        mask |= FilaProducaoPrevistaTrackingFields.FPR_COR_BICO4;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "FPR_COR_BICO5"))
                        mask |= FilaProducaoPrevistaTrackingFields.FPR_COR_BICO5;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "FPR_META_SETUP"))
                        mask |= FilaProducaoPrevistaTrackingFields.FPR_META_SETUP;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "FPR_ORD_ID_REPROGRAMADO"))
                        mask |= FilaProducaoPrevistaTrackingFields.FPR_ORD_ID_REPROGRAMADO;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "FPR_PRIORIDADE"))
                        mask |= FilaProducaoPrevistaTrackingFields.FPR_PRIORIDADE;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "FPR_SEQ_INCLUSAO_FILA"))
                        mask |= FilaProducaoPrevistaTrackingFields.FPR_SEQ_INCLUSAO_FILA;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "FPR_HIERARQUIA_SEQ_TRANSFORMACAO"))
                        mask |= FilaProducaoPrevistaTrackingFields.FPR_HIERARQUIA_SEQ_TRANSFORMACAO;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "FPR_ID_ORIGEM"))
                        mask |= FilaProducaoPrevistaTrackingFields.FPR_ID_ORIGEM;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "FPR_DATA_ENTREGA"))
                        mask |= FilaProducaoPrevistaTrackingFields.FPR_DATA_ENTREGA;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "EQU_ID"))
                        mask |= FilaProducaoPrevistaTrackingFields.EQU_ID;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "FPR_GRUPO_PRODUTIVO_MANUAL"))
                        mask |= FilaProducaoPrevistaTrackingFields.FPR_GRUPO_PRODUTIVO_MANUAL;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "FPR_EMISSAO"))
                        mask |= FilaProducaoPrevistaTrackingFields.FPR_EMISSAO;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "FPR_MOTIVO_PULA_FILA"))
                        mask |= FilaProducaoPrevistaTrackingFields.FPR_MOTIVO_PULA_FILA;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "OCO_ID"))
                        mask |= FilaProducaoPrevistaTrackingFields.OCO_ID;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "FPR_PESO_UNITARIO"))
                        mask |= FilaProducaoPrevistaTrackingFields.FPR_PESO_UNITARIO;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "FPR_M2_UNITARIO"))
                        mask |= FilaProducaoPrevistaTrackingFields.FPR_M2_UNITARIO;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "TenantID"))
                        mask |= FilaProducaoPrevistaTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "FilaProducaoPrevista", operation, recordId, "Deleted"))
                        mask |= FilaProducaoPrevistaTrackingFields.Deleted;
                    return mask;
                }

                private ulong GetT_GrupoMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "T_Grupo", operation, recordId, "GRU_ID"))
                        mask |= T_GrupoTrackingFields.GRU_ID;
                    if (DomainFieldTracked(policy, "T_Grupo", operation, recordId, "NOME"))
                        mask |= T_GrupoTrackingFields.NOME;
                    if (DomainFieldTracked(policy, "T_Grupo", operation, recordId, "EXIBELISTA"))
                        mask |= T_GrupoTrackingFields.EXIBELISTA;
                    if (DomainFieldTracked(policy, "T_Grupo", operation, recordId, "GRU_DESCRICAO"))
                        mask |= T_GrupoTrackingFields.GRU_DESCRICAO;
                    if (DomainFieldTracked(policy, "T_Grupo", operation, recordId, "TenantID"))
                        mask |= T_GrupoTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "T_Grupo", operation, recordId, "Deleted"))
                        mask |= T_GrupoTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "T_Grupo", operation, recordId, "Changed"))
                        mask |= T_GrupoTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "T_Grupo", operation, recordId, "UserId"))
                        mask |= T_GrupoTrackingFields.UserId;
                    return mask;
                }

                private ulong GetGrupoIndicadorMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "GrupoIndicador", operation, recordId, "GRU_IND_ID"))
                        mask |= GrupoIndicadorTrackingFields.GRU_IND_ID;
                    if (DomainFieldTracked(policy, "GrupoIndicador", operation, recordId, "GRU_ID"))
                        mask |= GrupoIndicadorTrackingFields.GRU_ID;
                    if (DomainFieldTracked(policy, "GrupoIndicador", operation, recordId, "IND_ID"))
                        mask |= GrupoIndicadorTrackingFields.IND_ID;
                    if (DomainFieldTracked(policy, "GrupoIndicador", operation, recordId, "TenantID"))
                        mask |= GrupoIndicadorTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "GrupoIndicador", operation, recordId, "Deleted"))
                        mask |= GrupoIndicadorTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "GrupoIndicador", operation, recordId, "Changed"))
                        mask |= GrupoIndicadorTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "GrupoIndicador", operation, recordId, "UserId"))
                        mask |= GrupoIndicadorTrackingFields.UserId;
                    return mask;
                }

                private ulong GetGrupoProdutoAbstratoMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "GrupoProdutoAbstrato", operation, recordId, "GRP_ID"))
                        mask |= GrupoProdutoAbstratoTrackingFields.GRP_ID;
                    if (DomainFieldTracked(policy, "GrupoProdutoAbstrato", operation, recordId, "GRP_DESCRICAO"))
                        mask |= GrupoProdutoAbstratoTrackingFields.GRP_DESCRICAO;
                    if (DomainFieldTracked(policy, "GrupoProdutoAbstrato", operation, recordId, "TEM_ID"))
                        mask |= GrupoProdutoAbstratoTrackingFields.TEM_ID;
                    if (DomainFieldTracked(policy, "GrupoProdutoAbstrato", operation, recordId, "GRP_TIPO"))
                        mask |= GrupoProdutoAbstratoTrackingFields.GRP_TIPO;
                    if (DomainFieldTracked(policy, "GrupoProdutoAbstrato", operation, recordId, "GRP_PAP_ONDA"))
                        mask |= GrupoProdutoAbstratoTrackingFields.GRP_PAP_ONDA;
                    if (DomainFieldTracked(policy, "GrupoProdutoAbstrato", operation, recordId, "GRP_PAP_GRAMATURA"))
                        mask |= GrupoProdutoAbstratoTrackingFields.GRP_PAP_GRAMATURA;
                    if (DomainFieldTracked(policy, "GrupoProdutoAbstrato", operation, recordId, "GRP_PAP_ALTURA"))
                        mask |= GrupoProdutoAbstratoTrackingFields.GRP_PAP_ALTURA;
                    if (DomainFieldTracked(policy, "GrupoProdutoAbstrato", operation, recordId, "GRP_PAP_NOME_COMERCIAL"))
                        mask |= GrupoProdutoAbstratoTrackingFields.GRP_PAP_NOME_COMERCIAL;
                    if (DomainFieldTracked(policy, "GrupoProdutoAbstrato", operation, recordId, "GRP_ATIVO"))
                        mask |= GrupoProdutoAbstratoTrackingFields.GRP_ATIVO;
                    if (DomainFieldTracked(policy, "GrupoProdutoAbstrato", operation, recordId, "GRP_DT_CRIACAO"))
                        mask |= GrupoProdutoAbstratoTrackingFields.GRP_DT_CRIACAO;
                    if (DomainFieldTracked(policy, "GrupoProdutoAbstrato", operation, recordId, "GRP_PAPEL1"))
                        mask |= GrupoProdutoAbstratoTrackingFields.GRP_PAPEL1;
                    if (DomainFieldTracked(policy, "GrupoProdutoAbstrato", operation, recordId, "GRP_PAPEL2"))
                        mask |= GrupoProdutoAbstratoTrackingFields.GRP_PAPEL2;
                    if (DomainFieldTracked(policy, "GrupoProdutoAbstrato", operation, recordId, "GRP_PAPEL3"))
                        mask |= GrupoProdutoAbstratoTrackingFields.GRP_PAPEL3;
                    if (DomainFieldTracked(policy, "GrupoProdutoAbstrato", operation, recordId, "GRP_PAPEL4"))
                        mask |= GrupoProdutoAbstratoTrackingFields.GRP_PAPEL4;
                    if (DomainFieldTracked(policy, "GrupoProdutoAbstrato", operation, recordId, "GRP_PAPEL5"))
                        mask |= GrupoProdutoAbstratoTrackingFields.GRP_PAPEL5;
                    if (DomainFieldTracked(policy, "GrupoProdutoAbstrato", operation, recordId, "GRP_ID_INTEGRACAO"))
                        mask |= GrupoProdutoAbstratoTrackingFields.GRP_ID_INTEGRACAO;
                    if (DomainFieldTracked(policy, "GrupoProdutoAbstrato", operation, recordId, "GRP_ID_INTEGRACAO_ERP"))
                        mask |= GrupoProdutoAbstratoTrackingFields.GRP_ID_INTEGRACAO_ERP;
                    if (DomainFieldTracked(policy, "GrupoProdutoAbstrato", operation, recordId, "GRP_TYPE"))
                        mask |= GrupoProdutoAbstratoTrackingFields.GRP_TYPE;
                    if (DomainFieldTracked(policy, "GrupoProdutoAbstrato", operation, recordId, "GRP_PERFORMANCE"))
                        mask |= GrupoProdutoAbstratoTrackingFields.GRP_PERFORMANCE;
                    if (DomainFieldTracked(policy, "GrupoProdutoAbstrato", operation, recordId, "GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO"))
                        mask |= GrupoProdutoAbstratoTrackingFields.GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO;
                    if (DomainFieldTracked(policy, "GrupoProdutoAbstrato", operation, recordId, "GRP_RESINA"))
                        mask |= GrupoProdutoAbstratoTrackingFields.GRP_RESINA;
                    if (DomainFieldTracked(policy, "GrupoProdutoAbstrato", operation, recordId, "GRP_ENDURECEDOR_MIOLO"))
                        mask |= GrupoProdutoAbstratoTrackingFields.GRP_ENDURECEDOR_MIOLO;
                    if (DomainFieldTracked(policy, "GrupoProdutoAbstrato", operation, recordId, "VIN_ID"))
                        mask |= GrupoProdutoAbstratoTrackingFields.VIN_ID;
                    if (DomainFieldTracked(policy, "GrupoProdutoAbstrato", operation, recordId, "GRP_COLUNA_DE"))
                        mask |= GrupoProdutoAbstratoTrackingFields.GRP_COLUNA_DE;
                    if (DomainFieldTracked(policy, "GrupoProdutoAbstrato", operation, recordId, "GRP_COLUNA_ATE"))
                        mask |= GrupoProdutoAbstratoTrackingFields.GRP_COLUNA_ATE;
                    if (DomainFieldTracked(policy, "GrupoProdutoAbstrato", operation, recordId, "GRP_CRUSH"))
                        mask |= GrupoProdutoAbstratoTrackingFields.GRP_CRUSH;
                    if (DomainFieldTracked(policy, "GrupoProdutoAbstrato", operation, recordId, "GRP_ID_FAMILIA"))
                        mask |= GrupoProdutoAbstratoTrackingFields.GRP_ID_FAMILIA;
                    if (DomainFieldTracked(policy, "GrupoProdutoAbstrato", operation, recordId, "GRP_REFILE_LARGURA"))
                        mask |= GrupoProdutoAbstratoTrackingFields.GRP_REFILE_LARGURA;
                    if (DomainFieldTracked(policy, "GrupoProdutoAbstrato", operation, recordId, "GRP_REFILE_COMPRIMENTO"))
                        mask |= GrupoProdutoAbstratoTrackingFields.GRP_REFILE_COMPRIMENTO;
                    if (DomainFieldTracked(policy, "GrupoProdutoAbstrato", operation, recordId, "GRP_TIPO_LAP"))
                        mask |= GrupoProdutoAbstratoTrackingFields.GRP_TIPO_LAP;
                    if (DomainFieldTracked(policy, "GrupoProdutoAbstrato", operation, recordId, "GRP_LAP_PROLONGADO"))
                        mask |= GrupoProdutoAbstratoTrackingFields.GRP_LAP_PROLONGADO;
                    if (DomainFieldTracked(policy, "GrupoProdutoAbstrato", operation, recordId, "GRP_TAMANHO_LAP_OND_SIMPLES"))
                        mask |= GrupoProdutoAbstratoTrackingFields.GRP_TAMANHO_LAP_OND_SIMPLES;
                    if (DomainFieldTracked(policy, "GrupoProdutoAbstrato", operation, recordId, "GRP_TAMANHO_LAP_OND_DUPLA"))
                        mask |= GrupoProdutoAbstratoTrackingFields.GRP_TAMANHO_LAP_OND_DUPLA;
                    if (DomainFieldTracked(policy, "GrupoProdutoAbstrato", operation, recordId, "GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES"))
                        mask |= GrupoProdutoAbstratoTrackingFields.GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES;
                    if (DomainFieldTracked(policy, "GrupoProdutoAbstrato", operation, recordId, "GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA"))
                        mask |= GrupoProdutoAbstratoTrackingFields.GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA;
                    if (DomainFieldTracked(policy, "GrupoProdutoAbstrato", operation, recordId, "GRP_FEFCO"))
                        mask |= GrupoProdutoAbstratoTrackingFields.GRP_FEFCO;
                    if (DomainFieldTracked(policy, "GrupoProdutoAbstrato", operation, recordId, "GRP_TOLERANCIA_DIMENCAO_CHAPA_DE"))
                        mask |= GrupoProdutoAbstratoTrackingFields.GRP_TOLERANCIA_DIMENCAO_CHAPA_DE;
                    if (DomainFieldTracked(policy, "GrupoProdutoAbstrato", operation, recordId, "GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE"))
                        mask |= GrupoProdutoAbstratoTrackingFields.GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE;
                    if (DomainFieldTracked(policy, "GrupoProdutoAbstrato", operation, recordId, "GRP_PREFIXO_ID_PRODUTO"))
                        mask |= GrupoProdutoAbstratoTrackingFields.GRP_PREFIXO_ID_PRODUTO;
                    if (DomainFieldTracked(policy, "GrupoProdutoAbstrato", operation, recordId, "GRP_COLUNA_CAIXA"))
                        mask |= GrupoProdutoAbstratoTrackingFields.GRP_COLUNA_CAIXA;
                    if (DomainFieldTracked(policy, "GrupoProdutoAbstrato", operation, recordId, "GRP_COLUNA_CHAPA"))
                        mask |= GrupoProdutoAbstratoTrackingFields.GRP_COLUNA_CHAPA;
                    if (DomainFieldTracked(policy, "GrupoProdutoAbstrato", operation, recordId, "GRP_MULLEN"))
                        mask |= GrupoProdutoAbstratoTrackingFields.GRP_MULLEN;
                    if (DomainFieldTracked(policy, "GrupoProdutoAbstrato", operation, recordId, "GRP_TENDENCIA_TOLERANCIA_PEDIDO"))
                        mask |= GrupoProdutoAbstratoTrackingFields.GRP_TENDENCIA_TOLERANCIA_PEDIDO;
                    if (DomainFieldTracked(policy, "GrupoProdutoAbstrato", operation, recordId, "GRP_PERCENTUAL_PERDA_MEDIA"))
                        mask |= GrupoProdutoAbstratoTrackingFields.GRP_PERCENTUAL_PERDA_MEDIA;
                    if (DomainFieldTracked(policy, "GrupoProdutoAbstrato", operation, recordId, "GRP_FILTRA_SEQ_TRANS"))
                        mask |= GrupoProdutoAbstratoTrackingFields.GRP_FILTRA_SEQ_TRANS;
                    if (DomainFieldTracked(policy, "GrupoProdutoAbstrato", operation, recordId, "GRP_IMG_CAIXA"))
                        mask |= GrupoProdutoAbstratoTrackingFields.GRP_IMG_CAIXA;
                    if (DomainFieldTracked(policy, "GrupoProdutoAbstrato", operation, recordId, "TenantID"))
                        mask |= GrupoProdutoAbstratoTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "GrupoProdutoAbstrato", operation, recordId, "Deleted"))
                        mask |= GrupoProdutoAbstratoTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "GrupoProdutoAbstrato", operation, recordId, "Changed"))
                        mask |= GrupoProdutoAbstratoTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "GrupoProdutoAbstrato", operation, recordId, "UserId"))
                        mask |= GrupoProdutoAbstratoTrackingFields.UserId;
                    return mask;
                }

                private ulong GetGrupoRecursoMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "GrupoRecurso", operation, recordId, "GRE_ID"))
                        mask |= GrupoRecursoTrackingFields.GRE_ID;
                    if (DomainFieldTracked(policy, "GrupoRecurso", operation, recordId, "GRE_DESCRICAO"))
                        mask |= GrupoRecursoTrackingFields.GRE_DESCRICAO;
                    if (DomainFieldTracked(policy, "GrupoRecurso", operation, recordId, "TenantID"))
                        mask |= GrupoRecursoTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "GrupoRecurso", operation, recordId, "Deleted"))
                        mask |= GrupoRecursoTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "GrupoRecurso", operation, recordId, "Changed"))
                        mask |= GrupoRecursoTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "GrupoRecurso", operation, recordId, "UserId"))
                        mask |= GrupoRecursoTrackingFields.UserId;
                    return mask;
                }

                private ulong GetGrupoSegmentoMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "GrupoSegmento", operation, recordId, "Id"))
                        mask |= GrupoSegmentoTrackingFields.Id;
                    if (DomainFieldTracked(policy, "GrupoSegmento", operation, recordId, "GRS_ID"))
                        mask |= GrupoSegmentoTrackingFields.GRS_ID;
                    if (DomainFieldTracked(policy, "GrupoSegmento", operation, recordId, "GRS_DESCRICAO"))
                        mask |= GrupoSegmentoTrackingFields.GRS_DESCRICAO;
                    if (DomainFieldTracked(policy, "GrupoSegmento", operation, recordId, "GRS_INTEGRACAO_ERP"))
                        mask |= GrupoSegmentoTrackingFields.GRS_INTEGRACAO_ERP;
                    if (DomainFieldTracked(policy, "GrupoSegmento", operation, recordId, "TenantID"))
                        mask |= GrupoSegmentoTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "GrupoSegmento", operation, recordId, "Deleted"))
                        mask |= GrupoSegmentoTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "GrupoSegmento", operation, recordId, "Changed"))
                        mask |= GrupoSegmentoTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "GrupoSegmento", operation, recordId, "UserId"))
                        mask |= GrupoSegmentoTrackingFields.UserId;
                    return mask;
                }

                private ulong GetT_HORARIO_RECEBIMENTOMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "T_HORARIO_RECEBIMENTO", operation, recordId, "HRE_DIA_DA_SEMANA"))
                        mask |= T_HORARIO_RECEBIMENTOTrackingFields.HRE_DIA_DA_SEMANA;
                    if (DomainFieldTracked(policy, "T_HORARIO_RECEBIMENTO", operation, recordId, "HRE_HORA_INICIAL"))
                        mask |= T_HORARIO_RECEBIMENTOTrackingFields.HRE_HORA_INICIAL;
                    if (DomainFieldTracked(policy, "T_HORARIO_RECEBIMENTO", operation, recordId, "HRE_HORA_FINAL"))
                        mask |= T_HORARIO_RECEBIMENTOTrackingFields.HRE_HORA_FINAL;
                    if (DomainFieldTracked(policy, "T_HORARIO_RECEBIMENTO", operation, recordId, "CLI_ID"))
                        mask |= T_HORARIO_RECEBIMENTOTrackingFields.CLI_ID;
                    if (DomainFieldTracked(policy, "T_HORARIO_RECEBIMENTO", operation, recordId, "HRE_ID"))
                        mask |= T_HORARIO_RECEBIMENTOTrackingFields.HRE_ID;
                    if (DomainFieldTracked(policy, "T_HORARIO_RECEBIMENTO", operation, recordId, "TenantID"))
                        mask |= T_HORARIO_RECEBIMENTOTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "T_HORARIO_RECEBIMENTO", operation, recordId, "Deleted"))
                        mask |= T_HORARIO_RECEBIMENTOTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "T_HORARIO_RECEBIMENTO", operation, recordId, "Changed"))
                        mask |= T_HORARIO_RECEBIMENTOTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "T_HORARIO_RECEBIMENTO", operation, recordId, "UserId"))
                        mask |= T_HORARIO_RECEBIMENTOTrackingFields.UserId;
                    return mask;
                }

                private ulong GetImpressoraMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Impressora", operation, recordId, "IMP_ID"))
                        mask |= ImpressoraTrackingFields.IMP_ID;
                    if (DomainFieldTracked(policy, "Impressora", operation, recordId, "IMP_IP"))
                        mask |= ImpressoraTrackingFields.IMP_IP;
                    if (DomainFieldTracked(policy, "Impressora", operation, recordId, "IMP_NOME"))
                        mask |= ImpressoraTrackingFields.IMP_NOME;
                    if (DomainFieldTracked(policy, "Impressora", operation, recordId, "TenantID"))
                        mask |= ImpressoraTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Impressora", operation, recordId, "Deleted"))
                        mask |= ImpressoraTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Impressora", operation, recordId, "Changed"))
                        mask |= ImpressoraTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Impressora", operation, recordId, "UserId"))
                        mask |= ImpressoraTrackingFields.UserId;
                    return mask;
                }

                private ulong GetT_IndicadoresMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "T_Indicadores", operation, recordId, "IND_ID"))
                        mask |= T_IndicadoresTrackingFields.IND_ID;
                    if (DomainFieldTracked(policy, "T_Indicadores", operation, recordId, "IND_DESCRICAO"))
                        mask |= T_IndicadoresTrackingFields.IND_DESCRICAO;
                    if (DomainFieldTracked(policy, "T_Indicadores", operation, recordId, "NEG_ID"))
                        mask |= T_IndicadoresTrackingFields.NEG_ID;
                    if (DomainFieldTracked(policy, "T_Indicadores", operation, recordId, "DESC_CALCULO"))
                        mask |= T_IndicadoresTrackingFields.DESC_CALCULO;
                    if (DomainFieldTracked(policy, "T_Indicadores", operation, recordId, "IND_TIPOCOMPARADOR"))
                        mask |= T_IndicadoresTrackingFields.IND_TIPOCOMPARADOR;
                    if (DomainFieldTracked(policy, "T_Indicadores", operation, recordId, "IND_GRAFICO"))
                        mask |= T_IndicadoresTrackingFields.IND_GRAFICO;
                    if (DomainFieldTracked(policy, "T_Indicadores", operation, recordId, "IND_CONEXAO"))
                        mask |= T_IndicadoresTrackingFields.IND_CONEXAO;
                    if (DomainFieldTracked(policy, "T_Indicadores", operation, recordId, "IND_DTCRIACAO"))
                        mask |= T_IndicadoresTrackingFields.IND_DTCRIACAO;
                    if (DomainFieldTracked(policy, "T_Indicadores", operation, recordId, "RESPOSAVELIND"))
                        mask |= T_IndicadoresTrackingFields.RESPOSAVELIND;
                    if (DomainFieldTracked(policy, "T_Indicadores", operation, recordId, "RESPOSAVELCARGA"))
                        mask |= T_IndicadoresTrackingFields.RESPOSAVELCARGA;
                    if (DomainFieldTracked(policy, "T_Indicadores", operation, recordId, "PROCEXTRACAO"))
                        mask |= T_IndicadoresTrackingFields.PROCEXTRACAO;
                    if (DomainFieldTracked(policy, "T_Indicadores", operation, recordId, "PER_ID"))
                        mask |= T_IndicadoresTrackingFields.PER_ID;
                    if (DomainFieldTracked(policy, "T_Indicadores", operation, recordId, "DIM_ID"))
                        mask |= T_IndicadoresTrackingFields.DIM_ID;
                    if (DomainFieldTracked(policy, "T_Indicadores", operation, recordId, "DOM_EMPRESA"))
                        mask |= T_IndicadoresTrackingFields.DOM_EMPRESA;
                    if (DomainFieldTracked(policy, "T_Indicadores", operation, recordId, "DOM_FILIAL"))
                        mask |= T_IndicadoresTrackingFields.DOM_FILIAL;
                    if (DomainFieldTracked(policy, "T_Indicadores", operation, recordId, "TenantID"))
                        mask |= T_IndicadoresTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "T_Indicadores", operation, recordId, "Deleted"))
                        mask |= T_IndicadoresTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "T_Indicadores", operation, recordId, "Changed"))
                        mask |= T_IndicadoresTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "T_Indicadores", operation, recordId, "UserId"))
                        mask |= T_IndicadoresTrackingFields.UserId;
                    return mask;
                }

                private ulong GetIndicadoresDepartamentosMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "IndicadoresDepartamentos", operation, recordId, "INDDEP_ID"))
                        mask |= IndicadoresDepartamentosTrackingFields.INDDEP_ID;
                    if (DomainFieldTracked(policy, "IndicadoresDepartamentos", operation, recordId, "DEP_ID"))
                        mask |= IndicadoresDepartamentosTrackingFields.DEP_ID;
                    if (DomainFieldTracked(policy, "IndicadoresDepartamentos", operation, recordId, "IND_ID"))
                        mask |= IndicadoresDepartamentosTrackingFields.IND_ID;
                    if (DomainFieldTracked(policy, "IndicadoresDepartamentos", operation, recordId, "TenantID"))
                        mask |= IndicadoresDepartamentosTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "IndicadoresDepartamentos", operation, recordId, "Deleted"))
                        mask |= IndicadoresDepartamentosTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "IndicadoresDepartamentos", operation, recordId, "Changed"))
                        mask |= IndicadoresDepartamentosTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "IndicadoresDepartamentos", operation, recordId, "UserId"))
                        mask |= IndicadoresDepartamentosTrackingFields.UserId;
                    return mask;
                }

                private ulong GetIndicadoresDimencoesMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "IndicadoresDimencoes", operation, recordId, "Id"))
                        mask |= IndicadoresDimencoesTrackingFields.Id;
                    if (DomainFieldTracked(policy, "IndicadoresDimencoes", operation, recordId, "DIM_ID"))
                        mask |= IndicadoresDimencoesTrackingFields.DIM_ID;
                    if (DomainFieldTracked(policy, "IndicadoresDimencoes", operation, recordId, "IND_ID"))
                        mask |= IndicadoresDimencoesTrackingFields.IND_ID;
                    if (DomainFieldTracked(policy, "IndicadoresDimencoes", operation, recordId, "DIM_DESCRICAO"))
                        mask |= IndicadoresDimencoesTrackingFields.DIM_DESCRICAO;
                    if (DomainFieldTracked(policy, "IndicadoresDimencoes", operation, recordId, "DIM_SQL"))
                        mask |= IndicadoresDimencoesTrackingFields.DIM_SQL;
                    if (DomainFieldTracked(policy, "IndicadoresDimencoes", operation, recordId, "DIM_CONEXAO"))
                        mask |= IndicadoresDimencoesTrackingFields.DIM_CONEXAO;
                    if (DomainFieldTracked(policy, "IndicadoresDimencoes", operation, recordId, "TenantID"))
                        mask |= IndicadoresDimencoesTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "IndicadoresDimencoes", operation, recordId, "Deleted"))
                        mask |= IndicadoresDimencoesTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "IndicadoresDimencoes", operation, recordId, "Changed"))
                        mask |= IndicadoresDimencoesTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "IndicadoresDimencoes", operation, recordId, "UserId"))
                        mask |= IndicadoresDimencoesTrackingFields.UserId;
                    return mask;
                }

                private ulong GetIndicadoresFatosDimencoesMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "IndicadoresFatosDimencoes", operation, recordId, "Id"))
                        mask |= IndicadoresFatosDimencoesTrackingFields.Id;
                    if (DomainFieldTracked(policy, "IndicadoresFatosDimencoes", operation, recordId, "FAT_ID"))
                        mask |= IndicadoresFatosDimencoesTrackingFields.FAT_ID;
                    if (DomainFieldTracked(policy, "IndicadoresFatosDimencoes", operation, recordId, "IND_ID"))
                        mask |= IndicadoresFatosDimencoesTrackingFields.IND_ID;
                    if (DomainFieldTracked(policy, "IndicadoresFatosDimencoes", operation, recordId, "DIM_ID"))
                        mask |= IndicadoresFatosDimencoesTrackingFields.DIM_ID;
                    if (DomainFieldTracked(policy, "IndicadoresFatosDimencoes", operation, recordId, "FAT_DESCRICAO"))
                        mask |= IndicadoresFatosDimencoesTrackingFields.FAT_DESCRICAO;
                    if (DomainFieldTracked(policy, "IndicadoresFatosDimencoes", operation, recordId, "TenantID"))
                        mask |= IndicadoresFatosDimencoesTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "IndicadoresFatosDimencoes", operation, recordId, "Deleted"))
                        mask |= IndicadoresFatosDimencoesTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "IndicadoresFatosDimencoes", operation, recordId, "Changed"))
                        mask |= IndicadoresFatosDimencoesTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "IndicadoresFatosDimencoes", operation, recordId, "UserId"))
                        mask |= IndicadoresFatosDimencoesTrackingFields.UserId;
                    return mask;
                }

                private ulong GetIndicadoresPeriodosDimencoesMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "IndicadoresPeriodosDimencoes", operation, recordId, "Id"))
                        mask |= IndicadoresPeriodosDimencoesTrackingFields.Id;
                    if (DomainFieldTracked(policy, "IndicadoresPeriodosDimencoes", operation, recordId, "PER_ID"))
                        mask |= IndicadoresPeriodosDimencoesTrackingFields.PER_ID;
                    if (DomainFieldTracked(policy, "IndicadoresPeriodosDimencoes", operation, recordId, "IND_ID"))
                        mask |= IndicadoresPeriodosDimencoesTrackingFields.IND_ID;
                    if (DomainFieldTracked(policy, "IndicadoresPeriodosDimencoes", operation, recordId, "DIM_ID"))
                        mask |= IndicadoresPeriodosDimencoesTrackingFields.DIM_ID;
                    if (DomainFieldTracked(policy, "IndicadoresPeriodosDimencoes", operation, recordId, "PER_DESCRICAO"))
                        mask |= IndicadoresPeriodosDimencoesTrackingFields.PER_DESCRICAO;
                    if (DomainFieldTracked(policy, "IndicadoresPeriodosDimencoes", operation, recordId, "TenantID"))
                        mask |= IndicadoresPeriodosDimencoesTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "IndicadoresPeriodosDimencoes", operation, recordId, "Deleted"))
                        mask |= IndicadoresPeriodosDimencoesTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "IndicadoresPeriodosDimencoes", operation, recordId, "Changed"))
                        mask |= IndicadoresPeriodosDimencoesTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "IndicadoresPeriodosDimencoes", operation, recordId, "UserId"))
                        mask |= IndicadoresPeriodosDimencoesTrackingFields.UserId;
                    return mask;
                }

                private ulong GetInformacoesComplementaresMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "InformacoesComplementares", operation, recordId, "INF_ID"))
                        mask |= InformacoesComplementaresTrackingFields.INF_ID;
                    if (DomainFieldTracked(policy, "InformacoesComplementares", operation, recordId, "INF_DESCRICAO"))
                        mask |= InformacoesComplementaresTrackingFields.INF_DESCRICAO;
                    if (DomainFieldTracked(policy, "InformacoesComplementares", operation, recordId, "INF_VALOR"))
                        mask |= InformacoesComplementaresTrackingFields.INF_VALOR;
                    if (DomainFieldTracked(policy, "InformacoesComplementares", operation, recordId, "MET_ID"))
                        mask |= InformacoesComplementaresTrackingFields.MET_ID;
                    if (DomainFieldTracked(policy, "InformacoesComplementares", operation, recordId, "INF_DATA"))
                        mask |= InformacoesComplementaresTrackingFields.INF_DATA;
                    if (DomainFieldTracked(policy, "InformacoesComplementares", operation, recordId, "TenantID"))
                        mask |= InformacoesComplementaresTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "InformacoesComplementares", operation, recordId, "Deleted"))
                        mask |= InformacoesComplementaresTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "InformacoesComplementares", operation, recordId, "Changed"))
                        mask |= InformacoesComplementaresTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "InformacoesComplementares", operation, recordId, "UserId"))
                        mask |= InformacoesComplementaresTrackingFields.UserId;
                    return mask;
                }

                private ulong GetInpecaoVisualMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "InpecaoVisual", operation, recordId, "Id"))
                        mask |= InpecaoVisualTrackingFields.Id;
                    if (DomainFieldTracked(policy, "InpecaoVisual", operation, recordId, "IPV_ID"))
                        mask |= InpecaoVisualTrackingFields.IPV_ID;
                    if (DomainFieldTracked(policy, "InpecaoVisual", operation, recordId, "TenantID"))
                        mask |= InpecaoVisualTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "InpecaoVisual", operation, recordId, "Deleted"))
                        mask |= InpecaoVisualTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "InpecaoVisual", operation, recordId, "Changed"))
                        mask |= InpecaoVisualTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "InpecaoVisual", operation, recordId, "UserId"))
                        mask |= InpecaoVisualTrackingFields.UserId;
                    return mask;
                }

                private ulong GetItemInspecaoMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "ItemInspecao", operation, recordId, "Id"))
                        mask |= ItemInspecaoTrackingFields.Id;
                    if (DomainFieldTracked(policy, "ItemInspecao", operation, recordId, "ITI_ID"))
                        mask |= ItemInspecaoTrackingFields.ITI_ID;
                    if (DomainFieldTracked(policy, "ItemInspecao", operation, recordId, "ITI_DESC"))
                        mask |= ItemInspecaoTrackingFields.ITI_DESC;
                    if (DomainFieldTracked(policy, "ItemInspecao", operation, recordId, "TenantID"))
                        mask |= ItemInspecaoTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "ItemInspecao", operation, recordId, "Deleted"))
                        mask |= ItemInspecaoTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "ItemInspecao", operation, recordId, "Changed"))
                        mask |= ItemInspecaoTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "ItemInspecao", operation, recordId, "UserId"))
                        mask |= ItemInspecaoTrackingFields.UserId;
                    return mask;
                }

                private ulong GetItemTestavelMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "ItemTestavel", operation, recordId, "Id"))
                        mask |= ItemTestavelTrackingFields.Id;
                    if (DomainFieldTracked(policy, "ItemTestavel", operation, recordId, "ITE_ID"))
                        mask |= ItemTestavelTrackingFields.ITE_ID;
                    if (DomainFieldTracked(policy, "ItemTestavel", operation, recordId, "ITE_DESCRICAO"))
                        mask |= ItemTestavelTrackingFields.ITE_DESCRICAO;
                    if (DomainFieldTracked(policy, "ItemTestavel", operation, recordId, "ITE_OBS"))
                        mask |= ItemTestavelTrackingFields.ITE_OBS;
                    if (DomainFieldTracked(policy, "ItemTestavel", operation, recordId, "ITE_NUMERO_DE_TESTES"))
                        mask |= ItemTestavelTrackingFields.ITE_NUMERO_DE_TESTES;
                    if (DomainFieldTracked(policy, "ItemTestavel", operation, recordId, "ITE_CONDICIONAL_DE_AVALIACAO"))
                        mask |= ItemTestavelTrackingFields.ITE_CONDICIONAL_DE_AVALIACAO;
                    if (DomainFieldTracked(policy, "ItemTestavel", operation, recordId, "ITE_VALOR_DA_CONDICIONAL"))
                        mask |= ItemTestavelTrackingFields.ITE_VALOR_DA_CONDICIONAL;
                    if (DomainFieldTracked(policy, "ItemTestavel", operation, recordId, "ITE_VALOR_CALCULADO_DA_CONDICIONAL"))
                        mask |= ItemTestavelTrackingFields.ITE_VALOR_CALCULADO_DA_CONDICIONAL;
                    if (DomainFieldTracked(policy, "ItemTestavel", operation, recordId, "ITE_TIPO_AVALIACAO_FINAL"))
                        mask |= ItemTestavelTrackingFields.ITE_TIPO_AVALIACAO_FINAL;
                    if (DomainFieldTracked(policy, "ItemTestavel", operation, recordId, "TenantID"))
                        mask |= ItemTestavelTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "ItemTestavel", operation, recordId, "Deleted"))
                        mask |= ItemTestavelTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "ItemTestavel", operation, recordId, "Changed"))
                        mask |= ItemTestavelTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "ItemTestavel", operation, recordId, "UserId"))
                        mask |= ItemTestavelTrackingFields.UserId;
                    return mask;
                }

                private ulong GetItensCalendarioMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "ItensCalendario", operation, recordId, "ICA_ID"))
                        mask |= ItensCalendarioTrackingFields.ICA_ID;
                    if (DomainFieldTracked(policy, "ItensCalendario", operation, recordId, "ICA_DATA_DE"))
                        mask |= ItensCalendarioTrackingFields.ICA_DATA_DE;
                    if (DomainFieldTracked(policy, "ItensCalendario", operation, recordId, "ICA_DATA_ATE"))
                        mask |= ItensCalendarioTrackingFields.ICA_DATA_ATE;
                    if (DomainFieldTracked(policy, "ItensCalendario", operation, recordId, "ICA_OBSERVACAO"))
                        mask |= ItensCalendarioTrackingFields.ICA_OBSERVACAO;
                    if (DomainFieldTracked(policy, "ItensCalendario", operation, recordId, "ICA_TIPO"))
                        mask |= ItensCalendarioTrackingFields.ICA_TIPO;
                    if (DomainFieldTracked(policy, "ItensCalendario", operation, recordId, "URM_ID"))
                        mask |= ItensCalendarioTrackingFields.URM_ID;
                    if (DomainFieldTracked(policy, "ItensCalendario", operation, recordId, "URN_ID"))
                        mask |= ItensCalendarioTrackingFields.URN_ID;
                    if (DomainFieldTracked(policy, "ItensCalendario", operation, recordId, "CAL_ID"))
                        mask |= ItensCalendarioTrackingFields.CAL_ID;
                    if (DomainFieldTracked(policy, "ItensCalendario", operation, recordId, "MAQ_ID"))
                        mask |= ItensCalendarioTrackingFields.MAQ_ID;
                    if (DomainFieldTracked(policy, "ItensCalendario", operation, recordId, "PRO_ID"))
                        mask |= ItensCalendarioTrackingFields.PRO_ID;
                    if (DomainFieldTracked(policy, "ItensCalendario", operation, recordId, "ICA_LIMPESA_MAQUINA"))
                        mask |= ItensCalendarioTrackingFields.ICA_LIMPESA_MAQUINA;
                    if (DomainFieldTracked(policy, "ItensCalendario", operation, recordId, "TenantID"))
                        mask |= ItensCalendarioTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "ItensCalendario", operation, recordId, "Deleted"))
                        mask |= ItensCalendarioTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "ItensCalendario", operation, recordId, "Changed"))
                        mask |= ItensCalendarioTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "ItensCalendario", operation, recordId, "UserId"))
                        mask |= ItensCalendarioTrackingFields.UserId;
                    return mask;
                }

                private ulong GetItenCalendarioDisponibilidadeVeiculosMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "ItenCalendarioDisponibilidadeVeiculos", operation, recordId, "Id"))
                        mask |= ItenCalendarioDisponibilidadeVeiculosTrackingFields.Id;
                    if (DomainFieldTracked(policy, "ItenCalendarioDisponibilidadeVeiculos", operation, recordId, "CDV_ID"))
                        mask |= ItenCalendarioDisponibilidadeVeiculosTrackingFields.CDV_ID;
                    if (DomainFieldTracked(policy, "ItenCalendarioDisponibilidadeVeiculos", operation, recordId, "TIP_ID"))
                        mask |= ItenCalendarioDisponibilidadeVeiculosTrackingFields.TIP_ID;
                    if (DomainFieldTracked(policy, "ItenCalendarioDisponibilidadeVeiculos", operation, recordId, "IDV_QTD"))
                        mask |= ItenCalendarioDisponibilidadeVeiculosTrackingFields.IDV_QTD;
                    if (DomainFieldTracked(policy, "ItenCalendarioDisponibilidadeVeiculos", operation, recordId, "TenantID"))
                        mask |= ItenCalendarioDisponibilidadeVeiculosTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "ItenCalendarioDisponibilidadeVeiculos", operation, recordId, "Deleted"))
                        mask |= ItenCalendarioDisponibilidadeVeiculosTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "ItenCalendarioDisponibilidadeVeiculos", operation, recordId, "Changed"))
                        mask |= ItenCalendarioDisponibilidadeVeiculosTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "ItenCalendarioDisponibilidadeVeiculos", operation, recordId, "UserId"))
                        mask |= ItenCalendarioDisponibilidadeVeiculosTrackingFields.UserId;
                    return mask;
                }

                private ulong GetItenCargaMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "ItenCarga", operation, recordId, "Id"))
                        mask |= ItenCargaTrackingFields.Id;
                    if (DomainFieldTracked(policy, "ItenCarga", operation, recordId, "CAR_ID"))
                        mask |= ItenCargaTrackingFields.CAR_ID;
                    if (DomainFieldTracked(policy, "ItenCarga", operation, recordId, "ORD_ID"))
                        mask |= ItenCargaTrackingFields.ORD_ID;
                    if (DomainFieldTracked(policy, "ItenCarga", operation, recordId, "ITC_ENTREGA_PLANEJADA"))
                        mask |= ItenCargaTrackingFields.ITC_ENTREGA_PLANEJADA;
                    if (DomainFieldTracked(policy, "ItenCarga", operation, recordId, "ITC_ENTREGA_REALIZADA"))
                        mask |= ItenCargaTrackingFields.ITC_ENTREGA_REALIZADA;
                    if (DomainFieldTracked(policy, "ItenCarga", operation, recordId, "ITC_ORDEM_ENTREGA"))
                        mask |= ItenCargaTrackingFields.ITC_ORDEM_ENTREGA;
                    if (DomainFieldTracked(policy, "ItenCarga", operation, recordId, "ITC_QTD_PLANEJADA"))
                        mask |= ItenCargaTrackingFields.ITC_QTD_PLANEJADA;
                    if (DomainFieldTracked(policy, "ItenCarga", operation, recordId, "ITC_QTD_REALIZADA"))
                        mask |= ItenCargaTrackingFields.ITC_QTD_REALIZADA;
                    if (DomainFieldTracked(policy, "ItenCarga", operation, recordId, "ORD_HASH_KEY"))
                        mask |= ItenCargaTrackingFields.ORD_HASH_KEY;
                    if (DomainFieldTracked(policy, "ItenCarga", operation, recordId, "NOT_ID"))
                        mask |= ItenCargaTrackingFields.NOT_ID;
                    if (DomainFieldTracked(policy, "ItenCarga", operation, recordId, "NOT_EMISSAO"))
                        mask |= ItenCargaTrackingFields.NOT_EMISSAO;
                    if (DomainFieldTracked(policy, "ItenCarga", operation, recordId, "TenantID"))
                        mask |= ItenCargaTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "ItenCarga", operation, recordId, "Deleted"))
                        mask |= ItenCargaTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "ItenCarga", operation, recordId, "Changed"))
                        mask |= ItenCargaTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "ItenCarga", operation, recordId, "UserId"))
                        mask |= ItenCargaTrackingFields.UserId;
                    return mask;
                }

                private ulong GetItensEstruturaImpressaoMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "ItensEstruturaImpressao", operation, recordId, "Id"))
                        mask |= ItensEstruturaImpressaoTrackingFields.Id;
                    if (DomainFieldTracked(policy, "ItensEstruturaImpressao", operation, recordId, "IES_CUSTOM_FONT_SIZE"))
                        mask |= ItensEstruturaImpressaoTrackingFields.IES_CUSTOM_FONT_SIZE;
                    if (DomainFieldTracked(policy, "ItensEstruturaImpressao", operation, recordId, "TenantID"))
                        mask |= ItensEstruturaImpressaoTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "ItensEstruturaImpressao", operation, recordId, "Deleted"))
                        mask |= ItensEstruturaImpressaoTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "ItensEstruturaImpressao", operation, recordId, "Changed"))
                        mask |= ItensEstruturaImpressaoTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "ItensEstruturaImpressao", operation, recordId, "UserId"))
                        mask |= ItensEstruturaImpressaoTrackingFields.UserId;
                    return mask;
                }

                private ulong GetItensOrcamentoMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "ItensOrcamento", operation, recordId, "Id"))
                        mask |= ItensOrcamentoTrackingFields.Id;
                    if (DomainFieldTracked(policy, "ItensOrcamento", operation, recordId, "ITO_ID"))
                        mask |= ItensOrcamentoTrackingFields.ITO_ID;
                    if (DomainFieldTracked(policy, "ItensOrcamento", operation, recordId, "ORC_ID"))
                        mask |= ItensOrcamentoTrackingFields.ORC_ID;
                    if (DomainFieldTracked(policy, "ItensOrcamento", operation, recordId, "TIP_ID"))
                        mask |= ItensOrcamentoTrackingFields.TIP_ID;
                    if (DomainFieldTracked(policy, "ItensOrcamento", operation, recordId, "PRO_ID"))
                        mask |= ItensOrcamentoTrackingFields.PRO_ID;
                    if (DomainFieldTracked(policy, "ItensOrcamento", operation, recordId, "ITO_OBS"))
                        mask |= ItensOrcamentoTrackingFields.ITO_OBS;
                    if (DomainFieldTracked(policy, "ItensOrcamento", operation, recordId, "ITO_QUANTIDADE"))
                        mask |= ItensOrcamentoTrackingFields.ITO_QUANTIDADE;
                    if (DomainFieldTracked(policy, "ItensOrcamento", operation, recordId, "ITO_CUSTO"))
                        mask |= ItensOrcamentoTrackingFields.ITO_CUSTO;
                    if (DomainFieldTracked(policy, "ItensOrcamento", operation, recordId, "ITO_MARGEM"))
                        mask |= ItensOrcamentoTrackingFields.ITO_MARGEM;
                    if (DomainFieldTracked(policy, "ItensOrcamento", operation, recordId, "ITO_VALOR_UNITARIO"))
                        mask |= ItensOrcamentoTrackingFields.ITO_VALOR_UNITARIO;
                    if (DomainFieldTracked(policy, "ItensOrcamento", operation, recordId, "ITO_VERSSAO_CUSTO"))
                        mask |= ItensOrcamentoTrackingFields.ITO_VERSSAO_CUSTO;
                    if (DomainFieldTracked(policy, "ItensOrcamento", operation, recordId, "ITO_STATUS"))
                        mask |= ItensOrcamentoTrackingFields.ITO_STATUS;
                    if (DomainFieldTracked(policy, "ItensOrcamento", operation, recordId, "ITO_ERP_CUSTOS_FIXOS"))
                        mask |= ItensOrcamentoTrackingFields.ITO_ERP_CUSTOS_FIXOS;
                    if (DomainFieldTracked(policy, "ItensOrcamento", operation, recordId, "ITO_ERP_CUSTOS_VARIAVEIS"))
                        mask |= ItensOrcamentoTrackingFields.ITO_ERP_CUSTOS_VARIAVEIS;
                    if (DomainFieldTracked(policy, "ItensOrcamento", operation, recordId, "ITO_ERP_DESPESAS_VAR_VENDA"))
                        mask |= ItensOrcamentoTrackingFields.ITO_ERP_DESPESAS_VAR_VENDA;
                    if (DomainFieldTracked(policy, "ItensOrcamento", operation, recordId, "ITO_ERP_IMPOSTOS"))
                        mask |= ItensOrcamentoTrackingFields.ITO_ERP_IMPOSTOS;
                    if (DomainFieldTracked(policy, "ItensOrcamento", operation, recordId, "GRP_ID_COMPOSICAO"))
                        mask |= ItensOrcamentoTrackingFields.GRP_ID_COMPOSICAO;
                    if (DomainFieldTracked(policy, "ItensOrcamento", operation, recordId, "ITO_LARGURA"))
                        mask |= ItensOrcamentoTrackingFields.ITO_LARGURA;
                    if (DomainFieldTracked(policy, "ItensOrcamento", operation, recordId, "ITO_COMPRIMENTO"))
                        mask |= ItensOrcamentoTrackingFields.ITO_COMPRIMENTO;
                    if (DomainFieldTracked(policy, "ItensOrcamento", operation, recordId, "TenantID"))
                        mask |= ItensOrcamentoTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "ItensOrcamento", operation, recordId, "Deleted"))
                        mask |= ItensOrcamentoTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "ItensOrcamento", operation, recordId, "Changed"))
                        mask |= ItensOrcamentoTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "ItensOrcamento", operation, recordId, "UserId"))
                        mask |= ItensOrcamentoTrackingFields.UserId;
                    return mask;
                }

                private ulong GetItensPackedMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "ItensPacked", operation, recordId, "Id"))
                        mask |= ItensPackedTrackingFields.Id;
                    if (DomainFieldTracked(policy, "ItensPacked", operation, recordId, "IPA_ID"))
                        mask |= ItensPackedTrackingFields.IPA_ID;
                    if (DomainFieldTracked(policy, "ItensPacked", operation, recordId, "CAR_ID"))
                        mask |= ItensPackedTrackingFields.CAR_ID;
                    if (DomainFieldTracked(policy, "ItensPacked", operation, recordId, "PRO_ID"))
                        mask |= ItensPackedTrackingFields.PRO_ID;
                    if (DomainFieldTracked(policy, "ItensPacked", operation, recordId, "ORD_ID"))
                        mask |= ItensPackedTrackingFields.ORD_ID;
                    if (DomainFieldTracked(policy, "ItensPacked", operation, recordId, "IPA_COORDC"))
                        mask |= ItensPackedTrackingFields.IPA_COORDC;
                    if (DomainFieldTracked(policy, "ItensPacked", operation, recordId, "IPA_COORDL"))
                        mask |= ItensPackedTrackingFields.IPA_COORDL;
                    if (DomainFieldTracked(policy, "ItensPacked", operation, recordId, "IPA_COORDA"))
                        mask |= ItensPackedTrackingFields.IPA_COORDA;
                    if (DomainFieldTracked(policy, "ItensPacked", operation, recordId, "IPA_DIMC"))
                        mask |= ItensPackedTrackingFields.IPA_DIMC;
                    if (DomainFieldTracked(policy, "ItensPacked", operation, recordId, "IPA_DIML"))
                        mask |= ItensPackedTrackingFields.IPA_DIML;
                    if (DomainFieldTracked(policy, "ItensPacked", operation, recordId, "IPA_DIMA"))
                        mask |= ItensPackedTrackingFields.IPA_DIMA;
                    if (DomainFieldTracked(policy, "ItensPacked", operation, recordId, "IPA_QTD_POR_PALETE"))
                        mask |= ItensPackedTrackingFields.IPA_QTD_POR_PALETE;
                    if (DomainFieldTracked(policy, "ItensPacked", operation, recordId, "TenantID"))
                        mask |= ItensPackedTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "ItensPacked", operation, recordId, "Deleted"))
                        mask |= ItensPackedTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "ItensPacked", operation, recordId, "Changed"))
                        mask |= ItensPackedTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "ItensPacked", operation, recordId, "UserId"))
                        mask |= ItensPackedTrackingFields.UserId;
                    return mask;
                }

                private ulong GetLaudoTesteFisicoMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "LaudoTesteFisico", operation, recordId, "Id"))
                        mask |= LaudoTesteFisicoTrackingFields.Id;
                    if (DomainFieldTracked(policy, "LaudoTesteFisico", operation, recordId, "LTF_ID"))
                        mask |= LaudoTesteFisicoTrackingFields.LTF_ID;
                    if (DomainFieldTracked(policy, "LaudoTesteFisico", operation, recordId, "LTF_EMISSAO"))
                        mask |= LaudoTesteFisicoTrackingFields.LTF_EMISSAO;
                    if (DomainFieldTracked(policy, "LaudoTesteFisico", operation, recordId, "LTF_VALOR"))
                        mask |= LaudoTesteFisicoTrackingFields.LTF_VALOR;
                    if (DomainFieldTracked(policy, "LaudoTesteFisico", operation, recordId, "LTF_OBS"))
                        mask |= LaudoTesteFisicoTrackingFields.LTF_OBS;
                    if (DomainFieldTracked(policy, "LaudoTesteFisico", operation, recordId, "LTF_STATUS"))
                        mask |= LaudoTesteFisicoTrackingFields.LTF_STATUS;
                    if (DomainFieldTracked(policy, "LaudoTesteFisico", operation, recordId, "ORD_ID"))
                        mask |= LaudoTesteFisicoTrackingFields.ORD_ID;
                    if (DomainFieldTracked(policy, "LaudoTesteFisico", operation, recordId, "ROT_PRO_ID"))
                        mask |= LaudoTesteFisicoTrackingFields.ROT_PRO_ID;
                    if (DomainFieldTracked(policy, "LaudoTesteFisico", operation, recordId, "FPR_SEQ_REPETICAO"))
                        mask |= LaudoTesteFisicoTrackingFields.FPR_SEQ_REPETICAO;
                    if (DomainFieldTracked(policy, "LaudoTesteFisico", operation, recordId, "USE_ID"))
                        mask |= LaudoTesteFisicoTrackingFields.USE_ID;
                    if (DomainFieldTracked(policy, "LaudoTesteFisico", operation, recordId, "TenantID"))
                        mask |= LaudoTesteFisicoTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "LaudoTesteFisico", operation, recordId, "Deleted"))
                        mask |= LaudoTesteFisicoTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "LaudoTesteFisico", operation, recordId, "Changed"))
                        mask |= LaudoTesteFisicoTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "LaudoTesteFisico", operation, recordId, "UserId"))
                        mask |= LaudoTesteFisicoTrackingFields.UserId;
                    return mask;
                }

                private ulong GetLogsMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Logs", operation, recordId, "Id"))
                        mask |= LogsTrackingFields.Id;
                    if (DomainFieldTracked(policy, "Logs", operation, recordId, "LOG_CHAVE"))
                        mask |= LogsTrackingFields.LOG_CHAVE;
                    if (DomainFieldTracked(policy, "Logs", operation, recordId, "LOG_CONTEXTO"))
                        mask |= LogsTrackingFields.LOG_CONTEXTO;
                    if (DomainFieldTracked(policy, "Logs", operation, recordId, "LOG_CONTEUDO"))
                        mask |= LogsTrackingFields.LOG_CONTEUDO;
                    if (DomainFieldTracked(policy, "Logs", operation, recordId, "LOG_ID"))
                        mask |= LogsTrackingFields.LOG_ID;
                    if (DomainFieldTracked(policy, "Logs", operation, recordId, "LOG_EMISSAO"))
                        mask |= LogsTrackingFields.LOG_EMISSAO;
                    if (DomainFieldTracked(policy, "Logs", operation, recordId, "TenantID"))
                        mask |= LogsTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Logs", operation, recordId, "Deleted"))
                        mask |= LogsTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Logs", operation, recordId, "Changed"))
                        mask |= LogsTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Logs", operation, recordId, "UserId"))
                        mask |= LogsTrackingFields.UserId;
                    return mask;
                }

                private ulong GetLogsDatabaseMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "LogsDatabase", operation, recordId, "LOGS_ID"))
                        mask |= LogsDatabaseTrackingFields.LOGS_ID;
                    if (DomainFieldTracked(policy, "LogsDatabase", operation, recordId, "LOGS_TABLE"))
                        mask |= LogsDatabaseTrackingFields.LOGS_TABLE;
                    if (DomainFieldTracked(policy, "LogsDatabase", operation, recordId, "LOGS_KEY"))
                        mask |= LogsDatabaseTrackingFields.LOGS_KEY;
                    if (DomainFieldTracked(policy, "LogsDatabase", operation, recordId, "LOGS_KEY1"))
                        mask |= LogsDatabaseTrackingFields.LOGS_KEY1;
                    if (DomainFieldTracked(policy, "LogsDatabase", operation, recordId, "LOGS_KEY2"))
                        mask |= LogsDatabaseTrackingFields.LOGS_KEY2;
                    if (DomainFieldTracked(policy, "LogsDatabase", operation, recordId, "LOGS_KEY3"))
                        mask |= LogsDatabaseTrackingFields.LOGS_KEY3;
                    if (DomainFieldTracked(policy, "LogsDatabase", operation, recordId, "LOGS_KEY4"))
                        mask |= LogsDatabaseTrackingFields.LOGS_KEY4;
                    if (DomainFieldTracked(policy, "LogsDatabase", operation, recordId, "LOGS_COLUMN"))
                        mask |= LogsDatabaseTrackingFields.LOGS_COLUMN;
                    if (DomainFieldTracked(policy, "LogsDatabase", operation, recordId, "LOGS_BEFORE"))
                        mask |= LogsDatabaseTrackingFields.LOGS_BEFORE;
                    if (DomainFieldTracked(policy, "LogsDatabase", operation, recordId, "LOGS_AFTER"))
                        mask |= LogsDatabaseTrackingFields.LOGS_AFTER;
                    if (DomainFieldTracked(policy, "LogsDatabase", operation, recordId, "LOGS_ACTION"))
                        mask |= LogsDatabaseTrackingFields.LOGS_ACTION;
                    if (DomainFieldTracked(policy, "LogsDatabase", operation, recordId, "LOGS_DATE"))
                        mask |= LogsDatabaseTrackingFields.LOGS_DATE;
                    if (DomainFieldTracked(policy, "LogsDatabase", operation, recordId, "USE_ID"))
                        mask |= LogsDatabaseTrackingFields.USE_ID;
                    if (DomainFieldTracked(policy, "LogsDatabase", operation, recordId, "LOGS_ORIGEM"))
                        mask |= LogsDatabaseTrackingFields.LOGS_ORIGEM;
                    if (DomainFieldTracked(policy, "LogsDatabase", operation, recordId, "TenantID"))
                        mask |= LogsDatabaseTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "LogsDatabase", operation, recordId, "Deleted"))
                        mask |= LogsDatabaseTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "LogsDatabase", operation, recordId, "Changed"))
                        mask |= LogsDatabaseTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "LogsDatabase", operation, recordId, "UserId"))
                        mask |= LogsDatabaseTrackingFields.UserId;
                    return mask;
                }

                private ulong GetLoockMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Loock", operation, recordId, "Id"))
                        mask |= LoockTrackingFields.Id;
                    if (DomainFieldTracked(policy, "Loock", operation, recordId, "LOO_ID"))
                        mask |= LoockTrackingFields.LOO_ID;
                    if (DomainFieldTracked(policy, "Loock", operation, recordId, "LOO_DESCRICAO"))
                        mask |= LoockTrackingFields.LOO_DESCRICAO;
                    if (DomainFieldTracked(policy, "Loock", operation, recordId, "LOO_CONTEUDO"))
                        mask |= LoockTrackingFields.LOO_CONTEUDO;
                    if (DomainFieldTracked(policy, "Loock", operation, recordId, "TenantID"))
                        mask |= LoockTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Loock", operation, recordId, "Deleted"))
                        mask |= LoockTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Loock", operation, recordId, "Changed"))
                        mask |= LoockTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Loock", operation, recordId, "UserId"))
                        mask |= LoockTrackingFields.UserId;
                    return mask;
                }

                private ulong GetLoteTesteMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "LoteTeste", operation, recordId, "Id"))
                        mask |= LoteTesteTrackingFields.Id;
                    if (DomainFieldTracked(policy, "LoteTeste", operation, recordId, "LT_ID"))
                        mask |= LoteTesteTrackingFields.LT_ID;
                    if (DomainFieldTracked(policy, "LoteTeste", operation, recordId, "TES_ID"))
                        mask |= LoteTesteTrackingFields.TES_ID;
                    if (DomainFieldTracked(policy, "LoteTeste", operation, recordId, "RL_ID"))
                        mask |= LoteTesteTrackingFields.RL_ID;
                    if (DomainFieldTracked(policy, "LoteTeste", operation, recordId, "TenantID"))
                        mask |= LoteTesteTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "LoteTeste", operation, recordId, "Deleted"))
                        mask |= LoteTesteTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "LoteTeste", operation, recordId, "Changed"))
                        mask |= LoteTesteTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "LoteTeste", operation, recordId, "UserId"))
                        mask |= LoteTesteTrackingFields.UserId;
                    return mask;
                }

                private ulong GetLotesMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Lotes", operation, recordId, "Id"))
                        mask |= LotesTrackingFields.Id;
                    if (DomainFieldTracked(policy, "Lotes", operation, recordId, "MOV_LOTE"))
                        mask |= LotesTrackingFields.MOV_LOTE;
                    if (DomainFieldTracked(policy, "Lotes", operation, recordId, "MOV_SUB_LOTE"))
                        mask |= LotesTrackingFields.MOV_SUB_LOTE;
                    if (DomainFieldTracked(policy, "Lotes", operation, recordId, "LOT_LARGURA"))
                        mask |= LotesTrackingFields.LOT_LARGURA;
                    if (DomainFieldTracked(policy, "Lotes", operation, recordId, "LOT_COMPRIMENTO"))
                        mask |= LotesTrackingFields.LOT_COMPRIMENTO;
                    if (DomainFieldTracked(policy, "Lotes", operation, recordId, "LOT_DIAMETRO"))
                        mask |= LotesTrackingFields.LOT_DIAMETRO;
                    if (DomainFieldTracked(policy, "Lotes", operation, recordId, "TenantID"))
                        mask |= LotesTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Lotes", operation, recordId, "Deleted"))
                        mask |= LotesTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Lotes", operation, recordId, "Changed"))
                        mask |= LotesTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Lotes", operation, recordId, "UserId"))
                        mask |= LotesTrackingFields.UserId;
                    return mask;
                }

                private ulong GetMapaMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Mapa", operation, recordId, "Id"))
                        mask |= MapaTrackingFields.Id;
                    if (DomainFieldTracked(policy, "Mapa", operation, recordId, "MAP_ID"))
                        mask |= MapaTrackingFields.MAP_ID;
                    if (DomainFieldTracked(policy, "Mapa", operation, recordId, "PON_ID"))
                        mask |= MapaTrackingFields.PON_ID;
                    if (DomainFieldTracked(policy, "Mapa", operation, recordId, "PON_ID_VIZINHO"))
                        mask |= MapaTrackingFields.PON_ID_VIZINHO;
                    if (DomainFieldTracked(policy, "Mapa", operation, recordId, "MAP_DISTANCIA"))
                        mask |= MapaTrackingFields.MAP_DISTANCIA;
                    if (DomainFieldTracked(policy, "Mapa", operation, recordId, "MAP_CUSTO_PEDAGIO_POR_EIXO"))
                        mask |= MapaTrackingFields.MAP_CUSTO_PEDAGIO_POR_EIXO;
                    if (DomainFieldTracked(policy, "Mapa", operation, recordId, "ROD_ID"))
                        mask |= MapaTrackingFields.ROD_ID;
                    if (DomainFieldTracked(policy, "Mapa", operation, recordId, "MAP_ALTURA_ROD"))
                        mask |= MapaTrackingFields.MAP_ALTURA_ROD;
                    if (DomainFieldTracked(policy, "Mapa", operation, recordId, "TenantID"))
                        mask |= MapaTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Mapa", operation, recordId, "Deleted"))
                        mask |= MapaTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Mapa", operation, recordId, "Changed"))
                        mask |= MapaTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Mapa", operation, recordId, "UserId"))
                        mask |= MapaTrackingFields.UserId;
                    return mask;
                }

                private ulong GetMaquinaGrupoMaquinaMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "MaquinaGrupoMaquina", operation, recordId, "Id"))
                        mask |= MaquinaGrupoMaquinaTrackingFields.Id;
                    if (DomainFieldTracked(policy, "MaquinaGrupoMaquina", operation, recordId, "GMA_ID"))
                        mask |= MaquinaGrupoMaquinaTrackingFields.GMA_ID;
                    if (DomainFieldTracked(policy, "MaquinaGrupoMaquina", operation, recordId, "MAQ_ID"))
                        mask |= MaquinaGrupoMaquinaTrackingFields.MAQ_ID;
                    if (DomainFieldTracked(policy, "MaquinaGrupoMaquina", operation, recordId, "TenantID"))
                        mask |= MaquinaGrupoMaquinaTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "MaquinaGrupoMaquina", operation, recordId, "Deleted"))
                        mask |= MaquinaGrupoMaquinaTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "MaquinaGrupoMaquina", operation, recordId, "Changed"))
                        mask |= MaquinaGrupoMaquinaTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "MaquinaGrupoMaquina", operation, recordId, "UserId"))
                        mask |= MaquinaGrupoMaquinaTrackingFields.UserId;
                    return mask;
                }

                private ulong GetMaquinaImpressoraMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "MaquinaImpressora", operation, recordId, "MAQ_IMP_ID"))
                        mask |= MaquinaImpressoraTrackingFields.MAQ_IMP_ID;
                    if (DomainFieldTracked(policy, "MaquinaImpressora", operation, recordId, "MAQ_ID"))
                        mask |= MaquinaImpressoraTrackingFields.MAQ_ID;
                    if (DomainFieldTracked(policy, "MaquinaImpressora", operation, recordId, "IMP_ID"))
                        mask |= MaquinaImpressoraTrackingFields.IMP_ID;
                    if (DomainFieldTracked(policy, "MaquinaImpressora", operation, recordId, "MAI_FACAO"))
                        mask |= MaquinaImpressoraTrackingFields.MAI_FACAO;
                    if (DomainFieldTracked(policy, "MaquinaImpressora", operation, recordId, "TenantID"))
                        mask |= MaquinaImpressoraTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "MaquinaImpressora", operation, recordId, "Deleted"))
                        mask |= MaquinaImpressoraTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "MaquinaImpressora", operation, recordId, "Changed"))
                        mask |= MaquinaImpressoraTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "MaquinaImpressora", operation, recordId, "UserId"))
                        mask |= MaquinaImpressoraTrackingFields.UserId;
                    return mask;
                }

                private ulong GetT_MAQUINAS_EQUIPESMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "T_MAQUINAS_EQUIPES", operation, recordId, "Id"))
                        mask |= T_MAQUINAS_EQUIPESTrackingFields.Id;
                    if (DomainFieldTracked(policy, "T_MAQUINAS_EQUIPES", operation, recordId, "MAQ_ID"))
                        mask |= T_MAQUINAS_EQUIPESTrackingFields.MAQ_ID;
                    if (DomainFieldTracked(policy, "T_MAQUINAS_EQUIPES", operation, recordId, "EQU_ID"))
                        mask |= T_MAQUINAS_EQUIPESTrackingFields.EQU_ID;
                    if (DomainFieldTracked(policy, "T_MAQUINAS_EQUIPES", operation, recordId, "CAL_ID"))
                        mask |= T_MAQUINAS_EQUIPESTrackingFields.CAL_ID;
                    if (DomainFieldTracked(policy, "T_MAQUINAS_EQUIPES", operation, recordId, "CLI_ID"))
                        mask |= T_MAQUINAS_EQUIPESTrackingFields.CLI_ID;
                    if (DomainFieldTracked(policy, "T_MAQUINAS_EQUIPES", operation, recordId, "TenantID"))
                        mask |= T_MAQUINAS_EQUIPESTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "T_MAQUINAS_EQUIPES", operation, recordId, "Deleted"))
                        mask |= T_MAQUINAS_EQUIPESTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "T_MAQUINAS_EQUIPES", operation, recordId, "Changed"))
                        mask |= T_MAQUINAS_EQUIPESTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "T_MAQUINAS_EQUIPES", operation, recordId, "UserId"))
                        mask |= T_MAQUINAS_EQUIPESTrackingFields.UserId;
                    return mask;
                }

                private ulong GetT_MedicoesMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "T_Medicoes", operation, recordId, "Id"))
                        mask |= T_MedicoesTrackingFields.Id;
                    if (DomainFieldTracked(policy, "T_Medicoes", operation, recordId, "MED_ID"))
                        mask |= T_MedicoesTrackingFields.MED_ID;
                    if (DomainFieldTracked(policy, "T_Medicoes", operation, recordId, "IND_ID"))
                        mask |= T_MedicoesTrackingFields.IND_ID;
                    if (DomainFieldTracked(policy, "T_Medicoes", operation, recordId, "MET_ID"))
                        mask |= T_MedicoesTrackingFields.MET_ID;
                    if (DomainFieldTracked(policy, "T_Medicoes", operation, recordId, "UNI_ID"))
                        mask |= T_MedicoesTrackingFields.UNI_ID;
                    if (DomainFieldTracked(policy, "T_Medicoes", operation, recordId, "MED_DATA"))
                        mask |= T_MedicoesTrackingFields.MED_DATA;
                    if (DomainFieldTracked(policy, "T_Medicoes", operation, recordId, "MED_VALOR"))
                        mask |= T_MedicoesTrackingFields.MED_VALOR;
                    if (DomainFieldTracked(policy, "T_Medicoes", operation, recordId, "MED_AC_ANO"))
                        mask |= T_MedicoesTrackingFields.MED_AC_ANO;
                    if (DomainFieldTracked(policy, "T_Medicoes", operation, recordId, "MED_DATAMEDICAO"))
                        mask |= T_MedicoesTrackingFields.MED_DATAMEDICAO;
                    if (DomainFieldTracked(policy, "T_Medicoes", operation, recordId, "MED_PONDERACAO"))
                        mask |= T_MedicoesTrackingFields.MED_PONDERACAO;
                    if (DomainFieldTracked(policy, "T_Medicoes", operation, recordId, "DIM_ID"))
                        mask |= T_MedicoesTrackingFields.DIM_ID;
                    if (DomainFieldTracked(policy, "T_Medicoes", operation, recordId, "DIM_DESCRICAO"))
                        mask |= T_MedicoesTrackingFields.DIM_DESCRICAO;
                    if (DomainFieldTracked(policy, "T_Medicoes", operation, recordId, "DIM_SUBDIMENSAO_ID"))
                        mask |= T_MedicoesTrackingFields.DIM_SUBDIMENSAO_ID;
                    if (DomainFieldTracked(policy, "T_Medicoes", operation, recordId, "DIM_SUB_DESCRICAO"))
                        mask |= T_MedicoesTrackingFields.DIM_SUB_DESCRICAO;
                    if (DomainFieldTracked(policy, "T_Medicoes", operation, recordId, "PER_ID"))
                        mask |= T_MedicoesTrackingFields.PER_ID;
                    if (DomainFieldTracked(policy, "T_Medicoes", operation, recordId, "PER_DESCRICAO"))
                        mask |= T_MedicoesTrackingFields.PER_DESCRICAO;
                    if (DomainFieldTracked(policy, "T_Medicoes", operation, recordId, "FAT_ID"))
                        mask |= T_MedicoesTrackingFields.FAT_ID;
                    if (DomainFieldTracked(policy, "T_Medicoes", operation, recordId, "FAT_DESCRICAO"))
                        mask |= T_MedicoesTrackingFields.FAT_DESCRICAO;
                    if (DomainFieldTracked(policy, "T_Medicoes", operation, recordId, "MED_SQL"))
                        mask |= T_MedicoesTrackingFields.MED_SQL;
                    if (DomainFieldTracked(policy, "T_Medicoes", operation, recordId, "DOM_EMPRESA"))
                        mask |= T_MedicoesTrackingFields.DOM_EMPRESA;
                    if (DomainFieldTracked(policy, "T_Medicoes", operation, recordId, "DOM_FILIAL"))
                        mask |= T_MedicoesTrackingFields.DOM_FILIAL;
                    if (DomainFieldTracked(policy, "T_Medicoes", operation, recordId, "MED_VALOR_DISPER"))
                        mask |= T_MedicoesTrackingFields.MED_VALOR_DISPER;
                    if (DomainFieldTracked(policy, "T_Medicoes", operation, recordId, "TenantID"))
                        mask |= T_MedicoesTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "T_Medicoes", operation, recordId, "Deleted"))
                        mask |= T_MedicoesTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "T_Medicoes", operation, recordId, "Changed"))
                        mask |= T_MedicoesTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "T_Medicoes", operation, recordId, "UserId"))
                        mask |= T_MedicoesTrackingFields.UserId;
                    return mask;
                }

                private ulong GetMedicoesOnduladeiraMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "MedicoesOnduladeira", operation, recordId, "Id"))
                        mask |= MedicoesOnduladeiraTrackingFields.Id;
                    if (DomainFieldTracked(policy, "MedicoesOnduladeira", operation, recordId, "TenantID"))
                        mask |= MedicoesOnduladeiraTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "MedicoesOnduladeira", operation, recordId, "Deleted"))
                        mask |= MedicoesOnduladeiraTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "MedicoesOnduladeira", operation, recordId, "Changed"))
                        mask |= MedicoesOnduladeiraTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "MedicoesOnduladeira", operation, recordId, "UserId"))
                        mask |= MedicoesOnduladeiraTrackingFields.UserId;
                    return mask;
                }

                private ulong GetMedidasTesteMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "MedidasTeste", operation, recordId, "Id"))
                        mask |= MedidasTesteTrackingFields.Id;
                    if (DomainFieldTracked(policy, "MedidasTeste", operation, recordId, "MDT_ID"))
                        mask |= MedidasTesteTrackingFields.MDT_ID;
                    if (DomainFieldTracked(policy, "MedidasTeste", operation, recordId, "MDT_DESC"))
                        mask |= MedidasTesteTrackingFields.MDT_DESC;
                    if (DomainFieldTracked(policy, "MedidasTeste", operation, recordId, "MDT_VALOR_ESPERADO"))
                        mask |= MedidasTesteTrackingFields.MDT_VALOR_ESPERADO;
                    if (DomainFieldTracked(policy, "MedidasTeste", operation, recordId, "MDT_ENCONTRADO"))
                        mask |= MedidasTesteTrackingFields.MDT_ENCONTRADO;
                    if (DomainFieldTracked(policy, "MedidasTeste", operation, recordId, "UNI_ID"))
                        mask |= MedidasTesteTrackingFields.UNI_ID;
                    if (DomainFieldTracked(policy, "MedidasTeste", operation, recordId, "TenantID"))
                        mask |= MedidasTesteTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "MedidasTeste", operation, recordId, "Deleted"))
                        mask |= MedidasTesteTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "MedidasTeste", operation, recordId, "Changed"))
                        mask |= MedidasTesteTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "MedidasTeste", operation, recordId, "UserId"))
                        mask |= MedidasTesteTrackingFields.UserId;
                    return mask;
                }

                private ulong GetMemoriaDeCalculoMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "MemoriaDeCalculo", operation, recordId, "Id"))
                        mask |= MemoriaDeCalculoTrackingFields.Id;
                    if (DomainFieldTracked(policy, "MemoriaDeCalculo", operation, recordId, "MEM_ID"))
                        mask |= MemoriaDeCalculoTrackingFields.MEM_ID;
                    if (DomainFieldTracked(policy, "MemoriaDeCalculo", operation, recordId, "ORC_ID"))
                        mask |= MemoriaDeCalculoTrackingFields.ORC_ID;
                    if (DomainFieldTracked(policy, "MemoriaDeCalculo", operation, recordId, "MEM_VALOR"))
                        mask |= MemoriaDeCalculoTrackingFields.MEM_VALOR;
                    if (DomainFieldTracked(policy, "MemoriaDeCalculo", operation, recordId, "MEM_DESCRICAO"))
                        mask |= MemoriaDeCalculoTrackingFields.MEM_DESCRICAO;
                    if (DomainFieldTracked(policy, "MemoriaDeCalculo", operation, recordId, "TenantID"))
                        mask |= MemoriaDeCalculoTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "MemoriaDeCalculo", operation, recordId, "Deleted"))
                        mask |= MemoriaDeCalculoTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "MemoriaDeCalculo", operation, recordId, "Changed"))
                        mask |= MemoriaDeCalculoTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "MemoriaDeCalculo", operation, recordId, "UserId"))
                        mask |= MemoriaDeCalculoTrackingFields.UserId;
                    return mask;
                }

                private ulong GetMensagemMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Mensagem", operation, recordId, "MEN_ID"))
                        mask |= MensagemTrackingFields.MEN_ID;
                    if (DomainFieldTracked(policy, "Mensagem", operation, recordId, "MEN_SEND"))
                        mask |= MensagemTrackingFields.MEN_SEND;
                    if (DomainFieldTracked(policy, "Mensagem", operation, recordId, "MEN_EMISSION"))
                        mask |= MensagemTrackingFields.MEN_EMISSION;
                    if (DomainFieldTracked(policy, "Mensagem", operation, recordId, "MEN_STATUS"))
                        mask |= MensagemTrackingFields.MEN_STATUS;
                    if (DomainFieldTracked(policy, "Mensagem", operation, recordId, "MEN_RECEIVE"))
                        mask |= MensagemTrackingFields.MEN_RECEIVE;
                    if (DomainFieldTracked(policy, "Mensagem", operation, recordId, "MEN_TYPE"))
                        mask |= MensagemTrackingFields.MEN_TYPE;
                    if (DomainFieldTracked(policy, "Mensagem", operation, recordId, "MEN_QTD_TRY_SEND"))
                        mask |= MensagemTrackingFields.MEN_QTD_TRY_SEND;
                    if (DomainFieldTracked(policy, "Mensagem", operation, recordId, "MEN_DATE_TRY_SEND"))
                        mask |= MensagemTrackingFields.MEN_DATE_TRY_SEND;
                    if (DomainFieldTracked(policy, "Mensagem", operation, recordId, "TenantID"))
                        mask |= MensagemTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Mensagem", operation, recordId, "Deleted"))
                        mask |= MensagemTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Mensagem", operation, recordId, "Changed"))
                        mask |= MensagemTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Mensagem", operation, recordId, "UserId"))
                        mask |= MensagemTrackingFields.UserId;
                    return mask;
                }

                private ulong GetMesesMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Meses", operation, recordId, "MES"))
                        mask |= MesesTrackingFields.MES;
                    if (DomainFieldTracked(policy, "Meses", operation, recordId, "fator"))
                        mask |= MesesTrackingFields.fator;
                    if (DomainFieldTracked(policy, "Meses", operation, recordId, "TenantID"))
                        mask |= MesesTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Meses", operation, recordId, "Deleted"))
                        mask |= MesesTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Meses", operation, recordId, "Changed"))
                        mask |= MesesTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Meses", operation, recordId, "UserId"))
                        mask |= MesesTrackingFields.UserId;
                    return mask;
                }

                private ulong GetT_MetasMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "T_Metas", operation, recordId, "MET_ID"))
                        mask |= T_MetasTrackingFields.MET_ID;
                    if (DomainFieldTracked(policy, "T_Metas", operation, recordId, "MET_DTINICIO"))
                        mask |= T_MetasTrackingFields.MET_DTINICIO;
                    if (DomainFieldTracked(policy, "T_Metas", operation, recordId, "MET_DTFIM"))
                        mask |= T_MetasTrackingFields.MET_DTFIM;
                    if (DomainFieldTracked(policy, "T_Metas", operation, recordId, "MET_ALVO"))
                        mask |= T_MetasTrackingFields.MET_ALVO;
                    if (DomainFieldTracked(policy, "T_Metas", operation, recordId, "MET_TIPOALVO"))
                        mask |= T_MetasTrackingFields.MET_TIPOALVO;
                    if (DomainFieldTracked(policy, "T_Metas", operation, recordId, "IND_ID"))
                        mask |= T_MetasTrackingFields.IND_ID;
                    if (DomainFieldTracked(policy, "T_Metas", operation, recordId, "MET_RANGE01"))
                        mask |= T_MetasTrackingFields.MET_RANGE01;
                    if (DomainFieldTracked(policy, "T_Metas", operation, recordId, "MET_RANGE02"))
                        mask |= T_MetasTrackingFields.MET_RANGE02;
                    if (DomainFieldTracked(policy, "T_Metas", operation, recordId, "MET_RANGE03"))
                        mask |= T_MetasTrackingFields.MET_RANGE03;
                    if (DomainFieldTracked(policy, "T_Metas", operation, recordId, "DIM_ID"))
                        mask |= T_MetasTrackingFields.DIM_ID;
                    if (DomainFieldTracked(policy, "T_Metas", operation, recordId, "FAT_ID"))
                        mask |= T_MetasTrackingFields.FAT_ID;
                    if (DomainFieldTracked(policy, "T_Metas", operation, recordId, "DIM_SUBDIMENSAO_ID"))
                        mask |= T_MetasTrackingFields.DIM_SUBDIMENSAO_ID;
                    if (DomainFieldTracked(policy, "T_Metas", operation, recordId, "PER_ID"))
                        mask |= T_MetasTrackingFields.PER_ID;
                    if (DomainFieldTracked(policy, "T_Metas", operation, recordId, "DOM_EMPRESA"))
                        mask |= T_MetasTrackingFields.DOM_EMPRESA;
                    if (DomainFieldTracked(policy, "T_Metas", operation, recordId, "DOM_FILIAL"))
                        mask |= T_MetasTrackingFields.DOM_FILIAL;
                    if (DomainFieldTracked(policy, "T_Metas", operation, recordId, "TenantID"))
                        mask |= T_MetasTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "T_Metas", operation, recordId, "Deleted"))
                        mask |= T_MetasTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "T_Metas", operation, recordId, "Changed"))
                        mask |= T_MetasTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "T_Metas", operation, recordId, "UserId"))
                        mask |= T_MetasTrackingFields.UserId;
                    return mask;
                }

                private ulong GetMovimentoEstoqueMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "MovimentoEstoque", operation, recordId, "Id"))
                        mask |= MovimentoEstoqueTrackingFields.Id;
                    if (DomainFieldTracked(policy, "MovimentoEstoque", operation, recordId, "ProdutoId"))
                        mask |= MovimentoEstoqueTrackingFields.ProdutoId;
                    if (DomainFieldTracked(policy, "MovimentoEstoque", operation, recordId, "OrderId"))
                        mask |= MovimentoEstoqueTrackingFields.OrderId;
                    if (DomainFieldTracked(policy, "MovimentoEstoque", operation, recordId, "Tipo"))
                        mask |= MovimentoEstoqueTrackingFields.Tipo;
                    if (DomainFieldTracked(policy, "MovimentoEstoque", operation, recordId, "TurnoId"))
                        mask |= MovimentoEstoqueTrackingFields.TurnoId;
                    if (DomainFieldTracked(policy, "MovimentoEstoque", operation, recordId, "TurmaId"))
                        mask |= MovimentoEstoqueTrackingFields.TurmaId;
                    if (DomainFieldTracked(policy, "MovimentoEstoque", operation, recordId, "Quantidade"))
                        mask |= MovimentoEstoqueTrackingFields.Quantidade;
                    if (DomainFieldTracked(policy, "MovimentoEstoque", operation, recordId, "MOV_PESO_UNITARIO"))
                        mask |= MovimentoEstoqueTrackingFields.MOV_PESO_UNITARIO;
                    if (DomainFieldTracked(policy, "MovimentoEstoque", operation, recordId, "DataHoraCriacao"))
                        mask |= MovimentoEstoqueTrackingFields.DataHoraCriacao;
                    if (DomainFieldTracked(policy, "MovimentoEstoque", operation, recordId, "DataHoraEmissao"))
                        mask |= MovimentoEstoqueTrackingFields.DataHoraEmissao;
                    if (DomainFieldTracked(policy, "MovimentoEstoque", operation, recordId, "DiaTurma"))
                        mask |= MovimentoEstoqueTrackingFields.DiaTurma;
                    if (DomainFieldTracked(policy, "MovimentoEstoque", operation, recordId, "Lote"))
                        mask |= MovimentoEstoqueTrackingFields.Lote;
                    if (DomainFieldTracked(policy, "MovimentoEstoque", operation, recordId, "SubLote"))
                        mask |= MovimentoEstoqueTrackingFields.SubLote;
                    if (DomainFieldTracked(policy, "MovimentoEstoque", operation, recordId, "MaquinaId"))
                        mask |= MovimentoEstoqueTrackingFields.MaquinaId;
                    if (DomainFieldTracked(policy, "MovimentoEstoque", operation, recordId, "USE_ID"))
                        mask |= MovimentoEstoqueTrackingFields.USE_ID;
                    if (DomainFieldTracked(policy, "MovimentoEstoque", operation, recordId, "Observacao"))
                        mask |= MovimentoEstoqueTrackingFields.Observacao;
                    if (DomainFieldTracked(policy, "MovimentoEstoque", operation, recordId, "OcorrenciaId"))
                        mask |= MovimentoEstoqueTrackingFields.OcorrenciaId;
                    if (DomainFieldTracked(policy, "MovimentoEstoque", operation, recordId, "Armazem"))
                        mask |= MovimentoEstoqueTrackingFields.Armazem;
                    if (DomainFieldTracked(policy, "MovimentoEstoque", operation, recordId, "Endereco"))
                        mask |= MovimentoEstoqueTrackingFields.Endereco;
                    if (DomainFieldTracked(policy, "MovimentoEstoque", operation, recordId, "Estorno"))
                        mask |= MovimentoEstoqueTrackingFields.Estorno;
                    if (DomainFieldTracked(policy, "MovimentoEstoque", operation, recordId, "SequenciaTransformacao"))
                        mask |= MovimentoEstoqueTrackingFields.SequenciaTransformacao;
                    if (DomainFieldTracked(policy, "MovimentoEstoque", operation, recordId, "SequenciaRepeticao"))
                        mask |= MovimentoEstoqueTrackingFields.SequenciaRepeticao;
                    if (DomainFieldTracked(policy, "MovimentoEstoque", operation, recordId, "ObsOpParcial"))
                        mask |= MovimentoEstoqueTrackingFields.ObsOpParcial;
                    if (DomainFieldTracked(policy, "MovimentoEstoque", operation, recordId, "OcoIdOpParcial"))
                        mask |= MovimentoEstoqueTrackingFields.OcoIdOpParcial;
                    if (DomainFieldTracked(policy, "MovimentoEstoque", operation, recordId, "MOV_ID_INTEGRACAO"))
                        mask |= MovimentoEstoqueTrackingFields.MOV_ID_INTEGRACAO;
                    if (DomainFieldTracked(policy, "MovimentoEstoque", operation, recordId, "MOV_ID_INTEGRACAO_ERP"))
                        mask |= MovimentoEstoqueTrackingFields.MOV_ID_INTEGRACAO_ERP;
                    if (DomainFieldTracked(policy, "MovimentoEstoque", operation, recordId, "CAR_ID"))
                        mask |= MovimentoEstoqueTrackingFields.CAR_ID;
                    if (DomainFieldTracked(policy, "MovimentoEstoque", operation, recordId, "MOV_ID_DESTINO"))
                        mask |= MovimentoEstoqueTrackingFields.MOV_ID_DESTINO;
                    if (DomainFieldTracked(policy, "MovimentoEstoque", operation, recordId, "PRO_ID_DESTINO"))
                        mask |= MovimentoEstoqueTrackingFields.PRO_ID_DESTINO;
                    if (DomainFieldTracked(policy, "MovimentoEstoque", operation, recordId, "MOV_LOTE_DESTINO"))
                        mask |= MovimentoEstoqueTrackingFields.MOV_LOTE_DESTINO;
                    if (DomainFieldTracked(policy, "MovimentoEstoque", operation, recordId, "MOV_SUB_LOTE_DESTINO"))
                        mask |= MovimentoEstoqueTrackingFields.MOV_SUB_LOTE_DESTINO;
                    if (DomainFieldTracked(policy, "MovimentoEstoque", operation, recordId, "MOV_ID_ORIGEM"))
                        mask |= MovimentoEstoqueTrackingFields.MOV_ID_ORIGEM;
                    if (DomainFieldTracked(policy, "MovimentoEstoque", operation, recordId, "PRO_ID_ORIGEM"))
                        mask |= MovimentoEstoqueTrackingFields.PRO_ID_ORIGEM;
                    if (DomainFieldTracked(policy, "MovimentoEstoque", operation, recordId, "MOV_LOTE_ORIGEM"))
                        mask |= MovimentoEstoqueTrackingFields.MOV_LOTE_ORIGEM;
                    if (DomainFieldTracked(policy, "MovimentoEstoque", operation, recordId, "MOV_SUB_LOTE_ORIGEM"))
                        mask |= MovimentoEstoqueTrackingFields.MOV_SUB_LOTE_ORIGEM;
                    if (DomainFieldTracked(policy, "MovimentoEstoque", operation, recordId, "MOV_TYPE"))
                        mask |= MovimentoEstoqueTrackingFields.MOV_TYPE;
                    if (DomainFieldTracked(policy, "MovimentoEstoque", operation, recordId, "MOV_DOC"))
                        mask |= MovimentoEstoqueTrackingFields.MOV_DOC;
                    if (DomainFieldTracked(policy, "MovimentoEstoque", operation, recordId, "MOV_APROVEITAMENTO"))
                        mask |= MovimentoEstoqueTrackingFields.MOV_APROVEITAMENTO;
                    if (DomainFieldTracked(policy, "MovimentoEstoque", operation, recordId, "MOV_RETIDO"))
                        mask |= MovimentoEstoqueTrackingFields.MOV_RETIDO;
                    if (DomainFieldTracked(policy, "MovimentoEstoque", operation, recordId, "MOV_VINCOS_ONDULADEIRA"))
                        mask |= MovimentoEstoqueTrackingFields.MOV_VINCOS_ONDULADEIRA;
                    if (DomainFieldTracked(policy, "MovimentoEstoque", operation, recordId, "BOL_ID"))
                        mask |= MovimentoEstoqueTrackingFields.BOL_ID;
                    if (DomainFieldTracked(policy, "MovimentoEstoque", operation, recordId, "ORD_ID_ORIGEM"))
                        mask |= MovimentoEstoqueTrackingFields.ORD_ID_ORIGEM;
                    if (DomainFieldTracked(policy, "MovimentoEstoque", operation, recordId, "COR_SEQUENCIA"))
                        mask |= MovimentoEstoqueTrackingFields.COR_SEQUENCIA;
                    if (DomainFieldTracked(policy, "MovimentoEstoque", operation, recordId, "VER_ID"))
                        mask |= MovimentoEstoqueTrackingFields.VER_ID;
                    if (DomainFieldTracked(policy, "MovimentoEstoque", operation, recordId, "MOV_TIPO_CUSTO"))
                        mask |= MovimentoEstoqueTrackingFields.MOV_TIPO_CUSTO;
                    if (DomainFieldTracked(policy, "MovimentoEstoque", operation, recordId, "MOV_GRUPO_CONTABIL"))
                        mask |= MovimentoEstoqueTrackingFields.MOV_GRUPO_CONTABIL;
                    if (DomainFieldTracked(policy, "MovimentoEstoque", operation, recordId, "FOR_ID"))
                        mask |= MovimentoEstoqueTrackingFields.FOR_ID;
                    if (DomainFieldTracked(policy, "MovimentoEstoque", operation, recordId, "CLI_ID"))
                        mask |= MovimentoEstoqueTrackingFields.CLI_ID;
                    if (DomainFieldTracked(policy, "MovimentoEstoque", operation, recordId, "TenantID"))
                        mask |= MovimentoEstoqueTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "MovimentoEstoque", operation, recordId, "Deleted"))
                        mask |= MovimentoEstoqueTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "MovimentoEstoque", operation, recordId, "Changed"))
                        mask |= MovimentoEstoqueTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "MovimentoEstoque", operation, recordId, "UserId"))
                        mask |= MovimentoEstoqueTrackingFields.UserId;
                    return mask;
                }

                private ulong GetMunicipioMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Municipio", operation, recordId, "MUN_ID"))
                        mask |= MunicipioTrackingFields.MUN_ID;
                    if (DomainFieldTracked(policy, "Municipio", operation, recordId, "MUN_NOME"))
                        mask |= MunicipioTrackingFields.MUN_NOME;
                    if (DomainFieldTracked(policy, "Municipio", operation, recordId, "UF_COD"))
                        mask |= MunicipioTrackingFields.UF_COD;
                    if (DomainFieldTracked(policy, "Municipio", operation, recordId, "MUN_CODIGO_IBGE"))
                        mask |= MunicipioTrackingFields.MUN_CODIGO_IBGE;
                    if (DomainFieldTracked(policy, "Municipio", operation, recordId, "MUN_LATITUDE"))
                        mask |= MunicipioTrackingFields.MUN_LATITUDE;
                    if (DomainFieldTracked(policy, "Municipio", operation, recordId, "MUN_LONGITUDE"))
                        mask |= MunicipioTrackingFields.MUN_LONGITUDE;
                    if (DomainFieldTracked(policy, "Municipio", operation, recordId, "MUN_ID_INTEGRACAO_ERP"))
                        mask |= MunicipioTrackingFields.MUN_ID_INTEGRACAO_ERP;
                    if (DomainFieldTracked(policy, "Municipio", operation, recordId, "MUN_CODIGO_SIAFI"))
                        mask |= MunicipioTrackingFields.MUN_CODIGO_SIAFI;
                    if (DomainFieldTracked(policy, "Municipio", operation, recordId, "MUN_CODIGO_CNPJ"))
                        mask |= MunicipioTrackingFields.MUN_CODIGO_CNPJ;
                    if (DomainFieldTracked(policy, "Municipio", operation, recordId, "MUN_DISTANCIA_KM"))
                        mask |= MunicipioTrackingFields.MUN_DISTANCIA_KM;
                    if (DomainFieldTracked(policy, "Municipio", operation, recordId, "TenantID"))
                        mask |= MunicipioTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Municipio", operation, recordId, "Deleted"))
                        mask |= MunicipioTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Municipio", operation, recordId, "Changed"))
                        mask |= MunicipioTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Municipio", operation, recordId, "UserId"))
                        mask |= MunicipioTrackingFields.UserId;
                    return mask;
                }

                private ulong GetT_NegocioMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "T_Negocio", operation, recordId, "NEG_ID"))
                        mask |= T_NegocioTrackingFields.NEG_ID;
                    if (DomainFieldTracked(policy, "T_Negocio", operation, recordId, "NEG_DESCRICAO"))
                        mask |= T_NegocioTrackingFields.NEG_DESCRICAO;
                    if (DomainFieldTracked(policy, "T_Negocio", operation, recordId, "TenantID"))
                        mask |= T_NegocioTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "T_Negocio", operation, recordId, "Deleted"))
                        mask |= T_NegocioTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "T_Negocio", operation, recordId, "Changed"))
                        mask |= T_NegocioTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "T_Negocio", operation, recordId, "UserId"))
                        mask |= T_NegocioTrackingFields.UserId;
                    return mask;
                }

                private ulong GetObjetoControlavelMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "ObjetoControlavel", operation, recordId, "Id"))
                        mask |= ObjetoControlavelTrackingFields.Id;
                    if (DomainFieldTracked(policy, "ObjetoControlavel", operation, recordId, "OBJ_ID"))
                        mask |= ObjetoControlavelTrackingFields.OBJ_ID;
                    if (DomainFieldTracked(policy, "ObjetoControlavel", operation, recordId, "OBJ_DESCRICAO"))
                        mask |= ObjetoControlavelTrackingFields.OBJ_DESCRICAO;
                    if (DomainFieldTracked(policy, "ObjetoControlavel", operation, recordId, "OBJ_TIPO"))
                        mask |= ObjetoControlavelTrackingFields.OBJ_TIPO;
                    if (DomainFieldTracked(policy, "ObjetoControlavel", operation, recordId, "OBJ_GRUPO"))
                        mask |= ObjetoControlavelTrackingFields.OBJ_GRUPO;
                    if (DomainFieldTracked(policy, "ObjetoControlavel", operation, recordId, "TenantID"))
                        mask |= ObjetoControlavelTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "ObjetoControlavel", operation, recordId, "Deleted"))
                        mask |= ObjetoControlavelTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "ObjetoControlavel", operation, recordId, "Changed"))
                        mask |= ObjetoControlavelTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "ObjetoControlavel", operation, recordId, "UserId"))
                        mask |= ObjetoControlavelTrackingFields.UserId;
                    return mask;
                }

                private ulong GetObservacoesMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Observacoes", operation, recordId, "OBS_ID"))
                        mask |= ObservacoesTrackingFields.OBS_ID;
                    if (DomainFieldTracked(policy, "Observacoes", operation, recordId, "OBS_TIPO"))
                        mask |= ObservacoesTrackingFields.OBS_TIPO;
                    if (DomainFieldTracked(policy, "Observacoes", operation, recordId, "OBS_DESCRICAO"))
                        mask |= ObservacoesTrackingFields.OBS_DESCRICAO;
                    if (DomainFieldTracked(policy, "Observacoes", operation, recordId, "CLI_ID"))
                        mask |= ObservacoesTrackingFields.CLI_ID;
                    if (DomainFieldTracked(policy, "Observacoes", operation, recordId, "MAQ_ID"))
                        mask |= ObservacoesTrackingFields.MAQ_ID;
                    if (DomainFieldTracked(policy, "Observacoes", operation, recordId, "PRO_ID"))
                        mask |= ObservacoesTrackingFields.PRO_ID;
                    if (DomainFieldTracked(policy, "Observacoes", operation, recordId, "ROT_SEQ_TRANFORMACAO"))
                        mask |= ObservacoesTrackingFields.ROT_SEQ_TRANFORMACAO;
                    if (DomainFieldTracked(policy, "Observacoes", operation, recordId, "OBS_INTEGRACAO"))
                        mask |= ObservacoesTrackingFields.OBS_INTEGRACAO;
                    if (DomainFieldTracked(policy, "Observacoes", operation, recordId, "TenantID"))
                        mask |= ObservacoesTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Observacoes", operation, recordId, "Deleted"))
                        mask |= ObservacoesTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Observacoes", operation, recordId, "Changed"))
                        mask |= ObservacoesTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Observacoes", operation, recordId, "UserId"))
                        mask |= ObservacoesTrackingFields.UserId;
                    return mask;
                }

                private ulong GetOcorrenciaMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Ocorrencia", operation, recordId, "OCO_ID"))
                        mask |= OcorrenciaTrackingFields.OCO_ID;
                    if (DomainFieldTracked(policy, "Ocorrencia", operation, recordId, "OCO_DESCRICAO"))
                        mask |= OcorrenciaTrackingFields.OCO_DESCRICAO;
                    if (DomainFieldTracked(policy, "Ocorrencia", operation, recordId, "TIP_ID"))
                        mask |= OcorrenciaTrackingFields.TIP_ID;
                    if (DomainFieldTracked(policy, "Ocorrencia", operation, recordId, "GMA_ID"))
                        mask |= OcorrenciaTrackingFields.GMA_ID;
                    if (DomainFieldTracked(policy, "Ocorrencia", operation, recordId, "MAQ_ID"))
                        mask |= OcorrenciaTrackingFields.MAQ_ID;
                    if (DomainFieldTracked(policy, "Ocorrencia", operation, recordId, "SPR"))
                        mask |= OcorrenciaTrackingFields.SPR;
                    if (DomainFieldTracked(policy, "Ocorrencia", operation, recordId, "OCO_SUB_TIPO"))
                        mask |= OcorrenciaTrackingFields.OCO_SUB_TIPO;
                    if (DomainFieldTracked(policy, "Ocorrencia", operation, recordId, "SUB_ID"))
                        mask |= OcorrenciaTrackingFields.SUB_ID;
                    if (DomainFieldTracked(policy, "Ocorrencia", operation, recordId, "TenantID"))
                        mask |= OcorrenciaTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Ocorrencia", operation, recordId, "Deleted"))
                        mask |= OcorrenciaTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Ocorrencia", operation, recordId, "Changed"))
                        mask |= OcorrenciaTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Ocorrencia", operation, recordId, "UserId"))
                        mask |= OcorrenciaTrackingFields.UserId;
                    return mask;
                }

                private ulong GetOndaMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Onda", operation, recordId, "OND_ID"))
                        mask |= OndaTrackingFields.OND_ID;
                    if (DomainFieldTracked(policy, "Onda", operation, recordId, "OND_ESPESSURA"))
                        mask |= OndaTrackingFields.OND_ESPESSURA;
                    if (DomainFieldTracked(policy, "Onda", operation, recordId, "OND_PESO_COLA"))
                        mask |= OndaTrackingFields.OND_PESO_COLA;
                    if (DomainFieldTracked(policy, "Onda", operation, recordId, "OND_RENDIMENTO_ONDA_1"))
                        mask |= OndaTrackingFields.OND_RENDIMENTO_ONDA_1;
                    if (DomainFieldTracked(policy, "Onda", operation, recordId, "OND_RENDIMENTO_ONDA_2"))
                        mask |= OndaTrackingFields.OND_RENDIMENTO_ONDA_2;
                    if (DomainFieldTracked(policy, "Onda", operation, recordId, "OND_PROFUNDIDADE_VINCO"))
                        mask |= OndaTrackingFields.OND_PROFUNDIDADE_VINCO;
                    if (DomainFieldTracked(policy, "Onda", operation, recordId, "OND_ID_INTEGRACAO"))
                        mask |= OndaTrackingFields.OND_ID_INTEGRACAO;
                    if (DomainFieldTracked(policy, "Onda", operation, recordId, "VIN_ID"))
                        mask |= OndaTrackingFields.VIN_ID;
                    if (DomainFieldTracked(policy, "Onda", operation, recordId, "TenantID"))
                        mask |= OndaTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Onda", operation, recordId, "Deleted"))
                        mask |= OndaTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Onda", operation, recordId, "Changed"))
                        mask |= OndaTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Onda", operation, recordId, "UserId"))
                        mask |= OndaTrackingFields.UserId;
                    return mask;
                }

                private ulong GetOperacoesMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Operacoes", operation, recordId, "Id"))
                        mask |= OperacoesTrackingFields.Id;
                    if (DomainFieldTracked(policy, "Operacoes", operation, recordId, "OPE_TIPO_REGISTRO"))
                        mask |= OperacoesTrackingFields.OPE_TIPO_REGISTRO;
                    if (DomainFieldTracked(policy, "Operacoes", operation, recordId, "OPE_ID"))
                        mask |= OperacoesTrackingFields.OPE_ID;
                    if (DomainFieldTracked(policy, "Operacoes", operation, recordId, "GMA_ID"))
                        mask |= OperacoesTrackingFields.GMA_ID;
                    if (DomainFieldTracked(policy, "Operacoes", operation, recordId, "MAQ_ID"))
                        mask |= OperacoesTrackingFields.MAQ_ID;
                    if (DomainFieldTracked(policy, "Operacoes", operation, recordId, "PRO_ID"))
                        mask |= OperacoesTrackingFields.PRO_ID;
                    if (DomainFieldTracked(policy, "Operacoes", operation, recordId, "OPE_EXCECAO"))
                        mask |= OperacoesTrackingFields.OPE_EXCECAO;
                    if (DomainFieldTracked(policy, "Operacoes", operation, recordId, "ROT_SEQ_TRANFORMACAO"))
                        mask |= OperacoesTrackingFields.ROT_SEQ_TRANFORMACAO;
                    if (DomainFieldTracked(policy, "Operacoes", operation, recordId, "ORD_ID"))
                        mask |= OperacoesTrackingFields.ORD_ID;
                    if (DomainFieldTracked(policy, "Operacoes", operation, recordId, "FPR_SEQ_REPETICAO"))
                        mask |= OperacoesTrackingFields.FPR_SEQ_REPETICAO;
                    if (DomainFieldTracked(policy, "Operacoes", operation, recordId, "TenantID"))
                        mask |= OperacoesTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Operacoes", operation, recordId, "Deleted"))
                        mask |= OperacoesTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Operacoes", operation, recordId, "Changed"))
                        mask |= OperacoesTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Operacoes", operation, recordId, "UserId"))
                        mask |= OperacoesTrackingFields.UserId;
                    return mask;
                }

                private ulong GetOptAlteracaoDimencoesMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "OptAlteracaoDimencoes", operation, recordId, "Id"))
                        mask |= OptAlteracaoDimencoesTrackingFields.Id;
                    if (DomainFieldTracked(policy, "OptAlteracaoDimencoes", operation, recordId, "OAD_ID"))
                        mask |= OptAlteracaoDimencoesTrackingFields.OAD_ID;
                    if (DomainFieldTracked(policy, "OptAlteracaoDimencoes", operation, recordId, "TenantID"))
                        mask |= OptAlteracaoDimencoesTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "OptAlteracaoDimencoes", operation, recordId, "Deleted"))
                        mask |= OptAlteracaoDimencoesTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "OptAlteracaoDimencoes", operation, recordId, "Changed"))
                        mask |= OptAlteracaoDimencoesTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "OptAlteracaoDimencoes", operation, recordId, "UserId"))
                        mask |= OptAlteracaoDimencoesTrackingFields.UserId;
                    return mask;
                }

                private ulong GetOrcamentoMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Orcamento", operation, recordId, "Id"))
                        mask |= OrcamentoTrackingFields.Id;
                    if (DomainFieldTracked(policy, "Orcamento", operation, recordId, "ORC_ID"))
                        mask |= OrcamentoTrackingFields.ORC_ID;
                    if (DomainFieldTracked(policy, "Orcamento", operation, recordId, "REP_ID"))
                        mask |= OrcamentoTrackingFields.REP_ID;
                    if (DomainFieldTracked(policy, "Orcamento", operation, recordId, "CON_ID"))
                        mask |= OrcamentoTrackingFields.CON_ID;
                    if (DomainFieldTracked(policy, "Orcamento", operation, recordId, "ORC_TIPO_FRETE"))
                        mask |= OrcamentoTrackingFields.ORC_TIPO_FRETE;
                    if (DomainFieldTracked(policy, "Orcamento", operation, recordId, "ORC_EMISSAO"))
                        mask |= OrcamentoTrackingFields.ORC_EMISSAO;
                    if (DomainFieldTracked(policy, "Orcamento", operation, recordId, "CLI_ID"))
                        mask |= OrcamentoTrackingFields.CLI_ID;
                    if (DomainFieldTracked(policy, "Orcamento", operation, recordId, "VER_ID"))
                        mask |= OrcamentoTrackingFields.VER_ID;
                    if (DomainFieldTracked(policy, "Orcamento", operation, recordId, "TenantID"))
                        mask |= OrcamentoTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Orcamento", operation, recordId, "Deleted"))
                        mask |= OrcamentoTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Orcamento", operation, recordId, "Changed"))
                        mask |= OrcamentoTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Orcamento", operation, recordId, "UserId"))
                        mask |= OrcamentoTrackingFields.UserId;
                    return mask;
                }

                private ulong GetOrderTrackMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "OrderTrack", operation, recordId, "Id"))
                        mask |= OrderTrackTrackingFields.Id;
                    if (DomainFieldTracked(policy, "OrderTrack", operation, recordId, "OTK_ID"))
                        mask |= OrderTrackTrackingFields.OTK_ID;
                    if (DomainFieldTracked(policy, "OrderTrack", operation, recordId, "OTK_SEQUENCIA"))
                        mask |= OrderTrackTrackingFields.OTK_SEQUENCIA;
                    if (DomainFieldTracked(policy, "OrderTrack", operation, recordId, "OTK_VERSSAO"))
                        mask |= OrderTrackTrackingFields.OTK_VERSSAO;
                    if (DomainFieldTracked(policy, "OrderTrack", operation, recordId, "ORD_ID"))
                        mask |= OrderTrackTrackingFields.ORD_ID;
                    if (DomainFieldTracked(policy, "OrderTrack", operation, recordId, "OTK_EVENTO"))
                        mask |= OrderTrackTrackingFields.OTK_EVENTO;
                    if (DomainFieldTracked(policy, "OrderTrack", operation, recordId, "OTK_DATA_NECESSIDADE_DE"))
                        mask |= OrderTrackTrackingFields.OTK_DATA_NECESSIDADE_DE;
                    if (DomainFieldTracked(policy, "OrderTrack", operation, recordId, "OTK_DATA_NECESSIDADE_ATE"))
                        mask |= OrderTrackTrackingFields.OTK_DATA_NECESSIDADE_ATE;
                    if (DomainFieldTracked(policy, "OrderTrack", operation, recordId, "OTK_DATA_PREVISTA"))
                        mask |= OrderTrackTrackingFields.OTK_DATA_PREVISTA;
                    if (DomainFieldTracked(policy, "OrderTrack", operation, recordId, "OTK_DATA_REALIZADA"))
                        mask |= OrderTrackTrackingFields.OTK_DATA_REALIZADA;
                    if (DomainFieldTracked(policy, "OrderTrack", operation, recordId, "FPR_ID"))
                        mask |= OrderTrackTrackingFields.FPR_ID;
                    if (DomainFieldTracked(policy, "OrderTrack", operation, recordId, "TenantID"))
                        mask |= OrderTrackTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "OrderTrack", operation, recordId, "Deleted"))
                        mask |= OrderTrackTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "OrderTrack", operation, recordId, "Changed"))
                        mask |= OrderTrackTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "OrderTrack", operation, recordId, "UserId"))
                        mask |= OrderTrackTrackingFields.UserId;
                    return mask;
                }

                private ulong GetOrderMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "ORD_ID"))
                        mask |= OrderTrackingFields.ORD_ID;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "ORD_ID_RESERVA"))
                        mask |= OrderTrackingFields.ORD_ID_RESERVA;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "ORD_ID_CONJUNTO"))
                        mask |= OrderTrackingFields.ORD_ID_CONJUNTO;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "PRO_ID"))
                        mask |= OrderTrackingFields.PRO_ID;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "PRO_ID_CONJUNTO"))
                        mask |= OrderTrackingFields.PRO_ID_CONJUNTO;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "CLI_ID"))
                        mask |= OrderTrackingFields.CLI_ID;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "ORD_PRECO_UNITARIO"))
                        mask |= OrderTrackingFields.ORD_PRECO_UNITARIO;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "ORD_QUANTIDADE"))
                        mask |= OrderTrackingFields.ORD_QUANTIDADE;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "ORD_DATA_ENTREGA_DE"))
                        mask |= OrderTrackingFields.ORD_DATA_ENTREGA_DE;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "ORD_DATA_ENTREGA_ATE"))
                        mask |= OrderTrackingFields.ORD_DATA_ENTREGA_ATE;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "ORD_TIPO"))
                        mask |= OrderTrackingFields.ORD_TIPO;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "ORD_TOLERANCIA_MAIS"))
                        mask |= OrderTrackingFields.ORD_TOLERANCIA_MAIS;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "ORD_TOLERANCIA_MENOS"))
                        mask |= OrderTrackingFields.ORD_TOLERANCIA_MENOS;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "HASH_KEY"))
                        mask |= OrderTrackingFields.HASH_KEY;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "ORD_INICIO_JANELA_EMBARQUE"))
                        mask |= OrderTrackingFields.ORD_INICIO_JANELA_EMBARQUE;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "ORD_FIM_JANELA_EMBARQUE"))
                        mask |= OrderTrackingFields.ORD_FIM_JANELA_EMBARQUE;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "ORD_EMBARQUE_ALVO"))
                        mask |= OrderTrackingFields.ORD_EMBARQUE_ALVO;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "ORD_INICIO_GRUPO_PRODUTIVO"))
                        mask |= OrderTrackingFields.ORD_INICIO_GRUPO_PRODUTIVO;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "ORD_FIM_GRUPO_PRODUTIVO"))
                        mask |= OrderTrackingFields.ORD_FIM_GRUPO_PRODUTIVO;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "ORD_PESO_UNITARIO"))
                        mask |= OrderTrackingFields.ORD_PESO_UNITARIO;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "ORD_PESO_UNITARIO_BRUTO"))
                        mask |= OrderTrackingFields.ORD_PESO_UNITARIO_BRUTO;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "ORD_M2_UNITARIO"))
                        mask |= OrderTrackingFields.ORD_M2_UNITARIO;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "ORD_MIT"))
                        mask |= OrderTrackingFields.ORD_MIT;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "CAR_TIPO_CARREGAMENTO"))
                        mask |= OrderTrackingFields.CAR_TIPO_CARREGAMENTO;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "ORD_STATUS"))
                        mask |= OrderTrackingFields.ORD_STATUS;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "ORD_TIPO_FRETE"))
                        mask |= OrderTrackingFields.ORD_TIPO_FRETE;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "ORD_ENDERECO_ENTREGA"))
                        mask |= OrderTrackingFields.ORD_ENDERECO_ENTREGA;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "ORD_BAIRRO_ENTREGA"))
                        mask |= OrderTrackingFields.ORD_BAIRRO_ENTREGA;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "UF_ID_ENTREGA"))
                        mask |= OrderTrackingFields.UF_ID_ENTREGA;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "ORD_CEP_ENTREGA"))
                        mask |= OrderTrackingFields.ORD_CEP_ENTREGA;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "MUN_ID_ENTREGA"))
                        mask |= OrderTrackingFields.MUN_ID_ENTREGA;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "ORD_REGIAO_ENTREGA"))
                        mask |= OrderTrackingFields.ORD_REGIAO_ENTREGA;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "ORD_LARGURA"))
                        mask |= OrderTrackingFields.ORD_LARGURA;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "ORD_COMPRIMENTO"))
                        mask |= OrderTrackingFields.ORD_COMPRIMENTO;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "ORD_GRAMATURA"))
                        mask |= OrderTrackingFields.ORD_GRAMATURA;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "GRP_ID"))
                        mask |= OrderTrackingFields.GRP_ID;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "ORD_ID_INTEGRACAO"))
                        mask |= OrderTrackingFields.ORD_ID_INTEGRACAO;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "ORD_OBSERVACAO_OTIMIZADOR"))
                        mask |= OrderTrackingFields.ORD_OBSERVACAO_OTIMIZADOR;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "ORD_COR_FILA"))
                        mask |= OrderTrackingFields.ORD_COR_FILA;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "ORD_PED_CLI"))
                        mask |= OrderTrackingFields.ORD_PED_CLI;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "ORD_OP_INTEGRACAO"))
                        mask |= OrderTrackingFields.ORD_OP_INTEGRACAO;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "ORD_LOTE_PILOTO"))
                        mask |= OrderTrackingFields.ORD_LOTE_PILOTO;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "ORD_PRIORIDADE"))
                        mask |= OrderTrackingFields.ORD_PRIORIDADE;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "ORD_EMISSAO"))
                        mask |= OrderTrackingFields.ORD_EMISSAO;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "REP_ID"))
                        mask |= OrderTrackingFields.REP_ID;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "ORD_RESINA"))
                        mask |= OrderTrackingFields.ORD_RESINA;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "ORD_ENDURECEDOR_MIOLO"))
                        mask |= OrderTrackingFields.ORD_ENDURECEDOR_MIOLO;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "PRO_ID_INTEGRACAO_ERP"))
                        mask |= OrderTrackingFields.PRO_ID_INTEGRACAO_ERP;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "ORD_VINCOS_ONDULADEIRA"))
                        mask |= OrderTrackingFields.ORD_VINCOS_ONDULADEIRA;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "ORD_ERP_CUSTOS_FIXOS"))
                        mask |= OrderTrackingFields.ORD_ERP_CUSTOS_FIXOS;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "ORD_ERP_CUSTOS_VARIAVEIS"))
                        mask |= OrderTrackingFields.ORD_ERP_CUSTOS_VARIAVEIS;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "ORD_ERP_DESPESAS_VAR_VENDA"))
                        mask |= OrderTrackingFields.ORD_ERP_DESPESAS_VAR_VENDA;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "ORD_ERP_IMPOSTOS"))
                        mask |= OrderTrackingFields.ORD_ERP_IMPOSTOS;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "ORD_STATUS_PLANEJAMENTO"))
                        mask |= OrderTrackingFields.ORD_STATUS_PLANEJAMENTO;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "ORD_TOLERANCIA_DIMENSAO_CHAPA_DE"))
                        mask |= OrderTrackingFields.ORD_TOLERANCIA_DIMENSAO_CHAPA_DE;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE"))
                        mask |= OrderTrackingFields.ORD_TOLERANCIA_DIMENSAO_CHAPA_ATE;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "ORD_PROMOVE_DE"))
                        mask |= OrderTrackingFields.ORD_PROMOVE_DE;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "ORD_PROMOVE_ATE"))
                        mask |= OrderTrackingFields.ORD_PROMOVE_ATE;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "ORD_TRAVA_COMPOSICAO"))
                        mask |= OrderTrackingFields.ORD_TRAVA_COMPOSICAO;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "ORD_TRAVA_RESINA"))
                        mask |= OrderTrackingFields.ORD_TRAVA_RESINA;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "ORD_PROMOVE_RESINA"))
                        mask |= OrderTrackingFields.ORD_PROMOVE_RESINA;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "ORD_LATITUDE_ENTREGA"))
                        mask |= OrderTrackingFields.ORD_LATITUDE_ENTREGA;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "ORD_LONGITUDE_ENTREGA"))
                        mask |= OrderTrackingFields.ORD_LONGITUDE_ENTREGA;
                    if (DomainFieldTracked(policy, "Order", operation, recordId, "OCO_ID_CANCELAMENTO"))
                        mask |= OrderTrackingFields.OCO_ID_CANCELAMENTO;
                    return mask;
                }

                private ulong GetParamMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Param", operation, recordId, "PAR_ID"))
                        mask |= ParamTrackingFields.PAR_ID;
                    if (DomainFieldTracked(policy, "Param", operation, recordId, "PAR_DESCRICAO"))
                        mask |= ParamTrackingFields.PAR_DESCRICAO;
                    if (DomainFieldTracked(policy, "Param", operation, recordId, "PAR_VALOR_S"))
                        mask |= ParamTrackingFields.PAR_VALOR_S;
                    if (DomainFieldTracked(policy, "Param", operation, recordId, "PAR_VALOR_N"))
                        mask |= ParamTrackingFields.PAR_VALOR_N;
                    if (DomainFieldTracked(policy, "Param", operation, recordId, "PAR_VALOR_D"))
                        mask |= ParamTrackingFields.PAR_VALOR_D;
                    if (DomainFieldTracked(policy, "Param", operation, recordId, "TenantID"))
                        mask |= ParamTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Param", operation, recordId, "Deleted"))
                        mask |= ParamTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Param", operation, recordId, "Changed"))
                        mask |= ParamTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Param", operation, recordId, "UserId"))
                        mask |= ParamTrackingFields.UserId;
                    return mask;
                }

                private ulong GetParametrosDeCustoMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "ParametrosDeCusto", operation, recordId, "Id"))
                        mask |= ParametrosDeCustoTrackingFields.Id;
                    if (DomainFieldTracked(policy, "ParametrosDeCusto", operation, recordId, "PAR_ID"))
                        mask |= ParametrosDeCustoTrackingFields.PAR_ID;
                    if (DomainFieldTracked(policy, "ParametrosDeCusto", operation, recordId, "PRO_ID"))
                        mask |= ParametrosDeCustoTrackingFields.PRO_ID;
                    if (DomainFieldTracked(policy, "ParametrosDeCusto", operation, recordId, "CUS_ID"))
                        mask |= ParametrosDeCustoTrackingFields.CUS_ID;
                    if (DomainFieldTracked(policy, "ParametrosDeCusto", operation, recordId, "PAR_VALOR"))
                        mask |= ParametrosDeCustoTrackingFields.PAR_VALOR;
                    if (DomainFieldTracked(policy, "ParametrosDeCusto", operation, recordId, "TenantID"))
                        mask |= ParametrosDeCustoTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "ParametrosDeCusto", operation, recordId, "Deleted"))
                        mask |= ParametrosDeCustoTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "ParametrosDeCusto", operation, recordId, "Changed"))
                        mask |= ParametrosDeCustoTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "ParametrosDeCusto", operation, recordId, "UserId"))
                        mask |= ParametrosDeCustoTrackingFields.UserId;
                    return mask;
                }

                private ulong GetPendenciasInterfaceMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "PendenciasInterface", operation, recordId, "PEN_STATUS_OUT"))
                        mask |= PendenciasInterfaceTrackingFields.PEN_STATUS_OUT;
                    if (DomainFieldTracked(policy, "PendenciasInterface", operation, recordId, "PEN_PROTOCOLO_OUT"))
                        mask |= PendenciasInterfaceTrackingFields.PEN_PROTOCOLO_OUT;
                    if (DomainFieldTracked(policy, "PendenciasInterface", operation, recordId, "PEN_ID_PROTOCOLO_OUT"))
                        mask |= PendenciasInterfaceTrackingFields.PEN_ID_PROTOCOLO_OUT;
                    if (DomainFieldTracked(policy, "PendenciasInterface", operation, recordId, "PEN_STATUS_IN"))
                        mask |= PendenciasInterfaceTrackingFields.PEN_STATUS_IN;
                    if (DomainFieldTracked(policy, "PendenciasInterface", operation, recordId, "PEN_PROTOCOLO_IN"))
                        mask |= PendenciasInterfaceTrackingFields.PEN_PROTOCOLO_IN;
                    if (DomainFieldTracked(policy, "PendenciasInterface", operation, recordId, "PEN_ID_PROTOCOLO_IN"))
                        mask |= PendenciasInterfaceTrackingFields.PEN_ID_PROTOCOLO_IN;
                    if (DomainFieldTracked(policy, "PendenciasInterface", operation, recordId, "DATA_ENTRADA"))
                        mask |= PendenciasInterfaceTrackingFields.DATA_ENTRADA;
                    if (DomainFieldTracked(policy, "PendenciasInterface", operation, recordId, "TenantID"))
                        mask |= PendenciasInterfaceTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "PendenciasInterface", operation, recordId, "Deleted"))
                        mask |= PendenciasInterfaceTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "PendenciasInterface", operation, recordId, "Changed"))
                        mask |= PendenciasInterfaceTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "PendenciasInterface", operation, recordId, "UserId"))
                        mask |= PendenciasInterfaceTrackingFields.UserId;
                    if (DomainFieldTracked(policy, "PendenciasInterface", operation, recordId, "PEN_ID"))
                        mask |= PendenciasInterfaceTrackingFields.PEN_ID;
                    return mask;
                }

                private ulong GetPerfilMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Perfil", operation, recordId, "PER_ID"))
                        mask |= PerfilTrackingFields.PER_ID;
                    if (DomainFieldTracked(policy, "Perfil", operation, recordId, "PER_NOME"))
                        mask |= PerfilTrackingFields.PER_NOME;
                    if (DomainFieldTracked(policy, "Perfil", operation, recordId, "TenantID"))
                        mask |= PerfilTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Perfil", operation, recordId, "Deleted"))
                        mask |= PerfilTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Perfil", operation, recordId, "Changed"))
                        mask |= PerfilTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Perfil", operation, recordId, "UserId"))
                        mask |= PerfilTrackingFields.UserId;
                    return mask;
                }

                private ulong GetPerfilObjetoControlavelMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "PerfilObjetoControlavel", operation, recordId, "Id"))
                        mask |= PerfilObjetoControlavelTrackingFields.Id;
                    if (DomainFieldTracked(policy, "PerfilObjetoControlavel", operation, recordId, "PER_ID"))
                        mask |= PerfilObjetoControlavelTrackingFields.PER_ID;
                    if (DomainFieldTracked(policy, "PerfilObjetoControlavel", operation, recordId, "OBJ_ID"))
                        mask |= PerfilObjetoControlavelTrackingFields.OBJ_ID;
                    if (DomainFieldTracked(policy, "PerfilObjetoControlavel", operation, recordId, "PEO_ACAO"))
                        mask |= PerfilObjetoControlavelTrackingFields.PEO_ACAO;
                    if (DomainFieldTracked(policy, "PerfilObjetoControlavel", operation, recordId, "TenantID"))
                        mask |= PerfilObjetoControlavelTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "PerfilObjetoControlavel", operation, recordId, "Deleted"))
                        mask |= PerfilObjetoControlavelTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "PerfilObjetoControlavel", operation, recordId, "Changed"))
                        mask |= PerfilObjetoControlavelTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "PerfilObjetoControlavel", operation, recordId, "UserId"))
                        mask |= PerfilObjetoControlavelTrackingFields.UserId;
                    return mask;
                }

                private ulong GetPeriodicidadeTesteMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "PeriodicidadeTeste", operation, recordId, "Id"))
                        mask |= PeriodicidadeTesteTrackingFields.Id;
                    if (DomainFieldTracked(policy, "PeriodicidadeTeste", operation, recordId, "PER_ID"))
                        mask |= PeriodicidadeTesteTrackingFields.PER_ID;
                    if (DomainFieldTracked(policy, "PeriodicidadeTeste", operation, recordId, "PER_QTD"))
                        mask |= PeriodicidadeTesteTrackingFields.PER_QTD;
                    if (DomainFieldTracked(policy, "PeriodicidadeTeste", operation, recordId, "UNI_ID"))
                        mask |= PeriodicidadeTesteTrackingFields.UNI_ID;
                    if (DomainFieldTracked(policy, "PeriodicidadeTeste", operation, recordId, "GRP_ID"))
                        mask |= PeriodicidadeTesteTrackingFields.GRP_ID;
                    if (DomainFieldTracked(policy, "PeriodicidadeTeste", operation, recordId, "TenantID"))
                        mask |= PeriodicidadeTesteTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "PeriodicidadeTeste", operation, recordId, "Deleted"))
                        mask |= PeriodicidadeTesteTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "PeriodicidadeTeste", operation, recordId, "Changed"))
                        mask |= PeriodicidadeTesteTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "PeriodicidadeTeste", operation, recordId, "UserId"))
                        mask |= PeriodicidadeTesteTrackingFields.UserId;
                    return mask;
                }

                private ulong GetPlanoAmostralTesteMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "PlanoAmostralTeste", operation, recordId, "GRP_TIPO"))
                        mask |= PlanoAmostralTesteTrackingFields.GRP_TIPO;
                    if (DomainFieldTracked(policy, "PlanoAmostralTeste", operation, recordId, "TenantID"))
                        mask |= PlanoAmostralTesteTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "PlanoAmostralTeste", operation, recordId, "Deleted"))
                        mask |= PlanoAmostralTesteTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "PlanoAmostralTeste", operation, recordId, "Changed"))
                        mask |= PlanoAmostralTesteTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "PlanoAmostralTeste", operation, recordId, "UserId"))
                        mask |= PlanoAmostralTesteTrackingFields.UserId;
                    if (DomainFieldTracked(policy, "PlanoAmostralTeste", operation, recordId, "PAT_ID"))
                        mask |= PlanoAmostralTesteTrackingFields.PAT_ID;
                    if (DomainFieldTracked(policy, "PlanoAmostralTeste", operation, recordId, "PAT_QTD_CAIXAS_DE"))
                        mask |= PlanoAmostralTesteTrackingFields.PAT_QTD_CAIXAS_DE;
                    if (DomainFieldTracked(policy, "PlanoAmostralTeste", operation, recordId, "PAT_QTD_CAIXAS_ATE"))
                        mask |= PlanoAmostralTesteTrackingFields.PAT_QTD_CAIXAS_ATE;
                    if (DomainFieldTracked(policy, "PlanoAmostralTeste", operation, recordId, "PAT_N_AMOSTRAGEM"))
                        mask |= PlanoAmostralTesteTrackingFields.PAT_N_AMOSTRAGEM;
                    if (DomainFieldTracked(policy, "PlanoAmostralTeste", operation, recordId, "PAT_PERCENT_ESPECIF"))
                        mask |= PlanoAmostralTesteTrackingFields.PAT_PERCENT_ESPECIF;
                    return mask;
                }

                private ulong GetPlanoacaoMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Planoacao", operation, recordId, "PLA_ID"))
                        mask |= PlanoacaoTrackingFields.PLA_ID;
                    if (DomainFieldTracked(policy, "Planoacao", operation, recordId, "PLA_DESCRICAO"))
                        mask |= PlanoacaoTrackingFields.PLA_DESCRICAO;
                    if (DomainFieldTracked(policy, "Planoacao", operation, recordId, "MET_ID"))
                        mask |= PlanoacaoTrackingFields.MET_ID;
                    if (DomainFieldTracked(policy, "Planoacao", operation, recordId, "PLA_STATUS"))
                        mask |= PlanoacaoTrackingFields.PLA_STATUS;
                    if (DomainFieldTracked(policy, "Planoacao", operation, recordId, "PLA_DATA"))
                        mask |= PlanoacaoTrackingFields.PLA_DATA;
                    if (DomainFieldTracked(policy, "Planoacao", operation, recordId, "PLA_METAPERIODO"))
                        mask |= PlanoacaoTrackingFields.PLA_METAPERIODO;
                    if (DomainFieldTracked(policy, "Planoacao", operation, recordId, "PLA_VLRPERIODO"))
                        mask |= PlanoacaoTrackingFields.PLA_VLRPERIODO;
                    if (DomainFieldTracked(policy, "Planoacao", operation, recordId, "PLA_METACULADO"))
                        mask |= PlanoacaoTrackingFields.PLA_METACULADO;
                    if (DomainFieldTracked(policy, "Planoacao", operation, recordId, "PLA_VLRACUMULADO"))
                        mask |= PlanoacaoTrackingFields.PLA_VLRACUMULADO;
                    if (DomainFieldTracked(policy, "Planoacao", operation, recordId, "PLA_REFERENCIA"))
                        mask |= PlanoacaoTrackingFields.PLA_REFERENCIA;
                    if (DomainFieldTracked(policy, "Planoacao", operation, recordId, "USE_ID"))
                        mask |= PlanoacaoTrackingFields.USE_ID;
                    if (DomainFieldTracked(policy, "Planoacao", operation, recordId, "TenantID"))
                        mask |= PlanoacaoTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Planoacao", operation, recordId, "Deleted"))
                        mask |= PlanoacaoTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Planoacao", operation, recordId, "Changed"))
                        mask |= PlanoacaoTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Planoacao", operation, recordId, "UserId"))
                        mask |= PlanoacaoTrackingFields.UserId;
                    return mask;
                }

                private ulong GetPlotagemMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Plotagem", operation, recordId, "Id"))
                        mask |= PlotagemTrackingFields.Id;
                    if (DomainFieldTracked(policy, "Plotagem", operation, recordId, "PLO_ID"))
                        mask |= PlotagemTrackingFields.PLO_ID;
                    if (DomainFieldTracked(policy, "Plotagem", operation, recordId, "PLO_NOME"))
                        mask |= PlotagemTrackingFields.PLO_NOME;
                    if (DomainFieldTracked(policy, "Plotagem", operation, recordId, "PLO_DIMENSAO"))
                        mask |= PlotagemTrackingFields.PLO_DIMENSAO;
                    if (DomainFieldTracked(policy, "Plotagem", operation, recordId, "PLO_X"))
                        mask |= PlotagemTrackingFields.PLO_X;
                    if (DomainFieldTracked(policy, "Plotagem", operation, recordId, "PLO_Y"))
                        mask |= PlotagemTrackingFields.PLO_Y;
                    if (DomainFieldTracked(policy, "Plotagem", operation, recordId, "PLO_Z"))
                        mask |= PlotagemTrackingFields.PLO_Z;
                    if (DomainFieldTracked(policy, "Plotagem", operation, recordId, "PLO_GRAFICO"))
                        mask |= PlotagemTrackingFields.PLO_GRAFICO;
                    if (DomainFieldTracked(policy, "Plotagem", operation, recordId, "CON_ID"))
                        mask |= PlotagemTrackingFields.CON_ID;
                    if (DomainFieldTracked(policy, "Plotagem", operation, recordId, "TenantID"))
                        mask |= PlotagemTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Plotagem", operation, recordId, "Deleted"))
                        mask |= PlotagemTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Plotagem", operation, recordId, "Changed"))
                        mask |= PlotagemTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Plotagem", operation, recordId, "UserId"))
                        mask |= PlotagemTrackingFields.UserId;
                    return mask;
                }

                private ulong GetPoliticaOnduladeiraMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "PoliticaOnduladeira", operation, recordId, "Id"))
                        mask |= PoliticaOnduladeiraTrackingFields.Id;
                    if (DomainFieldTracked(policy, "PoliticaOnduladeira", operation, recordId, "POL_ID"))
                        mask |= PoliticaOnduladeiraTrackingFields.POL_ID;
                    if (DomainFieldTracked(policy, "PoliticaOnduladeira", operation, recordId, "POL_NIVEL"))
                        mask |= PoliticaOnduladeiraTrackingFields.POL_NIVEL;
                    if (DomainFieldTracked(policy, "PoliticaOnduladeira", operation, recordId, "POL_PROMOCAO"))
                        mask |= PoliticaOnduladeiraTrackingFields.POL_PROMOCAO;
                    if (DomainFieldTracked(policy, "PoliticaOnduladeira", operation, recordId, "POL_DIAS_ANTECIPACAO"))
                        mask |= PoliticaOnduladeiraTrackingFields.POL_DIAS_ANTECIPACAO;
                    if (DomainFieldTracked(policy, "PoliticaOnduladeira", operation, recordId, "POL_METROS_LINEARES"))
                        mask |= PoliticaOnduladeiraTrackingFields.POL_METROS_LINEARES;
                    if (DomainFieldTracked(policy, "PoliticaOnduladeira", operation, recordId, "TenantID"))
                        mask |= PoliticaOnduladeiraTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "PoliticaOnduladeira", operation, recordId, "Deleted"))
                        mask |= PoliticaOnduladeiraTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "PoliticaOnduladeira", operation, recordId, "Changed"))
                        mask |= PoliticaOnduladeiraTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "PoliticaOnduladeira", operation, recordId, "UserId"))
                        mask |= PoliticaOnduladeiraTrackingFields.UserId;
                    return mask;
                }

                private ulong GetPontosMapaMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "PontosMapa", operation, recordId, "PON_ID"))
                        mask |= PontosMapaTrackingFields.PON_ID;
                    if (DomainFieldTracked(policy, "PontosMapa", operation, recordId, "PON_DESCRICAO"))
                        mask |= PontosMapaTrackingFields.PON_DESCRICAO;
                    if (DomainFieldTracked(policy, "PontosMapa", operation, recordId, "PON_TIPO"))
                        mask |= PontosMapaTrackingFields.PON_TIPO;
                    if (DomainFieldTracked(policy, "PontosMapa", operation, recordId, "PON_LATITUDE"))
                        mask |= PontosMapaTrackingFields.PON_LATITUDE;
                    if (DomainFieldTracked(policy, "PontosMapa", operation, recordId, "PON_LONGITUDE"))
                        mask |= PontosMapaTrackingFields.PON_LONGITUDE;
                    if (DomainFieldTracked(policy, "PontosMapa", operation, recordId, "PON_DISTANCIA_KM"))
                        mask |= PontosMapaTrackingFields.PON_DISTANCIA_KM;
                    if (DomainFieldTracked(policy, "PontosMapa", operation, recordId, "TenantID"))
                        mask |= PontosMapaTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "PontosMapa", operation, recordId, "Deleted"))
                        mask |= PontosMapaTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "PontosMapa", operation, recordId, "Changed"))
                        mask |= PontosMapaTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "PontosMapa", operation, recordId, "UserId"))
                        mask |= PontosMapaTrackingFields.UserId;
                    return mask;
                }

                private ulong GetT_PREFERENCIASMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "T_PREFERENCIAS", operation, recordId, "Id"))
                        mask |= T_PREFERENCIASTrackingFields.Id;
                    if (DomainFieldTracked(policy, "T_PREFERENCIAS", operation, recordId, "PRE_ID"))
                        mask |= T_PREFERENCIASTrackingFields.PRE_ID;
                    if (DomainFieldTracked(policy, "T_PREFERENCIAS", operation, recordId, "PRE_DESCRICAO"))
                        mask |= T_PREFERENCIASTrackingFields.PRE_DESCRICAO;
                    if (DomainFieldTracked(policy, "T_PREFERENCIAS", operation, recordId, "PRE_NAMESPACE"))
                        mask |= T_PREFERENCIASTrackingFields.PRE_NAMESPACE;
                    if (DomainFieldTracked(policy, "T_PREFERENCIAS", operation, recordId, "PRE_TIPO"))
                        mask |= T_PREFERENCIASTrackingFields.PRE_TIPO;
                    if (DomainFieldTracked(policy, "T_PREFERENCIAS", operation, recordId, "PRE_VALOR"))
                        mask |= T_PREFERENCIASTrackingFields.PRE_VALOR;
                    if (DomainFieldTracked(policy, "T_PREFERENCIAS", operation, recordId, "USE_ID"))
                        mask |= T_PREFERENCIASTrackingFields.USE_ID;
                    if (DomainFieldTracked(policy, "T_PREFERENCIAS", operation, recordId, "PER_ID"))
                        mask |= T_PREFERENCIASTrackingFields.PER_ID;
                    if (DomainFieldTracked(policy, "T_PREFERENCIAS", operation, recordId, "TenantID"))
                        mask |= T_PREFERENCIASTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "T_PREFERENCIAS", operation, recordId, "Deleted"))
                        mask |= T_PREFERENCIASTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "T_PREFERENCIAS", operation, recordId, "Changed"))
                        mask |= T_PREFERENCIASTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "T_PREFERENCIAS", operation, recordId, "UserId"))
                        mask |= T_PREFERENCIASTrackingFields.UserId;
                    return mask;
                }

                private ulong GetProtocoloOnduladeiraMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "ProtocoloOnduladeira", operation, recordId, "Id"))
                        mask |= ProtocoloOnduladeiraTrackingFields.Id;
                    if (DomainFieldTracked(policy, "ProtocoloOnduladeira", operation, recordId, "PTO_ID"))
                        mask |= ProtocoloOnduladeiraTrackingFields.PTO_ID;
                    if (DomainFieldTracked(policy, "ProtocoloOnduladeira", operation, recordId, "PTO_CHAVE"))
                        mask |= ProtocoloOnduladeiraTrackingFields.PTO_CHAVE;
                    if (DomainFieldTracked(policy, "ProtocoloOnduladeira", operation, recordId, "MAQ_ID"))
                        mask |= ProtocoloOnduladeiraTrackingFields.MAQ_ID;
                    if (DomainFieldTracked(policy, "ProtocoloOnduladeira", operation, recordId, "PTO_COMANDO"))
                        mask |= ProtocoloOnduladeiraTrackingFields.PTO_COMANDO;
                    if (DomainFieldTracked(policy, "ProtocoloOnduladeira", operation, recordId, "TenantID"))
                        mask |= ProtocoloOnduladeiraTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "ProtocoloOnduladeira", operation, recordId, "Deleted"))
                        mask |= ProtocoloOnduladeiraTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "ProtocoloOnduladeira", operation, recordId, "Changed"))
                        mask |= ProtocoloOnduladeiraTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "ProtocoloOnduladeira", operation, recordId, "UserId"))
                        mask |= ProtocoloOnduladeiraTrackingFields.UserId;
                    return mask;
                }

                private ulong GetRecursosMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Recursos", operation, recordId, "REC_ID"))
                        mask |= RecursosTrackingFields.REC_ID;
                    if (DomainFieldTracked(policy, "Recursos", operation, recordId, "REC_DESCRICAO"))
                        mask |= RecursosTrackingFields.REC_DESCRICAO;
                    if (DomainFieldTracked(policy, "Recursos", operation, recordId, "CAL_ID"))
                        mask |= RecursosTrackingFields.CAL_ID;
                    if (DomainFieldTracked(policy, "Recursos", operation, recordId, "REC_CONTROL_IP"))
                        mask |= RecursosTrackingFields.REC_CONTROL_IP;
                    if (DomainFieldTracked(policy, "Recursos", operation, recordId, "GRE_ID"))
                        mask |= RecursosTrackingFields.GRE_ID;
                    if (DomainFieldTracked(policy, "Recursos", operation, recordId, "TenantID"))
                        mask |= RecursosTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Recursos", operation, recordId, "Deleted"))
                        mask |= RecursosTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Recursos", operation, recordId, "Changed"))
                        mask |= RecursosTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Recursos", operation, recordId, "UserId"))
                        mask |= RecursosTrackingFields.UserId;
                    return mask;
                }

                private ulong GetRegistrosOnduladeiraMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "RegistrosOnduladeira", operation, recordId, "Id"))
                        mask |= RegistrosOnduladeiraTrackingFields.Id;
                    if (DomainFieldTracked(policy, "RegistrosOnduladeira", operation, recordId, "REG_ID"))
                        mask |= RegistrosOnduladeiraTrackingFields.REG_ID;
                    if (DomainFieldTracked(policy, "RegistrosOnduladeira", operation, recordId, "REG_RESPOSTA"))
                        mask |= RegistrosOnduladeiraTrackingFields.REG_RESPOSTA;
                    if (DomainFieldTracked(policy, "RegistrosOnduladeira", operation, recordId, "REG_STATUS"))
                        mask |= RegistrosOnduladeiraTrackingFields.REG_STATUS;
                    if (DomainFieldTracked(policy, "RegistrosOnduladeira", operation, recordId, "REG_DATA_INICIO"))
                        mask |= RegistrosOnduladeiraTrackingFields.REG_DATA_INICIO;
                    if (DomainFieldTracked(policy, "RegistrosOnduladeira", operation, recordId, "TenantID"))
                        mask |= RegistrosOnduladeiraTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "RegistrosOnduladeira", operation, recordId, "Deleted"))
                        mask |= RegistrosOnduladeiraTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "RegistrosOnduladeira", operation, recordId, "Changed"))
                        mask |= RegistrosOnduladeiraTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "RegistrosOnduladeira", operation, recordId, "UserId"))
                        mask |= RegistrosOnduladeiraTrackingFields.UserId;
                    return mask;
                }

                private ulong GetRepresentantesMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Representantes", operation, recordId, "Id"))
                        mask |= RepresentantesTrackingFields.Id;
                    if (DomainFieldTracked(policy, "Representantes", operation, recordId, "REP_ID"))
                        mask |= RepresentantesTrackingFields.REP_ID;
                    if (DomainFieldTracked(policy, "Representantes", operation, recordId, "REP_NOME"))
                        mask |= RepresentantesTrackingFields.REP_NOME;
                    if (DomainFieldTracked(policy, "Representantes", operation, recordId, "TenantID"))
                        mask |= RepresentantesTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Representantes", operation, recordId, "Deleted"))
                        mask |= RepresentantesTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Representantes", operation, recordId, "Changed"))
                        mask |= RepresentantesTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Representantes", operation, recordId, "UserId"))
                        mask |= RepresentantesTrackingFields.UserId;
                    return mask;
                }

                private ulong GetRespInspVisualMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "RespInspVisual", operation, recordId, "Id"))
                        mask |= RespInspVisualTrackingFields.Id;
                    if (DomainFieldTracked(policy, "RespInspVisual", operation, recordId, "RIV_ID"))
                        mask |= RespInspVisualTrackingFields.RIV_ID;
                    if (DomainFieldTracked(policy, "RespInspVisual", operation, recordId, "IPV_ID"))
                        mask |= RespInspVisualTrackingFields.IPV_ID;
                    if (DomainFieldTracked(policy, "RespInspVisual", operation, recordId, "ITI_ID"))
                        mask |= RespInspVisualTrackingFields.ITI_ID;
                    if (DomainFieldTracked(policy, "RespInspVisual", operation, recordId, "RIV_STATUS"))
                        mask |= RespInspVisualTrackingFields.RIV_STATUS;
                    if (DomainFieldTracked(policy, "RespInspVisual", operation, recordId, "TenantID"))
                        mask |= RespInspVisualTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "RespInspVisual", operation, recordId, "Deleted"))
                        mask |= RespInspVisualTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "RespInspVisual", operation, recordId, "Changed"))
                        mask |= RespInspVisualTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "RespInspVisual", operation, recordId, "UserId"))
                        mask |= RespInspVisualTrackingFields.UserId;
                    return mask;
                }

                private ulong GetRestricoesDeRodagemMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "RestricoesDeRodagem", operation, recordId, "Id"))
                        mask |= RestricoesDeRodagemTrackingFields.Id;
                    if (DomainFieldTracked(policy, "RestricoesDeRodagem", operation, recordId, "RES_ID"))
                        mask |= RestricoesDeRodagemTrackingFields.RES_ID;
                    if (DomainFieldTracked(policy, "RestricoesDeRodagem", operation, recordId, "RES_TIPO"))
                        mask |= RestricoesDeRodagemTrackingFields.RES_TIPO;
                    if (DomainFieldTracked(policy, "RestricoesDeRodagem", operation, recordId, "RES_HORA_INI"))
                        mask |= RestricoesDeRodagemTrackingFields.RES_HORA_INI;
                    if (DomainFieldTracked(policy, "RestricoesDeRodagem", operation, recordId, "RES_HORA_FIM"))
                        mask |= RestricoesDeRodagemTrackingFields.RES_HORA_FIM;
                    if (DomainFieldTracked(policy, "RestricoesDeRodagem", operation, recordId, "RES_VELOCIDADE_HORA_RUSH"))
                        mask |= RestricoesDeRodagemTrackingFields.RES_VELOCIDADE_HORA_RUSH;
                    if (DomainFieldTracked(policy, "RestricoesDeRodagem", operation, recordId, "TVE_ID"))
                        mask |= RestricoesDeRodagemTrackingFields.TVE_ID;
                    if (DomainFieldTracked(policy, "RestricoesDeRodagem", operation, recordId, "MAP_ID"))
                        mask |= RestricoesDeRodagemTrackingFields.MAP_ID;
                    if (DomainFieldTracked(policy, "RestricoesDeRodagem", operation, recordId, "TenantID"))
                        mask |= RestricoesDeRodagemTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "RestricoesDeRodagem", operation, recordId, "Deleted"))
                        mask |= RestricoesDeRodagemTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "RestricoesDeRodagem", operation, recordId, "Changed"))
                        mask |= RestricoesDeRodagemTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "RestricoesDeRodagem", operation, recordId, "UserId"))
                        mask |= RestricoesDeRodagemTrackingFields.UserId;
                    return mask;
                }

                private ulong GetResultLoteMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "ResultLote", operation, recordId, "Id"))
                        mask |= ResultLoteTrackingFields.Id;
                    if (DomainFieldTracked(policy, "ResultLote", operation, recordId, "TenantID"))
                        mask |= ResultLoteTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "ResultLote", operation, recordId, "Deleted"))
                        mask |= ResultLoteTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "ResultLote", operation, recordId, "Changed"))
                        mask |= ResultLoteTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "ResultLote", operation, recordId, "UserId"))
                        mask |= ResultLoteTrackingFields.UserId;
                    return mask;
                }

                private ulong GetResultMedidaMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "ResultMedida", operation, recordId, "Id"))
                        mask |= ResultMedidaTrackingFields.Id;
                    if (DomainFieldTracked(policy, "ResultMedida", operation, recordId, "RSM_ID"))
                        mask |= ResultMedidaTrackingFields.RSM_ID;
                    if (DomainFieldTracked(policy, "ResultMedida", operation, recordId, "RL_ID"))
                        mask |= ResultMedidaTrackingFields.RL_ID;
                    if (DomainFieldTracked(policy, "ResultMedida", operation, recordId, "MDT_ID"))
                        mask |= ResultMedidaTrackingFields.MDT_ID;
                    if (DomainFieldTracked(policy, "ResultMedida", operation, recordId, "TenantID"))
                        mask |= ResultMedidaTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "ResultMedida", operation, recordId, "Deleted"))
                        mask |= ResultMedidaTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "ResultMedida", operation, recordId, "Changed"))
                        mask |= ResultMedidaTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "ResultMedida", operation, recordId, "UserId"))
                        mask |= ResultMedidaTrackingFields.UserId;
                    return mask;
                }

                private ulong GetRodoviasMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Rodovias", operation, recordId, "Id"))
                        mask |= RodoviasTrackingFields.Id;
                    if (DomainFieldTracked(policy, "Rodovias", operation, recordId, "ROD_ID"))
                        mask |= RodoviasTrackingFields.ROD_ID;
                    if (DomainFieldTracked(policy, "Rodovias", operation, recordId, "ROD_DESCRICAO"))
                        mask |= RodoviasTrackingFields.ROD_DESCRICAO;
                    if (DomainFieldTracked(policy, "Rodovias", operation, recordId, "TenantID"))
                        mask |= RodoviasTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Rodovias", operation, recordId, "Deleted"))
                        mask |= RodoviasTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Rodovias", operation, recordId, "Changed"))
                        mask |= RodoviasTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Rodovias", operation, recordId, "UserId"))
                        mask |= RodoviasTrackingFields.UserId;
                    return mask;
                }

                private ulong GetRotaRealizadaMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "RotaRealizada", operation, recordId, "ROT_ID"))
                        mask |= RotaRealizadaTrackingFields.ROT_ID;
                    if (DomainFieldTracked(policy, "RotaRealizada", operation, recordId, "CAR_ID"))
                        mask |= RotaRealizadaTrackingFields.CAR_ID;
                    if (DomainFieldTracked(policy, "RotaRealizada", operation, recordId, "ROT_DATA_HORA"))
                        mask |= RotaRealizadaTrackingFields.ROT_DATA_HORA;
                    if (DomainFieldTracked(policy, "RotaRealizada", operation, recordId, "ROT_LAT"))
                        mask |= RotaRealizadaTrackingFields.ROT_LAT;
                    if (DomainFieldTracked(policy, "RotaRealizada", operation, recordId, "ROT_LONG"))
                        mask |= RotaRealizadaTrackingFields.ROT_LONG;
                    if (DomainFieldTracked(policy, "RotaRealizada", operation, recordId, "TenantID"))
                        mask |= RotaRealizadaTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "RotaRealizada", operation, recordId, "Deleted"))
                        mask |= RotaRealizadaTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "RotaRealizada", operation, recordId, "Changed"))
                        mask |= RotaRealizadaTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "RotaRealizada", operation, recordId, "UserId"))
                        mask |= RotaRealizadaTrackingFields.UserId;
                    return mask;
                }

                private ulong GetRotaPontosMapaMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "RotaPontosMapa", operation, recordId, "Id"))
                        mask |= RotaPontosMapaTrackingFields.Id;
                    if (DomainFieldTracked(policy, "RotaPontosMapa", operation, recordId, "ROT_ID"))
                        mask |= RotaPontosMapaTrackingFields.ROT_ID;
                    if (DomainFieldTracked(policy, "RotaPontosMapa", operation, recordId, "PON_ID_DESTINO"))
                        mask |= RotaPontosMapaTrackingFields.PON_ID_DESTINO;
                    if (DomainFieldTracked(policy, "RotaPontosMapa", operation, recordId, "PON_ID_ORIGEM"))
                        mask |= RotaPontosMapaTrackingFields.PON_ID_ORIGEM;
                    if (DomainFieldTracked(policy, "RotaPontosMapa", operation, recordId, "ROT_CUSTO_TOTAL"))
                        mask |= RotaPontosMapaTrackingFields.ROT_CUSTO_TOTAL;
                    if (DomainFieldTracked(policy, "RotaPontosMapa", operation, recordId, "PON_ID_ROTEIRO"))
                        mask |= RotaPontosMapaTrackingFields.PON_ID_ROTEIRO;
                    if (DomainFieldTracked(policy, "RotaPontosMapa", operation, recordId, "ROT_ORDEM_ROTEIRO"))
                        mask |= RotaPontosMapaTrackingFields.ROT_ORDEM_ROTEIRO;
                    if (DomainFieldTracked(policy, "RotaPontosMapa", operation, recordId, "ROT_TIPO"))
                        mask |= RotaPontosMapaTrackingFields.ROT_TIPO;
                    if (DomainFieldTracked(policy, "RotaPontosMapa", operation, recordId, "ROT_DISTANCIA"))
                        mask |= RotaPontosMapaTrackingFields.ROT_DISTANCIA;
                    if (DomainFieldTracked(policy, "RotaPontosMapa", operation, recordId, "TenantID"))
                        mask |= RotaPontosMapaTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "RotaPontosMapa", operation, recordId, "Deleted"))
                        mask |= RotaPontosMapaTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "RotaPontosMapa", operation, recordId, "Changed"))
                        mask |= RotaPontosMapaTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "RotaPontosMapa", operation, recordId, "UserId"))
                        mask |= RotaPontosMapaTrackingFields.UserId;
                    return mask;
                }

                private ulong GetSegmentoMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Segmento", operation, recordId, "Id"))
                        mask |= SegmentoTrackingFields.Id;
                    if (DomainFieldTracked(policy, "Segmento", operation, recordId, "SEG_ID"))
                        mask |= SegmentoTrackingFields.SEG_ID;
                    if (DomainFieldTracked(policy, "Segmento", operation, recordId, "SEG_DESCRICAO"))
                        mask |= SegmentoTrackingFields.SEG_DESCRICAO;
                    if (DomainFieldTracked(policy, "Segmento", operation, recordId, "SEG_ID_SEGUIMENTO_PAI"))
                        mask |= SegmentoTrackingFields.SEG_ID_SEGUIMENTO_PAI;
                    if (DomainFieldTracked(policy, "Segmento", operation, recordId, "GRS_ID"))
                        mask |= SegmentoTrackingFields.GRS_ID;
                    if (DomainFieldTracked(policy, "Segmento", operation, recordId, "SEG_INTEGRACAO_ERP"))
                        mask |= SegmentoTrackingFields.SEG_INTEGRACAO_ERP;
                    if (DomainFieldTracked(policy, "Segmento", operation, recordId, "TenantID"))
                        mask |= SegmentoTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Segmento", operation, recordId, "Deleted"))
                        mask |= SegmentoTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Segmento", operation, recordId, "Changed"))
                        mask |= SegmentoTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Segmento", operation, recordId, "UserId"))
                        mask |= SegmentoTrackingFields.UserId;
                    return mask;
                }

                private ulong GetSegmentosProdutosMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "SegmentosProdutos", operation, recordId, "Id"))
                        mask |= SegmentosProdutosTrackingFields.Id;
                    if (DomainFieldTracked(policy, "SegmentosProdutos", operation, recordId, "GRS_ID"))
                        mask |= SegmentosProdutosTrackingFields.GRS_ID;
                    if (DomainFieldTracked(policy, "SegmentosProdutos", operation, recordId, "PRO_ID"))
                        mask |= SegmentosProdutosTrackingFields.PRO_ID;
                    if (DomainFieldTracked(policy, "SegmentosProdutos", operation, recordId, "SEG_ID"))
                        mask |= SegmentosProdutosTrackingFields.SEG_ID;
                    if (DomainFieldTracked(policy, "SegmentosProdutos", operation, recordId, "TenantID"))
                        mask |= SegmentosProdutosTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "SegmentosProdutos", operation, recordId, "Deleted"))
                        mask |= SegmentosProdutosTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "SegmentosProdutos", operation, recordId, "Changed"))
                        mask |= SegmentosProdutosTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "SegmentosProdutos", operation, recordId, "UserId"))
                        mask |= SegmentosProdutosTrackingFields.UserId;
                    return mask;
                }

                private ulong GetSemaforoMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Semaforo", operation, recordId, "Id"))
                        mask |= SemaforoTrackingFields.Id;
                    if (DomainFieldTracked(policy, "Semaforo", operation, recordId, "SEM_ID"))
                        mask |= SemaforoTrackingFields.SEM_ID;
                    if (DomainFieldTracked(policy, "Semaforo", operation, recordId, "SEM_STATUS"))
                        mask |= SemaforoTrackingFields.SEM_STATUS;
                    if (DomainFieldTracked(policy, "Semaforo", operation, recordId, "SEM_ORIGEM"))
                        mask |= SemaforoTrackingFields.SEM_ORIGEM;
                    if (DomainFieldTracked(policy, "Semaforo", operation, recordId, "SEM_EMISSAO"))
                        mask |= SemaforoTrackingFields.SEM_EMISSAO;
                    if (DomainFieldTracked(policy, "Semaforo", operation, recordId, "SEM_ID_CONEXAO"))
                        mask |= SemaforoTrackingFields.SEM_ID_CONEXAO;
                    if (DomainFieldTracked(policy, "Semaforo", operation, recordId, "TenantID"))
                        mask |= SemaforoTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Semaforo", operation, recordId, "Deleted"))
                        mask |= SemaforoTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Semaforo", operation, recordId, "Changed"))
                        mask |= SemaforoTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Semaforo", operation, recordId, "UserId"))
                        mask |= SemaforoTrackingFields.UserId;
                    return mask;
                }

                private ulong GetSubOcorrenciaMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "SubOcorrencia", operation, recordId, "Id"))
                        mask |= SubOcorrenciaTrackingFields.Id;
                    if (DomainFieldTracked(policy, "SubOcorrencia", operation, recordId, "SUB_ID"))
                        mask |= SubOcorrenciaTrackingFields.SUB_ID;
                    if (DomainFieldTracked(policy, "SubOcorrencia", operation, recordId, "SUB_DESCRICAO"))
                        mask |= SubOcorrenciaTrackingFields.SUB_DESCRICAO;
                    if (DomainFieldTracked(policy, "SubOcorrencia", operation, recordId, "TenantID"))
                        mask |= SubOcorrenciaTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "SubOcorrencia", operation, recordId, "Deleted"))
                        mask |= SubOcorrenciaTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "SubOcorrencia", operation, recordId, "Changed"))
                        mask |= SubOcorrenciaTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "SubOcorrencia", operation, recordId, "UserId"))
                        mask |= SubOcorrenciaTrackingFields.UserId;
                    return mask;
                }

                private ulong GetTabelaMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Tabela", operation, recordId, "ID_TABELA"))
                        mask |= TabelaTrackingFields.ID_TABELA;
                    if (DomainFieldTracked(policy, "Tabela", operation, recordId, "CODIGO"))
                        mask |= TabelaTrackingFields.CODIGO;
                    if (DomainFieldTracked(policy, "Tabela", operation, recordId, "NOME"))
                        mask |= TabelaTrackingFields.NOME;
                    if (DomainFieldTracked(policy, "Tabela", operation, recordId, "TenantID"))
                        mask |= TabelaTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Tabela", operation, recordId, "Deleted"))
                        mask |= TabelaTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Tabela", operation, recordId, "Changed"))
                        mask |= TabelaTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Tabela", operation, recordId, "UserId"))
                        mask |= TabelaTrackingFields.UserId;
                    return mask;
                }

                private ulong GetTargetProdutoMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "TAR_ID"))
                        mask |= TargetProdutoTrackingFields.TAR_ID;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "MOV_ID"))
                        mask |= TargetProdutoTrackingFields.MOV_ID;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "ORD_ID"))
                        mask |= TargetProdutoTrackingFields.ORD_ID;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "PRO_ID"))
                        mask |= TargetProdutoTrackingFields.PRO_ID;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "MAQ_ID"))
                        mask |= TargetProdutoTrackingFields.MAQ_ID;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "UNI_ID"))
                        mask |= TargetProdutoTrackingFields.UNI_ID;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "TURM_ID"))
                        mask |= TargetProdutoTrackingFields.TURM_ID;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "TURN_ID"))
                        mask |= TargetProdutoTrackingFields.TURN_ID;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "USE_ID"))
                        mask |= TargetProdutoTrackingFields.USE_ID;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "TAR_DIA_TURMA"))
                        mask |= TargetProdutoTrackingFields.TAR_DIA_TURMA;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "TAR_META_PERFORMANCE"))
                        mask |= TargetProdutoTrackingFields.TAR_META_PERFORMANCE;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "TAR_REALIZADO_PERFORMANCE"))
                        mask |= TargetProdutoTrackingFields.TAR_REALIZADO_PERFORMANCE;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "TAR_PERCENTUAL_REALIZADO_PERFORMANCE"))
                        mask |= TargetProdutoTrackingFields.TAR_PERCENTUAL_REALIZADO_PERFORMANCE;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "TAR_PROXIMA_META_PERFORMANCE"))
                        mask |= TargetProdutoTrackingFields.TAR_PROXIMA_META_PERFORMANCE;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "TAR_META_TEMPO_SETUP"))
                        mask |= TargetProdutoTrackingFields.TAR_META_TEMPO_SETUP;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "TAR_REALIZADO_TEMPO_SETUP"))
                        mask |= TargetProdutoTrackingFields.TAR_REALIZADO_TEMPO_SETUP;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "TAR_PROXIMA_META_TEMPO_SETUP"))
                        mask |= TargetProdutoTrackingFields.TAR_PROXIMA_META_TEMPO_SETUP;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "TAR_META_TEMPO_SETUP_AJUSTE"))
                        mask |= TargetProdutoTrackingFields.TAR_META_TEMPO_SETUP_AJUSTE;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "TAR_REALIZADO_TEMPO_SETUP_AJUSTE"))
                        mask |= TargetProdutoTrackingFields.TAR_REALIZADO_TEMPO_SETUP_AJUSTE;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE"))
                        mask |= TargetProdutoTrackingFields.TAR_PROXIMA_META_TEMPO_SETUP_AJUSTE;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "OCO_ID_PERFORMANCE"))
                        mask |= TargetProdutoTrackingFields.OCO_ID_PERFORMANCE;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "TAR_OBS_PERFORMANCE"))
                        mask |= TargetProdutoTrackingFields.TAR_OBS_PERFORMANCE;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "OCO_ID_SETUP"))
                        mask |= TargetProdutoTrackingFields.OCO_ID_SETUP;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "TAR_OBS_SETUP"))
                        mask |= TargetProdutoTrackingFields.TAR_OBS_SETUP;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "OCO_ID_SETUPA"))
                        mask |= TargetProdutoTrackingFields.OCO_ID_SETUPA;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "TAR_OBS_SETUPA"))
                        mask |= TargetProdutoTrackingFields.TAR_OBS_SETUPA;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "TAR_TIPO_FEEDBACK_PERFORMANCE"))
                        mask |= TargetProdutoTrackingFields.TAR_TIPO_FEEDBACK_PERFORMANCE;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "TAR_TIPO_FEEDBACK_SETUP"))
                        mask |= TargetProdutoTrackingFields.TAR_TIPO_FEEDBACK_SETUP;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "TAR_TIPO_FEEDBACK_SETUP_AJUSTE"))
                        mask |= TargetProdutoTrackingFields.TAR_TIPO_FEEDBACK_SETUP_AJUSTE;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "TAR_QTD_SETUP_AJUSTE"))
                        mask |= TargetProdutoTrackingFields.TAR_QTD_SETUP_AJUSTE;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "TAR_QTD"))
                        mask |= TargetProdutoTrackingFields.TAR_QTD;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "TAR_PARAMETRO_TIME_WORK_STOP_MACHINE"))
                        mask |= TargetProdutoTrackingFields.TAR_PARAMETRO_TIME_WORK_STOP_MACHINE;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE"))
                        mask |= TargetProdutoTrackingFields.TAR_PARAMETRO_TEMPO_QUEBRA_DE_LOTE;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "ROT_SEQ_TRANFORMACAO"))
                        mask |= TargetProdutoTrackingFields.ROT_SEQ_TRANFORMACAO;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "FPR_SEQ_REPETICAO"))
                        mask |= TargetProdutoTrackingFields.FPR_SEQ_REPETICAO;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "TAR_PERFORMANCE_MAX_VERDE"))
                        mask |= TargetProdutoTrackingFields.TAR_PERFORMANCE_MAX_VERDE;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "TAR_PERFORMANCE_MIN_VERDE"))
                        mask |= TargetProdutoTrackingFields.TAR_PERFORMANCE_MIN_VERDE;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "TAR_SETUP_MAX_VERDE"))
                        mask |= TargetProdutoTrackingFields.TAR_SETUP_MAX_VERDE;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "TAR_SETUP_MIN_VERDE"))
                        mask |= TargetProdutoTrackingFields.TAR_SETUP_MIN_VERDE;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "TAR_SETUPA_MAX_VERDE"))
                        mask |= TargetProdutoTrackingFields.TAR_SETUPA_MAX_VERDE;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "TAR_SETUPA_MIN_VERDE"))
                        mask |= TargetProdutoTrackingFields.TAR_SETUPA_MIN_VERDE;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "TAR_PERFORMANCE_MIN_AMARELO"))
                        mask |= TargetProdutoTrackingFields.TAR_PERFORMANCE_MIN_AMARELO;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "TAR_SETUP_MAX_AMARELO"))
                        mask |= TargetProdutoTrackingFields.TAR_SETUP_MAX_AMARELO;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "TAR_SETUPA_MAX_AMARELO"))
                        mask |= TargetProdutoTrackingFields.TAR_SETUPA_MAX_AMARELO;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "TAR_OBS_OP_PARCIAL"))
                        mask |= TargetProdutoTrackingFields.TAR_OBS_OP_PARCIAL;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "TAR_OCO_ID_OP_PARCIAL"))
                        mask |= TargetProdutoTrackingFields.TAR_OCO_ID_OP_PARCIAL;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "TAR_COR_PERFORMANCE"))
                        mask |= TargetProdutoTrackingFields.TAR_COR_PERFORMANCE;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "TAR_COR_SETUP_GERAL"))
                        mask |= TargetProdutoTrackingFields.TAR_COR_SETUP_GERAL;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "TAR_COR_SETUP"))
                        mask |= TargetProdutoTrackingFields.TAR_COR_SETUP;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "TAR_COR_SETUPA"))
                        mask |= TargetProdutoTrackingFields.TAR_COR_SETUPA;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "TAR_DIA_TURMA_D"))
                        mask |= TargetProdutoTrackingFields.TAR_DIA_TURMA_D;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "FEE_QTD_PECAS_POR_PULSO"))
                        mask |= TargetProdutoTrackingFields.FEE_QTD_PECAS_POR_PULSO;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "TAR_QTD_PERDAS"))
                        mask |= TargetProdutoTrackingFields.TAR_QTD_PERDAS;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "TAR_DATA_INICIAL"))
                        mask |= TargetProdutoTrackingFields.TAR_DATA_INICIAL;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "TAR_DATA_FINAL"))
                        mask |= TargetProdutoTrackingFields.TAR_DATA_FINAL;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "TAR_APROVADO"))
                        mask |= TargetProdutoTrackingFields.TAR_APROVADO;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "TAR_TEMPO_PRODUZINDO"))
                        mask |= TargetProdutoTrackingFields.TAR_TEMPO_PRODUZINDO;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "TenantID"))
                        mask |= TargetProdutoTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "Deleted"))
                        mask |= TargetProdutoTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "Changed"))
                        mask |= TargetProdutoTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "TargetProduto", operation, recordId, "UserId"))
                        mask |= TargetProdutoTrackingFields.UserId;
                    return mask;
                }

                private ulong GetTemplatesGrupoMaquinaMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "TemplatesGrupoMaquina", operation, recordId, "Id"))
                        mask |= TemplatesGrupoMaquinaTrackingFields.Id;
                    if (DomainFieldTracked(policy, "TemplatesGrupoMaquina", operation, recordId, "TEM_ID"))
                        mask |= TemplatesGrupoMaquinaTrackingFields.TEM_ID;
                    if (DomainFieldTracked(policy, "TemplatesGrupoMaquina", operation, recordId, "GMA_ID"))
                        mask |= TemplatesGrupoMaquinaTrackingFields.GMA_ID;
                    if (DomainFieldTracked(policy, "TemplatesGrupoMaquina", operation, recordId, "TenantID"))
                        mask |= TemplatesGrupoMaquinaTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "TemplatesGrupoMaquina", operation, recordId, "Deleted"))
                        mask |= TemplatesGrupoMaquinaTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "TemplatesGrupoMaquina", operation, recordId, "Changed"))
                        mask |= TemplatesGrupoMaquinaTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "TemplatesGrupoMaquina", operation, recordId, "UserId"))
                        mask |= TemplatesGrupoMaquinaTrackingFields.UserId;
                    return mask;
                }

                private ulong GetTemplatesMaquinasMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "TemplatesMaquinas", operation, recordId, "Id"))
                        mask |= TemplatesMaquinasTrackingFields.Id;
                    if (DomainFieldTracked(policy, "TemplatesMaquinas", operation, recordId, "TEM_ID"))
                        mask |= TemplatesMaquinasTrackingFields.TEM_ID;
                    if (DomainFieldTracked(policy, "TemplatesMaquinas", operation, recordId, "MAQ_ID"))
                        mask |= TemplatesMaquinasTrackingFields.MAQ_ID;
                    if (DomainFieldTracked(policy, "TemplatesMaquinas", operation, recordId, "TenantID"))
                        mask |= TemplatesMaquinasTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "TemplatesMaquinas", operation, recordId, "Deleted"))
                        mask |= TemplatesMaquinasTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "TemplatesMaquinas", operation, recordId, "Changed"))
                        mask |= TemplatesMaquinasTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "TemplatesMaquinas", operation, recordId, "UserId"))
                        mask |= TemplatesMaquinasTrackingFields.UserId;
                    return mask;
                }

                private ulong GetTempoSetupOnduladeiraMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "TempoSetupOnduladeira", operation, recordId, "TEM_ID"))
                        mask |= TempoSetupOnduladeiraTrackingFields.TEM_ID;
                    if (DomainFieldTracked(policy, "TempoSetupOnduladeira", operation, recordId, "OND_ID_DE"))
                        mask |= TempoSetupOnduladeiraTrackingFields.OND_ID_DE;
                    if (DomainFieldTracked(policy, "TempoSetupOnduladeira", operation, recordId, "OND_ID_PARA"))
                        mask |= TempoSetupOnduladeiraTrackingFields.OND_ID_PARA;
                    if (DomainFieldTracked(policy, "TempoSetupOnduladeira", operation, recordId, "TEM_RESINA_DE"))
                        mask |= TempoSetupOnduladeiraTrackingFields.TEM_RESINA_DE;
                    if (DomainFieldTracked(policy, "TempoSetupOnduladeira", operation, recordId, "TEM_RESINA_PARA"))
                        mask |= TempoSetupOnduladeiraTrackingFields.TEM_RESINA_PARA;
                    if (DomainFieldTracked(policy, "TempoSetupOnduladeira", operation, recordId, "TEM_TEMPO"))
                        mask |= TempoSetupOnduladeiraTrackingFields.TEM_TEMPO;
                    if (DomainFieldTracked(policy, "TempoSetupOnduladeira", operation, recordId, "TenantID"))
                        mask |= TempoSetupOnduladeiraTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "TempoSetupOnduladeira", operation, recordId, "Deleted"))
                        mask |= TempoSetupOnduladeiraTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "TempoSetupOnduladeira", operation, recordId, "Changed"))
                        mask |= TempoSetupOnduladeiraTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "TempoSetupOnduladeira", operation, recordId, "UserId"))
                        mask |= TempoSetupOnduladeiraTrackingFields.UserId;
                    return mask;
                }

                private ulong GetTemposLogisticosMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "TemposLogisticos", operation, recordId, "Id"))
                        mask |= TemposLogisticosTrackingFields.Id;
                    if (DomainFieldTracked(policy, "TemposLogisticos", operation, recordId, "TMP_TIPO_TEMPO"))
                        mask |= TemposLogisticosTrackingFields.TMP_TIPO_TEMPO;
                    if (DomainFieldTracked(policy, "TemposLogisticos", operation, recordId, "TMP_TIPO_CARGA"))
                        mask |= TemposLogisticosTrackingFields.TMP_TIPO_CARGA;
                    if (DomainFieldTracked(policy, "TemposLogisticos", operation, recordId, "TMP_TEMPO_MEDIO_UNITARIO"))
                        mask |= TemposLogisticosTrackingFields.TMP_TEMPO_MEDIO_UNITARIO;
                    if (DomainFieldTracked(policy, "TemposLogisticos", operation, recordId, "CLI_ID"))
                        mask |= TemposLogisticosTrackingFields.CLI_ID;
                    if (DomainFieldTracked(policy, "TemposLogisticos", operation, recordId, "TenantID"))
                        mask |= TemposLogisticosTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "TemposLogisticos", operation, recordId, "Deleted"))
                        mask |= TemposLogisticosTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "TemposLogisticos", operation, recordId, "Changed"))
                        mask |= TemposLogisticosTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "TemposLogisticos", operation, recordId, "UserId"))
                        mask |= TemposLogisticosTrackingFields.UserId;
                    return mask;
                }

                private ulong GetTesteFisicoMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "TesteFisico", operation, recordId, "Id"))
                        mask |= TesteFisicoTrackingFields.Id;
                    if (DomainFieldTracked(policy, "TesteFisico", operation, recordId, "TES_ID"))
                        mask |= TesteFisicoTrackingFields.TES_ID;
                    if (DomainFieldTracked(policy, "TesteFisico", operation, recordId, "ITE_ID"))
                        mask |= TesteFisicoTrackingFields.ITE_ID;
                    if (DomainFieldTracked(policy, "TesteFisico", operation, recordId, "USR_ID"))
                        mask |= TesteFisicoTrackingFields.USR_ID;
                    if (DomainFieldTracked(policy, "TesteFisico", operation, recordId, "TES_NOME_TECNICO"))
                        mask |= TesteFisicoTrackingFields.TES_NOME_TECNICO;
                    if (DomainFieldTracked(policy, "TesteFisico", operation, recordId, "TES_AMOSTRA"))
                        mask |= TesteFisicoTrackingFields.TES_AMOSTRA;
                    if (DomainFieldTracked(policy, "TesteFisico", operation, recordId, "TES_OP"))
                        mask |= TesteFisicoTrackingFields.TES_OP;
                    if (DomainFieldTracked(policy, "TesteFisico", operation, recordId, "TES_VALOR_NUMERICO"))
                        mask |= TesteFisicoTrackingFields.TES_VALOR_NUMERICO;
                    if (DomainFieldTracked(policy, "TesteFisico", operation, recordId, "TES_VALOR_DATA"))
                        mask |= TesteFisicoTrackingFields.TES_VALOR_DATA;
                    if (DomainFieldTracked(policy, "TesteFisico", operation, recordId, "TES_VALOR_TEXTO"))
                        mask |= TesteFisicoTrackingFields.TES_VALOR_TEXTO;
                    if (DomainFieldTracked(policy, "TesteFisico", operation, recordId, "TES_EMISSAO"))
                        mask |= TesteFisicoTrackingFields.TES_EMISSAO;
                    if (DomainFieldTracked(policy, "TesteFisico", operation, recordId, "ORD_ID"))
                        mask |= TesteFisicoTrackingFields.ORD_ID;
                    if (DomainFieldTracked(policy, "TesteFisico", operation, recordId, "PRO_ID"))
                        mask |= TesteFisicoTrackingFields.PRO_ID;
                    if (DomainFieldTracked(policy, "TesteFisico", operation, recordId, "MAQ_ID"))
                        mask |= TesteFisicoTrackingFields.MAQ_ID;
                    if (DomainFieldTracked(policy, "TesteFisico", operation, recordId, "FPR_SEQ_REPETICAO"))
                        mask |= TesteFisicoTrackingFields.FPR_SEQ_REPETICAO;
                    if (DomainFieldTracked(policy, "TesteFisico", operation, recordId, "FPR_SEQ_TRANFORMACAO"))
                        mask |= TesteFisicoTrackingFields.FPR_SEQ_TRANFORMACAO;
                    if (DomainFieldTracked(policy, "TesteFisico", operation, recordId, "TenantID"))
                        mask |= TesteFisicoTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "TesteFisico", operation, recordId, "Deleted"))
                        mask |= TesteFisicoTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "TesteFisico", operation, recordId, "Changed"))
                        mask |= TesteFisicoTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "TesteFisico", operation, recordId, "UserId"))
                        mask |= TesteFisicoTrackingFields.UserId;
                    return mask;
                }

                private ulong GetTipoABNTMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "TipoABNT", operation, recordId, "Id"))
                        mask |= TipoABNTTrackingFields.Id;
                    if (DomainFieldTracked(policy, "TipoABNT", operation, recordId, "ABN_ID"))
                        mask |= TipoABNTTrackingFields.ABN_ID;
                    if (DomainFieldTracked(policy, "TipoABNT", operation, recordId, "ABN_DESCRICAO"))
                        mask |= TipoABNTTrackingFields.ABN_DESCRICAO;
                    if (DomainFieldTracked(policy, "TipoABNT", operation, recordId, "TenantID"))
                        mask |= TipoABNTTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "TipoABNT", operation, recordId, "Deleted"))
                        mask |= TipoABNTTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "TipoABNT", operation, recordId, "Changed"))
                        mask |= TipoABNTTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "TipoABNT", operation, recordId, "UserId"))
                        mask |= TipoABNTTrackingFields.UserId;
                    return mask;
                }

                private ulong GetTipoCarroceriaMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "TipoCarroceria", operation, recordId, "Id"))
                        mask |= TipoCarroceriaTrackingFields.Id;
                    if (DomainFieldTracked(policy, "TipoCarroceria", operation, recordId, "TCA_ID"))
                        mask |= TipoCarroceriaTrackingFields.TCA_ID;
                    if (DomainFieldTracked(policy, "TipoCarroceria", operation, recordId, "TCA_DESCRICAO"))
                        mask |= TipoCarroceriaTrackingFields.TCA_DESCRICAO;
                    if (DomainFieldTracked(policy, "TipoCarroceria", operation, recordId, "TenantID"))
                        mask |= TipoCarroceriaTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "TipoCarroceria", operation, recordId, "Deleted"))
                        mask |= TipoCarroceriaTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "TipoCarroceria", operation, recordId, "Changed"))
                        mask |= TipoCarroceriaTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "TipoCarroceria", operation, recordId, "UserId"))
                        mask |= TipoCarroceriaTrackingFields.UserId;
                    return mask;
                }

                private ulong GetTipoDispositivoMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "TipoDispositivo", operation, recordId, "Id"))
                        mask |= TipoDispositivoTrackingFields.Id;
                    if (DomainFieldTracked(policy, "TipoDispositivo", operation, recordId, "TDI_ID"))
                        mask |= TipoDispositivoTrackingFields.TDI_ID;
                    if (DomainFieldTracked(policy, "TipoDispositivo", operation, recordId, "TDI_DESCRICAO"))
                        mask |= TipoDispositivoTrackingFields.TDI_DESCRICAO;
                    if (DomainFieldTracked(policy, "TipoDispositivo", operation, recordId, "TenantID"))
                        mask |= TipoDispositivoTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "TipoDispositivo", operation, recordId, "Deleted"))
                        mask |= TipoDispositivoTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "TipoDispositivo", operation, recordId, "Changed"))
                        mask |= TipoDispositivoTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "TipoDispositivo", operation, recordId, "UserId"))
                        mask |= TipoDispositivoTrackingFields.UserId;
                    return mask;
                }

                private ulong GetTipoDispositivoMaquinaMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "TipoDispositivoMaquina", operation, recordId, "Id"))
                        mask |= TipoDispositivoMaquinaTrackingFields.Id;
                    if (DomainFieldTracked(policy, "TipoDispositivoMaquina", operation, recordId, "TDI_ID"))
                        mask |= TipoDispositivoMaquinaTrackingFields.TDI_ID;
                    if (DomainFieldTracked(policy, "TipoDispositivoMaquina", operation, recordId, "MAQ_ID"))
                        mask |= TipoDispositivoMaquinaTrackingFields.MAQ_ID;
                    if (DomainFieldTracked(policy, "TipoDispositivoMaquina", operation, recordId, "TenantID"))
                        mask |= TipoDispositivoMaquinaTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "TipoDispositivoMaquina", operation, recordId, "Deleted"))
                        mask |= TipoDispositivoMaquinaTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "TipoDispositivoMaquina", operation, recordId, "Changed"))
                        mask |= TipoDispositivoMaquinaTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "TipoDispositivoMaquina", operation, recordId, "UserId"))
                        mask |= TipoDispositivoMaquinaTrackingFields.UserId;
                    return mask;
                }

                private ulong GetTipoInspecaoItensMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "TipoInspecaoItens", operation, recordId, "Id"))
                        mask |= TipoInspecaoItensTrackingFields.Id;
                    if (DomainFieldTracked(policy, "TipoInspecaoItens", operation, recordId, "TII_ID"))
                        mask |= TipoInspecaoItensTrackingFields.TII_ID;
                    if (DomainFieldTracked(policy, "TipoInspecaoItens", operation, recordId, "TIV_ID"))
                        mask |= TipoInspecaoItensTrackingFields.TIV_ID;
                    if (DomainFieldTracked(policy, "TipoInspecaoItens", operation, recordId, "ITI_ID"))
                        mask |= TipoInspecaoItensTrackingFields.ITI_ID;
                    if (DomainFieldTracked(policy, "TipoInspecaoItens", operation, recordId, "TenantID"))
                        mask |= TipoInspecaoItensTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "TipoInspecaoItens", operation, recordId, "Deleted"))
                        mask |= TipoInspecaoItensTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "TipoInspecaoItens", operation, recordId, "Changed"))
                        mask |= TipoInspecaoItensTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "TipoInspecaoItens", operation, recordId, "UserId"))
                        mask |= TipoInspecaoItensTrackingFields.UserId;
                    return mask;
                }

                private ulong GetTipoInspecaoVisualMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "TipoInspecaoVisual", operation, recordId, "Id"))
                        mask |= TipoInspecaoVisualTrackingFields.Id;
                    if (DomainFieldTracked(policy, "TipoInspecaoVisual", operation, recordId, "TIV_ID"))
                        mask |= TipoInspecaoVisualTrackingFields.TIV_ID;
                    if (DomainFieldTracked(policy, "TipoInspecaoVisual", operation, recordId, "TenantID"))
                        mask |= TipoInspecaoVisualTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "TipoInspecaoVisual", operation, recordId, "Deleted"))
                        mask |= TipoInspecaoVisualTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "TipoInspecaoVisual", operation, recordId, "Changed"))
                        mask |= TipoInspecaoVisualTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "TipoInspecaoVisual", operation, recordId, "UserId"))
                        mask |= TipoInspecaoVisualTrackingFields.UserId;
                    if (DomainFieldTracked(policy, "TipoInspecaoVisual", operation, recordId, "TIV_NOME"))
                        mask |= TipoInspecaoVisualTrackingFields.TIV_NOME;
                    if (DomainFieldTracked(policy, "TipoInspecaoVisual", operation, recordId, "TIV_DESCRICAO"))
                        mask |= TipoInspecaoVisualTrackingFields.TIV_DESCRICAO;
                    if (DomainFieldTracked(policy, "TipoInspecaoVisual", operation, recordId, "TIV_FECHAMENTO"))
                        mask |= TipoInspecaoVisualTrackingFields.TIV_FECHAMENTO;
                    if (DomainFieldTracked(policy, "TipoInspecaoVisual", operation, recordId, "TIV_AMOSTRA_ALEATORIA"))
                        mask |= TipoInspecaoVisualTrackingFields.TIV_AMOSTRA_ALEATORIA;
                    if (DomainFieldTracked(policy, "TipoInspecaoVisual", operation, recordId, "TIV_N_AMOSTRAS"))
                        mask |= TipoInspecaoVisualTrackingFields.TIV_N_AMOSTRAS;
                    if (DomainFieldTracked(policy, "TipoInspecaoVisual", operation, recordId, "TIV_MEDIDA"))
                        mask |= TipoInspecaoVisualTrackingFields.TIV_MEDIDA;
                    if (DomainFieldTracked(policy, "TipoInspecaoVisual", operation, recordId, "TIV_ESPECIFICACAO"))
                        mask |= TipoInspecaoVisualTrackingFields.TIV_ESPECIFICACAO;
                    if (DomainFieldTracked(policy, "TipoInspecaoVisual", operation, recordId, "TIV_TOL_MAIS"))
                        mask |= TipoInspecaoVisualTrackingFields.TIV_TOL_MAIS;
                    if (DomainFieldTracked(policy, "TipoInspecaoVisual", operation, recordId, "TIV_TOL_MENOS"))
                        mask |= TipoInspecaoVisualTrackingFields.TIV_TOL_MENOS;
                    return mask;
                }

                private ulong GetTipoMovimentoEstoqueMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "TipoMovimentoEstoque", operation, recordId, "TIP_ID"))
                        mask |= TipoMovimentoEstoqueTrackingFields.TIP_ID;
                    if (DomainFieldTracked(policy, "TipoMovimentoEstoque", operation, recordId, "TIP_DESCRICAO"))
                        mask |= TipoMovimentoEstoqueTrackingFields.TIP_DESCRICAO;
                    if (DomainFieldTracked(policy, "TipoMovimentoEstoque", operation, recordId, "TIP_TYPE"))
                        mask |= TipoMovimentoEstoqueTrackingFields.TIP_TYPE;
                    if (DomainFieldTracked(policy, "TipoMovimentoEstoque", operation, recordId, "SPR"))
                        mask |= TipoMovimentoEstoqueTrackingFields.SPR;
                    if (DomainFieldTracked(policy, "TipoMovimentoEstoque", operation, recordId, "TenantID"))
                        mask |= TipoMovimentoEstoqueTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "TipoMovimentoEstoque", operation, recordId, "Deleted"))
                        mask |= TipoMovimentoEstoqueTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "TipoMovimentoEstoque", operation, recordId, "Changed"))
                        mask |= TipoMovimentoEstoqueTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "TipoMovimentoEstoque", operation, recordId, "UserId"))
                        mask |= TipoMovimentoEstoqueTrackingFields.UserId;
                    return mask;
                }

                private ulong GetTipoOcorrenciaMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "TipoOcorrencia", operation, recordId, "Id"))
                        mask |= TipoOcorrenciaTrackingFields.Id;
                    if (DomainFieldTracked(policy, "TipoOcorrencia", operation, recordId, "Descricao"))
                        mask |= TipoOcorrenciaTrackingFields.Descricao;
                    if (DomainFieldTracked(policy, "TipoOcorrencia", operation, recordId, "Spr"))
                        mask |= TipoOcorrenciaTrackingFields.Spr;
                    if (DomainFieldTracked(policy, "TipoOcorrencia", operation, recordId, "TenantID"))
                        mask |= TipoOcorrenciaTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "TipoOcorrencia", operation, recordId, "Deleted"))
                        mask |= TipoOcorrenciaTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "TipoOcorrencia", operation, recordId, "Changed"))
                        mask |= TipoOcorrenciaTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "TipoOcorrencia", operation, recordId, "UserId"))
                        mask |= TipoOcorrenciaTrackingFields.UserId;
                    return mask;
                }

                private ulong GetTipoTesteMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "TipoTeste", operation, recordId, "TT_ESPECIFICACAO"))
                        mask |= TipoTesteTrackingFields.TT_ESPECIFICACAO;
                    if (DomainFieldTracked(policy, "TipoTeste", operation, recordId, "TT_ORIGEM_ESPECIFICACAO"))
                        mask |= TipoTesteTrackingFields.TT_ORIGEM_ESPECIFICACAO;
                    if (DomainFieldTracked(policy, "TipoTeste", operation, recordId, "TT_IMPRIME_NO_LAUDO"))
                        mask |= TipoTesteTrackingFields.TT_IMPRIME_NO_LAUDO;
                    if (DomainFieldTracked(policy, "TipoTeste", operation, recordId, "TenantID"))
                        mask |= TipoTesteTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "TipoTeste", operation, recordId, "Deleted"))
                        mask |= TipoTesteTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "TipoTeste", operation, recordId, "Changed"))
                        mask |= TipoTesteTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "TipoTeste", operation, recordId, "UserId"))
                        mask |= TipoTesteTrackingFields.UserId;
                    if (DomainFieldTracked(policy, "TipoTeste", operation, recordId, "TT_ID"))
                        mask |= TipoTesteTrackingFields.TT_ID;
                    if (DomainFieldTracked(policy, "TipoTeste", operation, recordId, "TT_NOME"))
                        mask |= TipoTesteTrackingFields.TT_NOME;
                    if (DomainFieldTracked(policy, "TipoTeste", operation, recordId, "TT_DESC"))
                        mask |= TipoTesteTrackingFields.TT_DESC;
                    if (DomainFieldTracked(policy, "TipoTeste", operation, recordId, "TT_TOL_MAIS"))
                        mask |= TipoTesteTrackingFields.TT_TOL_MAIS;
                    if (DomainFieldTracked(policy, "TipoTeste", operation, recordId, "TT_TOL_MENOS"))
                        mask |= TipoTesteTrackingFields.TT_TOL_MENOS;
                    if (DomainFieldTracked(policy, "TipoTeste", operation, recordId, "TT_NORMA"))
                        mask |= TipoTesteTrackingFields.TT_NORMA;
                    if (DomainFieldTracked(policy, "TipoTeste", operation, recordId, "TT_INICIO_PROCESSO"))
                        mask |= TipoTesteTrackingFields.TT_INICIO_PROCESSO;
                    if (DomainFieldTracked(policy, "TipoTeste", operation, recordId, "TA_ID"))
                        mask |= TipoTesteTrackingFields.TA_ID;
                    if (DomainFieldTracked(policy, "TipoTeste", operation, recordId, "UNI_ID"))
                        mask |= TipoTesteTrackingFields.UNI_ID;
                    if (DomainFieldTracked(policy, "TipoTeste", operation, recordId, "TT_N_AMOSTRAS_P_TESTE"))
                        mask |= TipoTesteTrackingFields.TT_N_AMOSTRAS_P_TESTE;
                    if (DomainFieldTracked(policy, "TipoTeste", operation, recordId, "TT_MAX_DEF_CRITICO"))
                        mask |= TipoTesteTrackingFields.TT_MAX_DEF_CRITICO;
                    if (DomainFieldTracked(policy, "TipoTeste", operation, recordId, "TT_MAX_DEF_GRAVE"))
                        mask |= TipoTesteTrackingFields.TT_MAX_DEF_GRAVE;
                    return mask;
                }

                private ulong GetTipoVeiculoMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "TipoVeiculo", operation, recordId, "Id"))
                        mask |= TipoVeiculoTrackingFields.Id;
                    if (DomainFieldTracked(policy, "TipoVeiculo", operation, recordId, "TIP_ID"))
                        mask |= TipoVeiculoTrackingFields.TIP_ID;
                    if (DomainFieldTracked(policy, "TipoVeiculo", operation, recordId, "TIP_DESCRICAO"))
                        mask |= TipoVeiculoTrackingFields.TIP_DESCRICAO;
                    if (DomainFieldTracked(policy, "TipoVeiculo", operation, recordId, "TIP_QTD_DISPONIVEL"))
                        mask |= TipoVeiculoTrackingFields.TIP_QTD_DISPONIVEL;
                    if (DomainFieldTracked(policy, "TipoVeiculo", operation, recordId, "TIP_VALOR_KM"))
                        mask |= TipoVeiculoTrackingFields.TIP_VALOR_KM;
                    if (DomainFieldTracked(policy, "TipoVeiculo", operation, recordId, "TIP_VALOR_DIARIA"))
                        mask |= TipoVeiculoTrackingFields.TIP_VALOR_DIARIA;
                    if (DomainFieldTracked(policy, "TipoVeiculo", operation, recordId, "TIP_VALOR_AJUDANTE"))
                        mask |= TipoVeiculoTrackingFields.TIP_VALOR_AJUDANTE;
                    if (DomainFieldTracked(policy, "TipoVeiculo", operation, recordId, "TIP_QTD_EIXOS"))
                        mask |= TipoVeiculoTrackingFields.TIP_QTD_EIXOS;
                    if (DomainFieldTracked(policy, "TipoVeiculo", operation, recordId, "TIP_VELOCIDADE_MEDIA"))
                        mask |= TipoVeiculoTrackingFields.TIP_VELOCIDADE_MEDIA;
                    if (DomainFieldTracked(policy, "TipoVeiculo", operation, recordId, "TIP_CAPACIDADE_ALTURA"))
                        mask |= TipoVeiculoTrackingFields.TIP_CAPACIDADE_ALTURA;
                    if (DomainFieldTracked(policy, "TipoVeiculo", operation, recordId, "TIP_CAPACIDADE_COMPRIMENTO"))
                        mask |= TipoVeiculoTrackingFields.TIP_CAPACIDADE_COMPRIMENTO;
                    if (DomainFieldTracked(policy, "TipoVeiculo", operation, recordId, "TIP_CAPACIDADE_LARGURA"))
                        mask |= TipoVeiculoTrackingFields.TIP_CAPACIDADE_LARGURA;
                    if (DomainFieldTracked(policy, "TipoVeiculo", operation, recordId, "TIP_CAPACIDADE_ALTURA_PESCOCO_E"))
                        mask |= TipoVeiculoTrackingFields.TIP_CAPACIDADE_ALTURA_PESCOCO_E;
                    if (DomainFieldTracked(policy, "TipoVeiculo", operation, recordId, "TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E"))
                        mask |= TipoVeiculoTrackingFields.TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E;
                    if (DomainFieldTracked(policy, "TipoVeiculo", operation, recordId, "TIP_CAPACIDADE_LARGURA_PESCOCO_E"))
                        mask |= TipoVeiculoTrackingFields.TIP_CAPACIDADE_LARGURA_PESCOCO_E;
                    if (DomainFieldTracked(policy, "TipoVeiculo", operation, recordId, "TIP_CAPACIDADE_ALTURA_PESCOCO_D"))
                        mask |= TipoVeiculoTrackingFields.TIP_CAPACIDADE_ALTURA_PESCOCO_D;
                    if (DomainFieldTracked(policy, "TipoVeiculo", operation, recordId, "TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D"))
                        mask |= TipoVeiculoTrackingFields.TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D;
                    if (DomainFieldTracked(policy, "TipoVeiculo", operation, recordId, "TIP_CAPACIDADE_LARGURA_PESCOCO_D"))
                        mask |= TipoVeiculoTrackingFields.TIP_CAPACIDADE_LARGURA_PESCOCO_D;
                    if (DomainFieldTracked(policy, "TipoVeiculo", operation, recordId, "TIP_CAPACIDADE_M3"))
                        mask |= TipoVeiculoTrackingFields.TIP_CAPACIDADE_M3;
                    if (DomainFieldTracked(policy, "TipoVeiculo", operation, recordId, "TenantID"))
                        mask |= TipoVeiculoTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "TipoVeiculo", operation, recordId, "Deleted"))
                        mask |= TipoVeiculoTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "TipoVeiculo", operation, recordId, "Changed"))
                        mask |= TipoVeiculoTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "TipoVeiculo", operation, recordId, "UserId"))
                        mask |= TipoVeiculoTrackingFields.UserId;
                    return mask;
                }

                private ulong GetVincoMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Vinco", operation, recordId, "VIN_ID"))
                        mask |= VincoTrackingFields.VIN_ID;
                    if (DomainFieldTracked(policy, "Vinco", operation, recordId, "VIN_DESCRICAO"))
                        mask |= VincoTrackingFields.VIN_DESCRICAO;
                    if (DomainFieldTracked(policy, "Vinco", operation, recordId, "VIN_ID_DESLOCAMENTO"))
                        mask |= VincoTrackingFields.VIN_ID_DESLOCAMENTO;
                    if (DomainFieldTracked(policy, "Vinco", operation, recordId, "TenantID"))
                        mask |= VincoTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Vinco", operation, recordId, "Deleted"))
                        mask |= VincoTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Vinco", operation, recordId, "Changed"))
                        mask |= VincoTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Vinco", operation, recordId, "UserId"))
                        mask |= VincoTrackingFields.UserId;
                    return mask;
                }

                private ulong GetTiposVincoGruposProdutosMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "TiposVincoGruposProdutos", operation, recordId, "Id"))
                        mask |= TiposVincoGruposProdutosTrackingFields.Id;
                    if (DomainFieldTracked(policy, "TiposVincoGruposProdutos", operation, recordId, "Id2"))
                        mask |= TiposVincoGruposProdutosTrackingFields.Id2;
                    if (DomainFieldTracked(policy, "TiposVincoGruposProdutos", operation, recordId, "TenantID"))
                        mask |= TiposVincoGruposProdutosTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "TiposVincoGruposProdutos", operation, recordId, "Deleted"))
                        mask |= TiposVincoGruposProdutosTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "TiposVincoGruposProdutos", operation, recordId, "Changed"))
                        mask |= TiposVincoGruposProdutosTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "TiposVincoGruposProdutos", operation, recordId, "UserId"))
                        mask |= TiposVincoGruposProdutosTrackingFields.UserId;
                    return mask;
                }

                private ulong GetTiposVincoOndasMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "TiposVincoOndas", operation, recordId, "Id"))
                        mask |= TiposVincoOndasTrackingFields.Id;
                    if (DomainFieldTracked(policy, "TiposVincoOndas", operation, recordId, "Id2"))
                        mask |= TiposVincoOndasTrackingFields.Id2;
                    if (DomainFieldTracked(policy, "TiposVincoOndas", operation, recordId, "TenantID"))
                        mask |= TiposVincoOndasTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "TiposVincoOndas", operation, recordId, "Deleted"))
                        mask |= TiposVincoOndasTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "TiposVincoOndas", operation, recordId, "Changed"))
                        mask |= TiposVincoOndasTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "TiposVincoOndas", operation, recordId, "UserId"))
                        mask |= TiposVincoOndasTrackingFields.UserId;
                    return mask;
                }

                private ulong GetTiposVincoProdutosMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "TiposVincoProdutos", operation, recordId, "Id"))
                        mask |= TiposVincoProdutosTrackingFields.Id;
                    if (DomainFieldTracked(policy, "TiposVincoProdutos", operation, recordId, "Id2"))
                        mask |= TiposVincoProdutosTrackingFields.Id2;
                    if (DomainFieldTracked(policy, "TiposVincoProdutos", operation, recordId, "TenantID"))
                        mask |= TiposVincoProdutosTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "TiposVincoProdutos", operation, recordId, "Deleted"))
                        mask |= TiposVincoProdutosTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "TiposVincoProdutos", operation, recordId, "Changed"))
                        mask |= TiposVincoProdutosTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "TiposVincoProdutos", operation, recordId, "UserId"))
                        mask |= TiposVincoProdutosTrackingFields.UserId;
                    return mask;
                }

                private ulong GetTransportadoraMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Transportadora", operation, recordId, "Id"))
                        mask |= TransportadoraTrackingFields.Id;
                    if (DomainFieldTracked(policy, "Transportadora", operation, recordId, "TRA_ID"))
                        mask |= TransportadoraTrackingFields.TRA_ID;
                    if (DomainFieldTracked(policy, "Transportadora", operation, recordId, "TRA_NOME"))
                        mask |= TransportadoraTrackingFields.TRA_NOME;
                    if (DomainFieldTracked(policy, "Transportadora", operation, recordId, "TRA_EMAIL"))
                        mask |= TransportadoraTrackingFields.TRA_EMAIL;
                    if (DomainFieldTracked(policy, "Transportadora", operation, recordId, "TRA_RESPONSAVEL"))
                        mask |= TransportadoraTrackingFields.TRA_RESPONSAVEL;
                    if (DomainFieldTracked(policy, "Transportadora", operation, recordId, "TRA_FONE"))
                        mask |= TransportadoraTrackingFields.TRA_FONE;
                    if (DomainFieldTracked(policy, "Transportadora", operation, recordId, "TRA_ID_INTEGRACAO"))
                        mask |= TransportadoraTrackingFields.TRA_ID_INTEGRACAO;
                    if (DomainFieldTracked(policy, "Transportadora", operation, recordId, "TRA_ID_INTEGRACAO_ERP"))
                        mask |= TransportadoraTrackingFields.TRA_ID_INTEGRACAO_ERP;
                    if (DomainFieldTracked(policy, "Transportadora", operation, recordId, "TenantID"))
                        mask |= TransportadoraTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Transportadora", operation, recordId, "Deleted"))
                        mask |= TransportadoraTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Transportadora", operation, recordId, "Changed"))
                        mask |= TransportadoraTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Transportadora", operation, recordId, "UserId"))
                        mask |= TransportadoraTrackingFields.UserId;
                    return mask;
                }

                private ulong GetTurmaMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Turma", operation, recordId, "Id"))
                        mask |= TurmaTrackingFields.Id;
                    if (DomainFieldTracked(policy, "Turma", operation, recordId, "Descricao"))
                        mask |= TurmaTrackingFields.Descricao;
                    if (DomainFieldTracked(policy, "Turma", operation, recordId, "TURM_HORA_INI_DIA1"))
                        mask |= TurmaTrackingFields.TURM_HORA_INI_DIA1;
                    if (DomainFieldTracked(policy, "Turma", operation, recordId, "TURM_HORA_FIM_DIA1"))
                        mask |= TurmaTrackingFields.TURM_HORA_FIM_DIA1;
                    if (DomainFieldTracked(policy, "Turma", operation, recordId, "TURM_HORA_INI_DIA2"))
                        mask |= TurmaTrackingFields.TURM_HORA_INI_DIA2;
                    if (DomainFieldTracked(policy, "Turma", operation, recordId, "TURM_HORA_FIM_DIA2"))
                        mask |= TurmaTrackingFields.TURM_HORA_FIM_DIA2;
                    if (DomainFieldTracked(policy, "Turma", operation, recordId, "TURM_HORA_INI_DIA3"))
                        mask |= TurmaTrackingFields.TURM_HORA_INI_DIA3;
                    if (DomainFieldTracked(policy, "Turma", operation, recordId, "TURM_HORA_FIM_DIA3"))
                        mask |= TurmaTrackingFields.TURM_HORA_FIM_DIA3;
                    if (DomainFieldTracked(policy, "Turma", operation, recordId, "TURM_HORA_INI_DIA4"))
                        mask |= TurmaTrackingFields.TURM_HORA_INI_DIA4;
                    if (DomainFieldTracked(policy, "Turma", operation, recordId, "TURM_HORA_FIM_DIA4"))
                        mask |= TurmaTrackingFields.TURM_HORA_FIM_DIA4;
                    if (DomainFieldTracked(policy, "Turma", operation, recordId, "TURM_HORA_INI_DIA5"))
                        mask |= TurmaTrackingFields.TURM_HORA_INI_DIA5;
                    if (DomainFieldTracked(policy, "Turma", operation, recordId, "TURM_HORA_FIM_DIA5"))
                        mask |= TurmaTrackingFields.TURM_HORA_FIM_DIA5;
                    if (DomainFieldTracked(policy, "Turma", operation, recordId, "TURM_HORA_INI_DIA6"))
                        mask |= TurmaTrackingFields.TURM_HORA_INI_DIA6;
                    if (DomainFieldTracked(policy, "Turma", operation, recordId, "TURM_HORA_FIM_DIA6"))
                        mask |= TurmaTrackingFields.TURM_HORA_FIM_DIA6;
                    if (DomainFieldTracked(policy, "Turma", operation, recordId, "TURM_HORA_INI_DIA7"))
                        mask |= TurmaTrackingFields.TURM_HORA_INI_DIA7;
                    if (DomainFieldTracked(policy, "Turma", operation, recordId, "TURM_HORA_FIM_DIA7"))
                        mask |= TurmaTrackingFields.TURM_HORA_FIM_DIA7;
                    if (DomainFieldTracked(policy, "Turma", operation, recordId, "TenantID"))
                        mask |= TurmaTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Turma", operation, recordId, "Deleted"))
                        mask |= TurmaTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Turma", operation, recordId, "Changed"))
                        mask |= TurmaTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Turma", operation, recordId, "UserId"))
                        mask |= TurmaTrackingFields.UserId;
                    return mask;
                }

                private ulong GetTurnoMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Turno", operation, recordId, "Id"))
                        mask |= TurnoTrackingFields.Id;
                    if (DomainFieldTracked(policy, "Turno", operation, recordId, "Descricao"))
                        mask |= TurnoTrackingFields.Descricao;
                    if (DomainFieldTracked(policy, "Turno", operation, recordId, "TURN_PRIORIDADE"))
                        mask |= TurnoTrackingFields.TURN_PRIORIDADE;
                    if (DomainFieldTracked(policy, "Turno", operation, recordId, "TURN_HORA_INI_DIA1"))
                        mask |= TurnoTrackingFields.TURN_HORA_INI_DIA1;
                    if (DomainFieldTracked(policy, "Turno", operation, recordId, "TURN_HORA_FIM_DIA1"))
                        mask |= TurnoTrackingFields.TURN_HORA_FIM_DIA1;
                    if (DomainFieldTracked(policy, "Turno", operation, recordId, "TURN_HORA_INI_DIA2"))
                        mask |= TurnoTrackingFields.TURN_HORA_INI_DIA2;
                    if (DomainFieldTracked(policy, "Turno", operation, recordId, "TURN_HORA_FIM_DIA2"))
                        mask |= TurnoTrackingFields.TURN_HORA_FIM_DIA2;
                    if (DomainFieldTracked(policy, "Turno", operation, recordId, "TURN_HORA_INI_DIA3"))
                        mask |= TurnoTrackingFields.TURN_HORA_INI_DIA3;
                    if (DomainFieldTracked(policy, "Turno", operation, recordId, "TURN_HORA_FIM_DIA3"))
                        mask |= TurnoTrackingFields.TURN_HORA_FIM_DIA3;
                    if (DomainFieldTracked(policy, "Turno", operation, recordId, "TURN_HORA_INI_DIA4"))
                        mask |= TurnoTrackingFields.TURN_HORA_INI_DIA4;
                    if (DomainFieldTracked(policy, "Turno", operation, recordId, "TURN_HORA_FIM_DIA4"))
                        mask |= TurnoTrackingFields.TURN_HORA_FIM_DIA4;
                    if (DomainFieldTracked(policy, "Turno", operation, recordId, "TURN_HORA_INI_DIA5"))
                        mask |= TurnoTrackingFields.TURN_HORA_INI_DIA5;
                    if (DomainFieldTracked(policy, "Turno", operation, recordId, "TURN_HORA_FIM_DIA5"))
                        mask |= TurnoTrackingFields.TURN_HORA_FIM_DIA5;
                    if (DomainFieldTracked(policy, "Turno", operation, recordId, "TURN_HORA_INI_DIA6"))
                        mask |= TurnoTrackingFields.TURN_HORA_INI_DIA6;
                    if (DomainFieldTracked(policy, "Turno", operation, recordId, "TURN_HORA_FIM_DIA6"))
                        mask |= TurnoTrackingFields.TURN_HORA_FIM_DIA6;
                    if (DomainFieldTracked(policy, "Turno", operation, recordId, "TURN_HORA_INI_DIA7"))
                        mask |= TurnoTrackingFields.TURN_HORA_INI_DIA7;
                    if (DomainFieldTracked(policy, "Turno", operation, recordId, "TURN_HORA_FIM_DIA7"))
                        mask |= TurnoTrackingFields.TURN_HORA_FIM_DIA7;
                    if (DomainFieldTracked(policy, "Turno", operation, recordId, "TenantID"))
                        mask |= TurnoTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Turno", operation, recordId, "Deleted"))
                        mask |= TurnoTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Turno", operation, recordId, "Changed"))
                        mask |= TurnoTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Turno", operation, recordId, "UserId"))
                        mask |= TurnoTrackingFields.UserId;
                    return mask;
                }

                private ulong GetUnidadeMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Unidade", operation, recordId, "UNI_ID"))
                        mask |= UnidadeTrackingFields.UNI_ID;
                    if (DomainFieldTracked(policy, "Unidade", operation, recordId, "DEESCRICAO"))
                        mask |= UnidadeTrackingFields.DEESCRICAO;
                    if (DomainFieldTracked(policy, "Unidade", operation, recordId, "UN"))
                        mask |= UnidadeTrackingFields.UN;
                    if (DomainFieldTracked(policy, "Unidade", operation, recordId, "TenantID"))
                        mask |= UnidadeTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Unidade", operation, recordId, "Deleted"))
                        mask |= UnidadeTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Unidade", operation, recordId, "Changed"))
                        mask |= UnidadeTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Unidade", operation, recordId, "UserId"))
                        mask |= UnidadeTrackingFields.UserId;
                    return mask;
                }

                private ulong GetUnidadeMedidaMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "UnidadeMedida", operation, recordId, "UNI_ID"))
                        mask |= UnidadeMedidaTrackingFields.UNI_ID;
                    if (DomainFieldTracked(policy, "UnidadeMedida", operation, recordId, "UNI_DESCRICAO"))
                        mask |= UnidadeMedidaTrackingFields.UNI_DESCRICAO;
                    if (DomainFieldTracked(policy, "UnidadeMedida", operation, recordId, "UNI_ESCALA_TEMPO"))
                        mask |= UnidadeMedidaTrackingFields.UNI_ESCALA_TEMPO;
                    if (DomainFieldTracked(policy, "UnidadeMedida", operation, recordId, "TenantID"))
                        mask |= UnidadeMedidaTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "UnidadeMedida", operation, recordId, "Deleted"))
                        mask |= UnidadeMedidaTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "UnidadeMedida", operation, recordId, "Changed"))
                        mask |= UnidadeMedidaTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "UnidadeMedida", operation, recordId, "UserId"))
                        mask |= UnidadeMedidaTrackingFields.UserId;
                    return mask;
                }

                private ulong GetUniuserMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Uniuser", operation, recordId, "USERGRU_ID"))
                        mask |= UniuserTrackingFields.USERGRU_ID;
                    if (DomainFieldTracked(policy, "Uniuser", operation, recordId, "UNI_ID"))
                        mask |= UniuserTrackingFields.UNI_ID;
                    if (DomainFieldTracked(policy, "Uniuser", operation, recordId, "USE_ID"))
                        mask |= UniuserTrackingFields.USE_ID;
                    if (DomainFieldTracked(policy, "Uniuser", operation, recordId, "TenantID"))
                        mask |= UniuserTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Uniuser", operation, recordId, "Deleted"))
                        mask |= UniuserTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Uniuser", operation, recordId, "Changed"))
                        mask |= UniuserTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Uniuser", operation, recordId, "UserId"))
                        mask |= UniuserTrackingFields.UserId;
                    return mask;
                }

                private ulong GetT_USER_GRUPOMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "T_USER_GRUPO", operation, recordId, "Id"))
                        mask |= T_USER_GRUPOTrackingFields.Id;
                    if (DomainFieldTracked(policy, "T_USER_GRUPO", operation, recordId, "GRU_ID"))
                        mask |= T_USER_GRUPOTrackingFields.GRU_ID;
                    if (DomainFieldTracked(policy, "T_USER_GRUPO", operation, recordId, "ID_USUARIO"))
                        mask |= T_USER_GRUPOTrackingFields.ID_USUARIO;
                    if (DomainFieldTracked(policy, "T_USER_GRUPO", operation, recordId, "TenantID"))
                        mask |= T_USER_GRUPOTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "T_USER_GRUPO", operation, recordId, "Deleted"))
                        mask |= T_USER_GRUPOTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "T_USER_GRUPO", operation, recordId, "Changed"))
                        mask |= T_USER_GRUPOTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "T_USER_GRUPO", operation, recordId, "UserId"))
                        mask |= T_USER_GRUPOTrackingFields.UserId;
                    return mask;
                }

                private ulong GetUsuarioMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Usuario", operation, recordId, "USE_ID"))
                        mask |= UsuarioTrackingFields.USE_ID;
                    if (DomainFieldTracked(policy, "Usuario", operation, recordId, "USE_NOME"))
                        mask |= UsuarioTrackingFields.USE_NOME;
                    if (DomainFieldTracked(policy, "Usuario", operation, recordId, "USE_EMAIL"))
                        mask |= UsuarioTrackingFields.USE_EMAIL;
                    if (DomainFieldTracked(policy, "Usuario", operation, recordId, "USE_SENHA"))
                        mask |= UsuarioTrackingFields.USE_SENHA;
                    if (DomainFieldTracked(policy, "Usuario", operation, recordId, "TURM_ID"))
                        mask |= UsuarioTrackingFields.TURM_ID;
                    if (DomainFieldTracked(policy, "Usuario", operation, recordId, "USE_ATIVO"))
                        mask |= UsuarioTrackingFields.USE_ATIVO;
                    if (DomainFieldTracked(policy, "Usuario", operation, recordId, "USE_CODERP"))
                        mask |= UsuarioTrackingFields.USE_CODERP;
                    if (DomainFieldTracked(policy, "Usuario", operation, recordId, "TenantID"))
                        mask |= UsuarioTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Usuario", operation, recordId, "Deleted"))
                        mask |= UsuarioTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Usuario", operation, recordId, "Changed"))
                        mask |= UsuarioTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Usuario", operation, recordId, "UserId"))
                        mask |= UsuarioTrackingFields.UserId;
                    return mask;
                }

                private ulong GetUsuarioObjetoControlavelMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "UsuarioObjetoControlavel", operation, recordId, "Id"))
                        mask |= UsuarioObjetoControlavelTrackingFields.Id;
                    if (DomainFieldTracked(policy, "UsuarioObjetoControlavel", operation, recordId, "USE_ID"))
                        mask |= UsuarioObjetoControlavelTrackingFields.USE_ID;
                    if (DomainFieldTracked(policy, "UsuarioObjetoControlavel", operation, recordId, "OBJ_ID"))
                        mask |= UsuarioObjetoControlavelTrackingFields.OBJ_ID;
                    if (DomainFieldTracked(policy, "UsuarioObjetoControlavel", operation, recordId, "USU_OBJETO_ACAO"))
                        mask |= UsuarioObjetoControlavelTrackingFields.USU_OBJETO_ACAO;
                    if (DomainFieldTracked(policy, "UsuarioObjetoControlavel", operation, recordId, "TenantID"))
                        mask |= UsuarioObjetoControlavelTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "UsuarioObjetoControlavel", operation, recordId, "Deleted"))
                        mask |= UsuarioObjetoControlavelTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "UsuarioObjetoControlavel", operation, recordId, "Changed"))
                        mask |= UsuarioObjetoControlavelTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "UsuarioObjetoControlavel", operation, recordId, "UserId"))
                        mask |= UsuarioObjetoControlavelTrackingFields.UserId;
                    return mask;
                }

                private ulong GetUsuarioPerfilMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "UsuarioPerfil", operation, recordId, "Id"))
                        mask |= UsuarioPerfilTrackingFields.Id;
                    if (DomainFieldTracked(policy, "UsuarioPerfil", operation, recordId, "USE_ID"))
                        mask |= UsuarioPerfilTrackingFields.USE_ID;
                    if (DomainFieldTracked(policy, "UsuarioPerfil", operation, recordId, "PER_ID"))
                        mask |= UsuarioPerfilTrackingFields.PER_ID;
                    if (DomainFieldTracked(policy, "UsuarioPerfil", operation, recordId, "TenantID"))
                        mask |= UsuarioPerfilTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "UsuarioPerfil", operation, recordId, "Deleted"))
                        mask |= UsuarioPerfilTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "UsuarioPerfil", operation, recordId, "Changed"))
                        mask |= UsuarioPerfilTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "UsuarioPerfil", operation, recordId, "UserId"))
                        mask |= UsuarioPerfilTrackingFields.UserId;
                    return mask;
                }

                private ulong GetUsuariosCargaMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "UsuariosCarga", operation, recordId, "Id"))
                        mask |= UsuariosCargaTrackingFields.Id;
                    if (DomainFieldTracked(policy, "UsuariosCarga", operation, recordId, "USE_ID"))
                        mask |= UsuariosCargaTrackingFields.USE_ID;
                    if (DomainFieldTracked(policy, "UsuariosCarga", operation, recordId, "CAR_ID"))
                        mask |= UsuariosCargaTrackingFields.CAR_ID;
                    if (DomainFieldTracked(policy, "UsuariosCarga", operation, recordId, "RGO_ID"))
                        mask |= UsuariosCargaTrackingFields.RGO_ID;
                    if (DomainFieldTracked(policy, "UsuariosCarga", operation, recordId, "TenantID"))
                        mask |= UsuariosCargaTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "UsuariosCarga", operation, recordId, "Deleted"))
                        mask |= UsuariosCargaTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "UsuariosCarga", operation, recordId, "Changed"))
                        mask |= UsuariosCargaTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "UsuariosCarga", operation, recordId, "UserId"))
                        mask |= UsuariosCargaTrackingFields.UserId;
                    return mask;
                }

                private ulong GetVariavelMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Variavel", operation, recordId, "Id"))
                        mask |= VariavelTrackingFields.Id;
                    if (DomainFieldTracked(policy, "Variavel", operation, recordId, "VAR_ID"))
                        mask |= VariavelTrackingFields.VAR_ID;
                    if (DomainFieldTracked(policy, "Variavel", operation, recordId, "VAR_DESCRICAO"))
                        mask |= VariavelTrackingFields.VAR_DESCRICAO;
                    if (DomainFieldTracked(policy, "Variavel", operation, recordId, "CON_ID"))
                        mask |= VariavelTrackingFields.CON_ID;
                    if (DomainFieldTracked(policy, "Variavel", operation, recordId, "VAR_MODO"))
                        mask |= VariavelTrackingFields.VAR_MODO;
                    if (DomainFieldTracked(policy, "Variavel", operation, recordId, "TenantID"))
                        mask |= VariavelTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Variavel", operation, recordId, "Deleted"))
                        mask |= VariavelTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Variavel", operation, recordId, "Changed"))
                        mask |= VariavelTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Variavel", operation, recordId, "UserId"))
                        mask |= VariavelTrackingFields.UserId;
                    return mask;
                }

                private ulong GetVariavelPlotagemMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "VariavelPlotagem", operation, recordId, "Id"))
                        mask |= VariavelPlotagemTrackingFields.Id;
                    if (DomainFieldTracked(policy, "VariavelPlotagem", operation, recordId, "VAR_ID"))
                        mask |= VariavelPlotagemTrackingFields.VAR_ID;
                    if (DomainFieldTracked(policy, "VariavelPlotagem", operation, recordId, "PLO_ID"))
                        mask |= VariavelPlotagemTrackingFields.PLO_ID;
                    if (DomainFieldTracked(policy, "VariavelPlotagem", operation, recordId, "TenantID"))
                        mask |= VariavelPlotagemTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "VariavelPlotagem", operation, recordId, "Deleted"))
                        mask |= VariavelPlotagemTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "VariavelPlotagem", operation, recordId, "Changed"))
                        mask |= VariavelPlotagemTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "VariavelPlotagem", operation, recordId, "UserId"))
                        mask |= VariavelPlotagemTrackingFields.UserId;
                    return mask;
                }

                private ulong GetVeiculoMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Veiculo", operation, recordId, "Id"))
                        mask |= VeiculoTrackingFields.Id;
                    if (DomainFieldTracked(policy, "Veiculo", operation, recordId, "VEI_PLACA"))
                        mask |= VeiculoTrackingFields.VEI_PLACA;
                    if (DomainFieldTracked(policy, "Veiculo", operation, recordId, "TIP_ID"))
                        mask |= VeiculoTrackingFields.TIP_ID;
                    if (DomainFieldTracked(policy, "Veiculo", operation, recordId, "VEI_CAPACIDADE_M3"))
                        mask |= VeiculoTrackingFields.VEI_CAPACIDADE_M3;
                    if (DomainFieldTracked(policy, "Veiculo", operation, recordId, "VEI_CAPACIDADE_LARGURA"))
                        mask |= VeiculoTrackingFields.VEI_CAPACIDADE_LARGURA;
                    if (DomainFieldTracked(policy, "Veiculo", operation, recordId, "VEI_CAPACIDADE_COMPRIMENTO"))
                        mask |= VeiculoTrackingFields.VEI_CAPACIDADE_COMPRIMENTO;
                    if (DomainFieldTracked(policy, "Veiculo", operation, recordId, "VEI_CAPACIDADE_ALTURA"))
                        mask |= VeiculoTrackingFields.VEI_CAPACIDADE_ALTURA;
                    if (DomainFieldTracked(policy, "Veiculo", operation, recordId, "VEI_MODELO"))
                        mask |= VeiculoTrackingFields.VEI_MODELO;
                    if (DomainFieldTracked(policy, "Veiculo", operation, recordId, "VEI_NOME_MOTORISTA"))
                        mask |= VeiculoTrackingFields.VEI_NOME_MOTORISTA;
                    if (DomainFieldTracked(policy, "Veiculo", operation, recordId, "VEI_DADOS_CONTATO"))
                        mask |= VeiculoTrackingFields.VEI_DADOS_CONTATO;
                    if (DomainFieldTracked(policy, "Veiculo", operation, recordId, "VEI_CPF_MOTORISTA"))
                        mask |= VeiculoTrackingFields.VEI_CPF_MOTORISTA;
                    if (DomainFieldTracked(policy, "Veiculo", operation, recordId, "TCA_ID"))
                        mask |= VeiculoTrackingFields.TCA_ID;
                    if (DomainFieldTracked(policy, "Veiculo", operation, recordId, "VEI_EMISSAO"))
                        mask |= VeiculoTrackingFields.VEI_EMISSAO;
                    if (DomainFieldTracked(policy, "Veiculo", operation, recordId, "VEI_VENCIMENTO"))
                        mask |= VeiculoTrackingFields.VEI_VENCIMENTO;
                    if (DomainFieldTracked(policy, "Veiculo", operation, recordId, "VEI_STATUS"))
                        mask |= VeiculoTrackingFields.VEI_STATUS;
                    if (DomainFieldTracked(policy, "Veiculo", operation, recordId, "TenantID"))
                        mask |= VeiculoTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Veiculo", operation, recordId, "Deleted"))
                        mask |= VeiculoTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Veiculo", operation, recordId, "Changed"))
                        mask |= VeiculoTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Veiculo", operation, recordId, "UserId"))
                        mask |= VeiculoTrackingFields.UserId;
                    return mask;
                }

                private ulong GetVersaoCustoMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "VersaoCusto", operation, recordId, "Id"))
                        mask |= VersaoCustoTrackingFields.Id;
                    if (DomainFieldTracked(policy, "VersaoCusto", operation, recordId, "VER_ID"))
                        mask |= VersaoCustoTrackingFields.VER_ID;
                    if (DomainFieldTracked(policy, "VersaoCusto", operation, recordId, "VER_STATUS"))
                        mask |= VersaoCustoTrackingFields.VER_STATUS;
                    if (DomainFieldTracked(policy, "VersaoCusto", operation, recordId, "VER_OBS"))
                        mask |= VersaoCustoTrackingFields.VER_OBS;
                    if (DomainFieldTracked(policy, "VersaoCusto", operation, recordId, "TenantID"))
                        mask |= VersaoCustoTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "VersaoCusto", operation, recordId, "Deleted"))
                        mask |= VersaoCustoTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "VersaoCusto", operation, recordId, "Changed"))
                        mask |= VersaoCustoTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "VersaoCusto", operation, recordId, "UserId"))
                        mask |= VersaoCustoTrackingFields.UserId;
                    return mask;
                }

                private ulong GetVerssaoCustoMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "VerssaoCusto", operation, recordId, "Id"))
                        mask |= VerssaoCustoTrackingFields.Id;
                    if (DomainFieldTracked(policy, "VerssaoCusto", operation, recordId, "VER_ID"))
                        mask |= VerssaoCustoTrackingFields.VER_ID;
                    if (DomainFieldTracked(policy, "VerssaoCusto", operation, recordId, "VER_STATUS"))
                        mask |= VerssaoCustoTrackingFields.VER_STATUS;
                    if (DomainFieldTracked(policy, "VerssaoCusto", operation, recordId, "VER_DATA_VERSSAO_CUSTO"))
                        mask |= VerssaoCustoTrackingFields.VER_DATA_VERSSAO_CUSTO;
                    if (DomainFieldTracked(policy, "VerssaoCusto", operation, recordId, "VER_OBS"))
                        mask |= VerssaoCustoTrackingFields.VER_OBS;
                    if (DomainFieldTracked(policy, "VerssaoCusto", operation, recordId, "TenantID"))
                        mask |= VerssaoCustoTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "VerssaoCusto", operation, recordId, "Deleted"))
                        mask |= VerssaoCustoTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "VerssaoCusto", operation, recordId, "Changed"))
                        mask |= VerssaoCustoTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "VerssaoCusto", operation, recordId, "UserId"))
                        mask |= VerssaoCustoTrackingFields.UserId;
                    return mask;
                }

                private ulong GetCabvisaoMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Cabvisao", operation, recordId, "CAB_ID"))
                        mask |= CabvisaoTrackingFields.CAB_ID;
                    if (DomainFieldTracked(policy, "Cabvisao", operation, recordId, "CAB_DESC"))
                        mask |= CabvisaoTrackingFields.CAB_DESC;
                    if (DomainFieldTracked(policy, "Cabvisao", operation, recordId, "CAB_STATUS"))
                        mask |= CabvisaoTrackingFields.CAB_STATUS;
                    if (DomainFieldTracked(policy, "Cabvisao", operation, recordId, "USE_ID"))
                        mask |= CabvisaoTrackingFields.USE_ID;
                    if (DomainFieldTracked(policy, "Cabvisao", operation, recordId, "TenantID"))
                        mask |= CabvisaoTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Cabvisao", operation, recordId, "Deleted"))
                        mask |= CabvisaoTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Cabvisao", operation, recordId, "Changed"))
                        mask |= CabvisaoTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Cabvisao", operation, recordId, "UserId"))
                        mask |= CabvisaoTrackingFields.UserId;
                    return mask;
                }

                private ulong GetMovimentosMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Movimentos", operation, recordId, "MOV_ID"))
                        mask |= MovimentosTrackingFields.MOV_ID;
                    if (DomainFieldTracked(policy, "Movimentos", operation, recordId, "MOV_DATA"))
                        mask |= MovimentosTrackingFields.MOV_DATA;
                    if (DomainFieldTracked(policy, "Movimentos", operation, recordId, "MOV_VALOR"))
                        mask |= MovimentosTrackingFields.MOV_VALOR;
                    if (DomainFieldTracked(policy, "Movimentos", operation, recordId, "MOV_PLAID"))
                        mask |= MovimentosTrackingFields.MOV_PLAID;
                    if (DomainFieldTracked(policy, "Movimentos", operation, recordId, "MOV_UNID"))
                        mask |= MovimentosTrackingFields.MOV_UNID;
                    if (DomainFieldTracked(policy, "Movimentos", operation, recordId, "Tr_Unidade_UNI_ID"))
                        mask |= MovimentosTrackingFields.Tr_Unidade_UNI_ID;
                    if (DomainFieldTracked(policy, "Movimentos", operation, recordId, "TenantID"))
                        mask |= MovimentosTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Movimentos", operation, recordId, "Deleted"))
                        mask |= MovimentosTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Movimentos", operation, recordId, "Changed"))
                        mask |= MovimentosTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Movimentos", operation, recordId, "UserId"))
                        mask |= MovimentosTrackingFields.UserId;
                    return mask;
                }

                private ulong GetPlanocontasMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Planocontas", operation, recordId, "PLA_ID"))
                        mask |= PlanocontasTrackingFields.PLA_ID;
                    if (DomainFieldTracked(policy, "Planocontas", operation, recordId, "PLA_CODIGO"))
                        mask |= PlanocontasTrackingFields.PLA_CODIGO;
                    if (DomainFieldTracked(policy, "Planocontas", operation, recordId, "PLA_DESCRICAO"))
                        mask |= PlanocontasTrackingFields.PLA_DESCRICAO;
                    if (DomainFieldTracked(policy, "Planocontas", operation, recordId, "PLA_TIPO"))
                        mask |= PlanocontasTrackingFields.PLA_TIPO;
                    if (DomainFieldTracked(policy, "Planocontas", operation, recordId, "PLA_NATUREZA"))
                        mask |= PlanocontasTrackingFields.PLA_NATUREZA;
                    if (DomainFieldTracked(policy, "Planocontas", operation, recordId, "TenantID"))
                        mask |= PlanocontasTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Planocontas", operation, recordId, "Deleted"))
                        mask |= PlanocontasTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Planocontas", operation, recordId, "Changed"))
                        mask |= PlanocontasTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Planocontas", operation, recordId, "UserId"))
                        mask |= PlanocontasTrackingFields.UserId;
                    return mask;
                }

                private ulong GetUnidade_UnidadeMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Unidade_Unidade", operation, recordId, "UNI_ID"))
                        mask |= Unidade_UnidadeTrackingFields.UNI_ID;
                    if (DomainFieldTracked(policy, "Unidade_Unidade", operation, recordId, "UNI_DESCRICAO"))
                        mask |= Unidade_UnidadeTrackingFields.UNI_DESCRICAO;
                    if (DomainFieldTracked(policy, "Unidade_Unidade", operation, recordId, "TenantID"))
                        mask |= Unidade_UnidadeTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Unidade_Unidade", operation, recordId, "Deleted"))
                        mask |= Unidade_UnidadeTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Unidade_Unidade", operation, recordId, "Changed"))
                        mask |= Unidade_UnidadeTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Unidade_Unidade", operation, recordId, "UserId"))
                        mask |= Unidade_UnidadeTrackingFields.UserId;
                    return mask;
                }

                private ulong GetVisoesMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Visoes", operation, recordId, "VIS_ID"))
                        mask |= VisoesTrackingFields.VIS_ID;
                    if (DomainFieldTracked(policy, "Visoes", operation, recordId, "VIS_PLANID"))
                        mask |= VisoesTrackingFields.VIS_PLANID;
                    if (DomainFieldTracked(policy, "Visoes", operation, recordId, "VIS_FORMULA"))
                        mask |= VisoesTrackingFields.VIS_FORMULA;
                    if (DomainFieldTracked(policy, "Visoes", operation, recordId, "CAB_ID"))
                        mask |= VisoesTrackingFields.CAB_ID;
                    if (DomainFieldTracked(policy, "Visoes", operation, recordId, "TenantID"))
                        mask |= VisoesTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Visoes", operation, recordId, "Deleted"))
                        mask |= VisoesTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Visoes", operation, recordId, "Changed"))
                        mask |= VisoesTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Visoes", operation, recordId, "UserId"))
                        mask |= VisoesTrackingFields.UserId;
                    return mask;
                }

                private ulong GetRelatoriosMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "Relatorios", operation, recordId, "REL_ID"))
                        mask |= RelatoriosTrackingFields.REL_ID;
                    if (DomainFieldTracked(policy, "Relatorios", operation, recordId, "REL_NOME_RELATORIO"))
                        mask |= RelatoriosTrackingFields.REL_NOME_RELATORIO;
                    if (DomainFieldTracked(policy, "Relatorios", operation, recordId, "REL_NOME_CAMPO"))
                        mask |= RelatoriosTrackingFields.REL_NOME_CAMPO;
                    if (DomainFieldTracked(policy, "Relatorios", operation, recordId, "REL_TIPO_CAMPO"))
                        mask |= RelatoriosTrackingFields.REL_TIPO_CAMPO;
                    if (DomainFieldTracked(policy, "Relatorios", operation, recordId, "REL_POS_X"))
                        mask |= RelatoriosTrackingFields.REL_POS_X;
                    if (DomainFieldTracked(policy, "Relatorios", operation, recordId, "REL_POS_Y"))
                        mask |= RelatoriosTrackingFields.REL_POS_Y;
                    if (DomainFieldTracked(policy, "Relatorios", operation, recordId, "REL_TAMANHO_FONTE"))
                        mask |= RelatoriosTrackingFields.REL_TAMANHO_FONTE;
                    if (DomainFieldTracked(policy, "Relatorios", operation, recordId, "TenantID"))
                        mask |= RelatoriosTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "Relatorios", operation, recordId, "Deleted"))
                        mask |= RelatoriosTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "Relatorios", operation, recordId, "Changed"))
                        mask |= RelatoriosTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "Relatorios", operation, recordId, "UserId"))
                        mask |= RelatoriosTrackingFields.UserId;
                    return mask;
                }

                private ulong GetInspecaoVisualMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "InspecaoVisual", operation, recordId, "IPV_ID"))
                        mask |= InspecaoVisualTrackingFields.IPV_ID;
                    if (DomainFieldTracked(policy, "InspecaoVisual", operation, recordId, "IPV_VALOR"))
                        mask |= InspecaoVisualTrackingFields.IPV_VALOR;
                    if (DomainFieldTracked(policy, "InspecaoVisual", operation, recordId, "IPV_ID_OPERADOR"))
                        mask |= InspecaoVisualTrackingFields.IPV_ID_OPERADOR;
                    if (DomainFieldTracked(policy, "InspecaoVisual", operation, recordId, "IPV_ID_LIBERACAO"))
                        mask |= InspecaoVisualTrackingFields.IPV_ID_LIBERACAO;
                    if (DomainFieldTracked(policy, "InspecaoVisual", operation, recordId, "IPV_OBS"))
                        mask |= InspecaoVisualTrackingFields.IPV_OBS;
                    if (DomainFieldTracked(policy, "InspecaoVisual", operation, recordId, "IPV_DATA_COLETA"))
                        mask |= InspecaoVisualTrackingFields.IPV_DATA_COLETA;
                    if (DomainFieldTracked(policy, "InspecaoVisual", operation, recordId, "IPV_DATA_AVAL"))
                        mask |= InspecaoVisualTrackingFields.IPV_DATA_AVAL;
                    if (DomainFieldTracked(policy, "InspecaoVisual", operation, recordId, "TIV_ID"))
                        mask |= InspecaoVisualTrackingFields.TIV_ID;
                    if (DomainFieldTracked(policy, "InspecaoVisual", operation, recordId, "TURN_ID"))
                        mask |= InspecaoVisualTrackingFields.TURN_ID;
                    if (DomainFieldTracked(policy, "InspecaoVisual", operation, recordId, "TURM_ID"))
                        mask |= InspecaoVisualTrackingFields.TURM_ID;
                    if (DomainFieldTracked(policy, "InspecaoVisual", operation, recordId, "ORD_ID"))
                        mask |= InspecaoVisualTrackingFields.ORD_ID;
                    if (DomainFieldTracked(policy, "InspecaoVisual", operation, recordId, "ROT_PRO_ID"))
                        mask |= InspecaoVisualTrackingFields.ROT_PRO_ID;
                    if (DomainFieldTracked(policy, "InspecaoVisual", operation, recordId, "ROT_MAQ_ID"))
                        mask |= InspecaoVisualTrackingFields.ROT_MAQ_ID;
                    if (DomainFieldTracked(policy, "InspecaoVisual", operation, recordId, "ROT_SEQ_TRANSFORMACAO"))
                        mask |= InspecaoVisualTrackingFields.ROT_SEQ_TRANSFORMACAO;
                    if (DomainFieldTracked(policy, "InspecaoVisual", operation, recordId, "FPR_SEQ_REPETICAO"))
                        mask |= InspecaoVisualTrackingFields.FPR_SEQ_REPETICAO;
                    if (DomainFieldTracked(policy, "InspecaoVisual", operation, recordId, "IPV_STATUS_LIBERACAO"))
                        mask |= InspecaoVisualTrackingFields.IPV_STATUS_LIBERACAO;
                    if (DomainFieldTracked(policy, "InspecaoVisual", operation, recordId, "IPV_VALOR_MEDIDA"))
                        mask |= InspecaoVisualTrackingFields.IPV_VALOR_MEDIDA;
                    if (DomainFieldTracked(policy, "InspecaoVisual", operation, recordId, "TenantID"))
                        mask |= InspecaoVisualTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "InspecaoVisual", operation, recordId, "Deleted"))
                        mask |= InspecaoVisualTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "InspecaoVisual", operation, recordId, "Changed"))
                        mask |= InspecaoVisualTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "InspecaoVisual", operation, recordId, "UserId"))
                        mask |= InspecaoVisualTrackingFields.UserId;
                    return mask;
                }

                private ulong GetTemplateTipoInspecaoVisualMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "TemplateTipoInspecaoVisual", operation, recordId, "TTI_ID"))
                        mask |= TemplateTipoInspecaoVisualTrackingFields.TTI_ID;
                    if (DomainFieldTracked(policy, "TemplateTipoInspecaoVisual", operation, recordId, "TIV_ID"))
                        mask |= TemplateTipoInspecaoVisualTrackingFields.TIV_ID;
                    if (DomainFieldTracked(policy, "TemplateTipoInspecaoVisual", operation, recordId, "TEM_ID"))
                        mask |= TemplateTipoInspecaoVisualTrackingFields.TEM_ID;
                    if (DomainFieldTracked(policy, "TemplateTipoInspecaoVisual", operation, recordId, "TenantID"))
                        mask |= TemplateTipoInspecaoVisualTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "TemplateTipoInspecaoVisual", operation, recordId, "Deleted"))
                        mask |= TemplateTipoInspecaoVisualTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "TemplateTipoInspecaoVisual", operation, recordId, "Changed"))
                        mask |= TemplateTipoInspecaoVisualTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "TemplateTipoInspecaoVisual", operation, recordId, "UserId"))
                        mask |= TemplateTipoInspecaoVisualTrackingFields.UserId;
                    return mask;
                }

                private ulong GetTemplateTipoTesteMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "TemplateTipoTeste", operation, recordId, "TTT_ID"))
                        mask |= TemplateTipoTesteTrackingFields.TTT_ID;
                    if (DomainFieldTracked(policy, "TemplateTipoTeste", operation, recordId, "TT_ID"))
                        mask |= TemplateTipoTesteTrackingFields.TT_ID;
                    if (DomainFieldTracked(policy, "TemplateTipoTeste", operation, recordId, "TEM_ID"))
                        mask |= TemplateTipoTesteTrackingFields.TEM_ID;
                    if (DomainFieldTracked(policy, "TemplateTipoTeste", operation, recordId, "TenantID"))
                        mask |= TemplateTipoTesteTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "TemplateTipoTeste", operation, recordId, "Deleted"))
                        mask |= TemplateTipoTesteTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "TemplateTipoTeste", operation, recordId, "Changed"))
                        mask |= TemplateTipoTesteTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "TemplateTipoTeste", operation, recordId, "UserId"))
                        mask |= TemplateTipoTesteTrackingFields.UserId;
                    return mask;
                }

                private ulong GetTipoAvaliacaoMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "TipoAvaliacao", operation, recordId, "TA_ID"))
                        mask |= TipoAvaliacaoTrackingFields.TA_ID;
                    if (DomainFieldTracked(policy, "TipoAvaliacao", operation, recordId, "TA_DESC"))
                        mask |= TipoAvaliacaoTrackingFields.TA_DESC;
                    if (DomainFieldTracked(policy, "TipoAvaliacao", operation, recordId, "TenantID"))
                        mask |= TipoAvaliacaoTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "TipoAvaliacao", operation, recordId, "Deleted"))
                        mask |= TipoAvaliacaoTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "TipoAvaliacao", operation, recordId, "Changed"))
                        mask |= TipoAvaliacaoTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "TipoAvaliacao", operation, recordId, "UserId"))
                        mask |= TipoAvaliacaoTrackingFields.UserId;
                    return mask;
                }

                private ulong GetPedidoPlanejavelMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "PedidoPlanejavel", operation, recordId, "PedidoId"))
                        mask |= PedidoPlanejavelTrackingFields.PedidoId;
                    if (DomainFieldTracked(policy, "PedidoPlanejavel", operation, recordId, "ClienteId"))
                        mask |= PedidoPlanejavelTrackingFields.ClienteId;
                    if (DomainFieldTracked(policy, "PedidoPlanejavel", operation, recordId, "ClienteNome"))
                        mask |= PedidoPlanejavelTrackingFields.ClienteNome;
                    if (DomainFieldTracked(policy, "PedidoPlanejavel", operation, recordId, "Estado"))
                        mask |= PedidoPlanejavelTrackingFields.Estado;
                    if (DomainFieldTracked(policy, "PedidoPlanejavel", operation, recordId, "Municipio"))
                        mask |= PedidoPlanejavelTrackingFields.Municipio;
                    if (DomainFieldTracked(policy, "PedidoPlanejavel", operation, recordId, "Regiao"))
                        mask |= PedidoPlanejavelTrackingFields.Regiao;
                    if (DomainFieldTracked(policy, "PedidoPlanejavel", operation, recordId, "Bairro"))
                        mask |= PedidoPlanejavelTrackingFields.Bairro;
                    if (DomainFieldTracked(policy, "PedidoPlanejavel", operation, recordId, "RotaId"))
                        mask |= PedidoPlanejavelTrackingFields.RotaId;
                    if (DomainFieldTracked(policy, "PedidoPlanejavel", operation, recordId, "EmbarqueAlvo"))
                        mask |= PedidoPlanejavelTrackingFields.EmbarqueAlvo;
                    if (DomainFieldTracked(policy, "PedidoPlanejavel", operation, recordId, "DataEntregaDe"))
                        mask |= PedidoPlanejavelTrackingFields.DataEntregaDe;
                    if (DomainFieldTracked(policy, "PedidoPlanejavel", operation, recordId, "DataEntregaAte"))
                        mask |= PedidoPlanejavelTrackingFields.DataEntregaAte;
                    if (DomainFieldTracked(policy, "PedidoPlanejavel", operation, recordId, "Peso"))
                        mask |= PedidoPlanejavelTrackingFields.Peso;
                    if (DomainFieldTracked(policy, "PedidoPlanejavel", operation, recordId, "Volume"))
                        mask |= PedidoPlanejavelTrackingFields.Volume;
                    if (DomainFieldTracked(policy, "PedidoPlanejavel", operation, recordId, "SaldoAExpedir"))
                        mask |= PedidoPlanejavelTrackingFields.SaldoAExpedir;
                    if (DomainFieldTracked(policy, "PedidoPlanejavel", operation, recordId, "Status"))
                        mask |= PedidoPlanejavelTrackingFields.Status;
                    if (DomainFieldTracked(policy, "PedidoPlanejavel", operation, recordId, "CargaAtualId"))
                        mask |= PedidoPlanejavelTrackingFields.CargaAtualId;
                    if (DomainFieldTracked(policy, "PedidoPlanejavel", operation, recordId, "VersaoPlanejamento"))
                        mask |= PedidoPlanejavelTrackingFields.VersaoPlanejamento;
                    if (DomainFieldTracked(policy, "PedidoPlanejavel", operation, recordId, "AlertasResumo"))
                        mask |= PedidoPlanejavelTrackingFields.AlertasResumo;
                    return mask;
                }

                private ulong GetCargaPlanejavelMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "CargaPlanejavel", operation, recordId, "CargaId"))
                        mask |= CargaPlanejavelTrackingFields.CargaId;
                    if (DomainFieldTracked(policy, "CargaPlanejavel", operation, recordId, "Status"))
                        mask |= CargaPlanejavelTrackingFields.Status;
                    if (DomainFieldTracked(policy, "CargaPlanejavel", operation, recordId, "TransportadoraId"))
                        mask |= CargaPlanejavelTrackingFields.TransportadoraId;
                    if (DomainFieldTracked(policy, "CargaPlanejavel", operation, recordId, "VeiculoId"))
                        mask |= CargaPlanejavelTrackingFields.VeiculoId;
                    if (DomainFieldTracked(policy, "CargaPlanejavel", operation, recordId, "TipoVeiculoId"))
                        mask |= CargaPlanejavelTrackingFields.TipoVeiculoId;
                    if (DomainFieldTracked(policy, "CargaPlanejavel", operation, recordId, "PesoTeorico"))
                        mask |= CargaPlanejavelTrackingFields.PesoTeorico;
                    if (DomainFieldTracked(policy, "CargaPlanejavel", operation, recordId, "VolumeTeorico"))
                        mask |= CargaPlanejavelTrackingFields.VolumeTeorico;
                    if (DomainFieldTracked(policy, "CargaPlanejavel", operation, recordId, "InicioJanelaEmbarque"))
                        mask |= CargaPlanejavelTrackingFields.InicioJanelaEmbarque;
                    if (DomainFieldTracked(policy, "CargaPlanejavel", operation, recordId, "FimJanelaEmbarque"))
                        mask |= CargaPlanejavelTrackingFields.FimJanelaEmbarque;
                    if (DomainFieldTracked(policy, "CargaPlanejavel", operation, recordId, "EmbarqueAlvo"))
                        mask |= CargaPlanejavelTrackingFields.EmbarqueAlvo;
                    if (DomainFieldTracked(policy, "CargaPlanejavel", operation, recordId, "QuantidadePedidos"))
                        mask |= CargaPlanejavelTrackingFields.QuantidadePedidos;
                    if (DomainFieldTracked(policy, "CargaPlanejavel", operation, recordId, "AlertasResumo"))
                        mask |= CargaPlanejavelTrackingFields.AlertasResumo;
                    return mask;
                }

                private ulong GetOpcaoPlanejamentoTransporteMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "OpcaoPlanejamentoTransporte", operation, recordId, "OpcaoId"))
                        mask |= OpcaoPlanejamentoTransporteTrackingFields.OpcaoId;
                    if (DomainFieldTracked(policy, "OpcaoPlanejamentoTransporte", operation, recordId, "GrupoDecisaoId"))
                        mask |= OpcaoPlanejamentoTransporteTrackingFields.GrupoDecisaoId;
                    if (DomainFieldTracked(policy, "OpcaoPlanejamentoTransporte", operation, recordId, "Peso"))
                        mask |= OpcaoPlanejamentoTransporteTrackingFields.Peso;
                    if (DomainFieldTracked(policy, "OpcaoPlanejamentoTransporte", operation, recordId, "Volume"))
                        mask |= OpcaoPlanejamentoTransporteTrackingFields.Volume;
                    if (DomainFieldTracked(policy, "OpcaoPlanejamentoTransporte", operation, recordId, "CustoEstimado"))
                        mask |= OpcaoPlanejamentoTransporteTrackingFields.CustoEstimado;
                    if (DomainFieldTracked(policy, "OpcaoPlanejamentoTransporte", operation, recordId, "AderenciaCubagem"))
                        mask |= OpcaoPlanejamentoTransporteTrackingFields.AderenciaCubagem;
                    if (DomainFieldTracked(policy, "OpcaoPlanejamentoTransporte", operation, recordId, "AderenciaJanelaEntrega"))
                        mask |= OpcaoPlanejamentoTransporteTrackingFields.AderenciaJanelaEntrega;
                    if (DomainFieldTracked(policy, "OpcaoPlanejamentoTransporte", operation, recordId, "RiscoResumo"))
                        mask |= OpcaoPlanejamentoTransporteTrackingFields.RiscoResumo;
                    if (DomainFieldTracked(policy, "OpcaoPlanejamentoTransporte", operation, recordId, "PedidosResumo"))
                        mask |= OpcaoPlanejamentoTransporteTrackingFields.PedidosResumo;
                    if (DomainFieldTracked(policy, "OpcaoPlanejamentoTransporte", operation, recordId, "OpcoesConflitantesResumo"))
                        mask |= OpcaoPlanejamentoTransporteTrackingFields.OpcoesConflitantesResumo;
                    return mask;
                }

                private ulong GetCenarioPlanejamentoTransporteMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "CenarioPlanejamentoTransporte", operation, recordId, "CenarioId"))
                        mask |= CenarioPlanejamentoTransporteTrackingFields.CenarioId;
                    if (DomainFieldTracked(policy, "CenarioPlanejamentoTransporte", operation, recordId, "Descricao"))
                        mask |= CenarioPlanejamentoTransporteTrackingFields.Descricao;
                    if (DomainFieldTracked(policy, "CenarioPlanejamentoTransporte", operation, recordId, "Objetivo"))
                        mask |= CenarioPlanejamentoTransporteTrackingFields.Objetivo;
                    if (DomainFieldTracked(policy, "CenarioPlanejamentoTransporte", operation, recordId, "QuantidadeCargas"))
                        mask |= CenarioPlanejamentoTransporteTrackingFields.QuantidadeCargas;
                    if (DomainFieldTracked(policy, "CenarioPlanejamentoTransporte", operation, recordId, "QuantidadePedidosNaoAtendidos"))
                        mask |= CenarioPlanejamentoTransporteTrackingFields.QuantidadePedidosNaoAtendidos;
                    if (DomainFieldTracked(policy, "CenarioPlanejamentoTransporte", operation, recordId, "CustoTotal"))
                        mask |= CenarioPlanejamentoTransporteTrackingFields.CustoTotal;
                    if (DomainFieldTracked(policy, "CenarioPlanejamentoTransporte", operation, recordId, "AderenciaCubagem"))
                        mask |= CenarioPlanejamentoTransporteTrackingFields.AderenciaCubagem;
                    if (DomainFieldTracked(policy, "CenarioPlanejamentoTransporte", operation, recordId, "AtrasoPrevisto"))
                        mask |= CenarioPlanejamentoTransporteTrackingFields.AtrasoPrevisto;
                    if (DomainFieldTracked(policy, "CenarioPlanejamentoTransporte", operation, recordId, "AlertasResumo"))
                        mask |= CenarioPlanejamentoTransporteTrackingFields.AlertasResumo;
                    return mask;
                }

                private ulong GetExperienciaPlanejamentoTransporteMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "ExperienciaPlanejamentoTransporte", operation, recordId, "Id"))
                        mask |= ExperienciaPlanejamentoTransporteTrackingFields.Id;
                    if (DomainFieldTracked(policy, "ExperienciaPlanejamentoTransporte", operation, recordId, "Tipo"))
                        mask |= ExperienciaPlanejamentoTransporteTrackingFields.Tipo;
                    if (DomainFieldTracked(policy, "ExperienciaPlanejamentoTransporte", operation, recordId, "Referencia"))
                        mask |= ExperienciaPlanejamentoTransporteTrackingFields.Referencia;
                    if (DomainFieldTracked(policy, "ExperienciaPlanejamentoTransporte", operation, recordId, "PedidoId"))
                        mask |= ExperienciaPlanejamentoTransporteTrackingFields.PedidoId;
                    if (DomainFieldTracked(policy, "ExperienciaPlanejamentoTransporte", operation, recordId, "ClienteId"))
                        mask |= ExperienciaPlanejamentoTransporteTrackingFields.ClienteId;
                    if (DomainFieldTracked(policy, "ExperienciaPlanejamentoTransporte", operation, recordId, "Municipio"))
                        mask |= ExperienciaPlanejamentoTransporteTrackingFields.Municipio;
                    if (DomainFieldTracked(policy, "ExperienciaPlanejamentoTransporte", operation, recordId, "Regiao"))
                        mask |= ExperienciaPlanejamentoTransporteTrackingFields.Regiao;
                    if (DomainFieldTracked(policy, "ExperienciaPlanejamentoTransporte", operation, recordId, "RotaId"))
                        mask |= ExperienciaPlanejamentoTransporteTrackingFields.RotaId;
                    if (DomainFieldTracked(policy, "ExperienciaPlanejamentoTransporte", operation, recordId, "Peso"))
                        mask |= ExperienciaPlanejamentoTransporteTrackingFields.Peso;
                    if (DomainFieldTracked(policy, "ExperienciaPlanejamentoTransporte", operation, recordId, "Volume"))
                        mask |= ExperienciaPlanejamentoTransporteTrackingFields.Volume;
                    if (DomainFieldTracked(policy, "ExperienciaPlanejamentoTransporte", operation, recordId, "Observacao"))
                        mask |= ExperienciaPlanejamentoTransporteTrackingFields.Observacao;
                    if (DomainFieldTracked(policy, "ExperienciaPlanejamentoTransporte", operation, recordId, "CriadoEm"))
                        mask |= ExperienciaPlanejamentoTransporteTrackingFields.CriadoEm;
                    if (DomainFieldTracked(policy, "ExperienciaPlanejamentoTransporte", operation, recordId, "CriadoPor"))
                        mask |= ExperienciaPlanejamentoTransporteTrackingFields.CriadoPor;
                    if (DomainFieldTracked(policy, "ExperienciaPlanejamentoTransporte", operation, recordId, "TenantID"))
                        mask |= ExperienciaPlanejamentoTransporteTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "ExperienciaPlanejamentoTransporte", operation, recordId, "Deleted"))
                        mask |= ExperienciaPlanejamentoTransporteTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "ExperienciaPlanejamentoTransporte", operation, recordId, "Changed"))
                        mask |= ExperienciaPlanejamentoTransporteTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "ExperienciaPlanejamentoTransporte", operation, recordId, "UserId"))
                        mask |= ExperienciaPlanejamentoTransporteTrackingFields.UserId;
                    return mask;
                }

                private ulong GetyFileUploadMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "yFileUpload", operation, recordId, "Id"))
                        mask |= yFileUploadTrackingFields.Id;
                    if (DomainFieldTracked(policy, "yFileUpload", operation, recordId, "Type"))
                        mask |= yFileUploadTrackingFields.Type;
                    if (DomainFieldTracked(policy, "yFileUpload", operation, recordId, "Status"))
                        mask |= yFileUploadTrackingFields.Status;
                    if (DomainFieldTracked(policy, "yFileUpload", operation, recordId, "FilePath"))
                        mask |= yFileUploadTrackingFields.FilePath;
                    if (DomainFieldTracked(policy, "yFileUpload", operation, recordId, "FileSize"))
                        mask |= yFileUploadTrackingFields.FileSize;
                    if (DomainFieldTracked(policy, "yFileUpload", operation, recordId, "EntityType"))
                        mask |= yFileUploadTrackingFields.EntityType;
                    if (DomainFieldTracked(policy, "yFileUpload", operation, recordId, "EntityId"))
                        mask |= yFileUploadTrackingFields.EntityId;
                    if (DomainFieldTracked(policy, "yFileUpload", operation, recordId, "CreatedAt"))
                        mask |= yFileUploadTrackingFields.CreatedAt;
                    if (DomainFieldTracked(policy, "yFileUpload", operation, recordId, "CompletedAt"))
                        mask |= yFileUploadTrackingFields.CompletedAt;
                    if (DomainFieldTracked(policy, "yFileUpload", operation, recordId, "TenantID"))
                        mask |= yFileUploadTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "yFileUpload", operation, recordId, "Deleted"))
                        mask |= yFileUploadTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "yFileUpload", operation, recordId, "Changed"))
                        mask |= yFileUploadTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "yFileUpload", operation, recordId, "UserId"))
                        mask |= yFileUploadTrackingFields.UserId;
                    return mask;
                }

                private ulong GetySagaMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "ySaga", operation, recordId, "Id"))
                        mask |= ySagaTrackingFields.Id;
                    if (DomainFieldTracked(policy, "ySaga", operation, recordId, "CorrelationId"))
                        mask |= ySagaTrackingFields.CorrelationId;
                    if (DomainFieldTracked(policy, "ySaga", operation, recordId, "Type"))
                        mask |= ySagaTrackingFields.Type;
                    if (DomainFieldTracked(policy, "ySaga", operation, recordId, "Status"))
                        mask |= ySagaTrackingFields.Status;
                    if (DomainFieldTracked(policy, "ySaga", operation, recordId, "KeyCurrentStep"))
                        mask |= ySagaTrackingFields.KeyCurrentStep;
                    if (DomainFieldTracked(policy, "ySaga", operation, recordId, "CreatedAt"))
                        mask |= ySagaTrackingFields.CreatedAt;
                    if (DomainFieldTracked(policy, "ySaga", operation, recordId, "CompletedAt"))
                        mask |= ySagaTrackingFields.CompletedAt;
                    if (DomainFieldTracked(policy, "ySaga", operation, recordId, "EntityType"))
                        mask |= ySagaTrackingFields.EntityType;
                    if (DomainFieldTracked(policy, "ySaga", operation, recordId, "EntityId"))
                        mask |= ySagaTrackingFields.EntityId;
                    if (DomainFieldTracked(policy, "ySaga", operation, recordId, "NextExecutionAt"))
                        mask |= ySagaTrackingFields.NextExecutionAt;
                    if (DomainFieldTracked(policy, "ySaga", operation, recordId, "LockedAt"))
                        mask |= ySagaTrackingFields.LockedAt;
                    if (DomainFieldTracked(policy, "ySaga", operation, recordId, "LockedBy"))
                        mask |= ySagaTrackingFields.LockedBy;
                    if (DomainFieldTracked(policy, "ySaga", operation, recordId, "TenantID"))
                        mask |= ySagaTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "ySaga", operation, recordId, "Deleted"))
                        mask |= ySagaTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "ySaga", operation, recordId, "Changed"))
                        mask |= ySagaTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "ySaga", operation, recordId, "UserId"))
                        mask |= ySagaTrackingFields.UserId;
                    return mask;
                }

                private ulong GetySagaStepMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "ySagaStep", operation, recordId, "Id"))
                        mask |= ySagaStepTrackingFields.Id;
                    if (DomainFieldTracked(policy, "ySagaStep", operation, recordId, "SagaId"))
                        mask |= ySagaStepTrackingFields.SagaId;
                    if (DomainFieldTracked(policy, "ySagaStep", operation, recordId, "StepKey"))
                        mask |= ySagaStepTrackingFields.StepKey;
                    if (DomainFieldTracked(policy, "ySagaStep", operation, recordId, "IndexOrder"))
                        mask |= ySagaStepTrackingFields.IndexOrder;
                    if (DomainFieldTracked(policy, "ySagaStep", operation, recordId, "CorrelationId"))
                        mask |= ySagaStepTrackingFields.CorrelationId;
                    if (DomainFieldTracked(policy, "ySagaStep", operation, recordId, "Status"))
                        mask |= ySagaStepTrackingFields.Status;
                    if (DomainFieldTracked(policy, "ySagaStep", operation, recordId, "ExecutionCount"))
                        mask |= ySagaStepTrackingFields.ExecutionCount;
                    if (DomainFieldTracked(policy, "ySagaStep", operation, recordId, "LastExecutionAt"))
                        mask |= ySagaStepTrackingFields.LastExecutionAt;
                    if (DomainFieldTracked(policy, "ySagaStep", operation, recordId, "CompletedAt"))
                        mask |= ySagaStepTrackingFields.CompletedAt;
                    if (DomainFieldTracked(policy, "ySagaStep", operation, recordId, "ErrorMessage"))
                        mask |= ySagaStepTrackingFields.ErrorMessage;
                    if (DomainFieldTracked(policy, "ySagaStep", operation, recordId, "Payload"))
                        mask |= ySagaStepTrackingFields.Payload;
                    if (DomainFieldTracked(policy, "ySagaStep", operation, recordId, "RetryCount"))
                        mask |= ySagaStepTrackingFields.RetryCount;
                    if (DomainFieldTracked(policy, "ySagaStep", operation, recordId, "TenantID"))
                        mask |= ySagaStepTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "ySagaStep", operation, recordId, "Deleted"))
                        mask |= ySagaStepTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "ySagaStep", operation, recordId, "Changed"))
                        mask |= ySagaStepTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "ySagaStep", operation, recordId, "UserId"))
                        mask |= ySagaStepTrackingFields.UserId;
                    return mask;
                }

                private ulong GetyOutboxMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "Id"))
                        mask |= yOutboxTrackingFields.Id;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "MessageId"))
                        mask |= yOutboxTrackingFields.MessageId;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "Type"))
                        mask |= yOutboxTrackingFields.Type;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "EntityType"))
                        mask |= yOutboxTrackingFields.EntityType;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "EntityId"))
                        mask |= yOutboxTrackingFields.EntityId;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "CorrelationId"))
                        mask |= yOutboxTrackingFields.CorrelationId;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "Payload"))
                        mask |= yOutboxTrackingFields.Payload;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "Status"))
                        mask |= yOutboxTrackingFields.Status;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "TransportType"))
                        mask |= yOutboxTrackingFields.TransportType;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "TransportData"))
                        mask |= yOutboxTrackingFields.TransportData;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "CreatedAt"))
                        mask |= yOutboxTrackingFields.CreatedAt;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "SentAt"))
                        mask |= yOutboxTrackingFields.SentAt;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "RetryCount"))
                        mask |= yOutboxTrackingFields.RetryCount;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "LastError"))
                        mask |= yOutboxTrackingFields.LastError;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "ProcessingAt"))
                        mask |= yOutboxTrackingFields.ProcessingAt;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "NextAttemptAt"))
                        mask |= yOutboxTrackingFields.NextAttemptAt;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "SagaId"))
                        mask |= yOutboxTrackingFields.SagaId;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "SagaStepId"))
                        mask |= yOutboxTrackingFields.SagaStepId;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "TenantID"))
                        mask |= yOutboxTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "Deleted"))
                        mask |= yOutboxTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "Changed"))
                        mask |= yOutboxTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "yOutbox", operation, recordId, "UserId"))
                        mask |= yOutboxTrackingFields.UserId;
                    return mask;
                }

                private ulong GetyInboxMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "yInbox", operation, recordId, "Id"))
                        mask |= yInboxTrackingFields.Id;
                    if (DomainFieldTracked(policy, "yInbox", operation, recordId, "MessageId"))
                        mask |= yInboxTrackingFields.MessageId;
                    if (DomainFieldTracked(policy, "yInbox", operation, recordId, "Type"))
                        mask |= yInboxTrackingFields.Type;
                    if (DomainFieldTracked(policy, "yInbox", operation, recordId, "EntityType"))
                        mask |= yInboxTrackingFields.EntityType;
                    if (DomainFieldTracked(policy, "yInbox", operation, recordId, "EntityId"))
                        mask |= yInboxTrackingFields.EntityId;
                    if (DomainFieldTracked(policy, "yInbox", operation, recordId, "CorrelationId"))
                        mask |= yInboxTrackingFields.CorrelationId;
                    if (DomainFieldTracked(policy, "yInbox", operation, recordId, "Payload"))
                        mask |= yInboxTrackingFields.Payload;
                    if (DomainFieldTracked(policy, "yInbox", operation, recordId, "Status"))
                        mask |= yInboxTrackingFields.Status;
                    if (DomainFieldTracked(policy, "yInbox", operation, recordId, "CreatedAt"))
                        mask |= yInboxTrackingFields.CreatedAt;
                    if (DomainFieldTracked(policy, "yInbox", operation, recordId, "RetryCount"))
                        mask |= yInboxTrackingFields.RetryCount;
                    if (DomainFieldTracked(policy, "yInbox", operation, recordId, "LastError"))
                        mask |= yInboxTrackingFields.LastError;
                    if (DomainFieldTracked(policy, "yInbox", operation, recordId, "ProcessingAt"))
                        mask |= yInboxTrackingFields.ProcessingAt;
                    if (DomainFieldTracked(policy, "yInbox", operation, recordId, "NextAttemptAt"))
                        mask |= yInboxTrackingFields.NextAttemptAt;
                    if (DomainFieldTracked(policy, "yInbox", operation, recordId, "SagaId"))
                        mask |= yInboxTrackingFields.SagaId;
                    if (DomainFieldTracked(policy, "yInbox", operation, recordId, "SagaStepId"))
                        mask |= yInboxTrackingFields.SagaStepId;
                    if (DomainFieldTracked(policy, "yInbox", operation, recordId, "TenantID"))
                        mask |= yInboxTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "yInbox", operation, recordId, "Deleted"))
                        mask |= yInboxTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "yInbox", operation, recordId, "Changed"))
                        mask |= yInboxTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "yInbox", operation, recordId, "UserId"))
                        mask |= yInboxTrackingFields.UserId;
                    return mask;
                }

                private ulong GetyTokenMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "yToken", operation, recordId, "Id"))
                        mask |= yTokenTrackingFields.Id;
                    if (DomainFieldTracked(policy, "yToken", operation, recordId, "TokenHash"))
                        mask |= yTokenTrackingFields.TokenHash;
                    if (DomainFieldTracked(policy, "yToken", operation, recordId, "Description"))
                        mask |= yTokenTrackingFields.Description;
                    if (DomainFieldTracked(policy, "yToken", operation, recordId, "ConnectorKey"))
                        mask |= yTokenTrackingFields.ConnectorKey;
                    if (DomainFieldTracked(policy, "yToken", operation, recordId, "Active"))
                        mask |= yTokenTrackingFields.Active;
                    if (DomainFieldTracked(policy, "yToken", operation, recordId, "ValidUntil"))
                        mask |= yTokenTrackingFields.ValidUntil;
                    if (DomainFieldTracked(policy, "yToken", operation, recordId, "CreatedAt"))
                        mask |= yTokenTrackingFields.CreatedAt;
                    if (DomainFieldTracked(policy, "yToken", operation, recordId, "LastUsedAt"))
                        mask |= yTokenTrackingFields.LastUsedAt;
                    if (DomainFieldTracked(policy, "yToken", operation, recordId, "TenantID"))
                        mask |= yTokenTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "yToken", operation, recordId, "UserId"))
                        mask |= yTokenTrackingFields.UserId;
                    if (DomainFieldTracked(policy, "yToken", operation, recordId, "Deleted"))
                        mask |= yTokenTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "yToken", operation, recordId, "Changed"))
                        mask |= yTokenTrackingFields.Changed;
                    return mask;
                }

                private ulong GetyTenantMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "yTenant", operation, recordId, "Id"))
                        mask |= yTenantTrackingFields.Id;
                    if (DomainFieldTracked(policy, "yTenant", operation, recordId, "CnpjCpf"))
                        mask |= yTenantTrackingFields.CnpjCpf;
                    if (DomainFieldTracked(policy, "yTenant", operation, recordId, "Nome"))
                        mask |= yTenantTrackingFields.Nome;
                    if (DomainFieldTracked(policy, "yTenant", operation, recordId, "UserId"))
                        mask |= yTenantTrackingFields.UserId;
                    if (DomainFieldTracked(policy, "yTenant", operation, recordId, "Deleted"))
                        mask |= yTenantTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "yTenant", operation, recordId, "Changed"))
                        mask |= yTenantTrackingFields.Changed;
                    return mask;
                }

                private ulong GetyUserMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "yUser", operation, recordId, "Id"))
                        mask |= yUserTrackingFields.Id;
                    if (DomainFieldTracked(policy, "yUser", operation, recordId, "Nome"))
                        mask |= yUserTrackingFields.Nome;
                    if (DomainFieldTracked(policy, "yUser", operation, recordId, "Email"))
                        mask |= yUserTrackingFields.Email;
                    if (DomainFieldTracked(policy, "yUser", operation, recordId, "Senha"))
                        mask |= yUserTrackingFields.Senha;
                    if (DomainFieldTracked(policy, "yUser", operation, recordId, "TenantID"))
                        mask |= yUserTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "yUser", operation, recordId, "Deleted"))
                        mask |= yUserTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "yUser", operation, recordId, "Changed"))
                        mask |= yUserTrackingFields.Changed;
                    return mask;
                }

                private ulong GetyConfigArctetureMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "yConfigArcteture", operation, recordId, "Id"))
                        mask |= yConfigArctetureTrackingFields.Id;
                    if (DomainFieldTracked(policy, "yConfigArcteture", operation, recordId, "AuditTrackerActived"))
                        mask |= yConfigArctetureTrackingFields.AuditTrackerActived;
                    if (DomainFieldTracked(policy, "yConfigArcteture", operation, recordId, "AuditCRUDActived"))
                        mask |= yConfigArctetureTrackingFields.AuditCRUDActived;
                    if (DomainFieldTracked(policy, "yConfigArcteture", operation, recordId, "TenantID"))
                        mask |= yConfigArctetureTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "yConfigArcteture", operation, recordId, "Deleted"))
                        mask |= yConfigArctetureTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "yConfigArcteture", operation, recordId, "Changed"))
                        mask |= yConfigArctetureTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "yConfigArcteture", operation, recordId, "UserId"))
                        mask |= yConfigArctetureTrackingFields.UserId;
                    return mask;
                }

                private ulong GetyConfigNotificationMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "yConfigNotification", operation, recordId, "Id"))
                        mask |= yConfigNotificationTrackingFields.Id;
                    if (DomainFieldTracked(policy, "yConfigNotification", operation, recordId, "TenantID"))
                        mask |= yConfigNotificationTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "yConfigNotification", operation, recordId, "EmailSmtpClient"))
                        mask |= yConfigNotificationTrackingFields.EmailSmtpClient;
                    if (DomainFieldTracked(policy, "yConfigNotification", operation, recordId, "EmailPort"))
                        mask |= yConfigNotificationTrackingFields.EmailPort;
                    if (DomainFieldTracked(policy, "yConfigNotification", operation, recordId, "EmailUserName"))
                        mask |= yConfigNotificationTrackingFields.EmailUserName;
                    if (DomainFieldTracked(policy, "yConfigNotification", operation, recordId, "EmailPassword"))
                        mask |= yConfigNotificationTrackingFields.EmailPassword;
                    if (DomainFieldTracked(policy, "yConfigNotification", operation, recordId, "Deleted"))
                        mask |= yConfigNotificationTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "yConfigNotification", operation, recordId, "Changed"))
                        mask |= yConfigNotificationTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "yConfigNotification", operation, recordId, "UserId"))
                        mask |= yConfigNotificationTrackingFields.UserId;
                    return mask;
                }

                private ulong GetyPerfilMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "yPerfil", operation, recordId, "Id"))
                        mask |= yPerfilTrackingFields.Id;
                    if (DomainFieldTracked(policy, "yPerfil", operation, recordId, "Description"))
                        mask |= yPerfilTrackingFields.Description;
                    if (DomainFieldTracked(policy, "yPerfil", operation, recordId, "TenantID"))
                        mask |= yPerfilTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "yPerfil", operation, recordId, "Deleted"))
                        mask |= yPerfilTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "yPerfil", operation, recordId, "Changed"))
                        mask |= yPerfilTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "yPerfil", operation, recordId, "UserId"))
                        mask |= yPerfilTrackingFields.UserId;
                    return mask;
                }

                private ulong GetyModuleMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "yModule", operation, recordId, "Id"))
                        mask |= yModuleTrackingFields.Id;
                    if (DomainFieldTracked(policy, "yModule", operation, recordId, "Description"))
                        mask |= yModuleTrackingFields.Description;
                    return mask;
                }

                private ulong GetyTenantModuleMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "yTenantModule", operation, recordId, "Id"))
                        mask |= yTenantModuleTrackingFields.Id;
                    if (DomainFieldTracked(policy, "yTenantModule", operation, recordId, "ModuleId"))
                        mask |= yTenantModuleTrackingFields.ModuleId;
                    if (DomainFieldTracked(policy, "yTenantModule", operation, recordId, "TenantID"))
                        mask |= yTenantModuleTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "yTenantModule", operation, recordId, "ValidUntil"))
                        mask |= yTenantModuleTrackingFields.ValidUntil;
                    if (DomainFieldTracked(policy, "yTenantModule", operation, recordId, "Deleted"))
                        mask |= yTenantModuleTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "yTenantModule", operation, recordId, "Changed"))
                        mask |= yTenantModuleTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "yTenantModule", operation, recordId, "UserId"))
                        mask |= yTenantModuleTrackingFields.UserId;
                    return mask;
                }

                private ulong GetyUserModuleMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "yUserModule", operation, recordId, "Id"))
                        mask |= yUserModuleTrackingFields.Id;
                    if (DomainFieldTracked(policy, "yUserModule", operation, recordId, "ModuleId"))
                        mask |= yUserModuleTrackingFields.ModuleId;
                    if (DomainFieldTracked(policy, "yUserModule", operation, recordId, "UserId"))
                        mask |= yUserModuleTrackingFields.UserId;
                    if (DomainFieldTracked(policy, "yUserModule", operation, recordId, "ValidUntil"))
                        mask |= yUserModuleTrackingFields.ValidUntil;
                    if (DomainFieldTracked(policy, "yUserModule", operation, recordId, "TenantID"))
                        mask |= yUserModuleTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "yUserModule", operation, recordId, "Deleted"))
                        mask |= yUserModuleTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "yUserModule", operation, recordId, "Changed"))
                        mask |= yUserModuleTrackingFields.Changed;
                    return mask;
                }

                private ulong GetyGrantMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "yGrant", operation, recordId, "Id"))
                        mask |= yGrantTrackingFields.Id;
                    if (DomainFieldTracked(policy, "yGrant", operation, recordId, "Description"))
                        mask |= yGrantTrackingFields.Description;
                    if (DomainFieldTracked(policy, "yGrant", operation, recordId, "TenantID"))
                        mask |= yGrantTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "yGrant", operation, recordId, "Deleted"))
                        mask |= yGrantTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "yGrant", operation, recordId, "Changed"))
                        mask |= yGrantTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "yGrant", operation, recordId, "UserId"))
                        mask |= yGrantTrackingFields.UserId;
                    return mask;
                }

                private ulong GetyPerfilGrantMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "yPerfilGrant", operation, recordId, "Id"))
                        mask |= yPerfilGrantTrackingFields.Id;
                    if (DomainFieldTracked(policy, "yPerfilGrant", operation, recordId, "PerfilId"))
                        mask |= yPerfilGrantTrackingFields.PerfilId;
                    if (DomainFieldTracked(policy, "yPerfilGrant", operation, recordId, "GrantId"))
                        mask |= yPerfilGrantTrackingFields.GrantId;
                    if (DomainFieldTracked(policy, "yPerfilGrant", operation, recordId, "CanGrant"))
                        mask |= yPerfilGrantTrackingFields.CanGrant;
                    if (DomainFieldTracked(policy, "yPerfilGrant", operation, recordId, "CanCreate"))
                        mask |= yPerfilGrantTrackingFields.CanCreate;
                    if (DomainFieldTracked(policy, "yPerfilGrant", operation, recordId, "CanRead"))
                        mask |= yPerfilGrantTrackingFields.CanRead;
                    if (DomainFieldTracked(policy, "yPerfilGrant", operation, recordId, "CanUpdate"))
                        mask |= yPerfilGrantTrackingFields.CanUpdate;
                    if (DomainFieldTracked(policy, "yPerfilGrant", operation, recordId, "CanDelete"))
                        mask |= yPerfilGrantTrackingFields.CanDelete;
                    if (DomainFieldTracked(policy, "yPerfilGrant", operation, recordId, "ValidUntil"))
                        mask |= yPerfilGrantTrackingFields.ValidUntil;
                    if (DomainFieldTracked(policy, "yPerfilGrant", operation, recordId, "TenantID"))
                        mask |= yPerfilGrantTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "yPerfilGrant", operation, recordId, "Deleted"))
                        mask |= yPerfilGrantTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "yPerfilGrant", operation, recordId, "Changed"))
                        mask |= yPerfilGrantTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "yPerfilGrant", operation, recordId, "UserId"))
                        mask |= yPerfilGrantTrackingFields.UserId;
                    return mask;
                }

                private ulong GetyUserGrantMask(
                    OperationalLoggingPolicy policy,
                    string? operation,
                    string? recordId)
                {
                    ulong mask = 0UL;
                    if (DomainFieldTracked(policy, "yUserGrant", operation, recordId, "Id"))
                        mask |= yUserGrantTrackingFields.Id;
                    if (DomainFieldTracked(policy, "yUserGrant", operation, recordId, "PerfilId"))
                        mask |= yUserGrantTrackingFields.PerfilId;
                    if (DomainFieldTracked(policy, "yUserGrant", operation, recordId, "GrantId"))
                        mask |= yUserGrantTrackingFields.GrantId;
                    if (DomainFieldTracked(policy, "yUserGrant", operation, recordId, "CanGrant"))
                        mask |= yUserGrantTrackingFields.CanGrant;
                    if (DomainFieldTracked(policy, "yUserGrant", operation, recordId, "CanCreate"))
                        mask |= yUserGrantTrackingFields.CanCreate;
                    if (DomainFieldTracked(policy, "yUserGrant", operation, recordId, "CanRead"))
                        mask |= yUserGrantTrackingFields.CanRead;
                    if (DomainFieldTracked(policy, "yUserGrant", operation, recordId, "CanUpdate"))
                        mask |= yUserGrantTrackingFields.CanUpdate;
                    if (DomainFieldTracked(policy, "yUserGrant", operation, recordId, "CanDelete"))
                        mask |= yUserGrantTrackingFields.CanDelete;
                    if (DomainFieldTracked(policy, "yUserGrant", operation, recordId, "ValidUntil"))
                        mask |= yUserGrantTrackingFields.ValidUntil;
                    if (DomainFieldTracked(policy, "yUserGrant", operation, recordId, "TenantID"))
                        mask |= yUserGrantTrackingFields.TenantID;
                    if (DomainFieldTracked(policy, "yUserGrant", operation, recordId, "Deleted"))
                        mask |= yUserGrantTrackingFields.Deleted;
                    if (DomainFieldTracked(policy, "yUserGrant", operation, recordId, "Changed"))
                        mask |= yUserGrantTrackingFields.Changed;
                    if (DomainFieldTracked(policy, "yUserGrant", operation, recordId, "UserId"))
                        mask |= yUserGrantTrackingFields.UserId;
                    return mask;
                }

                private bool DomainFieldTracked(
                    OperationalLoggingPolicy policy,
                    string entity,
                    string? operation,
                    string? recordId,
                    string field)
                {
                    var decision = Evaluate(
                        policy,
                        "DomainTracker",
                        operation,
                        entity,
                        recordId,
                        field,
                        false);

                    return decision.MatchedTarget is { } target &&
                           string.Equals(target.Component, "DomainTracker", StringComparison.OrdinalIgnoreCase) &&
                           decision.Enabled &&
                           !decision.Depth.Equals("D0", StringComparison.OrdinalIgnoreCase);
                }

                private static bool HasDomainTrackingTargets(OperationalLoggingPolicy policy)
                {
                    var now = DateTimeOffset.UtcNow;
                    foreach (var target in policy.Targets)
                    {
                        if (target.ExpiresAtUtc is not null && target.ExpiresAtUtc <= now)
                            continue;
                        if (!string.Equals(target.Component, "DomainTracker", StringComparison.OrdinalIgnoreCase))
                            continue;
                        if (string.Equals(target.Level, "None", StringComparison.OrdinalIgnoreCase))
                            continue;
                        if (string.Equals(target.Depth, "D0", StringComparison.OrdinalIgnoreCase))
                            continue;

                        return true;
                    }

                    return false;
                }


    private static bool Matches(string? expected, string? actual)
    {
        return string.IsNullOrWhiteSpace(expected) ||
               string.Equals(expected, actual, StringComparison.OrdinalIgnoreCase);
    }

    private static int Specificity(DiagnosticTarget target)
    {
        var score = 0;
        if (!string.IsNullOrWhiteSpace(target.Component)) score++;
        if (!string.IsNullOrWhiteSpace(target.Operation)) score += 2;
        if (!string.IsNullOrWhiteSpace(target.Entity)) score += 4;
        if (!string.IsNullOrWhiteSpace(target.RecordId)) score += 8;
        if (!string.IsNullOrWhiteSpace(target.Field)) score += 16;
        return score;
    }
}//Dominio.Schemas.CQRS.SourceCodeInfrastructureOperationalControlStateMigration