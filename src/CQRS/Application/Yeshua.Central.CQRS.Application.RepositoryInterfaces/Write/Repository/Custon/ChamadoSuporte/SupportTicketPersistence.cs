using IRepository.Read;

namespace IRepository.Write;

public partial interface IChamadoSuporteWriteRepository
{
    void Travar(string id, int tenantId, int userId);
    void InserirRascunho(SupportTicketData ticket, int tenantId, int userId);
    bool Abrir(string id, string assunto, string descricao, int tenantId, int userId);
}
