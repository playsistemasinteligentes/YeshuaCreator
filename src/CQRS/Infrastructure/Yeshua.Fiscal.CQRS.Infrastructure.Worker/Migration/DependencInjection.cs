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
                    builder.Services.AddTransient<ISagaStepInvoker, SagaStepInvoker>();
                    builder.Services.AddTransient<SagaResolverRegistry>();
                    builder.Services.AddTransient<ISagaResolverRegistry, SagaResolverRegistry>();
                    builder.Services.AddTransient<ISagaStepContinuation, SagaStepContinuation>();
                    builder.Services.AddScoped<OutboxService>();


builder.Services.AddTransient<IRepository.Write.IDocumentoFiscalWriteRepository, Input.Repository.DocumentoFiscal.DocumentoFiscalWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IDocumentoFiscalReadRepository, Read.Repository.DocumentoFiscalReadRepository>();
builder.Services.AddTransient<IQuery.Read.IDocumentoFiscalQueryRead, Query.Read.DocumentoFiscalQueryRead>();
builder.Services.AddTransient<IQuery.Write.IDocumentoFiscalQueryWrite, Query.Write.DocumentoFiscalQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertDocumentoFiscalReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateDocumentoFiscalReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteDocumentoFiscalReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.DocumentoFiscalReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.DocumentoFiscalReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.DocumentoFiscalReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IDocumentoFiscalOriginarioWriteRepository, Input.Repository.DocumentoFiscalOriginario.DocumentoFiscalOriginarioWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IDocumentoFiscalOriginarioReadRepository, Read.Repository.DocumentoFiscalOriginarioReadRepository>();
builder.Services.AddTransient<IQuery.Read.IDocumentoFiscalOriginarioQueryRead, Query.Read.DocumentoFiscalOriginarioQueryRead>();
builder.Services.AddTransient<IQuery.Write.IDocumentoFiscalOriginarioQueryWrite, Query.Write.DocumentoFiscalOriginarioQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertDocumentoFiscalOriginarioReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateDocumentoFiscalOriginarioReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteDocumentoFiscalOriginarioReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.DocumentoFiscalOriginarioReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.DocumentoFiscalOriginarioReadFKDocumentoFiscalIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.DocumentoFiscalOriginarioReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.DocumentoFiscalOriginarioReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.INFeProdutoSnapshotWriteRepository, Input.Repository.NFeProdutoSnapshot.NFeProdutoSnapshotWriteRepository>();
builder.Services.AddTransient<IRepository.Read.INFeProdutoSnapshotReadRepository, Read.Repository.NFeProdutoSnapshotReadRepository>();
builder.Services.AddTransient<IQuery.Read.INFeProdutoSnapshotQueryRead, Query.Read.NFeProdutoSnapshotQueryRead>();
builder.Services.AddTransient<IQuery.Write.INFeProdutoSnapshotQueryWrite, Query.Write.NFeProdutoSnapshotQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertNFeProdutoSnapshotReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateNFeProdutoSnapshotReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteNFeProdutoSnapshotReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.NFeProdutoSnapshotReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.NFeProdutoSnapshotReadFKDocumentoFiscalOriginarioIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.NFeProdutoSnapshotReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.NFeProdutoSnapshotReadFKUserIdReceiver>();

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
builder.Services.AddTransient<Command.Receivers.Read.CTeDocumentoOriginarioReadFKDocumentoFiscalOriginarioIdReceiver>();
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

builder.Services.AddTransient<IRepository.Write.IMDFeSolicitacaoFiscalWriteRepository, Input.Repository.MDFeSolicitacaoFiscal.MDFeSolicitacaoFiscalWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IMDFeSolicitacaoFiscalReadRepository, Read.Repository.MDFeSolicitacaoFiscalReadRepository>();
builder.Services.AddTransient<IQuery.Read.IMDFeSolicitacaoFiscalQueryRead, Query.Read.MDFeSolicitacaoFiscalQueryRead>();
builder.Services.AddTransient<IQuery.Write.IMDFeSolicitacaoFiscalQueryWrite, Query.Write.MDFeSolicitacaoFiscalQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertMDFeSolicitacaoFiscalReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateMDFeSolicitacaoFiscalReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteMDFeSolicitacaoFiscalReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MDFeSolicitacaoFiscalReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MDFeSolicitacaoFiscalReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MDFeSolicitacaoFiscalReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IMDFeDocumentoOriginarioWriteRepository, Input.Repository.MDFeDocumentoOriginario.MDFeDocumentoOriginarioWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IMDFeDocumentoOriginarioReadRepository, Read.Repository.MDFeDocumentoOriginarioReadRepository>();
builder.Services.AddTransient<IQuery.Read.IMDFeDocumentoOriginarioQueryRead, Query.Read.MDFeDocumentoOriginarioQueryRead>();
builder.Services.AddTransient<IQuery.Write.IMDFeDocumentoOriginarioQueryWrite, Query.Write.MDFeDocumentoOriginarioQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertMDFeDocumentoOriginarioReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateMDFeDocumentoOriginarioReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteMDFeDocumentoOriginarioReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MDFeDocumentoOriginarioReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MDFeDocumentoOriginarioReadFKMDFeSolicitacaoFiscalIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MDFeDocumentoOriginarioReadFKDocumentoFiscalOriginarioIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MDFeDocumentoOriginarioReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MDFeDocumentoOriginarioReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IMDFePercursoWriteRepository, Input.Repository.MDFePercurso.MDFePercursoWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IMDFePercursoReadRepository, Read.Repository.MDFePercursoReadRepository>();
builder.Services.AddTransient<IQuery.Read.IMDFePercursoQueryRead, Query.Read.MDFePercursoQueryRead>();
builder.Services.AddTransient<IQuery.Write.IMDFePercursoQueryWrite, Query.Write.MDFePercursoQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertMDFePercursoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateMDFePercursoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteMDFePercursoReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MDFePercursoReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MDFePercursoReadFKMDFeSolicitacaoFiscalIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MDFePercursoReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MDFePercursoReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IMDFeVeiculoWriteRepository, Input.Repository.MDFeVeiculo.MDFeVeiculoWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IMDFeVeiculoReadRepository, Read.Repository.MDFeVeiculoReadRepository>();
builder.Services.AddTransient<IQuery.Read.IMDFeVeiculoQueryRead, Query.Read.MDFeVeiculoQueryRead>();
builder.Services.AddTransient<IQuery.Write.IMDFeVeiculoQueryWrite, Query.Write.MDFeVeiculoQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertMDFeVeiculoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateMDFeVeiculoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteMDFeVeiculoReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MDFeVeiculoReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MDFeVeiculoReadFKMDFeSolicitacaoFiscalIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MDFeVeiculoReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MDFeVeiculoReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IMDFeCondutorWriteRepository, Input.Repository.MDFeCondutor.MDFeCondutorWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IMDFeCondutorReadRepository, Read.Repository.MDFeCondutorReadRepository>();
builder.Services.AddTransient<IQuery.Read.IMDFeCondutorQueryRead, Query.Read.MDFeCondutorQueryRead>();
builder.Services.AddTransient<IQuery.Write.IMDFeCondutorQueryWrite, Query.Write.MDFeCondutorQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertMDFeCondutorReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateMDFeCondutorReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteMDFeCondutorReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MDFeCondutorReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MDFeCondutorReadFKMDFeSolicitacaoFiscalIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MDFeCondutorReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MDFeCondutorReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IMDFeTentativaEmissaoWriteRepository, Input.Repository.MDFeTentativaEmissao.MDFeTentativaEmissaoWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IMDFeTentativaEmissaoReadRepository, Read.Repository.MDFeTentativaEmissaoReadRepository>();
builder.Services.AddTransient<IQuery.Read.IMDFeTentativaEmissaoQueryRead, Query.Read.MDFeTentativaEmissaoQueryRead>();
builder.Services.AddTransient<IQuery.Write.IMDFeTentativaEmissaoQueryWrite, Query.Write.MDFeTentativaEmissaoQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertMDFeTentativaEmissaoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateMDFeTentativaEmissaoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteMDFeTentativaEmissaoReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MDFeTentativaEmissaoReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MDFeTentativaEmissaoReadFKMDFeSolicitacaoFiscalIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MDFeTentativaEmissaoReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.MDFeTentativaEmissaoReadFKUserIdReceiver>();

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

