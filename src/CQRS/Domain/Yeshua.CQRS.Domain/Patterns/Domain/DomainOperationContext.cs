using System;

namespace Dominio.Patterns.Domain
{
    public sealed class DomainOperationContext
    {
        private DomainOperationContext(
            DomainOperation operation,
            DomainEntryPoint entryPoint,
            string intent,
            int? tenantId,
            int? userId,
            bool trustedSource,
            bool legacyMigration,
            string? traceId,
            string? receiverName,
            string? commandName,
            string? recordId,
            DateTime occurredAt)
        {
            Operation = operation;
            EntryPoint = entryPoint;
            Intent = intent;
            TenantId = tenantId;
            UserId = userId;
            TrustedSource = trustedSource;
            LegacyMigration = legacyMigration;
            TraceId = traceId;
            ReceiverName = receiverName;
            CommandName = commandName;
            RecordId = recordId;
            OccurredAt = occurredAt;
        }

        public DomainOperation Operation { get; }
        public DomainEntryPoint EntryPoint { get; }
        public string Intent { get; }
        public int? TenantId { get; }
        public int? UserId { get; }
        public bool TrustedSource { get; }
        public bool LegacyMigration { get; }
        public string? TraceId { get; }
        public string? ReceiverName { get; }
        public string? CommandName { get; }
        public string? RecordId { get; }
        public DateTime OccurredAt { get; }

        public static DomainOperationContext Create(
            DomainOperation operation,
            DomainEntryPoint entryPoint,
            string intent,
            int? tenantId = null,
            int? userId = null,
            bool trustedSource = false,
            bool legacyMigration = false,
            string? traceId = null,
            string? receiverName = null,
            string? commandName = null,
            string? recordId = null)
        {
            return new DomainOperationContext(
                operation,
                entryPoint,
                intent,
                tenantId,
                userId,
                trustedSource,
                legacyMigration,
                traceId,
                receiverName,
                commandName,
                recordId,
                DateTime.UtcNow);
        }
    }
}
