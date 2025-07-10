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
builder.Services.AddTransient<RepositoryInterfaces.Read.Repository.Especialidade.IEspecialidadeReadRepository, Read.ConcreteRepository.Especialidade.EspecialidadeReadRepository>();
builder.Services.AddTransient<Command.Receivers.Write.InsertEspecialidadeReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateEspecialidadeReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteEspecialidadeReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.EspecialidadeReadReceiver>();

builder.Services.AddTransient<Repositorio.Inputs.Repositorio.Profissional.IProfissionalWriteRepository, Input.Repository.Profissional.ProfissionalWriteRepository>();
builder.Services.AddTransient<RepositoryInterfaces.Read.Repository.Profissional.IProfissionalReadRepository, Read.ConcreteRepository.Profissional.ProfissionalReadRepository>();
builder.Services.AddTransient<Command.Receivers.Write.InsertProfissionalReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateProfissionalReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteProfissionalReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ProfissionalReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ProfissionalReadFKEspecialidadeIdReceiver>();

builder.Services.AddTransient<Repositorio.Inputs.Repositorio.DisponibilidadeAgenda.IDisponibilidadeAgendaWriteRepository, Input.Repository.DisponibilidadeAgenda.DisponibilidadeAgendaWriteRepository>();
builder.Services.AddTransient<RepositoryInterfaces.Read.Repository.DisponibilidadeAgenda.IDisponibilidadeAgendaReadRepository, Read.ConcreteRepository.DisponibilidadeAgenda.DisponibilidadeAgendaReadRepository>();
builder.Services.AddTransient<Command.Receivers.Write.InsertDisponibilidadeAgendaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateDisponibilidadeAgendaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteDisponibilidadeAgendaReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.DisponibilidadeAgendaReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.DisponibilidadeAgendaReadFKProfissionalIdReceiver>();

builder.Services.AddTransient<Repositorio.Inputs.Repositorio.GrupoServico.IGrupoServicoWriteRepository, Input.Repository.GrupoServico.GrupoServicoWriteRepository>();
builder.Services.AddTransient<RepositoryInterfaces.Read.Repository.GrupoServico.IGrupoServicoReadRepository, Read.ConcreteRepository.GrupoServico.GrupoServicoReadRepository>();
builder.Services.AddTransient<Command.Receivers.Write.InsertGrupoServicoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateGrupoServicoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteGrupoServicoReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.GrupoServicoReadReceiver>();

builder.Services.AddTransient<Repositorio.Inputs.Repositorio.Servico.IServicoWriteRepository, Input.Repository.Servico.ServicoWriteRepository>();
builder.Services.AddTransient<RepositoryInterfaces.Read.Repository.Servico.IServicoReadRepository, Read.ConcreteRepository.Servico.ServicoReadRepository>();
builder.Services.AddTransient<Command.Receivers.Write.InsertServicoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateServicoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteServicoReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ServicoReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ServicoReadFKGrupoServicoIdReceiver>();

builder.Services.AddTransient<Repositorio.Inputs.Repositorio.Paciente.IPacienteWriteRepository, Input.Repository.Paciente.PacienteWriteRepository>();
builder.Services.AddTransient<RepositoryInterfaces.Read.Repository.Paciente.IPacienteReadRepository, Read.ConcreteRepository.Paciente.PacienteReadRepository>();
builder.Services.AddTransient<Command.Receivers.Write.InsertPacienteReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdatePacienteReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeletePacienteReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.PacienteReadReceiver>();

builder.Services.AddTransient<Repositorio.Inputs.Repositorio.MovimentacaoFinanceira.IMovimentacaoFinanceiraWriteRepository, Input.Repository.MovimentacaoFinanceira.MovimentacaoFinanceiraWriteRepository>();
builder.Services.AddTransient<RepositoryInterfaces.Read.Repository.MovimentacaoFinanceira.IMovimentacaoFinanceiraReadRepository, Read.ConcreteRepository.MovimentacaoFinanceira.MovimentacaoFinanceiraReadRepository>();
builder.Services.AddTransient<Command.Receivers.Write.InsertMovimentacaoFinanceiraReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateMovimentacaoFinanceiraReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteMovimentacaoFinanceiraReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MovimentacaoFinanceiraReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MovimentacaoFinanceiraReadFKPacienteIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MovimentacaoFinanceiraReadFKServicoIdReceiver>();

builder.Services.AddTransient<Repositorio.Inputs.Repositorio.Sesoes.ISesoesWriteRepository, Input.Repository.Sesoes.SesoesWriteRepository>();
builder.Services.AddTransient<RepositoryInterfaces.Read.Repository.Sesoes.ISesoesReadRepository, Read.ConcreteRepository.Sesoes.SesoesReadRepository>();
builder.Services.AddTransient<Command.Receivers.Write.InsertSesoesReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateSesoesReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteSesoesReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.SesoesReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.SesoesReadFKPacienteIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.SesoesReadFKProfissionalIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.SesoesReadFKServicoIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.SesoesReadFKMovimentacaoFinanceiraIdReceiver>();

builder.Services.AddTransient<Repositorio.Inputs.Repositorio.Clinica.IClinicaWriteRepository, Input.Repository.Clinica.ClinicaWriteRepository>();
builder.Services.AddTransient<RepositoryInterfaces.Read.Repository.Clinica.IClinicaReadRepository, Read.ConcreteRepository.Clinica.ClinicaReadRepository>();
builder.Services.AddTransient<Command.Receivers.Write.InsertClinicaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateClinicaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteClinicaReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ClinicaReadReceiver>();

builder.Services.AddTransient<Repositorio.Inputs.Repositorio.Y_Tenant.IY_TenantWriteRepository, Input.Repository.Y_Tenant.Y_TenantWriteRepository>();
builder.Services.AddTransient<RepositoryInterfaces.Read.Repository.Y_Tenant.IY_TenantReadRepository, Read.ConcreteRepository.Y_Tenant.Y_TenantReadRepository>();
builder.Services.AddTransient<Command.Receivers.Write.InsertY_TenantReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateY_TenantReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteY_TenantReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.Y_TenantReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.Y_TenantReadFKUserIDAdminReceiver>();

builder.Services.AddTransient<Repositorio.Inputs.Repositorio.Y_User.IY_UserWriteRepository, Input.Repository.Y_User.Y_UserWriteRepository>();
builder.Services.AddTransient<RepositoryInterfaces.Read.Repository.Y_User.IY_UserReadRepository, Read.ConcreteRepository.Y_User.Y_UserReadRepository>();
builder.Services.AddTransient<Command.Receivers.Write.InsertY_UserReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateY_UserReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteY_UserReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.Y_UserReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.Y_UserReadFKTenantIDReceiver>();

builder.Services.AddTransient<Repositorio.Inputs.Repositorio.Y_Tenant_Configuration.IY_Tenant_ConfigurationWriteRepository, Input.Repository.Y_Tenant_Configuration.Y_Tenant_ConfigurationWriteRepository>();
builder.Services.AddTransient<Read.ConcreteRepository.Y_Tenant_Configuration.Y_Tenant_ConfigurationReadRepository>();
    builder.Services.AddTransient<RepositoryInterfaces.Read.Repository.Y_Tenant_Configuration.IY_Tenant_ConfigurationReadRepository>(sp =>
    {
    var inner = sp.GetRequiredService<Read.ConcreteRepository.Y_Tenant_Configuration.Y_Tenant_ConfigurationReadRepository>();
    var cacheById = sp.GetRequiredService<ICacheService<Repositorio.Outputs.DTOs.Y_Tenant_Configuration.Y_Tenant_ConfigurationDTO >>();
    var cacheAll = sp.GetRequiredService<ICacheService<IEnumerable<Repositorio.Outputs.DTOs.Y_Tenant_Configuration.Y_Tenant_ConfigurationDTO>>>();
        var cacheFKTenantID = sp.GetRequiredService<ICacheService<IEnumerable<Repositorio.Outputs.DTOs.Y_Tenant_Configuration.Y_Tenant_ConfigurationTenantIDDTO>>>();
    return new Read.ConcreteRepository.Y_Tenant_Configuration.Y_Tenant_ConfigurationReadRepositoryCacheDecorator(inner,cacheById,cacheAll,cacheFKTenantID    );
});
builder.Services.AddTransient<Command.Receivers.Write.InsertY_Tenant_ConfigurationReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateY_Tenant_ConfigurationReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteY_Tenant_ConfigurationReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.Y_Tenant_ConfigurationReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.Y_Tenant_ConfigurationReadFKTenantIDReceiver>();

builder.Services.AddTransient<Command.Receivers.UseCase.ContasCreateContaUseCaseReceiver>();

builder.Services.AddTransient<Command.Receivers.UseCase.ContasLoginUseCaseReceiver>();

builder.Services.AddTransient<Command.Receivers.UseCase.ContasRecoveryAccountUseCaseReceiver>();
}
}
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureAPIIndependenceInjectionMigration