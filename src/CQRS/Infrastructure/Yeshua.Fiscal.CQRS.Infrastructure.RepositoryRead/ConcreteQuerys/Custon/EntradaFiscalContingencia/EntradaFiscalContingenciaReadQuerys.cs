// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration
// </yeshua>

//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration

using Command.Read;
using Dapper;
using Shered.DB;
using System;
using System.Collections.Generic;

namespace Query.Read
{
    internal static class EntradaFiscalContingenciaCaseSearchQuery
    {
        private const string SelectColumns = @"
select [Id], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente],
       [SourceApplication], [SourceModule], [SourceMessageId],
       [EmitenteFiscalDocumento], [TomadorDocumento], [TransportadorDocumento],
       [RemetenteDocumento], [DestinatarioDocumento], [UFInicio], [UFFim],
       [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [RNTRC],
       [PlacaVeiculo], [UFVeiculo], [CondutorDocumento], [CondutorNome],
       [QuantidadeDocumentos], [ValorCarga], [PesoBruto], [Volume],
       [PendenciasJson], [SnapshotJson], [EmissaoFiscalCorrelationId],
       [EmissaoFiscalSagaId], [CriadoEmUtc], [AtualizadoEmUtc], [Status],
       [OperationalEntityId], [TenantID], [Deleted], [Changed], [UserId],
       [CertificadoDigitalId]
from [EntradaFiscalContingencia]";

        public static QueryModel Page(EntradaFiscalContingenciaReadCommand command, int tenantId)
        {
            var parameters = BuildParameters(command, tenantId, out var where);
            var page = Math.Max(1, command.Paginacao?.Page ?? 1);
            var pageSize = Math.Clamp(command.Paginacao?.PageSize ?? 8, 1, 100);

            parameters.Add("Offset", (page - 1) * pageSize);
            parameters.Add("PageSize", pageSize);

            var sql = $"{SelectColumns}{where} order by [Id] offset @Offset rows fetch next @PageSize rows only";
            return new QueryModel(sql, parameters);
        }

        public static QueryModel Count(EntradaFiscalContingenciaReadCommand command, int tenantId)
        {
            var parameters = BuildParameters(command, tenantId, out var where);
            var sql = $"select count(1) from [EntradaFiscalContingencia]{where}";
            return new QueryModel(sql, parameters);
        }

        private static DynamicParameters BuildParameters(EntradaFiscalContingenciaReadCommand command, int tenantId, out string where)
        {
            var clauses = new List<string>
            {
                "[TenantID] = @TenantID",
                "[Deleted] = @Deleted"
            };

            var parameters = new DynamicParameters();
            parameters.Add("TenantID", tenantId);
            parameters.Add("Deleted", false);

            AddEquals(clauses, parameters, "Id", command.Id);
            AddLike(clauses, parameters, "CorrelationId", command.CorrelationId);
            AddLike(clauses, parameters, "CargaId", command.CargaId);
            AddEquals(clauses, parameters, "TipoSolicitante", command.TipoSolicitante);
            AddEquals(clauses, parameters, "Ambiente", command.Ambiente);
            AddLike(clauses, parameters, "SourceApplication", command.SourceApplication);
            AddLike(clauses, parameters, "SourceModule", command.SourceModule);
            AddLike(clauses, parameters, "SourceMessageId", command.SourceMessageId);
            AddLike(clauses, parameters, "EmitenteFiscalDocumento", command.EmitenteFiscalDocumento);
            AddLike(clauses, parameters, "TomadorDocumento", command.TomadorDocumento);
            AddLike(clauses, parameters, "TransportadorDocumento", command.TransportadorDocumento);
            AddLike(clauses, parameters, "RemetenteDocumento", command.RemetenteDocumento);
            AddLike(clauses, parameters, "DestinatarioDocumento", command.DestinatarioDocumento);
            AddLike(clauses, parameters, "UFInicio", command.UFInicio);
            AddLike(clauses, parameters, "UFFim", command.UFFim);
            AddLike(clauses, parameters, "MunicipioInicioCodigoIbge", command.MunicipioInicioCodigoIbge);
            AddLike(clauses, parameters, "MunicipioFimCodigoIbge", command.MunicipioFimCodigoIbge);
            AddLike(clauses, parameters, "RNTRC", command.RNTRC);
            AddLike(clauses, parameters, "PlacaVeiculo", command.PlacaVeiculo);
            AddLike(clauses, parameters, "UFVeiculo", command.UFVeiculo);
            AddLike(clauses, parameters, "CondutorDocumento", command.CondutorDocumento);
            AddLike(clauses, parameters, "CondutorNome", command.CondutorNome);
            AddEquals(clauses, parameters, "QuantidadeDocumentos", command.QuantidadeDocumentos);
            AddLike(clauses, parameters, "EmissaoFiscalCorrelationId", command.EmissaoFiscalCorrelationId);
            AddEquals(clauses, parameters, "EmissaoFiscalSagaId", command.EmissaoFiscalSagaId);
            AddEquals(clauses, parameters, "Status", command.Status);
            AddLike(clauses, parameters, "OperationalEntityId", command.OperationalEntityId);
            AddEquals(clauses, parameters, "UserId", command.UserId);
            AddEquals(clauses, parameters, "CertificadoDigitalId", command.CertificadoDigitalId);

            if (command.CriadoEmUtc.HasValue)
            {
                parameters.Add("CriadoEmUtcInicio", command.CriadoEmUtc.Value.Date);
                clauses.Add("[CriadoEmUtc] >= @CriadoEmUtcInicio");
            }

            if (command.AtualizadoEmUtc.HasValue)
            {
                parameters.Add("CriadoEmUtcFim", command.AtualizadoEmUtc.Value.Date.AddDays(1));
                clauses.Add("[CriadoEmUtc] < @CriadoEmUtcFim");
            }

            where = $" where {string.Join(" and ", clauses)}";
            return parameters;
        }

        private static void AddEquals<T>(List<string> clauses, DynamicParameters parameters, string field, T? value)
            where T : struct
        {
            if (!value.HasValue)
                return;

            parameters.Add(field, value.Value);
            clauses.Add($"[{field}] = @{field}");
        }

        private static void AddLike(List<string> clauses, DynamicParameters parameters, string field, string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return;

            parameters.Add(field, $"%{value.Trim()}%");
            clauses.Add($"[{field}] like @{field}");
        }
    }
}