builder.Services.AddTransient<IRepository.Write.ISefazEndpointWriteRepository, Input.Repository.SefazEndpoint.SefazEndpointWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ISefazEndpointReadRepository, Read.Repository.SefazEndpointReadRepository>();
builder.Services.AddTransient<IQuery.Read.ISefazEndpointQueryRead, Query.Read.SefazEndpointQueryRead>();
builder.Services.AddTransient<IQuery.Write.ISefazEndpointQueryWrite, Query.Write.SefazEndpointQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertSefazEndpointReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateSefazEndpointReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteSefazEndpointReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.SefazEndpointReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.SefazEndpointReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.SefazEndpointReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.ICertificadoDigitalWriteRepository, Input.Repository.CertificadoDigital.CertificadoDigitalWriteRepository>();
builder.Services.AddTransient<IRepository.Read.ICertificadoDigitalReadRepository, Read.Repository.CertificadoDigitalReadRepository>();
builder.Services.AddTransient<IQuery.Read.ICertificadoDigitalQueryRead, Query.Read.CertificadoDigitalQueryRead>();
builder.Services.AddTransient<IQuery.Write.ICertificadoDigitalQueryWrite, Query.Write.CertificadoDigitalQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertCertificadoDigitalReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateCertificadoDigitalReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteCertificadoDigitalReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CertificadoDigitalReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CertificadoDigitalReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.CertificadoDigitalReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IEntradaFiscalContingenciaWriteRepository, Input.Repository.EntradaFiscalContingencia.EntradaFiscalContingenciaWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IEntradaFiscalContingenciaReadRepository, Read.Repository.EntradaFiscalContingenciaReadRepository>();
builder.Services.AddTransient<IQuery.Read.IEntradaFiscalContingenciaQueryRead, Query.Read.EntradaFiscalContingenciaQueryRead>();
builder.Services.AddTransient<IQuery.Write.IEntradaFiscalContingenciaQueryWrite, Query.Write.EntradaFiscalContingenciaQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertEntradaFiscalContingenciaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateEntradaFiscalContingenciaReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteEntradaFiscalContingenciaReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.EntradaFiscalContingenciaReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.EntradaFiscalContingenciaReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.EntradaFiscalContingenciaReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IEmissaoFiscalTransporteWriteRepository, Input.Repository.EmissaoFiscalTransporte.EmissaoFiscalTransporteWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IEmissaoFiscalTransporteReadRepository, Read.Repository.EmissaoFiscalTransporteReadRepository>();
builder.Services.AddTransient<IQuery.Read.IEmissaoFiscalTransporteQueryRead, Query.Read.EmissaoFiscalTransporteQueryRead>();
builder.Services.AddTransient<IQuery.Write.IEmissaoFiscalTransporteQueryWrite, Query.Write.EmissaoFiscalTransporteQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertEmissaoFiscalTransporteReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateEmissaoFiscalTransporteReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteEmissaoFiscalTransporteReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.EmissaoFiscalTransporteReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.EmissaoFiscalTransporteReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.EmissaoFiscalTransporteReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IContingenciaFiscalWriteRepository, Input.Repository.ContingenciaFiscal.ContingenciaFiscalWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IContingenciaFiscalReadRepository, Read.Repository.ContingenciaFiscalReadRepository>();
builder.Services.AddTransient<IQuery.Read.IContingenciaFiscalQueryRead, Query.Read.ContingenciaFiscalQueryRead>();
builder.Services.AddTransient<IQuery.Write.IContingenciaFiscalQueryWrite, Query.Write.ContingenciaFiscalQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertContingenciaFiscalReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateContingenciaFiscalReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteContingenciaFiscalReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ContingenciaFiscalReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ContingenciaFiscalReadFKEmissaoFiscalTransporteIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ContingenciaFiscalReadFKEntradaFiscalContingenciaIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ContingenciaFiscalReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.ContingenciaFiscalReadFKUserIdReceiver>();

