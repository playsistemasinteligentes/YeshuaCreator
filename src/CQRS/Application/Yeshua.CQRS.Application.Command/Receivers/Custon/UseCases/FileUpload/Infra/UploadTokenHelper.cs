using System.Security.Cryptography;
using System.Text;

namespace Command.Receivers.Custon.UseCases.FileUpload.Infra
{
    public static class UploadTokenHelper
    {
        private const string Secret = "SUPER_SECRET_UPLOAD_KEY_CHANGE_THIS";

        public static string Generate(int uploadId, int userId, int tenantId)
        {
            var expires = DateTimeOffset.UtcNow.AddHours(2).ToUnixTimeSeconds();

            var payload = $"{uploadId}:{userId}:{tenantId}:{expires}";

            using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(Secret));

            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(payload));

            var signature = Convert.ToBase64String(hash);

            var token = $"{payload}:{signature}";

            return Convert.ToBase64String(Encoding.UTF8.GetBytes(token));
        }

        public static (int uploadId, int userId, int tenantId) ValidateAndExtract(string token)
        {
            var decoded = Encoding.UTF8.GetString(Convert.FromBase64String(token));

            var parts = decoded.Split(':');

            if (parts.Length != 5)
                throw new Exception("Token inválido");

            var uploadId = int.Parse(parts[0]);
            var userId = int.Parse(parts[1]);
            var tenantId = int.Parse(parts[2]);
            var expires = long.Parse(parts[3]);
            var signature = parts[4];

            var payload = $"{uploadId}:{userId}:{tenantId}:{expires}";

            using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(Secret));

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(payload));

            var computedSignature = Convert.ToBase64String(computedHash);

            if (signature != computedSignature)
                throw new Exception("Assinatura inválida");

            if (DateTimeOffset.UtcNow.ToUnixTimeSeconds() > expires)
                throw new Exception("Token expirado");

            return (uploadId, userId, tenantId);
        }
    }
}