namespace IRepository.Write;
public partial interface ISesoesWriteRepository
{
    void ApplyInsight(int sessionId, string prontuario, string queixaPrincipal, string registroDocumental);
    void MarkInsightPending(int sessionId);
}
