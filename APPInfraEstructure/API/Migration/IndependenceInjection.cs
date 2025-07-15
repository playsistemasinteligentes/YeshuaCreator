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
            

builder.Services.AddTransient<Repositorio.Inputs.Repositorio.Especialidade.IEspecialidadeWriteRepository, Input.Repository.Especialidade.EspecialidadeWriteRepository>();
builder.Services.AddTransient<Read.RepositoryInterfaces.IEspecialidadeReadRepository, Read.Repository.EspecialidadeReadRepository>();
builder.Services.AddTransient<Command.Receivers.Write.InsertEspecialidadeReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateEspecialidadeReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteEspecialidadeReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.EspecialidadeReadReceiver>();

builder.Services.AddTransient<Repositorio.Inputs.Repositorio.Profissional.IProfissionalWriteRepository, Input.Repository.Profissional.ProfissionalWriteRepository>();
builder.Services.AddTransient<Read.RepositoryInterfaces.IProfissionalReadRepository, Read.Repository.ProfissionalReadRepository>();
builder.Services.AddTransient<Command.Receivers.Write.InsertProfissionalReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateProfissionalReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteProfissionalReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ProfissionalReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ProfissionalReadFKEspecialidadeIdReceiver>();

builder.Services.AddTransient<Repositorio.Inputs.Repositorio.DisponibilidadeAgenda.IDisponibilidadeAgendaWriteRepository, Input.Repository.DisponibilidadeAgenda.DisponibilidadeAgendaWriteRepository>();
builder.Services.AddTransient<Read.RepositoryInterfaces.IDisponibilidadeAgendaReadRepository, Read.Repository.DisponibilidadeAgendaReadRepository>();
builder.Services.AddTransient<Command.Receivers.Write.InsertDisponibilidadeAgendaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateDisponibilidadeAgendaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteDisponibilidadeAgendaReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.DisponibilidadeAgendaReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.DisponibilidadeAgendaReadFKProfissionalIdReceiver>();

builder.Services.AddTransient<Repositorio.Inputs.Repositorio.GrupoServico.IGrupoServicoWriteRepository, Input.Repository.GrupoServico.GrupoServicoWriteRepository>();
builder.Services.AddTransient<Read.RepositoryInterfaces.IGrupoServicoReadRepository, Read.Repository.GrupoServicoReadRepository>();
builder.Services.AddTransient<Command.Receivers.Write.InsertGrupoServicoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateGrupoServicoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteGrupoServicoReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.GrupoServicoReadReceiver>();

builder.Services.AddTransient<Repositorio.Inputs.Repositorio.Servico.IServicoWriteRepository, Input.Repository.Servico.ServicoWriteRepository>();
builder.Services.AddTransient<Read.RepositoryInterfaces.IServicoReadRepository, Read.Repository.ServicoReadRepository>();
builder.Services.AddTransient<Command.Receivers.Write.InsertServicoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateServicoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteServicoReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ServicoReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ServicoReadFKGrupoServicoIdReceiver>();

builder.Services.AddTransient<Repositorio.Inputs.Repositorio.Paciente.IPacienteWriteRepository, Input.Repository.Paciente.PacienteWriteRepository>();
builder.Services.AddTransient<Read.RepositoryInterfaces.IPacienteReadRepository, Read.Repository.PacienteReadRepository>();
builder.Services.AddTransient<Command.Receivers.Write.InsertPacienteReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdatePacienteReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeletePacienteReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.PacienteReadReceiver>();

builder.Services.AddTransient<Repositorio.Inputs.Repositorio.MovimentacaoFinanceira.IMovimentacaoFinanceiraWriteRepository, Input.Repository.MovimentacaoFinanceira.MovimentacaoFinanceiraWriteRepository>();
builder.Services.AddTransient<Read.RepositoryInterfaces.IMovimentacaoFinanceiraReadRepository, Read.Repository.MovimentacaoFinanceiraReadRepository>();
builder.Services.AddTransient<Command.Receivers.Write.InsertMovimentacaoFinanceiraReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateMovimentacaoFinanceiraReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteMovimentacaoFinanceiraReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MovimentacaoFinanceiraReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MovimentacaoFinanceiraReadFKPacienteIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MovimentacaoFinanceiraReadFKServicoIdReceiver>();

