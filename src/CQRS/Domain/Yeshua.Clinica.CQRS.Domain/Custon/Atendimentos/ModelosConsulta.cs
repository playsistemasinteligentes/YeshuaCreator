namespace Clinica.Modelos;

// IDs and versions are persisted by appointments. Never reinterpret an existing pair.
public static class ModelosConsulta
{
    public const int PsicologiaCompleta = 1;
    public const int RegistroSimplificado = 2;
    public const int VersaoAtual = 1;

    public static bool Suporta(int modelo, int versao = VersaoAtual) =>
        versao == VersaoAtual && modelo is PsicologiaCompleta or RegistroSimplificado;

    public static int Efetivo(int modelo) => modelo == 0 ? PsicologiaCompleta : modelo;
    public static int VersaoEfetiva(int versao) => versao == 0 ? VersaoAtual : versao;
}
