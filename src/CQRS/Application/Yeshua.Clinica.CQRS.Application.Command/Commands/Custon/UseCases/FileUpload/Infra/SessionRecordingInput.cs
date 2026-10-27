namespace Command.UseCase;
public partial record StarSessionUploadInputCommand
{
    public string Finalidade { get; set; } = "relato";
    public bool Autorizado { get; set; }
}
