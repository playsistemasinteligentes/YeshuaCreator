namespace IRepository.Write;
public partial interface IyFileUploadWriteRepository
{
    bool LockUploadForCurrentActor(int uploadId, int tenantId, int userId);
}
