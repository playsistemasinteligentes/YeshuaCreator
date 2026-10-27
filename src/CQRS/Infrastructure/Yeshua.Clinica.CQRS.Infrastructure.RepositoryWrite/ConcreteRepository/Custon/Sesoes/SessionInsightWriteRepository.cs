using Aplication.Interfaces.Services;
using IQuery.Write;
using RepositoryInterfaces.Patterns.UnitOfWork;
namespace Input.Repository.Sesoes;
public partial class SesoesWriteRepository
{
    private readonly IExecutionContext _insightContext = default!;
    public SesoesWriteRepository(IUnitOfWork unitOfWork, ISesoesQueryWrite query, IExecutionContext context)
        : this(unitOfWork, query) => _insightContext = context;
    public void ApplyInsight(int sessionId, string prontuario, string queixaPrincipal, string registroDocumental)
        => throw new InvalidOperationException("Resultados de IA são sugestões; utilize os Commands de revisão humana.");
    public void MarkInsightPending(int sessionId) { /* Upload não modifica o registro clínico. */ }
}
