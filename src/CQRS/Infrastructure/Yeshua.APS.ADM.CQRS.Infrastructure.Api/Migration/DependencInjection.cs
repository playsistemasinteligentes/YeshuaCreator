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
                    builder.Services.AddTransient<ISagaResolverRegistry, SagaResolverRegistry>();
                    builder.Services.AddScoped<OutboxService>();


builder.Services.AddTransient<IRepository.Write.IProdutoWriteRepository, Input.Repository.Produto.ProdutoWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IProdutoReadRepository, Read.Repository.ProdutoReadRepository>();
builder.Services.AddTransient<IQuery.Read.IProdutoQueryRead, Query.Read.ProdutoQueryRead>();
builder.Services.AddTransient<IQuery.Write.IProdutoQueryWrite, Query.Write.ProdutoQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertProdutoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateProdutoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteProdutoReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ProdutoReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ProdutoReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ProdutoReadFKUserIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ProdutoReadFKUNI_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ProdutoReadFKGRP_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ProdutoReadFKVIN_IDReceiver>();

builder.Services.AddTransient<IRepository.Write.IMaquinaWriteRepository, Input.Repository.Maquina.MaquinaWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IMaquinaReadRepository, Read.Repository.MaquinaReadRepository>();
builder.Services.AddTransient<IQuery.Read.IMaquinaQueryRead, Query.Read.MaquinaQueryRead>();
builder.Services.AddTransient<IQuery.Write.IMaquinaQueryWrite, Query.Write.MaquinaQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertMaquinaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateMaquinaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteMaquinaReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MaquinaReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MaquinaReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MaquinaReadFKUserIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MaquinaReadFKCAL_IDReceiver>();

