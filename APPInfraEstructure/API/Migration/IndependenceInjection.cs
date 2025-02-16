namespace API.Migrations
{
    public static class IndependenceInjection
    {
        public static void MapIndependenceInjection(WebApplicationBuilder builder)
        {

            builder.Services.AddTransient<Repositorio.Inputs.Repositorio.Especialidade.IEspecialidadeWriteRepository, Input.Repository.Especialidade.EspecialidadeWriteRepository>();
            builder.Services.AddTransient<RepositoryInterfaces.Read.Repository.Especialidade.IEspecialidadeReadRepository, Read.ConcreteRepository.Especialidade.EspecialidadeReadRepository>();
            builder.Services.AddTransient<Comandos.Receivers.Especialidade.InsertEspecialidadeReceiver>();
            builder.Services.AddTransient<Comandos.Receivers.Especialidade.UpdateEspecialidadeReceiver>();
            builder.Services.AddTransient<Comandos.Receivers.Especialidade.DeleteEspecialidadeReceiver>();

            builder.Services.AddTransient<Repositorio.Inputs.Repositorio.Profissional.IProfissionalWriteRepository, Input.Repository.Profissional.ProfissionalWriteRepository>();
            builder.Services.AddTransient<RepositoryInterfaces.Read.Repository.Profissional.IProfissionalReadRepository, Read.ConcreteRepository.Profissional.ProfissionalReadRepository>();
            builder.Services.AddTransient<Comandos.Receivers.Profissional.InsertProfissionalReceiver>();

            builder.Services.AddTransient<Repositorio.Inputs.Repositorio.DisponibilidadeAgenda.IDisponibilidadeAgendaWriteRepository, Input.Repository.DisponibilidadeAgenda.DisponibilidadeAgendaWriteRepository>();
            builder.Services.AddTransient<RepositoryInterfaces.Read.Repository.DisponibilidadeAgenda.IDisponibilidadeAgendaReadRepository, Read.ConcreteRepository.DisponibilidadeAgenda.DisponibilidadeAgendaReadRepository>();
            builder.Services.AddTransient<Comandos.Receivers.DisponibilidadeAgenda.InsertDisponibilidadeAgendaReceiver>();

            builder.Services.AddTransient<Repositorio.Inputs.Repositorio.GrupoServico.IGrupoServicoWriteRepository, Input.Repository.GrupoServico.GrupoServicoWriteRepository>();
            builder.Services.AddTransient<RepositoryInterfaces.Read.Repository.GrupoServico.IGrupoServicoReadRepository, Read.ConcreteRepository.GrupoServico.GrupoServicoReadRepository>();
            builder.Services.AddTransient<Comandos.Receivers.GrupoServico.InsertGrupoServicoReceiver>();

            builder.Services.AddTransient<Repositorio.Inputs.Repositorio.Servico.IServicoWriteRepository, Input.Repository.Servico.ServicoWriteRepository>();
            builder.Services.AddTransient<RepositoryInterfaces.Read.Repository.Servico.IServicoReadRepository, Read.ConcreteRepository.Servico.ServicoReadRepository>();
            builder.Services.AddTransient<Comandos.Receivers.Servico.InsertServicoReceiver>();

            builder.Services.AddTransient<Repositorio.Inputs.Repositorio.Paciente.IPacienteWriteRepository, Input.Repository.Paciente.PacienteWriteRepository>();
            builder.Services.AddTransient<RepositoryInterfaces.Read.Repository.Paciente.IPacienteReadRepository, Read.ConcreteRepository.Paciente.PacienteReadRepository>();
            builder.Services.AddTransient<Comandos.Receivers.Paciente.InsertPacienteReceiver>();

            builder.Services.AddTransient<Repositorio.Inputs.Repositorio.Agendamentos.IAgendamentosWriteRepository, Input.Repository.Agendamentos.AgendamentosWriteRepository>();
            builder.Services.AddTransient<RepositoryInterfaces.Read.Repository.Agendamentos.IAgendamentosReadRepository, Read.ConcreteRepository.Agendamentos.AgendamentosReadRepository>();
            builder.Services.AddTransient<Comandos.Receivers.Agendamentos.InsertAgendamentosReceiver>();

            builder.Services.AddTransient<Repositorio.Inputs.Repositorio.MovimentacaoFinanceira.IMovimentacaoFinanceiraWriteRepository, Input.Repository.MovimentacaoFinanceira.MovimentacaoFinanceiraWriteRepository>();
            builder.Services.AddTransient<RepositoryInterfaces.Read.Repository.MovimentacaoFinanceira.IMovimentacaoFinanceiraReadRepository, Read.ConcreteRepository.MovimentacaoFinanceira.MovimentacaoFinanceiraReadRepository>();
            builder.Services.AddTransient<Comandos.Receivers.MovimentacaoFinanceira.InsertMovimentacaoFinanceiraReceiver>();

            builder.Services.AddTransient<Repositorio.Inputs.Repositorio.Clinica.IClinicaWriteRepository, Input.Repository.Clinica.ClinicaWriteRepository>();
            builder.Services.AddTransient<RepositoryInterfaces.Read.Repository.Clinica.IClinicaReadRepository, Read.ConcreteRepository.Clinica.ClinicaReadRepository>();
            builder.Services.AddTransient<Comandos.Receivers.Clinica.InsertClinicaReceiver>();
        }
    }
}
