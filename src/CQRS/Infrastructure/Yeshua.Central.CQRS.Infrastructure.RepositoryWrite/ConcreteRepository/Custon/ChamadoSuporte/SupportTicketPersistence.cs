using IRepository.Read;

namespace Input.Repository.ChamadoSuporte;

public partial class ChamadoSuporteWriteRepository
{
    public void Travar(string id, int tenantId, int userId)
        => _UnitOfWork.Query<string>(@"SELECT Id FROM ChamadoSuporte WITH(UPDLOCK,HOLDLOCK)
            WHERE Id=@Id AND TenantID=@TenantID AND UserId=@UserId AND Deleted=0;",
            new { Id = id, TenantID = tenantId, UserId = userId }).ToList();

    public void InserirRascunho(SupportTicketData ticket, int tenantId, int userId)
        => _UnitOfWork.Execute(@"INSERT INTO ChamadoSuporte
            (Id,Aplicativo,Modulo,Tela,TituloTela,Rota,Caminho,Versao,FusoHorario,MomentoClienteUtc,
             Assunto,Descricao,Status,CriadoEmUtc,AbertoEmUtc,TenantID,UserId,Deleted,Changed,OperationalEntityId)
            VALUES(@Id,@Aplicativo,@Modulo,@Tela,@TituloTela,@Rota,@Caminho,@Versao,@FusoHorario,@MomentoClienteUtc,
             '', '',0,SYSUTCDATETIME(),NULL,@TenantID,@UserId,0,SYSUTCDATETIME(),@OperationalEntityId);",
            new { ticket.Id, ticket.Aplicativo, ticket.Modulo, ticket.Tela, ticket.TituloTela, ticket.Rota,
                ticket.Caminho, ticket.Versao, ticket.FusoHorario, ticket.MomentoClienteUtc,
                TenantID = tenantId, UserId = userId, OperationalEntityId = Guid.NewGuid().ToString("N") });

    public bool Abrir(string id, string assunto, string descricao, int tenantId, int userId)
        => _UnitOfWork.Execute(@"UPDATE ChamadoSuporte SET Assunto=@Assunto,Descricao=@Descricao,
            Status=1,AbertoEmUtc=SYSUTCDATETIME(),Changed=SYSUTCDATETIME()
            WHERE Id=@Id AND TenantID=@TenantID AND UserId=@UserId AND Status=0 AND Deleted=0;",
            new { Id = id, Assunto = assunto, Descricao = descricao, TenantID = tenantId, UserId = userId }) == 1;
}
