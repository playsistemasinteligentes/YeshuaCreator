public class JwtSettings
{
    public string SecretKey { get; set; } = string.Empty;
    public int ExpirationMinutes { get; set; } = 21600; // 15 dias corridos, em minutos.
}
