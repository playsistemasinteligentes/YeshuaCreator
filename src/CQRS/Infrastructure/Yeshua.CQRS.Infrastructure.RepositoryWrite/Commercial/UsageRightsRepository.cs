using System.Security.Cryptography;
using System.Text;
using Aplication.Interfaces.Services;
using Dominio.Commercial;
using RepositoryInterfaces.Commercial;
using RepositoryInterfaces.Patterns.UnitOfWork;

namespace Shared.Repository.Commercial;

public sealed class UsageRightsRepository(IUnitOfWork work, IExecutionContext context) : IUsageRightsRepository
{
    public void Synchronize(IReadOnlyList<UsageRight> rights)
    {
        if (context.TenantID <= 0) throw new InvalidOperationException("Tenant obrigatorio.");
        foreach (var right in rights)
        {
            work.Execute(@"MERGE yUsageRight WITH(HOLDLOCK) AS target
                USING (SELECT @Id AS Id) AS source ON target.Id=source.Id
                WHEN MATCHED AND target.TenantID=@TenantID THEN UPDATE SET
                    PeriodUntilUtc=CASE WHEN target.PeriodUntilUtc IS NULL OR target.PeriodUntilUtc<@Until
                        THEN @Until ELSE target.PeriodUntilUtc END,
                    GrantedUnits=CASE WHEN target.GrantedUnits<@Units THEN @Units ELSE target.GrantedUnits END,
                    Changed=SYSUTCDATETIME()
                WHEN NOT MATCHED THEN INSERT
                    (Id,ResourceKey,PeriodUntilUtc,GrantedUnits,ReservedUnits,ConsumedUnits,TenantID,UserId,Deleted,Changed,OperationalEntityId)
                    VALUES(@Id,@Resource,@Until,@Units,0,0,@TenantID,@UserId,0,SYSUTCDATETIME(),@OperationalEntityId);",
                new { Id = Key(right.Resource), Resource = right.Resource,
                    Until = right.Until > 0 ? (DateTime?)DateTimeOffset.FromUnixTimeSeconds(right.Until).UtcDateTime : null,
                    Units = right.GrantedUnits, TenantID = context.TenantID, UserId = context.UserId,
                    OperationalEntityId = Guid.NewGuid().ToString("N") });
        }
    }

