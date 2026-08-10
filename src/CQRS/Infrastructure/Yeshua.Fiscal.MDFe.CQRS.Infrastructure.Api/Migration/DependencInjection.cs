using System;
using Shered.Services;
using RepositoryInterfaces.Services;
using Command.Patterns;
using Command.Interfaces;
using Command.Patterns.OutBox;
using Command.Receivers;
using RepositoryInterfaces.Patterns.UnitOfWork;
using Shered.DB.Connection;
using Aplication.Interfaces.Services;
namespace Migrations
{
public static class DependencInjection
{
public static void MapDependencInjection(WebApplicationBuilder builder)
{


                    builder.Services.AddScoped<UnitOfWork>();
                    builder.Services.AddScoped<RepositoryInterfaces.Patterns.UnitOfWork.IUnitOfWork>(sp =>
                        new InstrumentedUnitOfWork(
                            sp.GetRequiredService<UnitOfWork>(),
                            sp.GetRequiredService<Dominio.Interfaces.ILogger>(),
                            sp.GetRequiredService<IExecutionContext>()
                        ));


                    builder.Services.AddSingleton(typeof(ICacheService<>), typeof(MemoryCacheService<>));
                    builder.Services.AddSingleton<ICacheKeyIndexManager, CacheKeyIndexManager>();
                    builder.Services.AddTransient<Dominio.Interfaces.ILogger, Shered.Logger.Logger>();
                    builder.Services.AddTransient<ISagaExecutor, SagaExecutor>();
                    builder.Services.AddScoped<OutboxService>();


builder.Services.AddTransient<IRepository.Write.IMDFeWriteRepository, Input.Repository.MDFe.MDFeWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IMDFeReadRepository, Read.Repository.MDFeReadRepository>();
builder.Services.AddTransient<IQuery.Read.IMDFeQueryRead, Query.Read.MDFeQueryRead>();
builder.Services.AddTransient<IQuery.Write.IMDFeQueryWrite, Query.Write.MDFeQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertMDFeReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateMDFeReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteMDFeReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MDFeReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MDFeReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MDFeReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IMDFeEncerramentoWriteRepository, Input.Repository.MDFeEncerramento.MDFeEncerramentoWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IMDFeEncerramentoReadRepository, Read.Repository.MDFeEncerramentoReadRepository>();
builder.Services.AddTransient<IQuery.Read.IMDFeEncerramentoQueryRead, Query.Read.MDFeEncerramentoQueryRead>();
builder.Services.AddTransient<IQuery.Write.IMDFeEncerramentoQueryWrite, Query.Write.MDFeEncerramentoQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertMDFeEncerramentoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateMDFeEncerramentoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteMDFeEncerramentoReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MDFeEncerramentoReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MDFeEncerramentoReadFKMDFeIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MDFeEncerramentoReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MDFeEncerramentoReadFKUserIdReceiver>();

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

builder.Services.AddTransient<Command.Receivers.UseCase.EncerrarMDFeHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.StarSessionUploadHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.SendFileHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.CreateContaHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.LoginHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.RecoveryAccountHandler>();
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