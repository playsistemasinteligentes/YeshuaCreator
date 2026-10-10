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
using RepositoryInterfaces.Patterns.Saga;
using Command.Receivers.Migration.Saga;
using Command.Patterns.OutBox;
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


                    var runtimeIdentityProvider = new RuntimeIdentityProvider(builder.Environment.EnvironmentName);
                    builder.Services.AddSingleton<IRuntimeIdentityProvider>(runtimeIdentityProvider);
                    builder.Services.AddYeshuaOperationalTelemetry(builder.Configuration, runtimeIdentityProvider.Current);
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
                            sp.GetRequiredService<Dominio.Interfaces.IOperationalTelemetryPolicy>(),
                            sp.GetRequiredService<IOperationalLogSink>()));
                    builder.Services.AddSingleton<Dominio.Interfaces.ILogger>(sp =>
                        sp.GetRequiredService<Shered.Logger.Logger>());
                    builder.Services.AddTransient<ISagaExecutor, SagaExecutor>();
                    builder.Services.AddTransient<ISagaStepInvoker, SagaStepInvoker>();
                    builder.Services.AddTransient<SagaResolverRegistry>();
                    builder.Services.AddTransient<ISagaResolverRegistry, SagaResolverRegistry>();
                    builder.Services.AddTransient<ISagaStepContinuation, SagaStepContinuation>();
                    builder.Services.AddScoped<OutboxService>();


builder.Services.AddTransient<IRepository.Write.IFotoWriteRepository, Input.Repository.Foto.FotoWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IFotoReadRepository, Read.Repository.FotoReadRepository>();
builder.Services.AddTransient<IQuery.Read.IFotoQueryRead, Query.Read.FotoQueryRead>();
builder.Services.AddTransient<IQuery.Write.IFotoQueryWrite, Query.Write.FotoQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertFotoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateFotoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteFotoReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.FotoReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.FotoReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.FotoReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IAlbumWriteRepository, Input.Repository.Album.AlbumWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IAlbumReadRepository, Read.Repository.AlbumReadRepository>();
builder.Services.AddTransient<IQuery.Read.IAlbumQueryRead, Query.Read.AlbumQueryRead>();
builder.Services.AddTransient<IQuery.Write.IAlbumQueryWrite, Query.Write.AlbumQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertAlbumReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateAlbumReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteAlbumReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.AlbumReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.AlbumReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.AlbumReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IAlbumFotoWriteRepository, Input.Repository.AlbumFoto.AlbumFotoWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IAlbumFotoReadRepository, Read.Repository.AlbumFotoReadRepository>();
builder.Services.AddTransient<IQuery.Read.IAlbumFotoQueryRead, Query.Read.AlbumFotoQueryRead>();
builder.Services.AddTransient<IQuery.Write.IAlbumFotoQueryWrite, Query.Write.AlbumFotoQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertAlbumFotoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateAlbumFotoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteAlbumFotoReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.AlbumFotoReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.AlbumFotoReadFKAlbumIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.AlbumFotoReadFKFotoIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.AlbumFotoReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.AlbumFotoReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IPublicacaoAlbumWriteRepository, Input.Repository.PublicacaoAlbum.PublicacaoAlbumWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IPublicacaoAlbumReadRepository, Read.Repository.PublicacaoAlbumReadRepository>();
builder.Services.AddTransient<IQuery.Read.IPublicacaoAlbumQueryRead, Query.Read.PublicacaoAlbumQueryRead>();
builder.Services.AddTransient<IQuery.Write.IPublicacaoAlbumQueryWrite, Query.Write.PublicacaoAlbumQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertPublicacaoAlbumReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdatePublicacaoAlbumReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeletePublicacaoAlbumReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.PublicacaoAlbumReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.PublicacaoAlbumReadFKAlbumIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.PublicacaoAlbumReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.PublicacaoAlbumReadFKUserIdReceiver>();

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

builder.Services.AddTransient<IRepository.Write.IyTenantApplicationWriteRepository, Input.Repository.yTenantApplication.yTenantApplicationWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IyTenantApplicationReadRepository, Read.Repository.yTenantApplicationReadRepository>();
builder.Services.AddTransient<IQuery.Read.IyTenantApplicationQueryRead, Query.Read.yTenantApplicationQueryRead>();
builder.Services.AddTransient<IQuery.Write.IyTenantApplicationQueryWrite, Query.Write.yTenantApplicationQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertyTenantApplicationReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateyTenantApplicationReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteyTenantApplicationReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yTenantApplicationReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yTenantApplicationReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.yTenantApplicationReadFKUserIdReceiver>();

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
builder.Services.AddTransient<Dominio.Saga.PublicarAlbumYouTubeSaga>();
builder.Services.AddTransient<Command.Receivers.PublicarAlbumYouTubeSagaHandlerResolver>();
builder.Services.AddTransient<PrepararManifestoAlbumHandler>();
builder.Services.AddTransient<RenderizarVideoAlbumHandler>();
builder.Services.AddTransient<EnviarVideoParaYouTubeHandler>();
builder.Services.AddTransient<FinalizarPublicacaoAlbumHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.SolicitarPublicacaoAlbumHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.StarSessionUploadHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.SendFileHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.RetrySagaStepHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.CreateContaHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.LoginHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.RecoveryAccountHandler>();
builder.Services.AddTransient<Dominio.Interfaces.Strategy.IMessage,Shered.Patterns.Strategy.Message>();
builder.Services.AddTransient<Shered.Patterns.Strategy.EmailNotification>();
builder.Services.AddTransient<Shered.Patterns.Strategy.SMSNotification>();
builder.Services.AddTransient<Shered.Patterns.Strategy.WhatsappNotification>();
builder.Services.AddTransient<Dominio.Interfaces.Strategy.IINotificationFactory,Shered.Patterns.Strategy.NotificationFactory>();
builder.Services.AddTransient<Dominio.Interfaces.Strategy.IMessage,Shered.Patterns.Strategy.Message>();

builder.Services.AddTransient<Command.Receivers.UseCase.OpenApplicationSessionHandler>();
}
public static Command.Interfaces.Patterns.Queue.QueueTopology GetQueueTopology()
{
return new Command.Interfaces.Patterns.Queue.QueueTopology
{
    Exchanges = new List<Command.Interfaces.Patterns.Queue.ExchangeDefinition>
    {
        new Command.Interfaces.Patterns.Queue.ExchangeDefinition
        {
            Name = "media.tasks",
            Type = "topic",
            Bindings = new List<Command.Interfaces.Patterns.Queue.QueueBindingDefinition>
            {
                new Command.Interfaces.Patterns.Queue.QueueBindingDefinition
                {
                    QueueName = "media.album.render.outbox",
                    RoutingKey = "media.album.render"
                },
            }
        },
        new Command.Interfaces.Patterns.Queue.ExchangeDefinition
        {
            Name = "media.results",
            Type = "topic",
            Bindings = new List<Command.Interfaces.Patterns.Queue.QueueBindingDefinition>
            {
                new Command.Interfaces.Patterns.Queue.QueueBindingDefinition
                {
                    QueueName = "media.album.rendered.inbox",
                    RoutingKey = "media.album.rendered"
                },
            }
        },
    }
};
}
}
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureDependencInjectionInjectionMigration