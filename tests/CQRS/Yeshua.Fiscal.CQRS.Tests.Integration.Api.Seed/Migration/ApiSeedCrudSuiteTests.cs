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

namespace Yeshua.Fiscal.CQRS.Tests.Integration.Api.Seed.Migration;

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

        var step1 = new DocumentoFiscal.DocumentoFiscalCrudApiSeedTests();
        await step1.ExecuteAsync();

        var step2 = new DocumentoFiscalOriginario.DocumentoFiscalOriginarioCrudApiSeedTests();
        await step2.ExecuteAsync();

        var step3 = new NFeProdutoSnapshot.NFeProdutoSnapshotCrudApiSeedTests();
        await step3.ExecuteAsync();

        var step4 = new CTeEntradaOficial.CTeEntradaOficialCrudApiSeedTests();
        await step4.ExecuteAsync();

        var step5 = new CTeRomaneioConsolidado.CTeRomaneioConsolidadoCrudApiSeedTests();
        await step5.ExecuteAsync();

        var step6 = new CTeSolicitacaoFiscal.CTeSolicitacaoFiscalCrudApiSeedTests();
        await step6.ExecuteAsync();

        var step7 = new CTeDocumentoOriginario.CTeDocumentoOriginarioCrudApiSeedTests();
        await step7.ExecuteAsync();

        var step8 = new CTeParticipanteSnapshot.CTeParticipanteSnapshotCrudApiSeedTests();
        await step8.ExecuteAsync();

        var step9 = new CTeTentativaEmissao.CTeTentativaEmissaoCrudApiSeedTests();
        await step9.ExecuteAsync();

        var step10 = new CTeSaidaMDFe.CTeSaidaMDFeCrudApiSeedTests();
        await step10.ExecuteAsync();

        var step11 = new MDFe.MDFeCrudApiSeedTests();
        await step11.ExecuteAsync();

        var step12 = new MDFeSolicitacaoFiscal.MDFeSolicitacaoFiscalCrudApiSeedTests();
        await step12.ExecuteAsync();

        var step13 = new MDFeDocumentoOriginario.MDFeDocumentoOriginarioCrudApiSeedTests();
        await step13.ExecuteAsync();

        var step14 = new MDFePercurso.MDFePercursoCrudApiSeedTests();
        await step14.ExecuteAsync();

        var step15 = new MDFeVeiculo.MDFeVeiculoCrudApiSeedTests();
        await step15.ExecuteAsync();

        var step16 = new MDFeCondutor.MDFeCondutorCrudApiSeedTests();
        await step16.ExecuteAsync();

        var step17 = new MDFeTentativaEmissao.MDFeTentativaEmissaoCrudApiSeedTests();
        await step17.ExecuteAsync();

        var step18 = new MDFeEncerramento.MDFeEncerramentoCrudApiSeedTests();
        await step18.ExecuteAsync();

        var step19 = new SefazEndpoint.SefazEndpointCrudApiSeedTests();
        await step19.ExecuteAsync();

        var step20 = new CertificadoDigital.CertificadoDigitalCrudApiSeedTests();
        await step20.ExecuteAsync();

        var step21 = new EntradaFiscalContingencia.EntradaFiscalContingenciaCrudApiSeedTests();
        await step21.ExecuteAsync();

        var step22 = new EmissaoFiscalTransporte.EmissaoFiscalTransporteCrudApiSeedTests();
        await step22.ExecuteAsync();

        var step23 = new ContingenciaFiscal.ContingenciaFiscalCrudApiSeedTests();
        await step23.ExecuteAsync();

        var step24 = new EmissaoFiscalTransporteDocumento.EmissaoFiscalTransporteDocumentoCrudApiSeedTests();
        await step24.ExecuteAsync();

        var step25 = new yFileUpload.yFileUploadCrudApiSeedTests();
        await step25.ExecuteAsync();

        var step26 = new ySaga.ySagaCrudApiSeedTests();
        await step26.ExecuteAsync();

        var step27 = new ySagaStep.ySagaStepCrudApiSeedTests();
        await step27.ExecuteAsync();

        var step28 = new yOutbox.yOutboxCrudApiSeedTests();
        await step28.ExecuteAsync();

        var step29 = new yInbox.yInboxCrudApiSeedTests();
        await step29.ExecuteAsync();

        var step30 = new yToken.yTokenCrudApiSeedTests();
        await step30.ExecuteAsync();

        var step31 = new yUser.yUserCrudApiSeedTests();
        await step31.ExecuteAsync();

        var step32 = new yConfigArcteture.yConfigArctetureCrudApiSeedTests();
        await step32.ExecuteAsync();

        var step33 = new yConfigNotification.yConfigNotificationCrudApiSeedTests();
        await step33.ExecuteAsync();

        var step34 = new yPerfil.yPerfilCrudApiSeedTests();
        await step34.ExecuteAsync();

        var step35 = new yModule.yModuleCrudApiSeedTests();
        await step35.ExecuteAsync();

        var step36 = new yTenantModule.yTenantModuleCrudApiSeedTests();
        await step36.ExecuteAsync();

        var step37 = new yUserModule.yUserModuleCrudApiSeedTests();
        await step37.ExecuteAsync();

        var step38 = new yGrant.yGrantCrudApiSeedTests();
        await step38.ExecuteAsync();

        var step39 = new yPerfilGrant.yPerfilGrantCrudApiSeedTests();
        await step39.ExecuteAsync();

        var step40 = new yUserGrant.yUserGrantCrudApiSeedTests();
        await step40.ExecuteAsync();

    }
}
