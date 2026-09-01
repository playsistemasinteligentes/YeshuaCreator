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

namespace Yeshua.Fiscal.MDFe.CQRS.Tests.Integration.Api.Seed.Migration;

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

        var step1 = new MDFe.MDFeCrudApiSeedTests();
        await step1.ExecuteAsync();

        var step2 = new MDFeEncerramento.MDFeEncerramentoCrudApiSeedTests();
        await step2.ExecuteAsync();

        var step3 = new yFileUpload.yFileUploadCrudApiSeedTests();
        await step3.ExecuteAsync();

        var step4 = new ySaga.ySagaCrudApiSeedTests();
        await step4.ExecuteAsync();

        var step5 = new ySagaStep.ySagaStepCrudApiSeedTests();
        await step5.ExecuteAsync();

        var step6 = new yOutbox.yOutboxCrudApiSeedTests();
        await step6.ExecuteAsync();

        var step7 = new yInbox.yInboxCrudApiSeedTests();
        await step7.ExecuteAsync();

        var step8 = new yToken.yTokenCrudApiSeedTests();
        await step8.ExecuteAsync();

        var step9 = new yUser.yUserCrudApiSeedTests();
        await step9.ExecuteAsync();

        var step10 = new yConfigArcteture.yConfigArctetureCrudApiSeedTests();
        await step10.ExecuteAsync();

        var step11 = new yConfigNotification.yConfigNotificationCrudApiSeedTests();
        await step11.ExecuteAsync();

        var step12 = new yPerfil.yPerfilCrudApiSeedTests();
        await step12.ExecuteAsync();

        var step13 = new yModule.yModuleCrudApiSeedTests();
        await step13.ExecuteAsync();

        var step14 = new yTenantModule.yTenantModuleCrudApiSeedTests();
        await step14.ExecuteAsync();

        var step15 = new yUserModule.yUserModuleCrudApiSeedTests();
        await step15.ExecuteAsync();

        var step16 = new yGrant.yGrantCrudApiSeedTests();
        await step16.ExecuteAsync();

        var step17 = new yPerfilGrant.yPerfilGrantCrudApiSeedTests();
        await step17.ExecuteAsync();

        var step18 = new yUserGrant.yUserGrantCrudApiSeedTests();
        await step18.ExecuteAsync();

    }
}
