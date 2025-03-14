public class JwtSettings
{
    public string SecretKey { get; set; } = "sua-chave-secreta-bem-forte-sua-chave-secreta-bem-forte-sua-chave-secreta-bem-forte-sua-chave-secreta-bem-forte";
    public int ExpirationMinutes { get; set; } = 1000;
}