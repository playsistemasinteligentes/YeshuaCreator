using Clinica.Atendimentos;
namespace Read.Repository;
public partial class ClinicaReadRepository
{
    public bool ConfiguracaoEstaPronta()=>_unitOfWork.Query<int>(@"SELECT f.Id FROM Profissional f
        JOIN Servico s ON s.Id=f.ServicoHabitualId AND s.TenantID=f.TenantID AND s.Deleted=0
        WHERE f.TenantID=@Tenant AND f.UsuarioAcessoId=@Actor AND f.Deleted=0 AND ISNULL(NULLIF(s.ModeloConsulta,0),1) IN(1,2)
        AND EXISTS(SELECT 1 FROM Clinica WHERE TenantID=@Tenant AND Deleted=0)",
        new{Tenant=_executionContext.TenantID,Actor=_executionContext.UserId}).ToList().Count==1;
    public ConfiguracaoOpcoes ConsultarOpcoesConfiguracao()
    {
        var args=new{Tenant=_executionContext.TenantID,Actor=_executionContext.UserId};
        var result=new ConfiguracaoOpcoes {
            Clinicas=_unitOfWork.Query<ClinicaInicialInfo>(@"SELECT TOP(101) Id,Nome,Endereco,Telefone,ISNULL(TipoEstrutura,1) TipoEstrutura
                FROM Clinica WHERE TenantID=@Tenant AND Deleted=0 ORDER BY Nome,Id",args).ToList(),
            Profissionais=_unitOfWork.Query<ProfissionalInicialInfo>(@"SELECT TOP(101) Id,Nome,Telefone,
                CAST(CASE WHEN UsuarioAcessoId=@Actor THEN 1 ELSE 0 END AS bit) Vinculado FROM Profissional
                WHERE TenantID=@Tenant AND Deleted=0 AND (UsuarioAcessoId IS NULL OR UsuarioAcessoId=@Actor) ORDER BY Nome,Id",args).ToList(),
            Servicos=_unitOfWork.Query<ServicoInicialInfo>(@"SELECT TOP(501) Id,Nome,Valor,ISNULL(NULLIF(ModeloConsulta,0),1) ModeloConsulta
                FROM Servico WHERE TenantID=@Tenant AND Deleted=0 AND ISNULL(NULLIF(ModeloConsulta,0),1) IN(1,2) ORDER BY Nome,Id",args).ToList()
        };
        if(result.Clinicas.Count>100||result.Profissionais.Count>100||result.Servicos.Count>500)
            throw new AtendimentoException("O cadastro excede o limite do assistente inicial. Solicite a configuração ao administrador.",409);
        return result;
    }
}