builder.Services.AddTransient<IRepository.Write.IEmissaoFiscalTransporteDocumentoWriteRepository, Input.Repository.EmissaoFiscalTransporteDocumento.EmissaoFiscalTransporteDocumentoWriteRepository>();
builder.Services.AddTransient<IRepository.Read.IEmissaoFiscalTransporteDocumentoReadRepository, Read.Repository.EmissaoFiscalTransporteDocumentoReadRepository>();
builder.Services.AddTransient<IQuery.Read.IEmissaoFiscalTransporteDocumentoQueryRead, Query.Read.EmissaoFiscalTransporteDocumentoQueryRead>();
builder.Services.AddTransient<IQuery.Write.IEmissaoFiscalTransporteDocumentoQueryWrite, Query.Write.EmissaoFiscalTransporteDocumentoQueryWrite>();
builder.Services.AddTransient<Command.Receivers.Write.InsertEmissaoFiscalTransporteDocumentoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.UpdateEmissaoFiscalTransporteDocumentoReceiver>();
builder.Services.AddTransient<Command.Receivers.Write.DeleteEmissaoFiscalTransporteDocumentoReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.EmissaoFiscalTransporteDocumentoReadReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.EmissaoFiscalTransporteDocumentoReadFKEmissaoFiscalTransporteIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.EmissaoFiscalTransporteDocumentoReadFKDocumentoFiscalIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.EmissaoFiscalTransporteDocumentoReadFKDocumentoFiscalOriginarioIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.EmissaoFiscalTransporteDocumentoReadFKNFeProdutoSnapshotIdReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.EmissaoFiscalTransporteDocumentoReadFKTenantIDReceiver>();
builder.Services.AddTransient<Command.Receivers.Read.EmissaoFiscalTransporteDocumentoReadFKUserIdReceiver>();

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
builder.Services.AddTransient<Dominio.Saga.EmissaoFiscalCargaStandardSaga>();
builder.Services.AddTransient<Command.Receivers.EmissaoFiscalCargaStandardSagaHandlerResolver>();
builder.Services.AddTransient<ReceberCargaProntaParaEmissaoFiscalHandler>();
builder.Services.AddTransient<AguardarDocumentosOriginariosDaCargaHandler>();
builder.Services.AddTransient<PrepararEntradaFiscalDaCargaHandler>();
builder.Services.AddTransient<MontarSolicitacoesCTeHandler>();
builder.Services.AddTransient<PrepararCTeHandler>();
builder.Services.AddTransient<AutorizarCTeNaSefazHandler>();
builder.Services.AddTransient<PublicarCTeAutorizadoParaMDFeHandler>();
builder.Services.AddTransient<MontarSolicitacaoMDFeHandler>();
builder.Services.AddTransient<PrepararMDFeHandler>();
builder.Services.AddTransient<AutorizarMDFeNaSefazHandler>();
builder.Services.AddTransient<PublicarDocumentosFiscaisDaCargaConcluidosHandler>();
builder.Services.AddTransient<Dominio.Saga.ContingenciaFiscalStandardSaga>();
builder.Services.AddTransient<Command.Receivers.ContingenciaFiscalStandardSagaHandlerResolver>();
builder.Services.AddTransient<ReceberNotasFiscaisDaContingenciaHandler>();
builder.Services.AddTransient<AnalisarNotasFiscaisDaContingenciaHandler>();
builder.Services.AddTransient<EscolherModeloAgrupamentoCTeHandler>();
builder.Services.AddTransient<SimularAgrupamentoCTeHandler>();
builder.Services.AddTransient<InformarFreteERateioHandler>();
builder.Services.AddTransient<SimularRateioFreteHandler>();
builder.Services.AddTransient<InformarDadosTransporteHandler>();
builder.Services.AddTransient<ValidarPlanoEmissaoFiscalHandler>();
builder.Services.AddTransient<ConfirmarPlanoEmissaoFiscalHandler>();
builder.Services.AddTransient<PublicarPlanoParaSagaFiscalHandler>();
builder.Services.AddTransient<AguardarResultadoEmissaoFiscalHandler>();
builder.Services.AddTransient<FinalizarContingenciaFiscalHandler>();
builder.Services.AddTransient<Dominio.Saga.EncerramentoMDFeStandardSaga>();
builder.Services.AddTransient<Command.Receivers.EncerramentoMDFeStandardSagaHandlerResolver>();
builder.Services.AddTransient<SolicitarEncerramentoMDFeHandler>();
builder.Services.AddTransient<PrepararEventoEncerramentoMDFeHandler>();
builder.Services.AddTransient<AutorizarEncerramentoMDFeNaSefazHandler>();
builder.Services.AddTransient<PublicarMDFeEncerradoHandler>();
builder.Services.AddTransient<Dominio.Saga.TesteSyncSaga>();
builder.Services.AddTransient<Command.Receivers.TesteSyncSagaHandlerResolver>();
builder.Services.AddTransient<TesteSyncPasso1Handler>();
builder.Services.AddTransient<TesteSyncPasso2Handler>();
builder.Services.AddTransient<TesteSyncPasso3Handler>();
builder.Services.AddTransient<TesteSyncPasso4Handler>();
builder.Services.AddTransient<TesteSyncPasso5Handler>();

builder.Services.AddTransient<Command.Receivers.UseCase.ReceberNotasFiscaisProdutoHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.InformarDocumentosOriginariosDaCargaHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.IniciarContingenciaFiscalHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.IniciarSagaTesteSyncHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.ReceberRomaneioConsolidadoParaCTeHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.SolicitarEmissaoCTeHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.AutorizarCTeHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.PublicarCTeAutorizadoParaMDFeHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.SolicitarEmissaoMDFeHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.AutorizarMDFeHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.EncerrarMDFeHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.ValidarCertificadoDigitalHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.InformarNotasFiscaisContingenciaHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.EscolherModeloAgrupamentoCTeContingenciaHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.InformarFreteERateioContingenciaHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.InformarDadosTransporteContingenciaHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.ConfirmarPlanoEmissaoFiscalContingenciaHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.InformarResultadoEmissaoFiscalContingenciaHandler>();

builder.Services.AddTransient<Command.Receivers.UseCase.AcordarSagaTesteSyncPasso3Handler>();

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