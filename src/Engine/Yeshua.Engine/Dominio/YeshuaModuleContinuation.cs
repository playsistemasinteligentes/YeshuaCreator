namespace Dominio
{
    public class YeshuaModuleContinuation
    {
        public string SourceModule { get; set; } = string.Empty;
        public string SourceSaga { get; set; } = string.Empty;
        public string SourceStep { get; set; } = string.Empty;
        public string Contract { get; set; } = string.Empty;
        public int ContractVersion { get; set; }
        public string TargetModule { get; set; } = string.Empty;
        public string TargetSaga { get; set; } = string.Empty;
        public bool Required { get; set; } = true;
        public string Direction { get; set; } = string.Empty;
    }
}
