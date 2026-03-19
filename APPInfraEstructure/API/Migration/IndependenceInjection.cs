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


            builder.Services.AddTransient<IRepository.Write.IPlanoContaWriteRepository, Input.Repository.PlanoConta.PlanoContaWriteRepository>();
            builder.Services.AddTransient<IRepository.Read.IPlanoContaReadRepository, Read.Repository.PlanoContaReadRepository>();
            builder.Services.AddTransient<IQuery.Read.IPlanoContaQueryRead, Query.Read.PlanoContaQueryRead>();
            builder.Services.AddTransient<IQuery.Write.IPlanoContaQueryWrite, Query.Write.PlanoContaQueryWrite>();
            builder.Services.AddTransient<Command.Receivers.Write.InsertPlanoContaReceiver>();
            builder.Services.AddTransient<Command.Receivers.Write.UpdatePlanoContaReceiver>();
            builder.Services.AddTransient<Command.Receivers.Write.DeletePlanoContaReceiver>();
            builder.Services.AddTransient<Command.Receivers.Read.PlanoContaReadReceiver>();
            builder.Services.AddTransient<Command.Receivers.Read.PlanoContaReadFKTenantIDReceiver>();
            builder.Services.AddTransient<Command.Receivers.Read.PlanoContaReadFKUserIdReceiver>();

            builder.Services.AddTransient<IRepository.Write.IMovimentoFinanceiroWriteRepository, Input.Repository.MovimentoFinanceiro.MovimentoFinanceiroWriteRepository>();
            builder.Services.AddTransient<IRepository.Read.IMovimentoFinanceiroReadRepository, Read.Repository.MovimentoFinanceiroReadRepository>();
            builder.Services.AddTransient<IQuery.Read.IMovimentoFinanceiroQueryRead, Query.Read.MovimentoFinanceiroQueryRead>();
            builder.Services.AddTransient<IQuery.Write.IMovimentoFinanceiroQueryWrite, Query.Write.MovimentoFinanceiroQueryWrite>();
            builder.Services.AddTransient<Command.Receivers.Write.InsertMovimentoFinanceiroReceiver>();
            builder.Services.AddTransient<Command.Receivers.Write.UpdateMovimentoFinanceiroReceiver>();
            builder.Services.AddTransient<Command.Receivers.Write.DeleteMovimentoFinanceiroReceiver>();
            builder.Services.AddTransient<Command.Receivers.Read.MovimentoFinanceiroReadReceiver>();
            builder.Services.AddTransient<Command.Receivers.Read.MovimentoFinanceiroReadFKContaDebitoIdReceiver>();
            builder.Services.AddTransient<Command.Receivers.Read.MovimentoFinanceiroReadFKTenantIDReceiver>();
            builder.Services.AddTransient<Command.Receivers.Read.MovimentoFinanceiroReadFKUserIdReceiver>();

            builder.Services.AddTransient<IRepository.Write.IEspecialidadeWriteRepository, Input.Repository.Especialidade.EspecialidadeWriteRepository>();
            builder.Services.AddTransient<IRepository.Read.IEspecialidadeReadRepository, Read.Repository.EspecialidadeReadRepository>();
            builder.Services.AddTransient<IQuery.Read.IEspecialidadeQueryRead, Query.Read.EspecialidadeQueryRead>();
            builder.Services.AddTransient<IQuery.Write.IEspecialidadeQueryWrite, Query.Write.EspecialidadeQueryWrite>();
            builder.Services.AddTransient<Command.Receivers.Write.InsertEspecialidadeReceiver>();
            builder.Services.AddTransient<Command.Receivers.Write.UpdateEspecialidadeReceiver>();
            builder.Services.AddTransient<Command.Receivers.Write.DeleteEspecialidadeReceiver>();
            builder.Services.AddTransient<Command.Receivers.Read.EspecialidadeReadReceiver>();
            builder.Services.AddTransient<Command.Receivers.Read.EspecialidadeReadFKTenantIDReceiver>();
            builder.Services.AddTransient<Command.Receivers.Read.EspecialidadeReadFKUserIdReceiver>();

            builder.Services.AddTransient<IRepository.Write.IProfissionalWriteRepository, Input.Repository.Profissional.ProfissionalWriteRepository>();
            builder.Services.AddTransient<IRepository.Read.IProfissionalReadRepository, Read.Repository.ProfissionalReadRepository>();
            builder.Services.AddTransient<IQuery.Read.IProfissionalQueryRead, Query.Read.ProfissionalQueryRead>();
            builder.Services.AddTransient<IQuery.Write.IProfissionalQueryWrite, Query.Write.ProfissionalQueryWrite>();
            builder.Services.AddTransient<Command.Receivers.Write.InsertProfissionalReceiver>();
            builder.Services.AddTransient<Command.Receivers.Write.UpdateProfissionalReceiver>();
            builder.Services.AddTransient<Command.Receivers.Write.DeleteProfissionalReceiver>();
            builder.Services.AddTransient<Command.Receivers.Read.ProfissionalReadReceiver>();
            builder.Services.AddTransient<Command.Receivers.Read.ProfissionalReadFKEspecialidadeIdReceiver>();
            builder.Services.AddTransient<Command.Receivers.Read.ProfissionalReadFKTenantIDReceiver>();
            builder.Services.AddTransient<Command.Receivers.Read.ProfissionalReadFKUserIdReceiver>();

            builder.Services.AddTransient<IRepository.Write.IDisponibilidadeAgendaWriteRepository, Input.Repository.DisponibilidadeAgenda.DisponibilidadeAgendaWriteRepository>();
            builder.Services.AddTransient<IRepository.Read.IDisponibilidadeAgendaReadRepository, Read.Repository.DisponibilidadeAgendaReadRepository>();
            builder.Services.AddTransient<IQuery.Read.IDisponibilidadeAgendaQueryRead, Query.Read.DisponibilidadeAgendaQueryRead>();
            builder.Services.AddTransient<IQuery.Write.IDisponibilidadeAgendaQueryWrite, Query.Write.DisponibilidadeAgendaQueryWrite>();
            builder.Services.AddTransient<Command.Receivers.Write.InsertDisponibilidadeAgendaReceiver>();
            builder.Services.AddTransient<Command.Receivers.Write.UpdateDisponibilidadeAgendaReceiver>();
            builder.Services.AddTransient<Command.Receivers.Write.DeleteDisponibilidadeAgendaReceiver>();
            builder.Services.AddTransient<Command.Receivers.Read.DisponibilidadeAgendaReadReceiver>();
            builder.Services.AddTransient<Command.Receivers.Read.DisponibilidadeAgendaReadFKProfissionalIdReceiver>();
            builder.Services.AddTransient<Command.Receivers.Read.DisponibilidadeAgendaReadFKTenantIDReceiver>();
            builder.Services.AddTransient<Command.Receivers.Read.DisponibilidadeAgendaReadFKUserIdReceiver>();

            builder.Services.AddTransient<IRepository.Write.IGrupoServicoWriteRepository, Input.Repository.GrupoServico.GrupoServicoWriteRepository>();
            builder.Services.AddTransient<IRepository.Read.IGrupoServicoReadRepository, Read.Repository.GrupoServicoReadRepository>();
            builder.Services.AddTransient<IQuery.Read.IGrupoServicoQueryRead, Query.Read.GrupoServicoQueryRead>();
            builder.Services.AddTransient<IQuery.Write.IGrupoServicoQueryWrite, Query.Write.GrupoServicoQueryWrite>();
            builder.Services.AddTransient<Command.Receivers.Write.InsertGrupoServicoReceiver>();
            builder.Services.AddTransient<Command.Receivers.Write.UpdateGrupoServicoReceiver>();
            builder.Services.AddTransient<Command.Receivers.Write.DeleteGrupoServicoReceiver>();
            builder.Services.AddTransient<Command.Receivers.Read.GrupoServicoReadReceiver>();
            builder.Services.AddTransient<Command.Receivers.Read.GrupoServicoReadFKTenantIDReceiver>();
            builder.Services.AddTransient<Command.Receivers.Read.GrupoServicoReadFKUserIdReceiver>();

            builder.Services.AddTransient<IRepository.Write.IServicoWriteRepository, Input.Repository.Servico.ServicoWriteRepository>();
            builder.Services.AddTransient<IRepository.Read.IServicoReadRepository, Read.Repository.ServicoReadRepository>();
            builder.Services.AddTransient<IQuery.Read.IServicoQueryRead, Query.Read.ServicoQueryRead>();
            builder.Services.AddTransient<IQuery.Write.IServicoQueryWrite, Query.Write.ServicoQueryWrite>();
            builder.Services.AddTransient<Command.Receivers.Write.InsertServicoReceiver>();
            builder.Services.AddTransient<Command.Receivers.Write.UpdateServicoReceiver>();
            builder.Services.AddTransient<Command.Receivers.Write.DeleteServicoReceiver>();
            builder.Services.AddTransient<Command.Receivers.Read.ServicoReadReceiver>();
            builder.Services.AddTransient<Command.Receivers.Read.ServicoReadFKGrupoServicoIdReceiver>();
            builder.Services.AddTransient<Command.Receivers.Read.ServicoReadFKTenantIDReceiver>();
            builder.Services.AddTransient<Command.Receivers.Read.ServicoReadFKUserIdReceiver>();

            builder.Services.AddTransient<IRepository.Write.IPacienteWriteRepository, Input.Repository.Paciente.PacienteWriteRepository>();
            builder.Services.AddTransient<IRepository.Read.IPacienteReadRepository, Read.Repository.PacienteReadRepository>();
            builder.Services.AddTransient<IQuery.Read.IPacienteQueryRead, Query.Read.PacienteQueryRead>();
            builder.Services.AddTransient<IQuery.Write.IPacienteQueryWrite, Query.Write.PacienteQueryWrite>();
            builder.Services.AddTransient<Command.Receivers.Write.InsertPacienteReceiver>();
            builder.Services.AddTransient<Command.Receivers.Write.UpdatePacienteReceiver>();
            builder.Services.AddTransient<Command.Receivers.Write.DeletePacienteReceiver>();
            builder.Services.AddTransient<Command.Receivers.Read.PacienteReadReceiver>();
            builder.Services.AddTransient<Command.Receivers.Read.PacienteReadFKTenantIDReceiver>();
            builder.Services.AddTransient<Command.Receivers.Read.PacienteReadFKUserIdReceiver>();
            builder.Services.AddTransient<Command.Receivers.Read.PacienteReadQueryGeralReceiver>();
            builder.Services.AddTransient<Command.Receivers.Read.PacienteReadQueryMesReceiver>();

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
            builder.Services.AddTransient<Command.Receivers.Read.MovimentacaoFinanceiraReadFKTenantIDReceiver>();
            builder.Services.AddTransient<Command.Receivers.Read.MovimentacaoFinanceiraReadFKUserIdReceiver>();

            builder.Services.AddTransient<IRepository.Write.ISesoesWriteRepository, Input.Repository.Sesoes.SesoesWriteRepository>();
            builder.Services.AddTransient<IRepository.Read.ISesoesReadRepository, Read.Repository.SesoesReadRepository>();
            builder.Services.AddTransient<IQuery.Read.ISesoesQueryRead, Query.Read.SesoesQueryRead>();
            builder.Services.AddTransient<IQuery.Write.ISesoesQueryWrite, Query.Write.SesoesQueryWrite>();
            builder.Services.AddTransient<Command.Receivers.Write.InsertSesoesReceiver>();
            builder.Services.AddTransient<Command.Receivers.Write.UpdateSesoesReceiver>();
            builder.Services.AddTransient<Command.Receivers.Write.DeleteSesoesReceiver>();
            builder.Services.AddTransient<Command.Receivers.Read.SesoesReadReceiver>();
            builder.Services.AddTransient<Command.Receivers.Read.SesoesReadFKPacienteIdReceiver>();
            builder.Services.AddTransient<Command.Receivers.Read.SesoesReadFKServicoIdReceiver>();
            builder.Services.AddTransient<Command.Receivers.Read.SesoesReadFKMovimentacaoFinanceiraIdReceiver>();
            builder.Services.AddTransient<Command.Receivers.Read.SesoesReadFKProfissionalIdReceiver>();
            builder.Services.AddTransient<Command.Receivers.Read.SesoesReadFKTenantIDReceiver>();
            builder.Services.AddTransient<Command.Receivers.Read.SesoesReadFKUserIdReceiver>();
            builder.Services.AddTransient<Command.Receivers.Read.SesoesReadQueryGeralReceiver>();
            builder.Services.AddTransient<Command.Receivers.Read.SesoesReadQueryHojeReceiver>();
            builder.Services.AddTransient<Command.Receivers.Read.SesoesReadQuerySemanaReceiver>();
            builder.Services.AddTransient<Command.Receivers.Read.SesoesReadQueryD30Receiver>();

            builder.Services.AddTransient<IRepository.Write.IClinicaWriteRepository, Input.Repository.Clinica.ClinicaWriteRepository>();
            builder.Services.AddTransient<IRepository.Read.IClinicaReadRepository, Read.Repository.ClinicaReadRepository>();
            builder.Services.AddTransient<IQuery.Read.IClinicaQueryRead, Query.Read.ClinicaQueryRead>();
            builder.Services.AddTransient<IQuery.Write.IClinicaQueryWrite, Query.Write.ClinicaQueryWrite>();
            builder.Services.AddTransient<Command.Receivers.Write.InsertClinicaReceiver>();
            builder.Services.AddTransient<Command.Receivers.Write.UpdateClinicaReceiver>();
            builder.Services.AddTransient<Command.Receivers.Write.DeleteClinicaReceiver>();
            builder.Services.AddTransient<Command.Receivers.Read.ClinicaReadReceiver>();
            builder.Services.AddTransient<Command.Receivers.Read.ClinicaReadFKTenantIDReceiver>();
            builder.Services.AddTransient<Command.Receivers.Read.ClinicaReadFKUserIdReceiver>();

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

            builder.Services.AddTransient<IRepository.Write.IyOutboxWriteRepository, Input.Repository.yOutbox.yOutboxWriteRepository>();
            builder.Services.AddTransient<IRepository.Read.IyOutboxReadRepository, Read.Repository.yOutboxReadRepository>();
            builder.Services.AddTransient<IQuery.Read.IyOutboxQueryRead, Query.Read.yOutboxQueryRead>();
            builder.Services.AddTransient<IQuery.Write.IyOutboxQueryWrite, Query.Write.yOutboxQueryWrite>();
            builder.Services.AddTransient<Command.Receivers.Write.InsertyOutboxReceiver>();
            builder.Services.AddTransient<Command.Receivers.Write.UpdateyOutboxReceiver>();
            builder.Services.AddTransient<Command.Receivers.Write.DeleteyOutboxReceiver>();
            builder.Services.AddTransient<Command.Receivers.Read.yOutboxReadReceiver>();
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
                var cacheById = sp.GetRequiredService<ICacheService<Repositorio.Outputs.yConfigArctetureDTO>>();
                var cacheAll = sp.GetRequiredService<ICacheService<IEnumerable<Repositorio.Outputs.yConfigArctetureDTO>>>();
                var cacheFKTenantID = sp.GetRequiredService<ICacheService<IEnumerable<Repositorio.Outputs.yConfigArctetureTenantIDDTO>>>();
                var cacheFKUserId = sp.GetRequiredService<ICacheService<IEnumerable<Repositorio.Outputs.yConfigArctetureUserIdDTO>>>();
                return new Read.Repository.yConfigArctetureReadRepositoryCacheDecorator(inner, cacheById, cacheAll, cacheFKTenantID, cacheFKUserId);
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
                var cacheById = sp.GetRequiredService<ICacheService<Repositorio.Outputs.yConfigNotificationDTO>>();
                var cacheAll = sp.GetRequiredService<ICacheService<IEnumerable<Repositorio.Outputs.yConfigNotificationDTO>>>();
                var cacheFKTenantID = sp.GetRequiredService<ICacheService<IEnumerable<Repositorio.Outputs.yConfigNotificationTenantIDDTO>>>();
                var cacheFKUserId = sp.GetRequiredService<ICacheService<IEnumerable<Repositorio.Outputs.yConfigNotificationUserIdDTO>>>();
                return new Read.Repository.yConfigNotificationReadRepositoryCacheDecorator(inner, cacheById, cacheAll, cacheFKTenantID, cacheFKUserId);
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

            builder.Services.AddTransient<Command.Receivers.UseCase.WorkerPollingOutBoxUseCaseReceiver>();

            builder.Services.AddTransient<Command.Receivers.UseCase.WorkerPollingInboxUseCaseReceiver>();

            builder.Services.AddTransient<Command.Receivers.UseCase.WorkerListenerInBoxUseCaseReceiver>();

            builder.Services.AddTransient<Command.Receivers.UseCase.InfraStarSessionUploadUseCaseReceiver>();

            builder.Services.AddTransient<Command.Receivers.UseCase.InfraSendFileUseCaseReceiver>();

            builder.Services.AddTransient<Command.Receivers.UseCase.ContasCreateContaUseCaseReceiver>();

            builder.Services.AddTransient<Command.Receivers.UseCase.ContasLoginUseCaseReceiver>();

            builder.Services.AddTransient<Command.Receivers.UseCase.ContasRecoveryAccountUseCaseReceiver>();
            builder.Services.AddTransient<Shered.Patterns.Strategy.EmailNotification>();
            builder.Services.AddTransient<Shered.Patterns.Strategy.SMSNotification>();
            builder.Services.AddTransient<Shered.Patterns.Strategy.WhatsappNotification>();
            builder.Services.AddTransient<Dominio.Interfaces.Strategy.IINotificationFactory, Shered.Patterns.Strategy.NotificationFactory>();
            builder.Services.AddTransient<Dominio.Interfaces.Strategy.IMessage, Shered.Patterns.Strategy.Message>();
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureAPIIndependenceInjectionMigration