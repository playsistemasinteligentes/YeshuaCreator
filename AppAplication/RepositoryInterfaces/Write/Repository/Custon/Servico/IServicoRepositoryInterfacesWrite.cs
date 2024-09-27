// 
public partial interface  Servico
{
    public int Id { get; set; }
    public int GrupoServicoId { get; set; }
    public string Nome { get; set; }
    public Decimal Valor { get; set; }
}
