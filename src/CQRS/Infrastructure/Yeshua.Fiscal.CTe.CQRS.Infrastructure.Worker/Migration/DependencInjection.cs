// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureDependencInjectionInjectionMigration
// </yeshua>

using System;
using Shered.Services;
using RepositoryInterfaces.Services;
using Command.Patterns;
using Command.Interfaces;
using Command.Receivers;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Shered.DB.Connection;
using Aplication.Interfaces.Services;
using Shared.Operational;
using Yeshua.Generated.Operational;
using Yeshua.Generated.OperationalControl;
using Migrations.Operational;
using Yeshua.Generated.OperationalHealth;
namespace Migrations
{
public static class DependencInjection
{
public static void MapDependencInjection(WebApplicationBuilder builder)
{


                    builder.Services.AddSingleton<IRuntimeIdentityProvider>(
                        _ => new RuntimeIdentityProvider(builder.Environment.EnvironmentName));
                    builder.Services.AddSingleton<OperationalLoggingPolicyState>(sp =>
                        new OperationalLoggingPolicyState(
                            sp.GetRequiredService<IRuntimeIdentityProvider>().Current.Application,
                            sp.GetRequiredService<IRuntimeIdentityProvider>().Current.Environment));
                    builder.Services.AddSingleton<IOperationalLoggingPolicyAccessor>(sp =>
                        sp.GetRequiredService<OperationalLoggingPolicyState>());
                    builder.Services.AddSingleton<Dominio.Interfaces.IOperationalTelemetryPolicy>(sp =>
                        sp.GetRequiredService<OperationalLoggingPolicyState>());
                    builder.Services.AddSingleton<Dominio.Interfaces.IDomainTrackingPolicy>(sp =>
                        sp.GetRequiredService<OperationalLoggingPolicyState>());
                    builder.Services.AddHostedService<OperationalPolicySynchronizer>();
                    builder.Services.AddHostedService<RuntimeIdentityReporter>();
                    builder.Services.AddSingleton<Microsoft.AspNetCore.Hosting.IStartupFilter, WorkerOperationalHealthStartupFilter>();

                    builder.Services.AddScoped<UnitOfWork>();
                    builder.Services.AddScoped<RepositoryTelemetry>();
                    builder.Services.AddScoped<RepositoryInterfaces.Patterns.UnitOfWork.IUnitOfWork>(sp =>
                        new InstrumentedUnitOfWork(
                            sp.GetRequiredService<UnitOfWork>(),
                            sp.GetRequiredService<RepositoryTelemetry>()
                        ));


                    builder.Services.AddSingleton(typeof(ICacheService<>), typeof(MemoryCacheService<>));
                    builder.Services.AddSingleton<ICacheKeyIndexManager, CacheKeyIndexManager>();
                    builder.Services.AddSingleton<Shered.Logger.Logger>(sp =>
                        new Shered.Logger.Logger(
                            sp.GetRequiredService<Dominio.Interfaces.IOperationalTelemetryPolicy>()));
                    builder.Services.AddSingleton<Dominio.Interfaces.ILogger>(sp =>
                        sp.GetRequiredService<Shered.Logger.Logger>());
                    builder.Services.AddTransient<ISagaExecutor, SagaExecutor>();


builder.Services.AddTransient<IRepository.Write.ICTeEntradaOficialWriteRepository, Input.Repository.CTeEntradaOficial.CTeEntradaOficialWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ICTeEntradaOficialReadRepository, Read.Repository.CTeEntradaOficialReadRepository>();
builder.Services.AddTransient<IQuery.Read.ICTeEntradaOficialQueryRead, Query.Read.CTeEntradaOficialQueryRead>();
builder.Services.AddTransient<IQuery.Write.ICTeEntradaOficialQueryWrite, Query.Write.CTeEntradaOficialQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertCTeEntradaOficialReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateCTeEntradaOficialReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteCTeEntradaOficialReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CTeEntradaOficialReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CTeEntradaOficialReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CTeEntradaOficialReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ICTeRomaneioConsolidadoWriteRepository, Input.Repository.CTeRomaneioConsolidado.CTeRomaneioConsolidadoWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ICTeRomaneioConsolidadoReadRepository, Read.Repository.CTeRomaneioConsolidadoReadRepository>();
builder.Services.AddTransient<IQuery.Read.ICTeRomaneioConsolidadoQueryRead, Query.Read.CTeRomaneioConsolidadoQueryRead>();
builder.Services.AddTransient<IQuery.Write.ICTeRomaneioConsolidadoQueryWrite, Query.Write.CTeRomaneioConsolidadoQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertCTeRomaneioConsolidadoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateCTeRomaneioConsolidadoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteCTeRomaneioConsolidadoReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CTeRomaneioConsolidadoReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CTeRomaneioConsolidadoReadFKEntradaOficialIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CTeRomaneioConsolidadoReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CTeRomaneioConsolidadoReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ICTeSolicitacaoFiscalWriteRepository, Input.Repository.CTeSolicitacaoFiscal.CTeSolicitacaoFiscalWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ICTeSolicitacaoFiscalReadRepository, Read.Repository.CTeSolicitacaoFiscalReadRepository>();
builder.Services.AddTransient<IQuery.Read.ICTeSolicitacaoFiscalQueryRead, Query.Read.CTeSolicitacaoFiscalQueryRead>();
builder.Services.AddTransient<IQuery.Write.ICTeSolicitacaoFiscalQueryWrite, Query.Write.CTeSolicitacaoFiscalQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertCTeSolicitacaoFiscalReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateCTeSolicitacaoFiscalReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteCTeSolicitacaoFiscalReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CTeSolicitacaoFiscalReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CTeSolicitacaoFiscalReadFKEntradaOficialIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CTeSolicitacaoFiscalReadFKRomaneioConsolidadoIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CTeSolicitacaoFiscalReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CTeSolicitacaoFiscalReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ICTeDocumentoOriginarioWriteRepository, Input.Repository.CTeDocumentoOriginario.CTeDocumentoOriginarioWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ICTeDocumentoOriginarioReadRepository, Read.Repository.CTeDocumentoOriginarioReadRepository>();
builder.Services.AddTransient<IQuery.Read.ICTeDocumentoOriginarioQueryRead, Query.Read.CTeDocumentoOriginarioQueryRead>();
builder.Services.AddTransient<IQuery.Write.ICTeDocumentoOriginarioQueryWrite, Query.Write.CTeDocumentoOriginarioQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertCTeDocumentoOriginarioReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateCTeDocumentoOriginarioReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteCTeDocumentoOriginarioReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CTeDocumentoOriginarioReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CTeDocumentoOriginarioReadFKCTeSolicitacaoFiscalIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CTeDocumentoOriginarioReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CTeDocumentoOriginarioReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ICTeParticipanteSnapshotWriteRepository, Input.Repository.CTeParticipanteSnapshot.CTeParticipanteSnapshotWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ICTeParticipanteSnapshotReadRepository, Read.Repository.CTeParticipanteSnapshotReadRepository>();
builder.Services.AddTransient<IQuery.Read.ICTeParticipanteSnapshotQueryRead, Query.Read.CTeParticipanteSnapshotQueryRead>();
builder.Services.AddTransient<IQuery.Write.ICTeParticipanteSnapshotQueryWrite, Query.Write.CTeParticipanteSnapshotQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertCTeParticipanteSnapshotReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateCTeParticipanteSnapshotReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteCTeParticipanteSnapshotReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CTeParticipanteSnapshotReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CTeParticipanteSnapshotReadFKCTeSolicitacaoFiscalIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CTeParticipanteSnapshotReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CTeParticipanteSnapshotReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ICTeTentativaEmissaoWriteRepository, Input.Repository.CTeTentativaEmissao.CTeTentativaEmissaoWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ICTeTentativaEmissaoReadRepository, Read.Repository.CTeTentativaEmissaoReadRepository>();
builder.Services.AddTransient<IQuery.Read.ICTeTentativaEmissaoQueryRead, Query.Read.CTeTentativaEmissaoQueryRead>();
builder.Services.AddTransient<IQuery.Write.ICTeTentativaEmissaoQueryWrite, Query.Write.CTeTentativaEmissaoQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertCTeTentativaEmissaoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateCTeTentativaEmissaoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteCTeTentativaEmissaoReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CTeTentativaEmissaoReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CTeTentativaEmissaoReadFKCTeSolicitacaoFiscalIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CTeTentativaEmissaoReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CTeTentativaEmissaoReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ICTeSaidaMDFeWriteRepository, Input.Repository.CTeSaidaMDFe.CTeSaidaMDFeWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ICTeSaidaMDFeReadRepository, Read.Repository.CTeSaidaMDFeReadRepository>();
builder.Services.AddTransient<IQuery.Read.ICTeSaidaMDFeQueryRead, Query.Read.CTeSaidaMDFeQueryRead>();
builder.Services.AddTransient<IQuery.Write.ICTeSaidaMDFeQueryWrite, Query.Write.CTeSaidaMDFeQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertCTeSaidaMDFeReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateCTeSaidaMDFeReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteCTeSaidaMDFeReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CTeSaidaMDFeReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CTeSaidaMDFeReadFKCTeTentativaEmissaoIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CTeSaidaMDFeReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CTeSaidaMDFeReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IyFileUploadWriteRepository, Input.Repository.yFileUpload.yFileUploadWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IyFileUploadReadRepository, Read.Repository.yFileUploadReadRepository>();
builder.Services.AddTransient<IQuery.Read.IyFileUploadQueryRead, Query.Read.yFileUploadQueryRead>();
builder.Services.AddTransient<IQuery.Write.IyFileUploadQueryWrite, Query.Write.yFileUploadQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertyFileUploadReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateyFileUploadReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteyFileUploadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yFileUploadReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yFileUploadReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yFileUploadReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IySagaWriteRepository, Input.Repository.ySaga.ySagaWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IySagaReadRepository, Read.Repository.ySagaReadRepository>();
builder.Services.AddTransient<IQuery.Read.IySagaQueryRead, Query.Read.ySagaQueryRead>();
builder.Services.AddTransient<IQuery.Write.IySagaQueryWrite, Query.Write.ySagaQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertySagaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateySagaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteySagaReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ySagaReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ySagaReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ySagaReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IySagaStepWriteRepository, Input.Repository.ySagaStep.ySagaStepWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IySagaStepReadRepository, Read.Repository.ySagaStepReadRepository>();
builder.Services.AddTransient<IQuery.Read.IySagaStepQueryRead, Query.Read.ySagaStepQueryRead>();
builder.Services.AddTransient<IQuery.Write.IySagaStepQueryWrite, Query.Write.ySagaStepQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertySagaStepReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateySagaStepReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteySagaStepReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ySagaStepReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ySagaStepReadFKSagaIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ySagaStepReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ySagaStepReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IyOutboxWriteRepository, Input.Repository.yOutbox.yOutboxWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IyOutboxReadRepository, Read.Repository.yOutboxReadRepository>();
builder.Services.AddTransient<IQuery.Read.IyOutboxQueryRead, Query.Read.yOutboxQueryRead>();
builder.Services.AddTransient<IQuery.Write.IyOutboxQueryWrite, Query.Write.yOutboxQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertyOutboxReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateyOutboxReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteyOutboxReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yOutboxReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yOutboxReadFKSagaIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yOutboxReadFKSagaStepIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yOutboxReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yOutboxReadFKUserIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yOutboxReadQueryProximaPendenteReceiver>();

builder.Services.AddTransient<IRepository.Write.IyInboxWriteRepository, Input.Repository.yInbox.yInboxWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IyInboxReadRepository, Read.Repository.yInboxReadRepository>();
builder.Services.AddTransient<IQuery.Read.IyInboxQueryRead, Query.Read.yInboxQueryRead>();
builder.Services.AddTransient<IQuery.Write.IyInboxQueryWrite, Query.Write.yInboxQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertyInboxReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateyInboxReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteyInboxReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yInboxReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yInboxReadFKSagaIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yInboxReadFKSagaStepIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yInboxReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yInboxReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IyTokenWriteRepository, Input.Repository.yToken.yTokenWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IyTokenReadRepository, Read.Repository.yTokenReadRepository>();
builder.Services.AddTransient<IQuery.Read.IyTokenQueryRead, Query.Read.yTokenQueryRead>();
builder.Services.AddTransient<IQuery.Write.IyTokenQueryWrite, Query.Write.yTokenQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertyTokenReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateyTokenReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteyTokenReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yTokenReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yTokenReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yTokenReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IyTenantWriteRepository, Input.Repository.yTenant.yTenantWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IyTenantReadRepository, Read.Repository.yTenantReadRepository>();
builder.Services.AddTransient<IQuery.Read.IyTenantQueryRead, Query.Read.yTenantQueryRead>();
builder.Services.AddTransient<IQuery.Write.IyTenantQueryWrite, Query.Write.yTenantQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertyTenantReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateyTenantReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteyTenantReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yTenantReadReceiver>();

builder.Services.AddTransient<IRepository.Write.IyUserWriteRepository, Input.Repository.yUser.yUserWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IyUserReadRepository, Read.Repository.yUserReadRepository>();
builder.Services.AddTransient<IQuery.Read.IyUserQueryRead, Query.Read.yUserQueryRead>();
builder.Services.AddTransient<IQuery.Write.IyUserQueryWrite, Query.Write.yUserQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertyUserReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateyUserReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteyUserReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yUserReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yUserReadFKTenantIDReceiver>();

builder.Services.AddTransient<IRepository.Write.IyConfigArctetureWriteRepository, Input.Repository.yConfigArcteture.yConfigArctetureWriteRepository>();
builder.Services.AddTransient<Read.Repository.yConfigArctetureReadRepository>();
    builder.Services.AddTransient<IRepository.Read.IyConfigArctetureReadRepository>(sp =>
    {
    var inner = sp.GetRequiredService<Read.Repository.yConfigArctetureReadRepository>();
    var cacheById = sp.GetRequiredService<ICacheService<Repositorio.Outputs.yConfigArctetureDTO >>();
    var cacheAll = sp.GetRequiredService<ICacheService<IEnumerable<Repositorio.Outputs.yConfigArctetureDTO>>>();
        var cacheFKTenantID = sp.GetRequiredService<ICacheService<IEnumerable<Repositorio.Outputs.yConfigArctetureTenantIDDTO>>>();
        var cacheFKUserId = sp.GetRequiredService<ICacheService<IEnumerable<Repositorio.Outputs.yConfigArctetureUserIdDTO>>>();
    return new Read.Repository.yConfigArctetureReadRepositoryCacheDecorator(inner,cacheById,cacheAll,cacheFKTenantID,cacheFKUserId    );
});
builder.Services.AddTransient<Command.Receivers.Write.InsertyConfigArctetureReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateyConfigArctetureReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteyConfigArctetureReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yConfigArctetureReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yConfigArctetureReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yConfigArctetureReadFKUserIdReceiver>();
builder.Services.AddTransient<IRepository.Write.IyConfigArctetureWriteRepository, Input.Repository.yConfigArcteture.yConfigArctetureWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IyConfigArctetureReadRepository, Read.Repository.yConfigArctetureReadRepository>();
builder.Services.AddTransient<IQuery.Read.IyConfigArctetureQueryRead, Query.Read.yConfigArctetureQueryRead>();
builder.Services.AddTransient<IQuery.Write.IyConfigArctetureQueryWrite, Query.Write.yConfigArctetureQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertyConfigArctetureReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateyConfigArctetureReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteyConfigArctetureReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yConfigArctetureReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yConfigArctetureReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yConfigArctetureReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IyConfigNotificationWriteRepository, Input.Repository.yConfigNotification.yConfigNotificationWriteRepository>();
builder.Services.AddTransient<Read.Repository.yConfigNotificationReadRepository>();
    builder.Services.AddTransient<IRepository.Read.IyConfigNotificationReadRepository>(sp =>
    {
    var inner = sp.GetRequiredService<Read.Repository.yConfigNotificationReadRepository>();
    var cacheById = sp.GetRequiredService<ICacheService<Repositorio.Outputs.yConfigNotificationDTO >>();
    var cacheAll = sp.GetRequiredService<ICacheService<IEnumerable<Repositorio.Outputs.yConfigNotificationDTO>>>();
        var cacheFKTenantID = sp.GetRequiredService<ICacheService<IEnumerable<Repositorio.Outputs.yConfigNotificationTenantIDDTO>>>();
        var cacheFKUserId = sp.GetRequiredService<ICacheService<IEnumerable<Repositorio.Outputs.yConfigNotificationUserIdDTO>>>();
    return new Read.Repository.yConfigNotificationReadRepositoryCacheDecorator(inner,cacheById,cacheAll,cacheFKTenantID,cacheFKUserId    );
});
builder.Services.AddTransient<Command.Receivers.Write.InsertyConfigNotificationReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateyConfigNotificationReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteyConfigNotificationReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yConfigNotificationReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yConfigNotificationReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yConfigNotificationReadFKUserIdReceiver>();
builder.Services.AddTransient<IRepository.Write.IyConfigNotificationWriteRepository, Input.Repository.yConfigNotification.yConfigNotificationWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IyConfigNotificationReadRepository, Read.Repository.yConfigNotificationReadRepository>();
builder.Services.AddTransient<IQuery.Read.IyConfigNotificationQueryRead, Query.Read.yConfigNotificationQueryRead>();
builder.Services.AddTransient<IQuery.Write.IyConfigNotificationQueryWrite, Query.Write.yConfigNotificationQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertyConfigNotificationReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateyConfigNotificationReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteyConfigNotificationReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yConfigNotificationReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yConfigNotificationReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yConfigNotificationReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IyPerfilWriteRepository, Input.Repository.yPerfil.yPerfilWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IyPerfilReadRepository, Read.Repository.yPerfilReadRepository>();
builder.Services.AddTransient<IQuery.Read.IyPerfilQueryRead, Query.Read.yPerfilQueryRead>();
builder.Services.AddTransient<IQuery.Write.IyPerfilQueryWrite, Query.Write.yPerfilQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertyPerfilReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateyPerfilReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteyPerfilReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yPerfilReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yPerfilReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yPerfilReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IyModuleWriteRepository, Input.Repository.yModule.yModuleWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IyModuleReadRepository, Read.Repository.yModuleReadRepository>();
builder.Services.AddTransient<IQuery.Read.IyModuleQueryRead, Query.Read.yModuleQueryRead>();
builder.Services.AddTransient<IQuery.Write.IyModuleQueryWrite, Query.Write.yModuleQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertyModuleReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateyModuleReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteyModuleReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yModuleReadReceiver>();

builder.Services.AddTransient<IRepository.Write.IyTenantModuleWriteRepository, Input.Repository.yTenantModule.yTenantModuleWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IyTenantModuleReadRepository, Read.Repository.yTenantModuleReadRepository>();
builder.Services.AddTransient<IQuery.Read.IyTenantModuleQueryRead, Query.Read.yTenantModuleQueryRead>();
builder.Services.AddTransient<IQuery.Write.IyTenantModuleQueryWrite, Query.Write.yTenantModuleQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertyTenantModuleReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateyTenantModuleReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteyTenantModuleReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yTenantModuleReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yTenantModuleReadFKModuleIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yTenantModuleReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yTenantModuleReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IyUserModuleWriteRepository, Input.Repository.yUserModule.yUserModuleWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IyUserModuleReadRepository, Read.Repository.yUserModuleReadRepository>();
builder.Services.AddTransient<IQuery.Read.IyUserModuleQueryRead, Query.Read.yUserModuleQueryRead>();
builder.Services.AddTransient<IQuery.Write.IyUserModuleQueryWrite, Query.Write.yUserModuleQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertyUserModuleReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateyUserModuleReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteyUserModuleReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yUserModuleReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yUserModuleReadFKModuleIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yUserModuleReadFKUserIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yUserModuleReadFKTenantIDReceiver>();

builder.Services.AddTransient<IRepository.Write.IyGrantWriteRepository, Input.Repository.yGrant.yGrantWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IyGrantReadRepository, Read.Repository.yGrantReadRepository>();
builder.Services.AddTransient<IQuery.Read.IyGrantQueryRead, Query.Read.yGrantQueryRead>();
builder.Services.AddTransient<IQuery.Write.IyGrantQueryWrite, Query.Write.yGrantQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertyGrantReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateyGrantReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteyGrantReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yGrantReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yGrantReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yGrantReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IyPerfilGrantWriteRepository, Input.Repository.yPerfilGrant.yPerfilGrantWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IyPerfilGrantReadRepository, Read.Repository.yPerfilGrantReadRepository>();
builder.Services.AddTransient<IQuery.Read.IyPerfilGrantQueryRead, Query.Read.yPerfilGrantQueryRead>();
builder.Services.AddTransient<IQuery.Write.IyPerfilGrantQueryWrite, Query.Write.yPerfilGrantQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertyPerfilGrantReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateyPerfilGrantReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteyPerfilGrantReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yPerfilGrantReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yPerfilGrantReadFKPerfilIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yPerfilGrantReadFKGrantIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yPerfilGrantReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yPerfilGrantReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IyUserGrantWriteRepository, Input.Repository.yUserGrant.yUserGrantWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IyUserGrantReadRepository, Read.Repository.yUserGrantReadRepository>();
builder.Services.AddTransient<IQuery.Read.IyUserGrantQueryRead, Query.Read.yUserGrantQueryRead>();
builder.Services.AddTransient<IQuery.Write.IyUserGrantQueryWrite, Query.Write.yUserGrantQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertyUserGrantReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateyUserGrantReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteyUserGrantReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yUserGrantReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yUserGrantReadFKPerfilIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yUserGrantReadFKGrantIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yUserGrantReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yUserGrantReadFKUserIdReceiver>();

builder.Services.AddTransient<Command.Receivers.UseCase.ReceberRomaneioConsolidadoParaCTeHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.SolicitarEmissaoCTeHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.AutorizarCTeHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.PublicarCTeAutorizadoParaMDFeHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.StarSessionUploadHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.SendFileHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.CreateContaHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.LoginHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.RecoveryAccountHandler>();
builder.Services.AddTransient<Dominio.Interfaces.Strategy.IMessage,Shered.Patterns.Strategy.Message>();
builder.Services.AddTransient<Shered.Patterns.Strategy.EmailNotification>();
builder.Services.AddTransient<Shered.Patterns.Strategy.SMSNotification>();
builder.Services.AddTransient<Shered.Patterns.Strategy.WhatsappNotification>();
builder.Services.AddTransient<Dominio.Interfaces.Strategy.IINotificationFactory,Shered.Patterns.Strategy.NotificationFactory>();
builder.Services.AddTransient<Dominio.Interfaces.Strategy.IMessage,Shered.Patterns.Strategy.Message>();
}
public static Command.Interfaces.Patterns.Queue.QueueTopology GetQueueTopology()
{
return new Command.Interfaces.Patterns.Queue.QueueTopology
{
    Exchanges = new List<Command.Interfaces.Patterns.Queue.ExchangeDefinition>
    {
    }
};
}
}
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureDependencInjectionInjectionMigration