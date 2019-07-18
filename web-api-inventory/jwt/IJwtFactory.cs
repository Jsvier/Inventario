using System.Security.Claims;
using System.Threading.Tasks;

namespace web_api_inventory.jwt {
    public interface IJwtFactory {
        Task<string> GenerateEncodedToken (string userName, ClaimsIdentity identity);
        ClaimsIdentity GenerateClaimsIdentity (string userName, string id);
    }
}