builder.Services.AddTransient<IRepository.Write.IGrupoMaquinaWriteRepository, Input.Repository.GrupoMaquina.GrupoMaquinaWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IGrupoMaquinaReadRepository, Read.Repository.GrupoMaquinaReadRepository>();
builder.Services.AddTransient<IQuery.Read.IGrupoMaquinaQueryRead, Query.Read.GrupoMaquinaQueryRead>();
builder.Services.AddTransient<IQuery.Write.IGrupoMaquinaQueryWrite, Query.Write.GrupoMaquinaQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertGrupoMaquinaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateGrupoMaquinaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteGrupoMaquinaReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.GrupoMaquinaReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.GrupoMaquinaReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.GrupoMaquinaReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ITemplateDeTestesWriteRepository, Input.Repository.TemplateDeTestes.TemplateDeTestesWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ITemplateDeTestesReadRepository, Read.Repository.TemplateDeTestesReadRepository>();
builder.Services.AddTransient<IQuery.Read.ITemplateDeTestesQueryRead, Query.Read.TemplateDeTestesQueryRead>();
builder.Services.AddTransient<IQuery.Write.ITemplateDeTestesQueryWrite, Query.Write.TemplateDeTestesQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertTemplateDeTestesReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateTemplateDeTestesReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteTemplateDeTestesReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TemplateDeTestesReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TemplateDeTestesReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TemplateDeTestesReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IRoteiroWriteRepository, Input.Repository.Roteiro.RoteiroWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IRoteiroReadRepository, Read.Repository.RoteiroReadRepository>();
builder.Services.AddTransient<IQuery.Read.IRoteiroQueryRead, Query.Read.RoteiroQueryRead>();
builder.Services.AddTransient<IQuery.Write.IRoteiroQueryWrite, Query.Write.RoteiroQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertRoteiroReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateRoteiroReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteRoteiroReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.RoteiroReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.RoteiroReadFKMaquinaIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.RoteiroReadFKProdutoIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.RoteiroReadFKGrupoMaquinaIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.RoteiroReadFKTemplateDeTestesIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.RoteiroReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.RoteiroReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IConsultaPedidoWriteRepository, Input.Repository.ConsultaPedido.ConsultaPedidoWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IConsultaPedidoReadRepository, Read.Repository.ConsultaPedidoReadRepository>();
builder.Services.AddTransient<IQuery.Read.IConsultaPedidoQueryRead, Query.Read.ConsultaPedidoQueryRead>();
builder.Services.AddTransient<IQuery.Write.IConsultaPedidoQueryWrite, Query.Write.ConsultaPedidoQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertConsultaPedidoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateConsultaPedidoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteConsultaPedidoReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ConsultaPedidoReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ConsultaPedidoReadFKProdutoIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IRoteiroPedidoWriteRepository, Input.Repository.RoteiroPedido.RoteiroPedidoWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IRoteiroPedidoReadRepository, Read.Repository.RoteiroPedidoReadRepository>();
builder.Services.AddTransient<IQuery.Read.IRoteiroPedidoQueryRead, Query.Read.RoteiroPedidoQueryRead>();
builder.Services.AddTransient<IQuery.Write.IRoteiroPedidoQueryWrite, Query.Write.RoteiroPedidoQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertRoteiroPedidoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateRoteiroPedidoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteRoteiroPedidoReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.RoteiroPedidoReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.RoteiroPedidoReadFKPedidoIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.RoteiroPedidoReadFKMaquinaIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.RoteiroPedidoReadFKProdutoIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IT_AGENDA_SCHEDULEWriteRepository, Input.Repository.T_AGENDA_SCHEDULE.T_AGENDA_SCHEDULEWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IT_AGENDA_SCHEDULEReadRepository, Read.Repository.T_AGENDA_SCHEDULEReadRepository>();
builder.Services.AddTransient<IQuery.Read.IT_AGENDA_SCHEDULEQueryRead, Query.Read.T_AGENDA_SCHEDULEQueryRead>();
builder.Services.AddTransient<IQuery.Write.IT_AGENDA_SCHEDULEQueryWrite, Query.Write.T_AGENDA_SCHEDULEQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertT_AGENDA_SCHEDULEReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateT_AGENDA_SCHEDULEReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteT_AGENDA_SCHEDULEReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.T_AGENDA_SCHEDULEReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.T_AGENDA_SCHEDULEReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.T_AGENDA_SCHEDULEReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IAuditoriaWriteRepository, Input.Repository.Auditoria.AuditoriaWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IAuditoriaReadRepository, Read.Repository.AuditoriaReadRepository>();
builder.Services.AddTransient<IQuery.Read.IAuditoriaQueryRead, Query.Read.AuditoriaQueryRead>();
builder.Services.AddTransient<IQuery.Write.IAuditoriaQueryWrite, Query.Write.AuditoriaQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertAuditoriaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateAuditoriaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteAuditoriaReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.AuditoriaReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.AuditoriaReadFKUSE_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.AuditoriaReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.AuditoriaReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IBoletimWriteRepository, Input.Repository.Boletim.BoletimWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IBoletimReadRepository, Read.Repository.BoletimReadRepository>();
builder.Services.AddTransient<IQuery.Read.IBoletimQueryRead, Query.Read.BoletimQueryRead>();
builder.Services.AddTransient<IQuery.Write.IBoletimQueryWrite, Query.Write.BoletimQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertBoletimReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateBoletimReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteBoletimReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.BoletimReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.BoletimReadFKGRP_ID_PROGRAMADOReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.BoletimReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.BoletimReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IBoletimEstudoWriteRepository, Input.Repository.BoletimEstudo.BoletimEstudoWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IBoletimEstudoReadRepository, Read.Repository.BoletimEstudoReadRepository>();
builder.Services.AddTransient<IQuery.Read.IBoletimEstudoQueryRead, Query.Read.BoletimEstudoQueryRead>();
builder.Services.AddTransient<IQuery.Write.IBoletimEstudoQueryWrite, Query.Write.BoletimEstudoQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertBoletimEstudoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateBoletimEstudoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteBoletimEstudoReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.BoletimEstudoReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.BoletimEstudoReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.BoletimEstudoReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ICalendarioWriteRepository, Input.Repository.Calendario.CalendarioWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ICalendarioReadRepository, Read.Repository.CalendarioReadRepository>();
builder.Services.AddTransient<IQuery.Read.ICalendarioQueryRead, Query.Read.CalendarioQueryRead>();
builder.Services.AddTransient<IQuery.Write.ICalendarioQueryWrite, Query.Write.CalendarioQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertCalendarioReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateCalendarioReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteCalendarioReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CalendarioReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CalendarioReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CalendarioReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ICalendarioDisponibilidadeVeiculosWriteRepository, Input.Repository.CalendarioDisponibilidadeVeiculos.CalendarioDisponibilidadeVeiculosWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ICalendarioDisponibilidadeVeiculosReadRepository, Read.Repository.CalendarioDisponibilidadeVeiculosReadRepository>();
builder.Services.AddTransient<IQuery.Read.ICalendarioDisponibilidadeVeiculosQueryRead, Query.Read.CalendarioDisponibilidadeVeiculosQueryRead>();
builder.Services.AddTransient<IQuery.Write.ICalendarioDisponibilidadeVeiculosQueryWrite, Query.Write.CalendarioDisponibilidadeVeiculosQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertCalendarioDisponibilidadeVeiculosReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateCalendarioDisponibilidadeVeiculosReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteCalendarioDisponibilidadeVeiculosReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CalendarioDisponibilidadeVeiculosReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CalendarioDisponibilidadeVeiculosReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CalendarioDisponibilidadeVeiculosReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ICanhotosWriteRepository, Input.Repository.Canhotos.CanhotosWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ICanhotosReadRepository, Read.Repository.CanhotosReadRepository>();
builder.Services.AddTransient<IQuery.Read.ICanhotosQueryRead, Query.Read.CanhotosQueryRead>();
builder.Services.AddTransient<IQuery.Write.ICanhotosQueryWrite, Query.Write.CanhotosQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertCanhotosReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateCanhotosReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteCanhotosReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CanhotosReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CanhotosReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CanhotosReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ICargaWriteRepository, Input.Repository.Carga.CargaWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ICargaReadRepository, Read.Repository.CargaReadRepository>();
builder.Services.AddTransient<IQuery.Read.ICargaQueryRead, Query.Read.CargaQueryRead>();
builder.Services.AddTransient<IQuery.Write.ICargaQueryWrite, Query.Write.CargaQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertCargaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateCargaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteCargaReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CargaReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CargaReadFKOCO_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CargaReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CargaReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ICargaPrevistaWriteRepository, Input.Repository.CargaPrevista.CargaPrevistaWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ICargaPrevistaReadRepository, Read.Repository.CargaPrevistaReadRepository>();
builder.Services.AddTransient<IQuery.Read.ICargaPrevistaQueryRead, Query.Read.CargaPrevistaQueryRead>();
builder.Services.AddTransient<IQuery.Write.ICargaPrevistaQueryWrite, Query.Write.CargaPrevistaQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertCargaPrevistaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateCargaPrevistaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteCargaPrevistaReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CargaPrevistaReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CargaPrevistaReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CargaPrevistaReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ICargosWriteRepository, Input.Repository.Cargos.CargosWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ICargosReadRepository, Read.Repository.CargosReadRepository>();
builder.Services.AddTransient<IQuery.Read.ICargosQueryRead, Query.Read.CargosQueryRead>();
builder.Services.AddTransient<IQuery.Write.ICargosQueryWrite, Query.Write.CargosQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertCargosReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateCargosReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteCargosReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CargosReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CargosReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CargosReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IClienteWriteRepository, Input.Repository.Cliente.ClienteWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IClienteReadRepository, Read.Repository.ClienteReadRepository>();
builder.Services.AddTransient<IQuery.Read.IClienteQueryRead, Query.Read.ClienteQueryRead>();
builder.Services.AddTransient<IQuery.Write.IClienteQueryWrite, Query.Write.ClienteQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertClienteReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateClienteReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteClienteReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ClienteReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ClienteReadFKMUN_ID_ENTREGAReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ClienteReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ClienteReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IClpMedicoesWriteRepository, Input.Repository.ClpMedicoes.ClpMedicoesWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IClpMedicoesReadRepository, Read.Repository.ClpMedicoesReadRepository>();
builder.Services.AddTransient<IQuery.Read.IClpMedicoesQueryRead, Query.Read.ClpMedicoesQueryRead>();
builder.Services.AddTransient<IQuery.Write.IClpMedicoesQueryWrite, Query.Write.ClpMedicoesQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertClpMedicoesReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateClpMedicoesReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteClpMedicoesReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ClpMedicoesReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ClpMedicoesReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ClpMedicoesReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IClpMedicoesHWriteRepository, Input.Repository.ClpMedicoesH.ClpMedicoesHWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IClpMedicoesHReadRepository, Read.Repository.ClpMedicoesHReadRepository>();
builder.Services.AddTransient<IQuery.Read.IClpMedicoesHQueryRead, Query.Read.ClpMedicoesHQueryRead>();
builder.Services.AddTransient<IQuery.Write.IClpMedicoesHQueryWrite, Query.Write.ClpMedicoesHQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertClpMedicoesHReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateClpMedicoesHReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteClpMedicoesHReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ClpMedicoesHReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ClpMedicoesHReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ClpMedicoesHReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IColaboradorWriteRepository, Input.Repository.Colaborador.ColaboradorWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IColaboradorReadRepository, Read.Repository.ColaboradorReadRepository>();
builder.Services.AddTransient<IQuery.Read.IColaboradorQueryRead, Query.Read.ColaboradorQueryRead>();
builder.Services.AddTransient<IQuery.Write.IColaboradorQueryWrite, Query.Write.ColaboradorQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertColaboradorReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateColaboradorReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteColaboradorReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ColaboradorReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ColaboradorReadFKTURM_idReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ColaboradorReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ColaboradorReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ICompensacaoWriteRepository, Input.Repository.Compensacao.CompensacaoWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ICompensacaoReadRepository, Read.Repository.CompensacaoReadRepository>();
builder.Services.AddTransient<IQuery.Read.ICompensacaoQueryRead, Query.Read.CompensacaoQueryRead>();
builder.Services.AddTransient<IQuery.Write.ICompensacaoQueryWrite, Query.Write.CompensacaoQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertCompensacaoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateCompensacaoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteCompensacaoReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CompensacaoReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CompensacaoReadFKGRP_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CompensacaoReadFKOND_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CompensacaoReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CompensacaoReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ICondicaoPagamentoWriteRepository, Input.Repository.CondicaoPagamento.CondicaoPagamentoWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ICondicaoPagamentoReadRepository, Read.Repository.CondicaoPagamentoReadRepository>();
builder.Services.AddTransient<IQuery.Read.ICondicaoPagamentoQueryRead, Query.Read.CondicaoPagamentoQueryRead>();
builder.Services.AddTransient<IQuery.Write.ICondicaoPagamentoQueryWrite, Query.Write.CondicaoPagamentoQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertCondicaoPagamentoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateCondicaoPagamentoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteCondicaoPagamentoReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CondicaoPagamentoReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CondicaoPagamentoReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CondicaoPagamentoReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IConfiguracoesWriteRepository, Input.Repository.Configuracoes.ConfiguracoesWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IConfiguracoesReadRepository, Read.Repository.ConfiguracoesReadRepository>();
builder.Services.AddTransient<IQuery.Read.IConfiguracoesQueryRead, Query.Read.ConfiguracoesQueryRead>();
builder.Services.AddTransient<IQuery.Write.IConfiguracoesQueryWrite, Query.Write.ConfiguracoesQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertConfiguracoesReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateConfiguracoesReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteConfiguracoesReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ConfiguracoesReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ConfiguracoesReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ConfiguracoesReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IConsultasWriteRepository, Input.Repository.Consultas.ConsultasWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IConsultasReadRepository, Read.Repository.ConsultasReadRepository>();
builder.Services.AddTransient<IQuery.Read.IConsultasQueryRead, Query.Read.ConsultasQueryRead>();
builder.Services.AddTransient<IQuery.Write.IConsultasQueryWrite, Query.Write.ConsultasQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertConsultasReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateConsultasReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteConsultasReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ConsultasReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ConsultasReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ConsultasReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IConsultasGruposWriteRepository, Input.Repository.ConsultasGrupos.ConsultasGruposWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IConsultasGruposReadRepository, Read.Repository.ConsultasGruposReadRepository>();
builder.Services.AddTransient<IQuery.Read.IConsultasGruposQueryRead, Query.Read.ConsultasGruposQueryRead>();
builder.Services.AddTransient<IQuery.Write.IConsultasGruposQueryWrite, Query.Write.ConsultasGruposQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertConsultasGruposReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateConsultasGruposReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteConsultasGruposReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ConsultasGruposReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ConsultasGruposReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ConsultasGruposReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IConsultasIndicadoresWriteRepository, Input.Repository.ConsultasIndicadores.ConsultasIndicadoresWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IConsultasIndicadoresReadRepository, Read.Repository.ConsultasIndicadoresReadRepository>();
builder.Services.AddTransient<IQuery.Read.IConsultasIndicadoresQueryRead, Query.Read.ConsultasIndicadoresQueryRead>();
builder.Services.AddTransient<IQuery.Write.IConsultasIndicadoresQueryWrite, Query.Write.ConsultasIndicadoresQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertConsultasIndicadoresReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateConsultasIndicadoresReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteConsultasIndicadoresReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ConsultasIndicadoresReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ConsultasIndicadoresReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ConsultasIndicadoresReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ICorConfiguracaoGraficoWriteRepository, Input.Repository.CorConfiguracaoGrafico.CorConfiguracaoGraficoWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ICorConfiguracaoGraficoReadRepository, Read.Repository.CorConfiguracaoGraficoReadRepository>();
builder.Services.AddTransient<IQuery.Read.ICorConfiguracaoGraficoQueryRead, Query.Read.CorConfiguracaoGraficoQueryRead>();
builder.Services.AddTransient<IQuery.Write.ICorConfiguracaoGraficoQueryWrite, Query.Write.CorConfiguracaoGraficoQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertCorConfiguracaoGraficoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateCorConfiguracaoGraficoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteCorConfiguracaoGraficoReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CorConfiguracaoGraficoReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CorConfiguracaoGraficoReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CorConfiguracaoGraficoReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ICorridasOnduladeiraWriteRepository, Input.Repository.CorridasOnduladeira.CorridasOnduladeiraWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ICorridasOnduladeiraReadRepository, Read.Repository.CorridasOnduladeiraReadRepository>();
builder.Services.AddTransient<IQuery.Read.ICorridasOnduladeiraQueryRead, Query.Read.CorridasOnduladeiraQueryRead>();
builder.Services.AddTransient<IQuery.Write.ICorridasOnduladeiraQueryWrite, Query.Write.CorridasOnduladeiraQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertCorridasOnduladeiraReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateCorridasOnduladeiraReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteCorridasOnduladeiraReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CorridasOnduladeiraReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CorridasOnduladeiraReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CorridasOnduladeiraReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ICorridasOnduladeiraEstudoWriteRepository, Input.Repository.CorridasOnduladeiraEstudo.CorridasOnduladeiraEstudoWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ICorridasOnduladeiraEstudoReadRepository, Read.Repository.CorridasOnduladeiraEstudoReadRepository>();
builder.Services.AddTransient<IQuery.Read.ICorridasOnduladeiraEstudoQueryRead, Query.Read.CorridasOnduladeiraEstudoQueryRead>();
builder.Services.AddTransient<IQuery.Write.ICorridasOnduladeiraEstudoQueryWrite, Query.Write.CorridasOnduladeiraEstudoQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertCorridasOnduladeiraEstudoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateCorridasOnduladeiraEstudoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteCorridasOnduladeiraEstudoReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CorridasOnduladeiraEstudoReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CorridasOnduladeiraEstudoReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CorridasOnduladeiraEstudoReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ICotasWriteRepository, Input.Repository.Cotas.CotasWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ICotasReadRepository, Read.Repository.CotasReadRepository>();
builder.Services.AddTransient<IQuery.Read.ICotasQueryRead, Query.Read.CotasQueryRead>();
builder.Services.AddTransient<IQuery.Write.ICotasQueryWrite, Query.Write.CotasQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertCotasReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateCotasReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteCotasReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CotasReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CotasReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CotasReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IT_DepartamentosWriteRepository, Input.Repository.T_Departamentos.T_DepartamentosWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IT_DepartamentosReadRepository, Read.Repository.T_DepartamentosReadRepository>();
builder.Services.AddTransient<IQuery.Read.IT_DepartamentosQueryRead, Query.Read.T_DepartamentosQueryRead>();
builder.Services.AddTransient<IQuery.Write.IT_DepartamentosQueryWrite, Query.Write.T_DepartamentosQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertT_DepartamentosReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateT_DepartamentosReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteT_DepartamentosReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.T_DepartamentosReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.T_DepartamentosReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.T_DepartamentosReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IEnderecosWriteRepository, Input.Repository.Enderecos.EnderecosWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IEnderecosReadRepository, Read.Repository.EnderecosReadRepository>();
builder.Services.AddTransient<IQuery.Read.IEnderecosQueryRead, Query.Read.EnderecosQueryRead>();
builder.Services.AddTransient<IQuery.Write.IEnderecosQueryWrite, Query.Write.EnderecosQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertEnderecosReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateEnderecosReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteEnderecosReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.EnderecosReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.EnderecosReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.EnderecosReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IEquipeWriteRepository, Input.Repository.Equipe.EquipeWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IEquipeReadRepository, Read.Repository.EquipeReadRepository>();
builder.Services.AddTransient<IQuery.Read.IEquipeQueryRead, Query.Read.EquipeQueryRead>();
builder.Services.AddTransient<IQuery.Write.IEquipeQueryWrite, Query.Write.EquipeQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertEquipeReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateEquipeReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteEquipeReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.EquipeReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.EquipeReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.EquipeReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IEstradasWriteRepository, Input.Repository.Estradas.EstradasWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IEstradasReadRepository, Read.Repository.EstradasReadRepository>();
builder.Services.AddTransient<IQuery.Read.IEstradasQueryRead, Query.Read.EstradasQueryRead>();
builder.Services.AddTransient<IQuery.Write.IEstradasQueryWrite, Query.Write.EstradasQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertEstradasReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateEstradasReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteEstradasReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.EstradasReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.EstradasReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.EstradasReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IEstruturaCustoWriteRepository, Input.Repository.EstruturaCusto.EstruturaCustoWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IEstruturaCustoReadRepository, Read.Repository.EstruturaCustoReadRepository>();
builder.Services.AddTransient<IQuery.Read.IEstruturaCustoQueryRead, Query.Read.EstruturaCustoQueryRead>();
builder.Services.AddTransient<IQuery.Write.IEstruturaCustoQueryWrite, Query.Write.EstruturaCustoQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertEstruturaCustoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateEstruturaCustoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteEstruturaCustoReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.EstruturaCustoReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.EstruturaCustoReadFKORD_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.EstruturaCustoReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.EstruturaCustoReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IEstruturaImpressaoWriteRepository, Input.Repository.EstruturaImpressao.EstruturaImpressaoWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IEstruturaImpressaoReadRepository, Read.Repository.EstruturaImpressaoReadRepository>();
builder.Services.AddTransient<IQuery.Read.IEstruturaImpressaoQueryRead, Query.Read.EstruturaImpressaoQueryRead>();
builder.Services.AddTransient<IQuery.Write.IEstruturaImpressaoQueryWrite, Query.Write.EstruturaImpressaoQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertEstruturaImpressaoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateEstruturaImpressaoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteEstruturaImpressaoReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.EstruturaImpressaoReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.EstruturaImpressaoReadFKCLI_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.EstruturaImpressaoReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.EstruturaImpressaoReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IEstruturaProdutoWriteRepository, Input.Repository.EstruturaProduto.EstruturaProdutoWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IEstruturaProdutoReadRepository, Read.Repository.EstruturaProdutoReadRepository>();
builder.Services.AddTransient<IQuery.Read.IEstruturaProdutoQueryRead, Query.Read.EstruturaProdutoQueryRead>();
builder.Services.AddTransient<IQuery.Write.IEstruturaProdutoQueryWrite, Query.Write.EstruturaProdutoQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertEstruturaProdutoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateEstruturaProdutoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteEstruturaProdutoReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.EstruturaProdutoReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.EstruturaProdutoReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.EstruturaProdutoReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IEtiquetaWriteRepository, Input.Repository.Etiqueta.EtiquetaWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IEtiquetaReadRepository, Read.Repository.EtiquetaReadRepository>();
builder.Services.AddTransient<IQuery.Read.IEtiquetaQueryRead, Query.Read.EtiquetaQueryRead>();
builder.Services.AddTransient<IQuery.Write.IEtiquetaQueryWrite, Query.Write.EtiquetaQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertEtiquetaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateEtiquetaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteEtiquetaReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.EtiquetaReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.EtiquetaReadFKUSE_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.EtiquetaReadFKORD_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.EtiquetaReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.EtiquetaReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IT_FavoritosWriteRepository, Input.Repository.T_Favoritos.T_FavoritosWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IT_FavoritosReadRepository, Read.Repository.T_FavoritosReadRepository>();
builder.Services.AddTransient<IQuery.Read.IT_FavoritosQueryRead, Query.Read.T_FavoritosQueryRead>();
builder.Services.AddTransient<IQuery.Write.IT_FavoritosQueryWrite, Query.Write.T_FavoritosQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertT_FavoritosReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateT_FavoritosReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteT_FavoritosReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.T_FavoritosReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.T_FavoritosReadFKUSE_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.T_FavoritosReadFKID_INDICADORReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.T_FavoritosReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.T_FavoritosReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IFechamentoTesteWriteRepository, Input.Repository.FechamentoTeste.FechamentoTesteWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IFechamentoTesteReadRepository, Read.Repository.FechamentoTesteReadRepository>();
builder.Services.AddTransient<IQuery.Read.IFechamentoTesteQueryRead, Query.Read.FechamentoTesteQueryRead>();
builder.Services.AddTransient<IQuery.Write.IFechamentoTesteQueryWrite, Query.Write.FechamentoTesteQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertFechamentoTesteReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateFechamentoTesteReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteFechamentoTesteReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.FechamentoTesteReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.FechamentoTesteReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.FechamentoTesteReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IFeedbackWriteRepository, Input.Repository.Feedback.FeedbackWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IFeedbackReadRepository, Read.Repository.FeedbackReadRepository>();
builder.Services.AddTransient<IQuery.Read.IFeedbackQueryRead, Query.Read.FeedbackQueryRead>();
builder.Services.AddTransient<IQuery.Write.IFeedbackQueryWrite, Query.Write.FeedbackQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertFeedbackReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateFeedbackReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteFeedbackReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.FeedbackReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.FeedbackReadFKOcorrenciaIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.FeedbackReadFKTurnoIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.FeedbackReadFKTurmaIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.FeedbackReadFKUsuarioIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.FeedbackReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.FeedbackReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IT_FeedbackMovEstoqueWriteRepository, Input.Repository.T_FeedbackMovEstoque.T_FeedbackMovEstoqueWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IT_FeedbackMovEstoqueReadRepository, Read.Repository.T_FeedbackMovEstoqueReadRepository>();
builder.Services.AddTransient<IQuery.Read.IT_FeedbackMovEstoqueQueryRead, Query.Read.T_FeedbackMovEstoqueQueryRead>();
builder.Services.AddTransient<IQuery.Write.IT_FeedbackMovEstoqueQueryWrite, Query.Write.T_FeedbackMovEstoqueQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertT_FeedbackMovEstoqueReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateT_FeedbackMovEstoqueReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteT_FeedbackMovEstoqueReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.T_FeedbackMovEstoqueReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.T_FeedbackMovEstoqueReadFKFeedbackIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.T_FeedbackMovEstoqueReadFKMovimentoEstoqueIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.T_FeedbackMovEstoqueReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.T_FeedbackMovEstoqueReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IFilaProducaoWriteRepository, Input.Repository.FilaProducao.FilaProducaoWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IFilaProducaoReadRepository, Read.Repository.FilaProducaoReadRepository>();
builder.Services.AddTransient<IQuery.Read.IFilaProducaoQueryRead, Query.Read.FilaProducaoQueryRead>();
builder.Services.AddTransient<IQuery.Write.IFilaProducaoQueryWrite, Query.Write.FilaProducaoQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertFilaProducaoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateFilaProducaoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteFilaProducaoReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.FilaProducaoReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.FilaProducaoReadFKORD_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.FilaProducaoReadFKOCO_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.FilaProducaoReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.FilaProducaoReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IFilaProducaoPrevistaWriteRepository, Input.Repository.FilaProducaoPrevista.FilaProducaoPrevistaWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IFilaProducaoPrevistaReadRepository, Read.Repository.FilaProducaoPrevistaReadRepository>();
builder.Services.AddTransient<IQuery.Read.IFilaProducaoPrevistaQueryRead, Query.Read.FilaProducaoPrevistaQueryRead>();
builder.Services.AddTransient<IQuery.Write.IFilaProducaoPrevistaQueryWrite, Query.Write.FilaProducaoPrevistaQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertFilaProducaoPrevistaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateFilaProducaoPrevistaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteFilaProducaoPrevistaReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.FilaProducaoPrevistaReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.FilaProducaoPrevistaReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.FilaProducaoPrevistaReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IT_GrupoWriteRepository, Input.Repository.T_Grupo.T_GrupoWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IT_GrupoReadRepository, Read.Repository.T_GrupoReadRepository>();
builder.Services.AddTransient<IQuery.Read.IT_GrupoQueryRead, Query.Read.T_GrupoQueryRead>();
builder.Services.AddTransient<IQuery.Write.IT_GrupoQueryWrite, Query.Write.T_GrupoQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertT_GrupoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateT_GrupoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteT_GrupoReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.T_GrupoReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.T_GrupoReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.T_GrupoReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IGrupoIndicadorWriteRepository, Input.Repository.GrupoIndicador.GrupoIndicadorWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IGrupoIndicadorReadRepository, Read.Repository.GrupoIndicadorReadRepository>();
builder.Services.AddTransient<IQuery.Read.IGrupoIndicadorQueryRead, Query.Read.GrupoIndicadorQueryRead>();
builder.Services.AddTransient<IQuery.Write.IGrupoIndicadorQueryWrite, Query.Write.GrupoIndicadorQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertGrupoIndicadorReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateGrupoIndicadorReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteGrupoIndicadorReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.GrupoIndicadorReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.GrupoIndicadorReadFKGRU_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.GrupoIndicadorReadFKIND_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.GrupoIndicadorReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.GrupoIndicadorReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IGrupoProdutoAbstratoWriteRepository, Input.Repository.GrupoProdutoAbstrato.GrupoProdutoAbstratoWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IGrupoProdutoAbstratoReadRepository, Read.Repository.GrupoProdutoAbstratoReadRepository>();
builder.Services.AddTransient<IQuery.Read.IGrupoProdutoAbstratoQueryRead, Query.Read.GrupoProdutoAbstratoQueryRead>();
builder.Services.AddTransient<IQuery.Write.IGrupoProdutoAbstratoQueryWrite, Query.Write.GrupoProdutoAbstratoQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertGrupoProdutoAbstratoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateGrupoProdutoAbstratoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteGrupoProdutoAbstratoReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.GrupoProdutoAbstratoReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.GrupoProdutoAbstratoReadFKGRP_PAP_ONDAReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.GrupoProdutoAbstratoReadFKVIN_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.GrupoProdutoAbstratoReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.GrupoProdutoAbstratoReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IGrupoRecursoWriteRepository, Input.Repository.GrupoRecurso.GrupoRecursoWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IGrupoRecursoReadRepository, Read.Repository.GrupoRecursoReadRepository>();
builder.Services.AddTransient<IQuery.Read.IGrupoRecursoQueryRead, Query.Read.GrupoRecursoQueryRead>();
builder.Services.AddTransient<IQuery.Write.IGrupoRecursoQueryWrite, Query.Write.GrupoRecursoQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertGrupoRecursoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateGrupoRecursoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteGrupoRecursoReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.GrupoRecursoReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.GrupoRecursoReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.GrupoRecursoReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IGrupoSegmentoWriteRepository, Input.Repository.GrupoSegmento.GrupoSegmentoWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IGrupoSegmentoReadRepository, Read.Repository.GrupoSegmentoReadRepository>();
builder.Services.AddTransient<IQuery.Read.IGrupoSegmentoQueryRead, Query.Read.GrupoSegmentoQueryRead>();
builder.Services.AddTransient<IQuery.Write.IGrupoSegmentoQueryWrite, Query.Write.GrupoSegmentoQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertGrupoSegmentoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateGrupoSegmentoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteGrupoSegmentoReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.GrupoSegmentoReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.GrupoSegmentoReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.GrupoSegmentoReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IT_HORARIO_RECEBIMENTOWriteRepository, Input.Repository.T_HORARIO_RECEBIMENTO.T_HORARIO_RECEBIMENTOWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IT_HORARIO_RECEBIMENTOReadRepository, Read.Repository.T_HORARIO_RECEBIMENTOReadRepository>();
builder.Services.AddTransient<IQuery.Read.IT_HORARIO_RECEBIMENTOQueryRead, Query.Read.T_HORARIO_RECEBIMENTOQueryRead>();
builder.Services.AddTransient<IQuery.Write.IT_HORARIO_RECEBIMENTOQueryWrite, Query.Write.T_HORARIO_RECEBIMENTOQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertT_HORARIO_RECEBIMENTOReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateT_HORARIO_RECEBIMENTOReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteT_HORARIO_RECEBIMENTOReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.T_HORARIO_RECEBIMENTOReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.T_HORARIO_RECEBIMENTOReadFKCLI_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.T_HORARIO_RECEBIMENTOReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.T_HORARIO_RECEBIMENTOReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IImpressoraWriteRepository, Input.Repository.Impressora.ImpressoraWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IImpressoraReadRepository, Read.Repository.ImpressoraReadRepository>();
builder.Services.AddTransient<IQuery.Read.IImpressoraQueryRead, Query.Read.ImpressoraQueryRead>();
builder.Services.AddTransient<IQuery.Write.IImpressoraQueryWrite, Query.Write.ImpressoraQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertImpressoraReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateImpressoraReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteImpressoraReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ImpressoraReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ImpressoraReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ImpressoraReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IT_IndicadoresWriteRepository, Input.Repository.T_Indicadores.T_IndicadoresWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IT_IndicadoresReadRepository, Read.Repository.T_IndicadoresReadRepository>();
builder.Services.AddTransient<IQuery.Read.IT_IndicadoresQueryRead, Query.Read.T_IndicadoresQueryRead>();
builder.Services.AddTransient<IQuery.Write.IT_IndicadoresQueryWrite, Query.Write.T_IndicadoresQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertT_IndicadoresReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateT_IndicadoresReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteT_IndicadoresReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.T_IndicadoresReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.T_IndicadoresReadFKNEG_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.T_IndicadoresReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.T_IndicadoresReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IIndicadoresDepartamentosWriteRepository, Input.Repository.IndicadoresDepartamentos.IndicadoresDepartamentosWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IIndicadoresDepartamentosReadRepository, Read.Repository.IndicadoresDepartamentosReadRepository>();
builder.Services.AddTransient<IQuery.Read.IIndicadoresDepartamentosQueryRead, Query.Read.IndicadoresDepartamentosQueryRead>();
builder.Services.AddTransient<IQuery.Write.IIndicadoresDepartamentosQueryWrite, Query.Write.IndicadoresDepartamentosQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertIndicadoresDepartamentosReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateIndicadoresDepartamentosReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteIndicadoresDepartamentosReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.IndicadoresDepartamentosReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.IndicadoresDepartamentosReadFKDEP_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.IndicadoresDepartamentosReadFKIND_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.IndicadoresDepartamentosReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.IndicadoresDepartamentosReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IIndicadoresDimencoesWriteRepository, Input.Repository.IndicadoresDimencoes.IndicadoresDimencoesWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IIndicadoresDimencoesReadRepository, Read.Repository.IndicadoresDimencoesReadRepository>();
builder.Services.AddTransient<IQuery.Read.IIndicadoresDimencoesQueryRead, Query.Read.IndicadoresDimencoesQueryRead>();
builder.Services.AddTransient<IQuery.Write.IIndicadoresDimencoesQueryWrite, Query.Write.IndicadoresDimencoesQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertIndicadoresDimencoesReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateIndicadoresDimencoesReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteIndicadoresDimencoesReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.IndicadoresDimencoesReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.IndicadoresDimencoesReadFKIND_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.IndicadoresDimencoesReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.IndicadoresDimencoesReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IIndicadoresFatosDimencoesWriteRepository, Input.Repository.IndicadoresFatosDimencoes.IndicadoresFatosDimencoesWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IIndicadoresFatosDimencoesReadRepository, Read.Repository.IndicadoresFatosDimencoesReadRepository>();
builder.Services.AddTransient<IQuery.Read.IIndicadoresFatosDimencoesQueryRead, Query.Read.IndicadoresFatosDimencoesQueryRead>();
builder.Services.AddTransient<IQuery.Write.IIndicadoresFatosDimencoesQueryWrite, Query.Write.IndicadoresFatosDimencoesQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertIndicadoresFatosDimencoesReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateIndicadoresFatosDimencoesReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteIndicadoresFatosDimencoesReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.IndicadoresFatosDimencoesReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.IndicadoresFatosDimencoesReadFKIND_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.IndicadoresFatosDimencoesReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.IndicadoresFatosDimencoesReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IIndicadoresPeriodosDimencoesWriteRepository, Input.Repository.IndicadoresPeriodosDimencoes.IndicadoresPeriodosDimencoesWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IIndicadoresPeriodosDimencoesReadRepository, Read.Repository.IndicadoresPeriodosDimencoesReadRepository>();
builder.Services.AddTransient<IQuery.Read.IIndicadoresPeriodosDimencoesQueryRead, Query.Read.IndicadoresPeriodosDimencoesQueryRead>();
builder.Services.AddTransient<IQuery.Write.IIndicadoresPeriodosDimencoesQueryWrite, Query.Write.IndicadoresPeriodosDimencoesQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertIndicadoresPeriodosDimencoesReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateIndicadoresPeriodosDimencoesReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteIndicadoresPeriodosDimencoesReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.IndicadoresPeriodosDimencoesReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.IndicadoresPeriodosDimencoesReadFKIND_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.IndicadoresPeriodosDimencoesReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.IndicadoresPeriodosDimencoesReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IInformacoesComplementaresWriteRepository, Input.Repository.InformacoesComplementares.InformacoesComplementaresWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IInformacoesComplementaresReadRepository, Read.Repository.InformacoesComplementaresReadRepository>();
builder.Services.AddTransient<IQuery.Read.IInformacoesComplementaresQueryRead, Query.Read.InformacoesComplementaresQueryRead>();
builder.Services.AddTransient<IQuery.Write.IInformacoesComplementaresQueryWrite, Query.Write.InformacoesComplementaresQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertInformacoesComplementaresReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateInformacoesComplementaresReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteInformacoesComplementaresReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.InformacoesComplementaresReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.InformacoesComplementaresReadFKMET_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.InformacoesComplementaresReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.InformacoesComplementaresReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IInpecaoVisualWriteRepository, Input.Repository.InpecaoVisual.InpecaoVisualWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IInpecaoVisualReadRepository, Read.Repository.InpecaoVisualReadRepository>();
builder.Services.AddTransient<IQuery.Read.IInpecaoVisualQueryRead, Query.Read.InpecaoVisualQueryRead>();
builder.Services.AddTransient<IQuery.Write.IInpecaoVisualQueryWrite, Query.Write.InpecaoVisualQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertInpecaoVisualReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateInpecaoVisualReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteInpecaoVisualReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.InpecaoVisualReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.InpecaoVisualReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.InpecaoVisualReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IItemInspecaoWriteRepository, Input.Repository.ItemInspecao.ItemInspecaoWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IItemInspecaoReadRepository, Read.Repository.ItemInspecaoReadRepository>();
builder.Services.AddTransient<IQuery.Read.IItemInspecaoQueryRead, Query.Read.ItemInspecaoQueryRead>();
builder.Services.AddTransient<IQuery.Write.IItemInspecaoQueryWrite, Query.Write.ItemInspecaoQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertItemInspecaoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateItemInspecaoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteItemInspecaoReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ItemInspecaoReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ItemInspecaoReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ItemInspecaoReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IItemTestavelWriteRepository, Input.Repository.ItemTestavel.ItemTestavelWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IItemTestavelReadRepository, Read.Repository.ItemTestavelReadRepository>();
builder.Services.AddTransient<IQuery.Read.IItemTestavelQueryRead, Query.Read.ItemTestavelQueryRead>();
builder.Services.AddTransient<IQuery.Write.IItemTestavelQueryWrite, Query.Write.ItemTestavelQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertItemTestavelReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateItemTestavelReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteItemTestavelReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ItemTestavelReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ItemTestavelReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ItemTestavelReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IItensCalendarioWriteRepository, Input.Repository.ItensCalendario.ItensCalendarioWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IItensCalendarioReadRepository, Read.Repository.ItensCalendarioReadRepository>();
builder.Services.AddTransient<IQuery.Read.IItensCalendarioQueryRead, Query.Read.ItensCalendarioQueryRead>();
builder.Services.AddTransient<IQuery.Write.IItensCalendarioQueryWrite, Query.Write.ItensCalendarioQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertItensCalendarioReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateItensCalendarioReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteItensCalendarioReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ItensCalendarioReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ItensCalendarioReadFKURM_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ItensCalendarioReadFKURN_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ItensCalendarioReadFKCAL_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ItensCalendarioReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ItensCalendarioReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IItenCalendarioDisponibilidadeVeiculosWriteRepository, Input.Repository.ItenCalendarioDisponibilidadeVeiculos.ItenCalendarioDisponibilidadeVeiculosWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IItenCalendarioDisponibilidadeVeiculosReadRepository, Read.Repository.ItenCalendarioDisponibilidadeVeiculosReadRepository>();
builder.Services.AddTransient<IQuery.Read.IItenCalendarioDisponibilidadeVeiculosQueryRead, Query.Read.ItenCalendarioDisponibilidadeVeiculosQueryRead>();
builder.Services.AddTransient<IQuery.Write.IItenCalendarioDisponibilidadeVeiculosQueryWrite, Query.Write.ItenCalendarioDisponibilidadeVeiculosQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertItenCalendarioDisponibilidadeVeiculosReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateItenCalendarioDisponibilidadeVeiculosReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteItenCalendarioDisponibilidadeVeiculosReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ItenCalendarioDisponibilidadeVeiculosReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ItenCalendarioDisponibilidadeVeiculosReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ItenCalendarioDisponibilidadeVeiculosReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IItenCargaWriteRepository, Input.Repository.ItenCarga.ItenCargaWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IItenCargaReadRepository, Read.Repository.ItenCargaReadRepository>();
builder.Services.AddTransient<IQuery.Read.IItenCargaQueryRead, Query.Read.ItenCargaQueryRead>();
builder.Services.AddTransient<IQuery.Write.IItenCargaQueryWrite, Query.Write.ItenCargaQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertItenCargaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateItenCargaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteItenCargaReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ItenCargaReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ItenCargaReadFKORD_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ItenCargaReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ItenCargaReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IItensEstruturaImpressaoWriteRepository, Input.Repository.ItensEstruturaImpressao.ItensEstruturaImpressaoWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IItensEstruturaImpressaoReadRepository, Read.Repository.ItensEstruturaImpressaoReadRepository>();
builder.Services.AddTransient<IQuery.Read.IItensEstruturaImpressaoQueryRead, Query.Read.ItensEstruturaImpressaoQueryRead>();
builder.Services.AddTransient<IQuery.Write.IItensEstruturaImpressaoQueryWrite, Query.Write.ItensEstruturaImpressaoQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertItensEstruturaImpressaoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateItensEstruturaImpressaoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteItensEstruturaImpressaoReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ItensEstruturaImpressaoReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ItensEstruturaImpressaoReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ItensEstruturaImpressaoReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IItensOrcamentoWriteRepository, Input.Repository.ItensOrcamento.ItensOrcamentoWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IItensOrcamentoReadRepository, Read.Repository.ItensOrcamentoReadRepository>();
builder.Services.AddTransient<IQuery.Read.IItensOrcamentoQueryRead, Query.Read.ItensOrcamentoQueryRead>();
builder.Services.AddTransient<IQuery.Write.IItensOrcamentoQueryWrite, Query.Write.ItensOrcamentoQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertItensOrcamentoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateItensOrcamentoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteItensOrcamentoReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ItensOrcamentoReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ItensOrcamentoReadFKGRP_ID_COMPOSICAOReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ItensOrcamentoReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ItensOrcamentoReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IItensPackedWriteRepository, Input.Repository.ItensPacked.ItensPackedWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IItensPackedReadRepository, Read.Repository.ItensPackedReadRepository>();
builder.Services.AddTransient<IQuery.Read.IItensPackedQueryRead, Query.Read.ItensPackedQueryRead>();
builder.Services.AddTransient<IQuery.Write.IItensPackedQueryWrite, Query.Write.ItensPackedQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertItensPackedReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateItensPackedReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteItensPackedReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ItensPackedReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ItensPackedReadFKORD_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ItensPackedReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ItensPackedReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ILaudoTesteFisicoWriteRepository, Input.Repository.LaudoTesteFisico.LaudoTesteFisicoWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ILaudoTesteFisicoReadRepository, Read.Repository.LaudoTesteFisicoReadRepository>();
builder.Services.AddTransient<IQuery.Read.ILaudoTesteFisicoQueryRead, Query.Read.LaudoTesteFisicoQueryRead>();
builder.Services.AddTransient<IQuery.Write.ILaudoTesteFisicoQueryWrite, Query.Write.LaudoTesteFisicoQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertLaudoTesteFisicoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateLaudoTesteFisicoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteLaudoTesteFisicoReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.LaudoTesteFisicoReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.LaudoTesteFisicoReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.LaudoTesteFisicoReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ILogsWriteRepository, Input.Repository.Logs.LogsWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ILogsReadRepository, Read.Repository.LogsReadRepository>();
builder.Services.AddTransient<IQuery.Read.ILogsQueryRead, Query.Read.LogsQueryRead>();
builder.Services.AddTransient<IQuery.Write.ILogsQueryWrite, Query.Write.LogsQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertLogsReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateLogsReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteLogsReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.LogsReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.LogsReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.LogsReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ILogsDatabaseWriteRepository, Input.Repository.LogsDatabase.LogsDatabaseWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ILogsDatabaseReadRepository, Read.Repository.LogsDatabaseReadRepository>();
builder.Services.AddTransient<IQuery.Read.ILogsDatabaseQueryRead, Query.Read.LogsDatabaseQueryRead>();
builder.Services.AddTransient<IQuery.Write.ILogsDatabaseQueryWrite, Query.Write.LogsDatabaseQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertLogsDatabaseReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateLogsDatabaseReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteLogsDatabaseReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.LogsDatabaseReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.LogsDatabaseReadFKUSE_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.LogsDatabaseReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.LogsDatabaseReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ILoockWriteRepository, Input.Repository.Loock.LoockWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ILoockReadRepository, Read.Repository.LoockReadRepository>();
builder.Services.AddTransient<IQuery.Read.ILoockQueryRead, Query.Read.LoockQueryRead>();
builder.Services.AddTransient<IQuery.Write.ILoockQueryWrite, Query.Write.LoockQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertLoockReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateLoockReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteLoockReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.LoockReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.LoockReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.LoockReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ILoteTesteWriteRepository, Input.Repository.LoteTeste.LoteTesteWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ILoteTesteReadRepository, Read.Repository.LoteTesteReadRepository>();
builder.Services.AddTransient<IQuery.Read.ILoteTesteQueryRead, Query.Read.LoteTesteQueryRead>();
builder.Services.AddTransient<IQuery.Write.ILoteTesteQueryWrite, Query.Write.LoteTesteQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertLoteTesteReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateLoteTesteReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteLoteTesteReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.LoteTesteReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.LoteTesteReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.LoteTesteReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ILotesWriteRepository, Input.Repository.Lotes.LotesWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ILotesReadRepository, Read.Repository.LotesReadRepository>();
builder.Services.AddTransient<IQuery.Read.ILotesQueryRead, Query.Read.LotesQueryRead>();
builder.Services.AddTransient<IQuery.Write.ILotesQueryWrite, Query.Write.LotesQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertLotesReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateLotesReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteLotesReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.LotesReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.LotesReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.LotesReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IMapaWriteRepository, Input.Repository.Mapa.MapaWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IMapaReadRepository, Read.Repository.MapaReadRepository>();
builder.Services.AddTransient<IQuery.Read.IMapaQueryRead, Query.Read.MapaQueryRead>();
builder.Services.AddTransient<IQuery.Write.IMapaQueryWrite, Query.Write.MapaQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertMapaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateMapaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteMapaReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MapaReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MapaReadFKPON_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MapaReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MapaReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IMaquinaGrupoMaquinaWriteRepository, Input.Repository.MaquinaGrupoMaquina.MaquinaGrupoMaquinaWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IMaquinaGrupoMaquinaReadRepository, Read.Repository.MaquinaGrupoMaquinaReadRepository>();
builder.Services.AddTransient<IQuery.Read.IMaquinaGrupoMaquinaQueryRead, Query.Read.MaquinaGrupoMaquinaQueryRead>();
builder.Services.AddTransient<IQuery.Write.IMaquinaGrupoMaquinaQueryWrite, Query.Write.MaquinaGrupoMaquinaQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertMaquinaGrupoMaquinaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateMaquinaGrupoMaquinaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteMaquinaGrupoMaquinaReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MaquinaGrupoMaquinaReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MaquinaGrupoMaquinaReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MaquinaGrupoMaquinaReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IMaquinaImpressoraWriteRepository, Input.Repository.MaquinaImpressora.MaquinaImpressoraWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IMaquinaImpressoraReadRepository, Read.Repository.MaquinaImpressoraReadRepository>();
builder.Services.AddTransient<IQuery.Read.IMaquinaImpressoraQueryRead, Query.Read.MaquinaImpressoraQueryRead>();
builder.Services.AddTransient<IQuery.Write.IMaquinaImpressoraQueryWrite, Query.Write.MaquinaImpressoraQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertMaquinaImpressoraReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateMaquinaImpressoraReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteMaquinaImpressoraReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MaquinaImpressoraReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MaquinaImpressoraReadFKIMP_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MaquinaImpressoraReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MaquinaImpressoraReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IT_MAQUINAS_EQUIPESWriteRepository, Input.Repository.T_MAQUINAS_EQUIPES.T_MAQUINAS_EQUIPESWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IT_MAQUINAS_EQUIPESReadRepository, Read.Repository.T_MAQUINAS_EQUIPESReadRepository>();
builder.Services.AddTransient<IQuery.Read.IT_MAQUINAS_EQUIPESQueryRead, Query.Read.T_MAQUINAS_EQUIPESQueryRead>();
builder.Services.AddTransient<IQuery.Write.IT_MAQUINAS_EQUIPESQueryWrite, Query.Write.T_MAQUINAS_EQUIPESQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertT_MAQUINAS_EQUIPESReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateT_MAQUINAS_EQUIPESReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteT_MAQUINAS_EQUIPESReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.T_MAQUINAS_EQUIPESReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.T_MAQUINAS_EQUIPESReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.T_MAQUINAS_EQUIPESReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IT_MedicoesWriteRepository, Input.Repository.T_Medicoes.T_MedicoesWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IT_MedicoesReadRepository, Read.Repository.T_MedicoesReadRepository>();
builder.Services.AddTransient<IQuery.Read.IT_MedicoesQueryRead, Query.Read.T_MedicoesQueryRead>();
builder.Services.AddTransient<IQuery.Write.IT_MedicoesQueryWrite, Query.Write.T_MedicoesQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertT_MedicoesReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateT_MedicoesReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteT_MedicoesReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.T_MedicoesReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.T_MedicoesReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.T_MedicoesReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IMedicoesOnduladeiraWriteRepository, Input.Repository.MedicoesOnduladeira.MedicoesOnduladeiraWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IMedicoesOnduladeiraReadRepository, Read.Repository.MedicoesOnduladeiraReadRepository>();
builder.Services.AddTransient<IQuery.Read.IMedicoesOnduladeiraQueryRead, Query.Read.MedicoesOnduladeiraQueryRead>();
builder.Services.AddTransient<IQuery.Write.IMedicoesOnduladeiraQueryWrite, Query.Write.MedicoesOnduladeiraQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertMedicoesOnduladeiraReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateMedicoesOnduladeiraReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteMedicoesOnduladeiraReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MedicoesOnduladeiraReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MedicoesOnduladeiraReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MedicoesOnduladeiraReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IMedidasTesteWriteRepository, Input.Repository.MedidasTeste.MedidasTesteWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IMedidasTesteReadRepository, Read.Repository.MedidasTesteReadRepository>();
builder.Services.AddTransient<IQuery.Read.IMedidasTesteQueryRead, Query.Read.MedidasTesteQueryRead>();
builder.Services.AddTransient<IQuery.Write.IMedidasTesteQueryWrite, Query.Write.MedidasTesteQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertMedidasTesteReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateMedidasTesteReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteMedidasTesteReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MedidasTesteReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MedidasTesteReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MedidasTesteReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IMemoriaDeCalculoWriteRepository, Input.Repository.MemoriaDeCalculo.MemoriaDeCalculoWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IMemoriaDeCalculoReadRepository, Read.Repository.MemoriaDeCalculoReadRepository>();
builder.Services.AddTransient<IQuery.Read.IMemoriaDeCalculoQueryRead, Query.Read.MemoriaDeCalculoQueryRead>();
builder.Services.AddTransient<IQuery.Write.IMemoriaDeCalculoQueryWrite, Query.Write.MemoriaDeCalculoQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertMemoriaDeCalculoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateMemoriaDeCalculoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteMemoriaDeCalculoReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MemoriaDeCalculoReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MemoriaDeCalculoReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MemoriaDeCalculoReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IMensagemWriteRepository, Input.Repository.Mensagem.MensagemWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IMensagemReadRepository, Read.Repository.MensagemReadRepository>();
builder.Services.AddTransient<IQuery.Read.IMensagemQueryRead, Query.Read.MensagemQueryRead>();
builder.Services.AddTransient<IQuery.Write.IMensagemQueryWrite, Query.Write.MensagemQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertMensagemReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateMensagemReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteMensagemReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MensagemReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MensagemReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MensagemReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IMesesWriteRepository, Input.Repository.Meses.MesesWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IMesesReadRepository, Read.Repository.MesesReadRepository>();
builder.Services.AddTransient<IQuery.Read.IMesesQueryRead, Query.Read.MesesQueryRead>();
builder.Services.AddTransient<IQuery.Write.IMesesQueryWrite, Query.Write.MesesQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertMesesReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateMesesReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteMesesReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MesesReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MesesReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MesesReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IT_MetasWriteRepository, Input.Repository.T_Metas.T_MetasWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IT_MetasReadRepository, Read.Repository.T_MetasReadRepository>();
builder.Services.AddTransient<IQuery.Read.IT_MetasQueryRead, Query.Read.T_MetasQueryRead>();
builder.Services.AddTransient<IQuery.Write.IT_MetasQueryWrite, Query.Write.T_MetasQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertT_MetasReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateT_MetasReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteT_MetasReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.T_MetasReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.T_MetasReadFKIND_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.T_MetasReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.T_MetasReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IMovimentoEstoqueWriteRepository, Input.Repository.MovimentoEstoque.MovimentoEstoqueWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IMovimentoEstoqueReadRepository, Read.Repository.MovimentoEstoqueReadRepository>();
builder.Services.AddTransient<IQuery.Read.IMovimentoEstoqueQueryRead, Query.Read.MovimentoEstoqueQueryRead>();
builder.Services.AddTransient<IQuery.Write.IMovimentoEstoqueQueryWrite, Query.Write.MovimentoEstoqueQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertMovimentoEstoqueReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateMovimentoEstoqueReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteMovimentoEstoqueReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MovimentoEstoqueReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MovimentoEstoqueReadFKOrderIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MovimentoEstoqueReadFKTipoReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MovimentoEstoqueReadFKTurnoIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MovimentoEstoqueReadFKTurmaIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MovimentoEstoqueReadFKOcorrenciaIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MovimentoEstoqueReadFKCLI_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MovimentoEstoqueReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MovimentoEstoqueReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IMunicipioWriteRepository, Input.Repository.Municipio.MunicipioWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IMunicipioReadRepository, Read.Repository.MunicipioReadRepository>();
builder.Services.AddTransient<IQuery.Read.IMunicipioQueryRead, Query.Read.MunicipioQueryRead>();
builder.Services.AddTransient<IQuery.Write.IMunicipioQueryWrite, Query.Write.MunicipioQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertMunicipioReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateMunicipioReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteMunicipioReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MunicipioReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MunicipioReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MunicipioReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IT_NegocioWriteRepository, Input.Repository.T_Negocio.T_NegocioWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IT_NegocioReadRepository, Read.Repository.T_NegocioReadRepository>();
builder.Services.AddTransient<IQuery.Read.IT_NegocioQueryRead, Query.Read.T_NegocioQueryRead>();
builder.Services.AddTransient<IQuery.Write.IT_NegocioQueryWrite, Query.Write.T_NegocioQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertT_NegocioReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateT_NegocioReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteT_NegocioReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.T_NegocioReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.T_NegocioReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.T_NegocioReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IObjetoControlavelWriteRepository, Input.Repository.ObjetoControlavel.ObjetoControlavelWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IObjetoControlavelReadRepository, Read.Repository.ObjetoControlavelReadRepository>();
builder.Services.AddTransient<IQuery.Read.IObjetoControlavelQueryRead, Query.Read.ObjetoControlavelQueryRead>();
builder.Services.AddTransient<IQuery.Write.IObjetoControlavelQueryWrite, Query.Write.ObjetoControlavelQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertObjetoControlavelReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateObjetoControlavelReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteObjetoControlavelReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ObjetoControlavelReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ObjetoControlavelReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ObjetoControlavelReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IObservacoesWriteRepository, Input.Repository.Observacoes.ObservacoesWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IObservacoesReadRepository, Read.Repository.ObservacoesReadRepository>();
builder.Services.AddTransient<IQuery.Read.IObservacoesQueryRead, Query.Read.ObservacoesQueryRead>();
builder.Services.AddTransient<IQuery.Write.IObservacoesQueryWrite, Query.Write.ObservacoesQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertObservacoesReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateObservacoesReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteObservacoesReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ObservacoesReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ObservacoesReadFKCLI_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ObservacoesReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ObservacoesReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IOcorrenciaWriteRepository, Input.Repository.Ocorrencia.OcorrenciaWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IOcorrenciaReadRepository, Read.Repository.OcorrenciaReadRepository>();
builder.Services.AddTransient<IQuery.Read.IOcorrenciaQueryRead, Query.Read.OcorrenciaQueryRead>();
builder.Services.AddTransient<IQuery.Write.IOcorrenciaQueryWrite, Query.Write.OcorrenciaQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertOcorrenciaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateOcorrenciaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteOcorrenciaReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.OcorrenciaReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.OcorrenciaReadFKTIP_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.OcorrenciaReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.OcorrenciaReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IOndaWriteRepository, Input.Repository.Onda.OndaWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IOndaReadRepository, Read.Repository.OndaReadRepository>();
builder.Services.AddTransient<IQuery.Read.IOndaQueryRead, Query.Read.OndaQueryRead>();
builder.Services.AddTransient<IQuery.Write.IOndaQueryWrite, Query.Write.OndaQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertOndaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateOndaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteOndaReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.OndaReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.OndaReadFKVIN_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.OndaReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.OndaReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IOperacoesWriteRepository, Input.Repository.Operacoes.OperacoesWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IOperacoesReadRepository, Read.Repository.OperacoesReadRepository>();
builder.Services.AddTransient<IQuery.Read.IOperacoesQueryRead, Query.Read.OperacoesQueryRead>();
builder.Services.AddTransient<IQuery.Write.IOperacoesQueryWrite, Query.Write.OperacoesQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertOperacoesReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateOperacoesReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteOperacoesReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.OperacoesReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.OperacoesReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.OperacoesReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IOptAlteracaoDimencoesWriteRepository, Input.Repository.OptAlteracaoDimencoes.OptAlteracaoDimencoesWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IOptAlteracaoDimencoesReadRepository, Read.Repository.OptAlteracaoDimencoesReadRepository>();
builder.Services.AddTransient<IQuery.Read.IOptAlteracaoDimencoesQueryRead, Query.Read.OptAlteracaoDimencoesQueryRead>();
builder.Services.AddTransient<IQuery.Write.IOptAlteracaoDimencoesQueryWrite, Query.Write.OptAlteracaoDimencoesQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertOptAlteracaoDimencoesReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateOptAlteracaoDimencoesReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteOptAlteracaoDimencoesReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.OptAlteracaoDimencoesReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.OptAlteracaoDimencoesReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.OptAlteracaoDimencoesReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IOrcamentoWriteRepository, Input.Repository.Orcamento.OrcamentoWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IOrcamentoReadRepository, Read.Repository.OrcamentoReadRepository>();
builder.Services.AddTransient<IQuery.Read.IOrcamentoQueryRead, Query.Read.OrcamentoQueryRead>();
builder.Services.AddTransient<IQuery.Write.IOrcamentoQueryWrite, Query.Write.OrcamentoQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertOrcamentoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateOrcamentoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteOrcamentoReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.OrcamentoReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.OrcamentoReadFKCLI_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.OrcamentoReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.OrcamentoReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IOrderTrackWriteRepository, Input.Repository.OrderTrack.OrderTrackWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IOrderTrackReadRepository, Read.Repository.OrderTrackReadRepository>();
builder.Services.AddTransient<IQuery.Read.IOrderTrackQueryRead, Query.Read.OrderTrackQueryRead>();
builder.Services.AddTransient<IQuery.Write.IOrderTrackQueryWrite, Query.Write.OrderTrackQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertOrderTrackReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateOrderTrackReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteOrderTrackReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.OrderTrackReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.OrderTrackReadFKORD_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.OrderTrackReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.OrderTrackReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IOrderWriteRepository, Input.Repository.Order.OrderWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IOrderReadRepository, Read.Repository.OrderReadRepository>();
builder.Services.AddTransient<IQuery.Read.IOrderQueryRead, Query.Read.OrderQueryRead>();
builder.Services.AddTransient<IQuery.Write.IOrderQueryWrite, Query.Write.OrderQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertOrderReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateOrderReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteOrderReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.OrderReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.OrderReadFKCLI_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.OrderReadFKMUN_ID_ENTREGAReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.OrderReadFKORD_REGIAO_ENTREGAReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.OrderReadFKOCO_ID_CANCELAMENTOReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.OrderReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.OrderReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IParamWriteRepository, Input.Repository.Param.ParamWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IParamReadRepository, Read.Repository.ParamReadRepository>();
builder.Services.AddTransient<IQuery.Read.IParamQueryRead, Query.Read.ParamQueryRead>();
builder.Services.AddTransient<IQuery.Write.IParamQueryWrite, Query.Write.ParamQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertParamReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateParamReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteParamReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ParamReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ParamReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ParamReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IParametrosDeCustoWriteRepository, Input.Repository.ParametrosDeCusto.ParametrosDeCustoWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IParametrosDeCustoReadRepository, Read.Repository.ParametrosDeCustoReadRepository>();
builder.Services.AddTransient<IQuery.Read.IParametrosDeCustoQueryRead, Query.Read.ParametrosDeCustoQueryRead>();
builder.Services.AddTransient<IQuery.Write.IParametrosDeCustoQueryWrite, Query.Write.ParametrosDeCustoQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertParametrosDeCustoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateParametrosDeCustoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteParametrosDeCustoReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ParametrosDeCustoReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ParametrosDeCustoReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ParametrosDeCustoReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IPendenciasInterfaceWriteRepository, Input.Repository.PendenciasInterface.PendenciasInterfaceWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IPendenciasInterfaceReadRepository, Read.Repository.PendenciasInterfaceReadRepository>();
builder.Services.AddTransient<IQuery.Read.IPendenciasInterfaceQueryRead, Query.Read.PendenciasInterfaceQueryRead>();
builder.Services.AddTransient<IQuery.Write.IPendenciasInterfaceQueryWrite, Query.Write.PendenciasInterfaceQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertPendenciasInterfaceReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdatePendenciasInterfaceReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeletePendenciasInterfaceReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.PendenciasInterfaceReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.PendenciasInterfaceReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.PendenciasInterfaceReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IPerfilWriteRepository, Input.Repository.Perfil.PerfilWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IPerfilReadRepository, Read.Repository.PerfilReadRepository>();
builder.Services.AddTransient<IQuery.Read.IPerfilQueryRead, Query.Read.PerfilQueryRead>();
builder.Services.AddTransient<IQuery.Write.IPerfilQueryWrite, Query.Write.PerfilQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertPerfilReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdatePerfilReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeletePerfilReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.PerfilReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.PerfilReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.PerfilReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IPerfilObjetoControlavelWriteRepository, Input.Repository.PerfilObjetoControlavel.PerfilObjetoControlavelWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IPerfilObjetoControlavelReadRepository, Read.Repository.PerfilObjetoControlavelReadRepository>();
builder.Services.AddTransient<IQuery.Read.IPerfilObjetoControlavelQueryRead, Query.Read.PerfilObjetoControlavelQueryRead>();
builder.Services.AddTransient<IQuery.Write.IPerfilObjetoControlavelQueryWrite, Query.Write.PerfilObjetoControlavelQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertPerfilObjetoControlavelReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdatePerfilObjetoControlavelReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeletePerfilObjetoControlavelReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.PerfilObjetoControlavelReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.PerfilObjetoControlavelReadFKPER_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.PerfilObjetoControlavelReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.PerfilObjetoControlavelReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IPeriodicidadeTesteWriteRepository, Input.Repository.PeriodicidadeTeste.PeriodicidadeTesteWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IPeriodicidadeTesteReadRepository, Read.Repository.PeriodicidadeTesteReadRepository>();
builder.Services.AddTransient<IQuery.Read.IPeriodicidadeTesteQueryRead, Query.Read.PeriodicidadeTesteQueryRead>();
builder.Services.AddTransient<IQuery.Write.IPeriodicidadeTesteQueryWrite, Query.Write.PeriodicidadeTesteQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertPeriodicidadeTesteReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdatePeriodicidadeTesteReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeletePeriodicidadeTesteReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.PeriodicidadeTesteReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.PeriodicidadeTesteReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.PeriodicidadeTesteReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IPlanoAmostralTesteWriteRepository, Input.Repository.PlanoAmostralTeste.PlanoAmostralTesteWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IPlanoAmostralTesteReadRepository, Read.Repository.PlanoAmostralTesteReadRepository>();
builder.Services.AddTransient<IQuery.Read.IPlanoAmostralTesteQueryRead, Query.Read.PlanoAmostralTesteQueryRead>();
builder.Services.AddTransient<IQuery.Write.IPlanoAmostralTesteQueryWrite, Query.Write.PlanoAmostralTesteQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertPlanoAmostralTesteReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdatePlanoAmostralTesteReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeletePlanoAmostralTesteReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.PlanoAmostralTesteReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.PlanoAmostralTesteReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.PlanoAmostralTesteReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IPlanoacaoWriteRepository, Input.Repository.Planoacao.PlanoacaoWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IPlanoacaoReadRepository, Read.Repository.PlanoacaoReadRepository>();
builder.Services.AddTransient<IQuery.Read.IPlanoacaoQueryRead, Query.Read.PlanoacaoQueryRead>();
builder.Services.AddTransient<IQuery.Write.IPlanoacaoQueryWrite, Query.Write.PlanoacaoQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertPlanoacaoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdatePlanoacaoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeletePlanoacaoReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.PlanoacaoReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.PlanoacaoReadFKMET_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.PlanoacaoReadFKUSE_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.PlanoacaoReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.PlanoacaoReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IPlotagemWriteRepository, Input.Repository.Plotagem.PlotagemWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IPlotagemReadRepository, Read.Repository.PlotagemReadRepository>();
builder.Services.AddTransient<IQuery.Read.IPlotagemQueryRead, Query.Read.PlotagemQueryRead>();
builder.Services.AddTransient<IQuery.Write.IPlotagemQueryWrite, Query.Write.PlotagemQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertPlotagemReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdatePlotagemReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeletePlotagemReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.PlotagemReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.PlotagemReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.PlotagemReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IPoliticaOnduladeiraWriteRepository, Input.Repository.PoliticaOnduladeira.PoliticaOnduladeiraWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IPoliticaOnduladeiraReadRepository, Read.Repository.PoliticaOnduladeiraReadRepository>();
builder.Services.AddTransient<IQuery.Read.IPoliticaOnduladeiraQueryRead, Query.Read.PoliticaOnduladeiraQueryRead>();
builder.Services.AddTransient<IQuery.Write.IPoliticaOnduladeiraQueryWrite, Query.Write.PoliticaOnduladeiraQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertPoliticaOnduladeiraReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdatePoliticaOnduladeiraReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeletePoliticaOnduladeiraReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.PoliticaOnduladeiraReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.PoliticaOnduladeiraReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.PoliticaOnduladeiraReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IPontosMapaWriteRepository, Input.Repository.PontosMapa.PontosMapaWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IPontosMapaReadRepository, Read.Repository.PontosMapaReadRepository>();
builder.Services.AddTransient<IQuery.Read.IPontosMapaQueryRead, Query.Read.PontosMapaQueryRead>();
builder.Services.AddTransient<IQuery.Write.IPontosMapaQueryWrite, Query.Write.PontosMapaQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertPontosMapaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdatePontosMapaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeletePontosMapaReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.PontosMapaReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.PontosMapaReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.PontosMapaReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IT_PREFERENCIASWriteRepository, Input.Repository.T_PREFERENCIAS.T_PREFERENCIASWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IT_PREFERENCIASReadRepository, Read.Repository.T_PREFERENCIASReadRepository>();
builder.Services.AddTransient<IQuery.Read.IT_PREFERENCIASQueryRead, Query.Read.T_PREFERENCIASQueryRead>();
builder.Services.AddTransient<IQuery.Write.IT_PREFERENCIASQueryWrite, Query.Write.T_PREFERENCIASQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertT_PREFERENCIASReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateT_PREFERENCIASReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteT_PREFERENCIASReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.T_PREFERENCIASReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.T_PREFERENCIASReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.T_PREFERENCIASReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IProtocoloOnduladeiraWriteRepository, Input.Repository.ProtocoloOnduladeira.ProtocoloOnduladeiraWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IProtocoloOnduladeiraReadRepository, Read.Repository.ProtocoloOnduladeiraReadRepository>();
builder.Services.AddTransient<IQuery.Read.IProtocoloOnduladeiraQueryRead, Query.Read.ProtocoloOnduladeiraQueryRead>();
builder.Services.AddTransient<IQuery.Write.IProtocoloOnduladeiraQueryWrite, Query.Write.ProtocoloOnduladeiraQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertProtocoloOnduladeiraReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateProtocoloOnduladeiraReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteProtocoloOnduladeiraReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ProtocoloOnduladeiraReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ProtocoloOnduladeiraReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ProtocoloOnduladeiraReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IRecursosWriteRepository, Input.Repository.Recursos.RecursosWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IRecursosReadRepository, Read.Repository.RecursosReadRepository>();
builder.Services.AddTransient<IQuery.Read.IRecursosQueryRead, Query.Read.RecursosQueryRead>();
builder.Services.AddTransient<IQuery.Write.IRecursosQueryWrite, Query.Write.RecursosQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertRecursosReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateRecursosReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteRecursosReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.RecursosReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.RecursosReadFKCAL_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.RecursosReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.RecursosReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IRegistrosOnduladeiraWriteRepository, Input.Repository.RegistrosOnduladeira.RegistrosOnduladeiraWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IRegistrosOnduladeiraReadRepository, Read.Repository.RegistrosOnduladeiraReadRepository>();
builder.Services.AddTransient<IQuery.Read.IRegistrosOnduladeiraQueryRead, Query.Read.RegistrosOnduladeiraQueryRead>();
builder.Services.AddTransient<IQuery.Write.IRegistrosOnduladeiraQueryWrite, Query.Write.RegistrosOnduladeiraQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertRegistrosOnduladeiraReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateRegistrosOnduladeiraReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteRegistrosOnduladeiraReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.RegistrosOnduladeiraReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.RegistrosOnduladeiraReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.RegistrosOnduladeiraReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IRepresentantesWriteRepository, Input.Repository.Representantes.RepresentantesWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IRepresentantesReadRepository, Read.Repository.RepresentantesReadRepository>();
builder.Services.AddTransient<IQuery.Read.IRepresentantesQueryRead, Query.Read.RepresentantesQueryRead>();
builder.Services.AddTransient<IQuery.Write.IRepresentantesQueryWrite, Query.Write.RepresentantesQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertRepresentantesReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateRepresentantesReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteRepresentantesReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.RepresentantesReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.RepresentantesReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.RepresentantesReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IRespInspVisualWriteRepository, Input.Repository.RespInspVisual.RespInspVisualWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IRespInspVisualReadRepository, Read.Repository.RespInspVisualReadRepository>();
builder.Services.AddTransient<IQuery.Read.IRespInspVisualQueryRead, Query.Read.RespInspVisualQueryRead>();
builder.Services.AddTransient<IQuery.Write.IRespInspVisualQueryWrite, Query.Write.RespInspVisualQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertRespInspVisualReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateRespInspVisualReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteRespInspVisualReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.RespInspVisualReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.RespInspVisualReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.RespInspVisualReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IRestricoesDeRodagemWriteRepository, Input.Repository.RestricoesDeRodagem.RestricoesDeRodagemWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IRestricoesDeRodagemReadRepository, Read.Repository.RestricoesDeRodagemReadRepository>();
builder.Services.AddTransient<IQuery.Read.IRestricoesDeRodagemQueryRead, Query.Read.RestricoesDeRodagemQueryRead>();
builder.Services.AddTransient<IQuery.Write.IRestricoesDeRodagemQueryWrite, Query.Write.RestricoesDeRodagemQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertRestricoesDeRodagemReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateRestricoesDeRodagemReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteRestricoesDeRodagemReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.RestricoesDeRodagemReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.RestricoesDeRodagemReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.RestricoesDeRodagemReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IResultLoteWriteRepository, Input.Repository.ResultLote.ResultLoteWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IResultLoteReadRepository, Read.Repository.ResultLoteReadRepository>();
builder.Services.AddTransient<IQuery.Read.IResultLoteQueryRead, Query.Read.ResultLoteQueryRead>();
builder.Services.AddTransient<IQuery.Write.IResultLoteQueryWrite, Query.Write.ResultLoteQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertResultLoteReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateResultLoteReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteResultLoteReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ResultLoteReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ResultLoteReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ResultLoteReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IResultMedidaWriteRepository, Input.Repository.ResultMedida.ResultMedidaWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IResultMedidaReadRepository, Read.Repository.ResultMedidaReadRepository>();
builder.Services.AddTransient<IQuery.Read.IResultMedidaQueryRead, Query.Read.ResultMedidaQueryRead>();
builder.Services.AddTransient<IQuery.Write.IResultMedidaQueryWrite, Query.Write.ResultMedidaQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertResultMedidaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateResultMedidaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteResultMedidaReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ResultMedidaReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ResultMedidaReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ResultMedidaReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IRodoviasWriteRepository, Input.Repository.Rodovias.RodoviasWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IRodoviasReadRepository, Read.Repository.RodoviasReadRepository>();
builder.Services.AddTransient<IQuery.Read.IRodoviasQueryRead, Query.Read.RodoviasQueryRead>();
builder.Services.AddTransient<IQuery.Write.IRodoviasQueryWrite, Query.Write.RodoviasQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertRodoviasReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateRodoviasReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteRodoviasReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.RodoviasReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.RodoviasReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.RodoviasReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IRotaRealizadaWriteRepository, Input.Repository.RotaRealizada.RotaRealizadaWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IRotaRealizadaReadRepository, Read.Repository.RotaRealizadaReadRepository>();
builder.Services.AddTransient<IQuery.Read.IRotaRealizadaQueryRead, Query.Read.RotaRealizadaQueryRead>();
builder.Services.AddTransient<IQuery.Write.IRotaRealizadaQueryWrite, Query.Write.RotaRealizadaQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertRotaRealizadaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateRotaRealizadaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteRotaRealizadaReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.RotaRealizadaReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.RotaRealizadaReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.RotaRealizadaReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IRotaPontosMapaWriteRepository, Input.Repository.RotaPontosMapa.RotaPontosMapaWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IRotaPontosMapaReadRepository, Read.Repository.RotaPontosMapaReadRepository>();
builder.Services.AddTransient<IQuery.Read.IRotaPontosMapaQueryRead, Query.Read.RotaPontosMapaQueryRead>();
builder.Services.AddTransient<IQuery.Write.IRotaPontosMapaQueryWrite, Query.Write.RotaPontosMapaQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertRotaPontosMapaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateRotaPontosMapaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteRotaPontosMapaReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.RotaPontosMapaReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.RotaPontosMapaReadFKPON_ID_DESTINOReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.RotaPontosMapaReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.RotaPontosMapaReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ISegmentoWriteRepository, Input.Repository.Segmento.SegmentoWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ISegmentoReadRepository, Read.Repository.SegmentoReadRepository>();
builder.Services.AddTransient<IQuery.Read.ISegmentoQueryRead, Query.Read.SegmentoQueryRead>();
builder.Services.AddTransient<IQuery.Write.ISegmentoQueryWrite, Query.Write.SegmentoQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertSegmentoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateSegmentoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteSegmentoReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.SegmentoReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.SegmentoReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.SegmentoReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ISegmentosProdutosWriteRepository, Input.Repository.SegmentosProdutos.SegmentosProdutosWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ISegmentosProdutosReadRepository, Read.Repository.SegmentosProdutosReadRepository>();
builder.Services.AddTransient<IQuery.Read.ISegmentosProdutosQueryRead, Query.Read.SegmentosProdutosQueryRead>();
builder.Services.AddTransient<IQuery.Write.ISegmentosProdutosQueryWrite, Query.Write.SegmentosProdutosQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertSegmentosProdutosReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateSegmentosProdutosReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteSegmentosProdutosReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.SegmentosProdutosReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.SegmentosProdutosReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.SegmentosProdutosReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ISemaforoWriteRepository, Input.Repository.Semaforo.SemaforoWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ISemaforoReadRepository, Read.Repository.SemaforoReadRepository>();
builder.Services.AddTransient<IQuery.Read.ISemaforoQueryRead, Query.Read.SemaforoQueryRead>();
builder.Services.AddTransient<IQuery.Write.ISemaforoQueryWrite, Query.Write.SemaforoQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertSemaforoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateSemaforoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteSemaforoReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.SemaforoReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.SemaforoReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.SemaforoReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ISubOcorrenciaWriteRepository, Input.Repository.SubOcorrencia.SubOcorrenciaWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ISubOcorrenciaReadRepository, Read.Repository.SubOcorrenciaReadRepository>();
builder.Services.AddTransient<IQuery.Read.ISubOcorrenciaQueryRead, Query.Read.SubOcorrenciaQueryRead>();
builder.Services.AddTransient<IQuery.Write.ISubOcorrenciaQueryWrite, Query.Write.SubOcorrenciaQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertSubOcorrenciaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateSubOcorrenciaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteSubOcorrenciaReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.SubOcorrenciaReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.SubOcorrenciaReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.SubOcorrenciaReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ITabelaWriteRepository, Input.Repository.Tabela.TabelaWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ITabelaReadRepository, Read.Repository.TabelaReadRepository>();
builder.Services.AddTransient<IQuery.Read.ITabelaQueryRead, Query.Read.TabelaQueryRead>();
builder.Services.AddTransient<IQuery.Write.ITabelaQueryWrite, Query.Write.TabelaQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertTabelaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateTabelaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteTabelaReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TabelaReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TabelaReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TabelaReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ITargetProdutoWriteRepository, Input.Repository.TargetProduto.TargetProdutoWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ITargetProdutoReadRepository, Read.Repository.TargetProdutoReadRepository>();
builder.Services.AddTransient<IQuery.Read.ITargetProdutoQueryRead, Query.Read.TargetProdutoQueryRead>();
builder.Services.AddTransient<IQuery.Write.ITargetProdutoQueryWrite, Query.Write.TargetProdutoQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertTargetProdutoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateTargetProdutoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteTargetProdutoReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TargetProdutoReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TargetProdutoReadFKMOV_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TargetProdutoReadFKORD_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TargetProdutoReadFKUNI_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TargetProdutoReadFKTURM_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TargetProdutoReadFKTURN_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TargetProdutoReadFKUSE_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TargetProdutoReadFKOCO_ID_PERFORMANCEReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TargetProdutoReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TargetProdutoReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ITemplatesGrupoMaquinaWriteRepository, Input.Repository.TemplatesGrupoMaquina.TemplatesGrupoMaquinaWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ITemplatesGrupoMaquinaReadRepository, Read.Repository.TemplatesGrupoMaquinaReadRepository>();
builder.Services.AddTransient<IQuery.Read.ITemplatesGrupoMaquinaQueryRead, Query.Read.TemplatesGrupoMaquinaQueryRead>();
builder.Services.AddTransient<IQuery.Write.ITemplatesGrupoMaquinaQueryWrite, Query.Write.TemplatesGrupoMaquinaQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertTemplatesGrupoMaquinaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateTemplatesGrupoMaquinaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteTemplatesGrupoMaquinaReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TemplatesGrupoMaquinaReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TemplatesGrupoMaquinaReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TemplatesGrupoMaquinaReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ITemplatesMaquinasWriteRepository, Input.Repository.TemplatesMaquinas.TemplatesMaquinasWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ITemplatesMaquinasReadRepository, Read.Repository.TemplatesMaquinasReadRepository>();
builder.Services.AddTransient<IQuery.Read.ITemplatesMaquinasQueryRead, Query.Read.TemplatesMaquinasQueryRead>();
builder.Services.AddTransient<IQuery.Write.ITemplatesMaquinasQueryWrite, Query.Write.TemplatesMaquinasQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertTemplatesMaquinasReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateTemplatesMaquinasReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteTemplatesMaquinasReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TemplatesMaquinasReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TemplatesMaquinasReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TemplatesMaquinasReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ITempoSetupOnduladeiraWriteRepository, Input.Repository.TempoSetupOnduladeira.TempoSetupOnduladeiraWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ITempoSetupOnduladeiraReadRepository, Read.Repository.TempoSetupOnduladeiraReadRepository>();
builder.Services.AddTransient<IQuery.Read.ITempoSetupOnduladeiraQueryRead, Query.Read.TempoSetupOnduladeiraQueryRead>();
builder.Services.AddTransient<IQuery.Write.ITempoSetupOnduladeiraQueryWrite, Query.Write.TempoSetupOnduladeiraQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertTempoSetupOnduladeiraReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateTempoSetupOnduladeiraReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteTempoSetupOnduladeiraReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TempoSetupOnduladeiraReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TempoSetupOnduladeiraReadFKOND_ID_DEReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TempoSetupOnduladeiraReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TempoSetupOnduladeiraReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ITemposLogisticosWriteRepository, Input.Repository.TemposLogisticos.TemposLogisticosWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ITemposLogisticosReadRepository, Read.Repository.TemposLogisticosReadRepository>();
builder.Services.AddTransient<IQuery.Read.ITemposLogisticosQueryRead, Query.Read.TemposLogisticosQueryRead>();
builder.Services.AddTransient<IQuery.Write.ITemposLogisticosQueryWrite, Query.Write.TemposLogisticosQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertTemposLogisticosReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateTemposLogisticosReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteTemposLogisticosReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TemposLogisticosReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TemposLogisticosReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TemposLogisticosReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ITesteFisicoWriteRepository, Input.Repository.TesteFisico.TesteFisicoWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ITesteFisicoReadRepository, Read.Repository.TesteFisicoReadRepository>();
builder.Services.AddTransient<IQuery.Read.ITesteFisicoQueryRead, Query.Read.TesteFisicoQueryRead>();
builder.Services.AddTransient<IQuery.Write.ITesteFisicoQueryWrite, Query.Write.TesteFisicoQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertTesteFisicoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateTesteFisicoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteTesteFisicoReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TesteFisicoReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TesteFisicoReadFKUSR_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TesteFisicoReadFKORD_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TesteFisicoReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TesteFisicoReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ITipoABNTWriteRepository, Input.Repository.TipoABNT.TipoABNTWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ITipoABNTReadRepository, Read.Repository.TipoABNTReadRepository>();
builder.Services.AddTransient<IQuery.Read.ITipoABNTQueryRead, Query.Read.TipoABNTQueryRead>();
builder.Services.AddTransient<IQuery.Write.ITipoABNTQueryWrite, Query.Write.TipoABNTQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertTipoABNTReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateTipoABNTReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteTipoABNTReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TipoABNTReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TipoABNTReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TipoABNTReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ITipoCarroceriaWriteRepository, Input.Repository.TipoCarroceria.TipoCarroceriaWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ITipoCarroceriaReadRepository, Read.Repository.TipoCarroceriaReadRepository>();
builder.Services.AddTransient<IQuery.Read.ITipoCarroceriaQueryRead, Query.Read.TipoCarroceriaQueryRead>();
builder.Services.AddTransient<IQuery.Write.ITipoCarroceriaQueryWrite, Query.Write.TipoCarroceriaQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertTipoCarroceriaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateTipoCarroceriaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteTipoCarroceriaReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TipoCarroceriaReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TipoCarroceriaReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TipoCarroceriaReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ITipoDispositivoWriteRepository, Input.Repository.TipoDispositivo.TipoDispositivoWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ITipoDispositivoReadRepository, Read.Repository.TipoDispositivoReadRepository>();
builder.Services.AddTransient<IQuery.Read.ITipoDispositivoQueryRead, Query.Read.TipoDispositivoQueryRead>();
builder.Services.AddTransient<IQuery.Write.ITipoDispositivoQueryWrite, Query.Write.TipoDispositivoQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertTipoDispositivoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateTipoDispositivoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteTipoDispositivoReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TipoDispositivoReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TipoDispositivoReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TipoDispositivoReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ITipoDispositivoMaquinaWriteRepository, Input.Repository.TipoDispositivoMaquina.TipoDispositivoMaquinaWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ITipoDispositivoMaquinaReadRepository, Read.Repository.TipoDispositivoMaquinaReadRepository>();
builder.Services.AddTransient<IQuery.Read.ITipoDispositivoMaquinaQueryRead, Query.Read.TipoDispositivoMaquinaQueryRead>();
builder.Services.AddTransient<IQuery.Write.ITipoDispositivoMaquinaQueryWrite, Query.Write.TipoDispositivoMaquinaQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertTipoDispositivoMaquinaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateTipoDispositivoMaquinaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteTipoDispositivoMaquinaReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TipoDispositivoMaquinaReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TipoDispositivoMaquinaReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TipoDispositivoMaquinaReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ITipoInspecaoItensWriteRepository, Input.Repository.TipoInspecaoItens.TipoInspecaoItensWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ITipoInspecaoItensReadRepository, Read.Repository.TipoInspecaoItensReadRepository>();
builder.Services.AddTransient<IQuery.Read.ITipoInspecaoItensQueryRead, Query.Read.TipoInspecaoItensQueryRead>();
builder.Services.AddTransient<IQuery.Write.ITipoInspecaoItensQueryWrite, Query.Write.TipoInspecaoItensQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertTipoInspecaoItensReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateTipoInspecaoItensReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteTipoInspecaoItensReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TipoInspecaoItensReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TipoInspecaoItensReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TipoInspecaoItensReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ITipoInspecaoVisualWriteRepository, Input.Repository.TipoInspecaoVisual.TipoInspecaoVisualWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ITipoInspecaoVisualReadRepository, Read.Repository.TipoInspecaoVisualReadRepository>();
builder.Services.AddTransient<IQuery.Read.ITipoInspecaoVisualQueryRead, Query.Read.TipoInspecaoVisualQueryRead>();
builder.Services.AddTransient<IQuery.Write.ITipoInspecaoVisualQueryWrite, Query.Write.TipoInspecaoVisualQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertTipoInspecaoVisualReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateTipoInspecaoVisualReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteTipoInspecaoVisualReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TipoInspecaoVisualReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TipoInspecaoVisualReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TipoInspecaoVisualReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ITipoMovimentoEstoqueWriteRepository, Input.Repository.TipoMovimentoEstoque.TipoMovimentoEstoqueWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ITipoMovimentoEstoqueReadRepository, Read.Repository.TipoMovimentoEstoqueReadRepository>();
builder.Services.AddTransient<IQuery.Read.ITipoMovimentoEstoqueQueryRead, Query.Read.TipoMovimentoEstoqueQueryRead>();
builder.Services.AddTransient<IQuery.Write.ITipoMovimentoEstoqueQueryWrite, Query.Write.TipoMovimentoEstoqueQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertTipoMovimentoEstoqueReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateTipoMovimentoEstoqueReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteTipoMovimentoEstoqueReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TipoMovimentoEstoqueReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TipoMovimentoEstoqueReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TipoMovimentoEstoqueReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ITipoOcorrenciaWriteRepository, Input.Repository.TipoOcorrencia.TipoOcorrenciaWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ITipoOcorrenciaReadRepository, Read.Repository.TipoOcorrenciaReadRepository>();
builder.Services.AddTransient<IQuery.Read.ITipoOcorrenciaQueryRead, Query.Read.TipoOcorrenciaQueryRead>();
builder.Services.AddTransient<IQuery.Write.ITipoOcorrenciaQueryWrite, Query.Write.TipoOcorrenciaQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertTipoOcorrenciaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateTipoOcorrenciaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteTipoOcorrenciaReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TipoOcorrenciaReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TipoOcorrenciaReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TipoOcorrenciaReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ITipoTesteWriteRepository, Input.Repository.TipoTeste.TipoTesteWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ITipoTesteReadRepository, Read.Repository.TipoTesteReadRepository>();
builder.Services.AddTransient<IQuery.Read.ITipoTesteQueryRead, Query.Read.TipoTesteQueryRead>();
builder.Services.AddTransient<IQuery.Write.ITipoTesteQueryWrite, Query.Write.TipoTesteQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertTipoTesteReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateTipoTesteReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteTipoTesteReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TipoTesteReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TipoTesteReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TipoTesteReadFKUserIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TipoTesteReadFKTA_IDReceiver>();

builder.Services.AddTransient<IRepository.Write.ITipoVeiculoWriteRepository, Input.Repository.TipoVeiculo.TipoVeiculoWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ITipoVeiculoReadRepository, Read.Repository.TipoVeiculoReadRepository>();
builder.Services.AddTransient<IQuery.Read.ITipoVeiculoQueryRead, Query.Read.TipoVeiculoQueryRead>();
builder.Services.AddTransient<IQuery.Write.ITipoVeiculoQueryWrite, Query.Write.TipoVeiculoQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertTipoVeiculoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateTipoVeiculoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteTipoVeiculoReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TipoVeiculoReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TipoVeiculoReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TipoVeiculoReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IVincoWriteRepository, Input.Repository.Vinco.VincoWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IVincoReadRepository, Read.Repository.VincoReadRepository>();
builder.Services.AddTransient<IQuery.Read.IVincoQueryRead, Query.Read.VincoQueryRead>();
builder.Services.AddTransient<IQuery.Write.IVincoQueryWrite, Query.Write.VincoQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertVincoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateVincoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteVincoReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.VincoReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.VincoReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.VincoReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ITiposVincoGruposProdutosWriteRepository, Input.Repository.TiposVincoGruposProdutos.TiposVincoGruposProdutosWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ITiposVincoGruposProdutosReadRepository, Read.Repository.TiposVincoGruposProdutosReadRepository>();
builder.Services.AddTransient<IQuery.Read.ITiposVincoGruposProdutosQueryRead, Query.Read.TiposVincoGruposProdutosQueryRead>();
builder.Services.AddTransient<IQuery.Write.ITiposVincoGruposProdutosQueryWrite, Query.Write.TiposVincoGruposProdutosQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertTiposVincoGruposProdutosReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateTiposVincoGruposProdutosReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteTiposVincoGruposProdutosReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TiposVincoGruposProdutosReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TiposVincoGruposProdutosReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TiposVincoGruposProdutosReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ITiposVincoOndasWriteRepository, Input.Repository.TiposVincoOndas.TiposVincoOndasWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ITiposVincoOndasReadRepository, Read.Repository.TiposVincoOndasReadRepository>();
builder.Services.AddTransient<IQuery.Read.ITiposVincoOndasQueryRead, Query.Read.TiposVincoOndasQueryRead>();
builder.Services.AddTransient<IQuery.Write.ITiposVincoOndasQueryWrite, Query.Write.TiposVincoOndasQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertTiposVincoOndasReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateTiposVincoOndasReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteTiposVincoOndasReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TiposVincoOndasReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TiposVincoOndasReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TiposVincoOndasReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ITiposVincoProdutosWriteRepository, Input.Repository.TiposVincoProdutos.TiposVincoProdutosWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ITiposVincoProdutosReadRepository, Read.Repository.TiposVincoProdutosReadRepository>();
builder.Services.AddTransient<IQuery.Read.ITiposVincoProdutosQueryRead, Query.Read.TiposVincoProdutosQueryRead>();
builder.Services.AddTransient<IQuery.Write.ITiposVincoProdutosQueryWrite, Query.Write.TiposVincoProdutosQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertTiposVincoProdutosReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateTiposVincoProdutosReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteTiposVincoProdutosReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TiposVincoProdutosReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TiposVincoProdutosReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TiposVincoProdutosReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ITransportadoraWriteRepository, Input.Repository.Transportadora.TransportadoraWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ITransportadoraReadRepository, Read.Repository.TransportadoraReadRepository>();
builder.Services.AddTransient<IQuery.Read.ITransportadoraQueryRead, Query.Read.TransportadoraQueryRead>();
builder.Services.AddTransient<IQuery.Write.ITransportadoraQueryWrite, Query.Write.TransportadoraQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertTransportadoraReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateTransportadoraReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteTransportadoraReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TransportadoraReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TransportadoraReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TransportadoraReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ITurmaWriteRepository, Input.Repository.Turma.TurmaWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ITurmaReadRepository, Read.Repository.TurmaReadRepository>();
builder.Services.AddTransient<IQuery.Read.ITurmaQueryRead, Query.Read.TurmaQueryRead>();
builder.Services.AddTransient<IQuery.Write.ITurmaQueryWrite, Query.Write.TurmaQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertTurmaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateTurmaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteTurmaReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TurmaReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TurmaReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TurmaReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ITurnoWriteRepository, Input.Repository.Turno.TurnoWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ITurnoReadRepository, Read.Repository.TurnoReadRepository>();
builder.Services.AddTransient<IQuery.Read.ITurnoQueryRead, Query.Read.TurnoQueryRead>();
builder.Services.AddTransient<IQuery.Write.ITurnoQueryWrite, Query.Write.TurnoQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertTurnoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateTurnoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteTurnoReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TurnoReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TurnoReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TurnoReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IUnidadeWriteRepository, Input.Repository.Unidade.UnidadeWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IUnidadeReadRepository, Read.Repository.UnidadeReadRepository>();
builder.Services.AddTransient<IQuery.Read.IUnidadeQueryRead, Query.Read.UnidadeQueryRead>();
builder.Services.AddTransient<IQuery.Write.IUnidadeQueryWrite, Query.Write.UnidadeQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertUnidadeReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateUnidadeReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteUnidadeReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.UnidadeReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.UnidadeReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.UnidadeReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IUnidadeMedidaWriteRepository, Input.Repository.UnidadeMedida.UnidadeMedidaWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IUnidadeMedidaReadRepository, Read.Repository.UnidadeMedidaReadRepository>();
builder.Services.AddTransient<IQuery.Read.IUnidadeMedidaQueryRead, Query.Read.UnidadeMedidaQueryRead>();
builder.Services.AddTransient<IQuery.Write.IUnidadeMedidaQueryWrite, Query.Write.UnidadeMedidaQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertUnidadeMedidaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateUnidadeMedidaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteUnidadeMedidaReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.UnidadeMedidaReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.UnidadeMedidaReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.UnidadeMedidaReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IUniuserWriteRepository, Input.Repository.Uniuser.UniuserWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IUniuserReadRepository, Read.Repository.UniuserReadRepository>();
builder.Services.AddTransient<IQuery.Read.IUniuserQueryRead, Query.Read.UniuserQueryRead>();
builder.Services.AddTransient<IQuery.Write.IUniuserQueryWrite, Query.Write.UniuserQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertUniuserReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateUniuserReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteUniuserReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.UniuserReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.UniuserReadFKUNI_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.UniuserReadFKUSE_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.UniuserReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.UniuserReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IT_USER_GRUPOWriteRepository, Input.Repository.T_USER_GRUPO.T_USER_GRUPOWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IT_USER_GRUPOReadRepository, Read.Repository.T_USER_GRUPOReadRepository>();
builder.Services.AddTransient<IQuery.Read.IT_USER_GRUPOQueryRead, Query.Read.T_USER_GRUPOQueryRead>();
builder.Services.AddTransient<IQuery.Write.IT_USER_GRUPOQueryWrite, Query.Write.T_USER_GRUPOQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertT_USER_GRUPOReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateT_USER_GRUPOReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteT_USER_GRUPOReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.T_USER_GRUPOReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.T_USER_GRUPOReadFKGRU_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.T_USER_GRUPOReadFKID_USUARIOReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.T_USER_GRUPOReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.T_USER_GRUPOReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IUsuarioWriteRepository, Input.Repository.Usuario.UsuarioWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IUsuarioReadRepository, Read.Repository.UsuarioReadRepository>();
builder.Services.AddTransient<IQuery.Read.IUsuarioQueryRead, Query.Read.UsuarioQueryRead>();
builder.Services.AddTransient<IQuery.Write.IUsuarioQueryWrite, Query.Write.UsuarioQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertUsuarioReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateUsuarioReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteUsuarioReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.UsuarioReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.UsuarioReadFKTURM_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.UsuarioReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.UsuarioReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IUsuarioObjetoControlavelWriteRepository, Input.Repository.UsuarioObjetoControlavel.UsuarioObjetoControlavelWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IUsuarioObjetoControlavelReadRepository, Read.Repository.UsuarioObjetoControlavelReadRepository>();
builder.Services.AddTransient<IQuery.Read.IUsuarioObjetoControlavelQueryRead, Query.Read.UsuarioObjetoControlavelQueryRead>();
builder.Services.AddTransient<IQuery.Write.IUsuarioObjetoControlavelQueryWrite, Query.Write.UsuarioObjetoControlavelQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertUsuarioObjetoControlavelReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateUsuarioObjetoControlavelReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteUsuarioObjetoControlavelReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.UsuarioObjetoControlavelReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.UsuarioObjetoControlavelReadFKUSE_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.UsuarioObjetoControlavelReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.UsuarioObjetoControlavelReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IUsuarioPerfilWriteRepository, Input.Repository.UsuarioPerfil.UsuarioPerfilWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IUsuarioPerfilReadRepository, Read.Repository.UsuarioPerfilReadRepository>();
builder.Services.AddTransient<IQuery.Read.IUsuarioPerfilQueryRead, Query.Read.UsuarioPerfilQueryRead>();
builder.Services.AddTransient<IQuery.Write.IUsuarioPerfilQueryWrite, Query.Write.UsuarioPerfilQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertUsuarioPerfilReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateUsuarioPerfilReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteUsuarioPerfilReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.UsuarioPerfilReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.UsuarioPerfilReadFKUSE_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.UsuarioPerfilReadFKPER_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.UsuarioPerfilReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.UsuarioPerfilReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IUsuariosCargaWriteRepository, Input.Repository.UsuariosCarga.UsuariosCargaWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IUsuariosCargaReadRepository, Read.Repository.UsuariosCargaReadRepository>();
builder.Services.AddTransient<IQuery.Read.IUsuariosCargaQueryRead, Query.Read.UsuariosCargaQueryRead>();
builder.Services.AddTransient<IQuery.Write.IUsuariosCargaQueryWrite, Query.Write.UsuariosCargaQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertUsuariosCargaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateUsuariosCargaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteUsuariosCargaReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.UsuariosCargaReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.UsuariosCargaReadFKUSE_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.UsuariosCargaReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.UsuariosCargaReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IVariavelWriteRepository, Input.Repository.Variavel.VariavelWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IVariavelReadRepository, Read.Repository.VariavelReadRepository>();
builder.Services.AddTransient<IQuery.Read.IVariavelQueryRead, Query.Read.VariavelQueryRead>();
builder.Services.AddTransient<IQuery.Write.IVariavelQueryWrite, Query.Write.VariavelQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertVariavelReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateVariavelReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteVariavelReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.VariavelReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.VariavelReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.VariavelReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IVariavelPlotagemWriteRepository, Input.Repository.VariavelPlotagem.VariavelPlotagemWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IVariavelPlotagemReadRepository, Read.Repository.VariavelPlotagemReadRepository>();
builder.Services.AddTransient<IQuery.Read.IVariavelPlotagemQueryRead, Query.Read.VariavelPlotagemQueryRead>();
builder.Services.AddTransient<IQuery.Write.IVariavelPlotagemQueryWrite, Query.Write.VariavelPlotagemQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertVariavelPlotagemReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateVariavelPlotagemReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteVariavelPlotagemReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.VariavelPlotagemReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.VariavelPlotagemReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.VariavelPlotagemReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IVeiculoWriteRepository, Input.Repository.Veiculo.VeiculoWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IVeiculoReadRepository, Read.Repository.VeiculoReadRepository>();
builder.Services.AddTransient<IQuery.Read.IVeiculoQueryRead, Query.Read.VeiculoQueryRead>();
builder.Services.AddTransient<IQuery.Write.IVeiculoQueryWrite, Query.Write.VeiculoQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertVeiculoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateVeiculoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteVeiculoReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.VeiculoReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.VeiculoReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.VeiculoReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IVersaoCustoWriteRepository, Input.Repository.VersaoCusto.VersaoCustoWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IVersaoCustoReadRepository, Read.Repository.VersaoCustoReadRepository>();
builder.Services.AddTransient<IQuery.Read.IVersaoCustoQueryRead, Query.Read.VersaoCustoQueryRead>();
builder.Services.AddTransient<IQuery.Write.IVersaoCustoQueryWrite, Query.Write.VersaoCustoQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertVersaoCustoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateVersaoCustoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteVersaoCustoReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.VersaoCustoReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.VersaoCustoReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.VersaoCustoReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IVerssaoCustoWriteRepository, Input.Repository.VerssaoCusto.VerssaoCustoWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IVerssaoCustoReadRepository, Read.Repository.VerssaoCustoReadRepository>();
builder.Services.AddTransient<IQuery.Read.IVerssaoCustoQueryRead, Query.Read.VerssaoCustoQueryRead>();
builder.Services.AddTransient<IQuery.Write.IVerssaoCustoQueryWrite, Query.Write.VerssaoCustoQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertVerssaoCustoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateVerssaoCustoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteVerssaoCustoReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.VerssaoCustoReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.VerssaoCustoReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.VerssaoCustoReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ICabvisaoWriteRepository, Input.Repository.Cabvisao.CabvisaoWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ICabvisaoReadRepository, Read.Repository.CabvisaoReadRepository>();
builder.Services.AddTransient<IQuery.Read.ICabvisaoQueryRead, Query.Read.CabvisaoQueryRead>();
builder.Services.AddTransient<IQuery.Write.ICabvisaoQueryWrite, Query.Write.CabvisaoQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertCabvisaoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateCabvisaoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteCabvisaoReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CabvisaoReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CabvisaoReadFKUSE_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CabvisaoReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CabvisaoReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IMovimentosWriteRepository, Input.Repository.Movimentos.MovimentosWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IMovimentosReadRepository, Read.Repository.MovimentosReadRepository>();
builder.Services.AddTransient<IQuery.Read.IMovimentosQueryRead, Query.Read.MovimentosQueryRead>();
builder.Services.AddTransient<IQuery.Write.IMovimentosQueryWrite, Query.Write.MovimentosQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertMovimentosReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateMovimentosReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteMovimentosReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MovimentosReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MovimentosReadFKMOV_PLAIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MovimentosReadFKTr_Unidade_UNI_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MovimentosReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MovimentosReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IPlanocontasWriteRepository, Input.Repository.Planocontas.PlanocontasWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IPlanocontasReadRepository, Read.Repository.PlanocontasReadRepository>();
builder.Services.AddTransient<IQuery.Read.IPlanocontasQueryRead, Query.Read.PlanocontasQueryRead>();
builder.Services.AddTransient<IQuery.Write.IPlanocontasQueryWrite, Query.Write.PlanocontasQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertPlanocontasReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdatePlanocontasReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeletePlanocontasReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.PlanocontasReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.PlanocontasReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.PlanocontasReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IUnidade_UnidadeWriteRepository, Input.Repository.Unidade_Unidade.Unidade_UnidadeWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IUnidade_UnidadeReadRepository, Read.Repository.Unidade_UnidadeReadRepository>();
builder.Services.AddTransient<IQuery.Read.IUnidade_UnidadeQueryRead, Query.Read.Unidade_UnidadeQueryRead>();
builder.Services.AddTransient<IQuery.Write.IUnidade_UnidadeQueryWrite, Query.Write.Unidade_UnidadeQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertUnidade_UnidadeReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateUnidade_UnidadeReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteUnidade_UnidadeReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.Unidade_UnidadeReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.Unidade_UnidadeReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.Unidade_UnidadeReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IVisoesWriteRepository, Input.Repository.Visoes.VisoesWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IVisoesReadRepository, Read.Repository.VisoesReadRepository>();
builder.Services.AddTransient<IQuery.Read.IVisoesQueryRead, Query.Read.VisoesQueryRead>();
builder.Services.AddTransient<IQuery.Write.IVisoesQueryWrite, Query.Write.VisoesQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertVisoesReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateVisoesReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteVisoesReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.VisoesReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.VisoesReadFKVIS_PLANIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.VisoesReadFKCAB_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.VisoesReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.VisoesReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IRelatoriosWriteRepository, Input.Repository.Relatorios.RelatoriosWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IRelatoriosReadRepository, Read.Repository.RelatoriosReadRepository>();
builder.Services.AddTransient<IQuery.Read.IRelatoriosQueryRead, Query.Read.RelatoriosQueryRead>();
builder.Services.AddTransient<IQuery.Write.IRelatoriosQueryWrite, Query.Write.RelatoriosQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertRelatoriosReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateRelatoriosReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteRelatoriosReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.RelatoriosReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.RelatoriosReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.RelatoriosReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IInspecaoVisualWriteRepository, Input.Repository.InspecaoVisual.InspecaoVisualWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IInspecaoVisualReadRepository, Read.Repository.InspecaoVisualReadRepository>();
builder.Services.AddTransient<IQuery.Read.IInspecaoVisualQueryRead, Query.Read.InspecaoVisualQueryRead>();
builder.Services.AddTransient<IQuery.Write.IInspecaoVisualQueryWrite, Query.Write.InspecaoVisualQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertInspecaoVisualReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateInspecaoVisualReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteInspecaoVisualReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.InspecaoVisualReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.InspecaoVisualReadFKTURN_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.InspecaoVisualReadFKTURM_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.InspecaoVisualReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.InspecaoVisualReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ITemplateTipoInspecaoVisualWriteRepository, Input.Repository.TemplateTipoInspecaoVisual.TemplateTipoInspecaoVisualWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ITemplateTipoInspecaoVisualReadRepository, Read.Repository.TemplateTipoInspecaoVisualReadRepository>();
builder.Services.AddTransient<IQuery.Read.ITemplateTipoInspecaoVisualQueryRead, Query.Read.TemplateTipoInspecaoVisualQueryRead>();
builder.Services.AddTransient<IQuery.Write.ITemplateTipoInspecaoVisualQueryWrite, Query.Write.TemplateTipoInspecaoVisualQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertTemplateTipoInspecaoVisualReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateTemplateTipoInspecaoVisualReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteTemplateTipoInspecaoVisualReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TemplateTipoInspecaoVisualReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TemplateTipoInspecaoVisualReadFKTEM_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TemplateTipoInspecaoVisualReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TemplateTipoInspecaoVisualReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ITemplateTipoTesteWriteRepository, Input.Repository.TemplateTipoTeste.TemplateTipoTesteWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ITemplateTipoTesteReadRepository, Read.Repository.TemplateTipoTesteReadRepository>();
builder.Services.AddTransient<IQuery.Read.ITemplateTipoTesteQueryRead, Query.Read.TemplateTipoTesteQueryRead>();
builder.Services.AddTransient<IQuery.Write.ITemplateTipoTesteQueryWrite, Query.Write.TemplateTipoTesteQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertTemplateTipoTesteReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateTemplateTipoTesteReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteTemplateTipoTesteReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TemplateTipoTesteReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TemplateTipoTesteReadFKTT_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TemplateTipoTesteReadFKTEM_IDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TemplateTipoTesteReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TemplateTipoTesteReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ITipoAvaliacaoWriteRepository, Input.Repository.TipoAvaliacao.TipoAvaliacaoWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ITipoAvaliacaoReadRepository, Read.Repository.TipoAvaliacaoReadRepository>();
builder.Services.AddTransient<IQuery.Read.ITipoAvaliacaoQueryRead, Query.Read.TipoAvaliacaoQueryRead>();
builder.Services.AddTransient<IQuery.Write.ITipoAvaliacaoQueryWrite, Query.Write.TipoAvaliacaoQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertTipoAvaliacaoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateTipoAvaliacaoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteTipoAvaliacaoReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TipoAvaliacaoReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TipoAvaliacaoReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.TipoAvaliacaoReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IPedidoPlanejavelWriteRepository, Input.Repository.PedidoPlanejavel.PedidoPlanejavelWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IPedidoPlanejavelReadRepository, Read.Repository.PedidoPlanejavelReadRepository>();
builder.Services.AddTransient<IQuery.Read.IPedidoPlanejavelQueryRead, Query.Read.PedidoPlanejavelQueryRead>();
builder.Services.AddTransient<IQuery.Write.IPedidoPlanejavelQueryWrite, Query.Write.PedidoPlanejavelQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertPedidoPlanejavelReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdatePedidoPlanejavelReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeletePedidoPlanejavelReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.PedidoPlanejavelReadReceiver>();