    public bool Reserve(string resource, string operationId, decimal units)
    {
        if (units <= 0 || string.IsNullOrWhiteSpace(operationId) || operationId.Length > 100)
            throw new ArgumentException("Consumo invalido.");
        return work.ExecuteScalar<bool>(@"DECLARE @OwnTransaction bit=CASE WHEN @@TRANCOUNT=0 THEN 1 ELSE 0 END;
            IF @OwnTransaction=1 BEGIN TRANSACTION;
            BEGIN TRY
                DECLARE @Until datetime,@Available decimal(18,4),@Existing int,@UsesPeriod bit=0,@Allowed bit=0;
                SELECT @Until=PeriodUntilUtc,@Available=GrantedUnits-ReservedUnits-ConsumedUnits
                    FROM yUsageRight WITH(UPDLOCK,HOLDLOCK) WHERE Id=@RightId AND TenantID=@TenantID AND Deleted=0;
                SELECT @Existing=Status FROM yUsageConsumption WITH(UPDLOCK,HOLDLOCK) WHERE Id=@Id AND TenantID=@TenantID;
                DECLARE @Now datetime2=SYSUTCDATETIME();
                IF @Existing IN(0,1) SET @Allowed=1;
                ELSE IF @Until>@Now OR @Available>=@Units
                BEGIN
                    SET @Allowed=1;
                    IF @Until>@Now SET @UsesPeriod=1;
                    IF @UsesPeriod=0 UPDATE yUsageRight SET ReservedUnits=ReservedUnits+@Units,Changed=SYSUTCDATETIME()
                        WHERE Id=@RightId AND TenantID=@TenantID;
                    IF @Existing IS NOT NULL UPDATE yUsageConsumption SET Status=0,UsesPeriod=@UsesPeriod,Units=@Units,
                        Changed=SYSUTCDATETIME() WHERE Id=@Id AND TenantID=@TenantID;
                    ELSE INSERT INTO yUsageConsumption
                        (Id,ResourceKey,OperationId,Units,UsesPeriod,Status,TenantID,UserId,Deleted,Changed,OperationalEntityId)
                        VALUES(@Id,@Resource,@OperationId,@Units,@UsesPeriod,0,@TenantID,@UserId,0,SYSUTCDATETIME(),@OperationalEntityId);
                END;
                IF @OwnTransaction=1 COMMIT TRANSACTION;
                SELECT @Allowed;
            END TRY
            BEGIN CATCH
                IF @OwnTransaction=1 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION;
                THROW;
            END CATCH;", Parameters(resource, operationId, units));
    }

    public void Confirm(string resource, string operationId) => Finish(resource, operationId, true);
    public void Release(string resource, string operationId) => Finish(resource, operationId, false);

    private void Finish(string resource, string operationId, bool confirmed)
    {
        var parameters = Parameters(resource, operationId, 0);
        work.Execute(@"DECLARE @OwnTransaction bit=CASE WHEN @@TRANCOUNT=0 THEN 1 ELSE 0 END;
            IF @OwnTransaction=1 BEGIN TRANSACTION;
            BEGIN TRY
                DECLARE @GrantExists bit=0,@Existing int,@UsesPeriod bit,@Quantity decimal(18,4);
                SELECT @GrantExists=1 FROM yUsageRight WITH(UPDLOCK,HOLDLOCK) WHERE Id=@RightId AND TenantID=@TenantID;
                SELECT @Existing=Status,@UsesPeriod=UsesPeriod,@Quantity=Units FROM yUsageConsumption WITH(UPDLOCK,HOLDLOCK)
                    WHERE Id=@Id AND TenantID=@TenantID;
                IF @Existing=0
                BEGIN
                    IF @UsesPeriod=0
                    BEGIN
                        UPDATE yUsageRight SET ReservedUnits=ReservedUnits-@Quantity,
                            ConsumedUnits=ConsumedUnits+CASE WHEN @Confirmed=1 THEN @Quantity ELSE 0 END,Changed=SYSUTCDATETIME()
                            WHERE Id=@RightId AND TenantID=@TenantID AND ReservedUnits>=@Quantity;
                        IF @@ROWCOUNT<>1 THROW 50001,'Reserva de uso inconsistente.',1;
                    END;
                    UPDATE yUsageConsumption SET Status=CASE WHEN @Confirmed=1 THEN 1 ELSE 2 END,Changed=SYSUTCDATETIME()
                        WHERE Id=@Id AND TenantID=@TenantID AND Status=0;
                END;
                IF @OwnTransaction=1 COMMIT TRANSACTION;
            END TRY
            BEGIN CATCH
                IF @OwnTransaction=1 AND @@TRANCOUNT>0 ROLLBACK TRANSACTION;
                THROW;
            END CATCH;", new { parameters.Id, parameters.RightId, parameters.TenantID, Confirmed = confirmed });
    }

    private ConsumptionParameters Parameters(string resource, string operationId, decimal units)
    {
        if (context.TenantID <= 0) throw new InvalidOperationException("Tenant obrigatorio.");
        return new(Key(resource + ":" + operationId), Key(resource), resource, operationId, units, context.TenantID, context.UserId,
            Guid.NewGuid().ToString("N"));
    }
    private string Key(string value) => Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(context.TenantID + ":" + value)));
    private sealed record ConsumptionParameters(string Id, string RightId, string Resource, string OperationId, decimal Units,
        int TenantID, int UserId, string OperationalEntityId);
}
