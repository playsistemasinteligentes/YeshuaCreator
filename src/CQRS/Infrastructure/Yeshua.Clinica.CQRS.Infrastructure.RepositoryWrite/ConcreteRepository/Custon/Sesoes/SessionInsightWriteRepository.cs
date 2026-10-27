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
    {
        var count = _UnitOfWork.Execute(@"UPDATE Sesoes
            SET Prontuario = @Prontuario, QueixaPrincipal = @QueixaPrincipal,
                RegistroDocumental = @RegistroDocumental, StatusProntuario = 3
            WHERE Id = @Id AND TenantID = @TenantID AND Deleted = 0;",
            new { Id = sessionId, TenantID = _insightContext.TenantID, Prontuario = prontuario,
                QueixaPrincipal = queixaPrincipal, RegistroDocumental = registroDocumental });
        if (count != 1) throw new InvalidOperationException("Sessao indisponivel no tenant atual.");
    }
    public void MarkInsightPending(int sessionId)
    {
        var count = _UnitOfWork.Execute(@"UPDATE Sesoes SET StatusProntuario = 2
            WHERE Id = @Id AND TenantID = @TenantID AND Deleted = 0;",
            new { Id = sessionId, TenantID = _insightContext.TenantID });
        if (count != 1) throw new InvalidOperationException("Sessao indisponivel no tenant atual.");
    }
}