builder.Services.AddTransient<Repositorio.Inputs.Repositorio.Sesoes.ISesoesWriteRepository, Input.Repository.Sesoes.SesoesWriteRepository>();
builder.Services.AddTransient<Read.RepositoryInterfaces.ISesoesReadRepository, Read.Repository.SesoesReadRepository>();
builder.Services.AddTransient<Command.Receivers.Write.InsertSesoesReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateSesoesReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteSesoesReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.SesoesReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.SesoesReadFKPacienteIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.SesoesReadFKProfissionalIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.SesoesReadFKServicoIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.SesoesReadFKMovimentacaoFinanceiraIdReceiver>();

builder.Services.AddTransient<Repositorio.Inputs.Repositorio.Clinica.IClinicaWriteRepository, Input.Repository.Clinica.ClinicaWriteRepository>();
builder.Services.AddTransient<Read.RepositoryInterfaces.IClinicaReadRepository, Read.Repository.ClinicaReadRepository>();
builder.Services.AddTransient<Command.Receivers.Write.InsertClinicaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateClinicaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteClinicaReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ClinicaReadReceiver>();

builder.Services.AddTransient<Repositorio.Inputs.Repositorio.Ytenant.IYtenantWriteRepository, Input.Repository.Ytenant.YtenantWriteRepository>();
builder.Services.AddTransient<Read.RepositoryInterfaces.IYtenantReadRepository, Read.Repository.YtenantReadRepository>();
builder.Services.AddTransient<Command.Receivers.Write.InsertYtenantReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateYtenantReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteYtenantReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.YtenantReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.YtenantReadFKUserIDAdminReceiver>();

builder.Services.AddTransient<Repositorio.Inputs.Repositorio.Yuser.IYuserWriteRepository, Input.Repository.Yuser.YuserWriteRepository>();
builder.Services.AddTransient<Read.RepositoryInterfaces.IYuserReadRepository, Read.Repository.YuserReadRepository>();
builder.Services.AddTransient<Command.Receivers.Write.InsertYuserReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateYuserReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteYuserReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.YuserReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.YuserReadFKTenantIDReceiver>();

builder.Services.AddTransient<Repositorio.Inputs.Repositorio.Ytenant_Configuration.IYtenant_ConfigurationWriteRepository, Input.Repository.Ytenant_Configuration.Ytenant_ConfigurationWriteRepository>();
builder.Services.AddTransient<Read.Repository.Ytenant_ConfigurationReadRepository>();
    builder.Services.AddTransient<Read.RepositoryInterfaces.IYtenant_ConfigurationReadRepository>(sp =>
    {
    var inner = sp.GetRequiredService<Read.Repository.Ytenant_ConfigurationReadRepository>();
    var cacheById = sp.GetRequiredService<ICacheService<Repositorio.Outputs.Ytenant_ConfigurationDTO >>();
    var cacheAll = sp.GetRequiredService<ICacheService<IEnumerable<Repositorio.Outputs.Ytenant_ConfigurationDTO>>>();
        var cacheFKTenantID = sp.GetRequiredService<ICacheService<IEnumerable<Repositorio.Outputs.Ytenant_ConfigurationTenantIDDTO>>>();
    return new Read.Repository.Ytenant_ConfigurationReadRepositoryCacheDecorator(inner,cacheById,cacheAll,cacheFKTenantID    );
});
builder.Services.AddTransient<Command.Receivers.Write.InsertYtenant_ConfigurationReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateYtenant_ConfigurationReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteYtenant_ConfigurationReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.Ytenant_ConfigurationReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.Ytenant_ConfigurationReadFKTenantIDReceiver>();

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