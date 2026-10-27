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
// dataClassification: OperationalData
// identities: Application,Environment,Version
// technicalOutcomes: Success,Failure
// businessOutcomes: notApplicable
// evidence: TestDataSeed
// </operational-spec>

namespace Yeshua.Clinica.CQRS.Tests.Integration.Api.Seed.Migration;

[Trait("TestPurpose", "TestDataSeed")]
[Trait("SpecificationGate", "G7")]
[Trait("DiagnosticDepth", "D0")]
public sealed class ApiSeedCrudSuiteTests
{
    [IntegrationFact]
    public async Task Crud_seed_suite_should_create_entities_in_dependency_order_without_cleanup()
    {
        ApiSeedTestContext.Clear();

        var step1 = new Clinica.ClinicaCrudApiSeedTests();
        await step1.ExecuteAsync();

        var step2 = new Especialidade.EspecialidadeCrudApiSeedTests();
        await step2.ExecuteAsync();

        var step3 = new GrupoServico.GrupoServicoCrudApiSeedTests();
        await step3.ExecuteAsync();

        var step4 = new Servico.ServicoCrudApiSeedTests();
        await step4.ExecuteAsync();

        var step5 = new Paciente.PacienteCrudApiSeedTests();
        await step5.ExecuteAsync();

        var step6 = new MovimentacaoFinanceira.MovimentacaoFinanceiraCrudApiSeedTests();
        await step6.ExecuteAsync();

        var step7 = new PlanoConta.PlanoContaCrudApiSeedTests();
        await step7.ExecuteAsync();

        var step8 = new MovimentoFinanceiro.MovimentoFinanceiroCrudApiSeedTests();
        await step8.ExecuteAsync();

        var step9 = new yFileUpload.yFileUploadCrudApiSeedTests();
        await step9.ExecuteAsync();

        var step10 = new ySaga.ySagaCrudApiSeedTests();
        await step10.ExecuteAsync();

        var step11 = new ySagaStep.ySagaStepCrudApiSeedTests();
        await step11.ExecuteAsync();

        var step12 = new yOutbox.yOutboxCrudApiSeedTests();
        await step12.ExecuteAsync();

        var step13 = new yInbox.yInboxCrudApiSeedTests();
        await step13.ExecuteAsync();

        var step14 = new yToken.yTokenCrudApiSeedTests();
        await step14.ExecuteAsync();

        var step15 = new yTenantApplication.yTenantApplicationCrudApiSeedTests();
        await step15.ExecuteAsync();

        var step16 = new yUser.yUserCrudApiSeedTests();
        await step16.ExecuteAsync();

        var step17 = new yConfigArcteture.yConfigArctetureCrudApiSeedTests();
        await step17.ExecuteAsync();

        var step18 = new yConfigNotification.yConfigNotificationCrudApiSeedTests();
        await step18.ExecuteAsync();

        var step19 = new yPerfil.yPerfilCrudApiSeedTests();
        await step19.ExecuteAsync();

        var step20 = new yModule.yModuleCrudApiSeedTests();
        await step20.ExecuteAsync();

        var step21 = new yTenantModule.yTenantModuleCrudApiSeedTests();
        await step21.ExecuteAsync();

        var step22 = new yUserModule.yUserModuleCrudApiSeedTests();
        await step22.ExecuteAsync();

        var step23 = new yGrant.yGrantCrudApiSeedTests();
        await step23.ExecuteAsync();

        var step24 = new yPerfilGrant.yPerfilGrantCrudApiSeedTests();
        await step24.ExecuteAsync();

        var step25 = new yUserGrant.yUserGrantCrudApiSeedTests();
        await step25.ExecuteAsync();

        var step26 = new Profissional.ProfissionalCrudApiSeedTests();
        await step26.ExecuteAsync();

        var step27 = new DisponibilidadeAgenda.DisponibilidadeAgendaCrudApiSeedTests();
        await step27.ExecuteAsync();

        var step28 = new Sesoes.SesoesCrudApiSeedTests();
        await step28.ExecuteAsync();

        var step29 = new RevisaoRegistroSessao.RevisaoRegistroSessaoCrudApiSeedTests();
        await step29.ExecuteAsync();

    }
}
