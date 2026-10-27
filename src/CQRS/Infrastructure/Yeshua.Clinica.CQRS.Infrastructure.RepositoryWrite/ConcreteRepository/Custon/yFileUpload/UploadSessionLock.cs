namespace Input.Repository.yFileUpload;
public partial class yFileUploadWriteRepository
{
    public bool LockUploadForCurrentActor(int uploadId, int tenantId, int userId)
        => _UnitOfWork.ExecuteScalar<int>(@"SELECT Id FROM yFileUpload WITH (UPDLOCK, HOLDLOCK)
            WHERE Id = @Id AND TenantID = @TenantID AND UserId = @UserId AND Deleted = 0;",
            new { Id = uploadId, TenantID = tenantId, UserId = userId }) == uploadId;
}
