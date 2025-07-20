using Shered.Services;
using RepositoryInterfaces.Services;
namespace API.Migrations
{
public static class IndependenceInjection
{
public static void MapIndependenceInjection(WebApplicationBuilder builder)
{

                    builder.Services.AddScoped<RepositoryInterfaces.Patterns.UnitOfWork.IUnitOfWork, Shered.DB.Connection.UnitOfWork>();
                    builder.Services.AddSingleton(typeof(ICacheService<>), typeof(MemoryCacheService<>));
                    builder.Services.AddSingleton<ICacheKeyIndexManager, CacheKeyIndexManager>();
                    builder.Services.AddTransient<Dominio.Interfaces.ILogger, Shered.Logger.Logger>();
            

builder.Services.AddTransient<IRepository.Write.IEspecialidadeWriteRepository, Input.Repository.Especialidade.EspecialidadeWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IEspecialidadeReadRepository, Read.Repository.EspecialidadeReadRepository>();
builder.Services.AddTransient<IQuery.Read.IEspecialidadeQueryRead, Query.Read.EspecialidadeQueryRead>();
builder.Services.AddTransient<IQuery.Write.IEspecialidadeQueryWrite, Query.Write.EspecialidadeQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertEspecialidadeReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateEspecialidadeReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteEspecialidadeReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.EspecialidadeReadReceiver>();

builder.Services.AddTransient<IRepository.Write.IProfissionalWriteRepository, Input.Repository.Profissional.ProfissionalWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IProfissionalReadRepository, Read.Repository.ProfissionalReadRepository>();
builder.Services.AddTransient<IQuery.Read.IProfissionalQueryRead, Query.Read.ProfissionalQueryRead>();
builder.Services.AddTransient<IQuery.Write.IProfissionalQueryWrite, Query.Write.ProfissionalQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertProfissionalReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateProfissionalReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteProfissionalReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ProfissionalReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ProfissionalReadFKEspecialidadeIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IDisponibilidadeAgendaWriteRepository, Input.Repository.DisponibilidadeAgenda.DisponibilidadeAgendaWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IDisponibilidadeAgendaReadRepository, Read.Repository.DisponibilidadeAgendaReadRepository>();
builder.Services.AddTransient<IQuery.Read.IDisponibilidadeAgendaQueryRead, Query.Read.DisponibilidadeAgendaQueryRead>();
builder.Services.AddTransient<IQuery.Write.IDisponibilidadeAgendaQueryWrite, Query.Write.DisponibilidadeAgendaQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertDisponibilidadeAgendaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateDisponibilidadeAgendaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteDisponibilidadeAgendaReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.DisponibilidadeAgendaReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.DisponibilidadeAgendaReadFKProfissionalIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IGrupoServicoWriteRepository, Input.Repository.GrupoServico.GrupoServicoWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IGrupoServicoReadRepository, Read.Repository.GrupoServicoReadRepository>();
builder.Services.AddTransient<IQuery.Read.IGrupoServicoQueryRead, Query.Read.GrupoServicoQueryRead>();
builder.Services.AddTransient<IQuery.Write.IGrupoServicoQueryWrite, Query.Write.GrupoServicoQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertGrupoServicoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateGrupoServicoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteGrupoServicoReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.GrupoServicoReadReceiver>();

builder.Services.AddTransient<IRepository.Write.IServicoWriteRepository, Input.Repository.Servico.ServicoWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IServicoReadRepository, Read.Repository.ServicoReadRepository>();
builder.Services.AddTransient<IQuery.Read.IServicoQueryRead, Query.Read.ServicoQueryRead>();
builder.Services.AddTransient<IQuery.Write.IServicoQueryWrite, Query.Write.ServicoQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertServicoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateServicoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteServicoReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ServicoReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ServicoReadFKGrupoServicoIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IPacienteWriteRepository, Input.Repository.Paciente.PacienteWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IPacienteReadRepository, Read.Repository.PacienteReadRepository>();
builder.Services.AddTransient<IQuery.Read.IPacienteQueryRead, Query.Read.PacienteQueryRead>();
builder.Services.AddTransient<IQuery.Write.IPacienteQueryWrite, Query.Write.PacienteQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertPacienteReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdatePacienteReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeletePacienteReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.PacienteReadReceiver>();

builder.Services.AddTransient<IRepository.Write.IMovimentacaoFinanceiraWriteRepository, Input.Repository.MovimentacaoFinanceira.MovimentacaoFinanceiraWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IMovimentacaoFinanceiraReadRepository, Read.Repository.MovimentacaoFinanceiraReadRepository>();
builder.Services.AddTransient<IQuery.Read.IMovimentacaoFinanceiraQueryRead, Query.Read.MovimentacaoFinanceiraQueryRead>();
builder.Services.AddTransient<IQuery.Write.IMovimentacaoFinanceiraQueryWrite, Query.Write.MovimentacaoFinanceiraQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertMovimentacaoFinanceiraReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateMovimentacaoFinanceiraReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteMovimentacaoFinanceiraReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MovimentacaoFinanceiraReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MovimentacaoFinanceiraReadFKPacienteIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MovimentacaoFinanceiraReadFKServicoIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ISesoesWriteRepository, Input.Repository.Sesoes.SesoesWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ISesoesReadRepository, Read.Repository.SesoesReadRepository>();
builder.Services.AddTransient<IQuery.Read.ISesoesQueryRead, Query.Read.SesoesQueryRead>();
builder.Services.AddTransient<IQuery.Write.ISesoesQueryWrite, Query.Write.SesoesQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertSesoesReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateSesoesReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteSesoesReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.SesoesReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.SesoesReadFKPacienteIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.SesoesReadFKProfissionalIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.SesoesReadFKServicoIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.SesoesReadFKMovimentacaoFinanceiraIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IClinicaWriteRepository, Input.Repository.Clinica.ClinicaWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IClinicaReadRepository, Read.Repository.ClinicaReadRepository>();
builder.Services.AddTransient<IQuery.Read.IClinicaQueryRead, Query.Read.ClinicaQueryRead>();
builder.Services.AddTransient<IQuery.Write.IClinicaQueryWrite, Query.Write.ClinicaQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertClinicaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateClinicaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteClinicaReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ClinicaReadReceiver>();

builder.Services.AddTransient<IRepository.Write.IYtenantWriteRepository, Input.Repository.Ytenant.YtenantWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IYtenantReadRepository, Read.Repository.YtenantReadRepository>();
builder.Services.AddTransient<IQuery.Read.IYtenantQueryRead, Query.Read.YtenantQueryRead>();
builder.Services.AddTransient<IQuery.Write.IYtenantQueryWrite, Query.Write.YtenantQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertYtenantReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateYtenantReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteYtenantReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.YtenantReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.YtenantReadFKUserIDAdminReceiver>();

builder.Services.AddTransient<IRepository.Write.IYStandardFieldsWriteRepository, Input.Repository.YStandardFields.YStandardFieldsWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IYStandardFieldsReadRepository, Read.Repository.YStandardFieldsReadRepository>();
builder.Services.AddTransient<IQuery.Read.IYStandardFieldsQueryRead, Query.Read.YStandardFieldsQueryRead>();
builder.Services.AddTransient<IQuery.Write.IYStandardFieldsQueryWrite, Query.Write.YStandardFieldsQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertYStandardFieldsReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateYStandardFieldsReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteYStandardFieldsReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.YStandardFieldsReadReceiver>();

builder.Services.AddTransient<IRepository.Write.IYuserWriteRepository, Input.Repository.Yuser.YuserWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IYuserReadRepository, Read.Repository.YuserReadRepository>();
builder.Services.AddTransient<IQuery.Read.IYuserQueryRead, Query.Read.YuserQueryRead>();
builder.Services.AddTransient<IQuery.Write.IYuserQueryWrite, Query.Write.YuserQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertYuserReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateYuserReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteYuserReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.YuserReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.YuserReadFKTenantIDReceiver>();

builder.Services.AddTransient<IRepository.Write.IYconfigArctetureWriteRepository, Input.Repository.YconfigArcteture.YconfigArctetureWriteRepository>();
builder.Services.AddTransient<Read.Repository.YconfigArctetureReadRepository>();
    builder.Services.AddTransient<IRepository.Read.IYconfigArctetureReadRepository>(sp =>
    {
    var inner = sp.GetRequiredService<Read.Repository.YconfigArctetureReadRepository>();
    var cacheById = sp.GetRequiredService<ICacheService<Repositorio.Outputs.YconfigArctetureDTO >>();
    var cacheAll = sp.GetRequiredService<ICacheService<IEnumerable<Repositorio.Outputs.YconfigArctetureDTO>>>();
        var cacheFKTenantID = sp.GetRequiredService<ICacheService<IEnumerable<Repositorio.Outputs.YconfigArctetureTenantIDDTO>>>();
    return new Read.Repository.YconfigArctetureReadRepositoryCacheDecorator(inner,cacheById,cacheAll,cacheFKTenantID    );
});
builder.Services.AddTransient<Command.Receivers.Write.InsertYconfigArctetureReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateYconfigArctetureReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteYconfigArctetureReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.YconfigArctetureReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.YconfigArctetureReadFKTenantIDReceiver>();
builder.Services.AddTransient<IRepository.Write.IYconfigArctetureWriteRepository, Input.Repository.YconfigArcteture.YconfigArctetureWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IYconfigArctetureReadRepository, Read.Repository.YconfigArctetureReadRepository>();
builder.Services.AddTransient<IQuery.Read.IYconfigArctetureQueryRead, Query.Read.YconfigArctetureQueryRead>();
builder.Services.AddTransient<IQuery.Write.IYconfigArctetureQueryWrite, Query.Write.YconfigArctetureQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertYconfigArctetureReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateYconfigArctetureReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteYconfigArctetureReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.YconfigArctetureReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.YconfigArctetureReadFKTenantIDReceiver>();

builder.Services.AddTransient<IRepository.Write.IYconfigNotificationWriteRepository, Input.Repository.YconfigNotification.YconfigNotificationWriteRepository>();
builder.Services.AddTransient<Read.Repository.YconfigNotificationReadRepository>();
    builder.Services.AddTransient<IRepository.Read.IYconfigNotificationReadRepository>(sp =>
    {
    var inner = sp.GetRequiredService<Read.Repository.YconfigNotificationReadRepository>();
    var cacheById = sp.GetRequiredService<ICacheService<Repositorio.Outputs.YconfigNotificationDTO >>();
    var cacheAll = sp.GetRequiredService<ICacheService<IEnumerable<Repositorio.Outputs.YconfigNotificationDTO>>>();
        var cacheFKTenantID = sp.GetRequiredService<ICacheService<IEnumerable<Repositorio.Outputs.YconfigNotificationTenantIDDTO>>>();
    return new Read.Repository.YconfigNotificationReadRepositoryCacheDecorator(inner,cacheById,cacheAll,cacheFKTenantID    );
});
builder.Services.AddTransient<Command.Receivers.Write.InsertYconfigNotificationReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateYconfigNotificationReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteYconfigNotificationReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.YconfigNotificationReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.YconfigNotificationReadFKTenantIDReceiver>();
builder.Services.AddTransient<IRepository.Write.IYconfigNotificationWriteRepository, Input.Repository.YconfigNotification.YconfigNotificationWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IYconfigNotificationReadRepository, Read.Repository.YconfigNotificationReadRepository>();
builder.Services.AddTransient<IQuery.Read.IYconfigNotificationQueryRead, Query.Read.YconfigNotificationQueryRead>();
builder.Services.AddTransient<IQuery.Write.IYconfigNotificationQueryWrite, Query.Write.YconfigNotificationQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertYconfigNotificationReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateYconfigNotificationReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteYconfigNotificationReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.YconfigNotificationReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.YconfigNotificationReadFKTenantIDReceiver>();

builder.Services.AddTransient<IRepository.Write.IYperfilWriteRepository, Input.Repository.Yperfil.YperfilWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IYperfilReadRepository, Read.Repository.YperfilReadRepository>();
builder.Services.AddTransient<IQuery.Read.IYperfilQueryRead, Query.Read.YperfilQueryRead>();
builder.Services.AddTransient<IQuery.Write.IYperfilQueryWrite, Query.Write.YperfilQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertYperfilReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateYperfilReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteYperfilReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.YperfilReadReceiver>();

builder.Services.AddTransient<IRepository.Write.IYpermtionsWriteRepository, Input.Repository.Ypermtions.YpermtionsWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IYpermtionsReadRepository, Read.Repository.YpermtionsReadRepository>();
builder.Services.AddTransient<IQuery.Read.IYpermtionsQueryRead, Query.Read.YpermtionsQueryRead>();
builder.Services.AddTransient<IQuery.Write.IYpermtionsQueryWrite, Query.Write.YpermtionsQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertYpermtionsReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateYpermtionsReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteYpermtionsReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.YpermtionsReadReceiver>();

builder.Services.AddTransient<IRepository.Write.IYperfilPermitionsWriteRepository, Input.Repository.YperfilPermitions.YperfilPermitionsWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IYperfilPermitionsReadRepository, Read.Repository.YperfilPermitionsReadRepository>();
builder.Services.AddTransient<IQuery.Read.IYperfilPermitionsQueryRead, Query.Read.YperfilPermitionsQueryRead>();
builder.Services.AddTransient<IQuery.Write.IYperfilPermitionsQueryWrite, Query.Write.YperfilPermitionsQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertYperfilPermitionsReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateYperfilPermitionsReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteYperfilPermitionsReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.YperfilPermitionsReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.YperfilPermitionsReadFKPerfilIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.YperfilPermitionsReadFKPermitionsIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IYpserPermitionsWriteRepository, Input.Repository.YpserPermitions.YpserPermitionsWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IYpserPermitionsReadRepository, Read.Repository.YpserPermitionsReadRepository>();
builder.Services.AddTransient<IQuery.Read.IYpserPermitionsQueryRead, Query.Read.YpserPermitionsQueryRead>();
builder.Services.AddTransient<IQuery.Write.IYpserPermitionsQueryWrite, Query.Write.YpserPermitionsQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertYpserPermitionsReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateYpserPermitionsReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteYpserPermitionsReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.YpserPermitionsReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.YpserPermitionsReadFKUserIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.YpserPermitionsReadFKPermitionsIdReceiver>();

builder.Services.AddTransient<Command.Receivers.UseCase.ContasCreateContaUseCaseReceiver>();

builder.Services.AddTransient<Command.Receivers.UseCase.ContasLoginUseCaseReceiver>();

builder.Services.AddTransient<Command.Receivers.UseCase.ContasRecoveryAccountUseCaseReceiver>();
builder.Services.AddTransient<Shered.Patterns.Strategy.EmailNotification>();
builder.Services.AddTransient<Shered.Patterns.Strategy.SMSNotification>();
builder.Services.AddTransient<Shered.Patterns.Strategy.WhatsappNotification>();
builder.Services.AddTransient<Dominio.Interfaces.Strategy.IINotificationFactory,Shered.Patterns.Strategy.NotificationFactory>();
builder.Services.AddTransient<Dominio.Interfaces.Strategy.IMessage,Shered.Patterns.Strategy.Message>();
}
}
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureAPIIndependenceInjectionMigration