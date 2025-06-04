namespace API.Migrations
{
public static class IndependenceInjection
{
public static void MapIndependenceInjection(WebApplicationBuilder builder)
{
builder.Services.AddScoped<RepositoryInterfaces.Patterns.UnitOfWork.IUnitOfWork, Shered.DB.Connection.UnitOfWork>();

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

builder.Services.AddTransient<Repositorio.Inputs.Repositorio.Y_User.IY_UserWriteRepository, Input.Repository.Y_User.Y_UserWriteRepository>();
builder.Services.AddTransient<RepositoryInterfaces.Read.Repository.Y_User.IY_UserReadRepository, Read.ConcreteRepository.Y_User.Y_UserReadRepository>();
builder.Services.AddTransient<Command.Receivers.Write.InsertY_UserReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateY_UserReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteY_UserReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.Y_UserReadReceiver>();

builder.Services.AddTransient<Repositorio.Inputs.Repositorio.Y_Company.IY_CompanyWriteRepository, Input.Repository.Y_Company.Y_CompanyWriteRepository>();
builder.Services.AddTransient<RepositoryInterfaces.Read.Repository.Y_Company.IY_CompanyReadRepository, Read.ConcreteRepository.Y_Company.Y_CompanyReadRepository>();
builder.Services.AddTransient<Command.Receivers.Write.InsertY_CompanyReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateY_CompanyReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteY_CompanyReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.Y_CompanyReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.Y_CompanyReadFKUserIDAdminReceiver>();

builder.Services.AddTransient<Repositorio.Inputs.Repositorio.Y_Perfil.IY_PerfilWriteRepository, Input.Repository.Y_Perfil.Y_PerfilWriteRepository>();
builder.Services.AddTransient<RepositoryInterfaces.Read.Repository.Y_Perfil.IY_PerfilReadRepository, Read.ConcreteRepository.Y_Perfil.Y_PerfilReadRepository>();
builder.Services.AddTransient<Command.Receivers.Write.InsertY_PerfilReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateY_PerfilReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteY_PerfilReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.Y_PerfilReadReceiver>();

builder.Services.AddTransient<Repositorio.Inputs.Repositorio.Y_Permtions.IY_PermtionsWriteRepository, Input.Repository.Y_Permtions.Y_PermtionsWriteRepository>();
builder.Services.AddTransient<RepositoryInterfaces.Read.Repository.Y_Permtions.IY_PermtionsReadRepository, Read.ConcreteRepository.Y_Permtions.Y_PermtionsReadRepository>();
builder.Services.AddTransient<Command.Receivers.Write.InsertY_PermtionsReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateY_PermtionsReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteY_PermtionsReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.Y_PermtionsReadReceiver>();

builder.Services.AddTransient<Repositorio.Inputs.Repositorio.Y_PerfilPermitions.IY_PerfilPermitionsWriteRepository, Input.Repository.Y_PerfilPermitions.Y_PerfilPermitionsWriteRepository>();
builder.Services.AddTransient<RepositoryInterfaces.Read.Repository.Y_PerfilPermitions.IY_PerfilPermitionsReadRepository, Read.ConcreteRepository.Y_PerfilPermitions.Y_PerfilPermitionsReadRepository>();
builder.Services.AddTransient<Command.Receivers.Write.InsertY_PerfilPermitionsReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateY_PerfilPermitionsReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteY_PerfilPermitionsReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.Y_PerfilPermitionsReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.Y_PerfilPermitionsReadFKPerfilIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.Y_PerfilPermitionsReadFKPermitionsIdReceiver>();

builder.Services.AddTransient<Repositorio.Inputs.Repositorio.Y_UserPermitions.IY_UserPermitionsWriteRepository, Input.Repository.Y_UserPermitions.Y_UserPermitionsWriteRepository>();
builder.Services.AddTransient<RepositoryInterfaces.Read.Repository.Y_UserPermitions.IY_UserPermitionsReadRepository, Read.ConcreteRepository.Y_UserPermitions.Y_UserPermitionsReadRepository>();
builder.Services.AddTransient<Command.Receivers.Write.InsertY_UserPermitionsReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateY_UserPermitionsReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteY_UserPermitionsReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.Y_UserPermitionsReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.Y_UserPermitionsReadFKUserIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.Y_UserPermitionsReadFKPermitionsIdReceiver>();

builder.Services.AddTransient<Command.Receivers.HubServiceMethod.ContasCreateContaServiceMethodReceiver>();

builder.Services.AddTransient<Command.Receivers.HubServiceMethod.ContasLoginServiceMethodReceiver>();
}
}
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureAPIIndependenceInjectionMigration