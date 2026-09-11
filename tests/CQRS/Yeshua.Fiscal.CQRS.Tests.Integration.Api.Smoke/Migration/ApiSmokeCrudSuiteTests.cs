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

namespace Yeshua.Fiscal.CQRS.Tests.Integration.Api.Smoke.Migration;

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
            var step1 = new DocumentoFiscal.DocumentoFiscalCrudApiSmokeTests();
            deleteSteps.Push(step1.DeleteAsync);
            await step1.ExecuteAsync();

            var step2 = new DocumentoFiscalOriginario.DocumentoFiscalOriginarioCrudApiSmokeTests();
            deleteSteps.Push(step2.DeleteAsync);
            await step2.ExecuteAsync();

            var step3 = new NFeProdutoSnapshot.NFeProdutoSnapshotCrudApiSmokeTests();
            deleteSteps.Push(step3.DeleteAsync);
            await step3.ExecuteAsync();

            var step4 = new CTeEntradaOficial.CTeEntradaOficialCrudApiSmokeTests();
            deleteSteps.Push(step4.DeleteAsync);
            await step4.ExecuteAsync();

            var step5 = new CTeRomaneioConsolidado.CTeRomaneioConsolidadoCrudApiSmokeTests();
            deleteSteps.Push(step5.DeleteAsync);
            await step5.ExecuteAsync();

            var step6 = new CTeSolicitacaoFiscal.CTeSolicitacaoFiscalCrudApiSmokeTests();
            deleteSteps.Push(step6.DeleteAsync);
            await step6.ExecuteAsync();

            var step7 = new CTeDocumentoOriginario.CTeDocumentoOriginarioCrudApiSmokeTests();
            deleteSteps.Push(step7.DeleteAsync);
            await step7.ExecuteAsync();

            var step8 = new CTeParticipanteSnapshot.CTeParticipanteSnapshotCrudApiSmokeTests();
            deleteSteps.Push(step8.DeleteAsync);
            await step8.ExecuteAsync();

            var step9 = new CTeTentativaEmissao.CTeTentativaEmissaoCrudApiSmokeTests();
            deleteSteps.Push(step9.DeleteAsync);
            await step9.ExecuteAsync();

            var step10 = new CTeSaidaMDFe.CTeSaidaMDFeCrudApiSmokeTests();
            deleteSteps.Push(step10.DeleteAsync);
            await step10.ExecuteAsync();

            var step11 = new MDFe.MDFeCrudApiSmokeTests();
            deleteSteps.Push(step11.DeleteAsync);
            await step11.ExecuteAsync();

            var step12 = new MDFeSolicitacaoFiscal.MDFeSolicitacaoFiscalCrudApiSmokeTests();
            deleteSteps.Push(step12.DeleteAsync);
            await step12.ExecuteAsync();

            var step13 = new MDFeDocumentoOriginario.MDFeDocumentoOriginarioCrudApiSmokeTests();
            deleteSteps.Push(step13.DeleteAsync);
            await step13.ExecuteAsync();

            var step14 = new MDFePercurso.MDFePercursoCrudApiSmokeTests();
            deleteSteps.Push(step14.DeleteAsync);
            await step14.ExecuteAsync();

            var step15 = new MDFeVeiculo.MDFeVeiculoCrudApiSmokeTests();
            deleteSteps.Push(step15.DeleteAsync);
            await step15.ExecuteAsync();

            var step16 = new MDFeCondutor.MDFeCondutorCrudApiSmokeTests();
            deleteSteps.Push(step16.DeleteAsync);
            await step16.ExecuteAsync();

            var step17 = new MDFeTentativaEmissao.MDFeTentativaEmissaoCrudApiSmokeTests();
            deleteSteps.Push(step17.DeleteAsync);
            await step17.ExecuteAsync();

            var step18 = new MDFeEncerramento.MDFeEncerramentoCrudApiSmokeTests();
            deleteSteps.Push(step18.DeleteAsync);
            await step18.ExecuteAsync();

            var step19 = new SefazEndpoint.SefazEndpointCrudApiSmokeTests();
            deleteSteps.Push(step19.DeleteAsync);
            await step19.ExecuteAsync();

            var step20 = new CertificadoDigital.CertificadoDigitalCrudApiSmokeTests();
            deleteSteps.Push(step20.DeleteAsync);
            await step20.ExecuteAsync();

            var step21 = new EntradaFiscalContingencia.EntradaFiscalContingenciaCrudApiSmokeTests();
            deleteSteps.Push(step21.DeleteAsync);
            await step21.ExecuteAsync();

            var step22 = new yFileUpload.yFileUploadCrudApiSmokeTests();
            deleteSteps.Push(step22.DeleteAsync);
            await step22.ExecuteAsync();

            var step23 = new ySaga.ySagaCrudApiSmokeTests();
            deleteSteps.Push(step23.DeleteAsync);
            await step23.ExecuteAsync();

            var step24 = new ySagaStep.ySagaStepCrudApiSmokeTests();
            deleteSteps.Push(step24.DeleteAsync);
            await step24.ExecuteAsync();

            var step25 = new yOutbox.yOutboxCrudApiSmokeTests();
            deleteSteps.Push(step25.DeleteAsync);
            await step25.ExecuteAsync();

            var step26 = new yInbox.yInboxCrudApiSmokeTests();
            deleteSteps.Push(step26.DeleteAsync);
            await step26.ExecuteAsync();

            var step27 = new yToken.yTokenCrudApiSmokeTests();
            deleteSteps.Push(step27.DeleteAsync);
            await step27.ExecuteAsync();

            var step28 = new yUser.yUserCrudApiSmokeTests();
            deleteSteps.Push(step28.DeleteAsync);
            await step28.ExecuteAsync();

            var step29 = new yConfigArcteture.yConfigArctetureCrudApiSmokeTests();
            deleteSteps.Push(step29.DeleteAsync);
            await step29.ExecuteAsync();

            var step30 = new yConfigNotification.yConfigNotificationCrudApiSmokeTests();
            deleteSteps.Push(step30.DeleteAsync);
            await step30.ExecuteAsync();

            var step31 = new yPerfil.yPerfilCrudApiSmokeTests();
            deleteSteps.Push(step31.DeleteAsync);
            await step31.ExecuteAsync();

            var step32 = new yModule.yModuleCrudApiSmokeTests();
            deleteSteps.Push(step32.DeleteAsync);
            await step32.ExecuteAsync();

            var step33 = new yTenantModule.yTenantModuleCrudApiSmokeTests();
            deleteSteps.Push(step33.DeleteAsync);
            await step33.ExecuteAsync();

            var step34 = new yUserModule.yUserModuleCrudApiSmokeTests();
            deleteSteps.Push(step34.DeleteAsync);
            await step34.ExecuteAsync();

            var step35 = new yGrant.yGrantCrudApiSmokeTests();
            deleteSteps.Push(step35.DeleteAsync);
            await step35.ExecuteAsync();

            var step36 = new yPerfilGrant.yPerfilGrantCrudApiSmokeTests();
            deleteSteps.Push(step36.DeleteAsync);
            await step36.ExecuteAsync();

            var step37 = new yUserGrant.yUserGrantCrudApiSmokeTests();
            deleteSteps.Push(step37.DeleteAsync);
            await step37.ExecuteAsync();

            var step38 = new Saga.EmissaoFiscalCargaStandard.EmissaoFiscalCargaStandardSagaApiSmokeTests();
            await step38.EmissaoFiscalCargaStandard_saga_should_run_with_real_api_and_infrastructure();

            var step39 = new Saga.ContingenciaFiscalStandard.ContingenciaFiscalStandardSagaApiSmokeTests();
            await step39.ContingenciaFiscalStandard_saga_should_run_with_real_api_and_infrastructure();

            var step40 = new Saga.EncerramentoMDFeStandard.EncerramentoMDFeStandardSagaApiSmokeTests();
            await step40.EncerramentoMDFeStandard_saga_should_run_with_real_api_and_infrastructure();

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
