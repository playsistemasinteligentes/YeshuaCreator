namespace Yeshua.CQRS.Tests.Integration.Api.Smoke.Migration;

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
            var step1 = new MDFe.MDFeCrudApiSmokeTests();
            deleteSteps.Push(step1.DeleteAsync);
            await step1.ExecuteAsync();

            var step2 = new MDFeEncerramento.MDFeEncerramentoCrudApiSmokeTests();
            deleteSteps.Push(step2.DeleteAsync);
            await step2.ExecuteAsync();

            var step3 = new yFileUpload.yFileUploadCrudApiSmokeTests();
            deleteSteps.Push(step3.DeleteAsync);
            await step3.ExecuteAsync();

            var step4 = new ySaga.ySagaCrudApiSmokeTests();
            deleteSteps.Push(step4.DeleteAsync);
            await step4.ExecuteAsync();

            var step5 = new ySagaStep.ySagaStepCrudApiSmokeTests();
            deleteSteps.Push(step5.DeleteAsync);
            await step5.ExecuteAsync();

            var step6 = new yOutbox.yOutboxCrudApiSmokeTests();
            deleteSteps.Push(step6.DeleteAsync);
            await step6.ExecuteAsync();

            var step7 = new yInbox.yInboxCrudApiSmokeTests();
            deleteSteps.Push(step7.DeleteAsync);
            await step7.ExecuteAsync();

            var step8 = new yUser.yUserCrudApiSmokeTests();
            deleteSteps.Push(step8.DeleteAsync);
            await step8.ExecuteAsync();

            var step9 = new yConfigArcteture.yConfigArctetureCrudApiSmokeTests();
            deleteSteps.Push(step9.DeleteAsync);
            await step9.ExecuteAsync();

            var step10 = new yConfigNotification.yConfigNotificationCrudApiSmokeTests();
            deleteSteps.Push(step10.DeleteAsync);
            await step10.ExecuteAsync();

            var step11 = new yPerfil.yPerfilCrudApiSmokeTests();
            deleteSteps.Push(step11.DeleteAsync);
            await step11.ExecuteAsync();

            var step12 = new yModule.yModuleCrudApiSmokeTests();
            deleteSteps.Push(step12.DeleteAsync);
            await step12.ExecuteAsync();

            var step13 = new yTenantModule.yTenantModuleCrudApiSmokeTests();
            deleteSteps.Push(step13.DeleteAsync);
            await step13.ExecuteAsync();

            var step14 = new yUserModule.yUserModuleCrudApiSmokeTests();
            deleteSteps.Push(step14.DeleteAsync);
            await step14.ExecuteAsync();

            var step15 = new yGrant.yGrantCrudApiSmokeTests();
            deleteSteps.Push(step15.DeleteAsync);
            await step15.ExecuteAsync();

            var step16 = new yPerfilGrant.yPerfilGrantCrudApiSmokeTests();
            deleteSteps.Push(step16.DeleteAsync);
            await step16.ExecuteAsync();

            var step17 = new yUserGrant.yUserGrantCrudApiSmokeTests();
            deleteSteps.Push(step17.DeleteAsync);
            await step17.ExecuteAsync();

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
