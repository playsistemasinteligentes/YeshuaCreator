using Aplication.Interfaces.Services;
using System.Security.Claims;

namespace Shered.Services
{
    public class CurrentUserHttp : ICurrentUser
    {
        private int? _manualTenantId;

        private readonly IHttpContextAccessor _http;
        public CurrentUserHttp(IHttpContextAccessor http) => _http = http;

        public int TenantID => _manualTenantId ?? GetTenantId();

        public int UserId => int.Parse(_http.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
        public IEnumerable<Claim> Claims => _http.HttpContext?.User?.Claims ?? Enumerable.Empty<Claim>();

        public int GetTenantId()
        {

            var claim = _http.HttpContext?.User?.FindFirst("tenantId");
            if (claim == null) return 0;
            return int.TryParse(claim.Value, out var id) ? id : 0;
        }
        /// <summary>
        /// ⚠️ Método temporário para setar o TenantID manualmente.
        /// Use com extrema cautela e remova assim que possível.
        /// </summary>
        public void SetTenantId(int id)
        {
            _manualTenantId = id;
        }

    }
}
