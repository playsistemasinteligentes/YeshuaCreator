using Aplication.Interfaces.Services;
using System.Security.Claims;

namespace Worker.Custon
{
    public class CurrentUser : ICurrentUser
    {
        private int _tenantId = 1;
        private int _userId = 1;

        public int UserId => _userId;

        public int TenantID => _tenantId;

        public IEnumerable<Claim> Claims => Enumerable.Empty<Claim>();

        public void SetTenantId(int id)
        {
            _tenantId = id;
        }

        // opcional (se quiser simular usuário)
        public void SetUserId(int id)
        {
            _userId = id;
        }
    }
}