builder.Services.AddTransient<IRepository.Write.ICargaPlanejavelWriteRepository, Input.Repository.CargaPlanejavel.CargaPlanejavelWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ICargaPlanejavelReadRepository, Read.Repository.CargaPlanejavelReadRepository>();
builder.Services.AddTransient<IQuery.Read.ICargaPlanejavelQueryRead, Query.Read.CargaPlanejavelQueryRead>();
builder.Services.AddTransient<IQuery.Write.ICargaPlanejavelQueryWrite, Query.Write.CargaPlanejavelQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertCargaPlanejavelReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateCargaPlanejavelReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteCargaPlanejavelReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CargaPlanejavelReadReceiver>();

builder.Services.AddTransient<IRepository.Write.IOpcaoPlanejamentoTransporteWriteRepository, Input.Repository.OpcaoPlanejamentoTransporte.OpcaoPlanejamentoTransporteWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IOpcaoPlanejamentoTransporteReadRepository, Read.Repository.OpcaoPlanejamentoTransporteReadRepository>();
builder.Services.AddTransient<IQuery.Read.IOpcaoPlanejamentoTransporteQueryRead, Query.Read.OpcaoPlanejamentoTransporteQueryRead>();
builder.Services.AddTransient<IQuery.Write.IOpcaoPlanejamentoTransporteQueryWrite, Query.Write.OpcaoPlanejamentoTransporteQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertOpcaoPlanejamentoTransporteReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateOpcaoPlanejamentoTransporteReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteOpcaoPlanejamentoTransporteReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.OpcaoPlanejamentoTransporteReadReceiver>();

builder.Services.AddTransient<IRepository.Write.ICenarioPlanejamentoTransporteWriteRepository, Input.Repository.CenarioPlanejamentoTransporte.CenarioPlanejamentoTransporteWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ICenarioPlanejamentoTransporteReadRepository, Read.Repository.CenarioPlanejamentoTransporteReadRepository>();
builder.Services.AddTransient<IQuery.Read.ICenarioPlanejamentoTransporteQueryRead, Query.Read.CenarioPlanejamentoTransporteQueryRead>();
builder.Services.AddTransient<IQuery.Write.ICenarioPlanejamentoTransporteQueryWrite, Query.Write.CenarioPlanejamentoTransporteQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertCenarioPlanejamentoTransporteReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateCenarioPlanejamentoTransporteReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteCenarioPlanejamentoTransporteReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CenarioPlanejamentoTransporteReadReceiver>();

builder.Services.AddTransient<IRepository.Write.IExperienciaPlanejamentoTransporteWriteRepository, Input.Repository.ExperienciaPlanejamentoTransporte.ExperienciaPlanejamentoTransporteWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IExperienciaPlanejamentoTransporteReadRepository, Read.Repository.ExperienciaPlanejamentoTransporteReadRepository>();
builder.Services.AddTransient<IQuery.Read.IExperienciaPlanejamentoTransporteQueryRead, Query.Read.ExperienciaPlanejamentoTransporteQueryRead>();
builder.Services.AddTransient<IQuery.Write.IExperienciaPlanejamentoTransporteQueryWrite, Query.Write.ExperienciaPlanejamentoTransporteQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertExperienciaPlanejamentoTransporteReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateExperienciaPlanejamentoTransporteReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteExperienciaPlanejamentoTransporteReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ExperienciaPlanejamentoTransporteReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ExperienciaPlanejamentoTransporteReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ExperienciaPlanejamentoTransporteReadFKUserIdReceiver>();

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
builder.Services.AddTransient<Dominio.Saga.CargaStandardSaga>();
builder.Services.AddTransient<Command.Receivers.CargaStandardSagaHandlerResolver>();
builder.Services.AddTransient<DefinirDadosTransporteHandler>();
builder.Services.AddTransient<EnviarNotasFiscaisHandler>();
builder.Services.AddTransient<GerarCTeHandler>();
builder.Services.AddTransient<GerarMDFeHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.BuscarContextoPlanejamentoTransporteHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.ListarLentesPlanejamentoTransporteHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.AbrirNoLentePlanejamentoTransporteHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.RevalidarSelecaoPlanejamentoTransporteHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.CriarCargaDaSelecaoPlanejamentoTransporteHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.ListarCargasAbertasPlanejamentoTransporteHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.RemoverPedidoDaCargaPlanejamentoTransporteHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.TrocarPedidoEntreCargasPlanejamentoTransporteHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.UnirCargasPlanejamentoTransporteHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.DividirCargaPlanejamentoTransporteHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.GerarGruposDecisaoPlanejamentoTransporteHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.AceitarOpcaoPlanejamentoTransporteHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.DescartarOpcaoPlanejamentoTransporteHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.GerarCenariosPlanejamentoTransporteHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.AplicarCenarioPlanejamentoTransporteHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.CatalogarExperienciaPlanejamentoTransporteHandler>();

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
        new Command.Interfaces.Patterns.Queue.ExchangeDefinition
        {
            Name = "apsadm.carga",
            Type = "topic",
            Bindings = new List<Command.Interfaces.Patterns.Queue.QueueBindingDefinition>
            {
                new Command.Interfaces.Patterns.Queue.QueueBindingDefinition
                {
                    QueueName = "carga.notas-fiscais.outbox",
                    RoutingKey = "carga.notas-fiscais.enviar"
                },
                new Command.Interfaces.Patterns.Queue.QueueBindingDefinition
                {
                    QueueName = "carga.notas-fiscais.inbox",
                    RoutingKey = "carga.notas-fiscais.enviadas"
                },
            }
        },
        new Command.Interfaces.Patterns.Queue.ExchangeDefinition
        {
            Name = "fiscal.cte",
            Type = "topic",
            Bindings = new List<Command.Interfaces.Patterns.Queue.QueueBindingDefinition>
            {
                new Command.Interfaces.Patterns.Queue.QueueBindingDefinition
                {
                    QueueName = "cte.emitir.outbox",
                    RoutingKey = "cte.emitir.solicitar"
                },
                new Command.Interfaces.Patterns.Queue.QueueBindingDefinition
                {
                    QueueName = "cte.emitir.inbox",
                    RoutingKey = "cte.emitir.autorizado"
                },
            }
        },
        new Command.Interfaces.Patterns.Queue.ExchangeDefinition
        {
            Name = "fiscal.mdfe",
            Type = "topic",
            Bindings = new List<Command.Interfaces.Patterns.Queue.QueueBindingDefinition>
            {
                new Command.Interfaces.Patterns.Queue.QueueBindingDefinition
                {
                    QueueName = "mdfe.emitir.outbox",
                    RoutingKey = "mdfe.emitir.solicitar"
                },
                new Command.Interfaces.Patterns.Queue.QueueBindingDefinition
                {
                    QueueName = "mdfe.emitir.inbox",
                    RoutingKey = "mdfe.emitir.autorizado"
                },
            }
        },
    }
};
}
}
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureDependencInjectionInjectionMigration